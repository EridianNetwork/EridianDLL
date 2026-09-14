using System;
using pumpkin.display;
using pumpkin.events;
using pumpkin.text;

namespace ns0
{
	// Token: 0x02000799 RID: 1945
	public class GClass34 : GClass26
	{
		// Token: 0x0600339E RID: 13214 RVA: 0x000ED27C File Offset: 0x000EB47C
		protected override void vmethod_0()
		{
			base.vmethod_0();
			this.movieClip_0.mouseChildrenEnabled = true;
			MovieClip movieClip = base.DisplayObjectContainer_0 as MovieClip;
			this.gclass25_0 = new GClass25();
			this.gclass25_0.method_0(movieClip.getChildByName<MovieClip>("mc_CancelBtn"));
			this.gclass25_0.addEventListener(MouseEvent.CLICK, new EventDispatcher.EventCallback(this.method_19));
			this.movieClip_1 = movieClip.getChildByName<MovieClip>("mc_MessageItem").getChildByName<MovieClip>("mc_Icon");
			this.textField_1 = movieClip.getChildByName<MovieClip>("mc_MessageItem").getChildByName<TextField>("tflv");
			this.textField_2 = movieClip.getChildByName<MovieClip>("mc_MessageItem").getChildByName<TextField>("tfname");
			this.textField_3 = movieClip.getChildByName<MovieClip>("mc_MessageItem").getChildByName<TextField>("status");
		}

		// Token: 0x0600339F RID: 13215 RVA: 0x00021A4F File Offset: 0x0001FC4F
		protected void method_19(CEvent cevent_0)
		{
			if (this.int_1 != -1)
			{
				GuildManager.smethod_0().method_30(this.int_1);
			}
		}

		// Token: 0x060033A0 RID: 13216 RVA: 0x000ED354 File Offset: 0x000EB554
		public override void vmethod_14(int int_2)
		{
			Guild guild = GuildManager.smethod_0().method_69(int_2);
			if (guild != null)
			{
				this.int_1 = guild.Id;
				this.textField_1.text = Utility.smethod_5("Lv.", Utility.smethod_8(guild.Level));
				this.textField_2.text = guild.Name;
			}
			else
			{
				this.int_1 = -1;
			}
		}

		// Token: 0x040023D2 RID: 9170
		protected GClass25 gclass25_0;

		// Token: 0x040023D3 RID: 9171
		protected MovieClip movieClip_1;

		// Token: 0x040023D4 RID: 9172
		protected TextField textField_1;

		// Token: 0x040023D5 RID: 9173
		protected TextField textField_2;

		// Token: 0x040023D6 RID: 9174
		protected TextField textField_3;

		// Token: 0x040023D7 RID: 9175
		private int int_1 = -1;
	}
}
