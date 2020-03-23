using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Net;
using System.Net.Mail;
using System.Drawing;
using System.Configuration;
using System.Data.SqlClient;
using belajarCRUDWPF.MyContext;

namespace belajarCRUDWPF
{
    /// <summary>
    /// Interaction logic for forgot.xaml
    /// </summary>
    public partial class forgot : Window
    {
        myContext connection = new myContext();
        public forgot()
        {
            InitializeComponent();
        }

        private void sendnewpass(string email, string password, string name)
        {
            MailMessage mm = new MailMessage("qwdqwf1@gmail.com", email);
            mm.Subject = "New Password To Login";
            mm.Body = string.Format("Hi {0},<br /><br />Your password is {1}.<br /><br />Thank You.", name, password);
            mm.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.EnableSsl = true;
            NetworkCredential NetworkCred = new NetworkCredential();
            NetworkCred.UserName = "qwdqwf1@gmail.com";
            NetworkCred.Password = "qweqweqwe";
            smtp.UseDefaultCredentials = true;
            smtp.Credentials = NetworkCred;
            smtp.Port = 587;
            try
            {
                smtp.Send(mm);
            }
            catch
            {

            }
        }

        private void btn_back_forgot_Click(object sender, RoutedEventArgs e)
        {
            loginregis loginpanel = new loginregis();
            this.Close(); ;
            loginpanel.Show();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }

        private void txt_login_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {

        }

        private void btn_login_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string password = System.Guid.NewGuid().ToString();
                var cmail = connection.Suppliers.Where(S => S.Email == txt_login.Text).FirstOrDefault();
                if (cmail == null)
                {
                    MessageBox.Show("Email Tidak Terdaftar");
                    txt_login.Focus();
                }
                else
                {
                    cmail.Password = password;
                    sendnewpass(cmail.Email, cmail.Password, cmail.Name);
                    connection.SaveChanges();
                    MessageBox.Show("Password Telah Terkirim Ke Email Anda");
                }
            }
            catch
            {

            }
        }
    }
}
