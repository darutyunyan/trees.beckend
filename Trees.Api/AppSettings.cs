using System.Diagnostics.CodeAnalysis;
using Trees.Api.Utils;

namespace Trees.Api
{
    public class AppSettings
    {
        public static string DB_CONNECTION_FORMAT = "Data Source={0};Database={1};Integrated Security=False;User ID={2};Password={3};TrustServerCertificate=True";

        [SetsRequiredMembers]
        public AppSettings()
        {
            DBAppSettings = new DataBaseSettings();
            DBLogSettings = new();
            ClientUrl = string.Empty;
            EmailSettings = new();
        }

        public required DataBaseSettings DBAppSettings { get; init; }
        public required DataBaseSettings DBLogSettings { get; init; }
        public required string ClientUrl { get; init; }
        public required EmailSetting EmailSettings { get; init; }

        public class EmailSetting
        {
            [SetsRequiredMembers]
            public EmailSetting()
            {
                SenderName = string.Empty;
                SmtpClient = string.Empty;
                EmailTo = string.Empty;
                EmailFrom = string.Empty;
                PasswordFrom = string.Empty;
            }

            public required string SenderName { get; init; }
            public int Port { get; init; }
            public required string SmtpClient { get; set; }
            public required string EmailTo { get; init; }
            public required string EmailFrom { get; init; }
            public required string PasswordFrom { get => Cryptographer.Decrypt(_passwordFrom); set => _passwordFrom = value; }

            private string? _passwordFrom;
        }

        public class DataBaseSettings
        {
            [SetsRequiredMembers]
            public DataBaseSettings()
            {
                DataSource = string.Empty;
                DataBase = string.Empty;
                UserID = string.Empty;
                Password = string.Empty;
            }

            public required string DataSource { get => Cryptographer.Decrypt(_dataSource); set => _dataSource = value; }
            public required string DataBase { get => Cryptographer.Decrypt(_dataBase); set => _dataBase = value; }
            public required string UserID { get => Cryptographer.Decrypt(_userId); set => _userId = value; }
            public required string Password { get => Cryptographer.Decrypt(_password); set => _password = value; }

            private string? _dataSource;
            private string? _dataBase;
            private string? _userId;
            private string? _password;
        }
    }
}
