using System;
using pumpkin.display;
using pumpkin.events;
using pumpkin.text;

namespace ns0
{
	// Token: 0x020007A2 RID: 1954
	public class GClass38 : GClass26
	{
		// Token: 0x060033FC RID: 13308 RVA: 0x000EE4FC File Offset: 0x000EC6FC
		protected override void vmethod_0()
		{
			base.vmethod_0();
			this.movieClip_0.mouseChildrenEnabled = true;
			MovieClip movieClip = base.DisplayObjectContainer_0 as MovieClip;
			this.textField_1 = movieClip.getChildByName<TextField>("tfname");
			this.textField_2 = movieClip.getChildByName<TextField>("tflevel");
			this.textField_3 = movieClip.getChildByName<TextField>("tfhonor");
			this.textField_4 = movieClip.getChildByName<TextField>("tfkilldeath");
			this.textField_5 = movieClip.getChildByName<TextField>("tfwindeath");
			this.gclass25_0 = new GClass25();
			this.gclass25_0.method_0(movieClip.getChildByName<MovieClip>("btn_Invite"));
			this.gclass25_0.addEventListener(MouseEvent.CLICK, new EventDispatcher.EventCallback(this.method_19));
		}

		// Token: 0x060033FD RID: 13309 RVA: 0x00021F71 File Offset: 0x00020171
		protected override void vmethod_11()
		{
			base.vmethod_11();
		}

		// Token: 0x060033FE RID: 13310 RVA: 0x00021F79 File Offset: 0x00020179
		protected void method_19(CEvent cevent_0)
		{
			LobbyManager.smethod_0().method_16(this.int_1);
		}

		// Token: 0x060033FF RID: 13311 RVA: 0x000EE5BC File Offset: 0x000EC7BC
		public override void vmethod_14(int int_2)
		{
			Presence presence = FriendManager.smethod_0().method_2(int_2);
			this.int_1 = presence.mCharacterId;
			if (LobbyManager.smethod_0().method_1())
			{
				this.gclass25_0.Boolean_6 = true;
			}
			else
			{
				this.gclass25_0.Boolean_6 = false;
			}
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
			double num = ((presence.mLossCount != 0) ? ((double)presence.mWinCount / (double)presence.mLossCount) : 0.0);
			if (text.EndsWith("0000"))
			{
				this.textField_5.text = text.Substring(0, text.IndexOf("."));
			}
			else
			{
				this.textField_5.text = text;
			}
		}

		// Token: 0x04002413 RID: 9235
		private int int_1 = -1;

		// Token: 0x04002414 RID: 9236
		protected TextField textField_1;

		// Token: 0x04002415 RID: 9237
		protected TextField textField_2;

		// Token: 0x04002416 RID: 9238
		protected TextField textField_3;

		// Token: 0x04002417 RID: 9239
		protected TextField textField_4;

		// Token: 0x04002418 RID: 9240
		protected TextField textField_5;

		// Token: 0x04002419 RID: 9241
		protected GClass25 gclass25_0;
	}
}
