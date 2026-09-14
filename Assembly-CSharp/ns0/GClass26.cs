using System;

namespace ns0
{
	// Token: 0x0200079E RID: 1950
	public class GClass26 : GClass25
	{
		// Token: 0x17000295 RID: 661
		// (set) Token: 0x060033E6 RID: 13286 RVA: 0x00021EA4 File Offset: 0x000200A4
		public override bool Boolean_6
		{
			set
			{
				base.Boolean_6 = value;
				if (this.movieClip_0 != null)
				{
					this.movieClip_0.mouseChildrenEnabled = true;
				}
			}
		}

		// Token: 0x060033E7 RID: 13287 RVA: 0x00021EC1 File Offset: 0x000200C1
		protected override void vmethod_4()
		{
			base.vmethod_4();
			this.movieClip_0.mouseChildrenEnabled = true;
		}

		// Token: 0x060033E8 RID: 13288 RVA: 0x0000311B File Offset: 0x0000131B
		protected virtual void vmethod_13()
		{
		}

		// Token: 0x060033E9 RID: 13289 RVA: 0x0000311B File Offset: 0x0000131B
		public virtual void vmethod_14(int int_1)
		{
		}

		// Token: 0x060033EA RID: 13290 RVA: 0x0000311B File Offset: 0x0000131B
		public virtual void vmethod_15(int int_1, bool bool_8)
		{
		}

		// Token: 0x04002401 RID: 9217
		protected int int_0 = -1;
	}
}
