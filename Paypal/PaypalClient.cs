using System.IO;
using System.Net;
using System.Threading.Tasks;
using Paypal.Authentication;
using Newtonsoft.Json;
using RestSharp;
using RestSharp.Deserializers;
using RestSharp.Serializers;

namespace Paypal
{
    public interface IPaypalEnvironment
    {
        string Url { get; }
        string ClientId { get; }
        string ClientSecret { get; }
    }

    public class SandboxEnvironment : IPaypalEnvironment
    {
        public string Url => "https://api.sandbox.paypal.com";
        public string ClientId { get; }
        public string ClientSecret { get; }

        public SandboxEnvironment(string clientId, string clientSecret)
        {
            ClientId = clientId;
            ClientSecret = clientSecret;
        }
    }

    public class LiveEnvironment : IPaypalEnvironment
    {
        public string Url => "https://api.paypal.com";
        public string ClientId { get; }
        public string ClientSecret { get; }

        public LiveEnvironment(string clientId, string clientSecret)
        {
            ClientId = clientId;
            ClientSecret = clientSecret;
        }
    }

    public class PaypalClient : RestClient
    {
        private IPaypalEnvironment m_environment;

        public PaypalClient(IPaypalEnvironment environment)
            : base(environment.Url)
        {
            m_environment = environment;

            Encoding = System.Text.Encoding.UTF8;
            Authenticator = new BasicAuthentication(environment.ClientId, environment.ClientSecret);

            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            AddHandler("application/json", () => NewtonsoftJsonSerializer.Default);
        }

        public override async Task<IRestResponse> ExecuteTaskAsync(IRestRequest request)
        {
            if (Authenticator is BasicAuthentication)
            {
                await Authenticate();
            }

            return await base.ExecuteGetTaskAsync(request);
        }

        //public async Task<IRestResponse> ExecuteAsync<T>(T req) where T : IRestRequest
        //{
        //    // Make sure we're auth'ed.
        //    //if (m_authToken == null && req.Parameters.All(p => p.Name != "Authorization"))
        //    //{
        //    //    IRestResponse response = await Authenticate();

        //    //    Console.WriteLine("Got response");
        //    //}

        //    return await ExecuteGetTaskAsync(req);
        //}

        private async Task Authenticate()
        {
            IRestResponse<OAuthResponse> oauth = await base.ExecuteTaskAsync<OAuthResponse>(new OAuthRequest());

            Authenticator = new OAuth(oauth.Data.AccessToken);
        }
    }

    public class NewtonsoftJsonSerializer : ISerializer, IDeserializer
    {
        private readonly JsonSerializer m_serializer;

        public NewtonsoftJsonSerializer(JsonSerializer serializer)
        {
            m_serializer = serializer;
        }

        public string ContentType
        {
            get => "application/json";
            set { }
        }

        public string DateFormat { get; set; }

        public string Namespace { get; set; }

        public string RootElement { get; set; }

        public string Serialize(object obj)
        {
            using (StringWriter stringWriter = new StringWriter())
            {
                using (JsonTextWriter jsonTextWriter = new JsonTextWriter(stringWriter))
                {
                    m_serializer.Serialize(jsonTextWriter, obj);

                    return stringWriter.ToString();
                }
            }
        }

        public T Deserialize<T>(RestSharp.IRestResponse response)
        {
            string content = response.Content;

            using (StringReader stringReader = new StringReader(content))
            {
                using (JsonTextReader jsonTextReader = new JsonTextReader(stringReader))
                {
                    return m_serializer.Deserialize<T>(jsonTextReader);
                }
            }
        }

        public static NewtonsoftJsonSerializer Default =>
            new NewtonsoftJsonSerializer(new Newtonsoft.Json.JsonSerializer()
            {
                NullValueHandling = NullValueHandling.Ignore,
            });
    }
}
