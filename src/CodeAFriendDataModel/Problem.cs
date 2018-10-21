using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;


/// <summary>
/// 
/// </summary>
public class Problem
{

  #region Aggregations


  #endregion

  #region Compositions

  /// <summary>
  /// 
  /// (Array of TestCase)
  /// </summary>
  public ArrayList UnnamedRoleB_1
  {
    get
    {
      return m_UnnamedRoleB_1;
    }
    set
    {
      m_UnnamedRoleB_1 = value;
    }
  }
  private ArrayList m_UnnamedRoleB_1;


  #endregion

  #region Attributes

  /// <summary>
  /// 
  /// </summary>
  private string Description;


  /// <summary>
  /// 
  /// </summary>
  private TestCase[ * ] TestCases;


  /// <summary>
  /// 
  /// </summary>
  private string Name;


  /// <summary>
  /// 
  /// </summary>
  private Solution[ * ] Solutions;


  /// <summary>
  /// 
  /// </summary>
  private string[ * ] Tags;



  #endregion


  #region Public methods

  /// <summary>
  /// 
  /// </summary>
  /// <param name="script"></param>
  /// <returns>bool</returns>
  public bool TestScript(UserScript script)
  {
    throw new Exception("The method or operation is not implemented.");
  }

  #endregion


  #region Protected methods

  #endregion


  #region Private methods

  #endregion


}

