using System;

namespace ns0
{
	// Token: 0x02000273 RID: 627
	public enum AsyncTaskStatus
	{
		// Token: 0x04000C1A RID: 3098
		Proceeding,
		// Token: 0x04000C1B RID: 3099
		Success,
		// Token: 0x04000C1C RID: 3100
		Error,
		// Token: 0x04000C1D RID: 3101
		Error_Timeout,
		// Token: 0x04000C1E RID: 3102
		Error_Disconnected,
		// Token: 0x04000C1F RID: 3103
		Error_AuthenticationFail,
		// Token: 0x04000C20 RID: 3104
		Error_NoCharacter,
		// Token: 0x04000C21 RID: 3105
		Error_NameAlreadyExists,
		// Token: 0x04000C22 RID: 3106
		Error_NameContainsIllegalWords,
		// Token: 0x04000C23 RID: 3107
		Error_NameTooLong,
		// Token: 0x04000C24 RID: 3108
		Error_NoAvatar,
		// Token: 0x04000C25 RID: 3109
		Error_JoinRoomFail,
		// Token: 0x04000C26 RID: 3110
		Error_NoPlayer,
		// Token: 0x04000C27 RID: 3111
		Error_NoSpawnPointAvailable,
		// Token: 0x04000C28 RID: 3112
		Error_WrongPassword
	}
}
