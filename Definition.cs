using System;
using CS426.node;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace CS426.analysis
{
	public abstract class Definition
	{
		public string name;

		public override string ToString()
		{
			return name;
		}
	}

	public abstract class TypeDefinition : Definition { }

	public class NumberDefinition : TypeDefinition { }

	public class StringDefinition : TypeDefinition { }

	public class VariableDefinition : Definition
	{
		public TypeDefinition variableType;
	}

	public class FloatDefinition : TypeDefinition { }

	public class BooleanDefinition : TypeDefinition { }

	public class FunctionDefinition : Definition
	{
		public List<VariableDefinition> parameters;
	}
}

