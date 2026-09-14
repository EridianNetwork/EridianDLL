using System;
using pumpkin.events;

namespace ns0
{
	// Token: 0x020007B4 RID: 1972
	public class GClass54 : CEvent
	{
		// Token: 0x060034F0 RID: 13552 RVA: 0x00022C07 File Offset: 0x00020E07
		public GClass54(string string_3, bool bool_0 = false, bool bool_1 = true)
			: base(string_3, bool_0, bool_1)
		{
		}

		// Token: 0x0400249A RID: 9370
		public static readonly string string_0 = "stateChange";

		// Token: 0x0400249B RID: 9371
		public static readonly string string_1 = "show";

		// Token: 0x0400249C RID: 9372
		public static readonly string string_2 = "hide";
	}
}
