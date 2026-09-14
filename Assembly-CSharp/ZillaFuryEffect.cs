using System;
using UnityEngine;

// Token: 0x020005EE RID: 1518
public class ZillaFuryEffect : MonoBehaviour
{
	// Token: 0x06002653 RID: 9811 RVA: 0x000B9220 File Offset: 0x000B7420
	public void method_0()
	{
		SkinnedMeshRenderer componentInChildren = base.GetComponentInChildren<SkinnedMeshRenderer>();
		if (this.m_furyMaterial != null)
		{
			componentInChildren.material = this.m_furyMaterial;
		}
	}

	// Token: 0x04001C0F RID: 7183
	public Material m_furyMaterial;
}
