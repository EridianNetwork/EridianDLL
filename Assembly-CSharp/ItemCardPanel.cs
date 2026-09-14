using System;
using System.Collections.Generic;
using System.Text;
using ns0;
using pumpkin.display;
using UnityEngine;
using XsdSettings;

// Token: 0x020007C9 RID: 1993
public class ItemCardPanel : GClass51
{
	// Token: 0x06003560 RID: 13664 RVA: 0x000F2B88 File Offset: 0x000F0D88
	public void method_5()
	{
		this._comparePanel.DisplayObjectContainer_0.x = 0f;
		this._cardPanel.DisplayObjectContainer_0.x = this.rightPosX;
		DisplayObject displayObjectContainer_ = this._cardPanel.DisplayObjectContainer_0;
		this._comparePanel.DisplayObjectContainer_0.visible = true;
		displayObjectContainer_.visible = true;
	}

	// Token: 0x06003561 RID: 13665 RVA: 0x000F2BE4 File Offset: 0x000F0DE4
	public void method_6(bool bool_0)
	{
		if (this._compareItem != null)
		{
			if (bool_0)
			{
				this._cardPanel.DisplayObjectContainer_0.x = 0f;
				this._comparePanel.DisplayObjectContainer_0.x = this.rightPosX;
			}
			else
			{
				this._comparePanel.DisplayObjectContainer_0.x = 0f;
				this._cardPanel.DisplayObjectContainer_0.x = this.rightPosX;
			}
		}
		else
		{
			this._cardPanel.DisplayObjectContainer_0.x = 0f;
			this._comparePanel.DisplayObjectContainer_0.x = this.rightPosX;
		}
	}

	// Token: 0x06003562 RID: 13666 RVA: 0x000F2C84 File Offset: 0x000F0E84
	public virtual void vmethod_2(MovieClip movieClip_0)
	{
		this._cardPanel = new ItemTipsPanel();
		this._cardPanel.method_0(movieClip_0);
		this._comparePanel = new ItemTipsPanel();
		this._comparePanel.method_0(movieClip_0.newInstance());
		if (this.displayObjectContainer_0 == null)
		{
			this.displayObjectContainer_0 = new MovieClip();
		}
		DisplayObject displayObjectContainer_ = this.displayObjectContainer_0;
		float num = 0f;
		this.displayObjectContainer_0.y = num;
		displayObjectContainer_.x = num;
		this.displayObjectContainer_0.addChild(this._comparePanel.DisplayObjectContainer_0);
		this.displayObjectContainer_0.addChild(this._cardPanel.DisplayObjectContainer_0);
		(this.displayObjectContainer_0 as MovieClip).mouseEnabled = false;
		(this.displayObjectContainer_0 as MovieClip).mouseChildrenEnabled = false;
		this.rightPosX = this._cardPanel.DisplayObjectContainer_0.width - 14f;
		this._comparePanel.DisplayObjectContainer_0.x += this.rightPosX;
	}

	// Token: 0x06003563 RID: 13667 RVA: 0x000F2D80 File Offset: 0x000F0F80
	public virtual void vmethod_3(ItemDNA itemDNA_0, ItemDNA itemDNA_1)
	{
		this._showItem = itemDNA_0;
		this._compareItem = itemDNA_1;
		if (this._compareItem == this._showItem)
		{
			this._compareItem = null;
		}
		if (this._showItem != null)
		{
			this.displayObjectContainer_0.visible = true;
			this.method_7();
		}
		else
		{
			this.displayObjectContainer_0.visible = false;
		}
	}

	// Token: 0x06003564 RID: 13668 RVA: 0x000F2DD8 File Offset: 0x000F0FD8
	public void method_7()
	{
		ItemTipsData itemTipsData = null;
		ItemTipsData itemTipsData2 = null;
		switch (this._showItem.m_type)
		{
		case ItemType.Weapon:
		{
			WeaponDNA weaponDNA = ((this._compareItem != null) ? this._compareItem.method_6() : null);
			WeaponDNA weaponDNA2 = this._showItem.method_6();
			itemTipsData = ItemCardPanel.smethod_2(weaponDNA2, weaponDNA, false);
			itemTipsData.price = this._showItem.m_price;
			itemTipsData.item = this._showItem;
			if (weaponDNA != null)
			{
				itemTipsData2 = ItemCardPanel.smethod_2(weaponDNA, null, false);
				itemTipsData2.item = this._compareItem;
				itemTipsData2.bEquiped = true;
				itemTipsData2.price = this._compareItem.m_price;
			}
			break;
		}
		case ItemType.Shield:
		{
			ShieldDNA shieldDNA = ((this._compareItem != null) ? this._compareItem.method_7() : null);
			ShieldDNA shieldDNA2 = this._showItem.method_7();
			itemTipsData = this.method_8(shieldDNA2, shieldDNA);
			itemTipsData.price = this._showItem.m_price;
			itemTipsData.item = this._showItem;
			if (shieldDNA != null)
			{
				itemTipsData2 = this.method_8(shieldDNA, shieldDNA2);
				itemTipsData2.item = this._compareItem;
				itemTipsData2.bEquiped = true;
				itemTipsData2.price = this._compareItem.m_price;
			}
			break;
		}
		case ItemType.Material:
			itemTipsData = new ItemTipsData();
			itemTipsData.name = LocalizedString.smethod_0(new LocalizedString(this._showItem.m_materialType.ToString()));
			itemTipsData.price = this._showItem.m_price;
			itemTipsData.item = this._showItem;
			break;
		case ItemType.ClassMode:
		{
			ClassModeDNA classModeDNA = ((this._compareItem != null) ? this._compareItem.method_8() : null);
			ClassModeDNA classModeDNA2 = this._showItem.method_8();
			itemTipsData = this.method_9(classModeDNA2, classModeDNA);
			itemTipsData.price = this._showItem.m_price;
			itemTipsData.item = this._showItem;
			if (classModeDNA != null)
			{
				itemTipsData2 = this.method_9(classModeDNA, classModeDNA2);
				itemTipsData2.item = this._compareItem;
				itemTipsData2.bEquiped = true;
				itemTipsData2.price = this._compareItem.m_price;
			}
			break;
		}
		case ItemType.Outfit:
		{
			OutfitDNA outfitDNA = this._showItem.method_9();
			itemTipsData = this.method_10(outfitDNA);
			itemTipsData.item = this._showItem;
			break;
		}
		}
		this._cardPanel.method_5(itemTipsData);
		this._comparePanel.method_5(itemTipsData2);
	}

	// Token: 0x06003565 RID: 13669 RVA: 0x000F3040 File Offset: 0x000F1240
	private static bool smethod_0(ShieldAttributeType shieldAttributeType_0, List<SkillAttributeConfig> list_1, ref float float_0)
	{
		float num = float_0;
		if (shieldAttributeType_0 == ShieldAttributeType.Capacity)
		{
			bool flag = false;
			foreach (SkillAttributeConfig skillAttributeConfig in list_1)
			{
				if (skillAttributeConfig.m_attrType == EffectType.WeaponMaxShieldPostAdd)
				{
					num += skillAttributeConfig.m_attrValue;
					flag = true;
				}
				float_0 = num;
			}
			return flag;
		}
		if (shieldAttributeType_0 == ShieldAttributeType.RechargeRate)
		{
			using (List<SkillAttributeConfig>.Enumerator enumerator2 = list_1.GetEnumerator())
			{
				while (enumerator2.MoveNext())
				{
					SkillAttributeConfig skillAttributeConfig2 = enumerator2.Current;
					if (skillAttributeConfig2.m_attrType == EffectType.ShieldRechargeRate)
					{
						num += float_0 * skillAttributeConfig2.m_attrValue;
						float_0 = num;
						return true;
					}
				}
				return false;
			}
		}
		if (shieldAttributeType_0 != ShieldAttributeType.RechargeDelay)
		{
			return false;
		}
		using (List<SkillAttributeConfig>.Enumerator enumerator3 = list_1.GetEnumerator())
		{
			while (enumerator3.MoveNext())
			{
				SkillAttributeConfig skillAttributeConfig3 = enumerator3.Current;
				if (skillAttributeConfig3.m_attrType == EffectType.ShieldRechargeDelay)
				{
					num += float_0 * skillAttributeConfig3.m_attrValue;
					float_0 = num;
					return true;
				}
			}
			return false;
		}
		bool flag2;
		return flag2;
	}

	// Token: 0x06003566 RID: 13670 RVA: 0x000F3168 File Offset: 0x000F1368
	private static bool smethod_1(AttributeType attributeType_0, List<SkillAttributeConfig> list_1, ref float float_0)
	{
		float num = float_0;
		if (attributeType_0 == AttributeType.WeaponDamage)
		{
			bool flag = false;
			foreach (SkillAttributeConfig skillAttributeConfig in list_1)
			{
				if (skillAttributeConfig.m_attrType == EffectType.BulletDamageScale || skillAttributeConfig.m_attrType == EffectType.BulletDamagePostAdd)
				{
					if (skillAttributeConfig.m_affectType == AffectType.Scale)
					{
						num += float_0 * skillAttributeConfig.m_attrValue;
					}
					else
					{
						num += skillAttributeConfig.m_attrValue;
					}
					flag = true;
				}
				float_0 = num;
			}
			return flag;
		}
		foreach (SkillAttributeConfig skillAttributeConfig2 in list_1)
		{
			if (!(skillAttributeConfig2.m_attrType.ToString() == attributeType_0.ToString()) && (skillAttributeConfig2.m_attrType != EffectType.WeaponReloadSpeed || attributeType_0 != AttributeType.ReloadTime))
			{
				if (skillAttributeConfig2.m_attrType != EffectType.ClipSize || attributeType_0 != AttributeType.ClipSize)
				{
					if (skillAttributeConfig2.m_attrType == EffectType.WeaponAccuracy && attributeType_0 == AttributeType.AccuracyMax)
					{
						float_0 = 100f - num * (1f - skillAttributeConfig2.m_attrValue);
						return true;
					}
					continue;
				}
			}
			if (skillAttributeConfig2.m_affectType == AffectType.Scale)
			{
				num += float_0 * skillAttributeConfig2.m_attrValue;
			}
			else
			{
				num += skillAttributeConfig2.m_attrValue;
			}
			float_0 = num;
			return true;
		}
		return false;
	}

	// Token: 0x06003567 RID: 13671 RVA: 0x000F32CC File Offset: 0x000F14CC
	public static ItemTipsData smethod_2(WeaponDNA weaponDNA_0, WeaponDNA weaponDNA_1 = null, bool bool_0 = false)
	{
		ItemTipsData itemTipsData = new ItemTipsData();
		if (weaponDNA_0 != null)
		{
			StringBuilder stringBuilder = new StringBuilder();
			EntityPlayer entityPlayer = null;
			if (MonoSingleton<Session>.Instance != null)
			{
				entityPlayer = MonoSingleton<Session>.Instance.GetLocalPlayer().GetEntity() as EntityPlayer;
			}
			itemTipsData.nameColor = UniUIManager.UniSWFToolClass.smethod_4(weaponDNA_0.m_rarity);
			itemTipsData.name = weaponDNA_0.method_4();
			itemTipsData.level = ((!(entityPlayer != null)) ? weaponDNA_0.m_level : entityPlayer.method_141(weaponDNA_0.m_level));
			bool flag = ServiceWrapperBase<CharacterServiceWrapper>.Instance.method_8() >= weaponDNA_0.m_level;
			itemTipsData.levelColor = ((!flag) ? UniUIManager.UniSWFToolClass.smethod_5(ServiceWrapperBase<CharacterServiceWrapper>.Instance.method_8(), weaponDNA_0.m_level) : Color.green);
			WeaponAttribute attribute = weaponDNA_0.m_attribute;
			WeaponAttribute weaponAttribute = ((weaponDNA_1 != null) ? weaponDNA_1.m_attribute : null);
			List<SkillAttributeConfig> list = WeaponExtraAttributeStore.WeaponExtraAttributeStore_0.vmethod_0(weaponDNA_0.m_extraEffect, weaponDNA_0.m_extraEffectIndex, weaponDNA_0.method_2(), weaponDNA_0.m_level);
			List<SkillAttributeConfig> list2 = null;
			bool flag2;
			if (!(flag2 = weaponDNA_1 == null || weaponDNA_1.m_type != weaponDNA_0.m_type))
			{
				list2 = WeaponExtraAttributeStore.WeaponExtraAttributeStore_0.vmethod_0(weaponDNA_1.m_extraEffect, weaponDNA_1.m_extraEffectIndex, weaponDNA_1.method_2(), weaponDNA_1.m_level);
			}
			ItemElement itemElement;
			if (!bool_0)
			{
				if (weaponDNA_0.m_starLevel > 0)
				{
					itemElement = new ItemElement();
					itemElement.value = weaponDNA_0.m_starLevel;
					itemElement.eType = ETipsItemType.STAR;
					itemElement.arrow = "none";
					itemTipsData.attributeList.Add(itemElement);
				}
				int num = StarLevelAttributeStore.StarLevelAttributeStore_0.method_1(weaponDNA_0.method_1(), weaponDNA_0.m_starLevel, weaponDNA_0.m_level, weaponDNA_0.m_rarity);
				if (num > 0)
				{
					itemElement = new ItemElement();
					stringBuilder.Append(LocalizedString.smethod_0(new LocalizedString("Weapon_Upgrade_Requirement"))).Append(" ").Append(weaponDNA_0.m_starExperience)
						.Append("/")
						.Append(num);
					itemElement.value = stringBuilder.ToString();
					itemElement.eType = ETipsItemType.TEXT;
					itemElement.arrow = "none";
					itemTipsData.attributeList.Add(itemElement);
				}
			}
			float num2 = 0f;
			float num3 = 0f;
			itemElement = new ItemElement();
			int value = (attribute.method_1(AttributeType.WeaponProjectilesPerShot) as IntAttributeValue).m_value;
			num2 = (attribute.method_1(AttributeType.WeaponDamage) as FloatAttributeValue).m_value;
			itemElement.aType = AttributeType.WeaponDamage;
			if (ItemCardPanel.smethod_1(AttributeType.WeaponDamage, list, ref num2))
			{
				itemElement.color = Color.green;
			}
			float num4 = ((!flag || !(entityPlayer != null)) ? num2 : ((float)entityPlayer.method_140((int)num2)));
			if (num4 > num2)
			{
				itemElement.color = Color.green;
			}
			num2 = num4;
			if (value > 1)
			{
				stringBuilder.Remove(0, stringBuilder.Length);
				stringBuilder.Append(value).Append(" x ").Append((num2 / (float)value).ToString("f1"));
				itemElement.value = stringBuilder.ToString();
			}
			else
			{
				itemElement.value = Utility.smethod_8((int)num2);
			}
			itemElement.eType = ETipsItemType.ITVA;
			if (flag2)
			{
				itemElement.arrow = "none";
			}
			else
			{
				num3 = (weaponAttribute.method_1(AttributeType.WeaponDamage) as FloatAttributeValue).m_value;
				ItemCardPanel.smethod_1(AttributeType.WeaponDamage, list2, ref num3);
				itemElement.arrow = UniUIManager.UniSWFToolClass.smethod_0(num2, num3, 1);
			}
			itemElement.iconType = AttributeType.WeaponDamage.ToString();
			itemElement.title = LocalizedString.smethod_0(new LocalizedString("WC_AttDesc_0"));
			itemTipsData.attributeList.Add(itemElement);
			itemElement = new ItemElement();
			num2 = attribute.method_2();
			itemElement.aType = AttributeType.AccuracyMax;
			if (ItemCardPanel.smethod_1(AttributeType.AccuracyMax, list, ref num2))
			{
				itemElement.color = Color.green;
			}
			itemElement.value = num2.ToString("f1");
			if (flag2)
			{
				itemElement.arrow = "none";
			}
			else
			{
				num3 = weaponAttribute.method_2();
				ItemCardPanel.smethod_1(AttributeType.AccuracyMax, list2, ref num3);
				itemElement.arrow = UniUIManager.UniSWFToolClass.smethod_0(num2, num3, 10);
			}
			itemElement.iconType = "accuracy";
			itemElement.eType = ETipsItemType.ITVA;
			itemElement.title = LocalizedString.smethod_0(new LocalizedString("WC_AttDesc_1"));
			itemTipsData.attributeList.Add(itemElement);
			itemElement = new ItemElement();
			num2 = (attribute.method_1(AttributeType.FireRate) as FloatAttributeValue).m_value;
			itemElement.aType = AttributeType.FireRate;
			if (ItemCardPanel.smethod_1(AttributeType.FireRate, list, ref num2))
			{
				itemElement.color = Color.green;
			}
			itemElement.value = num2.ToString("f1");
			if (flag2)
			{
				itemElement.arrow = "none";
			}
			else
			{
				num3 = (weaponAttribute.method_1(AttributeType.FireRate) as FloatAttributeValue).m_value;
				ItemCardPanel.smethod_1(AttributeType.FireRate, list2, ref num3);
				itemElement.arrow = UniUIManager.UniSWFToolClass.smethod_0(num2, num3, 10);
			}
			itemElement.iconType = AttributeType.FireRate.ToString();
			itemElement.eType = ETipsItemType.ITVA;
			itemElement.title = LocalizedString.smethod_0(new LocalizedString("WC_AttDesc_2"));
			itemTipsData.attributeList.Add(itemElement);
			itemElement = new ItemElement();
			num2 = (attribute.method_1(AttributeType.ReloadTime) as FloatAttributeValue).m_value;
			itemElement.aType = AttributeType.ReloadTime;
			if (ItemCardPanel.smethod_1(AttributeType.ReloadTime, list, ref num2))
			{
				itemElement.color = Color.green;
			}
			itemElement.value = num2.ToString("f1");
			if (flag2)
			{
				itemElement.arrow = "none";
			}
			else
			{
				num3 = (weaponAttribute.method_1(AttributeType.ReloadTime) as FloatAttributeValue).m_value;
				ItemCardPanel.smethod_1(AttributeType.ReloadTime, list2, ref num3);
				itemElement.arrow = UniUIManager.UniSWFToolClass.smethod_0(num2, num3, 100);
			}
			itemElement.iconType = AttributeType.ReloadTime.ToString();
			itemElement.eType = ETipsItemType.ITVA;
			itemElement.title = LocalizedString.smethod_0(new LocalizedString("WC_AttDesc_3"));
			itemTipsData.attributeList.Add(itemElement);
			itemElement = new ItemElement();
			num2 = (float)(attribute.method_1(AttributeType.ClipSize) as IntAttributeValue).m_value;
			itemElement.aType = AttributeType.ClipSize;
			if (ItemCardPanel.smethod_1(AttributeType.ClipSize, list, ref num2))
			{
				itemElement.color = Color.green;
			}
			itemElement.value = Utility.smethod_8((int)num2);
			if (flag2)
			{
				itemElement.arrow = "none";
			}
			else
			{
				num3 = (float)(weaponAttribute.method_1(AttributeType.ClipSize) as IntAttributeValue).m_value;
				ItemCardPanel.smethod_1(AttributeType.ClipSize, list2, ref num3);
				itemElement.arrow = UniUIManager.UniSWFToolClass.smethod_0(num2, num3, 10);
			}
			itemElement.iconType = AttributeType.ClipSize.ToString();
			itemElement.eType = ETipsItemType.ITVA;
			itemElement.title = LocalizedString.smethod_0(new LocalizedString("WC_AttDesc_4"));
			itemTipsData.attributeList.Add(itemElement);
			itemTipsData.brand = UniUIManager.UniSWFToolClass._BrandStringMap[(attribute.method_1(AttributeType.ManufactureType) as IntAttributeValue).m_value];
			AttackInfo.ElementalType value2 = (AttackInfo.ElementalType)(attribute.method_1(AttributeType.ElementalType) as IntAttributeValue).m_value;
			if (value2 != AttackInfo.ElementalType.None)
			{
				itemElement = new ItemElement();
				itemElement.value = (attribute.method_1(AttributeType.WeaponElementalDamage) as FloatAttributeValue).m_value.ToString("f1");
				num2 = (attribute.method_1(AttributeType.WeaponElementalDamage) as FloatAttributeValue).m_value;
				num4 = ((!(entityPlayer != null)) ? num2 : ((float)entityPlayer.method_140((int)num2)));
				if (num4 > num2)
				{
					itemElement.color = Color.green;
				}
				num2 = num4;
				itemElement.value = num2.ToString("f1");
				itemElement.aType = AttributeType.WeaponElementalDamage;
				if (flag2)
				{
					itemElement.arrow = "none";
				}
				else
				{
					itemElement.arrow = UniUIManager.UniSWFToolClass.smethod_0((attribute.method_1(AttributeType.WeaponElementalDamage) as FloatAttributeValue).m_value, (weaponAttribute.method_1(AttributeType.WeaponElementalDamage) as FloatAttributeValue).m_value, 10);
				}
				itemElement.iconType = Utility.smethod_5("element", value2.ToString());
				itemElement.eType = ETipsItemType.ITVA;
				itemElement.title = LocalizedString.smethod_0(new LocalizedString("WC_AttDesc_5"));
				itemTipsData.attributeList.Add(itemElement);
				itemElement = new ItemElement();
				itemElement.value = (attribute.method_1(AttributeType.ElementalProcCoef) as FloatAttributeValue).m_value.ToString("p0");
				itemElement.aType = AttributeType.ElementalProcCoef;
				if (flag2)
				{
					itemElement.arrow = "none";
				}
				else
				{
					itemElement.arrow = UniUIManager.UniSWFToolClass.smethod_0((attribute.method_1(AttributeType.ElementalProcCoef) as FloatAttributeValue).m_value, (weaponAttribute.method_1(AttributeType.ElementalProcCoef) as FloatAttributeValue).m_value, 10);
				}
				itemElement.iconType = Utility.smethod_5("element", value2.ToString());
				itemElement.eType = ETipsItemType.ITVA;
				itemElement.title = LocalizedString.smethod_0(new LocalizedString("WC_AttDesc_6"));
				itemTipsData.attributeList.Add(itemElement);
			}
			Dictionary<string, ItemCardDisplayType> dictionary = weaponDNA_0.imethod_0();
			ItemCardPanel.smethod_3(itemTipsData, dictionary);
		}
		return itemTipsData;
	}

	// Token: 0x06003568 RID: 13672 RVA: 0x000F3BB8 File Offset: 0x000F1DB8
	private static void smethod_3(ItemTipsData itemTipsData_0, Dictionary<string, ItemCardDisplayType> dictionary_0)
	{
		if (dictionary_0 != null)
		{
			foreach (KeyValuePair<string, ItemCardDisplayType> keyValuePair in dictionary_0)
			{
				ItemElement itemElement = new ItemElement();
				string text = keyValuePair.Key;
				bool flag = false;
				if (text[text.Length - 1] == 'G')
				{
					text = text.Substring(0, text.Length - 1);
					flag = true;
				}
				itemElement.value = text;
				itemElement.color = ((!flag) ? UniUIManager.UniSWFToolClass.smethod_9(keyValuePair.Value) : Color.green);
				itemElement.eType = ETipsItemType.TEXT;
				itemElement.arrow = "none";
				itemTipsData_0.additionAttList.Add(itemElement);
			}
		}
	}

	// Token: 0x06003569 RID: 13673 RVA: 0x000F3C84 File Offset: 0x000F1E84
	public ItemTipsData method_8(ShieldDNA shieldDNA_0, ShieldDNA shieldDNA_1 = null)
	{
		ItemTipsData itemTipsData = new ItemTipsData();
		if (shieldDNA_0 != null)
		{
			EntityPlayer entityPlayer = null;
			if (MonoSingleton<Session>.Instance != null)
			{
				entityPlayer = MonoSingleton<Session>.Instance.GetLocalPlayer().GetEntity() as EntityPlayer;
			}
			itemTipsData.name = shieldDNA_0.method_3();
			itemTipsData.level = ((!(entityPlayer != null)) ? shieldDNA_0.m_level : entityPlayer.method_141(shieldDNA_0.m_level));
			itemTipsData.nameColor = UniUIManager.UniSWFToolClass.smethod_3(shieldDNA_0.m_rarity);
			itemTipsData.levelColor = ((itemTipsData.level <= shieldDNA_0.m_level) ? UniUIManager.UniSWFToolClass.smethod_5(ServiceWrapperBase<CharacterServiceWrapper>.Instance.method_8(), shieldDNA_0.m_level) : Color.green);
			ShieldAttribute attribute = shieldDNA_0.m_attribute;
			List<SkillAttributeConfig> list = ShieldExtraAttributeStore.ShieldExtraAttributeStore_0.vmethod_0(shieldDNA_0.m_extraEffect, shieldDNA_0.m_extraEffectIndex, shieldDNA_0.method_1(), shieldDNA_0.m_level);
			List<SkillAttributeConfig> list2 = null;
			bool flag;
			if (!(flag = shieldDNA_1 == null))
			{
				list2 = ShieldExtraAttributeStore.ShieldExtraAttributeStore_0.vmethod_0(shieldDNA_1.m_extraEffect, shieldDNA_1.m_extraEffectIndex, shieldDNA_1.method_1(), shieldDNA_1.m_level);
			}
			float num = 0f;
			float num2 = 0f;
			ItemElement itemElement = new ItemElement();
			num = shieldDNA_0.method_7(ShieldAttributeType.Capacity);
			if (ItemCardPanel.smethod_0(ShieldAttributeType.Capacity, list, ref num))
			{
				itemElement.color = Color.green;
			}
			float num3 = ((!(entityPlayer != null)) ? num : ((float)entityPlayer.method_140((int)num)));
			if (num3 > num)
			{
				itemElement.color = Color.green;
			}
			num = num3;
			itemElement.value = num.ToString("f1");
			if (flag)
			{
				itemElement.arrow = "none";
			}
			else
			{
				num2 = shieldDNA_1.method_7(ShieldAttributeType.Capacity);
				ItemCardPanel.smethod_0(ShieldAttributeType.Capacity, list2, ref num2);
				itemElement.arrow = UniUIManager.UniSWFToolClass.smethod_0(shieldDNA_0.method_7(ShieldAttributeType.Capacity), shieldDNA_1.method_7(ShieldAttributeType.Capacity), 10);
			}
			itemElement.iconType = Utility.smethod_5("shield", ShieldAttributeType.Capacity.ToString());
			itemElement.eType = ETipsItemType.ITVA;
			itemElement.title = LocalizedString.smethod_0(new LocalizedString("SC_AttDesc_0"));
			itemTipsData.attributeList.Add(itemElement);
			itemElement = new ItemElement();
			num = shieldDNA_0.method_7(ShieldAttributeType.RechargeRate);
			if (ItemCardPanel.smethod_0(ShieldAttributeType.RechargeRate, list, ref num))
			{
				itemElement.color = Color.green;
			}
			itemElement.value = num.ToString("f1");
			if (flag)
			{
				itemElement.arrow = "none";
			}
			else
			{
				num2 = shieldDNA_1.method_7(ShieldAttributeType.RechargeRate);
				ItemCardPanel.smethod_0(ShieldAttributeType.RechargeRate, list2, ref num2);
				itemElement.arrow = UniUIManager.UniSWFToolClass.smethod_0(shieldDNA_0.method_7(ShieldAttributeType.RechargeRate), shieldDNA_1.method_7(ShieldAttributeType.RechargeRate), 10);
			}
			itemElement.iconType = Utility.smethod_5("shield", ShieldAttributeType.RechargeRate.ToString());
			itemElement.eType = ETipsItemType.ITVA;
			itemElement.title = LocalizedString.smethod_0(new LocalizedString("SC_AttDesc_1"));
			itemTipsData.attributeList.Add(itemElement);
			itemElement = new ItemElement();
			num = shieldDNA_0.method_7(ShieldAttributeType.RechargeDelay);
			if (ItemCardPanel.smethod_0(ShieldAttributeType.RechargeDelay, list, ref num))
			{
				itemElement.color = Color.green;
			}
			itemElement.value = num.ToString("f1");
			if (flag)
			{
				itemElement.arrow = "none";
			}
			else
			{
				num2 = shieldDNA_1.method_7(ShieldAttributeType.RechargeDelay);
				ItemCardPanel.smethod_0(ShieldAttributeType.RechargeDelay, list2, ref num2);
				itemElement.arrow = UniUIManager.UniSWFToolClass.smethod_0(shieldDNA_0.method_7(ShieldAttributeType.RechargeDelay), shieldDNA_1.method_7(ShieldAttributeType.RechargeDelay), 10);
			}
			itemElement.iconType = Utility.smethod_5("shield", ShieldAttributeType.RechargeDelay.ToString());
			itemElement.eType = ETipsItemType.ITVA;
			itemElement.title = LocalizedString.smethod_0(new LocalizedString("SC_AttDesc_2"));
			itemTipsData.attributeList.Add(itemElement);
			itemTipsData.brand = UniUIManager.UniSWFToolClass._BrandStringMap[(int)attribute.method_0(ShieldAttributeType.Manufacturer)];
			Dictionary<string, ItemCardDisplayType> dictionary = shieldDNA_0.imethod_0();
			ItemCardPanel.smethod_3(itemTipsData, dictionary);
		}
		return itemTipsData;
	}

	// Token: 0x0600356A RID: 13674 RVA: 0x000F4020 File Offset: 0x000F2220
	public ItemTipsData method_9(ClassModeDNA classModeDNA_0, ClassModeDNA classModeDNA_1 = null)
	{
		ItemTipsData itemTipsData = new ItemTipsData();
		if (classModeDNA_0 != null)
		{
			itemTipsData.name = classModeDNA_0.method_6();
			itemTipsData.nameColor = UniUIManager.UniSWFToolClass.smethod_3(classModeDNA_0.m_rarity);
			itemTipsData.level = classModeDNA_0.m_level;
			itemTipsData.levelColor = UniUIManager.UniSWFToolClass.smethod_5(ServiceWrapperBase<CharacterServiceWrapper>.Instance.method_8(), classModeDNA_0.m_level);
			ItemElement itemElement = new ItemElement();
			if (ServiceWrapperBase<CharacterServiceWrapper>.Instance.method_13().m_type != classModeDNA_0.method_3(classModeDNA_0.m_cmType))
			{
				itemElement.color = Color.red;
			}
			itemElement.value = LocalizedString.smethod_0(new LocalizedString("CC_Class_Requirement")) + LocalizedString.smethod_0(new LocalizedString("CLASS_" + classModeDNA_0.method_3(classModeDNA_0.m_cmType).ToString()));
			itemElement.eType = ETipsItemType.TEXT;
			itemTipsData.attributeList.Add(itemElement);
			List<SkillAttributeConfig> list = classModeDNA_0.method_2();
			foreach (SkillAttributeConfig skillAttributeConfig in list)
			{
				itemElement = new ItemElement();
				string text = string.Empty;
				if (SkillDisplayStore.SkillDisplayStore_0.m_skillDisplaySetup.method_1(skillAttributeConfig.m_attrType) == DisplayType.Percentage)
				{
					text = "P0";
				}
				else if (SkillDisplayStore.SkillDisplayStore_0.m_skillDisplaySetup.method_1(skillAttributeConfig.m_attrType) == DisplayType.RawValue)
				{
					text = "f2";
				}
				float attrValue = skillAttributeConfig.m_attrValue;
				string text2 = attrValue.ToString(text);
				if (attrValue > 0f)
				{
					text2 = Utility.smethod_5("+", text2);
				}
				itemElement.value = text2;
				itemElement.eType = ETipsItemType.TV;
				itemElement.title = LocalizedString.smethod_0(new LocalizedString(skillAttributeConfig.m_attrType.ToString()));
				itemTipsData.attributeList.Add(itemElement);
			}
		}
		return itemTipsData;
	}

	// Token: 0x0600356B RID: 13675 RVA: 0x000F41FC File Offset: 0x000F23FC
	public ItemTipsData method_10(OutfitDNA outfitDNA_0)
	{
		ItemTipsData itemTipsData = new ItemTipsData();
		if (outfitDNA_0 != null)
		{
			itemTipsData.name = LocalizedString.smethod_0(new LocalizedString(outfitDNA_0.m_name));
			itemTipsData.nameColor = Color.white;
			ItemElement itemElement = new ItemElement();
			if (ServiceWrapperBase<CharacterServiceWrapper>.Instance.method_13().method_5() != outfitDNA_0.m_avatarType)
			{
				itemElement.color = Color.red;
			}
			itemElement.value = LocalizedString.smethod_0(new LocalizedString("CC_Class_Requirement")) + LocalizedString.smethod_0(new LocalizedString("CLASS_" + outfitDNA_0.m_avatarType.ToString()));
			itemElement.eType = ETipsItemType.TEXT;
			itemTipsData.attributeList.Add(itemElement);
		}
		return itemTipsData;
	}

	// Token: 0x04002501 RID: 9473
	protected ItemTipsPanel _cardPanel;

	// Token: 0x04002502 RID: 9474
	protected ItemTipsPanel _comparePanel;

	// Token: 0x04002503 RID: 9475
	protected ItemDNA _showItem;

	// Token: 0x04002504 RID: 9476
	protected ItemDNA _compareItem;

	// Token: 0x04002505 RID: 9477
	protected float rightPosX;

	// Token: 0x04002506 RID: 9478
	protected float leftPosX;
}
