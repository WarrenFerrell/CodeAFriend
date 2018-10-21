using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;

using Datatypes;

/// <summary>
/// 
/// </summary>
public class Python : undef // AND LanguageStrategy
//WARNING: C# does not support multiple inheritance but there is more than 1 superclass defined in your UML model!
, undef
{

  #region Aggregations


  #endregion

  #region Compositions


  #endregion

  #region Attributes

  /// <summary>
  /// 
  /// </summary>
  private IronPythonInterpreter Interpreter;



  #endregion


  #region undef members

  #endregion


  #region Public methods

  #endregion


  #region Protected methods

  #endregion


  #region Private methods

  #endregion


  #region LanguageStrategy members

  public override ScriptEvaluation Execute(string scriptBody, RuntimeParameters parameters)
  {
    throw new Exception("The method or operation is not implemented.");
  }

  #endregion


}

