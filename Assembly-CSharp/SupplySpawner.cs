using System;
using System.Collections.Generic;
using ns0;
using UnityEngine;

// Token: 0x0200055E RID: 1374
public class SupplySpawner : MonoBehaviour, ILootListener
{
	// Token: 0x06002337 RID: 9015 RVA: 0x000A6700 File Offset: 0x000A4900
	private void Update()
	{
		if (Time.frameCount % 10 == 0)
		{
			this.m_entitySpawned.Clear();
			List<Entity> list;
			MonoSingleton<EntityManager>.Instance.method_6(Entity.EntityType.Object, out list);
			for (int i = 0; i < list.Count; i++)
			{
				float num = Vector3.Distance(list[i].transform.position, base.transform.position);
				if (num < 0.2f)
				{
					this.m_entitySpawned.Add(list[i]);
				}
			}
		}
		MeshRenderer componentInChildren = base.GetComponentInChildren<MeshRenderer>();
		if (componentInChildren)
		{
			if (this.m_entitySpawned.Count > 0)
			{
				componentInChildren.material = this.m_openMaterial;
			}
			else
			{
				componentInChildren.material = this.m_closeMaterial;
			}
		}
	}

	// Token: 0x06002338 RID: 9016 RVA: 0x000182F3 File Offset: 0x000164F3
	public void OnPickedUp(EntityPlayer picker, EntityObject item)
	{
		this.m_entitySpawned.Remove(item);
	}

	// Token: 0x040017D2 RID: 6098
	public float m_cooldownDelay = 15f;

	// Token: 0x040017D3 RID: 6099
	public Material m_openMaterial;

	// Token: 0x040017D4 RID: 6100
	public Material m_closeMaterial;

	// Token: 0x040017D5 RID: 6101
	private List<Entity> m_entitySpawned = new List<Entity>();
}
