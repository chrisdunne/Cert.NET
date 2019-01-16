using System;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Cert.NET
{
    public class Certificate : ICertificate
    {
        private X509Certificate2 _cert;

        public Certificate(string name)
        {
            _cert = GetCertificate(name);
        }

        public static X509Certificate2 GetCertificate(string name)
        {
            X509Store store = new X509Store(StoreName.My, StoreLocation.LocalMachine);

            store.Open(OpenFlags.OpenExistingOnly);

            var cert = store.Certificates.Find(X509FindType.FindBySubjectName, name, false);

            if (cert.Count == 0) return null;

            return cert[0];
        }

        public string GetPublicKey()
        {
            var sb = new StringBuilder();
            sb.AppendLine("-----BEGIN CERTIFICATE-----");
            sb.AppendLine(Convert.ToBase64String(_cert.Export(X509ContentType.Cert)/*, Base64FormattingOptions.InsertLineBreaks*/));
            sb.AppendLine("-----END CERTIFICATE-----");
            return sb.ToString();
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
