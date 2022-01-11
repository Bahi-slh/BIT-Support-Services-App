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
    public class ObtainedSkills : List<ObtainedSkill>
    {
        public ObtainedSkills(int contractorID)
        {
            SQLHelper helper = new SQLHelper();
            string sql = "select s.skillId,  s.[desc] from skill s, obtainedSkills os WHERE s.skillid = os.skillid and " +
                " contractorID = '" + contractorID + "'";
            DataTable skillsTable = helper.ExecuteSQL(sql);
            foreach (DataRow dr in skillsTable.Rows)
            {
                ObtainedSkill os = new ObtainedSkill(dr);
                this.Add(os);
            }
        }
    }
}
