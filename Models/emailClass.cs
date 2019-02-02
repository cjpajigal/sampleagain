using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IncidentManagement.Models
{
    public class emailClass
    {

        public void NewHeadlessEmail(string fromEmail, string password, string toAddress, string subject, string body)
        {
            using (System.Net.Mail.MailMessage myMail = new System.Net.Mail.MailMessage())
            {
                myMail.From = new System.Net.Mail.MailAddress(fromEmail);
                myMail.To.Add(toAddress);
                myMail.Subject = subject;
                myMail.IsBodyHtml = true;
                myMail.Body = body;



                using (System.Net.Mail.SmtpClient s = new System.Net.Mail.SmtpClient("smtp.gmail.com", 587))
                {
                    s.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
                    s.UseDefaultCredentials = false;
                    s.Credentials = new System.Net.NetworkCredential(myMail.From.ToString(), password);
                    s.EnableSsl = true;
                    s.Send(myMail);
                }
            }
        }

        /*
        public ActMonitor GetActivity(int id)
        {
            try
            {
                using (Activity_MonitoringEntities act = new Activity_MonitoringEntities())
                {
                    string actmon = (from x in act.ActMonitors
                                     orderby x.Unique_CAR_ID descending
                                      select x ).Take(1).ToString();
    /*SELECT
    CONCAT(s.[Size],' ', t.Type,' ' ,i.Incident_Event,' @ ', a.Location ,' (', n.ID,' Grid DMZ ',d.DMZ_Facility,'). Date & Time Discovered - ', a.[Date and Time of CAR Submission] ,' Root Cuse - ',' With cutomer imapct ',a.[Affected Area],
    '; No. of AHH: ', a.[Number of Affected Households], '; (*key accounts )', 'Status')

    FROM [Activity Monitoring].[dbo].[ActMonitor] a
    INNER JOIN [Activity Monitoring].[dbo].[Size] s ON a.size = s.id
    INNER JOIN [Activity Monitoring].[dbo].[Type$] t ON a.[Type of Equipment/Appurtenance] = t.ID
    INNER JOIN [Activity Monitoring].[dbo].[Incident_Event] i ON a.Incident = i.ID
    INNER JOIN [Activity Monitoring].[dbo].[NetworkGrid_BA] n ON a.[Network Grid/BA] = n.ID
    INNER JOIN [Activity Monitoring].[dbo].[DMZFacility] d ON a.[DMZ/ Facility] = d.ID

                    return actmon;
                }
            }
            catch (Exception)
            {
                return null;
            }

        }*/

    }
}