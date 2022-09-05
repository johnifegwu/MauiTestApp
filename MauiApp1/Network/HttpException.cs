using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1.Network
{
    [Serializable()]
    public class HttpException : Exception
    {
        public enum ErrorType
        {
            NoError,
            NetworkError,
            ServerError,
            APIError,
            SavedData,
            Canceled
        }

        public ErrorType ErrType { get; set; } //1 : server error; 2: network error; 

        public HttpException(ErrorType type = ErrorType.NoError) : base()
        {
            this.ErrType = type;
        }

        public HttpException(string message, ErrorType type = ErrorType.NoError) : base(message)
        {
            this.ErrType = type;

        }

        public HttpException(string message, Exception innerException, ErrorType type = ErrorType.NoError) : base(message, innerException)
        {
            this.ErrType = type;
        }
    }

}
