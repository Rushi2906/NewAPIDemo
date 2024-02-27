namespace NewAPIDemo.DAL
{
    public class DAL_Helper
    {
        public static string connectionString = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetConnectionString("MyConnectionString");
    }
}
