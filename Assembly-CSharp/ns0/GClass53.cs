using System;
using pumpkin.events;

namespace ns0
{
	// Token: 0x020007B3 RID: 1971
	public class GClass53 : MouseEvent
	{
		// Token: 0x060034EE RID: 13550 RVA: 0x00022BEC File Offset: 0x00020DEC
		public GClass53(string string_8, bool bool_1 = true, bool bool_2 = false, int int_1 = 0, bool bool_3 = false)
			: base(string_8, bool_1, bool_2)
		{
			this.int_0 = int_1;
			this.bool_0 = bool_3;
		}

		// Token: 0x04002490 RID: 9360
		public static readonly string string_0 = "buttonPress";

		// Token: 0x04002491 RID: 9361
		public static readonly string string_1 = "dragOver";

		// Token: 0x04002492 RID: 9362
		public static readonly string string_2 = "dragOut";

		// Token: 0x04002493 RID: 9363
		public static readonly string string_3 = "releaseOutside";

		// Token: 0x04002494 RID: 9364
		public static readonly string string_4 = "buttonSelected";

		// Token: 0x04002495 RID: 9365
		public static readonly string string_5 = "rightClick";

		// Token: 0x04002496 RID: 9366
		public static readonly string string_6 = "rigthPress";

		// Token: 0x04002497 RID: 9367
		public static readonly string string_7 = "doubleClick";

		// Token: 0x04002498 RID: 9368
		public int int_0;

		// Token: 0x04002499 RID: 9369
		public bool bool_0;
	}
}
