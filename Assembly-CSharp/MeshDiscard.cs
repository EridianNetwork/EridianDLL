using System;
using UnityEngine;

// Token: 0x020005C9 RID: 1481
public class MeshDiscard : MonoBehaviour
{
	// Token: 0x06002573 RID: 9587 RVA: 0x0000311B File Offset: 0x0000131B
	private void Start()
	{
	}

	// Token: 0x06002574 RID: 9588 RVA: 0x000B40DC File Offset: 0x000B22DC
	private void Update()
	{
		MeshRenderer component = base.gameObject.GetComponent<MeshRenderer>();
		if (component != null)
		{
			Material material = component.material;
			material.SetVector("_StartPosInWS", this.mStartPos.transform.position);
			material.SetVector("_StopPostInWS", this.mStopPos.transform.position);
			material.SetVector("_CurPosInWS", this.mCurPos.transform.position);
		}
	}

	// Token: 0x04001AD7 RID: 6871
	public GameObject mStartPos;

	// Token: 0x04001AD8 RID: 6872
	public GameObject mStopPos;

	// Token: 0x04001AD9 RID: 6873
	public GameObject mCurPos;
}
