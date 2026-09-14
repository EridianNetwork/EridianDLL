using System;
using System.Collections.Generic;
using Core;
using ns0;
using pumpkin.display;
using pumpkin.events;
using pumpkin.text;
using XsdSettings;

// Token: 0x020006B0 RID: 1712
public class uniHUDPlayerInfoView : HUDPlayerInfoView
{
	// Token: 0x06002CF9 RID: 11513 RVA: 0x0000311B File Offset: 0x0000131B
	public override void OnTestGUI()
	{
	}

	// Token: 0x17000239 RID: 569
	// (get) Token: 0x06002CFB RID: 11515 RVA: 0x0001DD74 File Offset: 0x0001BF74
	// (set) Token: 0x06002CFA RID: 11514 RVA: 0x0001DD43 File Offset: 0x0001BF43
	public override bool bPVPDisp
	{
		get
		{
			return base.bPVPDisp;
		}
		set
		{
			base.bPVPDisp = value;
			if (this.mcPlayerInfo != null)
			{
				this.mcPlayerInfo.bGreenWord = value;
			}
			if (this.mcLevelInfo != null)
			{
				this.mcLevelInfo.bGreenWord = value;
			}
		}
	}

	// Token: 0x06002CFC RID: 11516 RVA: 0x000D366C File Offset: 0x000D186C
	public override void vmethod_2()
	{
		base.vmethod_2();
		(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_45("PlayerInfoBar.swf", "ScreenPanel", new FuncLoad(this.method_5));
		(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_45("HUD.swf", "ScreenPanel", new FuncLoad(this.method_4));
		(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_45("HUD.swf", "Panel_WeaponSlot", new FuncLoad(this.method_7));
		(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_45("Weapon_card.swf", "Panel_SimpleWeaponCard", new FuncLoad(this.method_6));
	}

	// Token: 0x06002CFD RID: 11517 RVA: 0x000D3728 File Offset: 0x000D1928
	private void method_4(MovieClip movieClip_0)
	{
		this._rootPanel = new GClass51();
		movieClip_0.x = 0f;
		movieClip_0.y = 0f;
		this._rootPanel.method_3(movieClip_0, new GDelegate7(this.OnWidgetInitialized));
		(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_35(this._rootPanel);
	}

	// Token: 0x06002CFE RID: 11518 RVA: 0x000D378C File Offset: 0x000D198C
	private void method_5(MovieClip movieClip_0)
	{
		this._rootCharPanel = new GClass51();
		movieClip_0.x = 0f;
		movieClip_0.y = 0f;
		this._rootCharPanel.method_3(movieClip_0, new GDelegate7(this.OnWidgetInitialized));
		(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_35(this._rootCharPanel);
	}

	// Token: 0x06002CFF RID: 11519 RVA: 0x0001DD7C File Offset: 0x0001BF7C
	private void method_6(MovieClip movieClip_0)
	{
		this.mcWeaponCard = new SmallWeaponCardPanel();
		this.mcWeaponCard.method_0(movieClip_0);
		(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_35(this.mcWeaponCard);
	}

	// Token: 0x06002D00 RID: 11520 RVA: 0x0001DDB1 File Offset: 0x0001BFB1
	private void method_7(MovieClip movieClip_0)
	{
		this.mcWeaponSlotPanel = new WeaponSlotPanel();
		this.mcWeaponSlotPanel.method_0(movieClip_0);
		(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_35(this.mcWeaponSlotPanel);
	}

	// Token: 0x06002D01 RID: 11521 RVA: 0x000D37F0 File Offset: 0x000D19F0
	public override void vmethod_3()
	{
		base.vmethod_3();
		(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_37(this._rootCharPanel);
		(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_37(this._rootPanel);
		(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_37(this.mcWeaponCard);
		(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_37(this.mcWeaponSlotPanel);
		this.mcPlayerInfo = null;
		this.mcAmmoInfo = null;
		this._rootPanel = null;
		this._rootCharPanel = null;
		(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_48("PlayerInfoBar.swf");
		(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_48("HUD.swf");
		(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_48("Weapon_card.swf");
	}

	// Token: 0x06002D02 RID: 11522 RVA: 0x000D38D4 File Offset: 0x000D1AD4
	protected bool OnWidgetInitialized(ref MovieClip movieClip, Type widgetType)
	{
		bool flag = false;
		string name = movieClip.name;
		switch (name)
		{
		case "mcPlayerInfo":
			this.mcPlayerInfo = new ShieldHealthPanel();
			this.mcPlayerInfo.method_0(movieClip);
			if (this.mcPlayerInfo != null)
			{
				this.mcPlayerInfo.bGreenWord = this.bPVPDisp;
				this.mcPlayerInfo.method_6(this._iCurShield, this._iMaxShield);
				this.mcPlayerInfo.method_5(this._iCurHealth, this._iMaxHealth);
				this.mcPlayerInfo.method_7(this._playerClass);
			}
			flag = true;
			break;
		case "mcAmmo":
		{
			this.mcAmmoInfo = new uniHUDPlayerInfoView.AmmoPanel();
			MovieClip childByName = movieClip.getChildByName<MovieClip>("mcFilterBaker");
			if (childByName != null)
			{
				this.mcAmmoInfo.method_0(childByName);
				if (this.mcAmmoInfo != null)
				{
					this.mcAmmoInfo.method_5(this._iCurBullets, this._iClipBullets, this._iMaxBullets);
					this.mcAmmoInfo.method_7(this._curWeaponType);
					this.mcAmmoInfo.method_6(this._iCurGrenades, this._iMaxGrenades);
				}
			}
			flag = true;
			break;
		}
		case "mcExp":
			this.mcLevelInfo = new ExpLevelPanel();
			this.mcLevelInfo.method_0(movieClip);
			if (this.mcLevelInfo != null)
			{
				this.mcLevelInfo.bGreenWord = this.bPVPDisp;
				this.mcLevelInfo.method_7(this._iCurExp, this._iMaxExp);
				this.mcLevelInfo.method_8(this._iLevel, this._strName);
			}
			flag = true;
			break;
		}
		return flag;
	}

	// Token: 0x06002D03 RID: 11523 RVA: 0x000D3AA8 File Offset: 0x000D1CA8
	protected override void vmethod_1(bool bool_0, bool bool_1 = false)
	{
		base.vmethod_1(bool_0, bool_1);
		if (this._rootPanel != null)
		{
			this._rootPanel.DisplayObjectContainer_0.visible = this.Boolean_1;
		}
		if (this._rootCharPanel != null)
		{
			this._rootCharPanel.DisplayObjectContainer_0.visible = this.Boolean_1;
		}
		if (this.mcWeaponCard != null)
		{
			this.mcWeaponCard.DisplayObjectContainer_0.visible = this.Boolean_1;
		}
		if (this.mcWeaponSlotPanel != null && this.Boolean_1 && base.bAlwaysShowWeaponSlot)
		{
			this.mcWeaponSlotPanel.Boolean_0 = this.Boolean_1;
		}
	}

	// Token: 0x06002D04 RID: 11524 RVA: 0x000D3B40 File Offset: 0x000D1D40
	public override void vmethod_5(int int_0, int int_1)
	{
		bool flag = this._iCurShield != int_0 || this._iMaxShield != int_1;
		base.vmethod_5(int_0, int_1);
		if (flag && this.mcPlayerInfo != null)
		{
			this.mcPlayerInfo.method_6(this._iCurShield, this._iMaxShield);
		}
	}

	// Token: 0x06002D05 RID: 11525 RVA: 0x000D3B90 File Offset: 0x000D1D90
	public override void vmethod_6(int int_0, int int_1)
	{
		bool flag = this._iCurHealth != int_0 || this._iMaxHealth != int_1;
		base.vmethod_6(int_0, int_1);
		if (flag && this.mcPlayerInfo != null)
		{
			this.mcPlayerInfo.method_5(this._iCurHealth, this._iMaxHealth);
		}
	}

	// Token: 0x06002D06 RID: 11526 RVA: 0x000D3BE0 File Offset: 0x000D1DE0
	public override void vmethod_7(int int_0, int int_1)
	{
		bool flag = this._iCurExp != int_0 || this._iMaxExp != int_1;
		base.vmethod_7(int_0, int_1);
		if (flag && this.mcLevelInfo != null)
		{
			this.mcLevelInfo.method_7(this._iCurExp, this._iMaxExp);
		}
	}

	// Token: 0x06002D07 RID: 11527 RVA: 0x000D3C30 File Offset: 0x000D1E30
	public override void vmethod_8(int int_0, int int_1, int int_2, WeaponType weaponType_0)
	{
		bool flag = this._iCurBullets != int_0 || this._iMaxBullets != int_2 || this._iClipBullets != int_1;
		bool flag2 = this._curWeaponType != weaponType_0;
		base.vmethod_8(int_0, int_1, int_2, weaponType_0);
		if (this.mcAmmoInfo != null)
		{
			if (flag)
			{
				this.mcAmmoInfo.method_5(this._iCurBullets, this._iClipBullets, this._iMaxBullets);
			}
			if (flag2)
			{
				this.mcAmmoInfo.method_7(this._curWeaponType);
			}
		}
	}

	// Token: 0x06002D08 RID: 11528 RVA: 0x000D3CB4 File Offset: 0x000D1EB4
	public override void vmethod_9(int int_0, int int_1)
	{
		bool flag = this._iCurGrenades != int_0 || this._iMaxGrenades != int_1;
		base.vmethod_9(int_0, int_1);
		if (flag && this.mcAmmoInfo != null)
		{
			this.mcAmmoInfo.method_6(this._iCurGrenades, this._iMaxGrenades);
		}
	}

	// Token: 0x06002D09 RID: 11529 RVA: 0x0001DDE6 File Offset: 0x0001BFE6
	public override void vmethod_12(int int_0)
	{
		base.vmethod_12(int_0);
		if (this._bActive && this.mcLevelInfo != null)
		{
			this.mcLevelInfo.method_10(this._iLevel);
		}
		GClass61.GClass61_0.GInterface3_0.imethod_0(AudioEvents.smethod_0(AudioEventName.Chr_Shr_LevelUp));
	}

	// Token: 0x06002D0A RID: 11530 RVA: 0x0001DE25 File Offset: 0x0001C025
	public override void vmethod_10(string string_0)
	{
		base.vmethod_10(string_0);
		if (this._bActive && this.mcLevelInfo != null)
		{
			this.mcLevelInfo.method_8(this._iLevel, this._strName);
		}
	}

	// Token: 0x06002D0B RID: 11531 RVA: 0x0001DE55 File Offset: 0x0001C055
	public override void vmethod_11(int int_0)
	{
		base.vmethod_11(int_0);
		if (this._bActive && this.mcLevelInfo != null)
		{
			this.mcLevelInfo.method_8(this._iLevel, this._strName);
		}
	}

	// Token: 0x06002D0C RID: 11532 RVA: 0x000D3D04 File Offset: 0x000D1F04
	public override void vmethod_13(AvatarType avatarType_0)
	{
		bool flag = this._playerClass != avatarType_0;
		base.vmethod_13(avatarType_0);
		if (flag && this.mcPlayerInfo != null)
		{
			this.mcPlayerInfo.method_7(avatarType_0);
		}
	}

	// Token: 0x06002D0D RID: 11533 RVA: 0x0001DE85 File Offset: 0x0001C085
	public override void vmethod_15(bool bool_0)
	{
		base.vmethod_15(bool_0);
		if (this.mcPlayerInfo != null)
		{
			this.mcPlayerInfo.method_8(bool_0);
		}
	}

	// Token: 0x06002D0E RID: 11534 RVA: 0x0001DEA2 File Offset: 0x0001C0A2
	public override void vmethod_16(WeaponDNA weaponDNA_0, WeaponDNA weaponDNA_1)
	{
		base.vmethod_16(weaponDNA_0, weaponDNA_1);
		if (this._bActive && this.mcWeaponCard != null)
		{
			this.mcWeaponCard.vmethod_4(weaponDNA_0, weaponDNA_1);
		}
	}

	// Token: 0x06002D0F RID: 11535 RVA: 0x000D3D3C File Offset: 0x000D1F3C
	public override void vmethod_17(bool bool_0)
	{
		base.vmethod_17(bool_0);
		if (this._bActive && this.mcWeaponSlotPanel != null)
		{
			this.mcWeaponSlotPanel.Boolean_0 = bool_0 || base.bAlwaysShowWeaponSlot;
			this.mcWeaponSlotPanel.Update(MonoSingleton<AppManager>.Instance.method_0().vmethod_5<CharInfoView>().ItemDNA_0, MonoSingleton<AppManager>.Instance.method_0().vmethod_5<CharInfoView>().Int32_0);
		}
	}

	// Token: 0x04001FA0 RID: 8096
	private GClass51 _rootPanel;

	// Token: 0x04001FA1 RID: 8097
	private GClass51 _rootCharPanel;

	// Token: 0x04001FA2 RID: 8098
	private ShieldHealthPanel mcPlayerInfo;

	// Token: 0x04001FA3 RID: 8099
	private uniHUDPlayerInfoView.AmmoPanel mcAmmoInfo;

	// Token: 0x04001FA4 RID: 8100
	private ExpLevelPanel mcLevelInfo;

	// Token: 0x04001FA5 RID: 8101
	private SmallWeaponCardPanel mcWeaponCard;

	// Token: 0x04001FA6 RID: 8102
	private WeaponSlotPanel mcWeaponSlotPanel;

	// Token: 0x020006B1 RID: 1713
	private class AmmoPanel : GClass51
	{
		// Token: 0x06002D10 RID: 11536 RVA: 0x000D3DAC File Offset: 0x000D1FAC
		public AmmoPanel()
		{
			this.WEAPONTYPE_FRAME_MAP = new Dictionary<WeaponType, string>();
			this.WEAPONTYPE_FRAME_MAP.Add(WeaponType.SniperRifle, "sniper");
			this.WEAPONTYPE_FRAME_MAP.Add(WeaponType.ShotGun, "shotgun");
			this.WEAPONTYPE_FRAME_MAP.Add(WeaponType.SMG, "smg");
			this.WEAPONTYPE_FRAME_MAP.Add(WeaponType.RepeaterPistol, "repeater");
			this.WEAPONTYPE_FRAME_MAP.Add(WeaponType.CombatRifle, "smg");
			this.WEAPONTYPE_FRAME_MAP.Add(WeaponType.TOTAL, "none");
		}

		// Token: 0x1700023A RID: 570
		// (get) Token: 0x06002D12 RID: 11538 RVA: 0x0001DEDF File Offset: 0x0001C0DF
		// (set) Token: 0x06002D11 RID: 11537 RVA: 0x0001DEC9 File Offset: 0x0001C0C9
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

		// Token: 0x06002D13 RID: 11539 RVA: 0x000D3E30 File Offset: 0x000D2030
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
			this.mcBulletIcon = this.mcSelf.getChildByName<MovieClip>("bullet_icon");
			this.mcBulletBar = this.mcSelf.getChildByName<MovieClip>("bullets");
			this.tfBulletText = this.mcSelf.getChildByName<TextField>("bullet_c");
			this.tfMaxBulletText = this.mcSelf.getChildByName<TextField>("bullet_m");
			this.mcGrenadeIcon = this.mcSelf.getChildByName<MovieClip>("grenade_icon");
			this.mcGrenadeBar = this.mcSelf.getChildByName<MovieClip>("grenades");
			this.tfGrenadeText = this.mcSelf.getChildByName<TextField>("grenade_c");
			this.tfMaxGrenadeText = this.mcSelf.getChildByName<TextField>("grenade_m");
			if (this.mcBulletIcon != null)
			{
				this.mcBulletIcon.stop();
			}
			if (this.mcBulletBar != null)
			{
				this.mcBulletBar.stop();
				this.mcBulletBar.addFrameScript(this.mcBulletBar.totalFrames, new EventDispatcher.EventCallback(this.method_8));
				MovieClip childByName = this.mcBulletBar.getChildByName<MovieClip>("flash");
				if (childByName != null)
				{
					childByName.stop();
				}
			}
			if (this.tfBulletText != null)
			{
				this.tfBulletText.text = string.Empty;
			}
			if (this.tfMaxBulletText != null)
			{
				this.tfMaxBulletText.text = string.Empty;
			}
			if (this.mcGrenadeIcon != null)
			{
				this.mcGrenadeIcon.stop();
			}
			if (this.mcGrenadeBar != null)
			{
				this.mcGrenadeBar.stop();
			}
			if (this.tfGrenadeText != null)
			{
				this.tfGrenadeText.text = string.Empty;
			}
			if (this.tfMaxGrenadeText != null)
			{
				this.tfMaxGrenadeText.text = string.Empty;
			}
		}

		// Token: 0x06002D14 RID: 11540 RVA: 0x000D4014 File Offset: 0x000D2214
		public void method_5(int int_0, int int_1, int int_2)
		{
			if (this.mcBulletBar != null)
			{
				if (int_0 == 0)
				{
					this.mcBulletBar.gotoAndStop(100);
				}
				else
				{
					int num = (int)Math.Ceiling(100.0 * (double)int_0 / (double)int_1);
					this.mcBulletBar.gotoAndStop(101 - num);
				}
			}
			if (this.tfBulletText != null)
			{
				this.tfBulletText.text = Utility.smethod_8(int_0);
			}
			if (this.tfMaxBulletText != null)
			{
				this.tfMaxBulletText.text = Utility.smethod_8(int_2);
			}
		}

		// Token: 0x06002D15 RID: 11541 RVA: 0x000D409C File Offset: 0x000D229C
		public void method_6(int int_0, int int_1)
		{
			if (this.mcGrenadeBar != null)
			{
				if (int_0 == 0)
				{
					this.mcGrenadeBar.gotoAndStop(100);
				}
				else
				{
					int num = (int)Math.Ceiling(100.0 * (double)int_0 / (double)int_1);
					this.mcGrenadeBar.gotoAndStop(101 - num);
				}
			}
			if (this.tfGrenadeText != null)
			{
				this.tfGrenadeText.text = Utility.smethod_8(int_0);
			}
			if (this.tfMaxGrenadeText != null)
			{
				this.tfMaxGrenadeText.text = Utility.smethod_8(int_1);
			}
		}

		// Token: 0x06002D16 RID: 11542 RVA: 0x0001DEF6 File Offset: 0x0001C0F6
		public void method_7(WeaponType weaponType_0)
		{
			if (this.mcBulletIcon != null)
			{
				this.mcBulletIcon.gotoAndStop(this.WEAPONTYPE_FRAME_MAP[weaponType_0]);
			}
		}

		// Token: 0x06002D17 RID: 11543 RVA: 0x000D4124 File Offset: 0x000D2324
		private void method_8(CEvent cevent_0)
		{
			MovieClip childByName = this.mcBulletBar.getChildByName<MovieClip>("flash");
			if (childByName != null)
			{
				childByName.gotoAndPlay("go");
			}
		}

		// Token: 0x04001FA8 RID: 8104
		protected MovieClip mcSelf;

		// Token: 0x04001FA9 RID: 8105
		protected MovieClip mcBulletIcon;

		// Token: 0x04001FAA RID: 8106
		protected MovieClip mcBulletBar;

		// Token: 0x04001FAB RID: 8107
		protected TextField tfBulletText;

		// Token: 0x04001FAC RID: 8108
		protected TextField tfMaxBulletText;

		// Token: 0x04001FAD RID: 8109
		protected MovieClip mcGrenadeIcon;

		// Token: 0x04001FAE RID: 8110
		protected MovieClip mcGrenadeBar;

		// Token: 0x04001FAF RID: 8111
		protected TextField tfGrenadeText;

		// Token: 0x04001FB0 RID: 8112
		protected TextField tfMaxGrenadeText;

		// Token: 0x04001FB1 RID: 8113
		protected Dictionary<WeaponType, string> WEAPONTYPE_FRAME_MAP;
	}
}
