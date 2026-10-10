using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using BHV;
using Core;
using ns0;
using UnityEngine;
using XsdSettings;

// Token: 0x02000737 RID: 1847
public class GameSettingMgr : MonoSingleton<GameSettingMgr>
{
	// Token: 0x060030CB RID: 12491 RVA: 0x000DE204 File Offset: 0x000DC404
	private void Start()
	{
		string text2 = null;
		try
		{
			string text3 = Path.Combine(Application.dataPath, "../overrides/SettingsMenu_override.xml");
			if (File.Exists(text3))
			{
				text2 = File.ReadAllText(text3);
				DebugUtils.Log(LogCategory.Framework, "GameSettingMgr: using external settings override " + text3);
			}
		}
		catch (Exception ex)
		{
			DebugUtils.LogWarning(LogCategory.System, "GameSettingMgr settings override read failed: " + ex.Message);
			text2 = null;
		}
		if (text2 != null)
		{
			DebugUtils.Log(LogCategory.Framework, "GameSettingMgr: parsing external settings override.");
		}
		else
		{
			TextAsset textAsset = (TextAsset)ResourcesLoader.smethod_0("Settings/SettingMenu");
			text2 = textAsset.text;
			Resources.UnloadAsset(textAsset);
		}
		using (StringReader stringReader = new StringReader(text2))
		{
			foreach (Category category in (new XmlSerializer(typeof(SettingMenuSetup)).Deserialize(stringReader) as SettingMenuSetup).Settings)
			{
				List<GameSettingMgr.SettingItemData> list = null;
				if (!this._dicSettingsByCategory.TryGetValue(category.mCategoryType, out list))
				{
					list = new List<GameSettingMgr.SettingItemData>();
					this._dicSettingsByCategory.Add(category.mCategoryType, list);
				}
				if (category.mConfigItems != null)
				{
					foreach (SettingItem settingItem in category.mConfigItems)
					{
						GameSettingMgr.SettingItemData settingItemData = new GameSettingMgr.SettingItemData();
						settingItemData.config = settingItem;
						settingItemData.curValue.fValue = settingItem.mDefaultFloat;
						settingItemData.curValue.iIndex = ((settingItem.mFunctionType == SettingFunctionType.Language) ? 1 : settingItem.mDefaultInt);
						settingItemData.newValue.iIndex = settingItemData.curValue.iIndex;
						settingItemData.curValue.bOn = settingItem.mDefaultBool;
						list.Add(settingItemData);
						this._dicSettingsByFunctionType.Add(settingItem.mFunctionType, settingItemData);
					}
				}
			}
		}
		GameSettingMgr.SettingItemData settingItemData2;
		if (this._dicSettingsByFunctionType.TryGetValue(SettingFunctionType.Mute, out settingItemData2))
		{
			settingItemData2.curValue.bOn = false;
			settingItemData2.newValue.bOn = false;
			settingItemData2.bDirty = true;
		}
		this.method_11();
		ServiceWrapperBase<CharacterServiceWrapper>.Instance.method_0(this._settingsListener);
		this.method_12();
		JSONObject jsonobject = ServiceWrapperBase<CharacterServiceWrapper>.Instance.method_29("PlayerSetting");
		if (jsonobject != null)
		{
			this.OnGetSavedSettingsStrings(jsonobject.ToString());
		}
		string @string = PlayerPrefs.GetString("PlayerSetting");
		this.OnGetSavedSettingsStrings(@string);
		this.method_5();
	}

	// Token: 0x060030CC RID: 12492 RVA: 0x0001FD52 File Offset: 0x0001DF52
	public void method_0()
	{
		this._dicSettingsByCategory.Clear();
		this._dicSettingsByFunctionType.Clear();
	}

	// Token: 0x060030CD RID: 12493 RVA: 0x0001FD6A File Offset: 0x0001DF6A
	public Dictionary<SettingCategory, List<GameSettingMgr.SettingItemData>> method_1()
	{
		return this._dicSettingsByCategory;
	}

	// Token: 0x060030CE RID: 12494 RVA: 0x000DE3EC File Offset: 0x000DC5EC
	public void method_2(SettingCategory settingCategory_0)
	{
		List<GameSettingMgr.SettingItemData> list = null;
		if (this._dicSettingsByCategory.TryGetValue(settingCategory_0, out list))
		{
			foreach (GameSettingMgr.SettingItemData settingItemData in list)
			{
				settingItemData.Reset();
			}
		}
	}

	// Token: 0x060030CF RID: 12495 RVA: 0x0001FD72 File Offset: 0x0001DF72
	public bool method_3()
	{
		return MonoSingleton<InputManager>.Instance.method_19();
	}

	// Token: 0x060030D0 RID: 12496 RVA: 0x000DE44C File Offset: 0x000DC64C
	public bool method_4()
	{
		bool flag = false;
		foreach (GameSettingMgr.SettingItemData settingItemData in this._dicSettingsByFunctionType.Values)
		{
			if (settingItemData.method_5())
			{
				flag = true;
				break;
			}
		}
		return flag;
	}

	// Token: 0x060030D1 RID: 12497 RVA: 0x000DE4AC File Offset: 0x000DC6AC
	public void method_5()
	{
		if (this.method_4())
		{
			this._bNeedRestoreSettings = true;
			foreach (GameSettingMgr.SettingItemData settingItemData in this._dicSettingsByFunctionType.Values)
			{
				settingItemData.method_0();
			}
		}
	}

	// Token: 0x060030D2 RID: 12498 RVA: 0x000DE514 File Offset: 0x000DC714
	public void method_6()
	{
		foreach (GameSettingMgr.SettingItemData settingItemData in this._dicSettingsByFunctionType.Values)
		{
			settingItemData.method_3();
		}
	}

	// Token: 0x060030D3 RID: 12499 RVA: 0x000DE56C File Offset: 0x000DC76C
	public void method_7(bool bool_0)
	{
		if (MonoSingleton<GraphicsMgr>.Instance.Boolean_1 != bool_0)
		{
			GameSettingMgr.SettingItemData settingItemData = null;
			if (this._dicSettingsByFunctionType.TryGetValue(SettingFunctionType.ScreenResolution, out settingItemData))
			{
				if (settingItemData.config.mResolutions != null && settingItemData.config.mResolutions.Length > 0)
				{
					int leftValue = settingItemData.config.mResolutions[settingItemData.newValue.iIndex].LeftValue;
					int rightValue = settingItemData.config.mResolutions[settingItemData.newValue.iIndex].RightValue;
					MonoSingleton<GraphicsMgr>.Instance.method_6(bool_0, leftValue, rightValue);
				}
			}
			else
			{
				MonoSingleton<GraphicsMgr>.Instance.method_6(bool_0, 0, 0);
			}
		}
	}

	// Token: 0x060030D4 RID: 12500 RVA: 0x000DE610 File Offset: 0x000DC810
	public void method_8()
	{
		GameSettingMgr.SettingItemData settingItemData = null;
		if (this._dicSettingsByFunctionType.TryGetValue(SettingFunctionType.FullScreen, out settingItemData))
		{
			GameSettingMgr.SettingItemData settingItemData2 = null;
			if (this._dicSettingsByFunctionType.TryGetValue(SettingFunctionType.ScreenResolution, out settingItemData2))
			{
				if (settingItemData.bDirty)
				{
					settingItemData2.bEnable = !settingItemData.newValue.bOn;
				}
				else
				{
					settingItemData2.bEnable = !settingItemData.curValue.bOn;
				}
			}
		}
	}

	// Token: 0x060030D5 RID: 12501 RVA: 0x000DE674 File Offset: 0x000DC874
	public bool method_9(SettingFunctionType settingFunctionType_0)
	{
		bool flag = false;
		GameSettingMgr.SettingItemData settingItemData = null;
		if (this._dicSettingsByFunctionType.TryGetValue(settingFunctionType_0, out settingItemData))
		{
			flag = settingItemData.curValue.bOn;
		}
		return flag;
	}

	// Token: 0x060030D6 RID: 12502 RVA: 0x000DE6A4 File Offset: 0x000DC8A4
	public float method_10(SettingFunctionType settingFunctionType_0)
	{
		float num = 0f;
		GameSettingMgr.SettingItemData settingItemData = null;
		if (this._dicSettingsByFunctionType.TryGetValue(settingFunctionType_0, out settingItemData))
		{
			num = settingItemData.curValue.fValue;
		}
		return num;
	}

	// Token: 0x060030D7 RID: 12503 RVA: 0x000DE6D8 File Offset: 0x000DC8D8
	public void OnGetPlayerSettingFromServer()
	{
		JSONObject jsonobject = ServiceWrapperBase<CharacterServiceWrapper>.Instance.method_29("PlayerSetting");
		if (jsonobject != null)
		{
			this.OnGetSavedSettingsStrings(jsonobject.ToString());
		}
	}

	// Token: 0x060030D8 RID: 12504 RVA: 0x000DE704 File Offset: 0x000DC904
	public void method_11()
	{
		GameSettingMgr.SettingItemData settingItemData = null;
		if (this._dicSettingsByFunctionType.TryGetValue(SettingFunctionType.CustomKeyBinding, out settingItemData))
		{
			settingItemData.children.Clear();
			foreach (KeyValuePair<string, InputManager.InputKeyBinding> keyValuePair in MonoSingleton<InputManager>.Instance.method_14())
			{
				GameSettingMgr.SettingItemData settingItemData2 = new GameSettingMgr.SettingItemData();
				settingItemData2.type = GameSettingMgr.SettingItemDataType.KeyBinding;
				settingItemData2.controlAction = (ControlAction)((int)Enum.Parse(typeof(ControlAction), keyValuePair.Key));
				settingItemData2.curValue.keyBinding.primaryKey = keyValuePair.Value.primaryKey;
				settingItemData2.curValue.keyBinding.seconderyKey = keyValuePair.Value.seconderyKey;
				settingItemData2.newValue.keyBinding.primaryKey = keyValuePair.Value.primaryKey;
				settingItemData2.newValue.keyBinding.seconderyKey = keyValuePair.Value.seconderyKey;
				settingItemData.children.Add(settingItemData2);
			}
		}
	}

	// Token: 0x060030D9 RID: 12505 RVA: 0x000DE824 File Offset: 0x000DCA24
	protected void method_12()
	{
		Resolution resolution = MonoSingleton<GraphicsMgr>.Instance.method_9();
		Resolution resolution2 = default(Resolution);
		resolution2.height = 0;
		resolution2.width = 0;
		Resolution resolution3 = default(Resolution);
		resolution3.height = 0;
		resolution3.width = 0;
		bool flag = false;
		GameSettingMgr.SettingItemData settingItemData = null;
		GameSettingMgr.SettingItemData settingItemData2 = null;
		if (!this._dicSettingsByFunctionType.TryGetValue(SettingFunctionType.ScreenResolution, out settingItemData))
		{
			return;
		}
		if (!this._dicSettingsByFunctionType.TryGetValue(SettingFunctionType.FullScreen, out settingItemData2))
		{
			return;
		}
		bool flag2;
		if (!(flag2 = settingItemData.curValue.iIndex < 0))
		{
			if (settingItemData.config != null && settingItemData.config.mResolutions != null && settingItemData.curValue.iIndex < settingItemData.config.mResolutions.Length)
			{
				resolution2.width = settingItemData.config.mResolutions[settingItemData.curValue.iIndex].LeftValue;
				resolution2.height = settingItemData.config.mResolutions[settingItemData.curValue.iIndex].RightValue;
			}
			if (resolution.width < resolution2.width || resolution.height < resolution2.height)
			{
				flag2 = true;
			}
		}
		if (flag2)
		{
			bool flag3 = false;
			if (settingItemData.config != null && settingItemData.config.mResolutions != null)
			{
				foreach (IntPair intPair in settingItemData.config.mResolutions)
				{
					if (intPair.LeftValue == resolution.width && intPair.RightValue == resolution.height)
					{
						resolution3 = resolution;
						flag = true;
						flag3 = true;
						break;
					}
				}
			}
			if (flag3)
			{
				goto IL_0282;
			}
			List<Resolution> list = new List<Resolution>();
			if (settingItemData.config != null && settingItemData.config.mResolutions != null)
			{
				foreach (IntPair intPair2 in settingItemData.config.mResolutions)
				{
					list.Add(new Resolution
					{
						width = intPair2.LeftValue,
						height = intPair2.RightValue
					});
				}
				list.Sort(new Comparison<Resolution>(this.method_13));
			}
			using (List<Resolution>.Enumerator enumerator = list.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					Resolution resolution4 = enumerator.Current;
					if (resolution4.width < resolution.width && resolution4.height < resolution.height)
					{
						resolution3 = resolution4;
						flag = false;
						break;
					}
				}
				goto IL_0282;
			}
		}
		resolution3 = resolution2;
		if (settingItemData2 != null)
		{
			flag = settingItemData2.curValue.bOn;
		}
		IL_0282:
		if (resolution3.width != 0 && resolution3.height != 0)
		{
			if (settingItemData.config != null && settingItemData.config.mResolutions != null)
			{
				for (int j = 0; j < settingItemData.config.mResolutions.Length; j++)
				{
					if (settingItemData.config.mResolutions[j].LeftValue == resolution3.width && settingItemData.config.mResolutions[j].RightValue == resolution3.height)
					{
						settingItemData.newValue.iIndex = j;
						settingItemData.bDirty = true;
					}
				}
			}
			if (settingItemData2 != null)
			{
				settingItemData2.newValue.bOn = flag;
				settingItemData2.bDirty = true;
			}
			return;
		}
	}

	// Token: 0x060030DA RID: 12506 RVA: 0x0001FD7E File Offset: 0x0001DF7E
	protected int method_13(Resolution resolution_0, Resolution resolution_1)
	{
		return resolution_0.width - resolution_1.width;
	}

	// Token: 0x060030DB RID: 12507 RVA: 0x000DEB7C File Offset: 0x000DCD7C
	public void method_14(string string_0, int int_0)
	{
		List<int> list = new List<int>();
		list.Add(int_0);
		ServiceWrapperBase<CharacterServiceWrapper>.Instance.method_26(string_0, list);
	}

	// Token: 0x060030DC RID: 12508 RVA: 0x000DEBA4 File Offset: 0x000DCDA4
	public int method_15(string string_0)
	{
		int num = ((ServiceWrapperBase<CharacterServiceWrapper>.Instance != null) ? ServiceWrapperBase<CharacterServiceWrapper>.Instance.method_11() : 0);
		if (!this._disCharacterSetting.ContainsKey(num) && PlayerPrefs.HasKey(num.ToString()))
		{
			this._disCharacterSetting.Add(num, new Dictionary<string, int>());
			this.method_17(this._disCharacterSetting[num], PlayerPrefs.GetString(num.ToString()));
		}
		if (this._disCharacterSetting.ContainsKey(num) && this._disCharacterSetting[num].ContainsKey(string_0))
		{
			return this._disCharacterSetting[num][string_0];
		}
		return 0;
	}

	// Token: 0x060030DD RID: 12509 RVA: 0x000DEC48 File Offset: 0x000DCE48
	public void OnGetCharacterSettingFromServer(string setting)
	{
		int num = ((ServiceWrapperBase<CharacterServiceWrapper>.Instance != null) ? ServiceWrapperBase<CharacterServiceWrapper>.Instance.method_11() : 0);
		if (!this._disCharacterSetting.ContainsKey(num))
		{
			this._disCharacterSetting.Add(num, new Dictionary<string, int>());
		}
		this.method_17(this._disCharacterSetting[num], setting);
	}

	// Token: 0x060030DE RID: 12510 RVA: 0x000DEC9C File Offset: 0x000DCE9C
	private string method_16(Dictionary<string, int> dictionary_0)
	{
		JSONObject jsonobject = new JSONObject();
		foreach (KeyValuePair<string, int> keyValuePair in dictionary_0)
		{
			jsonobject.AddField(keyValuePair.Key, keyValuePair.Value);
		}
		return jsonobject.ToString();
	}

	// Token: 0x060030DF RID: 12511 RVA: 0x000DED04 File Offset: 0x000DCF04
	private void method_17(Dictionary<string, int> dictionary_0, string string_0)
	{
		JSONObject jsonobject = JSONObject.Create(string_0, -2, false, false);
		if (jsonobject != null && jsonobject.keys != null)
		{
			foreach (string text in jsonobject.keys)
			{
				if (dictionary_0.ContainsKey(text))
				{
					dictionary_0[text] = (int)jsonobject.GetField(text).n;
				}
				else
				{
					dictionary_0.Add(text, (int)jsonobject.GetField(text).n);
				}
			}
		}
	}

	// Token: 0x060030E0 RID: 12512 RVA: 0x000DED98 File Offset: 0x000DCF98
	public void method_18()
	{
		if (!this._bNeedRestoreSettings)
		{
			return;
		}
		this.method_8();
		List<GameSettingMgr.SettingItemData> list = new List<GameSettingMgr.SettingItemData>();
		List<GameSettingMgr.SettingItemData> list2 = new List<GameSettingMgr.SettingItemData>();
		foreach (GameSettingMgr.SettingItemData settingItemData in this._dicSettingsByFunctionType.Values)
		{
			SettingStoreLocation settingStoreLocation = settingItemData.config.mStoreLocation;
			if (settingItemData.config.mFunctionType == SettingFunctionType.FOV)
			{
				settingStoreLocation = SettingStoreLocation.Server;
			}
			if (settingStoreLocation != SettingStoreLocation.Server)
			{
				if (settingStoreLocation == SettingStoreLocation.Local)
				{
					list2.Add(settingItemData);
				}
			}
			else
			{
				list.Add(settingItemData);
			}
		}
		JSONObject jsonobject = new JSONObject();
		JSONObject jsonobject2 = new JSONObject();
		foreach (GameSettingMgr.SettingItemData settingItemData2 in list)
		{
			JSONObject jsonobject3 = this.method_19(settingItemData2);
			jsonobject.Add(jsonobject3);
		}
		foreach (GameSettingMgr.SettingItemData settingItemData3 in list2)
		{
			JSONObject jsonobject4 = this.method_19(settingItemData3);
			jsonobject2.Add(jsonobject4);
		}
		ServiceWrapperBase<CharacterServiceWrapper>.Instance.method_28("PlayerSetting", jsonobject);
		string text = jsonobject2.ToString();
		PlayerPrefs.SetString("PlayerSetting", text);
		PlayerPrefs.Save();
		this._bNeedRestoreSettings = false;
	}

	// Token: 0x060030E1 RID: 12513 RVA: 0x0001FD8F File Offset: 0x0001DF8F
	public void OnGetSavedSettingsStrings(string strPlayerSettings)
	{
		if (strPlayerSettings != null && strPlayerSettings.Length > 0)
		{
			this.method_20(strPlayerSettings);
		}
		this.method_8();
		this.method_5();
	}

	// Token: 0x060030E2 RID: 12514 RVA: 0x000DEF14 File Offset: 0x000DD114
	protected JSONObject method_19(GameSettingMgr.SettingItemData settingItemData_0)
	{
		if (settingItemData_0 == null)
		{
			return null;
		}
		JSONObject jsonobject = new JSONObject();
		jsonobject.AddField(0.ToString(), (int)settingItemData_0.type);
		if (settingItemData_0.type == GameSettingMgr.SettingItemDataType.ConfigItem)
		{
			jsonobject.AddField(1.ToString(), (int)settingItemData_0.config.mFunctionType);
			switch (settingItemData_0.config.mDisplayType)
			{
			case SettingDisplayType.Range:
				jsonobject.AddField(2.ToString(), settingItemData_0.curValue.fValue);
				break;
			case SettingDisplayType.Options:
				jsonobject.AddField(3.ToString(), settingItemData_0.curValue.iIndex);
				break;
			case SettingDisplayType.Toggle:
				jsonobject.AddField(4.ToString(), settingItemData_0.curValue.bOn);
				break;
			}
		}
		else if (settingItemData_0.type == GameSettingMgr.SettingItemDataType.KeyBinding)
		{
			jsonobject.AddField(5.ToString(), (int)settingItemData_0.controlAction);
			jsonobject.AddField(6.ToString(), (int)settingItemData_0.curValue.keyBinding.primaryKey);
			jsonobject.AddField(7.ToString(), (int)settingItemData_0.curValue.keyBinding.seconderyKey);
		}
		JSONObject jsonobject2 = new JSONObject();
		for (int i = 0; i < settingItemData_0.children.Count; i++)
		{
			GameSettingMgr.SettingItemData settingItemData = settingItemData_0.children[i];
			JSONObject jsonobject3 = this.method_19(settingItemData);
			jsonobject2.Add(jsonobject3);
		}
		jsonobject.AddField(8.ToString(), jsonobject2);
		return jsonobject;
	}

	// Token: 0x060030E3 RID: 12515 RVA: 0x000DF098 File Offset: 0x000DD298
	protected void method_20(string string_0)
	{
		JSONObject jsonobject = JSONObject.Create(string_0, -2, false, false);
		if (jsonobject != null && jsonobject.list != null)
		{
			foreach (JSONObject jsonobject2 in jsonobject.list)
			{
				JSONObject field = jsonobject2.GetField(1.ToString());
				GameSettingMgr.SettingItemData settingItemData = null;
				if (field != null)
				{
					int num = (int)field.n;
					SettingFunctionType settingFunctionType = (SettingFunctionType)num;
					if (this._dicSettingsByFunctionType.TryGetValue(settingFunctionType, out settingItemData))
					{
						this.method_21(jsonobject2, settingItemData);
					}
				}
			}
			return;
		}
	}

	// Token: 0x060030E4 RID: 12516 RVA: 0x000DF138 File Offset: 0x000DD338
	protected void method_21(JSONObject jsonobject_0, GameSettingMgr.SettingItemData settingItemData_0)
	{
		if (jsonobject_0 == null || settingItemData_0 == null)
		{
			return;
		}
		if (settingItemData_0.type == GameSettingMgr.SettingItemDataType.ConfigItem)
		{
			switch (settingItemData_0.config.mDisplayType)
			{
			case SettingDisplayType.Range:
			{
				JSONObject jsonobject = jsonobject_0.GetField(2.ToString());
				if (jsonobject != null)
				{
					float n = jsonobject.n;
					settingItemData_0.curValue.fValue = n;
					settingItemData_0.newValue.fValue = n;
				}
				break;
			}
			case SettingDisplayType.Options:
			{
				JSONObject jsonobject = jsonobject_0.GetField(3.ToString());
				if (jsonobject != null)
				{
					int num = (int)jsonobject.n;
					if (settingItemData_0.config != null && settingItemData_0.config.mFunctionType == SettingFunctionType.Language)
					{
						num = 1;
					}
					settingItemData_0.curValue.iIndex = num;
					settingItemData_0.newValue.iIndex = num;
				}
				break;
			}
			case SettingDisplayType.Toggle:
			{
				JSONObject jsonobject = jsonobject_0.GetField(4.ToString());
				if (jsonobject != null)
				{
					bool b = jsonobject.b;
					settingItemData_0.curValue.bOn = b;
					settingItemData_0.newValue.bOn = b;
				}
				break;
			}
			}
		}
		else if (settingItemData_0.type == GameSettingMgr.SettingItemDataType.KeyBinding)
		{
			JSONObject jsonobject = jsonobject_0.GetField(6.ToString());
			if (jsonobject != null)
			{
				int num2 = (int)jsonobject.n;
				settingItemData_0.curValue.keyBinding.primaryKey = (KeyCode)num2;
				settingItemData_0.newValue.keyBinding.primaryKey = (KeyCode)num2;
			}
			jsonobject = jsonobject_0.GetField(7.ToString());
			if (jsonobject != null)
			{
				int num3 = (int)jsonobject.n;
				settingItemData_0.curValue.keyBinding.seconderyKey = (KeyCode)num3;
				settingItemData_0.newValue.keyBinding.seconderyKey = (KeyCode)num3;
			}
		}
		settingItemData_0.bDirty = true;
		JSONObject field = jsonobject_0.GetField(8.ToString());
		if (field != null && field.list != null)
		{
			foreach (GameSettingMgr.SettingItemData settingItemData in settingItemData_0.children)
			{
				if (settingItemData.type == GameSettingMgr.SettingItemDataType.KeyBinding)
				{
					foreach (JSONObject jsonobject2 in field.list)
					{
						JSONObject field2 = jsonobject2.GetField(5.ToString());
						if (field2 != null)
						{
							int num4 = (int)field2.n;
							int controlAction = (int)settingItemData.controlAction;
							if (num4 == controlAction)
							{
								this.method_21(jsonobject2, settingItemData);
							}
						}
					}
				}
			}
			return;
		}
	}

	// Token: 0x040021DF RID: 8671
	protected const string PLAYERSETTING_KEY = "PlayerSetting";

	// Token: 0x040021E0 RID: 8672
	protected Dictionary<SettingCategory, List<GameSettingMgr.SettingItemData>> _dicSettingsByCategory = new Dictionary<SettingCategory, List<GameSettingMgr.SettingItemData>>();

	// Token: 0x040021E1 RID: 8673
	protected Dictionary<SettingFunctionType, GameSettingMgr.SettingItemData> _dicSettingsByFunctionType = new Dictionary<SettingFunctionType, GameSettingMgr.SettingItemData>();

	// Token: 0x040021E2 RID: 8674
	protected Dictionary<int, Dictionary<string, int>> _disCharacterSetting = new Dictionary<int, Dictionary<string, int>>();

	// Token: 0x040021E3 RID: 8675
	protected GameSettingMgr.SettingNotificationListener _settingsListener = new GameSettingMgr.SettingNotificationListener();

	// Token: 0x040021E4 RID: 8676
	protected bool _bNeedRestoreSettings;

	// Token: 0x02000738 RID: 1848
	public enum SettingItemDataType
	{
		// Token: 0x040021E6 RID: 8678
		ConfigItem,
		// Token: 0x040021E7 RID: 8679
		KeyBinding
	}

	// Token: 0x02000739 RID: 1849
	public enum UserData
	{
		// Token: 0x040021E9 RID: 8681
		PlayedTutorial
	}

	// Token: 0x0200073A RID: 1850
	public class SettingItemData
	{
		// Token: 0x060030E6 RID: 12518 RVA: 0x000DF3BC File Offset: 0x000DD5BC
		public void method_0()
		{
			if (!this.bEnable)
			{
				this.curValue.fValue = this.newValue.fValue;
				this.curValue.iIndex = this.newValue.iIndex;
				this.curValue.bOn = this.newValue.bOn;
				this.curValue.keyBinding.primaryKey = this.newValue.keyBinding.primaryKey;
				this.curValue.keyBinding.seconderyKey = this.newValue.keyBinding.seconderyKey;
				this.bDirty = false;
				return;
			}
			if (this.bDirty)
			{
				this.method_1(this.newValue);
				this.curValue.fValue = this.newValue.fValue;
				this.curValue.iIndex = this.newValue.iIndex;
				this.curValue.bOn = this.newValue.bOn;
				this.curValue.keyBinding.primaryKey = this.newValue.keyBinding.primaryKey;
				this.curValue.keyBinding.seconderyKey = this.newValue.keyBinding.seconderyKey;
				this.bDirty = false;
			}
			foreach (GameSettingMgr.SettingItemData settingItemData in this.children)
			{
				settingItemData.method_0();
			}
		}

		// Token: 0x060030E7 RID: 12519 RVA: 0x000DF544 File Offset: 0x000DD744
		protected void method_1(GameSettingMgr.SettingItemValueContainer settingItemValueContainer_0)
		{
			if (this.type == GameSettingMgr.SettingItemDataType.ConfigItem)
			{
				if (this.config == null)
				{
					return;
				}
				PlayerBehavior playerBehavior = null;
				if (MonoSingleton<Session>.Instance && MonoSingleton<Session>.Instance.GetLocalPlayer() != null)
				{
					playerBehavior = MonoSingleton<Session>.Instance.GetLocalPlayer().GetEntity().GetComponent<PlayerBehavior>();
				}
				switch (this.config.mFunctionType)
				{
				case SettingFunctionType.ScreenResolution:
					if (settingItemValueContainer_0.iIndex < this.config.mResolutions.Length)
					{
						IntPair intPair = this.config.mResolutions[settingItemValueContainer_0.iIndex];
						MonoSingleton<GraphicsMgr>.Instance.method_11(intPair.LeftValue, intPair.RightValue);
						return;
					}
					break;
				case SettingFunctionType.FullScreen:
					MonoSingleton<GameSettingMgr>.Instance.method_7(settingItemValueContainer_0.bOn);
					return;
				case SettingFunctionType.OverallQuality:
					QualitySettings.SetQualityLevel(settingItemValueContainer_0.iIndex);
					return;
				case SettingFunctionType.Mute:
					DebugUtils.Log(LogCategory.Audio, "MUTE PATCH CHECK: bOn=" + settingItemValueContainer_0.bOn.ToString() + " AudioSystem.Boolean_0=" + ComponentMonoSingleton<AudioSystem>.Boolean_0.ToString());
					if (ComponentMonoSingleton<AudioSystem>.Boolean_0)
					{
						ComponentMonoSingleton<AudioSystem>.Instance.Boolean_1 = !settingItemValueContainer_0.bOn;
						DebugUtils.Log(LogCategory.Audio, "MUTE PATCH APPLIED: m_enabled now=" + ComponentMonoSingleton<AudioSystem>.Instance.Boolean_1.ToString());
						return;
					}
					break;
				case SettingFunctionType.MasterVolume:
					if (ComponentMonoSingleton<AudioSystem>.Boolean_0 && settingItemValueContainer_0.fValue >= 0f)
					{
						int num = this.config.mRange.RightValue - this.config.mRange.LeftValue;
						ComponentMonoSingleton<AudioSystem>.Instance.method_3(BusDescriptor.Master, settingItemValueContainer_0.fValue / (float)num);
						return;
					}
					break;
				case SettingFunctionType.MusicVolume:
					if (ComponentMonoSingleton<AudioSystem>.Boolean_0)
					{
						int num2 = this.config.mRange.RightValue - this.config.mRange.LeftValue;
						ComponentMonoSingleton<AudioSystem>.Instance.method_3(BusDescriptor.Music, settingItemValueContainer_0.fValue / (float)num2);
						return;
					}
					break;
				case SettingFunctionType.SFXVolume:
					if (ComponentMonoSingleton<AudioSystem>.Boolean_0)
					{
						int num3 = this.config.mRange.RightValue - this.config.mRange.LeftValue;
						ComponentMonoSingleton<AudioSystem>.Instance.method_3(BusDescriptor.SFX, settingItemValueContainer_0.fValue / (float)num3);
						return;
					}
					break;
				case SettingFunctionType.InvertMouse:
					if (playerBehavior != null)
					{
						playerBehavior.method_46(settingItemValueContainer_0.bOn);
						return;
					}
					break;
				case SettingFunctionType.MouseSensitivity:
					if (playerBehavior != null)
					{
						playerBehavior.method_38(settingItemValueContainer_0.fValue);
						return;
					}
					break;
				case SettingFunctionType.AimSensitivity:
					if (playerBehavior != null)
					{
						playerBehavior.SetAimSensitivity(settingItemValueContainer_0.fValue);
						return;
					}
					break;
				case SettingFunctionType.CustomKeyBinding:
				case SettingFunctionType.ResetAllKeybindings:
				case SettingFunctionType.ReplayTutorial:
					break;
				case SettingFunctionType.HoldCrouching:
					if (playerBehavior != null)
					{
						playerBehavior.holdToCrouch = settingItemValueContainer_0.bOn;
						return;
					}
					break;
				case SettingFunctionType.EchoDuration:
					if (settingItemValueContainer_0.fValue > 0f)
					{
						float fValue = settingItemValueContainer_0.fValue;
						MonoSingleton<AppManager>.Instance.method_0().vmethod_5<EchoMessageView>().vmethod_8(fValue);
						return;
					}
					break;
				case SettingFunctionType.AlwaysShowWeaponSlots:
					MonoSingleton<AppManager>.Instance.method_0().vmethod_5<HUDPlayerInfoView>().bAlwaysShowWeaponSlot = settingItemValueContainer_0.bOn;
					return;
				case SettingFunctionType.FrameRate:
					Application.targetFrameRate = MonoSingleton<GraphicsMgr>.Instance.method_1(settingItemValueContainer_0.iIndex);
					QualitySettings.vSyncCount = 0;
					return;
				case SettingFunctionType.FOV:
					if (MonoSingleton<Session>.Instance != null && MonoSingleton<Session>.Instance.GetLocalPlayer() != null)
					{
						EntityPlayer entityPlayer = MonoSingleton<Session>.Instance.GetLocalPlayer().GetEntity() as EntityPlayer;
						if (entityPlayer != null)
						{
							entityPlayer.vmethod_14().vmethod_0<BHVFirstPersonSettings>().m_FOVDefault = settingItemValueContainer_0.fValue;
							return;
						}
					}
					break;
				case SettingFunctionType.Discord:
					if (settingItemValueContainer_0.bOn)
					{
						DiscordRpcHandler.Initialize();
						return;
					}
					DiscordRpcHandler.Shutdown();
					return;
				case SettingFunctionType.Language:
					if (this.config.mControlSchemeList != null && this.config.mControlSchemeList.Length > 1)
					{
						settingItemValueContainer_0.iIndex = 1;
						this.curValue.iIndex = 1;
						this.newValue.iIndex = 1;
						LocalizeSystem.smethod_0().method_0(this.config.mControlSchemeList[1]);
						MonoSingleton<global::EchoMessageManager>.Instance.RefreshLocalization();
						return;
					}
					break;
				default:
					return;
				}
			}
			else if (this.type == GameSettingMgr.SettingItemDataType.KeyBinding)
			{
				MonoSingleton<InputManager>.Instance.method_22(this.controlAction.ToString(), settingItemValueContainer_0.keyBinding.primaryKey, settingItemValueContainer_0.keyBinding.seconderyKey, ControlGroup.Common);
			}
		}

		// Token: 0x060030E8 RID: 12520 RVA: 0x000DF954 File Offset: 0x000DDB54
		public void Reset()
		{
			this.method_2();
			foreach (GameSettingMgr.SettingItemData settingItemData in this.children)
			{
				settingItemData.Reset();
			}
		}

		// Token: 0x060030E9 RID: 12521 RVA: 0x000DF9AC File Offset: 0x000DDBAC
		protected void method_2()
		{
			if (this.type == GameSettingMgr.SettingItemDataType.ConfigItem && this.config != null)
			{
				if (this.config.mFunctionType == SettingFunctionType.CustomKeyBinding)
				{
					MonoSingleton<InputManager>.Instance.method_23();
					MonoSingleton<GameSettingMgr>.Instance.method_11();
				}
				else
				{
					this.newValue.fValue = (this.curValue.fValue = this.config.mDefaultFloat);
					this.newValue.iIndex = (this.curValue.iIndex = ((this.config.mFunctionType == SettingFunctionType.Language) ? 1 : this.config.mDefaultInt));
					this.newValue.bOn = (this.curValue.bOn = this.config.mDefaultBool);
					this.method_1(this.curValue);
				}
			}
		}

		// Token: 0x060030EA RID: 12522 RVA: 0x000DFA70 File Offset: 0x000DDC70
		public void method_3()
		{
			this.method_4();
			foreach (GameSettingMgr.SettingItemData settingItemData in this.children)
			{
				settingItemData.method_4();
			}
		}

		// Token: 0x060030EB RID: 12523 RVA: 0x000DFAC8 File Offset: 0x000DDCC8
		protected void method_4()
		{
			if (this.bDirty)
			{
				this.newValue.fValue = this.curValue.fValue;
				this.newValue.iIndex = this.curValue.iIndex;
				this.newValue.bOn = this.curValue.bOn;
				this.newValue.keyBinding.primaryKey = this.curValue.keyBinding.primaryKey;
				this.newValue.keyBinding.seconderyKey = this.curValue.keyBinding.seconderyKey;
				this.bDirty = false;
			}
		}

		// Token: 0x060030EC RID: 12524 RVA: 0x000DFB6C File Offset: 0x000DDD6C
		public bool method_5()
		{
			bool flag;
			if (!(flag = this.bDirty && this.bEnable))
			{
				foreach (GameSettingMgr.SettingItemData settingItemData in this.children)
				{
					if (settingItemData.method_5())
					{
						flag = true;
						break;
					}
				}
			}
			return flag;
		}

		// Token: 0x040021EA RID: 8682
		public bool bDirty;

		// Token: 0x040021EB RID: 8683
		public bool bEnable = true;

		// Token: 0x040021EC RID: 8684
		public GameSettingMgr.SettingItemDataType type;

		// Token: 0x040021ED RID: 8685
		public GameSettingMgr.SettingItemValueContainer curValue = new GameSettingMgr.SettingItemValueContainer();

		// Token: 0x040021EE RID: 8686
		public GameSettingMgr.SettingItemValueContainer newValue = new GameSettingMgr.SettingItemValueContainer();

		// Token: 0x040021EF RID: 8687
		public SettingItem config;

		// Token: 0x040021F0 RID: 8688
		public ControlAction controlAction;

		// Token: 0x040021F1 RID: 8689
		public List<GameSettingMgr.SettingItemData> children = new List<GameSettingMgr.SettingItemData>();
	}

	// Token: 0x0200073B RID: 1851
	public class SettingItemValueContainer
	{
		// Token: 0x040021F2 RID: 8690
		public float fValue = -1f;

		// Token: 0x040021F3 RID: 8691
		public int iIndex = -1;

		// Token: 0x040021F4 RID: 8692
		public bool bOn;

		// Token: 0x040021F5 RID: 8693
		public InputManager.InputKeyBinding keyBinding = new InputManager.InputKeyBinding();
	}

	// Token: 0x0200073C RID: 1852
	public enum SettingSavingKeyword
	{
		// Token: 0x040021F7 RID: 8695
		dataType,
		// Token: 0x040021F8 RID: 8696
		functionType,
		// Token: 0x040021F9 RID: 8697
		fValue,
		// Token: 0x040021FA RID: 8698
		iIndex,
		// Token: 0x040021FB RID: 8699
		bOn,
		// Token: 0x040021FC RID: 8700
		action,
		// Token: 0x040021FD RID: 8701
		prikey,
		// Token: 0x040021FE RID: 8702
		seckey,
		// Token: 0x040021FF RID: 8703
		child
	}

	// Token: 0x0200073D RID: 1853
	protected class SettingNotificationListener : ICharacterServiceNotificationListerner
	{
		// Token: 0x060030EF RID: 12527 RVA: 0x0000311B File Offset: 0x0000131B
		void ICharacterServiceNotificationListerner.OnGotMyCurrencies(CurrencyInfo currency)
		{
		}

		// Token: 0x060030F0 RID: 12528 RVA: 0x0000311B File Offset: 0x0000131B
		void ICharacterServiceNotificationListerner.OnExperienceUpdated(int experience)
		{
		}

		// Token: 0x060030F1 RID: 12529 RVA: 0x0001FE05 File Offset: 0x0001E005
		void ICharacterServiceNotificationListerner.OnGetPersonalSettings(string strSettings)
		{
			MonoSingleton<GameSettingMgr>.Instance.OnGetPlayerSettingFromServer();
		}

		// Token: 0x060030F2 RID: 12530 RVA: 0x0000311B File Offset: 0x0000131B
		void ICharacterServiceNotificationListerner.OnSetPersonalSettings(int iResult)
		{
		}

		// Token: 0x060030F3 RID: 12531 RVA: 0x0001FE11 File Offset: 0x0001E011
		void ICharacterServiceNotificationListerner.OnGetCharacterSettings(string strSettings)
		{
			MonoSingleton<GameSettingMgr>.Instance.OnGetCharacterSettingFromServer(strSettings);
		}

		// Token: 0x060030F4 RID: 12532 RVA: 0x0000311B File Offset: 0x0000131B
		void ICharacterServiceNotificationListerner.OnSetCharacterSettings(int iResult)
		{
		}
	}
}
