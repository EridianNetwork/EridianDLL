using System;
using System.Collections.Generic;
using ns0;
using UnityEngine;

// Token: 0x02000775 RID: 1909
public class FontSwapTexture
{
	// Token: 0x06003298 RID: 12952 RVA: 0x000E7B2C File Offset: 0x000E5D2C
	public FontSwapTexture(int int_0, GameObject gameObject_0)
	{
		this._cameraTexture = new RenderTexture(1024, 1024, 0);
		this._cameraTexture.name = "FontSwapTexture_cameraTexture";
		float num = 51.2f;
		this._textureRoot = new GameObject("_Root_" + int_0);
		this._textureRoot.transform.parent = gameObject_0.transform;
		this._textureRoot.transform.localPosition = new Vector3(0f, (float)(-(float)int_0 * 1024), 0f);
		this._cameraObject = new GameObject("TextCamera");
		this._textRendererCamera = this._cameraObject.AddComponent<Camera>();
		this._textRendererCamera.clearFlags = CameraClearFlags.Color;
		this._textRendererCamera.backgroundColor = new Color(0.4f, 0.4f, 0.4f, 0f);
		this._textRendererCamera.cullingMask = 1 << LayerMask.NameToLayer("UI");
		this._textRendererCamera.targetTexture = this._cameraTexture;
		this._textRendererCamera.orthographicSize = num;
		this._textRendererCamera.pixelRect = new Rect(0f, 0f, 1024f, 1024f);
		this._textRendererCamera.orthographic = true;
		this._fontOutline = this._cameraObject.AddComponent<FontOutline>();
		this._fontOutline.edgeDetectShader = MonoSingleton<FontSwapManager>.Instance.mFontOutlineShader;
		this._cameraObject.transform.parent = this._textureRoot.transform;
		this._cameraObject.transform.localPosition = new Vector3(num, -51.2f, -1f);
	}

	// Token: 0x17000272 RID: 626
	// (get) Token: 0x06003299 RID: 12953 RVA: 0x00020F1E File Offset: 0x0001F11E
	public float Single_0
	{
		get
		{
			return this._textRendererCamera.orthographicSize * 2f;
		}
	}

	// Token: 0x0600329A RID: 12954 RVA: 0x000E7CE8 File Offset: 0x000E5EE8
	public void method_0()
	{
		global::UnityEngine.Object.Destroy(this._fontOutline);
		this._cameraTexture.DiscardContents();
		global::UnityEngine.Object.Destroy(this._cameraTexture);
		global::UnityEngine.Object.Destroy(this._textRendererCamera);
		global::UnityEngine.Object.Destroy(this._textureRoot);
		global::UnityEngine.Object.Destroy(this._cameraObject);
		this._arrRectList.Clear();
	}

	// Token: 0x0600329B RID: 12955 RVA: 0x000E7D44 File Offset: 0x000E5F44
	public bool method_1(float float_0, float float_1, out FontRect fontRect_0)
	{
		bool flag = false;
		if (this._arrRectList.Count == 0)
		{
			fontRect_0 = new FontRect(new Rect(0.001f, -0.001f, float_0, float_1));
			flag = true;
		}
		else
		{
			fontRect_0 = new FontRect(default(Rect));
			for (int i = 0; i < this._arrRectList.Count; i++)
			{
				FontRect fontRect = this._arrRectList[i];
				Rect rect = fontRect.rect;
				if (!fontRect.rightAlloc)
				{
					float num = Mathf.Ceil(100f * (rect.x + rect.width)) / 100f + 0.05f;
					float y = rect.y;
					Rect rect2 = new Rect(num, y, float_0, float_1);
					if (!this.method_4(rect2))
					{
						fontRect.rightAlloc = true;
						fontRect_0.leftRect = fontRect;
						fontRect_0.rect = rect2;
						flag = true;
						break;
					}
				}
				if (!fontRect.downAlloc)
				{
					float x = rect.x;
					float num2 = Mathf.Floor(100f * (rect.y - rect.height)) / 100f - 0.05f;
					Rect rect3 = new Rect(x, num2, float_0, float_1);
					if (!this.method_4(rect3))
					{
						fontRect.downAlloc = true;
						fontRect_0.upRect = fontRect;
						fontRect_0.rect = rect3;
						flag = true;
						break;
					}
				}
			}
		}
		if (flag)
		{
			this._arrRectList.Add(fontRect_0);
		}
		return flag;
	}

	// Token: 0x0600329C RID: 12956 RVA: 0x00020F31 File Offset: 0x0001F131
	public void method_2(FontRect fontRect_0)
	{
		if (fontRect_0.leftRect != null)
		{
			fontRect_0.leftRect.rightAlloc = false;
		}
		if (fontRect_0.upRect != null)
		{
			fontRect_0.upRect.downAlloc = false;
		}
		this._arrRectList.Remove(fontRect_0);
	}

	// Token: 0x0600329D RID: 12957 RVA: 0x00020F68 File Offset: 0x0001F168
	public void method_3()
	{
		this._arrRectList.Clear();
	}

	// Token: 0x0600329E RID: 12958 RVA: 0x000E7EAC File Offset: 0x000E60AC
	private bool method_4(Rect rect_0)
	{
		if (rect_0.x + rect_0.width + 0.05f > this.Single_0)
		{
			return true;
		}
		if (rect_0.y - rect_0.height - 0.05f < -this.Single_0)
		{
			return true;
		}
		for (int i = 0; i < this._arrRectList.Count; i++)
		{
			if (this.method_5(rect_0, this._arrRectList[i].rect))
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x0600329F RID: 12959 RVA: 0x000E7F2C File Offset: 0x000E612C
	private bool method_5(Rect rect_0, Rect rect_1)
	{
		float x = rect_0.x;
		float num = rect_0.x + rect_0.width + 0.05f;
		float y = rect_0.y;
		float num2 = rect_0.y - rect_0.height - 0.05f;
		float x2 = rect_1.x;
		float num3 = rect_1.x + rect_1.width + 0.05f;
		float y2 = rect_1.y;
		float num4 = rect_1.y - rect_1.height - 0.05f;
		return num2 < y2 && y > num4 && num > x2 && x < num3;
	}

	// Token: 0x04002310 RID: 8976
	public const int TextureSize = 1024;

	// Token: 0x04002311 RID: 8977
	private const float HORIZONTAL_SPACE = 0.05f;

	// Token: 0x04002312 RID: 8978
	private const float VERTICAL_SPACE = 0.05f;

	// Token: 0x04002313 RID: 8979
	private const float ACCURACY = 100f;

	// Token: 0x04002314 RID: 8980
	public Camera _textRendererCamera;

	// Token: 0x04002315 RID: 8981
	public RenderTexture _cameraTexture;

	// Token: 0x04002316 RID: 8982
	private GameObject _cameraObject;

	// Token: 0x04002317 RID: 8983
	private FontOutline _fontOutline;

	// Token: 0x04002318 RID: 8984
	public GameObject _textureRoot;

	// Token: 0x04002319 RID: 8985
	protected List<FontRect> _arrRectList = new List<FontRect>();
}
