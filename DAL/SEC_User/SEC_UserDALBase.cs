//using System.Data.Common;
//using System.Data;
//using Microsoft.Practices.EnterpriseLibrary.Data.Sql;

//namespace Validation_UI.DAL.SEC_User
//{
//    public class SEC_UserDALBase :SEC_DALHelper

//    {
//        #region Method: dbo_PR_SEC_User_SelectByPK
//        public DataTable dbo_PR_SEC_User_SelectByUserNamePassword(string UserName, string Password)
//        {
//            try
//            {
//                SqlDatabase sqlDB = new SqlDatabase(ConnectionString);
//                DbCommand dbCMD = sqlDB.GetStoredProcCommand("dbo.PR_SEC_User_SelectByUserNamePassword");
//                sqlDB.AddInParameter(dbCMD, "UserName", SqlDbType.VarChar, UserName);
//                sqlDB.AddInParameter(dbCMD, "Password", SqlDbType.VarChar, Password);

//                DataTable dt = new DataTable();
//                using (IDataReader dr = sqlDB.ExecuteReader(dbCMD))
//                {
//                    dt.Load(dr);
//                }

//                return dt;
//            }
//            catch (Exception ex)
//            {
//                return null;
//            }
//        }
//        #endregion
//    }
//}
