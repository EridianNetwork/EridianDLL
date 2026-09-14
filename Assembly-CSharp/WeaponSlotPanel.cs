using System;
using Core;
using ns0;
using pumpkin.display;
using pumpkin.events;

// Token: 0x02000817 RID: 2071
public class WeaponSlotPanel : GClass51
{
	// Token: 0x170002FC RID: 764
	// (get) Token: 0x060037FB RID: 14331 RVA: 0x0002530A File Offset: 0x0002350A
	// (set) Token: 0x060037FA RID: 14330 RVA: 0x00102C8C File Offset: 0x00100E8C
	public virtual bool Boolean_0
	{
		get
		{
			return this.mcSelf != null && this._bVisible;
		}
		set
		{
			if (this.mcSelf == null)
			{
				return;
			}
			if (this._bVisible == value)
			{
				return;
			}
			this._bVisible = value;
			if (value)
			{
				this.mcSelf.visible = value;
				this.mcSelf.gotoAndPlay("in");
			}
			else
			{
				this.mcSelf.gotoAndPlay("out");
				this.mcSelf.addFrameScript("end", new EventDispatcher.EventCallback(this.method_6));
			}
		}
	}

	// Token: 0x060037FC RID: 14332 RVA: 0x00102D04 File Offset: 0x00100F04
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
		this.mcSelf.visible = false;
	}

	// Token: 0x060037FD RID: 14333 RVA: 0x00102D54 File Offset: 0x00100F54
	protected override bool OnWidgetInitialized(ref MovieClip movieClip, Type widgetType)
	{
		if (movieClip.name.Length > "mcSlot".Length)
		{
			string text = movieClip.name.Substring(0, "mcSlot".Length);
			if (text == "mcSlot")
			{
				int num = Convert.ToInt32(movieClip.name.Substring("mcSlot".Length, movieClip.name.Length - "mcSlot".Length));
				if (num < this._arrWeaponSlots.Length && num >= 0)
				{
					movieClip.addEventListener(CEvent.ENTER_FRAME, new EventDispatcher.EventCallback(this.method_5));
					movieClip.userData = num;
					this._arrWeaponSlots[num] = movieClip;
					return true;
				}
				DebugUtils.LogWarning(LogCategory.GUI, string.Concat(new object[]
				{
					"Hud weapon slot name wrong! Index:",
					num,
					" is bigger than sum: ",
					this._arrWeaponSlots.Length
				}));
				return true;
			}
		}
		return false;
	}

	// Token: 0x060037FE RID: 14334 RVA: 0x00102E58 File Offset: 0x00101058
	protected void method_5(CEvent cevent_0)
	{
		MovieClip movieClip = cevent_0.currentTarget as MovieClip;
		if (movieClip != null)
		{
			int num = (int)movieClip.userData;
			UnityTextField childByName = movieClip.getChildByName<UnityTextField>("textField");
			if (childByName != null)
			{
				childByName.text = Utility.smethod_8(num + 1);
			}
			if (this._arrWeapons != null && this._arrWeapons[num] != null)
			{
				MovieClip childByName2 = movieClip.getChildByName<MovieClip>("mcIcon");
				if (childByName2 != null)
				{
					childByName2.gotoAndStop(this._arrWeapons[num].method_6().method_1().ToString());
				}
			}
		}
	}

	// Token: 0x060037FF RID: 14335 RVA: 0x0002531C File Offset: 0x0002351C
	private void method_6(CEvent cevent_0)
	{
		this.mcSelf.removeFrameScript("end", new EventDispatcher.EventCallback(this.method_6));
		this.mcSelf.visible = false;
	}

	// Token: 0x06003800 RID: 14336 RVA: 0x00102EE0 File Offset: 0x001010E0
	public void Update(ItemDNA[] arrWeapons, int activeIndex)
	{
		this._arrWeapons = arrWeapons;
		if (this._arrWeapons != null)
		{
			for (int i = 0; i < 4; i++)
			{
				string text = "none";
				if (this._arrWeapons[i] != null)
				{
					text = ((i != activeIndex) ? "normal" : "actived");
				}
				this._arrWeaponSlots[i].gotoAndStop(text);
			}
		}
	}

	// Token: 0x04002706 RID: 9990
	protected const string WEAPON_SLOT_PREFIX_NAME = "mcSlot";

	// Token: 0x04002707 RID: 9991
	protected MovieClip mcRoot;

	// Token: 0x04002708 RID: 9992
	protected MovieClip mcSelf;

	// Token: 0x04002709 RID: 9993
	protected UnityTextField tfSlotNumber;

	// Token: 0x0400270A RID: 9994
	protected MovieClip[] _arrWeaponSlots = new MovieClip[4];

	// Token: 0x0400270B RID: 9995
	protected ItemDNA[] _arrWeapons;

	// Token: 0x0400270C RID: 9996
	protected int _iLevel;

	// Token: 0x0400270D RID: 9997
	protected bool _bVisible;
}
