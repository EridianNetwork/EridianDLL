using System;
using UnityEngine;

// Token: 0x0200024A RID: 586
public class DestoryableObjEffect : MonoBehaviour
{
	// Token: 0x06000BFC RID: 3068 RVA: 0x0006832C File Offset: 0x0006652C
	private void Start()
	{
		VFXManager component = base.GetComponent<VFXManager>();
		if (component != null)
		{
			component.method_4(ENPCParticleType.E_Explode, 0f, true);
		}
		global::UnityEngine.Object.Destroy(base.gameObject, 2f);
	}
}
