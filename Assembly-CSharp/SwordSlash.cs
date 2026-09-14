using System;
using UnityEngine;

// Token: 0x02000255 RID: 597
public class SwordSlash : MonoBehaviour
{
	// Token: 0x06000C2F RID: 3119 RVA: 0x0000311B File Offset: 0x0000131B
	private void Start()
	{
	}

	// Token: 0x06000C30 RID: 3120 RVA: 0x00069788 File Offset: 0x00067988
	private void Update()
	{
		this.m_lifeTime -= Time.deltaTime;
		if (this.m_lifeTime < 0f)
		{
			global::UnityEngine.Object.Destroy(base.gameObject);
			return;
		}
		base.transform.position += base.transform.forward * Time.deltaTime * this.m_speed;
	}

	// Token: 0x04000B02 RID: 2818
	[HideInInspector]
	public BHVTaskManager m_BHVTaskManager;

	// Token: 0x04000B03 RID: 2819
	[HideInInspector]
	public GameObject m_attackObject;

	// Token: 0x04000B04 RID: 2820
	[HideInInspector]
	public int m_damagePoint = 10;

	// Token: 0x04000B05 RID: 2821
	public float m_lifeTime = 5f;

	// Token: 0x04000B06 RID: 2822
	public float m_speed = 5f;
}
