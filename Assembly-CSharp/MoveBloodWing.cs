using System;
using BHV_Skill;
using Photon;
using UnityEngine;
using XsdSettings;

// Token: 0x0200053C RID: 1340
public class MoveBloodWing : global::Photon.MonoBehaviour
{
	// Token: 0x06002299 RID: 8857 RVA: 0x00017BDE File Offset: 0x00015DDE
	private void Awake()
	{
		this.m_animator = base.GetComponent<Animator>();
		this.m_vfxMgr = base.GetComponent<VFXManager>();
	}

	// Token: 0x0600229A RID: 8858 RVA: 0x000A4260 File Offset: 0x000A2460
	private void Start()
	{
		this.method_13();
		this.method_0();
		this.m_owner_player.PlayerSkillManage_0.OnSkillEvent(SkillEvent.FireBirdSpawn);
		this.m_bFirstTick = true;
		this.method_10();
		if (this.m_owner_player.SkillTreeStatus_0.method_1(ESkillType.Ignition))
		{
			this.m_owner_player.PlayerSkillManage_0.method_6(true);
		}
	}

	// Token: 0x0600229B RID: 8859 RVA: 0x000A42BC File Offset: 0x000A24BC
	private void method_0()
	{
		this.m_setting = this.m_owner_player.PlayerSkillManage_0.method_1<BHVSkillSettingsFireBird>();
		this.m_flyaway_duration = this.method_27();
		this.m_flyaway_leftTime = this.m_flyaway_duration;
		base.transform.localScale *= this.m_setting.m_sizeScale;
		Transform transform = this.m_owner_player.GetComponent<PlayerController>().method_12();
		base.transform.position = transform.position + transform.TransformDirection(this.m_offset_spawnpoint);
		this.m_progress = 0f;
		base.transform.LookAt(transform.position + transform.TransformDirection(Vector3.up).normalized * 100f);
	}

	// Token: 0x0600229C RID: 8860 RVA: 0x000A438C File Offset: 0x000A258C
	private void FixedUpdate()
	{
		if (base.gameObject == null)
		{
			return;
		}
		if (base.transform == null)
		{
			return;
		}
		if (this.m_target == MoveBloodWing.TargetType.FlyingAway)
		{
			Vector3 vector = base.transform.forward * this.m_setting.m_flyaway_velocity * Time.deltaTime;
			base.transform.Translate(vector, Space.World);
			this.m_flyaway_leftTime -= Time.deltaTime;
			this.m_progress = Mathf.Clamp(1f - this.m_flyaway_leftTime / this.m_flyaway_duration, 0f, 1f);
			if (this.m_flyaway_leftTime <= 0f)
			{
				this.m_progress = 1f;
				FirebirdManage.smethod_2("[FlyingAway]  OnSkillEvent(SkillEvent.FirebirdReachEnd)");
				this.m_owner_player.PlayerSkillManage_0.OnSkillEvent(SkillEvent.FirebirdReachEnd);
				if (this.m_target == MoveBloodWing.TargetType.FlyingAway)
				{
					FirebirdManage.smethod_2("[FlyingAway]  Error! Still in FlyingAway");
					this.OnLifeEnd(MoveBloodWing.LifeEndType.FlyBack);
				}
			}
		}
		else if (this.m_target == MoveBloodWing.TargetType.Chase)
		{
			if (this.m_chase_target == null || this.m_chase_target.transform == null)
			{
				this.m_progress = 1f;
				this.m_owner_player.PlayerSkillManage_0.OnSkillEvent(SkillEvent.FirebirdReachEnd);
				return;
			}
			base.transform.position = this.m_chase_target.transform.position - this.m_chaseHoverDir * this.m_chase_radius;
			this.m_flyaway_leftTime -= Time.deltaTime;
			this.m_progress = Mathf.Clamp(1f - this.m_flyaway_leftTime / this.m_flyaway_duration, 0f, 1f);
			if (this.m_flyaway_leftTime <= 0f)
			{
				this.m_progress = 1f;
				FirebirdManage.smethod_2("[Chase]  OnSkillEvent(SkillEvent.FirebirdReachEnd)");
				this.m_owner_player.PlayerSkillManage_0.OnSkillEvent(SkillEvent.FirebirdReachEnd);
			}
			this.method_1();
		}
		else if (this.m_target == MoveBloodWing.TargetType.FlyingBack)
		{
			Vector3 vector2 = this.method_18();
			Vector3 normalized = (vector2 - base.transform.position).normalized;
			Vector3 vector3 = normalized * this.method_26() * Time.deltaTime;
			base.transform.Translate(vector3, Space.World);
			base.transform.LookAt(vector2);
			Vector3 vector4 = this.method_18();
			float num = Vector3.Distance(base.transform.position, this.m_pos_whenFlyBack);
			float num2 = Vector3.Distance(vector4, this.m_pos_whenFlyBack) - this.m_setting.m_radius_recall;
			this.m_progress = Mathf.Clamp(num / num2, 0f, 1f);
			float num3 = Vector3.Distance(vector4, base.transform.position);
			if (num3 < this.m_setting.m_radius_recall)
			{
				FirebirdManage.smethod_2("[FlyingBack]  OnLifeEnd(LifeEndType.FlyBack)");
				this.m_progress = 1f;
				this.m_vfxMgr.method_4(ENPCParticleType.E_FireBird_Absorb, 0f, true);
				this.OnLifeEnd(MoveBloodWing.LifeEndType.FlyBack);
			}
		}
		else if (this.m_target == MoveBloodWing.TargetType.Hover)
		{
			this.m_flyaway_leftTime -= Time.deltaTime;
			this.m_progress = Mathf.Clamp(1f - this.m_flyaway_leftTime / this.m_flyaway_duration, 0f, 1f);
			if (this.m_flyaway_leftTime <= 0f)
			{
				FirebirdManage.smethod_2("[Hover]  OnSkillEvent(SkillEvent.FirebirdReachEnd)");
				this.m_progress = 1f;
				this.m_owner_player.PlayerSkillManage_0.OnSkillEvent(SkillEvent.FirebirdReachEnd);
			}
			this.method_1();
			Vector3 vector5 = base.transform.up * 0.25f * Time.deltaTime;
			base.transform.Translate(vector5, Space.World);
			base.transform.LookAt(this.method_18());
		}
		else if (this.m_target == MoveBloodWing.TargetType.HurtZone)
		{
			this.m_flyaway_leftTime -= Time.deltaTime;
			this.m_progress = Mathf.Clamp(1f - this.m_flyaway_leftTime / this.m_flyaway_duration, 0f, 1f);
			if (this.m_flyaway_leftTime <= 0f)
			{
				FirebirdManage.smethod_2("[Hover]  OnSkillEvent(SkillEvent.FirebirdReachEnd)");
				this.m_progress = 1f;
				this.m_owner_player.PlayerSkillManage_0.OnSkillEvent(SkillEvent.FirebirdReachEnd);
			}
		}
	}

	// Token: 0x0600229D RID: 8861 RVA: 0x000A47CC File Offset: 0x000A29CC
	private void method_1()
	{
		this.m_flashVfxTime -= Time.deltaTime;
		if (this.m_flashVfxTime <= 0f)
		{
			this.m_flashVfxTime = this.m_flashVfxPeriod;
			this.m_vfxMgr.method_4(ENPCParticleType.E_FireBird_Flash, 0f, true);
		}
	}

	// Token: 0x0600229E RID: 8862 RVA: 0x00017BF8 File Offset: 0x00015DF8
	private void Update()
	{
		this.method_2();
		this.method_5();
		this.method_6();
		this.method_3();
		this.method_7();
	}

	// Token: 0x0600229F RID: 8863 RVA: 0x000A4818 File Offset: 0x000A2A18
	private void method_2()
	{
		if (this.m_bFirstTick)
		{
			this.m_bFirstTick = false;
			this.m_vfxMgr.method_0(ENPCParticleType.E_FireBird_Tailing, base.transform);
			this.m_vfxMgr.method_0(ENPCParticleType.E_FireBird_WingTips_L, base.transform);
			this.m_vfxMgr.method_0(ENPCParticleType.E_FireBird_WingTips_R, base.transform);
		}
	}

	// Token: 0x060022A0 RID: 8864 RVA: 0x00017C18 File Offset: 0x00015E18
	private void method_3()
	{
		this.m_owner_player.PlayerSkillManage_0.OnUpdateProgress_Skill(this.m_progress);
	}

	// Token: 0x060022A1 RID: 8865 RVA: 0x00017C30 File Offset: 0x00015E30
	private void method_4()
	{
		if (this.m_target == MoveBloodWing.TargetType.Dead)
		{
			this.m_delay_networkDestroy -= Time.deltaTime;
			if (this.m_delay_networkDestroy <= 0f)
			{
				this.method_21();
			}
		}
	}

	// Token: 0x060022A2 RID: 8866 RVA: 0x000A4870 File Offset: 0x000A2A70
	private void method_5()
	{
		if (this.m_target == MoveBloodWing.TargetType.Dive)
		{
			this.m_animatorInfo = this.m_animator.GetCurrentAnimatorStateInfo(0);
			if (this.m_animatorInfo.IsTag("End"))
			{
				FirebirdManage.smethod_2("[Update_DiveAnim  IsTag(End)]  OnLifeEnd(LifeEndType.Explosion)");
				this.OnLifeEnd(MoveBloodWing.LifeEndType.Explosion);
				return;
			}
			if (!this.m_animatorInfo.IsTag("Dive"))
			{
				return;
			}
			if (this.m_startTime_dive < 0f)
			{
				this.m_startTime_dive = Time.time;
				this.m_length_dive = this.m_animatorInfo.length;
			}
			if (this.method_25(0.95f))
			{
				FirebirdManage.smethod_2("[Update_DiveAnim AtAnimLength(0.95f)]  OnLifeEnd(LifeEndType.Explosion)");
				this.OnLifeEnd(MoveBloodWing.LifeEndType.Explosion);
			}
		}
	}

	// Token: 0x060022A3 RID: 8867 RVA: 0x000A491C File Offset: 0x000A2B1C
	private void method_6()
	{
		if (this.m_target == MoveBloodWing.TargetType.TurningBack)
		{
			this.m_animatorInfo = this.m_animator.GetCurrentAnimatorStateInfo(0);
			if (this.m_animatorInfo.IsTag("End"))
			{
				FirebirdManage.smethod_2("[Update_TurnBackAnim  IsTag(End)]  OnLifeEnd(LifeEndType.Explosion)");
				this.OnLifeEnd(MoveBloodWing.LifeEndType.Explosion);
				return;
			}
			if (!this.m_animatorInfo.IsTag("ReCall"))
			{
				return;
			}
			if (this.m_startTime_dive < 0f)
			{
				this.m_startTime_dive = Time.time;
				this.m_length_dive = this.m_animatorInfo.length;
			}
			if (this.method_25(0.8f))
			{
				FirebirdManage.smethod_2("[Update_TurnBackAnim AtAnimLength(0.8f)]  OnFlyBack()");
				this.m_animator.SetBool("bReCall", false);
				this.OnFlyBack();
			}
		}
	}

	// Token: 0x060022A4 RID: 8868 RVA: 0x000A49D8 File Offset: 0x000A2BD8
	public void OnLifeEnd(MoveBloodWing.LifeEndType _type)
	{
		FirebirdManage.smethod_2("[OnLifeEnd] Enter");
		this.method_17(MoveBloodWing.TargetType.Dead);
		this.method_20();
		if (_type == MoveBloodWing.LifeEndType.Explosion)
		{
			this.method_8();
			FirebirdManage.smethod_2("[OnLifeEnd] OnSkillEvent(SkillEvent.FireBirdExplode)");
			this.m_owner_player.PlayerSkillManage_0.OnSkillEvent(SkillEvent.FireBirdExplode);
		}
		else if (_type == MoveBloodWing.LifeEndType.FlyBack)
		{
			FirebirdManage.smethod_2("[OnLifeEnd] OnSkillEvent(SkillEvent.FireBirdAbsorb)");
			this.m_owner_player.PlayerSkillManage_0.OnSkillEvent(SkillEvent.FireBirdAbsorb);
		}
		try
		{
			this.m_animator.speed = 1f;
		}
		catch (Exception)
		{
		}
	}

	// Token: 0x060022A5 RID: 8869 RVA: 0x000A4A68 File Offset: 0x000A2C68
	private void method_7()
	{
		if (this.m_chainTimer.method_7() && this.m_chainNum > 0)
		{
			this.m_chainNum--;
			if (this.m_chainNum > 0)
			{
				this.m_chainTimer.Start(this.m_setting.m_chainInterval);
			}
			this.method_9(this.method_11(this.m_chainNum));
		}
	}

	// Token: 0x060022A6 RID: 8870 RVA: 0x000A4ACC File Offset: 0x000A2CCC
	private void method_8()
	{
		this.method_9(base.transform.position);
		this.m_chainNum = (int)this.m_owner_player.PlayerEffectManager_0.method_0(EffectType.FirebirdExplodeChainNum);
		if (this.m_chainNum > 0)
		{
			this.m_chainTimer.Start(this.m_setting.m_chainInterval);
		}
	}

	// Token: 0x060022A7 RID: 8871 RVA: 0x00017C60 File Offset: 0x00015E60
	private void method_9(Vector3 vector3_0)
	{
		this.m_vfxMgr.method_6(ENPCParticleType.E_FireBird_Burst, vector3_0, Quaternion.identity, 0f, true);
	}

	// Token: 0x060022A8 RID: 8872 RVA: 0x000A4B24 File Offset: 0x000A2D24
	private void method_10()
	{
		if (base.photonView.Object_0 != null)
		{
			this.m_chainRandomAngles[0] = (int)base.photonView.Object_0[1];
			this.m_chainRandomAngles[1] = (int)base.photonView.Object_0[2];
			this.m_chainRandomAngles[2] = (int)base.photonView.Object_0[3];
		}
	}

	// Token: 0x060022A9 RID: 8873 RVA: 0x000A4B8C File Offset: 0x000A2D8C
	private Vector3 method_11(int int_0)
	{
		float num = (float)this.m_chainRandomAngles[int_0];
		Quaternion quaternion = Quaternion.AngleAxis(num, Vector3.up);
		return base.transform.position + quaternion * (Vector3.forward * this.m_setting.m_chainRadius);
	}

	// Token: 0x060022AA RID: 8874 RVA: 0x000A4BDC File Offset: 0x000A2DDC
	private void OnTriggerEnter(Collider other)
	{
		if (this.m_owner_player == null)
		{
			return;
		}
		if (this.m_target != MoveBloodWing.TargetType.Dive && this.m_target != MoveBloodWing.TargetType.Dead)
		{
			if (this.m_target != MoveBloodWing.TargetType.TurningBack)
			{
				switch (this.method_12(other.gameObject))
				{
				case MoveBloodWing.ColliderType.Enviorment:
					this.m_owner_player.PlayerSkillManage_0.OnSkillEvent(SkillEvent.FirebirdCollideEnviorment);
					break;
				}
				return;
			}
		}
	}

	// Token: 0x060022AB RID: 8875 RVA: 0x000A4C50 File Offset: 0x000A2E50
	private MoveBloodWing.ColliderType method_12(GameObject gameObject_0)
	{
		string text = LayerMask.LayerToName(gameObject_0.layer);
		if (text.Equals("Default"))
		{
			if (gameObject_0.GetComponent<EntityNpc>() != null)
			{
				return MoveBloodWing.ColliderType.Npc;
			}
			if (gameObject_0.GetComponent<MinimapSwitch>() != null)
			{
				return MoveBloodWing.ColliderType.Unknown;
			}
			return MoveBloodWing.ColliderType.Enviorment;
		}
		else
		{
			if (text.Equals("Walkable"))
			{
				return MoveBloodWing.ColliderType.Enviorment;
			}
			return MoveBloodWing.ColliderType.Unknown;
		}
	}

	// Token: 0x060022AC RID: 8876 RVA: 0x000A4CA8 File Offset: 0x000A2EA8
	private void method_13()
	{
		if (base.photonView.Object_0 != null)
		{
			int num = (int)base.photonView.Object_0[0];
			this.m_owner_player = BadAssNetworkView.smethod_4(num) as EntityPlayer;
			FirebirdManage.smethod_2("[SetOwner] SetFirebird(this)");
			this.m_owner_player.PlayerSkillManage_0.vmethod_6(this);
		}
	}

	// Token: 0x060022AD RID: 8877 RVA: 0x00017C7C File Offset: 0x00015E7C
	public EntityPlayer method_14()
	{
		return this.m_owner_player;
	}

	// Token: 0x060022AE RID: 8878 RVA: 0x00017C84 File Offset: 0x00015E84
	public bool method_15()
	{
		return this.m_target == MoveBloodWing.TargetType.FlyingAway;
	}

	// Token: 0x060022AF RID: 8879 RVA: 0x00017C8F File Offset: 0x00015E8F
	public void OnFlyBack()
	{
		FirebirdManage.smethod_2("[OnFlyBack]");
		this.method_17(MoveBloodWing.TargetType.FlyingBack);
		this.m_pos_whenFlyBack = base.transform.position;
		this.m_progress = 0f;
	}

	// Token: 0x060022B0 RID: 8880 RVA: 0x00017CBE File Offset: 0x00015EBE
	public void OnTurnBack()
	{
		this.m_progress = 0f;
		this.method_23();
	}

	// Token: 0x060022B1 RID: 8881 RVA: 0x00017CD1 File Offset: 0x00015ED1
	public MoveBloodWing.TargetType method_16()
	{
		return this.m_target;
	}

	// Token: 0x060022B2 RID: 8882 RVA: 0x00017CD9 File Offset: 0x00015ED9
	private void method_17(MoveBloodWing.TargetType targetType_0)
	{
		FirebirdManage.smethod_2("[SetPhase] " + targetType_0);
		this.m_target = targetType_0;
	}

	// Token: 0x060022B3 RID: 8883 RVA: 0x000A4D04 File Offset: 0x000A2F04
	private Vector3 method_18()
	{
		if (this.m_playercontroller == null)
		{
			this.m_playercontroller = this.m_owner_player.GetComponent<PlayerController>();
		}
		return this.m_owner_player.transform.position + Vector3.up * this.m_playercontroller.method_25();
	}

	// Token: 0x060022B4 RID: 8884 RVA: 0x00017CF7 File Offset: 0x00015EF7
	public bool method_19()
	{
		return this.m_target == MoveBloodWing.TargetType.Dead;
	}

	// Token: 0x060022B5 RID: 8885 RVA: 0x000A4D5C File Offset: 0x000A2F5C
	private void method_20()
	{
		foreach (SkinnedMeshRenderer renderer in base.GetComponentsInChildren<SkinnedMeshRenderer>())
		{
			renderer.enabled = false;
		}
		this.m_vfxMgr.method_13(ENPCParticleType.E_FireBird_WingTips_L);
		this.m_vfxMgr.method_13(ENPCParticleType.E_FireBird_WingTips_R);
		this.m_vfxMgr.method_1(ENPCParticleType.E_FireBird_Tailing);
		this.m_owner_player.PlayerSkillManage_0.method_6(false);
	}

	// Token: 0x060022B6 RID: 8886 RVA: 0x0000311B File Offset: 0x0000131B
	private void method_21()
	{
	}

	// Token: 0x060022B7 RID: 8887 RVA: 0x00017D02 File Offset: 0x00015F02
	private void OnDestroy()
	{
		if (this.m_owner_player != null)
		{
			this.m_owner_player.PlayerSkillManage_0.OnSkillEvent(SkillEvent.FirebirdDestroyed);
		}
	}

	// Token: 0x060022B8 RID: 8888 RVA: 0x000A4DC4 File Offset: 0x000A2FC4
	public void method_22()
	{
		FirebirdManage.smethod_2("[PlayAnim_Dive]");
		this.method_17(MoveBloodWing.TargetType.Dive);
		this.m_animator.SetBool("bDive", true);
		try
		{
			this.m_animator.speed = 8f;
		}
		catch (Exception)
		{
		}
	}

	// Token: 0x060022B9 RID: 8889 RVA: 0x00017D24 File Offset: 0x00015F24
	private void method_23()
	{
		FirebirdManage.smethod_2("[PlayAnim_TurnBack]");
		this.method_17(MoveBloodWing.TargetType.TurningBack);
		this.m_animator.SetBool("bReCall", true);
	}

	// Token: 0x060022BA RID: 8890 RVA: 0x00017D48 File Offset: 0x00015F48
	public void method_24()
	{
		FirebirdManage.smethod_2("[PlayAnim_Hover]");
		this.method_17(MoveBloodWing.TargetType.Hover);
		this.m_animator.SetBool("bHover", true);
		this.m_vfxMgr.method_1(ENPCParticleType.E_FireBird_Tailing);
	}

	// Token: 0x060022BB RID: 8891 RVA: 0x00017D79 File Offset: 0x00015F79
	private bool method_25(float float_0)
	{
		return Time.time - this.m_startTime_dive > this.m_length_dive * float_0;
	}

	// Token: 0x060022BC RID: 8892 RVA: 0x000A4E18 File Offset: 0x000A3018
	private float method_26()
	{
		if (this.m_velocity_flyback < 0f)
		{
			this.m_velocity_flyback = this.m_setting.m_flyback_initVelocity;
		}
		else
		{
			this.m_velocity_flyback += this.m_setting.m_flyback_accel * Time.deltaTime;
		}
		return this.m_velocity_flyback;
	}

	// Token: 0x060022BD RID: 8893 RVA: 0x000A4E6C File Offset: 0x000A306C
	private float method_27()
	{
		return this.m_setting.m_flyaway_duration * this.m_owner_player.PlayerEffectManager_0.method_0(EffectType.FirebirdDuration);
	}

	// Token: 0x060022BE RID: 8894 RVA: 0x000A4E98 File Offset: 0x000A3098
	public void method_28(Entity entity_0)
	{
		this.m_chase_target = entity_0;
		this.method_17(MoveBloodWing.TargetType.Chase);
		this.m_animator.SetBool("bHover", true);
		this.m_chaseHoverDir = (entity_0.transform.position - base.transform.position).normalized;
	}

	// Token: 0x060022BF RID: 8895 RVA: 0x00017D91 File Offset: 0x00015F91
	public void method_29()
	{
		this.method_17(MoveBloodWing.TargetType.HurtZone);
		this.m_animator.SetBool("bHover", true);
	}

	// Token: 0x040016EE RID: 5870
	private MoveBloodWing.TargetType m_target;

	// Token: 0x040016EF RID: 5871
	private Animator m_animator;

	// Token: 0x040016F0 RID: 5872
	private AnimatorStateInfo m_animatorInfo;

	// Token: 0x040016F1 RID: 5873
	private float m_startTime_dive = -1f;

	// Token: 0x040016F2 RID: 5874
	private float m_length_dive;

	// Token: 0x040016F3 RID: 5875
	private EntityPlayer m_owner_player;

	// Token: 0x040016F4 RID: 5876
	private PlayerController m_playercontroller;

	// Token: 0x040016F5 RID: 5877
	public VFXManager m_vfxMgr;

	// Token: 0x040016F6 RID: 5878
	private float m_delay_networkDestroy = 3f;

	// Token: 0x040016F7 RID: 5879
	private Vector3 m_pos_whenFlyBack = Vector3.zero;

	// Token: 0x040016F8 RID: 5880
	private float m_progress;

	// Token: 0x040016F9 RID: 5881
	private float m_velocity_flyback = -1f;

	// Token: 0x040016FA RID: 5882
	private bool m_bFirstTick;

	// Token: 0x040016FB RID: 5883
	private Vector3 m_offset_spawnpoint = new Vector3(0f, 0f, 0f);

	// Token: 0x040016FC RID: 5884
	private BHVSkillSettingsFireBird m_setting;

	// Token: 0x040016FD RID: 5885
	private float m_flyaway_leftTime;

	// Token: 0x040016FE RID: 5886
	private float m_flyaway_duration;

	// Token: 0x040016FF RID: 5887
	private float m_flashVfxPeriod = 1f;

	// Token: 0x04001700 RID: 5888
	private float m_flashVfxTime;

	// Token: 0x04001701 RID: 5889
	private Utils.Timer m_chainTimer = new Utils.Timer();

	// Token: 0x04001702 RID: 5890
	private int m_chainNum;

	// Token: 0x04001703 RID: 5891
	private int[] m_chainRandomAngles = new int[3];

	// Token: 0x04001704 RID: 5892
	private Entity m_chase_target;

	// Token: 0x04001705 RID: 5893
	private float m_chase_radius = 2f;

	// Token: 0x04001706 RID: 5894
	private Vector3 m_chaseHoverDir = Vector3.zero;

	// Token: 0x0200053D RID: 1341
	public enum LifeEndType
	{
		// Token: 0x04001708 RID: 5896
		Explosion,
		// Token: 0x04001709 RID: 5897
		FlyBack,
		// Token: 0x0400170A RID: 5898
		PlayerDie
	}

	// Token: 0x0200053E RID: 1342
	public enum TargetType
	{
		// Token: 0x0400170C RID: 5900
		FlyingAway,
		// Token: 0x0400170D RID: 5901
		TurningBack,
		// Token: 0x0400170E RID: 5902
		FlyingBack,
		// Token: 0x0400170F RID: 5903
		Dive,
		// Token: 0x04001710 RID: 5904
		Dead,
		// Token: 0x04001711 RID: 5905
		Hover,
		// Token: 0x04001712 RID: 5906
		Chase,
		// Token: 0x04001713 RID: 5907
		HurtZone
	}

	// Token: 0x0200053F RID: 1343
	public enum ColliderType
	{
		// Token: 0x04001715 RID: 5909
		Enviorment,
		// Token: 0x04001716 RID: 5910
		Npc,
		// Token: 0x04001717 RID: 5911
		Player_TeamMate,
		// Token: 0x04001718 RID: 5912
		Player_Enemy,
		// Token: 0x04001719 RID: 5913
		Unknown
	}
}
