using System;
using Core;
using ns0;
using XsdSettings;

// Token: 0x020006EF RID: 1775
public class ClassSelectView : BaseView
{
	// Token: 0x06002EED RID: 12013 RVA: 0x0001EEE4 File Offset: 0x0001D0E4
	public virtual void vmethod_5(ClassSelectView.ClassChangeEvent classChangeEvent_0)
	{
		this.descChangeCB = classChangeEvent_0;
	}

	// Token: 0x06002EEE RID: 12014 RVA: 0x0001EEED File Offset: 0x0001D0ED
	public virtual void vmethod_6(ClassSelectView.ClassChangeEvent classChangeEvent_0)
	{
		this.classChangeCB = classChangeEvent_0;
	}

	// Token: 0x06002EEF RID: 12015 RVA: 0x0001EEF6 File Offset: 0x0001D0F6
	public override void vmethod_3()
	{
		base.vmethod_3();
		this.classChangeCB = null;
		this.descChangeCB = null;
	}

	// Token: 0x06002EF0 RID: 12016 RVA: 0x000D9510 File Offset: 0x000D7710
	public virtual void vmethod_7(AvatarType avatarType_0, string string_0, string string_1, bool bool_0 = false)
	{
		DebugUtils.Log(LogCategory.GUI, string.Concat(new object[] { "UI Base: Class Select setInfo: classID=", avatarType_0, ", strTitle=", string_0, ", bFirstTime=", bool_0 }));
	}

	// Token: 0x06002EF1 RID: 12017 RVA: 0x0000311B File Offset: 0x0000131B
	public virtual void vmethod_8()
	{
	}

	// Token: 0x06002EF2 RID: 12018 RVA: 0x0000311B File Offset: 0x0000131B
	public virtual void vmethod_9(AvatarType avatarType_0)
	{
	}

	// Token: 0x06002EF3 RID: 12019 RVA: 0x0001D654 File Offset: 0x0001B854
	protected void method_3(string string_0, string string_1)
	{
		DebugUtils.Log(LogCategory.GUI, "\n Password:" + string_1);
	}

	// Token: 0x06002EF4 RID: 12020 RVA: 0x0001EF0C File Offset: 0x0001D10C
	protected void method_4()
	{
		DebugUtils.Log(LogCategory.GUI, " onPrevClick ");
		MonoSingleton<AppManager>.Instance.GetComponent<FrontEndStepManager>().method_3(FrontEndStepManager.StepState.CharacterSelect, null);
	}

	// Token: 0x06002EF5 RID: 12021 RVA: 0x0001EF2A File Offset: 0x0001D12A
	protected void method_5()
	{
		DebugUtils.Log(LogCategory.GUI, " onNextClick ");
		this._logicBehaviour.method_6();
	}

	// Token: 0x040020DA RID: 8410
	public ClassSelectBehaviour _logicBehaviour;

	// Token: 0x040020DB RID: 8411
	protected ClassSelectView.ClassChangeEvent classChangeCB;

	// Token: 0x040020DC RID: 8412
	protected ClassSelectView.ClassChangeEvent descChangeCB;

	// Token: 0x020006F0 RID: 1776
	// (Invoke) Token: 0x06002EF7 RID: 12023
	public delegate void ClassChangeEvent(AvatarType className);
}
