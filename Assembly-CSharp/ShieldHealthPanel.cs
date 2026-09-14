using System;
using System.Collections.Generic;
using Core;
using ns0;
using pumpkin.display;
using pumpkin.events;
using UnityEngine;
using XsdSettings;

// Token: 0x0200081A RID: 2074
public class ShieldHealthPanel : GClass51
{
	// Token: 0x06003816 RID: 14358 RVA: 0x00103C0C File Offset: 0x00101E0C
	public ShieldHealthPanel()
	{
		this._dicFrameKeyTypeMap = new Dictionary<AvatarType, string>
		{
			{
				AvatarType.SIREN,
				"SIREN"
			},
			{
				AvatarType.SOLDIER,
				"SOLDIER"
			},
			{
				AvatarType.BERSERKER,
				"BERSERKER"
			},
			{
				AvatarType.HUNTER,
				"HUNTER"
			},
			{
				AvatarType.TOTAL,
				"SOLDIER"
			}
		};
	}

	// Token: 0x170002FF RID: 767
	// (get) Token: 0x06003818 RID: 14360 RVA: 0x000253E8 File Offset: 0x000235E8
	// (set) Token: 0x06003817 RID: 14359 RVA: 0x000253DF File Offset: 0x000235DF
	public bool bGreenWord { get; set; }

	// Token: 0x17000300 RID: 768
	// (get) Token: 0x0600381A RID: 14362 RVA: 0x00025413 File Offset: 0x00023613
	// (set) Token: 0x06003819 RID: 14361 RVA: 0x000253F0 File Offset: 0x000235F0
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
				if (value)
				{
					GroupManager.smethod_0().method_16();
				}
			}
		}
	}

	// Token: 0x0600381B RID: 14363 RVA: 0x00103CA4 File Offset: 0x00101EA4
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
		this.mcHealthIcon = this.mcSelf.getChildByName<MovieClip>("health_icon");
		this.mcHealthBar = this.mcSelf.getChildByName<MovieClip>("health");
		this.mcShieldBar = this.mcSelf.getChildByName<MovieClip>("shield");
		if (this.mcHealthIcon != null)
		{
			this.mcHealthIcon.stop();
		}
		if (this.mcHealthBar != null)
		{
			this.mcHealthBar.addFrameScript(this.mcHealthBar.totalFrames, new EventDispatcher.EventCallback(this.method_9));
			MovieClip childByName = this.mcHealthBar.getChildByName<MovieClip>("flash");
			if (childByName != null)
			{
				childByName.stop();
			}
		}
		if (this.mcShieldBar != null)
		{
			this.mcShieldBar.addFrameScript(this.mcShieldBar.totalFrames, new EventDispatcher.EventCallback(this.method_10));
			MovieClip childByName2 = this.mcShieldBar.getChildByName<MovieClip>("flash");
			if (childByName2 != null)
			{
				childByName2.stop();
			}
		}
		this.mc_Captain = this.mcSelf.getChildByName<MovieClip>("character");
	}

	// Token: 0x0600381C RID: 14364 RVA: 0x00103DE8 File Offset: 0x00101FE8
	public void method_5(int int_0, int int_1)
	{
		if (this.mcHealthBar == null)
		{
			return;
		}
		if (int_0 == 0)
		{
			this.mcHealthBar.gotoAndStop(101);
		}
		else
		{
			int num = (int)Math.Ceiling(100.0 * (double)int_0 / (double)int_1);
			this.mcHealthBar.gotoAndStop(101 - num);
		}
		UnityTextField childByName = this.mcHealthBar.getChildByName<UnityTextField>("health_disp");
		if (childByName != null)
		{
			childByName.text = Utility.smethod_8(int_0);
			if (this.bGreenWord)
			{
				childByName.Color_0 = Color.green;
			}
		}
	}

	// Token: 0x0600381D RID: 14365 RVA: 0x00103E74 File Offset: 0x00102074
	public void method_6(int int_0, int int_1)
	{
		if (this.mcShieldBar == null)
		{
			return;
		}
		if (int_0 == 0)
		{
			this.mcShieldBar.gotoAndStop(101);
		}
		else
		{
			int num = (int)Math.Ceiling(100.0 * (double)int_0 / (double)int_1);
			this.mcShieldBar.gotoAndStop(101 - num);
		}
		UnityTextField childByName = this.mcShieldBar.getChildByName<UnityTextField>("shield_disp");
		if (childByName != null)
		{
			childByName.text = Utility.smethod_8(int_0);
			if (this.bGreenWord)
			{
				childByName.Color_0 = Color.green;
			}
		}
	}

	// Token: 0x0600381E RID: 14366 RVA: 0x0002542A File Offset: 0x0002362A
	public void method_7(AvatarType avatarType_0)
	{
		if (this.mcCharacter != null)
		{
			this.mcCharacter.gotoAndStop(this._dicFrameKeyTypeMap[avatarType_0]);
		}
	}

	// Token: 0x0600381F RID: 14367 RVA: 0x0002544B File Offset: 0x0002364B
	public void method_8(bool bool_0)
	{
		if (this.mc_Captain != null && this.mc_Captain.visible != bool_0)
		{
			this.mc_Captain.visible = bool_0;
		}
	}

	// Token: 0x06003820 RID: 14368 RVA: 0x00103F00 File Offset: 0x00102100
	private void method_9(CEvent cevent_0)
	{
		MovieClip childByName = this.mcHealthBar.getChildByName<MovieClip>("flash");
		if (childByName != null)
		{
			childByName.gotoAndPlay("go");
		}
	}

	// Token: 0x06003821 RID: 14369 RVA: 0x00103F2C File Offset: 0x0010212C
	private void method_10(CEvent cevent_0)
	{
		MovieClip childByName = this.mcShieldBar.getChildByName<MovieClip>("flash");
		if (childByName != null)
		{
			childByName.gotoAndPlay("go");
		}
	}

	// Token: 0x04002732 RID: 10034
	protected MovieClip mcSelf;

	// Token: 0x04002733 RID: 10035
	protected MovieClip mcHealthIcon;

	// Token: 0x04002734 RID: 10036
	protected MovieClip mcHealthBar;

	// Token: 0x04002735 RID: 10037
	protected MovieClip mcShieldBar;

	// Token: 0x04002736 RID: 10038
	protected MovieClip mcCharacter;

	// Token: 0x04002737 RID: 10039
	protected MovieClip mc_Captain;

	// Token: 0x04002738 RID: 10040
	protected Dictionary<AvatarType, string> _dicFrameKeyTypeMap;

	// Token: 0x04002739 RID: 10041
	protected string[] TYPR_FRAME_MAP = new string[] { "none", "full", "open", "smash", "picked up", "reload" };
}
