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
    public class ClientManagementViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Client> _clients;
        private Client _selectedClient;
        private Client _client;
        private string _searchText;
        private string _searchChoice;
        private DateTime _initialDob;
        private RelayCommand _addCommand;
        private RelayCommand _updateCommand;
        private RelayCommand _searchCommand;
        private RelayCommand _reloadCommand;
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

        public RelayCommand ReloadCommand
        {
            get
            {
                if (_reloadCommand == null)
                {
                    _reloadCommand = new RelayCommand(this.ReloadMethod, true);

                }
                return _reloadCommand;
            }
            set
            {
                _reloadCommand = value;
            }
        }


        public ObservableCollection<Client> Clients
        {
            get { return _clients; }
            set
            {
                _clients = value;
                OnPropertyChanged("Clients");
            }
        }

        
        public Client SelectedClient
        {
            get { return _selectedClient; }
            set
            {
                _selectedClient = value;
                OnPropertyChanged("SelectedClient");
            }
        }
        public Client NewClient
        {
            get { _client.Dob = DateTime.Today;
                return _client; } //read
            set { _client = NewClient;
                
            }
        }
        public string SearchText
        {
            get { return _searchText; }
            set { _searchText = value; OnPropertyChanged("SearchText");
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

        public DateTime InitialDate { get { return _initialDob; } set { _initialDob = DateTime.Now; } }
        

        public ClientManagementViewModel()
        {
            //for adding a new client
            _client = new Client();

            Clients allClients = new Clients();
            this.Clients = new ObservableCollection<Client>(allClients);
        }

        public void AddMethod()
        {
            try 
            { 
            string resultMsg = NewClient.AddClient();
            MessageBox.Show(resultMsg);

            Clients allClients = new Clients();
            this.Clients = new ObservableCollection<Client>(allClients);
            }
            catch
            {
                MessageBox.Show("Please try again!");
            }
        }

        public void UpdateMethod()
        { 
            string resultMsg=SelectedClient.UpdateClient();
                MessageBox.Show(resultMsg);
                
                Clients allClients = new Clients();
                this.Clients = new ObservableCollection<Client>(allClients);
            //try
            //{
               
            //}
            //catch
            //{
            //    MessageBox.Show("Please try again!");
            //}
            
        }

        public void ReloadMethod()
        {
            

            Clients allClients = new Clients();
            this.Clients = new ObservableCollection<Client>(allClients);
            //try
            //{

            //}
            //catch
            //{
            //    MessageBox.Show("Please try again!");
            //}

        }

        public void SearchMethod()
        {
            
            
            try {
                Clients allClients = new Clients(this.SearchChoice, this.SearchText);
                this.Clients = new ObservableCollection<Client>(allClients);
                


            }
            catch 
            {
                MessageBox.Show("Please enter your choice of search and fill the search box!");
            }
        }

    }
}
