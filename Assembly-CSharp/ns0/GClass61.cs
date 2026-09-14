using System;
using System.Collections.Generic;
using pumpkin.events;

namespace ns0
{
	// Token: 0x020007BF RID: 1983
	public class GClass61
	{
		// Token: 0x06003525 RID: 13605 RVA: 0x00003197 File Offset: 0x00001397
		private GClass61()
		{
		}

		// Token: 0x170002D7 RID: 727
		// (get) Token: 0x06003526 RID: 13606 RVA: 0x00022EA4 File Offset: 0x000210A4
		public static GClass61 GClass61_0
		{
			get
			{
				if (GClass61.gclass61_0 == null)
				{
					GClass61.gclass61_0 = new GClass61();
				}
				return GClass61.gclass61_0;
			}
		}

		// Token: 0x170002D8 RID: 728
		// (get) Token: 0x06003527 RID: 13607 RVA: 0x00022EBC File Offset: 0x000210BC
		public GInterface3 GInterface3_0
		{
			get
			{
				return this.ginterface3_0;
			}
		}

		// Token: 0x06003528 RID: 13608 RVA: 0x00022EC4 File Offset: 0x000210C4
		public void method_0(GInterface3 ginterface3_1)
		{
			this.ginterface3_0 = ginterface3_1;
		}

		// Token: 0x06003529 RID: 13609 RVA: 0x00022ECD File Offset: 0x000210CD
		public void method_1(CEvent cevent_0, Dictionary<string, string> dictionary_0)
		{
			if (this.ginterface3_0 == null)
			{
				return;
			}
			if (dictionary_0.ContainsKey(cevent_0.type))
			{
				this.ginterface3_0.imethod_0(dictionary_0[cevent_0.type]);
			}
		}

		// Token: 0x040024B9 RID: 9401
		private GInterface3 ginterface3_0;

		// Token: 0x040024BA RID: 9402
		private static GClass61 gclass61_0;
	}
}
