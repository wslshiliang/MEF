using Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityModel.Sys
{
   public  class DictionaryModel : BaseModel
    {
		public string Code
		{
			get;
			set;
		}

		public string EngName
		{
			get;
			set;
		}

		public string Name
		{
			get;
			set;
		}

		public string NamePy
		{
			get;
			set;
		}

		public string SysType
		{
			get;
			set;
		}

		public int LoaDlev
		{
			get;
			set;
		}

		public string SecType
		{
			get;
			set;
		}

		public string SecName
		{
			get;
			set;
		}

		public string CategoryName
		{
			get;
			set;
		}

		public string CategoryCode
		{
			get;
			set;
		}

		public int Value
		{
			get;
			set;
		}

		public E_ValueType ValueType
		{
			get;
			set;
		}

		public int LoadIdx
		{
			get;
			set;
		}

		//public DictionaryModel()
		//{
		//}

		//public DictionaryModel(string EngName, string Name, string NamePy, string SysType, int LoaDlev, string SecType, string SecName, string CategoryName, string CategoryCode, int Value, int LoadIdx, string remark = "")
		//{
		//	this.EngName = EngName;
		//	this.Name = Name;
		//	this.NamePy = NamePy;
		//	this.SysType = SysType;
		//	this.LoaDlev = LoaDlev;
		//	this.SecName = SecName;
		//	this.CategoryName = CategoryName;
		//	this.CategoryCode = CategoryCode;
		//	this.Value = Value;
		//	this.LoadIdx = LoadIdx;
		//}

		//public void SetCode(string code)
		//{
		//	this.Code = code;
		//}

		//[return: Dynamic]
		//public static dynamic GetValue(ValueType Type, string Value)
		//{
		//	if (Type == ValueType.Int)
		//	{
		//		int num = 0;
		//		int.TryParse(Value, out num);
		//		return num;
		//	}
		//	return Value;
		//}
	}
}
