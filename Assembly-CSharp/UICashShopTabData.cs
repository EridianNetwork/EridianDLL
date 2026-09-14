using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x02000669 RID: 1641
public class UICashShopTabData
{
	// Token: 0x1400000C RID: 12
	// (add) Token: 0x06002945 RID: 10565 RVA: 0x0001B10B File Offset: 0x0001930B
	// (remove) Token: 0x06002946 RID: 10566 RVA: 0x0001B124 File Offset: 0x00019324
	public event UICashShopTabData.OnSelectedEventHandler Event_0
	{
		[MethodImpl(MethodImplOptions.Synchronized)]
		add
		{
			this.OnSelected = (UICashShopTabData.OnSelectedEventHandler)Delegate.Combine(this.OnSelected, value);
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		remove
		{
			this.OnSelected = (UICashShopTabData.OnSelectedEventHandler)Delegate.Remove(this.OnSelected, value);
		}
	}

	// Token: 0x06002947 RID: 10567 RVA: 0x000C2A20 File Offset: 0x000C0C20
	public List<UICashShopItemData> method_0(List<UICashShopItemData> list_0)
	{
		this.method_1();
		this.listItemsExceptSelection.Clear();
		if (this._stackFilter.Count > 0)
		{
			this.listItemsExceptSelection = this.method_5(list_0);
		}
		else
		{
			this.listItemsExceptSelection = list_0;
		}
		this.listItems = this.listItemsExceptSelection;
		foreach (UICashShopItemData uicashShopItemData in this.listSelection)
		{
			this.listItems.Add(uicashShopItemData);
		}
		return this.listItems;
	}

	// Token: 0x06002948 RID: 10568 RVA: 0x000C2AC0 File Offset: 0x000C0CC0
	private void method_1()
	{
		this._stackFilter.Clear();
		foreach (FilterInfo filterInfo in this._listFilter)
		{
			this._stackFilter.Push(filterInfo);
		}
	}

	// Token: 0x06002949 RID: 10569 RVA: 0x000C2B24 File Offset: 0x000C0D24
	public void method_2(List<FilterInfo> list_0)
	{
		this._listFilter.Clear();
		foreach (FilterInfo filterInfo in list_0)
		{
			this.method_3(filterInfo);
		}
	}

	// Token: 0x0600294A RID: 10570 RVA: 0x0001B13D File Offset: 0x0001933D
	public void method_3(FilterInfo filterInfo_0)
	{
		this._listFilter.Add(filterInfo_0);
	}

	// Token: 0x0600294B RID: 10571 RVA: 0x0001B14B File Offset: 0x0001934B
	public void method_4(FilterInfo filterInfo_0)
	{
		this._listFilter.Remove(filterInfo_0);
	}

	// Token: 0x0600294C RID: 10572 RVA: 0x000C2B7C File Offset: 0x000C0D7C
	private List<UICashShopItemData> method_5(List<UICashShopItemData> list_0)
	{
		List<UICashShopItemData> list = new List<UICashShopItemData>();
		if (this._stackFilter.Count <= 0)
		{
			return list_0;
		}
		FilterInfo filterInfo = this._stackFilter.Pop();
		foreach (UICashShopItemData uicashShopItemData in list_0)
		{
			if (CashShopManager.itemFilter(uicashShopItemData, filterInfo))
			{
				list.Add(uicashShopItemData);
			}
		}
		return this.method_5(list);
	}

	// Token: 0x1700020C RID: 524
	// (get) Token: 0x0600294D RID: 10573 RVA: 0x0001B15A File Offset: 0x0001935A
	// (set) Token: 0x0600294E RID: 10574 RVA: 0x0001B162 File Offset: 0x00019362
	public bool Boolean_0
	{
		get
		{
			return this._selected;
		}
		set
		{
			if (value == this._selected)
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

	// Token: 0x04001D96 RID: 7574
	private string _tabLabel;

	// Token: 0x04001D97 RID: 7575
	private bool _selected;

	// Token: 0x04001D98 RID: 7576
	private List<FilterInfo> _listFilter = new List<FilterInfo>();

	// Token: 0x04001D99 RID: 7577
	private Stack<FilterInfo> _stackFilter = new Stack<FilterInfo>();

	// Token: 0x04001D9A RID: 7578
	public string tabName = string.Empty;

	// Token: 0x04001D9B RID: 7579
	public List<UICashShopItemData> listSelection = new List<UICashShopItemData>();

	// Token: 0x04001D9C RID: 7580
	public List<UICashShopItemData> listItemsExceptSelection = new List<UICashShopItemData>();

	// Token: 0x04001D9D RID: 7581
	public List<UICashShopItemData> listItems = new List<UICashShopItemData>();

	// Token: 0x04001D9E RID: 7582
	public List<UICashShopTabData> listSubTab = new List<UICashShopTabData>();

	// Token: 0x04001D9F RID: 7583
	public UICashShopTabData parentTab;

	// Token: 0x04001DA0 RID: 7584
	private UICashShopTabData.OnSelectedEventHandler OnSelected;

	// Token: 0x0200066A RID: 1642
	// (Invoke) Token: 0x06002950 RID: 10576
	public delegate void OnSelectedEventHandler(UICashShopTabData tab);
}
