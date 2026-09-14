using System;
using pumpkin.events;

namespace ns0
{
	// Token: 0x020007B5 RID: 1973
	public class GClass55 : CEvent
	{
		// Token: 0x060034F2 RID: 13554 RVA: 0x00022C32 File Offset: 0x00020E32
		public GClass55(string string_0, object object_1, bool bool_0 = true, bool bool_1 = false)
			: base(string_0, bool_0, bool_1)
		{
			this.object_0 = object_1;
		}

		// Token: 0x0400249D RID: 9373
		public object object_0;
	}
}
