using System;
using ns0;
using pumpkin.display;
using XsdSettings;

// Token: 0x020007CA RID: 1994
public class ItemTips : GClass62
{
	// Token: 0x0600356C RID: 13676 RVA: 0x00023133 File Offset: 0x00021333
	public ItemTips(ItemDNA itemDNA_0)
	{
		this._showItem = itemDNA_0;
	}

	// Token: 0x0600356D RID: 13677 RVA: 0x000F42B0 File Offset: 0x000F24B0
	public override DisplayObject vmethod_0()
	{
		if (ItemTips._cardPanel == null)
		{
			ItemTips.smethod_0();
			return null;
		}
		MonoSingleton<AppManager>.Instance.method_0().vmethod_5<InventoryView>().method_3(this._showItem);
		ItemDNA itemDNA = null;
		ItemType type = this._showItem.m_type;
		switch (type)
		{
		case ItemType.Weapon:
			itemDNA = MonoSingleton<AppManager>.Instance.method_0().vmethod_5<CharInfoView>().vmethod_7();
			goto IL_0099;
		case ItemType.Shield:
			itemDNA = MonoSingleton<AppManager>.Instance.method_0().vmethod_5<CharInfoView>().method_3();
			goto IL_0099;
		}
		if (type == ItemType.ClassMode)
		{
			itemDNA = MonoSingleton<AppManager>.Instance.method_0().vmethod_5<CharInfoView>().method_4();
		}
		IL_0099:
		ItemTips._cardPanel.vmethod_3(this._showItem, itemDNA);
		return ItemTips._cardPanel.DisplayObjectContainer_0;
	}

	// Token: 0x0600356E RID: 13678 RVA: 0x000F4374 File Offset: 0x000F2574
	public static void smethod_0()
	{
		if (MonoSingleton<AppManager>.Instance == null)
		{
			return;
		}
		if (MonoSingleton<AppManager>.Instance.method_0() == null)
		{
			return;
		}
		UniUIManager uniUIManager = MonoSingleton<AppManager>.Instance.method_0() as UniUIManager;
		if (uniUIManager == null)
		{
			return;
		}
		uniUIManager.method_45("Tips.swf", "Panel_Tips_Card", new FuncLoad(ItemTips.smethod_2));
	}

	// Token: 0x0600356F RID: 13679 RVA: 0x000F43D8 File Offset: 0x000F25D8
	public static void smethod_1()
	{
		ItemTips._cardPanel = null;
		if (MonoSingleton<AppManager>.Instance == null)
		{
			return;
		}
		if (MonoSingleton<AppManager>.Instance.method_0() == null)
		{
			return;
		}
		UniUIManager uniUIManager = MonoSingleton<AppManager>.Instance.method_0() as UniUIManager;
		if (uniUIManager == null)
		{
			return;
		}
		uniUIManager.method_48("Tips.swf");
	}

	// Token: 0x06003570 RID: 13680 RVA: 0x00023142 File Offset: 0x00021342
	private static void smethod_2(MovieClip movieClip_0)
	{
		ItemTips._cardPanel = new ItemCardPanel();
		ItemTips._cardPanel.method_0(new MovieClip());
		ItemTips._cardPanel.vmethod_2(movieClip_0);
	}

	// Token: 0x06003571 RID: 13681 RVA: 0x00023169 File Offset: 0x00021369
	public override void OnPositionAdjusted(GClass24 tipsOrin, bool bRightExpend)
	{
		if (ItemTips._cardPanel != null)
		{
			ItemTips._cardPanel.method_6(bRightExpend);
		}
	}

	// Token: 0x06003572 RID: 13682 RVA: 0x0002317D File Offset: 0x0002137D
	public override void OnClean()
	{
		MonoSingleton<AppManager>.Instance.method_0().vmethod_5<InventoryView>().method_3(null);
		if (ItemTips._cardPanel != null)
		{
			ItemTips._cardPanel.method_5();
		}
	}

	// Token: 0x04002507 RID: 9479
	protected static ItemCardPanel _cardPanel;

	// Token: 0x04002508 RID: 9480
	protected ItemDNA _showItem;
}
