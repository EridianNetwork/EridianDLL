using System;
using Core;
using ns0;
using pumpkin.display;
using UnityEngine;

// Token: 0x020007CB RID: 1995
public class MoneyPanel : GClass51
{
	// Token: 0x06003573 RID: 13683 RVA: 0x000231A5 File Offset: 0x000213A5
	public MoneyPanel()
	{
		this._arrNumberSlots = new MovieClip[8];
	}

	// Token: 0x06003574 RID: 13684 RVA: 0x000231B9 File Offset: 0x000213B9
	protected override void vmethod_0()
	{
		base.vmethod_0();
	}

	// Token: 0x06003575 RID: 13685 RVA: 0x000F4434 File Offset: 0x000F2634
	protected override bool OnWidgetInitialized(ref MovieClip movieClip, Type widgetType)
	{
		bool flag = false;
		if (movieClip.name.Length > "mcSlotBit_".Length)
		{
			string text = movieClip.name.Substring(0, "mcSlotBit_".Length);
			if (text == "mcSlotBit_")
			{
				int num = Convert.ToInt32(movieClip.name.Substring("mcSlotBit_".Length, movieClip.name.Length - "mcSlotBit_".Length));
				if (num < this._arrNumberSlots.Length && num >= 0)
				{
					this._arrNumberSlots[num] = movieClip;
					return true;
				}
				DebugUtils.LogWarning(LogCategory.GUI, string.Concat(new object[] { "Money name wrong! Index:", num, " is bigger than sum: ", 8 }));
				return true;
			}
		}
		return flag;
	}

	// Token: 0x06003576 RID: 13686 RVA: 0x000F450C File Offset: 0x000F270C
	public void method_5(int int_0)
	{
		this._iMoneyValue = Mathf.FloorToInt(ServiceWrapperBase<ShopServiceWrapper>.Instance.ShopSetup_0.m_soldRatio * (float)int_0);
		int num = this._iMoneyValue;
		for (int i = 0; i < 8; i++)
		{
			if (this._arrNumberSlots[i] != null)
			{
				if (num > 0)
				{
					int num2 = num % 10;
					num = Mathf.FloorToInt((float)(num / 10));
					this._arrNumberSlots[i].gotoAndStop(Utility.smethod_5("Number_", Utility.smethod_8(num2)));
				}
				else
				{
					this._arrNumberSlots[i].gotoAndStop(Utility.smethod_5("Number_", "none"));
				}
			}
		}
	}

	// Token: 0x04002509 RID: 9481
	private const string SLOT_NAME = "mcSlotBit_";

	// Token: 0x0400250A RID: 9482
	private const string Number_NAME = "Number_";

	// Token: 0x0400250B RID: 9483
	private const int SLOT_NUMBER = 8;

	// Token: 0x0400250C RID: 9484
	protected MovieClip[] _arrNumberSlots;

	// Token: 0x0400250D RID: 9485
	protected int _iMoneyValue;
}
