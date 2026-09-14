using System;
using System.Collections.Generic;
using ns0;
using UnityEngine;

// Token: 0x020006BC RID: 1724
public class PopupMenuView : BaseView
{
	// Token: 0x06002D6B RID: 11627 RVA: 0x0000311D File Offset: 0x0000131D
	public override bool vmethod_0()
	{
		return false;
	}

	// Token: 0x06002D6C RID: 11628 RVA: 0x000D4AF0 File Offset: 0x000D2CF0
	public override void OnTestGUI()
	{
		int num = 0;
		foreach (MenuItemDef menuItemDef in this._arrCurrentMenu)
		{
			if (GUI.Button(new Rect((float)(Screen.width / 4 - 100), (float)(200 + num * 41), 100f, 40f), menuItemDef.itemTitle))
			{
				break;
			}
			num++;
		}
		if (num < this._arrCurrentMenu.Count)
		{
			this.method_7(num);
		}
	}

	// Token: 0x06002D6D RID: 11629 RVA: 0x0001DF17 File Offset: 0x0001C117
	public override void vmethod_2()
	{
		base.vmethod_2();
	}

	// Token: 0x06002D6E RID: 11630 RVA: 0x0001E26B File Offset: 0x0001C46B
	public override void vmethod_3()
	{
		base.vmethod_3();
		this.method_6();
	}

	// Token: 0x06002D6F RID: 11631 RVA: 0x000D4B8C File Offset: 0x000D2D8C
	public void method_3(MenuItemDef[] menuItemDef_0)
	{
		Vector2 vector = Input.mousePosition;
		vector.y = (float)Screen.height - vector.y;
		this.method_4(menuItemDef_0, vector, null);
	}

	// Token: 0x06002D70 RID: 11632 RVA: 0x000D4BC4 File Offset: 0x000D2DC4
	public void method_4(MenuItemDef[] menuItemDef_0, Vector2 vector2_0, PopupMenuView.MouseClickHooker mouseClickHooker_0 = null)
	{
		this._arrCurrentMenu.Clear();
		MonoSingleton<AppManager>.Instance.method_0().method_15(true, base.String_0);
		this._arrCurrentMenu.AddRange(menuItemDef_0);
		this._position = vector2_0;
		this.Boolean_1 = true;
		this.vmethod_5();
		this._funcMouseClkHooker = mouseClickHooker_0;
	}

	// Token: 0x06002D71 RID: 11633 RVA: 0x000D4C1C File Offset: 0x000D2E1C
	protected void method_5(int int_0)
	{
		MenuItemDef menuItemDef = new MenuItemDef(string.Empty, null, null);
		if (int_0 >= 0 && int_0 < this._arrCurrentMenu.Count)
		{
			menuItemDef = this._arrCurrentMenu[int_0];
		}
		if (this._funcMouseClkHooker == null)
		{
			this.method_6();
		}
		else
		{
			this._funcMouseClkHooker(int_0);
		}
		if (menuItemDef.itemFunc != null)
		{
			menuItemDef.itemFunc(menuItemDef.itemData);
		}
	}

	// Token: 0x06002D72 RID: 11634 RVA: 0x0001E279 File Offset: 0x0001C479
	public void method_6()
	{
		MonoSingleton<AppManager>.Instance.method_0().method_15(false, base.String_0);
		this._arrCurrentMenu.Clear();
		this.vmethod_6();
		this.Boolean_1 = false;
		this._funcMouseClkHooker = null;
	}

	// Token: 0x1700023B RID: 571
	// (get) Token: 0x06002D73 RID: 11635 RVA: 0x0001D50E File Offset: 0x0001B70E
	// (set) Token: 0x06002D74 RID: 11636 RVA: 0x0001E2B0 File Offset: 0x0001C4B0
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

	// Token: 0x06002D75 RID: 11637 RVA: 0x0000311B File Offset: 0x0000131B
	protected virtual void vmethod_5()
	{
	}

	// Token: 0x06002D76 RID: 11638 RVA: 0x0000311B File Offset: 0x0000131B
	protected virtual void vmethod_6()
	{
	}

	// Token: 0x06002D77 RID: 11639 RVA: 0x0001E2C2 File Offset: 0x0001C4C2
	protected void method_7(int int_0)
	{
		this.method_5(int_0);
	}

	// Token: 0x04001FDE RID: 8158
	protected List<MenuItemDef> _arrCurrentMenu = new List<MenuItemDef>();

	// Token: 0x04001FDF RID: 8159
	protected Vector2 _position;

	// Token: 0x04001FE0 RID: 8160
	protected PopupMenuView.MouseClickHooker _funcMouseClkHooker;

	// Token: 0x020006BD RID: 1725
	// (Invoke) Token: 0x06002D79 RID: 11641
	public delegate void MouseClickHooker(int index);
}
