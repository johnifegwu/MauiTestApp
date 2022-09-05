using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Web;
using JsonIgnoreAttribute = Newtonsoft.Json.JsonIgnoreAttribute;
using JsonSerializer = Newtonsoft.Json.JsonSerializer;

namespace MauiApp1.Network
{
    [Serializable()]
    public abstract class IRequest
    {
        [JsonIgnore()]
        public CancellationTokenSource cancelSource;

        [JsonIgnore()]
        public CancellationToken cancelToken { get; private set; }

        public virtual byte[] PostBytes() { return null; }

        public bool AllowLogging = true;
        public virtual bool UseCookies { get { return true; } }

        public static bool SkipFlurl { get; set; } = false;

        public static bool GetCustomUrl { get; set; } = false;

        private string url;

        public string Url
        {
            get
            {
                if (SkipFlurl)
                {
                    if (GetCustomUrl)
                    {
                        return url;
                    }
                    else
                    {
                        return ServerUrl + Query + QueryString();
                    }
                }
                else
                {
                    return Flurl.Url.Combine(ServerUrl, Query) + QueryString();
                }


            }
            set
            {
                url = value;
            }
        }
        protected string Query;
        public string ServerUrl;
        public bool IsBinaryResponse { get; internal set; }

        public string Postdata { get; internal set; }

        public virtual string AcceptMimeType { get { return "text/html;charset=iso-8859-1"; } }
        public abstract string QueryString();
        public abstract string PostString();

        public virtual string ContentType { get { return "application/x-www-form-urlencoded"; } }

        public bool UseAccessToken;
        public IRequest()
        {
            cancelSource = new CancellationTokenSource();
            cancelToken = (cancelSource as CancellationTokenSource).Token;


        }

        public void Cancel()
        {
            try
            {
                (cancelSource as CancellationTokenSource).Cancel();
            }
            catch (Exception e) { }
        }
    }

    [Serializable()]
    public class PostParamsGen : IRequest
    {
        protected string RocketMobile = "/webservices/cmaeon/rocket/mobile";
        protected string Rocket = "/webservices/cmaeon/rocket";

        protected Dictionary<string, object> PostParameters;

        public PostParamsGen()
        {
            ServerUrl = "";//AccountSettings.SharedAccountSettings.ServerURL;
        }
        public override string PostString()
        {
            bool encodeParameters = true;
            if (jsonParamName != null)
            {
                if (PostParameters == null)
                    PostParameters = new Dictionary<string, object>();
                JsonSerializer ijson = JsonObj as JsonSerializer;
                encodeParameters = false;
                if (ijson != null)
                {
                    //PostParameters.Add(jsonParamName, ijson.JsonSerialize());
                }
                else
                {
                    PostParameters.Add(jsonParamName, JsonConvert.SerializeObject(JsonObj));
                }

            }
            string post = PostParameters == null ? "" : string.Join("&",
                PostParameters.Where((o) => o.Value != null).ToList().Select((o) =>
                { return o.Key + "=" + (encodeParameters ? HttpUtility.UrlEncode(o.Value.ToString()) : o.Value.ToString()); }));
            return post;
        }
        string jsonParamName;
        public object JsonObj { get; set; }
        protected void AddJsonData(string pname, object jsonObj)
        {
            jsonParamName = pname;
            JsonObj = jsonObj;
        }

        public override string QueryString()
        {
            return null;
        }

        public static string QueryString(IDictionary<string, object> dict)
        {
            var list = new List<string>();
            foreach (var item in dict)
            {
                list.Add(item.Key + "=" + item.Value);
            }
            return string.Join("&", list);
        }

    }

    [Serializable()]
    public class RestApiRequest : IRequest
    {
        public override bool UseCookies { get { return false; } }

        protected Dictionary<string, object> PostParameters;

        public RestApiRequest()
        {
            ServerUrl = RestApi;
            UseAccessToken = true;
        }

        string RestApi = "";//AccountSettings.SharedAccountSettings.ApiURL;

        public override string PostString()
        {
            if (JsonObj != null) //rest api call
                return JsonConvert.SerializeObject(JsonObj);
            else
                return null;
        }
        public object JsonObj { get; set; }

        public override string QueryString()
        {
            if (PostParameters != null)
            {
                string post = PostParameters == null ? "" : string.Join("&",
                PostParameters.Where((o) => o.Value != null).ToList().Select((o) =>
                { return o.Key + "=" + o.Value.ToString(); }));
                return post;
            }
            return null;
        }

        public string AcceptTextType { get => "text/plain"; }
        public override string AcceptMimeType { get { return "application/json"; } }
        public override string ContentType { get { return "application/json-patch+json"; } }
    }
    public class QueryParamsGen : IRequest
    {
        public QueryParamsGen()
        {
            ServerUrl = "";//AccountSettings.SharedAccountSettings.ServerURL;
        }
        protected Dictionary<string, object> QueryParameters;

        protected string RocketMobile = "/webservices/cmaeon/rocket/mobile";
        protected string Rocket = "/webservices/cmaeon/rocket";

        public override string PostString()
        {
            return null;
        }

        public override string QueryString()
        {
            return QueryParameters == null ? "" : string.Join("&",
                QueryParameters.Where((o) => o.Value != null).ToList().Select((o) =>
                { return o.Key + "=" + HttpUtility.UrlEncode(o.Value.ToString()); }));
        }
    }


}
