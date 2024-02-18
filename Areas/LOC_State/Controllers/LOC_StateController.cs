using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Data;
using Validation_UI.Areas.LOC_Country.Models;
using Validation_UI.Areas.LOC_State.Models;

namespace Validation_UI.Areas.LOC_State.Controllers
{
    
    [Area("LOC_State")]
    [Route("LOC_State/[controller]/[action]")]
    public class LOC_StateController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        private IConfiguration Configuration;

        public LOC_StateController(IConfiguration _configuration)
        {
            Configuration = _configuration;
        }
        public IActionResult LOC_CountryListByID(int CountryID)
        {
            string connectionString = this.Configuration.GetConnectionString("ConnectionString1");
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            SqlCommand command = connection.CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "PR_State_SelectByPK";
            command.Parameters.AddWithValue("StateID", CountryID);
            SqlDataReader reader = command.ExecuteReader();
            DataTable table = new DataTable();
            table.Load(reader);
            connection.Close();
            return View(table);
        }

        #region SelectAll
        public IActionResult LOC_StateList()
        {

            #region Country DropDown
            string connectionString = this.Configuration.GetConnectionString("ConnectionString1");
            SqlConnection connection1 = new SqlConnection(connectionString);
            connection1.Open();
            SqlCommand objCmd1 = connection1.CreateCommand();
            objCmd1.CommandType = CommandType.StoredProcedure;
            objCmd1.CommandText = "PR_Country_ComboBox";
            SqlDataReader reader1 = objCmd1.ExecuteReader();
            DataTable dt1 = new DataTable();
            dt1.Load(reader1);
            connection1.Close();

            List<LOC_CountryModel> list = new List<LOC_CountryModel>();

            foreach (DataRow dr in dt1.Rows)
            {
                LOC_CountryModel countryModel = new LOC_CountryModel();
                countryModel.CountryID = Convert.ToInt32(dr["CountryID"]);
                countryModel.CountryName = dr["CountryName"].ToString();
                list.Add(countryModel);
            }
            ViewBag.CountryList = list;

            #endregion
            
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            SqlCommand command = connection.CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "PR_State_SelectAll";
            SqlDataReader reader = command.ExecuteReader();
            DataTable table = new DataTable();
            table.Load(reader);
            return View("LOC_StateList", table);
        }
        #endregion

        #region Add

        public IActionResult LOC_StateAdd(int StateID = 0)
        {
            #region Country_Comboox
            string connectionString = this.Configuration.GetConnectionString("ConnectionString1");
            SqlConnection sqlConnection1 = new SqlConnection(connectionString);
            sqlConnection1.Open();
            SqlCommand sqlCommand1 = sqlConnection1.CreateCommand();
            sqlCommand1.CommandType = CommandType.StoredProcedure;
            sqlCommand1.CommandText = "PR_Country_ComboBox";
            SqlDataReader sqlDataReader1 = sqlCommand1.ExecuteReader();
            DataTable table1 = new DataTable();
            table1.Load(sqlDataReader1);
            sqlConnection1.Close();

            List<LOC_CountryDropDownModel> list = new List<LOC_CountryDropDownModel>();
            foreach (DataRow item in table1.Rows)
            {
                LOC_CountryDropDownModel lOC_ContryDropDownModel = new LOC_CountryDropDownModel();
                lOC_ContryDropDownModel.CountryID = Convert.ToInt32(item["CountryID"]);
                lOC_ContryDropDownModel.CountryName = item["CountryName"].ToString();
                list.Add(lOC_ContryDropDownModel);
            }
            ViewBag.CountryList = list;

            #endregion

            #region Add

            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            SqlCommand command = connection.CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "PR_State_SelectByPK";
            command.Parameters.AddWithValue("@StateID", StateID);
            SqlDataReader reader = command.ExecuteReader();
            DataTable table = new DataTable();
            table.Load(reader);
            LOC_StateModel lOC_StateModel = new LOC_StateModel();
            foreach (DataRow dataRow in table.Rows)
            {
                lOC_StateModel.StateID = Convert.ToInt32(dataRow["StateID"]);
                lOC_StateModel.StateName = dataRow["StateName"].ToString();
                lOC_StateModel.StateCode = dataRow["StateCode"].ToString();
                lOC_StateModel.CountryID = Convert.ToInt32(dataRow["CountryID"]);
            }
            return View("LOC_StateAddEdit", lOC_StateModel);

            #endregion
        }
        #endregion

        #region Save
        [HttpPost]
        public IActionResult LOC_StateSave(LOC_StateModel modellOC_State, int StateID = 0)
        {
            string connectionString = this.Configuration.GetConnectionString("ConnectionString1");
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            SqlCommand command = connection.CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            if (StateID == 0)
            {
                command.CommandText = "PR_State_Insert";
                TempData["Msg"] = "Record Inserted Successfully";
                //command.Parameters.AddWithValue("@Created", DateTime.Now);
            }
            else
            {
                command.CommandText = "PR_State_UpdateByPK";
                command.Parameters.AddWithValue("@StateID", StateID);
                TempData["Msg"] = "Record Updated Successfully";
            }
            command.Parameters.AddWithValue("@StateName", modellOC_State.StateName);
            command.Parameters.AddWithValue("@StateCode", modellOC_State.StateCode);
            command.Parameters.AddWithValue("@CountryID", modellOC_State.CountryID);
            //command.Parameters.AddWithValue("@Modified", DateTime.Now);
            command.ExecuteNonQuery();
            connection.Close();
            return RedirectToAction("LOC_StateList");
        }
        #endregion

        #region Delete
        public IActionResult LOC_StateDelete(int StateID)
        {
            string connectionString = this.Configuration.GetConnectionString("ConnectionString1");
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            SqlCommand command = connection.CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "PR_State_DeleteByPK";
            command.Parameters.AddWithValue("@StateID", StateID);
            TempData["Msg"] = "Record Deleted Successfully";
            command.ExecuteNonQuery();
            connection.Close();
            return RedirectToAction("LOC_StateList");
        }
        #endregion

        #region FILTER
        public IActionResult LOC_StateFilter(LOC_StateFilterModel FilterModel)
        {
            string connectionStr = this.Configuration.GetConnectionString("ConnectionString1");

            #region Country DropDown

            SqlConnection connection1 = new SqlConnection(connectionStr);
            connection1.Open();
            SqlCommand objCmd1 = connection1.CreateCommand();
            objCmd1.CommandType = CommandType.StoredProcedure;
            objCmd1.CommandText = "PR_Country_ComboBox";
            SqlDataReader reader1 = objCmd1.ExecuteReader();
            DataTable dt1 = new DataTable();
            dt1.Load(reader1);
            connection1.Close();

            List<LOC_CountryModel> list = new List<LOC_CountryModel>();

            foreach (DataRow dr in dt1.Rows)
            {
                LOC_CountryModel countryModel = new LOC_CountryModel();
                countryModel.CountryID = Convert.ToInt32(dr["CountryID"]);
                countryModel.CountryName = dr["CountryName"].ToString();
                list.Add(countryModel);
            }
            ViewBag.CountryList = list;

            #endregion

            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(connectionStr);
            connection.Open();
            SqlCommand objCmd = connection.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "PR_State_filter";
            objCmd.Parameters.AddWithValue("@CountryID", FilterModel.CountryID);
            objCmd.Parameters.AddWithValue("@StateName", FilterModel.StateName);
            objCmd.Parameters.AddWithValue("@StateCode", FilterModel.StateCode);
            SqlDataReader objSDR = objCmd.ExecuteReader();
            dt.Load(objSDR);

            ModelState.Clear();
            return View("LOC_StateList", dt);
        }
        #endregion


    }
}
