namespace JcmSoft.EFCore
{
    public class AppConfig
    {
        public static string GetConnectionString()
        {
            return
               "Data Source=arthur;" +
               "Initial Catalog=JcmSoftDatabase;" +
               "Integrated Security=True;" +
               "TrustServerCertificate=True;";
        }
    }
}
