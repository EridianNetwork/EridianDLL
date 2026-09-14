using System;
using Core;
using ns0;
using UnityEngine;
using XsdSettings;

// Token: 0x020006AF RID: 1711
public class HUDPlayerInfoView : BaseView
{
	// Token: 0x06002CE3 RID: 11491 RVA: 0x000D34D0 File Offset: 0x000D16D0
	public override void OnTestGUI()
	{
		GUI.TextField(new Rect(20f, 630f, 200f, 25f), string.Concat(new object[] { "Health:", this._iCurHealth, " / ", this._iMaxHealth }));
		GUI.TextField(new Rect(20f, 600f, 200f, 25f), string.Concat(new object[] { "Shield:", this._iCurShield, " / ", this._iMaxShield }));
		GUI.TextField(new Rect(580f, 600f, 200f, 25f), string.Concat(new object[] { "Exp:", this._iCurExp, " / ", this._iMaxExp }));
		GUI.TextField(new Rect(1000f, 630f, 200f, 25f), string.Concat(new object[] { "Ammo:", this._iCurBullets, " / ", this._iMaxBullets }));
		GUI.TextField(new Rect(1000f, 600f, 200f, 25f), "Weapon Type:" + this._curWeaponType);
	}

	// Token: 0x17000237 RID: 567
	// (get) Token: 0x06002CE4 RID: 11492 RVA: 0x0001DC26 File Offset: 0x0001BE26
	// (set) Token: 0x06002CE5 RID: 11493 RVA: 0x0001DC2E File Offset: 0x0001BE2E
	public bool bAlwaysShowWeaponSlot { get; set; }

	// Token: 0x17000238 RID: 568
	// (get) Token: 0x06002CE7 RID: 11495 RVA: 0x0001DC40 File Offset: 0x0001BE40
	// (set) Token: 0x06002CE6 RID: 11494 RVA: 0x0001DC37 File Offset: 0x0001BE37
	public virtual bool bPVPDisp { get; set; }

	// Token: 0x06002CE8 RID: 11496 RVA: 0x0001DC48 File Offset: 0x0001BE48
	public override void vmethod_2()
	{
		base.vmethod_2();
		MonoSingleton<AppManager>.Instance.method_0().method_4(this);
	}

	// Token: 0x06002CE9 RID: 11497 RVA: 0x0001DC60 File Offset: 0x0001BE60
	public override void vmethod_3()
	{
		base.vmethod_3();
		MonoSingleton<AppManager>.Instance.method_0().method_5(this);
	}

	// Token: 0x06002CEA RID: 11498 RVA: 0x0001DC78 File Offset: 0x0001BE78
	public virtual void vmethod_5(int int_0, int int_1)
	{
		this._iCurShield = int_0;
		this._iMaxShield = int_1;
	}

	// Token: 0x06002CEB RID: 11499 RVA: 0x0001DC88 File Offset: 0x0001BE88
	public virtual void vmethod_6(int int_0, int int_1)
	{
		this._iCurHealth = int_0;
		this._iMaxHealth = int_1;
	}

	// Token: 0x06002CEC RID: 11500 RVA: 0x0001DC98 File Offset: 0x0001BE98
	public virtual void vmethod_7(int int_0, int int_1)
	{
		this._iCurExp = int_0;
		this._iMaxExp = int_1;
	}

	// Token: 0x06002CED RID: 11501 RVA: 0x0001DCA8 File Offset: 0x0001BEA8
	public virtual void vmethod_8(int int_0, int int_1, int int_2, WeaponType weaponType_0)
	{
		this._iCurBullets = ((int_0 >= 0) ? int_0 : 0);
		this._iClipBullets = int_1;
		this._iMaxBullets = int_2;
		this._curWeaponType = weaponType_0;
	}

	// Token: 0x06002CEE RID: 11502 RVA: 0x0001DCCE File Offset: 0x0001BECE
	public virtual void vmethod_9(int int_0, int int_1)
	{
		this._iCurGrenades = int_0;
		this._iMaxGrenades = int_1;
	}

	// Token: 0x06002CEF RID: 11503 RVA: 0x0001DCDE File Offset: 0x0001BEDE
	public virtual void vmethod_10(string string_0)
	{
		this._strName = string_0;
	}

	// Token: 0x06002CF0 RID: 11504 RVA: 0x0001DCE7 File Offset: 0x0001BEE7
	public virtual void vmethod_11(int int_0)
	{
		this._iLevel = int_0;
	}

	// Token: 0x06002CF1 RID: 11505 RVA: 0x0001DCE7 File Offset: 0x0001BEE7
	public virtual void vmethod_12(int int_0)
	{
		this._iLevel = int_0;
	}

	// Token: 0x06002CF2 RID: 11506 RVA: 0x0001DCF0 File Offset: 0x0001BEF0
	public virtual void vmethod_13(AvatarType avatarType_0)
	{
		this._playerClass = avatarType_0;
	}

	// Token: 0x06002CF3 RID: 11507 RVA: 0x0001DCF9 File Offset: 0x0001BEF9
	public virtual void vmethod_14(int int_0, int int_1)
	{
		DebugUtils.LogError(LogCategory.GUI, string.Concat(new object[] { "Money changed: ", int_0, " Total money left:", int_1 }));
	}

	// Token: 0x06002CF4 RID: 11508 RVA: 0x0000311B File Offset: 0x0000131B
	public virtual void vmethod_15(bool bool_0)
	{
	}

	// Token: 0x06002CF5 RID: 11509 RVA: 0x0000311B File Offset: 0x0000131B
	public virtual void vmethod_16(WeaponDNA weaponDNA_0, WeaponDNA weaponDNA_1)
	{
	}

	// Token: 0x06002CF6 RID: 11510 RVA: 0x0000311B File Offset: 0x0000131B
	public virtual void vmethod_17(bool bool_0)
	{
	}

	// Token: 0x06002CF7 RID: 11511 RVA: 0x0001DD2E File Offset: 0x0001BF2E
	protected void method_3(InventoryServiceWrapper.InventoryUpdateType inventoryUpdateType_0)
	{
		if (inventoryUpdateType_0 == InventoryServiceWrapper.InventoryUpdateType.ChangeActiveWeapon)
		{
			this.vmethod_17(true);
		}
	}

	// Token: 0x04001F8F RID: 8079
	protected int _iCurHealth;

	// Token: 0x04001F90 RID: 8080
	protected int _iMaxHealth;

	// Token: 0x04001F91 RID: 8081
	protected int _iCurShield;

	// Token: 0x04001F92 RID: 8082
	protected int _iMaxShield;

	// Token: 0x04001F93 RID: 8083
	protected int _iCurExp;

	// Token: 0x04001F94 RID: 8084
	protected int _iMaxExp;

	// Token: 0x04001F95 RID: 8085
	protected int _iCurBullets;

	// Token: 0x04001F96 RID: 8086
	protected int _iClipBullets;

	// Token: 0x04001F97 RID: 8087
	protected int _iMaxBullets;

	// Token: 0x04001F98 RID: 8088
	protected int _iCurGrenades;

	// Token: 0x04001F99 RID: 8089
	protected int _iMaxGrenades;

	// Token: 0x04001F9A RID: 8090
	protected WeaponType _curWeaponType;

	// Token: 0x04001F9B RID: 8091
	protected int _iLevel;

	// Token: 0x04001F9C RID: 8092
	protected string _strName = string.Empty;

	// Token: 0x04001F9D RID: 8093
	protected AvatarType _playerClass = AvatarType.TOTAL;
}
