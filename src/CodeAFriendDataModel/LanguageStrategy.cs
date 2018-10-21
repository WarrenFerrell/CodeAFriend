using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;


/// <summary>
/// 
/// </summary>
public abstract class LanguageStrategy
{

	#region Aggregations

	/// <summary>
	/// 
	/// (Array of RuntimeParameters)
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

	/// <summary>
	/// 
	/// </summary>
	public ScriptEvaluation UnnamedRoleB_2
	{
		get
		{
			return m_UnnamedRoleB_2;
		}
		set
		{
			m_UnnamedRoleB_2 = value;
		}
	}
	private ScriptEvaluation m_UnnamedRoleB_2;


	#endregion

	#region Compositions


	#endregion

	#region Attributes

	/// <summary>
	/// 
	/// </summary>
	private string Name;



	#endregion


	#region Public methods

	/// <summary>
	/// 
	/// </summary>
	/// <param name="scriptBody"></param>
	/// <param name="parameters"></param>
	/// <returns>ScriptEvaluation</returns>
	abstract public ScriptEvaluation Execute(string scriptBody, RuntimeParameters parameters);

	#endregion


	#region Protected methods

	#endregion


	#region Private methods

	#endregion


}

