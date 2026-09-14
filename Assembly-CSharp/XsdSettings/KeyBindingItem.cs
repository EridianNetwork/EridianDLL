using System;

namespace XsdSettings
{
	// Token: 0x020009A7 RID: 2471
	public class KeyBindingItem
	{
		// Token: 0x170005BA RID: 1466
		// (get) Token: 0x060044B7 RID: 17591 RVA: 0x0002D898 File Offset: 0x0002BA98
		// (set) Token: 0x060044B8 RID: 17592 RVA: 0x0002D8A0 File Offset: 0x0002BAA0
		public ControlAction mControlAction { get; set; }

		// Token: 0x170005BB RID: 1467
		// (get) Token: 0x060044B9 RID: 17593 RVA: 0x0002D8A9 File Offset: 0x0002BAA9
		// (set) Token: 0x060044BA RID: 17594 RVA: 0x0002D8B1 File Offset: 0x0002BAB1
		public KeyboardCode mPrimaryKey { get; set; }

		// Token: 0x170005BC RID: 1468
		// (get) Token: 0x060044BB RID: 17595 RVA: 0x0002D8BA File Offset: 0x0002BABA
		// (set) Token: 0x060044BC RID: 17596 RVA: 0x0002D8C2 File Offset: 0x0002BAC2
		public KeyboardCode mSecondaryKey { get; set; }

		// Token: 0x170005BD RID: 1469
		// (get) Token: 0x060044BD RID: 17597 RVA: 0x0002D8CB File Offset: 0x0002BACB
		// (set) Token: 0x060044BE RID: 17598 RVA: 0x0002D8D3 File Offset: 0x0002BAD3
		public ControlGroup mControlGroup { get; set; }

		// Token: 0x04003020 RID: 12320
		private ControlAction mControlActionField;

		// Token: 0x04003021 RID: 12321
		private KeyboardCode mPrimaryKeyField;

		// Token: 0x04003022 RID: 12322
		private KeyboardCode mSecondaryKeyField;

		// Token: 0x04003023 RID: 12323
		private ControlGroup mControlGroupField;
	}
}
