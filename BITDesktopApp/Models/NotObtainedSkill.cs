using BITDesktopApp.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BITDesktopApp.Models
{
    public class NotObtainedSkill : INotifyPropertyChanged
    {
        private int _skillId;
        private string _skill;
        private SQLHelper _db;
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string prop)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
        }
        public NotObtainedSkill()
        {
            _db = new SQLHelper();
        }
        public string Skill
        {
            get { return _skill; }
            set
            {
                _skill = value;
                OnPropertyChanged("Skill");
            }
        }

        public int SkillId
        {
            get { return _skillId; }
            set
            {
                _skillId = value;
                OnPropertyChanged("SkillId");
            }
        }

        
        public NotObtainedSkill(DataRow dr)
        {
            Skill = dr["desc"].ToString();
            SkillId = Convert.ToInt32(dr["skillId"].ToString());
            _db = new SQLHelper();
        }
    }
}
