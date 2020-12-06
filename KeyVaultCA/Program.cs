using System;
using System.Runtime.ConstrainedExecution;
using Azure.Identity;
using Azure.Security.KeyVault.Certificates;

namespace KeyVaultCA
{
    static class Program
    {
        static void CreateCA(string keyvaultUrl, string id, string caName)
        {
            var credential = new DefaultAzureCredential(true);
            var client = new CertificateClient(new Uri(keyvaultUrl), credential);
            
            var policy = new CACertificatePolicy("Self", caName);
            policy.KeyType = CertificateKeyType.Rsa;
            policy.KeySize = 4096;
            policy.ReuseKey = true;
            policy.KeyUsage.Add(CertificateKeyUsage.KeyCertSign);
            policy.KeyUsage.Add(CertificateKeyUsage.CrlSign);
            policy.Exportable = false;
            policy.Enabled = true;
            policy.CertificateAuthority = true;
            policy.PathLength = 1;
            
        }

        static void CreateHost(string rootCAUrl, string hostName)
        {
            
        }
        
        static void Main(string[] args)
        {
            if (args.Length == 0) { 
                Console.WriteLine("No operation was specified (createca|createhost)");
                return;
            }
            
            var operation = args[0];

            switch (operation.ToLower())
            {
                case "createca":
                    if (args.Length < 3)
                    {
                        Console.WriteLine("createca needs three parameters, keyvault_url id and distinguished_name");
                        return;
                    }
                    CreateCA(args[1], args[2], args[3]);
                    break;
                case "createhost":
                    if (args.Length < 3)
                    {
                        Console.WriteLine("createhost needs two parameters, root_ca_url and host_name");
                        return;
                    }
                    CreateHost(args[1], args[2]);
                    break;
                default:
                    Console.WriteLine("Not a supported operation");
                    return;
            }
        }
    }
}