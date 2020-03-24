using belajarCRUDWPF.Model;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Net;
using System.Net.Mail;
using System.Drawing;
using System.Configuration;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace belajarCRUDWPF
{
    /// FIXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
    public partial class MainWindow : Window
    {
        myContext connection = new myContext();
        int cb_sup;
        int cb_roles;
        public string Email;
        public MainWindow(string Remail)
        {
            InitializeComponent();
            tbl_supplier.ItemsSource = connection.Suppliers.ToList();
            cb_role.ItemsSource = connection.Roles.ToList();
            tbl_item.ItemsSource = connection.Items.ToList();
            drp_supplier.ItemsSource = connection.Suppliers.ToList();
            Email = Remail;
            Role_Access();
        }

        private void Role_Access()
        {
            var role_akses = connection.Suppliers.Where(S => S.Email == Email).FirstOrDefault();
            if(role_akses.Role.Id == 1)
            {
                tab2.IsSelected = true;
//                 tab1.IsEnabled = false;
//                 tab1.IsSelected = false;
                tab1.Visibility = Visibility.Collapsed;
            }
            else
            {
                tab1.IsEnabled = true;
                tab2.IsEnabled = true;
            }
        }
        private void sendnewpass(string email, string password, string name)
        {
            MailMessage mm = new MailMessage("qwdqwf1@gmail.com", email);
            mm.Subject = ("New Password To Login"+ " " + DateTime.Now);
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
        private void btn_insert_click(object sender, RoutedEventArgs e)
        {
            if (txt_id.Text == "")
            {
                string pattern_supp = @"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$";
                string password = System.Guid.NewGuid().ToString();
                var myrole = connection.Roles.Where(S => S.Id == cb_roles).FirstOrDefault();
                var input_data = new Supplier(txt_name.Text, txt_address.Text, txt_email.Text, password, myrole);
                if (txt_name.Text == "")
                {
                    MessageBox.Show("Anda Harus Mengisi Name");
                    txt_name.Focus();
                }
                else if (txt_address.Text == "")
                {
                    MessageBox.Show("Anda Harus Mengisi Address");
                    txt_address.Focus();
                }
                else if (txt_email.Text == "")
                {
                    MessageBox.Show("Anda Harus Mengisi Email");
                    txt_email.Focus();
                }
                else if (!Regex.Match(txt_email.Text, pattern_supp).Success)
                {
                    MessageBox.Show("Format Email Salah");
                    txt_email.Focus();
                }
                else
                {
                    connection.Suppliers.Add(input_data);
                    connection.SaveChanges();
                    sendnewpass(txt_email.Text, password, txt_name.Text);
                    txt_name.Text = string.Empty;
                    txt_address.Text = string.Empty;
                    txt_email.Text = string.Empty;
                    cb_role.Text = string.Empty;
                    MessageBox.Show("Anda Berhasil Memasukan Data");
                }
                tbl_supplier.ItemsSource = connection.Suppliers.ToList();
                drp_supplier.ItemsSource = connection.Suppliers.ToList();
            }
            else
            {
                int id = Convert.ToInt32(txt_id.Text);
                var myrole = connection.Roles.Where(S => S.Id == cb_roles).FirstOrDefault();
                var myid = connection.Suppliers.Where(S => S.Id == id).FirstOrDefault();
                myid.Name = txt_name.Text;
                myid.Address = txt_address.Text;
                myid.Email = txt_email.Text;
                myid.Role = myrole;
                if (!txt_email.Text.Contains("@gmail.com")
                   && !txt_email.Text.Contains("@yahoo.com")
                   && !txt_email.Text.Contains("@rocketmail.com")
                   && !txt_email.Text.Contains("@gmail.co.id")
                   && !txt_email.Text.Contains("@hotmail.com"))
                {
                    MessageBox.Show("Format Email Tidak Sesuai");
                    txt_email.Focus();
                }
                else
                {
                    connection.SaveChanges();
                    MessageBox.Show("Data Berhasil DiPerbarui");
                    tbl_supplier.ItemsSource = connection.Suppliers.ToList();
                    drp_supplier.ItemsSource = connection.Suppliers.ToList();
                    txt_id.Text = string.Empty;
                    txt_name.Text = string.Empty;
                    txt_address.Text = string.Empty;
                    txt_email.Text = string.Empty;
                }
            }
        }
        private void tbl_supplier_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var data = tbl_supplier.SelectedItem;
            if (data == null)
            {
                tbl_supplier.ItemsSource = connection.Suppliers.ToList();
            }
            else
            {
                string Id = (tbl_supplier.SelectedCells[0].Column.GetCellContent(data) as TextBlock).Text;
                txt_id.Text = Id;
                string Name = (tbl_supplier.SelectedCells[1].Column.GetCellContent(data) as TextBlock).Text;
                txt_name.Text = Name;
                string Address = (tbl_supplier.SelectedCells[2].Column.GetCellContent(data) as TextBlock).Text;
                txt_address.Text = Address;
                string Email = (tbl_supplier.SelectedCells[3].Column.GetCellContent(data) as TextBlock).Text;
                txt_email.Text = Email;
                string Role_id = (tbl_supplier.SelectedCells[4].Column.GetCellContent(data) as TextBlock).Text;
                cb_role.Text = Role_id;
            }
        }
        private void txt_id_Copy_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {

        }
        private void txt_name_Copy_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {

        }
        private void txt_price_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {

        }
        private void txt_stock_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {

        }
        private void drp_supplier_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //try
            //{
            //    cb_sup = Convert.ToInt32(drp_supplier.SelectedValue.ToString());
            //}
            //catch (Exception)
            //{
            //    drp_supplier.ItemsSource = connection.Suppliers.ToList();
            //}
            if (drp_supplier.Text == "")
            {
                drp_supplier.ItemsSource = connection.Suppliers.ToList();
            }
            else
            {
                cb_sup = Convert.ToInt32(drp_supplier.SelectedValue.ToString());
            }
        }
        private void btn_insert_item_Click(object sender, RoutedEventArgs e)
        {
            if (txt_id_item.Text == "")
            {
                string pattern_item = "[^a-zA-Z0-9]";
                var cPrice = Convert.ToInt32(txt_price_item.Text);
                var cStock = Convert.ToInt32(txt_stock_item.Text);
                var cSup = connection.Suppliers.Where(si => si.Id == cb_sup).FirstOrDefault();
                var inputitem = new Item(txt_name_item.Text, cPrice, cStock, cSup);
                if (Regex.IsMatch(txt_name_item.Text, pattern_item))
                {
                    MessageBox.Show("Format Nama Item Salah");
                }
                else
                {
                    connection.Items.Add(inputitem);
                    connection.SaveChanges();
                    MessageBox.Show("Data Telah Disimpan");
                    txt_id_item.Text = "";
                    txt_name_item.Text = "";
                    txt_price_item.Text = "";
                    txt_stock_item.Text = "";
                    drp_supplier.Text = string.Empty;
                    tbl_item.ItemsSource = connection.Items.ToList();
                }
            }
            else
            {
                int id_item = Convert.ToInt32(txt_id_item.Text);
                var cSup = connection.Suppliers.Where(si => si.Id == cb_sup).FirstOrDefault();
                var myid_item = connection.Items.Where(si => si.Id == id_item).FirstOrDefault();
                myid_item.Name = txt_name_item.Text;
                myid_item.Price = Int32.Parse(txt_price_item.Text);
                myid_item.Stock = Int32.Parse(txt_stock_item.Text);
                myid_item.Supplier = cSup;
                connection.SaveChanges();
                MessageBox.Show("Data Berhasil DiPerbarui");
                tbl_item.ItemsSource = connection.Items.ToList();
            }
        }
        private void tbl_item_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var data_item = tbl_item.SelectedItem;
            if (data_item == null)
            {
                tbl_item.ItemsSource = connection.Items.ToList();
            }
            else
            {
                string Id_item = (tbl_item.SelectedCells[0].Column.GetCellContent(data_item) as TextBlock).Text;
                txt_id_item.Text = Id_item;
                string Name_item = (tbl_item.SelectedCells[1].Column.GetCellContent(data_item) as TextBlock).Text;
                txt_name_item.Text = Name_item;
                string price_item = (tbl_item.SelectedCells[2].Column.GetCellContent(data_item) as TextBlock).Text;
                txt_price_item.Text = price_item;
                string stock_item = (tbl_item.SelectedCells[3].Column.GetCellContent(data_item) as TextBlock).Text;
                txt_stock_item.Text = stock_item;
                string supp_item = (tbl_item.SelectedCells[4].Column.GetCellContent(data_item) as TextBlock).Text;
                drp_supplier.Text = supp_item;
            }
        }
        private void txt_email_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {

        }
        private void txt_id_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {

        }
        private void txt_name_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {

        }
        private void txt_address_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {

        }
        private void btn_clear_supp_Click(object sender, RoutedEventArgs e)
        {
            txt_id.Text = string.Empty;
            txt_name.Text = string.Empty;
            txt_address.Text = string.Empty;
            txt_email.Text = string.Empty;
            cb_role.Text = string.Empty;
        }
        private void btn_clear_item_Click(object sender, RoutedEventArgs e)
        {
            txt_id_item.Text = "";
            txt_name_item.Text = "";
            txt_price_item.Text = "";
            txt_stock_item.Text = "";
            drp_supplier.Text = string.Empty;
        }
        private void cb_role_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cb_role.Text == "")
            {
                cb_role.ItemsSource = connection.Roles.ToList();
            }
            else
            {
                cb_roles = Convert.ToInt32(cb_role.SelectedValue.ToString());
            }
        }
        private void btn_delete_intbl_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int deletelist = Convert.ToInt32(txt_id.Text);
                var myid = connection.Suppliers.Where(S => S.Id == deletelist).FirstOrDefault();

                MessageBoxResult dr = MessageBox.Show("Are you sure to delete row?", "Confirmation", MessageBoxButton.YesNo);
                if (dr == MessageBoxResult.Yes)
                {
                    //delete row from database or datagridview...
                    connection.Suppliers.Remove(myid);
                    var delete = connection.SaveChanges();
                    MessageBox.Show(delete + "Data Berhasil DiHapus");
                    txt_id.Text = string.Empty;
                    txt_name.Text = string.Empty;
                    txt_address.Text = string.Empty;
                    txt_email.Text = string.Empty;
                    tbl_supplier.ItemsSource = connection.Suppliers.ToList();
                    drp_supplier.ItemsSource = connection.Suppliers.ToList();
                }
                else
                {
                    MessageBox.Show("Mohon Pilih Salah Satu Data");
                    tbl_supplier.ItemsSource = connection.Suppliers.ToList();
                    drp_supplier.ItemsSource = connection.Suppliers.ToList();
                }
            }
            catch (Exception)
            {
                tbl_supplier.ItemsSource = connection.Suppliers.ToList();
            }
            //try
            //{
            //    var data_item = tbl_item.SelectedItem;
            //    int Id_item = Convert.ToInt32((tbl_item.SelectedCells[0].Column.GetCellContent(data_item) as TextBlock).Text);
            //    var myid = connection.Suppliers.Where(S => S.Id == Id_item).FirstOrDefault();

            //    MessageBoxResult dr = MessageBox.Show("Are you sure to delete row?", "Confirmation", MessageBoxButton.YesNo);
            //    if (dr == MessageBoxResult.Yes)
            //    {
            //        //delete row from database or datagridview...
            //        connection.Suppliers.Remove(myid);
            //        var delete = connection.SaveChanges();
            //        MessageBox.Show(delete + "Data Berhasil DiHapus");
            //        txt_id.Text = string.Empty;
            //        txt_name.Text = string.Empty;
            //        txt_address.Text = string.Empty;
            //        txt_email.Text = string.Empty;
            //        cb_role.Text = string.Empty;
            //        tbl_supplier.ItemsSource = connection.Suppliers.ToList();
            //        drp_supplier.ItemsSource = connection.Suppliers.ToList();
            //    }
            //    else
            //    {
            //        MessageBox.Show("Mohon Pilih Salah Satu Data");
            //        tbl_supplier.ItemsSource = connection.Suppliers.ToList();
            //        drp_supplier.ItemsSource = connection.Suppliers.ToList();
            //    }
            //}
            //catch (Exception)
            //{
            //    tbl_supplier.ItemsSource = connection.Suppliers.ToList();
            //}
        }
        private void srcbx_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {

        }
        private void btn_src_Click(object sender, RoutedEventArgs e)
        {
            List<Supplier> rdatas = new List<Supplier>();
            int parseValue;
            if (srcbx.Text == "")
            {
                tbl_supplier.ItemsSource = connection.Suppliers.ToList();
            }
            else
            {
                foreach (Supplier tdah in connection.Suppliers.ToList())
                {
                    if (tdah.Name.ToLower().Contains(srcbx.Text.ToLower()))
                    {
                        rdatas.Add(tdah);
                    } else if (int.TryParse(srcbx.Text, out parseValue))
                    {
                        if (tdah.Id.Equals(Convert.ToInt32(srcbx.Text.ToLower())))
                        {
                            rdatas.Add(tdah);
                        }
                    } else if (tdah.Address.ToLower().Contains(srcbx.Text.ToLower()))
                    {
                        rdatas.Add(tdah);
                    }else if (tdah.Email.ToLower().Contains(srcbx.Text.ToLower()))
                    {
                        rdatas.Add(tdah);
                    }else if (tdah.Role.Name.ToLower().Contains(srcbx.Text.ToLower()))
                    {
                        rdatas.Add(tdah);
                    }
                }
                tbl_supplier.ItemsSource = rdatas.ToList();
            }
        }
        private void btn_dlt_intblitem_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int dlist_item = Convert.ToInt32(txt_id_item.Text);
                var myid_item = connection.Items.Where(S => S.Id == dlist_item).FirstOrDefault();

                MessageBoxResult dr = MessageBox.Show("Are you sure to delete row?", "Confirmation", MessageBoxButton.YesNo);
                if (dr == MessageBoxResult.Yes)
                {
                    //delete row from database or datagridview...
                    connection.Items.Remove(myid_item);
                    connection.SaveChanges();
                    MessageBox.Show("Data Berhasil DiHapus");
                    txt_id_item.Text = string.Empty;
                    txt_name_item.Text = string.Empty;
                    txt_price_item.Text = string.Empty;
                    txt_stock_item.Text = string.Empty;
                    drp_supplier.Text = string.Empty;
                    tbl_item.ItemsSource = connection.Items.ToList();
                }
                else
                {
                    tbl_item.ItemsSource = connection.Items.ToList();
                }
            }
            catch
            {
                MessageBox.Show("Mohon Pilih Salah Satu Data");
                tbl_item.ItemsSource = connection.Items.ToList();
                drp_supplier.ItemsSource = connection.Suppliers.ToList();
            }
        }
        private void srcbx_item_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {

        }
        private void btn_src_item_Click(object sender, RoutedEventArgs e)
        {
            List<Item> rdatas = new List<Item>();
            int parseValue;
            if (srcbx_item.Text == "")
            {
                tbl_item.ItemsSource = connection.Items.ToList();
            }
            else
            {
                foreach (Item tdah in connection.Items.ToList())
                {
                    if (tdah.Name.ToLower().Contains(srcbx_item.Text.ToLower()))
                    {
                        rdatas.Add(tdah);
                    }
                    else if (int.TryParse(srcbx_item.Text, out parseValue))
                    {
                        if (tdah.Id.Equals(Convert.ToInt32(srcbx_item.Text.ToLower())))
                        {
                            rdatas.Add(tdah);
                        }else if (tdah.Price.Equals(Convert.ToInt32(srcbx_item.Text.ToLower())))
                        {
                            rdatas.Add(tdah);
                        }else if (tdah.Stock.Equals(Convert.ToInt32(srcbx_item.Text.ToLower())))
                        {
                            rdatas.Add(tdah);
                        }

                    }else if (tdah.Supplier.Name.ToLower().Contains(srcbx_item.Text.ToLower()))
                    {
                        rdatas.Add(tdah);
                    }
                    //else if (int.TryParse(srcbx_item.Text, out parseValue))
                    //{
                    //    if (tdah.Price.Equals(Convert.ToInt32(srcbx_item.Text.ToLower())))
                    //    {
                    //        rdatas.Add(tdah);
                    //    }
                    //}
                    //else if (int.TryParse(srcbx_item.Text, out parseValue))
                    //{
                    //    if (tdah.Stock.Equals(Convert.ToInt32(srcbx_item.Text.ToLower())))
                    //    {
                    //        rdatas.Add(tdah);
                    //    }
                    //}
                    //else if (tdah.Password.ToLower().Contains(srcbx.Text.ToLower()))
                    //{
                    //    rdatas.Add(tdah);
                    //}
                }
                tbl_item.ItemsSource = rdatas.ToList();
            }
        }

        private void Lout2_Click(object sender, RoutedEventArgs e)
        {
            loginregis loginpanel = new loginregis();
            loginpanel.Show();
            this.Close();
        }

        private void Lout1_Click(object sender, RoutedEventArgs e)
        {
            loginregis loginpanel = new loginregis();
            loginpanel.Show();
            this.Close();
        }
    }
}
