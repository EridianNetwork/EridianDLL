using System;
using ns0;
using UnityEngine;
using XsdSettings;

// Token: 0x02000568 RID: 1384
public class TurretManage : PlayerSkillManage, InstantiateManager.InstanciationClient
{
	// Token: 0x0600239C RID: 9116 RVA: 0x000186BA File Offset: 0x000168BA
	public override void vmethod_0()
	{
		base.vmethod_0();
		this.m_skillId_begin_include = ESkillType.TurretFirstAction;
		this.m_skillId_end_exclude = ESkillType.HunterFirstAction;
		this.m_skillInfo.m_current_skillID = SkillID.Turret;
	}

	// Token: 0x0600239D RID: 9117 RVA: 0x000186E1 File Offset: 0x000168E1
	public override void Update()
	{
		base.Update();
		base.OnUpdateProgress_Skill(this.m_progressTimer_turretLife.method_2());
		base.OnUpdateProgress_CoolDown(this.m_progressTimer_cooldown.method_2());
	}

	// Token: 0x0600239E RID: 9118 RVA: 0x000A954C File Offset: 0x000A774C
	public override float vmethod_2()
	{
		float num = 1f;
		if (this.m_firerate_timer.method_6() && !this.m_firerate_timer.method_7())
		{
			num = this.m_playerOwner.PlayerEffectManager_0.method_0(EffectType.WpnSwapFireRate);
		}
		return num;
	}

	// Token: 0x0600239F RID: 9119 RVA: 0x0001359C File Offset: 0x0001179C
	public override void OnTriggerAction(float _delay)
	{
		this.m_animDelay = _delay;
	}

	// Token: 0x060023A0 RID: 9120 RVA: 0x0001870B File Offset: 0x0001690B
	public override void OnSkillTask(ESkillStatePhase _phase)
	{
		if (_phase == ESkillStatePhase.First)
		{
			this.OnTurretTask_1st();
		}
		else if (_phase == ESkillStatePhase.Second)
		{
			this.OnTurretTask_2nd();
		}
	}

	// Token: 0x060023A1 RID: 9121 RVA: 0x000039EC File Offset: 0x00001BEC
	public override bool vmethod_3()
	{
		return true;
	}

	// Token: 0x060023A2 RID: 9122 RVA: 0x0000311B File Offset: 0x0000131B
	public override void OnPlayerRespawn()
	{
	}

	// Token: 0x060023A3 RID: 9123 RVA: 0x0000311B File Offset: 0x0000131B
	public override void OnLeaveSession()
	{
	}

	// Token: 0x060023A4 RID: 9124 RVA: 0x0000311B File Offset: 0x0000131B
	public override void OnEnterPlayerCripple()
	{
	}

	// Token: 0x060023A5 RID: 9125 RVA: 0x00013635 File Offset: 0x00011835
	public override void OnPostAssembly()
	{
		base.method_6(false);
		this.m_playerOwner.VFXManager_0.method_0(ENPCParticleType.E_Berserk_CureHeart, this.m_playerOwner.transform);
	}

	// Token: 0x060023A6 RID: 9126 RVA: 0x00018722 File Offset: 0x00016922
	public override float vmethod_7()
	{
		return this.m_playerOwner.PlayerEffectManager_0.method_0(EffectType.WeaponReloadSpeed);
	}

	// Token: 0x060023A7 RID: 9127 RVA: 0x00018736 File Offset: 0x00016936
	public override float vmethod_8()
	{
		return this.m_playerOwner.PlayerEffectManager_0.method_0(EffectType.WeaponSwitchSpeed);
	}

	// Token: 0x060023A8 RID: 9128 RVA: 0x0000311B File Offset: 0x0000131B
	public override void OnDamaged(DamageContext context)
	{
	}

	// Token: 0x060023A9 RID: 9129 RVA: 0x0001874A File Offset: 0x0001694A
	public override void OnSwitchWeaponDone()
	{
		if (this.m_playerOwner.PlayerEffectManager_0.method_0(EffectType.WpnSwapFireRate) > 1f)
		{
			this.m_firerate_timer.Start(this.m_playerOwner.SkillTreeStatus_0.method_7(ESkillType.Readiness, 0));
		}
	}

	// Token: 0x060023AA RID: 9130 RVA: 0x0000311B File Offset: 0x0000131B
	public override void vmethod_12(Entity entity_0, HitInfo hitInfo_0)
	{
	}

	// Token: 0x060023AB RID: 9131 RVA: 0x00018783 File Offset: 0x00016983
	private void OnTurretTask_1st()
	{
		this.method_11();
		base.OnSkillEvent(SkillEvent.TurretThrowAnimStart);
	}

	// Token: 0x060023AC RID: 9132 RVA: 0x00018793 File Offset: 0x00016993
	private void OnTurretTask_2nd()
	{
		this.method_12();
	}

	// Token: 0x060023AD RID: 9133 RVA: 0x000A9590 File Offset: 0x000A7790
	private void method_11()
	{
		AnimationPlayerThrowTurretState animationPlayerThrowTurretState = this.m_animationMgr.method_16(Utils.smethod_23(AnimationStateFSM.PlayerThrowTurret)) as AnimationPlayerThrowTurretState;
		animationPlayerThrowTurretState.m_netLatency = this.m_animDelay;
		animationPlayerThrowTurretState.method_22(this.m_animationMgr.method_55(), this.m_playerOwner.PlayerEffectManager_0.method_0(EffectType.TurretDeployFar) > 1f);
		this.m_animationMgr.method_31(AnimationStateFSM.PlayerThrowTurret);
	}

	// Token: 0x060023AE RID: 9134 RVA: 0x000A95F8 File Offset: 0x000A77F8
	private void method_12()
	{
		AnimationPlayerRetrieveTurretState animationPlayerRetrieveTurretState = this.m_animationMgr.method_16(Utils.smethod_23(AnimationStateFSM.PlayerRetrieveTurret)) as AnimationPlayerRetrieveTurretState;
		animationPlayerRetrieveTurretState.m_netLatency = this.m_animDelay;
		animationPlayerRetrieveTurretState.method_22(this.m_animationMgr.method_55());
		this.m_animationMgr.method_31(AnimationStateFSM.PlayerRetrieveTurret);
	}

	// Token: 0x060023AF RID: 9135 RVA: 0x0000311B File Offset: 0x0000131B
	private void method_13(Vector3 vector3_0)
	{
	}

	// Token: 0x060023B0 RID: 9136 RVA: 0x0000311B File Offset: 0x0000131B
	private void method_14()
	{
	}

	// Token: 0x060023B1 RID: 9137 RVA: 0x0000311B File Offset: 0x0000131B
	public void OnInstanciate(GameObject instance, InstantiateManager.SpawnRequest request)
	{
	}

	// Token: 0x060023B2 RID: 9138 RVA: 0x000A9648 File Offset: 0x000A7848
	public override void OnSkillEvent_Local(SkillEvent _event, float _duration, Vector3 _vParam)
	{
		if (this.m_playerOwner.vmethod_25().IsMyActor())
		{
			if (this.m_eventMap.ContainsKey(_event))
			{
				this.m_eventMap[_event]();
			}
			if (_event == SkillEvent.CureHeartVFXOn)
			{
				base.method_6(true);
			}
			else if (_event == SkillEvent.CureHeartVFXOff)
			{
				base.method_6(false);
			}
			else
			{
				this.m_progressTimer_turretLife.method_4();
				this.m_progressTimer_cooldown.method_4();
				if (_event == SkillEvent.TurretSpawned)
				{
					this.m_progressTimer_turretLife.Start(_duration);
				}
				else if (_event == SkillEvent.TurretCooldownStart)
				{
					this.m_progressTimer_cooldown.Start(_duration);
				}
			}
			MonoSingleton<AppManager>.Instance.method_0().vmethod_5<HUDSkillStatusView>().OnSkillEvent(_event);
		}
	}

	// Token: 0x060023B3 RID: 9139 RVA: 0x000A96F4 File Offset: 0x000A78F4
	public override void OnSkillEvent_Client(SkillEvent _event, float _fParam, Vector3 _vParam)
	{
		Vector3 vector = _vParam + Vector3.up;
		if (_event == SkillEvent.TurretSpawned)
		{
			this.m_playerOwner.VFXManager_0.method_9(ENPCParticleType.E_TurretSpawn, vector, Quaternion.identity, true);
			if (this.m_playerOwner.PlayerEffectManager_0.method_0(EffectType.TurretDeployExplode) > 1f)
			{
				this.m_playerOwner.VFXManager_0.method_9(ENPCParticleType.E_Explode, vector, Quaternion.identity, true);
			}
			this.method_15(_vParam);
		}
		else if (_event == SkillEvent.TurretRetrieve)
		{
			this.m_playerOwner.VFXManager_0.method_8(ENPCParticleType.E_TurretOff, null, vector, Quaternion.identity, true);
			this.method_16();
		}
		else if (_event == SkillEvent.TurretRepulseExplode)
		{
			this.m_playerOwner.VFXManager_0.method_9(ENPCParticleType.E_Explode, vector, Quaternion.identity, true);
		}
	}

	// Token: 0x060023B4 RID: 9140 RVA: 0x000A97B0 File Offset: 0x000A79B0
	private void method_15(Vector3 vector3_0)
	{
		ENPCParticleType enpcparticleType = ENPCParticleType.E_TurretRegenAmmo;
		bool flag = this.m_playerOwner.PlayerEffectManager_0.method_0(EffectType.AmmoRegenAOE) > 0f;
		bool flag2 = this.m_playerOwner.PlayerEffectManager_0.method_0(EffectType.HealthRegenAOE) > 0f;
		if (!flag && !flag2)
		{
			return;
		}
		if (flag && !flag2)
		{
			enpcparticleType = ENPCParticleType.E_TurretRegenAmmo;
		}
		else if (!flag && flag2)
		{
			enpcparticleType = ENPCParticleType.E_TurretRegenHealth;
		}
		else if (flag && flag2)
		{
			enpcparticleType = ENPCParticleType.E_TurretRegenAmmoHealth;
		}
		this.m_playerOwner.VFXManager_0.method_10(enpcparticleType, vector3_0 + Vector3.up, true);
	}

	// Token: 0x060023B5 RID: 9141 RVA: 0x0001879B File Offset: 0x0001699B
	private void method_16()
	{
		this.m_playerOwner.VFXManager_0.method_13(ENPCParticleType.E_TurretRegenAmmo);
		this.m_playerOwner.VFXManager_0.method_13(ENPCParticleType.E_TurretRegenHealth);
		this.m_playerOwner.VFXManager_0.method_13(ENPCParticleType.E_TurretRegenAmmoHealth);
	}

	// Token: 0x0400183E RID: 6206
	private Utils.Timer m_firerate_timer = new Utils.Timer();

	// Token: 0x0400183F RID: 6207
	private Utils.Timer m_progressTimer_turretLife = new Utils.Timer();

	// Token: 0x04001840 RID: 6208
	private Utils.Timer m_progressTimer_cooldown = new Utils.Timer();
}
