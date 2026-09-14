using System;
using System.Collections.Generic;
using Core;
using ns0;
using XsdSettings;

// Token: 0x020006B2 RID: 1714
public class ClassCustomView : BaseView
{
	// Token: 0x06002D19 RID: 11545 RVA: 0x0001DF17 File Offset: 0x0001C117
	public override void vmethod_2()
	{
		base.vmethod_2();
	}

	// Token: 0x06002D1A RID: 11546 RVA: 0x000D4218 File Offset: 0x000D2418
	public virtual void vmethod_5()
	{
		ItemGeneratorService component = MonoSingleton<AppManager>.Instance.GetComponent<ItemGeneratorService>();
		AvatarType avatarType_ = MonoSingleton<AppManager>.Instance.GetComponent<FrontEndStepManager>().AvatarType_0;
		for (int i = 0; i < 5; i++)
		{
			List<BuildingPart> list = component.method_8(avatarType_, this.stylePartMap[i]);
			this._FeatureList.Add(list);
		}
	}

	// Token: 0x06002D1B RID: 11547 RVA: 0x0000311B File Offset: 0x0000131B
	public virtual void vmethod_6(AsyncTaskStatus genum0_0)
	{
	}

	// Token: 0x06002D1C RID: 11548 RVA: 0x0000311B File Offset: 0x0000131B
	public virtual void vmethod_7()
	{
	}

	// Token: 0x06002D1D RID: 11549 RVA: 0x0001DF1F File Offset: 0x0001C11F
	public override void vmethod_3()
	{
		this._FeatureList.Clear();
	}

	// Token: 0x06002D1E RID: 11550 RVA: 0x0001DF2C File Offset: 0x0001C12C
	protected void method_3()
	{
		this._logicBehaviour.method_4(3);
		DebugUtils.Log(LogCategory.GUI, " onPrevClick ");
		MonoSingleton<AppManager>.Instance.GetComponent<FrontEndStepManager>().method_3(FrontEndStepManager.StepState.ClassSelect, null);
	}

	// Token: 0x06002D1F RID: 11551 RVA: 0x0001DF56 File Offset: 0x0001C156
	protected void method_4()
	{
		DebugUtils.Log(LogCategory.GUI, " onNextClick ");
		this._logicBehaviour.method_7(this._name);
		this._logicBehaviour.method_8();
	}

	// Token: 0x06002D20 RID: 11552 RVA: 0x000D4268 File Offset: 0x000D2468
	protected void method_5(int int_0, int int_1, bool bool_0 = true)
	{
		if (this._FeatureList[int_0].Count > 0)
		{
			if (int_0 < 2)
			{
				this._logicBehaviour.method_5((byte)int_0, this._FeatureList[int_0][int_1].mFBX, bool_0);
			}
			else
			{
				this._logicBehaviour.method_5((byte)int_0, this._FeatureList[int_0][int_1].mMat, bool_0);
			}
		}
		else
		{
			this._logicBehaviour.method_5((byte)int_0, 0, bool_0);
		}
		this._logicBehaviour.method_6(this.animationName[int_0]);
	}

	// Token: 0x06002D21 RID: 11553 RVA: 0x0001DF7F File Offset: 0x0001C17F
	public int method_6(int int_0)
	{
		if (this._FeatureList.Count > 0)
		{
			return this._FeatureList[int_0].Count;
		}
		return 0;
	}

	// Token: 0x06002D22 RID: 11554 RVA: 0x0001DFA2 File Offset: 0x0001C1A2
	public string method_7(int int_0, int int_1)
	{
		return LocalizedString.smethod_0(this.styleName[int_0]) + (int_1 + 1);
	}

	// Token: 0x06002D23 RID: 11555 RVA: 0x000D4300 File Offset: 0x000D2500
	public void method_8(bool bool_0 = false)
	{
		if (bool_0)
		{
			this._bCursorInCheckRect = false;
			this._bRotateEnable = false;
		}
		GameUIManager.CursorManager.CursorType cursorType = GameUIManager.CursorManager.CursorType.DefaultCursor;
		if (this._bRotateEnable)
		{
			cursorType = GameUIManager.CursorManager.CursorType.HandClosed;
		}
		else if (this._bCursorInCheckRect)
		{
			cursorType = GameUIManager.CursorManager.CursorType.HandSelected;
		}
		MonoSingleton<AppManager>.Instance.method_0().vmethod_26(cursorType);
	}

	// Token: 0x04001FB2 RID: 8114
	public const int STYLE_NUM = 5;

	// Token: 0x04001FB3 RID: 8115
	public DNACreateBehaviour _logicBehaviour;

	// Token: 0x04001FB4 RID: 8116
	private List<List<BuildingPart>> _FeatureList = new List<List<BuildingPart>>();

	// Token: 0x04001FB5 RID: 8117
	private AvatarSubPart[] stylePartMap = new AvatarSubPart[]
	{
		AvatarSubPart.HAIR,
		AvatarSubPart.HEAD,
		AvatarSubPart.BODY,
		AvatarSubPart.PANTS,
		AvatarSubPart.SHOE
	};

	// Token: 0x04001FB6 RID: 8118
	private LocalizedString[] styleName = new LocalizedString[]
	{
		new LocalizedString("Hair"),
		new LocalizedString("Face"),
		new LocalizedString("Coat"),
		new LocalizedString("Pants"),
		new LocalizedString("Boots")
	};

	// Token: 0x04001FB7 RID: 8119
	private string[] animationName = new string[] { "stand_changehead", "stand_changehead", "stand_changebody", "stand_changebody", "stand_changebody" };

	// Token: 0x04001FB8 RID: 8120
	protected string _name = string.Empty;

	// Token: 0x04001FB9 RID: 8121
	protected bool _bRotateEnable;

	// Token: 0x04001FBA RID: 8122
	protected bool _bCursorInCheckRect;
}
