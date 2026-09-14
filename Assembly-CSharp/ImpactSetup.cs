using System;
using UnityEngine;

// Token: 0x0200057B RID: 1403
[Serializable]
public class ImpactSetup
{
	// Token: 0x040018AC RID: 6316
	public string m_impactType;

	// Token: 0x040018AD RID: 6317
	public ParticleSystem m_particuleSystem;

	// Token: 0x040018AE RID: 6318
	public Vector3 m_decalSize = new Vector3(0.22f, 0.22f, 0.22f);

	// Token: 0x040018AF RID: 6319
	public Texture2D[] m_texture;

	// Token: 0x040018B0 RID: 6320
	public Material m_material;
}
