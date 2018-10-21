using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;


/// <summary>
/// 
/// </summary>
public class User
{

  #region Aggregations

  /// <summary>
  /// 
  /// (Array of Script)
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

  #region Compositions


  #endregion

  #region Attributes

  /// <summary>
  /// 
  /// </summary>
  private UserScript[ * ] Scripts;


  /// <summary>
  /// 
  /// </summary>
  private string username;



  #endregion


  #region Public methods

  #endregion


  #region Protected methods

  #endregion


  #region Private methods

  #endregion


}

