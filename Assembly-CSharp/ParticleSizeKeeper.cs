using System;
using ns0;
using UnityEngine;

// Token: 0x020005DB RID: 1499
public class ParticleSizeKeeper : MonoBehaviour
{
	// Token: 0x060025FA RID: 9722 RVA: 0x000B7598 File Offset: 0x000B5798
	private void Start()
	{
		if (base.gameObject.particleSystem != null)
		{
			this.mOriginalSize = base.gameObject.particleSystem.startSize;
		}
		if (base.gameObject.GetComponent<MeshRenderer>() != null)
		{
			this.mOriginalScale = base.gameObject.transform.localScale;
		}
	}

	// Token: 0x060025FB RID: 9723 RVA: 0x000B75F8 File Offset: 0x000B57F8
	private void Update()
	{
		if (MonoSingleton<Session>.Instance.GetLocalPlayer() && MonoSingleton<Session>.Instance.GetLocalPlayer().GetEntity())
		{
			EntityPlayer entityPlayer = MonoSingleton<Session>.Instance.GetLocalPlayer().GetEntity() as EntityPlayer;
			if (entityPlayer != null)
			{
				BadAssFPSCamera badAssFPSCamera = entityPlayer.method_45();
				if (!badAssFPSCamera || !badAssFPSCamera.camera)
				{
					return;
				}
				float num = Vector3.Distance(base.gameObject.transform.position, badAssFPSCamera.camera.gameObject.transform.position);
				if (base.gameObject.particleSystem != null && badAssFPSCamera.method_3() != null)
				{
					float num2 = badAssFPSCamera.camera.fieldOfView / badAssFPSCamera.method_3().m_FOVDefault;
					base.gameObject.particleSystem.startSize = this.mOriginalSize * num2 * (num / this.KeepDistance);
				}
				if (base.gameObject.GetComponent<MeshRenderer>() != null)
				{
					base.gameObject.transform.localScale = this.mOriginalScale * (num / this.KeepDistance);
				}
			}
			return;
		}
	}

	// Token: 0x04001B9C RID: 7068
	public float KeepDistance = 10f;

	// Token: 0x04001B9D RID: 7069
	private float mOriginalSize = 1f;

	// Token: 0x04001B9E RID: 7070
	private Vector3 mOriginalScale = Vector3.one;
}
