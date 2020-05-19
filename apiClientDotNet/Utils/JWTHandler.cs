using System;
using apiClientDotNet.Models;
using System.Security.Cryptography;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Security;
using Org.BouncyCastle.OpenSsl;
using Org.BouncyCastle.Crypto.Parameters;
using System.IO;
using System.IdentityModel.Tokens.Jwt;
using Jose;

namespace apiClientDotNet.Utils
{
    public class JWTHandler
    {
        public string generateJWT(SymConfig config)
        {
            string jwt = "";
            AsymmetricKeyParameter secret = parseSecret(config);
            DateTime expirationTime = DateTime.Now.AddMinutes(4);

            var payload = new JwtPayload
            {
                { "sub", config.BotUsername },
                { "exp", ToUtcSeconds(expirationTime) }
            };

            RSAParameters rsaParams = DotNetUtilities.ToRSAParameters(secret as RsaPrivateCrtKeyParameters);

            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
            {
                rsa.ImportParameters(rsaParams);
                jwt = JWT.Encode(payload, rsa, JwsAlgorithm.RS512);
            }
            return jwt;
        }

        private AsymmetricKeyParameter parseSecret(SymConfig config)
        {
            AsymmetricCipherKeyPair keyPair;
            using (var reader = File.OpenText(config.BotPrivateKeyPath + config.BotPrivateKeyName)) // file containing RSA PKCS1 private key
            {
                keyPair = (AsymmetricCipherKeyPair)new PemReader(reader).ReadObject();
            }
            AsymmetricKeyParameter privateKey = keyPair.Private;

            return privateKey;
        }

        private static long ToUtcSeconds(DateTime dt)
        {
            return (dt.ToUniversalTime().Ticks - new DateTime(1970, 1, 1).Ticks) / TimeSpan.TicksPerSecond;
        }
    }
}
