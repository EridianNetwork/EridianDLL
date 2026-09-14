using System;
using System.Collections.Generic;
using Core;
using ns0;
using UnityEngine;

// Token: 0x02000527 RID: 1319
internal class PlayerSpawnClusterManager : ServiceWrapperBase<PlayerSpawnClusterManager>
{
	// Token: 0x060021F5 RID: 8693 RVA: 0x000176A4 File Offset: 0x000158A4
	public void Reset()
	{
		this.m_characterCluster.Clear();
		this.m_activeClusters.Clear();
	}

	// Token: 0x060021F6 RID: 8694 RVA: 0x000A1FA4 File Offset: 0x000A01A4
	public PlayerSpawnCluster method_0(PlayerInfoSync playerInfoSync_0)
	{
		if (playerInfoSync_0 == null)
		{
			return null;
		}
		if (!string.IsNullOrEmpty(MonoSingleton<AppManager>.Instance.m_autoTestCase))
		{
			PlayerSpawnCluster[] array = global::UnityEngine.Object.FindObjectsOfType(typeof(PlayerSpawnCluster)) as PlayerSpawnCluster[];
			for (int i = 0; i < array.Length; i++)
			{
				this.m_activeClusters.Add(array[i]);
			}
			return null;
		}
		PlayerSpawnCluster playerSpawnCluster;
		if (this.m_characterCluster.TryGetValue(playerInfoSync_0.m_characterId, out playerSpawnCluster))
		{
			return playerSpawnCluster;
		}
		foreach (PlayerSpawnCluster playerSpawnCluster2 in this.m_activeClusters)
		{
			if (playerSpawnCluster2.m_isTeamSpawner && playerSpawnCluster2.m_teamId == playerInfoSync_0.m_teamID)
			{
				this.m_characterCluster.Add(playerInfoSync_0.m_characterId, playerSpawnCluster2);
				return playerSpawnCluster2;
			}
		}
		HashSet<PlayerSpawnCluster> hashSet = new HashSet<PlayerSpawnCluster>(this.m_activeClusters);
		foreach (KeyValuePair<int, PlayerSpawnCluster> keyValuePair in this.m_characterCluster)
		{
			PlayerSpawnCluster value = keyValuePair.Value;
			hashSet.Remove(value);
		}
		DebugUtils.Log(LogCategory.Gamelogic, "GetActivePlayerSpawnCluster - Remaining Active PlayerSpawnCluster [" + hashSet.Count + "]");
		if (hashSet.Count == 0)
		{
			hashSet = this.m_activeClusters;
		}
		int num = global::UnityEngine.Random.Range(0, hashSet.Count);
		DebugUtils.Log(LogCategory.Gamelogic, string.Concat(new object[] { "GetActivePlayerSpawnCluster - Random Pick [", num, "] of [", hashSet.Count, "]" }));
		HashSet<PlayerSpawnCluster>.Enumerator enumerator = hashSet.GetEnumerator();
		while (enumerator.MoveNext())
		{
			if (num == 0)
			{
				this.m_characterCluster.Add(playerInfoSync_0.m_characterId, enumerator.Current);
				return enumerator.Current;
			}
			num--;
		}
		return null;
	}

	// Token: 0x060021F7 RID: 8695 RVA: 0x000176BC File Offset: 0x000158BC
	public void method_1(PlayerSpawnCluster playerSpawnCluster_0)
	{
		this.m_activeClusters.Add(playerSpawnCluster_0);
	}

	// Token: 0x060021F8 RID: 8696 RVA: 0x000A2170 File Offset: 0x000A0370
	public void method_2(PlayerSpawnCluster playerSpawnCluster_0, PlayerSpawnCluster playerSpawnCluster_1)
	{
		m_activeClusters.Remove(playerSpawnCluster_0);
		m_activeClusters.Add(playerSpawnCluster_1);
		List<int> list = new List<int>();
		Dictionary<int, PlayerSpawnCluster>.Enumerator enumerator = m_characterCluster.GetEnumerator();
		while (enumerator.MoveNext())
		{
			if (enumerator.Current.Value == playerSpawnCluster_0)
			{
				list.Add(enumerator.Current.Key);
			}
		}
		for (int i = 0; i < list.Count; i++)
		{
			m_characterCluster[list[i]] = playerSpawnCluster_1;
		}
	}
	// Token: 0x060021F9 RID: 8697 RVA: 0x000176CB File Offset: 0x000158CB
	public void method_3(PlayerSpawnCluster playerSpawnCluster_0)
	{
		this.m_activeClusters.Remove(playerSpawnCluster_0);
	}

	// Token: 0x0400169E RID: 5790
	private Dictionary<int, PlayerSpawnCluster> m_characterCluster = new Dictionary<int, PlayerSpawnCluster>();

	// Token: 0x0400169F RID: 5791
	private HashSet<PlayerSpawnCluster> m_activeClusters = new HashSet<PlayerSpawnCluster>();
}
