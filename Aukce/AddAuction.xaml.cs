﻿using Aukce.Data;
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
using System.Windows.Shapes;

namespace Aukce
{
    /// <summary>
    /// Interakční logika pro AddAuction.xaml
    /// </summary>
    public partial class AddAuction : Window
    {
        private MainViewModel vm;
        internal AddAuction(ApplicationDbContext db)
        {
            InitializeComponent();
            vm = (MainViewModel)DataContext;
            vm.Db = db;
            vm.ReloadCommand.Execute(null);
        }
    }
}
