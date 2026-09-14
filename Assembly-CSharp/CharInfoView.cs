using System;
using System.Collections.Generic;
using ns0;
using UnityEngine;
using XsdSettings;

// Token: 0x020006EB RID: 1771
public class CharInfoView : BaseView
{
	// Token: 0x06002EBA RID: 11962 RVA: 0x000D8C18 File Offset: 0x000D6E18
	public CharInfoView()
	{
		this._arrWeapons = new ItemDNA[this._iWeaponSlotSum];
		this._ammoInfoList = new Dictionary<int, Vector2>();
		for (int i = 0; i < 6; i++)
		{
			this._ammoInfoList.Add(i, new Vector2(0f, 0f));
		}
	}

	// Token: 0x1700024F RID: 591
	// (get) Token: 0x06002EBC RID: 11964 RVA: 0x0001ED83 File Offset: 0x0001CF83
	// (set) Token: 0x06002EBB RID: 11963 RVA: 0x0001ED7A File Offset: 0x0001CF7A
	public virtual bool bPVPDisp { get; set; }

	// Token: 0x17000250 RID: 592
	// (get) Token: 0x06002EBD RID: 11965 RVA: 0x0001ED8B File Offset: 0x0001CF8B
	public int Int32_0
	{
		get
		{
			return this._iActivedIndex;
		}
	}

	// Token: 0x17000251 RID: 593
	// (get) Token: 0x06002EBE RID: 11966 RVA: 0x0001ED93 File Offset: 0x0001CF93
	public ItemDNA[] ItemDNA_0
	{
		get
		{
			return this._arrWeapons;
		}
	}

	// Token: 0x06002EBF RID: 11967 RVA: 0x000D8C88 File Offset: 0x000D6E88
	public override void vmethod_2()
	{
		base.vmethod_2();
		MonoSingleton<AppManager>.Instance.method_0().method_16(this, "UIInventory");
		MonoSingleton<AppManager>.Instance.method_0().method_8(this);
		ServiceWrapperBase<InventoryServiceWrapper>.Instance.method_0(new InventoryServiceWrapper.InventoryUpdateCallback(this.vmethod_5));
		if (ServiceWrapperBase<InventoryServiceWrapper>.Instance.vmethod_2())
		{
			this.vmethod_5(InventoryServiceWrapper.InventoryUpdateType.FullUpdate);
			this.vmethod_5(InventoryServiceWrapper.InventoryUpdateType.ChangeActiveWeapon);
		}
	}

	// Token: 0x06002EC0 RID: 11968 RVA: 0x000D8CF4 File Offset: 0x000D6EF4
	public override void vmethod_3()
	{
		base.vmethod_3();
		MonoSingleton<AppManager>.Instance.method_0().method_9(this);
		this._modelController = null;
		MonoSingleton<AppManager>.Instance.method_0().method_17(this, string.Empty);
		this._bVisible = false;
		ServiceWrapperBase<InventoryServiceWrapper>.Instance.method_1(new InventoryServiceWrapper.InventoryUpdateCallback(this.vmethod_5));
	}

	// Token: 0x06002EC1 RID: 11969 RVA: 0x000D8D54 File Offset: 0x000D6F54
	public override bool OnShortCutCMD(string command)
	{
		if (MonoSingleton<Session>.Instance != null)
		{
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
			if (!component.method_3(PlayerAction.AccessInventory))
			{
				return false;
			}
		}
		if (!this.Boolean_0)
		{
			return false;
		}
		this.Boolean_1 = !this.Boolean_1;
		return true;
	}

	// Token: 0x06002EC2 RID: 11970 RVA: 0x000D8DD4 File Offset: 0x000D6FD4
	public override bool vmethod_4()
	{
		if (this.Boolean_1 && MonoSingleton<AppManager>.Instance.method_0().vmethod_5<WeaponPreviewView>().Boolean_1)
		{
			MonoSingleton<AppManager>.Instance.method_0().vmethod_5<WeaponPreviewView>().vmethod_5();
			return true;
		}
		if (this.Boolean_1)
		{
			this.Boolean_1 = false;
			return true;
		}
		return base.vmethod_4();
	}

	// Token: 0x06002EC3 RID: 11971 RVA: 0x000D8E2C File Offset: 0x000D702C
	public virtual void vmethod_5(InventoryServiceWrapper.InventoryUpdateType inventoryUpdateType_0)
	{
		if (inventoryUpdateType_0 != InventoryServiceWrapper.InventoryUpdateType.ChangeActiveWeapon)
		{
			if (inventoryUpdateType_0 != InventoryServiceWrapper.InventoryUpdateType.WeaponSlotsUpdate)
			{
				if (inventoryUpdateType_0 == InventoryServiceWrapper.InventoryUpdateType.ChangeEquipedShield)
				{
					this.method_7();
					this.vmethod_15();
					this.vmethod_11();
					goto IL_0088;
				}
				if (inventoryUpdateType_0 == InventoryServiceWrapper.InventoryUpdateType.ChangeEquipedClassMod)
				{
					this.method_8();
					this.vmethod_16();
					this.vmethod_11();
					goto IL_0088;
				}
				if (inventoryUpdateType_0 == InventoryServiceWrapper.InventoryUpdateType.ChangeEquipedOutfit)
				{
					this.method_9();
					this.vmethod_17();
					goto IL_0088;
				}
				if (inventoryUpdateType_0 == InventoryServiceWrapper.InventoryUpdateType.EquipItemFail)
				{
					goto IL_0088;
				}
				if (this.method_5())
				{
					this.vmethod_19();
					this.method_6();
					this.vmethod_9();
					goto IL_0088;
				}
				goto IL_0088;
			}
		}
		if (this.method_5())
		{
			this.method_6();
			this.vmethod_9();
			this.vmethod_11();
		}
		IL_0088:
		this.vmethod_14();
		this.vmethod_13();
		this.vmethod_18(inventoryUpdateType_0);
	}

	// Token: 0x06002EC4 RID: 11972 RVA: 0x0001ED9B File Offset: 0x0001CF9B
	public virtual void vmethod_6(PlayerProperties playerProperties_0)
	{
		if (playerProperties_0 != null)
		{
			this._playerInfo = playerProperties_0;
		}
		this.vmethod_10();
	}

	// Token: 0x06002EC5 RID: 11973 RVA: 0x0001EDAD File Offset: 0x0001CFAD
	public virtual ItemDNA vmethod_7()
	{
		if (this._arrWeapons != null && this._arrWeapons[this._iActivedIndex] != null)
		{
			return this._arrWeapons[this._iActivedIndex];
		}
		return null;
	}

	// Token: 0x06002EC6 RID: 11974 RVA: 0x0001EDD5 File Offset: 0x0001CFD5
	public ItemDNA method_3()
	{
		return this._shieldDNA;
	}

	// Token: 0x06002EC7 RID: 11975 RVA: 0x0001EDDD File Offset: 0x0001CFDD
	public ItemDNA method_4()
	{
		return this._classModeDNA;
	}

	// Token: 0x06002EC8 RID: 11976 RVA: 0x0001EDE5 File Offset: 0x0001CFE5
	protected override void vmethod_1(bool bool_0, bool bool_1 = false)
	{
		base.vmethod_1(bool_0, bool_1);
		if (this._bVisible && MonoSingleton<GraphicsMgr>.Instance != null)
		{
			MonoSingleton<GraphicsMgr>.Instance.method_22().method_9();
		}
	}

	// Token: 0x06002EC9 RID: 11977 RVA: 0x000D8ED4 File Offset: 0x000D70D4
	public virtual void vmethod_8(bool bool_0)
	{
		if (MonoSingleton<Session>.Instance != null && MonoSingleton<Session>.Instance.GetLocalPlayer() && MonoSingleton<Session>.Instance.GetLocalPlayer().GetEntity())
		{
			GameObject gameObject = (MonoSingleton<Session>.Instance.GetLocalPlayer().GetEntity().vmethod_12() as PlayerAnimationManagerFSM).method_28(bool_0);
			if (gameObject != null && bool_0)
			{
				MaterialHelper.smethod_0(gameObject);
				Vector3 vector = new Vector3(0f, 0f, 0f);
				Vector3 vector2 = new Vector3(0f, 180f, 0f);
				if (MonoSingleton<GraphicsMgr>.Instance != null)
				{
					MonoSingleton<GraphicsMgr>.Instance.method_22().method_16(gameObject, vector, vector2, false);
				}
				this._modelController = gameObject.GetComponent<UIModelController>();
				if (this._modelController == null)
				{
					this._modelController = gameObject.AddComponent<UIModelController>();
				}
				else
				{
					this._modelController.method_1();
				}
			}
		}
		if (MonoSingleton<GraphicsMgr>.Instance != null)
		{
			MonoSingleton<GraphicsMgr>.Instance.method_22().method_12(bool_0);
		}
		if (!bool_0)
		{
			ServiceWrapperBase<InventoryServiceWrapper>.Instance.method_21();
		}
	}

	// Token: 0x06002ECA RID: 11978 RVA: 0x0000311B File Offset: 0x0000131B
	protected virtual void vmethod_9()
	{
	}

	// Token: 0x06002ECB RID: 11979 RVA: 0x0000311B File Offset: 0x0000131B
	protected virtual void vmethod_10()
	{
	}

	// Token: 0x06002ECC RID: 11980 RVA: 0x0000311B File Offset: 0x0000131B
	protected virtual void vmethod_11()
	{
	}

	// Token: 0x06002ECD RID: 11981 RVA: 0x0000311B File Offset: 0x0000131B
	protected virtual void vmethod_12()
	{
	}

	// Token: 0x06002ECE RID: 11982 RVA: 0x0000311B File Offset: 0x0000131B
	protected virtual void vmethod_13()
	{
	}

	// Token: 0x06002ECF RID: 11983 RVA: 0x0000311B File Offset: 0x0000131B
	protected virtual void vmethod_14()
	{
	}

	// Token: 0x06002ED0 RID: 11984 RVA: 0x0000311B File Offset: 0x0000131B
	protected virtual void vmethod_15()
	{
	}

	// Token: 0x06002ED1 RID: 11985 RVA: 0x0000311B File Offset: 0x0000131B
	protected virtual void vmethod_16()
	{
	}

	// Token: 0x06002ED2 RID: 11986 RVA: 0x0000311B File Offset: 0x0000131B
	protected virtual void vmethod_17()
	{
	}

	// Token: 0x06002ED3 RID: 11987 RVA: 0x0000311B File Offset: 0x0000131B
	protected virtual void vmethod_18(InventoryServiceWrapper.InventoryUpdateType inventoryUpdateType_0)
	{
	}

	// Token: 0x06002ED4 RID: 11988 RVA: 0x0000311B File Offset: 0x0000131B
	protected virtual void vmethod_19()
	{
	}

	// Token: 0x06002ED5 RID: 11989 RVA: 0x000D9000 File Offset: 0x000D7200
	protected bool method_5()
	{
		if (!ServiceWrapperBase<InventoryServiceWrapper>.Instance.vmethod_2())
		{
			return false;
		}
		this.method_6();
		for (int i = 0; i < this._iWeaponSlotSum; i++)
		{
			this._arrWeapons[i] = ServiceWrapperBase<InventoryServiceWrapper>.Instance.method_7((byte)i);
		}
		return true;
	}

	// Token: 0x06002ED6 RID: 11990 RVA: 0x0001EE13 File Offset: 0x0001D013
	protected void method_6()
	{
		this._iActivedIndex = (int)ServiceWrapperBase<InventoryServiceWrapper>.Instance.method_8();
	}

	// Token: 0x06002ED7 RID: 11991 RVA: 0x0001EE25 File Offset: 0x0001D025
	protected void method_7()
	{
		this._shieldDNA = ServiceWrapperBase<InventoryServiceWrapper>.Instance.method_26();
	}

	// Token: 0x06002ED8 RID: 11992 RVA: 0x0001EE37 File Offset: 0x0001D037
	protected void method_8()
	{
		this._classModeDNA = ServiceWrapperBase<InventoryServiceWrapper>.Instance.method_27();
	}

	// Token: 0x06002ED9 RID: 11993 RVA: 0x000D9048 File Offset: 0x000D7248
	protected void method_9()
	{
		this._arrOutfits[0] = ServiceWrapperBase<InventoryServiceWrapper>.Instance.method_28(AvatarSubPart.HAIR);
		this._arrOutfits[1] = ServiceWrapperBase<InventoryServiceWrapper>.Instance.method_28(AvatarSubPart.MASK);
		this._arrOutfits[2] = ServiceWrapperBase<InventoryServiceWrapper>.Instance.method_28(AvatarSubPart.BODY);
		this._arrOutfits[3] = ServiceWrapperBase<InventoryServiceWrapper>.Instance.method_28(AvatarSubPart.PANTS);
		this._arrOutfits[4] = ServiceWrapperBase<InventoryServiceWrapper>.Instance.method_28(AvatarSubPart.SHOE);
	}

	// Token: 0x06002EDA RID: 11994 RVA: 0x0001EE49 File Offset: 0x0001D049
	protected void method_10(int int_0, int int_1)
	{
		if (ServiceWrapperBase<InventoryServiceWrapper>.Instance.vmethod_2())
		{
			ServiceWrapperBase<InventoryServiceWrapper>.Instance.method_13((byte)int_0, (byte)int_1);
		}
	}

	// Token: 0x06002EDB RID: 11995 RVA: 0x0001EE65 File Offset: 0x0001D065
	protected void method_11(int int_0)
	{
		if (ServiceWrapperBase<InventoryServiceWrapper>.Instance.vmethod_2() && this._iActivedIndex != int_0)
		{
			ServiceWrapperBase<InventoryServiceWrapper>.Instance.method_29((byte)int_0);
		}
	}

	// Token: 0x06002EDC RID: 11996 RVA: 0x0001EE88 File Offset: 0x0001D088
	protected void method_12(int int_0, int int_1)
	{
		if (ServiceWrapperBase<InventoryServiceWrapper>.Instance.vmethod_2())
		{
			ServiceWrapperBase<InventoryServiceWrapper>.Instance.method_12((byte)int_0, (byte)int_1);
		}
	}

	// Token: 0x06002EDD RID: 11997 RVA: 0x000D90B4 File Offset: 0x000D72B4
	protected virtual void vmethod_20(int int_0)
	{
		if (ServiceWrapperBase<InventoryServiceWrapper>.Instance.vmethod_2())
		{
			OutfitDNA outfitDNA = ServiceWrapperBase<InventoryServiceWrapper>.Instance.method_6(int_0).method_9();
			if (outfitDNA != null && this._playerInfo.m_avatarDna.m_type == outfitDNA.m_avatarType && MonoSingleton<GraphicsMgr>.Instance != null)
			{
				if (outfitDNA.m_avatarSubpart != AvatarSubPart.PANTS)
				{
					if (outfitDNA.m_avatarSubpart != AvatarSubPart.SHOE)
					{
						MonoSingleton<GraphicsMgr>.Instance.method_22().method_7();
						goto IL_0079;
					}
				}
				MonoSingleton<GraphicsMgr>.Instance.method_22().method_8();
			}
			IL_0079:
			ServiceWrapperBase<InventoryServiceWrapper>.Instance.method_25((byte)int_0, 0);
		}
	}

	// Token: 0x040020C4 RID: 8388
	protected ItemDNA[] _arrWeapons;

	// Token: 0x040020C5 RID: 8389
	protected int _iWeaponSlotSum = 4;

	// Token: 0x040020C6 RID: 8390
	protected int _iActivedIndex = -1;

	// Token: 0x040020C7 RID: 8391
	protected ItemDNA _shieldDNA;

	// Token: 0x040020C8 RID: 8392
	protected ItemDNA _classModeDNA;

	// Token: 0x040020C9 RID: 8393
	protected ItemDNA[] _arrOutfits = new ItemDNA[5];

	// Token: 0x040020CA RID: 8394
	protected Dictionary<int, Vector2> _ammoInfoList;

	// Token: 0x040020CB RID: 8395
	protected PlayerProperties _playerInfo;

	// Token: 0x040020CC RID: 8396
	protected UIModelController _modelController;
}
