using System;
using BHV;
using UnityEngine;

// Token: 0x02000058 RID: 88
public class AnimationFireState : AnimationManagerState
{
	// Token: 0x17000011 RID: 17
	// (get) Token: 0x060001EB RID: 491 RVA: 0x00003FEB File Offset: 0x000021EB
	// (set) Token: 0x060001EC RID: 492 RVA: 0x00003FF3 File Offset: 0x000021F3
	public float Single_0
	{
		get
		{
			return this.m_fireDuration;
		}
		set
		{
			this.m_fireDuration = value;
		}
	}

	// Token: 0x17000012 RID: 18
	// (get) Token: 0x060001ED RID: 493 RVA: 0x00003FFC File Offset: 0x000021FC
	// (set) Token: 0x060001EE RID: 494 RVA: 0x00004004 File Offset: 0x00002204
	public float Single_1
	{
		get
		{
			return this.m_fireIdleDuration;
		}
		set
		{
			this.m_fireIdleDuration = value;
		}
	}

	// Token: 0x060001EF RID: 495 RVA: 0x0003E7B4 File Offset: 0x0003C9B4
	public override void vmethod_0()
	{
		base.vmethod_0();
		this.m_AnimationManagerFSM.Animator_0.SetBool("IsFiring", true);
		this.m_fireTime = this.m_fireDuration;
		this.m_fireIdleTime = this.m_fireIdleDuration;
		this.m_firstShotPending = true;
		this.m_lastShotPending = false;
		if (this.m_fireTime < 0f)
		{
			this.m_fireTime = 3f;
		}
		if (this.m_fireIdleTime < 0f)
		{
			this.m_fireIdleTime = 1f;
		}
		base.m_status = AnimationStatus.PREPARE;
		this.m_animationEventController = this.m_AnimationManagerFSM.m_animationEventController;
		if (this.m_AnimationManagerFSM.m_isHumanoid)
		{
			this.m_AnimationManagerFSM.Animator_0.SetBool("IsCasual", false);
		}
		this.m_fireStep = EAnimationFireStep.FireShooting;
		if (this.m_AnimationManagerFSM.m_entity != null)
		{
			this.m_entityNPC = (EntityNpc)this.m_AnimationManagerFSM.m_entity;
		}
		if (this.m_entityNPC.m_subType == EntityNpc.EntitySubType.CHR_MidgetShotgunner)
		{
			int num = (int)global::UnityEngine.Random.Range(0f, 1.99f);
			this.m_AnimationManagerFSM.Animator_0.SetInteger("StanceMode", num);
		}
	}

	// Token: 0x060001F0 RID: 496 RVA: 0x0003E8D4 File Offset: 0x0003CAD4
	public override void vmethod_1()
	{
		if (!(this.m_AnimationManagerFSM == null) && !(this.m_AnimationManagerFSM.Animator_0 == null))
		{
			if (this.m_entityNPC.m_subType == EntityNpc.EntitySubType.CHR_BadassBanditKiller || this.m_entityNPC.m_subType == EntityNpc.EntitySubType.CHR_BanditKiller || this.m_entityNPC.m_subType == EntityNpc.EntitySubType.CHR_BanditRaider || this.m_entityNPC.m_subType == EntityNpc.EntitySubType.CHR_BanditScout)
			{
				int num = 0;
				bool flag = false;
				if (this.m_stance == BHVStance.STAND)
				{
					if (this.m_AnimationManagerFSM.Animator_0.GetCurrentAnimatorStateInfo(0).IsTag("CombatCrouchIdle"))
					{
						num = 0;
					}
					else
					{
						num = 2;
						flag = false;
					}
				}
				else if (this.m_stance == BHVStance.CROUCH)
				{
					if (this.m_AnimationManagerFSM.Animator_0.GetCurrentAnimatorStateInfo(0).IsTag("CombatStandIdle"))
					{
						num = 1;
					}
					else
					{
						num = 2;
						flag = true;
					}
				}
				this.m_AnimationManagerFSM.Animator_0.SetBool("IsCrouching", flag);
				this.m_AnimationManagerFSM.Animator_0.SetInteger("StanceMode", num);
			}
			if (this.m_fireStep == EAnimationFireStep.FireShooting)
			{
				base.m_status = AnimationStatus.RUNNING;
				if (this.m_fireTime <= 0f)
				{
					this.m_fireStep = EAnimationFireStep.FireIdle;
					this.m_firstShotPending = false;
					this.m_lastShotPending = true;
					if (this.m_animationEventController != null)
					{
						this.m_animationEventController.OnBanditShootStop();
					}
					this.m_AnimationManagerFSM.Animator_0.SetBool("IsFiring", false);
				}
				else
				{
					this.m_fireTime -= Time.deltaTime;
					if (this.m_animationEventController != null)
					{
					}
				}
			}
			else if (this.m_fireStep == EAnimationFireStep.FireIdle)
			{
				if (this.m_fireIdleTime <= 0f)
				{
					this.m_fireStep = EAnimationFireStep.FireFinish;
				}
				else
				{
					this.m_fireIdleTime -= Time.deltaTime;
				}
			}
			else if (this.m_fireStep == EAnimationFireStep.FireFinish)
			{
				base.m_status = AnimationStatus.SUCCESS;
			}
			return;
		}
	}

	// Token: 0x060001F1 RID: 497 RVA: 0x0003EAA4 File Offset: 0x0003CCA4
	public override void vmethod_2()
	{
		base.m_status = AnimationStatus.SUCCESS;
		this.m_firstShotPending = false;
		this.m_lastShotPending = false;
		base.vmethod_2();
		if (this.m_animationEventController != null)
		{
			this.m_animationEventController.OnBanditShootStop();
		}
		if (this.m_AnimationManagerFSM != null && this.m_AnimationManagerFSM.Animator_0 != null)
		{
			this.m_AnimationManagerFSM.Animator_0.SetBool("IsFiring", false);
		}
	}

	// Token: 0x040001C8 RID: 456
	protected const string FIRE_TAG = "Fire";

	// Token: 0x040001C9 RID: 457
	protected const string STAND_TAG = "CombatStandIdle";

	// Token: 0x040001CA RID: 458
	protected const string CROUCH_TAG = "CombatCrouchIdle";

	// Token: 0x040001CB RID: 459
	public AnimationEventController m_animationEventController;

	// Token: 0x040001CC RID: 460
	public EAnimationFireStep m_fireStep;

	// Token: 0x040001CD RID: 461
	public BHVStance m_stance = BHVStance.INVALID;

	// Token: 0x040001CE RID: 462
	protected EntityNpc m_entityNPC;

	// Token: 0x040001CF RID: 463
	public bool m_firstShotPending;

	// Token: 0x040001D0 RID: 464
	public bool m_lastShotPending;

	// Token: 0x040001D1 RID: 465
	protected float m_fireDuration;

	// Token: 0x040001D2 RID: 466
	protected float m_fireTime;

	// Token: 0x040001D3 RID: 467
	protected float m_fireIdleDuration;

	// Token: 0x040001D4 RID: 468
	protected float m_fireIdleTime;
}
