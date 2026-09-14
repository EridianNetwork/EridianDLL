using System;
using System.Collections.Generic;
using ns0;
using XsdSettings;

// Token: 0x0200075A RID: 1882
public class WareHouseView : BaseView
{
	// Token: 0x060031C8 RID: 12744 RVA: 0x000E20A0 File Offset: 0x000E02A0
	public WareHouseView()
	{
		this._arrItemComparion = new List<Comparison<UIItemSlotData>>(4);
		this._arrFilterList = new List<List<UIItemSlotData>>(4);
		this._arrFilterList.Add(new List<UIItemSlotData>());
		this._arrItemComparion.Add(new Comparison<UIItemSlotData>(InventoryView.smethod_0));
		this._arrFilterList.Add(new List<UIItemSlotData>());
		this._arrItemComparion.Add(new Comparison<UIItemSlotData>(InventoryView.smethod_2));
		this._arrFilterList.Add(new List<UIItemSlotData>());
		this._arrItemComparion.Add(new Comparison<UIItemSlotData>(InventoryView.smethod_3));
		this._arrFilterList.Add(new List<UIItemSlotData>());
		this._arrItemComparion.Add(new Comparison<UIItemSlotData>(InventoryView.smethod_4));
	}

	// Token: 0x060031C9 RID: 12745 RVA: 0x000206A1 File Offset: 0x0001E8A1
	public override void vmethod_2()
	{
		base.vmethod_2();
		MonoSingleton<AppManager>.Instance.method_0().method_6(this);
		ServiceWrapperBase<InventoryServiceWrapper>.Instance.method_3(new InventoryServiceWrapper.InventoryUpdateCallback(this.vmethod_5));
	}

	// Token: 0x060031CA RID: 12746 RVA: 0x000206D0 File Offset: 0x0001E8D0
	public override void vmethod_3()
	{
		base.vmethod_3();
		ServiceWrapperBase<InventoryServiceWrapper>.Instance.method_4(new InventoryServiceWrapper.InventoryUpdateCallback(this.vmethod_5));
		MonoSingleton<AppManager>.Instance.method_0().method_7(this);
		this._bVisible = false;
	}

	// Token: 0x060031CB RID: 12747 RVA: 0x000D8DD4 File Offset: 0x000D6FD4
	public override bool vmethod_4()
	{
		if (this.Boolean_1 && MonoSingleton<AppManager>.Instance.method_0().vmethod_5<WeaponPreviewView>().Boolean_1)
		{
			MonoSingleton<AppManager>.Instance.method_0().vmethod_5<WeaponPreviewView>().vmethod_5();
			return true;
		}
		if (this.Boolean_1)
		{
			this.Boolean_1 = false;
			return true;
		}
		return base.vmethod_4();
	}

	// Token: 0x060031CC RID: 12748 RVA: 0x0001D5D7 File Offset: 0x0001B7D7
	public override bool OnShortCutCMD(string command)
	{
		if (!this.Boolean_0)
		{
			return false;
		}
		this.Boolean_1 = !this.Boolean_1;
		return true;
	}

	// Token: 0x060031CD RID: 12749 RVA: 0x00020706 File Offset: 0x0001E906
	public virtual void vmethod_5(InventoryServiceWrapper.InventoryUpdateType inventoryUpdateType_0)
	{
		if (this.method_4())
		{
			this.vmethod_6();
		}
	}

	// Token: 0x060031CE RID: 12750 RVA: 0x00020716 File Offset: 0x0001E916
	protected override void vmethod_1(bool bool_0, bool bool_1 = false)
	{
		base.vmethod_1(bool_0, bool_1);
		if (this.Boolean_1)
		{
			ServiceWrapperBase<InventoryServiceWrapper>.Instance.method_36();
		}
		else
		{
			NPC_UIFlowController.smethod_0().method_3(NPC_UIFlowController.NPC_UIFlowState.None);
		}
	}

	// Token: 0x060031CF RID: 12751 RVA: 0x0000311B File Offset: 0x0000131B
	protected void method_3()
	{
	}

	// Token: 0x060031D0 RID: 12752 RVA: 0x0000311B File Offset: 0x0000131B
	protected virtual void vmethod_6()
	{
	}

	// Token: 0x060031D1 RID: 12753 RVA: 0x0002073F File Offset: 0x0001E93F
	protected bool method_4()
	{
		if (!ServiceWrapperBase<InventoryServiceWrapper>.Instance.vmethod_2())
		{
			return false;
		}
		this._arrItems = ServiceWrapperBase<InventoryServiceWrapper>.Instance.method_37();
		return this._arrItems != null;
	}

	// Token: 0x060031D2 RID: 12754 RVA: 0x0002076B File Offset: 0x0001E96B
	protected void method_5(int int_0, int int_1)
	{
		if (ServiceWrapperBase<InventoryServiceWrapper>.Instance.vmethod_2())
		{
			ServiceWrapperBase<InventoryServiceWrapper>.Instance.method_34((byte)int_0, (byte)int_1);
		}
	}

	// Token: 0x060031D3 RID: 12755 RVA: 0x00020787 File Offset: 0x0001E987
	protected void method_6(int int_0, int int_1)
	{
		if (ServiceWrapperBase<InventoryServiceWrapper>.Instance.vmethod_2())
		{
			ServiceWrapperBase<InventoryServiceWrapper>.Instance.method_35((byte)int_0, (byte)int_1, true);
		}
	}

	// Token: 0x060031D4 RID: 12756 RVA: 0x000E2168 File Offset: 0x000E0368
	protected void method_7()
	{
		foreach (List<UIItemSlotData> list in this._arrFilterList)
		{
			list.Clear();
		}
		if (this._arrItems == null)
		{
			return;
		}
		for (int i = 0; i < this._arrItems.Length; i++)
		{
			if (this._arrItems[i] != null)
			{
				ItemType type = this._arrItems[i].m_type;
				if (type <= ItemType.Weapon)
				{
					if (type == ItemType.NA)
					{
						this._arrFilterList[2].Add(new UIItemSlotData(this._arrItems[i], "warehouse", i, false));
						goto IL_0144;
					}
					if (type == ItemType.Weapon)
					{
						this._arrFilterList[0].Add(new UIItemSlotData(this._arrItems[i], "warehouse", i, false));
						goto IL_0144;
					}
				}
				else
				{
					if (type == ItemType.Shield)
					{
						goto IL_011F;
					}
					if (type == ItemType.Outfit)
					{
						this._arrFilterList[2].Add(new UIItemSlotData(this._arrItems[i], "warehouse", i, false));
						goto IL_0144;
					}
				}
				if (type != ItemType.ClassMode)
				{
					this._arrFilterList[3].Add(new UIItemSlotData(this._arrItems[i], "warehouse", i, false));
					goto IL_0144;
				}
				IL_011F:
				this._arrFilterList[1].Add(new UIItemSlotData(this._arrItems[i], "warehouse", i, false));
			}
			IL_0144:;
		}
	}

	// Token: 0x060031D5 RID: 12757 RVA: 0x000207A4 File Offset: 0x0001E9A4
	protected List<UIItemSlotData> method_8(int int_0)
	{
		if (int_0 >= 0 && int_0 <= this._arrFilterList.Count)
		{
			this._arrFilterList[int_0].Sort(this._arrItemComparion[int_0]);
			return this._arrFilterList[int_0];
		}
		return null;
	}

	// Token: 0x060031D6 RID: 12758 RVA: 0x0000311B File Offset: 0x0000131B
	protected void method_9(UIItemSlotData uiitemSlotData_0)
	{
	}

	// Token: 0x060031D7 RID: 12759 RVA: 0x0001F6EF File Offset: 0x0001D8EF
	protected void method_10(object object_0)
	{
		MonoSingleton<AppManager>.Instance.method_0().vmethod_5<WeaponPreviewView>().vmethod_6((WeaponDNA)object_0, true);
	}

	// Token: 0x0400226A RID: 8810
	public const string ITEM_ID_STR = "warehouse";

	// Token: 0x0400226B RID: 8811
	protected ItemDNA[] _arrItems;

	// Token: 0x0400226C RID: 8812
	protected List<List<UIItemSlotData>> _arrFilterList;

	// Token: 0x0400226D RID: 8813
	protected List<Comparison<UIItemSlotData>> _arrItemComparion;
}
