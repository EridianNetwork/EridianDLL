using System;
using System.Collections.Generic;
using ns0;
using UnityEngine;
using XsdSettings;

// Token: 0x020006BB RID: 1723
public class NPCDialogView : BaseView
{
	// Token: 0x06002D5E RID: 11614 RVA: 0x000039EC File Offset: 0x00001BEC
	public override bool vmethod_0()
	{
		return true;
	}

	// Token: 0x06002D5F RID: 11615 RVA: 0x0001E186 File Offset: 0x0001C386
	public void method_3(bool bool_0)
	{
		this._bTestvisible = bool_0;
	}

	// Token: 0x06002D60 RID: 11616 RVA: 0x0001E18F File Offset: 0x0001C38F
	public override void vmethod_2()
	{
		base.vmethod_2();
		MonoSingleton<AppManager>.Instance.method_0().method_6(this);
		MonoSingleton<AppManager>.Instance.method_0().method_0(new GameUIManager.ViewUpdateCB(this.method_4), false);
	}

	// Token: 0x06002D61 RID: 11617 RVA: 0x0001E1C3 File Offset: 0x0001C3C3
	public override void vmethod_3()
	{
		base.vmethod_3();
		MonoSingleton<AppManager>.Instance.method_0().method_1(new GameUIManager.ViewUpdateCB(this.method_4));
		MonoSingleton<AppManager>.Instance.method_0().method_7(this);
	}

	// Token: 0x06002D62 RID: 11618 RVA: 0x0001E1F6 File Offset: 0x0001C3F6
	protected override void vmethod_1(bool bool_0, bool bool_1 = false)
	{
		base.vmethod_1(bool_0, bool_1);
	}

	// Token: 0x06002D63 RID: 11619 RVA: 0x0001E200 File Offset: 0x0001C400
	public override bool vmethod_4()
	{
		if (this.Boolean_1)
		{
			NPC_UIFlowController.smethod_0().method_3(NPC_UIFlowController.NPC_UIFlowState.FunctionList);
			return true;
		}
		return base.vmethod_4();
	}

	// Token: 0x06002D64 RID: 11620 RVA: 0x000D4A30 File Offset: 0x000D2C30
	protected void method_4()
	{
		if (!this._bVisible)
		{
			return;
		}
		if (MonoSingleton<InputManager>.Instance.method_12(0, false) || MonoSingleton<InputManager>.Instance.method_9("Jump"))
		{
			this._iOnShowStrIndex++;
			if (this._iOnShowStrIndex < this._strDialogList.Count)
			{
				this.vmethod_7();
			}
			else
			{
				NPC_UIFlowController.smethod_0().method_3(NPC_UIFlowController.NPC_UIFlowState.Quest);
			}
		}
	}

	// Token: 0x06002D65 RID: 11621 RVA: 0x0001E21D File Offset: 0x0001C41D
	public bool method_5()
	{
		return this._NPCSetting != null;
	}

	// Token: 0x06002D66 RID: 11622 RVA: 0x000D4A9C File Offset: 0x000D2C9C
	public virtual void vmethod_5(string string_0 = null)
	{
		this._strDialogList.Clear();
		this._iOnShowStrIndex = 0;
		if (string_0 == null && this._NPCSetting != null)
		{
			this._strDialogList.Add(this._NPCSetting.m_greetingsId);
		}
		else
		{
			this._strDialogList.Add(string_0);
		}
		this.vmethod_7();
	}

	// Token: 0x06002D67 RID: 11623 RVA: 0x0001E22B File Offset: 0x0001C42B
	public virtual void vmethod_6(string[] string_0)
	{
		this._iOnShowStrIndex = 0;
		this._strDialogList = new List<string>(string_0);
		this.vmethod_7();
	}

	// Token: 0x06002D68 RID: 11624 RVA: 0x0001E246 File Offset: 0x0001C446
	public void method_6(GameObject gameObject_0)
	{
		if (gameObject_0 != null)
		{
			this.m_dialogCamera = gameObject_0;
		}
	}

	// Token: 0x06002D69 RID: 11625 RVA: 0x0000311B File Offset: 0x0000131B
	protected virtual void vmethod_7()
	{
	}

	// Token: 0x04001FD9 RID: 8153
	protected bool _bTestvisible;

	// Token: 0x04001FDA RID: 8154
	protected global::XsdSettings.TownNpc _NPCSetting;

	// Token: 0x04001FDB RID: 8155
	protected int _iOnShowStrIndex = -1;

	// Token: 0x04001FDC RID: 8156
	protected List<string> _strDialogList = new List<string>();

	// Token: 0x04001FDD RID: 8157
	protected GameObject m_dialogCamera;
}
