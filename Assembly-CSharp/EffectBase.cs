using System;
using UnityEngine;

// Token: 0x02000B49 RID: 2889
public abstract class EffectBase : MonoBehaviour
{
	// Token: 0x06004EA4 RID: 20132 RVA: 0x00033387 File Offset: 0x00031587
	public void PlayEffect(EffectTriggerData data)
	{
		if (!base.enabled)
		{
			return;
		}
		if (data.m_effectName == this.m_myName)
		{
			this.PlayEffect(data.m_trigger);
		}
	}

	// Token: 0x06004EA5 RID: 20133
	public abstract void PlayEffect(EffectTrigger trigger);

	// Token: 0x04003AE4 RID: 15076
	public string m_myName = "effect";

	// Token: 0x04003AE5 RID: 15077
	[HideInInspector]
	public EffectPool m_pool;
}
