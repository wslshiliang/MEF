using Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Utility
{
    public static class Security
    {
        private static readonly string AES_KEY = "#KGDYNIAKL!";
        /// <summary>
        /// AES 加密
        /// </summary>
        /// <param name="sourceString">原始密码文本</param>
        /// <returns>AES加密后的密码</returns>
        public static string AESEncryptor(string sourceString)
        {
            if (string.IsNullOrEmpty(sourceString)) return null;
            Byte[] toEncryptArray = Encoding.UTF8.GetBytes(sourceString);

            RijndaelManaged rm = new RijndaelManaged
            {
                Key = Encoding.UTF8.GetBytes(AES_KEY),
                Mode = CipherMode.ECB,
                Padding = PaddingMode.PKCS7
            };

            ICryptoTransform cTransform = rm.CreateEncryptor();
            Byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);

            return Convert.ToBase64String(resultArray, 0, resultArray.Length);
        }
        /// <summary>
        /// AES 解密
        /// </summary>
        /// <param name="aesString">原始密码文本</param>
        /// <returns>AES加密后的密码</returns>
        public static string AESDecryptor(string aesString)
        {
            if (string.IsNullOrEmpty(aesString)) return null;
            Byte[] toEncryptArray = Convert.FromBase64String(aesString);

            RijndaelManaged rm = new RijndaelManaged
            {
                Key = Encoding.UTF8.GetBytes(AES_KEY),
                Mode = CipherMode.ECB,
                Padding = PaddingMode.PKCS7
            };

            ICryptoTransform cTransform = rm.CreateDecryptor();
            Byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);

            return Encoding.UTF8.GetString(resultArray);
        }
        /// <summary>
        /// MD5加密
        /// </summary>
        /// <param name="sourceString"></param>
        /// <returns></returns>
        public static string Md5Encryptor(string sourceString)
        {
            string cl = sourceString;
            string pwd = "";
            MD5 md5 = MD5.Create(); //实例化一个md5对像
                                    // 加密后是一个字节类型的数组，这里要注意编码UTF8/Unicode等的选择　
            byte[] s = md5.ComputeHash(Encoding.UTF8.GetBytes(cl));
            // 通过使用循环，将字节类型的数组转换为字符串，此字符串是常规字符格式化所得
            for (int i = 0; i < s.Length; i++)
            {
                // 将得到的字符串使用十六进制类型格式。格式后的字符是小写的字母，如果使用大写（X）则格式后的字符是大写字符 
                pwd = pwd + s[i].ToString("X");
            }
            return pwd;
        }
        /// <summary>
        /// 计算密码强度
        /// </summary>
        /// <param name="password">密码字符串</param>
        /// <returns></returns>
        public static Strength PasswordStrength(string password)
        {
            //空字符串强度值为0
            if (password == "") return Strength.Invalid;
            //字符统计
            int iNum = 0, iLtt = 0, iSym = 0;
            foreach (char c in password)
            {
                if (c >= '0' && c <= '9') iNum++;
                else if (c >= 'a' && c <= 'z') iLtt++;
                else if (c >= 'A' && c <= 'Z') iLtt++;
                else iSym++;
            }
            if (iLtt == 0 && iSym == 0) return Strength.Weak; //纯数字密码
            if (iNum == 0 && iLtt == 0) return Strength.Weak; //纯符号密码
            if (iNum == 0 && iSym == 0) return Strength.Weak; //纯字母密码
            if (password.Length <= 6) return Strength.Weak; //长度不大于6的密码
            if (iLtt == 0) return Strength.Normal; //数字和符号构成的密码
            if (iSym == 0) return Strength.Normal; //数字和字母构成的密码
            if (iNum == 0) return Strength.Normal; //字母和符号构成的密码
            if (password.Length <= 10) return Strength.Normal; //长度不大于10的密码
            return Strength.Strong; //由数字、字母、符号构成的密码
        }
    }
}
