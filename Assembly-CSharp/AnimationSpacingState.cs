using System;
using UnityEngine;

// Token: 0x02000071 RID: 113
public class AnimationSpacingState : AnimationManagerState
{
	// Token: 0x06000261 RID: 609 RVA: 0x0000454F File Offset: 0x0000274F
	public AnimationSpacingState()
	{
		this.StateName = "Spacing";
		this.m_bInjured = false;
	}

	// Token: 0x06000262 RID: 610 RVA: 0x00004569 File Offset: 0x00002769
	public override void vmethod_0()
	{
		this.m_AnimationManagerFSM.Animator_0.SetBool("IsSpacing", true);
		this.m_AnimationManagerFSM.Animator_0.SetBool("bInjured", this.m_bInjured);
	}

	// Token: 0x06000263 RID: 611 RVA: 0x0000459C File Offset: 0x0000279C
	public override void vmethod_1()
	{
		this.m_turnAngle = this.m_AnimationManagerFSM.m_movementSync.m_turnAngle;
		this.m_AnimationManagerFSM.Animator_0.SetFloat("TurnAngle", this.m_turnAngle);
	}

	// Token: 0x06000264 RID: 612 RVA: 0x000045CF File Offset: 0x000027CF
	public override void vmethod_2()
	{
		base.vmethod_2();
		this.m_AnimationManagerFSM.Animator_0.SetBool("IsSpacing", false);
	}

	// Token: 0x06000265 RID: 613 RVA: 0x000045ED File Offset: 0x000027ED
	public void method_4(bool bool_1)
	{
		this.m_bInjured = bool_1;
	}

	// Token: 0x06000266 RID: 614 RVA: 0x000045F6 File Offset: 0x000027F6
	public void method_5(bool bool_1)
	{
		this.m_AnimationManagerFSM.Animator_0.SetBool("IsSpacing", bool_1);
	}

	// Token: 0x04000240 RID: 576
	public GameObject m_targetObj;

	// Token: 0x04000241 RID: 577
	private bool m_bInjured;

	// Token: 0x04000242 RID: 578
	public bool m_normalizeTurnAngle;
}
