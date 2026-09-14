using System;
using System.Collections.Generic;
using System.Reflection;
using ns0;
using pumpkin.display;
using pumpkin.events;
using pumpkin.swf;
using pumpkin.text;
using UnityEngine;

// Token: 0x02000780 RID: 1920
public class UnityTextField : BitmapTextField
{
	// Token: 0x17000275 RID: 629
	// (get) Token: 0x060032DA RID: 13018 RVA: 0x000211E2 File Offset: 0x0001F3E2
	public BitmapFontAssetInfo BitmapFontAssetInfo_0
	{
		get
		{
			return this.m_FontInfo;
		}
	}

	// Token: 0x17000276 RID: 630
	// (get) Token: 0x060032DB RID: 13019 RVA: 0x000211EA File Offset: 0x0001F3EA
	// (set) Token: 0x060032DC RID: 13020 RVA: 0x000211F2 File Offset: 0x0001F3F2
	public Color Color_0
	{
		get
		{
			return this._textColor;
		}
		set
		{
			if (value == this._textColor)
			{
				return;
			}
			this._textColor = value;
			base.textFormat.color = this._textColor;
			this.renderText();
		}
	}

	// Token: 0x060032DD RID: 13021 RVA: 0x00021221 File Offset: 0x0001F421
	public float method_0()
	{
		return this.maxW;
	}

	// Token: 0x060032DE RID: 13022 RVA: 0x00021229 File Offset: 0x0001F429
	public float method_1()
	{
		return this.maxH;
	}

	// Token: 0x17000277 RID: 631
	// (get) Token: 0x060032DF RID: 13023 RVA: 0x00021231 File Offset: 0x0001F431
	// (set) Token: 0x060032E0 RID: 13024 RVA: 0x0000311B File Offset: 0x0000131B
	public bool Boolean_0
	{
		get
		{
			return this.m_HasKeybaordFocus;
		}
		private set
		{
		}
	}

	// Token: 0x060032E1 RID: 13025 RVA: 0x000E9F5C File Offset: 0x000E815C
	protected void method_2(BitmapTextField bitmapTextField_0, out float float_0, out float float_1)
	{
		Type type = bitmapTextField_0.GetType();
		FieldInfo field = type.GetField("maxW", BindingFlags.Instance | BindingFlags.NonPublic);
		FieldInfo field2 = type.GetField("maxH", BindingFlags.Instance | BindingFlags.NonPublic);
		float_0 = (float)field.GetValue(bitmapTextField_0);
		float_1 = (float)field2.GetValue(bitmapTextField_0);
	}

	// Token: 0x060032E2 RID: 13026 RVA: 0x00021239 File Offset: 0x0001F439
	public void method_3()
	{
		this.renderText();
	}

	// Token: 0x060032E3 RID: 13027 RVA: 0x000E9FA8 File Offset: 0x000E81A8
	public override DisplayObject getObjectUnderPoint(Vector2 point)
	{
		if (!base.visible)
		{
			return null;
		}
		if (!this.mouseEnabled)
		{
			return null;
		}
		if (this.m_Alpha == 0f)
		{
			return null;
		}
		Vector2 vector = base.globalToLocal(point);
		if (vector.x >= 0f && vector.x <= this.srcWidth && vector.y >= 0f && vector.y <= this.srcHeight)
		{
			return this;
		}
		return null;
	}

	// Token: 0x060032E4 RID: 13028 RVA: 0x000EA020 File Offset: 0x000E8220
	protected override void _removeLastChar()
	{
		base._removeLastChar();
		this._iCaretIndex = Math.Max(0, --this._iCaretIndex);
	}

	// Token: 0x060032E5 RID: 13029 RVA: 0x000EA050 File Offset: 0x000E8250
	protected int method_4()
	{
		int num = 0;
		for (int i = 0; i < this.m_Text.Length; i++)
		{
			num += this.method_5(this.m_Text[i]);
		}
		return num;
	}

	// Token: 0x060032E6 RID: 13030 RVA: 0x00021241 File Offset: 0x0001F441
	protected int method_5(char char_0)
	{
		if (char_0 <= '\u007f')
		{
			return 1;
		}
		return 2;
	}

	// Token: 0x060032E7 RID: 13031 RVA: 0x000EA08C File Offset: 0x000E828C
	protected override void _appendChar(char c)
	{
		if (base.maxChars > 0 && this.method_4() + this.method_5(c) > base.maxChars)
		{
			return;
		}
		if (this.restrictChars != null && this.restrictChars.Contains(c))
		{
			return;
		}
		this.m_Text = this.m_Text.Insert(this._iCaretIndex, string.Empty + c);
		this._iCaretIndex++;
		this.renderText();
		if (this.autoInputScroll)
		{
			base.scrollV = base.maxScrollV;
		}
	}

	// Token: 0x060032E8 RID: 13032 RVA: 0x0002124B File Offset: 0x0001F44B
	protected override void renderText()
	{
		if (base.visible && this.Boolean_1)
		{
			this._bNeedReRender = true;
		}
	}

	// Token: 0x060032E9 RID: 13033 RVA: 0x000EA120 File Offset: 0x000E8320
	protected void method_6()
	{
		this._bNeedReRender = false;
		if (base.textFormat.font != null)
		{
			this.graphics.clear();
			this.graphics.drawOPs.Add(MonoSingleton<UFont2uniSWFGenerator>.Instance.method_4(this));
		}
		if (base.type == TextFieldType.INPUT)
		{
			Vector2 vector = MonoSingleton<UFont2uniSWFGenerator>.Instance.method_3(this._iCaretIndex);
			vector.y = this.maxH - vector.y + 2f;
			this.method_7(vector);
		}
	}

	// Token: 0x060032EA RID: 13034 RVA: 0x000EA1A8 File Offset: 0x000E83A8
	protected void method_7(Vector2 vector2_0)
	{
		if (this.m_Cursor != null)
		{
			this.m_Cursor.visible = this.m_HasKeybaordFocus;
			this.m_Cursor.colorTransform = this._textColor;
			this.m_Cursor.x = Math.Min(vector2_0.x, this.maxW);
			this.m_Cursor.y = vector2_0.y;
		}
		else if (this.m_Cursor != null)
		{
			this.m_Cursor.visible = false;
		}
	}

	// Token: 0x060032EB RID: 13035 RVA: 0x000EA224 File Offset: 0x000E8424
	protected override void _textChanged()
	{
		base._textChanged();
		this._iCaretIndex = Math.Max(0, Math.Min(this.m_Text.Length, this._iCaretIndex));
		this._textColor = base.textFormat.color;
		this.renderText();
	}

	// Token: 0x060032EC RID: 13036 RVA: 0x000EA270 File Offset: 0x000E8470
	protected override void _cursorChanged(DisplayObject cursor)
	{
		if (this.m_Cursor != null)
		{
			if (this.m_Cursor.parent != null)
			{
				this.m_Cursor.parent.removeChild(this.m_Cursor);
			}
			this.m_Cursor = null;
		}
		this.m_Cursor = cursor;
		if (this.m_Cursor != null)
		{
			base.addChild(this.m_Cursor);
		}
		this.renderText();
	}

	// Token: 0x060032ED RID: 13037 RVA: 0x0000311B File Offset: 0x0000131B
	protected override void onCreateCursor()
	{
	}

	// Token: 0x060032EE RID: 13038 RVA: 0x000EA2D0 File Offset: 0x000E84D0
	public override void setAssetInfo(SwfAssetContext assetContext, BitmapFontAssetInfo fontInfo, DisplayObjectInfo dispInfo)
	{
		fontInfo.bold = ((!fontInfo.className.Contains("b:1")) ? 0 : 1);
		fontInfo.italic = ((!fontInfo.className.Contains("i:1")) ? 0 : 1);
		fontInfo.spaceWidth = 1f;
		this.m_Type = dispInfo.textInfo.type;
		if (base.type == TextFieldType.INPUT)
		{
			base.cursor = MonoSingleton<UFont2uniSWFGenerator>.Instance.MovieClip_0.newInstance();
		}
		fontInfo.shared = base.type == TextFieldType.INPUT;
		fontInfo.color = Color.white;
		base.setAssetInfo(assetContext, fontInfo, dispInfo);
		this.assetContext.resourceLoader = assetContext.resourceLoader;
		this.assetContext.textureManager = assetContext.textureManager;
		this.maxW = dispInfo.tranform.width;
		this.maxH = dispInfo.tranform.height;
		this.renderText();
	}

	// Token: 0x060032EF RID: 13039 RVA: 0x000EA3C4 File Offset: 0x000E85C4
	protected override void setAssetInfo(SwfAssetContext assetContext, BitmapFontAssetInfo fontInfoIn, TextFormat format)
	{
		base.setAssetInfo(assetContext, fontInfoIn, format);
		this.m_CursorColor = Color.white;
		base.textFormat.bold = fontInfoIn.bold > 0;
		base.textFormat.italic = fontInfoIn.italic > 0;
		base.textFormat.color = fontInfoIn.color;
		this._textColor = fontInfoIn.color;
		MonoSingleton<UFont2uniSWFGenerator>.Instance.method_1(this);
	}

	// Token: 0x060032F0 RID: 13040 RVA: 0x00021264 File Offset: 0x0001F464
	protected override void _KeyboardFocusChange()
	{
		base._KeyboardFocusChange();
		this._iCaretIndex = this.m_Text.Length;
		this.renderText();
	}

	// Token: 0x060032F1 RID: 13041 RVA: 0x00021283 File Offset: 0x0001F483
	public override void updateFrame(CEvent e)
	{
		base.updateFrame(e);
		if (this._bNeedReRender)
		{
			this.method_6();
		}
	}

	// Token: 0x060032F2 RID: 13042 RVA: 0x0002129A File Offset: 0x0001F49A
	public void method_8()
	{
		this._bNeedReRender = true;
	}

	// Token: 0x060032F3 RID: 13043 RVA: 0x000EA438 File Offset: 0x000E8638
	protected override void OnSetParent(DisplayObjectContainer inParent)
	{
		base.OnSetParent(inParent);
		BadAssMovieClip badAssMovieClip = inParent as BadAssMovieClip;
		if (badAssMovieClip != null)
		{
			this._bTreeVisible = badAssMovieClip.Boolean_0 && this.m_Visible;
			this._bNeedReRender = true;
		}
		else
		{
			this._bTreeVisible = this.m_Visible;
		}
	}

	// Token: 0x060032F4 RID: 13044 RVA: 0x000212A3 File Offset: 0x0001F4A3
	protected override void OnSetVisble()
	{
		base.OnSetVisble();
		this.renderText();
	}

	// Token: 0x17000278 RID: 632
	// (get) Token: 0x060032F5 RID: 13045 RVA: 0x000212B1 File Offset: 0x0001F4B1
	// (set) Token: 0x060032F6 RID: 13046 RVA: 0x000212B9 File Offset: 0x0001F4B9
	public virtual bool Boolean_1
	{
		get
		{
			return this._bTreeVisible;
		}
		set
		{
			this._bTreeVisible = value;
			this.renderText();
		}
	}

	// Token: 0x0400235B RID: 9051
	protected int _iCaretIndex;

	// Token: 0x0400235C RID: 9052
	public List<char> restrictChars;

	// Token: 0x0400235D RID: 9053
	protected Color _textColor;

	// Token: 0x0400235E RID: 9054
	protected bool _bTreeVisible = true;

	// Token: 0x0400235F RID: 9055
	protected bool _bNeedReRender = true;
}
