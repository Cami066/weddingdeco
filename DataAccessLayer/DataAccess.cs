using System;
namespace DataAccessLayer
{
    public class DataAccess
    {
        public string _connectionString;

        public DataAccess()
        {
            _connectionString = "Server=mssqlstud.fhict.local;Database=dbi492849_wedding;User Id=dbi492849_wedding;Password=12345678;";
        }

    }
}
