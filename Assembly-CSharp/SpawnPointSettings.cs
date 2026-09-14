using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x0200040C RID: 1036
public class SpawnPointSettings : MonoBehaviour, InstantiateManager.InstanciationClient
{
	// Token: 0x060019E2 RID: 6626 RVA: 0x00013215 File Offset: 0x00011415
	private void Start()
	{
		if (this.m_spawnInfos != null && this.m_spawnInfos.Length > 0)
		{
			this.m_spawnInfo = this.m_spawnInfos[0];
		}
		SpawnPointSettings.smethod_0();
	}

	// Token: 0x060019E3 RID: 6627 RVA: 0x00086490 File Offset: 0x00084690
	public static void smethod_0()
	{
		SpawnPointSettings.m_npcFamilyList.Add(EntityNpc.EntitySubType.CHR_BanditKiller.ToString());
		SpawnPointSettings.m_npcFamilyList.Add(EntityNpc.EntitySubType.CHR_BanditRaider.ToString());
		SpawnPointSettings.m_npcFamilyList.Add(EntityNpc.EntitySubType.CHR_BanditScout.ToString());
	}

	// Token: 0x060019E4 RID: 6628 RVA: 0x0001323D File Offset: 0x0001143D
	public Entity.EntityType method_0()
	{
		return this.m_spawnInfo.m_entity;
	}

	// Token: 0x060019E5 RID: 6629 RVA: 0x000864E0 File Offset: 0x000846E0
	public static SpawnPointSettings[] smethod_1(Entity.EntityType entityType_0 = Entity.EntityType.None)
	{
		GameObject[] array = GameObject.FindGameObjectsWithTag("SpawnPoint");
		SpawnPointSettings[] array2 = new SpawnPointSettings[array.Length];
		int num = 0;
		for (int i = 0; i < array.Length; i++)
		{
			SpawnPointSettings component = array[i].GetComponent<SpawnPointSettings>();
			if (component != null)
			{
				Entity.EntityType entityType = component.method_0();
				if (entityType_0 == Entity.EntityType.None || entityType_0 == entityType)
				{
					array2[num] = component;
					num++;
				}
			}
		}
		SpawnPointSettings[] array3 = new SpawnPointSettings[num];
		Array.Copy(array2, 0, array3, 0, array3.Length);
		return array3;
	}

	// Token: 0x060019E6 RID: 6630 RVA: 0x00086558 File Offset: 0x00084758
	public static string smethod_2(string string_0)
	{
		string text = string_0.Replace("CHR_", string.Empty);
		string text2;
		if (text.EndsWith("XML"))
		{
			text2 = text.Replace("XML", string.Empty);
		}
		else
		{
			text2 = text;
		}
		return "BKT|NPC|" + text2;
	}

	// Token: 0x060019E7 RID: 6631 RVA: 0x000865A4 File Offset: 0x000847A4
	public static string smethod_3(string string_0, int int_0)
	{
		string text = string_0.Replace("CHR_", string.Empty);
		return "BKT|NPC|" + text;
	}

	// Token: 0x060019E8 RID: 6632 RVA: 0x0000311B File Offset: 0x0000131B
	public void OnInstanciate(GameObject instance, InstantiateManager.SpawnRequest request)
	{
	}

	// Token: 0x04001164 RID: 4452
	private Queue<InstantiateManager.InstanciationClient> m_callbacks = new Queue<InstantiateManager.InstanciationClient>();

	// Token: 0x04001165 RID: 4453
	public SpawnInfo m_spawnInfo;

	// Token: 0x04001166 RID: 4454
	public SpawnInfo[] m_spawnInfos = new SpawnInfo[0];

	// Token: 0x04001167 RID: 4455
	public NpcSpawningSettings.InitialState m_slotInitialState;

	// Token: 0x04001168 RID: 4456
	public bool m_bDefenseMode;

	// Token: 0x04001169 RID: 4457
	public bool m_bCombatSlot;

	// Token: 0x0400116A RID: 4458
	public float m_spawnDistance;

	// Token: 0x0400116B RID: 4459
	public static List<string> m_npcFamilyList = new List<string>();

	// Token: 0x0400116C RID: 4460
	public static int m_npcSmallTypeLevelMax = 12;

	// Token: 0x0400116D RID: 4461
	public static int m_npcMiddleTypeLevelMax = 12;
}
