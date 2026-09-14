using System;

// Token: 0x02000B18 RID: 2840
public class OperationCode
{
	// Token: 0x040038DC RID: 14556
	public const byte Authenticate = 230;

	// Token: 0x040038DD RID: 14557
	public const byte JoinLobby = 229;

	// Token: 0x040038DE RID: 14558
	public const byte LeaveLobby = 228;

	// Token: 0x040038DF RID: 14559
	public const byte CreateGame = 227;

	// Token: 0x040038E0 RID: 14560
	public const byte JoinGame = 226;

	// Token: 0x040038E1 RID: 14561
	public const byte JoinRandomGame = 225;

	// Token: 0x040038E2 RID: 14562
	public const byte Leave = 254;

	// Token: 0x040038E3 RID: 14563
	public const byte RaiseEvent = 253;

	// Token: 0x040038E4 RID: 14564
	public const byte SetProperties = 252;

	// Token: 0x040038E5 RID: 14565
	public const byte GetProperties = 251;

	// Token: 0x040038E6 RID: 14566
	public const byte ChangeGroups = 248;

	// Token: 0x040038E7 RID: 14567
	public const byte QueryRooms = 221;

	// Token: 0x040038E8 RID: 14568
	public const byte CancelJoin = 167;

	// Token: 0x040038E9 RID: 14569
	public const byte CloseGame = 138;

	// Token: 0x040038EA RID: 14570
	public const byte KickPlayerFromGame = 136;

	// Token: 0x040038EB RID: 14571
	public const byte Login = 222;

	// Token: 0x040038EC RID: 14572
	public const byte GetCharacterInfo = 220;

	// Token: 0x040038ED RID: 14573
	public const byte RequestCreateCharacter = 219;

	// Token: 0x040038EE RID: 14574
	public const byte UpdateCharacterName = 218;

	// Token: 0x040038EF RID: 14575
	public const byte UpdateCharacterModel = 217;

	// Token: 0x040038F0 RID: 14576
	public const byte UpdateCharacterExp = 216;

	// Token: 0x040038F1 RID: 14577
	public const byte SelectCharacter_OLD = 214;

	// Token: 0x040038F2 RID: 14578
	public const byte UpdateCharacterInfo = 213;

	// Token: 0x040038F3 RID: 14579
	public const byte RequestItemDNA = 212;

	// Token: 0x040038F4 RID: 14580
	public const byte SendMessage = 211;

	// Token: 0x040038F5 RID: 14581
	public const byte RetrieveMessages = 210;

	// Token: 0x040038F6 RID: 14582
	public const byte MarkAsRead = 209;

	// Token: 0x040038F7 RID: 14583
	public const byte DeleteMessage = 208;

	// Token: 0x040038F8 RID: 14584
	public const byte RetrieveFriendsList = 207;

	// Token: 0x040038F9 RID: 14585
	public const byte IsUserAFriend = 206;

	// Token: 0x040038FA RID: 14586
	public const byte SendFriendRequest = 164;

	// Token: 0x040038FB RID: 14587
	public const byte AcceptFriendRequest = 205;

	// Token: 0x040038FC RID: 14588
	public const byte RejectFriendRequest = 165;

	// Token: 0x040038FD RID: 14589
	public const byte Unfriend = 204;

	// Token: 0x040038FE RID: 14590
	public const byte Ignore = 203;

	// Token: 0x040038FF RID: 14591
	public const byte Unignore = 202;

	// Token: 0x04003900 RID: 14592
	public const byte IsUserIgnored = 201;

	// Token: 0x04003901 RID: 14593
	public const byte GetAllFriendsCharacterInfo = 144;

	// Token: 0x04003902 RID: 14594
	public const byte SendGameInvitation = 200;

	// Token: 0x04003903 RID: 14595
	public const byte AcceptGameInvitation = 137;

	// Token: 0x04003904 RID: 14596
	public const byte AcceptGroupGameInvitation = 199;

	// Token: 0x04003905 RID: 14597
	public const byte JoinSessionInProgress = 198;

	// Token: 0x04003906 RID: 14598
	public const byte IsFriendsGameJoinable = 197;

	// Token: 0x04003907 RID: 14599
	public const byte GetInventory = 196;

	// Token: 0x04003908 RID: 14600
	public const byte SwapInventorySlots = 195;

	// Token: 0x04003909 RID: 14601
	public const byte AddItemsToInventory = 194;

	// Token: 0x0400390A RID: 14602
	public const byte DropItemFromInventory = 193;

	// Token: 0x0400390B RID: 14603
	public const byte UpdateInventory = 177;

	// Token: 0x0400390C RID: 14604
	public const byte Split = 90;

	// Token: 0x0400390D RID: 14605
	public const byte Combine = 89;

	// Token: 0x0400390E RID: 14606
	public const byte Tidy = 88;

	// Token: 0x0400390F RID: 14607
	public const byte GetBackpackProgression = 59;

	// Token: 0x04003910 RID: 14608
	public const byte PurchaseBackpackSize = 58;

	// Token: 0x04003911 RID: 14609
	public const byte EquipWeapon = 192;

	// Token: 0x04003912 RID: 14610
	public const byte UnequipWeapon = 191;

	// Token: 0x04003913 RID: 14611
	public const byte SetActiveWeapon = 190;

	// Token: 0x04003914 RID: 14612
	public const byte EquipNewWeapon = 189;

	// Token: 0x04003915 RID: 14613
	public const byte UpdateAmmoCounts = 188;

	// Token: 0x04003916 RID: 14614
	public const byte SwapWeapons = 166;

	// Token: 0x04003917 RID: 14615
	public const byte GetMyCurrencies = 156;

	// Token: 0x04003918 RID: 14616
	public const byte GetCurrencies = 187;

	// Token: 0x04003919 RID: 14617
	public const byte UpdateCurrencies = 186;

	// Token: 0x0400391A RID: 14618
	public const byte GetSndaPoint = 55;

	// Token: 0x0400391B RID: 14619
	public const byte GetPlayerQuests = 185;

	// Token: 0x0400391C RID: 14620
	public const byte AcceptQuest = 184;

	// Token: 0x0400391D RID: 14621
	public const byte UpdateQuestRequirement = 183;

	// Token: 0x0400391E RID: 14622
	public const byte ClaimQuestRewards = 181;

	// Token: 0x0400391F RID: 14623
	public const byte RejectQuest = 215;

	// Token: 0x04003920 RID: 14624
	public const byte TalkToNPC = 150;

	// Token: 0x04003921 RID: 14625
	public const byte BringToNPC = 145;

	// Token: 0x04003922 RID: 14626
	public const byte CompleteQuest = 142;

	// Token: 0x04003923 RID: 14627
	public const byte GetDailyQuestContents = 141;

	// Token: 0x04003924 RID: 14628
	public const byte GetUnlockedInstances = 180;

	// Token: 0x04003925 RID: 14629
	public const byte CompleteInstance = 179;

	// Token: 0x04003926 RID: 14630
	public const byte UnlockInstance = 178;

	// Token: 0x04003927 RID: 14631
	public const byte GetMySkillPoints = 173;

	// Token: 0x04003928 RID: 14632
	public const byte GetInvestedSkillPoints = 171;

	// Token: 0x04003929 RID: 14633
	public const byte InvestSkillPoint = 170;

	// Token: 0x0400392A RID: 14634
	public const byte InvestMultipleSkillPoints = 169;

	// Token: 0x0400392B RID: 14635
	public const byte ResetSkillPoints = 168;

	// Token: 0x0400392C RID: 14636
	public const byte SendGroupInvitation = 163;

	// Token: 0x0400392D RID: 14637
	public const byte AcceptGroupInvitation = 162;

	// Token: 0x0400392E RID: 14638
	public const byte RejectGroupInvitation = 161;

	// Token: 0x0400392F RID: 14639
	public const byte KickPlayerFromGroup = 160;

	// Token: 0x04003930 RID: 14640
	public const byte LeaveGroup = 159;

	// Token: 0x04003931 RID: 14641
	public const byte GetMyGroupInfo = 158;

	// Token: 0x04003932 RID: 14642
	public const byte SendGameInvitationsToGroup = 157;

	// Token: 0x04003933 RID: 14643
	public const byte RejoinGroup = 151;

	// Token: 0x04003934 RID: 14644
	public const byte SmeltWeapon = 154;

	// Token: 0x04003935 RID: 14645
	public const byte CraftWeapon = 153;

	// Token: 0x04003936 RID: 14646
	public const byte GetMyCraftedWeapons = 143;

	// Token: 0x04003937 RID: 14647
	public const byte RequestSubmitMatchResult = 149;

	// Token: 0x04003938 RID: 14648
	public const byte RequestMatchRecord = 148;

	// Token: 0x04003939 RID: 14649
	public const byte GetPeerPresence = 147;

	// Token: 0x0400393A RID: 14650
	public const byte GetAllFriendsPresence = 146;

	// Token: 0x0400393B RID: 14651
	public const byte SetCurrentTown = 155;

	// Token: 0x0400393C RID: 14652
	public const byte SearchForCharacter = 152;

	// Token: 0x0400393D RID: 14653
	public const byte Chat = 139;

	// Token: 0x0400393E RID: 14654
	public const byte EquipShield = 135;

	// Token: 0x0400393F RID: 14655
	public const byte UnequipShield = 134;

	// Token: 0x04003940 RID: 14656
	public const byte CreateLobby = 87;

	// Token: 0x04003941 RID: 14657
	public const byte OpenLobby = 96;

	// Token: 0x04003942 RID: 14658
	public const byte FindLobby = 133;

	// Token: 0x04003943 RID: 14659
	public const byte InviteToLobby = 132;

	// Token: 0x04003944 RID: 14660
	public const byte AcceptLobbyInvitation = 131;

	// Token: 0x04003945 RID: 14661
	public const byte RejectLobbyInvitation = 130;

	// Token: 0x04003946 RID: 14662
	public const byte KickPlayerFromLobby = 129;

	// Token: 0x04003947 RID: 14663
	public const byte StartLobbyGame = 127;

	// Token: 0x04003948 RID: 14664
	public const byte GetLobby = 126;

	// Token: 0x04003949 RID: 14665
	public const byte CloseLobby = 125;

	// Token: 0x0400394A RID: 14666
	public const byte AcceptLobbyGameInvitation = 124;

	// Token: 0x0400394B RID: 14667
	public const byte SendPvPGameInvitations = 123;

	// Token: 0x0400394C RID: 14668
	public const byte SetTeamID = 122;

	// Token: 0x0400394D RID: 14669
	public const byte SubmitPvPResults = 56;

	// Token: 0x0400394E RID: 14670
	public const byte GetShop = 121;

	// Token: 0x0400394F RID: 14671
	public const byte BuyItem = 120;

	// Token: 0x04003950 RID: 14672
	public const byte SellItem = 119;

	// Token: 0x04003951 RID: 14673
	public const byte RedeemItem = 54;

	// Token: 0x04003952 RID: 14674
	public const byte GetCashShop = 49;

	// Token: 0x04003953 RID: 14675
	public const byte BuyCashItem = 48;

	// Token: 0x04003954 RID: 14676
	public const byte GetMyGuildApplications = 77;

	// Token: 0x04003955 RID: 14677
	public const byte CancelMyGuildApplication = 76;

	// Token: 0x04003956 RID: 14678
	public const byte GetMyGuildNews = 78;

	// Token: 0x04003957 RID: 14679
	public const byte ChangeGuildBanner = 100;

	// Token: 0x04003958 RID: 14680
	public const byte GetMyGuildInfo = 101;

	// Token: 0x04003959 RID: 14681
	public const byte GetMyGuildId = 102;

	// Token: 0x0400395A RID: 14682
	public const byte GetGuildInfo = 103;

	// Token: 0x0400395B RID: 14683
	public const byte CreateGuild = 104;

	// Token: 0x0400395C RID: 14684
	public const byte DismissGuild = 105;

	// Token: 0x0400395D RID: 14685
	public const byte NotifyGuildDismissal = 106;

	// Token: 0x0400395E RID: 14686
	public const byte ChangeGuildMaster = 107;

	// Token: 0x0400395F RID: 14687
	public const byte SearchGuild = 108;

	// Token: 0x04003960 RID: 14688
	public const byte ApplyToGuild = 109;

	// Token: 0x04003961 RID: 14689
	public const byte GetGuildApplications = 110;

	// Token: 0x04003962 RID: 14690
	public const byte ProcessGuildApplications = 111;

	// Token: 0x04003963 RID: 14691
	public const byte QuitGuild = 112;

	// Token: 0x04003964 RID: 14692
	public const byte ExpellFromGuild = 113;

	// Token: 0x04003965 RID: 14693
	public const byte InviteToGuild = 114;

	// Token: 0x04003966 RID: 14694
	public const byte GetMyGuildInvitations = 115;

	// Token: 0x04003967 RID: 14695
	public const byte ProcessGuildInvitations = 116;

	// Token: 0x04003968 RID: 14696
	public const byte GetGuildNews = 117;

	// Token: 0x04003969 RID: 14697
	public const byte UpdateGuildNews = 118;

	// Token: 0x0400396A RID: 14698
	public const byte AssignGuildManager = 73;

	// Token: 0x0400396B RID: 14699
	public const byte DischargeGuildManager = 72;

	// Token: 0x0400396C RID: 14700
	public const byte SubmitPvEGuildExpIncrement = 67;

	// Token: 0x0400396D RID: 14701
	public const byte GetGuildSkillList = 66;

	// Token: 0x0400396E RID: 14702
	public const byte GetMyGuildSkillList = 65;

	// Token: 0x0400396F RID: 14703
	public const byte ActivateGuildSkill = 64;

	// Token: 0x04003970 RID: 14704
	public const byte GetGuildManagerList = 63;

	// Token: 0x04003971 RID: 14705
	public const byte GetWarehouse = 99;

	// Token: 0x04003972 RID: 14706
	public const byte SwapWarehouseSlot = 98;

	// Token: 0x04003973 RID: 14707
	public const byte SwapInventoryWarehouseSlot = 97;

	// Token: 0x04003974 RID: 14708
	public const byte GetMail = 95;

	// Token: 0x04003975 RID: 14709
	public const byte SendMail = 94;

	// Token: 0x04003976 RID: 14710
	public const byte UpdateMailState = 93;

	// Token: 0x04003977 RID: 14711
	public const byte GetMailItems = 92;

	// Token: 0x04003978 RID: 14712
	public const byte DeleteMail = 91;

	// Token: 0x04003979 RID: 14713
	public const byte EquipClassMod = 86;

	// Token: 0x0400397A RID: 14714
	public const byte GetAntiLevel = 85;

	// Token: 0x0400397B RID: 14715
	public const byte GetCharacterList = 84;

	// Token: 0x0400397C RID: 14716
	public const byte SelectCharacter = 83;

	// Token: 0x0400397D RID: 14717
	public const byte CreateCharacter = 82;

	// Token: 0x0400397E RID: 14718
	public const byte GetCharacter = 81;

	// Token: 0x0400397F RID: 14719
	public const byte GetMyCharacter = 80;

	// Token: 0x04003980 RID: 14720
	public const byte UpdateCharacterExperience = 79;

	// Token: 0x04003981 RID: 14721
	public const byte DeleteCharacter = 60;

	// Token: 0x04003982 RID: 14722
	public const byte ConsumeEnergy = 47;

	// Token: 0x04003983 RID: 14723
	public const byte GetPersonalSettings = 75;

	// Token: 0x04003984 RID: 14724
	public const byte SetPersonalSettings = 74;

	// Token: 0x04003985 RID: 14725
	public const byte OpenLuckyBox = 71;

	// Token: 0x04003986 RID: 14726
	public const byte AwardLuckyBox = 70;

	// Token: 0x04003987 RID: 14727
	public const byte UpgradeStarExperience = 69;

	// Token: 0x04003988 RID: 14728
	public const byte UpgradeStarLevel = 68;

	// Token: 0x04003989 RID: 14729
	public const byte GPKAuthReply = 62;

	// Token: 0x0400398A RID: 14730
	public const byte RecordClientDebugInfo = 61;

	// Token: 0x0400398B RID: 14731
	public const byte GetRanking = 57;

	// Token: 0x0400398C RID: 14732
	public const byte GetCharacterSettings = 53;

	// Token: 0x0400398D RID: 14733
	public const byte SetCharacterSettings = 52;

	// Token: 0x0400398E RID: 14734
	public const byte EquipOutfit = 51;

	// Token: 0x0400398F RID: 14735
	public const byte UnequipOutfit = 50;

	// Token: 0x04003990 RID: 14736
	public const byte GetAchievements = 46;

	// Token: 0x04003991 RID: 14737
	public const byte UpdateAchievement = 45;

	// Token: 0x04003992 RID: 14738
	public const byte UpdateCharacterInstanceStat = 44;
}
