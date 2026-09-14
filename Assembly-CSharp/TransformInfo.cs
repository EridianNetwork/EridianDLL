using System;
using UnityEngine;

// Token: 0x0200000E RID: 14
public struct TransformInfo
{
	// Token: 0x06000088 RID: 136 RVA: 0x0000356A File Offset: 0x0000176A
	public TransformInfo(Vector3 vector3_0, Quaternion quaternion_0)
	{
		this.m_position = vector3_0;
		this.m_rotation = quaternion_0;
	}

	// Token: 0x04000042 RID: 66
	public Vector3 m_position;

	// Token: 0x04000043 RID: 67
	public Quaternion m_rotation;
}
