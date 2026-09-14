using System;
using System.Collections.Generic;
using ns0;
using UnityEngine;

// Token: 0x0200073E RID: 1854
public class PlayerListView : BaseView
{
	// Token: 0x17000257 RID: 599
	// (get) Token: 0x060030F6 RID: 12534 RVA: 0x0001D50E File Offset: 0x0001B70E
	// (set) Token: 0x060030F7 RID: 12535 RVA: 0x0001E2B0 File Offset: 0x0001C4B0
	public override bool Boolean_1
	{
		get
		{
			return this._bVisible;
		}
		set
		{
			if (this.Boolean_0)
			{
				this.vmethod_1(value, true);
			}
		}
	}

	// Token: 0x060030F8 RID: 12536 RVA: 0x0001FE3C File Offset: 0x0001E03C
	public override bool vmethod_4()
	{
		if (this.Boolean_1 && this.Boolean_0)
		{
			this.method_5();
			return true;
		}
		return false;
	}

	// Token: 0x060030F9 RID: 12537 RVA: 0x0001DF17 File Offset: 0x0001C117
	public override void vmethod_2()
	{
		base.vmethod_2();
	}

	// Token: 0x060030FA RID: 12538 RVA: 0x0001FE57 File Offset: 0x0001E057
	public override void vmethod_3()
	{
		base.vmethod_3();
		this.method_5();
	}

	// Token: 0x060030FB RID: 12539 RVA: 0x0001FE65 File Offset: 0x0001E065
	public void method_3(MenuItemDef[] menuItemDef_0)
	{
		this._subMenu.Clear();
		this._subMenu.AddRange(menuItemDef_0);
		this.vmethod_6();
	}

	// Token: 0x060030FC RID: 12540 RVA: 0x000DFBDC File Offset: 0x000DDDDC
	public void method_4(MenuItemDef[] menuItemDef_0, MenuItemDef[] menuItemDef_1, PlayerListView.SelectChangeDelegate selectChangeDelegate_0 = null, PlayerListView.CloseMenuDelegate closeMenuDelegate_0 = null)
	{
		Vector2 vector = new Vector2((float)Screen.width * 0.5f, (float)Screen.height * 0.5f);
		MonoSingleton<AppManager>.Instance.method_0().method_15(true, base.String_0);
		this._arrCurrentMenu.Clear();
		this._arrCurrentMenu.AddRange(menuItemDef_0);
		this._onSelectedChange = selectChangeDelegate_0;
		this._onMenuClosed = closeMenuDelegate_0;
		this._position = vector;
		this.Boolean_1 = true;
		this.method_3(menuItemDef_1);
		this.vmethod_5();
	}

	// Token: 0x060030FD RID: 12541 RVA: 0x0000311B File Offset: 0x0000131B
	protected virtual void vmethod_5()
	{
	}

	// Token: 0x060030FE RID: 12542 RVA: 0x0000311B File Offset: 0x0000131B
	protected virtual void vmethod_6()
	{
	}

	// Token: 0x060030FF RID: 12543 RVA: 0x0000311B File Offset: 0x0000131B
	protected virtual void vmethod_7()
	{
	}

	// Token: 0x06003100 RID: 12544 RVA: 0x000DFC60 File Offset: 0x000DDE60
	public void method_5()
	{
		this._arrCurrentMenu.Clear();
		this._subMenu.Clear();
		MonoSingleton<AppManager>.Instance.method_0().method_15(false, base.String_0);
		this.vmethod_7();
		this.Boolean_1 = false;
		if (this._onMenuClosed != null)
		{
			this._onMenuClosed();
		}
	}

	// Token: 0x06003101 RID: 12545 RVA: 0x0001FE84 File Offset: 0x0001E084
	protected void method_6(int int_0)
	{
		if (this._onSelectedChange != null)
		{
			this._onSelectedChange(int_0);
		}
	}

	// Token: 0x04002200 RID: 8704
	protected List<MenuItemDef> _arrCurrentMenu = new List<MenuItemDef>();

	// Token: 0x04002201 RID: 8705
	protected List<MenuItemDef> _subMenu = new List<MenuItemDef>();

	// Token: 0x04002202 RID: 8706
	protected Vector2 _position;

	// Token: 0x04002203 RID: 8707
	protected PlayerListView.SelectChangeDelegate _onSelectedChange;

	// Token: 0x04002204 RID: 8708
	protected PlayerListView.CloseMenuDelegate _onMenuClosed;

	// Token: 0x0200073F RID: 1855
	// (Invoke) Token: 0x06003103 RID: 12547
	public delegate void SelectChangeDelegate(int index);

	// Token: 0x02000740 RID: 1856
	// (Invoke) Token: 0x06003107 RID: 12551
	public delegate void CloseMenuDelegate();
}
