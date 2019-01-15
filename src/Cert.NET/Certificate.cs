using System.Security.Cryptography.X509Certificates;

namespace Cert.NET
{
    public class Certificate
    {
        private X509Certificate2 _cert;

        public Certificate(string name)
        {
            _cert = new X509Certificate2();
        }

        public string GetPublicKey()
        {
            return "Public Key";
        }

        public string GetPrivateKey()
        {
            return "Private Key";
        }

        public string GetCABundle()
        {
            return "CA Bundle";
        }
    }
}
