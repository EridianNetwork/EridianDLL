using System;
using System.Collections.Generic;
using Core;
using ns0;
using pumpkin.display;
using pumpkin.swf;
using UnityEngine;

// Token: 0x02000776 RID: 1910
internal class GUIFontSwapManager : MonoSingleton<GUIFontSwapManager>
{
	// Token: 0x060032A0 RID: 12960 RVA: 0x000E7FD4 File Offset: 0x000E61D4
	public GUIFontSwapManager()
	{
		this._arrRenderList = new Dictionary<UnityTextField, GUIFontSwapManager.GUITextElement>();
		this._arrSmallList = new List<List<GUIFontSwapManager.GUITextElement>>();
		this._arrLargeList = new List<List<GUIFontSwapManager.GUITextElement>>();
		this._cachedCounter = new GUIFontSwapManager.Counter(3f);
		this.FLASH_FONT_NAME_MAP = new Dictionary<string, int>();
	}

	// Token: 0x17000273 RID: 627
	// (get) Token: 0x060032A1 RID: 12961 RVA: 0x00020F75 File Offset: 0x0001F175
	// (set) Token: 0x060032A2 RID: 12962 RVA: 0x00020F7D File Offset: 0x0001F17D
	public MovieClip MovieClip_0
	{
		get
		{
			return this.mcCursor;
		}
		set
		{
			this.mcCursor = value;
		}
	}

	// Token: 0x060032A3 RID: 12963 RVA: 0x000E8060 File Offset: 0x000E6260
	protected override void Awake()
	{
		base.Awake();
		if (this._fontOutline == null)
		{
			this._fontOutline = base.gameObject.AddComponent<uniSWFFontOutline>();
			this._fontOutline.edgeDetectShader = this.edgeDetectShader;
		}
		foreach (GUIFontSwapManager.FontNameID fontNameID in this.FLASH_FONT_NAME)
		{
			this.FLASH_FONT_NAME_MAP[fontNameID.fontName] = fontNameID.index;
		}
	}

	// Token: 0x060032A4 RID: 12964 RVA: 0x000E80F8 File Offset: 0x000E62F8
	protected void method_0(List<GUIFontSwapManager.GUITextElement> list_0)
	{
		for (int i = 0; i < list_0.Count; i++)
		{
			list_0[i]._textField.method_3();
		}
	}

	// Token: 0x060032A5 RID: 12965 RVA: 0x000E8128 File Offset: 0x000E6328
	protected void method_1()
	{
		this._dirty = false;
		for (int i = 0; i < this._arrSmallTex.Count; i++)
		{
			if (this._arrSmallTex[i].bRenderFlag)
			{
				this._arrSmallTex[i].method_2();
				this._arrSmallTex[i].bRenderFlag = false;
				this.method_0(this._arrSmallList[i]);
			}
		}
		for (int j = 0; j < this._arrLargeTex.Count; j++)
		{
			if (this._arrLargeTex[j].bRenderFlag)
			{
				this._arrLargeTex[j].method_2();
				this._arrLargeTex[j].bRenderFlag = false;
				this.method_0(this._arrLargeList[j]);
			}
		}
	}

	// Token: 0x060032A6 RID: 12966 RVA: 0x00020F86 File Offset: 0x0001F186
	private void Update()
	{
		this._cachedCounter.method_0(Time.deltaTime);
		if (this._cachedCounter.method_1() && this._dirty)
		{
			this.method_1();
		}
	}

	// Token: 0x060032A7 RID: 12967 RVA: 0x00020FB3 File Offset: 0x0001F1B3
	private void OnGUI()
	{
		GUI.depth = -100;
		if (Event.current.type.Equals(EventType.Repaint) && this._bNeedRender)
		{
			this.method_3();
			this._bNeedRender = false;
		}
	}

	// Token: 0x060032A8 RID: 12968 RVA: 0x000E81F8 File Offset: 0x000E63F8
	public void method_2()
	{
		this._bNeedRender = true;
		this._dirty = true;
		this._cachedCounter.Reset();
		for (int i = 0; i < this._arrSmallTex.Count; i++)
		{
			this._arrSmallTex[i].bRenderFlag = true;
		}
		for (int j = 0; j < this._arrLargeTex.Count; j++)
		{
			this._arrLargeTex[j].bRenderFlag = true;
		}
	}

	// Token: 0x060032A9 RID: 12969 RVA: 0x000E8270 File Offset: 0x000E6470
	private void method_3()
	{
		Matrix4x4 matrix = GUI.matrix;
		GUI.matrix = Matrix4x4.Scale(new Vector3((float)Screen.width / 1024f, (float)Screen.height / 1024f, 1f));
		for (int i = 0; i < this._arrSmallTex.Count; i++)
		{
			if (this._arrSmallTex[i].bRenderFlag)
			{
				this.method_4(this._arrSmallTex[i], this._arrSmallList[i]);
				this.method_0(this._arrSmallList[i]);
			}
		}
		for (int j = 0; j < this._arrLargeTex.Count; j++)
		{
			if (this._arrLargeTex[j].bRenderFlag)
			{
				this.method_4(this._arrLargeTex[j], this._arrLargeList[j]);
				this.method_0(this._arrLargeList[j]);
			}
		}
		GUI.matrix = matrix;
	}

	// Token: 0x060032AA RID: 12970 RVA: 0x000E8368 File Offset: 0x000E6568
	protected void method_4(GUIFontSwapManager.RenderElement renderElement_0, List<GUIFontSwapManager.GUITextElement> list_0)
	{
		if (renderElement_0 != null && list_0 != null)
		{
			RenderTexture renderTexture = renderElement_0.renderTexture;
			RenderTexture.active = renderTexture;
			GL.Clear(true, true, new Color(0f, 0f, 0f, 0f));
			foreach (GUIFontSwapManager.GUITextElement guitextElement in list_0)
			{
				GUIStyle guistyle = this.method_6(guitextElement.fontName);
				this.method_5(guitextElement, ref guistyle);
				GUI.Label(guitextElement.rect, guitextElement._textField.text, guistyle);
			}
			this._fontOutline.method_1(renderTexture, renderTexture);
			return;
		}
	}

	// Token: 0x060032AB RID: 12971 RVA: 0x000E8424 File Offset: 0x000E6624
	private void method_5(GUIFontSwapManager.GUITextElement guitextElement_0, ref GUIStyle guistyle_0)
	{
		guistyle_0.richText = true;
		guistyle_0.fontStyle = guitextElement_0.fontStyle;
		guistyle_0.alignment = guitextElement_0.alignment;
		guistyle_0.normal.textColor = guitextElement_0._textField.Color_0;
		guistyle_0.fontSize = Mathf.RoundToInt(guitextElement_0._textField.textFormat.size);
		guistyle_0.wordWrap = guitextElement_0._textField.multiline;
		guistyle_0.clipping = TextClipping.Clip;
	}

	// Token: 0x060032AC RID: 12972 RVA: 0x00020FED File Offset: 0x0001F1ED
	public GUIStyle method_6(string string_0)
	{
		if (this.FLASH_FONT_NAME_MAP.ContainsKey(string_0))
		{
			return this._fontList[this.FLASH_FONT_NAME_MAP[string_0]];
		}
		return new GUIStyle(GUI.skin.textField);
	}

	// Token: 0x060032AD RID: 12973 RVA: 0x00021024 File Offset: 0x0001F224
	public Font method_7(string string_0)
	{
		return this.method_6(string_0).font;
	}

	// Token: 0x060032AE RID: 12974 RVA: 0x000E84A0 File Offset: 0x000E66A0
	public void method_8(GUIFontSwapManager.GUITextElement guitextElement_0)
	{
		List<GUIFontSwapManager.RenderElement> list;
		if (guitextElement_0.bLarge)
		{
			list = this._arrLargeTex;
		}
		else
		{
			list = this._arrSmallTex;
		}
		if (guitextElement_0.iTextureID < list.Count)
		{
			list[guitextElement_0.iTextureID].bRenderFlag = true;
		}
		this._bNeedRender = true;
		this._dirty = true;
		this._cachedCounter.Reset();
	}

	// Token: 0x060032AF RID: 12975 RVA: 0x000E8500 File Offset: 0x000E6700
	public void method_9(UnityTextField unityTextField_0)
	{
		if (this._arrRenderList.ContainsKey(unityTextField_0))
		{
			return;
		}
		GUIFontSwapManager.GUITextElement guitextElement = new GUIFontSwapManager.GUITextElement(unityTextField_0);
		this._arrRenderList.Add(unityTextField_0, guitextElement);
	}

	// Token: 0x060032B0 RID: 12976 RVA: 0x000E8530 File Offset: 0x000E6730
	protected int method_10(GUIFontSwapManager.GUITextElement guitextElement_0, ref GUIFontSwapManager.IntVec4 intVec4_0, List<List<GUIFontSwapManager.GUITextElement>> list_0, List<GUIFontSwapManager.RenderElement> list_1)
	{
		this.method_11(guitextElement_0, ref intVec4_0);
		if (intVec4_0.z == list_0.Count)
		{
			list_1.Add(new GUIFontSwapManager.RenderElement(new RenderTexture(1024, 1024, 0, RenderTextureFormat.Default, RenderTextureReadWrite.Linear), true));
			list_0.Add(new List<GUIFontSwapManager.GUITextElement>());
		}
		int num = list_0.Count - 1;
		list_0[num].Add(guitextElement_0);
		return num;
	}

	// Token: 0x060032B1 RID: 12977 RVA: 0x000E8594 File Offset: 0x000E6794
	protected void method_11(GUIFontSwapManager.GUITextElement guitextElement_0, ref GUIFontSwapManager.IntVec4 intVec4_0)
	{
		intVec4_0.x = intVec4_0.x - Mathf.CeilToInt(guitextElement_0.rect.width) - 2;
		if (intVec4_0.x < 0)
		{
			intVec4_0.x = 1024 - Mathf.CeilToInt(guitextElement_0.rect.width);
			intVec4_0.y = intVec4_0.y + intVec4_0.a + 4;
			if ((float)intVec4_0.y + guitextElement_0.rect.height + 4f >= 1024f)
			{
				intVec4_0.y = 0;
				intVec4_0.z++;
			}
		}
		intVec4_0.a = Mathf.Max(intVec4_0.a, Mathf.CeilToInt(guitextElement_0.rect.height));
		guitextElement_0.rect.x = (float)intVec4_0.x;
		guitextElement_0.rect.y = (float)intVec4_0.y;
		guitextElement_0.iTextureID = intVec4_0.z;
	}

	// Token: 0x060032B2 RID: 12978 RVA: 0x000E8680 File Offset: 0x000E6880
	public void method_12(UnityTextField unityTextField_0, out Rect rect_0, out Vector3 vector3_0, out Material material_0)
	{
		Vector2 vector;
		this.method_13(unityTextField_0, out rect_0, out vector3_0, out material_0, 0, out vector);
	}

	// Token: 0x060032B3 RID: 12979 RVA: 0x000E869C File Offset: 0x000E689C
	public void method_13(UnityTextField unityTextField_0, out Rect rect_0, out Vector3 vector3_0, out Material material_0, int int_0, out Vector2 vector2_0)
	{
		if (this._arrRenderList.ContainsKey(unityTextField_0))
		{
			GUIFontSwapManager.GUITextElement guitextElement = this._arrRenderList[unityTextField_0];
			Vector2 vector = guitextElement.method_2();
			rect_0 = new Rect(guitextElement.rect.x / 1024f, guitextElement.rect.y / 1024f, guitextElement.rect.width / 1024f, guitextElement.rect.height / 1024f);
			vector3_0 = new Vector3(vector.x, vector.y, 0f);
			if (guitextElement.bLarge)
			{
				if (this._dirty)
				{
					this._arrLargeTex[guitextElement.iTextureID].method_1();
				}
				else
				{
					this._arrLargeTex[guitextElement.iTextureID].method_0();
				}
				material_0 = this._arrLargeTex[guitextElement.iTextureID].material;
			}
			else
			{
				if (this._dirty)
				{
					this._arrSmallTex[guitextElement.iTextureID].method_1();
				}
				else
				{
					this._arrSmallTex[guitextElement.iTextureID].method_0();
				}
				material_0 = this._arrSmallTex[guitextElement.iTextureID].material;
			}
			GUIStyle guistyle = this.method_6(guitextElement.fontName);
			this.method_5(guitextElement, ref guistyle);
			vector2_0 = guistyle.GetCursorPixelPosition(guitextElement.rect, new GUIContent(unityTextField_0.text), int_0);
			vector2_0.x -= guitextElement.rect.x;
			vector2_0.y -= guitextElement.rect.y;
		}
		else
		{
			rect_0 = default(Rect);
			vector3_0 = default(Vector3);
			material_0 = null;
			vector2_0 = default(Vector2);
		}
	}

	// Token: 0x060032B4 RID: 12980 RVA: 0x000E8860 File Offset: 0x000E6A60
	public void method_14(UnityTextField unityTextField_0)
	{
		GUIFontSwapManager.GUITextElement guitextElement;
		if (this._arrRenderList.TryGetValue(unityTextField_0, out guitextElement))
		{
			guitextElement.method_0();
			if (guitextElement.rect.width >= 1024f || guitextElement.rect.height >= 1024f)
			{
				DebugUtils.LogWarning(LogCategory.GUI, "Textfield too big!!" + unityTextField_0.name);
				return;
			}
			if (guitextElement.rect.height < 40f)
			{
				this.method_10(guitextElement, ref this._SmallVec, this._arrSmallList, this._arrSmallTex);
				guitextElement.bLarge = false;
			}
			else
			{
				this.method_10(guitextElement, ref this._LargeVec, this._arrLargeList, this._arrLargeTex);
				guitextElement.bLarge = true;
			}
			this.method_8(guitextElement);
		}
	}

	// Token: 0x060032B5 RID: 12981 RVA: 0x000E8920 File Offset: 0x000E6B20
	public void method_15(UnityTextField unityTextField_0)
	{
		GUIFontSwapManager.GUITextElement guitextElement;
		if (this._arrRenderList.TryGetValue(unityTextField_0, out guitextElement))
		{
			guitextElement.method_0();
			this.method_8(guitextElement);
		}
	}

	// Token: 0x060032B6 RID: 12982 RVA: 0x00021032 File Offset: 0x0001F232
	private void Start()
	{
		this.mcCursor = new MovieClip("CommonLib.swf:TextFieldCursor");
	}

	// Token: 0x060032B7 RID: 12983 RVA: 0x000E894C File Offset: 0x000E6B4C
	public void method_16()
	{
		foreach (KeyValuePair<UnityTextField, GUIFontSwapManager.GUITextElement> keyValuePair in this._arrRenderList)
		{
			keyValuePair.Value.method_1();
		}
		this._arrRenderList.Clear();
		foreach (GUIFontSwapManager.RenderElement renderElement in this._arrSmallTex)
		{
			if (RenderTexture.active == renderElement.renderTexture)
			{
				RenderTexture.active = null;
			}
			renderElement.method_3();
		}
		this._arrSmallTex.Clear();
		foreach (GUIFontSwapManager.RenderElement renderElement2 in this._arrLargeTex)
		{
			if (RenderTexture.active == renderElement2.renderTexture)
			{
				RenderTexture.active = null;
			}
			renderElement2.method_3();
		}
		this._arrLargeTex.Clear();
		foreach (List<GUIFontSwapManager.GUITextElement> list in this._arrSmallList)
		{
			list.Clear();
		}
		this._arrSmallList.Clear();
		foreach (List<GUIFontSwapManager.GUITextElement> list2 in this._arrLargeList)
		{
			list2.Clear();
		}
		this._arrLargeList.Clear();
		this._SmallVec.method_0(1024, 0, 0, 0);
		this._LargeVec.method_0(1024, 0, 0, 0);
	}

	// Token: 0x0400231A RID: 8986
	private const int TEXTURE_SIZE = 1024;

	// Token: 0x0400231B RID: 8987
	private const int HORIZONTAL_SPACE = 2;

	// Token: 0x0400231C RID: 8988
	private const int VERTICAL_SPACE = 4;

	// Token: 0x0400231D RID: 8989
	private const int LARGE_SIZE_DEFINE = 40;

	// Token: 0x0400231E RID: 8990
	public Shader edgeDetectShader;

	// Token: 0x0400231F RID: 8991
	public uniSWFFontOutline _fontOutline;

	// Token: 0x04002320 RID: 8992
	protected bool _bNeedRender;

	// Token: 0x04002321 RID: 8993
	protected List<List<GUIFontSwapManager.GUITextElement>> _arrSmallList;

	// Token: 0x04002322 RID: 8994
	protected List<List<GUIFontSwapManager.GUITextElement>> _arrLargeList;

	// Token: 0x04002323 RID: 8995
	protected GUIFontSwapManager.IntVec4 _SmallVec = new GUIFontSwapManager.IntVec4(1024, 0, 0, 0);

	// Token: 0x04002324 RID: 8996
	protected GUIFontSwapManager.IntVec4 _LargeVec = new GUIFontSwapManager.IntVec4(1024, 0, 0, 0);

	// Token: 0x04002325 RID: 8997
	protected List<GUIFontSwapManager.RenderElement> _arrSmallTex = new List<GUIFontSwapManager.RenderElement>();

	// Token: 0x04002326 RID: 8998
	protected List<GUIFontSwapManager.RenderElement> _arrLargeTex = new List<GUIFontSwapManager.RenderElement>();

	// Token: 0x04002327 RID: 8999
	protected Dictionary<UnityTextField, GUIFontSwapManager.GUITextElement> _arrRenderList;

	// Token: 0x04002328 RID: 9000
	public List<GUIStyle> _fontList;

	// Token: 0x04002329 RID: 9001
	public List<GUIFontSwapManager.FontNameID> FLASH_FONT_NAME;

	// Token: 0x0400232A RID: 9002
	protected Dictionary<string, int> FLASH_FONT_NAME_MAP;

	// Token: 0x0400232B RID: 9003
	protected MovieClip mcCursor;

	// Token: 0x0400232C RID: 9004
	protected bool _dirty;

	// Token: 0x0400232D RID: 9005
	protected GUIFontSwapManager.Counter _cachedCounter;

	// Token: 0x02000777 RID: 1911
	public class GUITextElement
	{
		// Token: 0x060032B8 RID: 12984 RVA: 0x000E8B40 File Offset: 0x000E6D40
		public GUITextElement(UnityTextField unityTextField_0)
		{
			this._textField = unityTextField_0;
			this.rect = new Rect(0f, 0f, this._textField.method_0(), this._textField.method_1());
			this.fontStyle = FontStyle.Normal;
			if (this._textField.BitmapFontAssetInfo_0.italic > 0)
			{
				this.fontStyle |= FontStyle.Italic;
			}
			if (this._textField.BitmapFontAssetInfo_0.bold > 0)
			{
				this.fontStyle |= FontStyle.Bold;
			}
			if (this._textField.textFormat.align == 0)
			{
				this.alignment = TextAnchor.UpperLeft;
			}
			else
			{
				if (this._textField.textFormat.align != 1)
				{
					if (this._textField.textFormat.align != 4)
					{
						if (this._textField.textFormat.align == 2)
						{
							this.alignment = TextAnchor.UpperRight;
							goto IL_00E7;
						}
						goto IL_00E7;
					}
				}
				this.alignment = TextAnchor.UpperCenter;
			}
			IL_00E7:
			this.method_0();
		}

		// Token: 0x060032B9 RID: 12985 RVA: 0x000E8C3C File Offset: 0x000E6E3C
		public void method_0()
		{
			this.rect.width = (float)Mathf.CeilToInt(this._textField.method_0());
			this.rect.height = (float)Mathf.CeilToInt(this._textField.method_1());
			this.fontName = this._textField.textFormat.font;
		}

		// Token: 0x060032BA RID: 12986 RVA: 0x0000311B File Offset: 0x0000131B
		public void method_1()
		{
		}

		// Token: 0x060032BB RID: 12987 RVA: 0x00021044 File Offset: 0x0001F244
		public Vector2 method_2()
		{
			return new Vector2(this.rect.width, this.rect.height);
		}

		// Token: 0x0400232E RID: 9006
		public UnityTextField _textField;

		// Token: 0x0400232F RID: 9007
		public Rect rect;

		// Token: 0x04002330 RID: 9008
		public int iTextureID;

		// Token: 0x04002331 RID: 9009
		public bool bLarge;

		// Token: 0x04002332 RID: 9010
		public FontStyle fontStyle;

		// Token: 0x04002333 RID: 9011
		public TextAnchor alignment;

		// Token: 0x04002334 RID: 9012
		public string fontName;
	}

	// Token: 0x02000778 RID: 1912
	protected struct IntVec4
	{
		// Token: 0x060032BC RID: 12988 RVA: 0x00021061 File Offset: 0x0001F261
		public IntVec4(int int_0, int int_1, int int_2, int int_3)
		{
			this.x = int_0;
			this.y = int_1;
			this.z = int_2;
			this.a = int_3;
		}

		// Token: 0x060032BD RID: 12989 RVA: 0x00021061 File Offset: 0x0001F261
		public void method_0(int int_0, int int_1, int int_2, int int_3)
		{
			this.x = int_0;
			this.y = int_1;
			this.z = int_2;
			this.a = int_3;
		}

		// Token: 0x04002335 RID: 9013
		public int x;

		// Token: 0x04002336 RID: 9014
		public int y;

		// Token: 0x04002337 RID: 9015
		public int z;

		// Token: 0x04002338 RID: 9016
		public int a;
	}

	// Token: 0x02000779 RID: 1913
	[Serializable]
	public class FontNameID
	{
		// Token: 0x04002339 RID: 9017
		public string fontName = string.Empty;

		// Token: 0x0400233A RID: 9018
		public int index;
	}

	// Token: 0x0200077A RID: 1914
	protected class RenderElement
	{
		// Token: 0x060032BF RID: 12991 RVA: 0x000E8C98 File Offset: 0x000E6E98
		public RenderElement(RenderTexture renderTexture_0, bool bool_0)
		{
			this.renderTexture = renderTexture_0;
			this.cachedTexture = new Texture2D(this.renderTexture.width, this.renderTexture.height, TextureFormat.ARGB32, false, true);
			this.material = new Material(TextureManager.baseBitmapShader);
			this.material.mainTexture = this.renderTexture;
			this.bRenderFlag = bool_0;
		}

		// Token: 0x060032C0 RID: 12992 RVA: 0x00021093 File Offset: 0x0001F293
		public void method_0()
		{
			this.material.mainTexture = this.cachedTexture;
		}

		// Token: 0x060032C1 RID: 12993 RVA: 0x000210A6 File Offset: 0x0001F2A6
		public void method_1()
		{
			this.material.mainTexture = this.renderTexture;
		}

		// Token: 0x060032C2 RID: 12994 RVA: 0x000E8D00 File Offset: 0x000E6F00
		public void method_2()
		{
			RenderTexture.active = this.renderTexture;
			this.cachedTexture.ReadPixels(new Rect(0f, 0f, (float)this.renderTexture.width, (float)this.renderTexture.height), 0, 0);
			this.cachedTexture.Apply();
		}

		// Token: 0x060032C3 RID: 12995 RVA: 0x000210B9 File Offset: 0x0001F2B9
		public void method_3()
		{
			this.renderTexture.Release();
			global::UnityEngine.Object.Destroy(this.renderTexture);
			global::UnityEngine.Object.Destroy(this.cachedTexture);
			global::UnityEngine.Object.Destroy(this.material);
		}

		// Token: 0x0400233B RID: 9019
		public RenderTexture renderTexture;

		// Token: 0x0400233C RID: 9020
		public Texture2D cachedTexture;

		// Token: 0x0400233D RID: 9021
		public bool bRenderFlag;

		// Token: 0x0400233E RID: 9022
		public Material material;
	}

	// Token: 0x0200077B RID: 1915
	protected class Counter
	{
		// Token: 0x060032C4 RID: 12996 RVA: 0x000210E7 File Offset: 0x0001F2E7
		public Counter(float float_0)
		{
			this.current = 0f;
			this.target = float_0;
		}

		// Token: 0x060032C5 RID: 12997 RVA: 0x00021101 File Offset: 0x0001F301
		public void method_0(float float_0)
		{
			this.current += float_0;
		}

		// Token: 0x060032C6 RID: 12998 RVA: 0x00021111 File Offset: 0x0001F311
		public bool method_1()
		{
			return this.current >= this.target;
		}

		// Token: 0x060032C7 RID: 12999 RVA: 0x00021124 File Offset: 0x0001F324
		public void Reset()
		{
			this.current = 0f;
		}

		// Token: 0x0400233F RID: 9023
		private float target;

		// Token: 0x04002340 RID: 9024
		private float current;
	}
}
