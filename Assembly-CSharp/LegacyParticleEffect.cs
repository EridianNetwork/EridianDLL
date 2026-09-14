using System;
using UnityEngine;

// Token: 0x02000B55 RID: 2901
[AddComponentMenu("Effects/TKC/Legacy Particle Effect")]
public class LegacyParticleEffect : ClonableEffectBase
{
	// Token: 0x06004EC1 RID: 20161 RVA: 0x0014EAF4 File Offset: 0x0014CCF4
	public override void vmethod_1(EffectTrigger effectTrigger_0)
	{
		if (this.m_effect != null)
		{
			ParticleEmitter particleEmitter = (ParticleEmitter)global::UnityEngine.Object.Instantiate(this.m_effect);
			this.m_clone = particleEmitter.gameObject;
			particleEmitter.Emit();
		}
	}

	// Token: 0x06004EC2 RID: 20162 RVA: 0x00033572 File Offset: 0x00031772
	public override void vmethod_2()
	{
		if (this.m_effect != null)
		{
			this.m_effect.Emit();
		}
	}

	// Token: 0x06004EC3 RID: 20163 RVA: 0x0003358D File Offset: 0x0003178D
	public override GameObject vmethod_0()
	{
		if (this.m_effect == null)
		{
			return null;
		}
		return this.m_effect.gameObject;
	}

	// Token: 0x04003B22 RID: 15138
	public ParticleEmitter m_effect;
}
