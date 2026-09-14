using System;
using pumpkin.display;
using pumpkin.events;

namespace ns0
{
	// Token: 0x02000785 RID: 1925
	public class MatchmakingView : TestBaseView
	{
		// Token: 0x06003307 RID: 13063 RVA: 0x000EA734 File Offset: 0x000E8934
		public MatchmakingView(UniUIManager uniUIManager_1)
			: base(uniUIManager_1)
		{
			MovieClip movieClip = this.uniUIManager_0.method_47("match_making.swf", "NPCAnima");
			this.class1_0 = new MatchmakingView.Class1();
			this.class1_0.method_0(movieClip);
			this.uniUIManager_0.method_31(this.class1_0);
		}

		// Token: 0x06003308 RID: 13064 RVA: 0x00021382 File Offset: 0x0001F582
		public override void vmethod_0()
		{
			base.vmethod_0();
			if (this.class1_0 != null)
			{
				this.uniUIManager_0.method_37(this.class1_0);
				this.class1_0 = null;
			}
		}

		// Token: 0x0400236C RID: 9068
		private MatchmakingView.Class1 class1_0;

		// Token: 0x02000786 RID: 1926
		private class Class1 : GClass51
		{
			// Token: 0x0600330A RID: 13066 RVA: 0x000EA788 File Offset: 0x000E8988
			protected override void vmethod_0()
			{
				base.vmethod_0();
				this.movieClip_0 = this.displayObjectContainer_0 as MovieClip;
				this.movieClip_1 = this.movieClip_0.getChildByName<MovieClip>("mcNPCtalkframe");
				this.movieClip_0.gotoAndPlay("fadein");
				this.movieClip_1.gotoAndPlay("normal");
				this.movieClip_1.addEventListener(MouseEvent.CLICK, new EventDispatcher.EventCallback(this.method_5));
			}

			// Token: 0x0600330B RID: 13067 RVA: 0x000213AA File Offset: 0x0001F5AA
			private void method_5(CEvent cevent_0)
			{
				this.movieClip_0.gotoAndPlay("fadeout");
				this.movieClip_0.addFrameScript("fadeoutEnd", new EventDispatcher.EventCallback(this.method_6));
			}

			// Token: 0x0600330C RID: 13068 RVA: 0x000213D9 File Offset: 0x0001F5D9
			private void method_6(CEvent cevent_0)
			{
				this.movieClip_0.removeFrameScript("fadeoutEnd", new EventDispatcher.EventCallback(this.method_6));
				this.movieClip_0.gotoAndPlay("fadein");
			}

			// Token: 0x0400236D RID: 9069
			protected MovieClip movieClip_0;

			// Token: 0x0400236E RID: 9070
			private MovieClip movieClip_1;
		}
	}
}
