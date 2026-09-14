using System;
using UnityEngine;

namespace AutoTest
{
	// Token: 0x0200063C RID: 1596
	internal class AutoTestContinentResource : AutoTestResource, InstantiateManager.InstanciationClient
	{
		// Token: 0x0600287E RID: 10366 RVA: 0x0001AA59 File Offset: 0x00018C59
		public AutoTestContinentResource(GameObject obj)
			: base(obj)
		{
		}

		// Token: 0x0600287F RID: 10367 RVA: 0x000BE92C File Offset: 0x000BCB2C
		public bool Contains(Vector3 v)
		{
			Terrain component = base.Obj.GetComponent<Terrain>();
			Vector3 position = component.GetPosition();
			Vector3 size = component.terrainData.size;
			bool flag = false;
			if (v.x >= position.x && v.x <= position.x + size.x && v.z >= position.z && v.z <= position.z + size.z && v.y >= position.y - 3f)
			{
				flag = true;
			}
			return flag;
		}

		// Token: 0x06002880 RID: 10368 RVA: 0x0001AA62 File Offset: 0x00018C62
		public Vector3 Position()
		{
			return base.Obj.GetComponent<Terrain>().GetPosition();
		}

		// Token: 0x06002881 RID: 10369 RVA: 0x0000311B File Offset: 0x0000131B
		public virtual void OnInstanciate(GameObject instance, InstantiateManager.SpawnRequest request)
		{
		}
	}
}
