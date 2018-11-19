using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace SportsProDALClassLibrary
{
    public class TechnicianDAL
    {
        public DataTable RetrieveTechnicianNames()
        {
            SqlCommand cmdTechnicianNames = new SqlCommand();
            cmdTechnicianNames.CommandText = "SELECT NAME, TECHID FROM DBO.TECHNICIANS";
            cmdTechnicianNames.CommandType = CommandType.Text;
            SqlConnection aConn = new SqlConnection();
            aConn = TechSupportDB.GetTechSupportConnection();
            aConn.Open();
            cmdTechnicianNames.Connection = aConn;

            DataTable dtTechnicianNames = new DataTable();
            dtTechnicianNames.Load(cmdTechnicianNames.ExecuteReader());
            aConn.Close();
            return dtTechnicianNames;
        }

        public DataTable RetrieveTechnicianDetails(int techID)
        {
            SqlParameter incParm = new SqlParameter();
            incParm.ParameterName = "@incidentTech";
            incParm.Value = techID;
            incParm.Direction = ParameterDirection.Input;

            SqlCommand cmdTechnicianNames = new SqlCommand();
            cmdTechnicianNames.Parameters.Add(incParm);
            cmdTechnicianNames.CommandText = "SELECT EMAIL, PHONE FROM DBO.TECHNICIANS" +
                " WHERE TECHID = @incidentTech";
            cmdTechnicianNames.CommandType = CommandType.Text;
            SqlConnection aConn = new SqlConnection();
            aConn = TechSupportDB.GetTechSupportConnection();
            aConn.Open();
            cmdTechnicianNames.Connection = aConn;

            DataTable dtTechnicianDetails = new DataTable();
            dtTechnicianDetails.Load(cmdTechnicianNames.ExecuteReader());
            aConn.Close();
            return dtTechnicianDetails;
        }
    }
}
