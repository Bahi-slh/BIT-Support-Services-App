using BITDesktopApp.Models;
using BITDesktopApp.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BITDesktopApp.BLL
{
    class Contractors: List<Contractor>
    {
         public Contractors()
    {
        SQLHelper helper = new SQLHelper();
        string sql = "set dateformat dmy;select contractorId, title, firstname, lastname, phone, email, address, suburb, postcode, state, dob, statusId, rating from contractor";
        DataTable contractorTable = new DataTable();
        contractorTable = helper.ExecuteSQL(sql);
        foreach (DataRow dr in contractorTable.Rows)
        {
            Contractor newContractor = new Contractor(dr);
            this.Add(newContractor);
        }
    }

        public Contractors(string searchChoice, string searchText)
        {
            SQLHelper helper = new SQLHelper();
            string sql = "set dateformat dmy;select contractorId, title, firstname, lastname, phone, email, address, suburb, postcode, state, dob, statusId, rating from contractor where " + searchChoice + " LIKE '%" + searchText + "%' " + " order by " + searchChoice + " asc";
            DataTable contractorTable = new DataTable();
            contractorTable = helper.ExecuteSQL(sql);
            foreach (DataRow dr in contractorTable.Rows)
            {
                Contractor newContractor = new Contractor(dr);
                this.Add(newContractor);
            }
        }
    }
}
