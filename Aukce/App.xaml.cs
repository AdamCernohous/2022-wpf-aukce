﻿using Aukce.Data;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Aukce
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public ApplicationDbContext Db = new ApplicationDbContext();

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            MainWindow wnd = new MainWindow(Db);
            wnd.Show();
        }
    }
}
