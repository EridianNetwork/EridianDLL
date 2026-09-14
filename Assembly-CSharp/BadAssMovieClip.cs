using System;
using System.Collections.Generic;
using pumpkin.display;
using pumpkin.swf;
using pumpkin.text;
using UnityEngine;

// Token: 0x0200076F RID: 1903
public class BadAssMovieClip : MovieClip
{
	// Token: 0x0600325E RID: 12894 RVA: 0x00020CE2 File Offset: 0x0001EEE2
	public BadAssMovieClip()
	{
	}

	// Token: 0x0600325F RID: 12895 RVA: 0x00020D0F File Offset: 0x0001EF0F
	public BadAssMovieClip(string string_0)
		: base(string_0)
	{
	}

	// Token: 0x06003260 RID: 12896 RVA: 0x00020D3D File Offset: 0x0001EF3D
	public BadAssMovieClip(SwfURI swfURI_0)
		: base(swfURI_0)
	{
	}

	// Token: 0x06003261 RID: 12897 RVA: 0x00020D6B File Offset: 0x0001EF6B
	public BadAssMovieClip(ISwfResourceLoader iswfResourceLoader_0, string string_0)
		: base(iswfResourceLoader_0, string_0)
	{
	}

	// Token: 0x06003262 RID: 12898 RVA: 0x00020D9A File Offset: 0x0001EF9A
	public BadAssMovieClip(string string_0, string string_1)
		: base(string_0, string_1)
	{
	}

	// Token: 0x1700026D RID: 621
	// (set) Token: 0x06003263 RID: 12899 RVA: 0x00020DC9 File Offset: 0x0001EFC9
	public int Int32_0
	{
		set
		{
			this._iGridRenderSum = Math.Max(0, Math.Min(value, 9));
		}
	}

	// Token: 0x1700026E RID: 622
	// (get) Token: 0x06003264 RID: 12900 RVA: 0x00020DDF File Offset: 0x0001EFDF
	// (set) Token: 0x06003265 RID: 12901 RVA: 0x000E6398 File Offset: 0x000E4598
	public float Single_0
	{
		get
		{
			return base.width;
		}
		set
		{
			if (this._b9Scaled)
			{
				float num = 0f;
				if (this.m_CachedSliceSprite != null)
				{
					num = this.m_CachedSliceSprite.width - base.scale9Grid.width;
				}
				value = Math.Max(value, num);
				this._fInnerScaleX = (value - num) / this._scale9Rect.width;
				this.rebuildScale9Grid();
			}
		}
	}

	// Token: 0x1700026F RID: 623
	// (get) Token: 0x06003266 RID: 12902 RVA: 0x00020DE7 File Offset: 0x0001EFE7
	// (set) Token: 0x06003267 RID: 12903 RVA: 0x000E63FC File Offset: 0x000E45FC
	public float Single_1
	{
		get
		{
			return base.height;
		}
		set
		{
			if (this._b9Scaled)
			{
				float num = 0f;
				if (this.m_CachedSliceSprite != null)
				{
					num = this.m_CachedSliceSprite.height - base.scale9Grid.height;
				}
				value = Math.Max(value, num);
				this._fInnerScaleY = (value - num) / this._scale9Rect.height;
				this.rebuildScale9Grid();
			}
		}
	}

	// Token: 0x17000270 RID: 624
	// (get) Token: 0x06003268 RID: 12904 RVA: 0x00020DEF File Offset: 0x0001EFEF
	public Rect Rect_0
	{
		get
		{
			return this._scale9Rect;
		}
	}

	// Token: 0x06003269 RID: 12905 RVA: 0x000E6460 File Offset: 0x000E4660
	protected override BitmapTextField onInstanceBitmapTextField(BitmapFontAssetInfo bmpAssetInfo, int depthSlot)
	{
		return new UnityTextField();
	}

	// Token: 0x0600326A RID: 12906 RVA: 0x000E6474 File Offset: 0x000E4674
	protected override MovieClip onInstanceChildMovieClip(DisplayObjectInfo dispInfo, int depthSlot)
	{
		MovieClipAssetInfo movieInfoByCid = base.assetContext.getMovieInfoByCid(dispInfo.cid);
		MovieClipPlayer.registerGlobalLinkage(movieInfoByCid.className, typeof(BadAssMovieClip));
		MovieClip movieClip = base.onInstanceChildMovieClip(dispInfo, depthSlot);
		if (movieClip != null && dispInfo.name != null && dispInfo.name.Contains(MaskPad.MASKPAD_PREFIX))
		{
			MaskPad maskPad = new MaskPad();
			maskPad.method_0(movieClip, dispInfo.name);
		}
		return movieClip;
	}

	// Token: 0x0600326B RID: 12907 RVA: 0x00020DF7 File Offset: 0x0001EFF7
	protected override void OnSetScale9Grid(Rect rect)
	{
		base.OnSetScale9Grid(rect);
		if (MovieClipPlayer.enableScale9)
		{
			this._scale9Rect = rect;
			this._b9Scaled = true;
		}
	}

	// Token: 0x0600326C RID: 12908 RVA: 0x000E64E4 File Offset: 0x000E46E4
	public static Rect smethod_0(Material material_0, Rect rect_0, Rect rect_1)
	{
		Vector2 vector = TextureManager.MaterialPixelSpaceToUVSpace(material_0, new Vector2(rect_0.x, rect_0.y));
		Vector2 vector2 = TextureManager.MaterialPixelSpaceToUVSpace(material_0, new Vector2(rect_0.width, rect_0.height));
		return new Rect(vector.x + rect_1.x * vector2.x, vector.y + rect_1.y * vector2.y, vector2.x * rect_1.width, vector2.y * rect_1.height);
	}

	// Token: 0x0600326D RID: 12909 RVA: 0x000E6578 File Offset: 0x000E4778
	protected override void rebuildScale9Grid()
	{
		if (base.numChildren < 1)
		{
			return;
		}
		this.m_CachedSliceSprite = this.getChildAt(0) as pumpkin.display.Sprite;
		AssetBaseInfo assetBaseInfo = this.m_AssetContext.exports[this.m_CachedSliceSprite.cachedCid];
		BitmapAssetInfo bitmapAssetInfo = assetBaseInfo as BitmapAssetInfo;
		if (this.m_CachedSliceSprite == null)
		{
			return;
		}
		if (this.m_CachedSliceSprite.graphics.drawOPs.Count == 0)
		{
			return;
		}
		if (bitmapAssetInfo == null)
		{
			return;
		}
		this.m_CachedSliceSprite.visible = true;
		this.graphics.clear();
		float height = base.height;
		float width = base.width;
		GraphicsDrawOP graphicsDrawOP = this.m_CachedSliceSprite.graphics.drawOPs[0];
		Material material = graphicsDrawOP.material;
		if (material == null)
		{
			return;
		}
		Rect srcRect = bitmapAssetInfo.srcRect;
		float[] array = new float[]
		{
			0f,
			this._scale9Rect.x / width,
			(this._scale9Rect.x + this._scale9Rect.width) / width,
			1f
		};
		float[] array2 = new float[]
		{
			0f,
			this._scale9Rect.y / height,
			(this._scale9Rect.y + this._scale9Rect.height) / height,
			1f
		};
		float[] array3 = new float[]
		{
			0f,
			this._scale9Rect.x,
			this._scale9Rect.x + this._scale9Rect.width * this._fInnerScaleX,
			width + this._scale9Rect.width * (this._fInnerScaleX - 1f)
		};
		float[] array4 = new float[]
		{
			0f,
			this._scale9Rect.y,
			this._scale9Rect.y + this._scale9Rect.height * this._fInnerScaleY,
			height + this._scale9Rect.height * (this._fInnerScaleY - 1f)
		};
		for (int i = 0; i < this._iGridRenderSum; i++)
		{
			int num = Mathf.FloorToInt((float)(i / 3));
			int num2 = i % 3;
			Rect rect = Rect.MinMaxRect(array3[num2], array4[num], array3[num2 + 1], array4[num + 1]);
			Rect rect2 = Rect.MinMaxRect(array[num2], array2[num], array[num2 + 1], array2[num + 1]);
			rect2 = BadAssMovieClip.smethod_0(material, srcRect, rect2);
			this.graphics.drawRectUV(material, rect2, rect);
		}
		this.m_CachedSliceSprite.visible = false;
	}

	// Token: 0x0600326E RID: 12910 RVA: 0x000E67F4 File Offset: 0x000E49F4
	protected override void OnSetVisble()
	{
		base.OnSetVisble();
		BadAssMovieClip badAssMovieClip = this.m_Parent as BadAssMovieClip;
		if (badAssMovieClip != null)
		{
			this._bTreeVisible = badAssMovieClip.Boolean_0 && this.m_Visible;
		}
		else
		{
			this._bTreeVisible = this.m_Visible;
		}
		this.method_0();
	}

	// Token: 0x0600326F RID: 12911 RVA: 0x000E6844 File Offset: 0x000E4A44
	protected void method_0()
	{
		for (int i = 0; i < this.m_Children.Count; i++)
		{
			BadAssMovieClip badAssMovieClip = this.m_Children[i] as BadAssMovieClip;
			if (badAssMovieClip != null)
			{
				badAssMovieClip.OnParentTreeVisible(this._bTreeVisible);
			}
			else
			{
				UnityTextField unityTextField = this.m_Children[i] as UnityTextField;
				if (unityTextField != null)
				{
					unityTextField.Boolean_1 = this._bTreeVisible;
				}
			}
		}
	}

	// Token: 0x06003270 RID: 12912 RVA: 0x000E68AC File Offset: 0x000E4AAC
	protected override void OnSetParent(DisplayObjectContainer inParent)
	{
		base.OnSetParent(inParent);
		BadAssMovieClip badAssMovieClip = inParent as BadAssMovieClip;
		if (badAssMovieClip != null)
		{
			this._bTreeVisible = badAssMovieClip.Boolean_0 && this.m_Visible;
		}
		else
		{
			this._bTreeVisible = this.m_Visible;
		}
	}

	// Token: 0x06003271 RID: 12913 RVA: 0x000E68F0 File Offset: 0x000E4AF0
	public virtual void vmethod_0()
	{
		List<int> list = new List<int>();
		foreach (KeyValuePair<int, object> keyValuePair in this.m_InstanceCache)
		{
			if (keyValuePair.Value is TextField)
			{
				list.Add(keyValuePair.Key);
			}
		}
		foreach (int num in list)
		{
			this.m_InstanceCache.Remove(num);
		}
	}

	// Token: 0x06003272 RID: 12914 RVA: 0x00020E15 File Offset: 0x0001F015
	public virtual void OnParentTreeVisible(bool bVisible)
	{
		this._bTreeVisible = bVisible && this.m_Visible;
		this.method_0();
	}

	// Token: 0x17000271 RID: 625
	// (get) Token: 0x06003273 RID: 12915 RVA: 0x00020E2F File Offset: 0x0001F02F
	public virtual bool Boolean_0
	{
		get
		{
			return this._bTreeVisible;
		}
	}

	// Token: 0x040022EF RID: 8943
	private bool _b9Scaled;

	// Token: 0x040022F0 RID: 8944
	protected Rect _scale9Rect;

	// Token: 0x040022F1 RID: 8945
	protected float _fInnerScaleX = 1f;

	// Token: 0x040022F2 RID: 8946
	protected float _fInnerScaleY = 1f;

	// Token: 0x040022F3 RID: 8947
	protected int _iGridRenderSum = 9;

	// Token: 0x040022F4 RID: 8948
	protected bool _bTreeVisible = true;
}
