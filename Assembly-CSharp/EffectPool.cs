using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x02000B4B RID: 2891
public class EffectPool
{
	// Token: 0x06004EAA RID: 20138 RVA: 0x000333FF File Offset: 0x000315FF
	public EffectPool(int int_0)
	{
		this.m_max = int_0;
		if (int_0 > 0)
		{
			this.m_pool = new List<GameObject>(this.m_max);
		}
	}

	// Token: 0x06004EAB RID: 20139 RVA: 0x0014E698 File Offset: 0x0014C898
	public void method_0(GameObject gameObject_0)
	{
		if (this.m_pool != null && gameObject_0 != null)
		{
			while (this.m_pool.Count >= this.m_max)
			{
				GameObject gameObject = this.m_pool[0];
				gameObject.SendMessage("YouAreDestroyedByPool", SendMessageOptions.DontRequireReceiver);
				global::UnityEngine.Object.Destroy(gameObject);
				this.m_pool.RemoveAt(0);
			}
			this.m_pool.Add(gameObject_0);
		}
	}

	// Token: 0x06004EAC RID: 20140 RVA: 0x00033423 File Offset: 0x00031623
	public void method_1(GameObject gameObject_0)
	{
		if (this.m_pool != null)
		{
			this.m_pool.Remove(gameObject_0);
		}
	}

	// Token: 0x04003AE8 RID: 15080
	public int m_max;

	// Token: 0x04003AE9 RID: 15081
	private List<GameObject> m_pool;
}
