using Aukce.Data;
using Aukce.ViewModels;
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

namespace Aukce
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainViewModel vm;
        internal MainWindow(ApplicationDbContext db)
        {
            InitializeComponent();
            vm = (MainViewModel)DataContext;
            vm.Db = db;
            vm.ReloadCommand.Execute(null);
        }

        private void Btn_Login(object sender, RoutedEventArgs e)
        {
            LoginWindow login = new LoginWindow();
            login.DataContext = vm;
            login.ShowDialog();
        }

        private void Btn_Register(object sender, RoutedEventArgs e)
        {
            RegisterWindow register = new RegisterWindow();
            register.DataContext = vm;
            register.ShowDialog();
        }

        private void AddAuction(object sender, RoutedEventArgs e)
        {
            AddAuction addAuction = new AddAuction();
            addAuction.DataContext = vm;
            addAuction.ShowDialog();
        }

        private void Delete(object sender, RoutedEventArgs e)
        {
            DeleteAuction deleteAuction = new DeleteAuction();
            deleteAuction.DataContext = vm;
            deleteAuction.ShowDialog();
        }
    }
}