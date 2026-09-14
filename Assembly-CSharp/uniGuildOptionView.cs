using System;
using Core;
using ns0;
using pumpkin.display;
using pumpkin.events;
using pumpkin.text;

// Token: 0x020007FE RID: 2046
public class uniGuildOptionView : GuildOptionView
{
	// Token: 0x06003734 RID: 14132 RVA: 0x00024980 File Offset: 0x00022B80
	public override void vmethod_2()
	{
		base.vmethod_2();
		(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_45("Guild_flow.swf", "Mc_tips", new FuncLoad(this.method_3));
	}

	// Token: 0x06003735 RID: 14133 RVA: 0x000FD34C File Offset: 0x000FB54C
	public override void vmethod_3()
	{
		base.vmethod_3();
		(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_37(this._guildOptionPanel);
		this._guildOptionPanel = null;
		(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_48("Guild_flow.swf");
	}

	// Token: 0x06003736 RID: 14134 RVA: 0x000249B2 File Offset: 0x00022BB2
	private void method_3(MovieClip movieClip_0)
	{
		this._guildOptionPanel = new uniGuildOptionView.GuildOptionPanel();
		this._guildOptionPanel.method_0(movieClip_0);
		this._guildOptionPanel.Boolean_0 = false;
	}

	// Token: 0x06003737 RID: 14135 RVA: 0x000FD39C File Offset: 0x000FB59C
	protected override void vmethod_1(bool bool_0, bool bool_1 = false)
	{
		base.vmethod_1(bool_0, bool_1);
		if (bool_0)
		{
			MonoSingleton<AppManager>.Instance.GetComponent<UniUIManager>().method_32(this._guildOptionPanel);
		}
		else
		{
			MonoSingleton<AppManager>.Instance.GetComponent<UniUIManager>().method_37(this._guildOptionPanel);
		}
		this._guildOptionPanel.Boolean_0 = bool_0;
	}

	// Token: 0x04002646 RID: 9798
	private uniGuildOptionView.GuildOptionPanel _guildOptionPanel;

	// Token: 0x020007FF RID: 2047
	private class GuildOptionPanel : GClass51
	{
		// Token: 0x06003739 RID: 14137 RVA: 0x000FD3F0 File Offset: 0x000FB5F0
		protected override void vmethod_0()
		{
			base.vmethod_0();
			this.mc_root = this.displayObjectContainer_0 as MovieClip;
			if (this.mc_root == null)
			{
				DebugUtils.LogWarning(LogCategory.GUI, "UIWarning: GuildOptionPanel onInit() 'mc_root' is null! GuildOptionPanel won't work!!!");
				return;
			}
			this.mc_root.stopAll();
			this.mc_root.addEventListener(CEvent.ENTER_FRAME, new EventDispatcher.EventCallback(this.method_9));
			this.mc_Join = new GClass25();
			this.mc_Join.method_0(this.mc_root.getChildByName<MovieClip>("mc_total").getChildByName<MovieClip>("mc_Join"));
			this.mc_Join.addEventListener(MouseEvent.CLICK, new EventDispatcher.EventCallback(this.method_7));
			this.mc_Reject = new GClass25();
			this.mc_Reject.method_0(this.mc_root.getChildByName<MovieClip>("mc_total").getChildByName<MovieClip>("mc_Reject"));
			this.mc_Reject.addEventListener(MouseEvent.CLICK, new EventDispatcher.EventCallback(this.method_8));
			this.tf_Content = this.mc_root.getChildByName<MovieClip>("mc_total").getChildByName<TextField>("mc_content");
		}

		// Token: 0x170002F2 RID: 754
		// (get) Token: 0x0600373B RID: 14139 RVA: 0x00024A12 File Offset: 0x00022C12
		// (set) Token: 0x0600373A RID: 14138 RVA: 0x000249EB File Offset: 0x00022BEB
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
					if (value)
					{
						this.method_5();
					}
					else
					{
						this.method_6();
					}
					this.mc_root.visible = value;
				}
			}
		}

		// Token: 0x0600373C RID: 14140 RVA: 0x000FD50C File Offset: 0x000FB70C
		protected void method_5()
		{
			this.m_Timer.method_4();
			this.m_Timer.Start(180f);
			this.tf_Content.text = GuildManager.smethod_0().m_Invitation.guildMasterName + LocalizedString.smethod_0(new LocalizedString("GUILD_OWNER_INVITATION"));
			this.mc_root.gotoAndPlay("fadein");
		}

		// Token: 0x0600373D RID: 14141 RVA: 0x00024A29 File Offset: 0x00022C29
		protected void method_6()
		{
			GuildManager.smethod_0().m_bCanShowMessage = true;
			this.mc_root.gotoAndPlay("fadeout");
		}

		// Token: 0x0600373E RID: 14142 RVA: 0x00024A46 File Offset: 0x00022C46
		private void method_7(CEvent cevent_0)
		{
			this.m_Timer.method_4();
			GuildManager.smethod_0().method_27(true);
		}

		// Token: 0x0600373F RID: 14143 RVA: 0x00024A5E File Offset: 0x00022C5E
		private void method_8(CEvent cevent_0)
		{
			this.m_Timer.method_4();
			GuildManager.smethod_0().method_27(false);
		}

		// Token: 0x06003740 RID: 14144 RVA: 0x00024A76 File Offset: 0x00022C76
		private void method_9(CEvent cevent_0)
		{
			if (this.m_Timer.method_6() && this.m_Timer.method_7())
			{
				MonoSingleton<AppManager>.Instance.method_0().vmethod_5<GuildOptionView>().Boolean_1 = false;
			}
		}

		// Token: 0x04002647 RID: 9799
		public MovieClip mc_root;

		// Token: 0x04002648 RID: 9800
		private GClass25 mc_Join;

		// Token: 0x04002649 RID: 9801
		private GClass25 mc_Reject;

		// Token: 0x0400264A RID: 9802
		private TextField tf_Content;

		// Token: 0x0400264B RID: 9803
		private Utils.Timer m_Timer = new Utils.Timer();
	}
}
