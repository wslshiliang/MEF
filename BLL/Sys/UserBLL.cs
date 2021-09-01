using DAL;
using DB;
using EntityModel.Sys;
using System.Linq;
using Utility;

namespace BLL.Sys
{
    [System.ComponentModel.Composition.Export(typeof(IUser))]
    public class UserBLL : BaseDal<UserModel>, IUser
    {
        public dynamic Login(string userId, string userPwd)
        {
            var pwd = Security.Md5Encryptor(userPwd);
           var userInfo = Context.User.FirstOrDefault(c => c.UserId == userId && c.UserPwd == pwd && c.IsUsed==true);
            if (userInfo == null)
                return Ret.Error(-1, "用户名或密码错误，请重新输入；若多次登录失败，或是该账号已停用，请联系系统管理员");
            else
            {
                //登录成功，计算token
                if (userInfo.IsOnLine && TokenHelper.CheckUserCanLogin(userInfo.UserId))
                {
                    //用户已登录，把前面登录的用户踢出
                    string token = TokenHelper.ChangeToken(userInfo.UserId);
                    return Ret<dynamic>.Error(5, new { token = token, userName = userInfo.UserName, userId = userInfo.UserId },
                        $"用户{userInfo.UserName}已在其他客户端登录，已被踢出。");
                }
                else
                {
                    var token = TokenHelper.CreateToken(userInfo.UserId, userInfo.UserName);
                    userInfo.UserLogin(userId);
                    base.Update(userInfo);
                    int res=Context.SaveChanges();

                    if (res > 0)
                    {
                        var result = Ret<dynamic>.Success(new { token = token, userName = userInfo.UserName, userId = userInfo.UserId });
                        return result;
                    }
                    else
                    {
                        return Ret.Error(-1, "数据更新失败");
                    }
                } 
            }
        }
    }
}
