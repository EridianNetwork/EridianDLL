using System;
using ns0;
using UnityEngine;

// Token: 0x02000B3F RID: 2879
public class BassBillboard : MonoBehaviour
{
	// Token: 0x06004E7A RID: 20090 RVA: 0x0014C6A4 File Offset: 0x0014A8A4
	public void Start()
	{
		this.m_render = (Renderer)base.gameObject.GetComponent(typeof(Renderer));
		if (MonoSingleton<VisibilityManager>.Instance && this.m_render)
		{
			MonoSingleton<VisibilityManager>.Instance.method_0(this.m_render);
		}
		if (this.m_isMaxBounds)
		{
			MeshFilter component = base.gameObject.GetComponent<MeshFilter>();
			if (component != null)
			{
				component.mesh.bounds = new Bounds(component.mesh.bounds.center, new Vector3(1000f, 1000f, 1000f));
			}
		}
	}

	// Token: 0x06004E7B RID: 20091 RVA: 0x00033172 File Offset: 0x00031372
	private void OnDestroy()
	{
		if (MonoSingleton<VisibilityManager>.Instance && this.m_render)
		{
			MonoSingleton<VisibilityManager>.Instance.method_2(this.m_render);
		}
	}

	// Token: 0x06004E7C RID: 20092 RVA: 0x0014C750 File Offset: 0x0014A950
	public void method_0()
	{
		if (this.m_camera != null)
		{
			return;
		}
		for (int i = 0; i < Camera.allCameras.Length; i++)
		{
			Camera camera = Camera.allCameras[i];
			if (camera.name.ToLower().Contains("fps"))
			{
				this.m_camera = camera;
			}
		}
	}

	// Token: 0x06004E7D RID: 20093 RVA: 0x0014C7A4 File Offset: 0x0014A9A4
	private void OnWillRenderObject()
	{
		if (this.m_isActive)
		{
			this.method_0();
			if (!this.m_isVertical)
			{
				if (this.m_camera == null)
				{
					return;
				}
				base.transform.LookAt(base.transform.position + this.m_camera.transform.localToWorldMatrix.MultiplyVector(Vector3.forward), Vector3.up);
			}
			else
			{
				if (this.m_camera == null)
				{
					return;
				}
				Vector3 position = this.m_camera.transform.position;
				position.y = base.transform.position.y;
				base.transform.LookAt(position, Vector3.up);
			}
		}
	}

	// Token: 0x04003A96 RID: 14998
	public Camera m_camera;

	// Token: 0x04003A97 RID: 14999
	public bool m_isActive = true;

	// Token: 0x04003A98 RID: 15000
	public bool m_isVertical;

	// Token: 0x04003A99 RID: 15001
	public bool m_isMaxBounds;

	// Token: 0x04003A9A RID: 15002
	private Renderer m_render;
}
