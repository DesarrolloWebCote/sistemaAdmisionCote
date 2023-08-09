using iTextSharp.text.pdf;
using iTextSharp.text;
using iTextSharp.tool.xml;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.UI.WebControls;
using System.Net.Mail;
using System.Net.Mime;
using System.Net;
using iTextSharp.tool.xml.html.head;
using System.Drawing;

namespace WebApplication6
{
    public class d_mantenimiento_inscripcion
    {
        //Hacer conexion a base de datos
        SqlConnection conexion = new SqlConnection(
            ConfigurationManager.ConnectionStrings["conexion"].ConnectionString
        );

        //Verificar si el estudiante con x numero de cedula ya existe
        public bool ExisteEstudiante(int id_estudiante)
        {
            //Cuenta cuántas filas cumplen con la condición de tener un "id_persona" igual al valor del parámetro "@IdUsuario"
            SqlCommand cmd = new SqlCommand(
                "SELECT COUNT(*) FROM t_persona WHERE id_persona = @IdUsuario",
                conexion
            );
            cmd.Parameters.AddWithValue("@IdUsuario", id_estudiante);
            conexion.Open();
            //Devuelve la cantidad de estudiantes con el mismo id
            int count = (int)cmd.ExecuteScalar();
            conexion.Close();
            return count > 0;
        }

        public bool ExisteEncargado(int id_encargado)
        {
            //Cuenta cuántas filas cumplen con la condición de tener un "id_persona" igual al valor del parámetro "@IdUsuarioEn"
            SqlCommand cmd = new SqlCommand(
                "SELECT COUNT(*) FROM t_persona WHERE id_persona = @IdUsuarioEn",
                conexion
            );
            cmd.Parameters.AddWithValue("@IdUsuarioEn", id_encargado);
            conexion.Open();
            //Devuelve el resultado de la consulta, que en este caso es el resultado del COUNT(*),
            //es decir, el número de filas que cumplen con la condición.
            int count = (int)cmd.ExecuteScalar();
            conexion.Close();
            return count > 0;
        }

        public bool ExisteNumPostulante(int num_postulante)
        {
            //Cuenta cuántas filas cumplen con la condición de tener un Numero de postulante igual al valor del parámetro "@NumPostulante"
            SqlCommand cmd = new SqlCommand(
                "SELECT COUNT(*) FROM t_encargado WHERE numPostulante = @NumPostulante",
                conexion
            );
            cmd.Parameters.AddWithValue("@NumPostulante", num_postulante);
            conexion.Open();
            //Devuelve el resultado de la consulta, que en este caso es el resultado del COUNT(*),
            //es decir, el número de filas que cumplen con la condición.
            int count = (int)cmd.ExecuteScalar();
            conexion.Close();
            return count > 0;
        }

        public bool ExisteTelefonoEncargado(int telefono_encargado)
        {
            //Cuenta cuántas filas cumplen con la condición de tener un numero de telefono o telefonoResidencia igual al valor del parámetro "@TelefonoEncargado"
            SqlCommand cmd = new SqlCommand(
                "SELECT COUNT(*) FROM t_persona WHERE telefonoCelular = @TelefonoEncargado OR telefonoResidencia = @TelefonoEncargado",
                conexion
            );
            cmd.Parameters.AddWithValue("@TelefonoEncargado", telefono_encargado);
            conexion.Open();
            //Devuelve el resultado de la consulta, que en este caso es el resultado del COUNT(*),
            //es decir, el número de filas que cumplen con la condición.
            int count = (int)cmd.ExecuteScalar();
            conexion.Close();
            return count > 0;
        }

        public string GuardarForms(e_encargado_postulante entidad_Mantenimiento)
        {
            int id_usuariov = entidad_Mantenimiento.identificacion; //Variable utilizada para validar que el id de usuario y encargado no sean los mismos
            int id_encargadov = entidad_Mantenimiento.identificacion_usuario_en; //Variable utilizada para validar que el id de usuario y encargado no sean los mismos

            string primera_opcionv = entidad_Mantenimiento.primera_opcion; //Variable utilizada para validar que las especialidades no sean las mismas
            string segunda_opcionv = entidad_Mantenimiento.segunda_opcion; //Variable utilizada para validar que las especialidades no sean las mismas

            bool existe_estudiante = ExisteEstudiante(entidad_Mantenimiento.identificacion); //Llamar a los metodos para validar
            bool existe_encargado = ExisteEncargado(
                entidad_Mantenimiento.identificacion_usuario_en
            ); //Llamar a los metodos para validar
            bool existe_numpostulante = ExisteNumPostulante(
                entidad_Mantenimiento.numero_postulante
            ); //Llamar a los metodos para validar
            bool existe_telefonoencargado = ExisteTelefonoEncargado(
                entidad_Mantenimiento.telefono_en
            ); //Llamar a los metodos para validar

            //Validaciones que retornan un mensaje, de ese mensaje dependera la alerta
            if (existe_estudiante)
            {
                return "Esta identificacion de estudiante ya existe";
            }

            if (existe_encargado)
            {
                return "Esta identificacion de encargado ya existe";
            }

            if (existe_numpostulante)
            {
                return "Este numero de postulante ya existe se encuentra inscrito";
            }

            if (existe_telefonoencargado)
            {
                return "Este numero ya se encuentra en uso";
            }

            if (id_usuariov == id_encargadov)
            {
                return "La identificacion del estudiante no puede ser la misma que la del encargado";
            }
            if (primera_opcionv == segunda_opcionv)
            {
                return "Las especialidades elegidas no pueden ser las mismas";
            }

            //Metodo para guardar la entidad.
            SqlCommand cmd = new SqlCommand("Guardar", conexion);
            conexion.Open();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            //Datos Encargado
            cmd.Parameters.AddWithValue(
                "@IdUsuarioEn",
                entidad_Mantenimiento.identificacion_usuario_en
            );
            cmd.Parameters.AddWithValue("@OcupacionEn", entidad_Mantenimiento.ocupacion_en);
            cmd.Parameters.AddWithValue("@NombreEn", entidad_Mantenimiento.nombre_en);
            cmd.Parameters.AddWithValue("@ApellidoEn", entidad_Mantenimiento.apellido_en);
            cmd.Parameters.AddWithValue(
                "@SegundoApellidoEn",
                entidad_Mantenimiento.segundo_apellido_en
            );
            cmd.Parameters.AddWithValue("@TelEn", entidad_Mantenimiento.telefono_op_en);
            cmd.Parameters.AddWithValue("@TelOpEn", entidad_Mantenimiento.telefono_op_en);
            cmd.Parameters.AddWithValue("@NumPostulante", entidad_Mantenimiento.numero_postulante);
            cmd.Parameters.AddWithValue("@TipoEncargado", entidad_Mantenimiento.tipo_encargado);

            //DatosEstudiante
            cmd.Parameters.AddWithValue(
                "@ColegioDProcedencia",
                entidad_Mantenimiento.colegio_procedencia
            );
            cmd.Parameters.AddWithValue("@PrimerApellido", entidad_Mantenimiento.apellido);
            cmd.Parameters.AddWithValue("@SegundoApellido", entidad_Mantenimiento.segundo_apellido);
            cmd.Parameters.AddWithValue("@PrimeraOpcion", entidad_Mantenimiento.primera_opcion);
            cmd.Parameters.AddWithValue("@SegundaOpcion", entidad_Mantenimiento.segunda_opcion);
            cmd.Parameters.AddWithValue("@Nacionalidad", entidad_Mantenimiento.nacionalidad);
            cmd.Parameters.AddWithValue("@Edad", entidad_Mantenimiento.edad);
            cmd.Parameters.AddWithValue("@Sexo", entidad_Mantenimiento.sexo);
            cmd.Parameters.AddWithValue("@Telefono", entidad_Mantenimiento.telefono);
            cmd.Parameters.AddWithValue("@FechaNacimiento", entidad_Mantenimiento.fecha_nacimiento);
            cmd.Parameters.AddWithValue("@Nombre", entidad_Mantenimiento.nombre);
            cmd.Parameters.AddWithValue("@CorreoElec", entidad_Mantenimiento.correo_electronico);
            cmd.Parameters.AddWithValue("@IdUsuario", entidad_Mantenimiento.identificacion);
            cmd.ExecuteNonQuery();
            conexion.Close();
            //Mensaje que nos servira para mostrar la alerta y saber que se completo satisfactoriamente el proceso
            return "Success";
        }

        //Validar si la identificacion y el consecutivo se encuentra en la tabla verificacion
        public bool Verificar(e_encargado_postulante e_Mantenimiento)
        {
            SqlCommand cmd = new SqlCommand("Verificar", conexion);
            conexion.Open();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            //Verificar mediante id y numPostulante
            cmd.Parameters.AddWithValue("@identificacion", e_Mantenimiento.identificacion);
            cmd.Parameters.AddWithValue("@consecutivo", e_Mantenimiento.numero_postulante);

            SqlParameter resultado = new SqlParameter("@Resultado", System.Data.SqlDbType.Bit);
            resultado.Direction = System.Data.ParameterDirection.Output;
            cmd.Parameters.Add(resultado);

            cmd.ExecuteNonQuery();
            conexion.Close();
            bool resultado_obtenido = (bool)cmd.Parameters["@Resultado"].Value;
            if (resultado_obtenido == true)
            {
                return true; //Valores de retorno valiosos al momento de mostrar alerta :)
            }
            else
            {
                return false; //Valores de retorno valiosos al momento de mostrar alerta :)
            }
        }

        public void ConvertirHTMLaPDFDesdeArchivo(
            string ruta_archivo_html,
            string ruta_archivo_pdf,
            string colegio_procedencia,
            string primera_opcion,
            string id_estudiante,
            string segunda_opcion,
            string nombre,
            string nacionalidad,
            string fecha_nacimiento,
            string primer_apellido,
            string segundo_apellido,
            string sexo,
            string edad,
            string telefono,
            string correo,
            string identificacion_encargado,
            string ocupacion_encargado,
            string nombre_encargado,
            string celular_encargado,
            string apellido_encargado,
            string telefono_encargado,
            string tipo_encargado
        )
        {
            //PDF
            Document doc = new Document(PageSize.A4, 25, 25, 30, 30);

            //Crear el escritoR
            PdfWriter writer = PdfWriter.GetInstance(
                doc,
                new FileStream(ruta_archivo_pdf, FileMode.Create)
            );

            //Agregar imagen de fondo
            string ruta_imagen_fondo =
                "D:\\Avance Proyecto\\WebApplication6\\Plantilla\\escudo opaco.png";
            iTextSharp.text.Image imagenFondo = iTextSharp.text.Image.GetInstance(
                ruta_imagen_fondo
            );

            // Obtener el tamaño de la página
            float paginaAncho = doc.PageSize.Width;
            float paginaAlto = doc.PageSize.Height;

            // Obtener el tamaño de la imagen después de la escala
            float imagenAncho = imagenFondo.ScaledWidth;
            float imagenAlto = imagenFondo.ScaledHeight;

            // Calcular la posición para desplazar la imagen a la derecha
            float posicionX = (paginaAncho - imagenAncho) / 2 + 150;
            float posicionY = (paginaAlto - imagenAlto) / 2 + 50;

            imagenFondo.SetAbsolutePosition(posicionX, posicionY);

            doc.Open();

            // Agregar la imagen de fondo al PDF
            PdfContentByte cb = writer.DirectContentUnder;
            cb.AddImage(imagenFondo);

            //Leer HTML desde el archivo
            string contenidoHTML;
            using (StreamReader sr = new StreamReader(ruta_archivo_html))
            {
                contenidoHTML = sr.ReadToEnd();
            }

            //Sustituir los campos mediante el codigo que poseen en el html por las variables
            contenidoHTML = contenidoHTML.Replace("uls9", nombre);
            contenidoHTML = contenidoHTML.Replace("pyg7", primera_opcion);
            contenidoHTML = contenidoHTML.Replace("klw3", segunda_opcion);
            contenidoHTML = contenidoHTML.Replace("prm4", primer_apellido);
            contenidoHTML = contenidoHTML.Replace("sgq3", segundo_apellido);
            contenidoHTML = contenidoHTML.Replace("nci5", nacionalidad);
            contenidoHTML = contenidoHTML.Replace("fna7", fecha_nacimiento);
            contenidoHTML = contenidoHTML.Replace("por2", sexo);
            contenidoHTML = contenidoHTML.Replace("lki8", edad);
            contenidoHTML = contenidoHTML.Replace("zxs1", telefono);
            contenidoHTML = contenidoHTML.Replace("fht2", correo);
            contenidoHTML = contenidoHTML.Replace("c0l3", colegio_procedencia);
            contenidoHTML = contenidoHTML.Replace("gyh7", identificacion_encargado);
            contenidoHTML = contenidoHTML.Replace("qsa2", ocupacion_encargado);
            contenidoHTML = contenidoHTML.Replace("gtu7", nombre_encargado);
            contenidoHTML = contenidoHTML.Replace("hnm8", celular_encargado);
            contenidoHTML = contenidoHTML.Replace("lop4", apellido_encargado);
            contenidoHTML = contenidoHTML.Replace("fjk2", telefono_encargado);
            contenidoHTML = contenidoHTML.Replace("ski9", tipo_encargado);

            //Aplicar estilos al html

            //Parsear HTML y agregarlo al PDF
            using (TextReader reader = new StringReader(contenidoHTML))
            {
                XMLWorkerHelper.GetInstance().ParseXHtml(writer, doc, reader);
            }

            // Cerrar el documento


            doc.Close();
            writer.Close();
        }

        public void EnviarCorreo(
            //Parametros
            string correo,
            string nombre,
            string apellido,
            string ruta_archivo_adjunto
        )
        {
            //SMTP
            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587); // servidor SMTP
            //Cifrar conexion
            smtpClient.EnableSsl = true;
            //Metodo de delivery
            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            //Credenciales de la cuenta que va a enviar el CORREO
            smtpClient.Credentials = new NetworkCredential(
                "coteadmision2024@gmail.com",
                "climhjtgajoqzwvy"
            );

            //Cuerpo del correo, partes basicas digamos.
            MailMessage mail = new MailMessage();
            mail.To.Add(correo);
            mail.From = new MailAddress("coteadmision2024@gmail.com", "ADMISION 2024");
            mail.Subject = "Test mail";
            mail.Body = "PROCESO DE ADMISION - " + nombre + apellido;
            mail.IsBodyHtml = true;
            mail.Priority = MailPriority.Normal;

            //Adjuntar
            Attachment archivo_adjunto = new Attachment(
                ruta_archivo_adjunto,
                MediaTypeNames.Application.Pdf
            );
            mail.Attachments.Add(archivo_adjunto);

            //Enviar
            smtpClient.Send(mail);
        }
    }
}
