using System;
using Core;
using UnityEngine;

// Token: 0x020006AA RID: 1706
public class LoginView : BaseView
{
	// Token: 0x06002C77 RID: 11383 RVA: 0x0000311D File Offset: 0x0000131D
	public override bool vmethod_0()
	{
		return false;
	}

	// Token: 0x06002C78 RID: 11384 RVA: 0x000D1A00 File Offset: 0x000CFC00
	public override void OnTestGUI()
	{
		GUI.TextField(new Rect(100f, 100f, 80f, 25f), "Name:");
		GUI.TextField(new Rect(100f, 130f, 80f, 25f), "Password:");
		this._testName = GUI.TextField(new Rect(185f, 100f, 145f, 25f), this._testName, 20);
		this._testPassword = GUI.PasswordField(new Rect(185f, 130f, 145f, 25f), this._testPassword, "*"[0], 20);
		if (GUI.Button(new Rect(140f, 170f, 100f, 25f), "Login"))
		{
			this.method_4(this._testName, this._testPassword);
		}
	}

	// Token: 0x06002C79 RID: 11385 RVA: 0x0001D627 File Offset: 0x0001B827
	public virtual void vmethod_5(bool bool_0)
	{
		if (!bool_0)
		{
			DebugUtils.Log(LogCategory.GUI, "UI Base: Ooooooooops... system is busy!");
		}
		else
		{
			DebugUtils.Log(LogCategory.GUI, "UI Base: OK you can do anything!");
		}
	}

	// Token: 0x06002C7A RID: 11386 RVA: 0x0001D644 File Offset: 0x0001B844
	public virtual void vmethod_6(string string_0, string string_1)
	{
		this._name = string_0;
		this._password = string_1;
	}

	// Token: 0x06002C7B RID: 11387 RVA: 0x0001D654 File Offset: 0x0001B854
	protected void method_3(string string_0, string string_1)
	{
		DebugUtils.Log(LogCategory.GUI, "\n Password:" + string_1);
	}

	// Token: 0x06002C7C RID: 11388 RVA: 0x000D1AF0 File Offset: 0x000CFCF0
	protected void method_4(string string_0, string string_1)
	{
		this._name = string_0;
		this._password = string_1;
		if (string.IsNullOrEmpty(this._name))
		{
			DebugUtils.Log(LogCategory.GUI, "------No Name is here!!!!!------");
		}
		else if (string.IsNullOrEmpty(this._password))
		{
			DebugUtils.Log(LogCategory.GUI, "------No Password is here!!!!!------");
		}
		else
		{
			this._logicBehaviour.method_4(this._name, this._password);
		}
	}

	// Token: 0x06002C7D RID: 11389 RVA: 0x0001D667 File Offset: 0x0001B867
	protected bool method_5(string string_0, string string_1)
	{
		return !string.IsNullOrEmpty(string_0) && !string.IsNullOrEmpty(string_1);
	}

	// Token: 0x04001F57 RID: 8023
	private string _testName = string.Empty;

	// Token: 0x04001F58 RID: 8024
	private string _testPassword = string.Empty;

	// Token: 0x04001F59 RID: 8025
	public LoginBehaviour _logicBehaviour;

	// Token: 0x04001F5A RID: 8026
	protected string _name = string.Empty;

	// Token: 0x04001F5B RID: 8027
	protected string _password = string.Empty;
}
