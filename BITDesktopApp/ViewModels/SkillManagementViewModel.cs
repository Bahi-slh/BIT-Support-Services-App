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
    class SkillManagementViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Skill> _skills;
        
        private Skill _selectedSkill;
        private Skill _skill;
        private NotObtainedSkill _nos;
        private ObtainedSkill _os;
        private RelayCommand _addCommand;
        private RelayCommand _addSkillCommand;
        private RelayCommand _deleteCommand;
        private RelayCommand _deleteSkillCommand;

        private ObservableCollection<Contractor> _contractors;
        private Contractor _selectedContractor;
        private Contractor _contractor;

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

        public SkillManagementViewModel()
        {
            //for adding a new skill
            _skill = new Skill();
            _nos = new NotObtainedSkill();
            _contractor = new Contractor();

            Skills allSkills = new Skills();
            this.Skills = new ObservableCollection<Skill>(allSkills);

            if (Os == null)
            {
                Os = new ObtainedSkill();
            }

            if (Nos == null)
            {
                Nos = new NotObtainedSkill();
            }
            Contractors allContractors = new Contractors();
            this.Contractors = new ObservableCollection<Contractor>(allContractors);
        }


        //for skills list tab
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

        //for skills list tab
        public RelayCommand DeleteCommand
        {
            get
            {
                if (_deleteCommand == null)
                {
                    _deleteCommand = new RelayCommand(this.DeleteMethod, true);
                }
                return _deleteCommand;
            }
            set
            {
                _deleteCommand = value;
            }
        }

        public RelayCommand DeleteSkillCommand
        {
            get
            {
                if (_deleteSkillCommand == null)
                {
                    _deleteSkillCommand = new RelayCommand(this.DeleteContractorSkillMethod, true);
                }
                return _deleteSkillCommand;
            }
            set
            {
                _deleteSkillCommand = value;
            }
        }

        public RelayCommand AddSkillCommand
        {
            get
            {
                if (_addSkillCommand == null)
                {
                    _addSkillCommand = new RelayCommand(this.AddContractorSkillMethod, true);
                }
                return _addSkillCommand;
            }
            set
            {
                _addSkillCommand = value;
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


        //for skills list tab
        

        //for skills list tab
        public ObservableCollection<Skill> Skills
        {
            get { return _skills; }
            set
            {
                _skills = value;
                OnPropertyChanged("Skills");
            }
        }

        //for skills list tab
        public Skill SelectedSkill
        {
            get { return _selectedSkill; }
            set
            {
                _selectedSkill = value;
                OnPropertyChanged("SelectedSkill");
            }
        }

        public Skill NewSkill
        {
            get { return _skill; }
            set { _skill = NewSkill; }
        }


        public ObservableCollection<Contractor> Contractors
        {
            get { return _contractors; }
            set
            {
                _contractors = value;
                OnPropertyChanged("Contractors");
            }
        }
        public Contractor SelectedContractor
        {
            get { return _selectedContractor; }
            set
            {
                _selectedContractor = value;
                OnPropertyChanged("SelectedContractor");
            }
        }

        public ObtainedSkill Os
        {
            get { return _os; }
            set
            {
                _os = value;
                OnPropertyChanged("Os");
            }
        }

        public NotObtainedSkill Nos
        {
            get { return _nos; }
            set 
            { 
                _nos = value;
                OnPropertyChanged("Nos");
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
                Contractors allContractors = new Contractors(this.SearchChoice, this.SearchText);
                this.Contractors = new ObservableCollection<Contractor>(allContractors);

            }
            catch
            {
                MessageBox.Show("Please enter your choice of search and fill the search box!");
            }
        }

        public void AddMethod()
        {
            if (NewSkill != null)
            {
                try
                {
                NewSkill.AddSkill();

                MessageBox.Show("The Skill Added Successfully!!");

                Skills allSkills = new Skills();
                this.Skills = new ObservableCollection<Skill>(allSkills);
                }
                catch
                {
                    MessageBox.Show("Please enter a skill into the textbox!");
                }
               
            }
        }

        public void DeleteMethod()
        {
            if (SelectedSkill != null)
            {
                try 
                {
                 SelectedSkill.DeleteSkill();

                MessageBox.Show("The Skill Deleted Successfully!!");

                Contractors allContractors = new Contractors();
                this.Contractors = new ObservableCollection<Contractor>(allContractors);

                Skills skills = new Skills();
                this.Skills = new ObservableCollection<Skill>(skills);
                }
                catch
                {
                    MessageBox.Show("You cannot delete this skill as it is already an obtained skill for some contractors!");
                }
               
            }
        }

        public void AddContractorSkillMethod()
        {
            if (Nos !=null)
            {
                try
                {
                    SelectedContractor.NotObtainedSkill.SkillId = Nos.SkillId;

                    string resultMsg = SelectedContractor.AddContractorSkill();

                    MessageBox.Show(resultMsg);

                    Contractors allContractors = new Contractors();
                    this.Contractors = new ObservableCollection<Contractor>(allContractors);
                }
                catch 
                {
                    MessageBox.Show("Please select on the skill Id you want to add!");
                } 
            }
           

        }

        public void DeleteContractorSkillMethod()
        {
            if (Os !=null)
            {
                try
                {
                    SelectedContractor.OS.SkillId = Os.SkillId;
                    string resultMsg = SelectedContractor.DeleteContractorSkill();

                    MessageBox.Show(resultMsg);

                    Contractors allContractors = new Contractors();
                    this.Contractors = new ObservableCollection<Contractor>(allContractors);
                }
                catch 
                {
                    MessageBox.Show("Please select on the skill Id you want to delete!");
                } 
            }

        }
    }
}


