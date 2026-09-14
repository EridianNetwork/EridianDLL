using System;
using pumpkin.display;
using pumpkin.events;
using pumpkin.text;

namespace ns0
{
	// Token: 0x020007A3 RID: 1955
	public class GClass39 : GClass26
	{
		// Token: 0x06003400 RID: 13312 RVA: 0x00021F8B File Offset: 0x0002018B
		public GClass39()
		{
			this.dictionary_0.Clear();
		}

		// Token: 0x06003401 RID: 13313 RVA: 0x000EE714 File Offset: 0x000EC914
		protected override void vmethod_0()
		{
			base.vmethod_0();
			this.movieClip_0.mouseChildrenEnabled = true;
			MovieClip movieClip = base.DisplayObjectContainer_0 as MovieClip;
			this.movieClip_1 = movieClip.getChildByName<MovieClip>("roomowner");
			this.movieClip_2 = movieClip.getChildByName<MovieClip>("mc_self");
			this.textField_1 = movieClip.getChildByName<TextField>("tfname");
			this.textField_2 = movieClip.getChildByName<TextField>("tflevel");
			this.textField_3 = movieClip.getChildByName<TextField>("tfhonor");
			this.textField_4 = movieClip.getChildByName<TextField>("tfkilldeath");
			this.textField_5 = movieClip.getChildByName<TextField>("tfwindeath");
			this.gclass25_0 = new GClass25();
			this.gclass25_0.method_0(movieClip.getChildByName<MovieClip>("mc_kick"));
			this.gclass25_0.addEventListener(MouseEvent.CLICK, new EventDispatcher.EventCallback(this.method_21));
			this.gclass25_1 = new GClass25();
			this.gclass25_1.method_0(movieClip.getChildByName<MovieClip>("mc_info"));
			this.gclass25_1.addEventListener(MouseEvent.CLICK, new EventDispatcher.EventCallback(this.method_22));
			this.movieClip_0.addEventListener(CEvent.ENTER_FRAME, new EventDispatcher.EventCallback(this.method_20));
		}

		// Token: 0x06003402 RID: 13314 RVA: 0x000EE854 File Offset: 0x000ECA54
		private void method_19()
		{
			if (this.movieClip_1.visible != LobbyManager.smethod_0().method_2(this.int_1))
			{
				this.movieClip_1.visible = LobbyManager.smethod_0().method_2(this.int_1);
			}
			if (MonoSingleton<Session>.Instance.GetLocalPlayer() != null)
			{
				if (this.movieClip_2.visible != (MonoSingleton<Session>.Instance.GetLocalPlayer().m_characterId == this.int_1))
				{
					this.movieClip_2.visible = MonoSingleton<Session>.Instance.GetLocalPlayer().m_characterId == this.int_1;
				}
			}
			else
			{
				this.movieClip_2.visible = false;
			}
		}

		// Token: 0x06003403 RID: 13315 RVA: 0x00021FA5 File Offset: 0x000201A5
		protected override void vmethod_11()
		{
			base.vmethod_11();
			this.method_19();
		}

		// Token: 0x06003404 RID: 13316 RVA: 0x00021FB3 File Offset: 0x000201B3
		protected void method_20(CEvent cevent_0)
		{
			this.method_19();
		}

		// Token: 0x06003405 RID: 13317 RVA: 0x000EE900 File Offset: 0x000ECB00
		protected void method_21(CEvent cevent_0)
		{
			if (LobbyManager.smethod_0().method_1())
			{
				if (this.int_1 != MonoSingleton<Session>.Instance.GetLocalPlayer().m_characterId)
				{
					LobbyManager.smethod_0().method_22(this.int_1);
				}
				else
				{
					LobbyManager.smethod_0().method_24();
				}
			}
		}

		// Token: 0x06003406 RID: 13318 RVA: 0x00021FBB File Offset: 0x000201BB
		protected void method_22(CEvent cevent_0)
		{
			MonoSingleton<AppManager>.Instance.method_0().vmethod_5<PvPFlowView>().vmethod_6();
			LobbyManager.smethod_0().method_29(this.int_1);
		}

		// Token: 0x06003407 RID: 13319 RVA: 0x000EE94C File Offset: 0x000ECB4C
		public override void vmethod_14(int int_2)
		{
			Presence presence = LobbyManager.smethod_0().method_7(int_2);
			this.movieClip_1.visible = false;
			this.movieClip_2.visible = false;
			if (presence != null)
			{
				this.int_1 = presence.mCharacterId;
				this.textField_1.text = presence.mCharacterName;
				this.textField_2.text = Utility.smethod_5("LV.", Utility.smethod_8(presence.mCharacterLevel));
				this.textField_3.text = Utility.smethod_8(presence.mHonorPoint);
				string text = ((presence.mDeathCount != 0) ? ((double)presence.mKillCount / (double)presence.mDeathCount) : 0.0).ToString("0.0000");
				if (text.EndsWith("0000"))
				{
					this.textField_4.text = text.Substring(0, text.IndexOf("."));
				}
				else
				{
					this.textField_4.text = text;
				}
				text = ((presence.mLossCount != 0) ? ((double)presence.mWinCount / (double)presence.mLossCount) : 0.0).ToString("0.0000");
				if (text.EndsWith("0000"))
				{
					this.textField_5.text = text.Substring(0, text.IndexOf("."));
				}
				else
				{
					this.textField_5.text = text;
				}
				if (LobbyManager.smethod_0().method_2(this.int_1))
				{
					this.movieClip_1.visible = true;
				}
				if (MonoSingleton<Session>.Instance.GetLocalPlayer() != null)
				{
					if (presence.mCharacterId == MonoSingleton<Session>.Instance.GetLocalPlayer().m_characterId)
					{
						this.movieClip_2.visible = true;
						this.gclass25_0.Boolean_6 = false;
					}
				}
				else
				{
					this.gclass25_0.Boolean_6 = false;
				}
				if (!LobbyManager.smethod_0().method_1())
				{
					this.gclass25_0.Boolean_6 = false;
				}
			}
		}

		// Token: 0x0400241A RID: 9242
		private int int_1 = -1;

		// Token: 0x0400241B RID: 9243
		protected MovieClip movieClip_1;

		// Token: 0x0400241C RID: 9244
		protected MovieClip movieClip_2;

		// Token: 0x0400241D RID: 9245
		protected TextField textField_1;

		// Token: 0x0400241E RID: 9246
		protected TextField textField_2;

		// Token: 0x0400241F RID: 9247
		protected TextField textField_3;

		// Token: 0x04002420 RID: 9248
		protected TextField textField_4;

		// Token: 0x04002421 RID: 9249
		protected TextField textField_5;

		// Token: 0x04002422 RID: 9250
		protected GClass25 gclass25_0;

		// Token: 0x04002423 RID: 9251
		protected GClass25 gclass25_1;
	}
}
