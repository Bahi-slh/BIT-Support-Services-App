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
    /// Interaction logic for ContractorManagementView.xaml
    /// </summary>
    public partial class ContractorManagementView : Page
    {
        public ContractorManagementView()
        {
            InitializeComponent();
            this.DataContext = new ContractorManagementViewModel();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show("The contractor was updated successfully!");
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
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
