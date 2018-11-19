using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using SportsProDALClassLibrary;

namespace SportsProBLLClassLibrary
{
    public class IncidentBLL
    {
        public List<Incident> GetAllIncidents()
        {
            List<Incident> lstIncidents = new List<Incident>();
            DataTable dtAllIncidents = new DataTable();
            IncidentDAL incDAL = new IncidentDAL();
            dtAllIncidents = incDAL.RetrieveAllIncidents();
            foreach (DataRow dr in dtAllIncidents.Rows)
            {
                Incident anIncident = new Incident();
                anIncident.IncidentID = (int)dr["IncidentID"];
                anIncident.CustomerID = (int)dr["CustomerID"];
                anIncident.ProductCode = dr["ProductCode"].ToString();
                if (dr.IsNull("TechID"))
                { anIncident.TechID = null; }
                else
                { anIncident.TechID = (int?)dr["TechID"]; }
                anIncident.DateOpened = (DateTime)dr["DateOpened"];
                if (dr.IsNull("DateClosed"))
                { anIncident.DateClosed = null; }
                else
                { anIncident.DateClosed = (DateTime?)dr["DateClosed"]; }
                anIncident.Title = dr["Title"].ToString();
                anIncident.Description = dr["Description"].ToString();
                lstIncidents.Add(anIncident);
            }
            return lstIncidents;
        }

        public List<Incident> GetIncidentsByTechnician(int techID)
        {
            List<Incident> lstIncidentsByTech = new List<Incident>();
            DataTable dtIncidentsByTech = new DataTable();
            IncidentDAL incDal = new IncidentDAL();
             dtIncidentsByTech = incDal.RetrieveIncidentsByTechnician(techID);
            foreach (DataRow dr in dtIncidentsByTech.Rows)
            {
                Incident anIncident = new Incident();
                anIncident.IncidentID = (int)dr["IncidentID"];
                anIncident.CustomerID = (int)dr["CustomerID"];
                anIncident.ProductCode = dr["ProductCode"].ToString();
                if (dr.IsNull("TechID"))
                { anIncident.TechID = null; }
                else
                { anIncident.TechID = (int?)dr["TechID"]; }
                anIncident.DateOpened = (DateTime)dr["DateOpened"];
                if (dr.IsNull("DateClosed"))
                { anIncident.DateClosed = null; }
                else
                { anIncident.DateClosed = (DateTime?)dr["DateClosed"]; }
                anIncident.Title = dr["Title"].ToString();
                anIncident.Description = dr["Description"].ToString();
                lstIncidentsByTech.Add(anIncident);
            }
            return lstIncidentsByTech;
        }

        public List<Incident> GetOpenIncidentsByTechnician(int techID)
        {
            List<Incident> lstOpenIncidentsByTech = new List<Incident>();
            DataTable dtOpenIncidentsByTech = new DataTable();
            IncidentDAL incDal = new IncidentDAL();
            dtOpenIncidentsByTech = incDal.RetrieveOpenIncidentsByTechnician(techID);
            foreach (DataRow dr in dtOpenIncidentsByTech.Rows)
            {
                    Incident anIncident = new Incident();
                    anIncident.IncidentID = (int)dr["IncidentID"];
                    anIncident.CustomerID = (int)dr["CustomerID"];
                    anIncident.ProductCode = dr["ProductCode"].ToString();
                    if (dr.IsNull("TechID"))
                    { anIncident.TechID = null; }
                    else
                    { anIncident.TechID = (int?)dr["TechID"]; }
                    anIncident.DateOpened = (DateTime)dr["DateOpened"];
                    anIncident.DateClosed = null;
                    anIncident.Title = dr["Title"].ToString();
                    anIncident.Description = dr["Description"].ToString();
                    lstOpenIncidentsByTech.Add(anIncident);
            }
            return lstOpenIncidentsByTech;
        }        
    }
}
