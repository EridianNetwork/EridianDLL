using System;

namespace ns0
{
	// Token: 0x020007A0 RID: 1952
	public class GClass40 : GClass25
	{
		// Token: 0x060033EF RID: 13295 RVA: 0x00021ED5 File Offset: 0x000200D5
		public GClass40()
		{
			this.Boolean_2 = true;
			if (this.gclass17_0 == null)
			{
				this.String_1 = GClass40.string_6;
			}
		}

		// Token: 0x17000296 RID: 662
		// (get) Token: 0x060033F1 RID: 13297 RVA: 0x000039EC File Offset: 0x00001BEC
		// (set) Token: 0x060033F2 RID: 13298 RVA: 0x0000311B File Offset: 0x0000131B
		public override bool Boolean_2
		{
			get
			{
				return true;
			}
			set
			{
			}
		}

		// Token: 0x17000297 RID: 663
		// (get) Token: 0x060033F3 RID: 13299 RVA: 0x00021F03 File Offset: 0x00020103
		// (set) Token: 0x060033F4 RID: 13300 RVA: 0x00021F0B File Offset: 0x0002010B
		public override string String_1
		{
			get
			{
				return base.String_1;
			}
			set
			{
				base.String_1 = value;
			}
		}

		// Token: 0x0400240A RID: 9226
		public static readonly string string_6 = "default";
	}
}
