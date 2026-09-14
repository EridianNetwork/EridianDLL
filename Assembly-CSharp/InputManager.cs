using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using Core;
using ns0;
using UnityEngine;
using XsdSettings;

// Token: 0x02000266 RID: 614
public class InputManager : MonoSingleton<InputManager>
{
	// Token: 0x06000CC2 RID: 3266 RVA: 0x0000C1B8 File Offset: 0x0000A3B8
	public void method_0(InputReader inputReader_0)
	{
		this.m_reader = inputReader_0;
	}

	// Token: 0x06000CC3 RID: 3267 RVA: 0x0006CB84 File Offset: 0x0006AD84
	private void Start()
	{
		this.m_inputMap.Clear();
		this.m_groupMap.Clear();
		this.m_defaultInputMap.Clear();
		this.m_configToGlobalKeycodeMap.Clear();
		this.m_customableKeycodeCollection.Clear();
		this.m_customableFunctionCollection.Clear();
		this.m_listenersOnSettingsChanged.Clear();
		foreach (KeyboardCode keyboardCode in (KeyboardCode[])Enum.GetValues(typeof(KeyboardCode)))
		{
			KeyCode keyCode = (KeyCode)((int)Enum.Parse(typeof(KeyCode), keyboardCode.ToString()));
			this.m_configToGlobalKeycodeMap.Add(keyboardCode, keyCode);
			this.m_customableKeycodeCollection.Add(keyCode);
		}
		TextAsset textAsset = (TextAsset)ResourcesLoader.smethod_0("Settings/ControlScheme");
		using (StringReader stringReader = new StringReader(textAsset.text))
		{
			XmlSerializer xmlSerializer = new XmlSerializer(typeof(ControlSchemeSetup));
			this.m_presetControlSchemeSetup = xmlSerializer.Deserialize(stringReader) as ControlSchemeSetup;
		}
		ResourcesLoader.smethod_6(textAsset);
		this.method_23();
	}

	// Token: 0x06000CC4 RID: 3268 RVA: 0x0006CCB0 File Offset: 0x0006AEB0
	public void method_1(bool bool_0 = false)
	{
		if (bool_0)
		{
			this.m_isPlayerDead = true;
		}
		DebugUtils.Log(LogCategory.Input, "InputManager.LockControl - was: " + this.m_isControlLocked);
		this.m_isControlLocked = true;
		if (MonoSingleton<Session>.Instance)
		{
			PlayerInfoSync localPlayer = MonoSingleton<Session>.Instance.GetLocalPlayer();
			if (localPlayer)
			{
				StatisticsManager.StatSheet personalStatSheet = MonoSingleton<StatisticsManager>.Instance.GetCurrentSession().GetPersonalStatSheet(localPlayer);
				if (personalStatSheet != null)
				{
					personalStatSheet.method_3(true);
				}
			}
		}
	}

	// Token: 0x06000CC5 RID: 3269 RVA: 0x0006CD24 File Offset: 0x0006AF24
	public void method_2(bool bool_0 = false)
	{
		if (bool_0)
		{
			this.m_isPlayerDead = false;
		}
		if (this.m_isPlayerDead)
		{
			return;
		}
		DebugUtils.Log(LogCategory.Input, "InputManager.UnlockControl - was: " + this.m_isControlLocked);
		if (MonoSingleton<Session>.Instance)
		{
			PlayerInfoSync localPlayer = MonoSingleton<Session>.Instance.GetLocalPlayer();
			if (localPlayer)
			{
				StatisticsManager.StatSheet personalStatSheet = MonoSingleton<StatisticsManager>.Instance.GetCurrentSession().GetPersonalStatSheet(localPlayer);
				if (personalStatSheet != null)
				{
					personalStatSheet.method_3(false);
				}
			}
		}
		this.m_isControlLocked = false;
	}

	// Token: 0x06000CC6 RID: 3270 RVA: 0x0000C1C1 File Offset: 0x0000A3C1
	public bool method_3()
	{
		return this.m_isControlLocked;
	}

	// Token: 0x06000CC7 RID: 3271 RVA: 0x0006CDA0 File Offset: 0x0006AFA0
	public bool method_4(string string_0)
	{
		InputManager.InputKeyBinding inputKeyBinding = this.method_10(string_0);
		if (inputKeyBinding.primaryKey == KeyCode.None && inputKeyBinding.seconderyKey == KeyCode.None)
		{
			return this.m_reader.GetButton(string_0);
		}
		return this.m_reader.GetKey(inputKeyBinding.primaryKey) || this.m_reader.GetKey(inputKeyBinding.seconderyKey);
	}

	// Token: 0x06000CC8 RID: 3272 RVA: 0x0000C1C9 File Offset: 0x0000A3C9
	public float method_5(string string_0)
	{
		return this.m_reader.GetAxis(string_0);
	}

	// Token: 0x06000CC9 RID: 3273 RVA: 0x0006CDFC File Offset: 0x0006AFFC
	public bool method_6(string string_0)
	{
		InputManager.InputKeyBinding inputKeyBinding = this.method_10(string_0);
		if (inputKeyBinding.primaryKey == KeyCode.None && inputKeyBinding.seconderyKey == KeyCode.None)
		{
			return this.m_reader.GetButtonUp(string_0);
		}
		return this.m_reader.GetKeyUp(inputKeyBinding.primaryKey) || this.m_reader.GetKeyUp(inputKeyBinding.seconderyKey);
	}

	// Token: 0x06000CCA RID: 3274 RVA: 0x0000C1D7 File Offset: 0x0000A3D7
	public bool method_7(string string_0)
	{
		if (this.m_lastKeyUpdate[string_0] != 1)
		{
			if (this.m_lastKeyUpdate[string_0] != 3)
			{
				return false;
			}
		}
		return true;
	}

	// Token: 0x06000CCB RID: 3275 RVA: 0x0000C1FC File Offset: 0x0000A3FC
	public bool method_8(string string_0)
	{
		if (this.m_lastKeyUpdate[string_0] != 2)
		{
			if (this.m_lastKeyUpdate[string_0] != 3)
			{
				return false;
			}
		}
		return true;
	}

	// Token: 0x06000CCC RID: 3276 RVA: 0x0006CE58 File Offset: 0x0006B058
	public bool method_9(string string_0)
	{
		InputManager.InputKeyBinding inputKeyBinding = this.method_10(string_0);
		if (inputKeyBinding.primaryKey == KeyCode.None && inputKeyBinding.seconderyKey == KeyCode.None)
		{
			return this.m_reader.GetButtonDown(string_0);
		}
		return this.m_reader.GetKeyDown(inputKeyBinding.primaryKey) || this.m_reader.GetKeyDown(inputKeyBinding.seconderyKey);
	}

	// Token: 0x06000CCD RID: 3277 RVA: 0x0000C221 File Offset: 0x0000A421
	private InputManager.InputKeyBinding method_10(string string_0)
	{
		if (this.m_inputMap.ContainsKey(string_0))
		{
			return this.m_inputMap[string_0];
		}
		return new InputManager.InputKeyBinding(KeyCode.None, KeyCode.None);
	}

	// Token: 0x06000CCE RID: 3278 RVA: 0x0000C245 File Offset: 0x0000A445
	public bool method_11(int int_0, bool bool_0 = false)
	{
		return this.m_reader.GetMouseButton(int_0, bool_0);
	}

	// Token: 0x06000CCF RID: 3279 RVA: 0x0000C254 File Offset: 0x0000A454
	public bool method_12(int int_0, bool bool_0 = false)
	{
		return this.m_reader.GetMouseButtonDown(int_0, bool_0);
	}

	// Token: 0x06000CD0 RID: 3280 RVA: 0x0000C263 File Offset: 0x0000A463
	public bool method_13(int int_0, bool bool_0 = false)
	{
		return this.m_reader.GetMouseButtonUp(int_0, bool_0);
	}

	// Token: 0x06000CD1 RID: 3281 RVA: 0x0006CEB4 File Offset: 0x0006B0B4
	public Dictionary<string, InputManager.InputKeyBinding> method_14()
	{
		Dictionary<string, InputManager.InputKeyBinding> dictionary = new Dictionary<string, InputManager.InputKeyBinding>();
		foreach (KeyValuePair<string, InputManager.InputKeyBinding> keyValuePair in this.m_inputMap)
		{
			if (this.m_customableFunctionCollection.Contains(keyValuePair.Key))
			{
				dictionary.Add(keyValuePair.Key, keyValuePair.Value);
			}
		}
		return dictionary;
	}

	// Token: 0x06000CD2 RID: 3282 RVA: 0x0006CF30 File Offset: 0x0006B130
	public KeyCode method_15()
	{
		KeyCode keyCode = KeyCode.None;
		foreach (KeyCode keyCode2 in this.m_customableKeycodeCollection)
		{
			if (this.m_reader.GetKeyDown(keyCode2))
			{
				keyCode = keyCode2;
				break;
			}
		}
		return keyCode;
	}

	// Token: 0x06000CD3 RID: 3283 RVA: 0x0006CF90 File Offset: 0x0006B190
	public InputManager.InputKeyBinding method_16(string string_0)
	{
		InputManager.InputKeyBinding inputKeyBinding = null;
		this.m_inputMap.TryGetValue(string_0, out inputKeyBinding);
		return inputKeyBinding;
	}

	// Token: 0x06000CD4 RID: 3284 RVA: 0x0006CFB0 File Offset: 0x0006B1B0
	public List<string> method_17(string string_0, KeyCode keyCode_0)
	{
		ControlGroup controlGroup = ControlGroup.Common;
		this.m_groupMap.TryGetValue(string_0, out controlGroup);
		List<string> list = new List<string>();
		foreach (KeyValuePair<string, ControlGroup> keyValuePair in this.m_groupMap)
		{
			if (string_0 != keyValuePair.Key && (controlGroup == ControlGroup.Common || keyValuePair.Value == controlGroup || keyValuePair.Value == ControlGroup.Common) && (this.method_16(keyValuePair.Key).primaryKey == keyCode_0 || this.method_16(keyValuePair.Key).seconderyKey == keyCode_0))
			{
				list.Add(keyValuePair.Key);
			}
		}
		return list;
	}

	// Token: 0x06000CD5 RID: 3285 RVA: 0x0006D070 File Offset: 0x0006B270
	public bool method_18(string string_0, KeyCode keyCode_0)
	{
		ControlGroup controlGroup = ControlGroup.Common;
		this.m_groupMap.TryGetValue(string_0, out controlGroup);
		List<InputManager.InputKeyBinding> list = new List<InputManager.InputKeyBinding>();
		foreach (KeyValuePair<string, ControlGroup> keyValuePair in this.m_groupMap)
		{
			if (string_0 != keyValuePair.Key && (controlGroup == ControlGroup.Common || keyValuePair.Value == controlGroup || keyValuePair.Value == ControlGroup.Common))
			{
				list.Add(this.method_16(keyValuePair.Key));
			}
		}
		int i = 0;
		while (i < list.Count)
		{
			if (list[i].primaryKey != keyCode_0)
			{
				if (list[i].seconderyKey != keyCode_0)
				{
					i++;
					continue;
				}
			}
			return true;
		}
		return false;
	}

	// Token: 0x06000CD6 RID: 3286 RVA: 0x0006D144 File Offset: 0x0006B344
	public bool method_19()
	{
		foreach (KeyValuePair<string, InputManager.InputKeyBinding> keyValuePair in this.m_inputMap)
		{
			if (keyValuePair.Value.primaryKey == KeyCode.None)
			{
				return false;
			}
		}
		return true;
	}

	// Token: 0x06000CD7 RID: 3287 RVA: 0x0006D1A4 File Offset: 0x0006B3A4
	public void method_20(string string_0, KeyCode keyCode_0)
	{
		InputManager.InputKeyBinding inputKeyBinding = this.method_16(string_0);
		if (inputKeyBinding == null)
		{
			return;
		}
		if (inputKeyBinding.primaryKey == keyCode_0)
		{
			this.method_22(string_0, KeyCode.None, inputKeyBinding.seconderyKey, ControlGroup.Common);
		}
		if (inputKeyBinding.seconderyKey == keyCode_0)
		{
			this.method_22(string_0, inputKeyBinding.primaryKey, KeyCode.None, ControlGroup.Common);
		}
	}

	// Token: 0x06000CD8 RID: 3288 RVA: 0x0006D1F0 File Offset: 0x0006B3F0
	public void method_21(string string_0)
	{
		InputManager.InputKeyBinding inputKeyBinding = null;
		if (this.m_defaultInputMap.TryGetValue(string_0, out inputKeyBinding))
		{
			this.method_22(string_0, inputKeyBinding.primaryKey, inputKeyBinding.seconderyKey, ControlGroup.Common);
		}
	}

	// Token: 0x06000CD9 RID: 3289 RVA: 0x0006D224 File Offset: 0x0006B424
	public void method_22(string string_0, KeyCode keyCode_0, KeyCode keyCode_1, ControlGroup controlGroup_0 = ControlGroup.Common)
	{
		InputManager.InputKeyBinding inputKeyBinding = null;
		if (this.m_inputMap.TryGetValue(string_0, out inputKeyBinding))
		{
			inputKeyBinding.primaryKey = keyCode_0;
			inputKeyBinding.seconderyKey = keyCode_1;
		}
		else
		{
			inputKeyBinding = new InputManager.InputKeyBinding(keyCode_0, keyCode_1);
			this.m_inputMap.Add(string_0, inputKeyBinding);
			if (!this.m_groupMap.ContainsKey(string_0))
			{
				this.m_groupMap.Add(string_0, controlGroup_0);
			}
		}
		this.m_lastKeyUpdate.Clear();
		Dictionary<string, InputManager.InputKeyBinding>.Enumerator enumerator = this.m_inputMap.GetEnumerator();
		while (enumerator.MoveNext())
		{
			Dictionary<string, int> lastKeyUpdate = this.m_lastKeyUpdate;
			KeyValuePair<string, InputManager.InputKeyBinding> keyValuePair = enumerator.Current;
			lastKeyUpdate.Add(keyValuePair.Key, 0);
		}
		this.method_25(string_0, inputKeyBinding);
	}

	// Token: 0x06000CDA RID: 3290 RVA: 0x0006D2CC File Offset: 0x0006B4CC
	public void method_23()
	{
		this.m_inputMap.Clear();
		this.m_groupMap.Clear();
		this.m_defaultInputMap.Clear();
		if (this.m_presetControlSchemeSetup.mControlSchemeList != null && this.m_presetControlSchemeSetup.mControlSchemeList.Length > 0)
		{
			ControlScheme controlScheme = this.m_presetControlSchemeSetup.mControlSchemeList[0];
			if (controlScheme != null && controlScheme.mKeyBindingList != null)
			{
				foreach (KeyBindingItem keyBindingItem in controlScheme.mKeyBindingList)
				{
					KeyCode keyCode = KeyCode.None;
					KeyCode keyCode2 = KeyCode.None;
					this.m_configToGlobalKeycodeMap.TryGetValue(keyBindingItem.mPrimaryKey, out keyCode);
					this.m_configToGlobalKeycodeMap.TryGetValue(keyBindingItem.mSecondaryKey, out keyCode2);
					this.method_22(keyBindingItem.mControlAction.ToString(), keyCode, keyCode2, keyBindingItem.mControlGroup);
					InputManager.InputKeyBinding inputKeyBinding = new InputManager.InputKeyBinding(keyCode, keyCode2);
					this.m_defaultInputMap.Add(keyBindingItem.mControlAction.ToString(), inputKeyBinding);
					this.m_customableFunctionCollection.Add(keyBindingItem.mControlAction.ToString());
				}
			}
		}
		this.m_inputMap.Add("Escape", new InputManager.InputKeyBinding(KeyCode.Escape, KeyCode.None));
		this.m_inputMap.Add("UIChatInput", new InputManager.InputKeyBinding(KeyCode.Return, KeyCode.None));
		this.m_inputMap.Add("Fire1", new InputManager.InputKeyBinding(KeyCode.Mouse0, KeyCode.None));
		this.m_inputMap.Add("Delete", new InputManager.InputKeyBinding(KeyCode.Delete, KeyCode.None));
	}

	// Token: 0x06000CDB RID: 3291 RVA: 0x0006D450 File Offset: 0x0006B650
	public void method_24()
	{
		Dictionary<string, InputManager.InputKeyBinding>.Enumerator enumerator = this.m_inputMap.GetEnumerator();
		while (enumerator.MoveNext())
		{
			Dictionary<string, int> lastKeyUpdate = this.m_lastKeyUpdate;
			KeyValuePair<string, InputManager.InputKeyBinding> keyValuePair = enumerator.Current;
			lastKeyUpdate[keyValuePair.Key] = 0;
		}
	}

	// Token: 0x06000CDC RID: 3292 RVA: 0x0006D490 File Offset: 0x0006B690
	private void Update()
	{
		Dictionary<string, InputKeyBinding>.Enumerator enumerator = m_inputMap.GetEnumerator();
		while (enumerator.MoveNext())
		{
			bool flag = Input.GetKeyDown(enumerator.Current.Value.primaryKey) || Input.GetKeyDown(enumerator.Current.Value.seconderyKey);
			bool flag2;
			if ((flag2 = Input.GetKeyUp(enumerator.Current.Value.primaryKey) || Input.GetKeyUp(enumerator.Current.Value.seconderyKey)) && flag)
			{
				m_lastKeyUpdate[enumerator.Current.Key] = 3;
			}
			else if (flag2)
			{
				m_lastKeyUpdate[enumerator.Current.Key] = 2;
			}
			else if (flag)
			{
				m_lastKeyUpdate[enumerator.Current.Key] = 1;
			}
		}
	}
	// Token: 0x06000CDD RID: 3293 RVA: 0x0006D594 File Offset: 0x0006B794
	public void method_25(string string_0, InputManager.InputKeyBinding inputKeyBinding_0)
	{
		Dictionary<string, InputManager.InputKeyBinding> dictionary = new Dictionary<string, InputManager.InputKeyBinding>();
		dictionary[string_0] = inputKeyBinding_0;
		for (int i = 0; i < this.m_listenersOnSettingsChanged.Count; i++)
		{
			this.m_listenersOnSettingsChanged[i](dictionary);
		}
	}

	// Token: 0x06000CDE RID: 3294 RVA: 0x0000C272 File Offset: 0x0000A472
	public void method_26(InputManager.OnKeySettingsChanged onKeySettingsChanged_0)
	{
		if (!this.m_listenersOnSettingsChanged.Contains(onKeySettingsChanged_0))
		{
			this.m_listenersOnSettingsChanged.Add(onKeySettingsChanged_0);
		}
	}

	// Token: 0x06000CDF RID: 3295 RVA: 0x0000C28E File Offset: 0x0000A48E
	public void method_27(InputManager.OnKeySettingsChanged onKeySettingsChanged_0)
	{
		if (this.m_listenersOnSettingsChanged.Contains(onKeySettingsChanged_0))
		{
			this.m_listenersOnSettingsChanged.Remove(onKeySettingsChanged_0);
		}
	}

	// Token: 0x04000B95 RID: 2965
	private bool m_isControlLocked;

	// Token: 0x04000B96 RID: 2966
	private bool m_isPlayerDead;

	// Token: 0x04000B97 RID: 2967
	private InputReader m_reader = new RegularInputReader();

	// Token: 0x04000B98 RID: 2968
	private ControlSchemeSetup m_presetControlSchemeSetup;

	// Token: 0x04000B99 RID: 2969
	private Dictionary<string, InputManager.InputKeyBinding> m_inputMap = new Dictionary<string, InputManager.InputKeyBinding>();

	// Token: 0x04000B9A RID: 2970
	private Dictionary<string, ControlGroup> m_groupMap = new Dictionary<string, ControlGroup>();

	// Token: 0x04000B9B RID: 2971
	private Dictionary<string, InputManager.InputKeyBinding> m_defaultInputMap = new Dictionary<string, InputManager.InputKeyBinding>();

	// Token: 0x04000B9C RID: 2972
	private Dictionary<KeyboardCode, KeyCode> m_configToGlobalKeycodeMap = new Dictionary<KeyboardCode, KeyCode>();

	// Token: 0x04000B9D RID: 2973
	private HashSet<string> m_customableFunctionCollection = new HashSet<string>();

	// Token: 0x04000B9E RID: 2974
	private HashSet<KeyCode> m_customableKeycodeCollection = new HashSet<KeyCode>();

	// Token: 0x04000B9F RID: 2975
	private List<InputManager.OnKeySettingsChanged> m_listenersOnSettingsChanged = new List<InputManager.OnKeySettingsChanged>();

	// Token: 0x04000BA0 RID: 2976
	private Dictionary<string, int> m_lastKeyUpdate = new Dictionary<string, int>();

	// Token: 0x02000267 RID: 615
	public class InputKeyBinding
	{
		// Token: 0x06000CE0 RID: 3296 RVA: 0x00003197 File Offset: 0x00001397
		public InputKeyBinding()
		{
		}

		// Token: 0x06000CE1 RID: 3297 RVA: 0x0000C2AB File Offset: 0x0000A4AB
		public InputKeyBinding(KeyCode keyCode_0, KeyCode keyCode_1)
		{
			this.primaryKey = keyCode_0;
			this.seconderyKey = keyCode_1;
		}

		// Token: 0x04000BA1 RID: 2977
		public KeyCode primaryKey;

		// Token: 0x04000BA2 RID: 2978
		public KeyCode seconderyKey;
	}

	// Token: 0x02000268 RID: 616
	// (Invoke) Token: 0x06000CE3 RID: 3299
	public delegate void OnKeySettingsChanged(Dictionary<string, InputManager.InputKeyBinding> newKeySettings);
}
