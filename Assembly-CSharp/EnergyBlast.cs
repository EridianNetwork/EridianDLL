using System;
using UnityEngine;

// Token: 0x0200024B RID: 587
public class EnergyBlast : MonoBehaviour
{
	// Token: 0x06000BFE RID: 3070 RVA: 0x0000BA62 File Offset: 0x00009C62
	private void Start()
	{
		this.m_bStarted = false;
	}

	// Token: 0x06000BFF RID: 3071 RVA: 0x00068368 File Offset: 0x00066568
	private void Update()
	{
		if (!this.m_bStarted)
		{
			this.m_delayTimer -= Time.deltaTime;
			if (this.m_delayTimer < 0f)
			{
				ParticleSystem component = base.GetComponent<ParticleSystem>();
				if (component != null)
				{
					component.Play();
				}
				global::UnityEngine.Object.Destroy(base.gameObject, 5f);
				this.m_bStarted = true;
			}
		}
	}

	// Token: 0x04000AA6 RID: 2726
	[HideInInspector]
	public BHVTaskManager m_taskManager;

	// Token: 0x04000AA7 RID: 2727
	[HideInInspector]
	public float m_delayTimer = 1f;

	// Token: 0x04000AA8 RID: 2728
	private bool m_bStarted;
}
