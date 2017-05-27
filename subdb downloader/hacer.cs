using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.IO;
using System.Security.Permissions;
using System.Net;

namespace SubDBSharp
{
    public static class hacer
    {
        private static string useragent = "SubDB/1.0 (SubDBSharp/0.1; https://github.com/Albrod/SubBDSharp)";
        private static string languages = "http://api.thesubdb.com/?action=languages";
        private static string download="";
        private static string algo = "";

        public static string getHash(string filePath)
        {
            int readSize = 64 * 1024;
            byte[] bytes = new byte[2 * readSize];
            using (BinaryReader reader = new BinaryReader(new FileStream(filePath, FileMode.Open)))
            {
                byte[] firstBytes = new byte[readSize];
                byte[] lastBytes = new byte[readSize];
                reader.Read(firstBytes, 0, readSize);
                reader.BaseStream.Seek(-(readSize), SeekOrigin.End);
                reader.Read(lastBytes, 0, readSize);
                Array.Copy(firstBytes, bytes, firstBytes.Length);
                Array.Copy(lastBytes, 0, bytes, firstBytes.Length, lastBytes.Length);
            }
            var md5 = System.Security.Cryptography.MD5.Create().ComputeHash(bytes);
            var sb = new StringBuilder();
            foreach (var b in md5)
                sb.Append(b.ToString("X2"));
            return sb.ToString();
        }

        public static string algo()
        {
            string datosrespuesta = "";
            HttpWebRequest pedido = WebRequest.Create(languages) as HttpWebRequest;
            pedido.UserAgent = useragent;
            pedido.Method = "GET";
            using (HttpWebResponse respuesta = pedido.GetResponse() as HttpWebResponse)
            {
                using (StreamReader lector = new StreamReader(respuesta.GetResponseStream()))
                {
                    datosrespuesta = lector.ReadToEnd();
                    lector.Close();
                }

                respuesta.Close();
            }
            return datosrespuesta;
        }
    }
}
