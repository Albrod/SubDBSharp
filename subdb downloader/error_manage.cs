using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;

namespace SubDBSharp
{
    public static class error_manage
    {
        public static string get_error_app(Exception e)
        {
            string message = "";
            string code = "";
            if (e is UnauthorizedAccessException)
            {
                message = e.Message.Substring(0, (e.Message.IndexOf(":") - 2));
                code = "0x0U0A001";
            }
            return message + ", " + code;
        }

        public static string get_error_web(WebException e)
        {
            string message = "";
            string code = "";
            if (e.Status == WebExceptionStatus.ProtocolError)
            {
                if (e.Message.Contains("404"))
                {
                    message = "No hay subtitulos disponibles para este video";
                    code = "0x0W0b0404";
                }
            }
            return message + ", " + code;
        }
    }
}
