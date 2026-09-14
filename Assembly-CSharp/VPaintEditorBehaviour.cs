using System;
using UnityEngine;

// Token: 0x02000B79 RID: 2937
[ExecuteInEditMode]
public class VPaintEditorBehaviour : MonoBehaviour
{
	// Token: 0x06004F82 RID: 20354 RVA: 0x00033E7B File Offset: 0x0003207B
	public void OnEnable()
	{
		base.gameObject.hideFlags = HideFlags.HideInHierarchy;
	}
}
