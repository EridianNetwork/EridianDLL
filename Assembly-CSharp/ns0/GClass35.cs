using System;
using pumpkin.display;
using pumpkin.text;

namespace ns0
{
	// Token: 0x0200079A RID: 1946
	public class GClass35 : GClass26
	{
		// Token: 0x060033A2 RID: 13218 RVA: 0x000ED3B8 File Offset: 0x000EB5B8
		protected override void vmethod_0()
		{
			base.vmethod_0();
			MovieClip movieClip = base.DisplayObjectContainer_0 as MovieClip;
			this.textField_1 = movieClip.getChildByName<MovieClip>("online_status").getChildByName<TextField>("tfname");
		}

		// Token: 0x060033A3 RID: 13219 RVA: 0x000ED3F4 File Offset: 0x000EB5F4
		public override void vmethod_14(int int_1)
		{
			GuildNews guildNews = GuildManager.smethod_0().method_98(int_1);
			string text = string.Empty;
			if (guildNews != null)
			{
				if (guildNews.Reason == GuildNewsReason.GuildLevelUp)
				{
					text = Utility.smethod_5(LocalizedString.smethod_0(new LocalizedString(Utility.smethod_5("GUILD_", guildNews.Reason.ToString()))), Utility.smethod_8(guildNews.Objective));
				}
				else
				{
					if (guildNews.Reason != GuildNewsReason.Kicked && guildNews.Reason != GuildNewsReason.GuildManagerAssigned)
					{
						if (guildNews.Reason != GuildNewsReason.GuildManagerAssigned)
						{
							text = Utility.smethod_6(guildNews.PosterName, " ", LocalizedString.smethod_0(new LocalizedString(Utility.smethod_5("GUILD_", guildNews.Reason.ToString()))));
							goto IL_00E1;
						}
					}
					text = Utility.smethod_5(guildNews.ObjectiveName, LocalizedString.smethod_0(new LocalizedString(Utility.smethod_5("GUILD_", guildNews.Reason.ToString()))));
				}
				IL_00E1:
				this.textField_1.text = text;
			}
		}

		// Token: 0x040023D8 RID: 9176
		protected TextField textField_1;
	}
}
