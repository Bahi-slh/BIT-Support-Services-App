using BITDesktopApp.DAL;
using BITDesktopApp.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BITDesktopApp.BLL
{
    public class Skills : List<Skill>
    {
        public Skills()
        {
            SQLHelper helper = new SQLHelper();
            string sql ="select skillid, [desc] from Skill" ;
            DataTable skillTable = new DataTable();
            skillTable = helper.ExecuteSQL(sql);
            foreach (DataRow dr in skillTable.Rows)
            {
                Skill newSkill = new Skill(dr);
                this.Add(newSkill);
            }
        }
        //public Skills(int contractorId)
        //{
        //    SQLHelper helper = new SQLHelper();
        //    string sql = "SELECT s.[Desc], s.skillId FROM skill s WHERE s.skillId NOT IN (SELECT    os.skillId  FROM    ObtainedSkills os  WHERE   os.contractorId = '" + contractorId + "')";
        //    DataTable skillTable = new DataTable();
        //    skillTable = helper.ExecuteSQL(sql);
        //    foreach (DataRow dr in skillTable.Rows)
        //    {
        //        Skill aSkill = new Skill(dr);
        //        this.Add(aSkill);
        //    }
        //}
    }
}
