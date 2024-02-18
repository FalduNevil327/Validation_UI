using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Data;
using Validation_UI.Areas.LOC_Country.Models;
using Validation_UI.Areas.LOC_Branch.Models;

namespace Validation_UI.Areas.LOC_Branch.Controllers
{
    
    [Area("MST_Branch")]
    [Route("MST_Branch/[controller]/[action]")]
    public class MST_BranchController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        private IConfiguration Configuration;

        public MST_BranchController(IConfiguration _configuration)
        {
            Configuration = _configuration;
        }
        #region SelectAll
        public IActionResult MST_BranchList()
        {
            string connectionString = this.Configuration.GetConnectionString("ConnectionString1");
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            SqlCommand command = connection.CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "PR_Branch_SelectAll";
            SqlDataReader reader = command.ExecuteReader();
            DataTable table = new DataTable();
            table.Load(reader);
            return View(table);
        }
#endregion

        #region Add
        public IActionResult MST_BranchAdd(int BranchID = 0)
        {
            string connectionString = this.Configuration.GetConnectionString("ConnectionString1");
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            SqlCommand command = connection.CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "PR_Branch_SelectByPK";
            command.Parameters.AddWithValue("@BranchID", BranchID);
            SqlDataReader reader = command.ExecuteReader();
            DataTable table = new DataTable();
            table.Load(reader);
            MST_BranchModel mST_BranchModel = new MST_BranchModel();
            foreach (DataRow dataRow in table.Rows)
            {
                mST_BranchModel.BranchID = Convert.ToInt32(dataRow["BranchID"]);
                mST_BranchModel.BranchName = dataRow["BranchName"].ToString();
                mST_BranchModel.BranchCode = dataRow["BranchCode"].ToString();
            }
            return View("MST_BranchAddEdit", mST_BranchModel);
        }
#endregion

        #region Save
        public IActionResult MST_BranchSave(MST_BranchModel lOC_BranchModel, int BranchID = 0)
        {
            string connectionString = this.Configuration.GetConnectionString("ConnectionString1");
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            SqlCommand command = connection.CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            if (BranchID == 0)
            {
                command.CommandText = "PR_Branch_Insert";
                TempData["Msg"] = "Record Inserted Successfully";
            }
            else
            {
                command.CommandText = "PR_Branch_UpdateByPK";
                command.Parameters.AddWithValue("@BranchID", BranchID);
                TempData["Msg"] = "Record Updated Successfully";
            }
            command.Parameters.AddWithValue("@BranchName", lOC_BranchModel.BranchName);
            command.Parameters.AddWithValue("@BranchCode", lOC_BranchModel.BranchCode);
            command.ExecuteNonQuery();
            connection.Close();
            return RedirectToAction("MST_BranchList");
        }
#endregion

        #region Delete
        public IActionResult MSt_BranchDelete(int BranchID)
        {
            string connectionString = this.Configuration.GetConnectionString("ConnectionString1");
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            SqlCommand command = connection.CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "PR_Branch_DeleteByPK";
            command.Parameters.AddWithValue("@BranchID", BranchID);
            TempData["Msg"] = "Record Deleted Successfully";
            command.ExecuteNonQuery();
            connection.Close();
            return RedirectToAction("MST_BranchList");
        }
        #endregion
    }

}
