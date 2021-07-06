using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB
{
    public  class MySqlConncetion:BaseDal
    {
        public static void ConnectTest()
        { 
            bool exist= Context.Database.Exists();

            if (!exist)
            {
                bool flag = Context.Database.CreateIfNotExists();

                if (flag == true)
                {
                    Console.WriteLine("MySQL数据库创建成功！");
                }
                else
                {
                    Console.WriteLine("MySQL数据库创建失败！");
                }
            }
            else
            {
                //测试
                //     var res = Context.Database.SqlQuery<EntityModel.DemoClass>("select * from W_DemoClass;").FirstOrDefault();
            }
        }
    }
}

/*
 packages---EntityFramework.6.4.0(EntityFramework.dll,EntityFramework.SqlServer.dll);MySql.Data.6.10.9(MySql.Data.dll);MySql.Data.Entity.6.10.9(MySql.Data.Entity.EF6.dll)
 */