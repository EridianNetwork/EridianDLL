using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x020004E5 RID: 1253
public class ClusterAction_ResetAnimatorSpeed : ClusterAction
{
	// Token: 0x06002152 RID: 8530 RVA: 0x000A0D84 File Offset: 0x0009EF84
	public override object Clone()
	{
		ClusterAction_ResetAnimatorSpeed clusterAction_ResetAnimatorSpeed = ScriptableObject.CreateInstance(base.GetType()) as ClusterAction_ResetAnimatorSpeed;
		clusterAction_ResetAnimatorSpeed.m_npcType = this.m_npcType;
		clusterAction_ResetAnimatorSpeed.m_targetType = this.m_targetType;
		clusterAction_ResetAnimatorSpeed.m_targetObject = this.m_targetObject;
		clusterAction_ResetAnimatorSpeed.m_newAnimatorSpeed = this.m_newAnimatorSpeed;
		clusterAction_ResetAnimatorSpeed.m_resetType = this.m_resetType;
		clusterAction_ResetAnimatorSpeed.m_executionOrder = this.m_executionOrder;
		return clusterAction_ResetAnimatorSpeed;
	}

	// Token: 0x040015E5 RID: 5605
	public static Dictionary<string, float> m_storedSpeeds = new Dictionary<string, float>();

	// Token: 0x040015E6 RID: 5606
	public EntityNpc.EntitySubType m_npcType;

	// Token: 0x040015E7 RID: 5607
	public Scene.TargetType m_targetType;

	// Token: 0x040015E8 RID: 5608
	public GameObject m_targetObject;

	// Token: 0x040015E9 RID: 5609
	public float m_newAnimatorSpeed = 1f;

	// Token: 0x040015EA RID: 5610
	public ClusterAction_ResetAnimatorSpeed.ResetType m_resetType = ClusterAction_ResetAnimatorSpeed.ResetType.RestoreOriginalSpeed;

	// Token: 0x020004E6 RID: 1254
	public enum ResetType
	{
		// Token: 0x040015EC RID: 5612
		SetNewSpeed,
		// Token: 0x040015ED RID: 5613
		RestoreOriginalSpeed
	}
}
