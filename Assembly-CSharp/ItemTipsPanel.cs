using System;
using System.Collections.Generic;
using Core;
using ns0;
using pumpkin.display;
using pumpkin.events;
using UnityEngine;
using XsdSettings;

// Token: 0x020007C8 RID: 1992
public class ItemTipsPanel : GClass51
{
	// Token: 0x06003557 RID: 13655 RVA: 0x000230D3 File Offset: 0x000212D3
	public ItemTipsPanel()
	{
		this._portraitIL = new GClass43();
	}

	// Token: 0x06003558 RID: 13656 RVA: 0x000F2008 File Offset: 0x000F0208
	protected override void vmethod_0()
	{
		base.vmethod_0();
		this.mcSelf = this.displayObjectContainer_0 as MovieClip;
		if (this.mcSelf == null)
		{
			DebugUtils.LogWarning(LogCategory.GUI, "UIWarning: ItemTipsPanel MovieClip missing!!");
			return;
		}
		this.mcSelf.mouseEnabled = false;
		this.mcSelf.stopAll();
		this.vmethod_2();
	}

	// Token: 0x06003559 RID: 13657 RVA: 0x000F2060 File Offset: 0x000F0260
	protected override bool OnWidgetInitialized(ref MovieClip movieClip, Type widgetType)
	{
		bool flag = false;
		string name = movieClip.name;
		switch (name)
		{
		case "mcTop":
			this.mcTop = movieClip;
			flag = false;
			break;
		case "mcBottom":
			this.mcBottom = movieClip;
			flag = false;
			break;
		case "mcPrice":
			this.mcPrice = movieClip;
			this.mcPrice.visible = false;
			this.txMoney = this.mcPrice.getChildByName<UnityTextField>("txMoney");
			this.txMoney.Color_0 = Color.white;
			flag = false;
			break;
		case "mcUpElem0":
			this.mcUpElem = movieClip;
			this._fUpElemHeight = this.mcUpElem.srcHeight;
			this._arrUpItemCache.Add(this.mcUpElem);
			flag = true;
			break;
		case "mcDownElem0":
			this.mcDownElem = movieClip;
			this._fDownElemHeight = this.mcDownElem.srcHeight;
			this._arrDownItemCache.Add(this.mcDownElem);
			flag = true;
			break;
		case "mcBackGround":
			this.mcBackGround = movieClip as BadAssMovieClip;
			flag = true;
			break;
		case "mcBottomBg":
			this.mcBottomBg = movieClip as BadAssMovieClip;
			flag = true;
			break;
		case "mcLevelBg":
			this.mcLevelBg = movieClip;
			flag = true;
			break;
		case "mcTypeBg":
			this.mcTypeBg = movieClip;
			flag = true;
			break;
		case "mcColorCover":
			this.mcColorCover = movieClip as BadAssMovieClip;
			flag = true;
			break;
		case "mcTopContent":
			this.mcTopContent = movieClip;
			this.CONTENT_ORIN_Y = movieClip.y;
			flag = false;
			break;
		}
		return flag;
	}

	// Token: 0x0600355A RID: 13658 RVA: 0x000F2288 File Offset: 0x000F0488
	public void method_5(ItemTipsData itemTipsData_0)
	{
		this._tipsData = itemTipsData_0;
		if (this._tipsData != null)
		{
			base.DisplayObjectContainer_0.visible = true;
			this.txName.Color_0 = this._tipsData.nameColor;
			this.txName.text = this._tipsData.name;
			this.txLevelLabel.Color_0 = this._tipsData.levelColor;
			this.txLevelNumber.Color_0 = this._tipsData.levelColor;
			this.txLevelNumber.text = Utility.smethod_8(this._tipsData.level);
			this.txEquiped.visible = this._tipsData.bEquiped;
			if (this._tipsData.item != null)
			{
				this.mcType.visible = true;
				this.mcType.gotoAndStop(UniUIManager.UniSWFToolClass.smethod_2(this._tipsData.item));
			}
			else
			{
				this.mcType.visible = false;
			}
			float num = 0f;
			if (itemTipsData_0.item != null)
			{
				if (itemTipsData_0.item.method_3(ItemType.Weapon))
				{
					num = this.mcPortrait.srcHeight;
					this.mcPortrait.visible = true;
					this._portraitIL.vmethod_8(MonoSingleton<DNAPortrait>.Instance.method_3(itemTipsData_0.item, 0, 0, TexPostEffectMgr.POST_EFFECT_TYPE.POST_EFFECT_UI));
					this.mcIconRarity.colorTransform = this._tipsData.nameColor;
				}
				else
				{
					this.mcPortrait.visible = false;
					this.mcIconRarity.colorTransform = Color.white;
				}
			}
			this.mcBrand.gotoAndStop(this._tipsData.brand);
			DisplayObject displayObject = this.txLevelLabel;
			bool flag = this._tipsData.level > 0;
			this.mcLevelBg.visible = flag;
			displayObject.visible = flag;
			this.mcLevelBg.gotoAndStop((!this._tipsData.bEquiped) ? "normal" : "equiped");
			if (this._tipsData.nameColor == Color.white)
			{
				DisplayObject displayObject2 = this.mcColorCover;
				this.mcTypeBg.visible = false;
				displayObject2.visible = false;
			}
			else
			{
				DisplayObject displayObject3 = this.mcColorCover;
				this.mcTypeBg.visible = true;
				displayObject3.visible = true;
				this.mcTypeBg.colorTransform = this._tipsData.nameColor;
				this.mcColorCover.colorTransform = this._tipsData.nameColor;
			}
			this.method_6(num);
		}
		else
		{
			base.DisplayObjectContainer_0.visible = false;
		}
	}

	// Token: 0x0600355B RID: 13659 RVA: 0x000F24F4 File Offset: 0x000F06F4
	public void method_6(float float_0 = 0f)
	{
		int num = Mathf.CeilToInt(this._fUpElemHeight);
		int count = this._tipsData.attributeList.Count;
		if (count > this._arrUpItemCache.Count)
		{
			for (int i = this._arrUpItemCache.Count; i < count; i++)
			{
				MovieClip movieClip = this.mcUpElem.newInstance();
				movieClip.name = Utility.smethod_5("mcUpElem", Utility.smethod_8(i));
				this.mcTopContent.addChild(movieClip);
				movieClip.x = this.mcUpElem.x;
				movieClip.y = this.mcUpElem.y + (float)((num - 6) * i);
				this._arrUpItemCache.Add(movieClip);
			}
		}
		for (int j = 0; j < this._arrUpItemCache.Count; j++)
		{
			if (j < count)
			{
				this._arrUpItemCache[j].visible = true;
				this.method_7(this._tipsData.attributeList[j], this._arrUpItemCache[j]);
			}
			else
			{
				this._arrUpItemCache[j].visible = false;
			}
		}
		int count2 = this._tipsData.additionAttList.Count;
		if (count2 > this._arrDownItemCache.Count)
		{
			num = Mathf.CeilToInt(this._fDownElemHeight);
			for (int k = this._arrDownItemCache.Count; k < count2; k++)
			{
				MovieClip movieClip2 = this.mcDownElem.newInstance();
				movieClip2.name = Utility.smethod_5("mcDownElem", Utility.smethod_8(k));
				this.mcBottom.addChild(movieClip2);
				movieClip2.x = this.mcDownElem.x;
				movieClip2.y = this.mcDownElem.y + (float)((num - 6) * k);
				this._arrDownItemCache.Add(movieClip2);
			}
		}
		for (int l = 0; l < this._arrDownItemCache.Count; l++)
		{
			if (l < count2)
			{
				this._arrDownItemCache[l].visible = true;
				this.method_7(this._tipsData.additionAttList[l], this._arrDownItemCache[l]);
			}
			else
			{
				this._arrDownItemCache[l].visible = false;
			}
		}
		this.mcBottom.visible = count2 > 0;
		float num2 = (float)(55 + (num - 6) * count) + float_0;
		this.mcTopContent.y = this.CONTENT_ORIN_Y + float_0;
		this.mcBackGround.Int32_0 = ((count2 <= 0) ? 9 : 6);
		this.mcBackGround.Single_1 = num2 + 50f;
		this.mcBottom.y = this.mcTop.y + num2 + 3f;
		float num3 = this.mcBottom.y + 16f;
		if (this.mcBottom.visible)
		{
			float num4 = (float)((num - 6) * count2);
			this.mcBottomBg.Single_1 = 50f + num4;
			this.mcColorCover.Single_1 = 32f + num4;
			num3 += num4;
		}
		if (this.mcPrice != null)
		{
			this.mcPrice.visible = this._tipsData.price > 0;
			this.mcPrice.y = num3;
			if (this.mcPrice.visible && this.txMoney != null)
			{
				this.txMoney.text = "<color='#1CAAFC'><b>$</b></color><color='#FFCC00'> " + Mathf.FloorToInt(ServiceWrapperBase<ShopServiceWrapper>.Instance.ShopSetup_0.m_soldRatio * (float)this._tipsData.price).ToString() + "</color>";
			}
		}
	}

	// Token: 0x0600355C RID: 13660 RVA: 0x000230FC File Offset: 0x000212FC
	protected void method_7(ItemElement itemElement_0, MovieClip movieClip_0)
	{
		movieClip_0.userData = itemElement_0;
		movieClip_0.gotoAndStop(itemElement_0.eType.ToString());
		movieClip_0.addEventListener(CEvent.ENTER_FRAME, new EventDispatcher.EventCallback(this.method_8));
	}

	// Token: 0x0600355D RID: 13661 RVA: 0x000F2888 File Offset: 0x000F0A88
	protected void method_8(CEvent cevent_0)
	{
		MovieClip movieClip = (MovieClip)cevent_0.currentTarget;
		ItemElement itemElement = (ItemElement)movieClip.userData;
		switch (itemElement.eType)
		{
		case ETipsItemType.ITVA:
			movieClip.getChildByName<MovieClip>("iconType").gotoAndStop(itemElement.iconType);
			movieClip.getChildByName<UnityTextField>("title").text = itemElement.title;
			movieClip.getChildByName<UnityTextField>("value").Color_0 = itemElement.color;
			movieClip.getChildByName<UnityTextField>("value").text = (string)itemElement.value;
			movieClip.getChildByName<MovieClip>("arrow").gotoAndStop(itemElement.arrow);
			break;
		case ETipsItemType.TVA:
			movieClip.getChildByName<UnityTextField>("title").text = itemElement.title;
			movieClip.getChildByName<UnityTextField>("value").Color_0 = itemElement.color;
			movieClip.getChildByName<UnityTextField>("value").text = (string)itemElement.value;
			movieClip.getChildByName<MovieClip>("arrow").gotoAndStop(itemElement.arrow);
			break;
		case ETipsItemType.STAR:
		{
			int num = (int)itemElement.value;
			for (int i = 0; i < 9; i++)
			{
				movieClip.getChildByName("star" + i).visible = i < num;
			}
			break;
		}
		case ETipsItemType.TV:
			movieClip.getChildByName<UnityTextField>("title").text = itemElement.title;
			movieClip.getChildByName<UnityTextField>("value").Color_0 = itemElement.color;
			movieClip.getChildByName<UnityTextField>("value").text = (string)itemElement.value;
			break;
		case ETipsItemType.TEXT:
			movieClip.getChildByName<UnityTextField>("text").Color_0 = itemElement.color;
			movieClip.getChildByName<UnityTextField>("text").text = (string)itemElement.value;
			break;
		}
	}

	// Token: 0x0600355E RID: 13662 RVA: 0x000F2A64 File Offset: 0x000F0C64
	protected virtual void vmethod_2()
	{
		this.txName = this.mcTop.getChildByName<UnityTextField>("txName");
		this.txName.text = string.Empty;
		this.txLevelLabel = this.mcTop.getChildByName<UnityTextField>("txLevelLabel");
		this.txLevelLabel.text = LocalizedString.smethod_0(new LocalizedString("Level"));
		this.txLevelNumber = this.mcTop.getChildByName<UnityTextField>("txLevelNumber");
		this.txEquiped = this.mcTop.getChildByName<UnityTextField>("txEquiped");
		this.mcPortrait = this.mcTop.getChildByName<MovieClip>("mcPortrait");
		if (this.mcPortrait != null)
		{
			this.mcIconRarity = this.mcPortrait.getChildByName<MovieClip>("mcIconRarity");
			this._portraitIL.method_0(this.mcPortrait.getChildByName<MovieClip>("icons"));
		}
		this.mcType = this.mcTop.getChildByName<MovieClip>("mcType");
		this.mcTopContent = this.mcTop.getChildByName<MovieClip>("mcTopContent");
		this.mcBrand = this.mcTopContent.getChildByName<MovieClip>("mcBrand");
	}

	// Token: 0x040024E0 RID: 9440
	protected const string ITEM_MOVIE_NAME = "Movie_attribute";

	// Token: 0x040024E1 RID: 9441
	protected const int TOP_MIN_HEIGHT = 50;

	// Token: 0x040024E2 RID: 9442
	protected MovieClip mcSelf;

	// Token: 0x040024E3 RID: 9443
	protected MovieClip mcTop;

	// Token: 0x040024E4 RID: 9444
	protected MovieClip mcBottom;

	// Token: 0x040024E5 RID: 9445
	protected MovieClip mcPrice;

	// Token: 0x040024E6 RID: 9446
	protected UnityTextField txMoney;

	// Token: 0x040024E7 RID: 9447
	protected UnityTextField txName;

	// Token: 0x040024E8 RID: 9448
	protected UnityTextField txLevelLabel;

	// Token: 0x040024E9 RID: 9449
	protected UnityTextField txLevelNumber;

	// Token: 0x040024EA RID: 9450
	protected UnityTextField txEquiped;

	// Token: 0x040024EB RID: 9451
	protected MovieClip mcType;

	// Token: 0x040024EC RID: 9452
	protected MovieClip mcBrand;

	// Token: 0x040024ED RID: 9453
	protected MovieClip mcPortrait;

	// Token: 0x040024EE RID: 9454
	protected MovieClip mcLevelBg;

	// Token: 0x040024EF RID: 9455
	protected MovieClip mcTypeBg;

	// Token: 0x040024F0 RID: 9456
	protected MovieClip mcTopContent;

	// Token: 0x040024F1 RID: 9457
	protected BadAssMovieClip mcColorCover;

	// Token: 0x040024F2 RID: 9458
	protected BadAssMovieClip mcBackGround;

	// Token: 0x040024F3 RID: 9459
	protected BadAssMovieClip mcBottomBg;

	// Token: 0x040024F4 RID: 9460
	protected GClass43 _portraitIL;

	// Token: 0x040024F5 RID: 9461
	protected MovieClip mcIconRarity;

	// Token: 0x040024F6 RID: 9462
	protected MovieClip mcUpElem;

	// Token: 0x040024F7 RID: 9463
	protected List<MovieClip> _arrUpItemCache = new List<MovieClip>();

	// Token: 0x040024F8 RID: 9464
	protected MovieClip mcDownElem;

	// Token: 0x040024F9 RID: 9465
	protected List<MovieClip> _arrDownItemCache = new List<MovieClip>();

	// Token: 0x040024FA RID: 9466
	protected ItemTipsData _tipsData;

	// Token: 0x040024FB RID: 9467
	protected bool _bEntityDisplaying;

	// Token: 0x040024FC RID: 9468
	protected bool _bShowArrow;

	// Token: 0x040024FD RID: 9469
	protected float CONTENT_ORIN_Y;

	// Token: 0x040024FE RID: 9470
	protected float _fUpElemHeight;

	// Token: 0x040024FF RID: 9471
	protected float _fDownElemHeight;
}
