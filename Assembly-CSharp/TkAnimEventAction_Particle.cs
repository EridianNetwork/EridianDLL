using System;
using UnityEngine;

// Token: 0x02000B62 RID: 2914
[RequireComponent(typeof(ParticleSystem))]
public class TkAnimEventAction_Particle : TkAnimEventAction
{
	// Token: 0x06004EEB RID: 20203 RVA: 0x00033707 File Offset: 0x00031907
	public override bool OnAnimEvent()
	{
		this.ps = base.GetComponent<ParticleSystem>();
		return this.ps;
	}

	// Token: 0x06004EEC RID: 20204 RVA: 0x00033725 File Offset: 0x00031925
	private void Update()
	{
		if (!this.ps)
		{
			global::UnityEngine.Object.Destroy(base.gameObject);
		}
		else if (!this.ps.IsAlive())
		{
			global::UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	// Token: 0x04003B50 RID: 15184
	private ParticleSystem ps;
}
