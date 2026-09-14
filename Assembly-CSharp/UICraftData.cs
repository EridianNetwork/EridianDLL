using System;
using XsdSettings;

// Token: 0x0200075D RID: 1885
public class UICraftData
{
	// Token: 0x060031ED RID: 12781 RVA: 0x00020889 File Offset: 0x0001EA89
	public UICraftData(WeaponCraftConfig weaponCraftConfig_0, ItemDNA itemDNA_0)
	{
		this._weaponCraftConfig = weaponCraftConfig_0;
		this._weaponItemDNA = itemDNA_0;
	}

	// Token: 0x17000267 RID: 615
	// (get) Token: 0x060031EF RID: 12783 RVA: 0x000208A8 File Offset: 0x0001EAA8
	// (set) Token: 0x060031EE RID: 12782 RVA: 0x0002089F File Offset: 0x0001EA9F
	public ItemDNA ItemDNA_0
	{
		get
		{
			return this._weaponItemDNA;
		}
		set
		{
			this._weaponItemDNA = value;
		}
	}

	// Token: 0x17000268 RID: 616
	// (get) Token: 0x060031F1 RID: 12785 RVA: 0x000208B9 File Offset: 0x0001EAB9
	// (set) Token: 0x060031F0 RID: 12784 RVA: 0x000208B0 File Offset: 0x0001EAB0
	public WeaponCraftConfig WeaponCraftConfig_0
	{
		get
		{
			return this._weaponCraftConfig;
		}
		set
		{
			this.WeaponCraftConfig_0 = value;
		}
	}

	// Token: 0x17000269 RID: 617
	// (get) Token: 0x060031F3 RID: 12787 RVA: 0x000208CA File Offset: 0x0001EACA
	// (set) Token: 0x060031F2 RID: 12786 RVA: 0x000208C1 File Offset: 0x0001EAC1
	public UICraftData.CraftSlotState CraftSlotState_0
	{
		get
		{
			return this._state;
		}
		set
		{
			this._state = value;
		}
	}

	// Token: 0x0400227B RID: 8827
	protected WeaponCraftConfig _weaponCraftConfig;

	// Token: 0x0400227C RID: 8828
	protected ItemDNA _weaponItemDNA;

	// Token: 0x0400227D RID: 8829
	protected UICraftData.CraftSlotState _state;

	// Token: 0x0400227E RID: 8830
	public int CurMatAQuantity;

	// Token: 0x0400227F RID: 8831
	public int CurMatBQuantity;

	// Token: 0x04002280 RID: 8832
	public bool bCanCraft;

	// Token: 0x0200075E RID: 1886
	public enum CraftSlotState
	{
		// Token: 0x04002282 RID: 8834
		None,
		// Token: 0x04002283 RID: 8835
		Locked,
		// Token: 0x04002284 RID: 8836
		UnLocked,
		// Token: 0x04002285 RID: 8837
		Available,
		// Token: 0x04002286 RID: 8838
		Crafted
	}
}
