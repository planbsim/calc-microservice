// CalcSem.cs                                              HDO, 2006-08-28
// -------------
// Semantic evaluator for table-driven top-down parsing.
// Generated by Coco-2 (PGT).
//=====================================|========================================

using System;
using System.Text;
using System.Net.Http;

using Lex = CalcLex;
using Syn = CalcSyn;
using WebCalculator.Calculation.Coco2;

public class CalcSem {


  public const String MODULENAME = "CalcSem";

  public static void CalcSemMethod(Utils.ModuleAction action, out String moduleName) {
  //-----------------------------------|----------------------------------------
    moduleName = MODULENAME;
    switch (action) {
      case Utils.ModuleAction.getModuleName:
        return;
      case Utils.ModuleAction.initModule:
        break;
      case Utils.ModuleAction.resetModule:
        break;
      case Utils.ModuleAction.cleanupModule:
        return;
    } // switch
  } // CalcSemMethod


    // *** start of global SYN and SEM declarations from ATG ***

    public static int LastCalcResult = 0;
    // addition
  public static int Add(int a, int b) {
        return Arithmetic.Addition(a, b);
  }
  
  // substraction
  public static int Sub(int a, int b) {
    return a - b;
  }
  
  // multiplication
  public static int Mult(int a, int b) {
    return a * b;
  }
  
  // division
  public static int Div(int a, int b) {
    return a / b;
  }

  // *** end of global SYN and SEM declarations from ATG ***

  

  private static void NT_Calc() {
    int e = 0;
    for (;;) {
      switch (Syn.Interpret()) {
        case 0:
          return;
        case 1:
          NT_Expr(out e);
          break;
        case 2: // SEM
          Console.WriteLine(e); LastCalcResult = e;
          break;
      } // switch
    } // for
  } // NT_Calc

  private static void NT_Expr(out int e) {
    int t = 0; e = 0;
    for (;;) {
      switch (Syn.Interpret()) {
        case 0:
          return;
        case 1:
          NT_Term(out e);
          break;
        case 2:
          NT_Term(out t);
          break;
        case 3: // SEM
          e = Add(e, t);
          break;
        case 4:
          NT_Term(out t);
          break;
        case 5: // SEM
          e = Sub(e, t);
          break;
      } // switch
    } // for
  } // NT_Expr

  private static void NT_Term(out int t) {
    int f = 0; t = 0;
    for (;;) {
      switch (Syn.Interpret()) {
        case 0:
          return;
        case 1:
          NT_Fact(out t);
          break;
        case 2:
          NT_Fact(out f);
          break;
        case 3: // SEM
          t = Mult(t, f);
          break;
        case 4:
          NT_Fact(out f);
          break;
        case 5: // SEM
          t = Div(t, f);
          break;
      } // switch
    } // for
  } // NT_Term

  private static void NT_Fact(out int f) {
    f = 0;
    for (;;) {
      switch (Syn.Interpret()) {
        case 0:
          return;
        case 1:
          Lex.GETnumberAttr(out f);
          break;
        case 2:
          NT_Expr(out f);
          break;
      } // switch
    } // for
  } // NT_Fact


  public delegate void PragmaMethod();
  public static PragmaMethod[] pragmaMethods = {
      // none
    };


  public static void StartSem() {
  //-----------------------------------|----------------------------------------
    for (;;) {
      switch (Syn.Interpret()) {
        case 0:
          return;
        case 1:
          NT_Calc();
          break;
      } // switch
    } // for
  } // StartSem

    
} // CalcSem

// End of CalcSem.cs
//=====================================|========================================
