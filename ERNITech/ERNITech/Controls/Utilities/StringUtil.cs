using System;
using System.Text.RegularExpressions;
using Newtonsoft.Json.Linq;

namespace ERNITech.Controls.Utilities
{
    public class StringUtil
    {
        internal static JObject ToJObject(string str)
        {
            try
            {
                str = str.Insert(0, "{ \"obj\": ");
                str += "}";
                return JObject.Parse(str);
            }
            catch (Exception ex)
            {
                ex.ToString();
                return null;
            }
        }

        internal static bool EmailIsValid(string emailAddress)
        {
            try
            {
                if(ValidEmailRegex.IsMatch(emailAddress))
                {
                    var addr = new System.Net.Mail.MailAddress(emailAddress);
                    return addr.Address == emailAddress;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }

        static Regex ValidEmailRegex = CreateValidEmailRegex();
        private static Regex CreateValidEmailRegex()
        {
            string validEmailPattern = @"^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|"
                + @"([-a-z0-9!#$%&'*+/=?^_`{|}~]|(?<!\.)\.)*)(?<!\.)"
                + @"@[a-z0-9][\w\.-]*[a-z0-9]\.[a-z][a-z\.]*[a-z]$";
            return new Regex(validEmailPattern, RegexOptions.IgnoreCase);
        }
    }
}
