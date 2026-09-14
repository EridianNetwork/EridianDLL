using System;
using pumpkin.display;
using pumpkin.events;
using pumpkin.text;
using UnityEngine;
using XsdSettings;

namespace ns0
{
	// Token: 0x02000798 RID: 1944
	public class GClass33 : GClass26
	{
		// Token: 0x0600339A RID: 13210 RVA: 0x000ECF9C File Offset: 0x000EB19C
		protected override void vmethod_0()
		{
			base.vmethod_0();
			MovieClip movieClip = base.DisplayObjectContainer_0 as MovieClip;
			this.movieClip_1 = movieClip.getChildByName<MovieClip>("online_status").getChildByName<MovieClip>("mc_Icon");
			this.textField_1 = movieClip.getChildByName<MovieClip>("online_status").getChildByName<TextField>("tflv");
			this.textField_2 = movieClip.getChildByName<MovieClip>("online_status").getChildByName<TextField>("tfname");
			this.textField_3 = movieClip.getChildByName<MovieClip>("online_status").getChildByName<TextField>("tfposition");
			this.textField_4 = movieClip.getChildByName<MovieClip>("online_status").getChildByName<TextField>("tfjdtitle");
			this.movieClip_0.addEventListener(MouseEvent.CLICK, new EventDispatcher.EventCallback(this.method_19));
		}

		// Token: 0x0600339B RID: 13211 RVA: 0x000ED060 File Offset: 0x000EB260
		protected void method_19(CEvent cevent_0)
		{
			MouseEvent mouseEvent = (MouseEvent)cevent_0;
			if (mouseEvent != null && mouseEvent.buttonId == 1)
			{
				GuildManager.smethod_0().method_101(this.int_1);
			}
		}

		// Token: 0x0600339C RID: 13212 RVA: 0x000ED090 File Offset: 0x000EB290
		public override void vmethod_14(int int_2)
		{
			Presence presence = GuildManager.smethod_0().method_71(int_2);
			if (presence != null)
			{
				this.int_1 = presence.mCharacterId;
				AvatarType mAvatarType = presence.mAvatarType;
				this.movieClip_1.gotoAndStop(mAvatarType.ToString());
				this.textField_1.text = Utility.smethod_5("Lv.", Utility.smethod_8(presence.mCharacterLevel));
				this.textField_2.text = presence.mCharacterName;
				this.textField_4.textFormat.color = Color.green;
				if (GuildManager.smethod_0().method_9(presence.mCharacterId))
				{
					this.textField_4.text = LocalizedString.smethod_0(new LocalizedString("GUILD_OWNER"));
				}
				else if (GuildManager.smethod_0().method_83(presence.mCharacterId))
				{
					this.textField_4.text = LocalizedString.smethod_0(new LocalizedString("GUILD_MANAGER"));
				}
				else
				{
					this.textField_4.text = LocalizedString.smethod_0(new LocalizedString("GUILD_MEMBER"));
				}
				if (presence.mIsOnline)
				{
					this.textField_3.textFormat.color = Color.white;
					if (presence.mCurrentPlaylist != -1)
					{
						this.textField_3.text = LocalizedString.smethod_0(new LocalizedString(Utility.smethod_5("Instance_", Utility.smethod_8(presence.mCurrentPlaylist))));
					}
					else
					{
						this.textField_3.text = LocalizedString.smethod_0(new LocalizedString("Instance_28"));
					}
				}
				else
				{
					this.textField_3.textFormat.color = Color.gray;
					this.textField_3.text = Utility.smethod_13(presence.mLastOnline);
				}
			}
			else
			{
				this.int_1 = -1;
				this.textField_1.text = string.Empty;
				this.textField_2.text = string.Empty;
				this.textField_3.text = string.Empty;
				this.textField_4.text = string.Empty;
			}
		}

		// Token: 0x040023CC RID: 9164
		protected MovieClip movieClip_1;

		// Token: 0x040023CD RID: 9165
		protected TextField textField_1;

		// Token: 0x040023CE RID: 9166
		protected TextField textField_2;

		// Token: 0x040023CF RID: 9167
		protected TextField textField_3;

		// Token: 0x040023D0 RID: 9168
		protected TextField textField_4;

		// Token: 0x040023D1 RID: 9169
		private int int_1 = -1;
	}
}
