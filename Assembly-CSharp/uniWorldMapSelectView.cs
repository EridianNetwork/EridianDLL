using System;
using Core;
using ns0;
using pumpkin.display;

// Token: 0x020008C3 RID: 2243
public class uniWorldMapSelectView : WorldMapSelectView
{
	// Token: 0x06003E10 RID: 15888 RVA: 0x00029EC0 File Offset: 0x000280C0
	public override void vmethod_2()
	{
		base.vmethod_2();
		(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_45("WorldMapSelect.swf", "Whole", new FuncLoad(this.method_5));
	}

	// Token: 0x06003E11 RID: 15889 RVA: 0x001283EC File Offset: 0x001265EC
	public override void vmethod_3()
	{
		base.vmethod_3();
		(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_37(this._worldmapPanel);
		this._worldmapPanel = null;
		(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_48("WorldMapSelect.swf");
	}

	// Token: 0x06003E12 RID: 15890 RVA: 0x00029EF2 File Offset: 0x000280F2
	private void method_5(MovieClip movieClip_0)
	{
		this._worldmapPanel = new uniWorldMapSelectView.WorldMapPanel();
		this._worldmapPanel.method_0(movieClip_0);
		this._worldmapPanel.Boolean_0 = false;
	}

	// Token: 0x06003E13 RID: 15891 RVA: 0x0012843C File Offset: 0x0012663C
	protected override void vmethod_1(bool bool_0, bool bool_1 = false)
	{
		base.vmethod_1(bool_0, bool_1);
		if (bool_0)
		{
			MonoSingleton<AppManager>.Instance.GetComponent<UniUIManager>().method_31(this._worldmapPanel);
			(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).imethod_0("UI_BackMenu_Open_Main");
		}
		else
		{
			MonoSingleton<AppManager>.Instance.GetComponent<UniUIManager>().method_37(this._worldmapPanel);
			(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).imethod_0("UI_BackMenu_Close_Main");
		}
		this._worldmapPanel.Boolean_0 = bool_0;
	}

	// Token: 0x04002BB7 RID: 11191
	private uniWorldMapSelectView.WorldMapPanel _worldmapPanel;

	// Token: 0x020008C4 RID: 2244
	private class WorldMapPanel : GClass51
	{
		// Token: 0x06003E15 RID: 15893 RVA: 0x00029F18 File Offset: 0x00028118
		protected override void vmethod_0()
		{
			base.vmethod_0();
			this.mc_root = this.displayObjectContainer_0 as MovieClip;
			if (this.mc_root == null)
			{
				DebugUtils.LogWarning(LogCategory.GUI, "UIWarning: WorldMapPanel onInit() 'mc_root' is null! WorldMapPanel won't work!!!");
				return;
			}
		}

		// Token: 0x17000346 RID: 838
		// (get) Token: 0x06003E17 RID: 15895 RVA: 0x00029F5B File Offset: 0x0002815B
		// (set) Token: 0x06003E16 RID: 15894 RVA: 0x00029F45 File Offset: 0x00028145
		public virtual bool Boolean_0
		{
			get
			{
				return this.mc_root != null && this.mc_root.visible;
			}
			set
			{
				if (this.mc_root != null)
				{
					this.mc_root.visible = value;
				}
			}
		}

		// Token: 0x04002BB8 RID: 11192
		public MovieClip mc_root;
	}
}
