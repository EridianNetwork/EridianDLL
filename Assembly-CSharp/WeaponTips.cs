using System;
using ns0;
using pumpkin.display;

// Token: 0x020007C4 RID: 1988
public class WeaponTips : GClass62
{
	// Token: 0x06003551 RID: 13649 RVA: 0x00023041 File Offset: 0x00021241
	public WeaponTips(WeaponDNA weaponDNA_0)
	{
		this._showItem = weaponDNA_0;
	}

	// Token: 0x06003552 RID: 13650 RVA: 0x000F1F44 File Offset: 0x000F0144
	public override DisplayObject vmethod_0()
	{
		if (WeaponTips._weaponCardPanel == null)
		{
			WeaponTips.smethod_0();
			return null;
		}
		if (this._showItem == null)
		{
			return null;
		}
		ItemDNA itemDNA = MonoSingleton<AppManager>.Instance.method_0().vmethod_5<CharInfoView>().vmethod_7();
		WeaponTips._weaponCardPanel.vmethod_4(this._showItem, (itemDNA != null) ? itemDNA.method_6() : null);
		return WeaponTips._weaponCardPanel.DisplayObjectContainer_0;
	}

	// Token: 0x06003553 RID: 13651 RVA: 0x00023050 File Offset: 0x00021250
	public static void smethod_0()
	{
		(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_45("Weapon_card.swf", "Panel_SWC_No_Anim", new FuncLoad(WeaponTips.smethod_1));
	}

	// Token: 0x06003554 RID: 13652 RVA: 0x0002307C File Offset: 0x0002127C
	private static void smethod_1(MovieClip movieClip_0)
	{
		WeaponTips._weaponCardPanel = new SmallWeaponCardNoAnimation();
		WeaponTips._weaponCardPanel.method_0(movieClip_0);
	}

	// Token: 0x040024C7 RID: 9415
	protected static SmallWeaponCardNoAnimation _weaponCardPanel;

	// Token: 0x040024C8 RID: 9416
	public WeaponDNA _showItem;
}
