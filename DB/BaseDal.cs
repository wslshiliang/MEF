using EntityModel.Sys;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB
{
     public class BaseDal<T> where T : BaseModel
    {
        static MySqlModel db
        {
            get
            {
                var fullName = typeof(MySqlModel).FullName;
                object efContext = System.Runtime.Remoting.Messaging.CallContext.GetData(fullName);
              
                if (efContext == null)
                {
                    MySqlModel _db = new MySqlModel();
                    System.Runtime.Remoting.Messaging.CallContext.SetData(fullName, _db);
                    efContext = _db;
                }
                 
                return efContext as MySqlModel;
            }
        }


        static MySqlModel _Context;
        static BaseDal()
        {
            _Context = db;
        }
        public static MySqlModel Context
        {
            get
            {
                return _Context;
            }
        }


        /// <summary>
        /// 添加
        /// </summary> 
        public T Add(T t)
        {
            var ret = Context.Set<T>().Add(t);
            return ret;
        }
        /// <summary>
        /// 修改
        /// </summary> 
        public T Update(T t)
        {
            //DbSet.Attach(t);
            Context.Entry(t).State = EntityState.Modified;
            return t;
        }
        /// <summary>
        /// 删除
        /// </summary> 
        public bool Remove(T t)
        {
            Context.Set<T>().Remove(t);
            return true;
        }
    }
}
