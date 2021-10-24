using System.Collections.Generic;
using System.Data.SqlClient;

namespace ConsoleApp
{
    public class DatabaseLogging
    {
        private readonly bool _logMessage;
        private readonly bool _logWarning;
        private readonly bool _logError;
        private readonly IDictionary<string, string> _dbParams;

        public DatabaseLogging(bool logMessage, bool logWarning, bool logError, IDictionary<string, string> dbParams)
        {
            _logMessage = logMessage;
            _logWarning = logWarning;
            _logError = logError;
            _dbParams = dbParams;
        }

        public void Log(Entry entry)
        {
            int t = 0;
            if (entry.Message && _logMessage)
            {
                t = 1;
            }

            if (entry.Error && _logError)
            {
                t = 2;
            }

            if (entry.Warning && _logWarning)
            {
                t = 3;
            }

            if (t != 0)
            {
                string connectionString = "Server=" + _dbParams["serverName"] + ";Initial Catalog=" + _dbParams["DataBaseName"] + ";User ID=" + _dbParams["userName"] + ";Password=" + _dbParams["password"] + ";";
                SqlConnection sqlConnection = new SqlConnection(connectionString);

                string insertStatement = "insert into Log_Values values('" + entry.Text + "', " + t.ToString() + ")";
                SqlCommand sqlCommand = new SqlCommand(insertStatement, sqlConnection);
                sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();
            }
        }

    }
}