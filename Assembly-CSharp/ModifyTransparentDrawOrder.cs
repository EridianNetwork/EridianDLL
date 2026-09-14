using System;
using UnityEngine;

// Token: 0x020005CA RID: 1482
[ExecuteInEditMode]
public class ModifyTransparentDrawOrder : MonoBehaviour
{
	// Token: 0x06002576 RID: 9590 RVA: 0x000B4168 File Offset: 0x000B2368
	private void Start()
	{
		int num = 3000;
		Renderer component = base.gameObject.GetComponent<Renderer>();
		if (component != null)
		{
			for (int i = 0; i < component.materials.Length; i++)
			{
				Material material = component.materials[i];
				material.renderQueue = num + this.LayerNum;
			}
		}
	}

	// Token: 0x04001ADA RID: 6874
	public int LayerNum;
}
