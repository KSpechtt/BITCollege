using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.Xml.Linq;
using System.IO;

namespace Utility
{
    /// <summary>
    /// Represents a static class of Encryption
    /// </summary>
    public static class Encryption
    {
        /// <summary>
        /// Encrypts file.
        /// </summary>
        /// <param name="unencryptedFilename">The file to be encrypted</param>
        /// <param name="encryptedFileName">The name of the encrypted file.</param>
        /// <param name="key">The encryption key.</param>
        public static void encrypt(string unencryptedFilename , string encryptedFileName, string key)
        {
            FileStream fileStream = new FileStream(unencryptedFilename, FileMode.Open, FileAccess.Read);

            FileStream secondStream = new FileStream(encryptedFileName, FileMode.Create, FileAccess.Write);

            DESCryptoServiceProvider provider = new DESCryptoServiceProvider();

            provider.Key = ASCIIEncoding.ASCII.GetBytes(key);

            provider.IV = provider.Key;

            ICryptoTransform transform = provider.CreateEncryptor();

            CryptoStream cryptoStream = new CryptoStream(secondStream, transform, CryptoStreamMode.Write);

            byte[] byteArray = new byte[fileStream.Length];

            fileStream.Read(byteArray, 0, byteArray.Length);

            cryptoStream.Write(byteArray, 0, byteArray.Length);

            cryptoStream.Close();

            fileStream.Close();

            secondStream.Close();
        }

        /// <summary>
        /// Decrpyts the file.
        /// </summary>
        /// <param name="encryptedFileName">The name of the encrypted file.</param>
        /// <param name="unencryptedFileName">The name of the file after decrpyted</param>
        /// <param name="key">The encryption key.</param>
        public static void decrypt(string encryptedFileName, string unencryptedFileName, string key)
        {

            StreamWriter streamWriter = new StreamWriter(unencryptedFileName);
            try
            {
               

                DESCryptoServiceProvider provider = new DESCryptoServiceProvider();

                provider.Key = ASCIIEncoding.ASCII.GetBytes(key);

                provider.IV = provider.Key;

                FileStream fileStream = new FileStream(encryptedFileName, FileMode.Open, FileAccess.Read);

                ICryptoTransform transform = provider.CreateDecryptor();

                CryptoStream cryptoStream = new CryptoStream(fileStream, transform, CryptoStreamMode.Read);

                

                streamWriter.Write(new StreamReader(cryptoStream).ReadToEnd());

                streamWriter.Flush();

                streamWriter.Close();
            }
            catch (Exception ex)
            {
                streamWriter.Close();

                throw new Exception("An error has occured while attemping to decrypt.. :" + ex.Message);

            }

        }
    }
}
