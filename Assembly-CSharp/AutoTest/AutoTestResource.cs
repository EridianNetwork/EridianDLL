using System;
using UnityEngine;

namespace AutoTest
{
	// Token: 0x0200063B RID: 1595
	internal abstract class AutoTestResource
	{
		// Token: 0x0600287B RID: 10363 RVA: 0x0001AA32 File Offset: 0x00018C32
		public AutoTestResource(GameObject obj)
		{
			this.Obj = obj;
		}

		// Token: 0x170001FD RID: 509
		// (get) Token: 0x0600287C RID: 10364 RVA: 0x0001AA48 File Offset: 0x00018C48
		// (set) Token: 0x0600287D RID: 10365 RVA: 0x0001AA50 File Offset: 0x00018C50
		public GameObject Obj { get; private set; }

		// Token: 0x04001CB0 RID: 7344
		public bool m_usable = true;
	}
}
