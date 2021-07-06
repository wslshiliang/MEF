using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB
{
     public class BaseDal
    {
        static MySqlModel db
        {
            get
            { 
                object efContext = System.Runtime.Remoting.Messaging.CallContext.GetData(typeof(MySqlModel).FullName);
              
                if (efContext == null)
                {
                    MySqlModel _db = new MySqlModel();
                    System.Runtime.Remoting.Messaging.CallContext.SetData(typeof(MySqlModel).FullName, _db);
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
    }
}
