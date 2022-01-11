using BITDesktopApp.Models;
using BITDesktopApp.ViewModels;
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

namespace BITDesktopApp.Views
{
    /// <summary>
    /// Interaction logic for ClientManagementView.xaml
    /// </summary>
    public partial class ClientManagementView : Page
    {
        //private ClientManagementView clientVM;
        //private AddNewClientViewModel _newClient;
        public ClientManagementView()
        {
            InitializeComponent();
            

            this.DataContext = new ClientManagementViewModel();
            //dpAddDOB.SelectedDate = DateTime.Today.Date;



            //if (TabCtrl.SelectedIndex.ToString() == "-1")
            //{
            //    this.DataContext = new ClientManagementViewModel();
            //}
            //else if (TabCtrl.SelectedIndex.ToString()=="0")
            //{

            //}

            //else if (TabCtrl.SelectedIndex.ToString() == "1")
            //{
            //    this.DataContext = new AddNewClientViewModel();
            //}
            //else
            //{
            //    this.DataContext = new ClientManagementViewModel();
            //}


        }

        

        public void btnSearchClient_Click(object sender, RoutedEventArgs e)
        {
            //if (dgClients.) {btnShowAllClients.IsEnabled = true; }
            

        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            //cmbAddTitle.Items.Clear();
            txtAddFirstName.Clear();
            txtAddLastName.Clear();

            dpAddDOB.SelectedDate = DateTime.Today;
            txtAddPhone.Clear();
            txtAddEmail.Clear();
            txtAddAddress.Clear();
            txtAddSuburb.Clear();
            //cmbAddState.Items.Clear();
            txtAddPostcode.Clear();
        }
    }
}
