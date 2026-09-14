using System;
using UnityEngine;
using XsdSettings;

// Token: 0x020004DA RID: 1242
public class ClusterAction_GiveAmmo : ClusterAction
{
	// Token: 0x0600213E RID: 8510 RVA: 0x000A0B2C File Offset: 0x0009ED2C
	public override object Clone()
	{
		ClusterAction_GiveAmmo clusterAction_GiveAmmo = ScriptableObject.CreateInstance(base.GetType()) as ClusterAction_GiveAmmo;
		clusterAction_GiveAmmo.m_ammoType = this.m_ammoType;
		clusterAction_GiveAmmo.m_count = this.m_count;
		clusterAction_GiveAmmo.m_executionOrder = this.m_executionOrder;
		return clusterAction_GiveAmmo;
	}

	// Token: 0x040015CC RID: 5580
	public AmmoType m_ammoType;

	// Token: 0x040015CD RID: 5581
	public int m_count = 10;
}
