using CS426.node;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace CS426.analysis
{
    class SemanticAnalyzer : DepthFirstAdapter
    {
        //This is our global symbol table
        Dictionary<string, Definition> globalSymbolTable;

        //THis is our local symbol table 
        Dictionary<string, Definition> localSymbolTable;

        //This is our decorated parse tree
        Dictionary<Node, Definition> decoratedParseTree; 

    public void PrintWarning(Token t, string msg)
        {
            Console.WriteLine("Line" + t.Line + ", Col" + t.Pos + ":" + msg);
        }

       public override void InAConstantProgram(AConstantProgram node)
       {
           //Create a global table
           globalSymbolTable = new Dictionary<string, Definition>();

            //create a local table
            localSymbolTable = new Dictionary<string, Definition>();

            //Initalize the Decorated Parse Tree
            decoratedParseTree = new Dictionary<Node, Definition>();

            Definition intDefintion = new NumberDefinition();
            intDefintion.name = "int";

            Definition strDefinition = new StringDefinition();
            strDefinition.name = "string";

            globalSymbolTable.Add("int", intDefintion);
            globalSymbolTable.Add("string", strDefinition);
        }

        public override void OutAIntOperand(AIntOperand node)
        {
            Definition intDefinition = new NumberDefinition();

        }
    }
}
