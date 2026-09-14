using System;
using System.Text;
using Core;
using ns0;
using pumpkin.display;
using pumpkin.events;
using UnityEngine;

// Token: 0x02000818 RID: 2072
public class ExpLevelPanel : GClass51
{
	// Token: 0x170002FD RID: 765
	// (get) Token: 0x06003803 RID: 14339 RVA: 0x0002535D File Offset: 0x0002355D
	// (set) Token: 0x06003802 RID: 14338 RVA: 0x00025347 File Offset: 0x00023547
	public virtual bool Boolean_0
	{
		get
		{
			return this.mcSelf != null && this.mcSelf.visible;
		}
		set
		{
			if (this.mcSelf != null)
			{
				this.mcSelf.visible = value;
			}
		}
	}

	// Token: 0x170002FE RID: 766
	// (get) Token: 0x06003805 RID: 14341 RVA: 0x0002537D File Offset: 0x0002357D
	// (set) Token: 0x06003804 RID: 14340 RVA: 0x00025374 File Offset: 0x00023574
	public bool bGreenWord { get; set; }

	// Token: 0x06003806 RID: 14342 RVA: 0x00102F38 File Offset: 0x00101138
	protected override void vmethod_0()
	{
		base.vmethod_0();
		this.mcSelf = this.displayObjectContainer_0 as MovieClip;
		if (this.mcSelf == null)
		{
			DebugUtils.LogWarning(LogCategory.GUI, "UIWarning: Button onConfiUI() 'controlMC' is null! UIComponent won't work!!!");
			return;
		}
		this.mcSelf.stop();
		this.mcXPBar = this.mcSelf.getChildByName<MovieClip>("xpbar");
		this.mcLevelUp = this.mcSelf.getChildByName<MovieClip>("mcLevelUp");
		this.isAnimationDone = true;
		if (this.mcLevelUp != null)
		{
			this.mcLevelUp.visible = false;
			this.mcLevelUp.stop();
			this.mcLevelUp.addFrameScript("end", new EventDispatcher.EventCallback(this.method_5));
		}
		if (this.mcXPBar != null)
		{
			this.mcLevelInfo = this.mcXPBar.getChildByName<MovieClip>("levelInfo");
			this.mcLevelInfo.gotoAndStop("normal");
			this.mcLevelInfo.addFrameScript("end", new EventDispatcher.EventCallback(this.method_6));
			this.mcLevelInfoLevel = this.mcLevelInfo.getChildByName<MovieClip>("level");
			UnityTextField childByName = this.mcLevelInfoLevel.getChildByName<UnityTextField>("level");
			childByName.text = this.method_9(this._iLevel);
			if (this.bGreenWord)
			{
				childByName.Color_0 = Color.green;
			}
		}
	}

	// Token: 0x06003807 RID: 14343 RVA: 0x00025385 File Offset: 0x00023585
	protected void method_5(CEvent cevent_0)
	{
		this.mcLevelUp.visible = false;
		this.isAnimationDone = true;
		if (this.mcLevelInfo != null)
		{
			this.mcLevelInfo.gotoAndPlay("levelup");
		}
	}

	// Token: 0x06003808 RID: 14344 RVA: 0x00103084 File Offset: 0x00101284
	protected void method_6(CEvent cevent_0)
	{
		this.mcLevelInfo.gotoAndStop("normal");
		this.mcLevelInfoLevel = this.mcLevelInfo.getChildByName<MovieClip>("level");
		UnityTextField childByName = this.mcLevelInfoLevel.getChildByName<UnityTextField>("level");
		childByName.text = this.method_9(this._iLevel);
		if (this.bGreenWord)
		{
			childByName.Color_0 = Color.green;
		}
	}

	// Token: 0x06003809 RID: 14345 RVA: 0x001030F0 File Offset: 0x001012F0
	public void method_7(int int_0, int int_1)
	{
		if (this.mcXPBar != null)
		{
			int num = (int)Math.Ceiling(100.0 * (double)int_0 / (double)int_1);
			num = Math.Max(1, num);
			this.mcXPBar.gotoAndStop(num);
		}
	}

	// Token: 0x0600380A RID: 14346 RVA: 0x00103134 File Offset: 0x00101334
	public void method_8(int int_0, string string_1)
	{
		if (this.mcLevelInfo == null)
		{
			return;
		}
		this.mcLevelInfoLevel = this.mcLevelInfo.getChildByName<MovieClip>("level");
		if (this.mcLevelInfoLevel == null)
		{
			return;
		}
		UnityTextField unityTextField = this.mcLevelInfoLevel.getChildByName<UnityTextField>("level");
		if (unityTextField != null && this.isAnimationDone)
		{
			unityTextField.text = this.method_9(int_0);
			if (this.bGreenWord)
			{
				unityTextField.Color_0 = Color.green;
			}
		}
		unityTextField = this.mcXPBar.getChildByName<UnityTextField>("playername");
		if (unityTextField != null)
		{
			unityTextField.text = string_1;
		}
	}

	// Token: 0x0600380B RID: 14347 RVA: 0x001031C0 File Offset: 0x001013C0
	private string method_9(int int_0)
	{
		StringBuilder stringBuilder = new StringBuilder("Lv.");
		if (int_0 < 10)
		{
			stringBuilder.Append("  ");
		}
		stringBuilder.Append(int_0);
		return stringBuilder.ToString();
	}

	// Token: 0x0600380C RID: 14348 RVA: 0x001031F8 File Offset: 0x001013F8
	public void method_10(int int_0)
	{
		this._iLevel = int_0;
		if (this.mcLevelUp != null)
		{
			this.mcLevelUp.visible = true;
			this.isAnimationDone = false;
			this.mcLevelUp.gotoAndPlay("start");
		}
		if (this.mcXPBar != null)
		{
			this.mcXPBar.gotoAndPlay("shine");
		}
	}

	// Token: 0x0400270E RID: 9998
	protected MovieClip mcSelf;

	// Token: 0x0400270F RID: 9999
	protected MovieClip mcXPBar;

	// Token: 0x04002710 RID: 10000
	protected MovieClip mcLevelUp;

	// Token: 0x04002711 RID: 10001
	protected MovieClip mcLevelInfo;

	// Token: 0x04002712 RID: 10002
	protected MovieClip mcLevelInfoLevel;

	// Token: 0x04002713 RID: 10003
	protected int _iLevel;

	// Token: 0x04002714 RID: 10004
	protected bool isAnimationDone;
}
