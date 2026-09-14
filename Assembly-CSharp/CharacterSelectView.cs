using System;
using System.Collections.Generic;
using ns0;
using UnityEngine;

// Token: 0x020006AC RID: 1708
public class CharacterSelectView : BaseView
{
	// Token: 0x06002C8B RID: 11403 RVA: 0x0000311D File Offset: 0x0000131D
	public override bool vmethod_0()
	{
		return false;
	}

	// Token: 0x06002C8C RID: 11404 RVA: 0x000D1F58 File Offset: 0x000D0158
	public override void OnTestGUI()
	{
		string[] array = new string[this._data.Count];
		for (int i = 0; i < this._data.Count; i++)
		{
			array[i] = this._data[i].Name;
		}
		this.vmethod_11(GUI.SelectionGrid(new Rect(100f, 100f, 400f, 200f), 0, array, 1));
		if (GUI.Button(new Rect(140f, 470f, 100f, 25f), "Enter with " + this._data[this._currentSelect].Name))
		{
			this.vmethod_5(this._data[this._currentSelect].Id);
		}
	}

	// Token: 0x06002C8D RID: 11405 RVA: 0x0001D78C File Offset: 0x0001B98C
	public override void vmethod_3()
	{
		base.vmethod_3();
	}

	// Token: 0x06002C8E RID: 11406 RVA: 0x0001D794 File Offset: 0x0001B994
	public virtual void vmethod_5(int int_0)
	{
		this._logicBehaviour.vmethod_1(int_0);
	}

	// Token: 0x06002C8F RID: 11407 RVA: 0x0001D7A2 File Offset: 0x0001B9A2
	public virtual void vmethod_6(int int_0)
	{
		MonoSingleton<AppManager>.Instance.method_0().vmethod_5<HUDWarningView>().vmethod_7(LocalizedString.smethod_0(new LocalizedString("CharacterDel_Warning")), new Delegate_EventProc(this.OnConfirmDelete), new Delegate_EventProc(this.OnCancelDelete));
	}

	// Token: 0x06002C90 RID: 11408 RVA: 0x0001D7E1 File Offset: 0x0001B9E1
	protected virtual void OnConfirmDelete()
	{
		if (this._data == null)
		{
			return;
		}
		this.vmethod_7();
		this._logicBehaviour.method_4(this._data[this._currentSelect].Id);
	}

	// Token: 0x06002C91 RID: 11409 RVA: 0x0000311B File Offset: 0x0000131B
	protected virtual void OnCancelDelete()
	{
	}

	// Token: 0x06002C92 RID: 11410 RVA: 0x000D2024 File Offset: 0x000D0224
	public virtual void OnDeleteCharacter(bool success)
	{
		this.vmethod_8();
		if (success)
		{
			this._data.RemoveAt(this._currentSelect);
			this.vmethod_11(this._currentSelect);
			if (this._data.Count > 0)
			{
				this.vmethod_9(this._data[this._currentSelect].Id);
			}
			else
			{
				this.vmethod_9(-1);
			}
		}
	}

	// Token: 0x06002C93 RID: 11411 RVA: 0x0000311B File Offset: 0x0000131B
	public virtual void vmethod_7()
	{
	}

	// Token: 0x06002C94 RID: 11412 RVA: 0x0000311B File Offset: 0x0000131B
	public virtual void vmethod_8()
	{
	}

	// Token: 0x06002C95 RID: 11413 RVA: 0x0001D813 File Offset: 0x0001BA13
	public virtual void vmethod_9(int int_0)
	{
		this._logicBehaviour.method_5(int_0);
	}

	// Token: 0x06002C96 RID: 11414 RVA: 0x0001D821 File Offset: 0x0001BA21
	public virtual void vmethod_10(List<Character> list_0)
	{
		this._data = list_0;
	}

	// Token: 0x06002C97 RID: 11415 RVA: 0x0001D82A File Offset: 0x0001BA2A
	public virtual void vmethod_11(int int_0)
	{
		if (this._data == null)
		{
			return;
		}
		this._currentSelect = Math.Max(0, Math.Min(int_0, this._data.Count - 1));
	}

	// Token: 0x04001F64 RID: 8036
	protected List<Character> _data;

	// Token: 0x04001F65 RID: 8037
	protected int _currentSelect;

	// Token: 0x04001F66 RID: 8038
	public CharacterSelectBehaviour _logicBehaviour;
}
