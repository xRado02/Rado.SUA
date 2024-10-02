using System.Windows;
using Rado.SUA.Windows;
using System.Collections.Generic;
using Rado.SUA.Logic;
using System.IO;
using System.Diagnostics;
using System;

namespace Rado.SUA
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();           
        }

        private void btn_exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();         
        }

        private void btn_configure_Click(object sender, RoutedEventArgs e)
        {            
            ConfigureWindow cw = new ConfigureWindow();            
            cw.ShowDialog();   
        }

        private void btn_upgrade_Click(object sender, RoutedEventArgs e)
        {
            UpgradeProcessWindow upgradeProcessWindow = new UpgradeProcessWindow();
            upgradeProcessWindow.ShowDialog();
        }

        private void btn_readMe_Click(object sender, RoutedEventArgs e)
        {
            string exeDirectory = AppDomain.CurrentDomain.BaseDirectory;            
            string filePath = Path.Combine(exeDirectory, "README.txt");

            if (File.Exists(filePath))
            {
                Process.Start(new ProcessStartInfo("notepad.exe", filePath) { UseShellExecute = true });
            }
            else
            {
                MessageBox.Show("File not found.");
            }
        }
    }
}
