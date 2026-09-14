using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Core;
using ns0;
using XsdSettings;

// Token: 0x0200034E RID: 846
public class CharacterService : OnAccessSingleton<ICharacterService, CharacterService, CharacterServiceOffline>, ICharacterService
{
	// Token: 0x0600156D RID: 5485 RVA: 0x00079CF0 File Offset: 0x00077EF0
	public CharacterService()
	{
		PhotonNetwork.onlinePeer.method_5(84, new OperationResponseCallback(this.OnGetCharacterListResponse));
		PhotonNetwork.onlinePeer.method_5(83, new OperationResponseCallback(this.OnSelectCharacterResponse));
		PhotonNetwork.onlinePeer.method_5(82, new OperationResponseCallback(this.OnCreateCharacterResponse));
		PhotonNetwork.onlinePeer.method_5(80, new OperationResponseCallback(this.OnGetCharacterResponse));
		PhotonNetwork.onlinePeer.method_5(60, new OperationResponseCallback(this.OnDeleteCharacterResponse));
		PhotonNetwork.onlinePeer.method_5(81, new OperationResponseCallback(this.OnGetCharacterResponse));
		PhotonNetwork.onlinePeer.method_5(79, new OperationResponseCallback(this.OnUpdateCharacterExperienceResponse));
		PhotonNetwork.onlinePeer.method_5(47, new OperationResponseCallback(this.OnConsumeEnergyResponse));
		PhotonNetwork.onlinePeer.method_5(44, new OperationResponseCallback(this.OnUpdateCharacterInstanceStatResponse));
		PhotonNetwork.onlinePeer.method_5(75, new OperationResponseCallback(this.OnGetPersonalSettingsResponse));
		PhotonNetwork.onlinePeer.method_5(74, new OperationResponseCallback(this.OnSetPersonalSettingsResponse));
		PhotonNetwork.onlinePeer.method_5(62, new OperationResponseCallback(this.OnGPKAuthReplyResponse));
		PhotonNetwork.onlinePeer.method_5(53, new OperationResponseCallback(this.OnGetCharacterSettingsResponse));
		PhotonNetwork.onlinePeer.method_5(52, new OperationResponseCallback(this.OnSetCharacterSettingsResponse));
		PhotonNetwork.onlinePeer.method_7(206, new EventCallback(this.OnExperienceUpdatedEvent));
		PhotonNetwork.onlinePeer.method_7(204, new EventCallback(this.OnLevelUpEvent));
		PhotonNetwork.onlinePeer.method_7(162, new EventCallback(this.OnNotifyAntiAddictionEvent));
	}

	// Token: 0x0600156E RID: 5486 RVA: 0x0000FAB3 File Offset: 0x0000DCB3
	public void imethod_0(OnGetCharacterList onGetCharacterList_0)
	{
		if (onGetCharacterList_0 != null)
		{
			this.mOnGetCharacterList.Add(onGetCharacterList_0);
		}
		PhotonNetwork.onlinePeer.method_3(84, new object[0]);
	}

	// Token: 0x0600156F RID: 5487 RVA: 0x00079F70 File Offset: 0x00078170
	private void OnGetCharacterListResponse(short result, Dictionary<byte, object> parameters)
	{
		if (result == 0)
		{
			List<Character> characters = new List<Character>();
			foreach (DictionaryEntry item in (Hashtable)parameters[0])
			{
				characters.Add(new Character((Hashtable)item.Value));
			}
			mOnGetCharacterList.ForEach(delegate(OnGetCharacterList onGetCharacterList_0)
			{
				onGetCharacterList_0(characters);
			});
		}
		else
		{
			mOnGetCharacterList.ForEach(delegate(OnGetCharacterList onGetCharacterList_0)
			{
				onGetCharacterList_0(null);
			});
		}
		mOnGetCharacterList.Clear();
	}
	// Token: 0x06001570 RID: 5488 RVA: 0x0000FAD7 File Offset: 0x0000DCD7
	public void imethod_1(OnGetCharacter onGetCharacter_0, int int_0)
	{
		if (onGetCharacter_0 != null)
		{
			this.mOnSelectCharacter.Add(onGetCharacter_0);
		}
		PhotonNetwork.onlinePeer.method_3(83, new object[] { int_0 });
	}

	// Token: 0x06001571 RID: 5489 RVA: 0x0007A04C File Offset: 0x0007824C
	private void OnSelectCharacterResponse(short result, Dictionary<byte, object> parameters)
	{
		if (result == 0)
		{
			Character character = new Character((Hashtable)parameters[0]);
			mOnSelectCharacter.ForEach(delegate(OnGetCharacter onGetCharacter_0)
			{
				onGetCharacter_0(character);
			});
		}
		else
		{
			mOnSelectCharacter.ForEach(delegate(OnGetCharacter onGetCharacter_0)
			{
				onGetCharacter_0(null);
			});
		}
		mOnSelectCharacter.Clear();
	}
	// Token: 0x06001572 RID: 5490 RVA: 0x0007A0C8 File Offset: 0x000782C8
	public void imethod_2(OnCreateCharacter onCreateCharacter_0, string string_0, AvatarType avatarType_0, uint uint_0, string string_1, string string_2)
	{
		if (onCreateCharacter_0 != null)
		{
			this.mOnCreateCharacter.Add(onCreateCharacter_0);
		}
		PhotonNetwork.onlinePeer.method_3(82, new object[]
		{
			string_0,
			(int)avatarType_0,
			uint_0.ToString(),
			string_1,
			string_2
		});
	}

	// Token: 0x06001573 RID: 5491 RVA: 0x0007A118 File Offset: 0x00078318
	private void OnCreateCharacterResponse(short result, Dictionary<byte, object> parameters)
	{
		if (result == 0)
		{
			Character character = new Character((Hashtable)parameters[0]);
			mOnCreateCharacter.ForEach(delegate(OnCreateCharacter onCreateCharacter_0)
			{
				onCreateCharacter_0(CharacterOperationResult.Ok, character);
			});
		}
		else
		{
			CharacterOperationResult errorCode = CharacterOperationResult.Error_Unknown;
			switch (result)
			{
			case 32732:
				errorCode = CharacterOperationResult.Error_NameAlreadyExists;
				break;
			case 32733:
				errorCode = CharacterOperationResult.Error_NameTooLong;
				break;
			case 32734:
				errorCode = CharacterOperationResult.Error_NameContainsIllegalWords;
				break;
			}
			mOnCreateCharacter.ForEach(delegate(OnCreateCharacter onCreateCharacter_0)
			{
				onCreateCharacter_0(errorCode, null);
			});
		}
		mOnCreateCharacter.Clear();
	}
	// Token: 0x06001574 RID: 5492 RVA: 0x0000FB04 File Offset: 0x0000DD04
	public void imethod_3(OnGetCharacter onGetCharacter_0)
	{
		if (onGetCharacter_0 != null)
		{
			this.mOnGetCharacter.Add(onGetCharacter_0);
		}
		PhotonNetwork.onlinePeer.method_3(80, new object[0]);
	}

	// Token: 0x06001575 RID: 5493 RVA: 0x0000FB28 File Offset: 0x0000DD28
	public void imethod_10(OnGetCharacter onGetCharacter_0, int int_0)
	{
		if (onGetCharacter_0 != null)
		{
			this.mOnGetCharacter.Add(onGetCharacter_0);
		}
		PhotonNetwork.onlinePeer.method_3(81, new object[] { int_0 });
	}

	// Token: 0x06001576 RID: 5494 RVA: 0x0007A1C4 File Offset: 0x000783C4
	private void OnGetCharacterResponse(short result, Dictionary<byte, object> parameters)
	{
		if (result == 0)
		{
			Character character = new Character((Hashtable)parameters[0]);
			mOnGetCharacter.ForEach(delegate(OnGetCharacter onGetCharacter_0)
			{
				onGetCharacter_0(character);
			});
		}
		else
		{
			mOnGetCharacter.ForEach(delegate(OnGetCharacter onGetCharacter_0)
			{
				onGetCharacter_0(null);
			});
		}
		mOnGetCharacter.Clear();
	}
	// Token: 0x06001577 RID: 5495 RVA: 0x0000FB55 File Offset: 0x0000DD55
	public void method_0(OnUpdateCharacterExperience onUpdateCharacterExperience_0, int int_0, int int_1)
	{
		if (onUpdateCharacterExperience_0 != null)
		{
			this.mOnUpdateCharacterExperience.Add(onUpdateCharacterExperience_0);
		}
		PhotonNetwork.onlinePeer.method_3(79, new object[] { int_0, int_1 });
	}

	// Token: 0x06001578 RID: 5496 RVA: 0x0000FB8B File Offset: 0x0000DD8B
	public void imethod_4(OnDeleteCharacter onDeleteCharacter_0, int int_0)
	{
		if (onDeleteCharacter_0 != null)
		{
			this.mOnDeleteCharacter.Add(onDeleteCharacter_0);
		}
		PhotonNetwork.onlinePeer.method_3(60, new object[] { int_0 });
	}

	// Token: 0x06001579 RID: 5497 RVA: 0x0007A240 File Offset: 0x00078440
	private void OnDeleteCharacterResponse(short result, Dictionary<byte, object> parameters)
	{
		if (result == 0)
		{
			this.mOnDeleteCharacter.ForEach(new Action<OnDeleteCharacter>(CharacterService.smethod_3));
		}
		else
		{
			this.mOnDeleteCharacter.ForEach(new Action<OnDeleteCharacter>(CharacterService.smethod_4));
		}
		this.mOnDeleteCharacter.Clear();
	}

	// Token: 0x0600157A RID: 5498 RVA: 0x0000FBB8 File Offset: 0x0000DDB8
	public void method_1(OnConsumeEnergy onConsumeEnergy_0, params int[] int_0)
	{
		if (onConsumeEnergy_0 != null)
		{
			this.mOnConsumeEnergy.Add(onConsumeEnergy_0);
		}
		PhotonNetwork.onlinePeer.method_3(47, new object[] { int_0 });
	}

	// Token: 0x0600157B RID: 5499 RVA: 0x0007A2B0 File Offset: 0x000784B0
	private void OnConsumeEnergyResponse(short result, Dictionary<byte, object> parameters)
	{
		int[] characterIds = (int[])parameters[0];
		mOnConsumeEnergy.ForEach(delegate(OnConsumeEnergy onConsumeEnergy_0)
		{
			onConsumeEnergy_0(characterIds);
		});
		mOnConsumeEnergy.Clear();
	}
	// Token: 0x0600157C RID: 5500 RVA: 0x0007A2F8 File Offset: 0x000784F8
	public void method_2(int int_0, int int_1, int int_2, int int_3, int int_4, int int_5, int int_6, int int_7, int int_8)
	{
		PhotonNetwork.onlinePeer.method_3(44, new object[] { int_0, int_1, int_2, int_3, int_4, int_5, int_6, int_7, int_8 });
	}

	// Token: 0x0600157D RID: 5501 RVA: 0x0000311B File Offset: 0x0000131B
	private void OnUpdateCharacterInstanceStatResponse(short result, Dictionary<byte, object> parameters)
	{
	}

	// Token: 0x0600157E RID: 5502 RVA: 0x0000FBE0 File Offset: 0x0000DDE0
	public void imethod_5()
	{
		PhotonNetwork.onlinePeer.method_3(75, new object[0]);
	}

	// Token: 0x0600157F RID: 5503 RVA: 0x0000FBF5 File Offset: 0x0000DDF5
	public void imethod_6(string string_0)
	{
		PhotonNetwork.onlinePeer.method_3(74, new object[] { string_0 });
	}

	// Token: 0x06001580 RID: 5504 RVA: 0x0007A370 File Offset: 0x00078570
	private void OnUpdateCharacterExperienceResponse(short result, Dictionary<byte, object> parameters)
	{
		if (result == 0)
		{
			this.mOnUpdateCharacterExperience.ForEach(new Action<OnUpdateCharacterExperience>(CharacterService.smethod_5));
		}
		else
		{
			this.mOnGetCharacter.ForEach(new Action<OnGetCharacter>(CharacterService.smethod_6));
		}
		this.mOnUpdateCharacterExperience.Clear();
	}

	// Token: 0x06001581 RID: 5505 RVA: 0x0007A3E0 File Offset: 0x000785E0
	private void OnGetPersonalSettingsResponse(short result, Dictionary<byte, object> parameters)
	{
		if (result == 0)
		{
			string settings = (string)parameters[0];
			mOnGetPersonalSettings.ForEach(delegate(OnGetPersonalSettings onGetPersonalSettings_0)
			{
				onGetPersonalSettings_0(settings);
			});
		}
		else
		{
			mOnGetPersonalSettings.ForEach(delegate(OnGetPersonalSettings onGetPersonalSettings_0)
			{
				onGetPersonalSettings_0(null);
			});
		}
	}
	// Token: 0x06001582 RID: 5506 RVA: 0x0007A44C File Offset: 0x0007864C
	private void OnSetPersonalSettingsResponse(short result, Dictionary<byte, object> parameters)
	{
		mOnSetPersonalSettings.ForEach(delegate(OnSetPersonalSettings onSetPersonalSettings_0)
		{
			onSetPersonalSettings_0(result);
		});
	}
	// Token: 0x06001583 RID: 5507 RVA: 0x0000FC0E File Offset: 0x0000DE0E
	public void imethod_8()
	{
		PhotonNetwork.onlinePeer.method_3(53, new object[0]);
	}

	// Token: 0x06001584 RID: 5508 RVA: 0x0000FC23 File Offset: 0x0000DE23
	public void imethod_9(string string_0)
	{
		PhotonNetwork.onlinePeer.method_3(52, new object[] { string_0 });
	}

	// Token: 0x06001585 RID: 5509 RVA: 0x0007A480 File Offset: 0x00078680
	private void OnGetCharacterSettingsResponse(short result, Dictionary<byte, object> parameters)
	{
		if (result == 0)
		{
			string settings = (string)parameters[0];
			mOnGetCharacterSettings.ForEach(delegate(OnGetCharacterSettings onGetCharacterSettings_0)
			{
				onGetCharacterSettings_0(settings);
			});
		}
		else
		{
			mOnGetCharacterSettings.ForEach(delegate(OnGetCharacterSettings onGetCharacterSettings_0)
			{
				onGetCharacterSettings_0(null);
			});
		}
	}
	// Token: 0x06001586 RID: 5510 RVA: 0x0007A4EC File Offset: 0x000786EC
	private void OnSetCharacterSettingsResponse(short result, Dictionary<byte, object> parameters)
	{
		mOnSetCharacterSettings.ForEach(delegate(OnSetCharacterSettings onSetCharacterSettings_0)
		{
			onSetCharacterSettings_0(result);
		});
	}
	// Token: 0x06001587 RID: 5511 RVA: 0x0000FC3C File Offset: 0x0000DE3C
	public void imethod_19(OnGetCharacterSettings onGetCharacterSettings_0)
	{
		this.mOnGetCharacterSettings.Add(onGetCharacterSettings_0);
	}

	// Token: 0x06001588 RID: 5512 RVA: 0x0000FC4A File Offset: 0x0000DE4A
	public void imethod_20(OnSetCharacterSettings onSetCharacterSettings_0)
	{
		this.mOnSetCharacterSettings.Add(onSetCharacterSettings_0);
	}

	// Token: 0x06001589 RID: 5513 RVA: 0x0000FC58 File Offset: 0x0000DE58
	public void imethod_29(OnGetCharacterSettings onGetCharacterSettings_0)
	{
		this.mOnGetCharacterSettings.Remove(onGetCharacterSettings_0);
	}

	// Token: 0x0600158A RID: 5514 RVA: 0x0000FC67 File Offset: 0x0000DE67
	public void imethod_30(OnSetCharacterSettings onSetCharacterSettings_0)
	{
		this.mOnSetCharacterSettings.Remove(onSetCharacterSettings_0);
	}

	// Token: 0x0600158B RID: 5515 RVA: 0x0000FC76 File Offset: 0x0000DE76
	public void imethod_7(byte[] byte_0)
	{
		PhotonNetwork.onlinePeer.method_3(62, new object[] { byte_0 });
	}

	// Token: 0x0600158C RID: 5516 RVA: 0x0007A520 File Offset: 0x00078720
	private void OnGPKAuthReplyResponse(short result, Dictionary<byte, object> parameters)
	{
		mOnGPKAuthReply.ForEach(delegate(OnGPKAuthReply onGPKAuthReply_0)
		{
			onGPKAuthReply_0(result);
		});
	}
	// Token: 0x0600158D RID: 5517 RVA: 0x0000FC8F File Offset: 0x0000DE8F
	public void imethod_16(OnGPKDynCode onGPKDynCode_0)
	{
		this.mOnGPKDynCode.Add(onGPKDynCode_0);
	}

	// Token: 0x0600158E RID: 5518 RVA: 0x0000FC9D File Offset: 0x0000DE9D
	public void imethod_26(OnGPKDynCode onGPKDynCode_0)
	{
		this.mOnGPKDynCode.Remove(onGPKDynCode_0);
	}

	// Token: 0x0600158F RID: 5519 RVA: 0x0000FCAC File Offset: 0x0000DEAC
	public void imethod_17(OnGPKAuthData onGPKAuthData_0)
	{
		this.mOnGPKAuthData.Add(onGPKAuthData_0);
	}

	// Token: 0x06001590 RID: 5520 RVA: 0x0000FCBA File Offset: 0x0000DEBA
	public void imethod_27(OnGPKAuthData onGPKAuthData_0)
	{
		this.mOnGPKAuthData.Remove(onGPKAuthData_0);
	}

	// Token: 0x06001591 RID: 5521 RVA: 0x0000FCC9 File Offset: 0x0000DEC9
	public void imethod_18(OnGPKAuthReply onGPKAuthReply_0)
	{
		this.mOnGPKAuthReply.Add(onGPKAuthReply_0);
	}

	// Token: 0x06001592 RID: 5522 RVA: 0x0000FCD7 File Offset: 0x0000DED7
	public void imethod_28(OnGPKAuthReply onGPKAuthReply_0)
	{
		this.mOnGPKAuthReply.Remove(onGPKAuthReply_0);
	}

	// Token: 0x06001593 RID: 5523 RVA: 0x0000FCE6 File Offset: 0x0000DEE6
	public void imethod_11(OnExperienceUpdated onExperienceUpdated_0)
	{
		this.mOnExperienceUpdated.Add(onExperienceUpdated_0);
	}

	// Token: 0x06001594 RID: 5524 RVA: 0x0000FCF4 File Offset: 0x0000DEF4
	public void imethod_12(OnLevelUp onLevelUp_0)
	{
		this.mOnLevelUp.Add(onLevelUp_0);
	}

	// Token: 0x06001595 RID: 5525 RVA: 0x0000FD02 File Offset: 0x0000DF02
	public void imethod_13(OnNotifyAntiAddiction onNotifyAntiAddiction_0)
	{
		this.mOnNotifyAntiAddiction.Add(onNotifyAntiAddiction_0);
	}

	// Token: 0x06001596 RID: 5526 RVA: 0x0000FD10 File Offset: 0x0000DF10
	public void imethod_21(OnExperienceUpdated onExperienceUpdated_0)
	{
		this.mOnExperienceUpdated.Remove(onExperienceUpdated_0);
	}

	// Token: 0x06001597 RID: 5527 RVA: 0x0000FD1F File Offset: 0x0000DF1F
	public void imethod_22(OnLevelUp onLevelUp_0)
	{
		this.mOnLevelUp.Remove(onLevelUp_0);
	}

	// Token: 0x06001598 RID: 5528 RVA: 0x0000FD2E File Offset: 0x0000DF2E
	public void imethod_23(OnNotifyAntiAddiction onNotifyAntiAddiction_0)
	{
		this.mOnNotifyAntiAddiction.Remove(onNotifyAntiAddiction_0);
	}

	// Token: 0x06001599 RID: 5529 RVA: 0x0000FD3D File Offset: 0x0000DF3D
	public void imethod_14(OnGetPersonalSettings onGetPersonalSettings_0)
	{
		this.mOnGetPersonalSettings.Add(onGetPersonalSettings_0);
	}

	// Token: 0x0600159A RID: 5530 RVA: 0x0000FD4B File Offset: 0x0000DF4B
	public void imethod_15(OnSetPersonalSettings onSetPersonalSettings_0)
	{
		this.mOnSetPersonalSettings.Add(onSetPersonalSettings_0);
	}

	// Token: 0x0600159B RID: 5531 RVA: 0x0000FD59 File Offset: 0x0000DF59
	public void imethod_24(OnGetPersonalSettings onGetPersonalSettings_0)
	{
		this.mOnGetPersonalSettings.Remove(onGetPersonalSettings_0);
	}

	// Token: 0x0600159C RID: 5532 RVA: 0x0000FD68 File Offset: 0x0000DF68
	public void imethod_25(OnSetPersonalSettings onSetPersonalSettings_0)
	{
		this.mOnSetPersonalSettings.Remove(onSetPersonalSettings_0);
	}

	// Token: 0x0600159D RID: 5533 RVA: 0x0007A554 File Offset: 0x00078754
	private void OnExperienceUpdatedEvent(Dictionary<byte, object> parameters)
	{
		int newExperience = (int)parameters[0];
		mOnExperienceUpdated.ForEach(delegate(OnExperienceUpdated onExperienceUpdated_0)
		{
			onExperienceUpdated_0(newExperience);
		});
	}
	// Token: 0x0600159E RID: 5534 RVA: 0x0007A590 File Offset: 0x00078790
	private void OnLevelUpEvent(Dictionary<byte, object> parameters)
	{
		int characterId = (int)parameters[0];
		int newExperience = (int)parameters[1];
		int newLevel = (int)parameters[2];
		mOnLevelUp.ForEach(delegate(OnLevelUp onLevelUp_0)
		{
			onLevelUp_0(characterId, newLevel, newExperience);
		});
	}
	// Token: 0x0600159F RID: 5535 RVA: 0x0007A5F0 File Offset: 0x000787F0
	private void OnNotifyAntiAddictionEvent(Dictionary<byte, object> parameters)
	{
		int onlineMinutes = (int)parameters[0];
		int offlineMinutes = (int)parameters[1];
		DebugUtils.Log(LogCategory.Network, "AntiAddiction onlineMinutes:" + onlineMinutes + " offlineMinutes: " + offlineMinutes);
		mOnNotifyAntiAddiction.ForEach(delegate(OnNotifyAntiAddiction onNotifyAntiAddiction_0)
		{
			onNotifyAntiAddiction_0(onlineMinutes, offlineMinutes);
		});
	}
	// Token: 0x060015A0 RID: 5536 RVA: 0x0007A67C File Offset: 0x0007887C
	private void OnGPKDynCodeEvent(Dictionary<byte, object> parameters)
	{
		byte[] DynCode = (byte[])parameters[0];
		mOnGPKDynCode.ForEach(delegate(OnGPKDynCode onGPKDynCode_0)
		{
			onGPKDynCode_0(DynCode);
		});
		DebugUtils.Log(LogCategory.Network, "OnGPKDynCodeEvent:" + DynCode.Length);
	}
	// Token: 0x060015A1 RID: 5537 RVA: 0x0007A6D8 File Offset: 0x000788D8
	private void OnGPKAuthDataEvent(Dictionary<byte, object> parameters)
	{
		byte[] authData = (byte[])parameters[0];
		DebugUtils.Log(LogCategory.Network, "OnGPKAuthDataEvent:" + authData.Length);
		mOnGPKAuthData.ForEach(delegate(OnGPKAuthData onGPKAuthData_0)
		{
			onGPKAuthData_0(authData);
		});
	}
	// Token: 0x060015A2 RID: 5538 RVA: 0x0000FD77 File Offset: 0x0000DF77
	[CompilerGenerated]
	private static void smethod_0(OnGetCharacterList onGetCharacterList_0)
	{
		onGetCharacterList_0(null);
	}

	// Token: 0x060015A3 RID: 5539 RVA: 0x0000FD80 File Offset: 0x0000DF80
	[CompilerGenerated]
	private static void smethod_1(OnGetCharacter onGetCharacter_0)
	{
		onGetCharacter_0(null);
	}

	// Token: 0x060015A4 RID: 5540 RVA: 0x0000FD80 File Offset: 0x0000DF80
	[CompilerGenerated]
	private static void smethod_2(OnGetCharacter onGetCharacter_0)
	{
		onGetCharacter_0(null);
	}

	// Token: 0x060015A5 RID: 5541 RVA: 0x0000FD89 File Offset: 0x0000DF89
	[CompilerGenerated]
	private static void smethod_3(OnDeleteCharacter onDeleteCharacter_0)
	{
		onDeleteCharacter_0(true);
	}

	// Token: 0x060015A6 RID: 5542 RVA: 0x0000FD92 File Offset: 0x0000DF92
	[CompilerGenerated]
	private static void smethod_4(OnDeleteCharacter onDeleteCharacter_0)
	{
		onDeleteCharacter_0(false);
	}

	// Token: 0x060015A7 RID: 5543 RVA: 0x0000FD9B File Offset: 0x0000DF9B
	[CompilerGenerated]
	private static void smethod_5(OnUpdateCharacterExperience onUpdateCharacterExperience_0)
	{
		onUpdateCharacterExperience_0();
	}

	// Token: 0x060015A8 RID: 5544 RVA: 0x0000FD80 File Offset: 0x0000DF80
	[CompilerGenerated]
	private static void smethod_6(OnGetCharacter onGetCharacter_0)
	{
		onGetCharacter_0(null);
	}

	// Token: 0x060015A9 RID: 5545 RVA: 0x0000FDA3 File Offset: 0x0000DFA3
	[CompilerGenerated]
	private static void smethod_7(OnGetPersonalSettings onGetPersonalSettings_0)
	{
		onGetPersonalSettings_0(null);
	}

	// Token: 0x060015AA RID: 5546 RVA: 0x0000FDAC File Offset: 0x0000DFAC
	[CompilerGenerated]
	private static void smethod_8(OnGetCharacterSettings onGetCharacterSettings_0)
	{
		onGetCharacterSettings_0(null);
	}

	// Token: 0x04000E97 RID: 3735
	private List<OnGetCharacterList> mOnGetCharacterList = new List<OnGetCharacterList>();

	// Token: 0x04000E98 RID: 3736
	private List<OnGetCharacter> mOnSelectCharacter = new List<OnGetCharacter>();

	// Token: 0x04000E99 RID: 3737
	private List<OnCreateCharacter> mOnCreateCharacter = new List<OnCreateCharacter>();

	// Token: 0x04000E9A RID: 3738
	private List<OnGetCharacter> mOnGetCharacter = new List<OnGetCharacter>();

	// Token: 0x04000E9B RID: 3739
	private List<OnUpdateCharacterExperience> mOnUpdateCharacterExperience = new List<OnUpdateCharacterExperience>();

	// Token: 0x04000E9C RID: 3740
	private List<OnDeleteCharacter> mOnDeleteCharacter = new List<OnDeleteCharacter>();

	// Token: 0x04000E9D RID: 3741
	private List<OnConsumeEnergy> mOnConsumeEnergy = new List<OnConsumeEnergy>();

	// Token: 0x04000E9E RID: 3742
	private List<OnGetPersonalSettings> mOnGetPersonalSettings = new List<OnGetPersonalSettings>();

	// Token: 0x04000E9F RID: 3743
	private List<OnSetPersonalSettings> mOnSetPersonalSettings = new List<OnSetPersonalSettings>();

	// Token: 0x04000EA0 RID: 3744
	private List<OnExperienceUpdated> mOnExperienceUpdated = new List<OnExperienceUpdated>();

	// Token: 0x04000EA1 RID: 3745
	private List<OnLevelUp> mOnLevelUp = new List<OnLevelUp>();

	// Token: 0x04000EA2 RID: 3746
	private List<OnNotifyAntiAddiction> mOnNotifyAntiAddiction = new List<OnNotifyAntiAddiction>();

	// Token: 0x04000EA3 RID: 3747
	private List<OnGPKDynCode> mOnGPKDynCode = new List<OnGPKDynCode>();

	// Token: 0x04000EA4 RID: 3748
	private List<OnGPKAuthData> mOnGPKAuthData = new List<OnGPKAuthData>();

	// Token: 0x04000EA5 RID: 3749
	private List<OnGPKAuthReply> mOnGPKAuthReply = new List<OnGPKAuthReply>();

	// Token: 0x04000EA6 RID: 3750
	private List<OnGetCharacterSettings> mOnGetCharacterSettings = new List<OnGetCharacterSettings>();

	// Token: 0x04000EA7 RID: 3751
	private List<OnSetCharacterSettings> mOnSetCharacterSettings = new List<OnSetCharacterSettings>();

	// Token: 0x0200034F RID: 847
	public class GetCharacterListAsyncTask : PhotonNetworkTask
	{
		// Token: 0x060015AC RID: 5548 RVA: 0x0000D358 File Offset: 0x0000B558
		public void method_4()
		{
			this.float_1 = 30f;
		}

		// Token: 0x060015AD RID: 5549 RVA: 0x0000FDC8 File Offset: 0x0000DFC8
		public override void Start()
		{
			base.Start();
			OnAccessSingleton<ICharacterService, CharacterService, CharacterServiceOffline>.Prop_0.imethod_0(new OnGetCharacterList(this.OnGetCharacterList));
		}

		// Token: 0x060015AE RID: 5550 RVA: 0x0000FDE6 File Offset: 0x0000DFE6
		private void OnGetCharacterList(List<Character> characters)
		{
			this.m_characters = ((characters != null) ? characters : new List<Character>());
			base.SetStatus(AsyncTaskStatus.Success);
		}

		// Token: 0x04000EB1 RID: 3761
		public List<Character> m_characters = new List<Character>();
	}

	// Token: 0x02000350 RID: 848
	public class SelectCharacterAsyncTask : PhotonNetworkTask
	{
		// Token: 0x060015B0 RID: 5552 RVA: 0x0000FE08 File Offset: 0x0000E008
		public void method_4(int int_1)
		{
			this.float_1 = 30f;
			this.m_characterId = int_1;
		}

		// Token: 0x060015B1 RID: 5553 RVA: 0x0000FE1C File Offset: 0x0000E01C
		public override void Start()
		{
			base.Start();
			OnAccessSingleton<ICharacterService, CharacterService, CharacterServiceOffline>.Prop_0.imethod_1(new OnGetCharacter(this.OnGetCharacter), this.m_characterId);
		}

		// Token: 0x060015B2 RID: 5554 RVA: 0x0007A734 File Offset: 0x00078934
		private void OnGetCharacter(Character character)
		{
			if (character == null)
			{
				base.SetStatus(AsyncTaskStatus.Error_NoCharacter);
			}
			else
			{
				OnlineService.s_characterId = character.Id;
				PhotonNetwork.player.method_2(new Hashtable { 
				{
					"CharacterId",
					OnlineService.s_characterId
				} });
				this.m_character = character;
				if (ServiceWrapperBase<CharacterServiceWrapper>.Instance != null)
				{
					ServiceWrapperBase<CharacterServiceWrapper>.Instance.method_4(this.m_character);
				}
				OnAccessSingleton<IProgressionService, ProgressionService, ProgressionServiceOffline>.Prop_0.imethod_2(this.m_character.Instances);
				base.SetStatus(AsyncTaskStatus.Success);
			}
		}

		// Token: 0x04000EB2 RID: 3762
		private int m_characterId;

		// Token: 0x04000EB3 RID: 3763
		public Character m_character;
	}

	// Token: 0x02000351 RID: 849
	public class CreateCharacterAsyncTask : PhotonNetworkTask
	{
		// Token: 0x060015B4 RID: 5556 RVA: 0x0000FE40 File Offset: 0x0000E040
		public void method_4(string string_0, AvatarDNA avatarDNA_0)
		{
			this.float_1 = 30f;
			this.m_name = string_0;
			this.m_avatarDna = avatarDNA_0;
		}

		// Token: 0x060015B5 RID: 5557 RVA: 0x0007A7B8 File Offset: 0x000789B8
		public override void Start()
		{
			base.Start();
			OnAccessSingleton<ICharacterService, CharacterService, CharacterServiceOffline>.Prop_0.imethod_2(new OnCreateCharacter(this.OnCreateCharacter), this.m_name, this.m_avatarDna.method_5(), this.m_avatarDna.m_buildingUnit.bkID, string.Join(",", this.m_avatarDna.m_buildingUnit.mFBXs.Select<byte, string>(new Func<byte, string>(CharacterService.CreateCharacterAsyncTask.smethod_0)).ToArray<string>()), string.Join(",", this.m_avatarDna.m_buildingUnit.mMats.Select<byte, string>(new Func<byte, string>(CharacterService.CreateCharacterAsyncTask.smethod_1)).ToArray<string>()));
		}

		// Token: 0x060015B6 RID: 5558 RVA: 0x0007A884 File Offset: 0x00078A84
		private void OnCreateCharacter(CharacterOperationResult result, Character character)
		{
			if (result == CharacterOperationResult.Ok && character != null)
			{
				OnlineService.s_characterId = character.Id;
				PhotonNetwork.player.method_2(new Hashtable { 
				{
					"CharacterId",
					OnlineService.s_characterId
				} });
				this.m_character = character;
				if (ServiceWrapperBase<CharacterServiceWrapper>.Instance != null)
				{
					ServiceWrapperBase<CharacterServiceWrapper>.Instance.method_4(this.m_character);
				}
				OnAccessSingleton<IProgressionService, ProgressionService, ProgressionServiceOffline>.Prop_0.imethod_2(this.m_character.Instances);
				base.SetStatus(AsyncTaskStatus.Success);
			}
			else
			{
				switch (result)
				{
				case CharacterOperationResult.Error_NameTooLong:
					base.SetStatus(AsyncTaskStatus.Error_NameTooLong);
					break;
				case CharacterOperationResult.Error_NameAlreadyExists:
					base.SetStatus(AsyncTaskStatus.Error_NameAlreadyExists);
					break;
				case CharacterOperationResult.Error_NameContainsIllegalWords:
					base.SetStatus(AsyncTaskStatus.Error_NameContainsIllegalWords);
					break;
				default:
					base.SetStatus(AsyncTaskStatus.Error_NoCharacter);
					break;
				}
			}
		}

		// Token: 0x060015B7 RID: 5559 RVA: 0x00007C4E File Offset: 0x00005E4E
		[CompilerGenerated]
		private static string smethod_0(byte byte_0)
		{
			return byte_0.ToString();
		}

		// Token: 0x060015B8 RID: 5560 RVA: 0x00007C4E File Offset: 0x00005E4E
		[CompilerGenerated]
		private static string smethod_1(byte byte_0)
		{
			return byte_0.ToString();
		}

		// Token: 0x04000EB4 RID: 3764
		private string m_name;

		// Token: 0x04000EB5 RID: 3765
		private AvatarDNA m_avatarDna;

		// Token: 0x04000EB6 RID: 3766
		public Character m_character;
	}

	// Token: 0x02000352 RID: 850
	public class GetSelectedCharacterAsyncTask : PhotonNetworkTask
	{
		// Token: 0x060015BA RID: 5562 RVA: 0x0000D358 File Offset: 0x0000B558
		public void method_4()
		{
			this.float_1 = 30f;
		}

		// Token: 0x060015BB RID: 5563 RVA: 0x0000FE5B File Offset: 0x0000E05B
		public override void Start()
		{
			base.Start();
			OnAccessSingleton<ICharacterService, CharacterService, CharacterServiceOffline>.Prop_0.imethod_3(new OnGetCharacter(this.OnGetCharacter));
		}

		// Token: 0x060015BC RID: 5564 RVA: 0x0007A940 File Offset: 0x00078B40
		private void OnGetCharacter(Character character)
		{
			if (character == null)
			{
				base.SetStatus(AsyncTaskStatus.Error_NoCharacter);
			}
			else
			{
				this.m_character = character;
				if (ServiceWrapperBase<CharacterServiceWrapper>.Instance != null)
				{
					ServiceWrapperBase<CharacterServiceWrapper>.Instance.method_4(this.m_character);
				}
				OnAccessSingleton<IProgressionService, ProgressionService, ProgressionServiceOffline>.Prop_0.imethod_2(this.m_character.Instances);
				base.SetStatus(AsyncTaskStatus.Success);
			}
		}

		// Token: 0x04000EB9 RID: 3769
		public Character m_character;
	}

	// Token: 0x02000353 RID: 851
	public class DeleteCharacterAsyncTask : PhotonNetworkTask
	{
		// Token: 0x060015BE RID: 5566 RVA: 0x0000FE79 File Offset: 0x0000E079
		public void method_4(int int_1)
		{
			this.float_1 = 30f;
			this.m_characterId = int_1;
		}

		// Token: 0x060015BF RID: 5567 RVA: 0x0000FE8D File Offset: 0x0000E08D
		public override void Start()
		{
			base.Start();
			OnAccessSingleton<ICharacterService, CharacterService, CharacterServiceOffline>.Prop_0.imethod_4(new OnDeleteCharacter(this.OnDeleteCharacter), this.m_characterId);
		}

		// Token: 0x060015C0 RID: 5568 RVA: 0x0000FEB1 File Offset: 0x0000E0B1
		private void OnDeleteCharacter(bool success)
		{
			if (!success)
			{
				base.SetStatus(AsyncTaskStatus.Error);
			}
			else
			{
				base.SetStatus(AsyncTaskStatus.Success);
			}
		}

		// Token: 0x04000EBA RID: 3770
		private int m_characterId;

		// Token: 0x04000EBB RID: 3771
		public Character m_character;
	}
}
