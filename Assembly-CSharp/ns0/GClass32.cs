using System;
using pumpkin.display;
using pumpkin.events;
using pumpkin.text;

namespace ns0
{
	// Token: 0x02000797 RID: 1943
	public class GClass32 : GClass26
	{
		// Token: 0x06003395 RID: 13205 RVA: 0x000219FC File Offset: 0x0001FBFC
		public GClass32()
		{
			this.dictionary_0.Clear();
		}

		// Token: 0x06003396 RID: 13206 RVA: 0x000ECD54 File Offset: 0x000EAF54
		protected override void vmethod_0()
		{
			base.vmethod_0();
			this.movieClip_0.mouseChildrenEnabled = true;
			MovieClip movieClip = base.DisplayObjectContainer_0 as MovieClip;
			this.gclass25_0 = new GClass25();
			this.gclass25_0.method_0(movieClip.getChildByName<MovieClip>("mc_JoinBtn"));
			this.gclass25_0.addEventListener(MouseEvent.CLICK, new EventDispatcher.EventCallback(this.method_19));
			this.movieClip_1 = movieClip.getChildByName<MovieClip>("mc_FriendItem").getChildByName<MovieClip>("mc_Icon");
			this.textField_1 = movieClip.getChildByName<MovieClip>("mc_FriendItem").getChildByName<TextField>("tflv");
			this.textField_2 = movieClip.getChildByName<MovieClip>("mc_FriendItem").getChildByName<TextField>("tfname");
			this.textField_3 = movieClip.getChildByName<MovieClip>("mc_FriendItem").getChildByName<TextField>("status");
			this.textField_4 = movieClip.getChildByName<MovieClip>("mc_FriendItem").getChildByName<TextField>("headcount");
		}

		// Token: 0x06003397 RID: 13207 RVA: 0x00021A16 File Offset: 0x0001FC16
		protected void method_19(CEvent cevent_0)
		{
			if (this.int_1 != -1)
			{
				GuildManager.smethod_0().method_29(this.int_1);
			}
		}

		// Token: 0x06003398 RID: 13208 RVA: 0x000ECE48 File Offset: 0x000EB048
		public override void vmethod_14(int int_2)
		{
			Guild guild = GuildManager.smethod_0().method_68(int_2);
			if (guild != null)
			{
				this.int_1 = guild.Id;
				this.textField_1.text = Utility.smethod_5("LV.", Utility.smethod_8(guild.Level));
				this.textField_2.text = guild.Name;
				this.textField_3.text = string.Empty;
				this.textField_4.text = Utility.smethod_5(Utility.smethod_8(guild.MemberCount), LocalizedString.smethod_0(new LocalizedString("GuildMembers")));
				if (GuildManager.smethod_0().method_66(this.int_1))
				{
					this.gclass25_0.Boolean_6 = true;
					this.gclass25_0.Boolean_1 = true;
				}
				else
				{
					if (GuildManager.smethod_0().method_64(this.int_1))
					{
						this.textField_3.text = LocalizedString.smethod_0(new LocalizedString("GUILD_APPLIED"));
					}
					else
					{
						this.textField_3.text = string.Empty;
					}
					this.gclass25_0.Boolean_6 = false;
					this.gclass25_0.Boolean_1 = true;
				}
			}
			else
			{
				this.int_1 = -1;
				this.textField_1.text = string.Empty;
				this.textField_2.text = string.Empty;
				this.textField_3.text = string.Empty;
			}
		}

		// Token: 0x040023C5 RID: 9157
		protected GClass25 gclass25_0;

		// Token: 0x040023C6 RID: 9158
		protected MovieClip movieClip_1;

		// Token: 0x040023C7 RID: 9159
		protected TextField textField_1;

		// Token: 0x040023C8 RID: 9160
		protected TextField textField_2;

		// Token: 0x040023C9 RID: 9161
		protected TextField textField_3;

		// Token: 0x040023CA RID: 9162
		protected TextField textField_4;

		// Token: 0x040023CB RID: 9163
		private int int_1 = -1;
	}
}
