using System;
using UnityEngine;

// Token: 0x020005C2 RID: 1474
public class LightPillar : MonoBehaviour
{
	// Token: 0x06002563 RID: 9571 RVA: 0x0000311B File Offset: 0x0000131B
	private void Start()
	{
	}

	// Token: 0x06002564 RID: 9572 RVA: 0x000B3E08 File Offset: 0x000B2008
	private void OnWillRenderObject()
	{
		Renderer component = base.GetComponent<MeshRenderer>();
		if (component != null)
		{
			for (int i = 0; i < component.materials.Length; i++)
			{
				Material material = component.renderer.materials[i];
				if (material != null && material.shader.name == "TKC/Scene/LightPillar")
				{
					float time = Time.time;
					float num = (time - (float)((int)this.m_LightPillarStartTime)) * this.m_LightPillarSpeed;
					if ((double)num < 1.0)
					{
						material.SetFloat("_EmissiveOffset", num - this.m_LightPillarOffset);
					}
					else
					{
						float num2 = 1f / this.m_LightPillarSpeed;
						if (time > this.m_LightPillarStartTime + this.m_LightPillarInterval + num2)
						{
							this.m_LightPillarStartTime = time;
						}
					}
				}
			}
		}
	}

	// Token: 0x04001AC4 RID: 6852
	public float m_LightPillarSpeed = 1f;

	// Token: 0x04001AC5 RID: 6853
	public float m_LightPillarInterval = 1f;

	// Token: 0x04001AC6 RID: 6854
	public float m_LightPillarOffset;

	// Token: 0x04001AC7 RID: 6855
	private float m_LightPillarStartTime;
}
