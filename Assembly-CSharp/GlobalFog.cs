using System;
using UnityEngine;

// Token: 0x020005B4 RID: 1460
[RequireComponent(typeof(Camera))]
[AddComponentMenu("Image Effects/Global Fog")]
[ExecuteInEditMode]
internal class GlobalFog : MonoBehaviour
{
	// Token: 0x0600251B RID: 9499 RVA: 0x000B2590 File Offset: 0x000B0790
	private Material method_0(Shader shader_0, Material material_0)
	{
		if (!shader_0)
		{
			base.enabled = false;
			return null;
		}
		if (shader_0.isSupported && material_0 && material_0.shader == shader_0)
		{
			return material_0;
		}
		if (!shader_0.isSupported)
		{
			this.method_2();
			return null;
		}
		material_0 = new Material(shader_0);
		material_0.hideFlags = HideFlags.DontSave;
		if (material_0)
		{
			return material_0;
		}
		return null;
	}

	// Token: 0x0600251C RID: 9500 RVA: 0x000B25FC File Offset: 0x000B07FC
	private bool method_1(bool bool_0)
	{
		this.isSupported = true;
		if (!SystemInfo.supportsImageEffects || !SystemInfo.supportsRenderTextures)
		{
			this.method_2();
			return false;
		}
		if (bool_0 && !SystemInfo.SupportsRenderTextureFormat(RenderTextureFormat.Depth))
		{
			this.method_2();
			return false;
		}
		if (bool_0)
		{
			base.camera.depthTextureMode |= DepthTextureMode.Depth;
		}
		return true;
	}

	// Token: 0x0600251D RID: 9501 RVA: 0x00019365 File Offset: 0x00017565
	private void method_2()
	{
		base.enabled = false;
		this.isSupported = false;
	}

	// Token: 0x0600251E RID: 9502 RVA: 0x00019375 File Offset: 0x00017575
	private bool method_3()
	{
		this.method_1(true);
		this.fogMaterial = this.method_0(this.FogShader, this.fogMaterial);
		return this.isSupported;
	}

	// Token: 0x0600251F RID: 9503 RVA: 0x0001939D File Offset: 0x0001759D
	private void Start()
	{
		this.method_3();
	}

	// Token: 0x06002520 RID: 9504 RVA: 0x000193A6 File Offset: 0x000175A6
	private void OnEnable()
	{
		this.isSupported = true;
	}

	// Token: 0x06002521 RID: 9505 RVA: 0x000B2650 File Offset: 0x000B0850
	private void OnRenderImage(RenderTexture source, RenderTexture destination)
	{
		if (this.method_3() && (this.EnableNearFog || this.EnableFarFog))
		{
			this.CAMERA_NEAR = base.camera.nearClipPlane;
			this.CAMERA_FAR = base.camera.farClipPlane;
			this.CAMERA_FOV = base.camera.fieldOfView;
			this.CAMERA_ASPECT_RATIO = base.camera.aspect;
			Matrix4x4 identity = Matrix4x4.identity;
			float num = this.CAMERA_FOV * 0.5f;
			Vector3 vector = base.camera.transform.right * this.CAMERA_NEAR * Mathf.Tan(num * 0.017453292f) * this.CAMERA_ASPECT_RATIO;
			Vector3 vector2 = base.camera.transform.up * this.CAMERA_NEAR * Mathf.Tan(num * 0.017453292f);
			Vector3 vector3 = base.camera.transform.forward * this.CAMERA_NEAR - vector + vector2;
			float num2 = vector3.magnitude * this.CAMERA_FAR / this.CAMERA_NEAR;
			vector3.Normalize();
			vector3 *= num2;
			Vector3 vector4 = base.camera.transform.forward * this.CAMERA_NEAR + vector + vector2;
			vector4.Normalize();
			vector4 *= num2;
			Vector3 vector5 = base.camera.transform.forward * this.CAMERA_NEAR + vector - vector2;
			vector5.Normalize();
			vector5 *= num2;
			Vector3 vector6 = base.camera.transform.forward * this.CAMERA_NEAR - vector - vector2;
			vector6.Normalize();
			vector6 *= num2;
			identity.SetRow(0, vector3);
			identity.SetRow(1, vector4);
			identity.SetRow(2, vector5);
			identity.SetRow(3, vector6);
			this.fogMaterial.SetMatrix("_FrustumCornersWS", identity);
			this.fogMaterial.SetVector("_CameraWS", base.camera.transform.position);
			this.startDistance.x = 1f / this.NearStartDistance;
			this.startDistance.y = num2 - this.NearStartDistance;
			this.startDistance.z = 1f / this.FarStartDistance;
			this.startDistance.w = num2 - this.FarStartDistance;
			this.fogMaterial.SetVector("_StartDistance", this.startDistance);
			this.height.x = this.NearHeight;
			this.height.y = 1f / this.NearHeightScale;
			this.height.z = this.FarHeight;
			this.height.w = 1f / this.FarHeightScale;
			this.fogMaterial.SetVector("_Y", this.height);
			this.fogMaterial.SetFloat("_NearGlobalDensity", this.NearGlobalDensity * 0.01f);
			this.fogMaterial.SetFloat("_FarGlobalDensity", this.FarGlobalDensity * 0.01f);
			this.fogMaterial.SetColor("_FogColor", this.GlobalFogColor);
			if (this.EnableNearFog && this.EnableFarFog)
			{
				this.method_4(source, destination, this.fogMaterial, 0);
			}
			else if (this.EnableNearFog)
			{
				this.method_4(source, destination, this.fogMaterial, 1);
			}
			else if (this.EnableFarFog)
			{
				this.method_4(source, destination, this.fogMaterial, 2);
			}
			return;
		}
		Graphics.Blit(source, destination);
	}

	// Token: 0x06002522 RID: 9506 RVA: 0x000B2A28 File Offset: 0x000B0C28
	private void method_4(RenderTexture renderTexture_0, RenderTexture renderTexture_1, Material material_0, int int_0)
	{
		RenderTexture.active = renderTexture_1;
		material_0.SetTexture("_MainTex", renderTexture_0);
		GL.PushMatrix();
		GL.LoadOrtho();
		material_0.SetPass(int_0);
		GL.Begin(7);
		GL.MultiTexCoord2(0, 0f, 0f);
		GL.Vertex3(0f, 0f, 3f);
		GL.MultiTexCoord2(0, 1f, 0f);
		GL.Vertex3(1f, 0f, 2f);
		GL.MultiTexCoord2(0, 1f, 1f);
		GL.Vertex3(1f, 1f, 1f);
		GL.MultiTexCoord2(0, 0f, 1f);
		GL.Vertex3(0f, 1f, 0f);
		GL.End();
		GL.PopMatrix();
	}

	// Token: 0x04001A73 RID: 6771
	public bool EnableNearFog = true;

	// Token: 0x04001A74 RID: 6772
	public float NearStartDistance = 200f;

	// Token: 0x04001A75 RID: 6773
	public float NearGlobalDensity = 1f;

	// Token: 0x04001A76 RID: 6774
	public float NearHeightScale = 100f;

	// Token: 0x04001A77 RID: 6775
	public float NearHeight;

	// Token: 0x04001A78 RID: 6776
	public bool EnableFarFog = true;

	// Token: 0x04001A79 RID: 6777
	public float FarStartDistance = 200f;

	// Token: 0x04001A7A RID: 6778
	public float FarGlobalDensity = 1f;

	// Token: 0x04001A7B RID: 6779
	public float FarHeightScale = 100f;

	// Token: 0x04001A7C RID: 6780
	public float FarHeight;

	// Token: 0x04001A7D RID: 6781
	public Color GlobalFogColor = Color.grey;

	// Token: 0x04001A7E RID: 6782
	public Shader FogShader;

	// Token: 0x04001A7F RID: 6783
	private Material fogMaterial;

	// Token: 0x04001A80 RID: 6784
	protected bool isSupported = true;

	// Token: 0x04001A81 RID: 6785
	private float CAMERA_NEAR = 0.5f;

	// Token: 0x04001A82 RID: 6786
	private float CAMERA_FAR = 50f;

	// Token: 0x04001A83 RID: 6787
	private float CAMERA_FOV = 60f;

	// Token: 0x04001A84 RID: 6788
	private float CAMERA_ASPECT_RATIO = 1.333333f;

	// Token: 0x04001A85 RID: 6789
	private Vector4 startDistance = Vector4.zero;

	// Token: 0x04001A86 RID: 6790
	private Vector4 height = Vector4.zero;
}
