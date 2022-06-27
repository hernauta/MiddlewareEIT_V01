using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MiddlewareEIT.API.Services
{
    public class ProcesaArchivo
    {

        public static List<string> listarContenidoFTP(string dir, string user, string pass)
        {
            List<string> listA = new List<string>();
            FtpWebRequest dirFtp = (FtpWebRequest)FtpWebRequest.Create(dir);
            // Los datos del usuario (credenciales)           
            dirFtp.Credentials = new NetworkCredential(user, pass);
            // El comando a ejecutar  
            dirFtp.Method = WebRequestMethods.Ftp.ListDirectory;
            Encoding encode = System.Text.Encoding.GetEncoding("utf-8");

            using (StreamReader reader = new StreamReader(dirFtp.GetResponse().GetResponseStream(), encode))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(';');
                    listA.Add(values[0]);
                }
            }
            return listA;
        }

        public static string descargarftp(string dir, string user, string pass, string archivoorigen)
        {
            StreamWriter sw = null;
            StreamReader reader = null;
            FtpWebResponse response = null;
            var fechaarchivo = DateTime.Now.ToString("yyyyMMdd HHmm");
            string rutadestino = "C:\\Users\\56963\\Documents\\Destino_siemens\\Out\\New\\" + archivoorigen;
            //string rutadestino = @""+ archivoorigen;
            string info = "";
            string mensajeError = "";
            try
            {
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(dir + archivoorigen); // Ruta donde se encuentra el documento
                request.Method = WebRequestMethods.Ftp.DownloadFile;
                // se ingresa usuario y contraseña
                request.Credentials = new NetworkCredential(user, pass);
                request.UseBinary = false;                                  //SE USA FALSE PARA BAJAR DOCUMENTOS DE TEXTO
                response = (FtpWebResponse)request.GetResponse();
                Stream responseStream = response.GetResponseStream();
                reader = new StreamReader(responseStream);
                sw = new StreamWriter(rutadestino, true);
                info = reader.ReadToEnd();
                //depositar información en el nuevo archivo
                sw.Write(info, Encoding.UTF8);
                sw.Close();
            }
            catch (Exception e)
            {
                mensajeError = "Error al bajar el FTP " + e.Message + " " + dir;
                return mensajeError;
            }
            finally
            {
                reader.Close();
                response.Close();
            }
            return info + response.StatusDescription;

        }
   
        public static string[] CrearTxt(string dir, string user, string pass,  string contenido, string tipoarchivo)
        {
            var servidor = "ftp://192.168.100.13/";
            var usuario = "hernandurang@gmail.com";
            var password = "Lhasa654321";
            var archivoOrigen = tipoarchivo + DateTime.Now + ".txt";
            var directorios2 = "";

            string[] lines = { "Primera Línea", "Segunda Línea", "Tercera Línea" };
            File.WriteAllLines(@"C:\RutaArchivos\EscribeLineas.txt", lines);
            string text = "A class is the most powerful data type in C#. Like a structure, " +
                           "a class defines the data and behavior of the data type. ";
            File.WriteAllText(@"C:\RutaArchivos\EscribeTexto.txt", text);
            using (StreamWriter file = new StreamWriter("C:\\Users\\56963\\Documents\\Destino_siemens\\Out\\New\\" + archivoOrigen))
            {
                foreach (string line in lines)
                {
                    if (!line.Contains("Segunda"))
                    {
                        file.WriteLine(line);
                    }
                }
            }
            using (StreamWriter file = new StreamWriter(@"C:\RutaArchivos\EscribeLineas2.txt", true))
            {
                file.WriteLine("Cuarta Línea");
            }
            return lines;
        }

    }

}
