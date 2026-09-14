using System;
using UnityEngine;

// Token: 0x0200025B RID: 603
[Serializable]
public class BadAssCharacterMotorMovement
{
	// Token: 0x04000B29 RID: 2857
	[NonSerialized]
	public CollisionFlags collisionFlags;

	// Token: 0x04000B2A RID: 2858
	[NonSerialized]
	public Vector3 velocity;

	// Token: 0x04000B2B RID: 2859
	[NonSerialized]
	public Vector3 frameVelocity = Vector3.zero;

	// Token: 0x04000B2C RID: 2860
	[NonSerialized]
	public Vector3 hitPoint = Vector3.zero;

	// Token: 0x04000B2D RID: 2861
	[NonSerialized]
	public Vector3 lastHitPoint = Vector3.zero;

	// Token: 0x04000B2E RID: 2862
	[NonSerialized]
	public Vector3 lastHitNormal = Vector3.zero;

	// Token: 0x04000B2F RID: 2863
	[NonSerialized]
	public Vector3 frameOffset = Vector3.zero;
}
