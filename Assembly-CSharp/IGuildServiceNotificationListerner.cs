using System;

// Token: 0x020002E0 RID: 736
public interface IGuildServiceNotificationListerner
{
	// Token: 0x06001092 RID: 4242
	void OnReceivedGuildInvitation(int guildId, string guildMasterNick, string guildName);

	// Token: 0x06001093 RID: 4243
	void OnReceivedGuildJoined(int guildId, string guildName, bool isJoined);

	// Token: 0x06001094 RID: 4244
	void OnReceivedGuildExpelled(int guildId, string guildName, bool isGuildDismissed);

	// Token: 0x06001095 RID: 4245
	void OnReceivedFreeGuildSkillSlotGiven(int guildId, int remainFreeSkillCount);

	// Token: 0x06001096 RID: 4246
	void OnReceivedGuildSkillSelected(int guildId, int skillId, int remainFreeSkillCount);

	// Token: 0x06001097 RID: 4247
	void OnReceivedGuildManagerAssigned(int guildId);

	// Token: 0x06001098 RID: 4248
	void OnReceivedGuildManagerDischarged(int guildId);

	// Token: 0x06001099 RID: 4249
	void OnReceivedGuildMasterChanged(int guildId);
}
