using System;

// Token: 0x0200052A RID: 1322
[Serializable]
public class ClusterCompletionCondition : OldClusterCondition
{
	// Token: 0x06002205 RID: 8709 RVA: 0x00017727 File Offset: 0x00015927
	public override bool vmethod_0()
	{
		if (!this.m_isValid && this.m_cluster != null && this.m_cluster.method_0() == Scene.SceneState.Completed)
		{
			this.m_isValid = true;
		}
		return this.m_isValid;
	}

	// Token: 0x040016A6 RID: 5798
	public Scene m_cluster;
}
