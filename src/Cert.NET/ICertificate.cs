namespace Cert.NET
{
    public interface ICertificate
    {
        string GetPublicKey();
        string GetPrivateKey();
    }
}
