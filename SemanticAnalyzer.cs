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
        Dictionary<string, Definition> globalSymbolTable = new Dictionary<string, Definition>();

        //THis is our local symbol table 
        Dictionary<string, Definition> localSymbolTable = new Dictionary<string, Definition>();

        //This is our decorated parse tree
        Dictionary<Node, Definition> decoratedParseTree = new Dictionary<Node, Definition>();

        FunctionDefinition currentFunction = null;

        public void PrintWarning(Token t, string msg)
        {
            Console.WriteLine(t.Line + "," + t.Pos + ":" + msg);
        }

        public override void InAPassProgram(APassProgram node)
        {
            Definition intDefinition = new NumberDefinition();
            intDefinition.name = "int";

            Definition strDefinition = new StringDefinition();
            strDefinition.name = "string";

            Definition floatDefinition = new FloatDefinition();
            floatDefinition.name = "float";

            globalSymbolTable.Add("int", intDefinition);
            globalSymbolTable.Add("string", strDefinition);
            globalSymbolTable.Add("float", floatDefinition);
        }

        public override void InAConstantProgram(AConstantProgram node)
        {
            Definition intDefinition = new NumberDefinition();
            intDefinition.name = "int";

            Definition strDefinition = new StringDefinition();
            strDefinition.name = "string";

            Definition floatDefinition = new FloatDefinition();
            floatDefinition.name = "float";

            globalSymbolTable.Add("int", intDefinition);
            globalSymbolTable.Add("string", strDefinition);
            globalSymbolTable.Add("float", floatDefinition);
        }

        public override void OutAIntOperand(AIntOperand node)
        {
            Definition intDefinition = new NumberDefinition();
            intDefinition.name = "int";

            decoratedParseTree.Add(node, intDefinition);

        }

        public override void OutAFloatOperand(AFloatOperand node)
        {
            Definition floatDefinition = new FloatDefinition();
            floatDefinition.name = "float";

            decoratedParseTree.Add(node, floatDefinition);

        }

        public override void OutAStringOperand(AStringOperand node)
        {
            Definition stringDefinition = new StringDefinition();
            stringDefinition.name = "string";

            decoratedParseTree.Add(node, stringDefinition);
        }

        public override void OutAVariableOperand(AVariableOperand node)
        {
            String varName = node.GetId().Text;

            Definition varDefinition;

            if(!localSymbolTable.TryGetValue(varName, out varDefinition))
            {
                PrintWarning(node.GetId(), "Variable" + varName + "does not exist");
            }
            else if (!(varDefinition is VariableDefinition))
            {
                PrintWarning(node.GetId(), "Identifier" + varName + "is not a variable");
            }
            else
            {
                VariableDefinition v = (VariableDefinition)varDefinition;

                decoratedParseTree.Add(node, v.variableType);
            }


        }

        public override void OutAPassExpression4(APassExpression4 node)
        {
            Definition operandDefinition; 

            if(!decoratedParseTree.TryGetValue(node.GetOperand(), out operandDefinition))
            {
                //error would have printed at a lower node

            }
            else
            {
                decoratedParseTree.Add(node, operandDefinition);
            }
        }

        public override void OutAExpression4(AExpression4 node)
        {
            // open_parent or_expression close_parent | {pass} operand;

            Definition OrDef;

            if (!decoratedParseTree.TryGetValue(node.GetOrExpression(), out OrDef))
            {
                //error would have been printed at a lower node
            }
            else
            {
                    decoratedParseTree.Add(node, OrDef);
            }

        }

        public override void OutAPassExpression3(APassExpression3 node)
        {
            Definition expression4Def;

            if(!decoratedParseTree.TryGetValue(node.GetExpression4(), out expression4Def))
            {
                //error would have been printed at a lower node
            } 
            else
            {
                decoratedParseTree.Add(node, expression4Def);
            }
        }

        public override void OutANotExpression3(ANotExpression3 node)
        {
            //{not} not expression3
            Definition expression3Type;

            if (!decoratedParseTree.TryGetValue(node.GetExpression3(), out expression3Type))
            {
                //error would have been printed at a lower node 
            }
            else if (!(expression3Type is NumberDefinition))
            {
                PrintWarning(node.GetNot(), "Not only applies to numbers");
            }
            else
            {
                decoratedParseTree.Add(node, expression3Type);
            }
        }

        public override void OutANegExpression3(ANegExpression3 node)
        {
            //{neg} minus expression3
            Definition expression3Type;

            if (!decoratedParseTree.TryGetValue(node.GetExpression3(), out expression3Type))
            {
                //error would have been printed at a lower node 
            }
            else if (!(expression3Type is NumberDefinition))
            {
                PrintWarning(node.GetMinus(), "Only a number of float can be negated");
            }
            else if (!(expression3Type is FloatDefinition))
            {
                PrintWarning(node.GetMinus(), "Only a number or float can be negated");
            }
            else
            {
                decoratedParseTree.Add(node, expression3Type);
            }
        }

        public override void OutAPassExpression2(APassExpression2 node)
        {
            Definition expression3Def;

            if(!decoratedParseTree.TryGetValue(node.GetExpression3(), out expression3Def))
            {
                //Error would have printed at a lower node
            }
            else
            {
                decoratedParseTree.Add(node, expression3Def);
            }
        }

        public override void OutAMinusExpression2(AMinusExpression2 node)
        {
            //{minus} expression2 minus expression3
            Definition expression2Type;
            Definition expression3Type;

            if (!decoratedParseTree.TryGetValue(node.GetExpression2(), out expression2Type))
            {
                //error would have been printed at a lower node

            }
            else if (!decoratedParseTree.TryGetValue(node.GetExpression3(), out expression3Type))
            {
                //error would have been printed at a lower node 
            }
            else if (expression2Type.name != expression3Type.name)
            {
                PrintWarning(node.GetMinus(), "Could not subtract" + expression2Type.name + "and" + expression3Type.name);
            }
            else if (!(expression2Type is NumberDefinition))
            {
                PrintWarning(node.GetMinus(), "Could not subtract something of type" + expression2Type);
            }
            else
            {
                decoratedParseTree.Add(node, expression2Type);
            }
        }

        public override void OutAAddExpression2(AAddExpression2 node)
        {
            //{add} expression2 plus expression3
            //probably the same with * - and /

            Definition expression2Type;
            Definition expression3Type; 

            if(!decoratedParseTree.TryGetValue(node.GetExpression2(), out expression2Type))
            {
                //error would have been printed at a lower node

            }
            else if (!decoratedParseTree.TryGetValue(node.GetExpression3(), out expression3Type))
            {
                //error would have been printed at a lower node 
            }
            else if (expression2Type.name != expression3Type.name)
            {
                PrintWarning(node.GetPlus(), "Could not add" + expression2Type.name + "and" + expression3Type.name);
            }
            else if (!(expression2Type is NumberDefinition))
            {
                PrintWarning(node.GetPlus(), "Could not add something of type" + expression2Type);
            }
            else
            {
                decoratedParseTree.Add(node, expression2Type);
            }
        }

        public override void OutAPassExpression(APassExpression node)
        {
            Definition expression2Def;

            if (!decoratedParseTree.TryGetValue(node.GetExpression2(), out expression2Def))
            {
                //Error would have printed at a lower node
            }
            else
            {
                decoratedParseTree.Add(node, expression2Def);
            }
        }

        public override void OutADivExpression(ADivExpression node)
        {
            //{div} expression div expression2

            Definition expressionType;
            Definition expression2Type;

            if (!decoratedParseTree.TryGetValue(node.GetExpression(), out expressionType))
            {
                // the error would have been printed at the lower node.
            }
            else if (!decoratedParseTree.TryGetValue(node.GetExpression2(), out expression2Type))
            {
                // the error would have been printed at the lower node.
            }
            else if (expressionType.name != expression2Type.name)
            {
                PrintWarning(node.GetDiv(), "Could not divide " + expressionType.name
                    + " and " + expression2Type.name);
            }
            else if (!(expressionType is NumberDefinition))
            {
                PrintWarning(node.GetDiv(), "Could not divide something of type"
                    + expressionType.name);
            }
            else
            {
                decoratedParseTree.Add(node, expressionType);
            } 
        }

        public override void OutAMultExpression(AMultExpression node)
        {
            //{mult} expression mult expression2

            Definition expressionDef;
            Definition expression2Def;

            if (!decoratedParseTree.TryGetValue(node.GetExpression(), out expressionDef))
            {
                // We are checking to see if the node below us was decorated.
                // We don't have to print an error, because if something bad happened
                // the error would have been printed at the lower node.
            }
            else if (!decoratedParseTree.TryGetValue(node.GetExpression2(), out expression2Def))
            {
                // We are checking to see if the node below us was decorated.
                // We don't have to print an error, because if something bad happened
                // the error would have been printed at the lower node.
            }
            else if (expressionDef.GetType() != expression2Def.GetType())
            {
                PrintWarning(node.GetMult(), "Cannot multiply " + expressionDef.name
                    + " by " + expression2Def.name);
            }
            else if (!(expressionDef is NumberDefinition))
            {
                PrintWarning(node.GetMult(), "Cannot multiply something of type "
                    + expressionDef.name);
            }
            else
            {
                // Decorate ourselves (either expression2def or expression3def would work)
                decoratedParseTree.Add(node, expressionDef);
            }
        }

        public override void OutAPassQuantityExpression(APassQuantityExpression node)
        {
            //{pass} expression

            Definition expressionDef;

            if (!decoratedParseTree.TryGetValue(node.GetExpression(), out expressionDef))
            {
                //Error would have printed at a lower node
            }
            else
            {
                decoratedParseTree.Add(node, expressionDef);
            }

        }

        public override void OutALessQuantityExpression(ALessQuantityExpression node)
        {
            //{less} quantity_expression less expression

            Definition quantityExpDef;
            Definition expression;

            if (!decoratedParseTree.TryGetValue(node.GetQuantityExpression(), out quantityExpDef))
            {
                // the error would have been printed at the lower node.
            }
            else if (!decoratedParseTree.TryGetValue(node.GetExpression(), out expression))
            {
                // We are checking to see if the node below us was decorated.
                // We don't have to print an error, because if something bad happened
                // the error would have been printed at the lower node.
            }
            else if (quantityExpDef.GetType() != expression.GetType())
            {
                PrintWarning(node.GetLess(), "Cannot compare" + quantityExpDef.name
                    + " and" + expression.name);
            }
            else if (!(quantityExpDef is NumberDefinition))
            {
                PrintWarning(node.GetLess(), "Cannot compare something of type "
                    + quantityExpDef.name);
            }
            else
            {
                decoratedParseTree.Add(node, quantityExpDef);
            }
        }

        public override void OutAGreaterQuantityExpression(AGreaterQuantityExpression node)
        {
            //{greater} quantity_expression greater expression

            Definition quantityExpDef;
            Definition expression;

            if (!decoratedParseTree.TryGetValue(node.GetQuantityExpression(), out quantityExpDef))
            {
                // the error would have been printed at the lower node.
            }
            else if (!decoratedParseTree.TryGetValue(node.GetExpression(), out expression))
            {
                // We are checking to see if the node below us was decorated.
                // We don't have to print an error, because if something bad happened
                // the error would have been printed at the lower node.
            }
            else if (quantityExpDef.GetType() != expression.GetType())
            {
                PrintWarning(node.GetGreater(), "Cannot compare" + quantityExpDef.name
                    + " and" + expression.name);
            }
            else if (!(quantityExpDef is NumberDefinition))
            {
                PrintWarning(node.GetGreater(), "Cannot compare something of type "
                    + quantityExpDef.name);
            }
            else
            {
                decoratedParseTree.Add(node, quantityExpDef);
            }
        }

        public override void OutAPassEqualExpressions(APassEqualExpressions node)
        {
            //{pass} quantity_expression

            Definition expressionDef;

            if (!decoratedParseTree.TryGetValue(node.GetQuantityExpression(), out expressionDef))
            {
                //Error would have printed at a lower node
            }
            else
            {
                decoratedParseTree.Add(node, expressionDef);
            }


        }

        public override void OutAEquivEqualExpressions(AEquivEqualExpressions node)
        {
            //equal_expressions equiv quantity_expression

            Definition equalExpDef;
            Definition quantityExpDef;

            if (!decoratedParseTree.TryGetValue(node.GetEqualExpressions(), out equalExpDef))
            {
                // the error would have been printed at the lower node.
            }
            else if (!decoratedParseTree.TryGetValue(node.GetQuantityExpression(), out quantityExpDef))
            {
                // We are checking to see if the node below us was decorated.
                // We don't have to print an error, because if something bad happened
                // the error would have been printed at the lower node.
            }
            else if (quantityExpDef.GetType() != equalExpDef.GetType())
            {
                PrintWarning(node.GetEquiv(), "Cannot compare" + quantityExpDef.name
                    + " and" + equalExpDef.name);
            }
            else if (!(quantityExpDef is NumberDefinition))
            {
                PrintWarning(node.GetEquiv(), "Cannot compare something of type "
                    + quantityExpDef.name);
            }
            else
            {
                decoratedParseTree.Add(node, quantityExpDef);
            }
        }

        public override void OutANotEquivEqualExpressions(ANotEquivEqualExpressions node)
        {
            //equal_expressions not_equiv quantity_expression

            Definition equalExpDef;
            Definition quantityExpDef;

            if (!decoratedParseTree.TryGetValue(node.GetEqualExpressions(), out equalExpDef))
            {
                // the error would have been printed at the lower node.
            }
            else if (!decoratedParseTree.TryGetValue(node.GetQuantityExpression(), out quantityExpDef))
            {
                // We are checking to see if the node below us was decorated.
                // We don't have to print an error, because if something bad happened
                // the error would have been printed at the lower node.
            }
            else if (quantityExpDef.GetType() != equalExpDef.GetType())
            {
                PrintWarning(node.GetNotEquiv(), "Cannot compare" + quantityExpDef.name
                    + " and" + equalExpDef.name);
            }
            else if (!(quantityExpDef is NumberDefinition))
            {
                PrintWarning(node.GetNotEquiv(), "Cannot compare something of type "
                    + quantityExpDef.name);
            }
            else
            {
                decoratedParseTree.Add(node, quantityExpDef);
            }
        }

        public override void OutAGreatEqualEqualExpressions(AGreatEqualEqualExpressions node)
        {
            // { great_equal} equal_expressions great_equal quantity_expression
            Definition equalExpDef;
            Definition quantityExpDef;

            if (!decoratedParseTree.TryGetValue(node.GetEqualExpressions(), out equalExpDef))
            {
                // the error would have been printed at the lower node.
            }
            else if (!decoratedParseTree.TryGetValue(node.GetQuantityExpression(), out quantityExpDef))
            {
                // We are checking to see if the node below us was decorated.
                // We don't have to print an error, because if something bad happened
                // the error would have been printed at the lower node.
            }
            else if (quantityExpDef.GetType() != equalExpDef.GetType())
            {
                PrintWarning(node.GetGreatEqual(), "Cannot compare" + quantityExpDef.name
                    + " and" + equalExpDef.name);
            }
            else if (!(quantityExpDef is NumberDefinition))
            {
                PrintWarning(node.GetGreatEqual(), "Cannot compare something of type "
                    + quantityExpDef.name);
            }
            else
            {
                decoratedParseTree.Add(node, quantityExpDef);
            }
        }

        public override void OutALessEqualEqualExpressions(ALessEqualEqualExpressions node)
        {
            //{less_equal} equal_expressions less_equal quantity_expression

            Definition equalExpDef;
            Definition quantityExpDef;

            if (!decoratedParseTree.TryGetValue(node.GetEqualExpressions(), out equalExpDef))
            {
                // the error would have been printed at the lower node.
            }
            else if (!decoratedParseTree.TryGetValue(node.GetQuantityExpression(), out quantityExpDef))
            {
                // We are checking to see if the node below us was decorated.
                // We don't have to print an error, because if something bad happened
                // the error would have been printed at the lower node.
            }
            else if (quantityExpDef.GetType() != equalExpDef.GetType())
            {
                PrintWarning(node.GetLessEqual(), "Cannot compare" + quantityExpDef.name
                    + " and" + equalExpDef.name);
            }
            else if (!(quantityExpDef is NumberDefinition))
            {
                PrintWarning(node.GetLessEqual(), "Cannot compare something of type "
                    + quantityExpDef.name);
            }
            else
            {
                decoratedParseTree.Add(node, quantityExpDef);
            }
        }

        public override void OutAPassAndExpression(APassAndExpression node)
        {
            //{pass} equal_expressions
            Definition expressionDef;

            if (!decoratedParseTree.TryGetValue(node.GetEqualExpressions(), out expressionDef))
            {
                //Error would have printed at a lower node
            }
            else
            {
                decoratedParseTree.Add(node, expressionDef);
            }

        }

        public override void OutAAndAndExpression(AAndAndExpression node)
        {
            //{and} and_expression and equal_expressions

            Definition equalExpDef;
            Definition andExpDef;

            if (!decoratedParseTree.TryGetValue(node.GetEqualExpressions(), out equalExpDef))
            {
                // the error would have been printed at the lower node.
            }
            else if (!decoratedParseTree.TryGetValue(node.GetAndExpression(), out andExpDef))
            {
       
                // the error would have been printed at the lower node.
            }
            else if (andExpDef.GetType() != equalExpDef.GetType())
            {
                PrintWarning(node.GetAnd(), "Cannot compare" + equalExpDef.name
                    + " and" + andExpDef.name);
            }
            else
            {
                decoratedParseTree.Add(node, equalExpDef);
            }
        }

        public override void OutAPassOrExpression(APassOrExpression node)
        {
            Definition expressionDef;

            if (!decoratedParseTree.TryGetValue(node.GetAndExpression(), out expressionDef))
            {
                //Error would have printed at a lower node
            }
            else
            {
                decoratedParseTree.Add(node, expressionDef);
            }
        }

        public override void OutAOrOrExpression(AOrOrExpression node)
        {
            //{or} or_expression or and_expression

            Definition orExpDef;
            Definition andExpDef;

            if (!decoratedParseTree.TryGetValue(node.GetOrExpression(), out orExpDef))
            {
                // the error would have been printed at the lower node.
            }
            else if (!decoratedParseTree.TryGetValue(node.GetAndExpression(), out andExpDef))
            {

                // the error would have been printed at the lower node.
            }
            else if (andExpDef.GetType() != orExpDef.GetType())
            {
                PrintWarning(node.GetOr(), "Cannot compare" + orExpDef.name
                    + " and" + andExpDef.name);
            }
            else
            {
                decoratedParseTree.Add(node, orExpDef);
            }
        }

        //------------------------------
        //FINISH THE REST OF EXPRESSION and review 
        // -----------------------------

        //-----------------------------
        //Onto the statements! :D
        //-----------------------------

        public override void OutAConstantConstantDec(AConstantConstantDec node)
        {
            // {constant} keyword_constant [type]:id [varname]:id assign or_expression eol;
            Definition idDef;
            Definition varDef;
            Definition orExp;

            if(!globalSymbolTable.TryGetValue(node.GetType().Text, out idDef))
            {
                PrintWarning(node.GetType(), "Type " + node.GetType().Text + " does not exist");
            }
            else if (localSymbolTable.TryGetValue(node.GetVarname().Text, out varDef))
            {
                PrintWarning(node.GetVarname(), "ID " + node.GetVarname().Text + " has already been declared");
            }
            else if (!decoratedParseTree.TryGetValue(node.GetOrExpression(), out orExp))
            {
                //Error would have printed at a lower node 
            }
            else
            {
                // Add the id to the symbol table
                VariableDefinition newVariableDefinition = new VariableDefinition();
                newVariableDefinition.name = node.GetVarname().Text;
                newVariableDefinition.variableType = (TypeDefinition) idDef;

                localSymbolTable.Add(node.GetVarname().Text, newVariableDefinition);
            }
        }

        public override void OutALoopWhileStatement(ALoopWhileStatement node)
        {
            //	while_statement = {loop} keyword_while left_bracket or_expression right_bracket end statements end1; 
           Definition orDef;

            if (!decoratedParseTree.TryGetValue(node.GetOrExpression(), out orDef))
            {
                //error would have been printed at a lower node
            } else if(!(orDef is BooleanDefinition))
            {
                PrintWarning(node.GetLeftBracket(), "While " + node.GetOrExpression() + " is not a boolean");
            }
        }

        public override void OutAConditionalIfStatement(AConditionalIfStatement node)
        {
            //	if_statement = {conditional} keyword_if open_parent or_expression close_parent left_bracket statements right_bracket else_statement;
            Definition orDef;

            if(!decoratedParseTree.TryGetValue(node.GetOrExpression(), out orDef))
            {
                //error would have been printed at a lower node
            }
            else if(!(orDef is Boolean))
            {
                PrintWarning(node.GetOpenParent(), "If " + node.GetOrExpression() + " is not a boolesan");
            }

        }

        public override void OutAAssignmentAssignStatement(AAssignmentAssignStatement node)
        {
            //assign_statement = {assignment} id assign or_expression eol

            Definition idDef;
            Definition expressionDef;

            if (!localSymbolTable.TryGetValue(node.GetId().Text, out idDef))
            {
                PrintWarning(node.GetId(), "ID " + node.GetId().Text + " does not exist");
            }
            else if (!(idDef is VariableDefinition))
            {
                PrintWarning(node.GetId(), "ID " + node.GetId().Text + " is not a variable");
            }
            else if (!decoratedParseTree.TryGetValue(node.GetOrExpression(), out expressionDef))
            {
                // We are checking to see if the node below us was decorated.
                // We don't have to print an error, because if something bad happened
                // the error would have been printed at the lower node.
            }
            else if (((VariableDefinition)idDef).variableType.name != expressionDef.name)
            {
                PrintWarning(node.GetId(), "Cannot assign value of type " + expressionDef.name
                    + " to variable of type " + ((VariableDefinition)idDef).variableType.name);
            }
            else
            {
                // NOTHING IS REQUIRED ONCE ALL THE TESTS HAVE PASSED
            }
        }
        
        public override void OutACallFunctionCallStatement(ACallFunctionCallStatement node)
        {
            //	function_call_statement = {call} id open_parent arguments close_parent eol; 

            Definition idDef;

            if (!globalSymbolTable.TryGetValue(node.GetId().Text, out idDef))
            {
                PrintWarning(node.GetId(), "ID " + node.GetId().Text + " not found");
            }
            else if (!(idDef is FunctionDefinition))
            {
                PrintWarning(node.GetId(), "ID " + node.GetId().Text + " is not a function");
            }

            // TODO:  Verify parameters are in the correct order, and are of the correct type
            // HINT:  You can use a class variable to "build" a list of the parameters as
            //        you discover them!
            // Add the id to the symbol table
            else
            {
                VariableDefinition newVariableDefinition = new VariableDefinition();
                newVariableDefinition.name = node.GetId().Text;
                this.currentFunction.parameters.Add(newVariableDefinition);

                localSymbolTable.Add(node.GetId().Text, newVariableDefinition);
            }
        }

        public override void OutADeclarationDeclareStatement(ADeclarationDeclareStatement node)
        
        {
            //	declare_statement = {declaration} [type]:id [varname]:id eol;	

            Definition typeDef;
            Definition idDef;

            if (!globalSymbolTable.TryGetValue(node.GetType().Text, out typeDef))
            {
                // If the type
                // doesn't exist, throw an error
                PrintWarning(node.GetType(), "Type " + node.GetType().Text + " does not exist");
            }
            else if (localSymbolTable.TryGetValue(node.GetVarname().Text, out idDef))
            {
                // If the id exists, then we can't declare something with the same name
                PrintWarning(node.GetVarname(), "ID " + node.GetVarname().Text
                    + " has already been declared");
            }
            else
            {
                // Add the id to the symbol table
                VariableDefinition newVariableDefinition = new VariableDefinition();
                newVariableDefinition.name = node.GetVarname().Text;
                newVariableDefinition.variableType = (TypeDefinition)typeDef;

                localSymbolTable.Add(node.GetVarname().Text, newVariableDefinition);
            }
        }

        //----------------
        //FUNCTION CALLS
        //----------------

        public override void InASingleFunctionDec(ASingleFunctionDec node)
        {
            Definition idDef;

            if (globalSymbolTable.TryGetValue(node.GetId().Text, out idDef))
            {
                PrintWarning(node.GetId(), "Identifier " + node.GetId().Text + " is already being used");
            }
            else
            {
                // Wipes out the local symbol table
                localSymbolTable = new Dictionary<string, Definition>();

                // Registers the New Function Definition in the Global Table
                FunctionDefinition newFunctionDefinition = new FunctionDefinition();
                newFunctionDefinition.name = node.GetId().Text;

                // TODO:  You will have to figure out how to populate this with parameters
                // when you work on PEX 3
                newFunctionDefinition.parameters = new List<VariableDefinition>();

                // Adds the Function!
                globalSymbolTable.Add(node.GetId().Text, newFunctionDefinition);
            }
        }

        public override void OutASingleFunctionDec(ASingleFunctionDec node)
        {
            //Wipes out the local symbol table so that the next function doesn't have to deal with it
            localSymbolTable = new Dictionary<string, Definition>();

        }

        public override void OutASingleParameters(ASingleParameters node)
        {
            // {single} [type]:id [varname]:id 

            Definition typeDef;
            Definition idDef;

            if (!globalSymbolTable.TryGetValue(node.GetType().Text, out typeDef))
            {
                // If the type
                // doesn't exist, throw an error
                PrintWarning(node.GetType(), "Type " + node.GetType().Text + " does not exist");
            }
            else if (localSymbolTable.TryGetValue(node.GetVarname().Text, out idDef))
            {
                // If the id exists, then we can't declare something with the same name
                PrintWarning(node.GetVarname(), "ID " + node.GetVarname().Text
                    + " has already been declared");
            }
            else
            {
                // Add the id to the symbol table
                VariableDefinition newVariableDefinition = new VariableDefinition();
                newVariableDefinition.name = node.GetVarname().Text;
                newVariableDefinition.variableType = (TypeDefinition)typeDef;

                this.currentFunction.parameters.Add(newVariableDefinition);

                localSymbolTable.Add(node.GetVarname().Text, newVariableDefinition);
            }

        }

        public override void OutAMultipleParameters(AMultipleParameters node)
        {
            //{multiple} [type]:id [varname]:id comma parameters

            Definition typeDef;
            Definition idDef;

            if (!globalSymbolTable.TryGetValue(node.GetType().Text, out typeDef))
            {
                // If the type
                // doesn't exist, throw an error
                PrintWarning(node.GetType(), "Type " + node.GetType().Text + " does not exist");
            }
            else if (localSymbolTable.TryGetValue(node.GetVarname().Text, out idDef))
            {
                // If the id exists, then we can't declare something with the same name
                PrintWarning(node.GetVarname(), "ID " + node.GetVarname().Text
                    + " has already been declared");
            }
            else
            {
                // Add the id to the symbol table
                VariableDefinition newVariableDefinition = new VariableDefinition();
                newVariableDefinition.name = node.GetVarname().Text;
                newVariableDefinition.variableType = (TypeDefinition)typeDef;

                this.currentFunction.parameters.Add(newVariableDefinition);

                localSymbolTable.Add(node.GetVarname().Text, newVariableDefinition);
            }
        }

        public override void OutASingleArguments(ASingleArguments node)
        {
            //{single} or_expression

            Definition expressionDef;

            if (!decoratedParseTree.TryGetValue(node.GetOrExpression(), out expressionDef))
            {
                // We are checking to see if the node below us was decorated.
                // We don't have to print an error, because if something bad happened
                // the error would have been printed at the lower node.
            }
            else if (!(expressionDef is NumberDefinition) || !(expressionDef is StringDefinition))
            {
                Console.WriteLine("Invalid Parameter: " + expressionDef);
            }

        }

        public override void OutAMultipleArguments(AMultipleArguments node)
        {
            // {multiple} or_expression comma arguments

            Definition expressionDef;

            if (!decoratedParseTree.TryGetValue(node.GetOrExpression(), out expressionDef))
            {
                // We are checking to see if the node below us was decorated.
                // We don't have to print an error, because if something bad happened
                // the error would have been printed at the lower node.
            }
            else if (!(expressionDef is NumberDefinition) || !(expressionDef is StringDefinition))
            {
                Console.WriteLine("Invalid Parameter: " + expressionDef);
            }
            //Does multiple arguments need to save a list of expressions as well? I dont think so, but just in case
            /*else
            {
                // Add the id to the symbol table
                VariableDefinition newVariableDefinition = new VariableDefinition();
                newVariableDefinition.name = node.GetOrExpression().ToString;
                newVariableDefinition.variableType = (TypeDefinition)typeDef;

                this.currentFunction.parameters.Add(newVariableDefinition);

                localSymbolTable.Add(node.GetVarname().Text, newVariableDefinition);
            }*/
                
        }
    }
}
