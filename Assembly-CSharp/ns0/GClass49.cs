using System;

namespace ns0
{
	// Token: 0x020007AA RID: 1962
	public class GClass49 : GClass24
	{
		// Token: 0x06003473 RID: 13427 RVA: 0x0002256C File Offset: 0x0002076C
		protected override void vmethod_0()
		{
			base.vmethod_0();
			this.int_0 = this.movieClip_0.getTotalFrames();
		}

		// Token: 0x170002B0 RID: 688
		// (get) Token: 0x06003474 RID: 13428 RVA: 0x00022585 File Offset: 0x00020785
		// (set) Token: 0x06003475 RID: 13429 RVA: 0x0002258D File Offset: 0x0002078D
		public virtual int Int32_0
		{
			get
			{
				return this.int_1;
			}
			set
			{
				this.int_1 = value;
			}
		}

		// Token: 0x170002B1 RID: 689
		// (get) Token: 0x06003476 RID: 13430 RVA: 0x00022596 File Offset: 0x00020796
		// (set) Token: 0x06003477 RID: 13431 RVA: 0x0002259E File Offset: 0x0002079E
		public virtual int Int32_1
		{
			get
			{
				return this.int_2;
			}
			set
			{
				if (this.int_2 == value)
				{
					return;
				}
				this.int_2 = value;
				this.method_10();
			}
		}

		// Token: 0x170002B2 RID: 690
		// (get) Token: 0x06003478 RID: 13432 RVA: 0x000225B7 File Offset: 0x000207B7
		// (set) Token: 0x06003479 RID: 13433 RVA: 0x000EFF08 File Offset: 0x000EE108
		public virtual int Int32_2
		{
			get
			{
				return this.int_3;
			}
			set
			{
				int num = Math.Max(this.int_2, Math.Min(this.int_1, value));
				if (this.int_3 == num)
				{
					return;
				}
				this.int_3 = num;
				this.method_10();
			}
		}

		// Token: 0x170002B3 RID: 691
		// (get) Token: 0x0600347A RID: 13434 RVA: 0x000225B7 File Offset: 0x000207B7
		// (set) Token: 0x0600347B RID: 13435 RVA: 0x000225BF File Offset: 0x000207BF
		public virtual int Int32_3
		{
			get
			{
				return this.int_3;
			}
			set
			{
				this.Int32_2 = value;
			}
		}

		// Token: 0x0600347C RID: 13436 RVA: 0x000225C8 File Offset: 0x000207C8
		protected override void vmethod_5()
		{
			if (this.vmethod_3(new string[] { GClass22.string_3 }))
			{
				this.method_10();
			}
		}

		// Token: 0x0600347D RID: 13437 RVA: 0x000EFF44 File Offset: 0x000EE144
		protected void method_10()
		{
			if (!this.Boolean_6)
			{
				return;
			}
			double num = (double)((this.int_3 - this.int_2) / (this.int_1 - this.int_2));
			if (this.movieClip_0 != null)
			{
				this.movieClip_0.gotoAndPlay(Math.Max(1.0, Math.Round(num * (double)this.int_0)));
			}
		}

		// Token: 0x0400245A RID: 9306
		protected int int_0;

		// Token: 0x0400245B RID: 9307
		protected int int_1 = 10;

		// Token: 0x0400245C RID: 9308
		protected int int_2;

		// Token: 0x0400245D RID: 9309
		protected int int_3;
	}
}
