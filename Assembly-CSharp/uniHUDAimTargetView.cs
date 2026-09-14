using System;
using System.Collections.Generic;
using Core;
using ns0;
using pumpkin.display;
using pumpkin.events;
using pumpkin.geom;
using pumpkin.text;
using UnityEngine;
using XsdSettings;

// Token: 0x02000806 RID: 2054
public class uniHUDAimTargetView : HUDAimTargetView
{
	// Token: 0x06003778 RID: 14200 RVA: 0x000FFA50 File Offset: 0x000FDC50
	public uniHUDAimTargetView()
	{
		this.WEAPON_FRAME_MAP = new Dictionary<int, string>();
		this.WEAPON_FRAME_MAP.Add(2, "shotgun_");
		this.WEAPON_FRAME_MAP.Add(0, "SMG_");
		this.WEAPON_FRAME_MAP.Add(1, "Sniper_");
		this.WEAPON_FRAME_MAP.Add(3, "Pistol_");
		this.WEAPON_FRAME_MAP.Add(4, "CombatRifel_");
		this.WEAPON_FRAME_MAP.Add(5, "Spot");
		this.WEAPON_MARGIN_MAP = new Dictionary<int, Vector2>();
		this.WEAPON_MARGIN_MAP.Add(2, new Vector2(50f, 80f));
		this.WEAPON_MARGIN_MAP.Add(1, new Vector2(0f, 0f));
		this.WEAPON_MARGIN_MAP.Add(0, new Vector2(40f, 90f));
		this.WEAPON_MARGIN_MAP.Add(3, new Vector2(0f, 0f));
		this.WEAPON_MARGIN_MAP.Add(4, new Vector2(10f, 70f));
		this.WEAPON_MARGIN_MAP.Add(5, new Vector2(0f, 0f));
	}

	// Token: 0x06003779 RID: 14201 RVA: 0x000FFB8C File Offset: 0x000FDD8C
	public override void vmethod_2()
	{
		base.vmethod_2();
		(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_45("Tips.swf", "Panel_Tips_Card", new FuncLoad(this.method_5));
		BadAssMovieClip badAssMovieClip = new BadAssMovieClip("SightBead.swf", "ScreenPanel");
		BadAssMovieClip badAssMovieClip2 = new BadAssMovieClip("SightBead.swf", "Panel_BossHud");
		this.method_6(badAssMovieClip);
		this.method_7(badAssMovieClip2);
		this.method_9();
	}

	// Token: 0x0600377A RID: 14202 RVA: 0x000FFC00 File Offset: 0x000FDE00
	private void method_5(MovieClip movieClip_0)
	{
		float num = 0f;
		float num2 = 0f;
		MovieClip movieClip = new MovieClip();
		(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_42(out num, out num2);
		movieClip.x = num;
		movieClip.y = num2;
		movieClip.visible = false;
		this._itemPanel = new uniHUDAimTargetView.ItemCard3DPanel();
		this._itemPanel.method_0(movieClip);
		this._itemPanel.vmethod_2(movieClip_0);
		(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_34(this._itemPanel);
	}

	// Token: 0x0600377B RID: 14203 RVA: 0x000FFC8C File Offset: 0x000FDE8C
	private void method_6(MovieClip movieClip_0)
	{
		float num = 0f;
		float num2;
		(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_42(out num2, out num);
		movieClip_0.x = num2;
		movieClip_0.y = num;
		this._rootPanel = new GClass51();
		this._rootPanel.method_3(movieClip_0, new GDelegate7(this.OnWidgetInitialized));
		(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_35(this._rootPanel);
	}

	// Token: 0x0600377C RID: 14204 RVA: 0x000FFD04 File Offset: 0x000FDF04
	private void method_7(MovieClip movieClip_0)
	{
		float num = 0f;
		float num2;
		(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_42(out num2, out num);
		movieClip_0.x = num2;
		movieClip_0.y = num;
		this._bossPanel = new uniHUDAimTargetView.BossHudPanel();
		this._bossPanel.method_0(movieClip_0);
		(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_35(this._bossPanel);
		this._bossPanel.Boolean_0 = false;
	}

	// Token: 0x0600377D RID: 14205 RVA: 0x000FFD7C File Offset: 0x000FDF7C
	public override void vmethod_3()
	{
		base.vmethod_3();
		(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_37(this._rootPanel);
		(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_37(this._itemPanel);
		(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_37(this._bossPanel);
		this.method_10();
		this._itemPanel = null;
		this._eTipsPanel = null;
		this._crossHairPanel = null;
		this._maskPanel = null;
		this._rootPanel = null;
		this._bossPanel = null;
		this._badassAIPanel = null;
		this._coatingPanel = null;
		MaskManager.smethod_0().method_2();
		(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_48("Tips.swf");
		(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_48("SightBead.swf");
	}

	// Token: 0x0600377E RID: 14206 RVA: 0x000FFE58 File Offset: 0x000FE058
	protected bool OnWidgetInitialized(ref MovieClip movieClip, Type widgetType)
	{
		DebugUtils.Log(LogCategory.Gamelogic, "AIM_TARGET_WIDGET: " + movieClip.name);
		bool flag = false;
		string name = movieClip.name;
		if (name != null)
		{
			switch (name.Length)
			{
			case 6:
				if (name == "mcMask")
				{
					movieClip.visible = false;
					movieClip.stop();
					this._maskPanel = new uniHUDAimTargetView.MaskPanel();
					this._maskPanel.method_0(movieClip);
					flag = true;
				}
				break;
			case 7:
				if (name == "mcETips")
				{
					this._eTipsPanel = new ETipsPanel();
					this._eTipsPanel.method_0(movieClip);
					flag = true;
				}
				break;
			case 8:
				if (name == "mcAIInfo")
				{
					movieClip.visible = false;
					movieClip.stop();
					this._aiPanel = new uniHUDAimTargetView.AIInfoPanel();
					this._aiPanel.method_0(movieClip);
					flag = true;
				}
				break;
			case 9:
			{
				char c = name[2];
				if (c != 'C')
				{
					if (c == 'E')
					{
						if (name == "mcExpDown")
						{
							movieClip.visible = false;
							movieClip.stop();
							this._expPanel = new uniHUDAimTargetView.ExpDownPanel();
							this._expPanel.method_0(movieClip);
							flag = true;
						}
					}
				}
				else if (name == "mcCoating")
				{
					movieClip.visible = false;
					movieClip.stop();
					this._coatingPanel = new uniHUDAimTargetView.CoatingPanel();
					this._coatingPanel.method_0(movieClip);
					flag = true;
				}
				break;
			}
			case 11:
			{
				char c = name[0];
				if (c != 'm')
				{
					if (c == 'p')
					{
						if (name == "panelBadass")
						{
							movieClip.visible = false;
							movieClip.stop();
							this._badassAIPanel = new uniHUDAimTargetView.BadassAIInfoPanel();
							this._badassAIPanel.method_0(movieClip);
							flag = true;
						}
					}
				}
				else if (name == "mcCrossHair")
				{
					this._crossHairPanel = new uniHUDAimTargetView.CrossHairPanel();
					this._crossHairPanel.method_0(movieClip);
					flag = true;
				}
				break;
			}
			}
		}
		return flag;
	}

	// Token: 0x0600377F RID: 14207 RVA: 0x00024CF0 File Offset: 0x00022EF0
	public override void vmethod_8(E_USE_TYPE e_USE_TYPE_0)
	{
		base.vmethod_8(e_USE_TYPE_0);
		if (this._eTipsPanel == null)
		{
			return;
		}
		if (e_USE_TYPE_0 == E_USE_TYPE.E_NONE)
		{
			this._eTipsPanel.Boolean_0 = false;
		}
		else
		{
			this._eTipsPanel.vmethod_2((int)this._curType);
			this._eTipsPanel.Boolean_0 = true;
		}
	}

	// Token: 0x06003780 RID: 14208 RVA: 0x0010009C File Offset: 0x000FE29C
	public override void vmethod_5(E_SCOPE_TYPE e_SCOPE_TYPE_0 = E_SCOPE_TYPE.E_NORMAL)
	{
		bool flag = this._eAimMode != e_SCOPE_TYPE_0;
		base.vmethod_5(e_SCOPE_TYPE_0);
		if (flag)
		{
			this.method_8();
		}
	}

	// Token: 0x06003781 RID: 14209 RVA: 0x001000C8 File Offset: 0x000FE2C8
	public override void vmethod_6(EntityWeapon.ScopeHudType scopeHudType_0)
	{
		bool flag = this._eHudType != scopeHudType_0;
		base.vmethod_6(scopeHudType_0);
		if (flag)
		{
			this.method_8();
		}
	}

	// Token: 0x06003782 RID: 14210 RVA: 0x001000F4 File Offset: 0x000FE2F4
	public override void vmethod_7(float float_0, float float_1 = 3.4028235E+38f)
	{
		this._fCrossHairAccurate = float_0;
		this._fScopeCrossHairAccurate = float_1;
		if (this._crossHairPanel != null)
		{
			Camera camera_ = MonoSingleton<AppManager>.Instance.method_0().Camera_0;
			if (camera_ != null)
			{
				this.MAGIC_VALUE = 720f / camera_.fieldOfView;
			}
			int num = Mathf.CeilToInt(this._fCrossHairAccurate * this.MAGIC_VALUE);
			this._crossHairPanel.vmethod_5(num);
			this._crossHairPanel.vmethod_4((int)(this._fScopeCrossHairAccurate * (this.WEAPON_MARGIN_MAP[(int)this._weaponType].y - this.WEAPON_MARGIN_MAP[(int)this._weaponType].x) + this.WEAPON_MARGIN_MAP[(int)this._weaponType].x), this._weaponType);
		}
	}

	// Token: 0x06003783 RID: 14211 RVA: 0x00024D30 File Offset: 0x00022F30
	public override void vmethod_15(EntityNpc entityNpc_0)
	{
		if (this._bossPanel != null)
		{
			this._bossPanel.method_6(entityNpc_0);
		}
	}

	// Token: 0x06003784 RID: 14212 RVA: 0x00024D46 File Offset: 0x00022F46
	public override void vmethod_16()
	{
		if (this._bossPanel != null && !this._bossPanel.Boolean_0)
		{
			this._bossPanel.Boolean_0 = true;
		}
	}

	// Token: 0x06003785 RID: 14213 RVA: 0x00024D69 File Offset: 0x00022F69
	public override void vmethod_17()
	{
		if (this._bossPanel != null && this._bossPanel.Boolean_0)
		{
			this._bossPanel.method_10();
			this._bossPanel.Boolean_0 = false;
		}
	}

	// Token: 0x06003786 RID: 14214 RVA: 0x00024D97 File Offset: 0x00022F97
	public override void vmethod_18(int int_0, string string_0)
	{
		if (this._bossPanel != null)
		{
			this._bossPanel.method_7(int_0, string_0);
		}
	}

	// Token: 0x06003787 RID: 14215 RVA: 0x0000311B File Offset: 0x0000131B
	public override void vmethod_19(int int_0, int int_1, int int_2, int int_3)
	{
	}

	// Token: 0x06003788 RID: 14216 RVA: 0x001001CC File Offset: 0x000FE3CC
	public override void vmethod_12(Entity entity_0, bool bool_0 = false)
	{
		bool flag = this._aimedEntity != entity_0;
		if (this._bAimed && this._aimedEntity == null)
		{
			flag = true;
		}
		base.vmethod_12(entity_0, bool_0);
		if (entity_0 != null)
		{
			EntityDestoryableObj entityDestoryableObj = entity_0 as EntityDestoryableObj;
			if (entityDestoryableObj != null && entityDestoryableObj.m_bHideUI)
			{
				return;
			}
			bool flag2 = false;
			bool flag3 = false;
			if (entity_0.vmethod_8() == Entity.EntityType.Npc)
			{
				EntityNpc entityNpc = entity_0 as EntityNpc;
				if (entityNpc != null)
				{
					flag2 = entityNpc.method_18();
					flag3 = entityNpc.m_npcFamilly == EntityNpc.EntityNpcFamilly.Tutor;
				}
			}
			if (!flag2)
			{
				uniHUDAimTargetView.AIInfoPanel aiinfoPanel;
				if (this._aimedEntity is EntityNpc)
				{
					if ((this._aimedEntity as EntityNpc).method_17())
					{
						aiinfoPanel = this._badassAIPanel;
					}
					else
					{
						aiinfoPanel = this._aiPanel;
					}
				}
				else
				{
					aiinfoPanel = this._aiPanel;
				}
				if (aiinfoPanel != null)
				{
					if (!aiinfoPanel.Boolean_0)
					{
						aiinfoPanel.Boolean_0 = true;
					}
					string text = string.Empty;
					if (this._aimedEntity is EntityPlayer)
					{
						if ((this._aimedEntity as EntityPlayer).vmethod_9() == MonoSingleton<Session>.Instance.GetLocalPlayer().m_teamID)
						{
							aiinfoPanel.method_7("GREEN");
						}
						else
						{
							aiinfoPanel.method_7("RED");
						}
					}
					else if (flag3)
					{
						aiinfoPanel.method_7("GREEN");
					}
					else if (this._aimedEntity is EntityNpcSoldierTurret)
					{
						EntityNpcSoldierTurret entityNpcSoldierTurret = this._aimedEntity as EntityNpcSoldierTurret;
						text = entityNpcSoldierTurret.method_24();
						if (GroupManager.smethod_0().method_17(entityNpcSoldierTurret.m_relatedPlayer.method_20()))
						{
							aiinfoPanel.method_7("GREEN");
						}
						else if (MonoSingleton<Session>.Instance.GetLocalPlayer().m_characterId == entityNpcSoldierTurret.m_relatedPlayer.method_20())
						{
							aiinfoPanel.method_7("GREEN");
						}
						else
						{
							aiinfoPanel.method_7("RED");
						}
					}
					else
					{
						WeakPoint weakPoint = null;
						this._aimedEntity.method_8(out weakPoint);
						if (weakPoint != null && weakPoint.m_matterType == WeakPoint.MatterType.Armor)
						{
							aiinfoPanel.method_7("YELLOW");
						}
						else
						{
							aiinfoPanel.method_7("RED");
						}
					}
					aiinfoPanel.method_8(this._aimedEntity.vmethod_40(), this._aimedEntity.vmethod_41());
					aiinfoPanel.method_9(this._aimedEntity.vmethod_44(), this._aimedEntity.vmethod_45(), true);
					aiinfoPanel.method_10(this._aimedEntity.vmethod_3(), this._aimedEntity.vmethod_4(), text);
					aiinfoPanel.vmethod_2(this._aimedEntity);
				}
			}
			else
			{
				WeakPoint component = MonoSingleton<TargetingManager>.Instance.m_aimedCollider.gameObject.GetComponent<WeakPoint>();
				if (component != null && component.method_1())
				{
					if (component.m_matterType == WeakPoint.MatterType.Armor)
					{
						this._aiPanel.method_7("YELLOW");
					}
					else
					{
						this._aiPanel.method_7("RED");
					}
					EquipmentInventoryEntityNpcBoss equipmentInventoryEntityNpcBoss = this._aimedEntity.vmethod_19() as EquipmentInventoryEntityNpcBoss;
					if (equipmentInventoryEntityNpcBoss != null && this._aiPanel != null)
					{
						if (!this._aiPanel.Boolean_0)
						{
							this._aiPanel.Boolean_0 = true;
						}
						this._aiPanel.method_8(equipmentInventoryEntityNpcBoss.vmethod_29(component), equipmentInventoryEntityNpcBoss.vmethod_30(component));
						this._aiPanel.method_9(0, 100, false);
						this._aiPanel.method_10(0, LocalizedString.smethod_0(new LocalizedString(component.m_partInfo.ToString())), string.Empty);
					}
				}
			}
		}
		else
		{
			if (this._badassAIPanel != null)
			{
				this._badassAIPanel.Boolean_0 = false;
			}
			if (this._aiPanel != null)
			{
				this._aiPanel.Boolean_0 = false;
			}
		}
		if (flag)
		{
			this.method_8();
		}
	}

	// Token: 0x06003789 RID: 14217 RVA: 0x00100578 File Offset: 0x000FE778
	public override void vmethod_9(WeaponType weaponType_0)
	{
		bool flag = this._weaponType != weaponType_0;
		base.vmethod_9(weaponType_0);
		if (flag)
		{
			this.method_8();
		}
	}

	// Token: 0x0600378A RID: 14218 RVA: 0x001005A4 File Offset: 0x000FE7A4
	private void method_8()
	{
		uniHUDAimTargetView.CROSS_HAIR_COLOR cross_HAIR_COLOR = uniHUDAimTargetView.CROSS_HAIR_COLOR.WHITE;
		if (this._aimedEntity != null && !this._isInSameTeam)
		{
			cross_HAIR_COLOR = uniHUDAimTargetView.CROSS_HAIR_COLOR.RED;
		}
		if (this._isInSameTeam)
		{
			cross_HAIR_COLOR = uniHUDAimTargetView.CROSS_HAIR_COLOR.GREEN;
		}
		if (this._crossHairPanel != null && this.WEAPON_FRAME_MAP.ContainsKey((int)this._weaponType))
		{
			DisplayObject displayObjectContainer_ = this._coatingPanel.DisplayObjectContainer_0;
			bool flag = this._eAimMode != E_SCOPE_TYPE.E_NONE;
			this._crossHairPanel.Boolean_0 = flag;
			flag = flag;
			this._maskPanel.DisplayObjectContainer_0.visible = flag;
			displayObjectContainer_.visible = flag;
			if (this._eAimMode == E_SCOPE_TYPE.E_SNIPER)
			{
				if (this._weaponType == WeaponType.ShotGun)
				{
					this._crossHairPanel._rightRotation = 0f;
				}
				else
				{
					this._crossHairPanel._rightRotation = 90f;
				}
				this._crossHairPanel.method_5(this._elementalType);
				this._crossHairPanel.vmethod_3(this._eHudType);
				this._crossHairPanel.vmethod_2(this.WEAPON_FRAME_MAP[(int)this._weaponType] + "scope_04", cross_HAIR_COLOR, true);
				this._maskPanel.DisplayObjectContainer_0.visible = true;
				this._maskPanel.method_5(this._maskType.ToString());
				this._coatingPanel.DisplayObjectContainer_0.visible = true;
				this._coatingPanel.method_5(Utility.smethod_5(this._weaponType.ToString(), "_coating"));
			}
			else if (this._eAimMode == E_SCOPE_TYPE.E_NORMAL)
			{
				this._crossHairPanel._rightRotation = 90f;
				this._crossHairPanel.vmethod_2(Utility.smethod_5(this.WEAPON_FRAME_MAP[(int)this._weaponType], "regular"), cross_HAIR_COLOR, false);
				this._maskPanel.DisplayObjectContainer_0.visible = false;
				this._coatingPanel.DisplayObjectContainer_0.visible = false;
			}
			else
			{
				this._crossHairPanel._rightRotation = 90f;
				this._crossHairPanel.vmethod_2(this.WEAPON_FRAME_MAP[5], cross_HAIR_COLOR, false);
				this._maskPanel.DisplayObjectContainer_0.visible = false;
				this._coatingPanel.DisplayObjectContainer_0.visible = false;
			}
		}
	}

	// Token: 0x0600378B RID: 14219 RVA: 0x00024DAE File Offset: 0x00022FAE
	protected override void vmethod_21()
	{
		if (this._iconPanel != null)
		{
			this._iconPanel.method_8();
			this._iconObject.SetActive(false);
		}
		if (this._itemPanel != null)
		{
			this._itemPanel.method_11();
		}
	}

	// Token: 0x0600378C RID: 14220 RVA: 0x00024DE2 File Offset: 0x00022FE2
	protected override void vmethod_22()
	{
		base.vmethod_22();
		(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).imethod_0("UI_World_Use_Over");
		this._itemPanel.vmethod_3(this._interactingItem.method_13(), this._compareItem);
	}

	// Token: 0x0600378D RID: 14221 RVA: 0x001007CC File Offset: 0x000FE9CC
	protected override void vmethod_23(Vector3 vector3_0, bool bool_0)
	{
		base.vmethod_23(vector3_0, bool_0);
		if (this._iconObject != null)
		{
			this._iconObject.transform.position = vector3_0;
			this._iconObject.SetActive(true);
			this._mcbIcon.billboardCamera = MonoSingleton<AppManager>.Instance.method_0().Camera_0;
			string text = string.Empty;
			switch (this._interactingItem.method_13().m_type)
			{
			case ItemType.Weapon:
				text = "_" + (this._interactingItem as EntityWeapon).method_99().ToString();
				break;
			case ItemType.Ammo:
				text = "_" + this._interactingItem.method_13().m_ammoType.ToString();
				break;
			}
			string text2 = Pickable.LightPillarManager.smethod_0(this._interactingItem);
			this._iconPanel.method_7(this._interactingItem.method_13().m_type.ToString(), bool_0, text2, text);
		}
	}

	// Token: 0x0600378E RID: 14222 RVA: 0x001008D8 File Offset: 0x000FEAD8
	protected override void vmethod_20(Vector2 vector2_0, float float_0)
	{
		if (this._itemPanel != null)
		{
			this._itemPanel.method_12(Mathf.CeilToInt(vector2_0.x / GClass20.GClass20_0.Single_0), Mathf.CeilToInt(vector2_0.y / GClass20.GClass20_0.Single_0));
			this._itemPanel.method_13(float_0);
		}
	}

	// Token: 0x0600378F RID: 14223 RVA: 0x00024E1F File Offset: 0x0002301F
	protected override void vmethod_24(int int_0)
	{
		if (this._expPanel != null)
		{
			this._expPanel.vmethod_2(int_0);
		}
	}

	// Token: 0x06003790 RID: 14224 RVA: 0x00100934 File Offset: 0x000FEB34
	private void method_9()
	{
		if (this._iconObject == null)
		{
			this._iconObject = global::UnityEngine.Object.Instantiate(ResourcesLoader.smethod_0("UI_uniSWF/EntityIcon")) as GameObject;
			this._iconObject.name = "iconObject";
			(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).vmethod_4(this._iconObject);
		}
		this._mcbIcon = this._iconObject.GetComponent<MovieClipBehaviour>();
		if (this._mcbIcon != null)
		{
			this._mcbIcon.billboard = true;
			this._iconPanel = new uniHUDAimTargetView.EntityIconPanel();
			this._iconPanel.method_0(this._mcbIcon.movieClip);
		}
		this._iconObject.SetActive(false);
	}

	// Token: 0x06003791 RID: 14225 RVA: 0x00024E35 File Offset: 0x00023035
	private void method_10()
	{
		if (!(this._iconObject != null))
		{
		}
	}

	// Token: 0x06003792 RID: 14226 RVA: 0x001009EC File Offset: 0x000FEBEC
	public override bool OnScreenResized()
	{
		float num = 0f;
		float num2;
		(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_42(out num2, out num);
		this._rootPanel.DisplayObjectContainer_0.x = num2;
		this._rootPanel.DisplayObjectContainer_0.y = num;
		return true;
	}

	// Token: 0x0400269A RID: 9882
	private GClass51 _rootPanel;

	// Token: 0x0400269B RID: 9883
	private ETipsPanel _eTipsPanel;

	// Token: 0x0400269C RID: 9884
	private uniHUDAimTargetView.CrossHairPanel _crossHairPanel;

	// Token: 0x0400269D RID: 9885
	private uniHUDAimTargetView.MaskPanel _maskPanel;

	// Token: 0x0400269E RID: 9886
	private uniHUDAimTargetView.CoatingPanel _coatingPanel;

	// Token: 0x0400269F RID: 9887
	private uniHUDAimTargetView.AIInfoPanel _aiPanel;

	// Token: 0x040026A0 RID: 9888
	private uniHUDAimTargetView.EntityIconPanel _iconPanel;

	// Token: 0x040026A1 RID: 9889
	private uniHUDAimTargetView.ItemCard3DPanel _itemPanel;

	// Token: 0x040026A2 RID: 9890
	private uniHUDAimTargetView.ExpDownPanel _expPanel;

	// Token: 0x040026A3 RID: 9891
	private uniHUDAimTargetView.BossHudPanel _bossPanel;

	// Token: 0x040026A4 RID: 9892
	private uniHUDAimTargetView.BadassAIInfoPanel _badassAIPanel;

	// Token: 0x040026A5 RID: 9893
	private float MAGIC_VALUE = 16.744186f;

	// Token: 0x040026A6 RID: 9894
	private Dictionary<int, string> WEAPON_FRAME_MAP;

	// Token: 0x040026A7 RID: 9895
	private Dictionary<int, Vector2> WEAPON_MARGIN_MAP;

	// Token: 0x040026A8 RID: 9896
	private MovieClipBehaviour _mcbIcon;

	// Token: 0x02000807 RID: 2055
	public enum CROSS_HAIR_COLOR
	{
		// Token: 0x040026AB RID: 9899
		WHITE,
		// Token: 0x040026AC RID: 9900
		RED,
		// Token: 0x040026AD RID: 9901
		YELLOW,
		// Token: 0x040026AE RID: 9902
		GREEN
	}

	// Token: 0x02000808 RID: 2056
	private class BossHudPanel : GClass51
	{
		// Token: 0x170002F5 RID: 757
		// (get) Token: 0x06003795 RID: 14229 RVA: 0x00024E71 File Offset: 0x00023071
		// (set) Token: 0x06003794 RID: 14228 RVA: 0x00024E5B File Offset: 0x0002305B
		public virtual bool Boolean_0
		{
			get
			{
				return this.mcSelf != null && this.mcSelf.visible;
			}
			set
			{
				if (this.mcSelf != null)
				{
					this.mcSelf.visible = value;
				}
			}
		}

		// Token: 0x06003796 RID: 14230 RVA: 0x00100A3C File Offset: 0x000FEC3C
		protected override void vmethod_0()
		{
			base.vmethod_0();
			this.mcSelf = this.displayObjectContainer_0 as MovieClip;
			if (this.mcSelf == null)
			{
				DebugUtils.LogWarning(LogCategory.GUI, "UIWarning: BossHudPanel onInit() 'mcSelf' is null! BossHudPanel won't work!!!");
				return;
			}
			this.mcSelf.stop();
			this.tfBossName = this.mcSelf.getChildByName<TextField>("nameLabel");
			this.tfBossLevel = this.mcSelf.getChildByName<TextField>("level");
			this.mcCursor = this.mcSelf.getChildByName<MovieClip>("mc_cusor");
			this.mcCursor.stop();
			this.mcBlueBar = this.mcSelf.getChildByName<MovieClip>("mc_bluebar");
			this.mcBlueBar.stop();
			this.mcYellowBar = this.mcSelf.getChildByName<MovieClip>("mc_yellowbar");
			this.mcYellowBar.stop();
			this.mcRedBar = this.mcSelf.getChildByName<MovieClip>("mc_redbar");
			this.mcRedBar.stop();
			this.mcProgressBars = new MovieClip[] { this.mcCursor, this.mcBlueBar, this.mcYellowBar, this.mcRedBar };
			this.mcCurrentBar = this.mcBlueBar;
			this.method_5();
		}

		// Token: 0x06003797 RID: 14231 RVA: 0x00100B74 File Offset: 0x000FED74
		private void method_5()
		{
			for (int i = 0; i < this.mcProgressBars.Length; i++)
			{
				Rectangle bounds = this.mcProgressBars[i].getBounds(this.mcProgressBars[i].getChildByName<MovieClip>("mcProgressMask"));
				this.mcProgressBars[i].clipRect = bounds.rect;
			}
		}

		// Token: 0x06003798 RID: 14232 RVA: 0x00100BC8 File Offset: 0x000FEDC8
		public void method_6(EntityNpc entityNpc_0)
		{
			if (!string.IsNullOrEmpty(MonoSingleton<AppManager>.Instance.m_autoTestCase))
			{
				return;
			}
			if (this.m_BossEntity != null)
			{
				return;
			}
			if (entityNpc_0 != null)
			{
				this.m_BossEntity = entityNpc_0;
				this.mcSelf.addEventListener(CEvent.ENTER_FRAME, new EventDispatcher.EventCallback(this.Update));
			}
		}

		// Token: 0x06003799 RID: 14233 RVA: 0x00100C24 File Offset: 0x000FEE24
		public void method_7(int int_0, string string_1)
		{
			if (this.tfBossName != null)
			{
				this.tfBossName.text = string_1;
			}
			if (this.tfBossLevel != null)
			{
				if (int_0 != 0)
				{
					this.tfBossLevel.text = Utility.smethod_5("LV:", Utility.smethod_8(int_0));
				}
				else
				{
					this.tfBossLevel.text = string.Empty;
				}
			}
		}

		// Token: 0x0600379A RID: 14234 RVA: 0x00100C80 File Offset: 0x000FEE80
		public void method_8(int int_0, int int_1, int int_2, int int_3, int int_4)
		{
			if (this.mcCurrentBar == null)
			{
				return;
			}
			if (int_0 == 0)
			{
				if (this.m_nPhase == 3 && this.mcCurrentBar == this.mcRedBar && !this.m_bBossKilled)
				{
					this.m_bBossKilled = true;
					this.mcCurrentBar.gotoAndStop(100);
					this.mcCursor.gotoAndStop(100);
					this.m_bEnableHP = false;
					this.mcCursor.visible = false;
					this.mcCurrentBar.gotoAndPlay(101);
					this.mcCurrentBar.hasClipRect = false;
					this.mcSelf.addEventListener(CEvent.ENTER_FRAME, new EventDispatcher.EventCallback(this.method_9));
				}
				return;
			}
			if (this.m_nPhase != int_2)
			{
				this.m_bPhaseChanged = true;
				this.m_nPhase = int_2;
			}
			else
			{
				this.m_bPhaseChanged = false;
			}
			int_0 = Mathf.FloorToInt((float)(int_0 - int_1 * int_3 / 100));
			int_1 = Mathf.FloorToInt((float)(int_1 * Math.Abs(int_4 - int_3) / 100));
			if (this.m_bPhaseChanged)
			{
				if (this.m_bEnableHP)
				{
					this.mcCurrentBar.gotoAndStop(100);
					this.mcCursor.gotoAndStop(100);
					this.m_bEnableHP = false;
					this.mcCursor.visible = false;
					this.mcCurrentBar.gotoAndPlay(101);
					this.mcCurrentBar.hasClipRect = false;
					this.mcSelf.addEventListener(CEvent.ENTER_FRAME, new EventDispatcher.EventCallback(this.method_9));
				}
			}
			else if (this.m_bEnableHP)
			{
				int num = (int)Math.Ceiling(100.0 * (double)int_0 / (double)int_1);
				this.mcCurrentBar.hasClipRect = true;
				this.mcCurrentBar.gotoAndStop(101 - num);
				if (!this.mcCursor.visible)
				{
					this.mcCursor.visible = true;
				}
				this.mcCursor.gotoAndStop(101 - num);
			}
		}

		// Token: 0x0600379B RID: 14235 RVA: 0x00100E7C File Offset: 0x000FF07C
		private void method_9(CEvent cevent_0)
		{
			if (this.mcCurrentBar.isPlaying)
			{
				return;
			}
			if (this.m_nPhase == 1)
			{
				this.mcBlueBar.visible = true;
				this.mcBlueBar.gotoAndStop(1);
				this.mcYellowBar.gotoAndStop(1);
				this.mcYellowBar.visible = true;
				this.mcCurrentBar = this.mcBlueBar;
			}
			else if (this.m_nPhase == 2)
			{
				this.mcBlueBar.visible = false;
				this.mcYellowBar.gotoAndStop(1);
				this.mcRedBar.gotoAndStop(1);
				this.mcRedBar.visible = true;
				this.mcYellowBar.visible = true;
				this.mcCurrentBar = this.mcYellowBar;
			}
			else if (this.m_nPhase == 3 && this.mcCurrentBar != this.mcRedBar)
			{
				this.mcBlueBar.visible = false;
				this.mcYellowBar.visible = false;
				this.mcRedBar.gotoAndStop(1);
				this.mcRedBar.visible = true;
				this.mcCurrentBar = this.mcRedBar;
			}
			else if (this.m_nPhase == 3 && this.mcCurrentBar == this.mcRedBar)
			{
				this.Boolean_0 = false;
				this.method_11();
			}
			this.m_bEnableHP = true;
			this.mcSelf.removeEventListener(CEvent.ENTER_FRAME, new EventDispatcher.EventCallback(this.method_9));
		}

		// Token: 0x0600379C RID: 14236 RVA: 0x00100FEC File Offset: 0x000FF1EC
		private void Update(CEvent evt)
		{
			if (this.m_BossEntity != null)
			{
				EquipmentInventoryEntityNpcBoss equipmentInventoryEntityNpcBoss = this.m_BossEntity.vmethod_19() as EquipmentInventoryEntityNpcBoss;
				if (equipmentInventoryEntityNpcBoss != null)
				{
					if (!this.m_bBossInfoSet)
					{
						if (equipmentInventoryEntityNpcBoss.vmethod_23() != 0)
						{
							if (!this.Boolean_0)
							{
								this.Boolean_0 = true;
							}
							this.method_7((int)equipmentInventoryEntityNpcBoss.vmethod_23(), this.m_BossEntity.vmethod_4());
							this.m_bBossInfoSet = true;
						}
						else
						{
							this.method_7((int)equipmentInventoryEntityNpcBoss.vmethod_23(), this.m_BossEntity.vmethod_4());
						}
					}
					this.method_8(equipmentInventoryEntityNpcBoss.vmethod_4(), equipmentInventoryEntityNpcBoss.vmethod_0(), (int)equipmentInventoryEntityNpcBoss.method_7(), (int)equipmentInventoryEntityNpcBoss.method_8(), (int)equipmentInventoryEntityNpcBoss.method_9());
				}
			}
			else
			{
				if (this.Boolean_0)
				{
					this.Boolean_0 = false;
				}
				this.mcSelf.removeEventListener(CEvent.ENTER_FRAME, new EventDispatcher.EventCallback(this.Update));
			}
		}

		// Token: 0x0600379D RID: 14237 RVA: 0x00024E88 File Offset: 0x00023088
		public void method_10()
		{
			this.mcSelf.removeEventListener(CEvent.ENTER_FRAME, new EventDispatcher.EventCallback(this.Update));
		}

		// Token: 0x0600379E RID: 14238 RVA: 0x001010D0 File Offset: 0x000FF2D0
		public void method_11()
		{
			this.mcBlueBar.visible = true;
			this.mcRedBar.visible = true;
			this.mcYellowBar.visible = true;
			this.mcCursor.visible = true;
			this.m_bBossInfoSet = false;
			this.m_bBossKilled = false;
			this.m_bEnableHP = true;
			this.m_bPhaseChanged = false;
			this.m_nPhase = 1;
			this.mcCurrentBar = this.mcBlueBar;
			this.m_BossEntity = null;
			this.mcCursor.gotoAndStop(1);
			this.mcBlueBar.gotoAndStop(1);
			this.mcYellowBar.gotoAndStop(1);
			this.mcRedBar.gotoAndStop(1);
		}

		// Token: 0x040026AF RID: 9903
		protected MovieClip mcSelf;

		// Token: 0x040026B0 RID: 9904
		protected TextField tfBossName;

		// Token: 0x040026B1 RID: 9905
		protected TextField tfBossLevel;

		// Token: 0x040026B2 RID: 9906
		protected MovieClip mcCursor;

		// Token: 0x040026B3 RID: 9907
		protected MovieClip mcBlueBar;

		// Token: 0x040026B4 RID: 9908
		protected MovieClip mcYellowBar;

		// Token: 0x040026B5 RID: 9909
		protected MovieClip mcRedBar;

		// Token: 0x040026B6 RID: 9910
		protected MovieClip[] mcProgressBars;

		// Token: 0x040026B7 RID: 9911
		protected MovieClip mcCurrentBar;

		// Token: 0x040026B8 RID: 9912
		private bool m_bBossInfoSet;

		// Token: 0x040026B9 RID: 9913
		private bool m_bBossKilled;

		// Token: 0x040026BA RID: 9914
		private bool m_bEnableHP = true;

		// Token: 0x040026BB RID: 9915
		private bool m_bPhaseChanged;

		// Token: 0x040026BC RID: 9916
		private int m_nPhase = 1;

		// Token: 0x040026BD RID: 9917
		private EntityNpc m_BossEntity;

		// Token: 0x040026BE RID: 9918
		protected bool _bVisible;
	}

	// Token: 0x02000809 RID: 2057
	private class CoatingPanel : GClass51
	{
		// Token: 0x170002F6 RID: 758
		// (get) Token: 0x060037A1 RID: 14241 RVA: 0x00024EBA File Offset: 0x000230BA
		// (set) Token: 0x060037A0 RID: 14240 RVA: 0x00024EA7 File Offset: 0x000230A7
		public virtual bool Boolean_0
		{
			get
			{
				return this._bVisible;
			}
			set
			{
				if (this._bVisible == value)
				{
					return;
				}
				this._bVisible = value;
			}
		}

		// Token: 0x060037A2 RID: 14242 RVA: 0x00101188 File Offset: 0x000FF388
		protected override void vmethod_0()
		{
			base.vmethod_0();
			this.mcSelf = this.displayObjectContainer_0.getChildByName<MovieClip>("mcRoot");
			if (this.mcSelf == null)
			{
				this.mcSelf = this.displayObjectContainer_0 as MovieClip;
			}
			if (this.mcSelf == null)
			{
				DebugUtils.LogWarning(LogCategory.GUI, "UIWarning: CoatingPanel onConfiUI() 'mcSelf' is null! CoatingPanel won't work!!!");
				return;
			}
			this.mcSelf.stop();
		}

		// Token: 0x060037A3 RID: 14243 RVA: 0x00024EC2 File Offset: 0x000230C2
		public void method_5(string string_1)
		{
			this.mcSelf.gotoAndStop(string_1);
		}

		// Token: 0x040026BF RID: 9919
		protected MovieClip mcSelf;

		// Token: 0x040026C0 RID: 9920
		protected bool _bVisible;
	}

	// Token: 0x0200080A RID: 2058
	private class MaskPanel : GClass51
	{
		// Token: 0x170002F7 RID: 759
		// (get) Token: 0x060037A6 RID: 14246 RVA: 0x00024EE3 File Offset: 0x000230E3
		// (set) Token: 0x060037A5 RID: 14245 RVA: 0x00024ED0 File Offset: 0x000230D0
		public virtual bool Boolean_0
		{
			get
			{
				return this._bVisible;
			}
			set
			{
				if (this._bVisible == value)
				{
					return;
				}
				this._bVisible = value;
			}
		}

		// Token: 0x060037A7 RID: 14247 RVA: 0x001011EC File Offset: 0x000FF3EC
		protected override void vmethod_0()
		{
			base.vmethod_0();
			this.mcSelf = this.displayObjectContainer_0.getChildByName<MovieClip>("mcRoot");
			if (this.mcSelf == null)
			{
				this.mcSelf = this.displayObjectContainer_0 as MovieClip;
			}
			if (this.mcSelf == null)
			{
				DebugUtils.LogWarning(LogCategory.GUI, "UIWarning: MaskPanel onConfiUI() 'mcSelf' is null! MaskPanel won't work!!!");
				return;
			}
			this.mcSelf.stop();
		}

		// Token: 0x060037A8 RID: 14248 RVA: 0x00024EEB File Offset: 0x000230EB
		public void method_5(string string_1)
		{
			this.mcSelf.gotoAndStop(string_1);
		}

		// Token: 0x040026C1 RID: 9921
		protected MovieClip mcSelf;

		// Token: 0x040026C2 RID: 9922
		protected bool _bVisible;
	}

	// Token: 0x0200080B RID: 2059
	private class AIInfoPanel : GClass51
	{
		// Token: 0x170002F8 RID: 760
		// (get) Token: 0x060037AB RID: 14251 RVA: 0x00024F12 File Offset: 0x00023112
		// (set) Token: 0x060037AA RID: 14250 RVA: 0x00024EF9 File Offset: 0x000230F9
		public virtual bool Boolean_0
		{
			get
			{
				return this._bVisible;
			}
			set
			{
				if (this._bVisible == value)
				{
					return;
				}
				this._bVisible = value;
				this.method_5();
			}
		}

		// Token: 0x060037AC RID: 14252 RVA: 0x00101250 File Offset: 0x000FF450
		private void method_5()
		{
			if (this.displayObjectContainer_0 != null && this.mcSelf != null)
			{
				if (this._bVisible)
				{
					this.mcSelf.removeAllEventListeners(CEvent.ENTER_FRAME);
					this.displayObjectContainer_0.visible = true;
				}
				else
				{
					this.mcSelf.addEventListener(CEvent.ENTER_FRAME, new EventDispatcher.EventCallback(this.method_6));
				}
				return;
			}
		}

		// Token: 0x060037AD RID: 14253 RVA: 0x00024F1A File Offset: 0x0002311A
		private void method_6(CEvent cevent_0)
		{
			if (!this.mcShieldBar.isPlaying && !this.mcHealthBar.isPlaying)
			{
				this.mcSelf.removeAllEventListeners(CEvent.ENTER_FRAME);
				this.displayObjectContainer_0.visible = false;
				return;
			}
		}

		// Token: 0x060037AE RID: 14254 RVA: 0x0000311B File Offset: 0x0000131B
		public virtual void vmethod_2(Entity entity_0)
		{
		}

		// Token: 0x060037AF RID: 14255 RVA: 0x001012B4 File Offset: 0x000FF4B4
		protected override void vmethod_0()
		{
			base.vmethod_0();
			this.mcSelf = this.displayObjectContainer_0.getChildByName<MovieClip>("mcRoot");
			if (this.mcSelf == null)
			{
				this.mcSelf = this.displayObjectContainer_0 as MovieClip;
			}
			if (this.mcSelf == null)
			{
				DebugUtils.LogWarning(LogCategory.GUI, "UIWarning: AIInfoPanel onConfiUI() 'mcSelf' is null! AIInfoPanel won't work!!!");
				return;
			}
			this.mcSelf.stop();
			this.mcShieldBar = this.mcSelf.getChildByName<MovieClip>("mcShield");
			this.mcShieldBar.stop();
			this.mcHealthBar = this.mcSelf.getChildByName<MovieClip>("mcHealth");
			this.mcHealthBar.stop();
			this.mcHealthColorBar = this.mcHealthBar.getChildByName<MovieClip>("mc_hpbar");
			this.mcHealthColorBar.stop();
			this.tfName = this.mcSelf.getChildByName<TextField>("nameLabel");
			this.tfLevel = this.mcSelf.getChildByName<TextField>("level");
			this.tfPlayer = this.mcSelf.getChildByName<TextField>("playername");
			this._bMaskSetted = false;
		}

		// Token: 0x060037B0 RID: 14256 RVA: 0x001013C4 File Offset: 0x000FF5C4
		public void method_7(string string_1)
		{
			if (!this._bMaskSetted)
			{
				Rectangle bounds = this.mcHealthBar.getBounds(this.mcHealthColorBar);
				this.mcHealthBar.clipRect = bounds.rect;
				this.mcShieldBar.clipRect = bounds.rect;
				this._bMaskSetted = true;
			}
			this.mcHealthColorBar.gotoAndStop(string_1);
		}

		// Token: 0x060037B1 RID: 14257 RVA: 0x00101420 File Offset: 0x000FF620
		public void method_8(int int_0, int int_1)
		{
			if (this.mcHealthBar == null)
			{
				return;
			}
			if (int_0 == 0)
			{
				if (this.mcHealthBar.getCurrentFrame() <= 100)
				{
					this.mcHealthBar.hasClipRect = false;
					this.mcHealthBar.gotoAndPlay(101);
				}
			}
			else
			{
				int num = (int)Math.Ceiling(100.0 * (double)int_0 / (double)int_1);
				this.mcHealthBar.hasClipRect = true;
				this.mcHealthBar.gotoAndStop(101 - num);
			}
		}

		// Token: 0x060037B2 RID: 14258 RVA: 0x001014A0 File Offset: 0x000FF6A0
		public void method_9(int int_0, int int_1, bool bool_0 = true)
		{
			if (this.mcShieldBar == null)
			{
				return;
			}
			if (!bool_0)
			{
				this.mcShieldBar.visible = false;
				return;
			}
			this.mcShieldBar.visible = true;
			if (int_0 == 0)
			{
				if (int_1 == 0)
				{
					this.mcShieldBar.hasClipRect = false;
					this.mcShieldBar.gotoAndStop(this.mcShieldBar.totalFrames);
				}
				else if (this.mcShieldBar.getCurrentFrame() <= 100)
				{
					this.mcShieldBar.hasClipRect = false;
					this.mcShieldBar.gotoAndPlay(110);
				}
			}
			else
			{
				int num = (int)Math.Ceiling(100.0 * (double)int_0 / (double)int_1);
				this.mcShieldBar.hasClipRect = true;
				this.mcShieldBar.gotoAndStop(101 - num);
			}
		}

		// Token: 0x060037B3 RID: 14259 RVA: 0x00101568 File Offset: 0x000FF768
		public void method_10(int int_0, string string_1, string string_2 = "")
		{
			if (this.tfName != null)
			{
				this.tfName.text = string_1;
			}
			if (this.tfLevel != null)
			{
				int num = int_0;
				if (MonoSingleton<Session>.Instance.method_12())
				{
					(this.tfLevel as UnityTextField).Color_0 = Color.green;
					num = MonoSingleton<LevelingManager>.Instance.method_2();
				}
				if (int_0 == 0)
				{
					this.tfLevel.text = string.Empty;
				}
				else
				{
					this.tfLevel.text = Utility.smethod_5("Lv", Utility.smethod_8(num));
				}
			}
			if (this.tfPlayer != null)
			{
				this.tfPlayer.text = string_2;
			}
		}

		// Token: 0x040026C3 RID: 9923
		protected MovieClip mcSelf;

		// Token: 0x040026C4 RID: 9924
		protected MovieClip mcShieldBar;

		// Token: 0x040026C5 RID: 9925
		protected MovieClip mcHealthBar;

		// Token: 0x040026C6 RID: 9926
		protected MovieClip mcHealthColorBar;

		// Token: 0x040026C7 RID: 9927
		protected TextField tfName;

		// Token: 0x040026C8 RID: 9928
		protected TextField tfLevel;

		// Token: 0x040026C9 RID: 9929
		protected TextField tfPlayer;

		// Token: 0x040026CA RID: 9930
		protected bool _bVisible;

		// Token: 0x040026CB RID: 9931
		protected bool _bMaskSetted;
	}

	// Token: 0x0200080C RID: 2060
	private class BadassAIInfoPanel : uniHUDAimTargetView.AIInfoPanel
	{
		// Token: 0x060037B5 RID: 14261 RVA: 0x00024F5C File Offset: 0x0002315C
		protected override void vmethod_0()
		{
			base.vmethod_0();
			this.tfSkill = this.mcSelf.getChildByName<TextField>("skillLabel");
		}

		// Token: 0x060037B6 RID: 14262 RVA: 0x00101604 File Offset: 0x000FF804
		public override void vmethod_2(Entity entity_0)
		{
			string text = string.Empty;
			List<PassiveSkillType> list = entity_0.vmethod_6();
			for (int i = 0; i < list.Count; i++)
			{
				text = Utility.smethod_6(text, LocalizedString.smethod_0(new LocalizedString(list[i].ToString())), " ");
			}
			UnityTextField unityTextField = (UnityTextField)this.tfSkill;
			unityTextField.Color_0 = Color.yellow;
			this.tfSkill.text = text;
		}

		// Token: 0x040026CC RID: 9932
		protected TextField tfSkill;
	}

	// Token: 0x0200080D RID: 2061
	public class CrossHairPanel : GClass51
	{
		// Token: 0x060037B7 RID: 14263 RVA: 0x0010167C File Offset: 0x000FF87C
		public CrossHairPanel()
		{
			this._ColorFrameMap = new Dictionary<uniHUDAimTargetView.CROSS_HAIR_COLOR, string>();
			this._ColorFrameMap.Add(uniHUDAimTargetView.CROSS_HAIR_COLOR.WHITE, "white");
			this._ColorFrameMap.Add(uniHUDAimTargetView.CROSS_HAIR_COLOR.RED, "red");
			this._ColorFrameMap.Add(uniHUDAimTargetView.CROSS_HAIR_COLOR.GREEN, "green");
			this._ColorFrameMap.Add(uniHUDAimTargetView.CROSS_HAIR_COLOR.YELLOW, "yellow");
		}

		// Token: 0x170002F9 RID: 761
		// (get) Token: 0x060037B9 RID: 14265 RVA: 0x00024F90 File Offset: 0x00023190
		// (set) Token: 0x060037B8 RID: 14264 RVA: 0x00024F7A File Offset: 0x0002317A
		public virtual bool Boolean_0
		{
			get
			{
				return this.mcSelf != null && this.mcSelf.visible;
			}
			set
			{
				if (this.mcSelf != null)
				{
					this.mcSelf.visible = value;
				}
			}
		}

		// Token: 0x060037BA RID: 14266 RVA: 0x001016F0 File Offset: 0x000FF8F0
		public virtual void vmethod_2(string string_1, uniHUDAimTargetView.CROSS_HAIR_COLOR cross_HAIR_COLOR_0, bool bool_0 = false)
		{
			this._bScopeMode = bool_0;
			this._color = cross_HAIR_COLOR_0;
			if (this.mcSelf != null)
			{
				this.mcSelf.gotoAndStop(string_1);
				this.mcSelf.addEventListener(CEvent.ENTER_FRAME, new EventDispatcher.EventCallback(this.method_6));
			}
		}

		// Token: 0x060037BB RID: 14267 RVA: 0x00024FA7 File Offset: 0x000231A7
		public virtual void vmethod_3(EntityWeapon.ScopeHudType scopeHudType_0)
		{
			this.hudType = scopeHudType_0;
		}

		// Token: 0x060037BC RID: 14268 RVA: 0x00024FB0 File Offset: 0x000231B0
		public void method_5(AttackInfo.ElementalType elementalType_0)
		{
			this.elementType = elementalType_0;
		}

		// Token: 0x060037BD RID: 14269 RVA: 0x0010173C File Offset: 0x000FF93C
		public virtual void vmethod_4(int int_0, WeaponType weaponType_0 = WeaponType.TOTAL)
		{
			if (this.mcCrossHair != null && this.mcSelf != null)
			{
				float num = ((weaponType_0 != WeaponType.ShotGun) ? 0f : 180f);
				float num2 = 0f;
				for (int i = 0; i < 3; i++)
				{
					MovieClip childByName = this.mcCrossHair.getChildByName<MovieClip>(Utility.smethod_5("t", Utility.smethod_8(i)));
					if (childByName != null)
					{
						float num3 = 120f;
						childByName.x = Mathf.Sin(num / 180f * 3.1415927f) * (float)int_0;
						childByName.y = -Mathf.Cos(num / 180f * 3.1415927f) * (float)int_0;
						childByName.rotation = num2;
						num += num3;
						num2 += num3 + (float)(180 * (i + 1));
					}
				}
				for (int j = 0; j < 4; j++)
				{
					MovieClip childByName2 = this.mcCrossHair.getChildByName<MovieClip>(Utility.smethod_5("f", Utility.smethod_8(j)));
					if (childByName2 != null)
					{
						float num3 = 90f;
						Matrix matrix = childByName2.getMatrix().clone();
						matrix.setRotation(0f);
						matrix.tx = Mathf.Sin(num / 180f * 3.1415927f) * (float)int_0;
						matrix.ty = -Mathf.Cos(num / 180f * 3.1415927f) * (float)int_0;
						childByName2.setMatrix(matrix);
						childByName2.rotation = ((num < 180f) ? num : (num - 360f));
						num += num3;
					}
				}
				return;
			}
		}

		// Token: 0x060037BE RID: 14270 RVA: 0x001018C0 File Offset: 0x000FFAC0
		public virtual void vmethod_5(int int_0)
		{
			if (this.mcCrossHair != null && this.mcSelf != null)
			{
				MovieClip movieClip = this.mcCrossHair.getChildByName<MovieClip>("down");
				if (movieClip != null)
				{
					Matrix matrix = movieClip.getMatrix().clone();
					matrix.setRotation(0f);
					matrix.tx = 0f;
					matrix.ty = (float)int_0;
					movieClip.setMatrix(matrix);
					movieClip.invalidateMatrix(true);
					movieClip.rotation = -180f;
				}
				movieClip = this.mcCrossHair.getChildByName<MovieClip>("up");
				if (movieClip != null)
				{
					Matrix matrix = movieClip.getMatrix().clone();
					matrix.setRotation(0f);
					matrix.tx = 0f;
					matrix.ty = (float)(-(float)int_0);
					movieClip.setMatrix(matrix);
					movieClip.invalidateMatrix(true);
				}
				movieClip = this.mcCrossHair.getChildByName<MovieClip>("left");
				if (movieClip != null)
				{
					Matrix matrix = movieClip.getMatrix().clone();
					matrix.setRotation(0f);
					matrix.tx = (float)(-(float)int_0);
					matrix.ty = 0f;
					movieClip.setMatrix(matrix);
					movieClip.invalidateMatrix(true);
					movieClip.rotation = -this._rightRotation;
				}
				movieClip = this.mcCrossHair.getChildByName<MovieClip>("right");
				if (movieClip != null)
				{
					Matrix matrix = movieClip.getMatrix().clone();
					matrix.setRotation(0f);
					matrix.tx = (float)int_0;
					matrix.ty = 0f;
					movieClip.setMatrix(matrix);
					movieClip.invalidateMatrix(true);
					movieClip.rotation = this._rightRotation;
				}
				return;
			}
		}

		// Token: 0x060037BF RID: 14271 RVA: 0x00101A3C File Offset: 0x000FFC3C
		protected override void vmethod_0()
		{
			base.vmethod_0();
			this.mcSelf = this.displayObjectContainer_0 as MovieClip;
			if (this.mcSelf == null)
			{
				DebugUtils.LogWarning(LogCategory.GUI, "UIWarning: CrossHairPanel Cross Hair MovieClip missing!!");
				return;
			}
			this.mcSelf.gotoAndStop("Spot");
			this.mcCrossHair = this.mcSelf.getChildByName("crossHair") as MovieClip;
		}

		// Token: 0x060037C0 RID: 14272 RVA: 0x00101AA0 File Offset: 0x000FFCA0
		private void method_6(CEvent cevent_0)
		{
			this.mcSelf.removeEventListener(CEvent.ENTER_FRAME, new EventDispatcher.EventCallback(this.method_6));
			this.mcCrossHair = this.mcSelf.getChildByName<MovieClip>("crossHair");
			if (this.mcCrossHair != null)
			{
				this.mcCrossHair.gotoAndStop(this._ColorFrameMap[this._color]);
			}
			MovieClip childByName = this.mcSelf.getChildByName<MovieClip>("mc_elements");
			if (childByName != null)
			{
				if (this.elementType != AttackInfo.ElementalType.None && this.elementType != AttackInfo.ElementalType.Max)
				{
					if (this.elementType != AttackInfo.ElementalType.Explosive)
					{
						childByName.visible = true;
						childByName.gotoAndStop(this.elementType.ToString());
						goto IL_00AD;
					}
				}
				childByName.visible = false;
			}
			IL_00AD:
			if (this.mcCrossHair != null)
			{
				MovieClip childByName2 = this.mcCrossHair.getChildByName<MovieClip>("level");
				if (childByName2 != null)
				{
					int num = (int)this.hudType;
					childByName2.visible = num > 0;
					num = Math.Min(num + 1, childByName2.totalFrames);
					if (childByName2.visible)
					{
						childByName2.gotoAndStop(num);
						childByName2.colorTransform = UniUIManager.UniSWFToolClass.smethod_7(this.elementType);
					}
				}
			}
		}

		// Token: 0x040026CD RID: 9933
		protected MovieClip mcSelf;

		// Token: 0x040026CE RID: 9934
		protected MovieClip mcCrossHair;

		// Token: 0x040026CF RID: 9935
		protected Dictionary<uniHUDAimTargetView.CROSS_HAIR_COLOR, string> _ColorFrameMap;

		// Token: 0x040026D0 RID: 9936
		protected uniHUDAimTargetView.CROSS_HAIR_COLOR _color;

		// Token: 0x040026D1 RID: 9937
		public float _rightRotation = 90f;

		// Token: 0x040026D2 RID: 9938
		private AttackInfo.ElementalType elementType = AttackInfo.ElementalType.Max;

		// Token: 0x040026D3 RID: 9939
		private EntityWeapon.ScopeHudType hudType;

		// Token: 0x040026D4 RID: 9940
		public bool _bScopeMode;
	}

	// Token: 0x0200080E RID: 2062
	private class EntityIconPanel : GClass51
	{
		// Token: 0x060037C2 RID: 14274 RVA: 0x00101BBC File Offset: 0x000FFDBC
		protected override void vmethod_0()
		{
			base.vmethod_0();
			this.mcSelf = this.displayObjectContainer_0 as MovieClip;
			if (this.mcSelf == null)
			{
				DebugUtils.LogWarning(LogCategory.GUI, "UIWarning: EntityIconPanel MovieClip missing!!");
				return;
			}
			this.mcSelf.stop();
			this.mcRoot = this.mcSelf.getChildByName<MovieClip>("mcRoot");
			if (this.mcRoot != null)
			{
				this.mcForbid = this.mcRoot.getChildByName("mcForbid") as MovieClip;
			}
		}

		// Token: 0x060037C3 RID: 14275 RVA: 0x00101C38 File Offset: 0x000FFE38
		private void method_5(CEvent cevent_0)
		{
			this.mcRoot = this.mcSelf.getChildByName<MovieClip>("mcRoot");
			if (this.mcRoot != null)
			{
				this.mcForbid = this.mcRoot.getChildByName("mcForbid") as MovieClip;
				if (this.mcForbid != null)
				{
					this.mcForbid.visible = this._bForbid;
				}
				this.mcRoot.addEventListener(CEvent.ENTER_FRAME, new EventDispatcher.EventCallback(this.method_6));
				this.mcRoot.gotoAndStop(this._frame);
			}
		}

		// Token: 0x060037C4 RID: 14276 RVA: 0x00101CC8 File Offset: 0x000FFEC8
		private void method_6(CEvent cevent_0)
		{
			this.mcRoot.removeEventListener(CEvent.ENTER_FRAME, new EventDispatcher.EventCallback(this.method_6));
			this.mcIcon = this.mcRoot.getChildByName("mcIcon") as MovieClip;
			if (this.mcIcon != null)
			{
				this.mcIcon.gotoAndStop(this._strColor);
			}
		}

		// Token: 0x060037C5 RID: 14277 RVA: 0x00101D28 File Offset: 0x000FFF28
		public void method_7(string string_1, bool bool_0, string string_2, string string_3 = "")
		{
			this._frame = string_1 + string_3;
			this._bForbid = bool_0;
			this._strColor = string_2;
			this.mcRoot.gotoAndStop(this._frame);
			this.mcSelf.addEventListener(CEvent.ENTER_FRAME, new EventDispatcher.EventCallback(this.method_5));
			this.mcSelf.gotoAndPlay("IN");
		}

		// Token: 0x060037C6 RID: 14278 RVA: 0x00024FD7 File Offset: 0x000231D7
		public void method_8()
		{
			this._frame = string.Empty;
			this.mcSelf.gotoAndStop("IN");
			this.mcSelf.removeAllEventListeners(CEvent.ENTER_FRAME);
		}

		// Token: 0x040026D5 RID: 9941
		protected MovieClip mcSelf;

		// Token: 0x040026D6 RID: 9942
		protected MovieClip mcRoot;

		// Token: 0x040026D7 RID: 9943
		protected DisplayObject mcForbid;

		// Token: 0x040026D8 RID: 9944
		protected MovieClip mcIcon;

		// Token: 0x040026D9 RID: 9945
		protected string _frame = string.Empty;

		// Token: 0x040026DA RID: 9946
		protected string _strColor = string.Empty;

		// Token: 0x040026DB RID: 9947
		protected bool _bForbid;
	}

	// Token: 0x0200080F RID: 2063
	public class CardInfoMaker
	{
		// Token: 0x060037C7 RID: 14279 RVA: 0x00025005 File Offset: 0x00023205
		public CardInfoMaker(ItemDNA itemDNA_0, ItemDNA itemDNA_1)
		{
			this._showItem = itemDNA_0;
			this._compareItem = itemDNA_1;
		}

		// Token: 0x170002FA RID: 762
		// (get) Token: 0x060037C8 RID: 14280 RVA: 0x0002501B File Offset: 0x0002321B
		protected virtual string String_0
		{
			get
			{
				return "none";
			}
		}

		// Token: 0x060037C9 RID: 14281 RVA: 0x00101D90 File Offset: 0x000FFF90
		public virtual void vmethod_0(MovieClip movieClip_0)
		{
			this.mcRoot = movieClip_0;
			if (this.mcRoot != null)
			{
				if (this.mcRoot.currentLabel != this.String_0)
				{
					this.mcRoot.gotoAndStop(this.String_0);
					this.mcRoot.addFrameScript(this.String_0, new EventDispatcher.EventCallback(this.method_0));
				}
				else
				{
					this.vmethod_1();
				}
			}
		}

		// Token: 0x060037CA RID: 14282 RVA: 0x0000311B File Offset: 0x0000131B
		protected virtual void vmethod_1()
		{
		}

		// Token: 0x060037CB RID: 14283 RVA: 0x00025022 File Offset: 0x00023222
		private void method_0(CEvent cevent_0)
		{
			this.mcRoot.removeFrameScript(this.String_0, new EventDispatcher.EventCallback(this.method_0));
			this.vmethod_1();
		}

		// Token: 0x060037CC RID: 14284 RVA: 0x00101DFC File Offset: 0x000FFFFC
		protected void method_1(UnityTextField unityTextField_0, UnityTextField unityTextField_1, string string_0)
		{
			if (unityTextField_0 != null && unityTextField_1 != null)
			{
				if (string_0 == string.Empty)
				{
					unityTextField_1.visible = false;
					unityTextField_0.visible = false;
				}
				else
				{
					unityTextField_1.visible = true;
					unityTextField_0.visible = true;
					string[] array = string_0.Split(new char[] { '$' });
					if (array[0] == "Red")
					{
						unityTextField_0.visible = false;
						unityTextField_1.Color_0 = UniUIManager.UniSWFToolClass.smethod_8(array[0]);
						unityTextField_1.text = array[1];
					}
					else
					{
						Color color = UniUIManager.UniSWFToolClass.smethod_8(array[0]);
						unityTextField_1.Color_0 = color;
						unityTextField_0.Color_0 = color;
						unityTextField_0.text = array[1];
						unityTextField_1.text = array[2];
					}
				}
				return;
			}
		}

		// Token: 0x040026DC RID: 9948
		protected MovieClip mcRoot;

		// Token: 0x040026DD RID: 9949
		protected ItemDNA _showItem;

		// Token: 0x040026DE RID: 9950
		protected ItemDNA _compareItem;
	}

	// Token: 0x02000810 RID: 2064
	public class ItemCard3DPanel : ItemCardPanel
	{
		// Token: 0x060037CE RID: 14286 RVA: 0x00025050 File Offset: 0x00023250
		public override void vmethod_3(ItemDNA itemDNA_0, ItemDNA itemDNA_1)
		{
			base.vmethod_3(itemDNA_0, itemDNA_1);
			this.displayObjectContainer_0.visible = true;
		}

		// Token: 0x060037CF RID: 14287 RVA: 0x00025066 File Offset: 0x00023266
		public override void vmethod_2(MovieClip movieClip_0)
		{
			base.vmethod_2(movieClip_0);
			this._fXOffset = movieClip_0.width / 2f;
			this._fYOffset = movieClip_0.height / 3f;
		}

		// Token: 0x060037D0 RID: 14288 RVA: 0x00025093 File Offset: 0x00023293
		public void method_11()
		{
			this._showItem = null;
			this._compareItem = null;
			this.displayObjectContainer_0.visible = false;
		}

		// Token: 0x060037D1 RID: 14289 RVA: 0x000250AF File Offset: 0x000232AF
		public void method_12(int int_0, int int_1)
		{
			if (this.displayObjectContainer_0 != null)
			{
				this.displayObjectContainer_0.x = (float)int_0 - this._fXOffset * this._fScale;
				this.displayObjectContainer_0.y = (float)int_1 - this._fYOffset * this._fScale;
			}
		}

		// Token: 0x060037D2 RID: 14290 RVA: 0x00101EAC File Offset: 0x001000AC
		public void method_13(float float_0)
		{
			this.displayObjectContainer_0.scaleY = float_0;
			this.displayObjectContainer_0.scaleX = float_0;
			this._fScale = float_0;
		}

		// Token: 0x040026DF RID: 9951
		private float _fXOffset;

		// Token: 0x040026E0 RID: 9952
		private float _fYOffset;

		// Token: 0x040026E1 RID: 9953
		private float _fScale;
	}

	// Token: 0x02000811 RID: 2065
	private class ExpDownPanel : GClass51
	{
		// Token: 0x060037D4 RID: 14292 RVA: 0x00101EDC File Offset: 0x001000DC
		protected override void vmethod_0()
		{
			base.vmethod_0();
			this.mcSelf = this.displayObjectContainer_0 as MovieClip;
			if (this.mcSelf == null)
			{
				DebugUtils.LogWarning(LogCategory.GUI, "UIWarning: ExpDownPanel MovieClip missing!!");
				return;
			}
			this.mcSelf.visible = false;
			this.mcSelf.stop();
			this.mcRoot = this.mcSelf.getChildByName<MovieClip>("mcRoot");
			if (this.mcRoot != null)
			{
				this.mcRoot.stop();
				this.mcExp = this.mcRoot.getChildByName("mcExp") as MovieClip;
				if (this.mcExp != null)
				{
					this.tfValue = this.mcExp.getChildByName<TextField>("textField");
				}
				this.mcExpCover = this.mcRoot.getChildByName("mcExpCover") as MovieClip;
				if (this.mcExpCover != null)
				{
					this.tfValueCover = this.mcExpCover.getChildByName<TextField>("textField");
				}
				this.mcRoot.addFrameScript("end", new EventDispatcher.EventCallback(this.method_5));
			}
		}

		// Token: 0x060037D5 RID: 14293 RVA: 0x000250EF File Offset: 0x000232EF
		public virtual void vmethod_2(int int_0)
		{
			this._iExp = int_0;
			this.mcRoot.gotoAndPlay("start");
			this.mcSelf.visible = true;
		}

		// Token: 0x060037D6 RID: 14294 RVA: 0x00025114 File Offset: 0x00023314
		private void method_5(CEvent cevent_0)
		{
			this.mcSelf.visible = false;
		}

		// Token: 0x040026E2 RID: 9954
		protected const string WORD_XP = "xp";

		// Token: 0x040026E3 RID: 9955
		protected MovieClip mcSelf;

		// Token: 0x040026E4 RID: 9956
		protected MovieClip mcRoot;

		// Token: 0x040026E5 RID: 9957
		protected MovieClip mcExp;

		// Token: 0x040026E6 RID: 9958
		protected MovieClip mcExpCover;

		// Token: 0x040026E7 RID: 9959
		protected TextField tfValue;

		// Token: 0x040026E8 RID: 9960
		protected TextField tfValueCover;

		// Token: 0x040026E9 RID: 9961
		protected bool _bVisible;

		// Token: 0x040026EA RID: 9962
		protected int _iExp;
	}
}
