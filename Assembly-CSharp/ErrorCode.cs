using System;

// Token: 0x02000B13 RID: 2835
public class ErrorCode
{
	// Token: 0x04003821 RID: 14369
	public const int Ok = 0;

	// Token: 0x04003822 RID: 14370
	public const int OperationNotAllowedInCurrentState = -3;

	// Token: 0x04003823 RID: 14371
	public const int InvalidOperationCode = -2;

	// Token: 0x04003824 RID: 14372
	public const int InternalServerError = -1;

	// Token: 0x04003825 RID: 14373
	public const int InvalidAuthentication = 32767;

	// Token: 0x04003826 RID: 14374
	public const int GameIdAlreadyExists = 32766;

	// Token: 0x04003827 RID: 14375
	public const int GameFull = 32765;

	// Token: 0x04003828 RID: 14376
	public const int GameClosed = 32764;

	// Token: 0x04003829 RID: 14377
	[Obsolete("No longer used, cause random matchmaking is no longer a process.")]
	public const int AlreadyMatched = 32763;

	// Token: 0x0400382A RID: 14378
	public const int ServerFull = 32762;

	// Token: 0x0400382B RID: 14379
	public const int UserBlocked = 32761;

	// Token: 0x0400382C RID: 14380
	public const int NoRandomMatchFound = 32760;

	// Token: 0x0400382D RID: 14381
	public const int GameDoesNotExist = 32758;

	// Token: 0x0400382E RID: 14382
	public const int MaxCcuReached = 32757;

	// Token: 0x0400382F RID: 14383
	public const int InvalidRegion = 32756;

	// Token: 0x04003830 RID: 14384
	public const int OperationTimedOut = 32754;

	// Token: 0x04003831 RID: 14385
	public const int AppAuthenticationFailed = 32755;

	// Token: 0x04003832 RID: 14386
	public const int CharacterServiceGetError = 32752;

	// Token: 0x04003833 RID: 14387
	public const int CharacterServiceUpdateError = 32751;

	// Token: 0x04003834 RID: 14388
	public const int ItemServiceGetError = 32750;

	// Token: 0x04003835 RID: 14389
	public const int NoImplementation = 32749;

	// Token: 0x04003836 RID: 14390
	public const int ChatTypeError = 32748;

	// Token: 0x04003837 RID: 14391
	public const int ChatGroupError = 32747;

	// Token: 0x04003838 RID: 14392
	public const int ChatNotFriendError = 32746;

	// Token: 0x04003839 RID: 14393
	public const int ChatNotOnlineError = 32745;

	// Token: 0x0400383A RID: 14394
	public const int OutOfLevelRange = 32744;

	// Token: 0x0400383B RID: 14395
	public const int CharacterNotExist = 32743;

	// Token: 0x0400383C RID: 14396
	public const int LoginAlreadyOnline = 32742;

	// Token: 0x0400383D RID: 14397
	public const int MailNotExsit = 32741;

	// Token: 0x0400383E RID: 14398
	public const int MailCharacterNotExist = 32740;

	// Token: 0x0400383F RID: 14399
	public const int MailInBlock = 32739;

	// Token: 0x04003840 RID: 14400
	public const int MailContentLimit = 32738;

	// Token: 0x04003841 RID: 14401
	public const int MailInboxFull = 32737;

	// Token: 0x04003842 RID: 14402
	public const int MailNotItem = 32736;

	// Token: 0x04003843 RID: 14403
	public const int LoginBan = 32735;

	// Token: 0x04003844 RID: 14404
	public const int NicknameContainDirtyword = 32734;

	// Token: 0x04003845 RID: 14405
	public const int NicknameTooLong = 32733;

	// Token: 0x04003846 RID: 14406
	public const int NicknameAlreadyExists = 32732;

	// Token: 0x04003847 RID: 14407
	public const int AppVersionError = 32731;

	// Token: 0x04003848 RID: 14408
	public const int ServerMaintenance = 32730;

	// Token: 0x04003849 RID: 14409
	public const int InventoryFull = 32729;

	// Token: 0x0400384A RID: 14410
	public const int InvalidParameters = 32728;

	// Token: 0x0400384B RID: 14411
	public const int AlreadyPurchased = 32727;

	// Token: 0x0400384C RID: 14412
	public const int NotEnoughCurrency = 32726;

	// Token: 0x0400384D RID: 14413
	public const int NotFound = 32725;

	// Token: 0x0400384E RID: 14414
	public const int NotSupported = 32724;

	// Token: 0x0400384F RID: 14415
	public const int NotEnoughPlayers = 32723;

	// Token: 0x04003850 RID: 14416
	public const int MemberNotFound = 32722;

	// Token: 0x04003851 RID: 14417
	public const int ChatTooFast = 32721;
}
