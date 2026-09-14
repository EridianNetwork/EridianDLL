using System;
using System.Collections.Generic;
using System.Text;
using ns0;
using pumpkin.display;

// Token: 0x02000858 RID: 2136
public class uniLargeMapView : LargeMapView
{
	// Token: 0x06003A3A RID: 14906 RVA: 0x00026F04 File Offset: 0x00025104
	public override void vmethod_2()
	{
		base.vmethod_2();
		this._bActive = false;
		(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_45("MiniMap.swf", "Panel_LargeMapContainer", new FuncLoad(this.method_3));
	}

	// Token: 0x06003A3B RID: 14907 RVA: 0x00026F3D File Offset: 0x0002513D
	public override void vmethod_3()
	{
		base.vmethod_3();
		(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_37(this._container);
		(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_48("MiniMap.swf");
	}

	// Token: 0x06003A3C RID: 14908 RVA: 0x00110F14 File Offset: 0x0010F114
	private void method_3(MovieClip movieClip_0)
	{
		this._container = new GClass51();
		this._container.method_0(movieClip_0);
		MovieClip childByName = movieClip_0.getChildByName<MovieClip>("mcLargeMapRoot");
		if (childByName != null)
		{
			this._mapRoot = new uniLargeMapView.LargeMapRoot();
			this._mapRoot.MapCategoryTag_0 = UIMapDisplayManager.MapCategoryTag.LargeMap;
			this._mapRoot.Boolean_0 = true;
			this._mapRoot.Boolean_1 = false;
			this._mapRoot.method_0(childByName);
			UIMapDisplayManager.smethod_0().method_3(this._mapRoot);
		}
		this._bActive = true;
		this.vmethod_1(false, false);
	}

	// Token: 0x06003A3D RID: 14909 RVA: 0x00110FA4 File Offset: 0x0010F1A4
	protected override void vmethod_1(bool bool_0, bool bool_1 = false)
	{
		base.vmethod_1(bool_0, bool_1);
		if (bool_0)
		{
			MonoSingleton<AppManager>.Instance.GetComponent<UniUIManager>().method_31(this._container);
			(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).imethod_0("UI_BackMenu_Open_Main");
		}
		else
		{
			MonoSingleton<AppManager>.Instance.GetComponent<UniUIManager>().method_37(this._container);
			(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).imethod_0("UI_BackMenu_Close_Main");
		}
		if (this._container != null)
		{
			if (this._container.DisplayObjectContainer_0 != null)
			{
				this._container.DisplayObjectContainer_0.visible = bool_0;
			}
			if (this._mapRoot != null && this._mapRoot.DisplayObjectContainer_0 != null)
			{
				this._mapRoot.method_8(bool_0);
			}
		}
		if (bool_0)
		{
			MonoSingleton<GuidanceTipsManager>.Instance.method_2("guidance_map");
		}
	}

	// Token: 0x040028D7 RID: 10455
	protected GClass51 _container;

	// Token: 0x040028D8 RID: 10456
	protected MovieClip _largeMapRootMC;

	// Token: 0x040028D9 RID: 10457
	protected uniLargeMapView.LargeMapRoot _mapRoot;

	// Token: 0x02000859 RID: 2137
	protected class LargeMapRoot : UIMapDisplayManager.UIMapRoot
	{
		// Token: 0x06003A40 RID: 14912 RVA: 0x00111074 File Offset: 0x0010F274
		protected override void vmethod_0()
		{
			base.vmethod_0();
			this._MapObjTypeToShow.Clear();
			this._MapObjTypeToShow.Add(UIMapDataManager.MiniMapObjectType.NPC);
			this._MapObjTypeToShow.Add(UIMapDataManager.MiniMapObjectType.TownExit);
			this._MapObjTypeToShow.Add(UIMapDataManager.MiniMapObjectType.WorldMapDevice);
			this._MapObjTypeToShow.Add(UIMapDataManager.MiniMapObjectType.Trigger);
			this._MapObjTypeToShow.Add(UIMapDataManager.MiniMapObjectType.InstanceExitOpen);
			this._MapObjTypeToShow.Add(UIMapDataManager.MiniMapObjectType.InstanceExitClose);
			this._MapObjTypeToShow.Add(UIMapDataManager.MiniMapObjectType.RvEnterence);
			this._MapObjTypeToShow.Add(UIMapDataManager.MiniMapObjectType.RvEnterence_New);
			this._NpcIconToShow.Add(NpcTitleMgr.NPC_ICON_TYPE.NPC_ICON_DONE);
			this._NpcIconToShow.Add(NpcTitleMgr.NPC_ICON_TYPE.NPC_ICON_PROGRESS);
			this._NpcIconToShow.Add(NpcTitleMgr.NPC_ICON_TYPE.NPC_ICON_NEW);
			this._NpcIconToShow.Add(NpcTitleMgr.NPC_ICON_TYPE.NPC_ICON_DAILY_NEW);
			this._NpcIconToShow.Add(NpcTitleMgr.NPC_ICON_TYPE.NPC_ICON_DAILY_DONE);
			this._NpcIconToShow.Add(NpcTitleMgr.NPC_ICON_TYPE.NPC_ICON_SPECIAL_NEW);
			this._NpcIconToShow.Add(NpcTitleMgr.NPC_ICON_TYPE.NPC_ICON_CRAFT);
			this._NpcIconToShow.Add(NpcTitleMgr.NPC_ICON_TYPE.NPC_ICON_SPECIAL_DONE);
			this._NpcIconToShow.Add(NpcTitleMgr.NPC_ICON_TYPE.NPC_ICON_DOC);
			this._NpcIconToShow.Add(NpcTitleMgr.NPC_ICON_TYPE.NPC_ICON_GUILD);
			this._NpcIconToShow.Add(NpcTitleMgr.NPC_ICON_TYPE.NPC_ICON_MAIL);
			this._NpcIconToShow.Add(NpcTitleMgr.NPC_ICON_TYPE.NPC_ICON_MAIL_NEW);
			this._NpcIconToShow.Add(NpcTitleMgr.NPC_ICON_TYPE.NPC_ICON_WAREHOUSE);
			this._NpcIconToShow.Add(NpcTitleMgr.NPC_ICON_TYPE.NPC_ICON_SHOP);
			this._NpcIconToShow.Add(NpcTitleMgr.NPC_ICON_TYPE.NPC_ICON_UPGRADE);
			this._NpcIconToShow.Add(NpcTitleMgr.NPC_ICON_TYPE.NPC_ICON_PVP);
			MovieClip childByName = base.DisplayObjectContainer_0.getChildByName<MovieClip>("mcLegendContainer");
			if (childByName != null)
			{
				for (int i = 0; i < uniLargeMapView.LargeMapRoot.ITEM_COUNT; i++)
				{
					this._legendAry[i] = new uniLargeMapView.MapLegend();
					string text = uniLargeMapView.LargeMapRoot.ITEM_PREFIX + i;
					MovieClip childByName2 = childByName.getChildByName<MovieClip>(text);
					if (childByName2 != null)
					{
						this._legendAry[i].method_0(childByName2);
						childByName2.visible = false;
					}
				}
				this._textMapDesc = childByName.getChildByName<UnityTextField>("textMapDesc");
				if (this._textMapDesc != null)
				{
					this._textMapDesc.text = LocalizedString.smethod_0(new LocalizedString("Map_Control"));
				}
				this._textMapTitle = childByName.getChildByName<UnityTextField>("textMapName");
			}
		}

		// Token: 0x06003A41 RID: 14913 RVA: 0x00111284 File Offset: 0x0010F484
		public override void vmethod_6(string string_1, int int_0, int int_1)
		{
			StringBuilder stringBuilder = new StringBuilder(LocalizedString.smethod_0(new LocalizedString(string_1)));
			if (int_1 > 1)
			{
				stringBuilder.Append(" - ").Append(int_0);
			}
			if (this._textMapTitle != null)
			{
				this._textMapTitle.text = stringBuilder.ToString();
			}
		}

		// Token: 0x06003A42 RID: 14914 RVA: 0x00026FB9 File Offset: 0x000251B9
		public override void vmethod_2(UIMapDataManager.UIMapObject uimapObject_0)
		{
			base.vmethod_2(uimapObject_0);
			this.method_12();
		}

		// Token: 0x06003A43 RID: 14915 RVA: 0x00026FC8 File Offset: 0x000251C8
		public override void vmethod_3(int int_0)
		{
			base.vmethod_3(int_0);
			this.method_12();
		}

		// Token: 0x06003A44 RID: 14916 RVA: 0x00026FD7 File Offset: 0x000251D7
		public override void vmethod_5(int int_0)
		{
			base.vmethod_5(int_0);
			this.method_12();
		}

		// Token: 0x06003A45 RID: 14917 RVA: 0x00026FE6 File Offset: 0x000251E6
		protected override void vmethod_4()
		{
			base.vmethod_4();
			if (this._textMapDesc != null)
			{
				this._textMapDesc.visible = this._bHorizontalDragAble || this._bVerticalDragAble;
			}
		}

		// Token: 0x06003A46 RID: 14918 RVA: 0x001112D4 File Offset: 0x0010F4D4
		protected void method_12()
		{
			HashSet<NpcTitleMgr.NPC_ICON_TYPE> hashSet = new HashSet<NpcTitleMgr.NPC_ICON_TYPE>();
			HashSet<UIMapDataManager.MiniMapObjectType> hashSet2 = new HashSet<UIMapDataManager.MiniMapObjectType>();
			List<UIMapDisplayManager.MapIcon> list = new List<UIMapDisplayManager.MapIcon>();
			foreach (UIMapDisplayManager.MapIcon mapIcon in this._onShowMapIconDic.Values)
			{
				if (this._MapObjTypeToShow.Contains(mapIcon.UIMapObject_0.objInfo.ObjType))
				{
					if (mapIcon.UIMapObject_0.objInfo.ObjType == UIMapDataManager.MiniMapObjectType.NPC)
					{
						if (this._NpcIconToShow.Contains(mapIcon.UIMapObject_0.npcIconType) && !hashSet.Contains(mapIcon.UIMapObject_0.npcIconType))
						{
							list.Add(mapIcon);
							hashSet.Add(mapIcon.UIMapObject_0.npcIconType);
						}
					}
					else if (!hashSet2.Contains(mapIcon.UIMapObject_0.objInfo.ObjType))
					{
						list.Add(mapIcon);
						hashSet2.Add(mapIcon.UIMapObject_0.objInfo.ObjType);
					}
				}
			}
			int i = 0;
			while (i < uniLargeMapView.LargeMapRoot.ITEM_COUNT && i < list.Count)
			{
				if (this._legendAry[i] != null)
				{
					this._legendAry[i].DisplayObjectContainer_0.visible = true;
					this._legendAry[i].method_5(list[i].UIMapObject_0);
				}
				i++;
			}
			while (i < uniLargeMapView.LargeMapRoot.ITEM_COUNT)
			{
				if (this._legendAry[i] != null)
				{
					this._legendAry[i].DisplayObjectContainer_0.visible = false;
				}
				i++;
			}
		}

		// Token: 0x040028DA RID: 10458
		protected static string ITEM_PREFIX = "mcMapLegend_";

		// Token: 0x040028DB RID: 10459
		protected static int ITEM_COUNT = 10;

		// Token: 0x040028DC RID: 10460
		protected uniLargeMapView.MapLegend[] _legendAry = new uniLargeMapView.MapLegend[uniLargeMapView.LargeMapRoot.ITEM_COUNT];

		// Token: 0x040028DD RID: 10461
		protected HashSet<UIMapDataManager.MiniMapObjectType> _MapObjTypeToShow = new HashSet<UIMapDataManager.MiniMapObjectType>();

		// Token: 0x040028DE RID: 10462
		protected HashSet<NpcTitleMgr.NPC_ICON_TYPE> _NpcIconToShow = new HashSet<NpcTitleMgr.NPC_ICON_TYPE>();

		// Token: 0x040028DF RID: 10463
		protected UnityTextField _textMapTitle;

		// Token: 0x040028E0 RID: 10464
		protected UnityTextField _textMapDesc;

		// Token: 0x040028E1 RID: 10465
		protected string _strMapName;
	}

	// Token: 0x0200085A RID: 2138
	protected class MapLegend : GClass51
	{
		// Token: 0x06003A48 RID: 14920 RVA: 0x00111478 File Offset: 0x0010F678
		protected override void vmethod_0()
		{
			base.vmethod_0();
			this._mapIcon = new UIMapDisplayManager.MapIcon();
			MovieClip childByName = base.DisplayObjectContainer_0.getChildByName<MovieClip>("mcIcon");
			if (childByName != null)
			{
				this._mapIcon.method_0(childByName);
			}
			this._textDes = base.DisplayObjectContainer_0.getChildByName<UnityTextField>("textDes");
		}

		// Token: 0x06003A49 RID: 14921 RVA: 0x001114D0 File Offset: 0x0010F6D0
		public void method_5(UIMapDataManager.UIMapObject uimapObject_0)
		{
			if (uimapObject_0 != null && this._mapIcon != null)
			{
				this._mapIcon.method_7(uimapObject_0);
				string text = this.LEGEND_DES_PREFIX;
				if (uimapObject_0.objInfo.ObjType == UIMapDataManager.MiniMapObjectType.NPC)
				{
					string text2 = uimapObject_0.npcIconType.ToString();
					string text3 = "NPC_ICON_";
					string text4 = text2.Replace(text3, string.Empty);
					text += text4;
				}
				else
				{
					text += uimapObject_0.objInfo.ObjType.ToString();
				}
				if (this._textDes != null && text != null)
				{
					this._textDes.text = LocalizedString.smethod_0(new LocalizedString(text));
				}
			}
		}

		// Token: 0x040028E2 RID: 10466
		protected UIMapDisplayManager.MapIcon _mapIcon;

		// Token: 0x040028E3 RID: 10467
		protected UnityTextField _textDes;

		// Token: 0x040028E4 RID: 10468
		protected readonly string LEGEND_DES_PREFIX = "MapLegend_";
	}
}
