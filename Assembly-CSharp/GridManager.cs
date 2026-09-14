using System;
using System.Collections.Generic;
using Core;
using ns0;
using UnityEngine;

// Token: 0x02000AB3 RID: 2739
public class GridManager : MonoSingleton<GridManager>
{
	// Token: 0x1700077F RID: 1919
	// (get) Token: 0x06004A54 RID: 19028 RVA: 0x00030A1A File Offset: 0x0002EC1A
	// (set) Token: 0x06004A55 RID: 19029 RVA: 0x00030A22 File Offset: 0x0002EC22
	public SessionGrid m_sessionGrid { get; private set; }

	// Token: 0x06004A56 RID: 19030 RVA: 0x00030A2B File Offset: 0x0002EC2B
	protected override void Awake()
	{
		base.Awake();
		this.method_0();
	}

	// Token: 0x06004A57 RID: 19031 RVA: 0x0000311B File Offset: 0x0000131B
	private void Start()
	{
	}

	// Token: 0x06004A58 RID: 19032 RVA: 0x00030A39 File Offset: 0x0002EC39
	private void method_0()
	{
		this.m_sessionGrid = new SessionGrid(0);
		this.m_grids.Add(this.m_sessionGrid);
	}

	// Token: 0x06004A59 RID: 19033 RVA: 0x00030A58 File Offset: 0x0002EC58
	private void method_1()
	{
		if (!(MonoSingleton<Session>.Instance.method_24().imethod_4() is GameModeTown))
		{
			this.m_grids.Add(new InstanceGrid(this.m_gridIndex));
		}
	}

	// Token: 0x06004A5A RID: 19034 RVA: 0x00134F54 File Offset: 0x00133154
	public void method_2(Vector3 vector3_0, Vector3 vector3_1)
	{
		DebugUtils.Log(LogCategory.Gamelogic, string.Concat("RegisterLevelGrids:", m_gridIndex, " position:", vector3_0, " size:", vector3_1));
		m_grids.Add(new Grid(m_gridIndex++, vector3_0, vector3_1));
	}
	// Token: 0x06004A5B RID: 19035 RVA: 0x00134FD0 File Offset: 0x001331D0
	private void Update()
	{
		if (this.m_isLevelReady)
		{
			this.method_6();
			for (int i = 0; i < this.m_grids.Count; i++)
			{
				if (this.m_grids[i].isGeoGrid)
				{
					this.m_grids[i].Update();
				}
			}
			this.method_7();
		}
		else if (MonoSingleton<Session>.Instance.method_23())
		{
			this.method_1();
			this.method_3();
			this.m_isLevelReady = true;
		}
	}

	// Token: 0x06004A5C RID: 19036 RVA: 0x0013504C File Offset: 0x0013324C
	private void method_3()
	{
		for (int i = 0; i < this.m_grids.Count; i++)
		{
			for (int j = i + 1; j < this.m_grids.Count; j++)
			{
				if (this.m_grids[i].vmethod_8(this.m_grids[j]))
				{
					this.m_grids[i].vmethod_0(this.m_grids[j]);
					this.m_grids[j].vmethod_0(this.m_grids[i]);
				}
			}
		}
	}

	// Token: 0x06004A5D RID: 19037 RVA: 0x00030A86 File Offset: 0x0002EC86
	public void method_4(Entity entity_0)
	{
		if (!this.m_UnarrangedEntities.Contains(entity_0))
		{
			this.m_UnarrangedEntities.Add(entity_0);
		}
	}

	// Token: 0x06004A5E RID: 19038 RVA: 0x001350E4 File Offset: 0x001332E4
	public void method_5(Entity entity_0)
	{
		EntityPlayer entityPlayer = entity_0 as EntityPlayer;
		if (entityPlayer)
		{
			this.m_sessionGrid.vmethod_4(entityPlayer.vmethod_25().m_photonPlayer);
		}
		for (int i = 0; i < this.m_grids.Count; i++)
		{
			this.m_grids[i].vmethod_6(entity_0);
		}
		this.m_UnarrangedEntities.Remove(entity_0);
	}

	// Token: 0x06004A5F RID: 19039 RVA: 0x0013514C File Offset: 0x0013334C
	private void method_6()
	{
		for (int i = 0; i < m_UnarrangedEntities.Count; i++)
		{
			Entity entity = m_UnarrangedEntities[i];
			m_sessionGrid.vmethod_6(entity);
			EntityPlayer entityPlayer = entity as EntityPlayer;
			if ((bool)entityPlayer && (bool)entityPlayer.vmethod_25())
			{
				m_sessionGrid.vmethod_3(entityPlayer.vmethod_25().m_photonPlayer);
			}
			for (int j = 0; j < m_grids.Count; j++)
			{
				if (m_grids[j].isGeoGrid && m_grids[j].vmethod_7(entity))
				{
					m_grids[j].vmethod_5(entity);
					m_UnarrangedEntities.Remove(entity);
					break;
				}
			}
		}
	}
	// Token: 0x06004A60 RID: 19040 RVA: 0x00135220 File Offset: 0x00133420
	public void OnGridAddListener(Grid grid, PhotonPlayer player)
	{
		List<int> list = null;
		if (this.m_AddingGrids.TryGetValue(grid.m_id, out list))
		{
			list.Add(player.ActorId);
		}
		else
		{
			list = new List<int>();
			list.Add(player.ActorId);
			this.m_AddingGrids.Add(grid.m_id, list);
		}
	}

	// Token: 0x06004A61 RID: 19041 RVA: 0x00135278 File Offset: 0x00133478
	public void OnGridRemoveListener(Grid grid, PhotonPlayer player)
	{
		List<int> list = null;
		if (this.m_RemovingGrids.TryGetValue(grid.m_id, out list))
		{
			list.Add(player.ActorId);
		}
		else
		{
			list = new List<int>();
			list.Add(player.ActorId);
			this.m_RemovingGrids.Add(grid.m_id, list);
		}
	}

	// Token: 0x06004A62 RID: 19042 RVA: 0x0000311B File Offset: 0x0000131B
	private void method_7()
	{
	}

	// Token: 0x06004A63 RID: 19043 RVA: 0x001352D0 File Offset: 0x001334D0
	protected virtual void OnDrawGizmos()
	{
		foreach (Grid grid in this.m_grids)
		{
			grid.OnDrawGizmos();
		}
	}

	// Token: 0x0400361A RID: 13850
	public readonly List<Grid> m_grids = new List<Grid>();

	// Token: 0x0400361B RID: 13851
	private Dictionary<byte, List<int>> m_AddingGrids = new Dictionary<byte, List<int>>();

	// Token: 0x0400361C RID: 13852
	private Dictionary<byte, List<int>> m_RemovingGrids = new Dictionary<byte, List<int>>();

	// Token: 0x0400361D RID: 13853
	public List<Entity> m_UnarrangedEntities = new List<Entity>();

	// Token: 0x0400361E RID: 13854
	private bool m_isLevelReady;

	// Token: 0x0400361F RID: 13855
	private byte m_gridIndex = 10;
}
