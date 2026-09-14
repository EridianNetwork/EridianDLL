using System;
using Core;
using ns0;
using UnityEngine;
using XsdSettings;

// Token: 0x02000496 RID: 1174
public class EquipmentInventoryEntityPlayerTown : EquipmentInventoryEntityPlayer
{
	// Token: 0x06001F54 RID: 8020 RVA: 0x00015C5A File Offset: 0x00013E5A
	public bool method_39()
	{
		return this.isReady;
	}

	// Token: 0x06001F55 RID: 8021 RVA: 0x0009A2D4 File Offset: 0x000984D4
	public void method_40(byte byte_0, ItemDNA[] itemDNA_0, ItemDNA itemDNA_1, ItemDNA itemDNA_2, byte byte_1)
	{
		this.m_entity = base.GetComponent<EntityPlayer>();
		AvatarType avatarType = this.m_entity.vmethod_25().m_avatarDna.method_5();
		this.m_pouchList[0].method_0(MonoSingleton<LevelingManager>.Instance.method_5(avatarType, (int)byte_0));
		byte b = 0;
		while ((int)b < EquipmentInventoryEntityPlayer.s_weaponSlotCount)
		{
			if (!this.m_weaponSlots[(int)b].method_4() && itemDNA_0[(int)b] != null)
			{
				EntityWeapon entityWeapon = MonoSingleton<InstantiateManager>.Instance.method_3(itemDNA_0[(int)b].method_6(), Vector3.zero, Quaternion.identity, false);
				this.m_weaponSlots[(int)b].method_1(entityWeapon, itemDNA_0[(int)b]);
			}
			b += 1;
		}
		if (itemDNA_1 != null)
		{
			this.vmethod_45(itemDNA_1);
			ServiceWrapperBase<InventoryServiceWrapper>.Instance.method_2(InventoryServiceWrapper.InventoryUpdateType.ChangeEquipedShield);
		}
		if (itemDNA_2 != null)
		{
			this.vmethod_49(itemDNA_2);
			ServiceWrapperBase<InventoryServiceWrapper>.Instance.method_2(InventoryServiceWrapper.InventoryUpdateType.ChangeEquipedClassMod);
		}
		for (int i = 0; i < this.m_outfitCount; i++)
		{
			AvatarSubPart avatarSubPart = base.method_34(i);
			ItemDNA itemDNA = ServiceWrapperBase<InventoryServiceWrapper>.Instance.method_28(avatarSubPart);
			if (itemDNA != null)
			{
				this.m_outfitSlots[i] = itemDNA;
			}
		}
		if (this.m_entity != null && this.m_entity.vmethod_26())
		{
			ServiceWrapperBase<InventoryServiceWrapper>.Instance.method_2(InventoryServiceWrapper.InventoryUpdateType.ChangeEquipedOutfit);
		}
		this.vmethod_54(byte_1);
		if (this.m_entity != null && this.m_entity.vmethod_26())
		{
			this.m_isMine = true;
			ServiceWrapperBase<InventoryServiceWrapper>.Instance.method_2(InventoryServiceWrapper.InventoryUpdateType.FullUpdate);
		}
		this.method_41();
	}

	// Token: 0x06001F56 RID: 8022 RVA: 0x0009A438 File Offset: 0x00098638
	private void OnDestroy()
	{
		if (this.m_isMine)
		{
			Inventory inventory = OnAccessSingleton<IInventoryService, InventoryService, InventoryServiceOffline>.Prop_0.imethod_0(OnlineService.s_characterId, null);
			if (inventory != null)
			{
				inventory.method_12(this.vmethod_55());
			}
		}
	}

	// Token: 0x06001F57 RID: 8023 RVA: 0x0009A470 File Offset: 0x00098670
	public void method_41()
	{
		if (this.m_entity != null && this.m_entity.vmethod_26())
		{
			this.method_42(ServiceWrapperBase<InventoryServiceWrapper>.Instance.method_7(0), ServiceWrapperBase<InventoryServiceWrapper>.Instance.method_7(1), ServiceWrapperBase<InventoryServiceWrapper>.Instance.method_7(2), ServiceWrapperBase<InventoryServiceWrapper>.Instance.method_7(3), ServiceWrapperBase<InventoryServiceWrapper>.Instance.method_8());
		}
	}

	// Token: 0x06001F58 RID: 8024 RVA: 0x0009A4D4 File Offset: 0x000986D4
	private void method_42(ItemDNA itemDNA_0, ItemDNA itemDNA_1, ItemDNA itemDNA_2, ItemDNA itemDNA_3, byte byte_0)
	{
		object[] array = new object[] { itemDNA_0, itemDNA_1, itemDNA_2, itemDNA_3, byte_0 };
		base.photonView.method_4("RPC_RequestSetWeaponSlots", PhotonTargets.MasterClient, array);
	}

	// Token: 0x06001F59 RID: 8025 RVA: 0x0000311B File Offset: 0x0000131B
	[RPC]
	public void RPC_RequestSetWeaponSlots(ItemDNA s0, ItemDNA s1, ItemDNA s2, ItemDNA s3, byte activeSlot)
	{
	}

	// Token: 0x06001F5A RID: 8026 RVA: 0x00099B4C File Offset: 0x00097D4C
	[RPC]
	private void RPC_OnUpdateOutfits(ItemDNA outfit1, ItemDNA outfit2, ItemDNA outfit3, ItemDNA outfit4, ItemDNA outfit5)
	{
		if (this.m_entity == null)
		{
			return;
		}
		PlayerInfoSync playerInfoSync = this.m_entity.vmethod_25();
		if (playerInfoSync == null)
		{
			return;
		}
		if (playerInfoSync.IsMyActor())
		{
			return;
		}
		EntityPlayer entityPlayer = this.m_entity as EntityPlayer;
		if (entityPlayer != null)
		{
			this.m_outfitSlots[0] = outfit1;
			this.m_outfitSlots[1] = outfit2;
			this.m_outfitSlots[2] = outfit3;
			this.m_outfitSlots[3] = outfit4;
			this.m_outfitSlots[4] = outfit5;
			entityPlayer.method_119(this.m_outfitCount);
		}
	}

	// Token: 0x06001F5B RID: 8027 RVA: 0x0009A518 File Offset: 0x00098718
	private void OnLevelUp(PlayerInfoSync player)
	{
		Entity entity = player.GetEntity();
		if (entity == null)
		{
			return;
		}
		if (this.m_entity == null)
		{
			return;
		}
		if (player.IsMyActor() && entity.vmethod_0() == this.m_entity.vmethod_0())
		{
			AvatarType avatarType = player.m_avatarDna.method_5();
			int num = MonoSingleton<LevelingManager>.Instance.method_3(avatarType, player.m_exp);
			int num2 = MonoSingleton<LevelingManager>.Instance.method_5(avatarType, num);
			this.m_pouchList[0].method_0(num2);
		}
	}

	// Token: 0x06001F5C RID: 8028 RVA: 0x0009A5A0 File Offset: 0x000987A0
	public override void vmethod_45(ItemDNA itemDNA_0)
	{
		EntityShield entityShield = MonoSingleton<InstantiateManager>.Instance.method_4(Vector3.zero, Quaternion.identity, false);
		entityShield.method_18(itemDNA_0.method_7(), this.m_entity);
		entityShield.vmethod_63(this.m_entity);
		this.m_shieldSlot.method_1(entityShield, itemDNA_0);
		EntityPlayer entityPlayer = this.m_entity as EntityPlayer;
		if (entityPlayer != null && entityPlayer.SkillTreeStatus_0 != null)
		{
			entityPlayer.SkillTreeStatus_0.method_15();
		}
	}

	// Token: 0x06001F5D RID: 8029 RVA: 0x0009A61C File Offset: 0x0009881C
	public override void vmethod_49(ItemDNA itemDNA_0)
	{
		EntityClassMode entityClassMode = MonoSingleton<InstantiateManager>.Instance.method_5(itemDNA_0, Vector3.zero, Quaternion.identity, false);
		entityClassMode.vmethod_63(this.m_entity);
		entityClassMode.gameObject.SetActive(false);
		this.m_classModeSlot.method_1(entityClassMode, itemDNA_0);
	}

	// Token: 0x06001F5E RID: 8030 RVA: 0x00015C62 File Offset: 0x00013E62
	public void method_43(EntityShield entityShield_0)
	{
		this.m_shieldSlot.method_1(entityShield_0, null);
	}

	// Token: 0x06001F5F RID: 8031 RVA: 0x0000311B File Offset: 0x0000131B
	public void method_44(ItemDNA itemDNA_0)
	{
	}

	// Token: 0x06001F60 RID: 8032 RVA: 0x0000311B File Offset: 0x0000131B
	public void method_45(byte byte_0)
	{
	}

	// Token: 0x06001F61 RID: 8033 RVA: 0x0000311B File Offset: 0x0000131B
	public void method_46(byte byte_0, byte byte_1)
	{
	}

	// Token: 0x06001F62 RID: 8034 RVA: 0x0009A668 File Offset: 0x00098868
	public override void vmethod_43(byte byte_0, byte byte_1)
	{
		if (this.m_entity == null)
		{
			return;
		}
		if (!this.m_entity.vmethod_26())
		{
			return;
		}
		PlayerInfoSync playerInfoSync = this.m_entity.vmethod_25();
		if (playerInfoSync == null || !playerInfoSync.IsMyActor())
		{
			return;
		}
		EntityWeapon entityWeapon = ((this.m_weaponSlots[(int)byte_1] == null) ? null : (this.m_weaponSlots[(int)byte_1].method_3() as EntityWeapon));
		ItemDNA itemDNA = ServiceWrapperBase<InventoryServiceWrapper>.Instance.method_7(byte_1);
		if (itemDNA == null)
		{
			return;
		}
		this.m_weaponSlots[(int)byte_1].method_0(0, itemDNA);
		DebugUtils.Log(LogCategory.Gamelogic, "EquipWeapon - SpawnWeapon [ " + itemDNA.method_6().m_name + "]");
		EntityWeapon entityWeapon2 = MonoSingleton<InstantiateManager>.Instance.method_3(itemDNA.method_6(), Vector3.zero, Quaternion.identity, false);
		(this.m_entity as EntityPlayer).vmethod_65(entityWeapon2, byte_1);
		this.m_weaponSlots[(int)byte_1].method_1(entityWeapon2, itemDNA);
		if (itemDNA != null && itemDNA.method_6() != null && itemDNA.method_6().m_attribute != null)
		{
			this.vmethod_14(this.vmethod_13(itemDNA.m_ammoType) - (this.m_entity as EntityPlayer).method_57(IntAttributeValue.smethod_0(itemDNA.method_6().m_attribute.method_1(AttributeType.ClipSize) as IntAttributeValue)), itemDNA.m_ammoType);
		}
		if (entityWeapon != null)
		{
			MonoSingleton<EntityManager>.Instance.method_2(entityWeapon);
			DebugUtils.Log(LogCategory.Gamelogic, string.Concat(new object[]
			{
				"EquipWeapon - DestroyEntity [",
				entityWeapon.method_17().m_name,
				"] Item Slot ",
				byte_0
			}));
		}
		ServiceWrapperBase<InventoryServiceWrapper>.Instance.method_2(InventoryServiceWrapper.InventoryUpdateType.ItemUpdate);
		this.vmethod_54(byte_1);
	}

	// Token: 0x06001F63 RID: 8035 RVA: 0x0009A810 File Offset: 0x00098A10
	public override void vmethod_46(byte byte_0)
	{
		if (this.m_entity == null)
		{
			return;
		}
		PlayerInfoSync playerInfoSync = this.m_entity.vmethod_25();
		if (!(playerInfoSync == null) && playerInfoSync.IsMyActor())
		{
			ItemDNA itemDNA = ServiceWrapperBase<InventoryServiceWrapper>.Instance.method_26();
			if (itemDNA != null && itemDNA.method_3(ItemType.Shield))
			{
				EntityShield entityShield = this.m_shieldSlot.method_3() as EntityShield;
				this.vmethod_45(itemDNA);
				if (entityShield != null)
				{
					MonoSingleton<EntityManager>.Instance.method_2(entityShield);
				}
				ServiceWrapperBase<InventoryServiceWrapper>.Instance.method_2(InventoryServiceWrapper.InventoryUpdateType.ChangeEquipedShield);
			}
			return;
		}
	}

	// Token: 0x06001F64 RID: 8036 RVA: 0x0009A898 File Offset: 0x00098A98
	public override void vmethod_50(byte byte_0)
	{
		if (this.m_entity == null)
		{
			return;
		}
		PlayerInfoSync playerInfoSync = this.m_entity.vmethod_25();
		if (!(playerInfoSync == null) && playerInfoSync.IsMyActor())
		{
			ItemDNA itemDNA = ServiceWrapperBase<InventoryServiceWrapper>.Instance.method_27();
			if (itemDNA != null && itemDNA.method_3(ItemType.ClassMode))
			{
				EntityClassMode entityClassMode = this.m_classModeSlot.method_3() as EntityClassMode;
				this.vmethod_49(itemDNA);
				if (entityClassMode != null)
				{
					MonoSingleton<EntityManager>.Instance.method_2(entityClassMode);
				}
				ServiceWrapperBase<InventoryServiceWrapper>.Instance.method_2(InventoryServiceWrapper.InventoryUpdateType.ChangeEquipedClassMod);
			}
			return;
		}
	}

	// Token: 0x06001F65 RID: 8037 RVA: 0x0009A920 File Offset: 0x00098B20
	public override void vmethod_51(byte byte_0)
	{
		if (this.m_entity == null)
		{
			return;
		}
		PlayerInfoSync playerInfoSync = this.m_entity.vmethod_25();
		if (playerInfoSync == null || !playerInfoSync.IsMyActor())
		{
			return;
		}
		EntityPlayer entityPlayer = this.m_entity as EntityPlayer;
		if (entityPlayer == null)
		{
			return;
		}
		ItemDNA itemDNA = ServiceWrapperBase<InventoryServiceWrapper>.Instance.method_28((AvatarSubPart)byte_0);
		if (itemDNA != null && itemDNA.method_3(ItemType.Outfit))
		{
			int num = base.method_33((AvatarSubPart)byte_0);
			this.m_outfitSlots[num] = itemDNA;
			entityPlayer.method_121(itemDNA);
			ServiceWrapperBase<InventoryServiceWrapper>.Instance.method_2(InventoryServiceWrapper.InventoryUpdateType.ChangeEquipedOutfit);
		}
	}

	// Token: 0x06001F66 RID: 8038 RVA: 0x0009A9AC File Offset: 0x00098BAC
	public override void vmethod_52(byte byte_0)
	{
		if (this.m_entity == null)
		{
			return;
		}
		PlayerInfoSync playerInfoSync = this.m_entity.vmethod_25();
		if (playerInfoSync == null || !playerInfoSync.IsMyActor())
		{
			return;
		}
		EntityPlayer entityPlayer = this.m_entity as EntityPlayer;
		if (entityPlayer == null)
		{
			return;
		}
		int num = base.method_33((AvatarSubPart)byte_0);
		ItemDNA itemDNA = this.m_outfitSlots[num];
		if (itemDNA != null && itemDNA.method_3(ItemType.Outfit))
		{
			entityPlayer.method_120(itemDNA);
			this.m_outfitSlots[num] = null;
			ServiceWrapperBase<InventoryServiceWrapper>.Instance.method_2(InventoryServiceWrapper.InventoryUpdateType.ChangeEquipedOutfit);
		}
	}

	// Token: 0x06001F67 RID: 8039 RVA: 0x0000311B File Offset: 0x0000131B
	public override void vmethod_48()
	{
	}

	// Token: 0x06001F68 RID: 8040 RVA: 0x0000311B File Offset: 0x0000131B
	public override void vmethod_47()
	{
	}

	// Token: 0x06001F69 RID: 8041 RVA: 0x0009AA38 File Offset: 0x00098C38
	public override void vmethod_44(byte byte_0)
	{
		if (this.m_entity == null)
		{
			return;
		}
		PlayerInfoSync playerInfoSync = this.m_entity.vmethod_25();
		if (!(playerInfoSync == null) && playerInfoSync.IsMyActor())
		{
			this.m_isItemsDirty = true;
			EntityWeapon entityWeapon = this.m_weaponSlots[(int)byte_0].method_3() as EntityWeapon;
			if (entityWeapon)
			{
				this.vmethod_16(this.vmethod_15(entityWeapon.method_99()) + entityWeapon.m_ammoCount, entityWeapon.method_99());
				MonoSingleton<EntityManager>.Instance.method_2(entityWeapon);
			}
			this.m_weaponSlots[(int)byte_0].method_6();
			ServiceWrapperBase<InventoryServiceWrapper>.Instance.method_2(InventoryServiceWrapper.InventoryUpdateType.ItemUpdate);
			return;
		}
	}

	// Token: 0x06001F6A RID: 8042 RVA: 0x0009AAD8 File Offset: 0x00098CD8
	public override void vmethod_42(byte byte_0, byte byte_1)
	{
		if (this.m_entity == null)
		{
			return;
		}
		PlayerInfoSync playerInfoSync = this.m_entity.vmethod_25();
		if (!(playerInfoSync == null) && playerInfoSync.IsMyActor())
		{
			this.m_isItemsDirty = true;
			InventorySlot inventorySlot = this.m_weaponSlots[(int)byte_0];
			this.m_weaponSlots[(int)byte_0] = this.m_weaponSlots[(int)byte_1];
			this.m_weaponSlots[(int)byte_1] = inventorySlot;
			if (this.m_activeWeaponSlot == byte_0)
			{
				this.vmethod_54(byte_1);
			}
			else if (this.m_activeWeaponSlot == byte_1)
			{
				this.vmethod_54(byte_0);
			}
			ServiceWrapperBase<InventoryServiceWrapper>.Instance.method_2(InventoryServiceWrapper.InventoryUpdateType.ItemUpdate);
			return;
		}
	}

	// Token: 0x06001F6B RID: 8043 RVA: 0x0009AB68 File Offset: 0x00098D68
	protected override void Update()
	{
		if (this.m_entity == null)
		{
			return;
		}
		if (!this.isReady)
		{
			for (int i = 0; i < EquipmentInventoryEntityPlayer.s_weaponSlotCount; i++)
			{
				if (this.vmethod_28((byte)i) && this.vmethod_28((byte)i).vmethod_62())
				{
					this.isReady = true;
					break;
				}
			}
		}
		if (!this.m_entity.vmethod_26() && this.m_activeWeaponSlot != this.m_activeWeaponRecved)
		{
			(this.m_entity as EntityPlayer).vmethod_79(this.m_activeWeaponRecved);
		}
		if (!this.m_entity.method_3() && this.m_updateType != InventoryServiceWrapper.InventoryUpdateType.None)
		{
			ServiceWrapperBase<InventoryServiceWrapper>.Instance.method_2(this.m_updateType);
			this.m_updateType = InventoryServiceWrapper.InventoryUpdateType.None;
		}
		if (this.vmethod_26() == null && this.m_entity.vmethod_26())
		{
			ItemDNA itemDNA = ServiceWrapperBase<InventoryServiceWrapper>.Instance.method_26();
			if (itemDNA != null)
			{
				this.vmethod_45(itemDNA);
				ServiceWrapperBase<InventoryServiceWrapper>.Instance.method_2(InventoryServiceWrapper.InventoryUpdateType.ChangeEquipedShield);
			}
		}
	}

	// Token: 0x06001F6C RID: 8044 RVA: 0x0009AC60 File Offset: 0x00098E60
	public override void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
	{
		this.vmethod_35();
		if (stream.IsWriting)
		{
			stream.SendNext((byte)this.m_flags);
			for (int i = 0; i < EquipmentInventoryEntityPlayer.s_weaponSlotCount; i++)
			{
				ItemDNA itemDNA = this.m_weaponSlots[i].method_2();
				stream.SendNext(itemDNA);
			}
			stream.SendNext(this.vmethod_55());
		}
		if (stream.IsReading)
		{
			if (this.m_entity == null)
			{
				return;
			}
			if (this.m_entity.vmethod_26())
			{
				return;
			}
			this.m_flags = (EquipmentInventoryEntity.PropertyFlags)((byte)stream.ReceiveNext());
			for (int j = 0; j < EquipmentInventoryEntityPlayer.s_weaponSlotCount; j++)
			{
				ItemDNA itemDNA2 = (ItemDNA)stream.ReceiveNext();
				bool flag;
				if (itemDNA2 != null && this.m_weaponSlots[j] != null)
				{
					flag = itemDNA2.Equals(this.m_weaponSlots[j].method_2());
				}
				else
				{
					flag = itemDNA2 == null && (this.m_weaponSlots[j] == null || this.m_weaponSlots[j].method_2() == null);
				}
				if (!flag)
				{
					if (this.m_weaponSlots[j] != null && this.m_weaponSlots[j].method_2() != null)
					{
						DebugUtils.Log(LogCategory.Gamelogic, string.Concat(new object[]
						{
							"3d person of [",
							this.m_entity.vmethod_25().m_name,
							"] locally Destroy previous weapon:",
							this.m_weaponSlots[j].method_2().method_6()
						}));
						MonoSingleton<EntityManager>.Instance.method_2(this.m_weaponSlots[j].method_3());
					}
					if (itemDNA2 != null && this.m_weaponSlots[j] != null)
					{
						DebugUtils.Log(LogCategory.Gamelogic, string.Concat(new object[]
						{
							"3d person of [",
							this.m_entity.vmethod_25().m_name,
							"] locally SpawnWeapon:",
							itemDNA2.method_6()
						}));
						EntityWeapon entityWeapon = MonoSingleton<InstantiateManager>.Instance.method_3(itemDNA2.method_6(), Vector3.zero, Quaternion.identity, false);
						this.m_weaponSlots[j].method_1(entityWeapon, itemDNA2);
						(this.m_entity as EntityPlayer).vmethod_65(entityWeapon, (byte)j);
					}
				}
			}
			this.m_activeWeaponRecved = (byte)stream.ReceiveNext();
			DebugUtils.Log(LogCategory.Gamelogic, "Client Recving inventory in town. activeWeaponSlot:" + this.m_activeWeaponRecved.ToString());
		}
	}

	// Token: 0x06001F6D RID: 8045 RVA: 0x0009AEA4 File Offset: 0x000990A4
	public override EntityShield vmethod_56()
	{
		DebugUtils.Log(LogCategory.Gamelogic, "EquipmentTown: SpawnShield ");
		EntityShield entityShield = MonoSingleton<InstantiateManager>.Instance.method_4(Vector3.zero, Quaternion.identity, false);
		this.method_43(entityShield);
		return entityShield;
	}

	// Token: 0x06001F6E RID: 8046 RVA: 0x00015C71 File Offset: 0x00013E71
	public override void vmethod_54(byte byte_0)
	{
		if (this.m_entity == null)
		{
			return;
		}
		if (byte_0 != this.m_activeWeaponSlot)
		{
			this.m_activeWeaponSlot = byte_0;
		}
		ServiceWrapperBase<InventoryServiceWrapper>.Instance.method_2(InventoryServiceWrapper.InventoryUpdateType.ChangeActiveWeapon);
	}

	// Token: 0x06001F6F RID: 8047 RVA: 0x00015B9F File Offset: 0x00013D9F
	public override byte vmethod_55()
	{
		return this.m_activeWeaponSlot;
	}

	// Token: 0x0400143E RID: 5182
	private bool isReady;

	// Token: 0x0400143F RID: 5183
	private bool m_isMine;

	// Token: 0x04001440 RID: 5184
	private InventoryServiceWrapper.InventoryUpdateType m_updateType;

	// Token: 0x04001441 RID: 5185
	private byte m_activeWeaponRecved;
}
