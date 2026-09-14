using System;
using System.Collections.Generic;
using Core;
using ns0;
using UnityEngine;

// Token: 0x02000772 RID: 1906
internal class FontSwapManager : MonoSingleton<FontSwapManager>
{
	// Token: 0x06003280 RID: 12928 RVA: 0x000E700C File Offset: 0x000E520C
	public FontSwapManager()
	{
		this._arrTextureList = new List<FontSwapTexture>();
		this._arrRenderList = new Dictionary<UnityTextField, FontSwapManager.TextRenderElement>();
		this._mapFontName2ObjectName = new Dictionary<string, string>
		{
			{ "\u03a2\ufffd\ufffd\ufffdź\ufffd", "MSYH" },
			{ "MSYH", "MSYH" },
			{ "Compacta Bd BT", "COMPACTA Bold BT" }
		};
	}

	// Token: 0x06003281 RID: 12929 RVA: 0x00020E84 File Offset: 0x0001F084
	private void Update()
	{
		if (this._fUpdateTimer < 100f)
		{
			this._fUpdateTimer += Time.deltaTime;
		}
		else
		{
			this._fUpdateTimer = 0f;
			this.method_0();
		}
	}

	// Token: 0x06003282 RID: 12930 RVA: 0x000E708C File Offset: 0x000E528C
	public void method_0()
	{
		foreach (KeyValuePair<UnityTextField, FontSwapManager.TextRenderElement> keyValuePair in this._arrRenderList)
		{
			keyValuePair.Value._textMesh.renderer.enabled = true;
		}
		for (int i = 0; i < this._arrTextureList.Count; i++)
		{
			this._arrTextureList[i]._textRendererCamera.enabled = true;
			this._arrTextureList[i]._textRendererCamera.RenderWithShader(Shader.Find("Custom/UIFontColorBlend"), string.Empty);
		}
		foreach (KeyValuePair<UnityTextField, FontSwapManager.TextRenderElement> keyValuePair2 in this._arrRenderList)
		{
			keyValuePair2.Value._textField.method_3();
		}
	}

	// Token: 0x06003283 RID: 12931 RVA: 0x00020EB8 File Offset: 0x0001F0B8
	public void method_1(FontSwapManager.TextRenderElement textRenderElement_0)
	{
		this.method_2(textRenderElement_0._textTexture, textRenderElement_0);
	}

	// Token: 0x06003284 RID: 12932 RVA: 0x000E7190 File Offset: 0x000E5390
	private void method_2(FontSwapTexture fontSwapTexture_0, FontSwapManager.TextRenderElement textRenderElement_0)
	{
		foreach (KeyValuePair<UnityTextField, FontSwapManager.TextRenderElement> keyValuePair in this._arrRenderList)
		{
			if (keyValuePair.Value._textTexture == fontSwapTexture_0)
			{
				keyValuePair.Value._textMesh.renderer.enabled = true;
			}
		}
		fontSwapTexture_0._textRendererCamera.enabled = true;
		fontSwapTexture_0._textRendererCamera.RenderWithShader(Shader.Find("Custom/UIFontColorBlend"), string.Empty);
		textRenderElement_0._textField.method_3();
	}

	// Token: 0x06003285 RID: 12933 RVA: 0x000E7234 File Offset: 0x000E5434
	public Font method_3(string string_0)
	{
		Transform transform = this.method_4(string_0);
		TextMesh component = transform.gameObject.GetComponent<TextMesh>();
		if (component != null)
		{
			return component.font;
		}
		return null;
	}

	// Token: 0x06003286 RID: 12934 RVA: 0x000E7268 File Offset: 0x000E5468
	public Transform method_4(string string_0)
	{
		Transform transform = null;
		if (!string.IsNullOrEmpty(string_0) && this._mapFontName2ObjectName.ContainsKey(string_0))
		{
			transform = base.transform.FindChild(this._mapFontName2ObjectName[string_0]);
		}
		if (transform == null)
		{
			transform = base.transform.FindChild("MSYH");
		}
		return transform;
	}

	// Token: 0x06003287 RID: 12935 RVA: 0x000E72C0 File Offset: 0x000E54C0
	public void method_5(UnityTextField unityTextField_0)
	{
		if (this._arrRenderList.ContainsKey(unityTextField_0))
		{
			return;
		}
		FontSwapManager.TextRenderElement textRenderElement = new FontSwapManager.TextRenderElement(unityTextField_0);
		int count = this._arrRenderList.Count;
		textRenderElement._textMesh.gameObject.name = "TextMesh" + count;
		textRenderElement._textMesh.transform.parent = base.gameObject.transform;
		this.method_13(textRenderElement, 1f);
		this._arrRenderList.Add(unityTextField_0, textRenderElement);
	}

	// Token: 0x06003288 RID: 12936 RVA: 0x000E7344 File Offset: 0x000E5544
	public void method_6(UnityTextField unityTextField_0, out Rect rect_0, out Vector3 vector3_0, out Material material_0)
	{
		if (this._arrRenderList.ContainsKey(unityTextField_0))
		{
			FontSwapManager.TextRenderElement textRenderElement = this._arrRenderList[unityTextField_0];
			TextMesh textMesh = textRenderElement._textMesh;
			Vector2 vector = textRenderElement.method_2() * 10f;
			rect_0 = new Rect(textMesh.transform.localPosition.x * 10f / 1024f, -textMesh.transform.localPosition.y * 10f / 1024f, (vector.x + 1f) / 1024f, (vector.y + 1f) / 1024f);
			vector3_0 = new Vector3(vector.x, vector.y, 0f);
			if (textRenderElement._material == null)
			{
				textRenderElement._material = new Material(Shader.Find("Transparent/DiffuseDoubeSided"));
				textRenderElement._material.name = "FontSwapManager_GetRenderInfo";
			}
			textRenderElement._material.mainTexture = textRenderElement._textTexture._cameraTexture;
			material_0 = textRenderElement._material;
		}
		else
		{
			rect_0 = default(Rect);
			vector3_0 = default(Vector3);
			material_0 = null;
		}
	}

	// Token: 0x06003289 RID: 12937 RVA: 0x000E7474 File Offset: 0x000E5674
	public void method_7(UnityTextField unityTextField_0)
	{
		FontSwapManager.TextRenderElement textRenderElement;
		if (this._arrRenderList.TryGetValue(unityTextField_0, out textRenderElement))
		{
			textRenderElement.method_0();
			this.method_11(textRenderElement);
			this.method_1(textRenderElement);
		}
	}

	// Token: 0x0600328A RID: 12938 RVA: 0x0000311B File Offset: 0x0000131B
	private void Start()
	{
	}

	// Token: 0x0600328B RID: 12939 RVA: 0x000E74A8 File Offset: 0x000E56A8
	protected override void Awake()
	{
		base.Awake();
		if (this.FLASH_FONT_NAMES.Length > 0 && this.UNITY_FONT_NAMES.Length == this.FLASH_FONT_NAMES.Length)
		{
			this._mapFontName2ObjectName.Clear();
			for (int i = 0; i < this.FLASH_FONT_NAMES.Length; i++)
			{
				this._mapFontName2ObjectName.Add(this.FLASH_FONT_NAMES[i], this.UNITY_FONT_NAMES[i]);
			}
		}
		this.method_8();
	}

	// Token: 0x0600328C RID: 12940 RVA: 0x00020EC7 File Offset: 0x0001F0C7
	protected void method_8()
	{
		this._arrTextureList.Add(new FontSwapTexture(0, base.gameObject));
	}

	// Token: 0x0600328D RID: 12941 RVA: 0x000E7518 File Offset: 0x000E5718
	protected void method_9()
	{
		for (int i = 0; i < this._arrTextureList.Count; i++)
		{
			this._arrTextureList[i].method_3();
		}
	}

	// Token: 0x0600328E RID: 12942 RVA: 0x000E754C File Offset: 0x000E574C
	protected void method_10()
	{
		this.method_9();
		foreach (KeyValuePair<UnityTextField, FontSwapManager.TextRenderElement> keyValuePair in this._arrRenderList)
		{
			this.method_13(keyValuePair.Value, 1f);
		}
	}

	// Token: 0x0600328F RID: 12943 RVA: 0x000E75B0 File Offset: 0x000E57B0
	protected void method_11(FontSwapManager.TextRenderElement textRenderElement_0)
	{
		Vector2 vector = textRenderElement_0.method_2();
		FontRect fontRect = textRenderElement_0._fontRect;
		Rect rect = fontRect.rect;
		if (rect.width < vector.x || rect.height < vector.y)
		{
			this.method_13(textRenderElement_0, 1.5f);
		}
	}

	// Token: 0x06003290 RID: 12944 RVA: 0x000E7600 File Offset: 0x000E5800
	public void method_12()
	{
		foreach (KeyValuePair<UnityTextField, FontSwapManager.TextRenderElement> keyValuePair in this._arrRenderList)
		{
			keyValuePair.Value.method_1();
		}
		this._arrRenderList.Clear();
		for (int i = 0; i < this._arrTextureList.Count; i++)
		{
			this._arrTextureList[i].method_0();
		}
		this._arrTextureList.Clear();
	}

	// Token: 0x06003291 RID: 12945 RVA: 0x000E7694 File Offset: 0x000E5894
	protected void method_13(TextRenderElement textRenderElement_0, float float_0 = 1f)
	{
		if (textRenderElement_0._textTexture != null && textRenderElement_0._fontRect != null)
		{
			textRenderElement_0._textTexture.method_2(textRenderElement_0._fontRect);
		}
		textRenderElement_0._textTexture = null;
		textRenderElement_0._fontRect = null;
		Vector2 vector = textRenderElement_0.method_2() * float_0;
		FontRect fontRect_ = null;
		vector.x = Mathf.Ceil(100f * vector.x) / 100f;
		vector.y = Mathf.Ceil(100f * vector.y) / 100f;
		if (!(vector.x > 1024f) && vector.y <= 1024f)
		{
			for (int i = 0; i < _arrTextureList.Count; i++)
			{
				if (_arrTextureList[i].method_1(vector.x, vector.y, out fontRect_))
				{
					textRenderElement_0._textTexture = _arrTextureList[i];
					break;
				}
			}
			if (textRenderElement_0._textTexture == null)
			{
				textRenderElement_0._textTexture = new FontSwapTexture(_arrTextureList.Count, base.gameObject);
				textRenderElement_0._textTexture.method_1(vector.x, vector.y, out fontRect_);
				_arrTextureList.Add(textRenderElement_0._textTexture);
			}
			textRenderElement_0._fontRect = fontRect_;
			Rect rect = fontRect_.rect;
			textRenderElement_0._textMesh.transform.parent = textRenderElement_0._textTexture._textureRoot.transform;
			textRenderElement_0._textMesh.transform.localPosition = new Vector3(rect.x, rect.y, 0f);
		}
		else
		{
			DebugUtils.LogError(LogCategory.GUI, "FontSwapManager: Too big");
		}
	}
	// Token: 0x040022FE RID: 8958
	private const string DefaultFontName = "MSYH";

	// Token: 0x040022FF RID: 8959
	public Shader mFontOutlineShader;

	// Token: 0x04002300 RID: 8960
	protected List<FontSwapTexture> _arrTextureList;

	// Token: 0x04002301 RID: 8961
	protected Dictionary<UnityTextField, FontSwapManager.TextRenderElement> _arrRenderList;

	// Token: 0x04002302 RID: 8962
	protected Dictionary<string, string> _mapFontName2ObjectName;

	// Token: 0x04002303 RID: 8963
	public string[] FLASH_FONT_NAMES = new string[0];

	// Token: 0x04002304 RID: 8964
	public string[] UNITY_FONT_NAMES = new string[0];

	// Token: 0x04002305 RID: 8965
	private float _fUpdateTimer;

	// Token: 0x02000773 RID: 1907
	public class TextRenderElement
	{
		// Token: 0x06003292 RID: 12946 RVA: 0x000E7840 File Offset: 0x000E5A40
		public TextRenderElement(UnityTextField unityTextField_0)
		{
			this._textField = unityTextField_0;
			Transform transform = MonoSingleton<FontSwapManager>.Instance.method_4(this._textField.textFormat.font);
			GameObject gameObject = global::UnityEngine.Object.Instantiate(transform.gameObject) as GameObject;
			gameObject.layer = LayerMask.NameToLayer("UI");
			this._textMesh = gameObject.GetComponent<TextMesh>();
			this._textMesh.fontStyle = FontStyle.Normal;
			this._textMesh.fontSize = Mathf.RoundToInt(this._textField.textFormat.size);
			if (this._textField.textFormat.italic)
			{
				this._textMesh.fontStyle |= FontStyle.Italic;
			}
			if (this._textField.textFormat.bold)
			{
				this._textMesh.fontStyle |= FontStyle.Bold;
			}
			if (this._textField.textFormat.align == 0)
			{
				this._textMesh.alignment = TextAlignment.Left;
			}
			else
			{
				if (this._textField.textFormat.align != 1)
				{
					if (this._textField.textFormat.align != 4)
					{
						if (this._textField.textFormat.align == 2)
						{
							this._textMesh.alignment = TextAlignment.Right;
							goto IL_0140;
						}
						goto IL_0140;
					}
				}
				this._textMesh.alignment = TextAlignment.Center;
			}
			IL_0140:
			this.method_0();
		}

		// Token: 0x06003293 RID: 12947 RVA: 0x000E7994 File Offset: 0x000E5B94
		public void method_0()
		{
			string text = string.Empty;
			if (this._textField.multiline)
			{
				text = FontSwapManager.TextRenderElement.smethod_0(this._textField.text, this._textMesh, this._textField.method_0() / 10f);
			}
			else
			{
				text = this._textField.text.TrimEnd(new char[0]);
			}
			this._textMesh.color = this._textField.Color_0;
			this._textMesh.text = text;
		}

		// Token: 0x06003294 RID: 12948 RVA: 0x00020EE0 File Offset: 0x0001F0E0
		public void method_1()
		{
			if (this._textMesh.gameObject != null)
			{
				global::UnityEngine.Object.Destroy(this._textMesh.gameObject);
			}
			if (this._material != null)
			{
				global::UnityEngine.Object.Destroy(this._material);
			}
		}

		// Token: 0x06003295 RID: 12949 RVA: 0x000E7A18 File Offset: 0x000E5C18
		public Vector2 method_2()
		{
			return new Vector2(this._textMesh.renderer.bounds.size.x, this._textMesh.renderer.bounds.size.y);
		}

		// Token: 0x06003296 RID: 12950 RVA: 0x000E7A6C File Offset: 0x000E5C6C
		public static string smethod_0(string string_0, TextMesh textMesh_0, float float_0)
		{
			string text = string.Empty;
			string text2 = string.Empty;
			for (int i = 0; i < string_0.Length; i++)
			{
				text2 += string_0.Substring(i, 1);
				textMesh_0.text = text2;
				float x = textMesh_0.renderer.bounds.size.x;
				if (x > float_0)
				{
					text2 = string_0.Substring(i, 1);
					text = text + "\n" + string_0.Substring(i, 1);
				}
				else
				{
					text += string_0.Substring(i, 1);
				}
			}
			return text;
		}

		// Token: 0x04002306 RID: 8966
		public UnityTextField _textField;

		// Token: 0x04002307 RID: 8967
		public TextMesh _textMesh;

		// Token: 0x04002308 RID: 8968
		public FontSwapTexture _textTexture;

		// Token: 0x04002309 RID: 8969
		public FontRect _fontRect;

		// Token: 0x0400230A RID: 8970
		public Material _material;
	}
}
