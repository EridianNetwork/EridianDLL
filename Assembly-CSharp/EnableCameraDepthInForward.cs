using System;
using UnityEngine;

// Token: 0x02000B3A RID: 2874
[RequireComponent(typeof(Camera))]
public class EnableCameraDepthInForward : MonoBehaviour
{
	// Token: 0x06004E69 RID: 20073 RVA: 0x0003309E File Offset: 0x0003129E
	private void Start()
	{
		this.method_0();
	}

	// Token: 0x06004E6A RID: 20074 RVA: 0x000330A6 File Offset: 0x000312A6
	private void method_0()
	{
		if (base.GetComponent<Camera>().depthTextureMode == DepthTextureMode.None)
		{
			base.GetComponent<Camera>().depthTextureMode = DepthTextureMode.Depth;
		}
	}
}
