using System;
using pumpkin.display;
using pumpkin.events;

// Token: 0x02000782 RID: 1922
public class MaskPad
{
	// Token: 0x06003301 RID: 13057 RVA: 0x000EA54C File Offset: 0x000E874C
	public void method_0(MovieClip movieClip_0, string string_0)
	{
		string[] array = string_0.Split(new char[] { '_' });
		if (array != null && array.Length >= 2)
		{
			this._strMaskMCName = "Mask_" + array[1];
			this._relateMC = movieClip_0;
			this._relateMC.visible = false;
			this._relateMC.removeAllEventListeners(CEvent.ENTER_FRAME);
			this._relateMC.addEventListener(CEvent.ENTER_FRAME, new EventDispatcher.EventCallback(this.method_1));
			return;
		}
	}

	// Token: 0x06003302 RID: 13058 RVA: 0x000EA5CC File Offset: 0x000E87CC
	protected void method_1(CEvent cevent_0)
	{
		MovieClip movieClip = this._relateMC.parent as MovieClip;
		if (movieClip == null)
		{
			return;
		}
		MovieClip childByName = movieClip.getChildByName<MovieClip>(this._strMaskMCName);
		if (childByName == null)
		{
			return;
		}
		int childIndex = movieClip.getChildIndex(childByName);
		int childIndex2 = movieClip.getChildIndex(this._relateMC);
		if (childIndex >= childIndex2)
		{
			return;
		}
		for (int i = childIndex + 1; i < childIndex2; i++)
		{
			DisplayObject childAt = movieClip.getChildAt(i);
			childAt.clipRect = childByName.getBounds(childAt).rect;
		}
		childByName.visible = false;
	}

	// Token: 0x04002362 RID: 9058
	public static readonly string MASKPAD_PREFIX = "MaskPad";

	// Token: 0x04002363 RID: 9059
	protected string _strMaskMCName;

	// Token: 0x04002364 RID: 9060
	protected MovieClip _relateMC;
}
