using System.Data.OleDb;
using System.Data;

namespace ZWarehouseSystem.FunctionClass
{
    /// <summary>
    /// 数据库管理器
    /// </summary>
    class ZDatabaseManager
    {
        private const string BASE_CONNECT_INFO = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=";
        private string _databasePath;

        public ZDatabaseManager(string databasePath)
        {
            _databasePath = databasePath;
        }

        /// <summary>
        /// 使用传入的‘SQL’语句更新数据库并返回结果
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public bool UpdateDatabase(string sql)
        {
            using (OleDbConnection dbConnection = new OleDbConnection(BASE_CONNECT_INFO + _databasePath))
            {
                dbConnection.Open();
                OleDbCommand dbCommand = new OleDbCommand(sql, dbConnection);
                if (dbCommand.ExecuteNonQuery() == 0)
                    return false;
            }
            return true;
        }

        /// <summary>
        /// 获取查询结果的第一个数据行
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public string[] GetADataRow(string sql)
        {
            string[] data;
            using (OleDbConnection dbConnection = new OleDbConnection(BASE_CONNECT_INFO + _databasePath))
            {
                dbConnection.Open();
                OleDbCommand dbCommand = new OleDbCommand(sql, dbConnection);
                OleDbDataReader dbReader = dbCommand.ExecuteReader();

                if (dbReader.Read())
                {
                    data = new string[dbReader.FieldCount - 1];
                    for (int i = 1; i < dbReader.FieldCount; ++i)
                    {
                        data[i - 1] = dbReader[i].ToString();
                    }
                }
                else
                    data = null;
            }
            return data;
        }

        /// <summary>
        /// 得到一些符合要求的数据
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public DataSet  GetSomeData(string sql)
        {
            DataSet ds=new DataSet();
            using (OleDbConnection dbConnection = new OleDbConnection(BASE_CONNECT_INFO + _databasePath))
            {
                dbConnection.Open();
                OleDbCommand dbCommand = new OleDbCommand(sql, dbConnection);
                OleDbDataAdapter dbAdapter = new OleDbDataAdapter(dbCommand);
                dbAdapter.Fill(ds);
                if (ds.Tables.Count < 0)
                    ds = null;
            }
            return ds;
        }

    }
}