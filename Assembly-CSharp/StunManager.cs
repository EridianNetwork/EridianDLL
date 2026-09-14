using System;
using UnityEngine;

// Token: 0x0200008A RID: 138
public class StunManager : MonoBehaviour
{
	// Token: 0x060002EC RID: 748 RVA: 0x000434F0 File Offset: 0x000416F0
	private void Start()
	{
		base.transform.localPosition = this.m_locationOffset;
		base.transform.localRotation = Quaternion.Euler(this.m_rotationOffset);
		this.m_revolveAngle = 0f;
		this.m_stunParticleSystem = base.gameObject.particleSystem;
		this.m_stunParticleSystem.Clear();
	}

	// Token: 0x060002ED RID: 749 RVA: 0x0004354C File Offset: 0x0004174C
	private void Update()
	{
		if (!this.m_enableStun)
		{
			this.m_stunParticleSystem.Clear();
			return;
		}
		if (this.m_stunParticleSystem != null && !this.m_stunParticleSystem.isPlaying)
		{
			this.m_stunParticleSystem.Play();
		}
		this.m_revolveAngle += Time.deltaTime * this.m_revolveAngularSpeed;
		base.transform.localPosition = this.m_locationOffset + new Vector3(this.m_revolveRadius * Mathf.Sin(this.m_revolveAngle) + global::UnityEngine.Random.Range(0f, this.m_randomOffset), global::UnityEngine.Random.Range(0f, this.m_randomOffset), this.m_revolveRadius * Mathf.Cos(this.m_revolveAngle) + global::UnityEngine.Random.Range(0f, this.m_randomOffset));
	}

	// Token: 0x040002C3 RID: 707
	public Vector3 m_locationOffset = Vector3.zero;

	// Token: 0x040002C4 RID: 708
	public Vector3 m_rotationOffset = Vector3.zero;

	// Token: 0x040002C5 RID: 709
	public float m_revolveRadius;

	// Token: 0x040002C6 RID: 710
	public float m_revolveAngularSpeed;

	// Token: 0x040002C7 RID: 711
	public float m_randomOffset;

	// Token: 0x040002C8 RID: 712
	public bool m_enableStun;

	// Token: 0x040002C9 RID: 713
	protected float m_revolveAngle;

	// Token: 0x040002CA RID: 714
	protected ParticleSystem m_stunParticleSystem;
}
