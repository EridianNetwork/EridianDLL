using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using BHV;
using Core;
using ns0;
using UnityEngine;
using XsdSettings;

// Token: 0x02000451 RID: 1105
public class EntityNpc : Entity, AreaDamager, MeleeAttacker, SpitDamager, ChargeAttackDamager
{
	// Token: 0x06001B7C RID: 7036 RVA: 0x00013CFD File Offset: 0x00011EFD
	public override int vmethod_3()
	{
		if (this.m_npcFamilly == EntityNpc.EntityNpcFamilly.Tutor)
		{
			this.m_level = 0;
		}
		else
		{
			this.m_level = (int)this.m_equipment.vmethod_23();
		}
		this.method_11();
		return this.m_level;
	}

	// Token: 0x06001B7D RID: 7037 RVA: 0x000039EC File Offset: 0x00001BEC
	public override bool vmethod_20()
	{
		return true;
	}

	// Token: 0x06001B7E RID: 7038 RVA: 0x0008A404 File Offset: 0x00088604
	public override List<PassiveSkillType> vmethod_6()
	{
		List<PassiveSkillType> list = new List<PassiveSkillType>();
		foreach (PassiveSkillSettings passiveSkillSettings in this.m_passiveSkillSettings)
		{
			list.Add(passiveSkillSettings.m_skillType);
		}
		return list;
	}

	// Token: 0x06001B7F RID: 7039 RVA: 0x00013D2E File Offset: 0x00011F2E
	public void method_10()
	{
		if (this.m_appearName != null)
		{
			this.m_localizedAppearName = LocalizedString.smethod_0(new LocalizedString(this.m_appearName.ToString()));
		}
	}

	// Token: 0x06001B80 RID: 7040 RVA: 0x0008A464 File Offset: 0x00088664
	private void method_11()
	{
		if (this.m_appearName == null)
		{
			this.m_appearName = new StringBuilder(this.m_name);
			if (this.m_level > 12 && this.m_level <= 12)
			{
				this.m_appearName.Append("_M");
			}
			else if (this.m_level > 12)
			{
				this.m_appearName.Append("_L");
			}
			this.m_localizedAppearName = LocalizedString.smethod_0(new LocalizedString(this.m_appearName.ToString()));
		}
		if (!string.IsNullOrEmpty((this.m_equipment as EquipmentInventoryEntityNpc).m_npcNameFromCluster) && !this.m_bClusterNameSetuped)
		{
			this.m_bClusterNameSetuped = true;
			this.m_localizedAppearName = LocalizedString.smethod_0(new LocalizedString((this.m_equipment as EquipmentInventoryEntityNpc).m_npcNameFromCluster.ToString()));
		}
		if ((this.m_equipment as EquipmentInventoryEntityNpc).m_bMissionNpc && string.IsNullOrEmpty(this.m_localizedMissionName))
		{
			this.m_localizedMissionName = LocalizedString.smethod_0(new LocalizedString(this.m_missionName));
		}
	}

	// Token: 0x06001B81 RID: 7041 RVA: 0x00013D53 File Offset: 0x00011F53
	public override string vmethod_4()
	{
		if (this.m_appearName == null)
		{
			this.method_11();
		}
		return (!string.IsNullOrEmpty(this.m_localizedMissionName)) ? this.m_localizedMissionName : this.m_localizedAppearName;
	}

	// Token: 0x06001B82 RID: 7042 RVA: 0x0008A568 File Offset: 0x00088768
	public override float vmethod_5()
	{
		float num = 1f;
		foreach (PassiveSkillSettings passiveSkillSettings in this.m_passiveSkillSettings)
		{
			if (passiveSkillSettings.m_skillType == PassiveSkillType.SpeedMultiplier)
			{
				num *= passiveSkillSettings.m_multiplier;
			}
		}
		return num;
	}

	// Token: 0x06001B83 RID: 7043 RVA: 0x00013D7E File Offset: 0x00011F7E
	public override Entity.EntityType vmethod_8()
	{
		return Entity.EntityType.Npc;
	}

	// Token: 0x06001B84 RID: 7044 RVA: 0x00013D81 File Offset: 0x00011F81
	public override bool vmethod_47()
	{
		return this.m_subType == EntityNpc.EntitySubType.CHR_BanditSuicidePsycho || base.vmethod_47();
	}

	// Token: 0x06001B85 RID: 7045 RVA: 0x00013D95 File Offset: 0x00011F95
	public static string[] smethod_0()
	{
		return Enum.GetNames(typeof(EntityNpc.EntitySubType));
	}

	// Token: 0x06001B86 RID: 7046 RVA: 0x00013DA6 File Offset: 0x00011FA6
	public override int vmethod_9()
	{
		return this.m_teamID;
	}

	// Token: 0x06001B87 RID: 7047 RVA: 0x00013DAE File Offset: 0x00011FAE
	public override AIInventory vmethod_10()
	{
		if (this.m_aiInventory == null)
		{
			this.m_aiInventory = base.GetComponent<AIInventory>();
		}
		return this.m_aiInventory;
	}

	// Token: 0x06001B88 RID: 7048 RVA: 0x0008A5CC File Offset: 0x000887CC
	public override EntityWeapon vmethod_16()
	{
		AIInventory aiinventory = this.vmethod_10();
		if (aiinventory != null)
		{
			return aiinventory.m_weapon;
		}
		return null;
	}

	// Token: 0x06001B89 RID: 7049 RVA: 0x00013DD0 File Offset: 0x00011FD0
	public override EntityShield vmethod_18()
	{
		return this.vmethod_19().vmethod_26();
	}

	// Token: 0x06001B8A RID: 7050 RVA: 0x00013DDD File Offset: 0x00011FDD
	public override NavMeshAgent vmethod_11()
	{
		return base.GetComponent<NavMeshAgent>();
	}

	// Token: 0x06001B8B RID: 7051 RVA: 0x00013DE5 File Offset: 0x00011FE5
	public override AnimationManager vmethod_12()
	{
		return base.GetComponent<AnimationManagerFSM>();
	}

	// Token: 0x06001B8C RID: 7052 RVA: 0x00013DED File Offset: 0x00011FED
	public override EquipmentInventoryEntity vmethod_19()
	{
		return this.m_equipment;
	}

	// Token: 0x06001B8D RID: 7053 RVA: 0x00013DF5 File Offset: 0x00011FF5
	public override CollisionManager vmethod_21()
	{
		return this.m_collisionManager;
	}

	// Token: 0x06001B8E RID: 7054 RVA: 0x0008A5F4 File Offset: 0x000887F4
	public override void Start()
	{
		this.m_equipment = base.GetComponent<EquipmentInventoryEntity>();
		this.m_collisionManager = base.GetComponent<CollisionManager>();
		base.Start();
		base.gameObject.SendMessage("OnSpawnCompleted", null, SendMessageOptions.DontRequireReceiver);
		this.vmethod_21().method_0(true);
		base.gameObject.layer = LayerMask.NameToLayer("Npc");
		this.m_ability.method_0(new Melee());
		this.m_ability.method_0(new AreaDamage());
		this.m_ability.method_0(new SpitDamage());
		this.m_ability.method_0(new ChargeAttackDamage());
		this.m_ability.method_0(new KnockBack());
		if (this.m_entityMng != null)
		{
			int num = this.m_entityMng.method_9(Entity.EntityType.Player);
			if (num > 0)
			{
				this.m_playerCountAtStartTime = num;
			}
		}
		this.m_bHaveBeenAlerted = false;
		if (this.method_18())
		{
			MonoSingleton<AppManager>.Instance.method_0().vmethod_5<HUDAimTargetView>().vmethod_15(this);
		}
		this.m_vfxManager = base.GetComponentInChildren<VFXManager>();
		this.m_bHealEffect = false;
		this.m_lastShield = int.MaxValue;
		this.method_12();
		DebugUtils.Log(LogCategory.AI, "m_berserkAuraModifier " + this.m_berserkAuraModifier);
		base.photonView.method_4("RPC_RequestPassiveSkill", PhotonTargets.MasterClient, new object[0]);
		this.m_bClusterNameSetuped = false;
	}

	// Token: 0x06001B8F RID: 7055 RVA: 0x0008A74C File Offset: 0x0008894C
	public void method_12()
	{
		if (this.m_subType != EntityNpc.EntitySubType.CHR_SoldierTurretBasic)
		{
			MapObjectMark mapObjectMark = base.gameObject.AddComponent<MapObjectMark>();
			if (this.m_subType == EntityNpc.EntitySubType.CHR_ClapTrapTutor)
			{
				mapObjectMark.ObjType = UIMapDataManager.MiniMapObjectType.NPC;
			}
			else
			{
				switch (this.m_npcRank)
				{
				case EntityNpc.EntityNpcRank.Common:
					mapObjectMark.ObjType = UIMapDataManager.MiniMapObjectType.Enemy;
					mapObjectMark.bAlwaysOnMap = true;
					break;
				case EntityNpc.EntityNpcRank.Badass:
					mapObjectMark.ObjType = UIMapDataManager.MiniMapObjectType.Badass;
					mapObjectMark.bAlwaysOnMap = true;
					break;
				case EntityNpc.EntityNpcRank.Boss:
					mapObjectMark.ObjType = UIMapDataManager.MiniMapObjectType.Boss;
					mapObjectMark.bAlwaysOnMap = true;
					break;
				}
			}
			mapObjectMark.method_0();
		}
	}

	// Token: 0x06001B90 RID: 7056 RVA: 0x0000311B File Offset: 0x0000131B
	private void method_13(float float_0)
	{
	}

	// Token: 0x06001B91 RID: 7057 RVA: 0x0000311B File Offset: 0x0000131B
	[RPC]
	public void RPC_RequestPassiveSkill(PhotonMessageInfo info)
	{
	}

	// Token: 0x06001B92 RID: 7058 RVA: 0x0008A7D4 File Offset: 0x000889D4
	[RPC]
	public void RPC_ApplyPassiveSkill(Hashtable passiveSkills)
	{
		this.m_passiveSkillSettings.Clear();
		for (int i = 0; i < passiveSkills.Count; i++)
		{
			PassiveSkillSettings passiveSkillSettings = new PassiveSkillSettings();
			Hashtable hashtable = passiveSkills[i] as Hashtable;
			passiveSkillSettings.m_multiplier = (float)hashtable[0];
			passiveSkillSettings.m_skillID = (int)hashtable[1];
			passiveSkillSettings.m_skillType = (PassiveSkillType)((byte)hashtable[2]);
			this.m_passiveSkillSettings.Add(passiveSkillSettings);
		}
	}

	// Token: 0x06001B93 RID: 7059 RVA: 0x0000311B File Offset: 0x0000131B
	public void imethod_1()
	{
	}

	// Token: 0x06001B94 RID: 7060 RVA: 0x0000311B File Offset: 0x0000131B
	public void imethod_0()
	{
	}

	// Token: 0x06001B95 RID: 7061 RVA: 0x0000311B File Offset: 0x0000131B
	public void imethod_2()
	{
	}

	// Token: 0x06001B96 RID: 7062 RVA: 0x0000311B File Offset: 0x0000131B
	public void imethod_3()
	{
	}

	// Token: 0x06001B97 RID: 7063 RVA: 0x0008A868 File Offset: 0x00088A68
	public override Vector3 vmethod_27()
	{
		EntityWeapon entityWeapon = this.vmethod_16();
		if (entityWeapon != null)
		{
			return entityWeapon.m_fireDirection;
		}
		return base.vmethod_27();
	}

	// Token: 0x06001B98 RID: 7064 RVA: 0x0008A894 File Offset: 0x00088A94
	public override Vector3 vmethod_28()
	{
		EntityWeapon entityWeapon = this.vmethod_16();
		if (entityWeapon != null)
		{
			return entityWeapon.m_fireOrigin;
		}
		return base.vmethod_28();
	}

	// Token: 0x06001B99 RID: 7065 RVA: 0x0000311B File Offset: 0x0000131B
	private void method_14()
	{
	}

	// Token: 0x06001B9A RID: 7066 RVA: 0x0008A8C0 File Offset: 0x00088AC0
	public override void Update()
	{
		int num = this.vmethod_40();
		EntityShield entityShield = this.vmethod_18();
		if (entityShield != null && num > 0)
		{
			entityShield.method_23();
			int num2 = this.vmethod_44();
			int num3 = this.vmethod_45();
			if (num2 > this.m_lastShield && num2 == num3)
			{
				this.m_vfxManager.method_10(ENPCParticleType.E_DamageShieldFull, base.transform.position, true);
			}
			this.m_lastShield = num2;
		}
		this.method_14();
		if (this.m_vfxManager != null)
		{
			if (this.m_lastHP > 0 && num > this.m_lastHP)
			{
				Vector3 position = base.transform.position;
				position.y += this.m_entityHeight * 0.5f;
				this.m_vfxManager.method_10(ENPCParticleType.E_NPC_Heal, position, true);
				this.m_bHealEffect = true;
			}
			else if (this.m_bHealEffect)
			{
				this.m_bHealEffect = false;
				this.m_vfxManager.method_13(ENPCParticleType.E_NPC_Heal);
			}
		}
		this.m_lastHP = num;
		EquipmentInventoryEntityNpc equipmentInventoryEntityNpc = this.m_equipment as EquipmentInventoryEntityNpc;
		if (equipmentInventoryEntityNpc != null)
		{
			if (equipmentInventoryEntityNpc.Boolean_0 && this.vmethod_40() > 0)
			{
				if (!this.m_hasBerserkAura && this.m_vfxManager != null)
				{
					Vector3 zero = Vector3.zero;
					zero.y = this.m_entityHeight - 1.8f;
					this.m_vfxManager.method_5(ENPCParticleType.E_BerserkAura_Start, this, base.transform, zero, Quaternion.Euler(-90f, 0f, 0f), 2f, true);
					this.m_vfxManager.method_5(ENPCParticleType.E_BerserkAura_Continue, this, base.transform, zero, Quaternion.Euler(-90f, 0f, 0f), 0f, true);
				}
				this.m_hasBerserkAura = true;
			}
			else
			{
				if (this.m_hasBerserkAura && this.m_vfxManager != null)
				{
					this.m_vfxManager.method_13(ENPCParticleType.E_BerserkAura_Continue);
				}
				this.m_hasBerserkAura = false;
			}
		}
	}

	// Token: 0x06001B9B RID: 7067 RVA: 0x00013DFD File Offset: 0x00011FFD
	public override int vmethod_46()
	{
		return this.m_playerCountAtStartTime;
	}

	// Token: 0x06001B9C RID: 7068 RVA: 0x00013E05 File Offset: 0x00012005
	public bool method_15()
	{
		return this.m_bHaveBeenAlerted;
	}

	// Token: 0x06001B9D RID: 7069 RVA: 0x0008AAB0 File Offset: 0x00088CB0
	public override bool vmethod_53()
	{
		BHVTaskManager bhvtaskManager = this.vmethod_14();
		if (bhvtaskManager == null)
		{
			return true;
		}
		BHVTask bhvtask = bhvtaskManager.method_12();
		return bhvtask == null || bhvtask.m_Type == BHVTaskType.Dead || bhvtask.m_Type == BHVTaskType.Die;
	}

	// Token: 0x06001B9E RID: 7070 RVA: 0x0008AAF0 File Offset: 0x00088CF0
	[AudioParameterFunction]
	public string GetHurtState()
	{
		if (this.m_equipment == null)
		{
			return "Default";
		}
		if (this.m_equipment.vmethod_0() == 0)
		{
			return "Default";
		}
		if (this.m_alreadyLowHP)
		{
			if (100 * this.m_equipment.vmethod_4() / this.m_equipment.vmethod_0() > this.m_lowHPThreshold)
			{
				this.m_alreadyLowHP = false;
			}
			return "Default";
		}
		if (100 * this.m_equipment.vmethod_4() / this.m_equipment.vmethod_0() < this.m_lowHPThreshold)
		{
			this.m_alreadyLowHP = true;
			return "LowHP";
		}
		return "Default";
	}

	// Token: 0x06001B9F RID: 7071 RVA: 0x0008AB90 File Offset: 0x00088D90
	public override ENPCParticleType vmethod_13(ENPCParticleType enpcparticleType_0, WeakPoint weakPoint_0)
	{
		if (this.vmethod_44() > 0)
		{
			enpcparticleType_0 = ENPCParticleType.E_DamageShieldHit;
			return ENPCParticleType.E_DamageShieldHit;
		}
		if (this.m_subType != EntityNpc.EntitySubType.CHR_BadassCrimsonLanceDefender)
		{
			if (this.m_subType != EntityNpc.EntitySubType.CHR_CrimsonLanceDefender)
			{
				if (this.m_subType == EntityNpc.EntitySubType.CHR_SpiderantWorker || this.m_subType == EntityNpc.EntitySubType.CHR_BadassSpiderantWorker || this.m_subType == EntityNpc.EntitySubType.CHR_SpiderantWidowmaker)
				{
					if (weakPoint_0.method_3() != WeakPoint.StrengthType.Strong)
					{
						if (weakPoint_0.method_3() != WeakPoint.StrengthType.VeryStrong)
						{
							if (weakPoint_0.method_3() == WeakPoint.StrengthType.Weak || weakPoint_0.method_3() == WeakPoint.StrengthType.VeryWeak)
							{
								return ENPCParticleType.E_DamagedBulletNone;
							}
							return enpcparticleType_0;
						}
					}
					return ENPCParticleType.E_DamageOnArmor;
				}
				return enpcparticleType_0;
			}
		}
		if (weakPoint_0.method_3() == WeakPoint.StrengthType.Indestructible)
		{
			return ENPCParticleType.E_DamageOnArmor;
		}
		return enpcparticleType_0;
	}

	// Token: 0x06001BA0 RID: 7072 RVA: 0x00013E0D File Offset: 0x0001200D
	public EntityNpc.EntityNpcRank method_16()
	{
		return this.m_npcRank;
	}

	// Token: 0x06001BA1 RID: 7073 RVA: 0x00013E15 File Offset: 0x00012015
	public bool method_17()
	{
		return this.m_npcRank == EntityNpc.EntityNpcRank.Badass;
	}

	// Token: 0x06001BA2 RID: 7074 RVA: 0x00013E20 File Offset: 0x00012020
	public bool method_18()
	{
		return this.m_npcRank == EntityNpc.EntityNpcRank.Boss;
	}

	// Token: 0x06001BA3 RID: 7075 RVA: 0x0008AC1C File Offset: 0x00088E1C
	public void method_19(bool bool_0, int int_0)
	{
		if (int_0 <= 0)
		{
			return;
		}
		DamageInfo damageInfo = default(DamageInfo);
		damageInfo.m_attackSubType = AttackSubType.Recover;
		damageInfo.m_from = this.vmethod_0();
		damageInfo.m_healthDamagePoints = int_0;
		EquipmentInventoryEntityNpc equipmentInventoryEntityNpc = this.vmethod_19() as EquipmentInventoryEntityNpc;
		if (equipmentInventoryEntityNpc != null)
		{
			equipmentInventoryEntityNpc.method_1(bool_0);
		}
	}

	// Token: 0x06001BA4 RID: 7076 RVA: 0x00013E2B File Offset: 0x0001202B
	public override VFXManager vmethod_15()
	{
		return this.m_vfxManager;
	}

	// Token: 0x06001BA5 RID: 7077 RVA: 0x0000311B File Offset: 0x0000131B
	public override void vmethod_49()
	{
	}

	// Token: 0x06001BA6 RID: 7078 RVA: 0x0008AC70 File Offset: 0x00088E70
	public override Vector3 vmethod_50()
	{
		if (Mathf.Approximately(base.transform.position.x, this.m_snapOnGroundPosition.x) && Mathf.Approximately(base.transform.position.z, this.m_snapOnGroundPosition.z))
		{
			return this.m_snapOnGroundPosition;
		}
		float num = 0.25f;
		Vector3 vector = base.transform.position + Vector3.up * (1f + this.m_entityHeight);
		RaycastHit raycastHit;
		if (Physics.SphereCast(vector, num, Vector3.down, out raycastHit, 10f, 1 << LayerMask.NameToLayer("Walkable")))
		{
			vector.y = raycastHit.point.y;
			this.m_snapOnGroundPosition = vector;
			return vector;
		}
		return base.transform.position;
	}

	// Token: 0x06001BA7 RID: 7079 RVA: 0x0008AD4C File Offset: 0x00088F4C
	public override string vmethod_56()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(string.Concat(new object[]
		{
			this.vmethod_4(),
			base.transform.position,
			" HP",
			this.vmethod_40()
		})).Append(" SP" + this.vmethod_44()).AppendLine();
		stringBuilder.Append(this.vmethod_14().ToString());
		stringBuilder.Append(this.vmethod_12().ToString());
		return stringBuilder.ToString();
	}

	// Token: 0x06001BA8 RID: 7080 RVA: 0x00013E33 File Offset: 0x00012033
	protected override void Awake()
	{
		base.Awake();
		base.GetComponent<BHVTaskManager>().method_3(this.m_subType);
		base.GetComponent<NPCAnimationManagerFSM>().method_19(this.m_subType);
	}

	// Token: 0x06001BA9 RID: 7081 RVA: 0x0000311B File Offset: 0x0000131B
	public void method_20(Entity entity_0)
	{
	}

	// Token: 0x06001BAA RID: 7082 RVA: 0x0008ADEC File Offset: 0x00088FEC
	public override void vmethod_57(float float_0)
	{
		AnimationManagerFSM component = base.GetComponent<AnimationManagerFSM>();
		if (float_0 < 1f)
		{
			component.method_7(float_0);
		}
		else
		{
			component.method_6();
		}
	}

	// Token: 0x06001BAB RID: 7083 RVA: 0x0008ADEC File Offset: 0x00088FEC
	[RPC]
	private void RPC_DoSlowdown(float _rate, PhotonMessageInfo info)
	{
		AnimationManagerFSM component = base.GetComponent<AnimationManagerFSM>();
		if (_rate < 1f)
		{
			component.method_7(_rate);
		}
		else
		{
			component.method_6();
		}
	}

	// Token: 0x06001BAC RID: 7084 RVA: 0x0008AE18 File Offset: 0x00089018
	public override void vmethod_58(bool bool_0)
	{
		AnimationManagerFSM component = base.GetComponent<AnimationManagerFSM>();
		if (bool_0)
		{
			component.method_7(this.m_speedRate_marked);
		}
		else
		{
			component.method_6();
		}
	}

	// Token: 0x06001BAD RID: 7085 RVA: 0x00013E5D File Offset: 0x0001205D
	public float method_21()
	{
		if (this.m_UIMarkLevelHeight <= 0f)
		{
			return this.m_entityHeight;
		}
		return this.m_UIMarkLevelHeight;
	}

	// Token: 0x04001201 RID: 4609
	protected const int m_juniorLevel = 12;

	// Token: 0x04001202 RID: 4610
	protected const int m_midLevel = 12;

	// Token: 0x04001203 RID: 4611
	protected const int m_seniorLevlel = 20;

	// Token: 0x04001204 RID: 4612
	private EquipmentInventoryEntity m_equipment;

	// Token: 0x04001205 RID: 4613
	private CollisionManager m_collisionManager;

	// Token: 0x04001206 RID: 4614
	private int m_playerCountAtStartTime = 1;

	// Token: 0x04001207 RID: 4615
	public string m_missionName = string.Empty;

	// Token: 0x04001208 RID: 4616
	public EntityNpc.EntitySubType m_subType;

	// Token: 0x04001209 RID: 4617
	public EntityNpc.EntityNpcFamilly m_npcFamilly;

	// Token: 0x0400120A RID: 4618
	public int m_lowHPThreshold = 20;

	// Token: 0x0400120B RID: 4619
	public bool m_alreadyLowHP;

	// Token: 0x0400120C RID: 4620
	public EntityNpc.EntityNpcRank m_npcRank;

	// Token: 0x0400120D RID: 4621
	private float m_berserkAuraModifier = 1f;

	// Token: 0x0400120E RID: 4622
	[HideInInspector]
	public GameObject m_attackTarget;

	// Token: 0x0400120F RID: 4623
	[HideInInspector]
	public bool m_bHaveBeenAlerted;

	// Token: 0x04001210 RID: 4624
	[HideInInspector]
	public int m_level = -1;

	// Token: 0x04001211 RID: 4625
	[HideInInspector]
	public float m_accumulateHealPoint;

	// Token: 0x04001212 RID: 4626
	public GameObject m_spawnObjPrefab;

	// Token: 0x04001213 RID: 4627
	public GameObject[] m_spawnObjPrefabList;

	// Token: 0x04001214 RID: 4628
	public Transform m_headTransform;

	// Token: 0x04001215 RID: 4629
	public Transform m_rightHandWeaponSlot;

	// Token: 0x04001216 RID: 4630
	public Transform m_leftHandWeaponSlot;

	// Token: 0x04001217 RID: 4631
	public List<PassiveSkill> m_passiveSkill = new List<PassiveSkill>();

	// Token: 0x04001218 RID: 4632
	private List<PassiveSkillSettings> m_passiveSkillSettings = new List<PassiveSkillSettings>();

	// Token: 0x04001219 RID: 4633
	public int m_teamID = 255;

	// Token: 0x0400121A RID: 4634
	private int m_lastHP;

	// Token: 0x0400121B RID: 4635
	private int m_lastShield;

	// Token: 0x0400121C RID: 4636
	private VFXManager m_vfxManager;

	// Token: 0x0400121D RID: 4637
	private bool m_bHealEffect;

	// Token: 0x0400121E RID: 4638
	private bool m_hasBerserkAura;

	// Token: 0x0400121F RID: 4639
	private EntityStatusTracker m_statusTracker = new EntityStatusTracker();

	// Token: 0x04001220 RID: 4640
	[HideInInspector]
	public StringBuilder m_appearName;

	// Token: 0x04001221 RID: 4641
	[HideInInspector]
	public string m_localizedAppearName;

	// Token: 0x04001222 RID: 4642
	[HideInInspector]
	public string m_localizedMissionName;

	// Token: 0x04001223 RID: 4643
	[HideInInspector]
	public bool m_bClusterNameSetuped;

	// Token: 0x04001224 RID: 4644
	private AIInventory m_aiInventory;

	// Token: 0x04001225 RID: 4645
	private float m_speedRate_marked = 0.5f;

	// Token: 0x04001226 RID: 4646
	[SerializeField]
	private float m_UIMarkLevelHeight;

	// Token: 0x02000452 RID: 1106
	public enum EntitySubType
	{
		// Token: 0x04001228 RID: 4648
		None,
		// Token: 0x04001229 RID: 4649
		CHR_SkagAdult,
		// Token: 0x0400122A RID: 4650
		CHR_SkagAlpha,
		// Token: 0x0400122B RID: 4651
		CHR_SkagPup,
		// Token: 0x0400122C RID: 4652
		CHR_SkagSpitter,
		// Token: 0x0400122D RID: 4653
		CHR_SkagZilla,
		// Token: 0x0400122E RID: 4654
		CHR_BanditKiller,
		// Token: 0x0400122F RID: 4655
		CHR_BanditRaider,
		// Token: 0x04001230 RID: 4656
		CHR_BanditNineToes,
		// Token: 0x04001231 RID: 4657
		CHR_BanditBruiser,
		// Token: 0x04001232 RID: 4658
		CHR_BanditPsycho,
		// Token: 0x04001233 RID: 4659
		CHR_SpiderantWidowmaker,
		// Token: 0x04001234 RID: 4660
		CHR_BanditSuicidePsycho,
		// Token: 0x04001235 RID: 4661
		CHR_SpiderantWorker,
		// Token: 0x04001236 RID: 4662
		CHR_CrimsonLanceDefender,
		// Token: 0x04001237 RID: 4663
		CHR_GuardianWraith,
		// Token: 0x04001238 RID: 4664
		CHR_SpiderantTalos,
		// Token: 0x04001239 RID: 4665
		CHR_BadassVkag,
		// Token: 0x0400123A RID: 4666
		CHR_BadassBanditKiller,
		// Token: 0x0400123B RID: 4667
		CHR_BadassBanditPsycho,
		// Token: 0x0400123C RID: 4668
		CHR_CrimsonMechaKnoxx,
		// Token: 0x0400123D RID: 4669
		CHR_BadassSpiderantWorker,
		// Token: 0x0400123E RID: 4670
		CHR_BadassCrimsonLanceDefender,
		// Token: 0x0400123F RID: 4671
		CHR_BadassGuardianWraith,
		// Token: 0x04001240 RID: 4672
		CHR_Rakk,
		// Token: 0x04001241 RID: 4673
		CHR_MidgetShotgunner,
		// Token: 0x04001242 RID: 4674
		CHR_BanditScout,
		// Token: 0x04001243 RID: 4675
		CHR_SoldierTurretBasic,
		// Token: 0x04001244 RID: 4676
		CHR_CrimsonLanceMedic,
		// Token: 0x04001245 RID: 4677
		CHR_MedicalStation,
		// Token: 0x04001246 RID: 4678
		CHR_BanditApollyon,
		// Token: 0x04001247 RID: 4679
		CHR_CrimsonLanceInfantry,
		// Token: 0x04001248 RID: 4680
		CHR_CrimsonLanceSniper,
		// Token: 0x04001249 RID: 4681
		CHR_ArchAngel,
		// Token: 0x0400124A RID: 4682
		CHR_ClapTrapTutor,
		// Token: 0x0400124B RID: 4683
		CHR_TheInsane,
		// Token: 0x0400124C RID: 4684
		CHR_TheInsaneTentacle,
		// Token: 0x0400124D RID: 4685
		CHR_TheInsaneTentacleLarge,
		// Token: 0x0400124E RID: 4686
		CHR_Crabworm,
		// Token: 0x0400124F RID: 4687
		CHR_TheInsaneCrystal,
		// Token: 0x04001250 RID: 4688
		CHR_ZillaKing,
		// Token: 0x04001251 RID: 4689
		CHR_SpitterQueen,
		// Token: 0x04001252 RID: 4690
		CHR_DrBlofeld,
		// Token: 0x04001253 RID: 4691
		CHR_BatistaTheRocketLord,
		// Token: 0x04001254 RID: 4692
		CHR_InterstellarEraser,
		// Token: 0x04001255 RID: 4693
		CHR_MajorVanCleef,
		// Token: 0x04001256 RID: 4694
		CHR_CrimsonLanceAssassin
	}

	// Token: 0x02000453 RID: 1107
	public enum EntityNpcFamilly
	{
		// Token: 0x04001258 RID: 4696
		None,
		// Token: 0x04001259 RID: 4697
		Bandit,
		// Token: 0x0400125A RID: 4698
		Skag,
		// Token: 0x0400125B RID: 4699
		Spiderant,
		// Token: 0x0400125C RID: 4700
		Guardian,
		// Token: 0x0400125D RID: 4701
		Crimson,
		// Token: 0x0400125E RID: 4702
		Bird,
		// Token: 0x0400125F RID: 4703
		Turret,
		// Token: 0x04001260 RID: 4704
		Tutor,
		// Token: 0x04001261 RID: 4705
		Item
	}

	// Token: 0x02000454 RID: 1108
	public enum EntityNpcRank
	{
		// Token: 0x04001263 RID: 4707
		Common,
		// Token: 0x04001264 RID: 4708
		Badass,
		// Token: 0x04001265 RID: 4709
		Boss
	}
}
