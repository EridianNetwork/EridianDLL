using System;
using UnityEngine;

namespace Core
{
	// Token: 0x020002B7 RID: 695
	[Serializable]
	public class UIMessage
	{
		// Token: 0x04000D4D RID: 3405
		public UIMessage.GEnum1 m_type;

		// Token: 0x04000D4E RID: 3406
		public string m_text = "Default Text";

		// Token: 0x04000D4F RID: 3407
		public float m_duration = 5f;

		// Token: 0x04000D50 RID: 3408
		public bool m_displayCountDown;

		// Token: 0x04000D51 RID: 3409
		[HideInInspector]
		public float m_decayDate;

		// Token: 0x020002B8 RID: 696
		public enum GEnum1
		{
			// Token: 0x04000D53 RID: 3411
			const_0,
			// Token: 0x04000D54 RID: 3412
			const_1,
			// Token: 0x04000D55 RID: 3413
			const_2,
			// Token: 0x04000D56 RID: 3414
			const_3,
			// Token: 0x04000D57 RID: 3415
			const_4,
			// Token: 0x04000D58 RID: 3416
			const_5,
			// Token: 0x04000D59 RID: 3417
			const_6
		}
	}
}
