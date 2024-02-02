using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
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

namespace WpfApp777
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {

        private Contact selectedContact;

        public ObservableCollection<Contact> Contacts { get; set; }

        public Contact SelectedContact
        {
            get => selectedContact;
            set 
            {
                selectedContact = value;
                PropertyChanged?.Invoke(this,
                    new PropertyChangedEventArgs(nameof(SelectedContact)));

            }
        }

        public MainWindow()
        {
            InitializeComponent();

            Contacts = new ObservableCollection<Contact>();

            Contacts.Add(new Contact 
            {
                Name = "asdfghjkl;'",
                Phone = 1098
                 
            });
            Contacts.Add(new Contact
            {
                Name = "qwertyuiop[",
                Phone = 2269879
            });
            DataContext = this;

        }

        public event PropertyChangedEventHandler? PropertyChanged;

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string message = SelectedContact == null ?
                "Ничего не выбрано" :
                SelectedContact.ToString();
            MessageBox.Show(message);
        }



        private void ClickMePupsik(object sender, RoutedEventArgs e)
        {
            Contacts.Add(new Contact() { Name = "", Phone = 0});
        }

        private void ClickMePupsichek(object sender, RoutedEventArgs e)
        {
            if (Contacts.Contains(SelectedContact))
            {
                Contacts.Remove(SelectedContact);
            }

        }

        private void GiveMeAPassword(object sender, RoutedEventArgs e)
        {
            if (Contacts.Contains(SelectedContact))
            {
                OpenFileDialog openFileDialog = new();
                openFileDialog.ShowDialog();
                var path = openFileDialog.FileName;
                selectedContact.Img = File.ReadAllBytes(path);
                PropertyChanged?.Invoke(this,
                  new PropertyChangedEventArgs(nameof(SelectedContact)));
            }
        }
    }
    public class Contact
    {
        public string Name { get; set; }
        public int Phone { get; set; }
        public byte[] Img { get; set; }

        public override string ToString()
        {
            return $"{Name} {Phone}";
        }


    } 
}
