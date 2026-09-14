using System;
using UnityEngine;

// Token: 0x020006DC RID: 1756
public class MinimapSwitch : MonoBehaviour
{
	// Token: 0x06002E50 RID: 11856 RVA: 0x000D80F4 File Offset: 0x000D62F4
	private void OnTriggerEnter(Collider collider)
	{
		EntityPlayer component = collider.GetComponent<EntityPlayer>();
		if (component != null && component.vmethod_25() != null && component.vmethod_25().IsMyActor())
		{
			UIMapDataManager.smethod_0().method_5(this.MapTexIdxFrom0);
		}
	}

	// Token: 0x04002092 RID: 8338
	public int MapTexIdxFrom0;
}
