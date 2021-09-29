using Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityModel.Sys
{
   public partial class DictionaryModel : BaseModel
    {
        public DictionaryModel() : base() { }
      

        public DictionaryModel(string Code, string Name, string NamePy, string SysType, int LoaDlev, string SecType, string SecName, string CategoryName, string CategoryCode, int Value, int LoadIdx, E_ValueType ValueType,string uName, string remark = "")
        {
            this.EngName = EngName;
            this.Name = Name;
            this.NamePy = NamePy;
            this.SysType = SysType;
            this.LoaDlev = LoaDlev;
            this.SecType = SecType;
            this.SecName = SecName;
            this.CategoryName = CategoryName;
            this.CategoryCode = CategoryCode;
            this.Value = Value;
            this.ValueType = ValueType;
            this.LoadIdx = LoadIdx;
            this.Code = Code;
            this.Remark = remark;
            this.IsUsed = true;
            this.CrtTime = DateTime.Now;
            this.CrtUser=uName;
        }

        public void SetCode(string code)
        {
            this.Code = code;
        }

        //[return: Dynamic]
        //public static dynamic GetValue(ValueType Type, string Value)
        //{
        //    if (Type == ValueType.Int)
        //    {
        //        int num = 0;
        //        int.TryParse(Value, out num);
        //        return num;
        //    }
        //    return Value;
        //}
    }
}
