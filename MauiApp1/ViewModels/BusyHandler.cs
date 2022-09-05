using MauiApp1.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1.ViewModels
{
    public class BusyHandler
    {
        public bool isBusy { get; set; }
        public string message { get; private set; }
        public Action clickHandler { get; private set; }
        public RestResponseStatus respstatus { get; private set; }

        //       public IRequest theRequest;
        public CancellationTokenSource canceltokensource;

        public BusyHandler(Network.IRequest theRequest)
        {
            this.isBusy = true;
            this.canceltokensource = theRequest.cancelSource;
        }
        public BusyHandler(string message)
        {
            this.isBusy = isBusy;
            this.message = message;
        }

        public async Task ExecuteBusyAction(Func<Task> theBusyAction)
        {
            if (isBusy)
                return;
            try
            {
                isBusy = true;
                await theBusyAction();
            }
            catch (Exception e)
            {
                //Debug.WriteLine(e.Message);
            }
            finally
            {
                isBusy = false;
            }
        }


        public BusyHandler(RestResponseStatus respstatus)
        {
            this.respstatus = respstatus;
            switch (respstatus.ErrType)
            {
                case HttpException.ErrorType.NoError:
                    message = null;
                    break;
                case HttpException.ErrorType.NetworkError:
                    message = "Network error";
                    break;
                case HttpException.ErrorType.SavedData:
                    message = "Showing saved data";
                    break;
                case HttpException.ErrorType.Canceled:
                    message = "Request canceled";
                    break;
                default:
                    message = "Server error"; ;
                    break;
            }
        }

        public BusyHandler()
        {
            isBusy = true;
        }

        public BusyHandler(bool isbusy)
        {
            isBusy = isbusy;
        }

        public BusyHandler(CancellationTokenSource canceltokensource)
        {
            this.canceltokensource = canceltokensource;
        }
    }
}
