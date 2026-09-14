using System;
using ns0;
using UnityEngine;

// Token: 0x020005BF RID: 1471
[AddComponentMenu("Image Effects/SnapImageEffect")]
[RequireComponent(typeof(Camera))]
[ExecuteInEditMode]
public class SnapImageEffect : PostEffectsBase
{
	// Token: 0x06002550 RID: 9552 RVA: 0x000195D8 File Offset: 0x000177D8
	private void OnDestroy()
	{
		global::UnityEngine.Object.Destroy(this.mSnapEffectMaterial);
	}

	// Token: 0x06002551 RID: 9553 RVA: 0x000195E5 File Offset: 0x000177E5
	private void OnDisable()
	{
		if (this.mSnapEffectMaterial)
		{
			global::UnityEngine.Object.DestroyImmediate(this.mSnapEffectMaterial);
		}
	}

	// Token: 0x06002552 RID: 9554 RVA: 0x000B3908 File Offset: 0x000B1B08
	public override bool CheckResources()
	{
		this.mSnapEffectShader = Shader.Find("Custom/SnapEffect");
		this.CheckSupport(true);
		this.mSnapEffectMaterial = this.CheckShaderAndCreateMaterial(this.mSnapEffectShader, this.mSnapEffectMaterial);
		if (!this.isSupported)
		{
			this.ReportAutoDisable();
		}
		return this.isSupported;
	}

	// Token: 0x06002553 RID: 9555 RVA: 0x000B395C File Offset: 0x000B1B5C
	private void OnRenderImage(RenderTexture source, RenderTexture destination)
	{
		if (!this.CheckResources())
		{
			Graphics.Blit(source, destination);
			return;
		}
		if (!MonoSingleton<GraphicsMgr>.Instance.method_19().method_3())
		{
			Graphics.Blit(source, destination);
			return;
		}
		Rect rect = MonoSingleton<GraphicsMgr>.Instance.method_19().method_6();
		int num = (int)(rect.width * (float)source.width);
		int num2 = (int)(rect.height * (float)source.height);
		RenderTexture temporary = RenderTexture.GetTemporary(num, num2, 0, source.format);
		int mItemTexW = MonoSingleton<GraphicsMgr>.Instance.method_19().mItemTexW;
		int mItemTexH = MonoSingleton<GraphicsMgr>.Instance.method_19().mItemTexH;
		RenderTexture temporary2 = RenderTexture.GetTemporary(mItemTexW, mItemTexH, 0, source.format);
		float num3 = (float)mItemTexW / (float)mItemTexH;
		float num4 = (float)num / (float)num2;
		Rect rect2 = new Rect(0f, 0f, 1f, 1f);
		if (num4 > num3)
		{
			float num5 = (float)(num2 * mItemTexW) / (float)(num * mItemTexH);
			float num6 = (1f - num5) * 0.5f;
			rect2 = new Rect(0f, num6, 1f, num6 + num5);
		}
		else
		{
			float num7 = (float)(num * mItemTexH) / (float)(num2 * mItemTexW);
			float num8 = (1f - num7) * 0.5f;
			rect2 = new Rect(num8, 0f, num8 + num7, 1f);
		}
		this.method_0(source, temporary, 0);
		this.method_0(source, temporary, 1);
		this.method_0(source, MonoSingleton<GraphicsMgr>.Instance.method_19().mResultRt, 0);
		this.method_1(temporary, MonoSingleton<GraphicsMgr>.Instance.method_19().mResultRt, 1, rect2);
		Graphics.Blit(MonoSingleton<GraphicsMgr>.Instance.method_19().mResultRt, destination);
		base.StartCoroutine(MonoSingleton<GraphicsMgr>.Instance.method_19().method_8(MonoSingleton<GraphicsMgr>.Instance.method_19().mResultRt));
		RenderTexture.ReleaseTemporary(temporary);
		RenderTexture.ReleaseTemporary(temporary2);
	}

	// Token: 0x06002554 RID: 9556 RVA: 0x000B3B30 File Offset: 0x000B1D30
	private void method_0(RenderTexture renderTexture_0, RenderTexture renderTexture_1, int int_0)
	{
		RenderTexture.active = renderTexture_1;
		this.mSnapEffectMaterial.SetTexture("_MainTex", renderTexture_0);
		GL.PushMatrix();
		GL.LoadOrtho();
		this.mSnapEffectMaterial.SetPass(int_0);
		GL.Begin(7);
		Rect rect = MonoSingleton<GraphicsMgr>.Instance.method_19().method_6();
		float num = 6f / (float)renderTexture_0.width;
		float num2 = 2f / (float)renderTexture_0.height;
		float num3 = rect.x - num;
		float num4 = rect.y - num2;
		float num5 = rect.x + rect.width + num;
		float num6 = rect.y + rect.height + num2;
		GL.MultiTexCoord2(0, num3, num4);
		GL.Vertex3(0f, 0f, 0f);
		GL.MultiTexCoord2(0, num5, num4);
		GL.Vertex3(1f, 0f, 0f);
		GL.MultiTexCoord2(0, num5, num6);
		GL.Vertex3(1f, 1f, 0f);
		GL.MultiTexCoord2(0, num3, num6);
		GL.Vertex3(0f, 1f, 0f);
		GL.End();
		GL.PopMatrix();
	}

	// Token: 0x06002555 RID: 9557 RVA: 0x000B3C58 File Offset: 0x000B1E58
	private void method_1(RenderTexture renderTexture_0, RenderTexture renderTexture_1, int int_0, Rect rect_0)
	{
		RenderTexture.active = renderTexture_1;
		this.mSnapEffectMaterial.SetTexture("_MainTex", renderTexture_0);
		GL.PushMatrix();
		GL.LoadOrtho();
		this.mSnapEffectMaterial.SetPass(int_0);
		GL.Begin(7);
		float x = rect_0.x;
		float y = rect_0.y;
		float width = rect_0.width;
		float height = rect_0.height;
		GL.MultiTexCoord2(0, 0f, 0f);
		GL.Vertex3(x, y, 0f);
		GL.MultiTexCoord2(0, 1f, 0f);
		GL.Vertex3(width, y, 0f);
		GL.MultiTexCoord2(0, 1f, 1f);
		GL.Vertex3(width, height, 0f);
		GL.MultiTexCoord2(0, 0f, 1f);
		GL.Vertex3(x, height, 0f);
		GL.End();
		GL.PopMatrix();
	}

	// Token: 0x04001ABD RID: 6845
	public Shader mSnapEffectShader;

	// Token: 0x04001ABE RID: 6846
	private Material mSnapEffectMaterial;
}
