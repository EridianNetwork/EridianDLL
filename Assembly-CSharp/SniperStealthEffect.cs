using System;
using UnityEngine;

// Token: 0x020005E1 RID: 1505
public class SniperStealthEffect : MonoBehaviour
{
	// Token: 0x06002618 RID: 9752 RVA: 0x00019CF0 File Offset: 0x00017EF0
	public void method_0(bool bool_0, SkinnedMeshRenderer skinnedMeshRenderer_0)
	{
		if (skinnedMeshRenderer_0 == null)
		{
			return;
		}
		if (bool_0)
		{
			if (this.m_sniperStealthMaterials != null)
			{
				skinnedMeshRenderer_0.materials = this.m_sniperStealthMaterials;
			}
		}
		else if (this.m_sniperMaterials != null)
		{
			skinnedMeshRenderer_0.materials = this.m_sniperMaterials;
		}
	}

	// Token: 0x04001BBC RID: 7100
	public Material[] m_sniperStealthMaterials;

	// Token: 0x04001BBD RID: 7101
	[HideInInspector]
	public Material[] m_sniperMaterials;
}
