using System;
using Core;
using ns0;
using pumpkin.display;
using pumpkin.events;
using pumpkin.text;
using XsdSettings;

// Token: 0x02000861 RID: 2145
public class uniMatchMakingView : MatchMakingView
{
	// Token: 0x17000317 RID: 791
	// (get) Token: 0x06003A87 RID: 14983 RVA: 0x00027320 File Offset: 0x00025520
	public override bool Boolean_0
	{
		get
		{
			return this._bActive && this._matchmakingPanel != null;
		}
	}

	// Token: 0x06003A88 RID: 14984 RVA: 0x00027339 File Offset: 0x00025539
	public override void vmethod_2()
	{
		base.vmethod_2();
		(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_45("match_making.swf", "NPCAnima", new FuncLoad(this.method_3));
	}

	// Token: 0x06003A89 RID: 14985 RVA: 0x00112D18 File Offset: 0x00110F18
	public override void vmethod_3()
	{
		base.vmethod_3();
		base.method_0(false);
		(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_37(this._matchmakingPanel);
		(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_37(this._blackPanel);
		this._matchmakingPanel = null;
		this._blackPanel = null;
		(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_48("match_making.swf");
		(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).Boolean_2 = true;
	}

	// Token: 0x06003A8A RID: 14986 RVA: 0x0002736B File Offset: 0x0002556B
	private void method_3(MovieClip movieClip_0)
	{
		this._matchmakingPanel = new uniMatchMakingView.MatchMakingPanel();
		this._matchmakingPanel.method_0(movieClip_0);
		this._blackPanel = new uniMatchMakingView.BlackPanel();
		this._blackPanel.method_0(new MovieClip("CommonLib.swf:black_bg"));
	}

	// Token: 0x06003A8B RID: 14987 RVA: 0x00112DA4 File Offset: 0x00110FA4
	protected override void vmethod_1(bool bool_0, bool bool_1 = false)
	{
		DebugUtils.Log(LogCategory.GUI, string.Concat(new string[]
		{
			"uniMatchMakingView.vmethod_1 bool_0=",
			bool_0.ToString(),
			" bool_1=",
			bool_1.ToString(),
			" panel=",
			(this._matchmakingPanel == null) ? "NULL" : "ok",
			" gameMode=",
			this.m_gameMode.ToString()
		}));
		base.vmethod_1(bool_0, bool_1);
		if (bool_0)
		{
			(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_31(this._blackPanel);
			(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_31(this._matchmakingPanel);
		}
		else
		{
			(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_37(this._blackPanel);
		}
		if (this._matchmakingPanel != null && !bool_1)
		{
			if (bool_0)
			{
				MonoSingleton<AppManager>.Instance.method_0().vmethod_5<PauseMenuView>().Boolean_0 = false;
				MonoSingleton<AppManager>.Instance.GetComponent<GameUIManager>().Boolean_2 = false;
				if (this.m_gameMode == GamemodeType.GamemodePvE)
				{
					TownBehaviour.smethod_2();
				}
				else
				{
					TownBehaviour.smethod_0();
				}
			}
			else
			{
				MonoSingleton<AppManager>.Instance.method_0().vmethod_5<PauseMenuView>().Boolean_0 = true;
				MonoSingleton<AppManager>.Instance.GetComponent<GameUIManager>().Boolean_2 = true;
				if (this.m_gameMode == GamemodeType.GamemodePvE)
				{
					TownBehaviour.smethod_3();
				}
				else
				{
					TownBehaviour.smethod_1();
				}
			}
			this._matchmakingPanel.Boolean_0 = bool_0;
		}
	}

	// Token: 0x06003A8C RID: 14988 RVA: 0x000273A6 File Offset: 0x000255A6
	public override void vmethod_5()
	{
		base.vmethod_5();
		if (this._matchmakingPanel != null)
		{
			this._matchmakingPanel.method_5();
		}
	}

	// Token: 0x06003A8D RID: 14989 RVA: 0x000273C1 File Offset: 0x000255C1
	public override void vmethod_6()
	{
		DebugUtils.Log(LogCategory.GUI, "uniMatchMakingView.vmethod_6 panel=" + ((this._matchmakingPanel == null) ? "NULL" : "ok"));
		if (this._matchmakingPanel != null)
		{
			this._matchmakingPanel.method_7();
			TownBehaviour.smethod_1();
		}
	}

	// Token: 0x04002916 RID: 10518
	private uniMatchMakingView.MatchMakingPanel _matchmakingPanel;

	// Token: 0x04002917 RID: 10519
	private uniMatchMakingView.BlackPanel _blackPanel;

	// Token: 0x02000862 RID: 2146
	private class BlackPanel : GClass51
	{
		// Token: 0x17000318 RID: 792
		// (get) Token: 0x06003A90 RID: 14992 RVA: 0x00027415 File Offset: 0x00025615
		// (set) Token: 0x06003A8F RID: 14991 RVA: 0x000273FF File Offset: 0x000255FF
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

		// Token: 0x06003A91 RID: 14993 RVA: 0x00112F14 File Offset: 0x00111114
		protected override void vmethod_0()
		{
			base.vmethod_0();
			this.mcSelf = this.displayObjectContainer_0 as MovieClip;
			if (this.mcSelf == null)
			{
				DebugUtils.LogWarning(LogCategory.GUI, "UIWarning: MatchMakingPanel onInit() 'mcSelf' is null! MatchMakingPanel won't work!!!");
				return;
			}
			DisplayObject displayObject = this.mcSelf;
			float num = 512f;
			this.mcSelf.scaleY = num;
			displayObject.scaleX = num;
			DisplayObject displayObject2 = this.mcSelf;
			num = -256f;
			this.mcSelf.y = num;
			displayObject2.x = num;
			this.mcSelf.mouseEnabled = true;
			this.mcSelf.alpha = 0.5f;
			this.mcSelf.visible = true;
		}

		// Token: 0x04002918 RID: 10520
		protected MovieClip mcSelf;
	}

	// Token: 0x02000863 RID: 2147
	private class MatchMakingPanel : GClass51
	{
		// Token: 0x17000319 RID: 793
		// (get) Token: 0x06003A94 RID: 14996 RVA: 0x00027467 File Offset: 0x00025667
		// (set) Token: 0x06003A93 RID: 14995 RVA: 0x0002742C File Offset: 0x0002562C
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
					if (value)
					{
						MonoSingleton<AppManager>.Instance.GetComponent<GameUIManager>().Boolean_2 = false;
						this.method_5();
					}
					else
					{
						MonoSingleton<AppManager>.Instance.GetComponent<GameUIManager>().Boolean_2 = true;
						this.method_6();
					}
				}
			}
		}

		// Token: 0x06003A95 RID: 14997 RVA: 0x00112FB0 File Offset: 0x001111B0
		protected override void vmethod_0()
		{
			base.vmethod_0();
			this.mcSelf = this.displayObjectContainer_0 as MovieClip;
			if (this.mcSelf == null)
			{
				DebugUtils.LogWarning(LogCategory.GUI, "UIWarning: MatchMakingPanel onInit() 'mcSelf' is null! MatchMakingPanel won't work!!!");
				return;
			}
			this._MessageField = this.mcSelf.getChildByName<MovieClip>("mcNPCtalkframe").getChildByName<TextField>("textDescription");
			this._MessageField.text = LocalizedString.smethod_0(new LocalizedString("Matchmaking_searhing_remind"));
			this.mcSelf.stop();
		}

		// Token: 0x06003A96 RID: 14998 RVA: 0x0002747E File Offset: 0x0002567E
		public void method_5()
		{
			this.mcSelf.gotoAndPlay("fadein");
		}

		// Token: 0x06003A97 RID: 14999 RVA: 0x00027490 File Offset: 0x00025690
		private void method_6()
		{
			this.mcSelf.gotoAndPlay("fadeout");
			this.mcSelf.addFrameScript("fadeoutEnd", new EventDispatcher.EventCallback(this.method_8));
		}

		// Token: 0x06003A98 RID: 15000 RVA: 0x0000311B File Offset: 0x0000131B
		public void method_7()
		{
		}

		// Token: 0x06003A99 RID: 15001 RVA: 0x00113030 File Offset: 0x00111230
		private void method_8(CEvent cevent_0)
		{
			this.mcSelf.removeFrameScript("fadeoutEnd", new EventDispatcher.EventCallback(this.method_8));
			MonoSingleton<AppManager>.Instance.GetComponent<GameUIManager>().Boolean_0 = false;
			(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_37(this);
			if (!(MonoSingleton<Session>.Instance != null) || !MonoSingleton<Session>.Instance.method_16())
			{
				MonoSingleton<GameFlowManager>.Instance.method_7();
			}
		}

		// Token: 0x04002919 RID: 10521
		protected MovieClip mcSelf;

		// Token: 0x0400291A RID: 10522
		private TextField _MessageField;
	}
}
