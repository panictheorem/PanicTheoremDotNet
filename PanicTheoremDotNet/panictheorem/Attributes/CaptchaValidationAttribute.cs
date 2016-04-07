using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;

namespace panictheorem.Attributes
{
    //applied to ContactController's 
    public class CaptchaValidationAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {

            if (filterContext.RequestContext.HttpContext.Request["g-recaptcha-response"] != null)
            {
                //Get private key from Web.Config file
                string privatekey = WebConfigurationManager.AppSettings["RecaptchaPrivateKey"];
                //Set up request to google to validate captcha
                string response = filterContext.RequestContext.HttpContext.Request["g-recaptcha-response"];
                //Validate captcha and assign to ActionParamater which will be passed to action.
                filterContext.ActionParameters["CaptchaValid"] = Validate(response, privatekey);
            }
        }

        public static bool Validate(string mainresponse, string privatekey)
        {

            try
            {
                //Set up request to google to validate captcha
                HttpWebRequest req = (HttpWebRequest)WebRequest.Create("https://www.google.com/recaptcha/api/siteverify?secret=" + privatekey + "&response=" + mainresponse);

                //Get json response from google
                WebResponse response = req.GetResponse();

                using (StreamReader readStream = new StreamReader(response.GetResponseStream()))
                {
                    //Get response as string
                    string jsonResponse = readStream.ReadToEnd();

                    //convert string to .NET object based on JSON structure
                    JsonResponseObject jobj = JsonConvert.DeserializeObject<JsonResponseObject>(jsonResponse);

                    //return whether 
                    return jobj.success;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
        //.NET object mapping to JSON
        public class JsonResponseObject
        {
            public bool success { get; set; }
            [JsonProperty("error-codes")]
            public List<string> errorcodes { get; set; }
        }
    }
}