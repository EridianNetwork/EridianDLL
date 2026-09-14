using System;
using pumpkin.display;

namespace ns0
{
	// Token: 0x0200078A RID: 1930
	public class WrapUpView : TestBaseView
	{
		// Token: 0x06003317 RID: 13079 RVA: 0x000EAB44 File Offset: 0x000E8D44
		public WrapUpView(UniUIManager uniUIManager_1)
			: base(uniUIManager_1)
		{
			MovieClip movieClip = this.uniUIManager_0.method_47("Wrap Up.swf", "Whole");
			this.class3_0 = new WrapUpView.Class3();
			this.class3_0.method_0(movieClip);
			this.uniUIManager_0.method_31(this.class3_0);
		}

		// Token: 0x06003318 RID: 13080 RVA: 0x00021482 File Offset: 0x0001F682
		public override void vmethod_0()
		{
			base.vmethod_0();
			if (this.class3_0 != null)
			{
				this.uniUIManager_0.method_37(this.class3_0);
				this.class3_0 = null;
			}
		}

		// Token: 0x04002377 RID: 9079
		private WrapUpView.Class3 class3_0;

		// Token: 0x0200078B RID: 1931
		private class Class3 : GClass51
		{
			// Token: 0x0600331A RID: 13082 RVA: 0x000EAB98 File Offset: 0x000E8D98
			protected override void vmethod_0()
			{
				base.vmethod_0();
				this.movieClip_0 = this.displayObjectContainer_0 as MovieClip;
				this.movieClip_0.gotoAndPlay("fadein");
				this.movieClip_1 = this.movieClip_0.getChildByName<MovieClip>("mc_total");
				this.movieClip_1.gotoAndPlay("show detail");
			}

			// Token: 0x04002378 RID: 9080
			protected MovieClip movieClip_0;

			// Token: 0x04002379 RID: 9081
			private MovieClip movieClip_1;
		}
	}
}
