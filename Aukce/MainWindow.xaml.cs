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
        public MainWindow()
        {
            InitializeComponent();
        }
    }
}
