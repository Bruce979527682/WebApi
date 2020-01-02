using JWT;
using JWT.Algorithms;
using JWT.Builder;
using Newtonsoft.Json;
using System;

namespace Utility
{
    public class JwtHelper
    {
        /// <summary>
        /// 创建jwtToken,采用微软内部方法，默认使用HS256加密，如果需要其他加密方式，请更改源码
        /// 返回的结果和CreateToken一样
        /// </summary>
        /// <param name="payLoad"></param>
        /// <param name="expiresMinute">有效分钟</param>
        /// <returns></returns>
        public static string CreateToken(int userId)
        {
            var token = new JwtBuilder()
                .WithAlgorithm(new HMACSHA256Algorithm())
                .WithSecret(ConfigHelper.GetValue("SecurityKey"))
                .AddClaim("exp", DateTimeOffset.UtcNow.AddHours(1).ToUnixTimeSeconds())
                .AddClaim("userid", userId)
                .Build();
            return token;
        }

        /// <summary>
        /// 验证身份 验证签名的有效性,
        /// </summary>
        /// <param name="token"></param>
        /// 例如：payLoad["aud"]?.ToString() == "roberAuddience";
        /// 例如：验证是否过期 等
        /// <returns></returns>
        public static bool Validate(string token)
        {
            var success = false;
            if (string.IsNullOrWhiteSpace(token))
            {
                return success;
            }
            try
            {
                var json = new JwtBuilder()
                    .WithSecret(ConfigHelper.GetValue("SecurityKey"))
                    .MustVerifySignature()
                    .Decode(token);
                var info = JsonConvert.DeserializeObject<JwtInfo>(json);                
                if (info != null)
                {
                    success = true;
                }
            }
            catch (TokenExpiredException)
            {
                Console.WriteLine("Token has expired");
            }
            catch (SignatureVerificationException)
            {
                Console.WriteLine("Token has invalid signature");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return success;
        }

        private class JwtInfo
        {
            public long exp { get; set; }
            public int userid { get; set; }
        }

    }
}
