using System;
using XsdSettings;

// Token: 0x020002EA RID: 746
public interface ICharacterService
{
	// Token: 0x060010EA RID: 4330
	void imethod_0(OnGetCharacterList onGetCharacterList_0);

	// Token: 0x060010EB RID: 4331
	void imethod_1(OnGetCharacter onGetCharacter_0, int int_0);

	// Token: 0x060010EC RID: 4332
	void imethod_2(OnCreateCharacter onCreateCharacter_0, string string_0, AvatarType avatarType_0, uint uint_0, string string_1, string string_2);

	// Token: 0x060010ED RID: 4333
	void imethod_3(OnGetCharacter onGetCharacter_0);

	// Token: 0x060010EE RID: 4334
	void imethod_4(OnDeleteCharacter onDeleteCharacter_0, int int_0);

	// Token: 0x060010EF RID: 4335
	void imethod_5();

	// Token: 0x060010F0 RID: 4336
	void imethod_6(string string_0);

	// Token: 0x060010F1 RID: 4337
	void imethod_7(byte[] byte_0);

	// Token: 0x060010F2 RID: 4338
	void imethod_8();

	// Token: 0x060010F3 RID: 4339
	void imethod_9(string string_0);

	// Token: 0x060010F4 RID: 4340
	void imethod_10(OnGetCharacter onGetCharacter_0, int int_0);

	// Token: 0x060010F5 RID: 4341
	void imethod_11(OnExperienceUpdated onExperienceUpdated_0);

	// Token: 0x060010F6 RID: 4342
	void imethod_12(OnLevelUp onLevelUp_0);

	// Token: 0x060010F7 RID: 4343
	void imethod_13(OnNotifyAntiAddiction onNotifyAntiAddiction_0);

	// Token: 0x060010F8 RID: 4344
	void imethod_14(OnGetPersonalSettings onGetPersonalSettings_0);

	// Token: 0x060010F9 RID: 4345
	void imethod_15(OnSetPersonalSettings onSetPersonalSettings_0);

	// Token: 0x060010FA RID: 4346
	void imethod_16(OnGPKDynCode onGPKDynCode_0);

	// Token: 0x060010FB RID: 4347
	void imethod_17(OnGPKAuthData onGPKAuthData_0);

	// Token: 0x060010FC RID: 4348
	void imethod_18(OnGPKAuthReply onGPKAuthReply_0);

	// Token: 0x060010FD RID: 4349
	void imethod_19(OnGetCharacterSettings onGetCharacterSettings_0);

	// Token: 0x060010FE RID: 4350
	void imethod_20(OnSetCharacterSettings onSetCharacterSettings_0);

	// Token: 0x060010FF RID: 4351
	void imethod_21(OnExperienceUpdated onExperienceUpdated_0);

	// Token: 0x06001100 RID: 4352
	void imethod_22(OnLevelUp onLevelUp_0);

	// Token: 0x06001101 RID: 4353
	void imethod_23(OnNotifyAntiAddiction onNotifyAntiAddiction_0);

	// Token: 0x06001102 RID: 4354
	void imethod_24(OnGetPersonalSettings onGetPersonalSettings_0);

	// Token: 0x06001103 RID: 4355
	void imethod_25(OnSetPersonalSettings onSetPersonalSettings_0);

	// Token: 0x06001104 RID: 4356
	void imethod_26(OnGPKDynCode onGPKDynCode_0);

	// Token: 0x06001105 RID: 4357
	void imethod_27(OnGPKAuthData onGPKAuthData_0);

	// Token: 0x06001106 RID: 4358
	void imethod_28(OnGPKAuthReply onGPKAuthReply_0);

	// Token: 0x06001107 RID: 4359
	void imethod_29(OnGetCharacterSettings onGetCharacterSettings_0);

	// Token: 0x06001108 RID: 4360
	void imethod_30(OnSetCharacterSettings onSetCharacterSettings_0);
}
