using System;
using Core;
using ns0;
using pumpkin.display;
using pumpkin.events;
using UnityEngine;

// Token: 0x020007D4 RID: 2004
public class uniCashShopView : CashShopView
{
	// Token: 0x060035B8 RID: 13752 RVA: 0x00023521 File Offset: 0x00021721
	public override void vmethod_2()
	{
		base.vmethod_2();
		(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_45("2014_CoinShop.swf", "Panel_Shop", new FuncLoad(this.method_3));
	}

	// Token: 0x060035B9 RID: 13753 RVA: 0x00023553 File Offset: 0x00021753
	private void method_3(MovieClip movieClip_0)
	{
		this._mcRoot = movieClip_0;
		this._mcRoot.visible = false;
		this._panelRoot = new GClass51();
		this._panelRoot.method_0(this._mcRoot);
		this._bActive = true;
	}

	// Token: 0x060035BA RID: 13754 RVA: 0x000F59B4 File Offset: 0x000F3BB4
	public override void vmethod_3()
	{
		base.vmethod_3();
		if (this._panelRoot != null)
		{
			(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_37(this._panelRoot);
		}
		this._panelRoot = null;
		(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_48("2014_CoinShop");
	}

	// Token: 0x060035BB RID: 13755 RVA: 0x000F5A0C File Offset: 0x000F3C0C
	protected override void vmethod_1(bool bool_0, bool bool_1 = false)
	{
		base.vmethod_1(bool_0, bool_1);
		if (this._mcRoot != null)
		{
			if (bool_0)
			{
				(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_31(this._panelRoot);
				this._mcRoot.visible = true;
				this._mcRoot.gotoAndPlay("Open");
			}
			else
			{
				this._mcRoot.gotoAndPlay("Close");
			}
		}
	}

	// Token: 0x060035BC RID: 13756 RVA: 0x0000311B File Offset: 0x0000131B
	protected virtual void vmethod_8()
	{
	}

	// Token: 0x0400253D RID: 9533
	private GClass51 _panelRoot;

	// Token: 0x0400253E RID: 9534
	private MovieClip _mcTestContainer;

	// Token: 0x0400253F RID: 9535
	private MovieClip _mcRoot;

	// Token: 0x020007D5 RID: 2005
	public class CashShopPanel : GClass51
	{
		// Token: 0x170002E2 RID: 738
		// (get) Token: 0x060035BE RID: 13758 RVA: 0x000235A1 File Offset: 0x000217A1
		// (set) Token: 0x060035BF RID: 13759 RVA: 0x000235AE File Offset: 0x000217AE
		public bool Boolean_0
		{
			get
			{
				return this.mcRootMovie.visible;
			}
			set
			{
				this.mcRootMovie.visible = value;
			}
		}

		// Token: 0x170002E3 RID: 739
		// (get) Token: 0x060035C0 RID: 13760 RVA: 0x000235BC File Offset: 0x000217BC
		public bool Boolean_1
		{
			get
			{
				return this.mcRootMovie.isPlaying;
			}
		}

		// Token: 0x060035C1 RID: 13761 RVA: 0x000F5A78 File Offset: 0x000F3C78
		protected override void vmethod_0()
		{
			base.vmethod_0();
			this.mcRootMovie = base.DisplayObjectContainer_0 as MovieClip;
			this.mcRootMovie.stopAll();
			this.mcRoot = this.mcRootMovie.getChildByName<MovieClip>("mcRoot");
			this.mcRoot.stopAll();
			if (this.mcRoot == null)
			{
			}
		}

		// Token: 0x060035C2 RID: 13762 RVA: 0x000F5AD0 File Offset: 0x000F3CD0
		protected override bool OnWidgetInitialized(ref MovieClip movieClip, Type widgetType)
		{
			bool flag = false;
			string name = movieClip.name;
			if (movieClip.name.Contains("mcItemSlot"))
			{
				string text = name.Substring("mcItemSlot".Length, name.Length - "mcItemSlot".Length);
				int num;
				if (!int.TryParse(text, out num))
				{
					DebugUtils.LogWarning(LogCategory.Gamelogic, "cash shop slot item's name invalid!");
				}
				if (num < 60)
				{
					uniCashShopView.CashShopPanel.CashShopItemSlot cashShopItemSlot = this.slots[num];
					if (cashShopItemSlot == null)
					{
						cashShopItemSlot = new uniCashShopView.CashShopPanel.CashShopItemSlot();
					}
					cashShopItemSlot.method_0(movieClip);
					cashShopItemSlot.removeAllEventListeners(MouseEvent.CLICK);
					cashShopItemSlot.addEventListener(MouseEvent.CLICK, new EventDispatcher.EventCallback(this.method_5));
					flag = true;
				}
			}
			return flag;
		}

		// Token: 0x060035C3 RID: 13763 RVA: 0x000F5B84 File Offset: 0x000F3D84
		protected void method_5(CEvent cevent_0)
		{
			uniCashShopView.CashShopPanel.CashShopItemSlot cashShopItemSlot = cevent_0.target as uniCashShopView.CashShopPanel.CashShopItemSlot;
			if (cashShopItemSlot != null)
			{
				UICashShopItemData uicashShopItemData = cashShopItemSlot.Object_0 as UICashShopItemData;
				if (uicashShopItemData != null)
				{
					uicashShopItemData.Boolean_0 = true;
				}
			}
		}

		// Token: 0x04002540 RID: 9536
		public const int MAX_SLOT_COUNT = 60;

		// Token: 0x04002541 RID: 9537
		protected const string SLOT_NAME_PREFIX = "mcItemSlot";

		// Token: 0x04002542 RID: 9538
		protected MovieClip mcRoot;

		// Token: 0x04002543 RID: 9539
		protected MovieClip mcRootMovie;

		// Token: 0x04002544 RID: 9540
		protected int _iItemSum;

		// Token: 0x04002545 RID: 9541
		protected uniCashShopView.CashShopPanel.CashShopItemSlot[] slots = new uniCashShopView.CashShopPanel.CashShopItemSlot[60];

		// Token: 0x04002546 RID: 9542
		protected MovieClip mcContent;

		// Token: 0x04002547 RID: 9543
		protected GClass47 mcScrollView;

		// Token: 0x04002548 RID: 9544
		protected GClass46 mcSB;

		// Token: 0x020007D6 RID: 2006
		protected class CashShopItemSlot : GClass44
		{
			// Token: 0x060035C5 RID: 13765 RVA: 0x000F5BB8 File Offset: 0x000F3DB8
			protected override void vmethod_0()
			{
				base.vmethod_0();
				this._txtName = base.DisplayObjectContainer_0.getChildByName<UnityTextField>("textName");
				this._txtPrice = base.DisplayObjectContainer_0.getChildByName<UnityTextField>("textPrice");
				this._txtQuantity = base.DisplayObjectContainer_0.getChildByName<UnityTextField>("textQuantity");
				if (this._txtName != null)
				{
					this._txtName.text = null;
					this._txtName.visible = false;
				}
				if (this._txtPrice != null)
				{
					this._txtPrice.text = null;
					this._txtPrice.visible = false;
					this._defaultColor = this._txtPrice.Color_0;
				}
			}

			// Token: 0x060035C6 RID: 13766 RVA: 0x000F5C60 File Offset: 0x000F3E60
			public void method_34(UICashShopItemData uicashShopItemData_0)
			{
				if (uicashShopItemData_0 != null)
				{
					base.Object_0 = uicashShopItemData_0;
					base.DisplayObjectContainer_0.visible = true;
					if (this._txtName != null)
					{
						this._txtName.text = "TestLabel";
					}
				}
				else
				{
					base.Object_0 = null;
					base.DisplayObjectContainer_0.visible = false;
					if (this._txtName != null)
					{
						this._txtName.text = null;
					}
				}
			}

			// Token: 0x04002549 RID: 9545
			protected UnityTextField _txtPrice;

			// Token: 0x0400254A RID: 9546
			protected UnityTextField _txtName;

			// Token: 0x0400254B RID: 9547
			protected UnityTextField _txtQuantity;

			// Token: 0x0400254C RID: 9548
			protected Color _defaultColor;
		}
	}
}
