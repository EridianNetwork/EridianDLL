using System;
using System.Collections.Generic;
using Core;
using ns0;
using pumpkin.display;
using pumpkin.events;
using pumpkin.text;

// Token: 0x020007E7 RID: 2023
public class uniCurrencyUpdateView : CurrencyUpdateView
{
	// Token: 0x0600369F RID: 13983 RVA: 0x000FA10C File Offset: 0x000F830C
	public override void vmethod_2()
	{
		base.vmethod_2();
		(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_45("Money_Value.swf", "Movie_MoneyAnimaRoot", new FuncLoad(this.method_5));
		(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_45("Ammo_Value.swf", "Panel_Ammo_Value", new FuncLoad(this.method_4));
	}

	// Token: 0x060036A0 RID: 13984 RVA: 0x00024095 File Offset: 0x00022295
	private void method_4(MovieClip movieClip_0)
	{
		this._ammoPanel = new uniCurrencyUpdateView.AmmoGainEffect();
		this._ammoPanel.method_0(movieClip_0);
		movieClip_0.stop();
		(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_33(this._ammoPanel);
	}

	// Token: 0x060036A1 RID: 13985 RVA: 0x000FA174 File Offset: 0x000F8374
	private void method_5(MovieClip movieClip_0)
	{
		this._root = new GClass51();
		this._root.method_0(movieClip_0);
		this._rootMC = movieClip_0.getChildByName<MovieClip>("mcMoneyAnimation");
		if (this._rootMC == null)
		{
			DebugUtils.LogError(LogCategory.GUI, "Can not find MovieClip : mcMoneyAnimation");
			return;
		}
		this._rootMC.addFrameScript("KeyFrame_1", new EventDispatcher.EventCallback(this.method_8));
		this._rootMC.addFrameScript("KeyFrame_2", new EventDispatcher.EventCallback(this.method_8));
		this._rootMC.addFrameScript("KeyFrame_3", new EventDispatcher.EventCallback(this.method_8));
		this._rootMC.addFrameScript("disappear", new EventDispatcher.EventCallback(this.method_9));
		this._rootMC.addFrameScript("normal", new EventDispatcher.EventCallback(this.method_6));
		this._rootMC.addFrameScript("getNewacount", new EventDispatcher.EventCallback(this.method_7));
		this._rootMC.addFrameScript("fadeout", new EventDispatcher.EventCallback(this.method_10));
		this._rootMC.addFrameScript("fadeoutEnd", new EventDispatcher.EventCallback(this.method_11));
		this._rootMC.visible = false;
		this._slotMachine = new uniCurrencyUpdateView.UIMoneySlotMachine();
		(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_33(this._root);
	}

	// Token: 0x060036A2 RID: 13986 RVA: 0x000FA2D8 File Offset: 0x000F84D8
	public override void vmethod_3()
	{
		base.vmethod_3();
		(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_37(this._ammoPanel);
		(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_48("Ammo_Value.swf");
		this._ammoPanel = null;
		(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_37(this._root);
		(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_48("Money_Value.swf");
	}

	// Token: 0x060036A3 RID: 13987 RVA: 0x000FA358 File Offset: 0x000F8558
	protected override void vmethod_1(bool bool_0, bool bool_1 = false)
	{
		base.vmethod_1(bool_0, bool_1);
		if (this._rootMC == null)
		{
			return;
		}
		if (bool_0)
		{
			(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_33(this._root);
			this._rootMC.visible = true;
			this._rootMC.gotoAndPlay("fadein");
		}
		else
		{
			this._rootMC.gotoAndPlay("fadeout");
		}
	}

	// Token: 0x060036A4 RID: 13988 RVA: 0x000240D0 File Offset: 0x000222D0
	protected override void vmethod_11()
	{
		base.vmethod_11();
		if (this._rootMC != null)
		{
			this._rootMC.visible = true;
			this._rootMC.gotoAndPlay("getNewacount");
		}
	}

	// Token: 0x060036A5 RID: 13989 RVA: 0x000240FC File Offset: 0x000222FC
	protected void method_6(CEvent cevent_0)
	{
		this._curStatus = CurrencyUpdateView.SlotMachineAnimaStatus.Normal;
		this.vmethod_8();
	}

	// Token: 0x060036A6 RID: 13990 RVA: 0x000FA3C4 File Offset: 0x000F85C4
	protected void method_7(CEvent cevent_0)
	{
		MovieClip childByName = this._rootMC.getChildByName<MovieClip>("mcDeltaMoney");
		if (childByName != null)
		{
			childByName.addFrameScript("Start", new EventDispatcher.EventCallback(this.method_9));
			childByName.addFrameScript("KeyFrame_1", new EventDispatcher.EventCallback(this.method_9));
			childByName.addFrameScript("KeyFrame_2", new EventDispatcher.EventCallback(this.method_9));
			childByName.addFrameScript("KeyFrame_3", new EventDispatcher.EventCallback(this.method_9));
			childByName.addFrameScript("KeyFrame_4", new EventDispatcher.EventCallback(this.method_9));
			childByName.gotoAndPlay("Start");
		}
		this._slotMachine.method_5(this._iCurMoneyAmount, this._iTarMoneyAmount);
	}

	// Token: 0x060036A7 RID: 13991 RVA: 0x0002410B File Offset: 0x0002230B
	protected void method_8(CEvent cevent_0)
	{
		this.method_13();
	}

	// Token: 0x060036A8 RID: 13992 RVA: 0x00024113 File Offset: 0x00022313
	protected void method_9(CEvent cevent_0)
	{
		this.method_12();
	}

	// Token: 0x060036A9 RID: 13993 RVA: 0x0002411B File Offset: 0x0002231B
	protected void method_10(CEvent cevent_0)
	{
		this.vmethod_9();
	}

	// Token: 0x060036AA RID: 13994 RVA: 0x00024123 File Offset: 0x00022323
	protected void method_11(CEvent cevent_0)
	{
		this._rootMC.visible = false;
		this.vmethod_10();
		(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_37(this._root);
	}

	// Token: 0x060036AB RID: 13995 RVA: 0x000FA484 File Offset: 0x000F8684
	protected void method_12()
	{
		int num = this._iTarMoneyAmount - this._iCurMoneyAmount;
		MovieClip childByName = this._rootMC.getChildByName<MovieClip>("mcDeltaMoney");
		if (childByName != null)
		{
			MovieClip childByName2 = childByName.getChildByName<MovieClip>("mcMoneyCount");
			if (num > 0)
			{
				childByName2.gotoAndStop("Gain");
			}
			else
			{
				childByName2.gotoAndStop("Lose");
			}
			UnityTextField unityTextField = (UnityTextField)childByName2.getChildByName<TextField>("textDelta");
			if (unityTextField != null)
			{
				string text;
				if (num > 0)
				{
					text = Utility.smethod_5("+", Utility.smethod_8(num));
				}
				else
				{
					text = Utility.smethod_8(num);
				}
				unityTextField.text = text;
			}
		}
	}

	// Token: 0x060036AC RID: 13996 RVA: 0x000FA51C File Offset: 0x000F871C
	protected void method_13()
	{
		MovieClip childByName = this._rootMC.getChildByName<MovieClip>("mcSlotMachine");
		this._slotMachine.method_0(childByName);
		this._slotMachine.method_6(this._iCurMoneyAmount, this._iTarMoneyAmount);
	}

	// Token: 0x060036AD RID: 13997 RVA: 0x00024151 File Offset: 0x00022351
	public override void vmethod_14(bool bool_0 = false)
	{
		base.vmethod_14(bool_0);
		if (this._ammoPanel == null)
		{
			return;
		}
		this._ammoPanel.method_5();
	}

	// Token: 0x040025C5 RID: 9669
	protected GClass51 _root;

	// Token: 0x040025C6 RID: 9670
	protected MovieClip _rootMC;

	// Token: 0x040025C7 RID: 9671
	protected uniCurrencyUpdateView.UIMoneySlotMachine _slotMachine;

	// Token: 0x040025C8 RID: 9672
	protected uniCurrencyUpdateView.AmmoGainEffect _ammoPanel;

	// Token: 0x020007E8 RID: 2024
	public class AmmoGainEffect : GClass51
	{
		// Token: 0x060036AF RID: 13999 RVA: 0x0002416E File Offset: 0x0002236E
		protected override void vmethod_0()
		{
			base.vmethod_0();
			this.mcRoot = base.DisplayObjectContainer_0.getChildByName<MovieClip>("mcRoot");
			this.mcRoot.visible = false;
			this.mcRoot.mouseEnabled = false;
		}

		// Token: 0x060036B0 RID: 14000 RVA: 0x000241A4 File Offset: 0x000223A4
		public void method_5()
		{
			this.mcRoot.visible = true;
			this.mcRoot.gotoAndPlay("fadein");
		}

		// Token: 0x040025C9 RID: 9673
		protected MovieClip mcRoot;
	}

	// Token: 0x020007E9 RID: 2025
	public class UIMoneySlotMachine : GClass51
	{
		// Token: 0x060036B2 RID: 14002 RVA: 0x000FA560 File Offset: 0x000F8760
		protected override bool OnWidgetInitialized(ref MovieClip movieClip, Type widgetType)
		{
			bool flag = false;
			if (movieClip.name.Contains("mcSlotBit_"))
			{
				flag = true;
				string[] array = movieClip.name.Split(new char[] { '_' });
				int num = Convert.ToInt32(array[1]);
				if (num >= 1 && num <= 8)
				{
					movieClip.visible = false;
					if (this._slotBits[num - 1] == null)
					{
						this._slotBits[num - 1] = new uniCurrencyUpdateView.UIMoneySlotMachineBit();
					}
					this._slotBits[num - 1].method_0(movieClip);
				}
				else
				{
					DebugUtils.LogWarning(LogCategory.GUI, "Wrong Slot machine bit name " + movieClip.name);
				}
			}
			else if (movieClip.name.Contains("mcSlotBitBG_"))
			{
				flag = true;
				string[] array2 = movieClip.name.Split(new char[] { '_' });
				int num2 = Convert.ToInt32(array2[1]);
				if (num2 >= 1 && num2 <= 8)
				{
					this._slotBG[num2 - 1] = movieClip;
					movieClip.visible = false;
				}
				else
				{
					DebugUtils.LogWarning(LogCategory.GUI, "Wrong Slot machine bit BG name " + movieClip.name);
				}
			}
			else if (movieClip.name.Contains("mcDollarSymbol_"))
			{
				flag = true;
				string[] array3 = movieClip.name.Split(new char[] { '_' });
				int num3 = Convert.ToInt32(array3[1]);
				if (num3 >= 1 && num3 <= 8)
				{
					this._dollarSymbol[num3 - 1] = movieClip;
					movieClip.visible = false;
				}
				else
				{
					DebugUtils.LogWarning(LogCategory.GUI, "Wrong Dollar Symbol name " + movieClip.name);
				}
			}
			return flag;
		}

		// Token: 0x060036B3 RID: 14003 RVA: 0x000241EE File Offset: 0x000223EE
		protected override void vmethod_0()
		{
			base.vmethod_0();
			this._rootMC = base.DisplayObjectContainer_0 as MovieClip;
			this._rootMC.visible = false;
		}

		// Token: 0x060036B4 RID: 14004 RVA: 0x000FA6EC File Offset: 0x000F88EC
		public void method_5(int int_0, int int_1)
		{
			int i = 0;
			this._curNumSequence = this.method_7(int_0);
			this._tarNumSequence = this.method_7(int_1);
			int num = ((this._tarNumSequence.Count <= this._curNumSequence.Count) ? this._curNumSequence.Count : this._tarNumSequence.Count);
			int num2 = ((this._tarNumSequence.Count >= this._curNumSequence.Count) ? this._curNumSequence.Count : this._tarNumSequence.Count);
			foreach (MovieClip movieClip in this._dollarSymbol)
			{
				movieClip.visible = false;
			}
			if (num > 0)
			{
				this._dollarSymbol[num - 1].visible = true;
			}
			while (i < num2)
			{
				this._slotBG[i].visible = true;
				this._slotBits[i].method_5(true);
				if (this._tarNumSequence[i] == this._curNumSequence[i])
				{
					this._slotBits[i].method_7(this._tarNumSequence[i]);
				}
				else
				{
					this._slotBits[i].method_6(this._tarNumSequence[i]);
				}
				i++;
			}
			if (num > num2)
			{
				while (i < num)
				{
					int num3 = ((num != this._tarNumSequence.Count) ? 0 : this._tarNumSequence[i]);
					this._slotBits[i].method_6(num3);
					i++;
				}
			}
			while (i < 8)
			{
				this._slotBits[i].method_5(false);
				this._slotBG[i].visible = false;
				i++;
			}
		}

		// Token: 0x060036B5 RID: 14005 RVA: 0x000FA88C File Offset: 0x000F8A8C
		public void method_6(int int_0, int int_1)
		{
			int i = 0;
			this._curNumSequence = this.method_7(int_0);
			this._tarNumSequence = this.method_7(int_1);
			int num = ((this._tarNumSequence.Count <= this._curNumSequence.Count) ? this._curNumSequence.Count : this._tarNumSequence.Count);
			foreach (MovieClip movieClip in this._dollarSymbol)
			{
				movieClip.visible = false;
			}
			if (num > 0)
			{
				this._dollarSymbol[num - 1].visible = true;
			}
			while (i < num && i < 8)
			{
				int num2 = ((i >= this._curNumSequence.Count) ? 0 : this._curNumSequence[i]);
				this._slotBits[i].method_7(num2);
				this._slotBits[i].method_5(true);
				this._slotBG[i].visible = true;
				i++;
			}
			while (i < 8)
			{
				this._slotBits[i].method_5(false);
				this._slotBG[i].visible = false;
				i++;
			}
		}

		// Token: 0x060036B6 RID: 14006 RVA: 0x000FA9A0 File Offset: 0x000F8BA0
		protected List<int> method_7(int int_0)
		{
			List<int> list = new List<int>();
			while (int_0 != 0)
			{
				int num = int_0 % 10;
				list.Add(num);
				int_0 /= 10;
			}
			return list;
		}

		// Token: 0x040025CA RID: 9674
		protected const int SLOT_MACHINE_BIT_COUNT = 8;

		// Token: 0x040025CB RID: 9675
		protected const string SLOT_NAME_PREFIX = "mcSlotBit_";

		// Token: 0x040025CC RID: 9676
		protected const string SLOTBG_NAME_PREFIX = "mcSlotBitBG_";

		// Token: 0x040025CD RID: 9677
		protected const string DOLLARSYMBOL_NAME_PREFIX = "mcDollarSymbol_";

		// Token: 0x040025CE RID: 9678
		protected MovieClip _rootMC;

		// Token: 0x040025CF RID: 9679
		protected uniCurrencyUpdateView.UIMoneySlotMachineBit[] _slotBits = new uniCurrencyUpdateView.UIMoneySlotMachineBit[8];

		// Token: 0x040025D0 RID: 9680
		protected MovieClip[] _slotBG = new MovieClip[8];

		// Token: 0x040025D1 RID: 9681
		protected MovieClip[] _dollarSymbol = new MovieClip[8];

		// Token: 0x040025D2 RID: 9682
		protected List<int> _curNumSequence;

		// Token: 0x040025D3 RID: 9683
		protected List<int> _tarNumSequence;
	}

	// Token: 0x020007EA RID: 2026
	public class UIMoneySlotMachineBit : GClass51
	{
		// Token: 0x060036B8 RID: 14008 RVA: 0x00024231 File Offset: 0x00022431
		protected override void vmethod_0()
		{
			base.vmethod_0();
			this._rootMC = base.DisplayObjectContainer_0 as MovieClip;
			this._rootMC.visible = false;
		}

		// Token: 0x060036B9 RID: 14009 RVA: 0x00024256 File Offset: 0x00022456
		public void method_5(bool bool_0)
		{
			if (this._rootMC != null)
			{
				this._rootMC.visible = bool_0;
			}
		}

		// Token: 0x060036BA RID: 14010 RVA: 0x0002426C File Offset: 0x0002246C
		public void method_6(int int_0)
		{
			if (this.method_8(int_0))
			{
				this._slotBitMC.gotoAndPlay("Start");
			}
		}

		// Token: 0x060036BB RID: 14011 RVA: 0x00024287 File Offset: 0x00022487
		public void method_7(int int_0)
		{
			if (this.method_8(int_0))
			{
				this._slotBitMC.gotoAndStop("Final");
			}
		}

		// Token: 0x060036BC RID: 14012 RVA: 0x000FA9D0 File Offset: 0x000F8BD0
		protected bool method_8(int int_0)
		{
			bool flag = false;
			if (int_0 >= 0 && int_0 <= 9)
			{
				if (this._rootMC != null)
				{
					string text = this._strFramePrefix + int_0;
					this._rootMC.gotoAndStop(text);
					string text2 = this._strSlotPrefix + int_0;
					this._slotBitMC = this._rootMC.getChildByName<MovieClip>(text2);
					if (this._slotBitMC != null)
					{
						flag = true;
					}
				}
				return flag;
			}
			DebugUtils.LogError(LogCategory.GUI, string.Concat(new object[]
			{
				"Wrong slot machine bit num at ",
				this._rootMC.name,
				"  value : ",
				int_0
			}));
			return flag;
		}

		// Token: 0x040025D4 RID: 9684
		protected MovieClip _rootMC;

		// Token: 0x040025D5 RID: 9685
		protected MovieClip _slotBitMC;

		// Token: 0x040025D6 RID: 9686
		protected string _strFramePrefix = "Number_";

		// Token: 0x040025D7 RID: 9687
		protected string _strSlotPrefix = "mcSLot_";
	}
}
