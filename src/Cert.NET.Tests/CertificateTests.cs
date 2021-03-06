﻿using NUnit.Framework;
using System.Security.Cryptography.X509Certificates;

namespace Cert.NET.Tests
{
    [TestFixture]
    public class CertificateTests
    {
        [Test]
        public void Certificate_WhenInstantiated_ReturnCert()
        {
            string input = "chrisdunne.net";
            var output = new Certificate(input);

            Assert.IsInstanceOf(typeof(Certificate), output);
        }

        [Test]
        public void Certificate_WhenGetCert_ReturnCert([Values("chrisdunne.net", "localhost")]string input)
        {
            var output = Certificate.GetCertificate(input);

            Assert.IsTrue(output == null || output.GetType() == typeof(X509Certificate2));
        }

        [Test]
        public void Certificate_WhenGetPublic_ReturnKey()
        {
            Certificate cert = new Certificate("chrisdunne.net");
            string output = cert.GetPublicKey();

            Assert.IsNotEmpty(output, "Public Key is empty");
            StringAssert.Contains("-----BEGIN CERTIFICATE-----", output);
            StringAssert.Contains("-----END CERTIFICATE-----", output);
        }

        [Test]
        public void Certificate_WhenGetPrivate_ReturnKey()
        {
            Certificate cert = new Certificate("chrisdunne.net");
            string output = cert.GetPrivateKey();

            Assert.IsNotEmpty(output, "Private Key is empty");
            StringAssert.Contains("-----BEGIN CERTIFICATE-----", output);
            StringAssert.Contains("-----END RSA PRIVATE KEY-----", output);
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
