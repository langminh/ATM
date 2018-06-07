using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using DTO;
using BUL;
using M_ATM.UC;
using M_ATM.UC.UC1;
using M_ATM.UC.UC2;
using M_ATM.UC.UC3;
using M_ATM.UC.UC4;
using M_ATM.UC.UC6;
using M_ATM.UC.UC5;

namespace M_ATM
{
    public partial class MainForm : Form
    {
        private static readonly string maMayATM = "ATM000001";

        //Delegate Define
        public delegate void ButonChagne(string name);
        public event ButonChagne btnChange;

        public delegate void DeleteText();
        public event DeleteText delete_Text;

        public delegate void ExitLogin();
        public event ExitLogin exit;

        public delegate void btnEnter();
        public event btnEnter btn_ok;

        //Local UC variable
        private Validation validation;
        private BeginUC beginUC;
        private MainUC main;
        private WithDraw withDraw;
        private BeingFinal_UC beingFinal;
        private WithDraw_Chosse draw_Chosse;
        private CheckBanlance checkBanlance;
        private ViewHistory viewHistory;
        private ChangePIN changePIN;
        private CardTranfer cardTranfer;
        private Final_UC final_UC;

        //Local variable
        private DanhsachtheATM ds;
        private Danhsachtaikhoan tk;
        private DanhsachKhachHang kh;
        private ATM thongTinMay;
        private List<LoaiTienTrongATM> danhSachLoaiTienTrongMay;
        private string mathe;

        private static double soLuongTien = 0;

        public MainForm()
        {
            InitializeComponent();

            thongTinMay = ATM_BUL.Instance.LayThongTinMayATM(maMayATM);
            danhSachLoaiTienTrongMay = LoaiTienTrongATM_BUL.Instance.DanhSachLoaiTien(maMayATM);

            foreach (var item in danhSachLoaiTienTrongMay)
            {
                soLuongTien += item.SoLuongMoiLoaiTien * LoaiTienTrongATM_BUL.Instance.LayMenhGiaTien(item.MaTien).GiaTriTien;
            }
            validation = new Validation(this);
            draw_Chosse = new WithDraw_Chosse(this);

            validation.login += Validation_login;
            validation.cancel += Validation_cancel;

            draw_Chosse.ok += Draw_Chosse_ok;

            beginUC = new BeginUC();
            beginUC.click += Main_click;
        }

        private void Validation_cancel()
        {
            mainPanel.Controls.Clear();
            mainPanel.Controls.Add(beginUC);
        }

        /// <summary>
        /// Lựa chọn số tiền nhập vào
        /// </summary>
        /// <param name="isContinue"></param>
        /// <param name="soTien"></param>
        private void Draw_Chosse_ok(bool isContinue, double soTien)
        {
            if (isContinue && soTien != -1)
            {
                if (DanhSachTaiKhoan_BUL.Instance.SoTienCoTrongTaiKhoan(tk.Mataikhoan) >= soTien)
                {
                    if (DanhSachTaiKhoan_BUL.Instance.RutTien(tk.Mataikhoan, soTien) > 0)
                    {
                        GhiGiaoDich ghi = new GhiGiaoDich();
                        ghi.Ngaygiaodich = DateTime.Now;
                        ghi.MoTaGD = "Rút tiền";
                        ghi.SoTheATM = ds.SoTheATM;
                        ghi.MaATM = thongTinMay.MaATM;
                        ghi.Malog = "Log01";
                        ghi.KhoanTienGD = soTien;
                        ghi.SotheATMnhanTien = "";

                        GhiGiaoDich_BUL.Instance.TaoMoiBanGhi(ghi);

                        mainPanel.Controls.Clear();
                        mainPanel.Controls.Add(final_UC);
                    }
                    else
                    {
                        MessageBox.Show("Đã xảy ra lỗi trong quá trình xử lý.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Số tiền trong tài khoản không đủ để thực hiện giao dịch", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                mainPanel.Controls.Clear();
                mainPanel.Controls.Add(main);
            }
        }


        /// <summary>
        /// Chọn số tiền mặc định trên máy
        /// </summary>
        /// <param name="money"></param>
        private void WithDraw_SetMoney(string money)
        {
            double soTien = 0;
            if (money.Equals("none"))
            {
                mainPanel.Controls.Clear();
                mainPanel.Controls.Add(draw_Chosse);
            }
            else
            {
                string[] temp_ = money.Split('.');
                money = string.Empty;
                for (int i = 0; i < temp_.Length; i++)
                {
                    money += temp_[i];
                }
                soTien = double.Parse(money);
                if (DanhSachTaiKhoan_BUL.Instance.SoTienCoTrongTaiKhoan(tk.Mataikhoan) >= soTien)
                {
                    if (DanhSachTaiKhoan_BUL.Instance.RutTien(tk.Mataikhoan, soTien) > 0)
                    {
                        GhiGiaoDich ghi = new GhiGiaoDich();
                        ghi.Ngaygiaodich = DateTime.Now;
                        ghi.MoTaGD = "Rút tiền";
                        ghi.SoTheATM = ds.SoTheATM;
                        ghi.MaATM = thongTinMay.MaATM;
                        ghi.Malog = "Log01";
                        ghi.KhoanTienGD = soTien;
                        ghi.SotheATMnhanTien = "";

                        GhiGiaoDich_BUL.Instance.TaoMoiBanGhi(ghi);

                        mainPanel.Controls.Clear();
                        mainPanel.Controls.Add(final_UC);
                    }
                    else
                    {
                        MessageBox.Show("Đã xảy ra lỗi trong quá trình xử lý.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Số tiền trong tài khoản không đủ để thực hiện giao dịch", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }


        /// <summary>
        /// Hiển thị use case rút tiền
        /// </summary>
        private void Main_rutten()
        {
            mainPanel.Controls.Clear();
            mainPanel.Controls.Add(withDraw);
        }


        /// <summary>
        /// Bắt sự kiện đăng nhập và khởi tạo các use case có liên quan
        /// </summary>
        /// <param name="isSuccess"></param>
        /// <param name="ds"></param>
        /// <param name="mathe"></param>
        private void Validation_login(bool isSuccess, DanhsachtheATM ds, string mathe)
        {
            if (isSuccess)
            {
                this.ds = ds;
                tk = DanhSachTaiKhoan_BUL.Instance.LayThongTinTaiKhoan(ds.Mataikhoan);
                kh = KhachHang_BUL.Instance.LayThongTinKhachHang(tk.Makhachhang);
                main = new MainUC(tk, kh);
                this.mathe = mathe;

                main.rutten += Main_rutten;
                main.checkBalance += Main_checkBalance;
                main.history += Main_history;
                main.changePIN += Main_changePIN;
                main.exit += Main_exit;
                main.cardTranfer += Main_cardTranfer;

                viewHistory = new ViewHistory(tk, kh, mathe, thongTinMay.MaATM);
                checkBanlance = new CheckBanlance(tk, kh, mathe, thongTinMay.MaATM);
                changePIN = new ChangePIN(mathe, thongTinMay.MaATM, this);
                withDraw = new WithDraw(tk, kh);
                beingFinal = new BeingFinal_UC(tk, kh);
                cardTranfer = new CardTranfer(tk, kh, mathe, thongTinMay.MaATM, this);
                final_UC = new Final_UC(tk, kh);

                withDraw.SetMoney += WithDraw_SetMoney;
                viewHistory.click += ViewHistory_click;
                checkBanlance.click += CheckBanlance_click;
                changePIN.ok += ChangePIN_ok;
                cardTranfer.tranfer += CardTranfer_tranfer;
                
                final_UC.click_Finish += Final_UC_click_Finish;

                mainPanel.Controls.Clear();
                mainPanel.Controls.Add(main);
            }
        }

        private void Main_cardTranfer()
        {
            mainPanel.Controls.Clear();
            mainPanel.Controls.Add(cardTranfer);
        }

        private void Main_exit()
        {
            if (exit != null)
            {
                exit();
            }
            mainPanel.Controls.Clear();
            mainPanel.Controls.Add(beginUC);
        }

        /// <summary>
        /// Sau khi kết thúc giao dịch rút tiền, lựa chọn trở về trang chính hoặc thoát
        /// </summary>
        /// <param name="isContinue"></param>
        private void Final_UC_click_Finish(bool isContinue)
        {
            if (isContinue)
            {
                mainPanel.Controls.Clear();
                mainPanel.Controls.Add(main);
            }
            else
            {
                mainPanel.Controls.Clear();
                mainPanel.Controls.Add(main);
            }
        }
        /// <summary>
        /// Sau khi kết thúc giao dịch chuyển tiền, lựa chọn trở về trang chính hoặc thoát
        /// </summary>
        /// <param name="isContinue"></param>
        private void CardTranfer_tranfer(bool isContinue)
        {
            if (isContinue)
            {
                mainPanel.Controls.Clear();
                mainPanel.Controls.Add(cardTranfer);
            }
            else
            {
                mainPanel.Controls.Clear();
                mainPanel.Controls.Add(main);
            }
        }

        /// <summary>
        /// Sau khi kết thúc giao dịch đổi mã pin, lựa chọn trở về trang chính hoặc thoát
        /// </summary>
        /// <param name="isContinue"></param>
        private void ChangePIN_ok(bool isContinue)
        {
            if (isContinue)
            {
                mainPanel.Controls.Clear();
                mainPanel.Controls.Add(main);
            }
            else
            {
                mainPanel.Controls.Clear();
                mainPanel.Controls.Add(beginUC);
            }
        }

        /// <summary>
        /// Hiển thị giao diện use case đổi mật khẩu
        /// </summary>
        /// <param name="isContinue"></param>
        private void Main_changePIN()
        {
            mainPanel.Controls.Clear();
            mainPanel.Controls.Add(changePIN);
        }

        /// <summary>
        /// Hiển thị giao diện lịch sử giao dịch
        /// </summary>
        private void Main_history()
        {
            mainPanel.Controls.Clear();
            mainPanel.Controls.Add(viewHistory);
        }


        /// <summary>
        /// Hiển thị giao diện vấn tin tài khoản
        /// </summary>
        private void Main_checkBalance()
        {
            checkBanlance.loadData(tk, kh, mathe, thongTinMay.MaATM);
            mainPanel.Controls.Clear();
            mainPanel.Controls.Add(checkBanlance);
        }

        /// <summary>
        /// Sau khi kết thúc usecase xem lịch sử giao dịch, lựa chọn trở về trang chính hoặc thoát
        /// </summary>
        /// <param name="isContinue"></param>
        private void ViewHistory_click(bool isContinue)
        {
            if (isContinue)
            {
                mainPanel.Controls.Clear();
                mainPanel.Controls.Add(main);
            }
            else
            {
                mainPanel.Controls.Clear();
                mainPanel.Controls.Add(main);
            }
        }

        /// <summary>
        /// Sau khi kết thúc usecase vấn tin tài khoản,lựa chọn trở về trang chính hoặc thoát
        /// </summary>
        /// <param name="isContinue"></param>
        private void CheckBanlance_click(bool isContinue)
        {
            if (isContinue)
            {
                mainPanel.Controls.Clear();
                mainPanel.Controls.Add(main);
            }
            else
            {
                mainPanel.Controls.Clear();
                mainPanel.Controls.Add(main);
            }
        }

        /// <summary>
        /// sự kiện khởi tạo màn hình đăng nhập hệ thống
        /// </summary>
        private void Main_click()
        {
            mainPanel.Controls.Clear();
            mainPanel.Controls.Add(validation);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            for (int i = 1; i < 13; i++)
            {
                if (i == 11)
                {
                    mainBtn.Controls.Add(InitButton(i, "0"));
                }
                else if (i == 10)
                {
                    mainBtn.Controls.Add(InitButton(i, "*"));
                }
                else if (i == 12)
                {
                    mainBtn.Controls.Add(InitButton(i, "#"));
                }
                else
                {
                    mainBtn.Controls.Add(InitButton(i, i.ToString()));
                }
            }

            mainPanel.Controls.Add(beginUC);
        }

        private Button InitButton(int n, string name)
        {
            Button b = new Button();
            b.Name = n.ToString();
            b.Width = 120;
            b.Height = 62;
            b.Text = name;
            b.Click += B_Click;
            return b;
        }

        private void B_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (btnChange != null)
            {
                btnChange(b.Text);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (delete_Text != null)
            {
                delete_Text();
            }
        }

        private void btnNhap_Click(object sender, EventArgs e)
        {
            if(btn_ok!= null)
            {
                btn_ok();
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            if (exit != null)
            {
                exit();
            }
            mainPanel.Controls.Clear();
            mainPanel.Controls.Add(main);
        }
    }
}
