using System;
using UnityEngine;

namespace ns0
{
	// Token: 0x020007B9 RID: 1977
	public class GClass58
	{
		// Token: 0x170002D1 RID: 721
		// (get) Token: 0x0600350A RID: 13578 RVA: 0x00022DA0 File Offset: 0x00020FA0
		public static GClass58 GClass58_0
		{
			get
			{
				if (GClass58.gclass58_0 == null)
				{
					GClass58.gclass58_0 = new GClass58();
				}
				return GClass58.gclass58_0;
			}
		}

		// Token: 0x0600350B RID: 13579 RVA: 0x00022DB8 File Offset: 0x00020FB8
		public void method_0(GClass50 gclass50_1)
		{
			Input.imeCompositionMode = IMECompositionMode.On;
			Input.compensateSensors = true;
			this.gclass50_0 = gclass50_1;
		}

		// Token: 0x0600350C RID: 13580 RVA: 0x00022DCD File Offset: 0x00020FCD
		public void method_1(GClass50 gclass50_1)
		{
			if (this.gclass50_0 == gclass50_1)
			{
				this.gclass50_0 = null;
			}
			if (this.gclass50_0 == null)
			{
				Input.imeCompositionMode = IMECompositionMode.Off;
				Input.compensateSensors = false;
			}
		}

		// Token: 0x170002D2 RID: 722
		// (get) Token: 0x0600350D RID: 13581 RVA: 0x00022DF3 File Offset: 0x00020FF3
		// (set) Token: 0x0600350E RID: 13582 RVA: 0x00022DFB File Offset: 0x00020FFB
		public GClass50 GClass50_0
		{
			get
			{
				return this.gclass50_0;
			}
			private set
			{
				this.gclass50_0 = value;
			}
		}

		// Token: 0x170002D3 RID: 723
		// (get) Token: 0x0600350F RID: 13583 RVA: 0x00022E04 File Offset: 0x00021004
		public bool Boolean_0
		{
			get
			{
				return this.gclass50_0 != null;
			}
		}

		// Token: 0x06003510 RID: 13584 RVA: 0x00022E12 File Offset: 0x00021012
		public void method_2()
		{
			Input.imeCompositionMode = IMECompositionMode.Off;
			Input.compensateSensors = false;
			GClass20.GClass20_0.Stage_0.focus = null;
			this.gclass50_0 = null;
		}

		// Token: 0x040024B1 RID: 9393
		private static GClass58 gclass58_0;

		// Token: 0x040024B2 RID: 9394
		private GClass50 gclass50_0;
	}
}
