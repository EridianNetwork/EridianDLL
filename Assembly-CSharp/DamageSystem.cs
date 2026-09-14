using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using Core;
using ns0;
using UnityEngine;
using XsdSettings;

// Token: 0x02000577 RID: 1399
internal class DamageSystem
{
	// Token: 0x060023E6 RID: 9190 RVA: 0x000AA744 File Offset: 0x000A8944
	public void method_0()
	{
		TextAsset textAsset = ResourcesLoader.smethod_0("ElementalDamageTable") as TextAsset;
		using (MemoryStream memoryStream = new MemoryStream(textAsset.bytes))
		{
			XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<ElementalDamageSettings>));
			this.m_elementalDamageSettings = xmlSerializer.Deserialize(memoryStream) as List<ElementalDamageSettings>;
		}
		Resources.UnloadAsset(textAsset);
		TextAsset textAsset2 = ResourcesLoader.smethod_0("BOL_DamageSettings") as TextAsset;
		using (MemoryStream memoryStream2 = new MemoryStream(textAsset2.bytes))
		{
			XmlSerializer xmlSerializer2 = new XmlSerializer(typeof(DamageSettings));
			this.m_damageSettings = xmlSerializer2.Deserialize(memoryStream2) as DamageSettings;
		}
		Resources.UnloadAsset(textAsset2);
	}

	// Token: 0x060023E7 RID: 9191 RVA: 0x000AA814 File Offset: 0x000A8A14
	private ElementalDamageSettings method_1(AttackInfo.ElementalType elementalType_0)
	{
		for (int i = 0; i < this.m_elementalDamageSettings.Count; i++)
		{
			if (this.m_elementalDamageSettings[i].m_elemental == elementalType_0)
			{
				return this.m_elementalDamageSettings[i];
			}
		}
		return null;
	}

	// Token: 0x060023E8 RID: 9192 RVA: 0x000AA85C File Offset: 0x000A8A5C
	public float method_2(AttackInfo.ElementalType elementalType_0, Entity entity_0, Entity entity_1)
	{
		float num = this.method_1(elementalType_0).m_effectDuration;
		if (entity_0 != null && entity_0 is EntityPlayer)
		{
			float num2 = (entity_0 as EntityPlayer).PlayerEffectManager_0.method_0(EffectType.DecreaseElementalDuration);
			num *= num2;
		}
		if (entity_1 != null && entity_1 is EntityPlayer)
		{
			float num3 = (entity_1 as EntityPlayer).PlayerEffectManager_0.method_0(EffectType.ExtendElementalDOT);
			num *= num3;
		}
		return num;
	}

	// Token: 0x060023E9 RID: 9193 RVA: 0x0001896D File Offset: 0x00016B6D
	public int method_3()
	{
		return this.m_damageSettings.m_DOT_LIMIT_PLAYER;
	}

	// Token: 0x060023EA RID: 9194 RVA: 0x0001897A File Offset: 0x00016B7A
	public int method_4()
	{
		return this.m_damageSettings.m_DOT_LIMIT_AI;
	}

	// Token: 0x060023EB RID: 9195 RVA: 0x000AA8C8 File Offset: 0x000A8AC8
	private float method_5(float float_0)
	{
		if (MonoSingleton<Session>.Instance.method_12())
		{
			return Mathf.Clamp(float_0, this.m_damageSettings.m_pvp_damageMin, this.m_damageSettings.m_pvp_damageMax);
		}
		return Mathf.Clamp(float_0, this.m_damageSettings.m_pve_damageMin, this.m_damageSettings.m_pve_damageMax);
	}

	// Token: 0x060023EC RID: 9196 RVA: 0x000AA91C File Offset: 0x000A8B1C
	public bool method_6(HitInfo hitInfo_0, bool bool_0, ref DamageInfo damageInfo_0)
	{
		Entity entity = BadAssNetworkView.smethod_4(hitInfo_0.m_to);
		Entity entity2 = BadAssNetworkView.smethod_4(hitInfo_0.m_owner);
		int num = 0;
		int num2 = 0;
		int num3 = 0;
		if (entity.vmethod_51())
		{
			return false;
		}
		if (!entity.vmethod_53() && this.method_13(entity) > 0)
		{
			float num4 = this.method_5((float)hitInfo_0.m_damagePoint);
			WeakPoint weakPoint = entity.vmethod_21().method_12((int)hitInfo_0.m_weakPointIndex);
			float num5;
			if (AttackInfo.smethod_0(hitInfo_0.m_attackSubType) == AttackInfo.AttackType.DamageOverTime)
			{
				WeakPoint weakPoint2 = entity.vmethod_21().method_12(entity.method_7());
				num5 = this.method_23(entity, weakPoint2);
			}
			else
			{
				num5 = this.method_23(entity, weakPoint);
				if (num5 <= 1f && DamageManager.DamageManager_0.method_21(entity2))
				{
					int num6 = ((!MonoSingleton<Session>.Instance.method_12()) ? 0 : 1);
					num5 = this.m_damageSettings.m_weakpointStrengthModifiers[num6];
					DamageManager.DamageManager_0.method_19(hitInfo_0);
				}
			}
			bool flag = num5 > 1f;
			if (num5 > 1E-45f)
			{
				float num7 = this.method_15(entity2, hitInfo_0);
				float num8 = this.method_16(entity2, hitInfo_0);
				float num9 = this.method_17(entity2, hitInfo_0);
				float num10 = this.method_18(entity2, hitInfo_0);
				float num11 = this.method_20(entity2, hitInfo_0);
				float num12 = this.method_19(entity2, entity, hitInfo_0, flag);
				float num13 = this.method_22(entity, hitInfo_0);
				float num14 = this.method_24(entity, hitInfo_0);
				float num15 = this.method_21(entity, hitInfo_0);
				float num16 = num4;
				num16 *= num7;
				num16 *= num8;
				num16 *= num9;
				num16 *= num10;
				num16 *= num11;
				num16 *= num12;
				float num17 = 1f;
				if (flag)
				{
					EntityWeapon entityWeapon = BadAssNetworkView.smethod_4(hitInfo_0.m_from) as EntityWeapon;
					if (entityWeapon != null)
					{
						num17 = FloatAttributeValue.smethod_0(entityWeapon.m_attribute.method_1(AttributeType.CriticalHitScale) as FloatAttributeValue);
					}
				}
				float num18 = entity2.vmethod_61();
				num16 *= 1f + (num5 - 1f) * (num17 + num18 - 1f);
				num16 *= num13;
				num16 *= num14;
				num16 *= num15;
				hitInfo_0.m_damagePoint = (int)num16;
				float num19 = this.method_25(entity, hitInfo_0);
				num16 *= num19;
				if (num19 < 0f)
				{
					num16 = 0f;
				}
				else
				{
					num16 = this.method_5(num16);
				}
				int num20 = this.method_12(entity);
				if (num20 > 0 && num16 > 0f && weakPoint.m_damagePropagationType == WeakPoint.DamagePropagationType.ApplyToOwner)
				{
					float num21 = this.method_26(entity, hitInfo_0);
					float num24;
					if (num21 > 1f)
					{
						float num22 = this.method_9(entity2, EffectType.ShockEnhance);
						float num23 = DamageSystem.smethod_0(entity2, entity, EffectType.ShockResistance);
						num24 = num16 * (1f + (num21 - 1f) * (1f + num22 - num23));
					}
					else
					{
						num24 = num16 * num21;
					}
					num24 = this.method_5(num24);
					num = Mathf.FloorToInt(num24);
					if (num20 >= num)
					{
						num16 = -1f;
					}
					else
					{
						num = num20;
						num16 -= (float)num20 / num21;
					}
				}
				if (num16 > 0f)
				{
					int num25 = this.method_14(entity, weakPoint);
					if (num25 > 0)
					{
						float num26 = this.method_27(weakPoint.m_matterType, hitInfo_0);
						float num29;
						if (num26 > 1f)
						{
							if (hitInfo_0.m_elementalType == AttackInfo.ElementalType.Fire)
							{
								float num27 = this.method_9(entity2, EffectType.FireEnhance);
								float num28 = DamageSystem.smethod_0(entity2, entity, EffectType.FireResistance);
								num29 = num16 * (1f + (num26 - 1f) * (1f + num27 - num28));
							}
							else if (hitInfo_0.m_elementalType == AttackInfo.ElementalType.Corrosive)
							{
								float num30 = this.method_9(entity2, EffectType.CorrosiveEnhance);
								float num31 = DamageSystem.smethod_0(entity2, entity, EffectType.CorrosiveResistance);
								num29 = num16 * (1f + (num26 - 1f) * (1f + num30 - num31));
							}
							else
							{
								num29 = num16 * num26;
							}
						}
						else
						{
							num29 = num16 * num26;
						}
						num29 = this.method_5(num29);
						int num32 = Mathf.FloorToInt(num29);
						if (num25 >= num32)
						{
							num16 = -1f;
							num2 = num32;
						}
						else
						{
							num2 = num25;
							num16 -= (float)num2;
						}
					}
				}
				if (num16 > 0f)
				{
					float num33 = this.method_27(weakPoint.m_matterType, hitInfo_0);
					num16 *= num33;
					num16 = this.method_5(num16);
					num3 = Mathf.FloorToInt(num16);
				}
			}
			damageInfo_0.m_attackSubType = hitInfo_0.m_attackSubType;
			damageInfo_0.m_elementalType = hitInfo_0.m_elementalType;
			damageInfo_0.m_isTriggeringDamageOverTime = false;
			damageInfo_0.m_from = ((hitInfo_0.m_owner == 0) ? hitInfo_0.m_from : hitInfo_0.m_owner);
			damageInfo_0.m_shieldDamagePoints = num;
			damageInfo_0.m_healthDamagePoints = num3 + num2;
			damageInfo_0.m_weakPointIndex = (int)hitInfo_0.m_weakPointIndex;
			damageInfo_0.m_force = hitInfo_0.m_rayDirection.magnitude;
			return true;
		}
		EntityPlayer entityPlayer = entity as EntityPlayer;
		if (entityPlayer != null && entityPlayer.method_67())
		{
			damageInfo_0.m_attackSubType = hitInfo_0.m_attackSubType;
			damageInfo_0.m_elementalType = hitInfo_0.m_elementalType;
			damageInfo_0.m_isTriggeringDamageOverTime = false;
			damageInfo_0.m_from = ((hitInfo_0.m_owner == 0) ? hitInfo_0.m_from : hitInfo_0.m_owner);
			damageInfo_0.m_shieldDamagePoints = 0;
			damageInfo_0.m_healthDamagePoints = 1;
			damageInfo_0.m_weakPointIndex = (int)hitInfo_0.m_weakPointIndex;
			damageInfo_0.m_force = hitInfo_0.m_rayDirection.magnitude;
			return true;
		}
		return false;
	}

	// Token: 0x060023ED RID: 9197 RVA: 0x000AAE48 File Offset: 0x000A9048
	private bool method_7(HitInfo hitInfo_0, Entity entity_0, EntityWeapon entityWeapon_0)
	{
		if (!this.method_11(hitInfo_0, entityWeapon_0))
		{
			return false;
		}
		float num = entity_0.vmethod_54(entityWeapon_0, hitInfo_0.m_to);
		MonoSingleton<StateDamageManager>.Instance.method_0(hitInfo_0, num, this.method_2(hitInfo_0.m_elementalType, BadAssNetworkView.smethod_4(hitInfo_0.m_to), entity_0));
		return true;
	}

	// Token: 0x060023EE RID: 9198 RVA: 0x000AAE94 File Offset: 0x000A9094
	public bool method_8(HitInfo hitInfo_0, float float_0, ref DamageInfo damageInfo_0)
	{
		damageInfo_0.m_attackSubType = hitInfo_0.m_attackSubType;
		damageInfo_0.m_elementalType = hitInfo_0.m_elementalType;
		damageInfo_0.m_isTriggeringDamageOverTime = true;
		damageInfo_0.m_from = ((hitInfo_0.m_owner == 0) ? hitInfo_0.m_from : hitInfo_0.m_owner);
		damageInfo_0.m_shieldDamagePoints = 0;
		damageInfo_0.m_healthDamagePoints = 0;
		damageInfo_0.m_weakPointIndex = (int)hitInfo_0.m_weakPointIndex;
		damageInfo_0.m_force = hitInfo_0.m_rayDirection.magnitude;
		MonoSingleton<StateDamageManager>.Instance.method_0(hitInfo_0, float_0, this.method_2(hitInfo_0.m_elementalType, BadAssNetworkView.smethod_4(hitInfo_0.m_to), BadAssNetworkView.smethod_4(hitInfo_0.m_owner)));
		return true;
	}

	// Token: 0x060023EF RID: 9199 RVA: 0x000AAF38 File Offset: 0x000A9138
	private float method_9(Entity entity_0, EffectType effectType_0)
	{
		float num = 0f;
		if (entity_0 is EntityPlayer)
		{
			EntityPlayer entityPlayer = entity_0 as EntityPlayer;
			num = entityPlayer.PlayerEffectManager_0.method_0(effectType_0);
		}
		return num;
	}

	// Token: 0x060023F0 RID: 9200 RVA: 0x000AAF68 File Offset: 0x000A9168
	public static float smethod_0(Entity entity_0, Entity entity_1, EffectType effectType_0)
	{
		float num = 0f;
		if (entity_1 is EntityPlayer)
		{
			EntityPlayer entityPlayer = entity_1 as EntityPlayer;
			num = entityPlayer.PlayerEffectManager_0.method_2(effectType_0) + entityPlayer.PlayerEffectManager_0.method_2(EffectType.AllResistance);
			if (MonoSingleton<Session>.Instance.method_12())
			{
				num *= entityPlayer.method_72();
				num /= 200f * MonoSingleton<LevelingManager>.Instance.method_7() + num;
			}
			else
			{
				num /= 200f * MonoSingleton<LevelingManager>.Instance.method_6(entity_0.vmethod_3()) + num;
			}
		}
		return num;
	}

	// Token: 0x060023F1 RID: 9201 RVA: 0x00018987 File Offset: 0x00016B87
	public static EffectType smethod_1(AttackInfo.ElementalType elementalType_0)
	{
		if (elementalType_0 == AttackInfo.ElementalType.Fire)
		{
			return EffectType.FireResistance;
		}
		if (elementalType_0 == AttackInfo.ElementalType.Shock)
		{
			return EffectType.ShockResistance;
		}
		if (elementalType_0 == AttackInfo.ElementalType.Corrosive)
		{
			return EffectType.CorrosiveResistance;
		}
		return EffectType.Invalid;
	}

	// Token: 0x060023F2 RID: 9202 RVA: 0x000AAFF0 File Offset: 0x000A91F0
	private bool method_10(HitInfo hitInfo_0, EntityWeapon entityWeapon_0)
	{
		return !(entityWeapon_0 == null) && this.m_lastHitInfo != null && hitInfo_0 != null && (entityWeapon_0.method_99() == WeaponType.ShotGun && this.m_lastWeapon == entityWeapon_0) && Mathf.Abs((float)(this.m_lastHitInfo.m_timeStamp - hitInfo_0.m_timeStamp)) < 0.001f;
	}

	// Token: 0x060023F3 RID: 9203 RVA: 0x000AB04C File Offset: 0x000A924C
	private bool method_11(HitInfo hitInfo_0, EntityWeapon entityWeapon_0)
	{
		if (hitInfo_0.m_elementalType == AttackInfo.ElementalType.None)
		{
			return false;
		}
		Entity entity = BadAssNetworkView.smethod_4(hitInfo_0.m_to);
		if (entity == null || !entity.vmethod_59())
		{
			return false;
		}
		if (this.method_10(hitInfo_0, entityWeapon_0))
		{
			return false;
		}
		this.m_lastWeapon = entityWeapon_0;
		this.m_lastHitInfo = hitInfo_0;
		float num;
		if (entityWeapon_0 != null)
		{
			num = entityWeapon_0.method_102();
		}
		else
		{
			num = this.method_1(hitInfo_0.m_elementalType).m_baseProcRatio;
		}
		if (num <= 0f)
		{
			return false;
		}
		if (num >= 1f)
		{
			return true;
		}
		float num2 = global::UnityEngine.Random.Range(0f, 1f);
		return num2 <= num;
	}

	// Token: 0x060023F4 RID: 9204 RVA: 0x000AB0EC File Offset: 0x000A92EC
	private int method_12(Entity entity_0)
	{
		if (entity_0 == null)
		{
			return 0;
		}
		EntityShield entityShield = entity_0.vmethod_18();
		if (entityShield == null)
		{
			return 0;
		}
		return entityShield.m_shieldPoints.method_5();
	}

	// Token: 0x060023F5 RID: 9205 RVA: 0x000AB124 File Offset: 0x000A9324
	private int method_13(Entity entity_0)
	{
		if (entity_0 == null)
		{
			return 0;
		}
		EquipmentInventoryEntity equipmentInventoryEntity = entity_0.vmethod_19();
		if (equipmentInventoryEntity == null)
		{
			return 0;
		}
		return equipmentInventoryEntity.vmethod_4();
	}

	// Token: 0x060023F6 RID: 9206 RVA: 0x000AB154 File Offset: 0x000A9354
	private int method_14(Entity entity_0, WeakPoint weakPoint_0)
	{
		if (weakPoint_0 == null)
		{
			return 0;
		}
		if (weakPoint_0.m_damagePropagationType != WeakPoint.DamagePropagationType.ApplyToSelf)
		{
			return 0;
		}
		if (entity_0 == null)
		{
			return 0;
		}
		EquipmentInventoryEntity equipmentInventoryEntity = entity_0.vmethod_19();
		if (equipmentInventoryEntity == null)
		{
			return 0;
		}
		return equipmentInventoryEntity.vmethod_29(weakPoint_0);
	}

	// Token: 0x060023F7 RID: 9207 RVA: 0x00013122 File Offset: 0x00011322
	private float method_15(Entity entity_0, HitInfo hitInfo_0)
	{
		return 1f;
	}

	// Token: 0x060023F8 RID: 9208 RVA: 0x00013122 File Offset: 0x00011322
	private float method_16(Entity entity_0, HitInfo hitInfo_0)
	{
		return 1f;
	}

	// Token: 0x060023F9 RID: 9209 RVA: 0x000189A5 File Offset: 0x00016BA5
	private float method_17(Entity entity_0, HitInfo hitInfo_0)
	{
		if (entity_0 == null)
		{
			return 1f;
		}
		return entity_0.vmethod_29(AttackInfo.smethod_0(hitInfo_0.m_attackSubType));
	}

	// Token: 0x060023FA RID: 9210 RVA: 0x000189C7 File Offset: 0x00016BC7
	private float method_18(Entity entity_0, HitInfo hitInfo_0)
	{
		if (entity_0 == null)
		{
			return 1f;
		}
		return entity_0.vmethod_30(AttackInfo.smethod_0(hitInfo_0.m_attackSubType));
	}

	// Token: 0x060023FB RID: 9211 RVA: 0x000189E9 File Offset: 0x00016BE9
	private float method_19(Entity entity_0, Entity entity_1, HitInfo hitInfo_0, bool bool_0)
	{
		if (entity_0 == null)
		{
			return 1f;
		}
		return entity_0.vmethod_36(AttackInfo.smethod_0(hitInfo_0.m_attackSubType), bool_0, entity_1);
	}

	// Token: 0x060023FC RID: 9212 RVA: 0x00018A0E File Offset: 0x00016C0E
	private float method_20(Entity entity_0, HitInfo hitInfo_0)
	{
		if (entity_0 == null)
		{
			return 1f;
		}
		return entity_0.vmethod_31();
	}

	// Token: 0x060023FD RID: 9213 RVA: 0x00018A25 File Offset: 0x00016C25
	private float method_21(Entity entity_0, HitInfo hitInfo_0)
	{
		if (entity_0 == null)
		{
			return 1f;
		}
		return entity_0.vmethod_32();
	}

	// Token: 0x060023FE RID: 9214 RVA: 0x00013122 File Offset: 0x00011322
	private float method_22(Entity entity_0, HitInfo hitInfo_0)
	{
		return 1f;
	}

	// Token: 0x060023FF RID: 9215 RVA: 0x000AB19C File Offset: 0x000A939C
	private float method_23(Entity entity_0, WeakPoint weakPoint_0)
	{
		if (weakPoint_0 == null)
		{
			return 1f;
		}
		if (this.m_damageSettings == null)
		{
			return 1f;
		}
		int num = (int)weakPoint_0.method_3();
		if (this.m_damageSettings.m_weakpointStrengthModifiers == null)
		{
			return 1f;
		}
		if (num >= 0 && this.m_damageSettings.m_weakpointStrengthModifiers.Length > num)
		{
			return this.m_damageSettings.m_weakpointStrengthModifiers[num];
		}
		return 1f;
	}

	// Token: 0x06002400 RID: 9216 RVA: 0x00013122 File Offset: 0x00011322
	private float method_24(Entity entity_0, HitInfo hitInfo_0)
	{
		return 1f;
	}

	// Token: 0x06002401 RID: 9217 RVA: 0x00018A3C File Offset: 0x00016C3C
	private float method_25(Entity entity_0, HitInfo hitInfo_0)
	{
		return entity_0.vmethod_33(entity_0, hitInfo_0);
	}

	// Token: 0x06002402 RID: 9218 RVA: 0x000AB208 File Offset: 0x000A9408
	private float method_26(Entity entity_0, HitInfo hitInfo_0)
	{
		ElementalDamageSettings elementalDamageSettings = this.method_1(hitInfo_0.m_elementalType);
		if (elementalDamageSettings == null)
		{
			return 1f;
		}
		return elementalDamageSettings.m_damageCoefShield;
	}

	// Token: 0x06002403 RID: 9219 RVA: 0x000AB234 File Offset: 0x000A9434
	private float method_27(WeakPoint.MatterType matterType_0, HitInfo hitInfo_0)
	{
		ElementalDamageSettings elementalDamageSettings = this.method_1(hitInfo_0.m_elementalType);
		if (elementalDamageSettings == null)
		{
			return 1f;
		}
		if (matterType_0 == WeakPoint.MatterType.Flesh)
		{
			return elementalDamageSettings.m_damageCoefFlesh;
		}
		if (matterType_0 != WeakPoint.MatterType.Armor)
		{
			DebugUtils.LogError(LogCategory.Gamelogic, "Invalid Matter Type: " + matterType_0.ToString());
			return 1f;
		}
		return elementalDamageSettings.m_damageCoefArmor;
	}

	// Token: 0x06002404 RID: 9220 RVA: 0x00018A46 File Offset: 0x00016C46
	public int method_28(AvatarType avatarType_0, WeaponType weaponType_0)
	{
		return m_damageSettings.m_meleeDamage[(int)((int)avatarType_0 * 5 + weaponType_0)];
	}
	// Token: 0x0400189C RID: 6300
	private DamageSettings m_damageSettings = new DamageSettings();

	// Token: 0x0400189D RID: 6301
	private List<ElementalDamageSettings> m_elementalDamageSettings = new List<ElementalDamageSettings>();

	// Token: 0x0400189E RID: 6302
	private EntityWeapon m_lastWeapon;

	// Token: 0x0400189F RID: 6303
	private HitInfo m_lastHitInfo;
}
