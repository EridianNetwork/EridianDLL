using System;
using UnityEngine;

// Token: 0x02000072 RID: 114
public class AnimationSpawnState : AnimationManagerState
{
	// Token: 0x06000268 RID: 616 RVA: 0x000408EC File Offset: 0x0003EAEC
	public override void vmethod_0()
	{
		base.vmethod_0();
		this.m_AnimationManagerFSM.Animator_0.SetBool("IsSpawn", false);
		if (this.m_VFXManager)
		{
			this.m_VFXManager.method_4(ENPCParticleType.E_Spawn, 0f, true);
		}
		base.m_status = AnimationStatus.RUNNING;
	}

	// Token: 0x06000269 RID: 617 RVA: 0x0004093C File Offset: 0x0003EB3C
	public override void vmethod_1()
	{
		if (!(this.m_AnimationManagerFSM == null) && !(this.m_AnimationManagerFSM.Animator_0 == null))
		{
			this.m_animatorInfo = this.m_AnimationManagerFSM.Animator_0.GetCurrentAnimatorStateInfo(0);
			if (this.m_spawnStarted)
			{
				if (base.method_1(this.m_animatorInfo, this.m_startTime, 0.98f) || !this.m_animatorInfo.IsTag("Spawn"))
				{
					base.m_status = AnimationStatus.SUCCESS;
				}
			}
			else if (this.m_animatorInfo.IsTag("Spawn"))
			{
				this.m_spawnStarted = true;
				this.m_startTime = this.m_animatorInfo.normalizedTime;
				if (this.m_spawnDuration > 0f)
				{
					this.m_oldAnimatorSpeed = this.m_AnimationManagerFSM.Animator_0.speed;
					this.m_AnimationManagerFSM.Animator_0.speed = this.m_animatorInfo.length / this.m_spawnDuration;
				}
			}
			return;
		}
	}

	// Token: 0x0600026A RID: 618 RVA: 0x00040A34 File Offset: 0x0003EC34
	public override void vmethod_2()
	{
		base.vmethod_2();
		this.m_AnimationManagerFSM.Animator_0.SetBool("IsSpawn", true);
		if (this.m_VFXManager)
		{
			this.m_VFXManager.method_13(ENPCParticleType.E_Spawn);
		}
		if (this.m_AnimationManagerFSM.Transform_0 != null)
		{
			SkinnedMeshRenderer component = this.m_AnimationManagerFSM.Transform_0.GetComponent<SkinnedMeshRenderer>();
			if (component != null)
			{
				component.updateWhenOffscreen = true;
			}
		}
		if (this.m_spawnDuration > 0f)
		{
			this.m_AnimationManagerFSM.Animator_0.speed = this.m_oldAnimatorSpeed;
		}
	}

	// Token: 0x04000243 RID: 579
	private const string SPAWN_TAG = "Spawn";

	// Token: 0x04000244 RID: 580
	public bool m_spawnStarted;

	// Token: 0x04000245 RID: 581
	private AnimatorStateInfo m_animatorInfo;

	// Token: 0x04000246 RID: 582
	private float m_startTime;

	// Token: 0x04000247 RID: 583
	public float m_spawnDuration = -1f;

	// Token: 0x04000248 RID: 584
	private float m_oldAnimatorSpeed = 1f;
}
