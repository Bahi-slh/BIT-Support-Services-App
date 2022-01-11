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
    public class NotObtainedSkills: List<NotObtainedSkill>
    {
        public NotObtainedSkills(int contractorId)
        {
            SQLHelper helper = new SQLHelper();
            string sql = "SELECT s.[Desc], s.skillId FROM skill s WHERE s.skillId NOT IN (SELECT    os.skillId  FROM    ObtainedSkills os  WHERE   os.contractorId = '" + contractorId + "')";
            DataTable skillTable = new DataTable();
            skillTable = helper.ExecuteSQL(sql);
            foreach (DataRow dr in skillTable.Rows)
            {
                NotObtainedSkill aSkill = new NotObtainedSkill(dr);
                this.Add(aSkill);
            }
        }
    }
}
