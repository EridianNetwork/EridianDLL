using System;
using System.Collections.Generic;
using Core;
using ns0;
using XsdSettings;

// Token: 0x0200030A RID: 778
public class InventoryServiceWrapper : ServiceWrapper<IInventoryServiceWrapper, InventoryServiceWrapper>
{
	// Token: 0x0600122F RID: 4655 RVA: 0x0000E2ED File Offset: 0x0000C4ED
	public void method_0(InventoryServiceWrapper.InventoryUpdateCallback inventoryUpdateCallback_0)
	{
		this.m_inventoryCallbacks.Add(inventoryUpdateCallback_0);
	}

	// Token: 0x06001230 RID: 4656 RVA: 0x0000E2FB File Offset: 0x0000C4FB
	public void method_1(InventoryServiceWrapper.InventoryUpdateCallback inventoryUpdateCallback_0)
	{
		this.m_inventoryCallbacks.Remove(inventoryUpdateCallback_0);
	}

	// Token: 0x06001231 RID: 4657 RVA: 0x00076600 File Offset: 0x00074800
	public void method_2(InventoryUpdateType inventoryUpdateType_0)
	{
		m_inventoryCallbacks.ForEach(delegate(InventoryUpdateCallback inventoryUpdateCallback_0)
		{
			inventoryUpdateCallback_0(inventoryUpdateType_0);
		});
	}
	// Token: 0x06001232 RID: 4658 RVA: 0x0000E30A File Offset: 0x0000C50A
	public void method_3(InventoryServiceWrapper.InventoryUpdateCallback inventoryUpdateCallback_0)
	{
		this.m_WareHouseCallback = (InventoryServiceWrapper.InventoryUpdateCallback)Delegate.Combine(this.m_WareHouseCallback, inventoryUpdateCallback_0);
	}

	// Token: 0x06001233 RID: 4659 RVA: 0x0000E323 File Offset: 0x0000C523
	public void method_4(InventoryServiceWrapper.InventoryUpdateCallback inventoryUpdateCallback_0)
	{
		this.m_WareHouseCallback = (InventoryServiceWrapper.InventoryUpdateCallback)Delegate.Remove(this.m_WareHouseCallback, inventoryUpdateCallback_0);
	}

	// Token: 0x06001234 RID: 4660 RVA: 0x0000E33C File Offset: 0x0000C53C
	public void method_5(InventoryServiceWrapper.InventoryUpdateType inventoryUpdateType_0)
	{
		if (this.m_WareHouseCallback != null)
		{
			this.m_WareHouseCallback(inventoryUpdateType_0);
		}
	}

	// Token: 0x06001235 RID: 4661 RVA: 0x00076634 File Offset: 0x00074834
	protected override IInventoryServiceWrapper vmethod_0()
	{
		if (MonoSingleton<Session>.Instance != null && !MonoSingleton<Session>.Instance.method_16() && MonoSingleton<Session>.Instance.GetLocalPlayer() && MonoSingleton<Session>.Instance.GetLocalPlayer().GetEntity())
		{
			return this.m_wrapperSession;
		}
		if (MonoSingleton<Session>.Instance != null && MonoSingleton<Session>.Instance.method_16() && MonoSingleton<Session>.Instance.GetLocalPlayer() && MonoSingleton<Session>.Instance.GetLocalPlayer().GetEntity())
		{
			return this.m_wrapperTown;
		}
		return this.m_wrapperOnline;
	}

	// Token: 0x06001236 RID: 4662 RVA: 0x0000E352 File Offset: 0x0000C552
	public override void vmethod_1()
	{
		this.m_wrapperOnline = new InventoryServiceWrapperOnline();
		this.m_wrapperSession = new InventoryServiceWrapperSession();
		this.m_wrapperTown = new InventoryServiceWrapperTown();
		base.vmethod_1();
	}

	// Token: 0x06001237 RID: 4663 RVA: 0x0000E37B File Offset: 0x0000C57B
	public ItemDNA method_6(int int_0)
	{
		return this.vmethod_0().imethod_2(int_0);
	}

	// Token: 0x06001238 RID: 4664 RVA: 0x0000E389 File Offset: 0x0000C589
	public ItemDNA method_7(byte byte_0)
	{
		return this.vmethod_0().imethod_3(byte_0);
	}

	// Token: 0x06001239 RID: 4665 RVA: 0x0000E397 File Offset: 0x0000C597
	public byte method_8()
	{
		return this.vmethod_0().imethod_7();
	}

	// Token: 0x0600123A RID: 4666 RVA: 0x0000E3A4 File Offset: 0x0000C5A4
	public int method_9(AmmoType ammoType_0)
	{
		return this.vmethod_0().imethod_8(ammoType_0);
	}

	// Token: 0x0600123B RID: 4667 RVA: 0x0000E3B2 File Offset: 0x0000C5B2
	public int method_10(AmmoType ammoType_0)
	{
		return this.vmethod_0().imethod_9(ammoType_0);
	}

	// Token: 0x0600123C RID: 4668 RVA: 0x0000E3C0 File Offset: 0x0000C5C0
	public void method_11(byte byte_0, byte byte_1)
	{
		if (byte_0 != byte_1)
		{
			this.vmethod_0().imethod_12(byte_0, byte_1);
		}
	}

	// Token: 0x0600123D RID: 4669 RVA: 0x0000E3D3 File Offset: 0x0000C5D3
	public void method_12(byte byte_0, byte byte_1)
	{
		if (byte_0 == byte_1)
		{
			return;
		}
		this.vmethod_0().imethod_13(byte_0, byte_1);
	}

	// Token: 0x0600123E RID: 4670 RVA: 0x0000E3E7 File Offset: 0x0000C5E7
	public void method_13(byte byte_0, byte byte_1)
	{
		this.vmethod_0().imethod_14(byte_0, byte_1);
		MonoSingleton<GuidanceTipsManager>.Instance.method_2("guidance_equip_weapon");
	}

	// Token: 0x0600123F RID: 4671 RVA: 0x0000E405 File Offset: 0x0000C605
	public void method_14(byte byte_0)
	{
		this.vmethod_0().imethod_15(byte_0);
	}

	// Token: 0x06001240 RID: 4672 RVA: 0x0000E413 File Offset: 0x0000C613
	public void method_15()
	{
		this.vmethod_0().imethod_17();
	}

	// Token: 0x06001241 RID: 4673 RVA: 0x0000E420 File Offset: 0x0000C620
	public void method_16()
	{
		this.vmethod_0().imethod_18();
	}

	// Token: 0x06001242 RID: 4674 RVA: 0x0000E42D File Offset: 0x0000C62D
	public void method_17(AvatarSubPart avatarSubPart_0)
	{
		this.vmethod_0().imethod_21(avatarSubPart_0);
	}

	// Token: 0x06001243 RID: 4675 RVA: 0x0000E43B File Offset: 0x0000C63B
	public void method_18(byte byte_0)
	{
		this.vmethod_0().imethod_22(byte_0);
	}

	// Token: 0x06001244 RID: 4676 RVA: 0x0000E449 File Offset: 0x0000C649
	public void method_19(byte byte_0)
	{
		this.vmethod_0().imethod_16(byte_0);
		MonoSingleton<GuidanceTipsManager>.Instance.method_2("guidance_equip_shield");
	}

	// Token: 0x06001245 RID: 4677 RVA: 0x0000E466 File Offset: 0x0000C666
	public void method_20(byte byte_0)
	{
		this.vmethod_0().imethod_19(byte_0);
		MonoSingleton<GuidanceTipsManager>.Instance.method_2("guidance_equip_classMod");
	}

	// Token: 0x06001246 RID: 4678 RVA: 0x000766D8 File Offset: 0x000748D8
	public void method_21()
	{
		if (MonoSingleton<Session>.Instance.GetLocalPlayer() != null)
		{
			EntityPlayer entityPlayer = MonoSingleton<Session>.Instance.GetLocalPlayer().GetEntity() as EntityPlayer;
			if (entityPlayer != null)
			{
				entityPlayer.method_118();
			}
		}
	}

	// Token: 0x06001247 RID: 4679 RVA: 0x0000E483 File Offset: 0x0000C683
	public void method_22(byte byte_0)
	{
		this.vmethod_0().imethod_20(byte_0);
	}

	// Token: 0x06001248 RID: 4680 RVA: 0x0000E491 File Offset: 0x0000C691
	public void method_23()
	{
		this.vmethod_0().imethod_23();
	}

	// Token: 0x06001249 RID: 4681 RVA: 0x0000E49E File Offset: 0x0000C69E
	public void method_24(int int_0, int int_1)
	{
		this.vmethod_0().imethod_24(int_0, int_1);
	}

	// Token: 0x0600124A RID: 4682 RVA: 0x0007671C File Offset: 0x0007491C
	public void method_25(byte byte_0, byte byte_1 = 0)
	{
		ItemDNA itemDNA = this.method_6((int)byte_0);
		ItemType type = itemDNA.m_type;
		switch (type)
		{
		case ItemType.Weapon:
			this.method_13(byte_0, byte_1);
			return;
		case ItemType.Shield:
			this.method_19(byte_0);
			return;
		}
		switch (type)
		{
		case ItemType.ClassMode:
			this.method_20(byte_0);
			return;
		case ItemType.Outfit:
			this.method_22(byte_0);
			return;
		}
		DebugUtils.LogError(LogCategory.Default, itemDNA.m_type.ToString() + "is not equippable");
	}

	// Token: 0x0600124B RID: 4683 RVA: 0x0000E4AD File Offset: 0x0000C6AD
	public ItemDNA method_26()
	{
		if (this.vmethod_0() == null)
		{
			return null;
		}
		return this.vmethod_0().imethod_4();
	}

	// Token: 0x0600124C RID: 4684 RVA: 0x0000E4C4 File Offset: 0x0000C6C4
	public ItemDNA method_27()
	{
		if (this.vmethod_0() == null)
		{
			return null;
		}
		return this.vmethod_0().imethod_5();
	}

	// Token: 0x0600124D RID: 4685 RVA: 0x0000E4DB File Offset: 0x0000C6DB
	public ItemDNA method_28(AvatarSubPart avatarSubPart_0)
	{
		if (this.vmethod_0() == null)
		{
			return null;
		}
		return this.vmethod_0().imethod_6(avatarSubPart_0);
	}

	// Token: 0x0600124E RID: 4686 RVA: 0x0000E4F3 File Offset: 0x0000C6F3
	public void method_29(byte byte_0)
	{
		if (this.method_30(byte_0))
		{
			this.vmethod_0().imethod_25(byte_0);
		}
	}

	// Token: 0x0600124F RID: 4687 RVA: 0x0000E50A File Offset: 0x0000C70A
	public bool method_30(byte byte_0)
	{
		return this.vmethod_0().imethod_26(byte_0);
	}

	// Token: 0x06001250 RID: 4688 RVA: 0x0000E518 File Offset: 0x0000C718
	public int method_31()
	{
		return this.vmethod_0().imethod_10();
	}

	// Token: 0x06001251 RID: 4689 RVA: 0x0000E525 File Offset: 0x0000C725
	public int method_32()
	{
		return this.vmethod_0().imethod_11();
	}

	// Token: 0x06001252 RID: 4690 RVA: 0x000767B4 File Offset: 0x000749B4
	public int method_33(MaterialType materialType_0)
	{
		int num = 0;
		sbyte b = 0;
		while ((int)b < this.method_31())
		{
			ItemDNA itemDNA = this.method_6((int)b);
			if (itemDNA != null && itemDNA.method_3(ItemType.Material) && itemDNA.m_materialType == materialType_0)
			{
				num += itemDNA.m_value;
			}
			b += 1;
		}
		return num;
	}

	// Token: 0x06001253 RID: 4691 RVA: 0x0000E532 File Offset: 0x0000C732
	public void method_34(byte byte_0, byte byte_1)
	{
		if (byte_0 == byte_1)
		{
			return;
		}
		this.vmethod_0().imethod_27(byte_0, byte_1);
	}

	// Token: 0x06001254 RID: 4692 RVA: 0x0000E546 File Offset: 0x0000C746
	public void method_35(byte byte_0, byte byte_1, bool bool_1)
	{
		this.vmethod_0().imethod_28(byte_0, byte_1, bool_1);
	}

	// Token: 0x06001255 RID: 4693 RVA: 0x0000E556 File Offset: 0x0000C756
	public void method_36()
	{
		this.vmethod_0().imethod_29();
	}

	// Token: 0x06001256 RID: 4694 RVA: 0x0000E563 File Offset: 0x0000C763
	public ItemDNA[] method_37()
	{
		return this.vmethod_0().imethod_30();
	}

	// Token: 0x06001257 RID: 4695 RVA: 0x0000E570 File Offset: 0x0000C770
	public bool method_38(ItemDNA itemDNA_0)
	{
		return this.vmethod_0().imethod_31(itemDNA_0);
	}

	// Token: 0x06001258 RID: 4696 RVA: 0x00076800 File Offset: 0x00074A00
	public bool method_39(ItemDNA itemDNA_0)
	{
		bool flag;
		if (flag = this.method_38(itemDNA_0))
		{
			MonoSingleton<global::ns0.EchoMessageManager>.Instance.method_8("70001");
		}
		return flag;
	}

	// Token: 0x04000E1B RID: 3611
	private List<InventoryServiceWrapper.InventoryUpdateCallback> m_inventoryCallbacks = new List<InventoryServiceWrapper.InventoryUpdateCallback>();

	// Token: 0x04000E1C RID: 3612
	private InventoryServiceWrapper.InventoryUpdateCallback m_WareHouseCallback;

	// Token: 0x0200030B RID: 779
	public enum InventoryUpdateType
	{
		// Token: 0x04000E1E RID: 3614
		None,
		// Token: 0x04000E1F RID: 3615
		ItemUpdate,
		// Token: 0x04000E20 RID: 3616
		ChangeActiveWeapon,
		// Token: 0x04000E21 RID: 3617
		ChangeEquipedShield,
		// Token: 0x04000E22 RID: 3618
		ChangeEquipedClassMod,
		// Token: 0x04000E23 RID: 3619
		ChangeEquipedOutfit,
		// Token: 0x04000E24 RID: 3620
		WeaponSlotsUpdate,
		// Token: 0x04000E25 RID: 3621
		EquipItemFail,
		// Token: 0x04000E26 RID: 3622
		FullUpdate
	}

	// Token: 0x0200030C RID: 780
	// (Invoke) Token: 0x0600125A RID: 4698
	public delegate void InventoryUpdateCallback(InventoryServiceWrapper.InventoryUpdateType updateType);
}
