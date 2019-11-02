using NeedleBuddy.DB;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeedleBuddy.API.MessageService
{
    public class SMSService : ISMSService
    {
        private string _baseUri;
        private string _accountKey;
        private string _message = "The needle you reported has been retrieved. Thank you for your report!";
        public SMSService(string baseUri, IRepository _repository)
        {
            _baseUri = baseUri;
            _accountKey = _repository.GetSMSsecret().Clientsecret1;
        }

        public void SendSMSMessage(string phoneNumber)
        {
            dynamic body = new ExpandoObject();
            body.MessageBody = _message;

            using (var wClient = new System.Net.WebClient())
            {
                wClient.Encoding = Encoding.UTF8;
                wClient.Headers.Add("content-type", "application/json");

                wClient.UploadString($"{_baseUri}/{_accountKey}/{phoneNumber}",
                  Newtonsoft.Json.JsonConvert.SerializeObject(body));
            }
        }
    }
}
