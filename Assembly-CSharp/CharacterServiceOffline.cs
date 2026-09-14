using System;
using XsdSettings;

// Token: 0x0200031C RID: 796
public class CharacterServiceOffline : ICharacterService
{
	// Token: 0x0600133C RID: 4924 RVA: 0x0000EEFC File Offset: 0x0000D0FC
	public void imethod_0(OnGetCharacterList onGetCharacterList_0)
	{
		if (onGetCharacterList_0 != null)
		{
			onGetCharacterList_0(null);
		}
	}

	// Token: 0x0600133D RID: 4925 RVA: 0x0000EF08 File Offset: 0x0000D108
	public void imethod_1(OnGetCharacter onGetCharacter_0, int int_0)
	{
		if (onGetCharacter_0 != null)
		{
			onGetCharacter_0(this.m_character);
		}
	}

	// Token: 0x0600133E RID: 4926 RVA: 0x00077424 File Offset: 0x00075624
	public void imethod_2(OnCreateCharacter onCreateCharacter_0, string string_0, AvatarType avatarType_0, uint uint_0, string string_1, string string_2)
	{
		this.m_character = new Character
		{
			Name = string_0,
			AvatarType = avatarType_0,
			AvatarId = uint_0,
			AvatarMaterials = string_2,
			AvatarParts = string_1
		};
		if (onCreateCharacter_0 != null)
		{
			onCreateCharacter_0(CharacterOperationResult.Ok, this.m_character);
		}
	}

	// Token: 0x0600133F RID: 4927 RVA: 0x0000EF08 File Offset: 0x0000D108
	public void imethod_3(OnGetCharacter onGetCharacter_0)
	{
		if (onGetCharacter_0 != null)
		{
			onGetCharacter_0(this.m_character);
		}
	}

	// Token: 0x06001340 RID: 4928 RVA: 0x0000EF08 File Offset: 0x0000D108
	public void imethod_10(OnGetCharacter onGetCharacter_0, int int_0)
	{
		if (onGetCharacter_0 != null)
		{
			onGetCharacter_0(this.m_character);
		}
	}

	// Token: 0x06001341 RID: 4929 RVA: 0x0000EF19 File Offset: 0x0000D119
	public void method_0(OnUpdateCharacterExperience onUpdateCharacterExperience_0, int int_0, int int_1)
	{
		if (onUpdateCharacterExperience_0 != null)
		{
			onUpdateCharacterExperience_0();
		}
	}

	// Token: 0x06001342 RID: 4930 RVA: 0x0000EF24 File Offset: 0x0000D124
	public void imethod_4(OnDeleteCharacter onDeleteCharacter_0, int int_0)
	{
		if (onDeleteCharacter_0 != null)
		{
			onDeleteCharacter_0(true);
		}
	}

	// Token: 0x06001343 RID: 4931 RVA: 0x0000EF30 File Offset: 0x0000D130
	public void method_1(OnConsumeEnergy onConsumeEnergy_0, params int[] int_0)
	{
		if (onConsumeEnergy_0 != null)
		{
			onConsumeEnergy_0(null);
		}
	}

	// Token: 0x06001344 RID: 4932 RVA: 0x0000311B File Offset: 0x0000131B
	public void method_2(int int_0, int int_1, int int_2, int int_3, int int_4, int int_5, int int_6, int int_7, int int_8)
	{
	}

	// Token: 0x06001345 RID: 4933 RVA: 0x0000311B File Offset: 0x0000131B
	public void imethod_5()
	{
	}

	// Token: 0x06001346 RID: 4934 RVA: 0x0000311B File Offset: 0x0000131B
	public void imethod_6(string string_0)
	{
	}

	// Token: 0x06001347 RID: 4935 RVA: 0x0000311B File Offset: 0x0000131B
	public void imethod_8()
	{
	}

	// Token: 0x06001348 RID: 4936 RVA: 0x0000311B File Offset: 0x0000131B
	public void imethod_9(string string_0)
	{
	}

	// Token: 0x06001349 RID: 4937 RVA: 0x0000311B File Offset: 0x0000131B
	public void imethod_7(byte[] byte_0)
	{
	}

	// Token: 0x0600134A RID: 4938 RVA: 0x0000311B File Offset: 0x0000131B
	public void imethod_11(OnExperienceUpdated onExperienceUpdated_0)
	{
	}

	// Token: 0x0600134B RID: 4939 RVA: 0x0000311B File Offset: 0x0000131B
	public void imethod_12(OnLevelUp onLevelUp_0)
	{
	}

	// Token: 0x0600134C RID: 4940 RVA: 0x0000311B File Offset: 0x0000131B
	public void imethod_13(OnNotifyAntiAddiction onNotifyAntiAddiction_0)
	{
	}

	// Token: 0x0600134D RID: 4941 RVA: 0x0000311B File Offset: 0x0000131B
	public void imethod_14(OnGetPersonalSettings onGetPersonalSettings_0)
	{
	}

	// Token: 0x0600134E RID: 4942 RVA: 0x0000311B File Offset: 0x0000131B
	public void imethod_15(OnSetPersonalSettings onSetPersonalSettings_0)
	{
	}

	// Token: 0x0600134F RID: 4943 RVA: 0x0000311B File Offset: 0x0000131B
	public void imethod_21(OnExperienceUpdated onExperienceUpdated_0)
	{
	}

	// Token: 0x06001350 RID: 4944 RVA: 0x0000311B File Offset: 0x0000131B
	public void imethod_22(OnLevelUp onLevelUp_0)
	{
	}

	// Token: 0x06001351 RID: 4945 RVA: 0x0000311B File Offset: 0x0000131B
	public void imethod_23(OnNotifyAntiAddiction onNotifyAntiAddiction_0)
	{
	}

	// Token: 0x06001352 RID: 4946 RVA: 0x0000311B File Offset: 0x0000131B
	public void imethod_24(OnGetPersonalSettings onGetPersonalSettings_0)
	{
	}

	// Token: 0x06001353 RID: 4947 RVA: 0x0000311B File Offset: 0x0000131B
	public void imethod_25(OnSetPersonalSettings onSetPersonalSettings_0)
	{
	}

	// Token: 0x06001354 RID: 4948 RVA: 0x0000311B File Offset: 0x0000131B
	public void imethod_16(OnGPKDynCode onGPKDynCode_0)
	{
	}

	// Token: 0x06001355 RID: 4949 RVA: 0x0000311B File Offset: 0x0000131B
	public void imethod_26(OnGPKDynCode onGPKDynCode_0)
	{
	}

	// Token: 0x06001356 RID: 4950 RVA: 0x0000311B File Offset: 0x0000131B
	public void imethod_17(OnGPKAuthData onGPKAuthData_0)
	{
	}

	// Token: 0x06001357 RID: 4951 RVA: 0x0000311B File Offset: 0x0000131B
	public void imethod_27(OnGPKAuthData onGPKAuthData_0)
	{
	}

	// Token: 0x06001358 RID: 4952 RVA: 0x0000311B File Offset: 0x0000131B
	public void imethod_18(OnGPKAuthReply onGPKAuthReply_0)
	{
	}

	// Token: 0x06001359 RID: 4953 RVA: 0x0000311B File Offset: 0x0000131B
	public void imethod_28(OnGPKAuthReply onGPKAuthReply_0)
	{
	}

	// Token: 0x0600135A RID: 4954 RVA: 0x0000311B File Offset: 0x0000131B
	public void imethod_19(OnGetCharacterSettings onGetCharacterSettings_0)
	{
	}

	// Token: 0x0600135B RID: 4955 RVA: 0x0000311B File Offset: 0x0000131B
	public void imethod_20(OnSetCharacterSettings onSetCharacterSettings_0)
	{
	}

	// Token: 0x0600135C RID: 4956 RVA: 0x0000311B File Offset: 0x0000131B
	public void imethod_29(OnGetCharacterSettings onGetCharacterSettings_0)
	{
	}

	// Token: 0x0600135D RID: 4957 RVA: 0x0000311B File Offset: 0x0000131B
	public void imethod_30(OnSetCharacterSettings onSetCharacterSettings_0)
	{
	}

	// Token: 0x04000E53 RID: 3667
	private Character m_character;
}
