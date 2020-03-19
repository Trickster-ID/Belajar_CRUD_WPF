﻿using belajarCRUDWPF.Model;
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
        public MainWindow()
        {
            InitializeComponent();
            tbl_supplier.ItemsSource = connection.Suppliers.ToList();
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

        }

        private void btn_update_Click(object sender, RoutedEventArgs e)
        {
            int id = Convert.ToInt32(txt_id.Text);
            var myid = connection.Suppliers.Where(S => S.Id == id).FirstOrDefault();
            myid.Name = txt_name.Text;
            myid.Address = txt_address.Text;

            connection.SaveChanges();
            tbl_supplier.ItemsSource = connection.Suppliers.ToList();

            MessageBox.Show("Data Berhasil DiPerbarui");
        }

        private void btn_delete_Click(object sender, RoutedEventArgs e)
        {
            
            int deletelist = Convert.ToInt32(txt_id.Text);
            var myid = connection.Suppliers.Where(S => S.Id == deletelist).FirstOrDefault();
            connection.Suppliers.Remove(myid);
            var delete = connection.SaveChanges();
            txt_id.Text = string.Empty;
            txt_name.Text = string.Empty;
            txt_address.Text = string.Empty;
            MessageBox.Show(delete + "Data Berhasil DiHapus");
            tbl_supplier.ItemsSource = connection.Suppliers.ToList();
            
            
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
    }
}
