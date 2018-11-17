using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace WEB_APP_SCHOOL_NET.UC
{
    public partial class sms : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //var accountSid = "AC33382ed841dc6a086a2867083ecd9be0";
            //// Your Auth Token from twilio.com/console
            //var authToken = "d5167bd66e9dd6d8f13b247b223aa5ac";

            //TwilioClient.Init(accountSid, authToken);

            //var message = MessageResource.Create(
            //    to: new PhoneNumber("+919873321199"),
            //    from: new PhoneNumber("+14342772139"),
            //    body: "Hello from C#");
            //string sid = message.Sid;
            ////Console.WriteLine(message.Sid);
            ////Console.Write("Press any key to continue.");
            ////Console.ReadKey();
        }
    }
}