using System;

// Token: 0x02000B16 RID: 2838
public class EventCode
{
	// Token: 0x04003865 RID: 14437
	public const byte GuildMemberQuit = 240;

	// Token: 0x04003866 RID: 14438
	public const byte GuildMemberJoined = 239;

	// Token: 0x04003867 RID: 14439
	public const byte GuildMasterChanged = 238;

	// Token: 0x04003868 RID: 14440
	public const byte GuildManagerDischarged = 237;

	// Token: 0x04003869 RID: 14441
	public const byte GuildManagerAssigned = 236;

	// Token: 0x0400386A RID: 14442
	public const byte GuildSkillSelected = 235;

	// Token: 0x0400386B RID: 14443
	public const byte FreeGuildSkillSlotGiven = 234;

	// Token: 0x0400386C RID: 14444
	public const byte GuildExpelled = 233;

	// Token: 0x0400386D RID: 14445
	public const byte GuildJoined = 232;

	// Token: 0x0400386E RID: 14446
	public const byte GuildInvitation = 231;

	// Token: 0x0400386F RID: 14447
	public const byte GameList = 230;

	// Token: 0x04003870 RID: 14448
	public const byte GameListUpdate = 229;

	// Token: 0x04003871 RID: 14449
	public const byte QueueState = 228;

	// Token: 0x04003872 RID: 14450
	public const byte Match = 227;

	// Token: 0x04003873 RID: 14451
	public const byte AppStats = 226;

	// Token: 0x04003874 RID: 14452
	public const byte AzureNodeInfo = 210;

	// Token: 0x04003875 RID: 14453
	public const byte Join = 255;

	// Token: 0x04003876 RID: 14454
	public const byte Leave = 254;

	// Token: 0x04003877 RID: 14455
	public const byte PropertiesChanged = 253;

	// Token: 0x04003878 RID: 14456
	[Obsolete("Use PropertiesChanged now.")]
	public const byte SetProperties = 253;

	// Token: 0x04003879 RID: 14457
	public const byte NewMessage = 223;

	// Token: 0x0400387A RID: 14458
	public const byte InventoryUpdated = 222;

	// Token: 0x0400387B RID: 14459
	public const byte InventoryAction = 221;

	// Token: 0x0400387C RID: 14460
	public const byte InstanceCompleted = 219;

	// Token: 0x0400387D RID: 14461
	public const byte InstanceUnlocked = 205;

	// Token: 0x0400387E RID: 14462
	public const byte CurrenciesUpdated = 218;

	// Token: 0x0400387F RID: 14463
	public const byte SndaPointUpdated = 156;

	// Token: 0x04003880 RID: 14464
	public const byte QuestStatusUpdated = 220;

	// Token: 0x04003881 RID: 14465
	public const byte QuestTaskCompleted = 217;

	// Token: 0x04003882 RID: 14466
	public const byte QuestRewardClaimed = 215;

	// Token: 0x04003883 RID: 14467
	public const byte SkillPointEarned = 216;

	// Token: 0x04003884 RID: 14468
	public const byte KickedFromGroup = 215;

	// Token: 0x04003885 RID: 14469
	public const byte NewGroupLeader = 214;

	// Token: 0x04003886 RID: 14470
	public const byte NewGroupMember = 213;

	// Token: 0x04003887 RID: 14471
	public const byte GroupInviteRejected = 212;

	// Token: 0x04003888 RID: 14472
	public const byte GroupMemberLeft = 211;

	// Token: 0x04003889 RID: 14473
	public const byte GroupGameStarted = 210;

	// Token: 0x0400388A RID: 14474
	public const byte GroupDisbanded = 209;

	// Token: 0x0400388B RID: 14475
	public const byte GroupMatchmakingStarted = 165;

	// Token: 0x0400388C RID: 14476
	public const byte NewFriend = 208;

	// Token: 0x0400388D RID: 14477
	public const byte Unfriended = 207;

	// Token: 0x0400388E RID: 14478
	public const byte RejectFriend = 155;

	// Token: 0x0400388F RID: 14479
	public const byte ExperienceUpdated = 206;

	// Token: 0x04003890 RID: 14480
	public const byte CharacterInfoUpdated = 204;

	// Token: 0x04003891 RID: 14481
	public const byte Chat = 199;

	// Token: 0x04003892 RID: 14482
	public const byte SendChatOk = 198;

	// Token: 0x04003893 RID: 14483
	public const byte GameOwnerChanged = 197;

	// Token: 0x04003894 RID: 14484
	public const byte KickedFromGame = 196;

	// Token: 0x04003895 RID: 14485
	public const byte PresenceUpdated = 195;

	// Token: 0x04003896 RID: 14486
	public const byte PlayerJoinedLobby = 194;

	// Token: 0x04003897 RID: 14487
	public const byte PlayerLeftLobby = 193;

	// Token: 0x04003898 RID: 14488
	public const byte LobbyCreated = 166;

	// Token: 0x04003899 RID: 14489
	public const byte LobbyGameStarted = 192;

	// Token: 0x0400389A RID: 14490
	public const byte LobbyClosed = 191;

	// Token: 0x0400389B RID: 14491
	public const byte LobbyOwnerChanged = 190;

	// Token: 0x0400389C RID: 14492
	public const byte GroupJoinedLobby = 189;

	// Token: 0x0400389D RID: 14493
	public const byte GroupLeaveLobby = 188;

	// Token: 0x0400389E RID: 14494
	public const byte LobbyOpened = 164;

	// Token: 0x0400389F RID: 14495
	public const byte QuestClearDailyQuest = 170;

	// Token: 0x040038A0 RID: 14496
	public const byte QuestTaskUpdated = 169;

	// Token: 0x040038A1 RID: 14497
	public const byte LobbyDelete = 152;

	// Token: 0x040038A2 RID: 14498
	public const byte WarehouseUpdated = 168;

	// Token: 0x040038A3 RID: 14499
	public const byte NewMail = 167;

	// Token: 0x040038A4 RID: 14500
	public const byte MailList = 161;

	// Token: 0x040038A5 RID: 14501
	public const byte KickPlayer = 163;

	// Token: 0x040038A6 RID: 14502
	public const byte NotifyAntiAddiction = 162;

	// Token: 0x040038A7 RID: 14503
	public const byte Announcements = 160;

	// Token: 0x040038A8 RID: 14504
	public const byte NotifyAntiAddictionLevel = 159;

	// Token: 0x040038A9 RID: 14505
	public const byte GPKDynCode = 158;

	// Token: 0x040038AA RID: 14506
	public const byte GPKAuthData = 157;

	// Token: 0x040038AB RID: 14507
	public const byte AchievementUpdated = 154;

	// Token: 0x040038AC RID: 14508
	public const byte Shutdown = 153;
}
