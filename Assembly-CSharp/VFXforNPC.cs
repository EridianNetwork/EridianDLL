using System;
using UnityEngine;

// Token: 0x0200008D RID: 141
[Serializable]
public class VFXforNPC
{
	// Token: 0x040002D6 RID: 726
	public ENPCParticleType m_type;

	// Token: 0x040002D7 RID: 727
	[HideInInspector]
	public GameObject m_particleGameObject;

	// Token: 0x040002D8 RID: 728
	public string m_particleGameObjectName;

	// Token: 0x040002D9 RID: 729
	[HideInInspector]
	public ParticleSystem m_particle;

	// Token: 0x040002DA RID: 730
	public Transform m_particleTransform;

	// Token: 0x040002DB RID: 731
	[HideInInspector]
	public Utils.Timer m_timer = new Utils.Timer();

	// Token: 0x040002DC RID: 732
	public string m_audioEvent = string.Empty;

	// Token: 0x040002DD RID: 733
	public string m_boneParent = string.Empty;

	// Token: 0x040002DE RID: 734
	[HideInInspector]
	public Transform m_boneTr;
}
