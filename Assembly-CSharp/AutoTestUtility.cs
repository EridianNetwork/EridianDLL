using System;
using System.Collections;
using System.Diagnostics;
using System.Xml;
using Core;
using ns0;
using UnityEngine;
using XsdSettings;

// Token: 0x02000640 RID: 1600
public static class AutoTestUtility
{
	// Token: 0x0600288A RID: 10378 RVA: 0x000BF2C0 File Offset: 0x000BD4C0
	public static void smethod_0(Vector3 vector3_0)
	{
		WeaponGeneratorService component = MonoSingleton<AppManager>.Instance.GetComponent<WeaponGeneratorService>();
		ItemDNA itemDNA = ItemDNA.smethod_2(component.m_weapons[0]);
		vector3_0.y += 1f;
		MonoSingleton<AppManager>.Instance.GetComponent<InstantiateManager>().method_6(itemDNA, vector3_0, Quaternion.identity, Vector3.up, -1, -1, 0, 0);
	}

	// Token: 0x0600288B RID: 10379 RVA: 0x000BF31C File Offset: 0x000BD51C
	public static int smethod_1(string string_0 = null)
	{
		string text = "lvl_autotest_1";
		if (string_0 == "playerShootingTestPvP")
		{
			text = "lvl_autotest_PvP";
		}
		int num = -1;
		MatchmakingService component = MonoSingleton<AppManager>.Instance.GetComponent<MatchmakingService>();
		if (component != null)
		{
			Playlist playlist = component.method_3(text);
			num = playlist.m_id;
		}
		return num;
	}

	// Token: 0x0600288C RID: 10380 RVA: 0x00011F80 File Offset: 0x00010180
	public static int smethod_2()
	{
		return -1;
	}

	// Token: 0x0600288D RID: 10381 RVA: 0x000BF368 File Offset: 0x000BD568
	public static string smethod_3(int int_0)
	{
		MatchmakingService component = MonoSingleton<AppManager>.Instance.GetComponent<MatchmakingService>();
		if (component != null)
		{
			Playlist playlist = component.method_1(int_0);
			return playlist.m_gameMode;
		}
		return string.Empty;
	}

	// Token: 0x0600288E RID: 10382 RVA: 0x0001AACD File Offset: 0x00018CCD
	public static string smethod_4()
	{
		return Environment.GetEnvironmentVariable("gamemode");
	}

	// Token: 0x0600288F RID: 10383 RVA: 0x000BF3A0 File Offset: 0x000BD5A0
	public static void smethod_5()
	{
		string text = Environment.GetEnvironmentVariable("mapname");
		if (string.IsNullOrEmpty(text))
		{
			string[] array = MonoSingleton<AppManager>.Instance.m_autoTestCase.Split(new char[] { '|' });
			if (array.Length > 1)
			{
				text = array[1];
			}
		}
		if (string.IsNullOrEmpty(text))
		{
			DebugUtils.Log(LogCategory.Autotest, "No EnvVar For MapName");
		}
		else
		{
			DebugUtils.Log(LogCategory.Autotest, "From EnvVar, Map Name Is: " + text);
			if (!string.IsNullOrEmpty(MonoSingleton<AppManager>.Instance.m_privateSessionName))
			{
				string text2 = "lvl_autotest_1";
				string text3 = "lvl_deleted";
				XmlDocument xmlDocument = LevelLoadingManager.MapsDescXml.MapsDescXml_0.method_0();
				XmlNodeList elementsByTagName = xmlDocument.GetElementsByTagName("Map");
				for (int i = 0; i < elementsByTagName.Count; i++)
				{
					XmlNode xmlNode = elementsByTagName.Item(i);
					if (xmlNode.Attributes["name"].Value.ToLower() == text2.ToLower())
					{
						xmlNode.Attributes["name"].Value = text3;
					}
				}
				for (int j = 0; j < elementsByTagName.Count; j++)
				{
					XmlNode xmlNode2 = elementsByTagName.Item(j);
					if (xmlNode2.Attributes["name"].Value.ToLower() == text.ToLower())
					{
						xmlNode2.Attributes["name"].Value = text2;
					}
				}
			}
		}
		Playlist playlist = MatchmakingService.MatchmakingService_0.method_2(text);
		if (playlist != null)
		{
			MonoSingleton<AppManager>.Instance.m_playlistId = playlist.m_id;
			DebugUtils.Log(LogCategory.Autotest, "Now new id: " + playlist.m_id);
		}
		string environmentVariable = Environment.GetEnvironmentVariable("maxplayer");
		int num = 0;
		if (int.TryParse(environmentVariable, out num))
		{
			MatchmakingService.MatchmakingService_0.method_1(MonoSingleton<AppManager>.Instance.m_playlistId).m_maxPlayerCount = num;
		}
		string environmentVariable2 = Environment.GetEnvironmentVariable("npcname");
		if (string.IsNullOrEmpty(environmentVariable2))
		{
			DebugUtils.Log(LogCategory.Autotest, "No Npc List");
		}
		else
		{
			DebugUtils.Log(LogCategory.Autotest, "From EnvVar, Npc Name Is: " + environmentVariable2);
			XmlDocument xmlDocument2 = LevelLoadingManager.MapsDescXml.MapsDescXml_0.method_0();
			XmlNode xmlNode3 = xmlDocument2.SelectSingleNode("/Instance/Maps/Map[@name='lvl_autotest_1']/NPCSetting");
			xmlNode3.RemoveAll();
			string[] array2 = environmentVariable2.Split(new char[] { '|' });
			for (int k = 0; k < array2.Length; k++)
			{
				string text4 = array2[k].Trim();
				XmlElement xmlElement = xmlDocument2.CreateElement("NPC");
				XmlAttribute xmlAttribute = xmlDocument2.CreateAttribute("value");
				xmlAttribute.Value = text4;
				xmlElement.Attributes.Append(xmlAttribute);
				xmlNode3.AppendChild(xmlElement);
			}
		}
	}

	// Token: 0x06002890 RID: 10384 RVA: 0x000BF64C File Offset: 0x000BD84C
	public static Entity smethod_6<T>() where T : Entity
	{
		GameObject gameObject = GameObject.Find("/AppManager/Entities");
		for (int i = 0; i < gameObject.transform.childCount; i++)
		{
			GameObject gameObject2 = gameObject.transform.GetChild(i).gameObject;
			if (gameObject2 != null)
			{
				Entity entity = gameObject2.GetComponent<T>();
				if (entity != null)
				{
					return entity;
				}
			}
		}
		return null;
	}

	// Token: 0x06002891 RID: 10385 RVA: 0x000BF6B0 File Offset: 0x000BD8B0
	public static IEnumerator smethod_7(AvatarType avatarType_0)
	{
		CharacterService.GetCharacterListAsyncTask getCharacterList = new CharacterService.GetCharacterListAsyncTask();
		getCharacterList.method_4();
		ns0.MonoSingleton<AsyncTaskManager>.Instance.method_1(getCharacterList);
		while (!getCharacterList.IsStatus())
		{
			yield return 0;
		}
		if (getCharacterList.GetStatus() != AsyncTaskStatus.Success)
		{
			DebugUtils.LogError(LogCategory.Autotest, "Can't Get Character List");
			yield break;
		}
		Character character2 = null;
		if (getCharacterList.m_characters.Count > 0)
		{
			CharacterService.SelectCharacterAsyncTask selectCharacter = new CharacterService.SelectCharacterAsyncTask();
			selectCharacter.method_4(getCharacterList.m_characters[0].Id);
			ns0.MonoSingleton<AsyncTaskManager>.Instance.method_1(selectCharacter);
			while (!selectCharacter.IsStatus())
			{
				yield return 0;
			}
			if (selectCharacter.GetStatus() != AsyncTaskStatus.Success)
			{
				DebugUtils.LogError(LogCategory.Autotest, "Can't Select Character");
				yield break;
			}
			character2 = selectCharacter.m_character;
		}
		else
		{
			AvatarDNA dna = new AvatarDNA();
			dna.method_6(avatarType_0);
			CharacterService.CreateCharacterAsyncTask createCharacter = new CharacterService.CreateCharacterAsyncTask();
			createCharacter.method_4(OnlineService.s_userName, dna);
			ns0.MonoSingleton<AsyncTaskManager>.Instance.method_1(createCharacter);
			while (!createCharacter.IsStatus())
			{
				yield return 0;
			}
			if (createCharacter.GetStatus() != AsyncTaskStatus.Success)
			{
				DebugUtils.LogError(LogCategory.Autotest, string.Concat("Can't Create Character[", OnlineService.s_userName, "][", dna, "]"));
				yield break;
			}
			character2 = createCharacter.m_character;
			s_isANewlyCreatedCharacter = true;
		}
		PlayerProperties localPlayer = new PlayerProperties
		{
			m_id = character2.Id,
			m_name = character2.Name,
			m_exp = character2.Experience,
			m_level = character2.Level
		};
		AvatarDNA newdna = new AvatarDNA();
		newdna.method_8(character2.AvatarType, character2.AvatarParts, character2.AvatarMaterials, character2.AvatarId);
		localPlayer.m_avatarDna = newdna;
		ns0.MonoSingleton<PlayerManager>.Instance.method_0(localPlayer, bool_0: true);
	}
	// Token: 0x06002892 RID: 10386 RVA: 0x000BF6D4 File Offset: 0x000BD8D4
	public static void smethod_8(int int_0 = -1)
	{
		GameFlowManager component = MonoSingleton<AutoTestManager>.Instance.GetComponent<GameFlowManager>();
		if (int_0 != -1)
		{
			GamemodeType gamemodeType = MatchmakingService.smethod_0(AutoTestUtility.smethod_3(int_0));
			if (MatchmakingService.smethod_1(gamemodeType))
			{
				component.method_12(int_0, gamemodeType);
			}
			else
			{
				component.method_8(int_0);
			}
		}
		else
		{
			component.method_8(MonoSingleton<AppManager>.Instance.m_playlistId);
		}
	}

	// Token: 0x06002893 RID: 10387 RVA: 0x000BF728 File Offset: 0x000BD928
	public static IEnumerator smethod_9(AvatarType avatarType_0, int int_0 = -1)
	{
		MatchmakingService.LeaveRoomAsyncTask leaveRoom = new MatchmakingService.LeaveRoomAsyncTask();
		leaveRoom.method_4();
		ns0.MonoSingleton<AsyncTaskManager>.Instance.method_1(leaveRoom);
		while (!leaveRoom.IsStatus())
		{
			yield return 0;
		}
		while (!Application.CanStreamedLevelBeLoaded("ResourcesLoading"))
		{
			Application.GetStreamProgressForLevel("ResourcesLoading");
			yield return null;
		}
		GameFlowManager gameFlow = ns0.MonoSingleton<AutoTestManager>.Instance.GetComponent<GameFlowManager>();
		CharacterService.GetCharacterListAsyncTask getCharacterList = new CharacterService.GetCharacterListAsyncTask();
		getCharacterList.method_4();
		ns0.MonoSingleton<AsyncTaskManager>.Instance.method_1(getCharacterList);
		while (!getCharacterList.IsStatus())
		{
			yield return 0;
		}
		if (getCharacterList.GetStatus() != AsyncTaskStatus.Success)
		{
			DebugUtils.LogError(LogCategory.Autotest, "Can't Get Character List");
			yield break;
		}
		Character character2 = null;
		if (getCharacterList.m_characters.Count > 0)
		{
			CharacterService.SelectCharacterAsyncTask selectCharacter = new CharacterService.SelectCharacterAsyncTask();
			selectCharacter.method_4(getCharacterList.m_characters[0].Id);
			ns0.MonoSingleton<AsyncTaskManager>.Instance.method_1(selectCharacter);
			while (!selectCharacter.IsStatus())
			{
				yield return 0;
			}
			if (selectCharacter.GetStatus() != AsyncTaskStatus.Success)
			{
				DebugUtils.LogError(LogCategory.Autotest, "Can't Select Character");
				yield break;
			}
			character2 = selectCharacter.m_character;
		}
		else
		{
			AvatarDNA dna = new AvatarDNA();
			dna.method_6(avatarType_0);
			CharacterService.CreateCharacterAsyncTask createCharacter = new CharacterService.CreateCharacterAsyncTask();
			createCharacter.method_4(OnlineService.s_userName, dna);
			ns0.MonoSingleton<AsyncTaskManager>.Instance.method_1(createCharacter);
			while (!createCharacter.IsStatus())
			{
				yield return 0;
			}
			if (createCharacter.GetStatus() != AsyncTaskStatus.Success)
			{
				DebugUtils.LogError(LogCategory.Autotest, string.Concat("Can't Create Character[", OnlineService.s_userName, "][", dna, "]"));
				yield break;
			}
			character2 = createCharacter.m_character;
		}
		PlayerProperties localPlayer = new PlayerProperties
		{
			m_id = character2.Id,
			m_name = character2.Name,
			m_exp = character2.Experience,
			m_level = character2.Level
		};
		AvatarDNA newdna = new AvatarDNA();
		newdna.method_8(character2.AvatarType, character2.AvatarParts, character2.AvatarMaterials, character2.AvatarId);
		localPlayer.m_avatarDna = newdna;
		ns0.MonoSingleton<PlayerManager>.Instance.method_0(localPlayer, bool_0: true);
		if (int_0 != -1)
		{
			GamemodeType gameMode = MatchmakingService.smethod_0(smethod_3(int_0));
			if (MatchmakingService.smethod_1(gameMode))
			{
				gameFlow.method_12(int_0, gameMode);
			}
			else
			{
				gameFlow.method_8(int_0);
			}
		}
		else
		{
			gameFlow.method_8(ns0.MonoSingleton<AppManager>.Instance.m_playlistId);
		}
	}
	// Token: 0x06002894 RID: 10388 RVA: 0x0000311B File Offset: 0x0000131B
	private static void OnLoginProcess(bool isExistingUser)
	{
	}

	// Token: 0x06002895 RID: 10389 RVA: 0x0000311B File Offset: 0x0000131B
	private static void OnCreateProcess(int errorCode)
	{
	}

	// Token: 0x06002896 RID: 10390 RVA: 0x0000311B File Offset: 0x0000131B
	private static void OnFinishProcess(int errorCode)
	{
	}

	// Token: 0x04001CEE RID: 7406
	public static bool s_isANewlyCreatedCharacter;
}
