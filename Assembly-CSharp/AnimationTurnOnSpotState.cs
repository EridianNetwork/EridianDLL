using System;
using BHV;
using UnityEngine;

// Token: 0x02000078 RID: 120
public class AnimationTurnOnSpotState : AnimationManagerState
{
	// Token: 0x06000285 RID: 645 RVA: 0x00041078 File Offset: 0x0003F278
	public override void vmethod_0()
	{
		base.vmethod_0();
		this.m_finalFacing.y = 0f;
		this.m_AnimationManagerFSM.Animator_0.SetFloat("TurnAngle", this.method_4());
		this.m_AnimationManagerFSM.Animator_0.SetBool("bTurnOnSpot", true);
	}

	// Token: 0x06000286 RID: 646 RVA: 0x000410CC File Offset: 0x0003F2CC
	public override void vmethod_1()
	{
		float num = BHVTaskUtils.smethod_8(this.m_finalFacing, this.m_AnimationManagerFSM.transform.forward);
		if (num < 345f && num > 15f)
		{
			if (this.m_AnimationManagerFSM.Animator_0.GetFloat("TurnAngle") >= 345f || this.m_AnimationManagerFSM.Animator_0.GetFloat("TurnAngle") <= 15f)
			{
				this.m_AnimationManagerFSM.Animator_0.SetFloat("TurnAngle", this.method_4());
			}
		}
		else
		{
			base.m_status = AnimationStatus.SUCCESS;
			this.m_AnimationManagerFSM.Animator_0.SetBool("bTurnOnSpot", false);
			this.m_AnimationManagerFSM.Animator_0.SetFloat("TurnAngle", 0f);
		}
	}

	// Token: 0x06000287 RID: 647 RVA: 0x0000474D File Offset: 0x0000294D
	public override void vmethod_2()
	{
		base.vmethod_2();
		this.m_AnimationManagerFSM.Animator_0.SetBool("bTurnOnSpot", false);
		this.m_AnimationManagerFSM.Animator_0.SetFloat("TurnAngle", 0f);
	}

	// Token: 0x06000288 RID: 648 RVA: 0x00041194 File Offset: 0x0003F394
	private float method_4()
	{
		float num = 360f - BHVTaskUtils.smethod_8(this.m_finalFacing, this.m_AnimationManagerFSM.transform.forward);
		if (num < 345f && num > 15f)
		{
			if (num > 15f && num <= 60f)
			{
				num = 45f;
			}
			else if (num > 60f && num <= 100f)
			{
				num = 90f;
			}
			else if (num > 100f && num <= 180f)
			{
				num = 179f;
			}
			else if (num > 180f && num <= 260f)
			{
				num = 181f;
			}
			else if (num > 260f && num <= 300f)
			{
				num = 270f;
			}
			else if (num > 300f && num <= 345f)
			{
				num = 315f;
			}
		}
		else
		{
			num = 0f;
		}
		return num;
	}

	// Token: 0x04000260 RID: 608
	public Vector3 m_finalFacing;
}
