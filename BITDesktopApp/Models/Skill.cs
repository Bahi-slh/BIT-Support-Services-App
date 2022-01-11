using BITDesktopApp.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BITDesktopApp.Models
{
    public class Skill : INotifyPropertyChanged
    {
        
        public event PropertyChangedEventHandler PropertyChanged;
        private SQLHelper _db;
        private void OnPropertyChanged(string prop)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
        }
        public int SkillId { get; set; }

        
        public string Description { get;  set; }

         public Skill() //default constructor
        {
            _db = new SQLHelper();
        }
        public Skill(DataRow dr)
        {
            this.SkillId = Convert.ToInt32(dr["skillId"].ToString());
            this.Description= dr["desc"].ToString();
           
            _db = new SQLHelper();

        }
       

        public string AddSkill()
        {
           
            string insertsql = " insert into Skill ( [desc])" + "values(@Description)";
            SqlParameter[] objParams = new SqlParameter[1];

            //objParams[0] = new SqlParameter("@SkillId", DbType.Int32);
            //objParams[0].Value = this.SkillId;

            objParams[0] = new SqlParameter("@Description", DbType.String);
            objParams[0].Value = this.Description;

            

            _db = new SQLHelper();
            int rowsAffected = _db.ExecuteNonQuery(insertsql, objParams);
            if (rowsAffected >= 1)
            {
                return "New Skill was added successfully!";
            }


            return "New skill addition was not successful, please try again.";
        }

        public int DeleteSkill()
        {
            
            string sql= "DELETE FROM Skill WHERE skillid = '" + SkillId +"'";
            _db = new SQLHelper();
            int _return=_db.ExecuteNonQuery(sql);
            return _return;
        }
    }
}
