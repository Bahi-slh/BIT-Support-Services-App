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
    class Clients : List<Client>
    {
        public Clients()
        {
            SQLHelper helper = new SQLHelper();
            string sql = "select clientId, title, firstname, lastname, phone, email, address, suburb, postcode, state, " +
                "  dob, statusId from Client";
            DataTable clientTable = new DataTable();
            clientTable = helper.ExecuteSQL(sql);
            foreach (DataRow dr in clientTable.Rows)
            {
                Client newClient = new Client(dr);
                this.Add(newClient);
            }
        }
        public Clients(string searchChoice,string searchText)
        {
            SQLHelper helper = new SQLHelper();
            string sql = "select clientId, title, firstname, lastname, phone, email, address, suburb, postcode, state, " +
                "  dob, statusId from Client where "+searchChoice+" LIKE '%"+searchText+"%' "+" order by "+searchChoice+" asc";
            DataTable clientTable = new DataTable();
            clientTable = helper.ExecuteSQL(sql);
            foreach (DataRow dr in clientTable.Rows)
            {
                Client newClient = new Client(dr);
                this.Add(newClient);
            }
        }
    }
}
