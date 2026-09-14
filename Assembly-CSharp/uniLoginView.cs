using System;
using Core;
using ns0;
using pumpkin.display;
using pumpkin.events;
using UnityEngine;

// Token: 0x020006AB RID: 1707
public class uniLoginView : LoginView
{
	// Token: 0x06002C7F RID: 11391 RVA: 0x0000311D File Offset: 0x0000131D
	public override bool vmethod_0()
	{
		return false;
	}

	// Token: 0x06002C80 RID: 11392 RVA: 0x000D1B58 File Offset: 0x000CFD58
	public override void OnTestGUI()
	{
		GUI.TextField(new Rect(500f, 600f, 280f, 25f), LocalizedString.smethod_0(this._testString));
		this._languageInput = GUI.TextField(new Rect(360f, 600f, 50f, 25f), this._languageInput, 5);
		if (GUI.Button(new Rect(200f, 600f, 150f, 25f), "Change Language:"))
		{
			LocalizeSystem.smethod_0().method_0(this._languageInput);
		}
	}

	// Token: 0x06002C81 RID: 11393 RVA: 0x0001D6A1 File Offset: 0x0001B8A1
	public override void vmethod_2()
	{
		base.vmethod_2();
		(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_45("Login.swf", "LoginView", new FuncLoad(this.method_6));
	}

	// Token: 0x06002C82 RID: 11394 RVA: 0x000D1BF0 File Offset: 0x000CFDF0
	private void method_6(MovieClip movieClip_0)
	{
		this._panel = new GClass51();
		DebugUtils.Log(LogCategory.GUI, "UI Base: Login view initializing!");
		this._panel.method_4(movieClip_0, "game_enabled", new GDelegate7(this.OnWidgetInitialized));
		(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_31(this._panel);
		MonoSingleton<AppManager>.Instance.method_0().method_0(new GameUIManager.ViewUpdateCB(this.method_9), false);
	}

	// Token: 0x06002C83 RID: 11395 RVA: 0x000D1C68 File Offset: 0x000CFE68
	protected bool OnWidgetInitialized(ref MovieClip movieClip, Type widgetType)
	{
		bool flag = false;
		string name = movieClip.name;
		if (!(name == "mcLoginBtn"))
		{
			if (!(name == "mcSignBtn"))
			{
				if (!(name == "mcNameInput"))
				{
					if (name == "mcPasswordInput")
					{
						this.mcPasswordInput = new GClass50();
						this.mcPasswordInput.method_0(movieClip);
						this.mcPasswordInput.Boolean_6 = true;
						this.mcPasswordInput.Boolean_1 = true;
						this.mcPasswordInput.String_0 = this._password;
						this.mcPasswordInput.Boolean_0 = true;
						flag = true;
					}
				}
				else
				{
					this.mcNameInput = new GClass50();
					this.mcNameInput.method_0(movieClip);
					this.mcNameInput.String_0 = this._name;
					this.mcNameInput.Boolean_2 = true;
					flag = true;
				}
			}
			else
			{
				this.mcSignBtn = new GClass25();
				this.mcSignBtn.method_0(movieClip);
				this.mcSignBtn.Boolean_6 = false;
				flag = true;
			}
		}
		else
		{
			this.mcLoginBtn = new GClass25();
			this.mcLoginBtn.method_0(movieClip);
			this.mcLoginBtn.addEventListener(MouseEvent.CLICK, new EventDispatcher.EventCallback(this.method_8));
			flag = true;
		}
		return flag;
	}

	// Token: 0x06002C84 RID: 11396 RVA: 0x0001D6D3 File Offset: 0x0001B8D3
	public override void vmethod_3()
	{
		(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_37(this._panel);
		this._panel = null;
		(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_48("Login.swf");
	}

	// Token: 0x06002C85 RID: 11397 RVA: 0x000D1DB0 File Offset: 0x000CFFB0
	public override void vmethod_5(bool bool_0)
	{
		base.vmethod_5(bool_0);
		if (this.mcLoginBtn != null)
		{
			this.mcLoginBtn.Boolean_6 = bool_0;
		}
		if (this.mcSignBtn != null)
		{
			this.mcSignBtn.Boolean_6 = bool_0;
		}
		if (this.mcNameInput != null)
		{
			this.mcNameInput.Boolean_6 = bool_0;
		}
		if (this.mcPasswordInput != null)
		{
			this.mcPasswordInput.Boolean_6 = bool_0;
		}
	}

	// Token: 0x06002C86 RID: 11398 RVA: 0x0001D70F File Offset: 0x0001B90F
	public override void vmethod_6(string string_0, string string_1)
	{
		base.vmethod_6(string_0, string_1);
		if (this.mcNameInput != null)
		{
			this.mcNameInput.String_0 = this._name;
		}
		if (this.mcPasswordInput != null)
		{
			this.mcPasswordInput.String_0 = this._password;
		}
	}

	// Token: 0x06002C87 RID: 11399 RVA: 0x0001D74B File Offset: 0x0001B94B
	protected void method_7(CEvent cevent_0)
	{
		DebugUtils.Log(LogCategory.GUI, "\n Password:" + this.mcPasswordInput.String_0);
		base.method_3(this.mcNameInput.String_0, this.mcPasswordInput.String_0);
	}

	// Token: 0x06002C88 RID: 11400 RVA: 0x000D1E14 File Offset: 0x000D0014
	protected void method_8(CEvent cevent_0)
	{
		if (base.method_5(this.mcNameInput.String_0, this.mcPasswordInput.String_0))
		{
			MonoSingleton<AppManager>.Instance.method_0().method_1(new GameUIManager.ViewUpdateCB(this.method_9));
			base.method_4(this.mcNameInput.String_0, this.mcPasswordInput.String_0);
		}
	}

	// Token: 0x06002C89 RID: 11401 RVA: 0x000D1E78 File Offset: 0x000D0078
	protected void method_9()
	{
		if (Input.GetKeyDown(KeyCode.Tab) && this.mcNameInput != null)
		{
			if (this.mcNameInput.method_10())
			{
				if (this.mcPasswordInput != null)
				{
					this.mcNameInput.Boolean_2 = false;
					this.mcPasswordInput.Boolean_2 = true;
				}
			}
			else
			{
				this.mcPasswordInput.Boolean_2 = false;
				this.mcNameInput.Boolean_2 = true;
			}
		}
		if ((Input.GetKey(KeyCode.KeypadEnter) || Input.GetKey(KeyCode.Return)) && this.mcNameInput != null && this.mcPasswordInput != null && base.method_5(this.mcNameInput.String_0, this.mcPasswordInput.String_0))
		{
			MonoSingleton<AppManager>.Instance.method_0().method_1(new GameUIManager.ViewUpdateCB(this.method_9));
			base.method_4(this.mcNameInput.String_0, this.mcPasswordInput.String_0);
		}
	}

	// Token: 0x04001F5C RID: 8028
	private readonly LocalizedString _testString = new LocalizedString("Test String");

	// Token: 0x04001F5D RID: 8029
	private string _languageInput = string.Empty;

	// Token: 0x04001F5E RID: 8030
	private GClass51 _panel;

	// Token: 0x04001F5F RID: 8031
	private GClass25 mcLoginBtn;

	// Token: 0x04001F60 RID: 8032
	private GClass25 mcSignBtn;

	// Token: 0x04001F61 RID: 8033
	private GClass50 mcNameInput;

	// Token: 0x04001F62 RID: 8034
	private GClass50 mcPasswordInput;
}
