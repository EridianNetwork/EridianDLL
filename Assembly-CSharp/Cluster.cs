using System;
using UnityEngine;

// Token: 0x020004CD RID: 1229
[RequireComponent(typeof(SpawnSlotContainer))]
public class Cluster : Scene, IDamageListener, InstantiateManager.InstanciationClient
{
	// Token: 0x06002127 RID: 8487 RVA: 0x0000311B File Offset: 0x0000131B
	private void Start()
	{
	}

	// Token: 0x06002128 RID: 8488 RVA: 0x00016F07 File Offset: 0x00015107
	private void OnDestroy()
	{
		DamageManager.DamageManager_0.method_4(this);
	}

	// Token: 0x06002129 RID: 8489 RVA: 0x0000311B File Offset: 0x0000131B
	protected override void vmethod_5()
	{
	}

	// Token: 0x0600212A RID: 8490 RVA: 0x0000311B File Offset: 0x0000131B
	public virtual void OnInstanciate(GameObject instance, InstantiateManager.SpawnRequest request)
	{
	}

	// Token: 0x0600212B RID: 8491 RVA: 0x0000311B File Offset: 0x0000131B
	public void OnDamaged(DamageContext context)
	{
	}

	// Token: 0x0600212C RID: 8492 RVA: 0x0000311B File Offset: 0x0000131B
	public void OnEntityKill(KillContext context)
	{
	}

	// Token: 0x0600212D RID: 8493 RVA: 0x0000311D File Offset: 0x0000131D
	protected override bool vmethod_3()
	{
		return false;
	}

	// Token: 0x040015A9 RID: 5545
	[HideInInspector]
	public bool m_showConfig;

	// Token: 0x040015AA RID: 5546
	[HideInInspector]
	public bool m_showSpawningData;

	// Token: 0x040015AB RID: 5547
	public int m_remainingNpcForCompletion;

	// Token: 0x040015AC RID: 5548
	public float m_nextSpawnTime;

	// Token: 0x040015AD RID: 5549
	[HideInInspector]
	public Cluster.ENextSpawnCondition m_nextSpawnCondition;

	// Token: 0x040015AE RID: 5550
	protected bool m_bSpawnPeeding;

	// Token: 0x040015AF RID: 5551
	public Cluster.SpawningOrder m_spawningOrder;

	// Token: 0x040015B0 RID: 5552
	public int m_minLevel;

	// Token: 0x040015B1 RID: 5553
	public int m_maxLevel;

	// Token: 0x040015B2 RID: 5554
	public int m_combatCount1p = 1;

	// Token: 0x040015B3 RID: 5555
	public int m_combatCount2p = 1;

	// Token: 0x040015B4 RID: 5556
	public int m_combatCount3p = 1;

	// Token: 0x040015B5 RID: 5557
	public int m_combatCount4p = 1;

	// Token: 0x040015B6 RID: 5558
	public bool m_bMissionCluster;

	// Token: 0x040015B7 RID: 5559
	public bool m_bBossLevel;

	// Token: 0x040015B8 RID: 5560
	public string m_spawnedNpcName;

	// Token: 0x040015B9 RID: 5561
	public Cluster.SpawningSlot[] m_spawningList;

	// Token: 0x020004CE RID: 1230
	public enum SpawningOrder
	{
		// Token: 0x040015BB RID: 5563
		FixedOrder,
		// Token: 0x040015BC RID: 5564
		RandomOrder
	}

	// Token: 0x020004CF RID: 1231
	public enum InitialSpawnType
	{
		// Token: 0x040015BE RID: 5566
		OnBegin,
		// Token: 0x040015BF RID: 5567
		OnTimer,
		// Token: 0x040015C0 RID: 5568
		OnTriggerZone
	}

	// Token: 0x020004D0 RID: 1232
	[Serializable]
	public class NpcSpawnProba
	{
		// Token: 0x040015C1 RID: 5569
		public string m_npc;
	}

	// Token: 0x020004D1 RID: 1233
	[Serializable]
	public class SpawningSlot
	{
		// Token: 0x040015C2 RID: 5570
		public Cluster.NpcSpawnProba[] m_probabilities;

		// Token: 0x040015C3 RID: 5571
		public int m_minPlayerCount = 1;
	}

	// Token: 0x020004D2 RID: 1234
	public enum ENextSpawnCondition
	{
		// Token: 0x040015C5 RID: 5573
		EDeath,
		// Token: 0x040015C6 RID: 5574
		ETimer
	}
}
