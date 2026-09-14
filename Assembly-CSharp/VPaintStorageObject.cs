using System;
using UnityEngine;
using Valkyrie.VPaint;

// Token: 0x02000B85 RID: 2949
public class VPaintStorageObject : ScriptableObject, IVPaintIdentifier
{
	// Token: 0x06004FCA RID: 20426 RVA: 0x0003409A File Offset: 0x0003229A
	public virtual void OnEnable()
	{
		base.hideFlags = HideFlags.HideInHierarchy;
	}

	// Token: 0x06004FCB RID: 20427 RVA: 0x0000311D File Offset: 0x0000131D
	public virtual bool IsEqualTo(IVPaintIdentifier obj)
	{
		return false;
	}
}
