using NUnit.Framework;
using System.Security.Cryptography.X509Certificates;

namespace Cert.NET.Tests
{
    [TestFixture]
    public class CertificateTests
    {
        [Test]
        public void Certificate_WhenInstantiated_ReturnCert()
        {
            string input = "www.chrisdunne.net";
            var output = new Certificate(input);

            Assert.IsInstanceOf(typeof(Certificate), output);
        }

        [Test]
        public void Certificate_WhenGetCert_ReturnCert()
        {
            string input = "www.chrisdunne.net";
            var output = Certificate.GetCertificate(input);
            Assert.IsInstanceOf(typeof(X509Certificate2), output);
        }

        [Test]
        public void Certificate_WhenGetPublic_ReturnKey()
        {
            Certificate cert = new Certificate("www.chrisdunne.net");
            string output = cert.GetPublicKey();

            Assert.IsNotEmpty(output, "Public Key is empty");
        }

        [Test]
        public void Certificate_WhenGetPrivate_ReturnKey()
        {
            Certificate cert = new Certificate("www.chrisdunne.net");
            string output = cert.GetPrivateKey();

            Assert.IsNotEmpty(output, "Private Key is empty");
        }

        [Test]
        public void Certificate_WhenGetCAB_ReturnKey()
        {
            Certificate cert = new Certificate("www.chrisdunne.net");
            string output = cert.GetCABundle();

            Assert.IsNotEmpty(output, "CA Bundle is empty");
        }

        [Test]
        public void Certificate_WhenDeleted_CheckExists()
        {
            Assert.Fail("Not Implemented");
        }

        [Test]
        public void Certificate_WhenCreate_CheckExists()
        {
            Assert.Fail("Not Implemented");
        }
    }
}
