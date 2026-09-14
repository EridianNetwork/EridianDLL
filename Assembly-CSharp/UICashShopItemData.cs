using System;
using System.Runtime.CompilerServices;

// Token: 0x02000664 RID: 1636
public class UICashShopItemData
{
	// Token: 0x1400000B RID: 11
	// (add) Token: 0x0600293B RID: 10555 RVA: 0x0001B085 File Offset: 0x00019285
	// (remove) Token: 0x0600293C RID: 10556 RVA: 0x0001B09E File Offset: 0x0001929E
	public event UICashShopItemData.OnSelectedEventHandler Event_0
	{
		[MethodImpl(MethodImplOptions.Synchronized)]
		add
		{
			this.OnSelected = (UICashShopItemData.OnSelectedEventHandler)Delegate.Combine(this.OnSelected, value);
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		remove
		{
			this.OnSelected = (UICashShopItemData.OnSelectedEventHandler)Delegate.Remove(this.OnSelected, value);
		}
	}

	// Token: 0x1700020B RID: 523
	// (get) Token: 0x0600293D RID: 10557 RVA: 0x0001B0B7 File Offset: 0x000192B7
	// (set) Token: 0x0600293E RID: 10558 RVA: 0x0001B0BF File Offset: 0x000192BF
	public bool Boolean_0
	{
		get
		{
			return this._selected;
		}
		set
		{
			if (this._selected == value)
			{
				return;
			}
			this._selected = value;
			if (this._selected && this.OnSelected != null)
			{
				this.OnSelected(this);
			}
		}
	}

	// Token: 0x04001D86 RID: 7558
	public OfferItem offerItem;

	// Token: 0x04001D87 RID: 7559
	public CashItem cashItem;

	// Token: 0x04001D88 RID: 7560
	private bool _selected;

	// Token: 0x04001D89 RID: 7561
	private UICashShopItemData.OnSelectedEventHandler OnSelected;

	// Token: 0x02000665 RID: 1637
	public enum ClassTypeEnum
	{
		// Token: 0x04001D8B RID: 7563
		SOLDIER = 1,
		// Token: 0x04001D8C RID: 7564
		HUNTER,
		// Token: 0x04001D8D RID: 7565
		SIREN = 4,
		// Token: 0x04001D8E RID: 7566
		BERSERKER = 8,
		// Token: 0x04001D8F RID: 7567
		ALL = 15
	}

	// Token: 0x02000666 RID: 1638
	public enum CurrencyEnum
	{
		// Token: 0x04001D91 RID: 7569
		MIDDLE_CURRENCY = 1,
		// Token: 0x04001D92 RID: 7570
		SHANDA_POINT
	}

	// Token: 0x02000667 RID: 1639
	// (Invoke) Token: 0x06002940 RID: 10560
	public delegate void OnSelectedEventHandler(UICashShopItemData cashItemData);
}
