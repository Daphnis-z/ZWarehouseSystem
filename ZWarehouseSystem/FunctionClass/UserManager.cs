using System.Collections.Generic;
using System.Data;

namespace ZWarehouseSystem.FunctionClass
{
    /// <summary>
    /// 用户管理器
    /// </summary>
    public class UserManager
    {
        private string _databasePath,
            _accountTableName;

        public string _userName,
            _userPassword,
            _group;

        private ZDatabaseManager _zdManager;

        public UserManager(string databasePath,string accountTableName)
        {
            _databasePath = databasePath;
            _accountTableName = accountTableName;

            _zdManager = new ZDatabaseManager(databasePath);
        }

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public bool Login(string userName,string password)
        {
            string sql = string.Format("select * from {0} where UserName='{1}'",_accountTableName,userName);
            var user = _zdManager.GetADataRow(sql);
            if (user != null && user[1] == password)
            {
                _userName = user[0];
                _userPassword = user[1];
                _group = user[2];
                return true;
            }
            return false;
        }

        /// <summary>
        /// 添加账户
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="group"></param>
        /// <returns></returns>
        public bool AddUser(string userName,string password,string group)
        {
            string sql = string.Format(
                "insert into {0} (UserName,ＺPassword,ＺGroup) values('{1}','{2}','{3}')", _accountTableName, userName, password, group);
            if (!CheckUserNameExist(userName)&&_zdManager.UpdateDatabase(sql))
                return true;
            return false;
        }

        /// <summary>
        /// 删除账户
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public bool RemoveUser(string userName)
        {
            string sql = string.Format("delete from {0} where UserName='{1}'", _accountTableName, userName);
            if (_zdManager.UpdateDatabase(sql))
                return true;
            return false;
        }

        /// <summary>
        /// 获取用户列表
        /// </summary>
        /// <returns></returns>
        public List<string> GetUserList()
        {
            List<string> users=null;
            string sql = string.Format("select UserName from {0}",_accountTableName);
            DataSet ds = _zdManager.GetSomeData(sql);
            if(ds!=null)
            {
                users = new List<string>();
                foreach(DataRow udr in ds.Tables[0].Rows)
                {
                    users.Add((string)udr["UserName"]);
                }
            }
            return users;
        }

        /// <summary>
        /// 检查账户是否已存在
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        private bool CheckUserNameExist(string userName)
        {
            string sql = string.Format("select * from {0} where UserName='{1}'", _accountTableName, userName);
            var data = _zdManager.GetADataRow(sql);
            if (data == null)
                return false;
            return true;
        }

    }
}