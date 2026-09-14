using System;

// Token: 0x02000083 RID: 131
[Serializable]
public class ParticleInfo
{
	// Token: 0x04000293 RID: 659
	public float m_delay;

	// Token: 0x04000294 RID: 660
	public ENPCParticleType m_particleToPlay;

	// Token: 0x04000295 RID: 661
	public float m_duration = 1f;

	// Token: 0x04000296 RID: 662
	public bool m_alreadyPlayed;

	// Token: 0x04000297 RID: 663
	public bool m_hideDefaultTransformWhenPlay;
}
