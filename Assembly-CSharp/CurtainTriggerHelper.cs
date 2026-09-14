using System;
using UnityEngine;

// Token: 0x02000081 RID: 129
public class CurtainTriggerHelper : MonoBehaviour
{
	// Token: 0x060002B4 RID: 692 RVA: 0x00042354 File Offset: 0x00040554
	private void Start()
	{
		if (base.gameObject.collider != null)
		{
			base.gameObject.collider.isTrigger = true;
			Rigidbody rigidbody = base.gameObject.AddComponent<Rigidbody>();
			rigidbody.useGravity = false;
			rigidbody.isKinematic = true;
		}
	}

	// Token: 0x060002B5 RID: 693 RVA: 0x000423A0 File Offset: 0x000405A0
	private void OnTriggerEnter(Collider intruder)
	{
		string text = intruder.gameObject.ToString();
		if (text.ToLower().Contains("boundingbox") && this.m_curtainManager != null)
		{
			this.m_curtainManager.OnTriggerEnter(intruder);
		}
	}

	// Token: 0x04000290 RID: 656
	public CurtainMecanimManager m_curtainManager;
}
