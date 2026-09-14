using System;
using System.Collections.Generic;

namespace ns0
{
	// Token: 0x020007B2 RID: 1970
	public class GClass52
	{
		// Token: 0x170002CC RID: 716
		// (get) Token: 0x060034EA RID: 13546 RVA: 0x00022BB6 File Offset: 0x00020DB6
		public static GClass52 GClass52_0
		{
			get
			{
				if (GClass52.gclass52_0 == null)
				{
					GClass52.gclass52_0 = new GClass52();
				}
				return GClass52.gclass52_0;
			}
		}

		// Token: 0x060034EB RID: 13547 RVA: 0x000F0DB4 File Offset: 0x000EEFB4
		public Type method_0(string string_0)
		{
			string[] array = string_0.Split(new char[] { '_' });
			if (array.Length > 0 && this.dictionary_1.ContainsKey(array[0]))
			{
				return this.dictionary_1[array[0]];
			}
			return null;
		}

		// Token: 0x060034EC RID: 13548 RVA: 0x00022BCE File Offset: 0x00020DCE
		public void method_1(string string_0, Type type_0)
		{
			this.dictionary_0[string_0] = type_0;
		}

		// Token: 0x060034ED RID: 13549 RVA: 0x00022BDD File Offset: 0x00020DDD
		public void method_2(string string_0, Type type_0)
		{
			this.dictionary_1[string_0] = type_0;
		}

		// Token: 0x0400248D RID: 9357
		private static GClass52 gclass52_0;

		// Token: 0x0400248E RID: 9358
		protected Dictionary<string, Type> dictionary_0 = new Dictionary<string, Type>();

		// Token: 0x0400248F RID: 9359
		protected Dictionary<string, Type> dictionary_1 = new Dictionary<string, Type>();
	}
}
