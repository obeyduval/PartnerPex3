using System;

namespace CS426.analysis
{
	public abstract classs Definition 
	{
		public string name;

	public override string ToString()
		{
		return name; 
		}
	}

public abstract class TypeDefinition : Definition { }

public class NumberDefinitioin : TypeDefinition { }

public class StringDefinition : TypeDefinition { }

public class VariableDefinition : Definition {
	public TypeDefinition variableType;
}

public class 
