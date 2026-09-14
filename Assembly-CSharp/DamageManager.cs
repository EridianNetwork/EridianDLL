using System;
using System.Collections;
using System.Collections.Generic;
using Core;
using ns0;
using Photon;
using UnityEngine;
using XsdSettings;

// Token: 0x02000574 RID: 1396
public class DamageManager : global::Photon.MonoBehaviour
{
	// Token: 0x060023C7 RID: 9159 RVA: 0x0001881B File Offset: 0x00016A1B
	public List<Entity> method_0()
	{
		return this.m_damageableEntities;
	}

	// Token: 0x060023C8 RID: 9160 RVA: 0x00018823 File Offset: 0x00016A23
	public void method_1(Entity entity_0)
	{
		if (!this.m_damageableEntities.Contains(entity_0))
		{
			this.m_damageableEntities.Add(entity_0);
		}
	}

	// Token: 0x060023C9 RID: 9161 RVA: 0x0001883F File Offset: 0x00016A3F
	public void method_2(Entity entity_0)
	{
		if (this.m_damageableEntities.Contains(entity_0))
		{
			this.m_damageableEntities.Remove(entity_0);
		}
	}

	// Token: 0x060023CA RID: 9162 RVA: 0x0001885C File Offset: 0x00016A5C
	public void method_3(IDamageListener idamageListener_0)
	{
		this.m_damageListeners.Add(idamageListener_0);
	}

	// Token: 0x060023CB RID: 9163 RVA: 0x0001886A File Offset: 0x00016A6A
	public void method_4(IDamageListener idamageListener_0)
	{
		if (this.m_damageListeners.Contains(idamageListener_0))
		{
			this.m_damageListeners.Remove(idamageListener_0);
		}
	}

	// Token: 0x170001C7 RID: 455
	// (get) Token: 0x060023CC RID: 9164 RVA: 0x00018887 File Offset: 0x00016A87
	public static DamageManager DamageManager_0
	{
		get
		{
			return DamageManager.s_instance;
		}
	}

	// Token: 0x060023CD RID: 9165 RVA: 0x0001888E File Offset: 0x00016A8E
	private void Awake()
	{
		DamageManager.s_instance = this;
	}

	// Token: 0x060023CE RID: 9166 RVA: 0x00018896 File Offset: 0x00016A96
	private void Start()
	{
		this.m_damageSystem.method_0();
	}

	// Token: 0x060023CF RID: 9167 RVA: 0x000188A3 File Offset: 0x00016AA3
	public float method_5(AttackInfo.ElementalType elementalType_0, Entity entity_0, Entity entity_1)
	{
		return this.m_damageSystem.method_2(elementalType_0, entity_0, entity_1);
	}

	// Token: 0x060023D0 RID: 9168 RVA: 0x000A9DC8 File Offset: 0x000A7FC8
	public void method_6(HitInfo hitInfo_0, bool bool_0)
	{
		DamageInfo damageInfo = default(DamageInfo);
		if (this.m_damageSystem.method_6(hitInfo_0, bool_0, ref damageInfo))
		{
			this.method_11(hitInfo_0.m_to, damageInfo, false);
		}
	}

	// Token: 0x060023D1 RID: 9169 RVA: 0x000A9DFC File Offset: 0x000A7FFC
	public void method_7(HitInfo hitInfo_0, float float_0)
	{
		DamageInfo damageInfo = default(DamageInfo);
		if (this.m_damageSystem.method_8(hitInfo_0, float_0, ref damageInfo))
		{
			this.method_11(hitInfo_0.m_to, damageInfo, false);
		}
	}

	// Token: 0x060023D2 RID: 9170 RVA: 0x000188B3 File Offset: 0x00016AB3
	public void Update()
	{
		this.method_12();
		this.method_8();
	}

	// Token: 0x060023D3 RID: 9171 RVA: 0x000A9E30 File Offset: 0x000A8030
	private void method_8()
	{
		KillContext killContext = default(KillContext);
		Dictionary<Pair<int, short>, List<DamageContext>> appliedDamageBuffer = this.m_appliedDamageBuffer;
		this.m_appliedDamageBuffer = this.m_damageBuffer;
		this.m_damageBuffer = appliedDamageBuffer;
		Dictionary<Pair<int, short>, List<DamageContext>>.Enumerator enumerator = this.m_appliedDamageBuffer.GetEnumerator();
		while (enumerator.MoveNext())
		{
			int num = 0;
			for (;;)
			{
				int num2 = num;
				KeyValuePair<Pair<int, short>, List<DamageContext>> keyValuePair = enumerator.Current;
				if (num2 >= keyValuePair.Value.Count)
				{
					break;
				}
				KeyValuePair<Pair<int, short>, List<DamageContext>> keyValuePair2 = enumerator.Current;
				DamageContext damageContext = keyValuePair2.Value[num];
				if (AttackInfo.smethod_0(damageContext.m_damageInfo.m_attackSubType) != AttackInfo.AttackType.Recover && damageContext.m_isRemote)
				{
					DamageInfo damageInfo = damageContext.m_damageInfo;
					if (damageInfo.m_isLethal)
					{
						WeakPoint weakPoint = damageContext.m_victim.vmethod_21().method_12(damageInfo.m_weakPointIndex);
						killContext.m_isRemote = damageContext.m_isRemote;
						killContext.m_killer = damageContext.m_killer;
						killContext.m_victim = damageContext.m_victim;
						killContext.m_strengthType = ((!(weakPoint != null)) ? WeakPoint.StrengthType.Normal : weakPoint.method_3());
						killContext.m_partInfo = ((!(weakPoint != null)) ? WeakPoint.PartInfo.None : weakPoint.m_partInfo);
						killContext.m_subType = damageInfo.m_attackSubType;
						killContext.m_elementalType = damageInfo.m_elementalType;
						if (killContext.m_victim != null && killContext.m_killer != null)
						{
							killContext.m_killDistance = Vector3.Distance(killContext.m_victim.method_1(), killContext.m_killer.method_1());
						}
					}
					for (int i = 0; i < this.m_damageListeners.Count; i++)
					{
						IDamageListener damageListener = this.m_damageListeners[i];
						damageListener.OnDamaged(damageContext);
						if (damageInfo.m_isLethal)
						{
							damageListener.OnEntityKill(killContext);
						}
					}
				}
				num++;
			}
		}
		this.m_appliedDamageBuffer.Clear();
	}

	// Token: 0x060023D4 RID: 9172 RVA: 0x000AA014 File Offset: 0x000A8214
	private void method_9(Hashtable hashtable_0)
	{
		if (hashtable_0.Count == 0)
		{
			return;
		}
		DamageInfo damageInfo_ = default(DamageInfo);
		int num = 0;
		m_multiKillsToSerialize.Clear();
		num = 1;
		byte b = (byte)hashtable_0[0];
		for (int i = 0; i < b; i++)
		{
			damageInfo_.m_from = (int)hashtable_0[num++];
			short num2 = (short)hashtable_0[num++];
			damageInfo_.m_attackSubType = (AttackSubType)(num2 >> 3);
			damageInfo_.m_elementalType = (AttackInfo.ElementalType)(num2 & 7);
			byte b2 = (byte)hashtable_0[num++];
			for (int j = 0; j < b2; j++)
			{
				int int_ = damageInfo_.m_from;
				if (AttackInfo.smethod_0(damageInfo_.m_attackSubType) != AttackInfo.AttackType.Recover)
				{
					int_ = (int)hashtable_0[num++];
				}
				short num3 = (short)hashtable_0[num++];
				damageInfo_.m_weakPointIndex = num3 >> 8;
				damageInfo_.m_healthDamagePoints = 0;
				damageInfo_.m_shieldDamagePoints = 0;
				if (((uint)num3 & 8u) != 0)
				{
					damageInfo_.m_healthDamagePoints = (int)hashtable_0[num++];
				}
				if (((uint)num3 & 4u) != 0)
				{
					damageInfo_.m_shieldDamagePoints = (int)hashtable_0[num++];
				}
				damageInfo_.m_isTriggeringDamageOverTime = (num3 & 2) != 0;
				damageInfo_.m_isLethal = (num3 & 1) == 1;
				damageInfo_.m_force = 0f;
				if (damageInfo_.m_isLethal)
				{
					damageInfo_.m_force = (int)(byte)hashtable_0[num++];
					int value = 0;
					if (m_multiKillsToSerialize.TryGetValue(damageInfo_.m_from, out value))
					{
						m_multiKillsToSerialize[damageInfo_.m_from] = value + 1;
					}
					else
					{
						value = 1;
						m_multiKillsToSerialize.Add(damageInfo_.m_from, 1);
					}
				}
				method_11(int_, damageInfo_, bool_0: true);
			}
		}
		Dictionary<int, int>.Enumerator enumerator = m_multiKillsToSerialize.GetEnumerator();
		while (enumerator.MoveNext())
		{
			if (enumerator.Current.Value > 1)
			{
				ns0.MonoSingleton<ScoringManager>.Instance.method_12(enumerator.Current.Key);
			}
		}
	}
	// Token: 0x060023D5 RID: 9173 RVA: 0x000188C1 File Offset: 0x00016AC1
	public void method_10(int int_0, DamageInfo damageInfo_0)
	{
		this.method_11(int_0, damageInfo_0, false);
	}

	// Token: 0x060023D6 RID: 9174 RVA: 0x000AA268 File Offset: 0x000A8468
	private void method_11(int int_0, DamageInfo damageInfo_0, bool bool_0)
	{
		Entity entity = BadAssNetworkView.smethod_4(damageInfo_0.m_from);
		Entity entity2 = BadAssNetworkView.smethod_4(int_0);
		if (entity == null || entity2 == null)
		{
			return;
		}
		CollisionManager collisionManager = entity2.vmethod_21();
		if (collisionManager == null)
		{
			return;
		}
		WeakPoint weakPoint = collisionManager.method_12(damageInfo_0.m_weakPointIndex);
		DamageContext damageContext = default(DamageContext);
		damageContext.m_killer = entity;
		damageContext.m_victim = entity2;
		damageContext.m_strengthType = ((!(weakPoint != null)) ? WeakPoint.StrengthType.Normal : weakPoint.method_3());
		damageContext.m_subType = damageInfo_0.m_attackSubType;
		damageContext.m_damageInfo = damageInfo_0;
		damageContext.m_isRemote = bool_0;
		int num = ((int)((short)damageInfo_0.m_attackSubType) << 3) | (int)((byte)damageInfo_0.m_elementalType & 7);
		Pair<int, short> pair = new Pair<int, short>(damageInfo_0.m_from, (short)num);
		List<DamageContext> list;
		if (this.m_damageBuffer.TryGetValue(pair, out list))
		{
			list.Add(damageContext);
		}
		else
		{
			list = new List<DamageContext>();
			list.Add(damageContext);
			this.m_damageBuffer.Add(pair, list);
		}
	}

	// Token: 0x060023D7 RID: 9175 RVA: 0x000AA374 File Offset: 0x000A8574
	private void method_12()
	{
		foreach (KeyValuePair<Pair<int, short>, List<DamageContext>> keyValuePair in this.m_damageBuffer)
		{
			List<DamageContext> value = keyValuePair.Value;
			for (int i = 0; i < value.Count; i++)
			{
				DamageContext damageContext = value[i];
				this.method_13(value[i].m_victim, damageContext.m_damageInfo, value[i].m_isRemote);
				value[i] = damageContext;
			}
		}
	}

	// Token: 0x060023D8 RID: 9176 RVA: 0x000AA3F8 File Offset: 0x000A85F8
	private bool method_13(Entity entity_0, DamageInfo damageInfo_0, bool bool_0)
	{
		bool flag = AttackInfo.smethod_0(damageInfo_0.m_attackSubType) == AttackInfo.AttackType.Recover;
		bool flag2 = false;
		EquipmentInventoryEntity equipmentInventoryEntity = entity_0.vmethod_19();
		if (equipmentInventoryEntity == null)
		{
			return flag2;
		}
		if (!bool_0)
		{
			equipmentInventoryEntity.vmethod_36();
		}
		int num = 0;
		if (damageInfo_0.m_shieldDamagePoints > 0)
		{
			EntityShield entityShield = entity_0.vmethod_18();
			if (entityShield != null)
			{
				if (flag)
				{
					entityShield.method_22(damageInfo_0.m_shieldDamagePoints);
					MonoSingleton<ScoringManager>.Instance.method_13(entity_0);
				}
				else if (bool_0)
				{
					num = entityShield.method_21(damageInfo_0.m_shieldDamagePoints);
				}
				else
				{
					num = entityShield.method_20(damageInfo_0.m_shieldDamagePoints);
				}
			}
			else if (!flag)
			{
				DebugUtils.LogError(LogCategory.Gamelogic, string.Concat(new string[]
				{
					"Shield Damage: [",
					damageInfo_0.m_shieldDamagePoints.ToString(),
					"] on Entity: [",
					entity_0.m_name,
					"] without shield!"
				}));
			}
		}
		int num2 = damageInfo_0.m_healthDamagePoints;
		int num3 = 0;
		WeakPoint weakPoint = entity_0.vmethod_21().method_12(damageInfo_0.m_weakPointIndex);
		if (weakPoint != null && !flag)
		{
			int num4 = equipmentInventoryEntity.vmethod_29(weakPoint);
			if (num4 > 0)
			{
				if (bool_0)
				{
					equipmentInventoryEntity.vmethod_31(weakPoint, num4 - damageInfo_0.m_healthDamagePoints);
					num3 = num4 - equipmentInventoryEntity.vmethod_29(weakPoint);
				}
				else
				{
					num3 = damageInfo_0.m_healthDamagePoints;
				}
				num2 -= num3;
			}
		}
		int num5 = num2;
		if (num2 > 0)
		{
			int num6 = equipmentInventoryEntity.vmethod_4();
			if (flag)
			{
				equipmentInventoryEntity.vmethod_5(num6 + num2);
			}
			else if (bool_0)
			{
				equipmentInventoryEntity.vmethod_5(Mathf.Max(0, num6 - num2));
				num5 = num6 - equipmentInventoryEntity.vmethod_4();
			}
		}
		if (!bool_0)
		{
			equipmentInventoryEntity.vmethod_35();
		}
		if (!MonoSingleton<AppManager>.Instance.m_noimpact && MonoSingleton<ImpactManager>.Instance != null)
		{
			MonoSingleton<ImpactManager>.Instance.method_18(entity_0, damageInfo_0, num, num5 + num3, bool_0);
		}
		return flag2;
	}

	// Token: 0x060023D9 RID: 9177 RVA: 0x000188CC File Offset: 0x00016ACC
	public void method_14(int int_0, int int_1)
	{
		base.photonView.method_4("RPC_H2L_ElementalResist", PhotonTargets.Others, new object[] { int_0, int_1 });
	}

	// Token: 0x060023DA RID: 9178 RVA: 0x000AA5C0 File Offset: 0x000A87C0
	[RPC]
	private void RPC_D(Hashtable t)
	{
		PlayerInfoSync localPlayer = MonoSingleton<Session>.Instance.GetLocalPlayer();
		if (localPlayer == null)
		{
			return;
		}
		if (localPlayer.PlayerState_0 < PlayerInfoSync.PlayerState.PlayerAndMapReady)
		{
			return;
		}
		for (int i = 0; i < t.Count; i++)
		{
			this.method_9(t[i] as Hashtable);
		}
	}

	// Token: 0x060023DB RID: 9179 RVA: 0x000AA614 File Offset: 0x000A8814
	[RPC]
	private void RPC_H2L_ElementalResist(int id_attacker, int id_victim, PhotonMessageInfo info)
	{
		Entity entity = BadAssNetworkView.smethod_4(id_victim);
		Entity entity2 = BadAssNetworkView.smethod_4(id_attacker);
		if (!MonoSingleton<AppManager>.Instance.m_noimpact && MonoSingleton<ImpactManager>.Instance != null)
		{
			MonoSingleton<ImpactManager>.Instance.method_12(entity2, entity);
		}
	}

	// Token: 0x060023DC RID: 9180 RVA: 0x000188F7 File Offset: 0x00016AF7
	public int method_15()
	{
		return this.m_damageSystem.method_3();
	}

	// Token: 0x060023DD RID: 9181 RVA: 0x00018904 File Offset: 0x00016B04
	public int method_16()
	{
		return this.m_damageSystem.method_4();
	}

	// Token: 0x060023DE RID: 9182 RVA: 0x00018911 File Offset: 0x00016B11
	public int method_17(AvatarType avatarType_0, WeaponType weaponType_0)
	{
		return this.m_damageSystem.method_28(avatarType_0, weaponType_0);
	}

	// Token: 0x060023DF RID: 9183 RVA: 0x000AA654 File Offset: 0x000A8854
	public bool method_18(int int_0, int int_1)
	{
		for (int i = 0; i < this.m_criticalHitList.Count; i++)
		{
			HitInfo hitInfo = this.m_criticalHitList[i];
			if ((hitInfo.m_from == int_0 || hitInfo.m_owner == int_0) && hitInfo.m_to == int_1)
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x060023E0 RID: 9184 RVA: 0x00018920 File Offset: 0x00016B20
	public void method_19(HitInfo hitInfo_0)
	{
		this.m_criticalHitList.Add(hitInfo_0);
	}

	// Token: 0x060023E1 RID: 9185 RVA: 0x000AA6A4 File Offset: 0x000A88A4
	public void method_20(int int_0, int int_1)
	{
		for (int i = this.m_criticalHitList.Count - 1; i >= 0; i--)
		{
			HitInfo hitInfo = this.m_criticalHitList[i];
			if ((hitInfo.m_from == int_0 || hitInfo.m_owner == int_0) && hitInfo.m_to == int_1)
			{
				this.m_criticalHitList.RemoveAt(i);
			}
		}
	}

	// Token: 0x060023E2 RID: 9186 RVA: 0x000AA700 File Offset: 0x000A8900
	public bool method_21(Entity entity_0)
	{
		EntityPlayer entityPlayer = entity_0 as EntityPlayer;
		if (entityPlayer != null)
		{
			float num = entityPlayer.PlayerEffectManager_0.method_0(EffectType.CriticalChance);
			float num2 = entityPlayer.method_147();
			if (num > 0f && num2 <= num)
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x04001885 RID: 6277
	private DamageSystem m_damageSystem = new DamageSystem();

	// Token: 0x04001886 RID: 6278
	private Dictionary<Pair<int, short>, List<DamageContext>> m_damageBuffer = new Dictionary<Pair<int, short>, List<DamageContext>>();

	// Token: 0x04001887 RID: 6279
	private Dictionary<Pair<int, short>, List<DamageContext>> m_appliedDamageBuffer = new Dictionary<Pair<int, short>, List<DamageContext>>();

	// Token: 0x04001888 RID: 6280
	private List<Entity> m_damageableEntities = new List<Entity>();

	// Token: 0x04001889 RID: 6281
	private List<IDamageListener> m_damageListeners = new List<IDamageListener>();

	// Token: 0x0400188A RID: 6282
	private static DamageManager s_instance;

	// Token: 0x0400188B RID: 6283
	private Dictionary<int, int> m_multiKillsToSerialize = new Dictionary<int, int>();

	// Token: 0x0400188C RID: 6284
	private List<HitInfo> m_criticalHitList = new List<HitInfo>();
}
