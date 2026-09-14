using System;
using UnityEngine;

// Token: 0x02000594 RID: 1428
public class ClearCameraDepth : MonoBehaviour
{
	// Token: 0x06002483 RID: 9347 RVA: 0x000AEC40 File Offset: 0x000ACE40
	private void FixedUpdate()
	{
		if (this.mWpnCamera)
		{
			base.camera.worldToCameraMatrix = this.mWpnCamera.worldToCameraMatrix;
			base.camera.transform.position = this.mWpnCamera.transform.position;
			base.camera.transform.rotation = this.mWpnCamera.transform.rotation;
			base.camera.ResetWorldToCameraMatrix();
		}
	}

	// Token: 0x04001963 RID: 6499
	public Camera mWpnCamera;
}
