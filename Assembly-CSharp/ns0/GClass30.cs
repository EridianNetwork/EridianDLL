using System;
using pumpkin.display;
using pumpkin.events;
using pumpkin.text;
using UnityEngine;

namespace ns0
{
	// Token: 0x02000795 RID: 1941
	public class GClass30 : GClass26
	{
		// Token: 0x06003385 RID: 13189 RVA: 0x000EC380 File Offset: 0x000EA580
		protected override void vmethod_0()
		{
			base.vmethod_0();
			this.movieClip_0.mouseChildrenEnabled = true;
			MovieClip movieClip = base.DisplayObjectContainer_0 as MovieClip;
			this.movieClip_1 = movieClip.getChildByName<MovieClip>("groupNormal");
			this.movieClip_2 = movieClip.getChildByName<MovieClip>("groupDecided");
			this.textField_1 = this.movieClip_1.getChildByName<TextField>("tfname");
			this.textField_2 = this.movieClip_2.getChildByName<TextField>("tfname");
			this.textField_3 = this.movieClip_1.getChildByName<TextField>("tflv");
			this.textField_4 = this.movieClip_2.getChildByName<TextField>("tflv");
			this.textField_5 = this.movieClip_2.getChildByName<TextField>("tfinfo");
			this.textField_6 = this.movieClip_1.getChildByName<TextField>("tfposition");
			this.movieClip_3 = this.movieClip_1.getChildByName<MovieClip>("mc_Icon");
			this.movieClip_4 = this.movieClip_2.getChildByName<MovieClip>("mc_Icon");
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
			this.textField_6.text = LocalizedString.smethod_0(new LocalizedString("Group_Invitation"));
			this.movieClip_0.addEventListener(CEvent.ENTER_FRAME, new EventDispatcher.EventCallback(this.method_19));
			this.gclass25_0.addEventListener(MouseEvent.CLICK, new EventDispatcher.EventCallback(this.method_21));
			this.gclass25_1.addEventListener(MouseEvent.CLICK, new EventDispatcher.EventCallback(this.method_22));
		}

		// Token: 0x06003386 RID: 13190 RVA: 0x00021977 File Offset: 0x0001FB77
		protected override void vmethod_11()
		{
			base.vmethod_11();
			this.vmethod_13();
		}

		// Token: 0x06003387 RID: 13191 RVA: 0x00021985 File Offset: 0x0001FB85
		protected void method_19(CEvent cevent_0)
		{
			this.vmethod_13();
		}

		// Token: 0x06003388 RID: 13192 RVA: 0x000EC570 File Offset: 0x000EA770
		protected override void vmethod_13()
		{
			if (this.int_0 == -1)
			{
				return;
			}
			if (!GroupManager.smethod_0().method_7(this.int_0))
			{
				return;
			}
			if (GroupManager.smethod_0().method_4(this.int_0) == GroupManager.InviteMessageStatus.e_WaitingForDecide)
			{
				if (GroupManager.smethod_0().method_18())
				{
					this.movieClip_2.visible = true;
					this.movieClip_1.visible = false;
					this.gclass25_0.Boolean_1 = true;
					this.gclass25_1.Boolean_1 = true;
					this.gclass25_0.Boolean_6 = false;
					this.gclass25_1.Boolean_6 = false;
				}
				else
				{
					this.movieClip_2.visible = false;
					this.movieClip_1.visible = true;
					this.method_20();
				}
			}
			else
			{
				this.movieClip_2.visible = true;
				this.movieClip_1.visible = false;
				this.gclass25_0.Boolean_1 = false;
				this.gclass25_1.Boolean_1 = false;
			}
			switch (GroupManager.smethod_0().method_4(this.int_0))
			{
			case GroupManager.InviteMessageStatus.e_Decided:
				this.textField_5.text = LocalizedString.smethod_0(new LocalizedString("Waiting_For_Join"));
				break;
			case GroupManager.InviteMessageStatus.e_Locked:
				this.textField_5.text = LocalizedString.smethod_0(new LocalizedString("Waiting"));
				break;
			case GroupManager.InviteMessageStatus.e_JoinFailed:
				this.textField_5.text = LocalizedString.smethod_0(new LocalizedString("Can't_Join"));
				break;
			case GroupManager.InviteMessageStatus.e_Accepted:
				this.textField_5.text = LocalizedString.smethod_0(new LocalizedString("Accepted"));
				break;
			case GroupManager.InviteMessageStatus.e_Rejected:
				this.textField_5.text = LocalizedString.smethod_0(new LocalizedString("Rejected"));
				break;
			default:
				this.textField_5.text = string.Empty;
				break;
			}
		}

		// Token: 0x06003389 RID: 13193 RVA: 0x000EC720 File Offset: 0x000EA920
		protected void method_20()
		{
			if (!this.gclass25_0.Boolean_6)
			{
				this.gclass25_0.Boolean_6 = true;
			}
			if (!this.gclass25_1.Boolean_6)
			{
				this.gclass25_1.Boolean_6 = true;
			}
			if (!(base.String_0 == "over") && !(base.String_0 == "down") && !(base.String_0 == "release"))
			{
				this.gclass25_0.Boolean_1 = false;
				this.gclass25_1.Boolean_1 = false;
			}
			else
			{
				if (!this.gclass25_0.Boolean_1)
				{
					this.gclass25_0.Boolean_1 = true;
				}
				if (!this.gclass25_1.Boolean_1)
				{
					this.gclass25_1.Boolean_1 = true;
				}
			}
		}

		// Token: 0x0600338A RID: 13194 RVA: 0x0002198D File Offset: 0x0001FB8D
		protected void method_21(CEvent cevent_0)
		{
			GroupManager.smethod_0().method_12(this.int_0);
		}

		// Token: 0x0600338B RID: 13195 RVA: 0x0002199F File Offset: 0x0001FB9F
		protected void method_22(CEvent cevent_0)
		{
			GroupManager.smethod_0().method_13(this.int_0);
		}

		// Token: 0x0600338C RID: 13196 RVA: 0x000EC7E4 File Offset: 0x000EA9E4
		public override void vmethod_14(int int_1)
		{
			PlayerProperties playerProperties = GroupManager.smethod_0().method_5(int_1);
			if (playerProperties != null)
			{
				this.int_0 = playerProperties.m_id;
				this.textField_1.text = playerProperties.m_name;
				this.textField_2.text = playerProperties.m_name;
				this.textField_3.text = Utility.smethod_5("Lv:", Utility.smethod_8(playerProperties.m_level));
				this.textField_4.text = Utility.smethod_5("Lv:", Utility.smethod_8(playerProperties.m_level));
				this.movieClip_3.gotoAndStop(playerProperties.m_avatarDna.method_5().ToString());
				this.movieClip_4.gotoAndStop(playerProperties.m_avatarDna.method_5().ToString());
			}
		}

		// Token: 0x040023AD RID: 9133
		protected MovieClip movieClip_1;

		// Token: 0x040023AE RID: 9134
		protected MovieClip movieClip_2;

		// Token: 0x040023AF RID: 9135
		protected MovieClip movieClip_3;

		// Token: 0x040023B0 RID: 9136
		protected MovieClip movieClip_4;

		// Token: 0x040023B1 RID: 9137
		protected GClass25 gclass25_0;

		// Token: 0x040023B2 RID: 9138
		protected GClass25 gclass25_1;

		// Token: 0x040023B3 RID: 9139
		protected TextField textField_1;

		// Token: 0x040023B4 RID: 9140
		protected TextField textField_2;

		// Token: 0x040023B5 RID: 9141
		protected TextField textField_3;

		// Token: 0x040023B6 RID: 9142
		protected TextField textField_4;

		// Token: 0x040023B7 RID: 9143
		protected TextField textField_5;

		// Token: 0x040023B8 RID: 9144
		protected TextField textField_6;
	}
}
