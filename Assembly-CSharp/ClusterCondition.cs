using System;
using UnityEngine;

// Token: 0x020004F9 RID: 1273
[Serializable]
public class ClusterCondition : ScriptableObject, ICloneable
{
	// Token: 0x0600216B RID: 8555 RVA: 0x000A1108 File Offset: 0x0009F308
	public virtual object Clone()
	{
		ClusterCondition clusterCondition = ScriptableObject.CreateInstance(base.GetType()) as ClusterCondition;
		clusterCondition.m_ownerCluster = this.m_ownerCluster;
		clusterCondition.m_isValid = this.m_isValid;
		return clusterCondition;
	}

	// Token: 0x170001BF RID: 447
	// (get) Token: 0x0600216C RID: 8556 RVA: 0x00017018 File Offset: 0x00015218
	// (set) Token: 0x0600216D RID: 8557 RVA: 0x0000311B File Offset: 0x0000131B
	public Scene Owner
	{
		get
		{
			return this.m_ownerCluster;
		}
		private set
		{
		}
	}

	// Token: 0x0600216E RID: 8558 RVA: 0x00017020 File Offset: 0x00015220
	public void method_0(Scene scene_0)
	{
		this.m_ownerCluster = scene_0;
	}

	// Token: 0x0600216F RID: 8559 RVA: 0x00017029 File Offset: 0x00015229
	public void method_1()
	{
		this.m_isValid = true;
	}

	// Token: 0x06002170 RID: 8560 RVA: 0x00017032 File Offset: 0x00015232
	public virtual bool vmethod_0()
	{
		return this.m_isValid;
	}

	// Token: 0x06002171 RID: 8561 RVA: 0x0001703A File Offset: 0x0001523A
	public virtual void Reset()
	{
		this.m_isValid = false;
	}

	// Token: 0x0400161F RID: 5663
	protected Scene m_ownerCluster;

	// Token: 0x04001620 RID: 5664
	protected bool m_isValid;
}
