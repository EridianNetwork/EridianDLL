using System;
using System.Collections.Generic;
using Core;
using ns0;
using Photon;
using UnityEngine;
using XsdSettings;

// Token: 0x0200054D RID: 1357
public class SkillTreeStatus : global::Photon.MonoBehaviour
{
	// Token: 0x060022F2 RID: 8946 RVA: 0x00017FB6 File Offset: 0x000161B6
	private void Awake()
	{
		this.m_skilldata_initialized_client = false;
		this.m_cacheDataReceived_client = string.Empty;
	}

	// Token: 0x060022F3 RID: 8947 RVA: 0x000A5CC8 File Offset: 0x000A3EC8
	public void method_0()
	{
		this.m_owner = base.GetComponent<EntityPlayer>();
		this.m_data.Clear();
		this.m_theTypeList = this.m_owner.PlayerSkillManage_0.method_2();
		for (int i = 0; i < this.m_theTypeList.Count; i++)
		{
			this.m_data.Add(this.m_theTypeList[i], new SkillTreeStatus.SkillStatus());
		}
		this.m_skilldata_initialized_client = true;
		if (this.m_cacheDataReceived_client != string.Empty)
		{
			this.method_10(this.m_cacheDataReceived_client);
		}
		SkillTreeStatus.smethod_0();
	}

	// Token: 0x060022F4 RID: 8948 RVA: 0x000A5D60 File Offset: 0x000A3F60
	private static void smethod_0()
	{
		if (SkillTreeStatus.m_effectInSKillDict != null)
		{
			return;
		}
		SkillTreeStatus.m_effectInSKillDict = new Dictionary<int, List<SkillTreeStatus.EffectInSkillData>>();
		SkillSetup skillSetup = ServiceWrapperBase<SkillTreeServiceWrapper>.Instance.method_0();
		for (int i = 0; i < skillSetup.m_skills.Length; i++)
		{
			Skill skill = skillSetup.m_skills[i];
			for (int j = 0; j < skill.m_effectList.Length; j++)
			{
				Effect effect = skill.m_effectList[j];
				if (effect.m_type != EffectType.Invalid)
				{
					SkillTreeStatus.EffectInSkillData effectInSkillData = new SkillTreeStatus.EffectInSkillData(skill.m_id, effect);
					if (SkillTreeStatus.m_effectInSKillDict.ContainsKey((int)effect.m_type))
					{
						SkillTreeStatus.m_effectInSKillDict[(int)effect.m_type].Add(effectInSkillData);
					}
					else
					{
						List<SkillTreeStatus.EffectInSkillData> list = new List<SkillTreeStatus.EffectInSkillData>();
						list.Add(effectInSkillData);
						SkillTreeStatus.m_effectInSKillDict.Add((int)effect.m_type, list);
					}
				}
			}
		}
	}

	// Token: 0x060022F5 RID: 8949 RVA: 0x000A5E34 File Offset: 0x000A4034
	private static void smethod_1()
	{
		int num = 0;
		string text = string.Empty;
		foreach (object obj in Enum.GetValues(typeof(EffectType)))
		{
			EffectType effectType = (EffectType)((int)obj);
			if (effectType != EffectType.Invalid)
			{
				if (effectType != EffectType.Max)
				{
					if (!SkillTreeStatus.m_effectInSKillDict.ContainsKey((int)effectType) && !SkillTreeStatus.m_effectOperationList.ContainsKey((int)effectType))
					{
						num++;
						text = text + effectType + " , ";
					}
				}
			}
		}
		if (num > 0)
		{
			DebugUtils.LogError(LogCategory.Gamelogic, string.Format("{0} effect operation missing: {1}", num, text));
		}
	}

	// Token: 0x060022F6 RID: 8950 RVA: 0x00017FCA File Offset: 0x000161CA
	public bool method_1(ESkillType eskillType_0)
	{
		return this.m_data[(int)eskillType_0].m_grade > 0;
	}

	// Token: 0x060022F7 RID: 8951 RVA: 0x00017FE0 File Offset: 0x000161E0
	public int method_2(ESkillType eskillType_0)
	{
		return this.m_data[(int)eskillType_0].m_grade;
	}

	// Token: 0x060022F8 RID: 8952 RVA: 0x000A5EF4 File Offset: 0x000A40F4
	public AffectType method_3(EffectType effectType_0)
	{
		List<SkillTreeStatus.EffectInSkillData> list;
		if (SkillTreeStatus.m_effectInSKillDict.TryGetValue((int)effectType_0, out list))
		{
			string operation = list[0].m_effectData.m_operation;
			for (int i = 0; i < 3; i++)
			{
				AffectType affectType = (AffectType)i;
				if (string.Equals(operation, Utils.smethod_22(affectType), StringComparison.OrdinalIgnoreCase))
				{
					return affectType;
				}
			}
			DebugUtils.LogError(LogCategory.Gamelogic, string.Format("GetOperation() 111 {0}", effectType_0));
		}
		else
		{
			AffectType affectType2;
			if (SkillTreeStatus.m_effectOperationList.TryGetValue((int)effectType_0, out affectType2))
			{
				return affectType2;
			}
			DebugUtils.LogError(LogCategory.Gamelogic, string.Format("GetOperation() {0} not exist", effectType_0));
		}
		return AffectType.Scale;
	}

	// Token: 0x060022F9 RID: 8953 RVA: 0x000A5F88 File Offset: 0x000A4188
	public float method_4(EffectType effectType_0)
	{
		AffectType affectType = this.method_3(effectType_0);
		float num = this.method_5(affectType);
		List<SkillTreeStatus.EffectInSkillData> list;
		if (SkillTreeStatus.m_effectInSKillDict.TryGetValue((int)effectType_0, out list))
		{
			int i = 0;
			while (i < list.Count)
			{
				SkillTreeStatus.SkillStatus skillStatus;
				if (!this.m_data.TryGetValue(list[i].m_skillID, out skillStatus))
				{
					i++;
				}
				else
				{
					Effect effectData = list[i].m_effectData;
					int grade = skillStatus.m_grade;
					num = this.method_6(grade, effectData.m_firstGrade, effectData.m_perGrade);
					if (affectType == AffectType.Scale)
					{
						num += 1f;
						break;
					}
					break;
				}
			}
		}
		return num;
	}

	// Token: 0x060022FA RID: 8954 RVA: 0x00017FF3 File Offset: 0x000161F3
	public float method_5(AffectType affectType_0)
	{
		if (affectType_0 == AffectType.Scale)
		{
			return 1f;
		}
		if (affectType_0 == AffectType.PostAdd)
		{
			return 0f;
		}
		return 0f;
	}

	// Token: 0x060022FB RID: 8955 RVA: 0x0001800E File Offset: 0x0001620E
	private float method_6(int int_0, float float_0, float float_1)
	{
		return (int_0 != 0) ? (float_0 + (float)(int_0 - 1) * float_1) : 0f;
	}

	// Token: 0x060022FC RID: 8956 RVA: 0x00018022 File Offset: 0x00016222
	public float method_7(ESkillType eskillType_0, int int_0 = 0)
	{
		return ServiceWrapperBase<SkillTreeServiceWrapper>.Instance.method_4((int)eskillType_0).m_effectList[int_0].m_duration;
	}

	// Token: 0x060022FD RID: 8957 RVA: 0x000A6024 File Offset: 0x000A4224
	private bool method_8(ESkillType eskillType_0, EffectType effectType_0)
	{
		foreach (Effect effect in ServiceWrapperBase<SkillTreeServiceWrapper>.Instance.method_4((int)eskillType_0).m_effectList)
		{
			if (effect.m_type == effectType_0)
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x060022FE RID: 8958 RVA: 0x000A6064 File Offset: 0x000A4264
	public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
	{
		if (!stream.IsWriting)
		{
			string text = (string)stream.ReceiveNext();
			if (this.m_skilldata_initialized_client)
			{
				this.method_10(text);
			}
			else
			{
				this.m_cacheDataReceived_client = text;
			}
		}
	}

	// Token: 0x060022FF RID: 8959 RVA: 0x000A60A0 File Offset: 0x000A42A0
	private string method_9()
	{
		string text = string.Empty;
		for (int i = 0; i < this.m_theTypeList.Count; i++)
		{
			text = string.Concat(new object[]
			{
				text,
				this.m_theTypeList[i],
				":",
				this.m_data[this.m_theTypeList[i]].m_grade,
				";"
			});
		}
		return text;
	}

	// Token: 0x06002300 RID: 8960 RVA: 0x000A6124 File Offset: 0x000A4324
	private void method_10(string string_0)
	{
		string[] array = string_0.Split(new char[] { ';' });
		for (int i = 0; i < array.Length; i++)
		{
			if (array[i].Length > 0)
			{
				string[] array2 = array[i].Split(new char[] { ':' });
				int num = Convert.ToInt32(array2[0]);
				int num2 = Convert.ToInt32(array2[1]);
				this.m_data[num].m_grade = num2;
			}
		}
	}

	// Token: 0x06002301 RID: 8961 RVA: 0x0001803B File Offset: 0x0001623B
	public void method_11(EntityShield entityShield_0)
	{
		this.method_12(entityShield_0);
	}

	// Token: 0x06002302 RID: 8962 RVA: 0x000A6198 File Offset: 0x000A4398
	private void method_12(EntityShield entityShield_0)
	{
		if (entityShield_0 == null)
		{
			return;
		}
		float num = this.m_owner.PlayerEffectManager_0.method_0(EffectType.EnlargeMaxShield);
		float num2 = this.m_owner.PlayerEffectManager_0.method_0(EffectType.WeaponMaxShieldScale);
		float num3 = this.m_owner.PlayerEffectManager_0.method_2(EffectType.WeaponMaxShieldPostAdd);
		float num4 = (float)entityShield_0.m_shieldPoints.method_6();
		float num5 = num4 * (num2 + num - 1f) + num3;
		if (MonoSingleton<Session>.Instance.method_12())
		{
			int num6 = this.m_owner.vmethod_3();
			float num7 = MonoSingleton<LevelingManager>.Instance.method_6(num6);
			float num8 = MonoSingleton<LevelingManager>.Instance.method_7();
			float num9 = num8 / num7;
			num5 *= num9;
		}
		entityShield_0.m_shieldPoints.method_7((int)num5);
	}

	// Token: 0x06002303 RID: 8963 RVA: 0x000A6254 File Offset: 0x000A4454
	private int method_13()
	{
		EntityWeapon entityWeapon = this.method_14();
		if (entityWeapon != null)
		{
			return entityWeapon.vmethod_3();
		}
		return this.m_owner.vmethod_3();
	}

	// Token: 0x06002304 RID: 8964 RVA: 0x000A6284 File Offset: 0x000A4484
	private EntityWeapon method_14()
	{
		EquipmentInventoryEntity equipmentInventoryEntity = this.m_owner.vmethod_19();
		if (equipmentInventoryEntity == null)
		{
			return null;
		}
		return equipmentInventoryEntity.vmethod_27();
	}

	// Token: 0x06002305 RID: 8965 RVA: 0x000A62B0 File Offset: 0x000A44B0
	[RPC]
	private void RPC_H2C_SetShieldMax(int _max, PhotonMessageInfo info)
	{
		if (this.m_owner == null)
		{
			return;
		}
		EntityShield entityShield = this.m_owner.vmethod_18();
		if (entityShield != null && entityShield.m_shieldPoints != null)
		{
			entityShield.m_shieldPoints.method_7(_max);
			if (MonoSingleton<Session>.Instance.method_12() && !this.m_sync_maxShield_PVP)
			{
				this.m_sync_maxShield_PVP = true;
				entityShield.m_shieldPoints.method_8(_max);
			}
		}
		else
		{
			this.m_newMaxShield_PVP_Init = _max;
		}
	}

	// Token: 0x06002306 RID: 8966 RVA: 0x000A6328 File Offset: 0x000A4528
	[RPC]
	private void RPC_H2C_SetMaxHP(int _max, PhotonMessageInfo _info)
	{
		if (this.m_owner != null && this.m_owner.vmethod_19() != null)
		{
			this.m_owner.vmethod_19().vmethod_1(_max);
			if (this.m_owner.vmethod_19().vmethod_4() > _max)
			{
				this.m_owner.vmethod_19().vmethod_5(_max);
			}
			if (MonoSingleton<Session>.Instance.method_12() && !this.m_sync_maxHP_PVP)
			{
				this.m_sync_maxHP_PVP = true;
				this.m_owner.vmethod_19().vmethod_5(_max);
			}
		}
		else
		{
			this.m_newMaxHP_PVP_Init = _max;
		}
	}

	// Token: 0x06002307 RID: 8967 RVA: 0x000A63C0 File Offset: 0x000A45C0
	private void Update()
	{
		if (MonoSingleton<Session>.Instance.method_12())
		{
			if (!this.m_sync_maxHP_PVP && this.m_newMaxHP_PVP_Init > 0 && this.m_owner != null && this.m_owner.vmethod_19() != null)
			{
				this.m_sync_maxHP_PVP = true;
				EquipmentInventoryEntity equipmentInventoryEntity = this.m_owner.vmethod_19();
				equipmentInventoryEntity.vmethod_1(this.m_newMaxHP_PVP_Init);
				equipmentInventoryEntity.vmethod_5(this.m_newMaxHP_PVP_Init);
			}
			if (!this.m_sync_maxShield_PVP && this.m_newMaxShield_PVP_Init > 0 && this.m_owner != null && this.m_owner.vmethod_18() != null)
			{
				this.m_sync_maxShield_PVP = true;
				EntityShield entityShield = this.m_owner.vmethod_18();
				entityShield.m_shieldPoints.method_7(this.m_newMaxShield_PVP_Init);
				entityShield.m_shieldPoints.method_8(this.m_newMaxShield_PVP_Init);
			}
		}
	}

	// Token: 0x06002308 RID: 8968 RVA: 0x000A64A0 File Offset: 0x000A46A0
	[RPC]
	private void RPC_H2C_SetShieldMax_InTown(float skillScale, float weaponScale, float weaponPostAdd, float curPowerRating, PhotonMessageInfo _info)
	{
		if (this.m_owner == null)
		{
			DebugUtils.LogError(LogCategory.Gamelogic, "Sync Shield In Town Error, m_owner == null");
			return;
		}
		EntityShield entityShield = this.m_owner.vmethod_18();
		if (entityShield != null && entityShield.m_shieldPoints != null)
		{
			float num = (float)entityShield.m_shieldPoints.method_6();
			float num2 = num * (weaponScale + skillScale - 1f) + weaponPostAdd * curPowerRating;
			entityShield.m_shieldPoints.method_7((int)num2);
		}
	}

	// Token: 0x06002309 RID: 8969 RVA: 0x00018044 File Offset: 0x00016244
	public void method_15()
	{
		if (this.m_owner.vmethod_25().IsMyActor())
		{
			base.photonView.method_4("RPC_L2H_AskForShield", PhotonTargets.MasterClient, new object[0]);
		}
	}

	// Token: 0x040017AA RID: 6058
	private EntityPlayer m_owner;

	// Token: 0x040017AB RID: 6059
	public Dictionary<int, SkillTreeStatus.SkillStatus> m_data = new Dictionary<int, SkillTreeStatus.SkillStatus>();

	// Token: 0x040017AC RID: 6060
	private List<int> m_theTypeList = new List<int>();

	// Token: 0x040017AD RID: 6061
	private bool m_skilldata_initialized_client;

	// Token: 0x040017AE RID: 6062
	private string m_cacheDataReceived_client = string.Empty;

	// Token: 0x040017AF RID: 6063
	private static Dictionary<int, List<SkillTreeStatus.EffectInSkillData>> m_effectInSKillDict = null;

	// Token: 0x040017B0 RID: 6064
	private static Dictionary<int, AffectType> m_effectOperationList = new Dictionary<int, AffectType>
	{
		{
			55,
			AffectType.PostAdd
		},
		{
			56,
			AffectType.PostAdd
		},
		{
			83,
			AffectType.Scale
		},
		{
			84,
			AffectType.Scale
		},
		{
			85,
			AffectType.Scale
		},
		{
			86,
			AffectType.PostAdd
		},
		{
			87,
			AffectType.Scale
		},
		{
			88,
			AffectType.PostAdd
		},
		{
			89,
			AffectType.Scale
		},
		{
			90,
			AffectType.PostAdd
		},
		{
			91,
			AffectType.PostAdd
		},
		{
			92,
			AffectType.Scale
		},
		{
			93,
			AffectType.Scale
		},
		{
			94,
			AffectType.PostAdd
		},
		{
			95,
			AffectType.PostAdd
		},
		{
			96,
			AffectType.Scale
		},
		{
			97,
			AffectType.PostAdd
		},
		{
			98,
			AffectType.PostAdd
		},
		{
			99,
			AffectType.PostAdd
		},
		{
			100,
			AffectType.Scale
		},
		{
			101,
			AffectType.PostAdd
		},
		{
			102,
			AffectType.Scale
		},
		{
			103,
			AffectType.Scale
		},
		{
			104,
			AffectType.PostAdd
		},
		{
			105,
			AffectType.PostAdd
		},
		{
			106,
			AffectType.PostAdd
		},
		{
			107,
			AffectType.Scale
		},
		{
			108,
			AffectType.Scale
		},
		{
			109,
			AffectType.Scale
		},
		{
			110,
			AffectType.Scale
		},
		{
			111,
			AffectType.Scale
		},
		{
			112,
			AffectType.Scale
		},
		{
			113,
			AffectType.PostAdd
		},
		{
			114,
			AffectType.Scale
		},
		{
			116,
			AffectType.Scale
		},
		{
			115,
			AffectType.PostAdd
		},
		{
			117,
			AffectType.PostAdd
		},
		{
			118,
			AffectType.Scale
		},
		{
			119,
			AffectType.PostAdd
		},
		{
			120,
			AffectType.PostAdd
		},
		{
			121,
			AffectType.PostAdd
		},
		{
			122,
			AffectType.PostAdd
		},
		{
			123,
			AffectType.PostAdd
		},
		{
			124,
			AffectType.PostAdd
		},
		{
			125,
			AffectType.PostAdd
		},
		{
			126,
			AffectType.PostAdd
		},
		{
			127,
			AffectType.PostAdd
		},
		{
			128,
			AffectType.PostAdd
		},
		{
			129,
			AffectType.PostAdd
		},
		{
			130,
			AffectType.PostAdd
		},
		{
			131,
			AffectType.PostAdd
		},
		{
			132,
			AffectType.PostAdd
		},
		{
			133,
			AffectType.PostAdd
		},
		{
			134,
			AffectType.PostAdd
		},
		{
			135,
			AffectType.PostAdd
		},
		{
			136,
			AffectType.PostAdd
		},
		{
			137,
			AffectType.PostAdd
		},
		{
			138,
			AffectType.PostAdd
		},
		{
			139,
			AffectType.PostAdd
		},
		{
			140,
			AffectType.PostAdd
		},
		{
			54,
			AffectType.PostAdd
		},
		{
			64,
			AffectType.Scale
		}
	};

	// Token: 0x040017B1 RID: 6065
	private int m_newMaxHP_PVP_Init;

	// Token: 0x040017B2 RID: 6066
	private bool m_sync_maxHP_PVP;

	// Token: 0x040017B3 RID: 6067
	private int m_newMaxShield_PVP_Init;

	// Token: 0x040017B4 RID: 6068
	private bool m_sync_maxShield_PVP;

	// Token: 0x0200054E RID: 1358
	public class SkillStatus
	{
		// Token: 0x040017B5 RID: 6069
		public int m_grade;
	}

	// Token: 0x0200054F RID: 1359
	public class EffectInSkillData
	{
		// Token: 0x0600230B RID: 8971 RVA: 0x0001806F File Offset: 0x0001626F
		public EffectInSkillData(int int_0, Effect effect_0)
		{
			this.m_skillID = int_0;
			this.m_effectData = effect_0;
		}

		// Token: 0x040017B6 RID: 6070
		public int m_skillID;

		// Token: 0x040017B7 RID: 6071
		public Effect m_effectData;
	}

	// Token: 0x02000550 RID: 1360
	// (Invoke) Token: 0x0600230D RID: 8973
	public delegate void SkillUpgradeHandler(int grade);
}
