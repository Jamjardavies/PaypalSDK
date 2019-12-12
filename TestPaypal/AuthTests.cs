using System.Net;
using System.Threading.Tasks;
using NUnit.Framework;
using Paypal;
using Paypal.Authentication;
using RestSharp;

namespace TestPaypal
{
    public class Tests
    {
        private const string ClientId = "AXB1-y7WRDgoqLlY55TX4SJXZe_H1E_eh9znHv6_JCeU3H92frkVqOoEjsSAi3bIJbh-Lm3mbKhAyzDN";
        private const string ClientSecret = "EOVJvijci_ZMPe47JtzLVb3dUeGGSLz4YJD3dn21rnfG1ta6UhZpEzWrZlbKdxEan0WOAwhlo8xys6Ra";

        private PaypalClient m_client;

        [SetUp]
        public void Setup()
        {
            m_client = new PaypalClient(new LiveEnvironment(ClientId, ClientSecret));
        }

        [Test]
        public async Task TestAuthentication()
        {
            IRestResponse<OAuthResponse> oauth = await m_client.ExecuteTaskAsync<OAuthResponse>(new OAuthRequest());

            Assert.IsTrue(oauth.IsSuccessful);
            Assert.AreEqual(oauth.StatusCode, HttpStatusCode.OK);
        }
    }
}