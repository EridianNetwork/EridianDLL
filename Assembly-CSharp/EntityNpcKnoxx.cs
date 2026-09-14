using System;
using UnityEngine;

// Token: 0x02000456 RID: 1110
public class EntityNpcKnoxx : EntityNpc
{
	// Token: 0x06001BB2 RID: 7090 RVA: 0x00013EAE File Offset: 0x000120AE
	public override ENPCParticleType vmethod_13(ENPCParticleType enpcparticleType_0, WeakPoint weakPoint_0)
	{
		return ENPCParticleType.E_DamageOnArmor;
	}

	// Token: 0x04001266 RID: 4710
	public Transform m_lunchPointLeft;

	// Token: 0x04001267 RID: 4711
	public Transform m_lunchPointRight;
}
