using System;
using UnityEngine;

// Token: 0x02000B4A RID: 2890
public class EffectPoolController : MonoBehaviour
{
	// Token: 0x06004EA7 RID: 20135 RVA: 0x000333B1 File Offset: 0x000315B1
	private void OnDestroy()
	{
		if (!this.m_destroyedByPool && this.m_pool != null)
		{
			this.m_pool.method_1(base.gameObject);
		}
	}

	// Token: 0x06004EA8 RID: 20136 RVA: 0x000333D4 File Offset: 0x000315D4
	private void YouAreDestroyedByPool()
	{
		this.m_destroyedByPool = true;
	}

	// Token: 0x06004EA9 RID: 20137 RVA: 0x000333DD File Offset: 0x000315DD
	public void method_0(EffectPool effectPool_0)
	{
		this.m_pool = effectPool_0;
		if (this.m_pool != null)
		{
			this.m_pool.method_0(base.gameObject);
		}
	}

	// Token: 0x04003AE6 RID: 15078
	[HideInInspector]
	public bool m_destroyedByPool;

	// Token: 0x04003AE7 RID: 15079
	[HideInInspector]
	public EffectPool m_pool;
}
