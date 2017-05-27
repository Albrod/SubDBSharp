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
        private static string useragent = "SubDB/1.0 (SubDBSharp/0.1; https://github.com/Albrod/SubDBSharp)";
        private static string languages = "http://sandbox.thesubdb.com/?action=languages";
        private static string search = "http://sandbox.thesubdb.com/?action=search&hash=";
        private static string download = "http://sandbox.thesubdb.com/?action=download&hash=";
        private static string hash = "";
        static string languages_available;
        static string path = "";

        public static string getHash(string filePath)
        {
            path = filePath;
            int readSize = 64 * 1024;
            byte[] bytes = new byte[2 * readSize];
            try
            {                
                BinaryReader Bin_Lector = new BinaryReader(new FileStream(filePath, FileMode.Open));
                {
                    byte[] firstBytes = new byte[readSize];
                    byte[] lastBytes = new byte[readSize];
                    Bin_Lector.Read(firstBytes, 0, readSize);
                    Bin_Lector.BaseStream.Seek(-(readSize), SeekOrigin.End);
                    Bin_Lector.Read(lastBytes, 0, readSize);
                    Array.Copy(firstBytes, bytes, firstBytes.Length);
                    Array.Copy(lastBytes, 0, bytes, firstBytes.Length, lastBytes.Length);
                }
                Bin_Lector.Close();
                var md5 = System.Security.Cryptography.MD5.Create().ComputeHash(bytes);
                var sb = new StringBuilder();
                foreach (var b in md5)
                    sb.Append(b.ToString("X2"));
                hash = sb.ToString();
                return sb.ToString();
            }
            catch (Exception e)
            {
                return error_manage.get_error_app(e);
            }
        }

        public static string look_for_languages()
        {
            string datosrespuesta = "";
            HttpWebRequest pedido = WebRequest.Create(languages) as HttpWebRequest;
            pedido.UserAgent = useragent;
            pedido.Method = "GET";
            try
            {
                HttpWebResponse respuesta = pedido.GetResponse() as HttpWebResponse;
                {                    
                    StreamReader Stream_Lector = new StreamReader(respuesta.GetResponseStream());
                    {
                        datosrespuesta = Stream_Lector.ReadToEnd();
                    }
                    respuesta.Close();
                    Stream_Lector.Close();
                }
                return datosrespuesta;
            }
            catch (Exception e)
            {
                return error_manage.get_error_app(e);
            }
        }

        public static string look_for_subs()
        {
            string datosrespuesta = "";
            HttpWebRequest pedido = WebRequest.Create(search + hash) as HttpWebRequest;
            pedido.UserAgent = useragent;
            pedido.Method = "GET";
            try
            {
                HttpWebResponse respuesta = pedido.GetResponse() as HttpWebResponse;
                {
                    StreamReader Stream_Lector = new StreamReader(respuesta.GetResponseStream());
                    {
                        datosrespuesta = Stream_Lector.ReadToEnd();
                    }
                    respuesta.Close();
                    Stream_Lector.Close();
                }
                languages_available = datosrespuesta;
                return datosrespuesta;
            }
            catch (WebException e)
            {
                return error_manage.get_error_web(e);
            }
        }

        public static string download_sub()
        {
            string message = "";
            string datosrespuesta  = "";
            if (languages_available.Contains("es"))
            {
                HttpWebRequest pedido = WebRequest.Create(download + hash + "&language=" + "es") as HttpWebRequest;
                pedido.UserAgent = useragent;
                pedido.Method = "GET"; 
                try
                {
                    HttpWebResponse respuesta = pedido.GetResponse() as HttpWebResponse;
                    {
                        StreamReader Stream_Lector = new StreamReader(respuesta.GetResponseStream(), Encoding.Default);
                        {
                            datosrespuesta = Stream_Lector.ReadToEnd();
                        }
                        respuesta.Close();
                        Stream_Lector.Close();
                        StreamWriter stream_escritor = File.AppendText(path.Substring(0,path.LastIndexOf(".")) + ".es.srt");
                        stream_escritor.Write(datosrespuesta);
                        stream_escritor.Close();
                    }
                    languages_available = datosrespuesta;
                    message = "Archivo descargado correctamente";
                    return message;
                }
                catch (Exception e)
                {
                    return error_manage.get_error_app(e);
                }
            }
            else
            {
                message = "No hay subtitulos para ese idioma";
            }
            return message;
        }

    }
}
