using System.Text.Json;
using Azure.Security.KeyVault.Certificates;

namespace KeyVaultCA
{
    public class CACertificatePolicy : CertificatePolicy
    {
        private const string BasicConstraintsPropertyName = "basic_constraints";
        private const string CAPropertyName = "ca";
        private const string PathLengthPropertyName = "path_len_constraint";
        
        private static readonly JsonEncodedText s_basicConstraintsPropertyNameBytes = JsonEncodedText.Encode(BasicConstraintsPropertyName);
        
        private static readonly JsonEncodedText s_caPropertyNameBytes = JsonEncodedText.Encode(CAPropertyName);
        
        private static readonly JsonEncodedText s_pathLengthPropertyNameBytes = JsonEncodedText.Encode(PathLengthPropertyName);
        
        public CACertificatePolicy(string issuerName, string subject) : base(issuerName, subject)
        {
        }

        public CACertificatePolicy(string issuerName, SubjectAlternativeNames subjectAlternativeNames) : base(issuerName, subjectAlternativeNames)
        {
        }

        public CACertificatePolicy(string issuerName, string subject, SubjectAlternativeNames subjectAlternativeNames) : base(issuerName, subject, subjectAlternativeNames)
        {
        }
        
        public bool? CertificateAuthority { get; set; }
        
        public int? PathLength { get; set; }
        
        
    }
}