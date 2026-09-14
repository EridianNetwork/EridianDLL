using System;
using UnityEngine;

// Token: 0x02000A8A RID: 2698
public class DeadTimeController : MonoBehaviour
{
	// Token: 0x06004900 RID: 18688 RVA: 0x0002FA61 File Offset: 0x0002DC61
	private void Awake()
	{
		global::UnityEngine.Object.Destroy(base.gameObject, this.DeadTime);
	}

	// Token: 0x04003584 RID: 13700
	public float DeadTime = 1f;
}
