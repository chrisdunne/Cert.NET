using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.OpenSsl;
using Org.BouncyCastle.Security;
using System;
using System.IO;
using System.Security.Cryptography;
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
            var store = new X509Store(StoreName.My, StoreLocation.LocalMachine);

            store.Open(OpenFlags.OpenExistingOnly);

            var cert = store.Certificates.Find(X509FindType.FindBySubjectName, name, false);

            if (cert.Count == 0) return null;

            return cert[0];
        }

        public string GetPublicKey()
        {
            var sb = new StringBuilder();
            sb.AppendLine("-----BEGIN CERTIFICATE-----");
            sb.AppendLine(Convert.ToBase64String(_cert.Export(X509ContentType.Cert), Base64FormattingOptions.InsertLineBreaks));
            sb.AppendLine("-----END CERTIFICATE-----");
            return sb.ToString();
        }

        public string GetPrivateKey()
        {
            var rsa = (RSACryptoServiceProvider)_cert.PrivateKey;
            var memoryStream = new MemoryStream();
            var streamWriter = new StreamWriter(memoryStream);
            var pemWriter = new PemWriter(streamWriter);
            var keyPair = DotNetUtilities.GetRsaKeyPair(rsa);

            pemWriter.WriteObject(keyPair.Private);
            streamWriter.Flush();

            var output = Encoding.ASCII.GetString(memoryStream.GetBuffer()).Trim();
            var index_of_footer = output.IndexOf("-----END RSA PRIVATE KEY-----");

            memoryStream.Close();
            streamWriter.Close();

            return output.Substring(0, index_of_footer + 29);
        }
    }
}
