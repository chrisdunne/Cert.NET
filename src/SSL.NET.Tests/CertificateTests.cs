using NUnit.Framework;

namespace Cert.NET.Tests
{
    [TestFixture]
    public class CertificateTests
    {
        [Test]
        public void Certificate_WhenInstantiated_CreateCert()
        {
            string name = "www.chrisdunne.net";
            Certificate cert = new Certificate(name);

            Assert.IsInstanceOf(typeof(Certificate), cert);
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
