using System;
using Core;
using ns0;
using UnityEngine;

// Token: 0x02000127 RID: 295
[ExecuteInEditMode]
public class AudioManager : ResettableMonoSingleton<AudioManager>
{
	// Token: 0x060006B0 RID: 1712 RVA: 0x000548C4 File Offset: 0x00052AC4
	public static void smethod_0()
	{
		if (MonoSingleton<AppManager>.Instance.m_nosound)
		{
			return;
		}
		bool flag;
		if (flag = !MonoSingleton<AudioManager>.Boolean_0)
		{
			AudioManager.smethod_3();
		}
		bool flag2;
		if (flag2 = !ComponentMonoSingleton<AudioSystem>.Boolean_0)
		{
			AudioManager.smethod_1();
		}
		if (flag && flag2)
		{
			AudioManager.smethod_4();
		}
	}

	// Token: 0x060006B1 RID: 1713 RVA: 0x00007801 File Offset: 0x00005A01
	private static AudioSystem smethod_1()
	{
		ComponentMonoSingleton<AudioSystem>.smethod_0();
		ComponentMonoSingleton<AudioSystem>.Instance.imethod_0();
		return ComponentMonoSingleton<AudioSystem>.Instance;
	}

	// Token: 0x060006B2 RID: 1714 RVA: 0x0005490C File Offset: 0x00052B0C
	private static GameObject smethod_2()
	{
		GameObject gameObject = GameObject.Find(AudioManager.AUDIO_SYSTEM_GO_NAME);
		if (null == gameObject)
		{
			DebugUtils.Log(LogCategory.Audio, "AudioManager.GetAudioGameObject: creating audio GO");
			gameObject = new GameObject(AudioManager.AUDIO_SYSTEM_GO_NAME);
			gameObject.name = AudioManager.AUDIO_SYSTEM_GO_NAME;
			if (null != MonoSingleton<AppManager>.Instance)
			{
				gameObject.transform.parent = MonoSingleton<AppManager>.Instance.transform;
			}
			gameObject.hideFlags = HideFlags.DontSave;
			global::UnityEngine.Object.DontDestroyOnLoad(gameObject);
		}
		return gameObject;
	}

	// Token: 0x060006B3 RID: 1715 RVA: 0x00054980 File Offset: 0x00052B80
	private static void smethod_3()
	{
		DebugUtils.Log(LogCategory.Audio, "AudioManager.CreateAudioController()");
		GameObject gameObject = AudioManager.smethod_2();
		gameObject.AddComponent<AudioManager>();
	}

	// Token: 0x060006B4 RID: 1716 RVA: 0x00007819 File Offset: 0x00005A19
	private static void smethod_4()
	{
		ComponentMonoSingleton<AudioSystem>.Instance.method_2(MonoSingleton<AudioManager>.Instance.transform);
	}

	// Token: 0x060006B5 RID: 1717 RVA: 0x0000782F File Offset: 0x00005A2F
	protected override void Awake()
	{
		base.Awake();
		base.gameObject.hideFlags = HideFlags.DontSave;
		if (ComponentMonoSingleton<AudioSystem>.Boolean_0)
		{
			ComponentMonoSingleton<AudioSystem>.Instance.method_1(this);
		}
	}

	// Token: 0x060006B6 RID: 1718 RVA: 0x00007855 File Offset: 0x00005A55
	protected override void OnDestroy()
	{
		DebugUtils.Log(LogCategory.Audio, "AudioManager.OnDestroy");
		if (ComponentMonoSingleton<AudioSystem>.Boolean_0)
		{
			ComponentMonoSingleton<AudioSystem>.Instance.method_1(null);
		}
		base.OnDestroy();
	}

	// Token: 0x060006B7 RID: 1719 RVA: 0x0000787A File Offset: 0x00005A7A
	private void Update()
	{
		ComponentMonoSingleton<AudioSystem>.Instance.Update();
	}

	// Token: 0x060006B8 RID: 1720 RVA: 0x00007886 File Offset: 0x00005A86
	private void LateUpdate()
	{
		ComponentMonoSingleton<AudioSystem>.Instance.LateUpdate();
	}

	// Token: 0x060006B9 RID: 1721 RVA: 0x00007892 File Offset: 0x00005A92
	private void OnLevelWasLoaded(int iLevel)
	{
		ComponentMonoSingleton<AudioSystem>.Instance.imethod_3();
		ComponentMonoSingleton<AudioSystem>.Instance.imethod_2();
	}

	// Token: 0x060006BA RID: 1722 RVA: 0x000549A8 File Offset: 0x00052BA8
	public void method_0(string string_0)
	{
		if (ComponentMonoSingleton<AudioSystem>.Boolean_0 && !(null == MonoSingleton<Session>.Instance))
		{
			PlayerInfoSync localPlayer = MonoSingleton<Session>.Instance.GetLocalPlayer();
			if (!(null == localPlayer))
			{
				Entity entity = localPlayer.GetEntity();
				if (!(null == entity))
				{
					BaseEventTriggerCtl component = entity.gameObject.GetComponent<BaseEventTriggerCtl>();
					if (null == entity)
					{
						DebugUtils.LogWarning(LogCategory.Audio, "AudioManager.TriggerEventByNameOnLocalPlayer: local player entity doesn't contain a BaseEventTriggerCtl component");
					}
					else
					{
						component.TriggerEventByName(string_0);
					}
				}
			}
		}
	}

	// Token: 0x04000626 RID: 1574
	private static string AUDIO_SYSTEM_GO_NAME = "Audio Controller";
}
