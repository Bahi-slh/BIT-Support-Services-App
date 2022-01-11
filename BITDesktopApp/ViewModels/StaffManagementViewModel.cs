using BITDesktopApp.BLL;
using BITDesktopApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BITDesktopApp.ViewModels
{
    class StaffManagementViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Staff> _staffs;
        private Staff _selectedStaff;
        private Staff _staff;
        private RelayCommand _addCommand;
        private RelayCommand _updateCommand;
        private string _searchText;
        private string _searchChoice;
        private RelayCommand _searchCommand;

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string prop)
        {
            if (PropertyChanged != null) //this is checking if we do have an event handler
            {
                //PropertyChanged() is a delegate that will call an EventHandler
                //depending on who is Subscribed to listen to this event
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
        }

        public RelayCommand AddCommand //MY NOTE: RelayCommand acts as a way to bind commands between the viewmodel and UI elements.
        {
            get
            {
                if (_addCommand == null)
                {
                    _addCommand = new RelayCommand(this.AddMethod, true);
                }
                return _addCommand;
            }
            set
            {
                _addCommand = value;
            }
        }
        public RelayCommand UpdateCommand
        {
            get
            {
                if (_updateCommand == null)
                {
                    _updateCommand = new RelayCommand(this.UpdateMethod, true);

                }
                return _updateCommand;
            }
            set
            {
                _updateCommand = value;
            }
        }
        public RelayCommand SearchCommand
        {
            get
            {
                if (_searchCommand == null)
                {
                    _searchCommand = new RelayCommand(this.SearchMethod, true);

                }
                return _searchCommand;
            }
            set
            {
                _searchCommand = value;
            }
        }
        public StaffManagementViewModel()
        {
            //for adding a new staff
            _staff = new Staff();

            Staffs allStaffs = new Staffs();
            this.Staffs = new ObservableCollection<Staff>(allStaffs);
        }

        public Staff NewStaff
        {
            get {
                _staff.Dob = DateTime.Today;
                return _staff; }
            set { _staff = NewStaff; }
        }

        public void AddMethod()
        {
            try 
            {
            string resultMsg = NewStaff.AddStaff();
            MessageBox.Show(resultMsg);

            Staffs allStaffs = new Staffs();
            this.Staffs = new ObservableCollection<Staff>(allStaffs);   
            }
            catch
            {
                MessageBox.Show("Please try again!");
            }

        }

        public void UpdateMethod()
        {
            string resultMsg = SelectedStaff.UpdateStaff();
            MessageBox.Show(resultMsg);

            Staffs allStaffs = new Staffs();
            this.Staffs = new ObservableCollection<Staff>(allStaffs);
            //try
            //{ 
            
            //}
            //catch
            //{
            //    MessageBox.Show("Please try again!");
            //}


        }


        public ObservableCollection<Staff> Staffs
        {
            get { return _staffs; }
            set
            {
                _staffs = value;
                OnPropertyChanged("Staffs");
            }
        }
        public Staff SelectedStaff
        {
            get { return _selectedStaff; }
            set
            {
                _selectedStaff = value;
                OnPropertyChanged("SelectedStaff");
            }
        }
        public string SearchText
        {
            get { return _searchText; }
            set
            {
                _searchText = value; OnPropertyChanged("SearchText");
            }
        }

        public string SearchChoice
        {
            get { return _searchChoice; }
            set
            {
                _searchChoice = value; OnPropertyChanged("SearchChoice");
            }
        }

        public void SearchMethod()
        {

            try
            {
                Staffs allStaffs = new Staffs(this.SearchChoice, this.SearchText);
                this.Staffs = new ObservableCollection<Staff>(allStaffs);

            }
            catch
            {
                MessageBox.Show("Please enter your choice of search and fill the search box!");
            }
        }
    }
}
