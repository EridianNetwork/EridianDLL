using System;
using System.Collections.Generic;
using System.Text;
using ns0;
using pumpkin.display;
using pumpkin.events;
using pumpkin.geom;
using pumpkin.text;
using UnityEngine;

// Token: 0x02000865 RID: 2149
public class UIMapDisplayManager
{
	// Token: 0x06003A9F RID: 15007 RVA: 0x0002753B File Offset: 0x0002573B
	protected UIMapDisplayManager()
	{
	}

	// Token: 0x06003AA0 RID: 15008 RVA: 0x00027559 File Offset: 0x00025759
	public static UIMapDisplayManager smethod_0()
	{
		if (UIMapDisplayManager._instance == null)
		{
			UIMapDisplayManager._instance = new UIMapDisplayManager();
		}
		return UIMapDisplayManager._instance;
	}

	// Token: 0x06003AA1 RID: 15009 RVA: 0x00027571 File Offset: 0x00025771
	public void method_0()
	{
		UIMapDataManager.smethod_0().method_15(this._nofiListener);
		if (UIMapDataManager.smethod_0()._curStatus == UIMapDataManager.MinimapStatus.Normal)
		{
			this.method_2();
		}
	}

	// Token: 0x06003AA2 RID: 15010 RVA: 0x00027596 File Offset: 0x00025796
	public void method_1()
	{
		UIMapDataManager.smethod_0().method_16(this._nofiListener);
		this._mapList.Clear();
		this._bInited = false;
	}

	// Token: 0x06003AA3 RID: 15011 RVA: 0x001131AC File Offset: 0x001113AC
	public void OnAddNewMapObj(UIMapDataManager.UIMapObject tarObj)
	{
		foreach (UIMapDisplayManager.UIMapRoot uimapRoot in this._mapList)
		{
			uimapRoot.vmethod_2(tarObj);
		}
	}

	// Token: 0x06003AA4 RID: 15012 RVA: 0x00113200 File Offset: 0x00111400
	public void OnRemoveNewMapObj(UIMapDataManager.UIMapObject tarObj)
	{
		foreach (UIMapDisplayManager.UIMapRoot uimapRoot in this._mapList)
		{
			uimapRoot.vmethod_3(tarObj.objInfo.GetInstanceID());
		}
	}

	// Token: 0x06003AA5 RID: 15013 RVA: 0x0011325C File Offset: 0x0011145C
	public void OnObjInfoUpdated(UIMapDataManager.UIMapObject tarObj)
	{
		foreach (UIMapDisplayManager.UIMapRoot uimapRoot in this._mapList)
		{
			uimapRoot.vmethod_5(tarObj.objInfo.GetInstanceID());
		}
	}

	// Token: 0x06003AA6 RID: 15014 RVA: 0x001132B8 File Offset: 0x001114B8
	public void OnSwitchMapTexture(int iNewIdx)
	{
		UIMapDataManager.MapContext mapContext_ = UIMapDataManager.smethod_0().MapContext_0;
		foreach (UIMapDisplayManager.UIMapRoot uimapRoot in this._mapList)
		{
			if (mapContext_ != null && mapContext_.curMiniMapConfig != null && mapContext_.curMiniMapConfig.MiniMapTexture != null && iNewIdx < mapContext_.curMiniMapConfig.MiniMapTexture.Length)
			{
				Texture2D texture = mapContext_.curMiniMapConfig.MiniMapTexture[iNewIdx].texture;
				if (texture != null)
				{
					uimapRoot.Texture_0 = texture;
				}
			}
		}
	}

	// Token: 0x06003AA7 RID: 15015 RVA: 0x00113360 File Offset: 0x00111560
	protected void method_2()
	{
		UIMapDataManager.MapContext mapContext_ = UIMapDataManager.smethod_0().MapContext_0;
		if (mapContext_ != null && mapContext_.curMiniMapConfig != null)
		{
			foreach (UIMapDisplayManager.UIMapRoot uimapRoot in this._mapList)
			{
				if (uimapRoot.Texture_0 == null)
				{
					uimapRoot.Texture_0 = mapContext_.defaultTexture;
				}
				uimapRoot.Vector2_0 = mapContext_.v2DisplayAreaLocalSize;
				uimapRoot.Single_0 = mapContext_.curMiniMapConfig.Scale;
				uimapRoot.vmethod_6(mapContext_.strInstanceName, mapContext_.iMapIndex, mapContext_.iMapSubPartCnt);
				Dictionary<int, UIMapDataManager.UIMapObject> dictionary = UIMapDataManager.smethod_0().method_17();
				if (dictionary != null)
				{
					foreach (UIMapDataManager.UIMapObject uimapObject in dictionary.Values)
					{
						uimapRoot.vmethod_2(uimapObject);
					}
				}
			}
			this._bInited = true;
		}
	}

	// Token: 0x06003AA8 RID: 15016 RVA: 0x000275BA File Offset: 0x000257BA
	public void OnMapSetup()
	{
		this.method_2();
	}

	// Token: 0x06003AA9 RID: 15017 RVA: 0x0011347C File Offset: 0x0011167C
	public void Update()
	{
		UIMapDataManager.MapContext mapContext_ = UIMapDataManager.smethod_0().MapContext_0;
		if (this._bInited && mapContext_ != null)
		{
			for (int i = 0; i < this._mapList.Count; i++)
			{
				this._mapList[i].Update(mapContext_.v2PlayerPosInProportion, mapContext_.fPlayerDirAngle);
			}
		}
	}

	// Token: 0x06003AAA RID: 15018 RVA: 0x001134D4 File Offset: 0x001116D4
	public void method_3(UIMapDisplayManager.UIMapRoot uimapRoot_0)
	{
		UIMapDataManager.MapContext mapContext_ = UIMapDataManager.smethod_0().MapContext_0;
		if (mapContext_ != null && mapContext_.curMiniMapConfig != null)
		{
			uimapRoot_0.Texture_0 = mapContext_.defaultTexture;
			uimapRoot_0.Vector2_0 = mapContext_.v2DisplayAreaLocalSize;
			uimapRoot_0.Single_0 = mapContext_.curMiniMapConfig.Scale;
			uimapRoot_0.vmethod_6(mapContext_.strInstanceName, mapContext_.iMapIndex, mapContext_.iMapSubPartCnt);
		}
		if (this._bInited)
		{
			Dictionary<int, UIMapDataManager.UIMapObject> dictionary = UIMapDataManager.smethod_0().method_17();
			foreach (UIMapDataManager.UIMapObject uimapObject in dictionary.Values)
			{
				uimapRoot_0.vmethod_2(uimapObject);
			}
		}
		this._mapList.Add(uimapRoot_0);
	}

	// Token: 0x0400291D RID: 10525
	protected static UIMapDisplayManager _instance;

	// Token: 0x0400291E RID: 10526
	protected bool _bInited;

	// Token: 0x0400291F RID: 10527
	protected List<UIMapDisplayManager.UIMapRoot> _mapList = new List<UIMapDisplayManager.UIMapRoot>();

	// Token: 0x04002920 RID: 10528
	protected UIMapDisplayManager.MinimapNotificationListener _nofiListener = new UIMapDisplayManager.MinimapNotificationListener();

	// Token: 0x02000866 RID: 2150
	public enum MapCategoryTag
	{
		// Token: 0x04002922 RID: 10530
		Common,
		// Token: 0x04002923 RID: 10531
		MiniMap,
		// Token: 0x04002924 RID: 10532
		LargeMap,
		// Token: 0x04002925 RID: 10533
		PVPMap
	}

	// Token: 0x02000867 RID: 2151
	public class UIMapRoot : GClass51
	{
		// Token: 0x1700031A RID: 794
		// (set) Token: 0x06003AAC RID: 15020 RVA: 0x000275C2 File Offset: 0x000257C2
		public bool Boolean_0
		{
			set
			{
				this._bDragable = value;
			}
		}

		// Token: 0x1700031B RID: 795
		// (set) Token: 0x06003AAD RID: 15021 RVA: 0x000275CB File Offset: 0x000257CB
		public bool Boolean_1
		{
			set
			{
				this._bNeedAdjust = value;
			}
		}

		// Token: 0x1700031C RID: 796
		// (set) Token: 0x06003AAE RID: 15022 RVA: 0x000275D4 File Offset: 0x000257D4
		public Vector2 Vector2_0
		{
			set
			{
				this._v2WorldSize = value;
			}
		}

		// Token: 0x1700031D RID: 797
		// (set) Token: 0x06003AAF RID: 15023 RVA: 0x000275DD File Offset: 0x000257DD
		public float Single_0
		{
			set
			{
				this._fScale = value / this._fScale;
			}
		}

		// Token: 0x1700031E RID: 798
		// (get) Token: 0x06003AB1 RID: 15025 RVA: 0x000275F6 File Offset: 0x000257F6
		// (set) Token: 0x06003AB0 RID: 15024 RVA: 0x000275ED File Offset: 0x000257ED
		public UIMapDisplayManager.MapCategoryTag MapCategoryTag_0
		{
			get
			{
				return this._categoryTag;
			}
			set
			{
				this._categoryTag = value;
			}
		}

		// Token: 0x06003AB2 RID: 15026 RVA: 0x0011365C File Offset: 0x0011185C
		protected override void vmethod_0()
		{
			base.vmethod_0();
			MovieClip childByName = base.DisplayObjectContainer_0.getChildByName<MovieClip>("mcMapRect");
			if (childByName != null)
			{
				this._mapPanel = new GClass43();
				this._mapPanel.method_0(childByName);
				this._v2MapRectMCSize.x = childByName.width;
				this._v2MapRectMCSize.y = childByName.height;
				this._onShowRectInViewPort.width = childByName.width;
				this._onShowRectInViewPort.height = childByName.height;
			}
			this._mcIconTemplate = base.DisplayObjectContainer_0.getChildByName<MovieClip>("mcIconCollection");
			MovieClip childByName2 = base.DisplayObjectContainer_0.getChildByName<MovieClip>("mcPlayer");
			if (childByName2 != null)
			{
				this._player = new UIMapDisplayManager.MapObject();
				this._player.method_0(childByName2);
			}
			this._mcIconContainer = base.DisplayObjectContainer_0.getChildByName<MovieClip>("mcIconContainer");
			this._textMapName = base.DisplayObjectContainer_0.getChildByName<TextField>("textInstanceName");
			this._mcDragArea = base.DisplayObjectContainer_0.getChildByName<MovieClip>("mcDragArea");
			if (this._mcDragArea != null)
			{
				this._mcDragArea.addEventListener(MouseEvent.MOUSE_DOWN, new EventDispatcher.EventCallback(this.method_5));
				this._mcDragArea.addEventListener(MouseEvent.MOUSE_UP, new EventDispatcher.EventCallback(this.method_6));
			}
		}

		// Token: 0x06003AB3 RID: 15027 RVA: 0x001137A8 File Offset: 0x001119A8
		protected void method_5(CEvent cevent_0)
		{
			if (this._mcDragArea != null)
			{
				this._mcDragArea.addEventListener(MouseEvent.MOUSE_MOVE, new EventDispatcher.EventCallback(this.method_7));
				this._fLastFrameMousePosX = Input.mousePosition.x;
				this._fLastFrameMousePosY = Input.mousePosition.y;
			}
		}

		// Token: 0x06003AB4 RID: 15028 RVA: 0x000275FE File Offset: 0x000257FE
		protected void method_6(CEvent cevent_0)
		{
			if (this._mcDragArea != null)
			{
				this._mcDragArea.removeAllEventListeners(MouseEvent.MOUSE_MOVE);
				this._fLastFrameMousePosX = 0f;
				this._fLastFrameMousePosY = 0f;
			}
		}

		// Token: 0x06003AB5 RID: 15029 RVA: 0x00113800 File Offset: 0x00111A00
		protected void method_7(CEvent cevent_0)
		{
			this._bNeedUpdateViewPort = false;
			Resolution resolution = MonoSingleton<GraphicsMgr>.Instance.method_2();
			if (this._bHorizontalDragAble)
			{
				float num = Input.mousePosition.x - this._fLastFrameMousePosX;
				float num2 = this._onShowRectInViewPort.x + (this._fOffsetX + num);
				float num3 = this._onShowRectInViewPort.x + (this._fOffsetX + num) + this._onShowRectInViewPort.width;
				if (num2 < 0f && num3 > (float)resolution.width)
				{
					this._fOffsetX += num;
					this._bNeedUpdateViewPort = true;
				}
			}
			if (this._bVerticalDragAble)
			{
				float num4 = Input.mousePosition.y - this._fLastFrameMousePosY;
				float num5 = this._onShowRectInViewPort.y + (this._fOffsetY + num4);
				float num6 = this._onShowRectInViewPort.y + (this._fOffsetY + num4) + this._onShowRectInViewPort.height;
				if (num5 < 0f && num6 > (float)resolution.height)
				{
					this._fOffsetY += num4;
					this._bNeedUpdateViewPort = true;
				}
			}
			this._fLastFrameMousePosX = Input.mousePosition.x;
			this._fLastFrameMousePosY = Input.mousePosition.y;
		}

		// Token: 0x06003AB6 RID: 15030 RVA: 0x00113948 File Offset: 0x00111B48
		public void method_8(bool bool_0)
		{
			if (this._bDragable && !this._bNeedAdjust)
			{
				if (!this._bVisible && bool_0)
				{
					Vector2 vector = this.method_9(this._v2PlayerPos);
					float num = 0f;
					float num2 = 0f;
					float num3 = 50f;
					Resolution resolution = MonoSingleton<GraphicsMgr>.Instance.method_2();
					if (vector.x < 0f)
					{
						num = vector.x - num3;
					}
					else if (vector.x > (float)resolution.width)
					{
						num = vector.x - (float)resolution.width + num3;
					}
					if (vector.y < 0f)
					{
						num2 = vector.y - num3;
					}
					else if (vector.y > (float)resolution.height)
					{
						num2 = vector.y - (float)resolution.height + num3;
					}
					this._fOffsetX += num;
					this._fOffsetY += num2;
				}
				if (this._bVisible && !bool_0)
				{
					this._fOffsetX = 0f;
					this._fOffsetY = 0f;
					if (this._mcDragArea != null)
					{
						this._mcDragArea.removeAllEventListeners(MouseEvent.MOUSE_MOVE);
					}
				}
			}
			this._bVisible = bool_0;
		}

		// Token: 0x1700031F RID: 799
		// (get) Token: 0x06003AB8 RID: 15032 RVA: 0x0002762F File Offset: 0x0002582F
		// (set) Token: 0x06003AB7 RID: 15031 RVA: 0x00113A80 File Offset: 0x00111C80
		public Texture Texture_0
		{
			get
			{
				return this._mapTex;
			}
			set
			{
				this._mapTex = value;
				if (this._bDragable && this._mapTex != null)
				{
					if (!this._bNeedAdjust)
					{
						this._onShowRectInViewPort.x = (this._v2MapRectMCSize.x - (float)this._mapTex.width) / 2f;
						this._onShowRectInViewPort.y = (this._v2MapRectMCSize.y - (float)this._mapTex.height) / 2f;
						this._onShowRectInViewPort.height = (float)this._mapTex.height;
						this._onShowRectInViewPort.width = (float)this._mapTex.width;
						Resolution resolution = MonoSingleton<GraphicsMgr>.Instance.method_2();
						this._bHorizontalDragAble = this._mapTex.width > resolution.width;
						this._bVerticalDragAble = this._mapTex.height > resolution.height;
					}
					else
					{
						float num = this._v2MapRectMCSize.x / this._v2MapRectMCSize.y;
						float num2 = (float)this._mapTex.width / (float)this._mapTex.height;
						if (num > num2)
						{
							this._onShowRectInViewPort.height = this._v2MapRectMCSize.y;
							this._onShowRectInViewPort.width = this._v2MapRectMCSize.y * num2;
							this._onShowRectInViewPort.y = 0f;
							this._onShowRectInViewPort.x = (this._v2MapRectMCSize.x - this._onShowRectInViewPort.width) / 2f;
							this._fScale = this._onShowRectInViewPort.height / (float)this._mapTex.height;
						}
						else
						{
							this._onShowRectInViewPort.width = this._v2MapRectMCSize.x;
							this._onShowRectInViewPort.height = this._v2MapRectMCSize.x / num2;
							this._onShowRectInViewPort.x = 0f;
							this._onShowRectInViewPort.y = (this._v2MapRectMCSize.y - this._onShowRectInViewPort.height) / 2f;
							this._fScale = this._onShowRectInViewPort.width / (float)this._mapTex.width;
						}
					}
					this.vmethod_4();
				}
			}
		}

		// Token: 0x06003AB9 RID: 15033 RVA: 0x00113CCC File Offset: 0x00111ECC
		public virtual void vmethod_2(UIMapDataManager.UIMapObject uimapObject_0)
		{
			UIMapDisplayManager.MapIcon mapIcon = this.method_10();
			if (mapIcon != null)
			{
				mapIcon.method_7(uimapObject_0);
				if (!this._onShowMapIconDic.ContainsKey(uimapObject_0.objInfo.GetInstanceID()))
				{
					this._onShowMapIconDic.Add(uimapObject_0.objInfo.GetInstanceID(), mapIcon);
				}
			}
		}

		// Token: 0x06003ABA RID: 15034 RVA: 0x00113D1C File Offset: 0x00111F1C
		public virtual void vmethod_3(int int_0)
		{
			UIMapDisplayManager.MapIcon mapIcon = null;
			this._onShowMapIconDic.TryGetValue(int_0, out mapIcon);
			if (mapIcon != null)
			{
				mapIcon.method_5(false);
				this._onShowMapIconDic.Remove(int_0);
				this._mapIconPool.Add(mapIcon);
			}
		}

		// Token: 0x06003ABB RID: 15035 RVA: 0x0000311B File Offset: 0x0000131B
		protected virtual void vmethod_4()
		{
		}

		// Token: 0x06003ABC RID: 15036 RVA: 0x00113D60 File Offset: 0x00111F60
		public void Update(Vector2 v2PlayerPos, float fPlayerDirAngle)
		{
			this._v2PlayerPos = v2PlayerPos;
			if (this._bVisible)
			{
				this.method_11(v2PlayerPos);
				foreach (KeyValuePair<int, UIMapDisplayManager.MapIcon> keyValuePair in this._onShowMapIconDic)
				{
					UIMapDisplayManager.MapIcon value = keyValuePair.Value;
					if (value.UIMapObject_0 != null)
					{
						Vector2 vector = this.method_9(value.UIMapObject_0.v2LocalPosInProportion);
						value.vmethod_2(vector.x, vector.y);
					}
				}
				if (this._player != null)
				{
					Vector2 vector2 = this.method_9(v2PlayerPos);
					this._player.vmethod_2(vector2.x, vector2.y);
					this._player.method_6(fPlayerDirAngle);
				}
			}
		}

		// Token: 0x06003ABD RID: 15037 RVA: 0x00113E14 File Offset: 0x00112014
		protected Vector2 method_9(Vector2 vector2_0)
		{
			Vector2 vector = new Vector2(0f, 0f);
			vector.x = (vector2_0.x - this._onShowRectInTex.x) / this._onShowRectInTex.width * this._onShowRectInViewPort.width + this._onShowRectInViewPort.x;
			vector.y = (vector2_0.y - this._onShowRectInTex.y) / this._onShowRectInTex.height * this._onShowRectInViewPort.height + this._onShowRectInViewPort.y;
			if (this._bDragable)
			{
				vector.x += this._fOffsetX;
				vector.y -= this._fOffsetY;
			}
			return vector;
		}

		// Token: 0x06003ABE RID: 15038 RVA: 0x00113EE0 File Offset: 0x001120E0
		public UIMapDisplayManager.MapIcon method_10()
		{
			UIMapDisplayManager.MapIcon mapIcon;
			if (this._mapIconPool.Count > 0)
			{
				mapIcon = this._mapIconPool[0];
				this._mapIconPool.Remove(mapIcon);
			}
			else
			{
				if (this._mcIconTemplate == null)
				{
					return null;
				}
				MovieClip movieClip = this._mcIconTemplate.newInstance();
				movieClip.scaleX = this._mcIconTemplate.width / movieClip.width;
				movieClip.scaleY = this._mcIconTemplate.height / movieClip.height;
				if (this._mcIconContainer != null)
				{
					this._mcIconContainer.addChild(movieClip);
				}
				mapIcon = new UIMapDisplayManager.MapIcon();
				mapIcon.Rect_0 = this._onShowRectInViewPort;
				mapIcon.method_0(movieClip);
			}
			return mapIcon;
		}

		// Token: 0x06003ABF RID: 15039 RVA: 0x00113F90 File Offset: 0x00112190
		public virtual void vmethod_5(int int_0)
		{
			UIMapDisplayManager.MapIcon mapIcon = null;
			if (this._onShowMapIconDic.TryGetValue(int_0, out mapIcon))
			{
				mapIcon.method_7(null);
			}
		}

		// Token: 0x06003AC0 RID: 15040 RVA: 0x00113FB8 File Offset: 0x001121B8
		public virtual void vmethod_6(string string_1, int int_0, int int_1)
		{
			if (string_1 != null && string_1.Length != 0)
			{
				StringBuilder stringBuilder = new StringBuilder(LocalizedString.smethod_0(new LocalizedString(string_1)));
				if (int_1 > 1)
				{
					stringBuilder.Append(" - ").Append(int_0);
				}
				if (this._textMapName != null)
				{
					this._textMapName.text = stringBuilder.ToString();
				}
				return;
			}
		}

		// Token: 0x06003AC1 RID: 15041 RVA: 0x00114014 File Offset: 0x00112214
		protected void method_11(Vector2 vector2_0)
		{
			if (this._mapPanel != null && base.DisplayObjectContainer_0 != null)
			{
				Rect onShowRectInViewPort = this._onShowRectInViewPort;
				if (!this._bDragable)
				{
					Vector2 vector = new Vector2(0f, 0f);
					vector.x = this._onShowRectInViewPort.width * this._fScale / this._v2WorldSize.x;
					vector.y = this._onShowRectInViewPort.height * this._fScale / this._v2WorldSize.y;
					float num = vector2_0.x - vector.x / 2f;
					float num2 = vector2_0.y - vector.y / 2f;
					this._onShowRectInTex = new Rect(num, num2, vector.x, vector.y);
				}
				else
				{
					onShowRectInViewPort.x = this._onShowRectInViewPort.x + this._fOffsetX;
					onShowRectInViewPort.y = this._onShowRectInViewPort.y - this._fOffsetY;
					if (this._bNeedUpdateViewPort)
					{
						foreach (UIMapDisplayManager.MapIcon mapIcon in this._onShowMapIconDic.Values)
						{
							mapIcon.Rect_0 = onShowRectInViewPort;
						}
					}
					this._bNeedUpdateViewPort = false;
				}
				this._mapPanel.vmethod_10(this._mapTex, this._onShowRectInTex, onShowRectInViewPort);
				return;
			}
		}

		// Token: 0x04002926 RID: 10534
		protected GClass43 _mapPanel;

		// Token: 0x04002927 RID: 10535
		protected UIMapDisplayManager.MapObject _player;

		// Token: 0x04002928 RID: 10536
		protected MovieClip _mcIconTemplate;

		// Token: 0x04002929 RID: 10537
		protected MovieClip _mcIconContainer;

		// Token: 0x0400292A RID: 10538
		protected MovieClip _mcDragArea;

		// Token: 0x0400292B RID: 10539
		protected TextField _textMapName;

		// Token: 0x0400292C RID: 10540
		protected List<UIMapDisplayManager.MapIcon> _mapIconPool = new List<UIMapDisplayManager.MapIcon>();

		// Token: 0x0400292D RID: 10541
		protected Dictionary<int, UIMapDisplayManager.MapIcon> _onShowMapIconDic = new Dictionary<int, UIMapDisplayManager.MapIcon>();

		// Token: 0x0400292E RID: 10542
		protected Texture _mapTex;

		// Token: 0x0400292F RID: 10543
		protected float _fScale = 1f;

		// Token: 0x04002930 RID: 10544
		protected float _fOffsetX;

		// Token: 0x04002931 RID: 10545
		protected float _fOffsetY;

		// Token: 0x04002932 RID: 10546
		protected float _fLastFrameMousePosX;

		// Token: 0x04002933 RID: 10547
		protected float _fLastFrameMousePosY;

		// Token: 0x04002934 RID: 10548
		protected bool _bDragable;

		// Token: 0x04002935 RID: 10549
		protected bool _bNeedAdjust;

		// Token: 0x04002936 RID: 10550
		protected bool _bNeedUpdateViewPort;

		// Token: 0x04002937 RID: 10551
		protected bool _bVerticalDragAble;

		// Token: 0x04002938 RID: 10552
		protected bool _bHorizontalDragAble;

		// Token: 0x04002939 RID: 10553
		protected bool _bVisible = true;

		// Token: 0x0400293A RID: 10554
		protected Vector2 _v2WorldSize = new Vector2(0f, 0f);

		// Token: 0x0400293B RID: 10555
		protected Vector2 _v2PlayerPos = new Vector2(0f, 0f);

		// Token: 0x0400293C RID: 10556
		protected Vector2 _v2MapRectMCSize = new Vector2(0f, 0f);

		// Token: 0x0400293D RID: 10557
		protected Rect _onShowRectInTex = new Rect(0f, 0f, 1f, 1f);

		// Token: 0x0400293E RID: 10558
		protected Rect _onShowRectInViewPort = new Rect(0f, 0f, 1f, 1f);

		// Token: 0x0400293F RID: 10559
		protected UIMapDisplayManager.MapCategoryTag _categoryTag;
	}

	// Token: 0x02000868 RID: 2152
	public class MapIcon : UIMapDisplayManager.MapObject
	{
		// Token: 0x17000320 RID: 800
		// (set) Token: 0x06003AC3 RID: 15043 RVA: 0x0002765E File Offset: 0x0002585E
		public Rect Rect_0
		{
			set
			{
				this._onShowRectInViewPort = value;
			}
		}

		// Token: 0x17000321 RID: 801
		// (get) Token: 0x06003AC4 RID: 15044 RVA: 0x00027667 File Offset: 0x00025867
		public UIMapDataManager.UIMapObject UIMapObject_0
		{
			get
			{
				return this._iconData;
			}
		}

		// Token: 0x06003AC5 RID: 15045 RVA: 0x00114198 File Offset: 0x00112398
		public void method_7(UIMapDataManager.UIMapObject uimapObject_0 = null)
		{
			if (this._iconData == null || uimapObject_0 != null)
			{
				this._iconData = uimapObject_0;
			}
			if (this._iconData == null)
			{
				return;
			}
			MovieClip movieClip = base.DisplayObjectContainer_0 as MovieClip;
			if (this._iconData != null && movieClip != null)
			{
				movieClip.gotoAndStop(this._iconData.objInfo.ObjType.ToString());
				string text = "mcTarget_" + this._iconData.objInfo.ObjType.ToString();
				this._mcCurIcon = movieClip.getChildByName<MovieClip>(text);
				if (this._mcCurIcon != null)
				{
					this._fCurIconWidth = this._mcCurIcon.width * movieClip.scaleX;
					this._fCurIconHeight = this._mcCurIcon.height * movieClip.scaleY;
					if (this._iconData.objInfo.ObjType == UIMapDataManager.MiniMapObjectType.NPC)
					{
						this._mcCurIcon.gotoAndStop(this._iconData.npcIconType.ToString());
					}
					else if (this._iconData.objInfo.ObjType == UIMapDataManager.MiniMapObjectType.EnemyPlayer)
					{
						if (this._iconData.bIsDead)
						{
							this._mcCurIcon.gotoAndStop("dead");
							this._mcCurIcon.visible = true;
						}
						else
						{
							this._mcCurIcon.gotoAndStop("alive");
							this._mcCurIcon.visible = this._iconData.bIsOnFire;
						}
					}
					else if (this._iconData.objInfo.ObjType == UIMapDataManager.MiniMapObjectType.TeamMate)
					{
						if (this._iconData.bIsDead)
						{
							this._mcCurIcon.gotoAndStop("dead");
						}
						else if (this._iconData.bIsDeadInPvE)
						{
							this._mcCurIcon.gotoAndStop("SecondWind_dead");
						}
						else if (this._iconData.bIsRevived)
						{
							this._mcCurIcon.gotoAndStop("Being Revived");
						}
						else if (this._iconData.bIsDown)
						{
							this._mcCurIcon.gotoAndStop("SecondWind_down");
						}
						else if (this._iconData.bIsCripple)
						{
							this._mcCurIcon.gotoAndStop("SecondWind_crippled");
						}
						else
						{
							this._mcCurIcon.gotoAndStop("alive");
						}
					}
				}
				return;
			}
		}

		// Token: 0x06003AC6 RID: 15046 RVA: 0x0002766F File Offset: 0x0002586F
		public override void vmethod_2(float float_0, float float_1)
		{
			base.vmethod_2(float_0, float_1);
			this.method_8();
		}

		// Token: 0x06003AC7 RID: 15047 RVA: 0x001143D4 File Offset: 0x001125D4
		protected void method_8()
		{
			MovieClip movieClip = base.DisplayObjectContainer_0 as MovieClip;
			if (this._mcCurIcon != null && movieClip != null)
			{
				float x = movieClip.x;
				float y = movieClip.y;
				float num = x;
				float num2 = y;
				float num3 = this._fCurIconWidth / 2f;
				float num4 = this._fCurIconHeight / 2f;
				bool flag;
				if (!(flag = x + num3 <= this._onShowRectInViewPort.x + this._onShowRectInViewPort.width && x - num3 >= this._onShowRectInViewPort.x && y + num4 <= this._onShowRectInViewPort.y + this._onShowRectInViewPort.height && y - num4 >= this._onShowRectInViewPort.y))
				{
					if (this._iconData.objInfo.bAlwaysOnMap)
					{
						float num5 = this._onShowRectInViewPort.width / 2f;
						float num6 = this._onShowRectInViewPort.height / 2f;
						float num7 = x - num5;
						float num8 = y - num6;
						float num9 = Math.Abs(num6 / num8) * num7;
						float num10 = Math.Abs(num5 / num7) * num8;
						float num11 = Mathf.Abs(num7 / num8);
						if (num11 >= num5 / num6)
						{
							num2 = num6 + num10;
						}
						else
						{
							num = num5 + num9;
						}
					}
					if (num < num3)
					{
						num = num3;
					}
					else if (num > this._onShowRectInViewPort.width - num3)
					{
						num = this._onShowRectInViewPort.width - num3;
					}
					if (num2 < num4)
					{
						num2 = num4;
					}
					else if (num2 > this._onShowRectInViewPort.height - num4)
					{
						num2 = this._onShowRectInViewPort.height - num4;
					}
					Matrix matrix = movieClip.getMatrix();
					matrix.tx = num;
					matrix.ty = num2;
					movieClip.setMatrix(matrix);
				}
				movieClip.visible = (flag || this._iconData.objInfo.bAlwaysOnMap) && this._iconData.bIsOnSameLayer;
				return;
			}
		}

		// Token: 0x04002940 RID: 10560
		protected const string _strFramePrefix = "mcTarget_";

		// Token: 0x04002941 RID: 10561
		protected MovieClip _mcCurIcon;

		// Token: 0x04002942 RID: 10562
		protected UIMapDataManager.UIMapObject _iconData;

		// Token: 0x04002943 RID: 10563
		protected float _fCurIconWidth;

		// Token: 0x04002944 RID: 10564
		protected float _fCurIconHeight;

		// Token: 0x04002945 RID: 10565
		protected Rect _onShowRectInViewPort = new Rect(0f, 0f, 1f, 1f);
	}

	// Token: 0x02000869 RID: 2153
	public class MapObject : GClass51
	{
		// Token: 0x06003AC9 RID: 15049 RVA: 0x0002767F File Offset: 0x0002587F
		public virtual void vmethod_2(float float_0, float float_1)
		{
			if (base.DisplayObjectContainer_0 == null)
			{
				return;
			}
			base.DisplayObjectContainer_0.x = float_0;
			base.DisplayObjectContainer_0.y = float_1;
		}

		// Token: 0x06003ACA RID: 15050 RVA: 0x000276A2 File Offset: 0x000258A2
		public void method_5(bool bool_0)
		{
			if (base.DisplayObjectContainer_0 != null)
			{
				base.DisplayObjectContainer_0.visible = bool_0;
			}
		}

		// Token: 0x06003ACB RID: 15051 RVA: 0x000276B8 File Offset: 0x000258B8
		public void method_6(float float_0)
		{
			if (base.DisplayObjectContainer_0 == null)
			{
				return;
			}
			base.DisplayObjectContainer_0.rotation = float_0;
		}
	}

	// Token: 0x0200086A RID: 2154
	protected class MinimapNotificationListener : UIMapDataManager.MinimapNotificationListener
	{
		// Token: 0x06003ACD RID: 15053 RVA: 0x000276CF File Offset: 0x000258CF
		public void OnAddNewMapObject(UIMapDataManager.UIMapObject tarObj)
		{
			UIMapDisplayManager.smethod_0().OnAddNewMapObj(tarObj);
		}

		// Token: 0x06003ACE RID: 15054 RVA: 0x000276DC File Offset: 0x000258DC
		public void OnRemoveMapObject(UIMapDataManager.UIMapObject tarObj)
		{
			UIMapDisplayManager.smethod_0().OnRemoveNewMapObj(tarObj);
		}

		// Token: 0x06003ACF RID: 15055 RVA: 0x000276E9 File Offset: 0x000258E9
		public void OnMapObjectUpdate(UIMapDataManager.UIMapObject tarObj)
		{
			UIMapDisplayManager.smethod_0().OnObjInfoUpdated(tarObj);
		}

		// Token: 0x06003AD0 RID: 15056 RVA: 0x000276F6 File Offset: 0x000258F6
		public void OnSwitchMapTexture(int iNewIdx)
		{
			UIMapDisplayManager.smethod_0().OnSwitchMapTexture(iNewIdx);
		}

		// Token: 0x06003AD1 RID: 15057 RVA: 0x00027703 File Offset: 0x00025903
		public void OnMapSetup()
		{
			UIMapDisplayManager.smethod_0().OnMapSetup();
		}
	}
}
