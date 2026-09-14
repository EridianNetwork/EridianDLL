using System;

// Token: 0x02000056 RID: 86
public class AnimationEmptyState : AnimationManagerState
{
	// Token: 0x060001E1 RID: 481 RVA: 0x00003F57 File Offset: 0x00002157
	public AnimationEmptyState()
	{
		this.StateName = "Empty";
	}

	// Token: 0x060001E2 RID: 482 RVA: 0x00003F6A File Offset: 0x0000216A
	public override void vmethod_0()
	{
		this.ElapsedTime = 0f;
		base.vmethod_0();
		base.m_status = AnimationStatus.RUNNING;
	}

	// Token: 0x060001E3 RID: 483 RVA: 0x00003F84 File Offset: 0x00002184
	public override void vmethod_1()
	{
		base.m_status = AnimationStatus.SUCCESS;
	}

	// Token: 0x060001E4 RID: 484 RVA: 0x00003DB3 File Offset: 0x00001FB3
	public override void vmethod_2()
	{
		base.vmethod_2();
		base.m_status = AnimationStatus.SUCCESS;
	}
}
