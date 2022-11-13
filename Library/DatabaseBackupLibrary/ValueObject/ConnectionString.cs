using System.Data.SqlClient;

namespace DatabaseBackupLibrary
{
    public class ConnectionString
    {
        private readonly string value;
        private readonly SqlConnectionStringBuilder builder;

        public ConnectionString(string value)
        {
            this.value = value;
            this.builder = new SqlConnectionStringBuilder();
            this.builder.ConnectionString = value;
        }

        public string Value => this.value;
        public string MasterConnectionString
        {
            get
            {
                var tmpBuilder = new SqlConnectionStringBuilder(builder.ConnectionString);
                tmpBuilder.InitialCatalog = "master";
                return tmpBuilder.ConnectionString;
            }
        }
        public string InitialCatalog => this.builder.InitialCatalog;
    }
}
