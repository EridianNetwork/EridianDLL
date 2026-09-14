using System;
using System.Collections.Generic;
using Core;
using ns0;
using UnityEngine;

// Token: 0x02000AB0 RID: 2736
public class Grid
{
	// Token: 0x06004A3B RID: 19003 RVA: 0x00134A84 File Offset: 0x00132C84
	public Grid(byte byte_0, Vector3 vector3_0, Vector3 vector3_1, bool bool_0 = true)
	{
		this.m_id = byte_0;
		this.bounds.center = vector3_0;
		this.bounds.size = vector3_1;
		this.isGeoGrid = bool_0;
	}

	// Token: 0x1700077D RID: 1917
	// (get) Token: 0x06004A3C RID: 19004 RVA: 0x00030911 File Offset: 0x0002EB11
	// (set) Token: 0x06004A3D RID: 19005 RVA: 0x00030919 File Offset: 0x0002EB19
	public byte m_id { get; protected set; }

	// Token: 0x1700077E RID: 1918
	// (get) Token: 0x06004A3E RID: 19006 RVA: 0x00030922 File Offset: 0x0002EB22
	// (set) Token: 0x06004A3F RID: 19007 RVA: 0x0003092A File Offset: 0x0002EB2A
	public bool isGeoGrid { get; protected set; }

	// Token: 0x06004A40 RID: 19008 RVA: 0x00134B08 File Offset: 0x00132D08
	public List<PhotonView> method_0()
	{
		for (int i = 0; i < this.m_newcomersID.Count; i++)
		{
			PlayerInfoSync playerInfoSync = MonoSingleton<Session>.Instance.TryGetPlayerInfoSyncById(this.m_newcomersID[i]);
			if (playerInfoSync)
			{
				Entity entity = playerInfoSync.GetEntity();
				if (entity)
				{
					this.m_newcomersViews.AddRange(entity.m_networkViews);
				}
			}
		}
		return this.m_newcomersViews;
	}

	// Token: 0x06004A41 RID: 19009 RVA: 0x00030933 File Offset: 0x0002EB33
	public virtual void vmethod_0(Grid grid_0)
	{
		if (!this.m_nearby.Contains(grid_0))
		{
			this.m_nearby.Add(grid_0);
		}
	}

	// Token: 0x06004A42 RID: 19010 RVA: 0x0003094F File Offset: 0x0002EB4F
	public virtual void vmethod_1(PhotonView photonView_0)
	{
		if (!this.m_views.Contains(photonView_0))
		{
			this.m_views.Add(photonView_0);
		}
	}

	// Token: 0x06004A43 RID: 19011 RVA: 0x0003096B File Offset: 0x0002EB6B
	public virtual void vmethod_2(PhotonView photonView_0)
	{
		this.m_views.Remove(photonView_0);
	}

	// Token: 0x06004A44 RID: 19012 RVA: 0x00134B70 File Offset: 0x00132D70
	public virtual void vmethod_3(PhotonPlayer photonPlayer_0)
	{
		if (!this.m_newcomersID.Contains(photonPlayer_0.ActorId) && !this.m_settlersID.Contains(photonPlayer_0.ActorId))
		{
			this.m_newcomersID.Add(photonPlayer_0.ActorId);
			MonoSingleton<GridManager>.Instance.OnGridAddListener(this, photonPlayer_0);
		}
	}

	// Token: 0x06004A45 RID: 19013 RVA: 0x00134BC0 File Offset: 0x00132DC0
	public virtual void vmethod_4(PhotonPlayer photonPlayer_0)
	{
		if (this.m_settlersID.Remove(photonPlayer_0.ActorId))
		{
			this.m_newcomersID.Remove(photonPlayer_0.ActorId);
			MonoSingleton<GridManager>.Instance.OnGridRemoveListener(this, photonPlayer_0);
		}
		else if (this.m_newcomersID.Remove(photonPlayer_0.ActorId))
		{
			MonoSingleton<GridManager>.Instance.OnGridRemoveListener(this, photonPlayer_0);
		}
	}

	// Token: 0x06004A46 RID: 19014 RVA: 0x00134C20 File Offset: 0x00132E20
	public virtual void vmethod_5(Entity entity_0)
	{
		if (!this.m_entity.Contains(entity_0))
		{
			DebugUtils.Log(LogCategory.Network, string.Concat(new object[]
			{
				"Add Entity",
				entity_0.name,
				entity_0.vmethod_0(),
				" to grid",
				this.m_id
			}));
			this.m_entity.Add(entity_0);
			this.m_views.AddRange(entity_0.m_networkViews);
			if (entity_0 is EntityPlayer)
			{
				EntityPlayer entityPlayer = entity_0 as EntityPlayer;
				this.vmethod_3(entityPlayer.vmethod_25().m_photonPlayer);
			}
		}
	}

	// Token: 0x06004A47 RID: 19015 RVA: 0x00134CC4 File Offset: 0x00132EC4
	public virtual void vmethod_6(Entity entity_0)
	{
		if (this.m_entity.Contains(entity_0))
		{
			this.m_entity.Remove(entity_0);
			if (entity_0 is EntityPlayer)
			{
				EntityPlayer entityPlayer = entity_0 as EntityPlayer;
				this.vmethod_4(entityPlayer.vmethod_25().m_photonPlayer);
			}
		}
		for (int i = 0; i < entity_0.m_networkViews.Count; i++)
		{
			this.m_views.Remove(entity_0.m_networkViews[i]);
		}
	}

	// Token: 0x06004A48 RID: 19016 RVA: 0x00134D3C File Offset: 0x00132F3C
	public virtual bool vmethod_7(Entity entity_0)
	{
		if (entity_0 == null)
		{
			return false;
		}
		Transform transform = null;
		bool flag;
		try
		{
			transform = entity_0.transform;
			goto IL_0033;
		}
		catch (Exception ex)
		{
			DebugUtils.LogWarning(LogCategory.Framework, "Grid.InsideTheBounds [" + ex + "]");
			flag = false;
		}
		return flag;
		IL_0033:
		return !(transform == null) && this.bounds.Contains(transform.position);
	}

	// Token: 0x06004A49 RID: 19017 RVA: 0x0003097A File Offset: 0x0002EB7A
	public virtual bool vmethod_8(Grid grid_0)
	{
		return this.bounds.Intersects(grid_0.bounds);
	}

	// Token: 0x06004A4A RID: 19018 RVA: 0x00134DA8 File Offset: 0x00132FA8
	public virtual void Update()
	{
		for (int i = 0; i < this.m_entity.Count; i++)
		{
			Entity entity = this.m_entity[i];
			bool flag = false;
			for (int j = 0; j < this.m_nearby.Count; j++)
			{
				if (this.m_nearby[j].vmethod_7(entity))
				{
					this.m_nearby[j].vmethod_5(entity);
					flag = true;
				}
			}
			if (!this.vmethod_7(entity))
			{
				if (!flag)
				{
					DebugUtils.LogError(LogCategory.Network, string.Concat(new object[]
					{
						"can not allocate the entity ",
						entity.name,
						entity.vmethod_0(),
						"at grid ",
						this.m_id,
						" to another grid. pos:",
						entity.transform.position
					}));
					MonoSingleton<GridManager>.Instance.m_UnarrangedEntities.Add(entity);
				}
				this.vmethod_6(entity);
			}
		}
	}

	// Token: 0x06004A4B RID: 19019 RVA: 0x0003098D File Offset: 0x0002EB8D
	public void OnNetworkingUpdated()
	{
		this.m_settlersID.AddRange(this.m_newcomersID);
		this.m_newcomersID.Clear();
		this.m_newcomersViews.Clear();
	}

	// Token: 0x06004A4C RID: 19020 RVA: 0x00134EA4 File Offset: 0x001330A4
	public void OnDrawGizmos()
	{
		if (this.m_entity.Count >= 1)
		{
			Gizmos.color = Color.green;
		}
		Gizmos.DrawWireCube(this.bounds.center, this.bounds.size);
		foreach (Grid grid in this.m_nearby)
		{
			Gizmos.color = Color.blue;
			Gizmos.DrawLine(this.bounds.center, grid.bounds.center);
		}
		Gizmos.color = Color.white;
	}

	// Token: 0x04003610 RID: 13840
	private Bounds bounds;

	// Token: 0x04003611 RID: 13841
	public readonly List<PhotonView> m_views = new List<PhotonView>();

	// Token: 0x04003612 RID: 13842
	public readonly List<PhotonView> m_newcomersViews = new List<PhotonView>();

	// Token: 0x04003613 RID: 13843
	private List<Entity> m_entity = new List<Entity>();

	// Token: 0x04003614 RID: 13844
	private List<Grid> m_nearby = new List<Grid>();

	// Token: 0x04003615 RID: 13845
	public readonly List<int> m_newcomersID = new List<int>();

	// Token: 0x04003616 RID: 13846
	public readonly List<int> m_settlersID = new List<int>();

	// Token: 0x04003617 RID: 13847
	public readonly int m_maxUpdateViews = 100;
}
