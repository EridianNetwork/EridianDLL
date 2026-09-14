using System;
using BHV;

// Token: 0x02000026 RID: 38
public class CrimsonLanceAssassinAnimationManagerFSM : NPCAnimationManagerFSM
{
	// Token: 0x06000103 RID: 259 RVA: 0x0003A708 File Offset: 0x00038908
	public override void Start()
	{
		base.Start();
		this.m_movementSync = base.GetComponent<MovementSync>();
		this.m_isHumanoid = true;
		this.m_canUseFacingLogic = false;
		this.m_deathLayer = 2;
		this.m_meleeAttackSetting = base.GetComponent<BHVTaskManager>().vmethod_0<BHVMeleeAttackSettings>();
		this.m_animEventHandlerList.Add("ThrowWeapon", new AnimationManagerFSM.OnAnimEventHandler(base.OnThrowWeapon));
		this.m_animEventHandlerList.Add("MeleeSlashHit", new AnimationManagerFSM.OnAnimEventHandler(this.OnMeleeSlashHit));
		this.m_animEventHandlerList.Add("KickHit", new AnimationManagerFSM.OnAnimEventHandler(this.OnKickHit));
		this.m_animEventHandlerList.Add("LeftSwordSlash", new AnimationManagerFSM.OnAnimEventHandler(this.OnLeftSwordSlash));
		this.m_animEventHandlerList.Add("RightSwordSlash", new AnimationManagerFSM.OnAnimEventHandler(this.OnRightSwordSlash));
		this.m_animEventHandlerList.Add("SwordSlashEnd", new AnimationManagerFSM.OnAnimEventHandler(this.OnSwordSlashEnd));
		this.m_animEventHandlerList.Add("StartMeleeSlash", new AnimationManagerFSM.OnAnimEventHandler(this.OnStartMeleeSlash));
		this.m_animEventHandlerList.Add("ExitMeleeSlash", new AnimationManagerFSM.OnAnimEventHandler(this.OnExitMeleeSlash));
	}

	// Token: 0x06000104 RID: 260 RVA: 0x0000375F File Offset: 0x0000195F
	public override int vmethod_8(string string_0)
	{
		if (string_0.ToLower() == "hurtlight")
		{
			return 1;
		}
		return 0;
	}

	// Token: 0x06000105 RID: 261 RVA: 0x0003A830 File Offset: 0x00038A30
	public void OnMeleeSlashHit()
	{
		AnimationMeleeAttackState animationMeleeAttackState = base.method_16(Utils.smethod_23(AnimationStateFSM.MeleeAttack)) as AnimationMeleeAttackState;
		if (animationMeleeAttackState != null)
		{
			animationMeleeAttackState.m_triggetHitEvent = true;
		}
		if (this.m_meleeAttackSetting != null)
		{
			this.m_meleeAttackSetting.m_canKnockBack = false;
		}
	}

	// Token: 0x06000106 RID: 262 RVA: 0x0003A870 File Offset: 0x00038A70
	public void OnKickHit()
	{
		AnimationMeleeAttackState animationMeleeAttackState = base.method_16(Utils.smethod_23(AnimationStateFSM.MeleeAttack)) as AnimationMeleeAttackState;
		if (animationMeleeAttackState != null)
		{
			animationMeleeAttackState.m_triggetHitEvent = true;
		}
		if (this.m_meleeAttackSetting != null)
		{
			this.m_meleeAttackSetting.m_canKnockBack = true;
		}
	}

	// Token: 0x06000107 RID: 263 RVA: 0x0003A8B0 File Offset: 0x00038AB0
	public void OnLeftSwordSlash()
	{
		BHVTaskSwordSlash bhvtaskSwordSlash = base.GetComponent<BHVTaskManager>().method_13(BHVTaskLayer.FULLBODY) as BHVTaskSwordSlash;
		if (bhvtaskSwordSlash != null)
		{
			bhvtaskSwordSlash.method_0(true);
		}
	}

	// Token: 0x06000108 RID: 264 RVA: 0x0003A8DC File Offset: 0x00038ADC
	public void OnRightSwordSlash()
	{
		BHVTaskSwordSlash bhvtaskSwordSlash = base.GetComponent<BHVTaskManager>().method_13(BHVTaskLayer.FULLBODY) as BHVTaskSwordSlash;
		if (bhvtaskSwordSlash != null)
		{
			bhvtaskSwordSlash.method_0(false);
		}
	}

	// Token: 0x06000109 RID: 265 RVA: 0x0003A908 File Offset: 0x00038B08
	public void OnSwordSlashEnd()
	{
		BHVTaskSwordSlash bhvtaskSwordSlash = base.GetComponent<BHVTaskManager>().method_13(BHVTaskLayer.FULLBODY) as BHVTaskSwordSlash;
		if (bhvtaskSwordSlash != null)
		{
			bhvtaskSwordSlash.bool_1 = true;
		}
	}

	// Token: 0x0600010A RID: 266 RVA: 0x0003A934 File Offset: 0x00038B34
	public void OnStartMeleeSlash()
	{
		foreach (ObjectTrailEffect objectTrailEffect in base.gameObject.GetComponentsInChildren<ObjectTrailEffect>())
		{
			objectTrailEffect.enabled = true;
		}
	}

	// Token: 0x0600010B RID: 267 RVA: 0x0003A968 File Offset: 0x00038B68
	public void OnExitMeleeSlash()
	{
		foreach (ObjectTrailEffect objectTrailEffect in base.gameObject.GetComponentsInChildren<ObjectTrailEffect>())
		{
			objectTrailEffect.enabled = false;
		}
	}

	// Token: 0x04000121 RID: 289
	private BHVMeleeAttackSettings m_meleeAttackSetting;
}
