using System;
using UnityEngine;

// Token: 0x02000B48 RID: 2888
public class DynamicSkinCollider : MonoBehaviour
{
	// Token: 0x06004E9F RID: 20127 RVA: 0x0014E5D0 File Offset: 0x0014C7D0
	private Mesh method_0()
	{
		this.m_meshIndex = (this.m_meshIndex + 1) % this.m_mesh.Length;
		if (this.m_mesh[this.m_meshIndex] == null)
		{
			this.m_mesh[this.m_meshIndex] = new Mesh();
		}
		return this.m_mesh[this.m_meshIndex];
	}

	// Token: 0x06004EA0 RID: 20128 RVA: 0x00033341 File Offset: 0x00031541
	private Mesh method_1()
	{
		return this.m_mesh[this.m_meshIndex];
	}

	// Token: 0x06004EA1 RID: 20129 RVA: 0x0014E628 File Offset: 0x0014C828
	public MeshCollider method_2()
	{
		MeshCollider meshCollider = null;
		if (this.m_enabled && this.m_renderer)
		{
			if (Time.time - this.m_time > this.m_interval)
			{
				CPUSkinning.smethod_0(this.m_renderer, this.method_0());
				this.m_time = Time.time;
			}
			this.m_collider.sharedMesh = this.method_1();
			meshCollider = this.m_collider;
		}
		return meshCollider;
	}

	// Token: 0x06004EA2 RID: 20130 RVA: 0x00033350 File Offset: 0x00031550
	private void OnSpawnCompleted()
	{
		this.m_collider = base.gameObject.GetComponentInChildren<MeshCollider>();
		this.m_renderer = base.gameObject.GetComponentInChildren<SkinnedMeshRenderer>();
	}

	// Token: 0x04003ADD RID: 15069
	public MeshCollider m_collider;

	// Token: 0x04003ADE RID: 15070
	public SkinnedMeshRenderer m_renderer;

	// Token: 0x04003ADF RID: 15071
	private Mesh[] m_mesh = new Mesh[2];

	// Token: 0x04003AE0 RID: 15072
	private int m_meshIndex;

	// Token: 0x04003AE1 RID: 15073
	private float m_time;

	// Token: 0x04003AE2 RID: 15074
	private float m_interval = 0.25f;

	// Token: 0x04003AE3 RID: 15075
	private bool m_enabled = true;
}
