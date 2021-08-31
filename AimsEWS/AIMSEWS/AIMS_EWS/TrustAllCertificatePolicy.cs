using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;

namespace AIMS_EWS
{
    public class TrustAllCertificatePolicy : ICertificatePolicy
    {
        public void TrustAllCertificatePolicies() { }
        public Boolean CheckValidationResult(ServicePoint sp, X509Certificate cert, 
            WebRequest req, int problem)
        {
            return true;
        }
    }
}
