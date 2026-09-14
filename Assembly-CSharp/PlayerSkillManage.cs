using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using BHV_Skill;
using Core;
using ns0;
using Photon;
using UnityEngine;
using XsdSettings;

// Token: 0x020004C1 RID: 1217
public class PlayerSkillManage : global::Photon.MonoBehaviour, IPrefabManagerXmlGenericSetup
{
	// Token: 0x060020C5 RID: 8389 RVA: 0x00016C02 File Offset: 0x00014E02
	public PlayerSkillManage.BaseSkillBehavior method_0()
	{
		return this.m_behavior;
	}

	// Token: 0x170001BA RID: 442
	// (get) Token: 0x060020C6 RID: 8390 RVA: 0x00016C0A File Offset: 0x00014E0A
	// (set) Token: 0x060020C7 RID: 8391 RVA: 0x00016C12 File Offset: 0x00014E12
	public bool Boolean_0
	{
		get
		{
			return this.bForceMotionless;
		}
		set
		{
			this.bForceMotionless = value;
		}
	}

	// Token: 0x170001BB RID: 443
	// (get) Token: 0x060020C8 RID: 8392 RVA: 0x00016C1B File Offset: 0x00014E1B
	public PlayerSkillManage.RegenHealthManage RegenHealthManage_0
	{
		get
		{
			return this.m_regenHealthMgr;
		}
	}

	// Token: 0x060020C9 RID: 8393 RVA: 0x00016C23 File Offset: 0x00014E23
	public T method_1<T>() where T : BHVSkillSettings
	{
		return this.m_setup.method_1<T>();
	}

	// Token: 0x060020CA RID: 8394 RVA: 0x00016C30 File Offset: 0x00014E30
	private void OnSpawnCompleted()
	{
		this.m_playerOwner = base.GetComponent<EntityPlayer>();
		this.m_regenHealthMgr = new PlayerSkillManage.RegenHealthManage(this.m_playerOwner);
	}

	// Token: 0x060020CB RID: 8395 RVA: 0x0009FB60 File Offset: 0x0009DD60
	public bool imethod_0(string string_0)
	{
		if (string.IsNullOrEmpty(string_0))
		{
			return false;
		}
		bool flag;
		try
		{
			using (StringReader stringReader = new StringReader(string_0))
			{
				XmlSerializer xmlSerializer = new XmlSerializer(typeof(BHVSkillSetup));
				this.m_setup = xmlSerializer.Deserialize(stringReader) as BHVSkillSetup;
			}
			goto IL_005E;
		}
		catch (Exception ex)
		{
			DebugUtils.LogError(LogCategory.Gamelogic, "Invalid Skill Manager Settings:" + ex.Message);
			flag = false;
		}
		return flag;
		IL_005E:
		this.m_setup.method_0();
		return true;
	}

	// Token: 0x060020CC RID: 8396 RVA: 0x0009FBF4 File Offset: 0x0009DDF4
	public List<int> method_2()
	{
		this.m_skillList.Clear();
		ESkillType[] array = (ESkillType[])Enum.GetValues(typeof(ESkillType));
		foreach (ESkillType eskillType in array)
		{
			if (eskillType >= this.m_skillId_begin_include && eskillType < this.m_skillId_end_exclude)
			{
				this.m_skillList.Add((int)eskillType);
			}
		}
		return this.m_skillList;
	}

	// Token: 0x060020CD RID: 8397 RVA: 0x0009FC5C File Offset: 0x0009DE5C
	public virtual void vmethod_0()
	{
		this.m_skillAction = new PlayerSkillAction();
		this.m_animationMgr = this.m_playerOwner.vmethod_12() as PlayerAnimationManagerFSM;
		if (AuthoritativeActionManager.AuthoritativeActionManager_0)
		{
			this.m_playerOwner.m_ability.method_0(this.m_skillAction);
		}
	}

	// Token: 0x060020CE RID: 8398 RVA: 0x00016C4F File Offset: 0x00014E4F
	public virtual void Update()
	{
		if (this.m_regenHealthMgr == null)
		{
			return;
		}
		this.m_regenHealthMgr.Update();
	}

	// Token: 0x060020CF RID: 8399 RVA: 0x00016C65 File Offset: 0x00014E65
	public virtual void vmethod_1()
	{
		this.m_playerOwner.m_ability.method_5("PlayerSkillAction", false, 0);
	}

	// Token: 0x060020D0 RID: 8400 RVA: 0x00013122 File Offset: 0x00011322
	public virtual float vmethod_2()
	{
		return 1f;
	}

	// Token: 0x060020D1 RID: 8401 RVA: 0x0000311B File Offset: 0x0000131B
	public virtual void OnTriggerAction(float _delay)
	{
	}

	// Token: 0x060020D2 RID: 8402 RVA: 0x00016C7E File Offset: 0x00014E7E
	public virtual bool vmethod_3()
	{
		DebugUtils.LogError(LogCategory.Gamelogic, "Must override CanSkill()");
		return false;
	}

	// Token: 0x060020D3 RID: 8403 RVA: 0x00016C8C File Offset: 0x00014E8C
	public virtual float vmethod_4(float float_0)
	{
		if (this.m_playerOwner.method_69())
		{
			return float_0 * this.m_playerOwner.CharacterSetting_0.m_rotation_stun;
		}
		return float_0;
	}

	// Token: 0x060020D4 RID: 8404 RVA: 0x00013990 File Offset: 0x00011B90
	public virtual Vector3 vmethod_5(Vector3 vector3_0)
	{
		return vector3_0;
	}

	// Token: 0x060020D5 RID: 8405 RVA: 0x0000311B File Offset: 0x0000131B
	public virtual void OnPlayerRespawn()
	{
	}

	// Token: 0x060020D6 RID: 8406 RVA: 0x0000311B File Offset: 0x0000131B
	public virtual void OnLeaveSession()
	{
	}

	// Token: 0x060020D7 RID: 8407 RVA: 0x0000311B File Offset: 0x0000131B
	public virtual void vmethod_6(MoveBloodWing moveBloodWing_0)
	{
	}

	// Token: 0x060020D8 RID: 8408 RVA: 0x0000311B File Offset: 0x0000131B
	public virtual void OnPostAssembly()
	{
	}

	// Token: 0x060020D9 RID: 8409 RVA: 0x0000311B File Offset: 0x0000131B
	public virtual void OnSkillTask(ESkillStatePhase _phase)
	{
	}

	// Token: 0x060020DA RID: 8410 RVA: 0x00013122 File Offset: 0x00011322
	public virtual float vmethod_7()
	{
		return 1f;
	}

	// Token: 0x060020DB RID: 8411 RVA: 0x00013122 File Offset: 0x00011322
	public virtual float vmethod_8()
	{
		return 1f;
	}

	// Token: 0x060020DC RID: 8412 RVA: 0x0000311B File Offset: 0x0000131B
	public virtual void OnDamaged(DamageContext context)
	{
	}

	// Token: 0x060020DD RID: 8413 RVA: 0x0000311D File Offset: 0x0000131D
	public virtual bool vmethod_9(EntityWeapon entityWeapon_0)
	{
		return false;
	}

	// Token: 0x060020DE RID: 8414 RVA: 0x00013990 File Offset: 0x00011B90
	public virtual int vmethod_10(int int_0, float float_0)
	{
		return int_0;
	}

	// Token: 0x060020DF RID: 8415 RVA: 0x00013990 File Offset: 0x00011B90
	public virtual int vmethod_11(int int_0)
	{
		return int_0;
	}

	// Token: 0x060020E0 RID: 8416 RVA: 0x00016CAF File Offset: 0x00014EAF
	public virtual void vmethod_12(Entity entity_0, HitInfo hitInfo_0)
	{
		this.m_playerOwner.method_128(1f);
	}

	// Token: 0x060020E1 RID: 8417 RVA: 0x0000311B File Offset: 0x0000131B
	public virtual void OnPlayerKillEnemy(Entity _enemy, KillContext _context)
	{
	}

	// Token: 0x060020E2 RID: 8418 RVA: 0x0000311D File Offset: 0x0000131D
	public virtual bool vmethod_13()
	{
		return false;
	}

	// Token: 0x060020E3 RID: 8419 RVA: 0x0000311B File Offset: 0x0000131B
	public virtual void OnSwitchWeaponDone()
	{
	}

	// Token: 0x060020E4 RID: 8420 RVA: 0x0000311D File Offset: 0x0000131D
	public virtual bool vmethod_14()
	{
		return false;
	}

	// Token: 0x060020E5 RID: 8421 RVA: 0x0000311B File Offset: 0x0000131B
	public virtual void OnPlayerBeKilled()
	{
	}

	// Token: 0x060020E6 RID: 8422 RVA: 0x0000311B File Offset: 0x0000131B
	public virtual void OnEnterPlayerCripple()
	{
	}

	// Token: 0x060020E7 RID: 8423 RVA: 0x0000311B File Offset: 0x0000131B
	public virtual void OnEnterPlayerDown()
	{
	}

	// Token: 0x060020E8 RID: 8424 RVA: 0x0000311B File Offset: 0x0000131B
	public virtual void OnPlayerSuicide()
	{
	}

	// Token: 0x060020E9 RID: 8425 RVA: 0x0009FCAC File Offset: 0x0009DEAC
	protected void method_3(Entity entity_0, int int_0, AttackSubType attackSubType_0 = AttackSubType.SkillReflect)
	{
		HitInfo hitInfo = new HitInfo();
		hitInfo.m_from = this.m_playerOwner.vmethod_0();
		hitInfo.m_owner = this.m_playerOwner.vmethod_0();
		hitInfo.m_to = entity_0.vmethod_0();
		hitInfo.m_timeStamp = (double)Time.time;
		hitInfo.m_damagePoint = int_0;
		hitInfo.m_attackSubType = attackSubType_0;
		hitInfo.m_elementalType = AttackInfo.ElementalType.None;
		hitInfo.m_weakPointIndex = (sbyte)entity_0.method_7();
		DamageManager.DamageManager_0.method_6(hitInfo, false);
	}

	// Token: 0x060020EA RID: 8426 RVA: 0x00016CC1 File Offset: 0x00014EC1
	public void OnUpdateProgress_Skill(float _progress)
	{
		this.m_skillInfo.m_skillProgress = _progress;
	}

	// Token: 0x060020EB RID: 8427 RVA: 0x00016CCF File Offset: 0x00014ECF
	public void OnUpdateProgress_CoolDown(float _progress)
	{
		this.m_skillInfo.m_cooldownProgress = _progress;
	}

	// Token: 0x060020EC RID: 8428 RVA: 0x00016CDD File Offset: 0x00014EDD
	public SkillInfo method_4()
	{
		return this.m_skillInfo;
	}

	// Token: 0x060020ED RID: 8429 RVA: 0x00016CE5 File Offset: 0x00014EE5
	protected void method_5(SkillEvent skillEvent_0, PlayerSkillManage.SkillDelegate skillDelegate_0)
	{
		if (this.m_eventMap.ContainsKey(skillEvent_0))
		{
			DebugUtils.LogError(LogCategory.Gamelogic, string.Format("SkillEvent {0} is already registered", skillEvent_0));
		}
		else
		{
			this.m_eventMap.Add(skillEvent_0, skillDelegate_0);
		}
	}

	// Token: 0x060020EE RID: 8430 RVA: 0x0009FD28 File Offset: 0x0009DF28
	public void OnSkillEvent(SkillEvent _event)
	{
		PlayerSkillManage.SkillDelegate skillDelegate;
		if (this.m_eventMap.TryGetValue(_event, out skillDelegate) && skillDelegate != null)
		{
			skillDelegate();
		}
		if (this.m_playerOwner != null && this.m_playerOwner.vmethod_25() != null && this.m_playerOwner.vmethod_25().IsMyActor() && MonoSingleton<AppManager>.Instance.method_0() != null)
		{
			HUDSkillStatusView hudskillStatusView = MonoSingleton<AppManager>.Instance.method_0().vmethod_5<HUDSkillStatusView>();
			if (hudskillStatusView != null)
			{
				hudskillStatusView.OnSkillEvent(_event);
			}
		}
	}

	// Token: 0x060020EF RID: 8431 RVA: 0x00016D1A File Offset: 0x00014F1A
	public virtual void OnSkillEvent_Local(SkillEvent _event, float _fParam, Vector3 _vParam)
	{
		if (this.m_playerOwner.vmethod_25().IsMyActor())
		{
			if (_event == SkillEvent.CureHeartVFXOn)
			{
				this.method_6(true);
			}
			else if (_event == SkillEvent.CureHeartVFXOff)
			{
				this.method_6(false);
			}
		}
	}

	// Token: 0x060020F0 RID: 8432 RVA: 0x0000311B File Offset: 0x0000131B
	public virtual void OnSkillEvent_Client(SkillEvent _event, float _fParam, Vector3 _vParam)
	{
	}

	// Token: 0x060020F1 RID: 8433 RVA: 0x0009FDB0 File Offset: 0x0009DFB0
	public void method_6(bool bool_0)
	{
		if (VFXManager.smethod_3())
		{
			if (this.m_playerOwner.vmethod_26())
			{
				GameObject gameObject = this.m_playerOwner.VFXManager_0.method_11(ENPCParticleType.E_Berserk_CureHeart, 0);
				if (gameObject != null)
				{
					gameObject.SetActive(bool_0);
				}
			}
			else
			{
				GameObject gameObject = this.m_playerOwner.VFXManager_0.method_11(ENPCParticleType.E_Berserk_CureHeart, 0);
				if (gameObject != null)
				{
					gameObject.SetActive(false);
				}
			}
		}
	}

	// Token: 0x060020F2 RID: 8434 RVA: 0x0009FE20 File Offset: 0x0009E020
	public void method_7(float float_0)
	{
		float num = float_0 * Time.deltaTime;
		this.m_regenAmmoSum += num;
		int num2 = Mathf.FloorToInt(this.m_regenAmmoSum);
		if (num2 > 0)
		{
			WeaponType weaponType = this.m_playerOwner.vmethod_16().method_99();
			int num3 = this.m_playerOwner.vmethod_19().vmethod_15(weaponType);
			this.m_playerOwner.vmethod_19().vmethod_16(num3 + num2, weaponType);
			this.m_regenAmmoSum -= (float)num2;
		}
	}

	// Token: 0x060020F3 RID: 8435 RVA: 0x0009FE9C File Offset: 0x0009E09C
	public static int smethod_0(int int_0, float float_0)
	{
		int num = MonoSingleton<LevelingManager>.Instance.m_progressionSetup.m_experienceTable.Length;
		int num2 = int_0 - 1;
		float num3 = ((num2 >= MonoSingleton<LevelingManager>.Instance.m_progressionSetup.m_experienceTable.Length) ? MonoSingleton<LevelingManager>.Instance.m_progressionSetup.m_experienceTable[num - 1].m_powerRating : MonoSingleton<LevelingManager>.Instance.m_progressionSetup.m_experienceTable[num2].m_powerRating);
		return (int)(float_0 * num3);
	}

	// Token: 0x060020F4 RID: 8436 RVA: 0x0000311B File Offset: 0x0000131B
	protected void method_8()
	{
	}

	// Token: 0x060020F5 RID: 8437 RVA: 0x0000311B File Offset: 0x0000131B
	protected void method_9(float float_0)
	{
	}

	// Token: 0x060020F6 RID: 8438 RVA: 0x00016D46 File Offset: 0x00014F46
	public EntityPlayer method_10()
	{
		return this.m_playerOwner;
	}

	// Token: 0x060020F7 RID: 8439 RVA: 0x00016D4E File Offset: 0x00014F4E
	public static bool smethod_1(AttackSubType attackSubType_0)
	{
		return attackSubType_0 == AttackSubType.SkillReflect || attackSubType_0 == AttackSubType.BerserkReflect || attackSubType_0 == AttackSubType.HunterDrain;
	}

	// Token: 0x0400157B RID: 5499
	public PlayerSkillTreeManage m_eventSender;

	// Token: 0x0400157C RID: 5500
	protected float m_animDelay;

	// Token: 0x0400157D RID: 5501
	private float m_regenAmmoSum;

	// Token: 0x0400157E RID: 5502
	private PlayerSkillAction m_skillAction;

	// Token: 0x0400157F RID: 5503
	protected PlayerAnimationManagerFSM m_animationMgr;

	// Token: 0x04001580 RID: 5504
	protected PlayerSkillManage.BaseSkillBehavior m_behavior;

	// Token: 0x04001581 RID: 5505
	protected SkillInfo m_skillInfo = new SkillInfo();

	// Token: 0x04001582 RID: 5506
	protected Dictionary<SkillEvent, PlayerSkillManage.SkillDelegate> m_eventMap = new Dictionary<SkillEvent, PlayerSkillManage.SkillDelegate>();

	// Token: 0x04001583 RID: 5507
	protected EntityPlayer m_playerOwner;

	// Token: 0x04001584 RID: 5508
	private BHVSkillSetup m_setup;

	// Token: 0x04001585 RID: 5509
	protected ESkillType m_skillId_begin_include;

	// Token: 0x04001586 RID: 5510
	protected ESkillType m_skillId_end_exclude = ESkillType.Max;

	// Token: 0x04001587 RID: 5511
	private List<int> m_skillList = new List<int>();

	// Token: 0x04001588 RID: 5512
	private bool bForceMotionless;

	// Token: 0x04001589 RID: 5513
	protected PlayerSkillManage.RegenHealthManage m_regenHealthMgr;

	// Token: 0x020004C2 RID: 1218
	public class BaseSkillBehavior
	{
		// Token: 0x060020F8 RID: 8440 RVA: 0x00016D62 File Offset: 0x00014F62
		public BaseSkillBehavior(PlayerSkillManage playerSkillManage_0)
		{
			this.m_owner = playerSkillManage_0;
		}

		// Token: 0x060020F9 RID: 8441 RVA: 0x0000311B File Offset: 0x0000131B
		public virtual void OnFirstAction()
		{
		}

		// Token: 0x060020FA RID: 8442 RVA: 0x0000311B File Offset: 0x0000131B
		public virtual void OnSecondAction()
		{
		}

		// Token: 0x060020FB RID: 8443 RVA: 0x0000311D File Offset: 0x0000131D
		public virtual bool vmethod_0()
		{
			return false;
		}

		// Token: 0x0400158A RID: 5514
		protected PlayerSkillManage m_owner;
	}

	// Token: 0x020004C3 RID: 1219
	public class RegenHealthManage
	{
		// Token: 0x060020FC RID: 8444 RVA: 0x00016D71 File Offset: 0x00014F71
		public RegenHealthManage(EntityPlayer entityPlayer_0)
		{
			this.m_playerOwner = entityPlayer_0;
		}

		// Token: 0x060020FD RID: 8445 RVA: 0x00016D8B File Offset: 0x00014F8B
		public void method_0(float float_0, float float_1)
		{
			this.m_taskList.Add(new PlayerSkillManage.RegenHealthManage.RegenHealthTask(float_0, float_1));
			this.m_playerOwner.PlayerSkillManage_0.method_6(true);
		}

		// Token: 0x060020FE RID: 8446 RVA: 0x0009FF10 File Offset: 0x0009E110
		public void Update()
		{
			for (int i = this.m_taskList.Count - 1; i >= 0; i--)
			{
				PlayerSkillManage.RegenHealthManage.RegenHealthTask regenHealthTask = this.m_taskList[i];
				if (regenHealthTask.m_duration <= 0f)
				{
					this.m_taskList.RemoveAt(i);
					if (this.m_taskList.Count == 0)
					{
						this.m_playerOwner.PlayerSkillManage_0.method_6(false);
					}
				}
				else
				{
					regenHealthTask.m_duration -= Time.deltaTime;
				}
			}
		}

		// Token: 0x0400158B RID: 5515
		private EntityPlayer m_playerOwner;

		// Token: 0x0400158C RID: 5516
		private List<PlayerSkillManage.RegenHealthManage.RegenHealthTask> m_taskList = new List<PlayerSkillManage.RegenHealthManage.RegenHealthTask>();

		// Token: 0x020004C4 RID: 1220
		public class RegenHealthTask
		{
			// Token: 0x060020FF RID: 8447 RVA: 0x00016DB0 File Offset: 0x00014FB0
			public RegenHealthTask(float float_0, float float_1)
			{
				this.m_speed = float_0;
				this.m_duration = float_1;
			}

			// Token: 0x0400158D RID: 5517
			public float m_speed;

			// Token: 0x0400158E RID: 5518
			public float m_duration;
		}
	}

	// Token: 0x020004C5 RID: 1221
	// (Invoke) Token: 0x06002101 RID: 8449
	public delegate void SkillDelegate();
}
