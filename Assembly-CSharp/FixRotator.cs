using System;
using UnityEngine;

// Token: 0x02000A95 RID: 2709
public class FixRotator : MonoBehaviour
{
	// Token: 0x0600494F RID: 18767 RVA: 0x0002FED2 File Offset: 0x0002E0D2
	private void Awake()
	{
		this.m_myTransform = base.transform;
	}

	// Token: 0x06004950 RID: 18768 RVA: 0x0002FEE0 File Offset: 0x0002E0E0
	private void LateUpdate()
	{
		this.m_myTransform.rotation = Quaternion.Euler(this.m_globalRotationAngles);
	}

	// Token: 0x040035B2 RID: 13746
	private Transform m_myTransform;

	// Token: 0x040035B3 RID: 13747
	public Vector3 m_globalRotationAngles = Vector3.zero;
}
