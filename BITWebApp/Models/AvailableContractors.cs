using BITWebApp.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace BITWebApp.Models
{
    public class AvailableContractors
    {
       
        public static DataTable GetAllAvailableContractors(DateTime date, string time, string requiredSkill)
            // not useful
        {
            string sql = "set dateformat dmy; select t.timeslotId, t.starttime, a.availabilityId, a.availDate, " +
             " cr.contractorId, cr.firstname, cr.lastname " +
             " FROM Timeslot t, contractor cr, Availability a, " +
             " RequiredSkills rs, ObtainedSkills os, skill s , jobRequest j WHERE " +
             " os.contractorId = cr.contractorId and " +

             " os.skillId = s.skillId and " +
             " cr.contractorId = a.contractorId and " +

             " j.jobReqId = rs.jobReqId and "+

             " s.skillId = rs.skillId and "+
             " t.timeSlotId = a.timeSlotId and " +
             " s.[Desc]= '"+requiredSkill+"' and "+
             " a.availDate = '" + date+"' and " +
             " t.starttime = '"+ time+"' and " +
             " a.status = 'Available' " +

             " order by cr.rating desc ";

            SQLHelper helper = new SQLHelper();
            return helper.ExecuteSQL(sql);
        }

        public static DataTable GetAllAvailableContractors(DateTime bookingDate)
        {
            string sql = "set dateformat dmy; select c.firstname as [Firstname], c.lastname as [Lastname], c.address as [Address], c.suburb as [Suburb], c.state as [State], c.postcode as [Postcode],stuff((select '; ' + s.[desc] from skill s, ObtainedSkills os where os.contractorId = c.contractorId and s.skillId = os.skillId  for xml path('')), 1, 1 , '') [Skills],  t.timeSlotId, a.availabilityId, a.availDate as [Availability Date],t.startTime as [Time Slot], c.contractorId, c.Rating "
                + " from contractor c, Availability a, TimeSlot t where a.availDate BETWEEN '" + DateTime.Today + "' AND '" + bookingDate + "'  and a.contractorId = c.contractorId and a.status = 'Available'and a.timeSlotId = t.timeSlotId group by c.contractorId , c.firstname, c.lastname, c.address, c.suburb, c.state, c.postcode,t.startTime,t.timeSlotId, a.availabilityId, a.availDate, c.contractorId, c.rating order by c.Rating";

            SQLHelper helper = new SQLHelper();
            return helper.ExecuteSQL(sql);
        }
    }
}