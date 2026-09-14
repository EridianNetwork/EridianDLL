using System;
using System.Collections.Generic;
using BHV_Skill;
using ns0;
using UnityEngine;
using XsdSettings;

// Token: 0x0200043A RID: 1082
public class BerserkManage : PlayerSkillManage
{
	// Token: 0x06001A8E RID: 6798 RVA: 0x00087D14 File Offset: 0x00085F14
	public override void vmethod_0()
	{
		base.vmethod_0();
		this.m_skillId_begin_include = ESkillType.BerserkFirstAction;
		this.m_skillId_end_exclude = ESkillType.TurretFirstAction;
		this.m_settings = base.method_1<BHVSkillSettingsBerserk>();
		this.m_skillInfo.m_current_skillID = SkillID.Berserk;
		base.method_5(SkillEvent.BerserkStomp, new PlayerSkillManage.SkillDelegate(this.OnStomp));
		base.method_5(SkillEvent.BerserkPunchEnd, new PlayerSkillManage.SkillDelegate(this.OnPunchEnd));
		base.method_5(SkillEvent.BerserkDashToPunch, new PlayerSkillManage.SkillDelegate(this.OnDashToPunch));
		base.method_5(SkillEvent.BerserkDashStateExit, new PlayerSkillManage.SkillDelegate(this.OnDashStateExit));
		base.method_5(SkillEvent.BerserkCoolDownStart, new PlayerSkillManage.SkillDelegate(this.OnCoolDownStart));
		base.method_5(SkillEvent.SkillExit, new PlayerSkillManage.SkillDelegate(this.OnSkillExit));
		base.method_5(SkillEvent.BerserkDashEndHitNone, new PlayerSkillManage.SkillDelegate(this.OnDashEndHitNone));
	}

	// Token: 0x06001A8F RID: 6799 RVA: 0x00087DDC File Offset: 0x00085FDC
	private void method_11()
	{
		float num = Mathf.Clamp((Time.time - this.m_berserk_start) / (this.m_berserk_end - this.m_berserk_start), 0f, 1f);
		base.OnUpdateProgress_Skill(num);
		if (num >= 1f)
		{
			this.method_19(BerserkManage.BerserkPhase.Cooling);
			this.method_29();
			base.OnSkillEvent(SkillEvent.SkillExit);
			base.OnSkillEvent(SkillEvent.BerserkCoolDownStart);
			this.method_15();
		}
	}

	// Token: 0x06001A90 RID: 6800 RVA: 0x00087E44 File Offset: 0x00086044
	public override void Update()
	{
		base.Update();
		switch (this.m_phase)
		{
		case BerserkManage.BerserkPhase.Berserking:
			this.method_11();
			base.method_7(this.method_17());
			break;
		case BerserkManage.BerserkPhase.Dashing:
			this.method_11();
			this.method_16();
			break;
		case BerserkManage.BerserkPhase.Punch:
			this.method_11();
			break;
		case BerserkManage.BerserkPhase.Cooling:
		{
			float num = Mathf.Clamp((Time.time - this.m_cooldown_start) * this.m_rate_cooldown / (this.m_cooldown_end - this.m_cooldown_start), 0f, 1f);
			base.OnUpdateProgress_CoolDown(num);
			if (num >= 1f)
			{
				base.OnSkillEvent(SkillEvent.BerserkCoolDownEnd);
				this.m_phase = BerserkManage.BerserkPhase.Ready;
			}
			break;
		}
		}
		if (this.m_cooldownRateTimer.method_7())
		{
			this.method_14();
		}
	}

	// Token: 0x06001A91 RID: 6801 RVA: 0x0001359C File Offset: 0x0001179C
	public override void OnTriggerAction(float _delay)
	{
		this.m_animDelay = _delay;
	}

	// Token: 0x06001A92 RID: 6802 RVA: 0x000135A5 File Offset: 0x000117A5
	public override void OnSkillTask(ESkillStatePhase _phase)
	{
		if (_phase == ESkillStatePhase.First)
		{
			this.OnBerserkTask_1st();
		}
		else if (_phase == ESkillStatePhase.Second)
		{
			this.OnBerserkTask_2nd();
		}
	}

	// Token: 0x06001A93 RID: 6803 RVA: 0x00087F0C File Offset: 0x0008610C
	private void OnBerserkTask_1st()
	{
		if (this.m_phase == BerserkManage.BerserkPhase.Punch)
		{
			return;
		}
		this.m_meleeSkill_num = 0;
		this.m_phase = BerserkManage.BerserkPhase.Dashing;
		base.OnSkillEvent(SkillEvent.BerserkDashStart);
		this.m_berserk_start = Time.time;
		this.m_berserk_end = Time.time + this.method_12();
		this.m_leftRageNum = this.m_rageNum;
		this.m_dmg_inRange = 0;
		base.OnSkillEvent(SkillEvent.BerserkRageEffect);
		base.method_6(true);
		if (!this.m_playerOwner.vmethod_26())
		{
			this.m_playerOwner.VFXManager_0.method_4(ENPCParticleType.E_Player_BerserkStatus, 0f, true);
		}
	}

	// Token: 0x06001A94 RID: 6804 RVA: 0x00087FA0 File Offset: 0x000861A0
	private void OnBerserkTask_2nd()
	{
		this.m_playerOwner.method_80(this.m_animDelay);
		base.OnSkillEvent(SkillEvent.BerserkChargeStart);
		base.OnSkillEvent(SkillEvent.BerserkCoolDownStart);
		this.method_19(BerserkManage.BerserkPhase.Cooling);
		this.method_29();
		base.method_6(false);
		this.OnStomp();
		this.m_playerOwner.VFXManager_0.method_13(ENPCParticleType.E_Player_BerserkStatus);
		this.m_playerOwner.method_146(BadAssFPSCamera.ShakeType.high);
	}

	// Token: 0x06001A95 RID: 6805 RVA: 0x000135BC File Offset: 0x000117BC
	public override void OnEnterPlayerCripple()
	{
		base.OnSkillEvent(SkillEvent.BerserkCoolDownStart);
		this.method_19(BerserkManage.BerserkPhase.Cooling);
		this.method_29();
		base.method_6(false);
		this.m_playerOwner.VFXManager_0.method_13(ENPCParticleType.E_Player_BerserkStatus);
	}

	// Token: 0x06001A96 RID: 6806 RVA: 0x0000311B File Offset: 0x0000131B
	public override void OnEnterPlayerDown()
	{
	}

	// Token: 0x06001A97 RID: 6807 RVA: 0x000135ED File Offset: 0x000117ED
	private float method_12()
	{
		return this.m_settings.m_duration * this.m_playerOwner.PlayerEffectManager_0.method_0(EffectType.ExtendRangeDuration);
	}

	// Token: 0x06001A98 RID: 6808 RVA: 0x00088008 File Offset: 0x00086208
	public override bool vmethod_3()
	{
		bool flag;
		if (this.m_phase == BerserkManage.BerserkPhase.Ready)
		{
			flag = true;
		}
		else if (this.m_phase == BerserkManage.BerserkPhase.Berserking)
		{
			flag = !this.m_animationMgr.method_13(AnimationStateFSM.PlayerBerserkCharge);
		}
		else
		{
			flag = this.m_phase == BerserkManage.BerserkPhase.Punch || this.m_phase == BerserkManage.BerserkPhase.Dashing;
		}
		return flag;
	}

	// Token: 0x06001A99 RID: 6809 RVA: 0x0008805C File Offset: 0x0008625C
	public override float vmethod_4(float float_0)
	{
		if (this.m_playerOwner.method_69())
		{
			return float_0 * this.m_playerOwner.CharacterSetting_0.m_rotation_stun;
		}
		BerserkManage.BerserkPhase berserkPhase = this.method_28();
		if (berserkPhase != BerserkManage.BerserkPhase.Dashing)
		{
			if (berserkPhase != BerserkManage.BerserkPhase.Punch)
			{
				return float_0;
			}
		}
		if (this.m_autoAimAngle != null)
		{
			float value = this.m_autoAimAngle.Value;
			this.m_autoAimAngle = null;
			return value;
		}
		return float_0 * this.m_settings.m_rotationMultiplier;
	}

	// Token: 0x06001A9A RID: 6810 RVA: 0x000880D4 File Offset: 0x000862D4
	public override Vector3 vmethod_5(Vector3 vector3_0)
	{
		BerserkManage.BerserkPhase berserkPhase = this.method_28();
		if ((berserkPhase == BerserkManage.BerserkPhase.Dashing || berserkPhase == BerserkManage.BerserkPhase.Punch) && base.Boolean_0)
		{
			vector3_0.x *= 0.2f;
			vector3_0.z *= 0.2f;
			return vector3_0;
		}
		return vector3_0;
	}

	// Token: 0x06001A9B RID: 6811 RVA: 0x00088124 File Offset: 0x00086324
	public override float vmethod_2()
	{
		float num = 1f;
		if (this.m_phase == BerserkManage.BerserkPhase.Berserking)
		{
			num *= this.m_playerOwner.PlayerEffectManager_0.method_0(EffectType.BerserkFireRate);
		}
		return num;
	}

	// Token: 0x06001A9C RID: 6812 RVA: 0x0001360D File Offset: 0x0001180D
	public override void OnPlayerRespawn()
	{
		this.method_13();
	}

	// Token: 0x06001A9D RID: 6813 RVA: 0x0000311B File Offset: 0x0000131B
	public override void OnLeaveSession()
	{
	}

	// Token: 0x06001A9E RID: 6814 RVA: 0x0001360D File Offset: 0x0001180D
	public override void OnPlayerSuicide()
	{
		this.method_13();
	}

	// Token: 0x06001A9F RID: 6815 RVA: 0x00013615 File Offset: 0x00011815
	private void method_13()
	{
		base.OnSkillEvent(SkillEvent.BerserkCoolDownStart);
		base.OnSkillEvent(SkillEvent.BerserkCoolDownEnd);
		base.Boolean_0 = false;
		this.m_phase = BerserkManage.BerserkPhase.Ready;
	}

	// Token: 0x06001AA0 RID: 6816 RVA: 0x00013635 File Offset: 0x00011835
	public override void OnPostAssembly()
	{
		base.method_6(false);
		this.m_playerOwner.VFXManager_0.method_0(ENPCParticleType.E_Berserk_CureHeart, this.m_playerOwner.transform);
	}

	// Token: 0x06001AA1 RID: 6817 RVA: 0x0001365B File Offset: 0x0001185B
	public override bool vmethod_9(EntityWeapon entityWeapon_0)
	{
		return this.m_phase == BerserkManage.BerserkPhase.Berserking && entityWeapon_0.method_17().method_1() == WeaponType.ShotGun;
	}

	// Token: 0x06001AA2 RID: 6818 RVA: 0x00088158 File Offset: 0x00086358
	public override int vmethod_10(int int_0, float float_0)
	{
		int num = int_0;
		float num2 = this.m_playerOwner.PlayerEffectManager_0.method_0(EffectType.ConsumeNoAmmo);
		if (num2 > 0f && float_0 <= num2)
		{
			num = 0;
		}
		return num;
	}

	// Token: 0x06001AA3 RID: 6819 RVA: 0x00013677 File Offset: 0x00011877
	public override int vmethod_11(int int_0)
	{
		return int_0 + (int)this.m_playerOwner.PlayerEffectManager_0.method_0(EffectType.BulletPerShot);
	}

	// Token: 0x06001AA4 RID: 6820 RVA: 0x0008818C File Offset: 0x0008638C
	public override void OnDamaged(DamageContext context)
	{
		if (this.m_phase == BerserkManage.BerserkPhase.Berserking && context.m_victim == this.m_playerOwner && context.m_killer != this.m_playerOwner)
		{
			this.m_dmg_inRange += context.m_damageInfo.m_shieldDamagePoints + context.m_damageInfo.m_healthDamagePoints;
		}
		if (this.m_phase == BerserkManage.BerserkPhase.Cooling && context.m_victim == this.m_playerOwner && context.m_killer != this.m_playerOwner)
		{
			this.m_rate_cooldown = this.m_playerOwner.PlayerEffectManager_0.method_0(EffectType.AccelCooldownWhenHurt);
			this.m_cooldownRateTimer.Start(2.5f);
		}
	}

	// Token: 0x06001AA5 RID: 6821 RVA: 0x0001368E File Offset: 0x0001188E
	private void method_14()
	{
		this.m_rate_cooldown = 1f;
	}

	// Token: 0x06001AA6 RID: 6822 RVA: 0x0000311B File Offset: 0x0000131B
	public override void OnPlayerKillEnemy(Entity _enemy, KillContext _context)
	{
	}

	// Token: 0x06001AA7 RID: 6823 RVA: 0x0008824C File Offset: 0x0008644C
	public override bool vmethod_13()
	{
		if (this.m_playerOwner.vmethod_16().method_99() != WeaponType.ShotGun)
		{
			return false;
		}
		bool flag = false;
		float num = this.m_playerOwner.PlayerEffectManager_0.method_0(EffectType.DespHealthPercent);
		if (num > 0f)
		{
			float num2 = (float)this.m_playerOwner.vmethod_19().vmethod_4() / (float)this.m_playerOwner.vmethod_19().vmethod_0();
			if (num2 < num)
			{
				flag = true;
			}
		}
		return flag;
	}

	// Token: 0x06001AA8 RID: 6824 RVA: 0x0000311B File Offset: 0x0000131B
	public override void vmethod_12(Entity entity_0, HitInfo hitInfo_0)
	{
	}

	// Token: 0x17000168 RID: 360
	// (get) Token: 0x06001AA9 RID: 6825 RVA: 0x0001369B File Offset: 0x0001189B
	// (set) Token: 0x06001AAA RID: 6826 RVA: 0x000136A3 File Offset: 0x000118A3
	public int Int32_0
	{
		get
		{
			return this.m_meleeSkill_num;
		}
		set
		{
			this.m_meleeSkill_num = value;
		}
	}

	// Token: 0x06001AAB RID: 6827 RVA: 0x000882B8 File Offset: 0x000864B8
	public override bool vmethod_14()
	{
		if (this.m_phase == BerserkManage.BerserkPhase.Berserking)
		{
			int num = (int)this.m_playerOwner.PlayerEffectManager_0.method_0(EffectType.BerserkPunchCount);
			if (this.m_meleeSkill_num < num)
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x06001AAC RID: 6828 RVA: 0x000136AC File Offset: 0x000118AC
	private void method_15()
	{
		if (this.m_dmg_inRange > 0)
		{
			this.m_playerOwner.VFXManager_0.method_4(ENPCParticleType.E_Player_BerserkStomp, 0f, true);
		}
	}

	// Token: 0x06001AAD RID: 6829 RVA: 0x000882F0 File Offset: 0x000864F0
	private void method_16()
	{
		if (m_playerOwner == null || m_settings == null)
		{
			return;
		}
		Entity entity = null;
		List<Entity> list = m_playerOwner.method_150(m_settings.m_punchRadius);
		for (int i = 0; i < list.Count; i++)
		{
			Entity entity2 = list[i];
			Vector3 vector = m_playerOwner.transform.TransformDirection(Vector3.forward);
			Vector3 vector2 = entity2.transform.position - m_playerOwner.transform.position;
			if (Vector3.Dot(vector, vector2) > 0f && !(Vector3.Angle(vector, vector2) >= m_settings.m_punchAngle * 0.5f))
			{
				entity = entity2;
				break;
			}
		}
		if (entity != null)
		{
			if (ns0.MonoSingleton<Session>.Instance.method_12() && entity is EntityPlayer)
			{
				Vector3 fromDirection = m_playerOwner.transform.TransformDirection(Vector3.forward);
				Vector3 toDirection = entity.transform.position - m_playerOwner.transform.position;
				m_autoAimAngle = Quaternion.FromToRotation(fromDirection, toDirection).eulerAngles.y;
			}
			OnSkillEvent(SkillEvent.BerserkDashToPunch);
			method_26();
		}
	}
	// Token: 0x06001AAE RID: 6830 RVA: 0x000136D0 File Offset: 0x000118D0
	private float method_17()
	{
		return this.m_playerOwner.PlayerEffectManager_0.method_0(EffectType.RegenAmmoSpeed);
	}

	// Token: 0x06001AAF RID: 6831 RVA: 0x000136E4 File Offset: 0x000118E4
	private void method_18()
	{
		this.m_playerOwner.vmethod_16().method_28(999);
	}

	// Token: 0x06001AB0 RID: 6832 RVA: 0x00088444 File Offset: 0x00086644
	private void OnStomp()
	{
		this.m_playerOwner.VFXManager_0.method_4(ENPCParticleType.E_Player_BerserkStomp, 0f, true);
		if (this.m_playerOwner.vmethod_26())
		{
			this.m_playerOwner.VFXManager_0.method_4(ENPCParticleType.E_Berserk_StompShock_1st, 0f, true);
		}
		this.method_21(this.method_25());
		this.method_22();
		this.method_23();
		this.method_20();
	}

	// Token: 0x06001AB1 RID: 6833 RVA: 0x000884B0 File Offset: 0x000866B0
	private void OnDashToPunch()
	{
		if (this.m_phase == BerserkManage.BerserkPhase.Punch)
		{
			return;
		}
		if (this.m_phase == BerserkManage.BerserkPhase.Ready)
		{
			this.m_berserk_start = Time.time;
			this.m_berserk_end = Time.time + this.method_12();
			base.OnSkillEvent(SkillEvent.BerserkDashStart);
			base.OnSkillEvent(SkillEvent.BerserkRageEffect);
			base.method_6(true);
			if (!this.m_playerOwner.vmethod_26())
			{
				this.m_playerOwner.VFXManager_0.method_4(ENPCParticleType.E_Player_BerserkStatus, 0f, true);
			}
		}
		if (!this.m_playerOwner.vmethod_53())
		{
			this.m_phase = BerserkManage.BerserkPhase.Punch;
		}
		this.m_playerOwner.VFXManager_0.method_3(ENPCParticleType.E_Player_BerserkPunch, this.m_playerOwner.vmethod_17().transform, true, 0.5f, true);
		if (this.m_playerOwner.vmethod_26())
		{
			this.m_playerOwner.VFXManager_0.method_3(ENPCParticleType.E_Berserk_MeteorFist_1st, this.m_playerOwner.vmethod_17().transform, false, 0f, true);
		}
		this.m_playerOwner.method_146(BadAssFPSCamera.ShakeType.medium);
		this.m_playerOwner.method_82(0f);
		base.OnSkillEvent(SkillEvent.BerserkPunchStart);
	}

	// Token: 0x06001AB2 RID: 6834 RVA: 0x000136FB File Offset: 0x000118FB
	private void OnDashEndHitNone()
	{
		if (!this.m_playerOwner.vmethod_53())
		{
			this.method_19(BerserkManage.BerserkPhase.Berserking);
		}
		this.m_playerOwner.VFXManager_0.method_13(ENPCParticleType.E_Player_BerserkAirflow);
		this.m_playerOwner.VFXManager_0.method_13(ENPCParticleType.E_Player_BerserkDust);
	}

	// Token: 0x06001AB3 RID: 6835 RVA: 0x000136FB File Offset: 0x000118FB
	private void OnPunchEnd()
	{
		if (!this.m_playerOwner.vmethod_53())
		{
			this.method_19(BerserkManage.BerserkPhase.Berserking);
		}
		this.m_playerOwner.VFXManager_0.method_13(ENPCParticleType.E_Player_BerserkAirflow);
		this.m_playerOwner.VFXManager_0.method_13(ENPCParticleType.E_Player_BerserkDust);
	}

	// Token: 0x06001AB4 RID: 6836 RVA: 0x00013737 File Offset: 0x00011937
	private void OnDashStateExit()
	{
		if (this.m_playerOwner.vmethod_53())
		{
		}
		this.m_playerOwner.VFXManager_0.method_13(ENPCParticleType.E_Player_BerserkAirflow);
		this.m_playerOwner.VFXManager_0.method_13(ENPCParticleType.E_Player_BerserkDust);
	}

	// Token: 0x06001AB5 RID: 6837 RVA: 0x000885C4 File Offset: 0x000867C4
	private void OnCoolDownStart()
	{
		this.m_playerOwner.VFXManager_0.method_13(ENPCParticleType.E_Player_BerserkStatus);
		this.m_playerOwner.VFXManager_0.method_13(ENPCParticleType.E_Player_BerserkAirflow);
		this.m_playerOwner.VFXManager_0.method_13(ENPCParticleType.E_Player_BerserkDust);
		base.method_6(false);
	}

	// Token: 0x06001AB6 RID: 6838 RVA: 0x0001376C File Offset: 0x0001196C
	private void method_19(BerserkManage.BerserkPhase berserkPhase_0)
	{
		this.m_phase = berserkPhase_0;
	}

	// Token: 0x06001AB7 RID: 6839 RVA: 0x0000311B File Offset: 0x0000131B
	private void OnSkillExit()
	{
	}

	// Token: 0x06001AB8 RID: 6840 RVA: 0x0000311B File Offset: 0x0000131B
	private void method_20()
	{
	}

	// Token: 0x06001AB9 RID: 6841 RVA: 0x0000311B File Offset: 0x0000131B
	private void method_21(int int_0)
	{
	}

	// Token: 0x06001ABA RID: 6842 RVA: 0x0000311B File Offset: 0x0000131B
	private void method_22()
	{
	}

	// Token: 0x06001ABB RID: 6843 RVA: 0x0000311B File Offset: 0x0000131B
	public void method_23()
	{
	}

	// Token: 0x06001ABC RID: 6844 RVA: 0x00088614 File Offset: 0x00086814
	private float method_24()
	{
		float stompRadius = this.m_settings.m_stompRadius;
		return stompRadius * this.m_playerOwner.PlayerEffectManager_0.method_0(EffectType.BerserkStompRadius);
	}

	// Token: 0x06001ABD RID: 6845 RVA: 0x00088644 File Offset: 0x00086844
	private int method_25()
	{
		float num = MonoSingleton<LevelingManager>.Instance.method_6(this.m_playerOwner.vmethod_3());
		float num2 = this.m_settings.m_stompDamage * num;
		return (int)(num2 * this.m_playerOwner.PlayerEffectManager_0.method_0(EffectType.BerserkStompDamage));
	}

	// Token: 0x06001ABE RID: 6846 RVA: 0x0000311B File Offset: 0x0000131B
	public void method_26()
	{
	}

	// Token: 0x06001ABF RID: 6847 RVA: 0x0008868C File Offset: 0x0008688C
	private int method_27()
	{
		float num = MonoSingleton<LevelingManager>.Instance.method_6(this.m_playerOwner.vmethod_3());
		return (int)(this.m_settings.m_punchDamage * num * this.m_playerOwner.method_72());
	}

	// Token: 0x06001AC0 RID: 6848 RVA: 0x00013775 File Offset: 0x00011975
	public BerserkManage.BerserkPhase method_28()
	{
		return this.m_phase;
	}

	// Token: 0x06001AC1 RID: 6849 RVA: 0x0001377D File Offset: 0x0001197D
	private void method_29()
	{
		this.m_cooldown_start = Time.time;
		this.m_cooldown_end = Time.time + this.method_30();
	}

	// Token: 0x06001AC2 RID: 6850 RVA: 0x000886CC File Offset: 0x000868CC
	private float method_30()
	{
		return this.m_settings.m_cooldown * this.m_playerOwner.PlayerEffectManager_0.method_0(EffectType.BerserkCoolDownDuration);
	}

	// Token: 0x06001AC3 RID: 6851 RVA: 0x000886FC File Offset: 0x000868FC
	public void method_31()
	{
		if (this.m_phase == BerserkManage.BerserkPhase.Berserking && this.m_leftRageNum > 0)
		{
			float num = this.m_playerOwner.PlayerEffectManager_0.method_0(EffectType.BerserkRageDuration);
			this.m_berserk_end += num;
			this.m_leftRageNum--;
		}
	}

	// Token: 0x06001AC4 RID: 6852 RVA: 0x0008874C File Offset: 0x0008694C
	public override void OnSkillEvent_Client(SkillEvent _event, float _fParam, Vector3 _vParam)
	{
		if (_event == SkillEvent.BerserkExplodeOnHit)
		{
			this.m_playerOwner.VFXManager_0.method_4(ENPCParticleType.E_Player_BerserkStomp, 0f, true);
		}
		else if (_event == SkillEvent.BerserkDashToPunch)
		{
			if (_vParam.x > 0f)
			{
				this.m_autoAimAngle = new float?(_fParam);
			}
			this.OnDashToPunch();
		}
	}

	// Token: 0x06001AC5 RID: 6853 RVA: 0x0001379C File Offset: 0x0001199C
	public float method_32()
	{
		return this.m_settings.m_dashDuration;
	}

	// Token: 0x06001AC6 RID: 6854 RVA: 0x000137A9 File Offset: 0x000119A9
	public float method_33()
	{
		return this.m_settings.m_dashSpeed;
	}

	// Token: 0x0400118F RID: 4495
	private float m_berserk_start;

	// Token: 0x04001190 RID: 4496
	private float m_berserk_end;

	// Token: 0x04001191 RID: 4497
	private float m_cooldown_start;

	// Token: 0x04001192 RID: 4498
	private float m_cooldown_end;

	// Token: 0x04001193 RID: 4499
	private BerserkManage.BerserkPhase m_phase;

	// Token: 0x04001194 RID: 4500
	private int m_rageNum = 3;

	// Token: 0x04001195 RID: 4501
	private int m_leftRageNum = 3;

	// Token: 0x04001196 RID: 4502
	private BHVSkillSettingsBerserk m_settings;

	// Token: 0x04001197 RID: 4503
	private int m_dmg_inRange;

	// Token: 0x04001198 RID: 4504
	private float m_rate_cooldown = 1f;

	// Token: 0x04001199 RID: 4505
	private float? m_autoAimAngle;

	// Token: 0x0400119A RID: 4506
	private Utils.Timer m_cooldownRateTimer = new Utils.Timer();

	// Token: 0x0400119B RID: 4507
	private int m_meleeSkill_num;

	// Token: 0x0200043B RID: 1083
	public enum BerserkPhase
	{
		// Token: 0x0400119D RID: 4509
		Ready,
		// Token: 0x0400119E RID: 4510
		Berserking,
		// Token: 0x0400119F RID: 4511
		Dashing,
		// Token: 0x040011A0 RID: 4512
		Punch,
		// Token: 0x040011A1 RID: 4513
		Cooling
	}
}
