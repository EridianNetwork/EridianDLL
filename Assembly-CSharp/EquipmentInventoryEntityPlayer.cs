using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using Core;
using ns0;
using UnityEngine;
using XsdSettings;

// Token: 0x02000492 RID: 1170
public class EquipmentInventoryEntityPlayer : EquipmentInventoryEntity, IPhotonEvaluate
{
	// Token: 0x17000199 RID: 409
	// (get) Token: 0x06001EDA RID: 7898 RVA: 0x0001587B File Offset: 0x00013A7B
	// (set) Token: 0x06001EDB RID: 7899 RVA: 0x00015882 File Offset: 0x00013A82
	public int Int32_0
	{
		get
		{
			return EquipmentInventoryEntityPlayer.s_weaponSlotCount;
		}
		private set
		{
			EquipmentInventoryEntityPlayer.s_weaponSlotCount = value;
		}
	}

	// Token: 0x06001EDC RID: 7900 RVA: 0x0001588A File Offset: 0x00013A8A
	public bool method_1()
	{
		return this.m_isEquipmentReady;
	}

	// Token: 0x1700019A RID: 410
	// (get) Token: 0x06001EDD RID: 7901 RVA: 0x00015892 File Offset: 0x00013A92
	public int Int32_1
	{
		get
		{
			return this.m_outfitCount;
		}
	}

	// Token: 0x06001EDE RID: 7902 RVA: 0x0001589A File Offset: 0x00013A9A
	public ItemDNA[] method_2()
	{
		return this.m_itemSlots;
	}

	// Token: 0x06001EDF RID: 7903 RVA: 0x000154B8 File Offset: 0x000136B8
	public override int vmethod_4()
	{
		return this.m_pouchList[0].method_5();
	}

	// Token: 0x06001EE0 RID: 7904 RVA: 0x000154CB File Offset: 0x000136CB
	public override int vmethod_0()
	{
		return this.m_pouchList[0].method_4();
	}

	// Token: 0x06001EE1 RID: 7905 RVA: 0x000158A2 File Offset: 0x00013AA2
	public override int vmethod_2()
	{
		return this.m_pouchList[0].method_6();
	}

	// Token: 0x06001EE2 RID: 7906 RVA: 0x000158B5 File Offset: 0x00013AB5
	public int method_3()
	{
		return this.m_pouchList[7].method_5();
	}

	// Token: 0x06001EE3 RID: 7907 RVA: 0x000158C8 File Offset: 0x00013AC8
	public int method_4()
	{
		return this.m_pouchList[7].method_4();
	}

	// Token: 0x06001EE4 RID: 7908 RVA: 0x000158DB File Offset: 0x00013ADB
	public void method_5(int int_0)
	{
		this.m_pouchList[7].method_7(int_0);
	}

	// Token: 0x06001EE5 RID: 7909 RVA: 0x000158EF File Offset: 0x00013AEF
	public void method_6(int int_0)
	{
		this.m_pouchList[7].method_8(int_0);
	}

	// Token: 0x06001EE6 RID: 7910 RVA: 0x00015903 File Offset: 0x00013B03
	public int method_7()
	{
		return this.m_pouchList[8].method_5();
	}

	// Token: 0x06001EE7 RID: 7911 RVA: 0x00015916 File Offset: 0x00013B16
	public int method_8()
	{
		return this.m_pouchList[8].method_4();
	}

	// Token: 0x06001EE8 RID: 7912 RVA: 0x00015929 File Offset: 0x00013B29
	public void method_9(int int_0)
	{
		this.m_pouchList[8].method_7(int_0);
	}

	// Token: 0x06001EE9 RID: 7913 RVA: 0x0001593D File Offset: 0x00013B3D
	public void method_10(int int_0)
	{
		this.m_pouchList[8].method_8(int_0);
	}

	// Token: 0x06001EEA RID: 7914 RVA: 0x00097ED0 File Offset: 0x000960D0
	public override int vmethod_13(AmmoType ammoType_0 = AmmoType.SMG)
	{
		int num;
		switch (ammoType_0)
		{
		case AmmoType.SMG:
			num = this.m_pouchList[1].method_5();
			break;
		case AmmoType.SniperRifle:
			num = this.m_pouchList[3].method_5();
			break;
		case AmmoType.Grenade:
			num = this.vmethod_19();
			break;
		case AmmoType.ShotGun:
			num = this.m_pouchList[4].method_5();
			break;
		case AmmoType.Pistol:
			num = this.m_pouchList[5].method_5();
			break;
		case AmmoType.AssaultRifle:
			num = this.m_pouchList[6].method_5();
			break;
		default:
			num = 0;
			break;
		}
		return num;
	}

	// Token: 0x06001EEB RID: 7915 RVA: 0x00097F70 File Offset: 0x00096170
	public override int vmethod_15(WeaponType weaponType_0)
	{
		int num;
		switch (weaponType_0)
		{
		case WeaponType.SMG:
			num = this.m_pouchList[1].method_5();
			break;
		case WeaponType.SniperRifle:
			num = this.m_pouchList[3].method_5();
			break;
		case WeaponType.ShotGun:
			num = this.m_pouchList[4].method_5();
			break;
		case WeaponType.RepeaterPistol:
			num = this.m_pouchList[5].method_5();
			break;
		case WeaponType.CombatRifle:
			num = this.m_pouchList[6].method_5();
			break;
		default:
			num = 0;
			break;
		}
		return num;
	}

	// Token: 0x06001EEC RID: 7916 RVA: 0x00098004 File Offset: 0x00096204
	public override int vmethod_10(AmmoType ammoType_0 = AmmoType.SMG)
	{
		int num;
		switch (ammoType_0)
		{
		case AmmoType.SMG:
			num = this.m_pouchList[1].method_4();
			break;
		case AmmoType.SniperRifle:
			num = this.m_pouchList[3].method_4();
			break;
		case AmmoType.Grenade:
			num = this.vmethod_18();
			break;
		case AmmoType.ShotGun:
			num = this.m_pouchList[4].method_4();
			break;
		case AmmoType.Pistol:
			num = this.m_pouchList[5].method_4();
			break;
		case AmmoType.AssaultRifle:
			num = this.m_pouchList[6].method_4();
			break;
		default:
			num = 0;
			break;
		}
		return num;
	}

	// Token: 0x06001EED RID: 7917 RVA: 0x000980A4 File Offset: 0x000962A4
	public override int vmethod_11(WeaponType weaponType_0)
	{
		int num;
		switch (weaponType_0)
		{
		case WeaponType.SMG:
			num = this.m_pouchList[1].method_4();
			break;
		case WeaponType.SniperRifle:
			num = this.m_pouchList[3].method_4();
			break;
		case WeaponType.ShotGun:
			num = this.m_pouchList[4].method_4();
			break;
		case WeaponType.RepeaterPistol:
			num = this.m_pouchList[5].method_4();
			break;
		case WeaponType.CombatRifle:
			num = this.m_pouchList[6].method_4();
			break;
		default:
			num = 0;
			break;
		}
		return num;
	}

	// Token: 0x06001EEE RID: 7918 RVA: 0x00098138 File Offset: 0x00096338
	public override int vmethod_12(WeaponType weaponType_0)
	{
		int num;
		switch (weaponType_0)
		{
		case WeaponType.SMG:
			num = this.m_pouchList[1].method_6();
			break;
		case WeaponType.SniperRifle:
			num = this.m_pouchList[3].method_6();
			break;
		case WeaponType.ShotGun:
			num = this.m_pouchList[4].method_6();
			break;
		case WeaponType.RepeaterPistol:
			num = this.m_pouchList[5].method_6();
			break;
		case WeaponType.CombatRifle:
			num = this.m_pouchList[6].method_6();
			break;
		default:
			num = 0;
			break;
		}
		return num;
	}

	// Token: 0x06001EEF RID: 7919 RVA: 0x00015951 File Offset: 0x00013B51
	public override int vmethod_19()
	{
		return this.m_pouchList[2].method_5();
	}

	// Token: 0x06001EF0 RID: 7920 RVA: 0x00015964 File Offset: 0x00013B64
	public override int vmethod_18()
	{
		return this.m_pouchList[2].method_4();
	}

	// Token: 0x06001EF1 RID: 7921 RVA: 0x00015977 File Offset: 0x00013B77
	public override EquipmentInventoryEntity.PropertyFlags vmethod_24()
	{
		return this.m_flags;
	}

	// Token: 0x06001EF2 RID: 7922 RVA: 0x0001597F File Offset: 0x00013B7F
	public int method_11()
	{
		return this.m_itemSlotCount;
	}

	// Token: 0x06001EF3 RID: 7923 RVA: 0x000981CC File Offset: 0x000963CC
	public int method_12()
	{
		int num = 0;
		for (int i = 0; i < this.m_itemSlots.Length; i++)
		{
			if (this.m_itemSlots[i] != null)
			{
				num++;
			}
		}
		return num;
	}

	// Token: 0x06001EF4 RID: 7924 RVA: 0x00015987 File Offset: 0x00013B87
	public override int vmethod_6()
	{
		if (this.vmethod_26() != null)
		{
			return this.vmethod_26().m_shieldPoints.method_5();
		}
		return 0;
	}

	// Token: 0x06001EF5 RID: 7925 RVA: 0x000159A9 File Offset: 0x00013BA9
	public override int vmethod_7()
	{
		if (this.vmethod_26() != null)
		{
			return this.vmethod_26().m_shieldPoints.method_4();
		}
		return 0;
	}

	// Token: 0x06001EF6 RID: 7926 RVA: 0x000159CB File Offset: 0x00013BCB
	public virtual ItemDNA vmethod_39()
	{
		if (this.m_shieldSlot != null)
		{
			return this.m_shieldSlot.method_2();
		}
		return null;
	}

	// Token: 0x06001EF7 RID: 7927 RVA: 0x000159E2 File Offset: 0x00013BE2
	public ItemDNA method_13()
	{
		if (this.m_classModeSlot != null)
		{
			return this.m_classModeSlot.method_2();
		}
		return null;
	}

	// Token: 0x06001EF8 RID: 7928 RVA: 0x00098200 File Offset: 0x00096400
	public ItemDNA method_14(AvatarSubPart avatarSubPart_0)
	{
		int num = this.method_33(avatarSubPart_0);
		if (num >= 0 && num < this.m_outfitCount)
		{
			return this.m_outfitSlots[num];
		}
		return null;
	}

	// Token: 0x06001EF9 RID: 7929 RVA: 0x000159F9 File Offset: 0x00013BF9
	public ItemDNA method_15()
	{
		if ((int)this.m_activeWeaponSlot < this.m_weaponSlots.Length && this.m_weaponSlots[(int)this.m_activeWeaponSlot] != null)
		{
			return this.m_weaponSlots[(int)this.m_activeWeaponSlot].method_2();
		}
		return null;
	}

	// Token: 0x06001EFA RID: 7930 RVA: 0x00015A2E File Offset: 0x00013C2E
	public void method_16()
	{
		this.m_isAmmoDirty = true;
		this.m_isItemsDirty = true;
	}

	// Token: 0x06001EFB RID: 7931 RVA: 0x00015A3E File Offset: 0x00013C3E
	public override void vmethod_25(EquipmentInventoryEntity.PropertyFlags propertyFlags_0)
	{
		this.m_flags = propertyFlags_0;
	}

	// Token: 0x06001EFC RID: 7932 RVA: 0x00015A47 File Offset: 0x00013C47
	public override EntityShield vmethod_26()
	{
		return this.m_shieldSlot.method_3() as EntityShield;
	}

	// Token: 0x06001EFD RID: 7933 RVA: 0x00015A59 File Offset: 0x00013C59
	public override EntityWeapon vmethod_27()
	{
		return this.m_weaponSlots[(int)this.m_activeWeaponSlot].method_3() as EntityWeapon;
	}

	// Token: 0x06001EFE RID: 7934 RVA: 0x00015A72 File Offset: 0x00013C72
	public override EntityWeapon vmethod_28(byte byte_0)
	{
		return this.m_weaponSlots[(int)byte_0].method_3() as EntityWeapon;
	}

	// Token: 0x06001EFF RID: 7935 RVA: 0x00015A86 File Offset: 0x00013C86
	public bool method_17(byte byte_0)
	{
		return this.m_weaponSlots[(int)byte_0].method_4();
	}

	// Token: 0x06001F00 RID: 7936 RVA: 0x0009822C File Offset: 0x0009642C
	public bool method_18(ref int int_0)
	{
		for (int i = 0; i < EquipmentInventoryEntityPlayer.s_weaponSlotCount; i++)
		{
			if (this.m_weaponSlots[i] != null && !this.m_weaponSlots[i].method_4())
			{
				int_0 = i;
				return true;
			}
		}
		return false;
	}

	// Token: 0x06001F01 RID: 7937 RVA: 0x00015A95 File Offset: 0x00013C95
	public EntityClassMode method_19()
	{
		return this.m_classModeSlot.method_3() as EntityClassMode;
	}

	// Token: 0x06001F02 RID: 7938 RVA: 0x00098268 File Offset: 0x00096468
	public void method_20(ItemDNA itemDNA_0)
	{
		object[] array = new object[] { itemDNA_0 };
		base.photonView.method_5("RPC_ShowInventoryFull", this.m_entity.vmethod_25().method_1(), array);
	}

	// Token: 0x06001F03 RID: 7939 RVA: 0x000982A4 File Offset: 0x000964A4
	public void method_21(float float_0 = 1f)
	{
		for (int i = 0; i < 6; i++)
		{
			if (i != 2 && MonoSingleton<LootingManager>.Instance != null)
			{
				int num = MonoSingleton<LootingManager>.Instance.method_2(ItemType.Ammo, (AmmoType)i);
				num = (int)((float)num * float_0);
				this.vmethod_14(this.vmethod_13((AmmoType)i) + num, (AmmoType)i);
			}
		}
		base.photonView.method_5("RPC_UseAmmoPack", this.m_entity.vmethod_25().method_1(), new object[0]);
	}

	// Token: 0x06001F04 RID: 7940 RVA: 0x00015AA7 File Offset: 0x00013CA7
	[RPC]
	public void RPC_ShowInventoryFull(ItemDNA itemDNA)
	{
		ServiceWrapperBase<InventoryServiceWrapper>.Instance.method_39(itemDNA);
	}

	// Token: 0x06001F05 RID: 7941 RVA: 0x00015AB5 File Offset: 0x00013CB5
	[RPC]
	public void RPC_UseAmmoPack()
	{
		DebugUtils.Log(LogCategory.Gamelogic, "RPC_UseAmmoPack");
		MonoSingleton<AppManager>.Instance.method_0().vmethod_5<CurrencyUpdateView>().vmethod_14(false);
	}

	// Token: 0x06001F06 RID: 7942 RVA: 0x00098318 File Offset: 0x00096518
	public override void vmethod_14(int int_0, AmmoType ammoType_0 = AmmoType.SMG)
	{
		int num = this.vmethod_13(ammoType_0);
		switch (ammoType_0)
		{
		case AmmoType.SMG:
			this.m_pouchList[1].method_8(int_0);
			this.m_isAmmoDirty |= num != this.vmethod_13(ammoType_0);
			break;
		case AmmoType.SniperRifle:
			this.m_pouchList[3].method_8(int_0);
			this.m_isAmmoDirty |= num != this.vmethod_13(ammoType_0);
			break;
		case AmmoType.Grenade:
			this.vmethod_20(int_0);
			break;
		case AmmoType.ShotGun:
			this.m_pouchList[4].method_8(int_0);
			this.m_isAmmoDirty |= num != this.vmethod_13(ammoType_0);
			break;
		case AmmoType.Pistol:
			this.m_pouchList[5].method_8(int_0);
			this.m_isAmmoDirty |= num != this.vmethod_13(ammoType_0);
			break;
		case AmmoType.AssaultRifle:
			this.m_pouchList[6].method_8(int_0);
			this.m_isAmmoDirty |= num != this.vmethod_13(ammoType_0);
			break;
		default:
			DebugUtils.Log(LogCategory.Gamelogic, "Wrong ammo type setup!!!Please log a bug");
			break;
		}
	}

	// Token: 0x06001F07 RID: 7943 RVA: 0x00098454 File Offset: 0x00096654
	public override void vmethod_16(int int_0, WeaponType weaponType_0)
	{
		int num = this.vmethod_15(weaponType_0);
		switch (weaponType_0)
		{
		case WeaponType.SMG:
			this.m_pouchList[1].method_8(int_0);
			this.m_isAmmoDirty |= num != this.vmethod_15(weaponType_0);
			break;
		case WeaponType.SniperRifle:
			this.m_pouchList[3].method_8(int_0);
			this.m_isAmmoDirty |= num != this.vmethod_15(weaponType_0);
			break;
		case WeaponType.ShotGun:
			this.m_pouchList[4].method_8(int_0);
			this.m_isAmmoDirty |= num != this.vmethod_15(weaponType_0);
			break;
		case WeaponType.RepeaterPistol:
			this.m_pouchList[5].method_8(int_0);
			this.m_isAmmoDirty |= num != this.vmethod_15(weaponType_0);
			break;
		case WeaponType.CombatRifle:
			this.m_pouchList[6].method_8(int_0);
			this.m_isAmmoDirty |= num != this.vmethod_15(weaponType_0);
			break;
		default:
			DebugUtils.Log(LogCategory.Gamelogic, "Wrong ammo type setup!!!Please log a bug");
			break;
		}
	}

	// Token: 0x06001F08 RID: 7944 RVA: 0x00098580 File Offset: 0x00096780
	public override void vmethod_17(int int_0, WeaponType weaponType_0)
	{
		int num = this.vmethod_11(weaponType_0);
		switch (weaponType_0)
		{
		case WeaponType.SMG:
			this.m_pouchList[1].method_7(int_0);
			this.m_isAmmoDirty |= num != this.vmethod_11(weaponType_0);
			break;
		case WeaponType.SniperRifle:
			this.m_pouchList[3].method_7(int_0);
			this.m_isAmmoDirty |= num != this.vmethod_11(weaponType_0);
			break;
		case WeaponType.ShotGun:
			this.m_pouchList[4].method_7(int_0);
			this.m_isAmmoDirty |= num != this.vmethod_11(weaponType_0);
			break;
		case WeaponType.RepeaterPistol:
			this.m_pouchList[5].method_7(int_0);
			this.m_isAmmoDirty |= num != this.vmethod_11(weaponType_0);
			break;
		case WeaponType.CombatRifle:
			this.m_pouchList[6].method_7(int_0);
			this.m_isAmmoDirty |= num != this.vmethod_11(weaponType_0);
			break;
		default:
			DebugUtils.Log(LogCategory.Gamelogic, "Wrong ammo type setup!!!Please log a bug");
			break;
		}
	}

	// Token: 0x06001F09 RID: 7945 RVA: 0x000986AC File Offset: 0x000968AC
	public override void vmethod_20(int int_0)
	{
		int num = this.vmethod_19();
		this.m_pouchList[2].method_8(int_0);
		this.m_isAmmoDirty |= num != this.vmethod_19();
	}

	// Token: 0x06001F0A RID: 7946 RVA: 0x00015AD7 File Offset: 0x00013CD7
	public override int vmethod_21()
	{
		return this.m_pouchList[2].method_6();
	}

	// Token: 0x06001F0B RID: 7947 RVA: 0x000986EC File Offset: 0x000968EC
	public override void vmethod_22(int int_0)
	{
		int num = this.vmethod_18();
		if (int_0 < this.vmethod_19())
		{
			this.vmethod_20(int_0);
		}
		this.m_pouchList[2].method_7(int_0);
		this.m_isAmmoDirty |= num != this.vmethod_18();
	}

	// Token: 0x06001F0C RID: 7948 RVA: 0x000154DE File Offset: 0x000136DE
	public override void vmethod_1(int int_0)
	{
		this.m_pouchList[0].method_7(int_0);
	}

	// Token: 0x06001F0D RID: 7949 RVA: 0x000154F2 File Offset: 0x000136F2
	public override void vmethod_5(int int_0)
	{
		this.m_pouchList[0].method_8(int_0);
	}

	// Token: 0x06001F0E RID: 7950 RVA: 0x00015AEA File Offset: 0x00013CEA
	public override void vmethod_3(int int_0)
	{
		this.m_pouchList[0].method_9(int_0);
	}

	// Token: 0x06001F0F RID: 7951 RVA: 0x0009873C File Offset: 0x0009693C
	public override void vmethod_9(int int_0)
	{
		EntityShield entityShield = this.vmethod_26();
		if (entityShield == null)
		{
			return;
		}
		entityShield.m_shieldPoints.method_8(int_0);
	}

	// Token: 0x06001F10 RID: 7952 RVA: 0x00098768 File Offset: 0x00096968
	public override void vmethod_8(int int_0)
	{
		EntityShield entityShield = this.vmethod_26();
		if (entityShield == null)
		{
			return;
		}
		entityShield.m_shieldPoints.method_7(int_0);
	}

	// Token: 0x06001F11 RID: 7953 RVA: 0x00015AFE File Offset: 0x00013CFE
	public ItemDNA method_22(int int_0)
	{
		return this.m_itemSlots[int_0];
	}

	// Token: 0x06001F12 RID: 7954 RVA: 0x00015B08 File Offset: 0x00013D08
	public ItemDNA method_23(int int_0)
	{
		return this.m_outfitSlots[int_0];
	}

	// Token: 0x06001F13 RID: 7955 RVA: 0x00098794 File Offset: 0x00096994
	private void Awake()
	{
		this.m_weaponSlots = new InventorySlot[EquipmentInventoryEntityPlayer.s_weaponSlotCount];
		for (int i = 0; i < EquipmentInventoryEntityPlayer.s_weaponSlotCount; i++)
		{
			this.m_weaponSlots[i] = new InventorySlot();
		}
		this.m_itemSlots = new ItemDNA[this.m_itemSlotCount];
		this.m_outfitSlots = new ItemDNA[this.m_outfitCount];
		this.m_pouchList.Clear();
		this.m_pouchList.Add(new Utils.PouchNetwork());
		this.m_pouchList.Add(new Utils.PouchNetwork());
		this.m_pouchList.Add(new Utils.PouchNetwork());
		this.m_pouchList.Add(new Utils.PouchNetwork());
		this.m_pouchList.Add(new Utils.PouchNetwork());
		this.m_pouchList.Add(new Utils.PouchNetwork());
		this.m_pouchList.Add(new Utils.PouchNetwork());
		this.m_pouchList.Add(new Utils.PouchNetwork());
		this.m_pouchList.Add(new Utils.PouchNetwork());
	}

	// Token: 0x06001F14 RID: 7956 RVA: 0x00015B12 File Offset: 0x00013D12
	public override void Start()
	{
		base.Start();
		this.m_entity = base.GetComponent<EntityPlayer>();
		ServiceWrapperBase<InventoryServiceWrapper>.Instance.vmethod_2();
	}

	// Token: 0x06001F15 RID: 7957 RVA: 0x00015B31 File Offset: 0x00013D31
	protected virtual void Update()
	{
		if (base.photonView.Boolean_1 && this.m_isAmmoDirty)
		{
			this.method_37();
		}
		if (base.photonView.Boolean_1 && this.m_isItemsDirty)
		{
			this.method_38();
		}
	}

	// Token: 0x06001F16 RID: 7958 RVA: 0x0009888C File Offset: 0x00096A8C
	public virtual bool vmethod_40(ItemDNA itemDNA_0)
	{
		if (itemDNA_0 == null)
		{
			sbyte b = this.method_26();
			return (int)b < 0;
		}
		if (itemDNA_0.method_3(ItemType.Material))
		{
			sbyte b2 = this.method_24(itemDNA_0.m_materialType, itemDNA_0.m_value);
			if ((int)b2 < 0)
			{
				return true;
			}
		}
		else if (itemDNA_0.method_3(ItemType.Weapon) || itemDNA_0.method_3(ItemType.Shield) || itemDNA_0.method_3(ItemType.ClassMode))
		{
			sbyte b3 = this.method_26();
			if ((int)b3 < 0)
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x06001F17 RID: 7959 RVA: 0x000988FC File Offset: 0x00096AFC
	protected sbyte method_24(MaterialType materialType_0, int int_0)
	{
		sbyte b = 0;
		while ((int)b < this.m_itemSlots.Length)
		{
			if (this.m_itemSlots[(int)b] != null && this.m_itemSlots[(int)b].method_3(ItemType.Material) && this.m_itemSlots[(int)b].m_materialType == materialType_0 && this.m_itemSlots[(int)b].m_value + int_0 <= EquipmentInventoryEntityPlayer.s_materialQuantityPerSlot)
			{
				return b;
			}
			b += 1;
		}
		return this.method_26();
	}

	// Token: 0x06001F18 RID: 7960 RVA: 0x0009896C File Offset: 0x00096B6C
	private int method_25(MaterialType materialType_0)
	{
		int num = 0;
		for (int i = 0; i < this.m_itemSlots.Length; i++)
		{
			if (this.m_itemSlots[i] != null && this.m_itemSlots[i].m_type == ItemType.Material && this.m_itemSlots[i].m_materialType == materialType_0)
			{
				num += this.m_itemSlots[i].m_value;
			}
		}
		return num;
	}

	// Token: 0x06001F19 RID: 7961 RVA: 0x000989CC File Offset: 0x00096BCC
	protected sbyte method_26()
	{
		sbyte b = 0;
		while ((int)b < this.m_itemSlots.Length)
		{
			if (this.m_itemSlots[(int)b] == null)
			{
				return b;
			}
			b += 1;
		}
		return -1;
	}

	// Token: 0x06001F1A RID: 7962 RVA: 0x00015B69 File Offset: 0x00013D69
	public ItemDNA method_27(byte byte_0)
	{
		return this.m_weaponSlots[(int)byte_0].method_2();
	}

	// Token: 0x06001F1B RID: 7963 RVA: 0x000989FC File Offset: 0x00096BFC
	public virtual void vmethod_41(byte byte_0, byte byte_1)
	{
		if (this.m_entity == null)
		{
			return;
		}
		PlayerInfoSync playerInfoSync = this.m_entity.vmethod_25();
		if (!(playerInfoSync == null) && playerInfoSync.IsMyActor())
		{
			this.m_isItemsDirty = true;
			ItemDNA itemDNA = this.m_itemSlots[(int)byte_0];
			this.m_itemSlots[(int)byte_0] = this.m_itemSlots[(int)byte_1];
			this.m_itemSlots[(int)byte_1] = itemDNA;
			ServiceWrapperBase<InventoryServiceWrapper>.Instance.method_2(InventoryServiceWrapper.InventoryUpdateType.ItemUpdate);
			return;
		}
	}

	// Token: 0x06001F1C RID: 7964 RVA: 0x00098A6C File Offset: 0x00096C6C
	public virtual void vmethod_42(byte byte_0, byte byte_1)
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

	// Token: 0x06001F1D RID: 7965 RVA: 0x00098AFC File Offset: 0x00096CFC
	public virtual void vmethod_43(byte byte_0, byte byte_1)
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
		if (this.m_itemSlots[(int)byte_0] != null && !(entityPlayer == null) && this.m_itemSlots[(int)byte_0].method_5(entityPlayer))
		{
			this.m_isItemsDirty = true;
			EntityWeapon entityWeapon = this.m_weaponSlots[(int)byte_1].method_3() as EntityWeapon;
			this.m_weaponSlots[(int)byte_1].method_0(0, this.m_itemSlots[(int)byte_0]);
			if (entityWeapon != null)
			{
				this.vmethod_16(this.vmethod_15(entityWeapon.method_99()) + entityWeapon.m_ammoCount, entityWeapon.method_99());
				this.m_itemSlots[(int)byte_0] = ItemDNA.smethod_2(entityWeapon.method_17());
				MonoSingleton<EntityManager>.Instance.method_2(entityWeapon);
			}
			else
			{
				this.m_itemSlots[(int)byte_0] = null;
			}
			ServiceWrapperBase<InventoryServiceWrapper>.Instance.method_2(InventoryServiceWrapper.InventoryUpdateType.ItemUpdate);
			this.vmethod_54(byte_1);
			return;
		}
		ServiceWrapperBase<InventoryServiceWrapper>.Instance.method_2(InventoryServiceWrapper.InventoryUpdateType.EquipItemFail);
	}

	// Token: 0x06001F1E RID: 7966 RVA: 0x00098C14 File Offset: 0x00096E14
	public virtual void vmethod_44(byte byte_0)
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
		if (this.vmethod_55() == byte_0)
		{
			return;
		}
		sbyte b = this.method_26();
		if ((int)b == -1)
		{
			return;
		}
		this.m_isItemsDirty = true;
		EntityWeapon entityWeapon = this.m_weaponSlots[(int)byte_0].method_3() as EntityWeapon;
		if (entityWeapon)
		{
			this.m_itemSlots[(int)b] = ItemDNA.smethod_2(entityWeapon.method_17());
			this.vmethod_16(this.vmethod_15(entityWeapon.method_99()) + entityWeapon.m_ammoCount, entityWeapon.method_99());
			MonoSingleton<EntityManager>.Instance.method_2(entityWeapon);
		}
		this.m_weaponSlots[(int)byte_0].method_6();
		ServiceWrapperBase<InventoryServiceWrapper>.Instance.method_2(InventoryServiceWrapper.InventoryUpdateType.ItemUpdate);
	}

	// Token: 0x06001F1F RID: 7967 RVA: 0x0000311B File Offset: 0x0000131B
	public virtual void vmethod_45(ItemDNA itemDNA_0)
	{
	}

	// Token: 0x06001F20 RID: 7968 RVA: 0x00098CE4 File Offset: 0x00096EE4
	public void method_28(Vector3 vector3_0)
	{
		EntityShield entityShield = this.m_shieldSlot.method_3() as EntityShield;
		if (entityShield != null)
		{
			MonoSingleton<EntityManager>.Instance.method_2(entityShield);
		}
		Vector3 position = this.m_entity.transform.position;
		position.y += 1f;
		Vector3 normalized = (vector3_0 - this.m_entity.transform.position).normalized;
		MonoSingleton<InstantiateManager>.Instance.SpawnItemEntity(this.vmethod_39(), position, this.m_entity.transform.rotation, normalized, -1, -1, 0, 0);
	}

	// Token: 0x06001F21 RID: 7969 RVA: 0x00098D80 File Offset: 0x00096F80
	public virtual void vmethod_46(byte byte_0)
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
		if (this.m_itemSlots[(int)byte_0] != null && !(entityPlayer == null) && this.m_itemSlots[(int)byte_0].method_5(entityPlayer))
		{
			if (this.m_itemSlots[(int)byte_0] != null && this.m_itemSlots[(int)byte_0].method_3(ItemType.Shield))
			{
				EntityShield entityShield = this.m_shieldSlot.method_3() as EntityShield;
				this.m_isItemsDirty = true;
				if (entityShield != null)
				{
					if (entityShield.method_19() != null)
					{
						this.m_itemSlots[(int)byte_0] = ItemDNA.smethod_7(entityShield.method_19());
					}
					MonoSingleton<EntityManager>.Instance.method_2(entityShield);
				}
				else
				{
					this.m_itemSlots[(int)byte_0] = null;
				}
				ServiceWrapperBase<InventoryServiceWrapper>.Instance.method_2(InventoryServiceWrapper.InventoryUpdateType.ChangeEquipedShield);
			}
			return;
		}
		ServiceWrapperBase<InventoryServiceWrapper>.Instance.method_2(InventoryServiceWrapper.InventoryUpdateType.EquipItemFail);
	}

	// Token: 0x06001F22 RID: 7970 RVA: 0x00098E78 File Offset: 0x00097078
	public virtual void vmethod_47()
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
		sbyte b = this.method_26();
		if ((int)b == -1)
		{
			return;
		}
		this.m_isItemsDirty = true;
		EntityClassMode entityClassMode = this.m_classModeSlot.method_3() as EntityClassMode;
		if (entityClassMode)
		{
			this.m_itemSlots[(int)b] = ItemDNA.smethod_8(entityClassMode.method_17());
			MonoSingleton<EntityManager>.Instance.method_2(entityClassMode);
		}
		this.m_classModeSlot.method_6();
		ServiceWrapperBase<InventoryServiceWrapper>.Instance.method_2(InventoryServiceWrapper.InventoryUpdateType.ChangeEquipedClassMod);
	}

	// Token: 0x06001F23 RID: 7971 RVA: 0x00098F14 File Offset: 0x00097114
	public virtual void vmethod_48()
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
		sbyte b = this.method_26();
		if ((int)b == -1)
		{
			return;
		}
		this.m_isItemsDirty = true;
		EntityShield entityShield = this.m_shieldSlot.method_3() as EntityShield;
		if (entityShield)
		{
			this.m_itemSlots[(int)b] = ItemDNA.smethod_7(entityShield.method_19());
			MonoSingleton<EntityManager>.Instance.method_2(entityShield);
		}
		this.m_shieldSlot.method_6();
		ServiceWrapperBase<InventoryServiceWrapper>.Instance.method_2(InventoryServiceWrapper.InventoryUpdateType.ChangeEquipedShield);
	}

	// Token: 0x06001F24 RID: 7972 RVA: 0x00015B78 File Offset: 0x00013D78
	[RPC]
	public void RPC_ApplyShieldSetup(int maxShieldPoints, float RegenerationCooldown, float regenerationRate, int shieldToEquipId, ItemDNA itemDNA)
	{
		base.StartCoroutine(this.method_29(maxShieldPoints, RegenerationCooldown, regenerationRate, shieldToEquipId, itemDNA));
	}

	// Token: 0x06001F25 RID: 7973 RVA: 0x00098FB0 File Offset: 0x000971B0
	private IEnumerator method_29(int int_0, float float_0, float float_1, int int_1, ItemDNA itemDNA_0)
	{
		EntityShield shieldToEquip2 = null;
		BadAssNetworkView networkView2 = null;
		do
		{
			networkView2 = BadAssNetworkView.smethod_3(int_1);
			yield return 0;
		}
		while (networkView2 == null);
		shieldToEquip2 = networkView2.GetComponent<EntityShield>();
		shieldToEquip2.method_16(itemDNA_0.method_7(), m_entity, int_0, float_0, float_1);
		shieldToEquip2.vmethod_63(m_entity);
		m_shieldSlot.method_0(int_1, itemDNA_0);
		ns0.ServiceWrapperBase<InventoryServiceWrapper>.Instance.method_2(InventoryServiceWrapper.InventoryUpdateType.ChangeEquipedShield);
	}
	// Token: 0x06001F26 RID: 7974 RVA: 0x00099018 File Offset: 0x00097218
	[RPC]
	public void RPC_ApplyOutfitsSetup(ItemDNA outfit1, ItemDNA outfit2, ItemDNA outfit3, ItemDNA outfit4, ItemDNA outfit5)
	{
		this.m_outfitSlots[0] = outfit1;
		this.m_outfitSlots[1] = outfit2;
		this.m_outfitSlots[2] = outfit3;
		this.m_outfitSlots[3] = outfit4;
		this.m_outfitSlots[4] = outfit5;
		ServiceWrapperBase<InventoryServiceWrapper>.Instance.method_2(InventoryServiceWrapper.InventoryUpdateType.ChangeEquipedOutfit);
		EntityPlayer entityPlayer = this.m_entity as EntityPlayer;
		if (entityPlayer != null)
		{
			entityPlayer.method_119(this.m_outfitCount);
		}
	}

	// Token: 0x06001F27 RID: 7975 RVA: 0x00015B8E File Offset: 0x00013D8E
	[RPC]
	public void RPC_ApplyClassModeSetup(int classModeToEquipId, ItemDNA itemDNA)
	{
		base.StartCoroutine(this.method_30(classModeToEquipId, itemDNA));
	}

	// Token: 0x06001F28 RID: 7976 RVA: 0x00099080 File Offset: 0x00097280
	private IEnumerator method_30(int int_0, ItemDNA itemDNA_0)
	{
		EntityClassMode classModeToEquip2 = null;
		BadAssNetworkView networkView2 = null;
		do
		{
			networkView2 = BadAssNetworkView.smethod_3(int_0);
			yield return 0;
		}
		while (networkView2 == null);
		classModeToEquip2 = networkView2.GetComponent<EntityClassMode>();
		classModeToEquip2.method_18(m_entity);
		classModeToEquip2.vmethod_63(m_entity);
		m_classModeSlot.method_1(classModeToEquip2, itemDNA_0);
		ns0.ServiceWrapperBase<InventoryServiceWrapper>.Instance.method_2(InventoryServiceWrapper.InventoryUpdateType.ChangeEquipedClassMod);
	}
	// Token: 0x06001F29 RID: 7977 RVA: 0x000990B8 File Offset: 0x000972B8
	public virtual void vmethod_49(ItemDNA itemDNA_0)
	{
		EntityClassMode entityClassMode = MonoSingleton<InstantiateManager>.Instance.SpawnClassModeItem(itemDNA_0, Vector3.zero, Quaternion.identity, true);
		entityClassMode.method_16(itemDNA_0.method_8());
		entityClassMode.vmethod_63(this.m_entity);
	}

	// Token: 0x06001F2A RID: 7978 RVA: 0x0000311B File Offset: 0x0000131B
	public void method_31()
	{
	}

	// Token: 0x06001F2B RID: 7979 RVA: 0x000990F4 File Offset: 0x000972F4
	public virtual void vmethod_50(byte byte_0)
	{
		if (this.m_entity == null)
		{
			return;
		}
		PlayerInfoSync playerInfoSync = this.m_entity.vmethod_25();
		if (!(playerInfoSync == null) && playerInfoSync.IsMyActor())
		{
			if (this.m_itemSlots[(int)byte_0] != null && this.m_itemSlots[(int)byte_0].method_3(ItemType.ClassMode))
			{
				ClassModeDNA classModeDNA = this.m_itemSlots[(int)byte_0].method_8();
				EntityPlayer entityPlayer = this.m_entity as EntityPlayer;
				if (classModeDNA == null || entityPlayer == null || !this.m_itemSlots[(int)byte_0].method_5(entityPlayer))
				{
					ServiceWrapperBase<InventoryServiceWrapper>.Instance.method_2(InventoryServiceWrapper.InventoryUpdateType.EquipItemFail);
					return;
				}
				EntityClassMode entityClassMode = this.m_classModeSlot.method_3() as EntityClassMode;
				this.m_isItemsDirty = true;
				if (entityClassMode != null)
				{
					if (entityClassMode.method_17() != null)
					{
						this.m_itemSlots[(int)byte_0] = ItemDNA.smethod_8(entityClassMode.method_17());
					}
					MonoSingleton<EntityManager>.Instance.method_2(entityClassMode);
				}
				else
				{
					this.m_itemSlots[(int)byte_0] = null;
				}
				ServiceWrapperBase<InventoryServiceWrapper>.Instance.method_2(InventoryServiceWrapper.InventoryUpdateType.ChangeEquipedClassMod);
			}
			return;
		}
	}

	// Token: 0x06001F2C RID: 7980 RVA: 0x000991F8 File Offset: 0x000973F8
	public void method_32()
	{
		if (this.m_entity == null)
		{
			return;
		}
		PlayerInfoSync playerInfoSync = this.m_entity.vmethod_25();
		if (!(playerInfoSync == null) && playerInfoSync.IsMyActor())
		{
			int[] array = new int[13];
			for (MaterialType materialType = MaterialType.MT_Titanium; materialType < MaterialType.TOTAL; materialType++)
			{
				array[(int)materialType] = this.method_25(materialType);
			}
			List<ItemDNA> list = new List<ItemDNA>(this.m_itemSlots);
			list.RemoveAll(new Predicate<ItemDNA>(EquipmentInventoryEntityPlayer.smethod_0));
			list.RemoveAll(new Predicate<ItemDNA>(EquipmentInventoryEntityPlayer.smethod_1));
			for (MaterialType materialType2 = MaterialType.MT_Titanium; materialType2 < MaterialType.TOTAL; materialType2++)
			{
				int i = array[(int)materialType2];
				if (i > 0)
				{
					while (i > 99)
					{
						list.Add(ItemDNA.smethod_3(materialType2, 99));
						i -= 99;
					}
					list.Add(ItemDNA.smethod_3(materialType2, i));
				}
			}
			list = list.OrderByDescending<ItemDNA, int>(new Func<ItemDNA, int>(EquipmentInventoryEntityPlayer.smethod_2)).ToList<ItemDNA>();
			int num = this.m_itemSlotCount - list.Count;
			for (int j = 0; j < num; j++)
			{
				list.Add(null);
			}
			this.m_itemSlots = list.ToArray();
			ServiceWrapperBase<InventoryServiceWrapper>.Instance.method_2(InventoryServiceWrapper.InventoryUpdateType.ItemUpdate);
			return;
		}
	}

	// Token: 0x06001F2D RID: 7981 RVA: 0x0009935C File Offset: 0x0009755C
	public virtual void vmethod_51(byte byte_0)
	{
		if (!this.vmethod_34(byte_0))
		{
			return;
		}
		if (this.m_itemSlots[(int)byte_0] != null && this.m_itemSlots[(int)byte_0].method_3(ItemType.Outfit))
		{
			OutfitDNA outfitDNA = this.m_itemSlots[(int)byte_0].method_9();
			EntityPlayer entityPlayer = this.m_entity as EntityPlayer;
			if (outfitDNA == null || entityPlayer == null || !this.m_itemSlots[(int)byte_0].method_5(entityPlayer))
			{
				ServiceWrapperBase<InventoryServiceWrapper>.Instance.method_2(InventoryServiceWrapper.InventoryUpdateType.EquipItemFail);
				return;
			}
			ItemDNA itemDNA = this.m_itemSlots[(int)byte_0];
			int num = this.method_33(itemDNA.method_9().m_avatarSubpart);
			ItemDNA itemDNA2 = this.m_outfitSlots[num];
			this.m_outfitSlots[num] = itemDNA;
			this.m_isItemsDirty = true;
			if (itemDNA2 != null)
			{
				this.m_itemSlots[(int)byte_0] = itemDNA2;
			}
			else
			{
				this.m_itemSlots[(int)byte_0] = null;
			}
			entityPlayer.method_121(itemDNA);
			ServiceWrapperBase<InventoryServiceWrapper>.Instance.method_2(InventoryServiceWrapper.InventoryUpdateType.ChangeEquipedOutfit);
		}
	}

	// Token: 0x06001F2E RID: 7982 RVA: 0x00099438 File Offset: 0x00097638
	public virtual void vmethod_52(byte byte_0)
	{
		if (this.m_entity == null)
		{
			return;
		}
		EntityPlayer entityPlayer = this.m_entity as EntityPlayer;
		if (entityPlayer == null)
		{
			return;
		}
		PlayerInfoSync playerInfoSync = this.m_entity.vmethod_25();
		if (playerInfoSync == null || !playerInfoSync.IsMyActor())
		{
			return;
		}
		int num = this.method_33((AvatarSubPart)byte_0);
		sbyte b = this.method_26();
		if (b == -1)
		{
			return;
		}
		this.m_isItemsDirty = true;
		entityPlayer.method_120(this.m_outfitSlots[num]);
		if (this.m_outfitSlots[num] != null)
		{
			this.m_itemSlots[(int)b] = ItemDNA.smethod_9(this.m_outfitSlots[num].method_9());
			this.m_outfitSlots[num] = null;
		}
		ServiceWrapperBase<InventoryServiceWrapper>.Instance.method_2(InventoryServiceWrapper.InventoryUpdateType.ChangeEquipedOutfit);
	}

	// Token: 0x06001F2F RID: 7983 RVA: 0x000994EC File Offset: 0x000976EC
	protected int method_33(AvatarSubPart avatarSubPart_0)
	{
		switch (avatarSubPart_0)
		{
		case AvatarSubPart.HAIR:
			return 0;
		case AvatarSubPart.MASK:
			return 1;
		case AvatarSubPart.BODY:
			return 2;
		case AvatarSubPart.PANTS:
			return 3;
		case AvatarSubPart.SHOE:
			return 4;
		}
		DebugUtils.LogWarning(LogCategory.Gamelogic, "avatar type " + avatarSubPart_0.ToString() + " is not equippable item");
		return -1;
	}

	// Token: 0x06001F30 RID: 7984 RVA: 0x00099548 File Offset: 0x00097748
	protected AvatarSubPart method_34(int int_0)
	{
		switch (int_0)
		{
		case 0:
			return AvatarSubPart.HAIR;
		case 1:
			return AvatarSubPart.MASK;
		case 2:
			return AvatarSubPart.BODY;
		case 3:
			return AvatarSubPart.PANTS;
		case 4:
			return AvatarSubPart.SHOE;
		default:
			DebugUtils.LogWarning(LogCategory.Gamelogic, "avatar index " + int_0 + " is not equippable item index");
			return AvatarSubPart.TOTAL;
		}
	}

	// Token: 0x06001F31 RID: 7985 RVA: 0x00099598 File Offset: 0x00097798
	public virtual void vmethod_53(byte byte_0)
	{
		if (this.m_entity == null)
		{
			return;
		}
		PlayerInfoSync playerInfoSync = this.m_entity.vmethod_25();
		if (!(playerInfoSync == null) && playerInfoSync.IsMyActor())
		{
			this.m_isItemsDirty = true;
			ItemDNA itemDNA = this.m_itemSlots[(int)byte_0];
			if (itemDNA != null)
			{
				this.m_itemSlots[(int)byte_0] = null;
			}
			ServiceWrapperBase<InventoryServiceWrapper>.Instance.method_2(InventoryServiceWrapper.InventoryUpdateType.ItemUpdate);
			return;
		}
	}

	// Token: 0x06001F32 RID: 7986 RVA: 0x000995FC File Offset: 0x000977FC
	public virtual void vmethod_54(byte byte_0)
	{
		if (byte_0 != this.m_activeWeaponSlot)
		{
			this.m_activeWeaponSlot = byte_0;
			if (this.m_entity == null)
			{
				return;
			}
			PlayerInfoSync playerInfoSync = this.m_entity.vmethod_25();
			if (playerInfoSync != null && playerInfoSync.IsMyActor())
			{
				ServiceWrapperBase<InventoryServiceWrapper>.Instance.method_2(InventoryServiceWrapper.InventoryUpdateType.ChangeActiveWeapon);
			}
		}
	}

	// Token: 0x06001F33 RID: 7987 RVA: 0x00015B9F File Offset: 0x00013D9F
	public virtual byte vmethod_55()
	{
		return this.m_activeWeaponSlot;
	}

	// Token: 0x06001F34 RID: 7988 RVA: 0x00099650 File Offset: 0x00097850
	public byte method_35()
	{
		byte b = this.m_activeWeaponSlot;
		for (int i = 0; i < EquipmentInventoryEntityPlayer.s_weaponSlotCount; i++)
		{
			b += 1;
			if ((int)b >= EquipmentInventoryEntityPlayer.s_weaponSlotCount)
			{
				b = 0;
			}
			if (this.method_17(b))
			{
				break;
			}
		}
		return b;
	}

	// Token: 0x06001F35 RID: 7989 RVA: 0x00099690 File Offset: 0x00097890
	public void OnPhotonEvaluate(PhotonPlayer player, ref PhotonPriority priority)
	{
		if (player == null)
		{
			return;
		}
		if (this.m_entity == null)
		{
			return;
		}
		PlayerInfoSync playerInfoSync = this.m_entity.vmethod_25();
		if (playerInfoSync == null)
		{
			return;
		}
		if (playerInfoSync.m_id == player.ActorId)
		{
			priority.priority = -2000;
		}
	}

	// Token: 0x06001F36 RID: 7990 RVA: 0x000996E0 File Offset: 0x000978E0
	public virtual void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
	{
		this.vmethod_35();
		InventoryServiceWrapper.InventoryUpdateType inventoryUpdateType = InventoryServiceWrapper.InventoryUpdateType.None;
		if (stream.IsWriting)
		{
			stream.SendNext((byte)this.m_flags);
			int num = 0;
			ItemDNA itemDNA = null;
			if (this.m_shieldSlot.method_3() != null)
			{
				num = this.m_shieldSlot.method_3().vmethod_0();
				itemDNA = this.m_shieldSlot.method_2();
			}
			stream.SendNext(num);
			stream.SendNext(itemDNA);
			for (int i = 0; i < EquipmentInventoryEntityPlayer.s_weaponSlotCount; i++)
			{
				num = 0;
				itemDNA = null;
				if (this.m_weaponSlots[i].method_3())
				{
					num = this.m_weaponSlots[i].method_3().vmethod_0();
					itemDNA = this.m_weaponSlots[i].method_2();
				}
				stream.SendNext(num);
				stream.SendNext(itemDNA);
			}
			stream.SendNext(this.m_activeWeaponSlot);
			this.m_isEquipmentReady = true;
		}
		else
		{
			this.m_flags = (EquipmentInventoryEntity.PropertyFlags)((byte)stream.ReceiveNext());
			bool flag = false;
			int num2 = (int)stream.ReceiveNext();
			ItemDNA itemDNA2 = (ItemDNA)stream.ReceiveNext();
			bool flag2;
			if (itemDNA2 != null && this.m_shieldSlot != null)
			{
				flag2 = itemDNA2.Equals(this.m_shieldSlot.method_2());
			}
			else
			{
				flag2 = itemDNA2 == null && this.m_shieldSlot.method_2() == null;
			}
			flag |= !flag2;
			this.m_shieldSlot.method_0(num2, itemDNA2);
			for (int j = 0; j < EquipmentInventoryEntityPlayer.s_weaponSlotCount; j++)
			{
				int num3 = (int)stream.ReceiveNext();
				ItemDNA itemDNA3 = (ItemDNA)stream.ReceiveNext();
				bool flag3;
				if (itemDNA3 != null && this.m_weaponSlots[j] != null)
				{
					flag3 = itemDNA3.Equals(this.m_weaponSlots[j].method_2());
				}
				else
				{
					flag3 = itemDNA3 == null && this.m_weaponSlots[j].method_2() == null;
				}
				flag |= !flag3;
				this.m_weaponSlots[j].method_0(num3, itemDNA3);
			}
			byte b = (byte)stream.ReceiveNext();
			bool flag4 = this.m_activeWeaponSlot != b;
			this.vmethod_54(b);
			if (flag && flag4)
			{
				inventoryUpdateType = InventoryServiceWrapper.InventoryUpdateType.FullUpdate;
			}
			else if (flag)
			{
				inventoryUpdateType = InventoryServiceWrapper.InventoryUpdateType.ItemUpdate;
			}
			else if (flag4)
			{
				inventoryUpdateType = InventoryServiceWrapper.InventoryUpdateType.ChangeActiveWeapon;
			}
			this.m_isEquipmentReady = true;
		}
		if (this.m_entity != null && !this.m_entity.method_3() && inventoryUpdateType != InventoryServiceWrapper.InventoryUpdateType.None)
		{
			ServiceWrapperBase<InventoryServiceWrapper>.Instance.method_2(inventoryUpdateType);
		}
	}

	// Token: 0x06001F37 RID: 7991 RVA: 0x00015BA7 File Offset: 0x00013DA7
	public override void vmethod_35()
	{
		base.vmethod_35();
		if (this.vmethod_26())
		{
			this.vmethod_26().m_shieldPoints.method_10();
		}
	}

	// Token: 0x06001F38 RID: 7992 RVA: 0x00015BCC File Offset: 0x00013DCC
	public override void vmethod_36()
	{
		base.vmethod_35();
		if (this.vmethod_26())
		{
			this.vmethod_26().m_shieldPoints.method_11();
		}
	}

	// Token: 0x06001F39 RID: 7993 RVA: 0x00099958 File Offset: 0x00097B58
	public override Hashtable vmethod_37()
	{
		Hashtable hashtable = new Hashtable();
		hashtable[0] = this.vmethod_0();
		hashtable[1] = this.vmethod_4();
		hashtable[2] = this.vmethod_7();
		hashtable[3] = this.vmethod_6();
		hashtable[4] = this.method_4();
		hashtable[5] = this.method_3();
		hashtable[6] = this.method_8();
		hashtable[7] = this.method_7();
		return hashtable;
	}

	// Token: 0x06001F3A RID: 7994 RVA: 0x00099A24 File Offset: 0x00097C24
	public override void vmethod_38(Hashtable hashtable_0)
	{
		int num = (int)hashtable_0[0];
		int num2 = (int)hashtable_0[1];
		int num3 = (int)hashtable_0[2];
		int num4 = (int)hashtable_0[3];
		int num5 = (int)hashtable_0[4];
		int num6 = (int)hashtable_0[5];
		int num7 = (int)hashtable_0[6];
		int num8 = (int)hashtable_0[7];
		this.vmethod_1(num);
		this.vmethod_5(num2);
		this.vmethod_8(num3);
		this.vmethod_9(num4);
		this.method_5(num5);
		this.method_6(num6);
		this.method_9(num7);
		this.method_10(num8);
	}

	// Token: 0x06001F3B RID: 7995 RVA: 0x00099B04 File Offset: 0x00097D04
	public void method_36()
	{
		object[] array = new object[this.m_outfitCount];
		for (int i = 0; i < this.m_outfitCount; i++)
		{
			array[i] = this.m_outfitSlots[i];
		}
		base.photonView.method_4("RPC_OnUpdateOutfits", PhotonTargets.Others, array);
	}

	// Token: 0x06001F3C RID: 7996 RVA: 0x00099B4C File Offset: 0x00097D4C
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

	// Token: 0x06001F3D RID: 7997 RVA: 0x00099BD8 File Offset: 0x00097DD8
	private void method_37()
	{
		Hashtable hashtable = new Hashtable();
		hashtable[0] = (short)this.m_pouchList[1].method_4();
		hashtable[1] = (short)this.m_pouchList[1].method_5();
		hashtable[2] = (short)this.m_pouchList[3].method_4();
		hashtable[3] = (short)this.m_pouchList[3].method_5();
		hashtable[4] = (byte)this.m_pouchList[2].method_4();
		hashtable[5] = (byte)this.m_pouchList[2].method_5();
		hashtable[6] = (short)this.m_pouchList[4].method_4();
		hashtable[7] = (short)this.m_pouchList[4].method_5();
		hashtable[8] = (short)this.m_pouchList[5].method_4();
		hashtable[9] = (short)this.m_pouchList[5].method_5();
		hashtable[10] = (short)this.m_pouchList[6].method_4();
		hashtable[11] = (short)this.m_pouchList[6].method_5();
		base.photonView.method_5("RPC_OnReceiveAmmos", this.m_entity.vmethod_25().method_1(), new object[] { hashtable });
		this.m_isAmmoDirty = false;
	}

	// Token: 0x06001F3E RID: 7998 RVA: 0x00099DC4 File Offset: 0x00097FC4
	private void method_38()
	{
		Hashtable hashtable = new Hashtable();
		Hashtable hashtable2 = hashtable;
		int num = 0;
		int num2 = 1;
		hashtable2[num] = this.m_itemSlotCount;
		for (int i = 0; i < this.m_itemSlotCount; i++)
		{
			hashtable[num2++] = this.m_itemSlots[i];
		}
		base.photonView.method_5("RPC_OnReceiveItems", this.m_entity.vmethod_25().method_1(), new object[] { hashtable });
		this.m_isItemsDirty = false;
	}

	// Token: 0x06001F3F RID: 7999 RVA: 0x00099E4C File Offset: 0x0009804C
	[RPC]
	private void RPC_OnReceiveAmmos(Hashtable data)
	{
		this.m_pouchList[1].method_7((int)((short)data[0]));
		this.m_pouchList[1].method_8((int)((short)data[1]));
		this.m_pouchList[3].method_7((int)((short)data[2]));
		this.m_pouchList[3].method_8((int)((short)data[3]));
		this.m_pouchList[2].method_7((int)((byte)data[4]));
		this.m_pouchList[2].method_8((int)((byte)data[5]));
		this.m_pouchList[4].method_7((int)((short)data[6]));
		this.m_pouchList[4].method_8((int)((short)data[7]));
		this.m_pouchList[5].method_7((int)((short)data[8]));
		this.m_pouchList[5].method_8((int)((short)data[9]));
		this.m_pouchList[6].method_7((int)((short)data[10]));
		this.m_pouchList[6].method_8((int)((short)data[11]));
	}

	// Token: 0x06001F40 RID: 8000 RVA: 0x00099FF4 File Offset: 0x000981F4
	[RPC]
	private void RPC_OnReceiveItems(Hashtable data)
	{
		int num = 0;
		int num2 = 1;
		this.m_itemSlotCount = (int)data[num];
		ItemDNA[] array;
		if (this.m_itemSlotCount != this.m_itemSlots.Length)
		{
			array = new ItemDNA[this.m_itemSlotCount];
		}
		else
		{
			array = this.m_itemSlots;
		}
		bool flag = false;
		for (int i = 0; i < this.m_itemSlotCount; i++)
		{
			bool flag2 = false;
			ItemDNA itemDNA = (ItemDNA)data[num2++];
			if (i < this.m_itemSlots.Length)
			{
				if (itemDNA != null && this.m_itemSlots[i] != null)
				{
					flag2 = itemDNA.Equals(this.m_itemSlots[i]);
				}
				else
				{
					flag2 = itemDNA == null && this.m_itemSlots[i] == null;
				}
			}
			flag |= !flag2;
			array[i] = itemDNA;
		}
		this.m_itemSlots = array;
		if (this.m_entity && flag)
		{
			ServiceWrapperBase<InventoryServiceWrapper>.Instance.method_2(InventoryServiceWrapper.InventoryUpdateType.ItemUpdate);
		}
	}

	// Token: 0x06001F41 RID: 8001 RVA: 0x0009A0E0 File Offset: 0x000982E0
	public virtual EntityShield vmethod_56()
	{
		return null;
	}

	// Token: 0x06001F42 RID: 8002 RVA: 0x0000311B File Offset: 0x0000131B
	public virtual void vmethod_57(int int_0, int int_1)
	{
	}

	// Token: 0x06001F43 RID: 8003 RVA: 0x00015BF1 File Offset: 0x00013DF1
	[CompilerGenerated]
	private static bool smethod_0(ItemDNA itemDNA_0)
	{
		return itemDNA_0 == null;
	}

	// Token: 0x06001F44 RID: 8004 RVA: 0x00015BF7 File Offset: 0x00013DF7
	[CompilerGenerated]
	private static bool smethod_1(ItemDNA itemDNA_0)
	{
		return itemDNA_0.m_type == ItemType.Material;
	}

	// Token: 0x06001F45 RID: 8005 RVA: 0x00015C02 File Offset: 0x00013E02
	[CompilerGenerated]
	private static int smethod_2(ItemDNA itemDNA_0)
	{
		return Inventory.smethod_0(itemDNA_0);
	}

	// Token: 0x06001F46 RID: 8006 RVA: 0x00015C0A File Offset: 0x00013E0A
	[RPC]
	private void RPC_H2C_SetGrenadeCount(byte maxGrenades, byte curGrenades)
	{
		this.m_pouchList[2].method_7((int)maxGrenades);
		this.m_pouchList[2].method_8((int)curGrenades);
	}

	// Token: 0x04001409 RID: 5129
	protected static int s_weaponSlotCount = 4;

	// Token: 0x0400140A RID: 5130
	protected static int s_materialQuantityPerSlot = 99;

	// Token: 0x0400140B RID: 5131
	protected EquipmentInventoryEntity.PropertyFlags m_flags;

	// Token: 0x0400140C RID: 5132
	protected bool m_isAmmoDirty;

	// Token: 0x0400140D RID: 5133
	protected bool m_isItemsDirty;

	// Token: 0x0400140E RID: 5134
	private bool m_isEquipmentReady;

	// Token: 0x0400140F RID: 5135
	protected InventorySlot m_shieldSlot = new InventorySlot();

	// Token: 0x04001410 RID: 5136
	protected InventorySlot m_classModeSlot = new InventorySlot();

	// Token: 0x04001411 RID: 5137
	protected InventorySlot[] m_weaponSlots;

	// Token: 0x04001412 RID: 5138
	protected ItemDNA[] m_itemSlots;

	// Token: 0x04001413 RID: 5139
	protected ItemDNA[] m_outfitSlots;

	// Token: 0x04001414 RID: 5140
	protected byte m_activeWeaponSlot;

	// Token: 0x04001415 RID: 5141
	protected short m_lastShieldPointReceived;

	// Token: 0x04001416 RID: 5142
	protected int m_itemSlotCount = 60;

	// Token: 0x04001417 RID: 5143
	protected int m_outfitCount = 5;

	// Token: 0x04001418 RID: 5144
	protected Inventory m_inventory;

	// Token: 0x02000493 RID: 1171
	protected enum PouchType
	{
		// Token: 0x0400141D RID: 5149
		LIFE,
		// Token: 0x0400141E RID: 5150
		SMGAMMO,
		// Token: 0x0400141F RID: 5151
		GRENADE,
		// Token: 0x04001420 RID: 5152
		SNIPERAMMO,
		// Token: 0x04001421 RID: 5153
		SHOTGUNAMMO,
		// Token: 0x04001422 RID: 5154
		PISTOLAMMO,
		// Token: 0x04001423 RID: 5155
		ASSAULTRIFLEAMMO,
		// Token: 0x04001424 RID: 5156
		SECONDWINDLIFE,
		// Token: 0x04001425 RID: 5157
		SECONDWINDREVIVE
	}
}
