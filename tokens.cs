/* This file was generated by SableCC (http://www.sablecc.org/). */

using System;
using System.Collections;
using System.Text;

using  CS426.analysis;

namespace CS426.node {


public sealed class TKeywordWhile : Token
{
    public TKeywordWhile(string text)
    {
        Text = text;
    }

    public TKeywordWhile(string text, int line, int pos)
    {
        Text = text;
        Line = line;
        Pos = pos;
    }

    public override Object Clone()
    {
      return new TKeywordWhile(Text, Line, Pos);
    }

    public override void Apply(Switch sw)
    {
        ((Analysis) sw).CaseTKeywordWhile(this);
    }
}

public sealed class TKeywordLoop : Token
{
    public TKeywordLoop(string text)
    {
        Text = text;
    }

    public TKeywordLoop(string text, int line, int pos)
    {
        Text = text;
        Line = line;
        Pos = pos;
    }

    public override Object Clone()
    {
      return new TKeywordLoop(Text, Line, Pos);
    }

    public override void Apply(Switch sw)
    {
        ((Analysis) sw).CaseTKeywordLoop(this);
    }
}

public sealed class TKeywordConstant : Token
{
    public TKeywordConstant(string text)
    {
        Text = text;
    }

    public TKeywordConstant(string text, int line, int pos)
    {
        Text = text;
        Line = line;
        Pos = pos;
    }

    public override Object Clone()
    {
      return new TKeywordConstant(Text, Line, Pos);
    }

    public override void Apply(Switch sw)
    {
        ((Analysis) sw).CaseTKeywordConstant(this);
    }
}

public sealed class TKeywordStart : Token
{
    public TKeywordStart(string text)
    {
        Text = text;
    }

    public TKeywordStart(string text, int line, int pos)
    {
        Text = text;
        Line = line;
        Pos = pos;
    }

    public override Object Clone()
    {
      return new TKeywordStart(Text, Line, Pos);
    }

    public override void Apply(Switch sw)
    {
        ((Analysis) sw).CaseTKeywordStart(this);
    }
}

public sealed class TKeywordEnd : Token
{
    public TKeywordEnd(string text)
    {
        Text = text;
    }

    public TKeywordEnd(string text, int line, int pos)
    {
        Text = text;
        Line = line;
        Pos = pos;
    }

    public override Object Clone()
    {
      return new TKeywordEnd(Text, Line, Pos);
    }

    public override void Apply(Switch sw)
    {
        ((Analysis) sw).CaseTKeywordEnd(this);
    }
}

public sealed class TKeywordIf : Token
{
    public TKeywordIf(string text)
    {
        Text = text;
    }

    public TKeywordIf(string text, int line, int pos)
    {
        Text = text;
        Line = line;
        Pos = pos;
    }

    public override Object Clone()
    {
      return new TKeywordIf(Text, Line, Pos);
    }

    public override void Apply(Switch sw)
    {
        ((Analysis) sw).CaseTKeywordIf(this);
    }
}

public sealed class TKeywordElse : Token
{
    public TKeywordElse(string text)
    {
        Text = text;
    }

    public TKeywordElse(string text, int line, int pos)
    {
        Text = text;
        Line = line;
        Pos = pos;
    }

    public override Object Clone()
    {
      return new TKeywordElse(Text, Line, Pos);
    }

    public override void Apply(Switch sw)
    {
        ((Analysis) sw).CaseTKeywordElse(this);
    }
}

public sealed class TKeywordFunction : Token
{
    public TKeywordFunction(string text)
    {
        Text = text;
    }

    public TKeywordFunction(string text, int line, int pos)
    {
        Text = text;
        Line = line;
        Pos = pos;
    }

    public override Object Clone()
    {
      return new TKeywordFunction(Text, Line, Pos);
    }

    public override void Apply(Switch sw)
    {
        ((Analysis) sw).CaseTKeywordFunction(this);
    }
}

public sealed class TKeywordThen : Token
{
    public TKeywordThen(string text)
    {
        Text = text;
    }

    public TKeywordThen(string text, int line, int pos)
    {
        Text = text;
        Line = line;
        Pos = pos;
    }

    public override Object Clone()
    {
      return new TKeywordThen(Text, Line, Pos);
    }

    public override void Apply(Switch sw)
    {
        ((Analysis) sw).CaseTKeywordThen(this);
    }
}

public sealed class TEol : Token
{
    public TEol(string text)
    {
        Text = text;
    }

    public TEol(string text, int line, int pos)
    {
        Text = text;
        Line = line;
        Pos = pos;
    }

    public override Object Clone()
    {
      return new TEol(Text, Line, Pos);
    }

    public override void Apply(Switch sw)
    {
        ((Analysis) sw).CaseTEol(this);
    }
}

public sealed class TAssign : Token
{
    public TAssign(string text)
    {
        Text = text;
    }

    public TAssign(string text, int line, int pos)
    {
        Text = text;
        Line = line;
        Pos = pos;
    }

    public override Object Clone()
    {
      return new TAssign(Text, Line, Pos);
    }

    public override void Apply(Switch sw)
    {
        ((Analysis) sw).CaseTAssign(this);
    }
}

public sealed class TPlus : Token
{
    public TPlus(string text)
    {
        Text = text;
    }

    public TPlus(string text, int line, int pos)
    {
        Text = text;
        Line = line;
        Pos = pos;
    }

    public override Object Clone()
    {
      return new TPlus(Text, Line, Pos);
    }

    public override void Apply(Switch sw)
    {
        ((Analysis) sw).CaseTPlus(this);
    }
}

public sealed class TMult : Token
{
    public TMult(string text)
    {
        Text = text;
    }

    public TMult(string text, int line, int pos)
    {
        Text = text;
        Line = line;
        Pos = pos;
    }

    public override Object Clone()
    {
      return new TMult(Text, Line, Pos);
    }

    public override void Apply(Switch sw)
    {
        ((Analysis) sw).CaseTMult(this);
    }
}

public sealed class TDiv : Token
{
    public TDiv(string text)
    {
        Text = text;
    }

    public TDiv(string text, int line, int pos)
    {
        Text = text;
        Line = line;
        Pos = pos;
    }

    public override Object Clone()
    {
      return new TDiv(Text, Line, Pos);
    }

    public override void Apply(Switch sw)
    {
        ((Analysis) sw).CaseTDiv(this);
    }
}

public sealed class TMinus : Token
{
    public TMinus(string text)
    {
        Text = text;
    }

    public TMinus(string text, int line, int pos)
    {
        Text = text;
        Line = line;
        Pos = pos;
    }

    public override Object Clone()
    {
      return new TMinus(Text, Line, Pos);
    }

    public override void Apply(Switch sw)
    {
        ((Analysis) sw).CaseTMinus(this);
    }
}

public sealed class TEquiv : Token
{
    public TEquiv(string text)
    {
        Text = text;
    }

    public TEquiv(string text, int line, int pos)
    {
        Text = text;
        Line = line;
        Pos = pos;
    }

    public override Object Clone()
    {
      return new TEquiv(Text, Line, Pos);
    }

    public override void Apply(Switch sw)
    {
        ((Analysis) sw).CaseTEquiv(this);
    }
}

public sealed class TNotEquiv : Token
{
    public TNotEquiv(string text)
    {
        Text = text;
    }

    public TNotEquiv(string text, int line, int pos)
    {
        Text = text;
        Line = line;
        Pos = pos;
    }

    public override Object Clone()
    {
      return new TNotEquiv(Text, Line, Pos);
    }

    public override void Apply(Switch sw)
    {
        ((Analysis) sw).CaseTNotEquiv(this);
    }
}

public sealed class TGreater : Token
{
    public TGreater(string text)
    {
        Text = text;
    }

    public TGreater(string text, int line, int pos)
    {
        Text = text;
        Line = line;
        Pos = pos;
    }

    public override Object Clone()
    {
      return new TGreater(Text, Line, Pos);
    }

    public override void Apply(Switch sw)
    {
        ((Analysis) sw).CaseTGreater(this);
    }
}

public sealed class TGreatEqual : Token
{
    public TGreatEqual(string text)
    {
        Text = text;
    }

    public TGreatEqual(string text, int line, int pos)
    {
        Text = text;
        Line = line;
        Pos = pos;
    }

    public override Object Clone()
    {
      return new TGreatEqual(Text, Line, Pos);
    }

    public override void Apply(Switch sw)
    {
        ((Analysis) sw).CaseTGreatEqual(this);
    }
}

public sealed class TLess : Token
{
    public TLess(string text)
    {
        Text = text;
    }

    public TLess(string text, int line, int pos)
    {
        Text = text;
        Line = line;
        Pos = pos;
    }

    public override Object Clone()
    {
      return new TLess(Text, Line, Pos);
    }

    public override void Apply(Switch sw)
    {
        ((Analysis) sw).CaseTLess(this);
    }
}

public sealed class TLessEqual : Token
{
    public TLessEqual(string text)
    {
        Text = text;
    }

    public TLessEqual(string text, int line, int pos)
    {
        Text = text;
        Line = line;
        Pos = pos;
    }

    public override Object Clone()
    {
      return new TLessEqual(Text, Line, Pos);
    }

    public override void Apply(Switch sw)
    {
        ((Analysis) sw).CaseTLessEqual(this);
    }
}

public sealed class TSlash : Token
{
    public TSlash(string text)
    {
        Text = text;
    }

    public TSlash(string text, int line, int pos)
    {
        Text = text;
        Line = line;
        Pos = pos;
    }

    public override Object Clone()
    {
      return new TSlash(Text, Line, Pos);
    }

    public override void Apply(Switch sw)
    {
        ((Analysis) sw).CaseTSlash(this);
    }
}

public sealed class TOr : Token
{
    public TOr(string text)
    {
        Text = text;
    }

    public TOr(string text, int line, int pos)
    {
        Text = text;
        Line = line;
        Pos = pos;
    }

    public override Object Clone()
    {
      return new TOr(Text, Line, Pos);
    }

    public override void Apply(Switch sw)
    {
        ((Analysis) sw).CaseTOr(this);
    }
}

public sealed class TEnd : Token
{
    public TEnd(string text)
    {
        Text = text;
    }

    public TEnd(string text, int line, int pos)
    {
        Text = text;
        Line = line;
        Pos = pos;
    }

    public override Object Clone()
    {
      return new TEnd(Text, Line, Pos);
    }

    public override void Apply(Switch sw)
    {
        ((Analysis) sw).CaseTEnd(this);
    }
}

public sealed class TIncrement : Token
{
    public TIncrement(string text)
    {
        Text = text;
    }

    public TIncrement(string text, int line, int pos)
    {
        Text = text;
        Line = line;
        Pos = pos;
    }

    public override Object Clone()
    {
      return new TIncrement(Text, Line, Pos);
    }

    public override void Apply(Switch sw)
    {
        ((Analysis) sw).CaseTIncrement(this);
    }
}

public sealed class TDecrement : Token
{
    public TDecrement(string text)
    {
        Text = text;
    }

    public TDecrement(string text, int line, int pos)
    {
        Text = text;
        Line = line;
        Pos = pos;
    }

    public override Object Clone()
    {
      return new TDecrement(Text, Line, Pos);
    }

    public override void Apply(Switch sw)
    {
        ((Analysis) sw).CaseTDecrement(this);
    }
}

public sealed class TNot : Token
{
    public TNot(string text)
    {
        Text = text;
    }

    public TNot(string text, int line, int pos)
    {
        Text = text;
        Line = line;
        Pos = pos;
    }

    public override Object Clone()
    {
      return new TNot(Text, Line, Pos);
    }

    public override void Apply(Switch sw)
    {
        ((Analysis) sw).CaseTNot(this);
    }
}

public sealed class TComma : Token
{
    public TComma(string text)
    {
        Text = text;
    }

    public TComma(string text, int line, int pos)
    {
        Text = text;
        Line = line;
        Pos = pos;
    }

    public override Object Clone()
    {
      return new TComma(Text, Line, Pos);
    }

    public override void Apply(Switch sw)
    {
        ((Analysis) sw).CaseTComma(this);
    }
}

public sealed class TSingQuote : Token
{
    public TSingQuote(string text)
    {
        Text = text;
    }

    public TSingQuote(string text, int line, int pos)
    {
        Text = text;
        Line = line;
        Pos = pos;
    }

    public override Object Clone()
    {
      return new TSingQuote(Text, Line, Pos);
    }

    public override void Apply(Switch sw)
    {
        ((Analysis) sw).CaseTSingQuote(this);
    }
}

public sealed class TLeftBracket : Token
{
    public TLeftBracket(string text)
    {
        Text = text;
    }

    public TLeftBracket(string text, int line, int pos)
    {
        Text = text;
        Line = line;
        Pos = pos;
    }

    public override Object Clone()
    {
      return new TLeftBracket(Text, Line, Pos);
    }

    public override void Apply(Switch sw)
    {
        ((Analysis) sw).CaseTLeftBracket(this);
    }
}

public sealed class TRightBracket : Token
{
    public TRightBracket(string text)
    {
        Text = text;
    }

    public TRightBracket(string text, int line, int pos)
    {
        Text = text;
        Line = line;
        Pos = pos;
    }

    public override Object Clone()
    {
      return new TRightBracket(Text, Line, Pos);
    }

    public override void Apply(Switch sw)
    {
        ((Analysis) sw).CaseTRightBracket(this);
    }
}

public sealed class TOpenParent : Token
{
    public TOpenParent(string text)
    {
        Text = text;
    }

    public TOpenParent(string text, int line, int pos)
    {
        Text = text;
        Line = line;
        Pos = pos;
    }

    public override Object Clone()
    {
      return new TOpenParent(Text, Line, Pos);
    }

    public override void Apply(Switch sw)
    {
        ((Analysis) sw).CaseTOpenParent(this);
    }
}

public sealed class TCloseParent : Token
{
    public TCloseParent(string text)
    {
        Text = text;
    }

    public TCloseParent(string text, int line, int pos)
    {
        Text = text;
        Line = line;
        Pos = pos;
    }

    public override Object Clone()
    {
      return new TCloseParent(Text, Line, Pos);
    }

    public override void Apply(Switch sw)
    {
        ((Analysis) sw).CaseTCloseParent(this);
    }
}

public sealed class TDollar : Token
{
    public TDollar(string text)
    {
        Text = text;
    }

    public TDollar(string text, int line, int pos)
    {
        Text = text;
        Line = line;
        Pos = pos;
    }

    public override Object Clone()
    {
      return new TDollar(Text, Line, Pos);
    }

    public override void Apply(Switch sw)
    {
        ((Analysis) sw).CaseTDollar(this);
    }
}

public sealed class TId : Token
{
    public TId(string text)
    {
        Text = text;
    }

    public TId(string text, int line, int pos)
    {
        Text = text;
        Line = line;
        Pos = pos;
    }

    public override Object Clone()
    {
      return new TId(Text, Line, Pos);
    }

    public override void Apply(Switch sw)
    {
        ((Analysis) sw).CaseTId(this);
    }
}

public sealed class TComment : Token
{
    public TComment(string text)
    {
        Text = text;
    }

    public TComment(string text, int line, int pos)
    {
        Text = text;
        Line = line;
        Pos = pos;
    }

    public override Object Clone()
    {
      return new TComment(Text, Line, Pos);
    }

    public override void Apply(Switch sw)
    {
        ((Analysis) sw).CaseTComment(this);
    }
}

public sealed class TInteger : Token
{
    public TInteger(string text)
    {
        Text = text;
    }

    public TInteger(string text, int line, int pos)
    {
        Text = text;
        Line = line;
        Pos = pos;
    }

    public override Object Clone()
    {
      return new TInteger(Text, Line, Pos);
    }

    public override void Apply(Switch sw)
    {
        ((Analysis) sw).CaseTInteger(this);
    }
}

public sealed class TAnd : Token
{
    public TAnd(string text)
    {
        Text = text;
    }

    public TAnd(string text, int line, int pos)
    {
        Text = text;
        Line = line;
        Pos = pos;
    }

    public override Object Clone()
    {
      return new TAnd(Text, Line, Pos);
    }

    public override void Apply(Switch sw)
    {
        ((Analysis) sw).CaseTAnd(this);
    }
}

public sealed class TFloat : Token
{
    public TFloat(string text)
    {
        Text = text;
    }

    public TFloat(string text, int line, int pos)
    {
        Text = text;
        Line = line;
        Pos = pos;
    }

    public override Object Clone()
    {
      return new TFloat(Text, Line, Pos);
    }

    public override void Apply(Switch sw)
    {
        ((Analysis) sw).CaseTFloat(this);
    }
}

public sealed class TString : Token
{
    public TString(string text)
    {
        Text = text;
    }

    public TString(string text, int line, int pos)
    {
        Text = text;
        Line = line;
        Pos = pos;
    }

    public override Object Clone()
    {
      return new TString(Text, Line, Pos);
    }

    public override void Apply(Switch sw)
    {
        ((Analysis) sw).CaseTString(this);
    }
}

public sealed class TBlank : Token
{
    public TBlank(string text)
    {
        Text = text;
    }

    public TBlank(string text, int line, int pos)
    {
        Text = text;
        Line = line;
        Pos = pos;
    }

    public override Object Clone()
    {
      return new TBlank(Text, Line, Pos);
    }

    public override void Apply(Switch sw)
    {
        ((Analysis) sw).CaseTBlank(this);
    }
}


public abstract class Token : Node
{
    private string text;
    private int line;
    private int pos;

    public virtual string Text
    {
      get { return text; }
      set { text = value; }
    }

    public int Line
    {
      get { return line; }
      set { line = value; }
    }

    public int Pos
    {
      get { return pos; }
      set { pos = value; }
    }

    public override string ToString()
    {
        return text + " ";
    }

    internal override void RemoveChild(Node child)
    {
    }

    internal override void ReplaceChild(Node oldChild, Node newChild)
    {
    }
}

public sealed class EOF : Token
{
    public EOF()
    {
        Text = "";
    }

    public EOF(int line, int pos)
    {
        Text = "";
        Line = line;
        Pos = pos;
    }

    public override Object Clone()
    {
        return new EOF(Line, Pos);
    }

    public override void Apply(Switch sw)
    {
        ((Analysis) sw).CaseEOF(this);
    }
}
}
