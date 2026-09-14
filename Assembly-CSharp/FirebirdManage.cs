using System;
using BHV_Skill;
using Core;
using UnityEngine;
using XsdSettings;

// Token: 0x0200047B RID: 1147
public class FirebirdManage : PlayerSkillManage
{
	// Token: 0x06001DE5 RID: 7653 RVA: 0x00095650 File Offset: 0x00093850
	private FirebirdManage.FirebirdBehavior method_11(FireBirdBehaviorType fireBirdBehaviorType_0)
	{
		if (fireBirdBehaviorType_0 == FireBirdBehaviorType.Recall)
		{
			return new FirebirdManage.RecallBehavior(this);
		}
		if (fireBirdBehaviorType_0 != FireBirdBehaviorType.Hover)
		{
			DebugUtils.LogError(LogCategory.Gamelogic, "Invalid FireBird Behavior: " + fireBirdBehaviorType_0.ToString());
			return null;
		}
		return new FirebirdManage.HoverBehavior(this);
	}

	// Token: 0x06001DE6 RID: 7654 RVA: 0x00095690 File Offset: 0x00093890
	public override void vmethod_0()
	{
		base.vmethod_0();
		this.m_skillId_begin_include = ESkillType.FirebirdFirstAction;
		this.m_skillId_end_exclude = ESkillType.BerserkFirstAction;
		this.m_settings = base.method_1<BHVSkillSettingsFireBird>();
		this.m_behavior = this.method_11(this.m_settings.m_behavior);
		this.m_skillInfo.m_current_skillID = SkillID.FireBird;
		base.method_5(SkillEvent.ToSpawnFireBird, new PlayerSkillManage.SkillDelegate(this.method_16));
		base.method_5(SkillEvent.FireBirdTurnStart, new PlayerSkillManage.SkillDelegate(this.OnCallback));
		base.method_5(SkillEvent.FireBirdAbsorb, new PlayerSkillManage.SkillDelegate(this.OnAbsorb));
		base.method_5(SkillEvent.FireBirdExplode, new PlayerSkillManage.SkillDelegate(this.OnExplode));
		base.method_5(SkillEvent.FirebirdDestroyed, new PlayerSkillManage.SkillDelegate(this.OnFirebirdDestroy));
		base.method_5(SkillEvent.FirebirdReachEnd, new PlayerSkillManage.SkillDelegate((this.m_behavior as FirebirdManage.FirebirdBehavior).OnReachEnd));
		base.method_5(SkillEvent.FirebirdCollideEnviorment, new PlayerSkillManage.SkillDelegate((this.m_behavior as FirebirdManage.FirebirdBehavior).OnCollideEnviorment));
		base.method_5(SkillEvent.FireBirdSpawn, new PlayerSkillManage.SkillDelegate(this.OnFirebirdSpawn));
	}

	// Token: 0x06001DE7 RID: 7655 RVA: 0x00015084 File Offset: 0x00013284
	public override void Update()
	{
		base.Update();
		this.method_17();
	}

	// Token: 0x06001DE8 RID: 7656 RVA: 0x0001359C File Offset: 0x0001179C
	public override void OnTriggerAction(float _delay)
	{
		this.m_animDelay = _delay;
	}

	// Token: 0x06001DE9 RID: 7657 RVA: 0x00015092 File Offset: 0x00013292
	public override void OnSkillTask(ESkillStatePhase _phase)
	{
		if (_phase == ESkillStatePhase.First)
		{
			base.method_0().OnFirstAction();
		}
		else if (_phase == ESkillStatePhase.Second)
		{
			base.method_0().OnSecondAction();
		}
	}

	// Token: 0x06001DEA RID: 7658 RVA: 0x000150B3 File Offset: 0x000132B3
	public override void OnPlayerBeKilled()
	{
		this.method_12();
	}

	// Token: 0x06001DEB RID: 7659 RVA: 0x000150BB File Offset: 0x000132BB
	public override bool vmethod_3()
	{
		return this.m_animationMgr.method_50("PlayerFireBird");
	}

	// Token: 0x06001DEC RID: 7660 RVA: 0x000150B3 File Offset: 0x000132B3
	public override void OnPlayerRespawn()
	{
		this.method_12();
	}

	// Token: 0x06001DED RID: 7661 RVA: 0x0000311B File Offset: 0x0000131B
	public override void OnLeaveSession()
	{
	}

	// Token: 0x06001DEE RID: 7662 RVA: 0x000150B3 File Offset: 0x000132B3
	public override void OnPlayerSuicide()
	{
		this.method_12();
	}

	// Token: 0x06001DEF RID: 7663 RVA: 0x000150D2 File Offset: 0x000132D2
	private void method_12()
	{
		if (this.m_firebird)
		{
			this.m_firebird.OnLifeEnd(MoveBloodWing.LifeEndType.PlayerDie);
			this.m_firebird = null;
		}
		base.OnSkillEvent(SkillEvent.FireBirdCoolDownEnd);
		this.m_cooldown_FinishTime = 0f;
		this.method_15(0f);
	}

	// Token: 0x06001DF0 RID: 7664 RVA: 0x00015112 File Offset: 0x00013312
	public override void vmethod_6(MoveBloodWing moveBloodWing_0)
	{
		this.m_firebird = moveBloodWing_0;
	}

	// Token: 0x06001DF1 RID: 7665 RVA: 0x00013635 File Offset: 0x00011835
	public override void OnPostAssembly()
	{
		base.method_6(false);
		this.m_playerOwner.VFXManager_0.method_0(ENPCParticleType.E_Berserk_CureHeart, this.m_playerOwner.transform);
	}

	// Token: 0x06001DF2 RID: 7666 RVA: 0x0000311B File Offset: 0x0000131B
	public override void OnDamaged(DamageContext context)
	{
	}

	// Token: 0x06001DF3 RID: 7667 RVA: 0x0000311B File Offset: 0x0000131B
	public override void vmethod_12(Entity entity_0, HitInfo hitInfo_0)
	{
	}

	// Token: 0x06001DF4 RID: 7668 RVA: 0x00095794 File Offset: 0x00093994
	private bool method_13(HitInfo hitInfo_0)
	{
		Entity entity = BadAssNetworkView.smethod_4(hitInfo_0.m_from);
		return hitInfo_0.m_attackSubType == AttackSubType.DamageOverTimeGeneric && entity == this.m_playerOwner;
	}

	// Token: 0x06001DF5 RID: 7669 RVA: 0x0001511B File Offset: 0x0001331B
	private void OnFirebirdSpawn()
	{
		this.m_time_firebirdSpawn = Time.time;
	}

	// Token: 0x06001DF6 RID: 7670 RVA: 0x00015128 File Offset: 0x00013328
	private bool method_14(float float_0)
	{
		return Time.time <= this.m_time_firebirdSpawn + float_0;
	}

	// Token: 0x06001DF7 RID: 7671 RVA: 0x0000311B File Offset: 0x0000131B
	private void method_15(float float_0)
	{
	}

	// Token: 0x06001DF8 RID: 7672 RVA: 0x000957C8 File Offset: 0x000939C8
	private void OnAbsorb()
	{
		FirebirdManage.smethod_2("[OnAbsorb] m_firebird = null");
		this.m_firebird = null;
		Vector3 vector = new Vector3(0f, 1.2f, 0f);
		float num = this.m_playerOwner.PlayerEffectManager_0.method_0(EffectType.RefillShield);
		if (num > 0f)
		{
			this.m_playerOwner.VFXManager_0.method_5(ENPCParticleType.E_Player_AbsorbFirebird, this.m_playerOwner, this.m_playerOwner.transform, vector, Quaternion.identity, 3f, true);
		}
		this.m_cooldown_StartTime = Time.time;
		this.m_cooldown_FinishTime = Time.time + this.m_settings.m_cooldown_flyback;
		this.method_15(this.m_cooldown_FinishTime);
	}

	// Token: 0x06001DF9 RID: 7673 RVA: 0x00095874 File Offset: 0x00093A74
	private void OnExplode()
	{
		FirebirdManage.smethod_2("[OnExplode] m_firebird = null");
		this.m_firebird = null;
		this.m_cooldown_StartTime = Time.time;
		this.m_cooldown_FinishTime = Time.time + this.method_21();
		this.method_15(this.m_cooldown_FinishTime);
		Vector3 vector = new Vector3(0f, 1.2f, 0f);
		float num = this.m_playerOwner.PlayerEffectManager_0.method_0(EffectType.RefillShield);
		if (num > 0f)
		{
			this.m_playerOwner.VFXManager_0.method_5(ENPCParticleType.E_Player_AbsorbFirebird, this.m_playerOwner, this.m_playerOwner.transform, vector, Quaternion.identity, 3f, true);
		}
	}

	// Token: 0x06001DFA RID: 7674 RVA: 0x0001513C File Offset: 0x0001333C
	private void OnCallback()
	{
		if (this.m_firebird != null)
		{
			this.m_firebird.OnTurnBack();
		}
	}

	// Token: 0x06001DFB RID: 7675 RVA: 0x0000311B File Offset: 0x0000131B
	private void method_16()
	{
	}

	// Token: 0x06001DFC RID: 7676 RVA: 0x0000311B File Offset: 0x0000131B
	private void OnFirebirdDestroy()
	{
	}

	// Token: 0x06001DFD RID: 7677 RVA: 0x0009591C File Offset: 0x00093B1C
	private void method_17()
	{
		float num;
		if (this.m_cooldown_FinishTime <= 0f)
		{
			num = 0f;
		}
		else
		{
			num = (Time.time - this.m_cooldown_StartTime) / (this.m_cooldown_FinishTime - this.m_cooldown_StartTime);
			num = Mathf.Clamp(num, 0f, 1f);
			if (num >= 1f)
			{
				base.OnSkillEvent(SkillEvent.FireBirdCoolDownEnd);
				this.m_cooldown_FinishTime = 0f;
			}
		}
		base.OnUpdateProgress_CoolDown(num);
	}

	// Token: 0x06001DFE RID: 7678 RVA: 0x00015157 File Offset: 0x00013357
	private void method_18()
	{
		this.m_playerOwner.method_83(this.m_animDelay);
	}

	// Token: 0x06001DFF RID: 7679 RVA: 0x0001516A File Offset: 0x0001336A
	private void method_19()
	{
		this.m_playerOwner.method_84(this.m_animDelay);
	}

	// Token: 0x06001E00 RID: 7680 RVA: 0x0001517D File Offset: 0x0001337D
	public MoveBloodWing method_20()
	{
		return this.m_firebird;
	}

	// Token: 0x06001E01 RID: 7681 RVA: 0x00095994 File Offset: 0x00093B94
	private float method_21()
	{
		return this.m_settings.m_cooldown_explode * this.m_playerOwner.PlayerEffectManager_0.method_0(EffectType.FirebirdExplodeCooldown);
	}

	// Token: 0x06001E02 RID: 7682 RVA: 0x0000311B File Offset: 0x0000131B
	public static void smethod_2(string string_0)
	{
	}

	// Token: 0x06001E03 RID: 7683 RVA: 0x00015185 File Offset: 0x00013385
	public override void OnEnterPlayerCripple()
	{
		this.method_22();
	}

	// Token: 0x06001E04 RID: 7684 RVA: 0x000959C0 File Offset: 0x00093BC0
	private void method_22()
	{
		if (this.m_firebird)
		{
			this.m_firebird.OnLifeEnd(MoveBloodWing.LifeEndType.FlyBack);
			this.m_firebird = null;
		}
		this.m_cooldown_StartTime = Time.time;
		this.m_cooldown_FinishTime = Time.time + this.method_21();
		this.method_15(this.m_cooldown_FinishTime);
	}

	// Token: 0x040013AF RID: 5039
	private BHVSkillSettingsFireBird m_settings;

	// Token: 0x040013B0 RID: 5040
	private MoveBloodWing m_firebird;

	// Token: 0x040013B1 RID: 5041
	public float m_cooldown_StartTime;

	// Token: 0x040013B2 RID: 5042
	public float m_cooldown_FinishTime;

	// Token: 0x040013B3 RID: 5043
	private float m_time_firebirdSpawn;

	// Token: 0x0200047C RID: 1148
	public class FirebirdBehavior : PlayerSkillManage.BaseSkillBehavior
	{
		// Token: 0x06001E05 RID: 7685 RVA: 0x0001518D File Offset: 0x0001338D
		public FirebirdBehavior(PlayerSkillManage playerSkillManage_0)
			: base(playerSkillManage_0)
		{
			this.m_firebird_owner = this.m_owner as FirebirdManage;
		}

		// Token: 0x06001E06 RID: 7686 RVA: 0x0000311B File Offset: 0x0000131B
		public virtual void OnReachEnd()
		{
		}

		// Token: 0x06001E07 RID: 7687 RVA: 0x0000311B File Offset: 0x0000131B
		public virtual void OnCollideEnviorment()
		{
		}

		// Token: 0x040013B4 RID: 5044
		protected FirebirdManage m_firebird_owner;
	}

	// Token: 0x0200047D RID: 1149
	public class RecallBehavior : FirebirdManage.FirebirdBehavior
	{
		// Token: 0x06001E08 RID: 7688 RVA: 0x000151A7 File Offset: 0x000133A7
		public RecallBehavior(PlayerSkillManage playerSkillManage_0)
			: base(playerSkillManage_0)
		{
		}

		// Token: 0x06001E09 RID: 7689 RVA: 0x000151B0 File Offset: 0x000133B0
		public override void OnFirstAction()
		{
			this.m_firebird_owner.method_18();
			this.m_firebird_owner.OnSkillEvent(SkillEvent.FireBirdAnimStart);
		}

		// Token: 0x06001E0A RID: 7690 RVA: 0x000151C9 File Offset: 0x000133C9
		public override void OnSecondAction()
		{
			this.m_firebird_owner.method_19();
			this.m_firebird_owner.OnSkillEvent(SkillEvent.FireBirdTurnStart);
		}

		// Token: 0x06001E0B RID: 7691 RVA: 0x00095A18 File Offset: 0x00093C18
		public override bool vmethod_0()
		{
			MoveBloodWing.TargetType targetType = this.m_firebird_owner.method_20().method_16();
			return targetType == MoveBloodWing.TargetType.FlyingAway;
		}

		// Token: 0x06001E0C RID: 7692 RVA: 0x000151E3 File Offset: 0x000133E3
		public override void OnReachEnd()
		{
			this.m_firebird_owner.OnSkillEvent(SkillEvent.FireBirdDive);
			this.m_firebird_owner.method_20().method_22();
		}

		// Token: 0x06001E0D RID: 7693 RVA: 0x000151E3 File Offset: 0x000133E3
		public override void OnCollideEnviorment()
		{
			this.m_firebird_owner.OnSkillEvent(SkillEvent.FireBirdDive);
			this.m_firebird_owner.method_20().method_22();
		}
	}

	// Token: 0x0200047E RID: 1150
	public class HoverBehavior : FirebirdManage.FirebirdBehavior
	{
		// Token: 0x06001E0E RID: 7694 RVA: 0x000151A7 File Offset: 0x000133A7
		public HoverBehavior(PlayerSkillManage playerSkillManage_0)
			: base(playerSkillManage_0)
		{
		}

		// Token: 0x06001E0F RID: 7695 RVA: 0x000151B0 File Offset: 0x000133B0
		public override void OnFirstAction()
		{
			this.m_firebird_owner.method_18();
			this.m_firebird_owner.OnSkillEvent(SkillEvent.FireBirdAnimStart);
		}

		// Token: 0x06001E10 RID: 7696 RVA: 0x00095A3C File Offset: 0x00093C3C
		public override void OnSecondAction()
		{
			if (this.m_firebird_owner != null)
			{
				this.m_firebird_owner.method_19();
				this.m_firebird_owner.OnSkillEvent(SkillEvent.FireBirdDive);
				MoveBloodWing moveBloodWing = this.m_firebird_owner.method_20();
				if (moveBloodWing)
				{
					moveBloodWing.method_22();
				}
			}
		}

		// Token: 0x06001E11 RID: 7697 RVA: 0x00095A88 File Offset: 0x00093C88
		public override bool vmethod_0()
		{
			MoveBloodWing.TargetType targetType = this.m_firebird_owner.method_20().method_16();
			return targetType == MoveBloodWing.TargetType.FlyingAway || targetType == MoveBloodWing.TargetType.Hover || targetType == MoveBloodWing.TargetType.Chase || targetType == MoveBloodWing.TargetType.HurtZone;
		}

		// Token: 0x06001E12 RID: 7698 RVA: 0x00095AB8 File Offset: 0x00093CB8
		public override void OnReachEnd()
		{
			if (!(this.m_firebird_owner == null) && !(this.m_firebird_owner.method_20() == null))
			{
				FirebirdManage.smethod_2("[OnReachEnd  OK]");
				this.m_firebird_owner.method_20().m_vfxMgr.method_4(ENPCParticleType.E_FireBird_Absorb, 0f, true);
				this.m_firebird_owner.method_20().OnLifeEnd(MoveBloodWing.LifeEndType.FlyBack);
				return;
			}
			FirebirdManage.smethod_2("[OnReachEnd  fail]");
		}

		// Token: 0x06001E13 RID: 7699 RVA: 0x00095B2C File Offset: 0x00093D2C
		public override void OnCollideEnviorment()
		{
			if (!(this.m_firebird_owner == null) && !(this.m_firebird_owner.method_20() == null))
			{
				FirebirdManage.smethod_2("[OnCollideEnviorment  OK]");
				this.m_firebird_owner.method_20().method_29();
				return;
			}
			FirebirdManage.smethod_2("[OnCollideEnviorment  fail]");
		}
	}
}
