using System;
using Core;
using ns0;
using UnityEngine;

// Token: 0x02000125 RID: 293
[ExecuteInEditMode]
public class TkAudioSystem : MonoBehaviour
{
	// Token: 0x17000048 RID: 72
	// (get) Token: 0x06000696 RID: 1686 RVA: 0x0000777F File Offset: 0x0000597F
	public static bool Boolean_0
	{
		get
		{
			return TkAudioSystem.s_instance != null;
		}
	}

	// Token: 0x17000049 RID: 73
	// (get) Token: 0x06000697 RID: 1687 RVA: 0x000543E8 File Offset: 0x000525E8
	public static TkAudioSystem TkAudioSystem_0
	{
		get
		{
			if (!TkAudioSystem.s_instance)
			{
				DebugUtils.Log(LogCategory.Audio, "Instantiating TkAudioSystem");
				GameObject gameObject = GameObject.Find("TkAudioSystem");
				if (!gameObject)
				{
					gameObject = Tk.smethod_13("Audio/TkAudioSystem");
				}
				if (!gameObject)
				{
					gameObject = new GameObject();
				}
				gameObject.name = "TkAudioSystem";
				gameObject.hideFlags = HideFlags.DontSave;
				global::UnityEngine.Object.DontDestroyOnLoad(gameObject);
				if (MonoSingleton<AudioManager>.Boolean_0)
				{
					gameObject.transform.parent = MonoSingleton<AudioManager>.Instance.gameObject.transform;
				}
				TkAudioSystem.s_instance = Tk.smethod_48<TkAudioSystem>(gameObject);
			}
			return TkAudioSystem.s_instance;
		}
	}

	// Token: 0x1700004A RID: 74
	// (get) Token: 0x06000698 RID: 1688 RVA: 0x0000778C File Offset: 0x0000598C
	public static TkAudioBus TkAudioBus_0
	{
		get
		{
			return TkAudioSystem.TkAudioSystem_0.method_0();
		}
	}

	// Token: 0x06000699 RID: 1689 RVA: 0x00054484 File Offset: 0x00052684
	private TkAudioBus method_0()
	{
		if (!this.m_masterBus)
		{
			GameObject gameObject = Tk.smethod_33(base.gameObject, "MasterBus", true, true);
			if (!gameObject)
			{
				gameObject = new GameObject("MasterBus");
				gameObject.transform.parent = base.transform;
			}
			this.m_masterBus = Tk.smethod_48<TkAudioBus>(gameObject);
		}
		return this.m_masterBus;
	}

	// Token: 0x0600069A RID: 1690 RVA: 0x0000311B File Offset: 0x0000131B
	public static void smethod_0(string string_0)
	{
	}

	// Token: 0x1700004B RID: 75
	// (get) Token: 0x0600069B RID: 1691 RVA: 0x00007798 File Offset: 0x00005998
	public static AudioListener AudioListener_0
	{
		get
		{
			return TkAudioSystem.TkAudioSystem_0.m_audioListener;
		}
	}

	// Token: 0x0600069C RID: 1692 RVA: 0x000544E8 File Offset: 0x000526E8
	private void method_1()
	{
		GameObject gameObject = new GameObject("AUDIO_LISTENER");
		this.m_audioListener = gameObject.AddComponent<AudioListener>();
		global::UnityEngine.Object.DontDestroyOnLoad(gameObject);
	}

	// Token: 0x0600069D RID: 1693 RVA: 0x00054514 File Offset: 0x00052714
	public void method_2(Transform transform_0)
	{
		if (this.m_audioListener == null)
		{
			this.method_1();
		}
		if (this.m_audioListener)
		{
			this.m_audioListener.transform.parent = transform_0;
			this.m_audioListener.transform.localPosition = Vector3.zero;
			this.m_audioListener.transform.localRotation = Quaternion.identity;
			DebugUtils.Log(LogCategory.Audio, "Now audio listener is put on " + transform_0.name);
		}
		else
		{
			DebugUtils.LogError(LogCategory.Audio, "where is my audio listener?");
		}
	}

	// Token: 0x0600069E RID: 1694 RVA: 0x000545A0 File Offset: 0x000527A0
	public static TkAudioSource_PlaybackInstance smethod_1(string string_0)
	{
		GameObject gameObject = Tk.smethod_15(string_0);
		if (!gameObject)
		{
			return null;
		}
		TkAudioSource component = gameObject.GetComponent<TkAudioSource>();
		if (!component)
		{
			return null;
		}
		return component.method_11(1f);
	}

	// Token: 0x0600069F RID: 1695 RVA: 0x000545DC File Offset: 0x000527DC
	public static TkAudioSource_PlaybackInstance smethod_2(GameObject gameObject_0, string string_0)
	{
		if (!gameObject_0)
		{
			DebugUtils.LogWarning(LogCategory.Audio, "PlayResource obj is null");
			return TkAudioSystem.smethod_1(string_0);
		}
		GameObject gameObject = Tk.smethod_15(string_0);
		if (!gameObject)
		{
			return null;
		}
		TkAudioSource component = gameObject.GetComponent<TkAudioSource>();
		if (!component)
		{
			return null;
		}
		TkAudioSource tkAudioSource = component.method_0(gameObject_0, null, false) as TkAudioSource;
		return (!tkAudioSource) ? null : tkAudioSource.m_playbackInstance;
	}

	// Token: 0x060006A0 RID: 1696 RVA: 0x000077A4 File Offset: 0x000059A4
	public static void smethod_3(bool bool_0 = true)
	{
		if (!TkAudioSystem.s_instance)
		{
			return;
		}
		TkAudioSystem.TkAudioBus_0.method_2(true, bool_0);
	}

	// Token: 0x060006A1 RID: 1697 RVA: 0x00054648 File Offset: 0x00052848
	public static void smethod_4(string string_0, bool bool_0 = true)
	{
		TkAudioBus tkAudioBus = TkAudioSystem.smethod_6(string_0);
		if (tkAudioBus)
		{
			tkAudioBus.method_2(true, bool_0);
		}
	}

	// Token: 0x060006A2 RID: 1698 RVA: 0x0005466C File Offset: 0x0005286C
	public static void smethod_5(string string_0, bool bool_0)
	{
		TkAudioBus tkAudioBus = TkAudioSystem.smethod_6(string_0);
		if (tkAudioBus)
		{
			tkAudioBus.m_mute = bool_0;
		}
	}

	// Token: 0x060006A3 RID: 1699 RVA: 0x00054690 File Offset: 0x00052890
	public static TkAudioBus smethod_6(string string_0)
	{
		GameObject gameObject = Tk.smethod_33(TkAudioSystem.TkAudioBus_0.gameObject, string_0, true, true);
		if (!gameObject)
		{
			return null;
		}
		return gameObject.GetComponent<TkAudioBus>();
	}

	// Token: 0x060006A4 RID: 1700 RVA: 0x000546C0 File Offset: 0x000528C0
	private void Awake()
	{
		TkAudioSystem.s_instance = this;
		int num;
		int num2;
		AudioSettings.GetDSPBufferSize(out num, out num2);
		DebugUtils.Log(LogCategory.Audio, string.Concat(new object[]
		{
			"TkAudioSystem.Awake() SampleRate=",
			AudioSettings.outputSampleRate,
			" Buffer=",
			num,
			"x",
			num2
		}));
		global::UnityEngine.Object.DontDestroyOnLoad(base.gameObject);
		base.gameObject.hideFlags = HideFlags.DontSave;
		this.m_currentTime = AudioSettings.dspTime;
		this.m_lastUpdate = this.m_currentTime;
	}

	// Token: 0x060006A5 RID: 1701 RVA: 0x000077BF File Offset: 0x000059BF
	private void OnEnable()
	{
		TkAudioSystem.smethod_3(false);
	}

	// Token: 0x060006A6 RID: 1702 RVA: 0x0000311B File Offset: 0x0000131B
	private void OnDisable()
	{
	}

	// Token: 0x1700004C RID: 76
	// (get) Token: 0x060006A7 RID: 1703 RVA: 0x00054754 File Offset: 0x00052954
	public GameObject GameObject_0
	{
		get
		{
			if (!this._PlaybackInstanceGroup)
			{
				GameObject gameObject = Tk.smethod_33(base.gameObject, "__PlaybackInstanceGroup__", true, true);
				if (!gameObject)
				{
					gameObject = new GameObject("__PlaybackInstanceGroup__");
					gameObject.transform.parent = base.transform;
				}
				gameObject.hideFlags = HideFlags.DontSave;
				global::UnityEngine.Object.DontDestroyOnLoad(gameObject);
				this._PlaybackInstanceGroup = gameObject;
			}
			return this._PlaybackInstanceGroup;
		}
	}

	// Token: 0x060006A8 RID: 1704 RVA: 0x000547C0 File Offset: 0x000529C0
	public void method_3()
	{
		this.m_lastUpdate = this.m_currentTime;
		this.m_currentTime = AudioSettings.dspTime;
		float num = (float)(this.m_currentTime - this.m_lastUpdate);
		TkAudioSystem.TkAudioBus_0.method_4(null, null, num);
	}

	// Token: 0x060006A9 RID: 1705 RVA: 0x00054800 File Offset: 0x00052A00
	public void method_4()
	{
		this.m_soloCount = 0;
		if (this.m_masterBus == null)
		{
			return;
		}
		if (this.m_masterBus.m_solo)
		{
			this.m_soloCount++;
		}
		foreach (TkAudioBus tkAudioBus in this.m_masterBus.GetComponentsInChildren<TkAudioBus>())
		{
			if (tkAudioBus.m_solo)
			{
				this.m_soloCount++;
			}
		}
	}

	// Token: 0x060006AA RID: 1706 RVA: 0x00054874 File Offset: 0x00052A74
	public void method_5()
	{
		if (this.m_masterBus == null)
		{
			return;
		}
		TkAudioBus[] componentsInChildren = this.m_masterBus.GetComponentsInChildren<TkAudioBus>();
		this.m_masterBus.m_solo = false;
		foreach (TkAudioBus tkAudioBus in componentsInChildren)
		{
			tkAudioBus.m_solo = false;
		}
	}

	// Token: 0x060006AB RID: 1707 RVA: 0x000077C7 File Offset: 0x000059C7
	public static void smethod_7(GameObject gameObject_0)
	{
		global::UnityEngine.Object.Destroy(gameObject_0);
	}

	// Token: 0x04000619 RID: 1561
	private const string GAME_OBJECT_NAME = "TkAudioSystem";

	// Token: 0x0400061A RID: 1562
	public const string PlaybackInstanceGroupName = "__PlaybackInstanceGroup__";

	// Token: 0x0400061B RID: 1563
	[NonSerialized]
	public int m_soloCount;

	// Token: 0x0400061C RID: 1564
	[NonSerialized]
	public double m_lastUpdate;

	// Token: 0x0400061D RID: 1565
	[NonSerialized]
	public double m_currentTime;

	// Token: 0x0400061E RID: 1566
	public static TkSwitch.SolveDelegate s_onSwitch;

	// Token: 0x0400061F RID: 1567
	public static bool m_enableAssetbundle;

	// Token: 0x04000620 RID: 1568
	private AudioListener m_audioListener;

	// Token: 0x04000621 RID: 1569
	private TkAudioBus m_masterBus;

	// Token: 0x04000622 RID: 1570
	private static TkAudioSystem s_instance;

	// Token: 0x04000623 RID: 1571
	private GameObject _PlaybackInstanceGroup;
}
