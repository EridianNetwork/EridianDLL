using System;
using UnityEngine;

// Token: 0x02000038 RID: 56
public class TheInsaneCrystalAnimationManagerFSM : NPCAnimationManagerFSM
{
	// Token: 0x06000172 RID: 370 RVA: 0x0003C7D0 File Offset: 0x0003A9D0
	public override void Start()
	{
		base.Start();
		if (this.m_energyBlast != null)
		{
			this.m_energyBlast.gameObject.SetActive(true);
			this.m_energyBlastVFX = this.m_energyBlast.GetComponent<ParticleSystem>();
		}
		if (this.m_deathStruggle != null)
		{
			this.m_deathStruggle.gameObject.SetActive(true);
			this.m_deathStruggleVFX = this.m_deathStruggle.GetComponent<ParticleSystem>();
		}
	}

	// Token: 0x06000173 RID: 371 RVA: 0x00003BA3 File Offset: 0x00001DA3
	public void method_31(bool bool_0)
	{
		if (this.m_energyBlastVFX == null)
		{
			return;
		}
		if (bool_0)
		{
			this.m_energyBlastVFX.Play();
		}
		else
		{
			this.m_energyBlastVFX.Stop();
		}
	}

	// Token: 0x06000174 RID: 372 RVA: 0x0003C844 File Offset: 0x0003AA44
	public void method_32(bool bool_0)
	{
		if (this.m_deathStruggleVFX == null)
		{
			return;
		}
		if (bool_0)
		{
			this.m_deathStruggleVFX.Play();
		}
		else
		{
			this.m_deathStruggleVFX.Stop();
			this.m_VFXManager.method_10(ENPCParticleType.E_CrystalDeathStruggle, base.transform.position, true);
		}
	}

	// Token: 0x0400015B RID: 347
	public Transform m_energyBlast;

	// Token: 0x0400015C RID: 348
	public Transform m_deathStruggle;

	// Token: 0x0400015D RID: 349
	private ParticleSystem m_energyBlastVFX;

	// Token: 0x0400015E RID: 350
	private ParticleSystem m_deathStruggleVFX;
}
