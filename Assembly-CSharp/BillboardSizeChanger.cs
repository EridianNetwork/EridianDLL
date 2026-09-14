using System;
using ns0;
using UnityEngine;

// Token: 0x0200058D RID: 1421
public class BillboardSizeChanger : MonoBehaviour
{
	// Token: 0x0600245C RID: 9308 RVA: 0x00018D58 File Offset: 0x00016F58
	private void Start()
	{
		this.mOriginalScale = base.gameObject.transform.localScale;
	}

	// Token: 0x0600245D RID: 9309 RVA: 0x000AE018 File Offset: 0x000AC218
	private void Update()
	{
		if (!MonoSingleton<Session>.Instance.GetLocalPlayer() || !MonoSingleton<Session>.Instance.GetLocalPlayer().GetEntity())
		{
			return;
		}
		BadAssFPSCamera badAssFPSCamera = (MonoSingleton<Session>.Instance.GetLocalPlayer().GetEntity() as EntityPlayer).method_45();
		if (badAssFPSCamera && badAssFPSCamera.camera)
		{
			float num = Vector3.Distance(base.gameObject.transform.position, badAssFPSCamera.camera.gameObject.transform.position);
			if (num > this.mFarthestDistance)
			{
				float num2 = num / this.mFarthestDistance - 1f;
				base.gameObject.transform.localScale = new Vector3(num2, num2, 0f) + this.mOriginalScale;
			}
			else
			{
				base.gameObject.transform.localScale = this.mOriginalScale;
			}
			return;
		}
	}

	// Token: 0x0400192D RID: 6445
	public float mFarthestDistance = 10f;

	// Token: 0x0400192E RID: 6446
	private Vector3 mOriginalScale = new Vector3(1f, 1f, 1f);
}
