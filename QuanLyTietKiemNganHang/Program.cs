using QuanLyTietKiemNganHang.Forms;
using System;
using System.Windows.Forms;

namespace QuanLyTietKiemNganHang
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FrmDangNhap());
        }
    }
}
