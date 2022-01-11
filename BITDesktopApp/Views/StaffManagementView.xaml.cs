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
    /// Interaction logic for StaffManagementView.xaml
    /// </summary>
    public partial class StaffManagementView : Page
    {
        public StaffManagementView()
        {
            InitializeComponent();
            //ckeck if the user is admin before you perform other tasks
            //((MainWindow)System.Windows.Application.Current.MainWindow).StaffMngmntItem.IsEnabled = true;
            this.DataContext = new StaffManagementViewModel();
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {

            //MessageBox.Show("The staff was updated successfully!");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
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
