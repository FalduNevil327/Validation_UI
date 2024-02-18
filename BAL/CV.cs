//namespace Validation_UI.BAL
//{
//    public class CV
//    {
//        private static IHttpContextAccessor _HttpContextAccessor;
//        static CV()
//        {
//            _HttpContextAccessor = new HttpContextAccessor();
//        }

//        public static int? UserID()
//        {
//            return Convert.ToInt32(_HttpContextAccessor.HttpContext.Session.GetString("UserID"));
//        }

//        public static string UserName()
//        {
//            return _HttpContextAccessor.HttpContext.Session.GetString("UserName");
//        }

//        public static string PhotoPath()
//        {
//            return _HttpContextAccessor.HttpContext.Session.GetString("PhotoPath");
//        }

//        public static string FirstName()
//        {
//            return _HttpContextAccessor.HttpContext.Session.GetString("FirstName");
//        }

//        public static string LastName()
//        {
//            return _HttpContextAccessor.HttpContext.Session.GetString("LastName");
//        }
//    }
//}
