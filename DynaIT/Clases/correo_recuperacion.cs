namespace DynaIT.Clases
{
    public class correo_recuperacion : Correo_servidor
    {
        public correo_recuperacion()
        {
            senderMail = "pruebadynamics23@gmail.com";
            password = "C2824*$jj";
            host = "smtp.gmail.com";
            port = 587;
            ssl = true;

            initializeSmtpClient();

        }
    }
}