using System;
using System.Security.Cryptography;
using System.Text;

namespace LuckyMonkey.Utility.Library.EncryptionRelated
{
    /// <summary>
    /// 算法加密有关的类级【SHA1、MD5】
    /// </summary>
    public class EncryptionAlgorithm
    {
        /// <summary>
        /// SHA1加密方法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string Sha1Encrypt(string input)
        {
            //
            var buffer = Encoding.UTF8.GetBytes(input);

            var data = SHA1.Create().ComputeHash(buffer);
            var sb = new StringBuilder();
            foreach (var t in data)
            {
                sb.AppendFormat("{0:x2}", t);
            }
            return sb.ToString();
        }

        /// <summary>
        /// 将数据进行Md5加密，返回16位字符串
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string Md5EncryptToStr16(string input)
        {
            string md5Pwd = string.Empty;

            //使用加密服务提供程序
            var md5 = MD5.Create();

            var buffer = Encoding.UTF8.GetBytes(input);

            var hashBuffer = md5.ComputeHash(buffer);
            //将指定的字节子数组的每个元素的数值转换为它的等效十六进制字符串表示形式。
            md5Pwd = BitConverter.ToString(hashBuffer).Replace("-","").Substring(8,16);

            return md5Pwd;
        }

        /// <summary>
        /// 将数据进行Md5加密，返回32位字符串
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string Md5EncryptToStr32(string input)
        {
            var md5Pwd = string.Empty;
            var md5 = MD5.Create();
            var buffer = Encoding.UTF8.GetBytes(input);
            var hashBuffer = md5.ComputeHash(buffer);
            var stringBuilder = new StringBuilder();
            for (int i = 0; i < hashBuffer.Length; i++)
            {
                stringBuilder.AppendFormat(hashBuffer[i].ToString("x2"));
            }
            return stringBuilder.ToString();
        }
    }

}
