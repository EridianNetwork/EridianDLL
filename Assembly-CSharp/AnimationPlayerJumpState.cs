using System;
using UnityEngine;

// Token: 0x020000AF RID: 175
public class AnimationPlayerJumpState : PlayerAnimationState
{
	// Token: 0x06000420 RID: 1056 RVA: 0x00005B8A File Offset: 0x00003D8A
	public AnimationPlayerJumpState()
	{
		this.StateName = "PlayerJump";
	}

	// Token: 0x17000021 RID: 33
	// (get) Token: 0x06000421 RID: 1057 RVA: 0x00005BB3 File Offset: 0x00003DB3
	// (set) Token: 0x06000422 RID: 1058 RVA: 0x00005BBB File Offset: 0x00003DBB
	public EAnimationJumpStep EAnimationJumpStep_0
	{
		get
		{
			return this.m_animationJumpStep;
		}
		set
		{
			this.m_animationJumpStep = value;
			if (this.m_animationJumpStep == EAnimationJumpStep.JumpLand)
			{
				this.m_jumpLandStartTime = Time.time;
			}
		}
	}

	// Token: 0x06000423 RID: 1059 RVA: 0x00005BD8 File Offset: 0x00003DD8
	public override void vmethod_0()
	{
		base.vmethod_0();
		this.method_25();
	}

	// Token: 0x06000424 RID: 1060 RVA: 0x00049CE8 File Offset: 0x00047EE8
	public void method_22()
	{
		this.m_animatorInfo = base.method_15(true, 0);
		if (this.EAnimationJumpStep_0 == EAnimationJumpStep.JumpNull)
		{
			return;
		}
		if (this.EAnimationJumpStep_0 == EAnimationJumpStep.JumpPre)
		{
			if (this.method_23())
			{
				if (this.m_jumpStartedFirst)
				{
					if (this.m_animatorInfo.IsTag("JumpStart") && Time.time - this.m_startTime > this.m_jumpStartAnimDuration * 0.97f)
					{
					}
				}
				else if (this.m_animatorInfo.IsTag("JumpStart"))
				{
					this.m_jumpStartedFirst = true;
				}
			}
		}
		else if (this.EAnimationJumpStep_0 != EAnimationJumpStep.JumpLoop)
		{
			if (this.EAnimationJumpStep_0 == EAnimationJumpStep.JumpLand)
			{
				base.method_7(MecanimAnimationID.ID_1st_JumpLand);
			}
			else if (this.EAnimationJumpStep_0 == EAnimationJumpStep.JumpFinish)
			{
				base.m_status = AnimationStatus.SUCCESS;
			}
		}
	}

	// Token: 0x06000425 RID: 1061 RVA: 0x00049D9C File Offset: 0x00047F9C
	public bool method_23()
	{
		return (!this.m_AnimationManagerFSM.method_13(AnimationStateFSM.PlayerSwitchDown) || this.m_AnimationManagerFSM.method_16("PlayerSwitchDown").m_status != AnimationStatus.RUNNING) && (!this.m_AnimationManagerFSM.method_13(AnimationStateFSM.PlayerSwitchUp) || this.m_AnimationManagerFSM.method_16("PlayerSwitchUp").m_status != AnimationStatus.RUNNING) && (!this.m_AnimationManagerFSM.method_13(AnimationStateFSM.PlayerReload) || this.m_AnimationManagerFSM.method_16("PlayerReload").m_status != AnimationStatus.RUNNING) && (!this.m_AnimationManagerFSM.method_13(AnimationStateFSM.PlayerPickupWeapon) || this.m_AnimationManagerFSM.method_16("PlayerPickupWeapon").m_status != AnimationStatus.RUNNING);
	}

	// Token: 0x06000426 RID: 1062 RVA: 0x00049E50 File Offset: 0x00048050
	public void method_24()
	{
		this.m_animatorInfo = base.method_15(false, 0);
		if (this.EAnimationJumpStep_0 == EAnimationJumpStep.JumpNull)
		{
			return;
		}
		if (this.EAnimationJumpStep_0 == EAnimationJumpStep.JumpPre)
		{
			if (this.m_jumpStartedThird)
			{
				if (Time.time - this.m_startTime > this.m_jumpStartAnimDuration * 0.9f)
				{
					if (base.Boolean_0)
					{
						base.method_7(MecanimAnimationID.ID_1st_JumpStart);
					}
					base.method_16("bJumpStart", false);
					this.EAnimationJumpStep_0 = EAnimationJumpStep.JumpLoop;
				}
			}
			else
			{
				if (base.Boolean_0)
				{
					base.method_7(MecanimAnimationID.ID_1st_JumpStart);
				}
				base.method_16("bJumpStart", true);
				if (this.m_animatorInfo.IsTag("JumpIdle"))
				{
					this.m_jumpStartedThird = true;
				}
			}
		}
		else if (this.EAnimationJumpStep_0 != EAnimationJumpStep.JumpLoop)
		{
			if (this.EAnimationJumpStep_0 == EAnimationJumpStep.JumpLand)
			{
				if (this.m_jumpLandStartedThird)
				{
					if (Time.time - this.m_jumpLandStartTime > this.m_jumpLandAnimDuration * 0.9f)
					{
						this.EAnimationJumpStep_0 = EAnimationJumpStep.JumpFinish;
					}
				}
				else
				{
					if (base.Boolean_0)
					{
						base.method_8(MecanimAnimationID.ID_1st_JumpStart);
						base.method_7(MecanimAnimationID.ID_1st_JumpLand);
					}
					base.method_16("bJumpStart", false);
					base.method_16("bJumpLand", true);
					if (!this.m_animatorInfo.IsTag("JumpIdle"))
					{
						this.m_jumpLandStartedThird = true;
						if (base.Boolean_0)
						{
							base.method_8(MecanimAnimationID.ID_1st_JumpLand);
						}
						base.method_16("bJumpLand", false);
					}
				}
			}
			else if (this.EAnimationJumpStep_0 == EAnimationJumpStep.JumpFinish)
			{
				base.m_status = AnimationStatus.SUCCESS;
				if (base.Boolean_0)
				{
					base.method_8(MecanimAnimationID.ID_1st_JumpStart);
					base.method_8(MecanimAnimationID.ID_1st_JumpLand);
				}
				base.method_16("bJumpStart", false);
				base.method_16("bJumpLand", false);
			}
		}
	}

	// Token: 0x06000427 RID: 1063 RVA: 0x00049FFC File Offset: 0x000481FC
	public void method_25()
	{
		this.m_jumpStartedFirst = false;
		this.m_jumpStartedThird = false;
		this.m_jumpLandStartedFirst = false;
		this.m_jumpLandStartedThird = false;
		if (base.Boolean_0)
		{
			base.method_7(MecanimAnimationID.ID_1st_JumpStart);
			base.method_8(MecanimAnimationID.ID_1st_JumpLand);
		}
		base.method_16("bJumpStart", true);
		base.method_16("bJumpLand", false);
		this.m_startTime = Time.time;
		this.EAnimationJumpStep_0 = EAnimationJumpStep.JumpPre;
		base.m_status = AnimationStatus.RUNNING;
	}

	// Token: 0x06000428 RID: 1064 RVA: 0x00005BE6 File Offset: 0x00003DE6
	public bool method_26()
	{
		return this.EAnimationJumpStep_0 == EAnimationJumpStep.JumpFinish || this.EAnimationJumpStep_0 == EAnimationJumpStep.JumpLand || this.EAnimationJumpStep_0 == EAnimationJumpStep.JumpNull;
	}

	// Token: 0x06000429 RID: 1065 RVA: 0x00005C05 File Offset: 0x00003E05
	public override void vmethod_1()
	{
		if (base.Boolean_0)
		{
			this.method_22();
		}
		this.method_24();
	}

	// Token: 0x0600042A RID: 1066 RVA: 0x0004A070 File Offset: 0x00048270
	public override void vmethod_2()
	{
		BaseEventTriggerCtl componentInChildren = this.m_AnimationManagerFSM.m_animationHost.GetComponentInChildren<BaseEventTriggerCtl>();
		if (componentInChildren != null)
		{
			if (base.Boolean_0)
			{
				componentInChildren.vmethod_1(AudioEventName.Chr_Land_Rnd);
			}
			componentInChildren.vmethod_1(AudioEventName.Chr_Shr_Foley_Run_Rnd);
			componentInChildren.vmethod_1(AudioEventName.Chr_Shr_FootStep_Run);
		}
		base.vmethod_2();
		base.m_status = AnimationStatus.SUCCESS;
		if (base.Boolean_0)
		{
			base.method_8(MecanimAnimationID.ID_1st_JumpStart);
			base.method_7(MecanimAnimationID.ID_1st_JumpLand);
		}
		base.method_16("bJumpStart", false);
		base.method_16("bJumpLand", true);
	}

	// Token: 0x040003F5 RID: 1013
	private const string JUMPSTART_TAG = "JumpStart";

	// Token: 0x040003F6 RID: 1014
	private const string JUMPIDLE_TAG = "JumpIdle";

	// Token: 0x040003F7 RID: 1015
	private const string JUMPLAND_TAG = "JumpLand";

	// Token: 0x040003F8 RID: 1016
	public bool m_jumpStartedFirst;

	// Token: 0x040003F9 RID: 1017
	public bool m_jumpStartedThird;

	// Token: 0x040003FA RID: 1018
	public bool m_jumpLandStartedFirst;

	// Token: 0x040003FB RID: 1019
	public bool m_jumpLandStartedThird;

	// Token: 0x040003FC RID: 1020
	private float m_startTime;

	// Token: 0x040003FD RID: 1021
	private EAnimationJumpStep m_animationJumpStep;

	// Token: 0x040003FE RID: 1022
	private float m_jumpStartAnimDuration = 0.2f;

	// Token: 0x040003FF RID: 1023
	private float m_jumpLandAnimDuration = 0.3f;

	// Token: 0x04000400 RID: 1024
	private float m_jumpLandStartTime;
}
