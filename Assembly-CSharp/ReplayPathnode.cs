using System;
using UnityEngine;

// Token: 0x02000654 RID: 1620
[Serializable]
public class ReplayPathnode
{
	// Token: 0x060028FB RID: 10491 RVA: 0x000C15F4 File Offset: 0x000BF7F4
	public Vector3 method_0(int int_0, float float_0)
	{
		float num = 0.7853982f * (float)int_0;
		float num2 = Mathf.Cos(num);
		float num3 = Mathf.Sin(num);
		Vector3 vector = new Vector3(float_0 * num2 - float_0 * num3, 0.1f, float_0 * num3 + float_0 * num2);
		return vector;
	}

	// Token: 0x04001D41 RID: 7489
	public Vector3 pos;

	// Token: 0x04001D42 RID: 7490
	public Quaternion rot;

	// Token: 0x04001D43 RID: 7491
	public int ilookatpoint;

	// Token: 0x04001D44 RID: 7492
	public float lookatspeed;

	// Token: 0x04001D45 RID: 7493
	public float translatespeed;
}
