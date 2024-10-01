using AMS;
using System;
using System.Configuration;

public class AuthClass
{
    public AuthClass()
    {
        // Constructor
    }

    public static string Getconstring()
    {
        try
        {
            string encryptedDbKey = ConfigurationManager.AppSettings["Kripton_Key"];
            string encryptedConStr = ConfigurationManager.AppSettings["ConStr"];

            string decryptedDbKey = Kripta.Decrypt(encryptedDbKey, "PPASha@#$%-=.Pas").ToString().Trim();            
            string decryptedConStr = Kripta.Decrypt(encryptedConStr, "PPASha@#$%-=.Con").ToString().Trim().Replace("pass", decryptedDbKey);

            return decryptedConStr;
        }
        catch
        {
            return string.Empty;
        }
    }
}
