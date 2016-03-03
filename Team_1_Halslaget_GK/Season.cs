//Class for season, should be updated with more methods and/or fields/propertis
//Erik Drysén 2016-03-03.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Npgsql;
using System.Data;
using System.Web.Configuration;

namespace Team_1_Halslaget_GK
{
    public class Season
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        private DateTime GetLatestDate()
        {
            NpgsqlConnection conn = new NpgsqlConnection(WebConfigurationManager.ConnectionStrings["connectionString"].ConnectionString);
            DateTime date;
            try
            {
                conn.Open();
                NpgsqlCommand cmdGetMaxID = new NpgsqlCommand("SELECT MAX(slutdatum) FROM season; ", conn);
                NpgsqlDataAdapter nda = new NpgsqlDataAdapter();
                nda.SelectCommand = cmdGetMaxID;
                DataTable dt = new DataTable();
                nda.Fill(dt);

                if(dt.Rows.Count > 0)
                {
                    date = DateTime.Now.AddYears(-1);
                    return date;
                }
                else
                {
                    date = DateTime.Parse(dt.Rows[0]["max"].ToString());
                    return date;
                }
            }
            catch (NpgsqlException ex)
            {
                //NpgsqlException = ex.Message;
                date = DateTime.Today;
                return date;
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }

        public List<int> CreateYearList()
        {
            List<int> years = new List<int>();

            int startYear = GetLatestDate().Year;
            int thisYear = DateTime.Today.Year;
            int fiveYeares = startYear + 5;
            if(startYear <= thisYear)
            {
                startYear++;
                for (int i = startYear; i < fiveYeares; i++)
                {
                    years.Add(startYear);
                    startYear++;
                }
                return years;
            }
            else
            {
                for (int i = startYear; i < fiveYeares; i++)
                {
                    years.Add(startYear);
                    startYear++;
                }
                return years;
            }
        }

    }
}