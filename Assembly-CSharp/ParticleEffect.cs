using System;
using UnityEngine;

// Token: 0x02000B58 RID: 2904
[AddComponentMenu("Effects/TKC/Particle Effect")]
public class ParticleEffect : ClonableEffectBase
{
	// Token: 0x06004ECD RID: 20173 RVA: 0x0014F2B0 File Offset: 0x0014D4B0
	public override void vmethod_1(EffectTrigger effectTrigger_0)
	{
		if (this.m_effect != null)
		{
			base.method_0(this.vmethod_0().transform, effectTrigger_0);
			ParticleSystem particleSystem = (ParticleSystem)global::UnityEngine.Object.Instantiate(this.m_effect, this.vmethod_0().transform.position, this.vmethod_0().transform.rotation);
			this.m_clone = particleSystem.gameObject;
			if (!particleSystem.playOnAwake)
			{
				particleSystem.Play();
			}
		}
	}

	// Token: 0x06004ECE RID: 20174 RVA: 0x000335B9 File Offset: 0x000317B9
	public override void vmethod_2()
	{
		if (this.m_effect != null && (this.m_restartWhenPlay || !this.m_effect.isPlaying))
		{
			this.m_effect.Play();
		}
	}

	// Token: 0x06004ECF RID: 20175 RVA: 0x000335E9 File Offset: 0x000317E9
	public override GameObject vmethod_0()
	{
		if (this.m_effect == null)
		{
			return null;
		}
		return this.m_effect.gameObject;
	}

	// Token: 0x04003B26 RID: 15142
	public ParticleSystem m_effect;

	// Token: 0x04003B27 RID: 15143
	public bool m_restartWhenPlay = true;
}
