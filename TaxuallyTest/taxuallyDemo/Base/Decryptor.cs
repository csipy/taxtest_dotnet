using System;
using System.Text;
using System.Security.Cryptography;

namespace TaxuallyTest.taxuallyDemo.Base
{
    public static class PasswordDecryptor
    {
        private static readonly DataProtectionScope Scope = DataProtectionScope.CurrentUser;

        public static string Decrypt(string cipher)
        {
            if (string.IsNullOrEmpty(cipher))
            {
                throw new ArgumentNullException(nameof(cipher), "Cipher text cannot be null or empty.");
            }

            try
            {
                byte[] data = Convert.FromBase64String(cipher);
                byte[] decryptedData = ProtectedData.Unprotect(data, null, Scope);
                return Encoding.Unicode.GetString(decryptedData);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Decryption failed.", ex);
            }
        }
    }
}
