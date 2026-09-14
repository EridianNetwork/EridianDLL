using System;
using ns0;
using UnityEngine;

// Token: 0x020006F1 RID: 1777
public class CurrencyUpdateView : BaseView
{
	// Token: 0x17000252 RID: 594
	// (get) Token: 0x06002EFC RID: 12028 RVA: 0x0001EF4B File Offset: 0x0001D14B
	// (set) Token: 0x06002EFB RID: 12027 RVA: 0x0001EF42 File Offset: 0x0001D142
	public new bool Boolean_0
	{
		get
		{
			return this._bMoneyCountInited;
		}
		set
		{
			this._bMoneyCountInited = value;
		}
	}

	// Token: 0x06002EFD RID: 12029 RVA: 0x000D9560 File Offset: 0x000D7760
	public override void vmethod_2()
	{
		base.vmethod_2();
		MonoSingleton<AppManager>.Instance.method_0().method_0(new GameUIManager.ViewUpdateCB(this.method_3), false);
		this._currencyUpdateListener = new CurrencyUpdateView.currencyUpdateListener();
		this._currencyUpdateListener.RootView = this;
		this._bMoneyCountInited = false;
		this._fDeltaTime = 0f;
		ServiceWrapperBase<CharacterServiceWrapper>.Instance.method_0(this._currencyUpdateListener);
		ServiceWrapperBase<CharacterServiceWrapper>.Instance.method_22();
	}

	// Token: 0x06002EFE RID: 12030 RVA: 0x000D95D4 File Offset: 0x000D77D4
	public override void vmethod_3()
	{
		base.vmethod_3();
		MonoSingleton<AppManager>.Instance.method_0().method_1(new GameUIManager.ViewUpdateCB(this.method_3));
		ServiceWrapperBase<CharacterServiceWrapper>.Instance.method_1(this._currencyUpdateListener);
		this._currencyUpdateListener = null;
		this._bMoneyCountInited = false;
	}

	// Token: 0x06002EFF RID: 12031 RVA: 0x0001EF53 File Offset: 0x0001D153
	public virtual void vmethod_5(int int_0)
	{
		this._iTarMoneyAmount = int_0;
		if (this._iTarMoneyAmount == this._iCurMoneyAmount)
		{
			return;
		}
		if (this._curStatus == CurrencyUpdateView.SlotMachineAnimaStatus.None)
		{
			this.vmethod_1(true, false);
		}
		else if (this._curStatus != CurrencyUpdateView.SlotMachineAnimaStatus.FadeIn)
		{
			this.vmethod_11();
		}
	}

	// Token: 0x06002F00 RID: 12032 RVA: 0x0000311B File Offset: 0x0000131B
	protected virtual void vmethod_6()
	{
	}

	// Token: 0x06002F01 RID: 12033 RVA: 0x0000311B File Offset: 0x0000131B
	protected virtual void vmethod_7()
	{
	}

	// Token: 0x06002F02 RID: 12034 RVA: 0x0001EF8E File Offset: 0x0001D18E
	protected virtual void vmethod_8()
	{
		this._iCurMoneyAmount = this._iTarMoneyAmount;
	}

	// Token: 0x06002F03 RID: 12035 RVA: 0x0000311B File Offset: 0x0000131B
	protected virtual void vmethod_9()
	{
	}

	// Token: 0x06002F04 RID: 12036 RVA: 0x0001EF9C File Offset: 0x0001D19C
	protected virtual void vmethod_10()
	{
		this._curStatus = CurrencyUpdateView.SlotMachineAnimaStatus.None;
	}

	// Token: 0x06002F05 RID: 12037 RVA: 0x0001EFA5 File Offset: 0x0001D1A5
	protected virtual void vmethod_11()
	{
		this._curStatus = CurrencyUpdateView.SlotMachineAnimaStatus.ShowDelta;
	}

	// Token: 0x06002F06 RID: 12038 RVA: 0x0001EFAE File Offset: 0x0001D1AE
	public virtual void vmethod_12(int int_0)
	{
		if (!this._bMoneyCountInited)
		{
			this._iCurMoneyAmount = int_0;
			this._iTarMoneyAmount = int_0;
			this._bMoneyCountInited = true;
		}
	}

	// Token: 0x06002F07 RID: 12039 RVA: 0x0001EFCD File Offset: 0x0001D1CD
	public virtual void vmethod_13()
	{
		this.vmethod_1(false, false);
		this._curStatus = CurrencyUpdateView.SlotMachineAnimaStatus.FadeOut;
		this.vmethod_9();
		this._fDeltaTime = 0f;
	}

	// Token: 0x06002F08 RID: 12040 RVA: 0x0001EFEF File Offset: 0x0001D1EF
	private void method_3()
	{
		if (!this._bMoneyCountInited)
		{
			return;
		}
		if (this._curStatus == CurrencyUpdateView.SlotMachineAnimaStatus.Normal)
		{
			this._fDeltaTime += Time.deltaTime;
			if (this._fDeltaTime > 1f)
			{
				this.vmethod_13();
			}
		}
	}

	// Token: 0x06002F09 RID: 12041 RVA: 0x0000311B File Offset: 0x0000131B
	public virtual void vmethod_14(bool bool_0 = false)
	{
	}

	// Token: 0x040020DD RID: 8413
	protected const float NORMAL_STATUS_DURTION = 1f;

	// Token: 0x040020DE RID: 8414
	protected int _iCurMoneyAmount;

	// Token: 0x040020DF RID: 8415
	protected int _iTarMoneyAmount;

	// Token: 0x040020E0 RID: 8416
	protected CurrencyUpdateView.SlotMachineAnimaStatus _curStatus;

	// Token: 0x040020E1 RID: 8417
	protected bool _bMoneyCountInited;

	// Token: 0x040020E2 RID: 8418
	protected float _fDeltaTime;

	// Token: 0x040020E3 RID: 8419
	protected CurrencyUpdateView.currencyUpdateListener _currencyUpdateListener;

	// Token: 0x020006F2 RID: 1778
	public enum SlotMachineAnimaStatus
	{
		// Token: 0x040020E5 RID: 8421
		None,
		// Token: 0x040020E6 RID: 8422
		FadeIn,
		// Token: 0x040020E7 RID: 8423
		ShowDelta,
		// Token: 0x040020E8 RID: 8424
		Normal,
		// Token: 0x040020E9 RID: 8425
		FadeOut
	}

	// Token: 0x020006F3 RID: 1779
	protected class currencyUpdateListener : ICharacterServiceNotificationListerner
	{
		// Token: 0x06002F0B RID: 12043 RVA: 0x000D9620 File Offset: 0x000D7820
		public void OnGotMyCurrencies(CurrencyInfo currency)
		{
			if (this.RootView == null)
			{
				return;
			}
			if (!this.RootView.Boolean_0)
			{
				this.RootView.vmethod_12(currency.BondCurrency);
				this.RootView.Boolean_0 = true;
				return;
			}
			this.RootView.vmethod_5(currency.BondCurrency);
		}

		// Token: 0x06002F0C RID: 12044 RVA: 0x0000311B File Offset: 0x0000131B
		public void OnExperienceUpdated(int experience)
		{
		}

		// Token: 0x06002F0D RID: 12045 RVA: 0x0000311B File Offset: 0x0000131B
		public void OnGetPersonalSettings(string strSettings)
		{
		}

		// Token: 0x06002F0E RID: 12046 RVA: 0x0000311B File Offset: 0x0000131B
		public void OnSetPersonalSettings(int iReslut)
		{
		}

		// Token: 0x06002F0F RID: 12047 RVA: 0x0000311B File Offset: 0x0000131B
		public void OnGetCharacterSettings(string strSettings)
		{
		}

		// Token: 0x06002F10 RID: 12048 RVA: 0x0000311B File Offset: 0x0000131B
		public void OnSetCharacterSettings(int iReslut)
		{
		}

		// Token: 0x040020EA RID: 8426
		public CurrencyUpdateView RootView;
	}
}
