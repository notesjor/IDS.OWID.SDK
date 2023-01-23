using System.Security.Cryptography;
using System.Text;

namespace IDS.OWID.SDK
{
  public static class CredentialStore
  {
    public static void SaveCredentials(byte[] data, string password, string path) 
      => File.WriteAllBytes(path, ProtectedData.Protect(data, Encoding.UTF8.GetBytes(password), DataProtectionScope.CurrentUser));

    public static byte[] LoadCredentials(string password, string path)
      => ProtectedData.Unprotect(File.ReadAllBytes(path), Encoding.UTF8.GetBytes(password), DataProtectionScope.CurrentUser);
  }
}