using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cert.NET
{
    public interface ICertificate
    {
        string GetPublicKey();
        string GetPrivateKey();
        string GetCABundle();
    }
}
