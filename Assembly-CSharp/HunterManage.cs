using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using BHV_Skill;
using ns0;
using UnityEngine;
using XsdSettings;

// Token: 0x02000481 RID: 1153
public class HunterManage : PlayerSkillManage, InstantiateManager.InstanciationClient
{
	// Token: 0x06001E30 RID: 7728 RVA: 0x00096320 File Offset: 0x00094520
	public override void vmethod_0()
	{
		base.vmethod_0();
		this.m_skillId_begin_include = ESkillType.HunterFirstAction;
		this.m_skillId_end_exclude = ESkillType.Max;
		this.m_settings = base.method_1<BHVSkillSettingsHunter>();
		this.m_droidOffset_1st.Set(this.m_settings.m_offsetX_droid_1st, this.m_settings.m_offsetY_droid_1st, this.m_settings.m_offsetZ_droid_1st);
		this.m_droidOffset_3rd.Set(this.m_settings.m_offsetX_droid_3rd, this.m_settings.m_offsetY_droid_3rd, this.m_settings.m_offsetZ_droid_3rd);
		this.m_skillInfo.m_current_skillID = SkillID.Hunter;
	}

	// Token: 0x06001E31 RID: 7729 RVA: 0x000963BC File Offset: 0x000945BC
	public override void Update()
	{
		base.Update();
		base.OnUpdateProgress_Skill(this.m_progressTimer_droidLife.method_2());
		base.OnUpdateProgress_CoolDown(this.m_progressTimer_cooldown.method_2());
		if (this.m_playerOwner == null)
		{
			return;
		}
		if (this.m_spawnVfxTimer.method_7())
		{
			this.m_playerOwner.VFXManager_0.method_10(ENPCParticleType.E_HunterDroid_Spawn, this.method_16(ENPCParticleType.E_HunterDroid_Spawn), true);
		}
		bool flag = MarkCollect.MarkCollect_0.method_2();
		if (this.m_bMarking_lastTick != flag && this.m_droid != null)
		{
			if (flag)
			{
				Quaternion rotation = this.m_playerOwner.method_45().transform.rotation;
				this.m_playerOwner.VFXManager_0.method_9(ENPCParticleType.E_HunterDroid_Marking, this.method_16(ENPCParticleType.E_HunterDroid_Marking), rotation, true);
			}
			else
			{
				this.m_playerOwner.VFXManager_0.method_13(ENPCParticleType.E_HunterDroid_Marking);
			}
		}
		this.m_bMarking_lastTick = flag;
		if (!this.m_delay_vfx_disappear.method_7())
		{
		}
		if (this.m_playerOwner.method_47() != null)
		{
			VFXforNPC vfxforNPC = this.m_playerOwner.VFXManager_0.method_12(ENPCParticleType.E_Hunter_FullScreen, 0);
			if (vfxforNPC != null && vfxforNPC.m_particleGameObject != null)
			{
				if (this.m_playerOwner.method_47().IsRunning())
				{
					vfxforNPC.m_particleGameObject.transform.localPosition = this.m_VFXOffset_Sprint;
				}
				else
				{
					vfxforNPC.m_particleGameObject.transform.localPosition = this.m_VFXOffset_Normal;
				}
			}
		}
		this.method_23();
	}

	// Token: 0x06001E32 RID: 7730 RVA: 0x0001359C File Offset: 0x0001179C
	public override void OnTriggerAction(float _delay)
	{
		this.m_animDelay = _delay;
	}

	// Token: 0x06001E33 RID: 7731 RVA: 0x000152FC File Offset: 0x000134FC
	public override void OnSkillTask(ESkillStatePhase _phase)
	{
		if (_phase == ESkillStatePhase.First)
		{
			this.OnHunterTask_1st();
		}
		else if (_phase == ESkillStatePhase.Second)
		{
			this.OnHunterTask_2nd();
		}
	}

	// Token: 0x06001E34 RID: 7732 RVA: 0x000039EC File Offset: 0x00001BEC
	public override bool vmethod_3()
	{
		return true;
	}

	// Token: 0x06001E35 RID: 7733 RVA: 0x00015313 File Offset: 0x00013513
	public override void OnPlayerRespawn()
	{
		this.method_20();
	}

	// Token: 0x06001E36 RID: 7734 RVA: 0x0001531B File Offset: 0x0001351B
	public override void OnLeaveSession()
	{
		this.method_20();
		this.m_scriptOnVfxArray = null;
	}

	// Token: 0x06001E37 RID: 7735 RVA: 0x0001532A File Offset: 0x0001352A
	public override void OnEnterPlayerCripple()
	{
		this.method_21();
	}

	// Token: 0x06001E38 RID: 7736 RVA: 0x00013635 File Offset: 0x00011835
	public override void OnPostAssembly()
	{
		base.method_6(false);
		this.m_playerOwner.VFXManager_0.method_0(ENPCParticleType.E_Berserk_CureHeart, this.m_playerOwner.transform);
	}

	// Token: 0x06001E39 RID: 7737 RVA: 0x0000311B File Offset: 0x0000131B
	public override void vmethod_12(Entity entity_0, HitInfo hitInfo_0)
	{
	}

	// Token: 0x06001E3A RID: 7738 RVA: 0x0000311B File Offset: 0x0000131B
	public override void OnPlayerKillEnemy(Entity _enemy, KillContext _context)
	{
	}

	// Token: 0x06001E3B RID: 7739 RVA: 0x0000311B File Offset: 0x0000131B
	public override void OnDamaged(DamageContext context)
	{
	}

	// Token: 0x06001E3C RID: 7740 RVA: 0x00015332 File Offset: 0x00013532
	private void OnHunterTask_1st()
	{
		this.method_18();
		this.method_15();
	}

	// Token: 0x06001E3D RID: 7741 RVA: 0x00096528 File Offset: 0x00094728
	private void OnHunterTask_2nd()
	{
		this.method_19();
		this.m_playerOwner.VFXManager_0.method_10(ENPCParticleType.E_HunterDroid_SecondAction, this.method_16(ENPCParticleType.E_HunterDroid_SecondAction), true);
		this.m_delay_vfx_disappear.Start(this.m_settings.m_retrievedroid_delay);
		foreach (Entity entity in MarkManager.MarkManager_0.m_titleCrl.method_3())
		{
			if (entity != null)
			{
				WeakPoint weakPoint = null;
				entity.method_8(out weakPoint);
				entity.vmethod_15().method_5(ENPCParticleType.E_Marked_Slag, entity, weakPoint.transform, Vector3.zero, Quaternion.identity, 0f, true);
			}
		}
	}

	// Token: 0x06001E3E RID: 7742 RVA: 0x0000311B File Offset: 0x0000131B
	public void OnInstanciate(GameObject instance, InstantiateManager.SpawnRequest request)
	{
	}

	// Token: 0x06001E3F RID: 7743 RVA: 0x00015340 File Offset: 0x00013540
	public void method_11(HunterDroid hunterDroid_0)
	{
		this.m_droid = hunterDroid_0;
		this.m_skill_active_local = true;
	}

	// Token: 0x06001E40 RID: 7744 RVA: 0x000965F0 File Offset: 0x000947F0
	public override void OnSkillEvent_Local(SkillEvent _event, float _duration, Vector3 _vParam)
	{
		if (_event == SkillEvent.HunterExplodeWhenMarkedKilled)
		{
			return;
		}
		if (_event == SkillEvent.HunterSkillDurationExtend)
		{
			this.m_progressTimer_droidLife.method_10(_duration);
			return;
		}
		if (_event == SkillEvent.HunterCooldownJump)
		{
			this.m_progressTimer_cooldown.method_9(_duration);
		}
		else
		{
			this.m_progressTimer_cooldown.method_4();
		}
		this.m_progressTimer_droidLife.method_4();
		if (_event == SkillEvent.HunterDroidSpawned)
		{
			this.m_progressTimer_droidLife.Start(_duration);
			if (MonoSingleton<GraphicsMgr>.Instance != null)
			{
				MonoSingleton<GraphicsMgr>.Instance.method_24().method_4(this.m_playerOwner, ENPCParticleType.E_Hunter_FullScreen, this.m_VFXOffset_Normal, Quaternion.Euler(0f, 180f, 180f), 0f);
			}
			VFXforNPC vfxforNPC = this.m_playerOwner.VFXManager_0.method_12(ENPCParticleType.E_Hunter_FullScreen, 0);
			if (vfxforNPC != null && vfxforNPC.m_particleGameObject != null)
			{
				if (this.m_scriptOnVfxArray == null)
				{
					this.m_scriptOnVfxArray = vfxforNPC.m_particleGameObject.GetComponentsInChildren<HunterSkill_Script>();
				}
				for (int i = 0; i < this.m_scriptOnVfxArray.Length; i++)
				{
					this.m_scriptOnVfxArray[i].method_0();
				}
			}
		}
		else if (_event == SkillEvent.HunterCooldownStart)
		{
			this.m_progressTimer_cooldown.Start(_duration);
		}
		else if (_event == SkillEvent.HunterDroidEnd)
		{
			MarkManager.MarkManager_0.m_markProgress_client = 0;
			this.m_skill_active_local = false;
			if (MonoSingleton<GraphicsMgr>.Instance != null)
			{
				MonoSingleton<GraphicsMgr>.Instance.method_24().method_2(this.m_playerOwner, ENPCParticleType.E_Hunter_FullScreen);
			}
		}
		else if (_event == SkillEvent.HunterMarkInView)
		{
			this.method_12();
		}
		MonoSingleton<AppManager>.Instance.method_0().vmethod_5<HUDSkillStatusView>().OnSkillEvent(_event);
	}

	// Token: 0x06001E41 RID: 7745 RVA: 0x00096770 File Offset: 0x00094970
	public override void OnSkillEvent_Client(SkillEvent _event, float _fParam, Vector3 _vParam)
	{
		if (_event == SkillEvent.HunterDroidEnd)
		{
			this.m_playerOwner.VFXManager_0.method_13(ENPCParticleType.E_HunterDroid_Marking);
			this.m_playerOwner.VFXManager_0.method_10(ENPCParticleType.E_HunterDroid_Disappear, this.method_16(ENPCParticleType.E_HunterDroid_Disappear), true);
		}
		else if (_event == SkillEvent.HunterExplodeWhenMarkedKilled)
		{
			this.m_playerOwner.VFXManager_0.method_10(ENPCParticleType.E_Explode, _vParam, true);
		}
	}

	// Token: 0x06001E42 RID: 7746 RVA: 0x000967D0 File Offset: 0x000949D0
	private void method_12()
	{
		this.m_entityInViewList.Clear();
		foreach (Entity entity in DamageManager.DamageManager_0.method_0())
		{
			if ((entity is EntityNpc || entity is EntityPlayer) && !this.method_13(entity) && !(entity.vmethod_19() == null) && entity.vmethod_19().vmethod_4() > 0 && !MarkManager.MarkManager_0.m_titleCrl.method_1(entity) && this.method_24(entity))
			{
				this.m_entityInViewList.Add(entity);
			}
		}
		if (this.m_entityInViewList.Count <= 0)
		{
			return;
		}
		int num = (int)this.m_playerOwner.PlayerEffectManager_0.method_0(EffectType.MultiMarkCount);
		if (this.m_entityInViewList.Count <= num)
		{
			using (List<Entity>.Enumerator enumerator2 = this.m_entityInViewList.GetEnumerator())
			{
				while (enumerator2.MoveNext())
				{
					Entity entity2 = enumerator2.Current;
					MarkCollect.MarkCollect_0.method_5(entity2, this.m_playerOwner);
				}
				return;
			}
		}
		this.m_entityInViewList = this.m_entityInViewList.OrderBy<Entity, float>(new Func<Entity, float>(this.method_25)).ToList<Entity>();
		for (int i = 0; i < num; i++)
		{
			MarkCollect.MarkCollect_0.method_5(this.m_entityInViewList[i], this.m_playerOwner);
		}
	}

	// Token: 0x06001E43 RID: 7747 RVA: 0x00015350 File Offset: 0x00013550
	private bool method_13(Entity entity_0)
	{
		return this.m_playerOwner == entity_0 || (entity_0.vmethod_9() == this.m_playerOwner.vmethod_9() && !this.m_playerOwner.vmethod_47());
	}

	// Token: 0x06001E44 RID: 7748 RVA: 0x00015385 File Offset: 0x00013585
	public bool method_14()
	{
		return this.m_skill_active_local;
	}

	// Token: 0x06001E45 RID: 7749 RVA: 0x0001538D File Offset: 0x0001358D
	private void method_15()
	{
		this.m_spawnVfxTimer.Start(this.m_settings.m_spawnVfx_delay);
	}

	// Token: 0x06001E46 RID: 7750 RVA: 0x00096954 File Offset: 0x00094B54
	private Vector3 method_16(ENPCParticleType enpcparticleType_0)
	{
		Vector3 vector = this.m_playerOwner.transform.position;
		Vector3 vector2 = Vector3.zero;
		switch (enpcparticleType_0)
		{
		case ENPCParticleType.E_HunterDroid_Spawn:
			vector2.y = -0.3f;
			vector += this.m_playerOwner.transform.TransformDirection(this.method_22() + vector2);
			break;
		case ENPCParticleType.E_HunterDroid_Marking:
			vector2 = this.m_droid.transform.TransformDirection(new Vector3(-0.05f, 0.08f, 0.22f));
			vector += this.m_playerOwner.transform.TransformDirection(this.method_22());
			vector += vector2;
			break;
		case ENPCParticleType.E_HunterDroid_SecondAction:
			vector += this.m_playerOwner.transform.TransformDirection(this.method_22());
			break;
		case ENPCParticleType.E_HunterDroid_Disappear:
			vector += this.m_playerOwner.transform.TransformDirection(this.method_22());
			break;
		}
		return vector;
	}

	// Token: 0x06001E47 RID: 7751 RVA: 0x0000311B File Offset: 0x0000131B
	public void method_17()
	{
	}

	// Token: 0x06001E48 RID: 7752 RVA: 0x00096A58 File Offset: 0x00094C58
	private void method_18()
	{
		AnimationPlayerReleaseDroidState animationPlayerReleaseDroidState = this.m_animationMgr.method_16(Utils.smethod_23(AnimationStateFSM.PlayerReleaseDroid)) as AnimationPlayerReleaseDroidState;
		animationPlayerReleaseDroidState.m_netLatency = this.m_animDelay;
		animationPlayerReleaseDroidState.method_22(this.m_animationMgr.method_55());
		this.m_animationMgr.method_31(AnimationStateFSM.PlayerReleaseDroid);
	}

	// Token: 0x06001E49 RID: 7753 RVA: 0x00096AA8 File Offset: 0x00094CA8
	private void method_19()
	{
		AnimationPlayerRetrieveDroidState animationPlayerRetrieveDroidState = this.m_animationMgr.method_16(Utils.smethod_23(AnimationStateFSM.PlayerRetrieveDroid)) as AnimationPlayerRetrieveDroidState;
		animationPlayerRetrieveDroidState.m_netLatency = this.m_animDelay;
		animationPlayerRetrieveDroidState.method_22(this.m_animationMgr.method_55());
		this.m_animationMgr.method_31(AnimationStateFSM.PlayerRetrieveDroid);
	}

	// Token: 0x06001E4A RID: 7754 RVA: 0x00015313 File Offset: 0x00013513
	public override void OnPlayerSuicide()
	{
		this.method_20();
	}

	// Token: 0x06001E4B RID: 7755 RVA: 0x00096AF8 File Offset: 0x00094CF8
	private void method_20()
	{
		this.m_skill_active_local = false;
		base.OnSkillEvent(SkillEvent.HunterCooldownEnd);
		base.OnSkillEvent(SkillEvent.HunterCooldownStart);
		if (MonoSingleton<GraphicsMgr>.Instance)
		{
			MonoSingleton<GraphicsMgr>.Instance.method_24().method_2(this.m_playerOwner, ENPCParticleType.E_Hunter_FullScreen);
		}
		this.m_playerOwner.VFXManager_0.method_13(ENPCParticleType.E_HunterDroid_Marking);
		MonoSingleton<AppManager>.Instance.method_0().vmethod_5<HUDSkillStatusView>().OnSkillEvent(SkillEvent.HunterDroidEnd);
		this.m_progressTimer_droidLife.method_4();
	}

	// Token: 0x06001E4C RID: 7756 RVA: 0x00096AF8 File Offset: 0x00094CF8
	private void method_21()
	{
		this.m_skill_active_local = false;
		base.OnSkillEvent(SkillEvent.HunterCooldownEnd);
		base.OnSkillEvent(SkillEvent.HunterCooldownStart);
		if (MonoSingleton<GraphicsMgr>.Instance)
		{
			MonoSingleton<GraphicsMgr>.Instance.method_24().method_2(this.m_playerOwner, ENPCParticleType.E_Hunter_FullScreen);
		}
		this.m_playerOwner.VFXManager_0.method_13(ENPCParticleType.E_HunterDroid_Marking);
		MonoSingleton<AppManager>.Instance.method_0().vmethod_5<HUDSkillStatusView>().OnSkillEvent(SkillEvent.HunterDroidEnd);
		this.m_progressTimer_droidLife.method_4();
	}

	// Token: 0x06001E4D RID: 7757 RVA: 0x000153A5 File Offset: 0x000135A5
	public Vector3 method_22()
	{
		return (!this.m_playerOwner.vmethod_25().IsMyActor()) ? this.m_droidOffset_3rd : this.m_droidOffset_1st;
	}

	// Token: 0x06001E4E RID: 7758 RVA: 0x000153C7 File Offset: 0x000135C7
	[RPC]
	private void RPC_RegisterMarked(int _id, PhotonMessageInfo _info)
	{
		if (this.m_playerOwner.vmethod_25().IsMyActor())
		{
			this.m_local_markedList.Add(new HunterManage.LocalMarkedViewInfo(_id, Time.time));
		}
	}

	// Token: 0x06001E4F RID: 7759 RVA: 0x00096B74 File Offset: 0x00094D74
	private void method_23()
	{
		if (!this.m_playerOwner.vmethod_25().IsMyActor())
		{
			return;
		}
		int num = Time.frameCount % 3;
		for (int i = this.m_local_markedList.Count - 1; i >= 0; i--)
		{
			if (!MarkManager.MarkManager_0.m_titleCrl.method_2(this.m_local_markedList[i].m_id))
			{
				this.m_local_markedList.RemoveAt(i);
			}
			else
			{
				HunterManage.LocalMarkedViewInfo localMarkedViewInfo = this.m_local_markedList[i];
				Entity entity = BadAssNetworkView.smethod_4(localMarkedViewInfo.m_id);
				if (!(entity == null) && !entity.vmethod_53())
				{
					if (num == i && this.method_24(entity))
					{
						localMarkedViewInfo.m_lastInViewTime = Time.time;
					}
					if (Time.time - localMarkedViewInfo.m_lastInViewTime > 5f)
					{
						object[] array = new object[] { localMarkedViewInfo.m_id };
						base.photonView.method_4("RPC_CanNotSeeMarked", PhotonTargets.MasterClient, array);
						this.m_local_markedList.RemoveAt(i);
					}
				}
				else
				{
					this.m_local_markedList.RemoveAt(i);
				}
			}
		}
	}

	// Token: 0x06001E50 RID: 7760 RVA: 0x00096C88 File Offset: 0x00094E88
	private bool method_24(Entity entity_0)
	{
		if (!Utils.smethod_24(this.m_playerOwner.method_45().camera, entity_0.transform.position))
		{
			return false;
		}
		Vector3 vector = this.m_playerOwner.vmethod_28();
		Vector3 normalized = (entity_0.vmethod_23() - vector).normalized;
		Collider collider = null;
		float maxValue = float.MaxValue;
		Entity entity = TargetingService.smethod_1(this.m_playerOwner.vmethod_28(), normalized, this.m_playerOwner, out collider, ref maxValue, ColliderType.WeakPoint, false);
		return entity != null && entity == entity_0;
	}

	// Token: 0x06001E51 RID: 7761 RVA: 0x000153F1 File Offset: 0x000135F1
	[CompilerGenerated]
	private float method_25(Entity entity_0)
	{
		return Vector3.Distance(this.m_playerOwner.transform.position, entity_0.transform.position);
	}

	// Token: 0x040013BE RID: 5054
	private bool m_bMarking_lastTick;

	// Token: 0x040013BF RID: 5055
	private Utils.Timer m_delay_vfx_disappear = new Utils.Timer();

	// Token: 0x040013C0 RID: 5056
	private Vector3 m_VFXOffset_Normal = new Vector3(0f, 0f, 1.65f);

	// Token: 0x040013C1 RID: 5057
	private Vector3 m_VFXOffset_Sprint = new Vector3(0f, 0f, 1.43f);

	// Token: 0x040013C2 RID: 5058
	[HideInInspector]
	public BHVSkillSettingsHunter m_settings;

	// Token: 0x040013C3 RID: 5059
	private HunterDroid m_droid;

	// Token: 0x040013C4 RID: 5060
	private Utils.Timer m_progressTimer_droidLife = new Utils.Timer();

	// Token: 0x040013C5 RID: 5061
	private Utils.Timer m_progressTimer_cooldown = new Utils.Timer();

	// Token: 0x040013C6 RID: 5062
	private HunterSkill_Script[] m_scriptOnVfxArray;

	// Token: 0x040013C7 RID: 5063
	private List<Entity> m_entityInViewList = new List<Entity>();

	// Token: 0x040013C8 RID: 5064
	private bool m_skill_active_local;

	// Token: 0x040013C9 RID: 5065
	private Utils.Timer m_spawnVfxTimer = new Utils.Timer();

	// Token: 0x040013CA RID: 5066
	private Vector3 m_droidOffset_1st = Vector3.zero;

	// Token: 0x040013CB RID: 5067
	private Vector3 m_droidOffset_3rd = Vector3.zero;

	// Token: 0x040013CC RID: 5068
	private List<HunterManage.LocalMarkedViewInfo> m_local_markedList = new List<HunterManage.LocalMarkedViewInfo>();

	// Token: 0x02000482 RID: 1154
	public class LocalMarkedViewInfo
	{
		// Token: 0x06001E52 RID: 7762 RVA: 0x00015413 File Offset: 0x00013613
		public LocalMarkedViewInfo(int int_0, float float_0)
		{
			this.m_id = int_0;
			this.m_lastInViewTime = float_0;
		}

		// Token: 0x040013CD RID: 5069
		public int m_id;

		// Token: 0x040013CE RID: 5070
		public float m_lastInViewTime;
	}
}
