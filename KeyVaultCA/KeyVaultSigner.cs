using Org.BouncyCastle.Crypto;

namespace KeyVaultCA
{
    public class KeyVaultSigner : Org.BouncyCastle.Crypto.ISignatureFactory
    {
        
        
        public IStreamCalculator CreateCalculator()
        {
            throw new System.NotImplementedException();
        }

        public object AlgorithmDetails { get; }
    }
}