using System;
using pumpkin.events;

namespace ns0
{
	// Token: 0x020007B6 RID: 1974
	public class GClass56 : MouseEvent
	{
		// Token: 0x060034F3 RID: 13555 RVA: 0x00022C45 File Offset: 0x00020E45
		public GClass56(string string_2)
			: base(string_2)
		{
		}

		// Token: 0x060034F4 RID: 13556 RVA: 0x00022C4E File Offset: 0x00020E4E
		public GClass56(string string_2, bool bool_0, bool bool_1)
			: base(string_2, bool_0, bool_1)
		{
		}

		// Token: 0x0400249E RID: 9374
		public static readonly string string_0 = "mouseWheel";

		// Token: 0x0400249F RID: 9375
		public static readonly string string_1 = "doubleClick";

		// Token: 0x040024A0 RID: 9376
		public float float_0;
	}
}
