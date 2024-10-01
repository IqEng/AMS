using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AMS
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //string key = GenerateRandomKey(64);
            //string skey = GenerateRandomKey(32);
        }

        private static string GenerateRandomKey(int length)
        {
            byte[] buff = new byte[length];
            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(buff);
            }
            return BitConverter.ToString(buff).Replace("-", "");
        }
    }
}