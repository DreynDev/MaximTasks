namespace MaximTasks
{
    public static class AppSettings
    {
        // Статическая переменная для хранения конфигурации
        private static IConfiguration _configuration;

        // Статический конструктор для инициализации конфигурации
        static AppSettings()
        {
            _configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())  
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true) 
                .Build();
        }
        public static string RandomAPI => _configuration["AppSettings:RandomAPI"];
        public static List<string> BlackList => _configuration.GetSection("AppSettings:BlackList").Get<List<string>>();
    }

}
