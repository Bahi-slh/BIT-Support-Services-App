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
    public class AvailableContractors : List<AvailableContractor>
    {
        public AvailableContractors(DateTime bookingDate)
        {
            SQLHelper helper = new SQLHelper();

            string sql = "set dateformat dmy; select c.firstname, c.lastname, c.address, c.suburb, c.state, c.postcode,stuff((select '; ' + s.[desc] from skill s, ObtainedSkills os where os.contractorId = c.contractorId and s.skillId = os.skillId  for xml path('')), 1, 1 , '') [skills], t.startTime , t.timeSlotId, a.availabilityId, a.availDate, c.contractorId "
                + " from contractor c, Availability a, TimeSlot t where a.availDate BETWEEN '"+DateTime.Today+"' AND '" + bookingDate + "'  and a.contractorId = c.contractorId and a.status = 'Available'and a.timeSlotId = t.timeSlotId group by c.contractorId , c.firstname, c.lastname, c.address, c.suburb, c.state, c.postcode,t.startTime,t.timeSlotId, a.availabilityId, a.availDate, c.contractorId ";
            DataTable contractorsTable = helper.ExecuteSQL(sql);
            foreach (DataRow dr in contractorsTable.Rows)
            {
                AvailableContractor contractor = new AvailableContractor(dr);
                this.Add(contractor);
            }
        }

        public AvailableContractors(DateTime bookingDate, string searchChoice, string searchText)
        {
            SQLHelper helper = new SQLHelper();

            string sql = "set dateformat dmy; select c.firstname, c.lastname, c.address, c.suburb, c.state, c.postcode,stuff((select '; ' + s.[desc] from skill s, ObtainedSkills os where os.contractorId = c.contractorId and s.skillId = os.skillId  for xml path('')), 1, 1 , '') [skills], t.startTime , t.timeSlotId, a.availabilityId, a.availDate, c.contractorId "
                + " from contractor c, Availability a, TimeSlot t where a.availDate BETWEEN '" + DateTime.Today + "' AND '" + bookingDate + "'  and a.contractorId = c.contractorId and a.status = 'Available'and a.timeSlotId = t.timeSlotId and " + searchChoice + " LIKE '%" + searchText + "%' " + " group by c.contractorId , c.firstname, c.lastname, c.address, c.suburb, c.state, c.postcode,t.startTime,t.timeSlotId, a.availabilityId, a.availDate, c.contractorId ";
            DataTable contractorsTable = helper.ExecuteSQL(sql);
            foreach (DataRow dr in contractorsTable.Rows)
            {
                AvailableContractor contractor = new AvailableContractor(dr);
                this.Add(contractor);
            }
        }

        public AvailableContractors(DateTime bookingDate, string searchText)
        {
            SQLHelper helper = new SQLHelper();

            string sql = "set dateformat dmy; select c.firstname, c.lastname, c.address, c.suburb, c.state, c.postcode,stuff((select '; ' + s.[desc] from skill s, ObtainedSkills os where os.contractorId = c.contractorId and s.skillId = os.skillId  for xml path('')), 1, 1 , '') [skills], t.startTime , t.timeSlotId, a.availabilityId, a.availDate, c.contractorId "
                + " from contractor c, Availability a, TimeSlot t, skill s, ObtainedSkills os where a.availDate BETWEEN '"+DateTime.Today+"' AND '" + bookingDate + "'  and a.contractorId = c.contractorId and a.status = 'Available'and a.timeSlotId = t.timeSlotId and " +
                " os.contractorId = c.contractorId and s.skillId = os.skillId and s.[desc]" + " LIKE '%" + searchText + "%' " +
                " group by c.contractorId , c.firstname, c.lastname, c.address, c.suburb, c.state, c.postcode,t.startTime,t.timeSlotId, a.availabilityId, a.availDate, c.contractorId ";
            DataTable contractorsTable = helper.ExecuteSQL(sql);
            foreach (DataRow dr in contractorsTable.Rows)
            {
                AvailableContractor contractor = new AvailableContractor(dr);
                this.Add(contractor);
            }
        }

    }
}
