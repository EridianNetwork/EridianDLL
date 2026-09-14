using System;
using System.Collections.Generic;

// Token: 0x020003F1 RID: 1009
public interface ISkillTreeServiceNotificationListerner
{
	// Token: 0x06001959 RID: 6489
	void OnGetInvestedSkillPt(int characterId, List<InvestedSkill> investedSkillPoints);

	// Token: 0x0600195A RID: 6490
	void OnGetPlayerSkillPt(int characterId, int earned, int unspent, List<InvestedSkill> investedSkillPoints);

	// Token: 0x0600195B RID: 6491
	void OnInvestedSkillPt(int characterId, int skillId, bool wasSuccessful);

	// Token: 0x0600195C RID: 6492
	void OnResetSkillPt(int characterId, bool wasSuccessful);

	// Token: 0x0600195D RID: 6493
	void OnSkillPtEarned(int characterId, int numEarned);
}
