using System;
using Core;
using ns0;
using pumpkin.display;
using pumpkin.events;
using pumpkin.text;
using XsdSettings;

// Token: 0x02000819 RID: 2073
public class SmallWeaponCardPanel : GClass51
{
	// Token: 0x0600380E RID: 14350 RVA: 0x00103250 File Offset: 0x00101450
	protected override void vmethod_0()
	{
		base.vmethod_0();
		this.mcSelf = this.displayObjectContainer_0 as MovieClip;
		if (this.mcSelf == null)
		{
			DebugUtils.LogWarning(LogCategory.GUI, "UIWarning: SmallWeaponCardPanel MovieClip missing!!");
			return;
		}
		this.mcSelf.visible = false;
		this.mcSelf.stop();
		this.mcRootRoot = this.mcSelf.getChildByName<MovieClip>("mcRoot");
	}

	// Token: 0x0600380F RID: 14351 RVA: 0x000253B2 File Offset: 0x000235B2
	protected virtual void vmethod_2()
	{
		this.mcRoot = this.mcRootRoot.getChildByName<MovieClip>("mcRoot");
	}

	// Token: 0x06003810 RID: 14352 RVA: 0x001032B8 File Offset: 0x001014B8
	private void method_5(CEvent cevent_0)
	{
		this.vmethod_2();
		if (this.mcRoot != null)
		{
			this.vmethod_3();
			if (this.mcName != null)
			{
				this.mcName.text = this._tipsData.name;
				this.mcName.Color_0 = this._tipsData.nameColor;
			}
			this.mcBrand.gotoAndStop(this._tipsData.brand);
			if (this.mcRarity1 != null)
			{
				this.mcRarity1.colorTransform = UniUIManager.UniSWFToolClass.smethod_4(this._showEntity.m_rarity);
			}
			if (this.mcRarity2 != null)
			{
				this.mcRarity2.visible = this._showEntity.m_rarity != WeaponRarity.Common;
				this.mcRarity2.colorTransform = UniUIManager.UniSWFToolClass.smethod_4(this._showEntity.m_rarity);
			}
			int num = 0;
			int count = this._tipsData.attributeList.Count;
			if (0 < count)
			{
				this.mcDamage.Color_0 = this._tipsData.attributeList[num].color;
				this.mcDamage.text = (string)this._tipsData.attributeList[num].value;
				this.mcDamageArrow.gotoAndStop(this._tipsData.attributeList[num].arrow);
				num++;
			}
			if (num < count)
			{
				this.mcAccuracy.Color_0 = this._tipsData.attributeList[num].color;
				this.mcAccuracy.text = (string)this._tipsData.attributeList[num].value;
				this.mcAccuracyArrow.gotoAndStop(this._tipsData.attributeList[num].arrow);
				num++;
			}
			if (num < count)
			{
				this.mcFireRate.Color_0 = this._tipsData.attributeList[num].color;
				this.mcFireRate.text = (string)this._tipsData.attributeList[num].value;
				this.mcFireRateArrow.gotoAndStop(this._tipsData.attributeList[num].arrow);
				num++;
			}
			if (num < count)
			{
				this.mcReloadSpeed.Color_0 = this._tipsData.attributeList[num].color;
				this.mcReloadSpeed.text = (string)this._tipsData.attributeList[num].value;
				this.mcReloadSpeedArrow.gotoAndStop(this._tipsData.attributeList[num].arrow);
				num++;
			}
			if (num < count)
			{
				this.mcClipSize.Color_0 = this._tipsData.attributeList[num].color;
				this.mcClipSize.text = (string)this._tipsData.attributeList[num].value;
				this.mcClipSizeArrow.gotoAndStop(this._tipsData.attributeList[num].arrow);
				num++;
			}
			WeaponAttribute attribute = this._showEntity.m_attribute;
			AttackInfo.ElementalType value = (AttackInfo.ElementalType)(attribute.method_1(AttributeType.ElementalType) as IntAttributeValue).m_value;
			if (value != AttackInfo.ElementalType.None)
			{
				if (num < count && num + 1 < count)
				{
					string text = string.Empty;
					DisplayObject displayObject = this.mcElementDmg;
					this.mcElementCoef.visible = true;
					displayObject.visible = true;
					this.mcElementDmg.gotoAndStop(UniUIManager.UniSWFToolClass._ElementFrameMap[value] + "0");
					this.mcElementCoef.gotoAndStop(UniUIManager.UniSWFToolClass._ElementFrameMap[value] + "0");
					this.txElementDmg.Color_0 = this._tipsData.attributeList[num].color;
					this.txElementDmg.text = (string)this._tipsData.attributeList[num].value;
					text = this._tipsData.attributeList[num++].arrow;
					this.mcElementDmgArrow.visible = text != "none";
					this.mcElementDmgArrow.gotoAndStop(text);
					this.txElementCoef.Color_0 = this._tipsData.attributeList[num].color;
					this.txElementCoef.text = (string)this._tipsData.attributeList[num].value;
					text = this._tipsData.attributeList[num++].arrow;
					this.mcElementCoefArrow.visible = text != "none";
					this.mcElementCoefArrow.gotoAndStop(text);
				}
			}
			else
			{
				DisplayObject displayObject2 = this.mcElementDmgArrow;
				this.mcElementCoef.visible = false;
				this.mcElementDmg.visible = false;
				this.mcElementCoefArrow.visible = false;
				displayObject2.visible = false;
				TextField textField = this.txElementDmg;
				string empty = string.Empty;
				this.txElementCoef.text = empty;
				textField.text = empty;
			}
			DisplayObject displayObject3 = this.mcDamageArrow;
			bool flag = this._bShowArrow;
			this.mcClipSizeArrow.visible = flag;
			flag = flag;
			this.mcReloadSpeedArrow.visible = flag;
			flag = flag;
			this.mcFireRateArrow.visible = flag;
			flag = flag;
			this.mcAccuracyArrow.visible = flag;
			displayObject3.visible = flag;
		}
	}

	// Token: 0x06003811 RID: 14353 RVA: 0x00103824 File Offset: 0x00101A24
	protected virtual void vmethod_3()
	{
		this.mcName = this.mcRoot.getChildByName<UnityTextField>("mcName");
		this.mcDamage = this.mcRoot.getChildByName<UnityTextField>("mcDamage");
		this.mcAccuracy = this.mcRoot.getChildByName<UnityTextField>("mcAccuracy");
		this.mcFireRate = this.mcRoot.getChildByName<UnityTextField>("mcFireRate");
		this.mcReloadSpeed = this.mcRoot.getChildByName<UnityTextField>("mcReloadSpeed");
		this.mcClipSize = this.mcRoot.getChildByName<UnityTextField>("mcClipSize");
		this.mcDamageArrow = this.mcRoot.getChildByName<MovieClip>("mcDamageArrow");
		this.mcAccuracyArrow = this.mcRoot.getChildByName<MovieClip>("mcAccuracyArrow");
		this.mcFireRateArrow = this.mcRoot.getChildByName<MovieClip>("mcFireRateArrow");
		this.mcReloadSpeedArrow = this.mcRoot.getChildByName<MovieClip>("mcReloadSpeedArrow");
		this.mcClipSizeArrow = this.mcRoot.getChildByName<MovieClip>("mcClipSizeArrow");
		this.mcBrand = this.mcRoot.getChildByName<MovieClip>("gunbrand");
		this.txElementDmg = this.mcRoot.getChildByName<UnityTextField>("txElementDmg");
		this.mcElementDmg = this.mcRoot.getChildByName<MovieClip>("mcElementDmg");
		this.mcElementDmgArrow = this.mcRoot.getChildByName<MovieClip>("mcElementDmgArrow");
		this.txElementCoef = this.mcRoot.getChildByName<UnityTextField>("txElementCoef");
		this.mcElementCoef = this.mcRoot.getChildByName<MovieClip>("mcElementCoef");
		this.mcElementCoefArrow = this.mcRoot.getChildByName<MovieClip>("mcElementCoefArrow");
		MovieClip movieClip = this.mcRoot.getChildByName<MovieClip>("weapontype");
		if (movieClip != null)
		{
			this.mcRarity1 = movieClip.getChildAt(0) as Sprite;
		}
		movieClip = this.mcRoot.getChildByName<MovieClip>("weapontype_d");
		if (movieClip != null)
		{
			this.mcRarity2 = movieClip.getChildAt(0) as Sprite;
		}
	}

	// Token: 0x06003812 RID: 14354 RVA: 0x00103A0C File Offset: 0x00101C0C
	private void method_6(CEvent cevent_0)
	{
		this.mcSelf.visible = false;
		this.mcRootRoot.removeAllEventListeners(CEvent.ENTER_FRAME);
		this._showEntity = null;
		this._compareEntity = null;
		this._bEntityDisplaying = this._compareEntity != null;
		this._bShowArrow = false;
	}

	// Token: 0x06003813 RID: 14355 RVA: 0x000253CA File Offset: 0x000235CA
	private void method_7(CEvent cevent_0)
	{
		if (this._bShowArrow)
		{
			this.mcRootRoot.stop();
		}
	}

	// Token: 0x06003814 RID: 14356 RVA: 0x00103A60 File Offset: 0x00101C60
	public virtual void vmethod_4(WeaponDNA weaponDNA_0, WeaponDNA weaponDNA_1 = null)
	{
		if (weaponDNA_0 == null && weaponDNA_1 == null)
		{
			if (this._bEntityDisplaying || this._compareEntity != null)
			{
				this.method_8();
			}
			return;
		}
		if (weaponDNA_1 == null && this._bShowArrow)
		{
			return;
		}
		if (this._showEntity == weaponDNA_0 && this._compareEntity == weaponDNA_1)
		{
			return;
		}
		this._showEntity = weaponDNA_0;
		this._compareEntity = weaponDNA_1;
		this._bEntityDisplaying = this._compareEntity != null;
		this.mcSelf.visible = true;
		this._bShowArrow = weaponDNA_1 != null;
		if (weaponDNA_1 != null && weaponDNA_0 == null)
		{
			this._showEntity = weaponDNA_1;
			this._compareEntity = weaponDNA_0;
			this._bEntityDisplaying = this._compareEntity != null;
			this._bShowArrow = false;
		}
		this._tipsData = ItemCardPanel.smethod_2(this._showEntity, this._compareEntity, true);
		this.mcRootRoot.addEventListener(CEvent.ENTER_FRAME, new EventDispatcher.EventCallback(this.method_5));
		this.mcRootRoot.addFrameScript("off", new EventDispatcher.EventCallback(this.method_6));
		if (this._bShowArrow)
		{
			this.mcRootRoot.addFrameScript("AnimationEnd", new EventDispatcher.EventCallback(this.method_7));
		}
		this.mcRootRoot.gotoAndPlay("in");
	}

	// Token: 0x06003815 RID: 14357 RVA: 0x00103B98 File Offset: 0x00101D98
	public void method_8()
	{
		this._showEntity = null;
		this._compareEntity = null;
		this._bEntityDisplaying = this._compareEntity != null;
		this._bShowArrow = false;
		this.mcRootRoot.removeAllEventListeners(CEvent.ENTER_FRAME);
		this.mcRootRoot.addFrameScript("off", new EventDispatcher.EventCallback(this.method_6));
		this.mcRootRoot.gotoAndPlay("out");
	}

	// Token: 0x04002716 RID: 10006
	protected MovieClip mcSelf;

	// Token: 0x04002717 RID: 10007
	protected MovieClip mcRootRoot;

	// Token: 0x04002718 RID: 10008
	protected MovieClip mcRoot;

	// Token: 0x04002719 RID: 10009
	protected UnityTextField mcDamage;

	// Token: 0x0400271A RID: 10010
	protected UnityTextField mcAccuracy;

	// Token: 0x0400271B RID: 10011
	protected UnityTextField mcFireRate;

	// Token: 0x0400271C RID: 10012
	protected UnityTextField mcReloadSpeed;

	// Token: 0x0400271D RID: 10013
	protected UnityTextField mcClipSize;

	// Token: 0x0400271E RID: 10014
	protected MovieClip mcDamageArrow;

	// Token: 0x0400271F RID: 10015
	protected MovieClip mcAccuracyArrow;

	// Token: 0x04002720 RID: 10016
	protected MovieClip mcFireRateArrow;

	// Token: 0x04002721 RID: 10017
	protected MovieClip mcReloadSpeedArrow;

	// Token: 0x04002722 RID: 10018
	protected MovieClip mcClipSizeArrow;

	// Token: 0x04002723 RID: 10019
	protected UnityTextField txElementDmg;

	// Token: 0x04002724 RID: 10020
	protected MovieClip mcElementDmg;

	// Token: 0x04002725 RID: 10021
	protected MovieClip mcElementDmgArrow;

	// Token: 0x04002726 RID: 10022
	protected UnityTextField txElementCoef;

	// Token: 0x04002727 RID: 10023
	protected MovieClip mcElementCoef;

	// Token: 0x04002728 RID: 10024
	protected MovieClip mcElementCoefArrow;

	// Token: 0x04002729 RID: 10025
	protected MovieClip mcBrand;

	// Token: 0x0400272A RID: 10026
	protected UnityTextField mcName;

	// Token: 0x0400272B RID: 10027
	protected Sprite mcRarity1;

	// Token: 0x0400272C RID: 10028
	protected Sprite mcRarity2;

	// Token: 0x0400272D RID: 10029
	protected bool _bEntityDisplaying;

	// Token: 0x0400272E RID: 10030
	protected WeaponDNA _showEntity;

	// Token: 0x0400272F RID: 10031
	protected WeaponDNA _compareEntity;

	// Token: 0x04002730 RID: 10032
	protected bool _bShowArrow;

	// Token: 0x04002731 RID: 10033
	protected ItemTipsData _tipsData;
}
