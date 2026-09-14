using System;
using ns0;
using UnityEngine;

// Token: 0x0200055D RID: 1373
public class StaticEntitySpawner : MonoBehaviour, IEntityManagerListener, InstantiateManager.InstanciationClient
{
	// Token: 0x06002332 RID: 9010 RVA: 0x000A65A0 File Offset: 0x000A47A0
	private void Start()
	{
		MonoSingleton<EntityManager>.Instance.method_0(this);
		if (!this.m_bDestoryableObj)
		{
			Transform transform = base.transform;
			int childCount = transform.childCount;
			for (int i = 0; i < childCount; i++)
			{
				transform.GetChild(i).gameObject.SetActive(false);
			}
			MeshRenderer componentInChildren = base.GetComponentInChildren<MeshRenderer>();
			if (componentInChildren)
			{
				componentInChildren.enabled = false;
			}
			MeshCollider componentInChildren2 = base.GetComponentInChildren<MeshCollider>();
			if (componentInChildren2)
			{
				componentInChildren2.enabled = false;
			}
		}
	}

	// Token: 0x06002333 RID: 9011 RVA: 0x000182BB File Offset: 0x000164BB
	private void OnDestroy()
	{
		if (MonoSingleton<EntityManager>.Instance != null)
		{
			MonoSingleton<EntityManager>.Instance.method_1(this);
		}
	}

	// Token: 0x06002334 RID: 9012 RVA: 0x0000311B File Offset: 0x0000131B
	public void OnInstanciate(GameObject instance, InstantiateManager.SpawnRequest request)
	{
	}

	// Token: 0x06002335 RID: 9013 RVA: 0x000A661C File Offset: 0x000A481C
	public void OnEntitySpawn(Entity entity)
	{
		if (!this.m_binded && Vector3.Distance(entity.transform.position, base.gameObject.transform.position) < 0.1f)
		{
			if (!this.m_bDestoryableObj)
			{
				Transform transform = base.transform;
				int childCount = transform.childCount;
				for (int i = 0; i < childCount; i++)
				{
					GameObject gameObject = transform.GetChild(i).gameObject;
					if (gameObject.tag == "TemplatePathFinding")
					{
						global::UnityEngine.Object.Destroy(gameObject);
					}
					else
					{
						gameObject.SetActive(true);
					}
				}
				MeshRenderer componentInChildren = base.GetComponentInChildren<MeshRenderer>();
				if (componentInChildren)
				{
					componentInChildren.enabled = true;
				}
				MeshCollider componentInChildren2 = base.GetComponentInChildren<MeshCollider>();
				if (componentInChildren2)
				{
					componentInChildren2.enabled = true;
				}
			}
			base.gameObject.transform.parent = entity.transform;
			this.m_binded = true;
		}
	}

	// Token: 0x040017D0 RID: 6096
	private bool m_binded;

	// Token: 0x040017D1 RID: 6097
	public bool m_bDestoryableObj;
}
