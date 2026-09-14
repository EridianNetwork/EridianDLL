using System;
using UnityEngine;

// Token: 0x02000567 RID: 1383
public class TrajectoryGrenade : MonoBehaviour
{
	// Token: 0x06002399 RID: 9113 RVA: 0x00018617 File Offset: 0x00016817
	private void Start()
	{
		this.m_render = base.gameObject.AddComponent<LineRenderer>();
		this.m_render.SetWidth(0.15f, 0.15f);
		this.m_lineIndex = -1;
		this.m_render.SetVertexCount(this.m_vertexCount);
	}

	// Token: 0x0600239A RID: 9114 RVA: 0x00018657 File Offset: 0x00016857
	private void Update()
	{
		this.m_lineIndex++;
		if (this.m_lineIndex < this.m_vertexCount)
		{
			this.m_render.SetPosition(this.m_lineIndex, base.transform.position);
		}
	}

	// Token: 0x0400183B RID: 6203
	private LineRenderer m_render;

	// Token: 0x0400183C RID: 6204
	private int m_vertexCount = 500;

	// Token: 0x0400183D RID: 6205
	private int m_lineIndex;
}
