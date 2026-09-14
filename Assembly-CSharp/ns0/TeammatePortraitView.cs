using System;
using pumpkin.display;
using pumpkin.events;

namespace ns0
{
	// Token: 0x02000787 RID: 1927
	public class TeammatePortraitView : TestBaseView
	{
		// Token: 0x0600330D RID: 13069 RVA: 0x000EA800 File Offset: 0x000E8A00
		public TeammatePortraitView(UniUIManager uniUIManager_1)
			: base(uniUIManager_1)
		{
			MovieClip movieClip = this.uniUIManager_0.method_47("Team_mate_portrait.swf", "TeamMateInfo");
			this.class2_0 = new TeammatePortraitView.Class2();
			this.class2_0.method_0(movieClip);
			this.uniUIManager_0.method_31(this.class2_0);
		}

		// Token: 0x0600330E RID: 13070 RVA: 0x00021408 File Offset: 0x0001F608
		public override void vmethod_0()
		{
			base.vmethod_0();
			if (this.class2_0 != null)
			{
				this.uniUIManager_0.method_37(this.class2_0);
				this.class2_0 = null;
			}
		}

		// Token: 0x0400236F RID: 9071
		private TeammatePortraitView.Class2 class2_0;

		// Token: 0x02000788 RID: 1928
		private class Class2 : GClass51
		{
			// Token: 0x17000279 RID: 633
			// (get) Token: 0x06003311 RID: 13073 RVA: 0x0002145C File Offset: 0x0001F65C
			// (set) Token: 0x06003310 RID: 13072 RVA: 0x00021446 File Offset: 0x0001F646
			public virtual bool Boolean_0
			{
				get
				{
					return this.movieClip_0 != null && this.movieClip_0.visible;
				}
				set
				{
					if (this.movieClip_0 != null)
					{
						this.movieClip_0.visible = value;
					}
				}
			}

			// Token: 0x06003312 RID: 13074 RVA: 0x000EA854 File Offset: 0x000E8A54
			protected override void vmethod_0()
			{
				base.vmethod_0();
				this.movieClip_0 = this.displayObjectContainer_0 as MovieClip;
				this.movieClip_1 = this.movieClip_0.getChildByName<MovieClip>("MateInfo1");
				this.movieClip_2 = this.movieClip_0.getChildByName<MovieClip>("MateInfo2");
				this.movieClip_3 = this.movieClip_0.getChildByName<MovieClip>("MateInfo3");
				this.movieClip_1.addEventListener(MouseEvent.CLICK, new EventDispatcher.EventCallback(this.method_6));
				this.movieClip_2.addEventListener(MouseEvent.CLICK, new EventDispatcher.EventCallback(this.method_6));
				this.movieClip_3.addEventListener(MouseEvent.CLICK, new EventDispatcher.EventCallback(this.method_6));
				this.movieClip_1.addEventListener(CEvent.ENTER_FRAME, new EventDispatcher.EventCallback(this.method_5));
				this.movieClip_2.addEventListener(CEvent.ENTER_FRAME, new EventDispatcher.EventCallback(this.method_5));
				this.movieClip_3.addEventListener(CEvent.ENTER_FRAME, new EventDispatcher.EventCallback(this.method_5));
			}

			// Token: 0x06003313 RID: 13075 RVA: 0x000EA968 File Offset: 0x000E8B68
			protected void method_5(CEvent cevent_0)
			{
				MovieClip movieClip = cevent_0.currentTarget as MovieClip;
				if (movieClip != null && movieClip.getChildByName<MovieClip>("All") != null && movieClip.getChildByName<MovieClip>("All").getChildByName<MovieClip>("NormalStatus") != null && movieClip.getChildByName<MovieClip>("All").getChildByName<MovieClip>("NormalStatus").getChildByName<MovieClip>("icon") != null)
				{
					this.int_0 %= 100;
					movieClip.getChildByName<MovieClip>("All").getChildByName<MovieClip>("NormalStatus").getChildByName<MovieClip>("icon")
						.alpha = 0.5f;
					movieClip.getChildByName<MovieClip>("All").getChildByName<MovieClip>("NormalStatus").getChildByName<MovieClip>("health")
						.alpha = 0.5f;
					movieClip.getChildByName<MovieClip>("All").getChildByName<MovieClip>("NormalStatus").getChildByName<MovieClip>("shield")
						.alpha = 0.5f;
					movieClip.getChildByName<MovieClip>("All").getChildByName<MovieClip>("NormalStatus").getChildByName<MovieClip>("icon")
						.gotoAndStop(3);
					movieClip.getChildByName<MovieClip>("All").getChildByName<MovieClip>("NormalStatus").getChildByName<MovieClip>("health")
						.gotoAndStop(this.int_0);
					movieClip.getChildByName<MovieClip>("All").getChildByName<MovieClip>("NormalStatus").getChildByName<MovieClip>("shield")
						.gotoAndStop(this.int_0);
					this.int_0++;
				}
			}

			// Token: 0x06003314 RID: 13076 RVA: 0x000EAAF8 File Offset: 0x000E8CF8
			protected void method_6(CEvent cevent_0)
			{
				MovieClip movieClip = cevent_0.currentTarget as MovieClip;
				if (movieClip != null)
				{
					if (this.bool_0)
					{
						movieClip.gotoAndPlay("IN");
						this.bool_0 = false;
					}
					else
					{
						movieClip.gotoAndPlay("out");
						this.bool_0 = true;
					}
				}
			}

			// Token: 0x04002370 RID: 9072
			protected MovieClip movieClip_0;

			// Token: 0x04002371 RID: 9073
			private MovieClip movieClip_1;

			// Token: 0x04002372 RID: 9074
			private MovieClip movieClip_2;

			// Token: 0x04002373 RID: 9075
			private MovieClip movieClip_3;

			// Token: 0x04002374 RID: 9076
			private int int_0 = 1;

			// Token: 0x04002375 RID: 9077
			private bool bool_0 = true;
		}
	}
}
