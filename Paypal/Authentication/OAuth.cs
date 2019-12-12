using System;
using System.Linq;
using Newtonsoft.Json;
using RestSharp;
using RestSharp.Authenticators;

namespace Paypal.Authentication
{
    public class OAuth : IAuthenticator
    {
        private readonly string m_authHeader;

        public OAuth(string token)
        {
            m_authHeader = $"Bearer: {token}";
        }

        public void Authenticate(IRestClient client, IRestRequest request)
        {
            if (request.Parameters.Any(p => "Authorization".Equals(p.Name, StringComparison.OrdinalIgnoreCase)))
            {
                return;
            }

            request.AddParameter("Authorization", m_authHeader, ParameterType.HttpHeader);
        }
    }

    public class OAuthRequest : RestRequest
    {
        public OAuthRequest()
            : base("/v1/oauth2/token", Method.POST)
        {
            AddParameter("grant_type", "client_credentials");
        }
    }

    public class OAuthResponse : RestResponse
    {
        [JsonProperty("access_token")]
        public string AccessToken { get; set; }
    }

    public class IdentityRequest : RestRequest
    {
        public IdentityRequest()
            : base("/v1/identity/oauth2/userinfo", Method.GET)
        {
            AddQueryParameter("schema", "paypalv1.1");
        }
    }

    public class Identity
    {
        [JsonProperty("given_name")] public string Name { get; set; }
    }
}
