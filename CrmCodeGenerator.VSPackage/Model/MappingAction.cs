﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrmPluginRegExt.VSPackage.Model
{
	[Serializable]
	public class MappingAction
	{
		public string Name;
		public string VarName;
		public string Description;
		public string TargetEntityName;
		public InputField[] InputFields;
		public OutputField[] OutputFields;

		[Serializable]
		public class InputField
		{
			public string Name;
			public string VarName;
			public string TypeName;
			public int Position;
			public string JavaScriptValidationType;
			public string JavaScriptValidationExpression;
			public string NamespacedType;
			public string SerializeExpression;
			public bool Optional;
		}
		[Serializable]
		public class OutputField
		{
			public string Name;
			public string VarName;
			public string TypeName;
			public int Position;
			public string ValueNodeParser;
			public string JavaScriptType;
		}
	}
}
