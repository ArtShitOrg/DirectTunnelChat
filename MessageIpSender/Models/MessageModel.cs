using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageIpSender.Models
{
    public class MessageModel
    {
        public bool IsFromMe { get; set; }
        public string Message { get; set; }
        public TimeSpan Time { get; set; }

        public MessageModel() { }
        public MessageModel(bool isFromMe, string message, TimeSpan time)
        {
            IsFromMe = isFromMe;
            Message = message;
            Time = time;
        }
    }
}
