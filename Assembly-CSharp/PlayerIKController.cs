using System;
using UnityEngine;

// Token: 0x02000088 RID: 136
public class PlayerIKController : MonoBehaviour
{
	// Token: 0x060002E3 RID: 739 RVA: 0x00004B9B File Offset: 0x00002D9B
	public void method_0(Vector3 vector3_0)
	{
		this.m_hasValidTargetPosition = true;
		this.m_targetPosition = vector3_0;
	}

	// Token: 0x060002E4 RID: 740 RVA: 0x00004BAB File Offset: 0x00002DAB
	public void method_1()
	{
		this.m_hasValidTargetPosition = false;
	}

	// Token: 0x060002E5 RID: 741 RVA: 0x00004BB4 File Offset: 0x00002DB4
	private void Start()
	{
		this.m_animator = base.GetComponent<Animator>();
	}

	// Token: 0x060002E6 RID: 742 RVA: 0x00043498 File Offset: 0x00041698
	private void OnAnimatorIK(int layerIndex)
	{
		if (this.m_enableAimIK && layerIndex == 0 && this.m_hasValidTargetPosition)
		{
			this.m_animator.SetLookAtWeight(1f, 0.6f, 0.6f, 1f, 0.5f);
			this.m_animator.SetLookAtPosition(this.m_targetPosition);
		}
	}

	// Token: 0x040002BF RID: 703
	public Animator m_animator;

	// Token: 0x040002C0 RID: 704
	public bool m_enableAimIK;

	// Token: 0x040002C1 RID: 705
	private Vector3 m_targetPosition = Vector3.zero;

	// Token: 0x040002C2 RID: 706
	private bool m_hasValidTargetPosition;
}
