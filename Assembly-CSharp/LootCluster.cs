using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x02000523 RID: 1315
public class LootCluster : Scene, InstantiateManager.InstanciationClient
{
	// Token: 0x060021EF RID: 8687 RVA: 0x00017663 File Offset: 0x00015863
	private void Start()
	{
		this.m_spawningPoint = base.gameObject.GetComponentsInChildren<SpawnPointSettings>();
	}

	// Token: 0x060021F0 RID: 8688 RVA: 0x0000311B File Offset: 0x0000131B
	public virtual void OnInstanciate(GameObject instance, InstantiateManager.SpawnRequest request)
	{
	}

	// Token: 0x04001696 RID: 5782
	public LootCluster.TreasureBoxSettings[] m_boxList = new LootCluster.TreasureBoxSettings[0];

	// Token: 0x04001697 RID: 5783
	private SpawnPointSettings[] m_spawningPoint;

	// Token: 0x04001698 RID: 5784
	private List<int> m_spawnedEntityIDs = new List<int>();

	// Token: 0x02000524 RID: 1316
	[Serializable]
	public class LootSpawnProba
	{
		// Token: 0x04001699 RID: 5785
		public string m_item;

		// Token: 0x0400169A RID: 5786
		public int m_probability = 100;
	}

	// Token: 0x02000525 RID: 1317
	[Serializable]
	public class SpawnSlot
	{
		// Token: 0x0400169B RID: 5787
		public LootCluster.LootSpawnProba[] m_probabilities;
	}

	// Token: 0x02000526 RID: 1318
	[Serializable]
	public class TreasureBoxSettings
	{
		// Token: 0x0400169C RID: 5788
		public string m_treasureBox;

		// Token: 0x0400169D RID: 5789
		public LootCluster.SpawnSlot[] m_spawningList;
	}
}
