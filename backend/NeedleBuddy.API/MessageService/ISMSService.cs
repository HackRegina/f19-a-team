using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NeedleBuddy.API.MessageService
{
    public interface ISMSService
    {
        void SendSMSMessage(string phoneNumber);
    }
}
