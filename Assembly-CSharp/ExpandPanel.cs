using System;
using System.Collections.Generic;
using Core;
using ns0;
using pumpkin.display;
using pumpkin.events;
using pumpkin.geom;
using UnityEngine;

// Token: 0x020007E2 RID: 2018
internal class ExpandPanel : GClass51
{
	// Token: 0x06003675 RID: 13941 RVA: 0x000F9588 File Offset: 0x000F7788
	public ExpandPanel()
	{
		this._arrElemList = new List<MovieClip>();
		this._arrElemStateList = new List<ExpandPanel.ElementState>();
	}

	// Token: 0x06003676 RID: 13942 RVA: 0x00023F02 File Offset: 0x00022102
	public void method_5(string string_1, string string_2)
	{
		this._strMaskName = string_1;
		this._strMaskedChild = string_2;
	}

	// Token: 0x06003677 RID: 13943 RVA: 0x000F95D8 File Offset: 0x000F77D8
	protected override void vmethod_0()
	{
		base.vmethod_0();
		this.mcSelf = this.displayObjectContainer_0 as MovieClip;
		if (this.mcSelf == null)
		{
			DebugUtils.LogWarning(LogCategory.GUI, "UIWarning: Button onConfiUI() 'controlMC' is null! UIComponent won't work!!!");
		}
		string symbolName = this.mcSelf.getSymbolName();
		string[] array = symbolName.Split(new char[] { '_' });
		if (array[1] != null && array[1].ToLower() == "v")
		{
			this._bHorizontal = false;
		}
		this.mcSelf.addEventListener(CEvent.ENTER_FRAME, new EventDispatcher.EventCallback(this.method_9));
	}

	// Token: 0x06003678 RID: 13944 RVA: 0x000F966C File Offset: 0x000F786C
	public void method_6(int int_0 = 0)
	{
		if (this._iExpandIndex == int_0)
		{
			return;
		}
		int iExpandIndex = this._iExpandIndex;
		this._iExpandIndex = int_0;
		if (this._arrElemList.Count > 0 && int_0 < this._arrElemList.Count)
		{
			if (iExpandIndex != -1)
			{
				this._arrElemList[iExpandIndex].gotoAndPlay("shrinkStart");
			}
			this._arrElemList[int_0].gotoAndPlay("expandStart");
		}
	}

	// Token: 0x06003679 RID: 13945 RVA: 0x0000311B File Offset: 0x0000131B
	protected void method_7(CEvent cevent_0)
	{
	}

	// Token: 0x0600367A RID: 13946 RVA: 0x0000311B File Offset: 0x0000131B
	protected void method_8(CEvent cevent_0)
	{
	}

	// Token: 0x0600367B RID: 13947 RVA: 0x000F96E0 File Offset: 0x000F78E0
	protected void method_9(CEvent cevent_0)
	{
		this.mcSelf.removeEventListener(CEvent.ENTER_FRAME, new EventDispatcher.EventCallback(this.method_9));
		int num = 0;
		MovieClip movieClip;
		do
		{
			movieClip = this.mcSelf.getChildByName(Utility.smethod_5("element", Utility.smethod_8(num))) as MovieClip;
			if (movieClip != null)
			{
				ExpandPanel.ElementState elementState = new ExpandPanel.ElementState();
				elementState.vecOrinPos = new Vector2(movieClip.x, movieClip.y);
				DisplayObject childByName = movieClip.getChildByName<DisplayObject>(this._strMaskName);
				elementState.vecOrinSize = Vector2.zero;
				if (childByName != null)
				{
					elementState.vecOrinSize = new Vector2(childByName.width, childByName.height);
				}
				movieClip.userData = num;
				if (this._bHorizontal)
				{
					movieClip.addEventListener(CEvent.ENTER_FRAME, new EventDispatcher.EventCallback(this.method_7));
				}
				else
				{
					movieClip.addEventListener(CEvent.ENTER_FRAME, new EventDispatcher.EventCallback(this.method_8));
				}
				if (num != this._iExpandIndex)
				{
					movieClip.gotoAndStop("shrinked");
				}
				this._arrElemList.Add(movieClip);
				this._arrElemStateList.Add(elementState);
			}
			num++;
		}
		while (movieClip != null);
		this.method_6(this._iExpandIndex);
	}

	// Token: 0x0600367C RID: 13948 RVA: 0x000F9820 File Offset: 0x000F7A20
	protected void method_10(int int_0)
	{
		float num = 0f;
		this.method_12(this._arrElemList[int_0], this._strMaskName, this._strMaskedChild);
		for (int i = 0; i < int_0; i++)
		{
			num += this._arrElemStateList[i].fOffset;
		}
		this._arrElemList[int_0].x = this._arrElemStateList[int_0].vecOrinPos.x + num;
		DisplayObject childByName = this._arrElemList[int_0].getChildByName<DisplayObject>(this._strMaskName);
		this._arrElemStateList[int_0].fOffset = childByName.width - this._arrElemStateList[int_0].vecOrinSize.x;
	}

	// Token: 0x0600367D RID: 13949 RVA: 0x000F98E0 File Offset: 0x000F7AE0
	protected void method_11(int int_0)
	{
		float num = 0f;
		this.method_12(this._arrElemList[int_0], this._strMaskName, this._strMaskedChild);
		for (int i = 0; i < int_0; i++)
		{
			num += this._arrElemStateList[i].fOffset;
		}
		this._arrElemList[int_0].y = this._arrElemStateList[int_0].vecOrinPos.y + num;
		DisplayObject childByName = this._arrElemList[int_0].getChildByName<DisplayObject>(this._strMaskName);
		this._arrElemStateList[int_0].fOffset = childByName.height - this._arrElemStateList[int_0].vecOrinSize.y;
	}

	// Token: 0x0600367E RID: 13950 RVA: 0x000F99A0 File Offset: 0x000F7BA0
	public void method_12(MovieClip movieClip_0, string string_1, string string_2)
	{
		if (movieClip_0 != null && string_1 != null && !(string_1 == string.Empty))
		{
			DisplayObject childByName = movieClip_0.getChildByName(string_1);
			DisplayObject displayObject = movieClip_0.getChildByName(string_2);
			if (displayObject == null)
			{
				displayObject = movieClip_0;
				DebugUtils.LogError(LogCategory.GUI, " --- null!!!! ");
			}
			if (childByName != null)
			{
				Rectangle bounds = childByName.getBounds(displayObject);
				displayObject.clipRect = bounds.rect;
			}
			return;
		}
	}

	// Token: 0x040025A5 RID: 9637
	protected const string ELEM_NAME = "element";

	// Token: 0x040025A6 RID: 9638
	protected int _iExpandIndex = -1;

	// Token: 0x040025A7 RID: 9639
	protected List<MovieClip> _arrElemList;

	// Token: 0x040025A8 RID: 9640
	protected List<ExpandPanel.ElementState> _arrElemStateList;

	// Token: 0x040025A9 RID: 9641
	protected bool _bHorizontal = true;

	// Token: 0x040025AA RID: 9642
	protected MovieClip mcSelf;

	// Token: 0x040025AB RID: 9643
	protected string _strMaskName = string.Empty;

	// Token: 0x040025AC RID: 9644
	protected string _strMaskedChild = string.Empty;

	// Token: 0x020007E3 RID: 2019
	protected class ElementState
	{
		// Token: 0x040025AD RID: 9645
		public Vector2 vecOrinSize;

		// Token: 0x040025AE RID: 9646
		public Vector2 vecOrinPos;

		// Token: 0x040025AF RID: 9647
		public float fOffset;
	}
}
