using System.Data.SqlServerCe;


namespace FunPro.CW1._7586.DAL
{
    public class DBManager
    {
        protected SqlCeConnection Connection
        {
            get
            {
                return new SqlCeConnection(Properties.Settings.Default.ConnectionString);
            }
        }


    }
}
