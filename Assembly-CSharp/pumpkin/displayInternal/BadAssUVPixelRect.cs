using System;
using UnityEngine;

namespace pumpkin.displayInternal
{
	// Token: 0x02000771 RID: 1905
	internal struct BadAssUVPixelRect
	{
		// Token: 0x06003279 RID: 12921 RVA: 0x00020E45 File Offset: 0x0001F045
		public BadAssUVPixelRect(float float_8, float float_9, float float_10, float float_11, float float_12, float float_13, float float_14, float float_15)
		{
			this.float_0 = float_8;
			this.float_1 = float_9;
			this.float_2 = float_10;
			this.float_3 = float_11;
			this.float_4 = float_12;
			this.float_5 = float_13;
			this.float_6 = float_14;
			this.float_7 = float_15;
		}

		// Token: 0x0600327A RID: 12922 RVA: 0x000E6D3C File Offset: 0x000E4F3C
		public float method_0(float float_8)
		{
			float num = this.float_6 / this.float_2;
			this.float_2 = float_8;
			this.float_6 = this.float_2 * num;
			return this.float_2;
		}

		// Token: 0x0600327B RID: 12923 RVA: 0x000E6D74 File Offset: 0x000E4F74
		public float method_1(float float_8)
		{
			float num = this.float_7 / this.float_3;
			this.float_3 = float_8;
			this.float_7 = this.float_3 * num;
			return this.float_3;
		}

		// Token: 0x0600327C RID: 12924 RVA: 0x000E6DAC File Offset: 0x000E4FAC
		public float method_2(float float_8)
		{
			float num = this.float_6 / this.float_2;
			float num2 = float_8 - this.float_0;
			this.float_0 = float_8;
			this.float_4 += num2 * num;
			return this.float_0;
		}

		// Token: 0x0600327D RID: 12925 RVA: 0x000E6DF0 File Offset: 0x000E4FF0
		public float method_3(float float_8)
		{
			float num = this.float_7 / this.float_3;
			float num2 = float_8 - this.float_1;
			this.float_1 = float_8;
			this.float_5 += num2 * num;
			return this.float_1;
		}

		// Token: 0x0600327E RID: 12926 RVA: 0x000E6E34 File Offset: 0x000E5034
		public override string ToString()
		{
			return string.Concat(new object[]
			{
				"UVPixelRect( ", this.float_0, ", ", this.float_1, ", ", this.float_2, ", ", this.float_3, ", ", this.float_4,
				", ", this.float_5, ", ", this.float_6, ", ", this.float_7, " )"
			});
		}

		// Token: 0x0600327F RID: 12927 RVA: 0x000E6F10 File Offset: 0x000E5110
		public string method_4(Texture texture_0)
		{
			return string.Concat(new object[]
			{
				"UVPixelRect( ",
				this.float_0,
				", ",
				this.float_1,
				", ",
				this.float_2,
				", ",
				this.float_3,
				", ",
				this.float_4 * (float)texture_0.width,
				", ",
				this.float_5 * (float)texture_0.height,
				", ",
				this.float_6 * (float)texture_0.width,
				", ",
				this.float_7 * (float)texture_0.height,
				" )"
			});
		}

		// Token: 0x040022F6 RID: 8950
		public float float_0;

		// Token: 0x040022F7 RID: 8951
		public float float_1;

		// Token: 0x040022F8 RID: 8952
		public float float_2;

		// Token: 0x040022F9 RID: 8953
		public float float_3;

		// Token: 0x040022FA RID: 8954
		public float float_4;

		// Token: 0x040022FB RID: 8955
		public float float_5;

		// Token: 0x040022FC RID: 8956
		public float float_6;

		// Token: 0x040022FD RID: 8957
		public float float_7;
	}
}
