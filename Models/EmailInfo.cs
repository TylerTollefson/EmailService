using System.Collections.Generic;
using System.Net.Mail;
using System.Text.RegularExpressions;

namespace EmailService.Models
{
    public class EmailInfo
    {
        public List<string> EmailList { get; set; }
        public int UniqueCount { get; set; }
        static EmailInfo info = null;

        private EmailInfo()
        {
            EmailList = new List<string>();
        }
        public static EmailInfo getCurrent()
        {
            if(info == null)
            {
                info = new EmailInfo();
                return info;
            } else
            {
                return info;
            }
        }

        public void SetEmailList(List<string> emailList)
        {
            EmailList = emailList;
        }

        public void CleanseEmailList()
        {
            //we create an additional list because if we tried to change the element in the EmailList, C# wouldn't like it
            List<string> cleansedList = new List<string>();
            foreach(string email in EmailList)
            {
                MailAddress toCleanse = null;
                toCleanse = new MailAddress(email);
                string user = toCleanse.User;
                string host = toCleanse.Host;

                //if there is a + remove it and ignore all characters after it
                if(user.IndexOf("+") != -1)
                {
                    user = user.Substring(0, user.IndexOf("+"));
                }
                //if there is a . remove it and keep everything else
                if(user.IndexOf(".") != -1)
                {
                    user = Regex.Replace(user, "[@\\.]", string.Empty);
                }

                cleansedList.Add(user + "@" + host);
            }

            //Now that all emails are cleansed make our actual email list pretty
            EmailList = cleansedList;
        }

        public int GetUniqueCount()
        {
            var uniqueEmails = new HashSet<string>(EmailList);
            return uniqueEmails.Count;
        }
    }
}
