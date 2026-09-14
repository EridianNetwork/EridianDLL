using System;
using UnityEngine;

// Token: 0x020000D2 RID: 210
public class LODTag : MonoBehaviour
{
	// Token: 0x060004F0 RID: 1264 RVA: 0x000066EF File Offset: 0x000048EF
	private void Start()
	{
		LODSystem.smethod_0(base.gameObject, this.levelsOfDetial);
	}

	// Token: 0x060004F1 RID: 1265 RVA: 0x0000311B File Offset: 0x0000131B
	private void Update()
	{
	}

	// Token: 0x0400049D RID: 1181
	public int levelsOfDetial = 3;
}
