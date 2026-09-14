using System;
using pumpkin.display;
using pumpkin.events;

namespace ns0
{
	// Token: 0x020007BD RID: 1981
	public class GClass60 : EventDispatcher
	{
		// Token: 0x0600351C RID: 13596 RVA: 0x00022E37 File Offset: 0x00021037
		private GClass60()
		{
		}

		// Token: 0x170002D4 RID: 724
		// (get) Token: 0x0600351D RID: 13597 RVA: 0x00022E4D File Offset: 0x0002104D
		public static GClass60 GClass60_0
		{
			get
			{
				if (GClass60.gclass60_0 == null)
				{
					GClass60.gclass60_0 = new GClass60();
				}
				return GClass60.gclass60_0;
			}
		}

		// Token: 0x170002D5 RID: 725
		// (get) Token: 0x0600351E RID: 13598 RVA: 0x00022E65 File Offset: 0x00021065
		public bool Boolean_0
		{
			get
			{
				return this.bool_0;
			}
		}

		// Token: 0x170002D6 RID: 726
		// (get) Token: 0x0600351F RID: 13599 RVA: 0x00022E6D File Offset: 0x0002106D
		public DisplayObject DisplayObject_0
		{
			get
			{
				return this.displayObject_0;
			}
		}

		// Token: 0x06003520 RID: 13600 RVA: 0x00022E75 File Offset: 0x00021075
		private void OnTipsChange(CEvent evt)
		{
			if (this.bool_0)
			{
				this.method_2();
			}
		}

		// Token: 0x06003521 RID: 13601 RVA: 0x000F138C File Offset: 0x000EF58C
		public void method_0(GClass24 gclass24_1, GInterface1 ginterface1_0)
		{
			if (ginterface1_0 == null)
			{
				return;
			}
			this.method_2();
			this.gclass24_0 = gclass24_1;
			DisplayObject displayObject = GClass60.ginterface2_0.imethod_1(this.gclass24_0, ginterface1_0);
			if (displayObject == null)
			{
				return;
			}
			this.displayObject_0 = displayObject;
			this.bool_0 = true;
			this.gclass24_0.addEventListener("tipsChange", new EventDispatcher.EventCallback(this.OnTipsChange));
		}

		// Token: 0x06003522 RID: 13602 RVA: 0x00022E85 File Offset: 0x00021085
		public bool method_1(GInterface2 ginterface2_1)
		{
			if (ginterface2_1 == null)
			{
				return false;
			}
			GClass60.ginterface2_0 = ginterface2_1;
			GClass60.ginterface2_0.imethod_0();
			this.method_2();
			return true;
		}

		// Token: 0x06003523 RID: 13603 RVA: 0x000F13EC File Offset: 0x000EF5EC
		public void method_2()
		{
			GClass60.ginterface2_0.imethod_4(this.displayObject_0);
			if (this.gclass24_0 != null)
			{
				this.gclass24_0.removeEventListener("tipsChange", new EventDispatcher.EventCallback(this.OnTipsChange));
			}
			this.displayObject_0 = null;
			this.gclass24_0 = null;
			this.bool_0 = false;
		}

		// Token: 0x040024B4 RID: 9396
		private static GClass60 gclass60_0;

		// Token: 0x040024B5 RID: 9397
		private static GInterface2 ginterface2_0;

		// Token: 0x040024B6 RID: 9398
		private bool bool_0;

		// Token: 0x040024B7 RID: 9399
		private DisplayObject displayObject_0;

		// Token: 0x040024B8 RID: 9400
		private GClass24 gclass24_0;
	}
}
