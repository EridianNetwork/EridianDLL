using System;
using Core;
using UnityEngine;

// Token: 0x020004D3 RID: 1235
[Serializable]
public class ClusterAction : ScriptableObject, ICloneable, IComparable
{
	// Token: 0x06002131 RID: 8497 RVA: 0x000A0A08 File Offset: 0x0009EC08
	public virtual object Clone()
	{
		ClusterAction clusterAction = ScriptableObject.CreateInstance(base.GetType()) as ClusterAction;
		clusterAction.m_executionOrder = this.m_executionOrder;
		return clusterAction;
	}

	// Token: 0x06002132 RID: 8498 RVA: 0x000A0A34 File Offset: 0x0009EC34
	public int CompareTo(object obj)
	{
		if (!(obj is ClusterAction))
		{
			DebugUtils.LogError(LogCategory.System, "compare to Object is not a ClusterAction");
			return 0;
		}
		if (this == obj)
		{
			return 0;
		}
		int executionOrder = (obj as ClusterAction).m_executionOrder;
		if (this.m_executionOrder <= executionOrder)
		{
			return -1;
		}
		return 1;
	}

	// Token: 0x06002133 RID: 8499 RVA: 0x00003C2E File Offset: 0x00001E2E
	public virtual void vmethod_0(Scene scene_0)
	{
		throw new NotImplementedException();
	}

	// Token: 0x040015C7 RID: 5575
	[SerializeField]
	protected int m_executionOrder;
}
