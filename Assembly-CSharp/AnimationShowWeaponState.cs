using System;
using UnityEngine;

// Token: 0x0200006F RID: 111
public class AnimationShowWeaponState : AnimationManagerState
{
	// Token: 0x0600025A RID: 602 RVA: 0x000044F9 File Offset: 0x000026F9
	public override void vmethod_0()
	{
		base.vmethod_0();
		this.m_showWeaponStarted = false;
	}

	// Token: 0x0600025B RID: 603 RVA: 0x00040728 File Offset: 0x0003E928
	public override void vmethod_1()
	{
		this.m_animatorInfo = this.m_AnimationManagerFSM.Animator_0.GetCurrentAnimatorStateInfo(0);
		if (this.m_showWeaponStarted)
		{
			if (base.method_1(this.m_animatorInfo, this.m_startTime, 0.5f))
			{
				this.m_AnimationManagerFSM.vmethod_11(false);
			}
			if (base.method_1(this.m_animatorInfo, this.m_startTime, 0.98f) || !this.m_animatorInfo.IsTag("ShowWeapon"))
			{
				this.m_AnimationManagerFSM.Animator_0.SetBool("bShowWeapon", false);
				base.m_status = AnimationStatus.SUCCESS;
			}
		}
		else
		{
			this.m_AnimationManagerFSM.Animator_0.SetBool("bShowWeapon", true);
			if (this.m_animatorInfo.IsTag("ShowWeapon"))
			{
				this.m_showWeaponStarted = true;
				this.m_startTime = this.m_animatorInfo.normalizedTime;
			}
		}
	}

	// Token: 0x0600025C RID: 604 RVA: 0x00004508 File Offset: 0x00002708
	public override void vmethod_2()
	{
		base.vmethod_2();
		this.m_AnimationManagerFSM.Animator_0.SetBool("bShowWeapon", false);
	}

	// Token: 0x0400023B RID: 571
	private const string SHOWWEAPON_TAG = "ShowWeapon";

	// Token: 0x0400023C RID: 572
	private const int SHOWWEAPON_LAYER = 0;

	// Token: 0x0400023D RID: 573
	public bool m_showWeaponStarted;

	// Token: 0x0400023E RID: 574
	private AnimatorStateInfo m_animatorInfo;

	// Token: 0x0400023F RID: 575
	private float m_startTime;
}
