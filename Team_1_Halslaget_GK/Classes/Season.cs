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
        public bool track1to9 { get; set; }
        public bool track10to18 { get; set; }
        public bool trackRange { get; set; }

        //Constructor
        public Season()
        {
            DefaultValues();
        }

        /// <summary>
        /// Sets default values for object.
        /// </summary>
        public void DefaultValues()
        {
            track1to9 = true;
            track10to18 = true;
            trackRange = true;
        }

        /// <summary>
        /// Creates a sql string depending on what the user chooses.
        /// </summary>
        /// <returns></returns>
        private string SetCreateSeasonSQLString()
        {
            string sql = "";

            if (track1to9 && track10to18 && trackRange)
            {
                sql = "INSERT INTO season (startdatum, slutdatum, bana) VALUES (@startdatum, @slutdatum, '1-9'),(@startdatum, @slutdatum, '10-18'),(@startdatum, @slutdatum, 'range')";
            }

            else if (track1to9 && track10to18)
            {
                sql = "INSERT INTO season (startdatum, slutdatum, bana) VALUES (@startdatum, @slutdatum, '1-9'),(@startdatum, @slutdatum, '10-18')";
            }

            else if (track1to9 && trackRange)
            {
                sql = "INSERT INTO season (startdatum, slutdatum, bana) VALUES (@startdatum, @slutdatum, '1-9'),(@startdatum, @slutdatum, 'range')";
            }

            else if (track10to18 && trackRange)
            {
                sql = "INSERT INTO season (startdatum, slutdatum, bana) VALUES (@startdatum, @slutdatum, '10-18'),(@startdatum, @slutdatum, 'range')";
            }

            else if (track1to9)
            {
                sql = "INSERT INTO season (startdatum, slutdatum, bana) VALUES (@startdatum, @slutdatum, '1-9')";
            }

            else if (track10to18)
            {
                sql = "INSERT INTO season (startdatum, slutdatum, bana) VALUES (@startdatum, @slutdatum, '10-18')";
            }

            else if (trackRange)
            {
                sql = "INSERT INTO season (startdatum, slutdatum, bana) VALUES (@startdatum, @slutdatum, 'range')";
            }

            return sql;
        }

        /// <summary>
        /// Inserts a new season into the database.
        /// </summary>
        public void CreateSeason()
        {
            NpgsqlConnection conn = new NpgsqlConnection(WebConfigurationManager.ConnectionStrings["connectionString"].ConnectionString);
            try
            {
                string sql = SetCreateSeasonSQLString();
                conn.Open();
                NpgsqlCommand cmd = new NpgsqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@startdatum", StartDate);
                cmd.Parameters.AddWithValue("@slutdatum", EndDate);

                cmd.ExecuteNonQuery();
            }

            catch
            {
                NpgsqlException ex;
            }

            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }

        /// <summary>
        /// Gets the latest date in the database, in other words the season ending date.
        /// </summary>
        /// <returns></returns>
        public DateTime GetLatestDate()
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

                if(dt.Rows.Count < 0)
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

        /// <summary>
        /// Uses method GetLatestDate to retrieve latestdate in the database 
        /// and if the year of the latest date is this year it creates a list
        /// starting from next year. Otherwise a list with this year included.
        /// </summary>
        /// <returns></returns>
        public List<int> CreateYearList()
        {
            List<int> years = new List<int>();

            int startYear = GetLatestDate().Year;
            int thisYear = DateTime.Today.Year;
            int fiveYeares = startYear + 5;

            if(startYear > thisYear)
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