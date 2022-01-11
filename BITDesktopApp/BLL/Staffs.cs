using BITDesktopApp.Models;
using BITDesktopApp.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace BITDesktopApp.BLL
{
    class Staffs : List<Staff>
    {
        public Staffs()
        {
            SQLHelper helper = new SQLHelper();
            string sql = "select staffId, title, firstname, lastname, phone, email, address, suburb, postcode, state, " +
                "  dob, statusId, position from Staff";
            DataTable staffTable = new DataTable();
            staffTable = helper.ExecuteSQL(sql);
            foreach (DataRow dr in staffTable.Rows)
            {
                Staff newStaff = new Staff(dr);
                this.Add(newStaff);
            }
        }
        public Staffs(string searchChoice, string searchText)
        {
            SQLHelper helper = new SQLHelper();
            string sql = "select staffId, title, firstname, lastname, phone, email, address, suburb, postcode, state, " +
                "  dob, statusId, position from Staff where " + searchChoice + " LIKE '%" + searchText + "%' " + " order by " + searchChoice + " asc";
            DataTable staffTable = new DataTable();
            staffTable = helper.ExecuteSQL(sql);
            foreach (DataRow dr in staffTable.Rows)
            {
                Staff newStaff = new Staff(dr);
                this.Add(newStaff);
            }
        }
    }
}
