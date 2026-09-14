using System;
using UnityEngine;

// Token: 0x02000263 RID: 611
[RequireComponent(typeof(Camera))]
public class WeaponCameraControl : MonoBehaviour
{
	// Token: 0x06000CA1 RID: 3233 RVA: 0x0000C100 File Offset: 0x0000A300
	private void Awake()
	{
		this.method_3();
	}

	// Token: 0x06000CA2 RID: 3234 RVA: 0x0000C108 File Offset: 0x0000A308
	public Matrix4x4 method_0()
	{
		return this.m_camProjMatForCuntomShader;
	}

	// Token: 0x06000CA3 RID: 3235 RVA: 0x0000C110 File Offset: 0x0000A310
	public Camera method_1()
	{
		return base.camera;
	}

	// Token: 0x06000CA4 RID: 3236 RVA: 0x0000C118 File Offset: 0x0000A318
	public void method_2(float float_0)
	{
		base.camera.fieldOfView = float_0;
		base.camera.ResetProjectionMatrix();
		this.method_3();
	}

	// Token: 0x06000CA5 RID: 3237 RVA: 0x0000C137 File Offset: 0x0000A337
	public void method_3()
	{
		this.m_camProjMatForCuntomShader = this.method_4(base.camera.projectionMatrix);
	}

	// Token: 0x06000CA6 RID: 3238 RVA: 0x0006CA94 File Offset: 0x0006AC94
	public Matrix4x4 method_4(Matrix4x4 matrix4x4_0)
	{
		Matrix4x4 matrix4x = matrix4x4_0;
		if (SystemInfo.graphicsDeviceVersion.IndexOf("Direct3D") > -1)
		{
			for (int i = 0; i < 4; i++)
			{
				matrix4x[1, i] = -matrix4x[1, i];
			}
			for (int j = 0; j < 4; j++)
			{
				matrix4x[2, j] = matrix4x[2, j] * 0.5f + matrix4x[3, j] * 0.5f;
			}
		}
		return matrix4x;
	}

	// Token: 0x04000B94 RID: 2964
	private Matrix4x4 m_camProjMatForCuntomShader;
}
