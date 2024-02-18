﻿using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Data;
using Validation_UI.Areas.LOC_Country.Models;
using System.Reflection;

namespace Validation_UI.Areas.LOC_Country.Controllers
{
   [Area("LOC_Country")]
    [Route("LOC_Country/[controller]/[action]")]
    public class LOC_CountryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        private IConfiguration Configuration;

        public LOC_CountryController(IConfiguration _configuration)
        {
            Configuration = _configuration;
        }

        #region SelectAll
        public IActionResult LOC_CountryList()
        {
            string connectionString = this.Configuration.GetConnectionString("ConnectionString1");
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            SqlCommand command = connection.CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "PR_Country_SelectAll";
            SqlDataReader reader = command.ExecuteReader();
            DataTable table = new DataTable();
            table.Load(reader);
            return View(table);
        }
        #endregion

        #region CountryListByID
        public IActionResult LOC_CountryListByID(int CountryID)
        {
            string connectionString = this.Configuration.GetConnectionString("ConnectionString1");
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            SqlCommand command = connection.CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "PR_Country_SelectByPK";
            command.Parameters.AddWithValue("CountryID", CountryID);
            SqlDataReader reader = command.ExecuteReader();
            DataTable table = new DataTable();
            table.Load(reader);
            connection.Close();
            return View(table);
        }
        #endregion

        #region Save
        public IActionResult LOC_CountrySave(LOC_CountryModel lOC_CountryModel, int CountryID = 0)
        {
            string connectionString = this.Configuration.GetConnectionString("ConnectionString1");
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            SqlCommand command = connection.CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            if (CountryID == 0)
            {
                command.CommandText = "PR_Country_Insert";
                TempData["Msg"] = "Record Inserted Successfully";
            }
            else
            {
                command.CommandText = "PR_Country_UpdateByPK";
                command.Parameters.AddWithValue("@CountryID", CountryID);
                TempData["Msg"] = "Record Updated Successfully";
            }
           
            command.Parameters.AddWithValue("@CountryName", lOC_CountryModel.CountryName);
            command.Parameters.AddWithValue("@CountryCode", lOC_CountryModel.CountryCode);
            command.ExecuteNonQuery();
            connection.Close();
            return RedirectToAction("LOC_CountryList");
        }
        #endregion

        #region Delete
        public IActionResult LOC_CountryDelete(int CountryID)
        {
            string connectionString = this.Configuration.GetConnectionString("ConnectionString1");
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            SqlCommand command = connection.CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "PR_Country_DeleteByPK";
            command.Parameters.AddWithValue("@CountryID", CountryID);
            TempData["Msg"] = "Record Deleted Successfully";
            command.ExecuteNonQuery();
            connection.Close();
            return RedirectToAction("LOC_CountryList"); 
        }
        #endregion

        #region Add
        public IActionResult LOC_CountryAdd(int CountryID = 0)
        {
            string connectionString = this.Configuration.GetConnectionString("ConnectionString1");
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            SqlCommand command = connection.CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "PR_Country_SelectByPK";
            command.Parameters.AddWithValue("@CountryID", CountryID);
            SqlDataReader reader = command.ExecuteReader();
            DataTable table = new DataTable();
            table.Load(reader);
            LOC_CountryModel lOC_CountryModel = new LOC_CountryModel();
            foreach (DataRow dataRow in table.Rows)
            {
                lOC_CountryModel.CountryID = Convert.ToInt32(dataRow["CountryID"]);
                lOC_CountryModel.CountryName = dataRow["CountryName"].ToString();
                lOC_CountryModel.CountryCode = dataRow["CountryCode"].ToString();
            }
            return View("LOC_CountryAddEdit", lOC_CountryModel);
        }
        #endregion

        #region SEARCH
        public IActionResult LOC_CountrySearchByName(string? CountryName)
        {
            string connectionStr = this.Configuration.GetConnectionString("ConnectionString1");
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(connectionStr);
            connection.Open();
            SqlCommand objCmd = connection.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "PR_Country_SelectByCountryName";
            objCmd.Parameters.AddWithValue("@CountryName", CountryName);
            SqlDataReader objSDR = objCmd.ExecuteReader();
            dt.Load(objSDR);
            return View("LOC_CountryList", dt);
        }
        #endregion
    }
}

