using System;
using Core;
using ns0;
using UnityEngine;

// Token: 0x02000528 RID: 1320
[RequireComponent(typeof(SpawnSlotContainer))]
public class PlayerSpawnCluster : Scene, InstantiateManager.InstanciationClient
{
	// Token: 0x060021FB RID: 8699 RVA: 0x0000311B File Offset: 0x0000131B
	public void method_10(EntityPlayer entityPlayer_0)
	{
	}

	// Token: 0x060021FC RID: 8700 RVA: 0x000A2208 File Offset: 0x000A0408
	protected override void vmethod_0()
	{
		DebugUtils.Log(LogCategory.Gamelogic, "PlayerSpawnCluster.Begin [" + base.gameObject.name + "]");
		if (this.m_playerSpawnCluserToReplace != null)
		{
			this.m_playerSpawnCluserToReplace.method_5(true);
			ServiceWrapperBase<PlayerSpawnClusterManager>.Instance.method_2(this.m_playerSpawnCluserToReplace, this);
		}
		else
		{
			ServiceWrapperBase<PlayerSpawnClusterManager>.Instance.method_1(this);
		}
		base.vmethod_0();
	}

	// Token: 0x060021FD RID: 8701 RVA: 0x0000311D File Offset: 0x0000131D
	protected override bool vmethod_3()
	{
		return false;
	}

	// Token: 0x060021FE RID: 8702 RVA: 0x000176FB File Offset: 0x000158FB
	protected override void vmethod_1()
	{
		base.vmethod_1();
		ServiceWrapperBase<PlayerSpawnClusterManager>.Instance.method_3(this);
	}

	// Token: 0x060021FF RID: 8703 RVA: 0x0000311B File Offset: 0x0000131B
	protected override void vmethod_5()
	{
	}

	// Token: 0x06002200 RID: 8704 RVA: 0x0000311B File Offset: 0x0000131B
	public void OnInstanciate(GameObject instance, InstantiateManager.SpawnRequest request)
	{
	}

	// Token: 0x040016A0 RID: 5792
	public bool m_autoRespawn = true;

	// Token: 0x040016A1 RID: 5793
	public float m_respawnTime = 3f;

	// Token: 0x040016A2 RID: 5794
	public bool m_isTeamSpawner;

	// Token: 0x040016A3 RID: 5795
	public int m_teamId = 1;

	// Token: 0x040016A4 RID: 5796
	public PlayerSpawnCluster m_playerSpawnCluserToReplace;
}
