using System;
using BHV;
using UnityEngine;

// Token: 0x02000020 RID: 32
public class BanditKillerAnimationManagerFSM : NPCAnimationManagerFSM
{
	// Token: 0x060000DB RID: 219 RVA: 0x00039A2C File Offset: 0x00037C2C
	public override void Start()
	{
		base.Start();
		this.m_movementSync = base.GetComponent<MovementSync>();
		this.m_isHumanoid = true;
		this.m_canUseFacingLogic = false;
		this.m_shotSoundType = global::UnityEngine.Random.Range(0f, 3f);
		this.m_animEventHandlerList.Add("MeleeHit", new AnimationManagerFSM.OnAnimEventHandler(base.OnMeleeHit));
		if (this.m_animEventHandlerList != null)
		{
			this.m_animEventHandlerList.Add("StartShoot", new AnimationManagerFSM.OnAnimEventHandler(this.OnStartShoot));
		}
	}

	// Token: 0x060000DC RID: 220 RVA: 0x0000381E File Offset: 0x00001A1E
	public override void Update()
	{
		base.Update();
		this.method_32();
		this.method_31();
	}

	// Token: 0x060000DD RID: 221 RVA: 0x00039AB0 File Offset: 0x00037CB0
	public void method_31()
	{
		if (base.Animator_0 != null && base.Animator_0.GetInteger("StanceMode") != 0 && (base.method_13(AnimationStateFSM.Alert) || base.method_13(AnimationStateFSM.Warning) || base.method_13(AnimationStateFSM.MeleeAttack) || base.method_13(AnimationStateFSM.Move) || base.method_13(AnimationStateFSM.Die)))
		{
			base.Animator_0.SetInteger("StanceMode", 0);
		}
	}

	// Token: 0x060000DE RID: 222 RVA: 0x00039B20 File Offset: 0x00037D20
	public void method_32()
	{
		if (this.m_animationEventController == null)
		{
			return;
		}
		if (!base.method_13(AnimationStateFSM.Fire) && !base.method_13(AnimationStateFSM.CoverFire) && (!base.method_13(AnimationStateFSM.Idle) || base.BHVStressLevel_0 != BHVStressLevel.COMBAT) && (!base.method_13(AnimationStateFSM.Move) || base.BHVStressLevel_0 != BHVStressLevel.COMBAT || base.Animator_0.GetFloat("fSprintMode") >= 0.5f) && !base.method_13(AnimationStateFSM.CoverIdleBeforeFire))
		{
			this.m_animationEventController.m_enableAimIK = false;
		}
		else
		{
			this.m_animationEventController.m_enableAimIK = true;
		}
	}

	// Token: 0x060000DF RID: 223 RVA: 0x000037E4 File Offset: 0x000019E4
	public override int vmethod_8(string string_0)
	{
		if (string_0.ToLower() == "hurtlight")
		{
			return 4;
		}
		return 0;
	}

	// Token: 0x060000E0 RID: 224 RVA: 0x00039BB0 File Offset: 0x00037DB0
	public void OnStartShoot()
	{
		if (this.m_entity == null)
		{
			return;
		}
		EntityWeapon weapon = this.m_entity.vmethod_10().m_weapon;
		if (weapon != null)
		{
			weapon.method_79();
			NPCAnimationManagerFSM.smethod_0(this.m_AudioCtl, NPCAnimationManagerFSM.NPCSMGShootType.Chain, this.m_shotSoundType, ref this.m_lastShotSoundTime);
		}
	}

	// Token: 0x0400010A RID: 266
	private const int UPPERBODY_LAYER = 1;

	// Token: 0x0400010B RID: 267
	private float m_lastShotSoundTime;

	// Token: 0x0400010C RID: 268
	private float m_shotSoundType;
}
