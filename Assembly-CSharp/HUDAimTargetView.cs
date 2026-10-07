using System;
using ns0;
using UnityEngine;
using XsdSettings;

// Token: 0x020006AE RID: 1710
public class HUDAimTargetView : BaseView
{
	// Token: 0x06002CC8 RID: 11464 RVA: 0x000D2EC8 File Offset: 0x000D10C8
	public override void OnTestGUI()
	{
		if (this._bEUseTipShowing)
		{
			GUI.TextField(new Rect(640f, 400f, 100f, 25f), "[E] to Use");
		}
		GUI.TextField(new Rect(500f, 200f, 180f, 25f), "Accurate is:" + this._fCrossHairAccurate);
		GUI.TextField(new Rect(500f, 230f, 180f, 25f), "Aim Mode:" + this._eAimMode);
		if (this._aimedEntity != null)
		{
			EquipmentInventoryEntity equipmentInventoryEntity = this._aimedEntity.vmethod_19();
			GUI.TextField(new Rect(500f, 100f, 180f, 25f), string.Concat(new object[]
			{
				"HP:",
				equipmentInventoryEntity.vmethod_4(),
				"/",
				equipmentInventoryEntity.vmethod_0()
			}));
		}
		if (this._interactingItem != null && this._interactingItem.vmethod_67() && this._interactingItem.m_pickable.imethod_3(MonoSingleton<Session>.Instance.GetLocalPlayer().GetEntity()))
		{
			WeaponAttribute attribute = (this._interactingItem as EntityWeapon).m_attribute;
			string text = string.Empty;
			text += "LEVEL REQUIREMENT: 1";
			text = text + "Name:" + this._interactingItem.m_name;
			text = text + "\nDamage:" + (attribute.method_1(AttributeType.WeaponDamage) as FloatAttributeValue).m_value;
			text = text + "\nAccuracy:" + attribute.method_2();
			text = text + "\nFire Rate:" + (attribute.method_1(AttributeType.FireRate) as FloatAttributeValue).m_value;
			text = text + "\nReload Speed:" + (attribute.method_1(AttributeType.ReloadTime) as FloatAttributeValue).m_value;
			text = text + "\nMagazine Size:" + (this._interactingItem as EntityWeapon).method_101();
			string text2 = text;
			text = string.Concat(new object[]
			{
				text2,
				"\nFactory: XX\tQuanlity:\tType:",
				this._interactingItem.m_subType,
				"\n"
			});
			text += "Cost:30000\n";
			GUI.TextField(new Rect(500f, 100f, 180f, 200f), text);
		}
	}

	// Token: 0x06002CC9 RID: 11465 RVA: 0x000D315C File Offset: 0x000D135C
	public override void vmethod_2()
	{
		base.vmethod_2();
		Camera camera_ = MonoSingleton<AppManager>.Instance.method_0().Camera_0;
		if (camera_ != null)
		{
			this._screenPosition.Set(camera_.pixelWidth / 2f, camera_.pixelHeight / 2f, 0f);
		}
		MonoSingleton<AppManager>.Instance.method_0().method_4(this);
	}

	// Token: 0x06002CCA RID: 11466 RVA: 0x0001DB45 File Offset: 0x0001BD45
	public override void vmethod_3()
	{
		base.vmethod_3();
		MonoSingleton<AppManager>.Instance.method_0().method_5(this);
		this._weaponType = WeaponType.TOTAL;
		this._screenPosition = Vector3.zero;
	}

	// Token: 0x06002CCB RID: 11467 RVA: 0x0001DB6F File Offset: 0x0001BD6F
	public virtual void vmethod_5(E_SCOPE_TYPE e_SCOPE_TYPE_0 = E_SCOPE_TYPE.E_NORMAL)
	{
		this._eAimMode = e_SCOPE_TYPE_0;
	}

	// Token: 0x06002CCC RID: 11468 RVA: 0x0001DB78 File Offset: 0x0001BD78
	public virtual void vmethod_6(EntityWeapon.ScopeHudType scopeHudType_0)
	{
		this._eHudType = scopeHudType_0;
	}

	// Token: 0x06002CCD RID: 11469 RVA: 0x0001DB81 File Offset: 0x0001BD81
	public virtual void vmethod_7(float float_0, float float_1 = 3.4028235E+38f)
	{
		this._fCrossHairAccurate = float_0;
		this._fScopeCrossHairAccurate = float_1;
	}

	// Token: 0x06002CCE RID: 11470 RVA: 0x0001DB91 File Offset: 0x0001BD91
	public virtual void vmethod_8(E_USE_TYPE e_USE_TYPE_0)
	{
		this._curType = e_USE_TYPE_0;
	}

	// Token: 0x06002CCF RID: 11471 RVA: 0x0001DB9A File Offset: 0x0001BD9A
	public virtual void vmethod_9(WeaponType weaponType_0)
	{
		this._weaponType = weaponType_0;
	}

	// Token: 0x06002CD0 RID: 11472 RVA: 0x0001DBA3 File Offset: 0x0001BDA3
	public virtual void vmethod_10(AttackInfo.ElementalType elementalType_0)
	{
		this._elementalType = elementalType_0;
	}

	// Token: 0x06002CD1 RID: 11473 RVA: 0x0001DBAC File Offset: 0x0001BDAC
	public virtual void vmethod_11(EntityWeapon.ScopeMaskType scopeMaskType_0)
	{
		this._maskType = scopeMaskType_0;
	}

	// Token: 0x06002CD2 RID: 11474 RVA: 0x0001DBB5 File Offset: 0x0001BDB5
	public virtual void vmethod_12(Entity entity_0, bool bool_0 = false)
	{
		this._isInSameTeam = bool_0;
		this._aimedEntity = entity_0;
		this._bAimed = this._aimedEntity != null;
	}

	// Token: 0x06002CD3 RID: 11475 RVA: 0x000D31C0 File Offset: 0x000D13C0
	public virtual void vmethod_13(EntityObject entityObject_0, bool bool_0, bool bool_1, ItemDNA itemDNA_0 = null)
	{
		if (entityObject_0 == null)
		{
			if (this._bEntityDisplaying || this._interactingItem != entityObject_0)
			{
				this._interactingItem = null;
				this._bEntityDisplaying = false;
				this._pillorTF = null;
				this._compareItem = null;
				this.vmethod_21();
			}
			return;
		}
		Vector3 vector = this.method_3(entityObject_0);
		Vector3 vector2 = this.method_4(entityObject_0);
		if (entityObject_0 != this._interactingItem || this.m_previousIconeMode != bool_0 || this._compareItem != itemDNA_0)
		{
			this.vmethod_21();
			this._pillorTF = entityObject_0.gameObject.transform.FindChild("LightPillor");
			vector = this.method_3(entityObject_0);
			vector2 = this.method_4(entityObject_0);
			bool flag = this._interactingItem == entityObject_0 && this._compareItem == itemDNA_0;
			this._interactingItem = entityObject_0;
			this._bEntityDisplaying = true;
			this._compareItem = itemDNA_0;
			if (!bool_0)
			{
				ItemType type = entityObject_0.method_13().m_type;
				switch (type)
				{
				case ItemType.Weapon:
				case ItemType.Shield:
					break;
				default:
					if (type != ItemType.ClassMode)
					{
						this.vmethod_23(vector, bool_1);
						goto IL_0124;
					}
					break;
				}
				if (!flag)
				{
					this.vmethod_22();
				}
			}
			else
			{
				this.vmethod_23(vector, bool_1);
			}
			IL_0124:
			this.m_previousIconeMode = bool_0;
		}
		this.method_5();
	}

	// Token: 0x06002CD3 RID: 11475 RVA: 0x000D31C0 File Offset: 0x000D13C0
	public void method_5()
	{
		if (!this._bEntityDisplaying || this._interactingItem == null)
		{
			return;
		}
		Camera camera_ = MonoSingleton<AppManager>.Instance.method_0().Camera_0;
		if (camera_ == null)
		{
			return;
		}
		Vector3 vector = this.method_3(this._interactingItem);
		Vector3 vector2 = this.method_4(this._interactingItem);
		vector2.y += 0.4f;
		float num = Vector3.Distance(this.method_4(this._interactingItem), camera_.transform.position);
		Ray ray = new Ray(camera_.transform.position, camera_.transform.forward);
		RaycastHit raycastHit;
		if (this._pillorTF != null && this._pillorTF.collider.Raycast(ray, out raycastHit, 10f))
		{
			vector2.y = Mathf.Min(vector.y - 0.2f, Mathf.Max(raycastHit.point.y, vector2.y));
			num = raycastHit.distance;
		}
		num = 1.5f / num;
		Vector2 vector3 = camera_.WorldToScreenPoint(vector2);
		vector3.y = (float)Screen.height - vector3.y + 40f;
		this.vmethod_20(vector3, num);
	}

	// Token: 0x06002CD4 RID: 11476 RVA: 0x000D3400 File Offset: 0x000D1600
	public Vector3 method_3(EntityObject entityObject_0)
	{
		if (this._pillorTF != null)
		{
			return this._pillorTF.position + this._pillorTF.lossyScale.y * Vector3.up;
		}
		return entityObject_0.gameObject.transform.position + entityObject_0.gameObject.transform.lossyScale.y * Vector3.up;
	}

	// Token: 0x06002CD5 RID: 11477 RVA: 0x0001DBD7 File Offset: 0x0001BDD7
	public Vector3 method_4(EntityObject entityObject_0)
	{
		if (this._pillorTF != null)
		{
			return this._pillorTF.position;
		}
		return entityObject_0.gameObject.transform.position;
	}

	// Token: 0x06002CD6 RID: 11478 RVA: 0x000D3480 File Offset: 0x000D1680
	public override bool OnScreenResized()
	{
		Camera camera_ = MonoSingleton<AppManager>.Instance.method_0().Camera_0;
		if (camera_ != null)
		{
			this._screenPosition.Set(camera_.pixelWidth / 2f, camera_.pixelHeight / 2f, 0f);
		}
		return true;
	}

	// Token: 0x06002CD7 RID: 11479 RVA: 0x0001DC03 File Offset: 0x0001BE03
	public virtual void vmethod_14()
	{
		this.vmethod_24(0);
	}

	// Token: 0x06002CD8 RID: 11480 RVA: 0x0000311B File Offset: 0x0000131B
	public virtual void vmethod_15(EntityNpc entityNpc_0)
	{
	}

	// Token: 0x06002CD9 RID: 11481 RVA: 0x0000311B File Offset: 0x0000131B
	public virtual void vmethod_16()
	{
	}

	// Token: 0x06002CDA RID: 11482 RVA: 0x0000311B File Offset: 0x0000131B
	public virtual void vmethod_17()
	{
	}

	// Token: 0x06002CDB RID: 11483 RVA: 0x0000311B File Offset: 0x0000131B
	public virtual void vmethod_18(int int_0, string string_0)
	{
	}

	// Token: 0x06002CDC RID: 11484 RVA: 0x0000311B File Offset: 0x0000131B
	public virtual void vmethod_19(int int_0, int int_1, int int_2, int int_3)
	{
	}

	// Token: 0x06002CDD RID: 11485 RVA: 0x0000311B File Offset: 0x0000131B
	protected virtual void vmethod_20(Vector2 vector2_0, float float_0)
	{
	}

	// Token: 0x06002CDE RID: 11486 RVA: 0x0000311B File Offset: 0x0000131B
	protected virtual void vmethod_21()
	{
	}

	// Token: 0x06002CDF RID: 11487 RVA: 0x0000311B File Offset: 0x0000131B
	protected virtual void vmethod_22()
	{
	}

	// Token: 0x06002CE0 RID: 11488 RVA: 0x0000311B File Offset: 0x0000131B
	protected virtual void vmethod_23(Vector3 vector3_0, bool bool_0)
	{
	}

	// Token: 0x06002CE1 RID: 11489 RVA: 0x0000311B File Offset: 0x0000131B
	protected virtual void vmethod_24(int int_0)
	{
	}

	// Token: 0x04001F7C RID: 8060
	private bool _bEUseTipShowing;

	// Token: 0x04001F7D RID: 8061
	protected E_USE_TYPE _curType;

	// Token: 0x04001F7E RID: 8062
	protected float _fCrossHairAccurate;

	// Token: 0x04001F7F RID: 8063
	protected float _fScopeCrossHairAccurate;

	// Token: 0x04001F80 RID: 8064
	protected E_SCOPE_TYPE _eAimMode = E_SCOPE_TYPE.E_NORMAL;

	// Token: 0x04001F81 RID: 8065
	protected EntityWeapon.ScopeHudType _eHudType;

	// Token: 0x04001F82 RID: 8066
	protected bool _bAimed;

	// Token: 0x04001F83 RID: 8067
	protected Entity _aimedEntity;

	// Token: 0x04001F84 RID: 8068
	protected bool _isInSameTeam;

	// Token: 0x04001F85 RID: 8069
	protected WeaponType _weaponType = WeaponType.TOTAL;

	// Token: 0x04001F86 RID: 8070
	protected AttackInfo.ElementalType _elementalType = AttackInfo.ElementalType.Max;

	// Token: 0x04001F87 RID: 8071
	protected bool _bEntityDisplaying;

	// Token: 0x04001F88 RID: 8072
	protected EntityObject _interactingItem;

	// Token: 0x04001F89 RID: 8073
	protected ItemDNA _compareItem;

	// Token: 0x04001F8A RID: 8074
	protected EntityWeapon.ScopeMaskType _maskType;

	// Token: 0x04001F8B RID: 8075
	protected GameObject _iconObject;

	// Token: 0x04001F8C RID: 8076
	protected Vector3 _screenPosition = Vector3.zero;

	// Token: 0x04001F8D RID: 8077
	protected bool m_previousIconeMode = true;

	// Token: 0x04001F8E RID: 8078
	protected Transform _pillorTF;
}
