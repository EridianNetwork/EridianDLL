using System;
using System.Collections.Generic;
using ns0;
using pumpkin.display;
using pumpkin.displayInternal;
using pumpkin.geom;
using UnityEngine;

// Token: 0x0200077C RID: 1916
internal class UFont2uniSWFGenerator : MonoSingleton<UFont2uniSWFGenerator>
{
	// Token: 0x060032C8 RID: 13000 RVA: 0x000E8D58 File Offset: 0x000E6F58
	public UFont2uniSWFGenerator()
	{
		this._mapFontFlashName2UnityName = new Dictionary<string, string>
		{
			{ "\u03a2\ufffd\ufffd\ufffdź\ufffd", "MSYH" },
			{ "MSYH", "MSYH" },
			{ "Compacta Bd BT", "COMPACTA Bold BT" }
		};
		for (int i = 0; i < this.constShadowColorList.Length; i++)
		{
			this.constShadowColorList[i] = Color.black;
		}
	}

	// Token: 0x17000274 RID: 628
	// (get) Token: 0x060032C9 RID: 13001 RVA: 0x00021131 File Offset: 0x0001F331
	// (set) Token: 0x060032CA RID: 13002 RVA: 0x00021139 File Offset: 0x0001F339
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

	// Token: 0x060032CB RID: 13003 RVA: 0x000E8E44 File Offset: 0x000E7044
	public void method_0()
	{
		foreach (KeyValuePair<Font, UFont2uniSWFGenerator.FontRelatedThing> keyValuePair in this._mapFontRelatedList)
		{
			keyValuePair.Value.method_2();
		}
	}

	// Token: 0x060032CC RID: 13004 RVA: 0x000E8E9C File Offset: 0x000E709C
	public void method_1(UnityTextField unityTextField_0)
	{
		Font font = this.method_2(unityTextField_0.textFormat.font);
		if (this._mapFontRelatedList.ContainsKey(font))
		{
			this._mapFontRelatedList[font].method_0(unityTextField_0);
		}
	}

	// Token: 0x060032CD RID: 13005 RVA: 0x000E8EDC File Offset: 0x000E70DC
	public Font method_2(string string_0)
	{
		string text = "MSYH";
		if (this._mapFontFlashName2UnityName.ContainsKey(string_0))
		{
			text = this._mapFontFlashName2UnityName[string_0];
		}
		if (this.FONT_CACHE != null)
		{
			for (int i = 0; i < this.FONT_CACHE.Length; i++)
			{
				if (this.FONT_CACHE[i].name == text)
				{
					return this.FONT_CACHE[i].font;
				}
			}
		}
		return null;
	}

	// Token: 0x060032CE RID: 13006 RVA: 0x000E8F54 File Offset: 0x000E7154
	public Vector2 method_3(int int_0)
	{
		if (this._textGenerator == null)
		{
			return Vector2.zero;
		}
		if (int_0 < this._textGenerator.characters.Count && int_0 >= 0)
		{
			return this._textGenerator.characters[int_0].cursorPos;
		}
		return Vector2.zero;
	}

	// Token: 0x060032CF RID: 13007 RVA: 0x000E8FA8 File Offset: 0x000E71A8
	public GraphicsDrawOP method_4(UnityTextField unityTextField_0)
	{
		Font font = this.method_2(unityTextField_0.textFormat.font);
		if (font == null)
		{
			return null;
		}
		this.method_6(unityTextField_0, font);
		int num = this._textGenerator.characters.Count - 1;
		int count = this._textGenerator.verts.Count;
		string text = unityTextField_0.text;
		this.colors.Clear();
		this.positions.Clear();
		this.uvs.Clear();
		this.vertIndexs.Clear();
		this.shadowColors.Clear();
		this.shadowPositions.Clear();
		this.shadowUvs.Clear();
		this.shadowVertIndexs.Clear();
		float num2 = Mathf.Ceil(unityTextField_0.method_1());
		float num3 = Mathf.Ceil(unityTextField_0.method_0());
		int num4 = 0;
		int num6;
		for (int i = 0; i < num; i++)
		{
			int num5 = i << 2;
			if (num5 >= count)
			{
				break;
			}
			if (font.HasCharacter(text[i]) && text[i] >= '!' && !float.IsNaN(this._textGenerator.characters[i].charWidth) && this._textGenerator.characters[i].charWidth >= 2f)
			{
				UIVertex uivertex = this._textGenerator.verts[num5];
				Vector2 uv = uivertex.uv0;
				Vector2 vector = new Vector2((float)Mathf.RoundToInt(uivertex.position.x), (float)Mathf.RoundToInt(num2 - uivertex.position.y));
				uivertex = this._textGenerator.verts[num5 + 1];
				Vector2 uv2 = uivertex.uv0;
				Vector2 vector2 = new Vector2((float)Mathf.RoundToInt(uivertex.position.x), (float)Mathf.RoundToInt(num2 - uivertex.position.y));
				uivertex = this._textGenerator.verts[num5 + 2];
				Vector2 uv3 = uivertex.uv0;
				Vector2 vector3 = new Vector2((float)Mathf.RoundToInt(uivertex.position.x), (float)Mathf.RoundToInt(num2 - uivertex.position.y));
				uivertex = this._textGenerator.verts[num5 + 3];
				Vector2 uv4 = uivertex.uv0;
				Vector2 vector4 = new Vector2((float)Mathf.RoundToInt(uivertex.position.x), (float)Mathf.RoundToInt(num2 - uivertex.position.y));
				Color color = uivertex.color;
				this.uvs.Add(uv);
				this.uvs.Add(uv2);
				this.uvs.Add(uv3);
				this.uvs.Add(uv4);
				this.colors.Add(color);
				this.colors.Add(color);
				this.colors.Add(color);
				this.colors.Add(color);
				this.positions.Add(vector);
				this.positions.Add(vector2);
				this.positions.Add(vector3);
				this.positions.Add(vector4);
				num6 = num4 << 2;
				this.vertIndexs.Add(num6);
				this.vertIndexs.Add(num6 + 1);
				this.vertIndexs.Add(num6 + 2);
				this.vertIndexs.Add(num6 + 2);
				this.vertIndexs.Add(num6 + 3);
				this.vertIndexs.Add(num6);
				this.shadowColors.AddRange(this.constShadowColorList);
				num6 = num4 << 5;
				for (int j = -4; j < 5; j++)
				{
					if (j != 0)
					{
						int num7 = Mathf.RoundToInt((float)j / 3f);
						int num8 = j % 3 - num7;
						this.shadowUvs.Add(uv);
						this.shadowUvs.Add(uv2);
						this.shadowUvs.Add(uv3);
						this.shadowUvs.Add(uv4);
						this.shadowPositions.Add(new Vector2(vector.x + (float)num7, vector.y + (float)num8));
						this.shadowPositions.Add(new Vector2(vector2.x + (float)num7, vector2.y + (float)num8));
						this.shadowPositions.Add(new Vector2(vector3.x + (float)num7, vector3.y + (float)num8));
						this.shadowPositions.Add(new Vector2(vector4.x + (float)num7, vector4.y + (float)num8));
						this.shadowVertIndexs.Add(num6);
						this.shadowVertIndexs.Add(num6 + 1);
						this.shadowVertIndexs.Add(num6 + 2);
						this.shadowVertIndexs.Add(num6 + 2);
						this.shadowVertIndexs.Add(num6 + 3);
						this.shadowVertIndexs.Add(num6);
						num6 += 4;
					}
				}
				num4++;
			}
		}
		num6 = this.shadowPositions.Count;
		for (int k = 0; k < this.vertIndexs.Count; k++)
		{
			this.shadowVertIndexs.Add(this.vertIndexs[k] + num6);
		}
		this.shadowColors.AddRange(this.colors);
		this.shadowPositions.AddRange(this.positions);
		this.shadowUvs.AddRange(this.uvs);
		SimpleVectorShape simpleVectorShape = new SimpleVectorShape();
		simpleVectorShape.clear();
		simpleVectorShape.mouseEnabled = false;
		simpleVectorShape.vertices = this.shadowPositions.ToArray();
		simpleVectorShape.uv = this.shadowUvs.ToArray();
		simpleVectorShape.colors = this.shadowColors.ToArray();
		simpleVectorShape.cachedTriangulatedIndex = this.shadowVertIndexs.ToArray();
		return new GraphicsDrawOP
		{
			simpleVectorShape = simpleVectorShape,
			material = font.material,
			x = 0f,
			y = 0f,
			width = num3 + 2f,
			height = num2 + 2f,
			drawWidth = num3 + 2f,
			drawHeight = num2 + 2f,
			drawSrcRect = new Rect(0f, 0f, num3 + 2f, num2 + 2f)
		};
	}

	// Token: 0x060032D0 RID: 13008 RVA: 0x000E962C File Offset: 0x000E782C
	public pumpkin.display.Sprite[] method_5(UnityTextField unityTextField_0)
	{
		Font font = this.method_2(unityTextField_0.textFormat.font);
		if (font == null)
		{
			return null;
		}
		this.method_6(unityTextField_0, font);
		float num = (float)font.material.mainTexture.width;
		float num2 = (float)font.material.mainTexture.height;
		int num3 = this._textGenerator.characters.Count - 1;
		float num4 = Mathf.Ceil(unityTextField_0.method_1()) + 2f;
		List<pumpkin.display.Sprite> list = new List<pumpkin.display.Sprite>();
		List<pumpkin.display.Sprite> list2 = new List<pumpkin.display.Sprite>();
		int count = this._textGenerator.verts.Count;
		string text = unityTextField_0.text;
		for (int i = 0; i < num3; i++)
		{
			int num5 = i << 2;
			if (num5 >= count)
			{
				break;
			}
			if (font.HasCharacter(text[i]) && text[i] >= '!' && !float.IsNaN(this._textGenerator.characters[i].charWidth) && this._textGenerator.characters[i].charWidth >= 2f)
			{
				float num6 = Mathf.Min(this._textGenerator.verts[num5].uv0.x, this._textGenerator.verts[num5 + 2].uv0.x);
				float num7 = Mathf.Max(this._textGenerator.verts[num5].uv0.x, this._textGenerator.verts[num5 + 2].uv0.x);
				float num8 = Mathf.Min(this._textGenerator.verts[num5].uv0.y, this._textGenerator.verts[num5 + 2].uv0.y);
				float num9 = Mathf.Max(this._textGenerator.verts[num5].uv0.y, this._textGenerator.verts[num5 + 2].uv0.y);
				if (num6 != num7 && num9 != num8 && num9 <= 1f && num7 <= 1f)
				{
					Matrix matrix = new Matrix();
					float num10;
					float num11;
					if (this._textGenerator.verts[num5].uv0.x == this._textGenerator.verts[num5 + 1].uv0.x)
					{
						matrix.ty = num - num7 * num;
						matrix.tx = num2 - num9 * num2;
						matrix.rotate(1.5707964f);
						num10 = num9 * num2 - num8 * num2;
						num11 = num7 * num - num6 * num;
					}
					else
					{
						matrix.tx = num6 * num;
						matrix.ty = num8 * num2;
						matrix.scale(1f, -1f);
						num10 = num7 * num - num6 * num;
						num11 = num9 * num2 - num8 * num2;
					}
					GraphicsDrawOP graphicsDrawOP = new GraphicsDrawOP();
					graphicsDrawOP.color = this._textGenerator.verts[num5].color;
					graphicsDrawOP.material = font.material;
					graphicsDrawOP.x = 0f;
					graphicsDrawOP.y = 0f;
					graphicsDrawOP.width = num10;
					graphicsDrawOP.height = num11;
					graphicsDrawOP.drawWidth = num10;
					graphicsDrawOP.drawHeight = num11;
					graphicsDrawOP.drawSrcRect = new Rect(0f, 0f, num10, num11);
					graphicsDrawOP.matrix = matrix;
					pumpkin.display.Sprite sprite = new pumpkin.display.Sprite();
					pumpkin.display.Sprite sprite2 = sprite;
					sprite.mouseEnabled = false;
					sprite2.mouseChildrenEnabled = false;
					sprite.graphics.drawOPs.Clear();
					sprite.graphics.drawOPs.Add(graphicsDrawOP);
					sprite.x = Mathf.Round(this._textGenerator.verts[num5].position.x);
					sprite.y = Mathf.Round(num4 - this._textGenerator.verts[num5].position.y);
					list2.Add(sprite);
					GraphicsDrawOP graphicsDrawOP2 = this.method_7(graphicsDrawOP);
					graphicsDrawOP2.color = Color.black;
					for (int j = -4; j < 5; j++)
					{
						if (j != 0)
						{
							pumpkin.display.Sprite sprite3 = new pumpkin.display.Sprite();
							pumpkin.display.Sprite sprite4 = sprite3;
							sprite3.mouseEnabled = false;
							sprite4.mouseChildrenEnabled = false;
							sprite3.graphics.drawOPs.Clear();
							sprite3.graphics.drawOPs.Add(graphicsDrawOP2);
							int num12 = Mathf.RoundToInt((float)j / 3f);
							sprite3.x = sprite.x + (float)num12;
							sprite3.y = sprite.y + (float)(j % 3) - (float)num12;
							list.Add(sprite3);
						}
					}
				}
			}
		}
		list.AddRange(list2);
		return list.ToArray();
	}

	// Token: 0x060032D1 RID: 13009 RVA: 0x000E9B74 File Offset: 0x000E7D74
	protected void method_6(UnityTextField unityTextField_0, Font font_0)
	{
		if (this._textGenerator == null)
		{
			this._textGenerator = new TextGenerator();
			this._textSetting = default(TextGenerationSettings);
		}
		this._textSetting.font = font_0;
		this._textSetting.fontSize = Mathf.RoundToInt(unityTextField_0.textFormat.size);
		if (unityTextField_0.method_0() <= 220f)
		{
			this._textSetting.fontSize = Mathf.RoundToInt((float)this._textSetting.fontSize * 0.85f);
		}
		this._textSetting.color = unityTextField_0.Color_0;
		this._textSetting.richText = true;
		this._textSetting.generationExtents = new Vector2(unityTextField_0.method_0(), unityTextField_0.method_1());
		this._textSetting.lineSpacing = 1f;
		this._textSetting.horizontalOverflow = HorizontalWrapMode.Wrap;
		this._textSetting.verticalOverflow = VerticalWrapMode.Truncate;
		this._fShadowPixel = (((float)this._textSetting.fontSize >= 24f) ? 2f : 1f);
		this._textSetting.fontStyle = FontStyle.Normal;
		if (unityTextField_0.BitmapFontAssetInfo_0.italic > 0)
		{
			this._textSetting.fontStyle = this._textSetting.fontStyle | FontStyle.Italic;
		}
		if (unityTextField_0.BitmapFontAssetInfo_0.bold > 0)
		{
			this._textSetting.fontStyle = this._textSetting.fontStyle | FontStyle.Bold;
		}
		if (unityTextField_0.textFormat.align == 0)
		{
			this._textSetting.textAnchor = TextAnchor.UpperLeft;
		}
		else if (unityTextField_0.textFormat.align != 1 && unityTextField_0.textFormat.align != 4)
		{
			if (unityTextField_0.textFormat.align == 2)
			{
				this._textSetting.textAnchor = TextAnchor.UpperRight;
			}
		}
		else
		{
			this._textSetting.textAnchor = TextAnchor.UpperCenter;
		}
		font_0.RequestCharactersInTexture(unityTextField_0.text, this._textSetting.fontSize, this._textSetting.fontStyle);
		this._textGenerator.Populate(unityTextField_0.text, this._textSetting);
	}

	// Token: 0x060032D2 RID: 13010 RVA: 0x000E9D70 File Offset: 0x000E7F70
	private GraphicsDrawOP method_7(GraphicsDrawOP graphicsDrawOP_0)
	{
		return new GraphicsDrawOP
		{
			material = graphicsDrawOP_0.material,
			drawSrcRect = graphicsDrawOP_0.drawSrcRect,
			srcRect = graphicsDrawOP_0.srcRect,
			x = graphicsDrawOP_0.x,
			y = graphicsDrawOP_0.y,
			width = graphicsDrawOP_0.width,
			height = graphicsDrawOP_0.height,
			drawWidth = graphicsDrawOP_0.drawWidth,
			drawHeight = graphicsDrawOP_0.drawHeight,
			color = graphicsDrawOP_0.color,
			matrix = graphicsDrawOP_0.matrix
		};
	}

	// Token: 0x060032D3 RID: 13011 RVA: 0x00021142 File Offset: 0x0001F342
	private void Start()
	{
		this.mcCursor = new MovieClip("CommonLib.swf:TextFieldCursor");
	}

	// Token: 0x060032D4 RID: 13012 RVA: 0x000E9E08 File Offset: 0x000E8008
	protected override void Awake()
	{
		base.Awake();
		if (this.FONT_NAME_MAP != null && this.FONT_NAME_MAP.Length > 0)
		{
			this._mapFontFlashName2UnityName.Clear();
			for (int i = 0; i < this.FONT_NAME_MAP.Length; i++)
			{
				this._mapFontFlashName2UnityName.Add(this.FONT_NAME_MAP[i].FlashFontName, this.FONT_NAME_MAP[i].UnityFontName);
			}
		}
		if (this.FONT_CACHE != null)
		{
			this._mapFontRelatedList = new Dictionary<Font, UFont2uniSWFGenerator.FontRelatedThing>();
			for (int j = 0; j < this.FONT_CACHE.Length; j++)
			{
				this.FONT_CACHE[j].font.RequestCharactersInTexture(this.FONT_CACHE[j].initText, this.FONT_CACHE[j].initSize, this.FONT_CACHE[j].initStyle);
				this._mapFontRelatedList.Add(this.FONT_CACHE[j].font, new UFont2uniSWFGenerator.FontRelatedThing(this.FONT_CACHE[j].font));
			}
		}
	}

	// Token: 0x04002341 RID: 9025
	public const string DefaultFontName = "MSYH";

	// Token: 0x04002342 RID: 9026
	protected Dictionary<string, string> _mapFontFlashName2UnityName;

	// Token: 0x04002343 RID: 9027
	[SerializeField]
	public UFont2uniSWFGenerator.FlashNameUnityNameMap[] FONT_NAME_MAP;

	// Token: 0x04002344 RID: 9028
	[SerializeField]
	public UFont2uniSWFGenerator.FONT_INFO[] FONT_CACHE;

	// Token: 0x04002345 RID: 9029
	protected TextGenerator _textGenerator;

	// Token: 0x04002346 RID: 9030
	protected TextGenerationSettings _textSetting;

	// Token: 0x04002347 RID: 9031
	protected float _fShadowPixel = 1f;

	// Token: 0x04002348 RID: 9032
	protected Dictionary<Font, UFont2uniSWFGenerator.FontRelatedThing> _mapFontRelatedList;

	// Token: 0x04002349 RID: 9033
	protected MovieClip mcCursor;

	// Token: 0x0400234A RID: 9034
	private List<Color> colors = new List<Color>();

	// Token: 0x0400234B RID: 9035
	private List<Vector2> positions = new List<Vector2>();

	// Token: 0x0400234C RID: 9036
	private List<Vector2> uvs = new List<Vector2>();

	// Token: 0x0400234D RID: 9037
	private List<int> vertIndexs = new List<int>();

	// Token: 0x0400234E RID: 9038
	private List<Color> shadowColors = new List<Color>();

	// Token: 0x0400234F RID: 9039
	private List<Vector2> shadowPositions = new List<Vector2>();

	// Token: 0x04002350 RID: 9040
	private List<Vector2> shadowUvs = new List<Vector2>();

	// Token: 0x04002351 RID: 9041
	private List<int> shadowVertIndexs = new List<int>();

	// Token: 0x04002352 RID: 9042
	private Color[] constShadowColorList = new Color[32];

	// Token: 0x0200077D RID: 1917
	[Serializable]
	public struct FlashNameUnityNameMap
	{
		// Token: 0x04002353 RID: 9043
		public string FlashFontName;

		// Token: 0x04002354 RID: 9044
		public string UnityFontName;
	}

	// Token: 0x0200077E RID: 1918
	[Serializable]
	public struct FONT_INFO
	{
		// Token: 0x04002355 RID: 9045
		public Font font;

		// Token: 0x04002356 RID: 9046
		public string initText;

		// Token: 0x04002357 RID: 9047
		public int initSize;

		// Token: 0x04002358 RID: 9048
		public FontStyle initStyle;

		// Token: 0x04002359 RID: 9049
		public string name;
	}

	// Token: 0x0200077F RID: 1919
	protected class FontRelatedThing
	{
		// Token: 0x060032D5 RID: 13013 RVA: 0x00021154 File Offset: 0x0001F354
		public FontRelatedThing(Font font_0)
		{
			if (font_0 != null)
			{
				font_0.textureRebuildCallback = (Font.FontTextureRebuildCallback)Delegate.Combine(font_0.textureRebuildCallback, new Font.FontTextureRebuildCallback(this.method_1));
			}
		}

		// Token: 0x060032D6 RID: 13014 RVA: 0x00021187 File Offset: 0x0001F387
		public void method_0(UnityTextField unityTextField_0)
		{
			if (this._arrTFUpdateList == null)
			{
				this._arrTFUpdateList = new List<UnityTextField>();
			}
			if (this._arrTFUpdateList.Contains(unityTextField_0))
			{
				return;
			}
			this._arrTFUpdateList.Add(unityTextField_0);
		}

		// Token: 0x060032D7 RID: 13015 RVA: 0x000E9F20 File Offset: 0x000E8120
		public void method_1()
		{
			if (this._arrTFUpdateList != null)
			{
				for (int i = 0; i < this._arrTFUpdateList.Count; i++)
				{
					this._arrTFUpdateList[i].method_8();
				}
			}
		}

		// Token: 0x060032D8 RID: 13016 RVA: 0x000211B7 File Offset: 0x0001F3B7
		public void method_2()
		{
			if (this._arrTFUpdateList != null)
			{
				this._arrTFUpdateList.Clear();
			}
		}

		// Token: 0x0400235A RID: 9050
		protected List<UnityTextField> _arrTFUpdateList;
	}
}
