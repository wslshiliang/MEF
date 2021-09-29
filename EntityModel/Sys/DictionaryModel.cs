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

	}
}
