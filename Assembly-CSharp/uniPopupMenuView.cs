using System;
using System.Collections.Generic;
using Core;
using ns0;
using pumpkin.display;
using pumpkin.events;
using UnityEngine;

// Token: 0x020006BE RID: 1726
public class uniPopupMenuView : PopupMenuView
{
	// Token: 0x06002D7D RID: 11645 RVA: 0x000D4C90 File Offset: 0x000D2E90
	public override void OnTestGUI()
	{
		if (GUI.Button(new Rect((float)(Screen.width / 2 - 200), 100f, 140f, 60f), "PopupMenu"))
		{
			MenuItemDef[] array = new MenuItemDef[6];
			for (int i = 0; i < 6; i++)
			{
				array[i].itemTitle = "Right Menu " + i;
				array[i].itemData = i;
				array[i].itemFunc = new MenuItemProcessFunc(this.method_8);
			}
			MonoSingleton<AppManager>.Instance.method_0().vmethod_5<PopupMenuView>().method_3(array);
		}
	}

	// Token: 0x06002D7E RID: 11646 RVA: 0x0001E2D3 File Offset: 0x0001C4D3
	private void method_8(object object_0)
	{
		DebugUtils.Log(LogCategory.GUI, "onMenuClick : " + (int)object_0);
	}

	// Token: 0x06002D7F RID: 11647 RVA: 0x000D4D3C File Offset: 0x000D2F3C
	public override void vmethod_2()
	{
		base.vmethod_2();
		BadAssMovieClip badAssMovieClip = new BadAssMovieClip("CommonLib.swf", "PopupMenuPanel");
		this._rootPanel = new uniPopupMenuView.ListMenuPanel();
		this._rootPanel.method_0(badAssMovieClip);
		this._rootPanel.menuSelFunc = new uniPopupMenuView.MenuSelectedFunc(base.method_7);
		this._rootPanel.addEventListener("Cancel", new EventDispatcher.EventCallback(this.method_9));
	}

	// Token: 0x06002D80 RID: 11648 RVA: 0x0001E2F0 File Offset: 0x0001C4F0
	public override void vmethod_3()
	{
		base.vmethod_3();
		(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_37(this._rootPanel);
		this._rootPanel.menuSelFunc = null;
		this._rootPanel = null;
	}

	// Token: 0x06002D81 RID: 11649 RVA: 0x000D4DAC File Offset: 0x000D2FAC
	protected override void vmethod_5()
	{
		if (this._rootPanel != null)
		{
			(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_33(this._rootPanel);
			Vector2 vector = this._position / GClass20.GClass20_0.Single_0;
			this._rootPanel.vmethod_2(this._arrCurrentMenu.ToArray(), vector);
		}
	}

	// Token: 0x06002D82 RID: 11650 RVA: 0x0001E325 File Offset: 0x0001C525
	protected override void vmethod_6()
	{
		if (this._rootPanel != null)
		{
			(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_37(this._rootPanel);
			this._rootPanel.vmethod_3();
		}
	}

	// Token: 0x06002D83 RID: 11651 RVA: 0x0001E354 File Offset: 0x0001C554
	protected void method_9(CEvent cevent_0)
	{
		base.method_5(-1);
	}

	// Token: 0x04001FE1 RID: 8161
	private uniPopupMenuView.ListMenuPanel _rootPanel;

	// Token: 0x020006BF RID: 1727
	protected class ListMenuPanel : GClass51
	{
		// Token: 0x06002D84 RID: 11652 RVA: 0x0001E35D File Offset: 0x0001C55D
		public ListMenuPanel()
		{
			this._arrItemList = new List<MovieClip>();
			this._arrButtonList = new List<GClass25>();
		}

		// Token: 0x06002D85 RID: 11653 RVA: 0x000D4E0C File Offset: 0x000D300C
		protected override void vmethod_0()
		{
			base.vmethod_0();
			this.mcSelf = this.displayObjectContainer_0 as MovieClip;
			if (this.mcSelf == null)
			{
				DebugUtils.LogWarning(LogCategory.GUI, "UIWarning: Button onConfiUI() 'controlMC' is null! UIComponent won't work!!!");
			}
			this.mcSelf.visible = false;
			this._arrItemList.Clear();
			this._arrButtonList.Clear();
			this._background = this.mcSelf.getChildByName<BadAssMovieClip>("bg");
			for (int i = 0; i < 12; i++)
			{
				MovieClip childByName = this.mcSelf.getChildByName<MovieClip>("item" + i);
				GClass25 gclass = null;
				if (childByName != null)
				{
					childByName.visible = false;
					MovieClip childByName2 = childByName.getChildByName<MovieClip>("mcButton");
					if (childByName2 != null)
					{
						gclass = new GClass25();
						gclass.method_0(childByName2);
						gclass.Object_0 = i;
						gclass.addEventListener(MouseEvent.CLICK, new EventDispatcher.EventCallback(this.method_5));
					}
				}
				this._arrItemList.Add(childByName);
				this._arrButtonList.Add(gclass);
			}
		}

		// Token: 0x06002D86 RID: 11654 RVA: 0x000D4F10 File Offset: 0x000D3110
		public virtual void vmethod_2(MenuItemDef[] menuItemDef_0, Vector2 vector2_0)
		{
			if (this.mcSelf == null)
			{
				return;
			}
			this.mcSelf.visible = true;
			float num = 8f;
			for (int i = 0; i < 12; i++)
			{
				if (this._arrItemList[i] != null)
				{
					this._arrItemList[i].visible = i < menuItemDef_0.Length;
					if (this._arrItemList[i].visible && this._arrButtonList[i] != null)
					{
						this._arrButtonList[i].String_2 = menuItemDef_0[i].itemTitle;
						this._arrButtonList[i].Boolean_6 = menuItemDef_0[i].itemFunc != null;
						num += 30.5f;
					}
				}
			}
			num += 27f;
			this._background.Single_1 = num;
			this._background.Single_0 = 123f;
			Vector2 vector = new Vector2(vector2_0.x, vector2_0.y);
			float num2 = vector.y + num - GClass20.GClass20_0.Single_2;
			if (num2 > 0f)
			{
				vector.y -= num2;
			}
			this.mcSelf.x = vector.x;
			this.mcSelf.y = vector.y;
			GClass20.GClass20_0.Stage_0.addEventListener(MouseEvent.MOUSE_DOWN, new EventDispatcher.EventCallback(this.method_6));
		}

		// Token: 0x06002D87 RID: 11655 RVA: 0x0001E37B File Offset: 0x0001C57B
		public virtual void vmethod_3()
		{
			this.mcSelf.visible = false;
			GClass20.GClass20_0.Stage_0.removeEventListener(MouseEvent.MOUSE_DOWN, new EventDispatcher.EventCallback(this.method_6));
		}

		// Token: 0x06002D88 RID: 11656 RVA: 0x000D5088 File Offset: 0x000D3288
		protected void method_5(CEvent cevent_0)
		{
			GClass53 gclass = cevent_0 as GClass53;
			if (gclass == null)
			{
				return;
			}
			GClass25 gclass2 = gclass.target as GClass25;
			if (gclass2 != null && gclass2.Object_0 != null && this.menuSelFunc != null)
			{
				this.menuSelFunc((int)gclass2.Object_0);
			}
		}

		// Token: 0x06002D89 RID: 11657 RVA: 0x000D50D8 File Offset: 0x000D32D8
		protected void method_6(CEvent cevent_0)
		{
			if (!this.mcSelf.getBounds(this.mcSelf).contains(this.mcSelf.mouseX, this.mcSelf.mouseY))
			{
				base.dispatchEvent(new CEvent("Cancel"));
			}
		}

		// Token: 0x04001FE2 RID: 8162
		protected const int ITEM_SUM = 12;

		// Token: 0x04001FE3 RID: 8163
		protected MovieClip mcSelf;

		// Token: 0x04001FE4 RID: 8164
		protected BadAssMovieClip _background;

		// Token: 0x04001FE5 RID: 8165
		protected List<MovieClip> _arrItemList;

		// Token: 0x04001FE6 RID: 8166
		protected List<GClass25> _arrButtonList;

		// Token: 0x04001FE7 RID: 8167
		public uniPopupMenuView.MenuSelectedFunc menuSelFunc;
	}

	// Token: 0x020006C0 RID: 1728
	// (Invoke) Token: 0x06002D8B RID: 11659
	protected delegate void MenuSelectedFunc(int iIndex);
}
