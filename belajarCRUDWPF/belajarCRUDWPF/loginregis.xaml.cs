using belajarCRUDWPF.MyContext;
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

namespace belajarCRUDWPF
{
    /// <summary>
    /// Interaction logic for loginregis.xaml
    /// </summary>
    public partial class loginregis : Window
    {
        myContext connection = new myContext();
        public loginregis()
        {
            InitializeComponent();
        }
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }

        private void btn_login_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var cmail = connection.Suppliers.Where(S => S.Email == txt_login.Text).FirstOrDefault();
                //var cpass = connection.Suppliers.Where(S => S.Password == txt_pass.TextInput).FirstOrDefault();
                if (cmail == null)
                {
                    MessageBox.Show("Email Tidak Terdaftar");
                    txt_login.Focus();
                }
                else if (cmail.Password != txt_pass.Password.ToString())
                {
                    MessageBox.Show("Password Salah");
                    txt_pass.Focus();
                }
                else
                {
                    MainWindow mainWindow = new MainWindow(txt_login.Text);
                    mainWindow.Show();
                    this.Close();
                }
            }
            catch
            {

            }
        }

        private void txt_login_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {

        }

        private void txt_pass_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {

        }

        private void btn_to_forgot_Click(object sender, RoutedEventArgs e)
        {
            forgot forgotpanel = new forgot();
            forgotpanel.Show();
            this.Close(); ;
        }
    }
}
