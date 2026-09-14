using System;
using Core;
using ns0;
using pumpkin.display;
using pumpkin.events;
using UnityEngine;

// Token: 0x020007FC RID: 2044
public class uniGuildCreateView : GuildCreateView
{
	// Token: 0x06003720 RID: 14112 RVA: 0x00024848 File Offset: 0x00022A48
	public override void vmethod_2()
	{
		base.vmethod_2();
		(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_45("Guild_flow.swf", "Panel_DetailRoot", new FuncLoad(this.method_3));
	}

	// Token: 0x06003721 RID: 14113 RVA: 0x000FCBE0 File Offset: 0x000FADE0
	public override void vmethod_3()
	{
		base.vmethod_3();
		(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_37(this._guildCreatePanel);
		this._guildCreatePanel = null;
		(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_48("Guild_flow.swf");
	}

	// Token: 0x06003722 RID: 14114 RVA: 0x0002487A File Offset: 0x00022A7A
	private void method_3(MovieClip movieClip_0)
	{
		this._guildCreatePanel = new uniGuildCreateView.GuildCreatePanel();
		this._guildCreatePanel.method_0(movieClip_0);
		this._guildCreatePanel.Boolean_0 = false;
	}

	// Token: 0x06003723 RID: 14115 RVA: 0x000248A0 File Offset: 0x00022AA0
	protected override void vmethod_1(bool bool_0, bool bool_1 = false)
	{
		base.vmethod_1(bool_0, bool_1);
		if (bool_0)
		{
			(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_31(this._guildCreatePanel);
		}
		this._guildCreatePanel.Boolean_0 = bool_0;
	}

	// Token: 0x0400263B RID: 9787
	private uniGuildCreateView.GuildCreatePanel _guildCreatePanel;

	// Token: 0x020007FD RID: 2045
	private class GuildCreatePanel : GClass51
	{
		// Token: 0x06003725 RID: 14117 RVA: 0x000FCC30 File Offset: 0x000FAE30
		protected override void vmethod_0()
		{
			base.vmethod_0();
			this.mc_root = this.displayObjectContainer_0 as MovieClip;
			if (this.mc_root == null)
			{
				DebugUtils.LogWarning(LogCategory.GUI, "UIWarning: GuildSearchPanel onInit() 'mc_root' is null! GuildSearchPanel won't work!!!");
				return;
			}
			this.mc_root.visible = false;
			this.mc_CreateBtn = new GClass25();
			this.mc_CreateBtn.method_0(this.mc_root.getChildByName<MovieClip>("mc_total").getChildByName<MovieClip>("mc_create"));
			this.mc_CreateBtn.addEventListener(MouseEvent.CLICK, new EventDispatcher.EventCallback(this.method_11));
			this.mc_CancelBtn = new GClass25();
			this.mc_CancelBtn.method_0(this.mc_root.getChildByName<MovieClip>("mc_total").getChildByName<MovieClip>("mc_cancel"));
			this.mc_CancelBtn.addEventListener(MouseEvent.CLICK, new EventDispatcher.EventCallback(this.method_12));
			this.mc_CloseBtn = new GClass25();
			this.mc_CloseBtn.method_0(this.mc_root.getChildByName<MovieClip>("mc_total").getChildByName<MovieClip>("mcBtnClose"));
			this.mc_CloseBtn.addEventListener(MouseEvent.CLICK, new EventDispatcher.EventCallback(this.method_10));
			this.tf_GuildName = new GClass50();
			this.tf_GuildName.method_0(this.mc_root.getChildByName<MovieClip>("mc_total").getChildByName<MovieClip>("mcNameInput"));
			this.tf_GuildName.Boolean_6 = true;
			this.tf_GuildName.Int32_0 = 16;
			this.tf_GuildName.List_0 = GClass50.list_0;
			this.tf_GuildClaim = new GClass50();
			this.tf_GuildClaim.method_0(this.mc_root.getChildByName<MovieClip>("mc_total").getChildByName<MovieClip>("mcsloganInput"));
			this.tf_GuildClaim.Boolean_6 = true;
			this.tf_GuildClaim.Int32_0 = 30;
			this.tf_GuildClaim.List_0 = GClass50.list_0;
			this.tf_GuildName.Boolean_3 = true;
			this.tf_GuildClaim.Boolean_3 = true;
			this.tf_GuildName.Boolean_2 = false;
			this.tf_GuildClaim.Boolean_2 = false;
			this.tf_GuildName.addEventListener(CEvent.CHANGED, new EventDispatcher.EventCallback(this.method_8));
			this.tf_GuildClaim.addEventListener(CEvent.CHANGED, new EventDispatcher.EventCallback(this.method_8));
			this.mc_QuestCheck = new GClass40();
			this.mc_QuestCheck.method_0(this.mc_root.getChildByName<MovieClip>("mc_total").getChildByName<MovieClip>("mcQuestCheck"));
			this.mc_QuestCheck.bool_5 = true;
			this.mc_QuestCheck.String_1 = "quest";
			this.mc_QuestCheck.Boolean_3 = true;
			this.mc_QuestCheck.addEventListener(GClass53.string_4, new EventDispatcher.EventCallback(this.method_13));
			this.mc_PvECheck = new GClass40();
			this.mc_PvECheck.method_0(this.mc_root.getChildByName<MovieClip>("mc_total").getChildByName<MovieClip>("mcPvECheck"));
			this.mc_PvECheck.bool_5 = true;
			this.mc_PvECheck.String_1 = "pve";
			this.mc_PvECheck.Boolean_3 = true;
			this.mc_PvECheck.addEventListener(GClass53.string_4, new EventDispatcher.EventCallback(this.method_13));
			this.mc_PvPCheck = new GClass40();
			this.mc_PvPCheck.method_0(this.mc_root.getChildByName<MovieClip>("mc_total").getChildByName<MovieClip>("mcPvPCheck"));
			this.mc_PvPCheck.bool_5 = true;
			this.mc_PvPCheck.String_1 = "pvp";
			this.mc_PvPCheck.Boolean_3 = true;
			this.mc_PvPCheck.addEventListener(GClass53.string_4, new EventDispatcher.EventCallback(this.method_13));
			this.mc_SocialCheck = new GClass40();
			this.mc_SocialCheck.method_0(this.mc_root.getChildByName<MovieClip>("mc_total").getChildByName<MovieClip>("mcSocialCheck"));
			this.mc_SocialCheck.bool_5 = true;
			this.mc_SocialCheck.String_1 = "social";
			this.mc_SocialCheck.Boolean_3 = true;
			this.mc_SocialCheck.addEventListener(GClass53.string_4, new EventDispatcher.EventCallback(this.method_13));
		}

		// Token: 0x170002F1 RID: 753
		// (get) Token: 0x06003727 RID: 14119 RVA: 0x000248D4 File Offset: 0x00022AD4
		// (set) Token: 0x06003726 RID: 14118 RVA: 0x000FD054 File Offset: 0x000FB254
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
						MonoSingleton<AppManager>.Instance.method_0().method_0(new GameUIManager.ViewUpdateCB(this.method_15), false);
						this.tf_GuildName.Boolean_2 = true;
						this.tf_GuildClaim.Boolean_2 = false;
						this.tf_GuildName.String_0 = string.Empty;
						this.tf_GuildClaim.String_0 = string.Empty;
						this.mc_QuestCheck.Boolean_3 = true;
						this.mc_PvECheck.Boolean_3 = true;
						this.mc_PvPCheck.Boolean_3 = true;
						this.mc_SocialCheck.Boolean_3 = true;
						this.mc_CreateBtn.Boolean_6 = false;
						this.method_5();
					}
					else
					{
						MonoSingleton<AppManager>.Instance.method_0().method_1(new GameUIManager.ViewUpdateCB(this.method_15));
						this.method_6();
					}
				}
			}
		}

		// Token: 0x06003728 RID: 14120 RVA: 0x000248EB File Offset: 0x00022AEB
		protected void method_5()
		{
			this.mc_root.visible = true;
			MonoSingleton<AppManager>.Instance.method_0().Boolean_2 = false;
			this.mc_root.gotoAndPlay("DetailAppear");
		}

		// Token: 0x06003729 RID: 14121 RVA: 0x000FD12C File Offset: 0x000FB32C
		protected void method_6()
		{
			this.tf_GuildName.Boolean_2 = false;
			this.tf_GuildClaim.Boolean_2 = false;
			this.mc_root.gotoAndPlay("KeyFrame_2");
			this.mc_root.addFrameScript("KeyFrame_3", new EventDispatcher.EventCallback(this.method_7));
		}

		// Token: 0x0600372A RID: 14122 RVA: 0x00024919 File Offset: 0x00022B19
		protected void method_7(CEvent cevent_0)
		{
			this.mc_root.removeEventListener("KeyFrame_3", new EventDispatcher.EventCallback(this.method_7));
			this.mc_root.visible = false;
			(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_37(this);
		}

		// Token: 0x0600372B RID: 14123 RVA: 0x00024959 File Offset: 0x00022B59
		protected void method_8(CEvent cevent_0)
		{
			this.method_9();
		}

		// Token: 0x0600372C RID: 14124 RVA: 0x000FD180 File Offset: 0x000FB380
		private void method_9()
		{
			if (this.method_14() == GuildPreference.None)
			{
				this.mc_CreateBtn.Boolean_6 = false;
				return;
			}
			if (this.tf_GuildName.String_0.Length > 0 && this.tf_GuildClaim.String_0.Length > 0)
			{
				if (!this.mc_CreateBtn.Boolean_6)
				{
					this.mc_CreateBtn.Boolean_6 = true;
				}
			}
			else if (this.mc_CreateBtn.Boolean_6)
			{
				this.mc_CreateBtn.Boolean_6 = false;
			}
		}

		// Token: 0x0600372D RID: 14125 RVA: 0x00024961 File Offset: 0x00022B61
		private void method_10(CEvent cevent_0)
		{
			MonoSingleton<AppManager>.Instance.method_0().vmethod_5<GuildCreateView>().vmethod_4();
		}

		// Token: 0x0600372E RID: 14126 RVA: 0x000FD1FC File Offset: 0x000FB3FC
		private void method_11(CEvent cevent_0)
		{
			if (this.tf_GuildName.String_0 != string.Empty)
			{
				GuildPreference guildPreference = this.method_14();
				GuildManager.smethod_0().method_15(this.tf_GuildName.String_0, this.tf_GuildClaim.String_0, guildPreference);
				MonoSingleton<GuidanceTipsManager>.Instance.method_2("guidance_guild");
			}
		}

		// Token: 0x0600372F RID: 14127 RVA: 0x00024961 File Offset: 0x00022B61
		private void method_12(CEvent cevent_0)
		{
			MonoSingleton<AppManager>.Instance.method_0().vmethod_5<GuildCreateView>().vmethod_4();
		}

		// Token: 0x06003730 RID: 14128 RVA: 0x000FD258 File Offset: 0x000FB458
		private void method_13(CEvent cevent_0)
		{
			if (!(cevent_0.target is GClass25))
			{
				return;
			}
			this.method_9();
		}

		// Token: 0x06003731 RID: 14129 RVA: 0x000FD27C File Offset: 0x000FB47C
		private GuildPreference method_14()
		{
			GuildPreference guildPreference = GuildPreference.None;
			if (this.mc_QuestCheck != null && this.mc_PvECheck != null && this.mc_PvPCheck != null && this.mc_SocialCheck != null)
			{
				if (this.mc_QuestCheck.Boolean_3)
				{
					guildPreference |= GuildPreference.Quest;
				}
				if (this.mc_PvECheck.Boolean_3)
				{
					guildPreference |= GuildPreference.PvE;
				}
				if (this.mc_PvPCheck.Boolean_3)
				{
					guildPreference |= GuildPreference.PvP;
				}
				if (this.mc_SocialCheck.Boolean_3)
				{
					guildPreference |= GuildPreference.Social;
				}
				return guildPreference;
			}
			return GuildPreference.All;
		}

		// Token: 0x06003732 RID: 14130 RVA: 0x000FD2F4 File Offset: 0x000FB4F4
		protected void method_15()
		{
			if (Input.GetKeyDown(KeyCode.Tab))
			{
				if (this.tf_GuildName.method_10())
				{
					this.tf_GuildName.Boolean_2 = false;
					this.tf_GuildClaim.Boolean_2 = true;
				}
				else
				{
					this.tf_GuildClaim.Boolean_2 = false;
					this.tf_GuildName.Boolean_2 = true;
				}
			}
		}

		// Token: 0x0400263C RID: 9788
		public MovieClip mc_root;

		// Token: 0x0400263D RID: 9789
		private GClass25 mc_CreateBtn;

		// Token: 0x0400263E RID: 9790
		private GClass25 mc_CancelBtn;

		// Token: 0x0400263F RID: 9791
		private GClass25 mc_CloseBtn;

		// Token: 0x04002640 RID: 9792
		private GClass50 tf_GuildName;

		// Token: 0x04002641 RID: 9793
		private GClass50 tf_GuildClaim;

		// Token: 0x04002642 RID: 9794
		private GClass40 mc_QuestCheck;

		// Token: 0x04002643 RID: 9795
		private GClass40 mc_PvECheck;

		// Token: 0x04002644 RID: 9796
		private GClass40 mc_PvPCheck;

		// Token: 0x04002645 RID: 9797
		private GClass40 mc_SocialCheck;
	}
}
