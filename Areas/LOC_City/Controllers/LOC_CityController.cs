using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Data;
using Validation_UI.Areas.LOC_Country.Models;
using Validation_UI.Areas.LOC_State.Models;
using Validation_UI.Areas.LOC_City.Models;

namespace Validation_UI.Areas.LOC_City.Controllers
{
    
    [Area("LOC_City")]
    [Route("LOC_City/[controller]/[action]")]
    public class LOC_CityController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        private IConfiguration Configuration;

        public LOC_CityController(IConfiguration _configuration)
        {
            Configuration = _configuration;
        }


        //#region SelectAll
        //public IActionResult LOC_CityList()
        //{
        //    string connectionString = this.Configuration.GetConnectionString("ConnectionString1");
        //    SqlConnection connection = new SqlConnection(connectionString);
        //    connection.Open();
        //    SqlCommand command = connection.CreateCommand();
        //    command.CommandType = CommandType.StoredProcedure;
        //    command.CommandText = "PR_City_SelectAll";
        //    SqlDataReader reader = command.ExecuteReader();
        //    DataTable table = new DataTable();
        //    table.Load(reader);
        //    return View("LOC_CityList", table);
        //}
        //#endregion

        //#region Add

        //public IActionResult LOC_CityAdd(int CityID = 0)
        //{
        //    #region Country_Comboox
        //    string connectionString = this.Configuration.GetConnectionString("ConnectionString1");
        //    SqlConnection sqlConnection1 = new SqlConnection(connectionString);
        //    sqlConnection1.Open();
        //    SqlCommand sqlCommand1 = sqlConnection1.CreateCommand();
        //    sqlCommand1.CommandType = CommandType.StoredProcedure;
        //    sqlCommand1.CommandText = "PR_Country_ComboBox";
        //    SqlDataReader sqlDataReader1 = sqlCommand1.ExecuteReader();
        //    DataTable table1 = new DataTable();
        //    table1.Load(sqlDataReader1);
        //    sqlConnection1.Close();

        //    List<LOC_ContryDropDownModel> list1 = new List<LOC_ContryDropDownModel>();
        //    foreach (DataRow item in table1.Rows)
        //    {
        //        LOC_ContryDropDownModel lOC_ContryDropDownModel = new LOC_ContryDropDownModel();
        //        lOC_ContryDropDownModel.CountryID = Convert.ToInt32(item["CountryID"]);
        //        lOC_ContryDropDownModel.CountryName = item["CountryName"].ToString();
        //        list1.Add(lOC_ContryDropDownModel);
        //    }
        //    ViewBag.CountryList = list1;

        //    #endregion

        //    #region State_ComboBox
        //    SqlConnection sqlConnection2 = new SqlConnection(connectionString);
        //    sqlConnection2.Open();
        //    SqlCommand sqlCommand2 = sqlConnection2.CreateCommand();
        //    sqlCommand2.CommandType = CommandType.StoredProcedure;
        //    sqlCommand2.CommandText = "PR_State_ComboBox";
        //    SqlDataReader sqlDataReader2 = sqlCommand2.ExecuteReader();
        //    DataTable table2 = new DataTable();
        //    table2.Load(sqlDataReader2);
        //    sqlConnection2.Close();

        //    List<LOC_StateDropDownModel> list2 = new List<LOC_StateDropDownModel>();
        //    foreach (DataRow item in table2.Rows)
        //    {
        //        LOC_StateDropDownModel lOC_StateDropDownModel = new LOC_StateDropDownModel();
        //        lOC_StateDropDownModel.StateID = Convert.ToInt32(item["StateID"]);
        //        lOC_StateDropDownModel.StateName = item["StateName"].ToString();
        //        list2.Add(lOC_StateDropDownModel);
        //    }
        //    ViewBag.StateList = list2;

        //    #endregion

        //    #region Add

        //    SqlConnection connection = new SqlConnection(connectionString);
        //    connection.Open();
        //    SqlCommand command = connection.CreateCommand();
        //    command.CommandType = CommandType.StoredProcedure;
        //    command.CommandText = "PR_City_SelectByPK";
        //    command.Parameters.AddWithValue("@CityID", CityID);
        //    SqlDataReader reader = command.ExecuteReader();
        //    DataTable table = new DataTable();
        //    table.Load(reader);
        //    LOC_CityModel lOC_CityModel = new LOC_CityModel();
        //    foreach (DataRow dataRow in table.Rows)
        //    {
        //        lOC_CityModel.CityID = Convert.ToInt32(dataRow["CityID"]);
        //        lOC_CityModel.CityName = dataRow["CityName"].ToString();
        //        lOC_CityModel.CityCode = dataRow["CityCode"].ToString();
        //        lOC_CityModel.StateID = Convert.ToInt32(dataRow["StateID"]);
        //        lOC_CityModel.CountryID = Convert.ToInt32(dataRow["CountryID"]);
        //    }
        //    return View("LOC_CityAddEdit", lOC_CityModel);

        //    #endregion
        //}
        //#endregion

        //#region Save
        //public IActionResult LOC_CitySave(LOC_CityModel modellOC_City, int CityID = 0)
        //{
        //    string connectionString = this.Configuration.GetConnectionString("ConnectionString1");
        //    SqlConnection connection = new SqlConnection(connectionString);
        //    connection.Open();
        //    SqlCommand command = connection.CreateCommand();
        //    command.CommandType = CommandType.StoredProcedure;
        //    if (CityID == 0)
        //    {
        //        command.CommandText = "PR_City_Insert";
        //    }
        //    else
        //    {
        //        command.CommandText = "PR_City_UpdateByPK";
        //        command.Parameters.AddWithValue("@CityID", CityID);
        //    }

        //    command.Parameters.AddWithValue("@CityName", modellOC_City.CityName);
        //    command.Parameters.AddWithValue("@CityCode", modellOC_City.CityCode);
        //    command.Parameters.AddWithValue("@StateID", modellOC_City.CountryID);
        //    command.Parameters.AddWithValue("@CountryID", modellOC_City.CountryID);
        //    command.ExecuteNonQuery();
        //    connection.Close();
        //    return RedirectToAction("LOC_CityList");
        //}
        //#endregion

        //#region Delete
        //public IActionResult LOC_CityDelete(int CityID)
        //{
        //    string connectionString = this.Configuration.GetConnectionString("ConnectionString1");
        //    SqlConnection connection = new SqlConnection(connectionString);
        //    connection.Open();
        //    SqlCommand command = connection.CreateCommand();
        //    command.CommandType = CommandType.StoredProcedure;
        //    command.CommandText = "PR_City_DeleteByPK";
        //    command.Parameters.AddWithValue("@CityID", CityID);
        //    command.ExecuteNonQuery();
        //    connection.Close();
        //    return RedirectToAction("LOC_CityList");
        //}
        //#endregion


        #region SelectAll
        public IActionResult LOC_CityList()
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

            #region State DropDown

            SqlConnection connection2 = new SqlConnection(connectionString);
            connection2.Open();
            SqlCommand objCmd2 = connection2.CreateCommand();
            objCmd2.CommandType = CommandType.StoredProcedure;
            objCmd2.CommandText = "PR_State_ComboBox";
            SqlDataReader reader2 = objCmd2.ExecuteReader();
            DataTable dt2 = new DataTable();
            dt2.Load(reader2);
            connection2.Close();

            List<LOC_StateDropDownModel> list2 = new List<LOC_StateDropDownModel>();

            foreach (DataRow dr in dt2.Rows)
            {
                LOC_StateDropDownModel stateModel = new LOC_StateDropDownModel();
                stateModel.StateID = Convert.ToInt32(dr["StateID"]);
                stateModel.StateName = dr["stateName"].ToString();
                list2.Add(stateModel);
            }
            ViewBag.StateList = list2;

            #endregion


            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            SqlCommand command = connection.CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "PR_City_SelectAll";
            SqlDataReader reader = command.ExecuteReader();
            DataTable table = new DataTable();
            table.Load(reader);
            connection.Close();
            return View(table);
        }
        #endregion

        #region SelectByID
        public IActionResult LOC_CityListByID(int CityID)
        {
            string connectionString = this.Configuration.GetConnectionString("ConnectionString1");
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            SqlCommand command = connection.CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "PR_City_SelectByPK";
            command.Parameters.AddWithValue("CityID", CityID);
            SqlDataReader reader = command.ExecuteReader();
            DataTable table = new DataTable();
            table.Load(reader);
            connection.Close();
            return View(table);
        }
        #endregion

        #region Save
        public IActionResult LOC_CitySave(LOC_CityModel lOC_CityModel, int CityID = 0)
        {
            string connectionString = this.Configuration.GetConnectionString("ConnectionString1");
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            SqlCommand command = connection.CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            if (CityID == 0)
            {
                command.CommandText = "PR_City_Insert";
                TempData["Msg"] = "Record Inserted Successfully";
            }
            else
            {
                command.CommandText = "PR_City_UpdateByPK";
                command.Parameters.AddWithValue("@CityID", CityID);
                TempData["Msg"] = "Record Updated Successfully";
            }
            command.Parameters.AddWithValue("@CityName", lOC_CityModel.CityName);
            command.Parameters.AddWithValue("@CityCode", lOC_CityModel.CityCode);
            command.Parameters.AddWithValue("@StateID", lOC_CityModel.StateID);
            command.Parameters.AddWithValue("@CountryID", lOC_CityModel.CountryID);
            command.ExecuteNonQuery();
            connection.Close();
            return RedirectToAction("LOC_CityList");
        }
        #endregion

        #region Add
        public IActionResult LOC_CityAdd(int CityID = 0)
        {

            //#region CountryComboBox
            //string connectionString = this.Configuration.GetConnectionString("ConnectionString1");
            //SqlConnection connection2 = new SqlConnection(connectionString);
            //connection2.Open();
            //SqlCommand command2 = connection2.CreateCommand();
            //command2.CommandType = CommandType.StoredProcedure;
            //command2.CommandText = "PR_Country_ComboBox";
            //SqlDataReader reader2 = command2.ExecuteReader();
            //DataTable table2 = new DataTable();
            //table2.Load(reader2);
            //connection2.Close();

            //List<LOC_CountryDropDownModel> list2 = new List<LOC_CountryDropDownModel>();
            //foreach (DataRow row in table2.Rows)
            //{
            //    LOC_CountryDropDownModel lOC_ContryDropDownModel = new LOC_CountryDropDownModel();
            //    lOC_ContryDropDownModel.CountryID = Convert.ToInt32(row["CountryID"]);
            //    lOC_ContryDropDownModel.CountryName = row["CountryName"].ToString();
            //    list2.Add(lOC_ContryDropDownModel);
            //}
            //ViewBag.CountryList = list2;
            //#endregion

            //#region State ComboBox
            //SqlConnection connection1 = new SqlConnection(connectionString);
            //connection1.Open();
            //SqlCommand command1 = connection1.CreateCommand();
            //command1.CommandType = CommandType.StoredProcedure;
            //command1.CommandText = "PR_State_ComboBox";
            //SqlDataReader reader1 = command1.ExecuteReader();
            //DataTable table1 = new DataTable();
            //table1.Load(reader1);
            //connection1.Close();

            //List<LOC_StateDropDownModel> list = new List<LOC_StateDropDownModel>();
            //foreach (DataRow row in table1.Rows)
            //{
            //    LOC_StateDropDownModel lOC_StateDropDownModel = new LOC_StateDropDownModel();
            //    lOC_StateDropDownModel.StateID = Convert.ToInt32(row["StateID"]);
            //    lOC_StateDropDownModel.StateName = row["StateName"].ToString();
            //    list.Add(lOC_StateDropDownModel);
            //}
            //ViewBag.StateList = list;
            //#endregion

            string connectionString = this.Configuration.GetConnectionString("ConnectionString1");

            #region Country_ComboBox


            DataTable dt1 = new DataTable();
            SqlConnection conn1 = new SqlConnection(connectionString);
            conn1.Open();
            SqlCommand objCmd1 = conn1.CreateCommand();
            objCmd1.CommandType = CommandType.StoredProcedure;
            objCmd1.CommandText = "PR_Country_ComboBox";
            SqlDataReader objSDR1 = objCmd1.ExecuteReader();
            dt1.Load(objSDR1);

            List<LOC_CountryDropDownModel> list = new List<LOC_CountryDropDownModel>();

            foreach (DataRow dr in dt1.Rows)
            {
                LOC_CountryDropDownModel vlst = new LOC_CountryDropDownModel();
                vlst.CountryID = Convert.ToInt32(dr["CountryID"]);
                vlst.CountryName = dr["CountryName"].ToString();
                list.Add(vlst);
            }

            ViewBag.CountryList = list;

            #endregion

            #region State_ComboBox
            List<LOC_StateDropDownModel> list1 = new List<LOC_StateDropDownModel>();
            ViewBag.StateList = list1;
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            SqlCommand command = connection.CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "PR_City_SelectByPK";
            command.Parameters.AddWithValue("@CityID", CityID);
            SqlDataReader reader = command.ExecuteReader();
            DataTable table = new DataTable();
            table.Load(reader);
            LOC_CityModel lOC_CityModel = new LOC_CityModel();
            foreach (DataRow dataRow in table.Rows)
            {
                lOC_CityModel.CityID = Convert.ToInt32(dataRow["CityID"]);
                lOC_CityModel.CityName = dataRow["CityName"].ToString();
                lOC_CityModel.CityCode = dataRow["CityCode"].ToString();
                lOC_CityModel.StateID = Convert.ToInt32(dataRow["StateID"]);
                lOC_CityModel.CountryID = Convert.ToInt32(dataRow["CountryID"]);
            }
            return View("LOC_CityAddEdit", lOC_CityModel);
            #endregion
        }
        #endregion

        #region Delete
        public IActionResult LOC_CityDelete(int CityID)
        {
            string connectionString = this.Configuration.GetConnectionString("ConnectionString1");
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            SqlCommand command = connection.CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "PR_City_DeleteByPK";
            command.Parameters.AddWithValue("@CityID", CityID);
            TempData["Msg"] = "Record Deleted Successfully";
            command.ExecuteNonQuery();
            connection.Close();
            return RedirectToAction("LOC_CityList");
        }
        #endregion

        #region FILTER
        public IActionResult LOC_CityFilter(LOC_CityFilterModel FilterModel)
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

            #region State DropDown

            SqlConnection connection2 = new SqlConnection(connectionStr);
            connection2.Open();
            SqlCommand objCmd2 = connection2.CreateCommand();
            objCmd2.CommandType = CommandType.StoredProcedure;
            objCmd2.CommandText = "PR_State_ComboBox";
            SqlDataReader reader2 = objCmd2.ExecuteReader();
            DataTable dt2 = new DataTable();
            dt2.Load(reader2);
            connection2.Close();

            List<LOC_StateDropDownModel> list2 = new List<LOC_StateDropDownModel>();

            foreach (DataRow dr in dt2.Rows)
            {
                LOC_StateDropDownModel stateModel = new LOC_StateDropDownModel();
                stateModel.StateID = Convert.ToInt32(dr["StateID"]);
                stateModel.StateName = dr["stateName"].ToString();
                list2.Add(stateModel);
            }
            ViewBag.StateList = list2;

            #endregion

            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(connectionStr);
            connection.Open();
            SqlCommand objCmd = connection.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "PR_City_filter";
            objCmd.Parameters.AddWithValue("@CountryID", FilterModel.CountryID);
            objCmd.Parameters.AddWithValue("@StateID", FilterModel.StateID);
            objCmd.Parameters.AddWithValue("@CityName", FilterModel.CityName);
            objCmd.Parameters.AddWithValue("@CityCode", FilterModel.CityCode);
            SqlDataReader objSDR = objCmd.ExecuteReader();
            dt.Load(objSDR);

            ModelState.Clear();
            return View("LOC_CityList", dt);
        }
        #endregion

        #region Cascade DropDown of State
        public IActionResult StateDropDownByCountryID(int CountryID)
        {
            string myconnStr1 = this.Configuration.GetConnectionString("ConnectionString1");
            SqlConnection connection1 = new SqlConnection(myconnStr1);
            DataTable dt1 = new DataTable();
            connection1.Open();
            SqlCommand cmd1 = connection1.CreateCommand();
            cmd1.CommandType = CommandType.StoredProcedure;
            cmd1.CommandText = "PR_State_ComboBoxbyCountryId";
            cmd1.Parameters.AddWithValue("@CountryID", CountryID);
            SqlDataReader reader1 = cmd1.ExecuteReader();
            dt1.Load(reader1);

            List<LOC_StateDropDownModel> list = new List<LOC_StateDropDownModel>();

            foreach (DataRow dr in dt1.Rows)
            {
                LOC_StateDropDownModel lstList = new LOC_StateDropDownModel();
                lstList.StateID = Convert.ToInt32(dr["StateID"]);
                lstList.StateName = dr["StateName"].ToString();
                list.Add(lstList);
            }
            var vModel = list;
            return Json(vModel);

        }

        #endregion


    }
}
