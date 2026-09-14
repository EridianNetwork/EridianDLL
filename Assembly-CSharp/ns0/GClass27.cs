using System;
using pumpkin.display;
using pumpkin.events;
using pumpkin.text;
using UnityEngine;

namespace ns0
{
	// Token: 0x02000792 RID: 1938
	public class GClass27 : GClass26
	{
		// Token: 0x06003370 RID: 13168 RVA: 0x000EB948 File Offset: 0x000E9B48
		protected override void vmethod_0()
		{
			base.vmethod_0();
			this.movieClip_0.mouseChildrenEnabled = true;
			MovieClip movieClip = base.DisplayObjectContainer_0 as MovieClip;
			this.movieClip_1 = movieClip.getChildByName<MovieClip>("groupNormal");
			this.movieClip_2 = movieClip.getChildByName<MovieClip>("groupDecided");
			this.movieClip_3 = this.movieClip_1.getChildByName<MovieClip>("mc_Icon");
			this.movieClip_4 = this.movieClip_2.getChildByName<MovieClip>("mc_Icon");
			this.textField_1 = this.movieClip_1.getChildByName<TextField>("tfname");
			this.textField_2 = this.movieClip_2.getChildByName<TextField>("tfname");
			this.textField_3 = this.movieClip_1.getChildByName<TextField>("tflv");
			this.textField_4 = this.movieClip_2.getChildByName<TextField>("tflv");
			this.textField_5 = this.movieClip_2.getChildByName<TextField>("tfinfo");
			this.textField_6 = this.movieClip_1.getChildByName<TextField>("tfposition");
			MovieClip childByName = movieClip.getChildByName<MovieClip>("bt_accept");
			MovieClip childByName2 = movieClip.getChildByName<MovieClip>("bt_reject");
			this.gclass25_0 = new GClass25();
			this.gclass25_1 = new GClass25();
			this.gclass25_0.method_0(childByName);
			this.gclass25_1.method_0(childByName2);
			this.movieClip_1.visible = false;
			this.gclass25_0.Boolean_1 = false;
			this.gclass25_1.Boolean_1 = false;
			this.textField_6.textFormat.color = Color.green;
			this.textField_6.text = LocalizedString.smethod_0(new LocalizedString("Friend_Invitation"));
			this.movieClip_0.addEventListener(CEvent.ENTER_FRAME, new EventDispatcher.EventCallback(this.method_19));
			this.gclass25_0.addEventListener(MouseEvent.CLICK, new EventDispatcher.EventCallback(this.method_21));
			this.gclass25_1.addEventListener(MouseEvent.CLICK, new EventDispatcher.EventCallback(this.method_22));
		}

		// Token: 0x06003371 RID: 13169 RVA: 0x0002188C File Offset: 0x0001FA8C
		protected void method_19(CEvent cevent_0)
		{
			this.vmethod_13();
		}

		// Token: 0x06003372 RID: 13170 RVA: 0x00021894 File Offset: 0x0001FA94
		protected override void vmethod_11()
		{
			base.vmethod_11();
			this.vmethod_13();
		}

		// Token: 0x06003373 RID: 13171 RVA: 0x000218A2 File Offset: 0x0001FAA2
		protected override void vmethod_13()
		{
			if (this.int_0 == -1)
			{
				return;
			}
			if (!FriendManager.smethod_0().method_7(this.int_0))
			{
				return;
			}
			this.movieClip_2.visible = false;
			this.movieClip_1.visible = true;
			this.method_20();
		}

		// Token: 0x06003374 RID: 13172 RVA: 0x000EBB38 File Offset: 0x000E9D38
		protected void method_20()
		{
			if (!(base.String_0 == "over") && !(base.String_0 == "down") && !(base.String_0 == "release"))
			{
				this.gclass25_0.Boolean_1 = false;
				this.gclass25_1.Boolean_1 = false;
			}
			else
			{
				if (!this.gclass25_0.Boolean_1)
				{
					if (FriendManager.smethod_0().method_13())
					{
						this.gclass25_0.Boolean_6 = true;
					}
					else
					{
						this.gclass25_0.Boolean_6 = false;
					}
					this.gclass25_0.Boolean_1 = true;
				}
				if (!this.gclass25_1.Boolean_1)
				{
					this.gclass25_1.Boolean_1 = true;
				}
			}
		}

		// Token: 0x06003375 RID: 13173 RVA: 0x000218DF File Offset: 0x0001FADF
		protected void method_21(CEvent cevent_0)
		{
			FriendManager.smethod_0().method_15(this.int_0);
		}

		// Token: 0x06003376 RID: 13174 RVA: 0x000218F1 File Offset: 0x0001FAF1
		protected void method_22(CEvent cevent_0)
		{
			FriendManager.smethod_0().method_16(this.int_0);
		}

		// Token: 0x06003377 RID: 13175 RVA: 0x000EBBF0 File Offset: 0x000E9DF0
		public override void vmethod_14(int int_1)
		{
			PlayerProperties playerProperties = FriendManager.smethod_0().method_9(int_1);
			if (playerProperties != null)
			{
				this.int_0 = playerProperties.m_id;
				this.textField_1.text = playerProperties.m_name;
				this.textField_2.text = playerProperties.m_name;
				this.textField_3.text = Utility.smethod_5("Lv:", playerProperties.m_level.ToString());
				this.textField_4.text = Utility.smethod_5("Lv:", playerProperties.m_level.ToString());
				this.movieClip_3.gotoAndStop(playerProperties.m_avatarDna.m_type.ToString());
				this.movieClip_4.gotoAndStop(playerProperties.m_avatarDna.m_type.ToString());
			}
		}

		// Token: 0x04002395 RID: 9109
		protected MovieClip movieClip_1;

		// Token: 0x04002396 RID: 9110
		protected MovieClip movieClip_2;

		// Token: 0x04002397 RID: 9111
		protected MovieClip movieClip_3;

		// Token: 0x04002398 RID: 9112
		protected MovieClip movieClip_4;

		// Token: 0x04002399 RID: 9113
		protected GClass25 gclass25_0;

		// Token: 0x0400239A RID: 9114
		protected GClass25 gclass25_1;

		// Token: 0x0400239B RID: 9115
		protected TextField textField_1;

		// Token: 0x0400239C RID: 9116
		protected TextField textField_2;

		// Token: 0x0400239D RID: 9117
		protected TextField textField_3;

		// Token: 0x0400239E RID: 9118
		protected TextField textField_4;

		// Token: 0x0400239F RID: 9119
		protected TextField textField_5;

		// Token: 0x040023A0 RID: 9120
		protected TextField textField_6;
	}
}
