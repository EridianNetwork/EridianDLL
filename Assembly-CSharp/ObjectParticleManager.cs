using System;
using UnityEngine;

// Token: 0x02000084 RID: 132
public class ObjectParticleManager : MonoBehaviour
{
	// Token: 0x060002BC RID: 700 RVA: 0x00042488 File Offset: 0x00040688
	private void Start()
	{
		this.m_VFXManager = base.GetComponent<VFXManager>();
		this.m_startTime = Time.time;
		if (this.m_defaultTransform != null && this.m_alternativeTransform != null)
		{
			this.m_defaultTransform.gameObject.SetActive(true);
			this.m_alternativeTransform.gameObject.SetActive(false);
		}
	}

	// Token: 0x060002BD RID: 701 RVA: 0x000424EC File Offset: 0x000406EC
	private void Update()
	{
		for (int i = 0; i < this.m_particlePlayList.Length; i++)
		{
			if (!this.m_particlePlayList[i].m_alreadyPlayed && Time.time - this.m_startTime > this.m_particlePlayList[i].m_delay)
			{
				this.method_1(this.m_particlePlayList[i].m_particleToPlay, this.m_particlePlayList[i].m_duration);
				this.m_particlePlayList[i].m_alreadyPlayed = true;
				if (this.m_particlePlayList[i].m_hideDefaultTransformWhenPlay && this.m_defaultTransform != null)
				{
					this.m_defaultTransform.gameObject.SetActive(false);
				}
			}
		}
	}

	// Token: 0x060002BE RID: 702 RVA: 0x00042598 File Offset: 0x00040798
	public void method_0(ENPCParticleType enpcparticleType_0)
	{
		for (int i = 0; i < this.m_particlePlayList.Length; i++)
		{
			if (this.m_particlePlayList[i].m_particleToPlay == enpcparticleType_0)
			{
				this.m_particlePlayList[i].m_alreadyPlayed = false;
			}
		}
	}

	// Token: 0x060002BF RID: 703 RVA: 0x0000498E File Offset: 0x00002B8E
	public void method_1(ENPCParticleType enpcparticleType_0, float float_0)
	{
		this.m_VFXManager.method_4(enpcparticleType_0, float_0, true);
	}

	// Token: 0x060002C0 RID: 704 RVA: 0x0000499F File Offset: 0x00002B9F
	public void method_2()
	{
		this.m_VFXManager.method_15();
	}

	// Token: 0x060002C1 RID: 705 RVA: 0x000049AC File Offset: 0x00002BAC
	public void method_3()
	{
		if (this.m_defaultTransform != null && this.m_alternativeTransform != null)
		{
			this.m_defaultTransform.gameObject.SetActive(false);
			this.m_alternativeTransform.gameObject.SetActive(true);
		}
	}

	// Token: 0x060002C2 RID: 706 RVA: 0x000049EC File Offset: 0x00002BEC
	private void OnDestroy()
	{
		if (this.m_clearAllParticleAtEnd)
		{
			this.method_2();
		}
	}

	// Token: 0x04000298 RID: 664
	public bool m_clearAllParticleAtEnd;

	// Token: 0x04000299 RID: 665
	public ParticleInfo[] m_particlePlayList;

	// Token: 0x0400029A RID: 666
	public Transform m_defaultTransform;

	// Token: 0x0400029B RID: 667
	public Transform m_alternativeTransform;

	// Token: 0x0400029C RID: 668
	private VFXManager m_VFXManager;

	// Token: 0x0400029D RID: 669
	private float m_startTime;
}
