using dotenv.net;

namespace ComputerVisionCommonsObjectConsole.Configuration
{
    public static class AppConfiguration
    {
        internal static Func<DotEnvOptions, IDictionary<string, string>> ReadEnv = DotEnv.Read;
        internal static Action<DotEnvOptions> LoadEnv = DotEnv.Load;

        private static IDictionary<string, string>? envVars;

        private static IDictionary<string, string> EnvVars => envVars ??= Initialize();

        private static IDictionary<string, string> Initialize()
        {
            var environment = Environment.GetEnvironmentVariable("ENVIRONMENT");
            var envFileName = ".env";
            if (environment == "test")
                envFileName = ".env.test";
            else if (environment == "local") {
                envFileName = ".env.local";
            }
            var envFile = ResolveEnvFilePath(envFileName);
            Console.WriteLine($"Loading environment file: {envFile}");
            var options = new DotEnvOptions(envFilePaths: new[] { envFile });
            LoadEnv(options);
            return ReadEnv(options);
        }

        private static string ResolveEnvFilePath(string fileName)
        {
            foreach (var startDir in new[] { AppContext.BaseDirectory, Directory.GetCurrentDirectory() })
            {
                var dir = new DirectoryInfo(startDir);
                for (var i = 0; dir is not null && i < 6; i++, dir = dir.Parent)
                {
                    var candidate = Path.Combine(dir.FullName, fileName);
                    if (File.Exists(candidate))
                        return candidate;
                }
            }
            return fileName;
        }
        internal static void ResetForTests() => envVars = null;

        public static string environment => 
            EnvVars["ENVIRONMENT"] 
            ?? throw new InvalidOperationException("ENVIRONMENT environment variable is not set");

        public static string azureComputerVisionBaseUrl => 
            EnvVars["AZURE_COMPUTER_VISION_BASE_URL"] 
            ?? throw new InvalidOperationException("AZURE_COMPUTER_VISION_BASE_URL environment variable is not set");

        public static string azureComputerVisionApiKey =>
            EnvVars["AZURE_COMPUTER_VISION_API_KEY"] 
            ?? throw new InvalidOperationException("AZURE_COMPUTER_VISION_API_KEY environment variable is not set");

        public static string azureBlobStorageImageUrl =>
            EnvVars["AZURE_BLOB_STORAGE_IMAGE_URL"] 
            ?? throw new InvalidOperationException("AZURE_BLOB_STORAGE_IMAGE_URL environment variable is not set");

        public static void ValidateConfiguration()
        {
            try
            {
                _ = environment;
                _ = azureComputerVisionBaseUrl;
                _ = azureComputerVisionApiKey; 
                _ = azureBlobStorageImageUrl; 
                Console.WriteLine("✓ Configuration validation passed");
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine($"✗ Configuration validation failed: {ex.Message}");
                throw;
            }
        }
    }
    
}