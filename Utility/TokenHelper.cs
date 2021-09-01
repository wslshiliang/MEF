using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utility
{
    public static class TokenHelper
    {
        private static readonly List<TokenDb> LIST = new List<TokenDb>();
        /// <summary>
        /// 判断用户在Token列表中
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public static bool CheckUserCanLogin(string userId)
        {
            DeleteOverTimeDb();
            var db = LIST.FirstOrDefault(p => p.userId == userId);
            if (db != null && db.overTime > DateTime.Now)
                return true;
            return false;
        }
        /// <summary>
        /// 创建新登录
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public static string CreateToken(string userId, string userName)
        {
            var db = LIST.FirstOrDefault(p => p.userId == userId);
            if (db == null)
            {
                db = new TokenDb(userId, userName);
                LIST.Add(db);
            }
            else
            {
                db.RefreshOverTime();
            }
            DeleteOverTimeDb();
            return db.token;
        }
        private static void DeleteOverTimeDb()
        {
            var waiteDel = LIST.Where(p => p.overTime < DateTime.Now).ToList();
            while (waiteDel.Count > 0)
            {
                LIST.Remove(waiteDel[0]);
                waiteDel.RemoveAt(0);
            }
        }
        /// <summary>
        /// 检查Token
        /// </summary>
        /// <param name="token"></param>
        /// <param name="errMsg"></param>
        /// <returns></returns>
        internal static UserInfo CheckToken(string token, ref string errMsg)
        {
            var db = LIST.FirstOrDefault(p => p.token == token);
            if (db == null) errMsg = "没有登录信息";
            else if (db.overTime < DateTime.Now)
                errMsg = "登录已过期，请重新登录";
            else
            {
                DeleteOverTimeDb();
                return db.ToUserInfo();
            }
            return null;
        }

        /// <summary>
        /// 若用户已登录，踢出前面登录的用户
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public static string ChangeToken(string userId)
        {
            var db = LIST.FirstOrDefault(p => p.userId == userId);
            return db.ChangeToken();
        }

        internal static void LoginOut(string token)
        {
            var db = LIST.FirstOrDefault(p => p.token == token);
            if (db != null) LIST.Remove(db);
        }

        public static UserInfo GetUserInfo(string token, string defaultUserId = "无用户")
        {
            var db = LIST.FirstOrDefault(p => p.token == token);
            if (db != null && db.overTime > DateTime.Now)
            {
                return db.ToUserInfo();
            }
            else return new UserInfo(defaultUserId, defaultUserId);
        }

        internal static void RemoveToken(string userId)
        {
            var db = LIST.FirstOrDefault(p => p.userId == userId);
            if (db != null) LIST.Remove(db);
        }
    }

    public class UserInfo
    {
        public UserInfo() { }
        public UserInfo(string userId, string userName)
        {
            this.userId = userId;
            this.userName = userName;
        }
        public string userId { get; set; }
        public string userName { get; set; }
    }

    class TokenDb
    {
        public TokenDb(string userId, string userName)
        {
            this.userId = userId;
            this.userName = userName;
            RefreshOverTime();
            token = Guid.NewGuid().ToString("N");
        }
        public void RefreshOverTime()
        {
            overTime = DateTime.Now.AddMinutes(AppConfigurationValue.OverTimeSpanMinute);
        }
        public string userId { get; private set; }
        public string userName { get; set; }
        public string token { get; private set; }
        public DateTime overTime { get; private set; }

        public UserInfo ToUserInfo()
        {
            return new UserInfo(userId, userName);
        }

        internal string ChangeToken()
        {
            token = Guid.NewGuid().ToString("N");
            return token;
        }
    }
}
