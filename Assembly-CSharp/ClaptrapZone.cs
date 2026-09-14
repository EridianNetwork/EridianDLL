using System;
using ns0;
using UnityEngine;

// Token: 0x0200050F RID: 1295
public class ClaptrapZone : MonoSingleton<ClaptrapZone>
{
	// Token: 0x060021A0 RID: 8608 RVA: 0x000A1788 File Offset: 0x0009F988
	public void OnTriggerStay(Collider other)
	{
		EntityPlayer component = other.GetComponent<EntityPlayer>();
		if (component && component.m_claptrap)
		{
			StatisticsManager.SessionStats currentSession = MonoSingleton<StatisticsManager>.Instance.GetCurrentSession();
			if (currentSession != null)
			{
				currentSession.m_claptrapTeamID = (int)this.m_teamID;
				if (currentSession.m_claptrapScore < this.m_score)
				{
					currentSession.m_claptrapScore = this.m_score;
				}
			}
		}
	}

	// Token: 0x04001656 RID: 5718
	public ClaptrapZone.TeamID m_teamID = ClaptrapZone.TeamID.TeamA;

	// Token: 0x04001657 RID: 5719
	public int m_score = 1;

	// Token: 0x02000510 RID: 1296
	public enum TeamID
	{
		// Token: 0x04001659 RID: 5721
		TeamA = 1,
		// Token: 0x0400165A RID: 5722
		TeamB
	}
}
