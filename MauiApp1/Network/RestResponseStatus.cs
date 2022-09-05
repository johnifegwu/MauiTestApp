using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MauiApp1.Network.HttpException;

namespace MauiApp1.Network
{
    [Serializable()]
    public class RestResponseStatus
    {
        private ErrorType errType = ErrorType.NoError;

        public int StatusCode { get; set; }
        public string Message { get; set; }
        public ErrorType ErrType
        {
            get => errType;
            set
            {
                errType = value;
                if (errType == ErrorType.SavedData)
                    Message = "Showing Stored Data";
            }
        }
        public int ErrorCode { get; set; } //set from EventResponse

    }
}
