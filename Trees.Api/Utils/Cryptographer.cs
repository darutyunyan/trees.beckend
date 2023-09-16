using System.Security.Cryptography;
using System.Text;

namespace Trees.Api.Utils
{
    public static class Cryptographer
    {
        static Cryptographer()
        {
            _rsa = new RSACryptoServiceProvider();
            _rsa.FromXmlString(PUBLIC_KEY);
            _rsa.FromXmlString(PRIVATE_KEY);
        }

        public static string Encrypt(string str)
        {
            byte[] encryptedData = _rsa.Encrypt(Encoding.Unicode.GetBytes(str), true);
            return Convert.ToBase64String(encryptedData);
        }

        public static string Decrypt(string? encryptStr)
        {
            if (encryptStr == null)
                return string.Empty;

            byte[] decryptedData = _rsa.Decrypt(Convert.FromBase64String(encryptStr), true);
            return Encoding.Unicode.GetString(decryptedData);
        }

        private static RSACryptoServiceProvider _rsa;
        private static readonly string PUBLIC_KEY = "<RSAKeyValue><Modulus>+o/LtfVhNi5DUfX4/zlw4mB1vr7Ll9WqYuiqDUZKyClPO4flePBUxdhwQfi/2ghwMSDxVdXH+vZk6BeY+OnUo5GTsRxwknCHuzM1rRWPldt8WawRy4yu/+zdVaCufgV+jrEamoobEMxYZHOwb2NpmNrwt80k3JKrA6Caqpnccxk=</Modulus><Exponent>AQAB</Exponent></RSAKeyValue>";
        private static readonly string PRIVATE_KEY = "<RSAKeyValue><Modulus>+o/LtfVhNi5DUfX4/zlw4mB1vr7Ll9WqYuiqDUZKyClPO4flePBUxdhwQfi/2ghwMSDxVdXH+vZk6BeY+OnUo5GTsRxwknCHuzM1rRWPldt8WawRy4yu/+zdVaCufgV+jrEamoobEMxYZHOwb2NpmNrwt80k3JKrA6Caqpnccxk=</Modulus><Exponent>AQAB</Exponent><P>/FR6Gdy++bnybzmVHayk0+IBwO3oA9EtpnMWDPtOzTNhfWlsyo5rTu3lGlwoQfY68jEVgtwwXmixB5a93yE5gw==</P><Q>/jS8GdQ62+AaTtd0zIVDDNCFLpgWF3KR1gPEQ4jGLDdMA8dYvxJ95j/SY8MHCp9Ck55hqR6kIYcrkF08rS+qMw==</Q><DP>5CqLQmmOswgGhba+9NdRMFs0lL1LyG/U5Kc6cECqj/j/FcVH352KwRNy0DQ3HvZFdQ0XU35BqozmT2Nqi6Jiew==</DP><DQ>yGwdjiPFUExNkbHP9dxvs+/HwafJay06jEkl+bUhwgTLGwOWFffnaZ0SLPO8XoSYgjjSePuenoyrLURFraox/w==</DQ><InverseQ>s1lCiLeNFXHiFemnnubAb+Fu2NUlf3A+eixlXYgY/aY+y0O+3Perm7RTdkIzQ+Jxuimv9+pEY7l8cV9eVYYmeg==</InverseQ><D>JrDdvBNQF5W9P4LEGGU+UTaj9/huZ9vOm8dhuvsHwTDf00mA3dP+wy5Q518KARkcefmkSqTgZJh3rH84V/eDphA0xhX6wA3sdewQ5EFmDd+UGr6St/6zmRfCO3h9lAsRZsyHRyTzt/lX1a116Hed+TqED/7TBrwdukFTvAvbaSE=</D></RSAKeyValue>";
    }
}
