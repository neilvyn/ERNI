using System;
using ERNITech.Models;
using Xamarin.Forms;

namespace ERNITech.Services.Predefined
{
    public class Constants
    {
        #region urls
        private const string Local_BaseUrl = "127.0.0.1";
        private const string Exam_BaseUrl = "https://gist.githubusercontent.com";
        #endregion

#if DEBUG
        private static string BASE_ADDRESS = Local_BaseUrl;
#elif STAGING
        private static string BASE_ADDRESS = Exam_BaseUrl;
#elif RELEASE
        private static string BASE_ADDRESS = Exam_BaseUrl;
#else
        private static string BASE_ADDRESS = Exam_BaseUrl;
#endif

        #region api routes
        public static string URL_USERS = BASE_ADDRESS + "/erni-ph-mobile-team/c5b401c4fad718da9038669250baff06/raw/7e390e8aa3f7da4c35b65b493fcbfea3da55eac9/test.json";
        #endregion

        #region keys
        public static string AUTH_HEADER = "SampleHeaderAuthTokenPass@1234";
        #endregion

        #region default_flag_responses
        public static int FLAG_SUCCESS = 200;
        public static int FLAG_NOT_FOUND = 404;
        public static int FLAG_VALIDATION_ERROR = 400;
        public static int FLAG_SERVER_ERROR = 500;
        public static int FLAG_SESSION_EXPIRED = 401;
        #endregion

        #region alert_messages
        public static string CriticalTitleAlert = "Error";
        public static string DefaultTitleAlert = "Alert Message";
        public static string AlertPositiveLabel = "Got It!";
        public static string DefaultSuccessAlert = "Updated Successfully";

        public static AlertMessageModel HOST_UNREACHABLE = new AlertMessageModel { Title = "Host Unreachable", Description = "The URL cannot be reached and seems to be unavailable. Please try again later." };
        public static AlertMessageModel NO_CONNECTION = new AlertMessageModel { Title = "Failed Connection", Description = "Please check your internet connection and try again." };
        public static AlertMessageModel CANCELED_OPERATION = new AlertMessageModel { Title = "Canceled Operation", Description = "Request has been canceled." };
        public static AlertMessageModel REQUEST_TIMEOUT = new AlertMessageModel { Title = "Request Timeout", Description = "Please check your internet connection and try again." };
        #endregion

        #region colors
        public static readonly Color HEADER_COLOR = Color.FromHex("d1d1d1");
        public static readonly Color BUTTON_COLOR = Color.FromHex("097bed");
        public static readonly Color ALERT_COLOR = Color.Red;
        #endregion

        #region screen_pages
        public static string NAVIGATION_PAGE = "NavigationPage";
        public static string UsersPage = "UsersPage";
        public static string UserDetailPage = "UserDetailPage";
        #endregion
    }
}
