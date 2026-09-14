using System;
using UnityEngine;

// Token: 0x02000126 RID: 294
[RequireComponent(typeof(TkAudioSource))]
public class TkIAudioClip : MonoBehaviour
{
	// Token: 0x060006AD RID: 1709 RVA: 0x00003727 File Offset: 0x00001927
	public virtual TkAudioSingleClip vmethod_0(bool bool_0)
	{
		return null;
	}

	// Token: 0x04000624 RID: 1572
	[HideInInspector]
	public float m_randomRate = 1f;

	// Token: 0x04000625 RID: 1573
	[NonSerialized]
	public float m_tmpRandomRate = 1f;
}
