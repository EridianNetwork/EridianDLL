using System;
using ns0;
using pumpkin.display;

// Token: 0x02000864 RID: 2148
public class uniMiniMapView : MiniMapView
{
	// Token: 0x06003A9B RID: 15003 RVA: 0x000274C7 File Offset: 0x000256C7
	public override void vmethod_2()
	{
		base.vmethod_2();
		this._bActive = false;
		(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_45("MiniMap.swf", "Panel_MiniMapContainer", new FuncLoad(this.method_3));
	}

	// Token: 0x06003A9C RID: 15004 RVA: 0x001130A4 File Offset: 0x001112A4
	private void method_3(MovieClip movieClip_0)
	{
		this._bActive = true;
		this._container = new GClass51();
		this._container.method_0(movieClip_0);
		(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_31(this._container);
		MovieClip childByName = movieClip_0.getChildByName<MovieClip>("mcMiniMapRoot");
		if (childByName != null)
		{
			this._mapRoot = new UIMapDisplayManager.UIMapRoot();
			this._mapRoot.MapCategoryTag_0 = UIMapDisplayManager.MapCategoryTag.MiniMap;
			this._mapRoot.Boolean_0 = false;
			this._mapRoot.Boolean_1 = false;
			this._mapRoot.method_0(childByName);
			UIMapDisplayManager.smethod_0().method_3(this._mapRoot);
		}
	}

	// Token: 0x06003A9D RID: 15005 RVA: 0x00027500 File Offset: 0x00025700
	public override void vmethod_3()
	{
		base.vmethod_3();
		(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_37(this._container);
		(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_48("MiniMap.swf");
	}

	// Token: 0x06003A9E RID: 15006 RVA: 0x00113148 File Offset: 0x00111348
	protected override void vmethod_1(bool bool_0, bool bool_1 = false)
	{
		base.vmethod_1(bool_0, bool_1);
		if (this._container != null)
		{
			if (this._container.DisplayObjectContainer_0 != null)
			{
				this._container.DisplayObjectContainer_0.visible = bool_0;
			}
			if (this._mapRoot != null && this._mapRoot.DisplayObjectContainer_0 != null)
			{
				this._mapRoot.DisplayObjectContainer_0.visible = bool_0;
			}
		}
	}

	// Token: 0x0400291B RID: 10523
	protected GClass51 _container;

	// Token: 0x0400291C RID: 10524
	protected UIMapDisplayManager.UIMapRoot _mapRoot;
}
