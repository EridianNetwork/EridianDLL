using System;
using UnityEngine;

// Token: 0x02000484 RID: 1156
public interface InteractionClient
{
	// Token: 0x06001E53 RID: 7763
	bool imethod_2(Ray ray_0, ref float float_0);

	// Token: 0x06001E54 RID: 7764
	bool imethod_3(Entity entity_0);

	// Token: 0x06001E55 RID: 7765
	bool imethod_4();

	// Token: 0x06001E56 RID: 7766
	void imethod_5(Entity entity_0, bool bool_0 = false);

	// Token: 0x06001E57 RID: 7767
	Vector3 imethod_0();

	// Token: 0x06001E58 RID: 7768
	E_USE_TYPE imethod_6();
}
