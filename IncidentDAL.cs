using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace SportsProDALClassLibrary
{
    public class IncidentDAL
    {
        public DataTable RetrieveAllIncidents()
        {
            SqlCommand cmdAllIncidents = new SqlCommand();
            cmdAllIncidents.CommandText = "SELECT INCIDENTID," +
                " CUSTOMERID, PRODUCTCODE, TECHID, DATEOPENED," +
                " DATECLOSED, TITLE, DESCRIPTION FROM DBO.INCIDENTS";
            cmdAllIncidents.CommandType = CommandType.Text;
            SqlConnection aConn = new SqlConnection();
            aConn = TechSupportDB.GetTechSupportConnection();
            aConn.Open();
            cmdAllIncidents.Connection = aConn;

            DataTable dtAllIncidents = new DataTable();
            dtAllIncidents.Load(cmdAllIncidents.ExecuteReader());
            aConn.Close();
            return dtAllIncidents;
        }

        public DataTable RetrieveIncidentsByTechnician(int techID)
        {
            SqlParameter incParm = new SqlParameter();
            incParm.ParameterName = "@incidentTech";
            incParm.Value = techID;
            incParm.Direction = ParameterDirection.Input;

            SqlCommand cmdIncidentByTech = new SqlCommand();
            cmdIncidentByTech.Parameters.Add(incParm);
            cmdIncidentByTech.CommandText = "SELECT INCIDENTID," +
                " CUSTOMERID, PRODUCTCODE, TECHID, DATEOPENED," +
                " DATECLOSED, TITLE, DESCRIPTION FROM " +
                "DBO.INCIDENTS WHERE TECHID = @incidentTech";

            cmdIncidentByTech.CommandType = CommandType.Text;
            SqlConnection aConn = new SqlConnection();
            aConn = TechSupportDB.GetTechSupportConnection();
            aConn.Open();
            cmdIncidentByTech.Connection = aConn;

            DataTable dtIncidentsByTech = new DataTable();
            dtIncidentsByTech.Load(cmdIncidentByTech.ExecuteReader());
            return dtIncidentsByTech;
        } 

        public DataTable RetrieveOpenIncidentsByTechnician(int techID)
        {
            SqlParameter incParm = new SqlParameter();
            incParm.ParameterName = "@incidentTech";
            incParm.Value = techID;
            incParm.Direction = ParameterDirection.Input;

            SqlCommand cmdOpenIncidentByTech = new SqlCommand();
            cmdOpenIncidentByTech.Parameters.Add(incParm);
            cmdOpenIncidentByTech.CommandText = "SELECT INCIDENTID," +
                " CUSTOMERID, PRODUCTCODE, TECHID, DATEOPENED," +
                " DATECLOSED, TITLE, DESCRIPTION FROM " +
                "DBO.INCIDENTS WHERE DATECLOSED IS NULL AND TECHID = @incidentTech";

            cmdOpenIncidentByTech.CommandType = CommandType.Text;
            SqlConnection aConn = new SqlConnection();
            aConn = TechSupportDB.GetTechSupportConnection();
            aConn.Open();
            cmdOpenIncidentByTech.Connection = aConn;

            DataTable dtOpenIncidentsByTech = new DataTable();
            dtOpenIncidentsByTech.Load(cmdOpenIncidentByTech.ExecuteReader());
            return dtOpenIncidentsByTech;
        }
    }
}
