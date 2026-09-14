using System;
using ns0;
using XsdSettings;

// Token: 0x0200030F RID: 783
public class InventoryServiceWrapperSession : IInventoryServiceWrapper, IServiceWrapper
{
	// Token: 0x06001283 RID: 4739 RVA: 0x0000311B File Offset: 0x0000131B
	public void imethod_0()
	{
	}

	// Token: 0x06001284 RID: 4740 RVA: 0x00076878 File Offset: 0x00074A78
	public bool imethod_1()
	{
		this.m_localPlayer = MonoSingleton<Session>.Instance.GetLocalPlayer().GetEntity() as EntityPlayer;
		if (this.m_localPlayer)
		{
			this.m_equipment = this.m_localPlayer.vmethod_19() as EquipmentInventoryEntityPlayer;
			if (this.m_equipment)
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x06001285 RID: 4741 RVA: 0x0000E71B File Offset: 0x0000C91B
	public ItemDNA imethod_2(int int_0)
	{
		return this.m_equipment.method_22(int_0);
	}

	// Token: 0x06001286 RID: 4742 RVA: 0x0000E729 File Offset: 0x0000C929
	public ItemDNA imethod_3(byte byte_0)
	{
		return this.m_equipment.method_27(byte_0);
	}

	// Token: 0x06001287 RID: 4743 RVA: 0x0000E737 File Offset: 0x0000C937
	public byte imethod_7()
	{
		return this.m_equipment.vmethod_55();
	}

	// Token: 0x06001288 RID: 4744 RVA: 0x0000E744 File Offset: 0x0000C944
	public int imethod_8(AmmoType ammoType_0)
	{
		return this.m_equipment.vmethod_13(ammoType_0);
	}

	// Token: 0x06001289 RID: 4745 RVA: 0x0000E752 File Offset: 0x0000C952
	public int imethod_9(AmmoType ammoType_0)
	{
		return this.m_equipment.vmethod_10(ammoType_0);
	}

	// Token: 0x0600128A RID: 4746 RVA: 0x0000E760 File Offset: 0x0000C960
	public int imethod_10()
	{
		return this.m_equipment.method_11();
	}

	// Token: 0x0600128B RID: 4747 RVA: 0x0000E76D File Offset: 0x0000C96D
	public int imethod_11()
	{
		return this.m_equipment.method_12();
	}

	// Token: 0x0600128C RID: 4748 RVA: 0x0000E77A File Offset: 0x0000C97A
	public void imethod_12(byte byte_0, byte byte_1)
	{
		if (this.m_localPlayer)
		{
			this.m_localPlayer.vmethod_77(byte_0, byte_1);
		}
	}

	// Token: 0x0600128D RID: 4749 RVA: 0x0000E796 File Offset: 0x0000C996
	public void imethod_13(byte byte_0, byte byte_1)
	{
		if (this.m_localPlayer)
		{
			this.m_localPlayer.vmethod_78(byte_0, byte_1);
		}
	}

	// Token: 0x0600128E RID: 4750 RVA: 0x0000E7B2 File Offset: 0x0000C9B2
	public void imethod_14(byte byte_0, byte byte_1)
	{
		if (this.m_localPlayer)
		{
			this.m_localPlayer.vmethod_67(byte_0, byte_1);
		}
	}

	// Token: 0x0600128F RID: 4751 RVA: 0x0000E7CE File Offset: 0x0000C9CE
	public void imethod_15(byte byte_0)
	{
		if (this.m_localPlayer)
		{
			this.m_localPlayer.vmethod_68(byte_0);
		}
	}

	// Token: 0x06001290 RID: 4752 RVA: 0x0000E7E9 File Offset: 0x0000C9E9
	public void imethod_17()
	{
		if (this.m_localPlayer)
		{
			this.m_localPlayer.vmethod_73();
		}
	}

	// Token: 0x06001291 RID: 4753 RVA: 0x0000E803 File Offset: 0x0000CA03
	public void imethod_18()
	{
		if (this.m_localPlayer)
		{
			this.m_localPlayer.vmethod_74();
		}
	}

	// Token: 0x06001292 RID: 4754 RVA: 0x0000E81D File Offset: 0x0000CA1D
	public void imethod_21(AvatarSubPart avatarSubPart_0)
	{
		if (this.m_localPlayer)
		{
			this.m_localPlayer.vmethod_75((byte)avatarSubPart_0);
		}
	}

	// Token: 0x06001293 RID: 4755 RVA: 0x0000E839 File Offset: 0x0000CA39
	public void imethod_16(byte byte_0)
	{
		if (this.m_localPlayer)
		{
			this.m_localPlayer.vmethod_69(byte_0);
		}
	}

	// Token: 0x06001294 RID: 4756 RVA: 0x0000E854 File Offset: 0x0000CA54
	public void imethod_23()
	{
		if (this.m_localPlayer)
		{
			this.m_localPlayer.vmethod_70();
		}
	}

	// Token: 0x06001295 RID: 4757 RVA: 0x0000E86E File Offset: 0x0000CA6E
	public void imethod_24(int int_0, int int_1)
	{
		if (this.m_localPlayer)
		{
			OnAccessSingleton<IInventoryService, InventoryService, InventoryServiceOffline>.Prop_0.imethod_0(this.m_localPlayer.method_20(), null).method_25(int_0, int_1);
		}
	}

	// Token: 0x06001296 RID: 4758 RVA: 0x0000E89A File Offset: 0x0000CA9A
	public ItemDNA imethod_4()
	{
		if (this.m_localPlayer == null)
		{
			return null;
		}
		return this.m_localPlayer.method_39();
	}

	// Token: 0x06001297 RID: 4759 RVA: 0x0000E8B7 File Offset: 0x0000CAB7
	public void imethod_19(byte byte_0)
	{
		if (this.m_localPlayer)
		{
			this.m_localPlayer.vmethod_71(byte_0);
		}
	}

	// Token: 0x06001298 RID: 4760 RVA: 0x0000E8D2 File Offset: 0x0000CAD2
	public void imethod_20(byte byte_0)
	{
		if (this.m_localPlayer)
		{
			this.m_localPlayer.vmethod_72(byte_0);
		}
	}

	// Token: 0x06001299 RID: 4761 RVA: 0x0000E8ED File Offset: 0x0000CAED
	public ItemDNA imethod_5()
	{
		if (this.m_localPlayer == null)
		{
			return null;
		}
		return this.m_localPlayer.method_40();
	}

	// Token: 0x0600129A RID: 4762 RVA: 0x0000E90A File Offset: 0x0000CB0A
	public ItemDNA imethod_6(AvatarSubPart avatarSubPart_0)
	{
		if (this.m_localPlayer == null)
		{
			return null;
		}
		return this.m_localPlayer.method_41(avatarSubPart_0);
	}

	// Token: 0x0600129B RID: 4763 RVA: 0x0000E928 File Offset: 0x0000CB28
	public void imethod_22(byte byte_0)
	{
		if (this.m_localPlayer)
		{
			this.m_localPlayer.vmethod_76(byte_0);
		}
	}

	// Token: 0x0600129C RID: 4764 RVA: 0x0000E943 File Offset: 0x0000CB43
	public void imethod_25(byte byte_0)
	{
		if (this.m_localPlayer && this.m_localPlayer.method_88(byte_0))
		{
			this.m_localPlayer.vmethod_66(byte_0);
		}
	}

	// Token: 0x0600129D RID: 4765 RVA: 0x0000E96C File Offset: 0x0000CB6C
	public bool imethod_26(byte byte_0)
	{
		return this.m_equipment.method_27(byte_0) != null;
	}

	// Token: 0x0600129E RID: 4766 RVA: 0x0000311B File Offset: 0x0000131B
	public void imethod_27(byte byte_0, byte byte_1)
	{
	}

	// Token: 0x0600129F RID: 4767 RVA: 0x0000311B File Offset: 0x0000131B
	public void imethod_28(byte byte_0, byte byte_1, bool bool_0)
	{
	}

	// Token: 0x060012A0 RID: 4768 RVA: 0x0000311B File Offset: 0x0000131B
	public void imethod_29()
	{
	}

	// Token: 0x060012A1 RID: 4769 RVA: 0x00003727 File Offset: 0x00001927
	public ItemDNA[] imethod_30()
	{
		return null;
	}

	// Token: 0x060012A2 RID: 4770 RVA: 0x0000E980 File Offset: 0x0000CB80
	public bool imethod_31(ItemDNA itemDNA_0)
	{
		return this.m_equipment != null && this.m_equipment.vmethod_40(itemDNA_0);
	}

	// Token: 0x04000E2A RID: 3626
	private EquipmentInventoryEntityPlayer m_equipment;

	// Token: 0x04000E2B RID: 3627
	private EntityPlayer m_localPlayer;
}
