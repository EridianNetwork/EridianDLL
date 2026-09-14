using System;
using UnityEngine;

// Token: 0x02000AAF RID: 2735
public class GridInstance : MonoBehaviour
{
	// Token: 0x06004A39 RID: 19001 RVA: 0x0000311B File Offset: 0x0000131B
	private void Awake()
	{
	}

	// Token: 0x06004A3A RID: 19002 RVA: 0x000308EF File Offset: 0x0002EAEF
	private void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.cyan;
		Gizmos.DrawWireCube(base.transform.position, this.size);
	}

	// Token: 0x0400360E RID: 13838
	[SerializeField]
	public Vector3 size;

	// Token: 0x0400360F RID: 13839
	[SerializeField]
	public Vector3 halfsize;
}
