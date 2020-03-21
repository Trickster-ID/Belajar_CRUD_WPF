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

namespace belajarCRUDWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        myContext connection = new myContext();
        int cb_sup;
        public MainWindow()
        {
            InitializeComponent();
            tbl_supplier.ItemsSource = connection.Suppliers.ToList();
            tbl_item.ItemsSource = connection.Items.ToList();
            drp_supplier.ItemsSource = connection.Suppliers.ToList();
            //loaddata();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void btn_insert_click(object sender, RoutedEventArgs e)
        {
            var input_data = new Supplier (txt_name.Text, txt_address.Text);
            if (txt_name.Text == "")
            {
                MessageBox.Show("Anda Harus Mengisi Name");
                txt_name.Focus();
            }else if (txt_address.Text == ""){
                MessageBox.Show("Anda Harus Mengisi Address");
                txt_address.Focus();
            }else
            {
                connection.Suppliers.Add(input_data);
                connection.SaveChanges();
                txt_name.Text = string.Empty;
                txt_address.Text = string.Empty;
                MessageBox.Show("Anda Berhasil Memasukan Data");
            }
            tbl_supplier.ItemsSource = connection.Suppliers.ToList();
            drp_supplier.ItemsSource = connection.Suppliers.ToList();
        }

        private void btn_update_Click(object sender, RoutedEventArgs e)
        {
            int id = Convert.ToInt32(txt_id.Text);
            var myid = connection.Suppliers.Where(S => S.Id == id).FirstOrDefault();
            myid.Name = txt_name.Text;
            myid.Address = txt_address.Text;
            connection.SaveChanges();
            tbl_supplier.ItemsSource = connection.Suppliers.ToList();
            drp_supplier.ItemsSource = connection.Suppliers.ToList();
            MessageBox.Show("Data Berhasil DiPerbarui");
        }

        private void btn_delete_Click(object sender, RoutedEventArgs e)
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
                tbl_supplier.ItemsSource = connection.Suppliers.ToList();
            }
            else
            {
                tbl_supplier.ItemsSource = connection.Suppliers.ToList();
            }
        }

        private void txt_name_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {

        }

        private void txt_address_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {

        }

        private void txt_id_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {

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
            try
            {
                cb_sup = Convert.ToInt32(drp_supplier.SelectedValue.ToString());
            }
            catch (Exception)
            {
                drp_supplier.ItemsSource = connection.Suppliers.ToList();
            }
        }

        private void btn_update_item_Click(object sender, RoutedEventArgs e)
        {
            int id_item = Convert.ToInt32(txt_id_item.Text);
            var cSup = connection.Suppliers.Where(si => si.Id == cb_sup).FirstOrDefault();
            var myid_item = connection.Items.Where(si => si.Id == id_item).FirstOrDefault();
            myid_item.Name = txt_name_item.Text;
            myid_item.Price = Int32.Parse(txt_price_item.Text);
            myid_item.Stock = Int32.Parse(txt_stock_item.Text);
            myid_item.Supplier = cSup;
            connection.SaveChanges();
            tbl_item.ItemsSource = connection.Items.ToList();
            MessageBox.Show("Data Berhasil DiPerbarui");
        }

        private void btn_insert_item_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var cPrice = Convert.ToInt32(txt_price_item.Text);
                var cStock = Convert.ToInt32(txt_stock_item.Text);
                var cSup = connection.Suppliers.Where(si => si.Id == cb_sup).FirstOrDefault();
                var inputitem = new Item(txt_name_item.Text, cPrice, cStock, cSup);
                connection.Items.Add(inputitem);
                connection.SaveChanges();
                MessageBox.Show("Data Telah Disimpan");
                txt_name_item.Text = "";
                txt_price_item.Text = "";
                txt_stock_item.Text = "";
                drp_supplier.Text = string.Empty;
                tbl_item.ItemsSource = connection.Items.ToList();
            }
            catch(Exception)
            {
                MessageBox.Show("Mohon Isi Angka di Kolom Price & Stock");
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

        private void btn_delete_item_Click(object sender, RoutedEventArgs e)
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
    }
}
