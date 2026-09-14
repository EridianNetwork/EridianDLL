using System;
using System.Collections.Generic;
using ns0;
using UnityEngine;

// Token: 0x0200044F RID: 1103
public class EntityManager : MonoSingleton<EntityManager>
{
	// Token: 0x06001B6E RID: 7022 RVA: 0x00013C53 File Offset: 0x00011E53
	public void method_0(IEntityManagerListener ientityManagerListener_0)
	{
		this.m_listerner.Add(ientityManagerListener_0);
	}

	// Token: 0x06001B6F RID: 7023 RVA: 0x00013C61 File Offset: 0x00011E61
	public void method_1(IEntityManagerListener ientityManagerListener_0)
	{
		this.m_listerner.Remove(ientityManagerListener_0);
	}

	// Token: 0x06001B70 RID: 7024 RVA: 0x0008A170 File Offset: 0x00088370
	protected override void Awake()
	{
		base.Awake();
		this.m_entitiesPerType = new List<Entity>[Enum.GetNames(typeof(Entity.EntityType)).Length];
		for (int i = 0; i < this.m_entitiesPerType.Length; i++)
		{
			this.m_entitiesPerType[i] = new List<Entity>();
		}
		this.m_entityDirectory = new GameObject("Entities");
		this.m_entityDirectory.transform.parent = base.transform;
	}

	// Token: 0x06001B71 RID: 7025 RVA: 0x00013C70 File Offset: 0x00011E70
	public void method_2(Entity entity_0)
	{
		if (entity_0 != null && entity_0.gameObject != null)
		{
			global::UnityEngine.Object.Destroy(entity_0.gameObject);
		}
	}

	// Token: 0x06001B72 RID: 7026 RVA: 0x0008A1E8 File Offset: 0x000883E8
	private void method_3()
	{
		for (int i = 0; i < this.m_entitiesPerType[0].Count; i++)
		{
			this.method_2(this.m_entitiesPerType[0][i]);
		}
		for (int j = 0; j < this.m_entitiesPerType.Length; j++)
		{
			this.m_entitiesPerType[j].Clear();
		}
	}

	// Token: 0x06001B73 RID: 7027 RVA: 0x0008A244 File Offset: 0x00088444
	public void method_4(Entity entity_0)
	{
		this.m_entitiesPerType[0].Add(entity_0);
		this.m_entitiesPerType[(int)entity_0.vmethod_8()].Add(entity_0);
		for (int i = 0; i < this.m_listerner.Count; i++)
		{
			this.m_listerner[i].OnEntitySpawn(entity_0);
		}
	}

	// Token: 0x06001B74 RID: 7028 RVA: 0x00013C94 File Offset: 0x00011E94
	public void method_5(Entity entity_0)
	{
		this.m_entitiesPerType[0].Remove(entity_0);
		this.m_entitiesPerType[(int)entity_0.vmethod_8()].Remove(entity_0);
	}

	// Token: 0x06001B75 RID: 7029 RVA: 0x00013CB9 File Offset: 0x00011EB9
	public void method_6(Entity.EntityType entityType_0, out List<Entity> list_0)
	{
		list_0 = this.m_entitiesPerType[(int)entityType_0];
	}

	// Token: 0x06001B76 RID: 7030 RVA: 0x00013CC5 File Offset: 0x00011EC5
	public void method_7(out List<Entity> list_0)
	{
		list_0 = this.m_entitiesPerType[0];
	}

	// Token: 0x06001B77 RID: 7031 RVA: 0x0008A29C File Offset: 0x0008849C
	public void method_8(Entity.EntityType entityType_0)
	{
		if (entityType_0 == Entity.EntityType.None)
		{
			this.method_3();
		}
		else
		{
			List<Entity> list = new List<Entity>();
			int i = 0;
			while (i < this.m_entitiesPerType[(int)entityType_0].Count)
			{
				if (entityType_0 != Entity.EntityType.Object)
				{
					goto IL_004E;
				}
				EntityObject entityObject = (EntityObject)this.m_entitiesPerType[(int)entityType_0][i];
				if (!(entityObject.m_owner != null) || entityObject.m_owner.vmethod_8() != Entity.EntityType.Player)
				{
					goto IL_004E;
				}
				IL_0062:
				i++;
				continue;
				IL_004E:
				list.Add(this.m_entitiesPerType[(int)entityType_0][i]);
				goto IL_0062;
			}
			for (int j = 0; j < list.Count; j++)
			{
				this.method_2(list[j]);
				this.method_5(list[j]);
			}
		}
	}

	// Token: 0x06001B78 RID: 7032 RVA: 0x00013CD1 File Offset: 0x00011ED1
	public int method_9(Entity.EntityType entityType_0 = Entity.EntityType.None)
	{
		return this.m_entitiesPerType[(int)entityType_0].Count;
	}

	// Token: 0x06001B79 RID: 7033 RVA: 0x0008A34C File Offset: 0x0008854C
	public int[] method_10()
	{
		int[] array = new int[this.m_entitiesPerType.Length];
		for (int i = 0; i < this.m_entitiesPerType.Length; i++)
		{
			array[i] = this.m_entitiesPerType[i].Count;
		}
		return array;
	}

	// Token: 0x040011FB RID: 4603
	private List<IEntityManagerListener> m_listerner = new List<IEntityManagerListener>();

	// Token: 0x040011FC RID: 4604
	public GameObject m_entityDirectory;

	// Token: 0x040011FD RID: 4605
	private List<Entity>[] m_entitiesPerType;
}
