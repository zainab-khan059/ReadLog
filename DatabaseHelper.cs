using System.Data.SqlClient;

namespace ReadLog
{
    public static class DatabaseHelper
    {
        public static string connectionString =
            @"Data Source=(localdb)\MSSQLLocalDB;
              Initial Catalog=ReadLogDB;
              Integrated Security=True;
             MultipleActiveResultSets=True";
    }
}