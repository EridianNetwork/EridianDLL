using System;
using pumpkin.display;
using pumpkin.events;
using pumpkin.text;
using UnityEngine;

namespace ns0
{
	// Token: 0x02000796 RID: 1942
	public class GClass31 : GClass26
	{
		// Token: 0x0600338E RID: 13198 RVA: 0x000EC8B4 File Offset: 0x000EAAB4
		protected override void vmethod_0()
		{
			base.vmethod_0();
			this.movieClip_0.mouseChildrenEnabled = true;
			MovieClip movieClip = base.DisplayObjectContainer_0 as MovieClip;
			this.movieClip_1 = movieClip.getChildByName<MovieClip>("groupNormal");
			this.movieClip_2 = movieClip.getChildByName<MovieClip>("groupDecided");
			this.textField_1 = this.movieClip_1.getChildByName<TextField>("tflv");
			this.textField_2 = this.movieClip_1.getChildByName<TextField>("tfname");
			this.textField_3 = this.movieClip_1.getChildByName<TextField>("tfposition");
			this.textField_1.text = string.Empty;
			this.textField_2.text = string.Empty;
			this.textField_3.text = string.Empty;
			this.textField_4 = this.movieClip_2.getChildByName<TextField>("tflv");
			this.textField_5 = this.movieClip_2.getChildByName<TextField>("tfname");
			this.textField_6 = this.movieClip_2.getChildByName<TextField>("tfinfo");
			this.textField_4.text = string.Empty;
			this.textField_5.text = string.Empty;
			this.textField_6.text = string.Empty;
			this.gclass25_0 = new GClass25();
			this.gclass25_0.method_0(movieClip.getChildByName<MovieClip>("bt_accept"));
			this.gclass25_0.addEventListener(MouseEvent.CLICK, new EventDispatcher.EventCallback(this.method_20));
			this.gclass25_1 = new GClass25();
			this.gclass25_1.method_0(movieClip.getChildByName<MovieClip>("bt_reject"));
			this.gclass25_1.addEventListener(MouseEvent.CLICK, new EventDispatcher.EventCallback(this.method_21));
			this.movieClip_0.addEventListener(CEvent.ENTER_FRAME, new EventDispatcher.EventCallback(this.method_19));
		}

		// Token: 0x0600338F RID: 13199 RVA: 0x000219C0 File Offset: 0x0001FBC0
		protected override void vmethod_11()
		{
			base.vmethod_11();
			this.vmethod_13();
		}

		// Token: 0x06003390 RID: 13200 RVA: 0x000219CE File Offset: 0x0001FBCE
		protected void method_19(CEvent cevent_0)
		{
			this.vmethod_13();
		}

		// Token: 0x06003391 RID: 13201 RVA: 0x000ECA80 File Offset: 0x000EAC80
		protected override void vmethod_13()
		{
			if (this.applicationStatus_0 == GuildManager.ApplicationStatus.e_WaitingForDecide)
			{
				this.movieClip_1.visible = true;
				this.movieClip_2.visible = false;
				this.gclass25_0.Boolean_1 = true;
				this.gclass25_1.Boolean_1 = true;
			}
			else
			{
				this.movieClip_1.visible = false;
				this.movieClip_2.visible = true;
				this.gclass25_0.Boolean_1 = false;
				this.gclass25_1.Boolean_1 = false;
			}
		}

		// Token: 0x06003392 RID: 13202 RVA: 0x000219D6 File Offset: 0x0001FBD6
		private void method_20(CEvent cevent_0)
		{
			GuildManager.smethod_0().method_28(this.int_1, true);
		}

		// Token: 0x06003393 RID: 13203 RVA: 0x000219E9 File Offset: 0x0001FBE9
		private void method_21(CEvent cevent_0)
		{
			GuildManager.smethod_0().method_28(this.int_1, false);
		}

		// Token: 0x06003394 RID: 13204 RVA: 0x000ECAF8 File Offset: 0x000EACF8
		public override void vmethod_14(int int_2)
		{
			Presence presence = GuildManager.smethod_0().method_70(int_2);
			GuildManager.ApplicationStatus applicationStatus = GuildManager.smethod_0().method_75(int_2);
			if (presence != null)
			{
				this.applicationStatus_0 = applicationStatus;
				this.int_1 = presence.mCharacterId;
				if (applicationStatus == GuildManager.ApplicationStatus.e_WaitingForDecide)
				{
					this.movieClip_1.visible = true;
					this.movieClip_2.visible = false;
					this.gclass25_0.Boolean_1 = true;
					this.gclass25_1.Boolean_1 = true;
					this.textField_1.textFormat.color = Color.yellow;
					this.textField_1.text = Utility.smethod_5("LV.", Utility.smethod_8(presence.mCharacterLevel));
					this.textField_2.text = presence.mCharacterName;
					this.textField_3.text = string.Empty;
					this.textField_4.text = string.Empty;
					this.textField_5.text = string.Empty;
					this.textField_6.text = string.Empty;
				}
				else
				{
					this.movieClip_1.visible = false;
					this.movieClip_2.visible = true;
					this.gclass25_0.Boolean_1 = false;
					this.gclass25_1.Boolean_1 = false;
					this.textField_4.textFormat.color = Color.yellow;
					this.textField_4.text = Utility.smethod_5("LV.", Utility.smethod_8(presence.mCharacterLevel));
					this.textField_5.text = presence.mCharacterName;
					this.textField_1.text = string.Empty;
					this.textField_2.text = string.Empty;
					this.textField_3.text = string.Empty;
					if (applicationStatus == GuildManager.ApplicationStatus.e_Accepted)
					{
						this.textField_6.text = "Accepted";
					}
					if (applicationStatus == GuildManager.ApplicationStatus.e_Rejected)
					{
						this.textField_6.text = "Rejected";
					}
				}
			}
			else
			{
				this.int_1 = -1;
				this.gclass25_0.Boolean_1 = false;
				this.gclass25_1.Boolean_1 = false;
				this.textField_1.text = string.Empty;
				this.textField_2.text = string.Empty;
				this.textField_3.text = string.Empty;
				this.textField_4.text = string.Empty;
				this.textField_5.text = string.Empty;
				this.textField_6.text = string.Empty;
				this.applicationStatus_0 = GuildManager.ApplicationStatus.e_Rejected;
			}
		}

		// Token: 0x040023B9 RID: 9145
		protected MovieClip movieClip_1;

		// Token: 0x040023BA RID: 9146
		protected MovieClip movieClip_2;

		// Token: 0x040023BB RID: 9147
		protected TextField textField_1;

		// Token: 0x040023BC RID: 9148
		protected TextField textField_2;

		// Token: 0x040023BD RID: 9149
		protected TextField textField_3;

		// Token: 0x040023BE RID: 9150
		protected TextField textField_4;

		// Token: 0x040023BF RID: 9151
		protected TextField textField_5;

		// Token: 0x040023C0 RID: 9152
		protected TextField textField_6;

		// Token: 0x040023C1 RID: 9153
		protected GClass25 gclass25_0;

		// Token: 0x040023C2 RID: 9154
		protected GClass25 gclass25_1;

		// Token: 0x040023C3 RID: 9155
		private GuildManager.ApplicationStatus applicationStatus_0;

		// Token: 0x040023C4 RID: 9156
		private int int_1 = -1;
	}
}
