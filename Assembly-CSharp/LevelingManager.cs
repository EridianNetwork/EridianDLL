using System;
using System.IO;
using System.Xml.Serialization;
using Core;
using ns0;
using UnityEngine;
using XsdSettings;

// Token: 0x0200049B RID: 1179
public class LevelingManager : MonoSingleton<LevelingManager>, IDamageListener
{
	// Token: 0x06001F7E RID: 8062 RVA: 0x0009B0C0 File Offset: 0x000992C0
	private void Start()
	{
		TextAsset textAsset = (TextAsset)ResourcesLoader.smethod_0("Settings/PlayerProgression");
		using (StringReader stringReader = new StringReader(textAsset.text))
		{
			XmlSerializer xmlSerializer = new XmlSerializer(typeof(PlayerProgressionSetup));
			this.m_progressionSetup = xmlSerializer.Deserialize(stringReader) as PlayerProgressionSetup;
		}
		Resources.UnloadAsset(textAsset);
	}

	// Token: 0x06001F7F RID: 8063 RVA: 0x00015D45 File Offset: 0x00013F45
	public int method_0(AvatarType avatarType_0)
	{
		return this.m_progressionSetup.m_experienceTable[this.m_progressionSetup.m_experienceTable.Length - 1].m_requiredXp;
	}

	// Token: 0x06001F80 RID: 8064 RVA: 0x0009B130 File Offset: 0x00099330
	public int method_1(AvatarType avatarType_0)
	{
		int num = 0;
		switch (avatarType_0)
		{
		case AvatarType.SIREN:
			num = this.m_progressionSetup.m_defaultAttribute.SirenHP;
			break;
		case AvatarType.SOLDIER:
			num = this.m_progressionSetup.m_defaultAttribute.SoldierHP;
			break;
		case AvatarType.BERSERKER:
			num = this.m_progressionSetup.m_defaultAttribute.BerserkerHP;
			break;
		case AvatarType.HUNTER:
			num = this.m_progressionSetup.m_defaultAttribute.HunterHP;
			break;
		}
		return (int)((float)num * this.m_progressionSetup.m_experienceTable[this.m_progressionSetup.m_experienceTable.Length - 1].m_powerRating);
	}

	// Token: 0x06001F81 RID: 8065 RVA: 0x00015D67 File Offset: 0x00013F67
	public int method_2()
	{
		return this.m_progressionSetup.m_experienceTable.Length;
	}

	// Token: 0x06001F82 RID: 8066 RVA: 0x0009B1C8 File Offset: 0x000993C8
	public int method_3(AvatarType avatarType_0, int int_0)
	{
		for (int i = 1; i < this.m_progressionSetup.m_experienceTable.Length; i++)
		{
			if (int_0 < this.m_progressionSetup.m_experienceTable[i].m_requiredXp)
			{
				return i;
			}
		}
		return this.m_progressionSetup.m_experienceTable.Length;
	}

	// Token: 0x06001F83 RID: 8067 RVA: 0x00015D76 File Offset: 0x00013F76
	public int method_4(AvatarType avatarType_0, int int_0)
	{
		int_0--;
		if (int_0 < this.m_progressionSetup.m_experienceTable.Length)
		{
			return this.m_progressionSetup.m_experienceTable[int_0].m_requiredXp;
		}
		return this.method_0(avatarType_0);
	}

	// Token: 0x06001F84 RID: 8068 RVA: 0x0009B214 File Offset: 0x00099414
	public int method_5(AvatarType avatarType_0, int int_0)
	{
		int_0--;
		if (int_0 < this.m_progressionSetup.m_experienceTable.Length)
		{
			int num = 0;
			switch (avatarType_0)
			{
			case AvatarType.SIREN:
				num = this.m_progressionSetup.m_defaultAttribute.SirenHP;
				break;
			case AvatarType.SOLDIER:
				num = this.m_progressionSetup.m_defaultAttribute.SoldierHP;
				break;
			case AvatarType.BERSERKER:
				num = this.m_progressionSetup.m_defaultAttribute.BerserkerHP;
				break;
			case AvatarType.HUNTER:
				num = this.m_progressionSetup.m_defaultAttribute.HunterHP;
				break;
			}
			float num2 = (float)num * this.m_progressionSetup.m_experienceTable[int_0].m_powerRating;
			return (int)num2;
		}
		return this.method_1(avatarType_0);
	}

	// Token: 0x06001F85 RID: 8069 RVA: 0x00015DA9 File Offset: 0x00013FA9
	public float method_6(int int_0)
	{
		int_0--;
		if (int_0 < this.m_progressionSetup.m_experienceTable.Length)
		{
			return this.m_progressionSetup.m_experienceTable[int_0].m_powerRating;
		}
		return this.method_7();
	}

	// Token: 0x06001F86 RID: 8070 RVA: 0x00015DDB File Offset: 0x00013FDB
	public float method_7()
	{
		return this.m_progressionSetup.m_experienceTable[this.m_progressionSetup.m_experienceTable.Length - 1].m_powerRating;
	}

	// Token: 0x06001F87 RID: 8071 RVA: 0x0000311B File Offset: 0x0000131B
	public void OnDamaged(DamageContext context)
	{
	}

	// Token: 0x06001F88 RID: 8072 RVA: 0x0009B2C0 File Offset: 0x000994C0
	public void OnEntityKill(KillContext context)
	{
		if (context.m_victim != null)
		{
			Entity.EntityType entityType = context.m_victim.vmethod_8();
			if (entityType == Entity.EntityType.Npc)
			{
				if (context.m_killer != null && context.m_killer.vmethod_8() == Entity.EntityType.Player)
				{
					StatisticsManager.SessionStats currentSession = MonoSingleton<StatisticsManager>.Instance.GetCurrentSession();
					if (currentSession != null)
					{
						PlayerInfoSync playerInfoSync = context.m_killer.vmethod_25();
						EntityNpc entityNpc = context.m_victim as EntityNpc;
						if (entityNpc != null)
						{
							int num = MonoSingleton<ScoringManager>.Instance.method_16(entityNpc.method_16());
							StatisticsManager.StatSheet personalStatSheet = currentSession.GetPersonalStatSheet(playerInfoSync);
							if (personalStatSheet != null)
							{
								personalStatSheet.m_score += num;
							}
						}
					}
				}
			}
		}
	}

	// Token: 0x06001F89 RID: 8073 RVA: 0x0009B374 File Offset: 0x00099574
	private void OnLevelUp(PlayerInfoSync player)
	{
		DebugUtils.Log(LogCategory.Gamelogic, "LevelUP");
		if (player != null)
		{
			Entity entity = player.GetEntity();
			if (entity != null)
			{
				AvatarType avatarType = player.m_avatarDna.method_5();
				EquipmentInventoryEntityPlayer equipmentInventoryEntityPlayer = entity.vmethod_19() as EquipmentInventoryEntityPlayer;
				if (equipmentInventoryEntityPlayer != null)
				{
					int num = this.method_3(avatarType, player.m_exp);
					equipmentInventoryEntityPlayer.vmethod_3(this.method_5(avatarType, num));
					if ((!NetworkManager.smethod_3() || MonoSingleton<AppManager>.Instance.m_offlineMode) && player.IsMyActor())
					{
						MonoSingleton<AppManager>.Instance.method_0().vmethod_5<HUDPlayerInfoView>().vmethod_12(this.method_3(avatarType, player.m_exp));
						MonoSingleton<AppManager>.Instance.method_0().vmethod_5<HUDPlayerInfoView>().vmethod_11(this.method_3(avatarType, player.m_exp));
					}
				}
			}
		}
	}

	// Token: 0x0400144C RID: 5196
	public static int MAIL_UNLOCK_LEVEL = 1;

	// Token: 0x0400144D RID: 5197
	public static int JOINGUILD_UNLOCK_LEVEL = 1;

	// Token: 0x0400144E RID: 5198
	public static int SELLING_UNLOCK_LEVEL = 2;

	// Token: 0x0400144F RID: 5199
	public static int RV_UNLOCK_LEVEL = 3;

	// Token: 0x04001450 RID: 5200
	public static int CLASSMODESHOP_UNLOCK_LEVEL = 4;

	// Token: 0x04001451 RID: 5201
	public static int MELTING_UNLOCK_LEVEL = 3;

	// Token: 0x04001452 RID: 5202
	public static int WAREHOUSE_UNLOCK_LEVEL = 3;

	// Token: 0x04001453 RID: 5203
	public static int CRAFTING_UNLOCK_LEVEL = 3;

	// Token: 0x04001454 RID: 5204
	public static int PVP_UNLOCK_LEVEL = 5;

	// Token: 0x04001455 RID: 5205
	public static int UPGRADE_UNLOCK_LEVEL = 20;

	// Token: 0x04001456 RID: 5206
	public static int CREATEGUILD_UNLOCK_LEVEL = 8;

	// Token: 0x04001457 RID: 5207
	public bool m_giveExpOnKill;

	// Token: 0x04001458 RID: 5208
	public PlayerProgressionSetup m_progressionSetup = new PlayerProgressionSetup();
}
