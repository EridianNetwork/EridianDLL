using System;
using System.Collections.Generic;
using ns0;

// Token: 0x020006EA RID: 1770
public class CashShopView : BaseView
{
	// Token: 0x06002EB2 RID: 11954 RVA: 0x0001ED0D File Offset: 0x0001CF0D
	public override void vmethod_2()
	{
		base.vmethod_2();
		CashShopManager.CashShopManager_0.method_0();
		MonoSingleton<AppManager>.Instance.method_0().method_6(this);
	}

	// Token: 0x06002EB3 RID: 11955 RVA: 0x0001ED2F File Offset: 0x0001CF2F
	public override void vmethod_3()
	{
		base.vmethod_3();
		MonoSingleton<AppManager>.Instance.method_0().method_7(this);
		CashShopManager.CashShopManager_0.method_1();
		this._bVisible = false;
	}

	// Token: 0x06002EB4 RID: 11956 RVA: 0x000D8950 File Offset: 0x000D6B50
	public override bool OnShortCutCMD(string command)
	{
		if (MonoSingleton<Session>.Instance == null)
		{
			return false;
		}
		if (!MonoSingleton<Session>.Instance.method_16())
		{
			return false;
		}
		PlayerInfoSync localPlayer = MonoSingleton<Session>.Instance.GetLocalPlayer();
		if (localPlayer == null)
		{
			return false;
		}
		Entity entity = localPlayer.GetEntity();
		if (entity == null)
		{
			return false;
		}
		PlayerController component = entity.GetComponent<PlayerController>();
		if (component == null)
		{
			return false;
		}
		if (!this.Boolean_0)
		{
			return false;
		}
		this.Boolean_1 = !this.Boolean_1;
		return true;
	}

	// Token: 0x06002EB5 RID: 11957 RVA: 0x0001ED58 File Offset: 0x0001CF58
	public override bool vmethod_4()
	{
		if (this.Boolean_1)
		{
			this.vmethod_1(false, false);
			return true;
		}
		return base.vmethod_4();
	}

	// Token: 0x06002EB6 RID: 11958 RVA: 0x0001E1F6 File Offset: 0x0001C3F6
	protected override void vmethod_1(bool bool_0, bool bool_1 = false)
	{
		base.vmethod_1(bool_0, bool_1);
	}

	// Token: 0x06002EB7 RID: 11959 RVA: 0x0000311B File Offset: 0x0000131B
	public virtual void vmethod_5(CurrencyInfo currencyInfo_0)
	{
	}

	// Token: 0x06002EB8 RID: 11960 RVA: 0x0000311B File Offset: 0x0000131B
	protected virtual void vmethod_6()
	{
	}

	// Token: 0x06002EB9 RID: 11961 RVA: 0x0001ED72 File Offset: 0x0001CF72
	public virtual void vmethod_7(List<UICashShopItemData> list_0)
	{
		this.vmethod_6();
	}
}
