using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading;
using System.Web;

namespace FisioterapiaUlatskawa.Tags
{
    public class EnviarCorreo
    {
        static string cuerpoMensaje = "";

        public static MailAddress fromAddress = new MailAddress("xxxxxxx@gmail.com", "Soporte Ulatskawa");
        string fromPassword = "xxxxxxx";

        public static SmtpClient smtp;

        public EnviarCorreo()
        {

            smtp = new SmtpClient
            {
                //Host = "smtp.office365.com",
                //Port = 587,
                //EnableSsl = true,
                //DeliveryMethod = SmtpDeliveryMethod.Network,
                //UseDefaultCredentials = false,
                //Credentials = new NetworkCredential(fromAddress.Address, fromPassword)


                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)

            };

        }

        public bool EnviadorCorreo(string password, string correo)
        {

            cuerpoMensaje = cuerpoHtml(password);
            return enviarCorreos(correo);


        }


        public static string cuerpoHtml(string newPassword)
        {

            string sb = "<!DOCTYPE html>" +
            "<html lang=\"en\" xmlns:o=\"urn:schemas-microsoft-com:office:office\" xmlns:v=\"urn:schemas-microsoft-com:vml\">" +
            "<head>" +
            "<title></title>" +
            "<meta content=\"text/html; charset=utf-8\" http-equiv=\"Content-Type\"/>" +
            "<meta content=\"width=device-width, initial-scale=1.0\" name=\"viewport\"/>" +
            "<!--[if mso]><xml><o:OfficeDocumentSettings><o:PixelsPerInch>96</o:PixelsPerInch><o:AllowPNG/></o:OfficeDocumentSettings></xml><![endif]-->" +
            "<!--[if !mso]><!-->" +
            "<link href=\"https://fonts.googleapis.com/css?family=Open+Sans\" rel=\"stylesheet\" type=\"text/css\"/>" +
            "<link href=\"https://fonts.googleapis.com/css?family=Cabin\" rel=\"stylesheet\" type=\"text/css\"/>" +
            "<!--<![endif]-->" +
            "<style>" +
            "		" +
            "	</style>" +
            "</head>" +
            "<body style=\"background-color: #d9dffa; margin: 0; padding: 0; -webkit-text-size-adjust: none; text-size-adjust: none;\">" +
            "<table border=\"0\" cellpadding=\"0\" cellspacing=\"0\" class=\"nl-container\" role=\"presentation\" style=\"mso-table-lspace: 0pt; mso-table-rspace: 0pt; background-color: #d9dffa;\" width=\"100%\">" +
            "<tbody>" +
            "<tr>" +
            "<td>" +
            "<table align=\"center\" border=\"0\" cellpadding=\"0\" cellspacing=\"0\" class=\"row row-1\" role=\"presentation\" style=\"mso-table-lspace: 0pt; mso-table-rspace: 0pt; background-color: #cfd6f4;\" width=\"100%\">" +
            "<tbody>" +
            "<tr>" +
            "<td>" +
            "<table align=\"center\" border=\"0\" cellpadding=\"0\" cellspacing=\"0\" class=\"row-content stack\" role=\"presentation\" style=\"mso-table-lspace: 0pt; mso-table-rspace: 0pt; color: #000000; width: 600px;\" width=\"600\">" +
            "<tbody>" +
            "<tr>" +
            "<td class=\"column column-1\" style=\"mso-table-lspace: 0pt; mso-table-rspace: 0pt; font-weight: 400; text-align: left; vertical-align: top; padding-top: 20px; padding-bottom: 0px; border-top: 0px; border-right: 0px; border-bottom: 0px; border-left: 0px;\" width=\"100%\">" +
            "<table border=\"0\" cellpadding=\"0\" cellspacing=\"0\" class=\"image_block\" role=\"presentation\" style=\"mso-table-lspace: 0pt; mso-table-rspace: 0pt;\" width=\"100%\">" +
            "</table>" +
            "</td>" +
            "</tr>" +
            "</tbody>" +
            "</table>" +
            "</td>" +
            "</tr>" +
            "</tbody>" +
            "</table>" +
            "<table align=\"center\" border=\"0\" cellpadding=\"0\" cellspacing=\"0\" class=\"row row-2\" role=\"presentation\" style=\"mso-table-lspace: 0pt; mso-table-rspace: 0pt; background-color: #d9dffa; background-image: url('images/body_background_2.png'); background-position: top center; background-repeat: repeat;\" width=\"100%\">" +
            "<tbody>" +
            "<tr>" +
            "<td>" +
            "<table align=\"center\" border=\"0\" cellpadding=\"0\" cellspacing=\"0\" class=\"row-content stack\" role=\"presentation\" style=\"mso-table-lspace: 0pt; mso-table-rspace: 0pt; color: #000000; width: 600px;\" width=\"600\">" +
            "<tbody>" +
            "<tr>" +
            "<td class=\"column column-1\" style=\"mso-table-lspace: 0pt; mso-table-rspace: 0pt; font-weight: 400; text-align: left; vertical-align: top; padding-left: 50px; padding-right: 50px; padding-top: 15px; padding-bottom: 15px; border-top: 0px; border-right: 0px; border-bottom: 0px; border-left: 0px;\" width=\"100%\">" +
            "<table border=\"0\" cellpadding=\"10\" cellspacing=\"0\" class=\"text_block\" role=\"presentation\" style=\"mso-table-lspace: 0pt; mso-table-rspace: 0pt; word-break: break-word;\" width=\"100%\">" +
            "<tr>" +
            "<td>" +
            "<div style=\"font-family: sans-serif\">" +
            "<div style=\"font-size: 14px; mso-line-height-alt: 16.8px; color: #506bec; line-height: 1.2; font-family: Helvetica Neue, Helvetica, Arial, sans-serif;\">" +
            "<p style=\"margin: 0; font-size: 14px;\"><strong><span style=\"font-size:38px;\">Your New Password<br/></span></strong></p>" +
            "</div>" +
            "</div>" +
            "</td>" +
            "</tr>" +
            "</table>" +
            "<table border=\"0\" cellpadding=\"10\" cellspacing=\"0\" class=\"divider_block\" role=\"presentation\" style=\"mso-table-lspace: 0pt; mso-table-rspace: 0pt;\" width=\"100%\">" +
            "<tr>" +
            "<td>" +
            "<div align=\"center\">" +
            "<table border=\"0\" cellpadding=\"0\" cellspacing=\"0\" role=\"presentation\" style=\"mso-table-lspace: 0pt; mso-table-rspace: 0pt;\" width=\"100%\">" +
            "<tr>" +
            "<td class=\"divider_inner\" style=\"font-size: 1px; line-height: 1px; border-top: 1px solid #BBBBBB;\"><span> </span></td>" +
            "</tr>" +
            "</table>" +
            "</div>" +
            "</td>" +
            "</tr>" +
            "</table>" +
            "<table border=\"0\" cellpadding=\"10\" cellspacing=\"0\" class=\"text_block\" role=\"presentation\" style=\"mso-table-lspace: 0pt; mso-table-rspace: 0pt; word-break: break-word;\" width=\"100%\">" +
            "<tr>" +
            "<td>" +
            "<div style=\"font-family: sans-serif\">" +
            "<div style=\"font-size: 14px; mso-line-height-alt: 16.8px; color: #40507a; line-height: 1.2; font-family: Helvetica Neue, Helvetica, Arial, sans-serif;\">" +
            "<p style=\"margin: 0; font-size: 14px;\"><span style=\"font-size:16px;\">Hey, we received a request to reset your password.</span></p>" +
            "</div>" +
            "</div>" +
            "</td>" +
            "</tr>" +
            "</table>" +
            "<table border=\"0\" cellpadding=\"10\" cellspacing=\"0\" class=\"text_block\" role=\"presentation\" style=\"mso-table-lspace: 0pt; mso-table-rspace: 0pt; word-break: break-word;\" width=\"100%\">" +
            "<tr>" +
            "<td>" +
            "<div style=\"font-family: sans-serif\">" +
            "<div style=\"font-size: 14px; mso-line-height-alt: 16.8px; line-height: 1.2; font-family: Helvetica Neue, Helvetica, Arial, sans-serif;\">" +
            "<p style=\"margin: 0; font-size: 14px;\"><span style=\"font-size:17px; color: #506bec;\">New Password: <strong>" + newPassword + "</strong></span></p>" +
            "</div>" +
            "</div>" +
            "</td>" +
            "</tr>" +
            "</table>" +
            "<table border=\"0\" cellpadding=\"10\" cellspacing=\"0\" class=\"text_block\" role=\"presentation\" style=\"mso-table-lspace: 0pt; mso-table-rspace: 0pt; word-break: break-word;\" width=\"100%\">" +
            "<tr>" +
            "<td>" +
            "<div style=\"font-family: sans-serif\">" +
            "<div style=\"font-size: 14px; mso-line-height-alt: 16.8px; color: #40507a; line-height: 1.2; font-family: Helvetica Neue, Helvetica, Arial, sans-serif;\">" +
            "<p style=\"margin: 0; font-size: 14px;\"><span style=\"font-size:16px;\">Let’s get you a new one!</span></p>" +
            "</div>" +
            "</div>" +
            "</td>" +
            "</tr>" +
            "</table>" +
            "</td>" +
            "</tr>" +
            "</tbody>" +
            "</table>" +
            "</td>" +
            "</tr>" +
            "</tbody>" +
            "</table>" +
            "<table align=\"center\" border=\"0\" cellpadding=\"0\" cellspacing=\"0\" class=\"row row-3\" role=\"presentation\" style=\"mso-table-lspace: 0pt; mso-table-rspace: 0pt;\" width=\"100%\">" +
            "<tbody>" +
            "<tr>" +
            "<td>" +
            "<table align=\"center\" border=\"0\" cellpadding=\"0\" cellspacing=\"0\" class=\"row-content stack\" role=\"presentation\" style=\"mso-table-lspace: 0pt; mso-table-rspace: 0pt; color: #000000; width: 600px;\" width=\"600\">" +
            "<tbody>" +
            "<tr>" +
            "<td class=\"column column-1\" style=\"mso-table-lspace: 0pt; mso-table-rspace: 0pt; font-weight: 400; text-align: left; vertical-align: top; padding-top: 0px; padding-bottom: 5px; border-top: 0px; border-right: 0px; border-bottom: 0px; border-left: 0px;\" width=\"100%\">" +
            "<table border=\"0\" cellpadding=\"0\" cellspacing=\"0\" class=\"image_block\" role=\"presentation\" style=\"mso-table-lspace: 0pt; mso-table-rspace: 0pt;\" width=\"100%\">" +
            "<tr>" +
            "</tr>" +
            "</table>" +
            "</td>" +
            "</tr>" +
            "</tbody>" +
            "</table>" +
            "</td>" +
            "</tr>" +
            "</tbody>" +
            "</table>" +
            "<table align=\"center\" border=\"0\" cellpadding=\"0\" cellspacing=\"0\" class=\"row row-4\" role=\"presentation\" style=\"mso-table-lspace: 0pt; mso-table-rspace: 0pt;\" width=\"100%\">" +
            "<tbody>" +
            "<tr>" +
            "<td>" +
            "<table align=\"center\" border=\"0\" cellpadding=\"0\" cellspacing=\"0\" class=\"row-content stack\" role=\"presentation\" style=\"mso-table-lspace: 0pt; mso-table-rspace: 0pt; color: #000000; width: 600px;\" width=\"600\">" +
            "<tbody>" +
            "<tr>" +
            "<td class=\"column column-1\" style=\"mso-table-lspace: 0pt; mso-table-rspace: 0pt; font-weight: 400; text-align: left; vertical-align: top; padding-left: 10px; padding-right: 10px; padding-top: 10px; padding-bottom: 20px; border-top: 0px; border-right: 0px; border-bottom: 0px; border-left: 0px;\" width=\"100%\">" +
            "<table border=\"0\" cellpadding=\"10\" cellspacing=\"0\" class=\"image_block\" role=\"presentation\" style=\"mso-table-lspace: 0pt; mso-table-rspace: 0pt;\" width=\"100%\">" +
            "<tr>" +
            "<td>" +
            "<div align=\"center\" style=\"line-height:10px\"><a href=\"#\" style=\"outline:none\" tabindex=\"-1\" target=\"_blank\"><img alt=\"Logo\" src=\"xxxxxxxxxxxx \" style=\"display: block; height: auto; border: 0; width: 203px; max-width: 100%;\" title=\"MAR-ECO\" width=\"203\"/></a></div>" +
            "</td>" +
            "</tr>" +
            "</table>" +
            "<table border=\"0\" cellpadding=\"10\" cellspacing=\"0\" class=\"text_block\" role=\"presentation\" style=\"mso-table-lspace: 0pt; mso-table-rspace: 0pt; word-break: break-word;\" width=\"100%\">" +
            "<tr>" +
            "<td>" +
            "<div style=\"font-family: sans-serif\">" +
            "<div style=\"font-size: 14px; mso-line-height-alt: 16.8px; color: #97a2da; line-height: 1.2; font-family: Helvetica Neue, Helvetica, Arial, sans-serif;\">" +
            "</div>" +
            "</div>" +
            "</td>" +
            "</tr>" +
            "</table>" +
            "<table border=\"0\" cellpadding=\"10\" cellspacing=\"0\" class=\"text_block\" role=\"presentation\" style=\"mso-table-lspace: 0pt; mso-table-rspace: 0pt; word-break: break-word;\" width=\"100%\">" +
            "<tr>" +
            "<td>" +
            "<div style=\"font-family: sans-serif\">" +
            "<div style=\"font-size: 14px; mso-line-height-alt: 16.8px; color: #97a2da; line-height: 1.2; font-family: Helvetica Neue, Helvetica, Arial, sans-serif;\">" +
            "<p style=\"margin: 0; text-align: center; mso-line-height-alt: 16.8px;\"> </p>" +
            "<p style=\"margin: 0; text-align: center;\">© All rights reserved Ulastkawa</p>" +
            "</div>" +
            "</div>" +
            "</td>" +
            "</tr>" +
            "</table>" +
            "</td>" +
            "</tr>" +
            "</tbody>" +
            "</table>" +
            "</td>" +
            "</tr>" +
            "</tbody>" +
            "</table>" +
            "<table align=\"center\" border=\"0\" cellpadding=\"0\" cellspacing=\"0\" class=\"row row-5\" role=\"presentation\" style=\"mso-table-lspace: 0pt; mso-table-rspace: 0pt;\" width=\"100%\">" +
            "<tbody>" +
            "<tr>" +
            "<td>" +
            "<table align=\"center\" border=\"0\" cellpadding=\"0\" cellspacing=\"0\" class=\"row-content stack\" role=\"presentation\" style=\"mso-table-lspace: 0pt; mso-table-rspace: 0pt; color: #000000; width: 600px;\" width=\"600\">" +
            "<tbody>" +
            "<tr>" +
            "<td class=\"column column-1\" style=\"mso-table-lspace: 0pt; mso-table-rspace: 0pt; font-weight: 400; text-align: left; vertical-align: top; padding-top: 5px; padding-bottom: 5px; border-top: 0px; border-right: 0px; border-bottom: 0px; border-left: 0px;\" width=\"100%\">" +
            "<table border=\"0\" cellpadding=\"0\" cellspacing=\"0\" class=\"icons_block\" role=\"presentation\" style=\"mso-table-lspace: 0pt; mso-table-rspace: 0pt;\" width=\"100%\">" +
            "<tr>" +
            "<td style=\"vertical-align: middle; color: #9d9d9d; font-family: inherit; font-size: 15px; padding-bottom: 5px; padding-top: 5px; text-align: center;\">" +
            "<table cellpadding=\"0\" cellspacing=\"0\" role=\"presentation\" style=\"mso-table-lspace: 0pt; mso-table-rspace: 0pt;\" width=\"100%\">" +
            "<tr>" +
            "<td style=\"vertical-align: middle; text-align: center;\">" +
            "<!--[if vml]><table align=\"left\" cellpadding=\"0\" cellspacing=\"0\" role=\"presentation\" style=\"display:inline-block;padding-left:0px;padding-right:0px;mso-table-lspace: 0pt;mso-table-rspace: 0pt;\"><![endif]-->" +
            "<!--[if !vml]><!-->" +
            "<table cellpadding=\"0\" cellspacing=\"0\" class=\"icons-inner\" role=\"presentation\" style=\"mso-table-lspace: 0pt; mso-table-rspace: 0pt; display: inline-block; margin-right: -4px; padding-left: 0px; padding-right: 0px;\">" +
            "<!--<![endif]-->" +
            "</table>" +
            "</td>" +
            "</tr>" +
            "</table>" +
            "</td>" +
            "</tr>" +
            "</table>" +
            "</td>" +
            "</tr>" +
            "</tbody>" +
            "</table>" +
            "</td>" +
            "</tr>" +
            "</tbody>" +
            "</table>" +
            "</td>" +
            "</tr>" +
            "</tbody>" +
            "</table><!-- End -->" +
            "</body>" +
            "</html>";


            return sb;
        }



        private bool enviarCorreos(string correo)
        {
            bool valido = false;
            try
            {
                Thread envioCorreos = new Thread(() =>
                {
                    const string subject = "Change Password";
                    string body = cuerpoMensaje;

                    MailMessage mail = new MailMessage();

                    var fromAddress = new MailAddress("ajcg199519@gmail.com", "Soporte Ulatskawa");

                    //  var fromAddress = new MailAddress("ajcg199519@gmail.com", "Notificacion");


                    var toAddress = new MailAddress(correo, subject);
                    mail.To.Add(toAddress);


                    mail.From = fromAddress;
                    mail.Subject = subject;
                    mail.IsBodyHtml = true;
                    mail.Body = body;

                    smtp.Send(mail);

                });
                envioCorreos.Start();
                valido = true;
            }
            catch (Exception eeC)
            {
                valido = false;
            }
            return valido;
        }

    }
}