using System;
using ns0;
using XsdSettings;

// Token: 0x02000310 RID: 784
public class InventoryServiceWrapperTown : IInventoryServiceWrapper, IServiceWrapper
{
	// Token: 0x060012A4 RID: 4772 RVA: 0x0000E58C File Offset: 0x0000C78C
	public void method_0(Inventory inventory_0)
	{
		ServiceWrapperBase<InventoryServiceWrapper>.Instance.method_2(InventoryServiceWrapper.InventoryUpdateType.FullUpdate);
	}

	// Token: 0x060012A5 RID: 4773 RVA: 0x0000E99E File Offset: 0x0000CB9E
	public void method_1(int int_0, Inventory inventory_0)
	{
		this.m_inventory = inventory_0;
		ServiceWrapperBase<InventoryServiceWrapper>.Instance.method_2(InventoryServiceWrapper.InventoryUpdateType.FullUpdate);
	}

	// Token: 0x060012A6 RID: 4774 RVA: 0x0000E9B2 File Offset: 0x0000CBB2
	public void method_2(Warehouse warehouse_0)
	{
		this.m_warehouse = warehouse_0;
		ServiceWrapperBase<InventoryServiceWrapper>.Instance.method_5(InventoryServiceWrapper.InventoryUpdateType.FullUpdate);
	}

	// Token: 0x060012A7 RID: 4775 RVA: 0x000768D4 File Offset: 0x00074AD4
	public void imethod_0()
	{
		if (!this.m_isInitializing)
		{
			this.m_isInitializing = true;
			OnAccessSingleton<IInventoryService, InventoryService, InventoryServiceOffline>.Prop_0.imethod_6(new InventoryCallback(this.method_0));
			OnAccessSingleton<IInventoryService, InventoryService, InventoryServiceOffline>.Prop_0.imethod_0(OnlineService.s_characterId, new GetInventoryCallback(this.method_1));
			OnAccessSingleton<IInventoryService, InventoryService, InventoryServiceOffline>.Prop_0.imethod_10(new WarehouseCallback(this.method_2));
			OnAccessSingleton<IInventoryService, InventoryService, InventoryServiceOffline>.Prop_0.imethod_5();
		}
	}

	// Token: 0x060012A8 RID: 4776 RVA: 0x00076944 File Offset: 0x00074B44
	public bool imethod_1()
	{
		this.m_localPlayer = MonoSingleton<Session>.Instance.GetLocalPlayer().GetEntity() as EntityPlayer;
		if (this.m_localPlayer)
		{
			this.m_equipment = this.m_localPlayer.vmethod_19() as EquipmentInventoryEntityPlayerTown;
			if (this.m_equipment)
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x060012A9 RID: 4777 RVA: 0x0000E9C6 File Offset: 0x0000CBC6
	public ItemDNA imethod_2(int int_0)
	{
		return this.m_inventory.method_0(int_0);
	}

	// Token: 0x060012AA RID: 4778 RVA: 0x0000E9D4 File Offset: 0x0000CBD4
	public ItemDNA imethod_3(byte byte_0)
	{
		if (this.m_inventory == null)
		{
			return null;
		}
		return this.m_inventory.method_1(byte_0);
	}

	// Token: 0x060012AB RID: 4779 RVA: 0x000769A0 File Offset: 0x00074BA0
	public byte imethod_7()
	{
		if (this.m_localPlayer == null)
		{
			return 0;
		}
		EquipmentInventoryEntityPlayerTown equipmentInventoryEntityPlayerTown = this.m_localPlayer.vmethod_19() as EquipmentInventoryEntityPlayerTown;
		if (equipmentInventoryEntityPlayerTown == null)
		{
			return 0;
		}
		return equipmentInventoryEntityPlayerTown.vmethod_55();
	}

	// Token: 0x060012AC RID: 4780 RVA: 0x0000E9EC File Offset: 0x0000CBEC
	public int imethod_8(AmmoType ammoType_0)
	{
		if (this.m_inventory == null)
		{
			return 0;
		}
		return this.m_inventory.method_4(ammoType_0);
	}

	// Token: 0x060012AD RID: 4781 RVA: 0x0000EA04 File Offset: 0x0000CC04
	public int imethod_9(AmmoType ammoType_0)
	{
		if (this.m_inventory == null)
		{
			return 0;
		}
		return this.m_inventory.method_5(ammoType_0);
	}

	// Token: 0x060012AE RID: 4782 RVA: 0x0000EA1C File Offset: 0x0000CC1C
	public int imethod_10()
	{
		if (this.m_inventory == null)
		{
			return 0;
		}
		return this.m_inventory.method_37();
	}

	// Token: 0x060012AF RID: 4783 RVA: 0x0000EA33 File Offset: 0x0000CC33
	public int imethod_11()
	{
		if (this.m_inventory == null)
		{
			return 0;
		}
		return this.m_inventory.Int32_0;
	}

	// Token: 0x060012B0 RID: 4784 RVA: 0x0000EA4A File Offset: 0x0000CC4A
	public void imethod_12(byte byte_0, byte byte_1)
	{
		if (this.m_inventory == null)
		{
			return;
		}
		this.m_inventory.method_6(byte_0, byte_1);
	}

	// Token: 0x060012B1 RID: 4785 RVA: 0x000769E0 File Offset: 0x00074BE0
	public void imethod_13(byte byte_0, byte byte_1)
	{
		if (this.m_inventory != null)
		{
			this.m_inventory.method_7(byte_0, byte_1);
		}
		if (this.m_equipment != null)
		{
			this.m_equipment.method_41();
		}
		if (this.m_localPlayer)
		{
			this.m_localPlayer.vmethod_78(byte_0, byte_1);
		}
	}

	// Token: 0x060012B2 RID: 4786 RVA: 0x00076A38 File Offset: 0x00074C38
	public bool method_3(byte byte_0)
	{
		ItemDNA itemDNA = this.m_inventory.method_0((int)byte_0);
		return itemDNA.method_5(this.m_localPlayer);
	}

	// Token: 0x060012B3 RID: 4787 RVA: 0x00076A60 File Offset: 0x00074C60
	public void imethod_14(byte byte_0, byte byte_1)
	{
		if (!this.method_3(byte_0))
		{
			ServiceWrapperBase<InventoryServiceWrapper>.Instance.method_2(InventoryServiceWrapper.InventoryUpdateType.EquipItemFail);
			return;
		}
		this.m_inventory.method_9(byte_0, byte_1);
		this.m_equipment.method_41();
		if (this.m_localPlayer)
		{
			this.m_localPlayer.vmethod_67(byte_0, byte_1);
		}
		this.imethod_25(byte_1);
	}

	// Token: 0x060012B4 RID: 4788 RVA: 0x0000EA62 File Offset: 0x0000CC62
	public void imethod_15(byte byte_0)
	{
		if (this.imethod_7() == byte_0)
		{
			return;
		}
		this.m_inventory.method_11(byte_0);
		this.m_equipment.method_41();
		if (this.m_localPlayer)
		{
			this.m_localPlayer.vmethod_68(byte_0);
		}
	}

	// Token: 0x060012B5 RID: 4789 RVA: 0x0000311B File Offset: 0x0000131B
	public void imethod_17()
	{
	}

	// Token: 0x060012B6 RID: 4790 RVA: 0x0000311B File Offset: 0x0000131B
	public void imethod_18()
	{
	}

	// Token: 0x060012B7 RID: 4791 RVA: 0x0000EA9E File Offset: 0x0000CC9E
	public void imethod_21(AvatarSubPart avatarSubPart_0)
	{
		this.m_inventory.method_33(avatarSubPart_0);
		if (this.m_localPlayer)
		{
			this.m_localPlayer.vmethod_75((byte)avatarSubPart_0);
		}
	}

	// Token: 0x060012B8 RID: 4792 RVA: 0x00076ABC File Offset: 0x00074CBC
	public void imethod_16(byte byte_0)
	{
		if (!this.method_3(byte_0))
		{
			ServiceWrapperBase<InventoryServiceWrapper>.Instance.method_2(InventoryServiceWrapper.InventoryUpdateType.EquipItemFail);
			return;
		}
		if (this.m_inventory != null)
		{
			this.m_inventory.method_20(byte_0);
		}
		if (this.m_localPlayer)
		{
			this.m_localPlayer.vmethod_69(byte_0);
		}
	}

	// Token: 0x060012B9 RID: 4793 RVA: 0x0000EAC6 File Offset: 0x0000CCC6
	public ItemDNA imethod_4()
	{
		if (this.m_inventory == null)
		{
			return null;
		}
		return this.m_inventory.method_18();
	}

	// Token: 0x060012BA RID: 4794 RVA: 0x0000EADD File Offset: 0x0000CCDD
	public void imethod_23()
	{
		if (this.m_inventory != null)
		{
			this.m_inventory.method_26();
		}
	}

	// Token: 0x060012BB RID: 4795 RVA: 0x0000EAF2 File Offset: 0x0000CCF2
	public void imethod_24(int int_0, int int_1)
	{
		if (this.m_inventory != null)
		{
			this.m_inventory.method_25(int_0, int_1);
		}
	}

	// Token: 0x060012BC RID: 4796 RVA: 0x00076B0C File Offset: 0x00074D0C
	public void imethod_19(byte byte_0)
	{
		if (!this.method_3(byte_0))
		{
			ServiceWrapperBase<InventoryServiceWrapper>.Instance.method_2(InventoryServiceWrapper.InventoryUpdateType.EquipItemFail);
			return;
		}
		if (this.m_inventory != null)
		{
			this.m_inventory.method_23(byte_0);
		}
		if (this.m_localPlayer)
		{
			this.m_localPlayer.vmethod_71(byte_0);
		}
	}

	// Token: 0x060012BD RID: 4797 RVA: 0x00076B5C File Offset: 0x00074D5C
	public void imethod_20(byte byte_0)
	{
		if (!this.method_3(byte_0))
		{
			ServiceWrapperBase<InventoryServiceWrapper>.Instance.method_2(InventoryServiceWrapper.InventoryUpdateType.EquipItemFail);
			return;
		}
		ItemDNA itemDNA = this.m_inventory.method_0((int)byte_0);
		if (itemDNA != null && itemDNA.method_9() != null)
		{
			if (this.m_inventory != null)
			{
				this.m_inventory.method_32((int)byte_0);
			}
			if (this.m_localPlayer)
			{
				this.m_localPlayer.vmethod_72((byte)itemDNA.method_9().m_avatarSubpart);
			}
			return;
		}
	}

	// Token: 0x060012BE RID: 4798 RVA: 0x0000EB09 File Offset: 0x0000CD09
	public ItemDNA imethod_5()
	{
		return this.m_inventory.method_16();
	}

	// Token: 0x060012BF RID: 4799 RVA: 0x0000EB16 File Offset: 0x0000CD16
	public ItemDNA imethod_6(AvatarSubPart avatarSubPart_0)
	{
		return this.m_inventory.method_31(avatarSubPart_0);
	}

	// Token: 0x060012C0 RID: 4800 RVA: 0x0000EB24 File Offset: 0x0000CD24
	public void imethod_22(byte byte_0)
	{
		this.m_inventory.method_8(byte_0);
	}

	// Token: 0x060012C1 RID: 4801 RVA: 0x00076BD0 File Offset: 0x00074DD0
	public void imethod_25(byte byte_0)
	{
		if (!(this.m_localPlayer == null) && this.m_localPlayer.method_88(byte_0))
		{
			this.m_inventory.method_12(byte_0);
			if (this.m_localPlayer)
			{
				this.m_localPlayer.vmethod_66(byte_0);
				EquipmentInventoryEntityPlayerTown equipmentInventoryEntityPlayerTown = this.m_localPlayer.vmethod_19() as EquipmentInventoryEntityPlayerTown;
				if (equipmentInventoryEntityPlayerTown != null)
				{
					equipmentInventoryEntityPlayerTown.vmethod_54(byte_0);
				}
			}
			return;
		}
	}

	// Token: 0x060012C2 RID: 4802 RVA: 0x0000EB32 File Offset: 0x0000CD32
	public bool imethod_26(byte byte_0)
	{
		return this.m_equipment.method_27(byte_0) != null && this.m_inventory.method_1(byte_0) != null;
	}

	// Token: 0x060012C3 RID: 4803 RVA: 0x0000EB57 File Offset: 0x0000CD57
	public void imethod_27(byte byte_0, byte byte_1)
	{
		if (this.m_warehouse != null)
		{
			PhotonNetwork.onlinePeer.method_3(98, new object[] { byte_0, byte_1 });
		}
	}

	// Token: 0x060012C4 RID: 4804 RVA: 0x0000EB86 File Offset: 0x0000CD86
	public void imethod_28(byte byte_0, byte byte_1, bool bool_0)
	{
		if (this.m_warehouse != null)
		{
			PhotonNetwork.onlinePeer.method_3(97, new object[] { byte_0, byte_1, bool_0 });
		}
	}

	// Token: 0x060012C5 RID: 4805 RVA: 0x0000EBBE File Offset: 0x0000CDBE
	public void imethod_29()
	{
		if (this.m_warehouse != null)
		{
			OnAccessSingleton<IInventoryService, InventoryService, InventoryServiceOffline>.Prop_0.imethod_5();
		}
	}

	// Token: 0x060012C6 RID: 4806 RVA: 0x0000EBD2 File Offset: 0x0000CDD2
	public ItemDNA[] imethod_30()
	{
		if (this.m_warehouse != null)
		{
			return this.m_warehouse.method_1();
		}
		return null;
	}

	// Token: 0x060012C7 RID: 4807 RVA: 0x0000EBE9 File Offset: 0x0000CDE9
	public bool imethod_31(ItemDNA itemDNA_0)
	{
		return this.m_inventory.method_36();
	}

	// Token: 0x04000E2C RID: 3628
	private bool m_isInitializing;

	// Token: 0x04000E2D RID: 3629
	private Inventory m_inventory;

	// Token: 0x04000E2E RID: 3630
	private Warehouse m_warehouse;

	// Token: 0x04000E2F RID: 3631
	private EquipmentInventoryEntityPlayerTown m_equipment;

	// Token: 0x04000E30 RID: 3632
	private EntityPlayer m_localPlayer;
}
