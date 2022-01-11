using BITDesktopApp.Views;
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

namespace BITDesktopApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static readonly NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

        public MainWindow()
        {
            InitializeComponent();
        }
        public MainWindow(string UserType)
        {
            InitializeComponent();
            //ClientMngmntItem.IsVisible = false;
            //contentFrame.Navigate(new LoginView());
            if (UserType == "Admin")
            {
                StaffMngmntItem.IsEnabled = true;
            }
            else if (UserType == "Coordinator")
            {
                StaffMngmntItem.IsEnabled = false;
            }
            try
            {
                logger.Debug("Something to debug");
                logger.Info("The window was opened");
            }
            catch (Exception ex)
            {

                logger.Error(ex, "Exception generated");
            }
            NLog.LogManager.Shutdown();
        }
        //public MainWindow(bool status)
        //{
        //    if (status)//admin
        //    {
        //        //InitializeComponent();
        //        MainWindow dashboard = new MainWindow();
        //        dashboard.Show();
        //    }
            
        //    else//false means coordinator
        //    {
        //        MainWindow dashboard = new MainWindow();
        //        StaffMngmntItem.IsEnabled = false;
        //        //contentFrame.Navigate();
        //        dashboard.Show();
        //    }
        //}


        private void ClientMngmntItem_Selected(object sender, RoutedEventArgs e)
        {
            contentFrame.Navigate(new ClientManagementView());
        }

        private void ListViewItem_Selected(object sender, RoutedEventArgs e)
        {
            contentFrame.Navigate(new ContractorManagementView());
        }

        private void SkillMngmntItem_Selected(object sender, RoutedEventArgs e)
        {
            contentFrame.Navigate(new SkillManagementView());
        }

        private void StaffMngmntItem_Selected(object sender, RoutedEventArgs e)
        {
            contentFrame.Navigate(new StaffManagementView());
        }

        private void JobMngmntItem_Selected(object sender, RoutedEventArgs e)
        {
            contentFrame.Navigate(new JobManagementView());
        }
    }
}
