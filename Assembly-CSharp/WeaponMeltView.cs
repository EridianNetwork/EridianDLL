using System;
using System.Collections.Generic;
using Core;
using ns0;
using XsdSettings;

// Token: 0x0200075F RID: 1887
public class WeaponMeltView : BaseView
{
	// Token: 0x1700026A RID: 618
	// (get) Token: 0x060031F5 RID: 12789 RVA: 0x00020905 File Offset: 0x0001EB05
	// (set) Token: 0x060031F6 RID: 12790 RVA: 0x0002090D File Offset: 0x0001EB0D
	public ParticleManager ParticleManager_0
	{
		get
		{
			return this.m_particleManager;
		}
		set
		{
			this.m_particleManager = value;
		}
	}

	// Token: 0x060031F7 RID: 12791 RVA: 0x0001DF17 File Offset: 0x0001C117
	public override void vmethod_2()
	{
		base.vmethod_2();
	}

	// Token: 0x060031F8 RID: 12792 RVA: 0x00020916 File Offset: 0x0001EB16
	public override void vmethod_3()
	{
		base.vmethod_3();
		this.m_particleManager = null;
	}

	// Token: 0x060031F9 RID: 12793 RVA: 0x0001E0F3 File Offset: 0x0001C2F3
	public override bool vmethod_4()
	{
		if (this.Boolean_1)
		{
			this.Boolean_1 = false;
			return true;
		}
		return base.vmethod_4();
	}

	// Token: 0x060031FA RID: 12794 RVA: 0x000E24D0 File Offset: 0x000E06D0
	protected override void vmethod_1(bool bool_0, bool bool_1 = false)
	{
		base.vmethod_1(bool_0, bool_1);
		this.method_3(null, -1);
		if (this.m_particleManager != null)
		{
			this.m_particleManager.method_2();
		}
		if (this.Boolean_1)
		{
			MonoSingleton<AppManager>.Instance.method_0().vmethod_26(GameUIManager.CursorManager.CursorType.HammerLift);
			this.m_particleManager.Event_0 += this.method_5;
		}
		else
		{
			MonoSingleton<AppManager>.Instance.method_0().vmethod_26(GameUIManager.CursorManager.CursorType.DefaultCursor);
			NPC_UIFlowController.smethod_0().method_3(NPC_UIFlowController.NPC_UIFlowState.None);
			this.m_particleManager.Event_0 -= this.method_5;
		}
	}

	// Token: 0x060031FB RID: 12795 RVA: 0x000E256C File Offset: 0x000E076C
	public void method_3(ItemDNA itemDNA_0, int int_0)
	{
		if (this._meltWeapon == itemDNA_0 && this._inventoryIndex == int_0)
		{
			return;
		}
		this._iCost = -1;
		this._meltWeapon = null;
		this._inventoryIndex = int_0;
		if (itemDNA_0 != null && itemDNA_0.method_3(ItemType.Weapon))
		{
			this._meltWeapon = itemDNA_0;
			if (ServiceWrapperBase<CraftingServiceWrapper>.Instance.vmethod_2())
			{
				this._iCost = ServiceWrapperBase<CraftingServiceWrapper>.Instance.method_0(this._meltWeapon.method_6(), out this._arrMaterialList);
				if (this._arrMaterialList == null)
				{
					DebugUtils.Log(LogCategory.GUI, "Weapon melting config wrong! Weapon:" + this._meltWeapon.method_6().method_4());
				}
			}
		}
		this.vmethod_6();
	}

	// Token: 0x060031FC RID: 12796 RVA: 0x000E2610 File Offset: 0x000E0810
	protected virtual void vmethod_5(SmeltResult smeltResult_0, Dictionary<MaterialType, int> dictionary_0)
	{
		this.method_3(null, -1);
		switch (smeltResult_0)
		{
		case SmeltResult.Success:
			this.m_particleManager.Single_0 = 1f;
			this.m_particleManager.method_4(this.TYPE_MELTING, true, true, null);
			this._dicMaterialGained = dictionary_0;
			this.vmethod_7();
			break;
		case SmeltResult.ShopBought:
			MonoSingleton<AppManager>.Instance.method_0().vmethod_5<HUDWarningView>().vmethod_7(LocalizedString.smethod_0(new LocalizedString("Weapon_Melting_Failure")), new Delegate_EventProc(this.vmethod_9), null);
			break;
		case SmeltResult.NotEnoughCurrency:
			MonoSingleton<AppManager>.Instance.method_0().vmethod_5<HUDWarningView>().vmethod_7(LocalizedString.smethod_0(new LocalizedString("Warning_CurrencyInsufficient")), new Delegate_EventProc(this.vmethod_9), null);
			break;
		}
	}

	// Token: 0x060031FD RID: 12797 RVA: 0x0000311B File Offset: 0x0000131B
	protected virtual void vmethod_6()
	{
	}

	// Token: 0x060031FE RID: 12798 RVA: 0x0000311B File Offset: 0x0000131B
	protected virtual void vmethod_7()
	{
	}

	// Token: 0x060031FF RID: 12799 RVA: 0x000E26D8 File Offset: 0x000E08D8
	protected void method_4()
	{
		if (this.m_particleManager.Boolean_0)
		{
			return;
		}
		this._meltingIndex = this._inventoryIndex;
		if (this._meltingIndex == -1)
		{
			return;
		}
		if (ServiceWrapperBase<InventoryServiceWrapper>.Instance.method_39(null))
		{
			return;
		}
		if (this._meltWeapon.method_6().m_generationSource == GenerationSource.Shop)
		{
			MonoSingleton<AppManager>.Instance.method_0().vmethod_5<HUDWarningView>().vmethod_7(LocalizedString.smethod_0(new LocalizedString("Weapon_Melting_Failure")), new Delegate_EventProc(this.vmethod_8), null);
			return;
		}
		if (this._meltWeapon.method_4())
		{
			MonoSingleton<AppManager>.Instance.method_0().vmethod_5<HUDWarningView>().vmethod_7(LocalizedString.smethod_0(new LocalizedString("Warning_Weapon_Melting")), new Delegate_EventProc(this.vmethod_10), new Delegate_EventProc(this.vmethod_8));
		}
		else
		{
			this.vmethod_10();
		}
	}

	// Token: 0x06003200 RID: 12800 RVA: 0x00020925 File Offset: 0x0001EB25
	public void method_5()
	{
		this.m_particleManager.method_2();
	}

	// Token: 0x06003201 RID: 12801 RVA: 0x00020932 File Offset: 0x0001EB32
	protected virtual void vmethod_8()
	{
		DebugUtils.Log(LogCategory.GUI, "Player cancelled weapon melt!");
	}

	// Token: 0x06003202 RID: 12802 RVA: 0x0000311B File Offset: 0x0000131B
	protected virtual void vmethod_9()
	{
	}

	// Token: 0x06003203 RID: 12803 RVA: 0x0002093F File Offset: 0x0001EB3F
	protected virtual void vmethod_10()
	{
		if (ServiceWrapperBase<CraftingServiceWrapper>.Instance.vmethod_2())
		{
			ServiceWrapperBase<CraftingServiceWrapper>.Instance.method_1(new OnSmeltWeapon(this.vmethod_5), this._meltingIndex);
			MonoSingleton<GuidanceTipsManager>.Instance.method_2("guidance_melt");
		}
	}

	// Token: 0x04002287 RID: 8839
	protected ItemDNA _meltWeapon;

	// Token: 0x04002288 RID: 8840
	protected int _inventoryIndex = -1;

	// Token: 0x04002289 RID: 8841
	protected int _meltingIndex = -1;

	// Token: 0x0400228A RID: 8842
	protected int _iCost = -1;

	// Token: 0x0400228B RID: 8843
	protected AcquiredMaterial[] _arrMaterialList;

	// Token: 0x0400228C RID: 8844
	protected Dictionary<MaterialType, int> _dicMaterialGained;

	// Token: 0x0400228D RID: 8845
	protected ParticleManager m_particleManager;

	// Token: 0x0400228E RID: 8846
	protected string TYPE_GARBAGE = string.Empty;

	// Token: 0x0400228F RID: 8847
	protected string TYPE_MELTING = "PTL_Weapon_Melting";
}
