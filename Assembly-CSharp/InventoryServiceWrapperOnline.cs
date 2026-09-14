using System;
using ns0;
using XsdSettings;

// Token: 0x0200030E RID: 782
public class InventoryServiceWrapperOnline : IInventoryServiceWrapper, IServiceWrapper
{
	// Token: 0x06001260 RID: 4704 RVA: 0x0000E58C File Offset: 0x0000C78C
	public void method_0(Inventory inventory_0)
	{
		ServiceWrapperBase<InventoryServiceWrapper>.Instance.method_2(InventoryServiceWrapper.InventoryUpdateType.FullUpdate);
	}

	// Token: 0x06001261 RID: 4705 RVA: 0x0000E599 File Offset: 0x0000C799
	public void method_1(int int_0, Inventory inventory_0)
	{
		this.m_inventory = inventory_0;
		ServiceWrapperBase<InventoryServiceWrapper>.Instance.method_2(InventoryServiceWrapper.InventoryUpdateType.FullUpdate);
	}

	// Token: 0x06001262 RID: 4706 RVA: 0x00076828 File Offset: 0x00074A28
	public void imethod_0()
	{
		if (!this.m_isInitializing)
		{
			this.m_isInitializing = true;
			OnAccessSingleton<IInventoryService, InventoryService, InventoryServiceOffline>.Prop_0.imethod_6(new InventoryCallback(this.method_0));
			OnAccessSingleton<IInventoryService, InventoryService, InventoryServiceOffline>.Prop_0.imethod_0(OnlineService.s_characterId, new GetInventoryCallback(this.method_1));
		}
	}

	// Token: 0x06001263 RID: 4707 RVA: 0x0000E5AD File Offset: 0x0000C7AD
	public bool imethod_1()
	{
		return this.m_inventory != null;
	}

	// Token: 0x06001264 RID: 4708 RVA: 0x0000E5BB File Offset: 0x0000C7BB
	public ItemDNA imethod_2(int int_0)
	{
		return this.m_inventory.method_0(int_0);
	}

	// Token: 0x06001265 RID: 4709 RVA: 0x0000E5C9 File Offset: 0x0000C7C9
	public ItemDNA imethod_3(byte byte_0)
	{
		return this.m_inventory.method_1(byte_0);
	}

	// Token: 0x06001266 RID: 4710 RVA: 0x0000E5D7 File Offset: 0x0000C7D7
	public ItemDNA imethod_4()
	{
		return this.m_inventory.method_18();
	}

	// Token: 0x06001267 RID: 4711 RVA: 0x0000E5E4 File Offset: 0x0000C7E4
	public ItemDNA imethod_5()
	{
		return this.m_inventory.method_16();
	}

	// Token: 0x06001268 RID: 4712 RVA: 0x0000E5F1 File Offset: 0x0000C7F1
	public ItemDNA imethod_6(AvatarSubPart avatarSubPart_0)
	{
		return this.m_inventory.method_31(avatarSubPart_0);
	}

	// Token: 0x06001269 RID: 4713 RVA: 0x0000E5FF File Offset: 0x0000C7FF
	public byte imethod_7()
	{
		return this.m_inventory.method_3();
	}

	// Token: 0x0600126A RID: 4714 RVA: 0x0000E60C File Offset: 0x0000C80C
	public int imethod_8(AmmoType ammoType_0)
	{
		return this.m_inventory.method_4(ammoType_0);
	}

	// Token: 0x0600126B RID: 4715 RVA: 0x0000E61A File Offset: 0x0000C81A
	public int imethod_9(AmmoType ammoType_0)
	{
		return this.m_inventory.method_5(ammoType_0);
	}

	// Token: 0x0600126C RID: 4716 RVA: 0x0000E628 File Offset: 0x0000C828
	public int imethod_10()
	{
		return this.m_inventory.method_37();
	}

	// Token: 0x0600126D RID: 4717 RVA: 0x0000E635 File Offset: 0x0000C835
	public int imethod_11()
	{
		return this.m_inventory.Int32_0;
	}

	// Token: 0x0600126E RID: 4718 RVA: 0x0000E642 File Offset: 0x0000C842
	public void imethod_12(byte byte_0, byte byte_1)
	{
		this.m_inventory.method_6(byte_0, byte_1);
	}

	// Token: 0x0600126F RID: 4719 RVA: 0x0000E651 File Offset: 0x0000C851
	public void imethod_13(byte byte_0, byte byte_1)
	{
		this.m_inventory.method_7(byte_0, byte_1);
	}

	// Token: 0x06001270 RID: 4720 RVA: 0x0000E660 File Offset: 0x0000C860
	public void imethod_14(byte byte_0, byte byte_1)
	{
		this.m_inventory.method_9(byte_0, byte_1);
	}

	// Token: 0x06001271 RID: 4721 RVA: 0x0000E66F File Offset: 0x0000C86F
	public void imethod_15(byte byte_0)
	{
		this.m_inventory.method_11(byte_0);
	}

	// Token: 0x06001272 RID: 4722 RVA: 0x0000E67D File Offset: 0x0000C87D
	public void imethod_17()
	{
		this.m_inventory.method_30();
	}

	// Token: 0x06001273 RID: 4723 RVA: 0x0000E68A File Offset: 0x0000C88A
	public void imethod_18()
	{
		this.m_inventory.method_22();
	}

	// Token: 0x06001274 RID: 4724 RVA: 0x0000E697 File Offset: 0x0000C897
	public void imethod_21(AvatarSubPart avatarSubPart_0)
	{
		this.m_inventory.method_33(avatarSubPart_0);
	}

	// Token: 0x06001275 RID: 4725 RVA: 0x0000E6A5 File Offset: 0x0000C8A5
	public void imethod_16(byte byte_0)
	{
		this.m_inventory.method_20(byte_0);
	}

	// Token: 0x06001276 RID: 4726 RVA: 0x0000E6B3 File Offset: 0x0000C8B3
	public void imethod_19(byte byte_0)
	{
		this.m_inventory.method_23(byte_0);
	}

	// Token: 0x06001277 RID: 4727 RVA: 0x0000E6C1 File Offset: 0x0000C8C1
	public void imethod_20(byte byte_0)
	{
		this.m_inventory.method_32((int)byte_0);
	}

	// Token: 0x06001278 RID: 4728 RVA: 0x0000E6CF File Offset: 0x0000C8CF
	public void imethod_23()
	{
		this.m_inventory.method_26();
	}

	// Token: 0x06001279 RID: 4729 RVA: 0x0000E6DC File Offset: 0x0000C8DC
	public void imethod_24(int int_0, int int_1)
	{
		this.m_inventory.method_25(int_0, int_1);
	}

	// Token: 0x0600127A RID: 4730 RVA: 0x0000E6EB File Offset: 0x0000C8EB
	public void imethod_22(byte byte_0)
	{
		this.m_inventory.method_8(byte_0);
	}

	// Token: 0x0600127B RID: 4731 RVA: 0x0000E6F9 File Offset: 0x0000C8F9
	public void imethod_25(byte byte_0)
	{
		this.m_inventory.method_12(byte_0);
	}

	// Token: 0x0600127C RID: 4732 RVA: 0x0000E707 File Offset: 0x0000C907
	public bool imethod_26(byte byte_0)
	{
		return this.m_inventory.method_1(byte_0) != null;
	}

	// Token: 0x0600127D RID: 4733 RVA: 0x0000311B File Offset: 0x0000131B
	public void imethod_27(byte byte_0, byte byte_1)
	{
	}

	// Token: 0x0600127E RID: 4734 RVA: 0x0000311B File Offset: 0x0000131B
	public void imethod_28(byte byte_0, byte byte_1, bool bool_0)
	{
	}

	// Token: 0x0600127F RID: 4735 RVA: 0x0000311B File Offset: 0x0000131B
	public void imethod_29()
	{
	}

	// Token: 0x06001280 RID: 4736 RVA: 0x00003727 File Offset: 0x00001927
	public ItemDNA[] imethod_30()
	{
		return null;
	}

	// Token: 0x06001281 RID: 4737 RVA: 0x0000311D File Offset: 0x0000131D
	public bool imethod_31(ItemDNA itemDNA_0)
	{
		return false;
	}

	// Token: 0x04000E28 RID: 3624
	private bool m_isInitializing;

	// Token: 0x04000E29 RID: 3625
	private Inventory m_inventory;
}
