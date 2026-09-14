using System;
using UnityEngine;

// Token: 0x02000501 RID: 1281
public class ClusterCondition_PickupItem : ClusterCondition, ILootListener
{
	// Token: 0x06002180 RID: 8576 RVA: 0x000A1314 File Offset: 0x0009F514
	public override object Clone()
	{
		ClusterCondition_PickupItem clusterCondition_PickupItem = ScriptableObject.CreateInstance(base.GetType()) as ClusterCondition_PickupItem;
		clusterCondition_PickupItem.m_itemType = this.m_itemType;
		clusterCondition_PickupItem.m_ownerCluster = this.m_ownerCluster;
		clusterCondition_PickupItem.m_isValid = this.m_isValid;
		return clusterCondition_PickupItem;
	}

	// Token: 0x06002181 RID: 8577 RVA: 0x0000311B File Offset: 0x0000131B
	public void OnPickedUp(EntityPlayer picker, EntityObject item)
	{
	}

	// Token: 0x0400162C RID: 5676
	public EntityObject.EntitySubType m_itemType = EntityObject.EntitySubType.Weapon;
}
