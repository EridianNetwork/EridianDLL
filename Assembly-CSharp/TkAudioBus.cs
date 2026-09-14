using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x0200011C RID: 284
[ExecuteInEditMode]
public class TkAudioBus : MonoBehaviour
{
	// Token: 0x06000654 RID: 1620 RVA: 0x00052D5C File Offset: 0x00050F5C
	public TkAudioBus method_0()
	{
		GameObject gameObject = new GameObject();
		gameObject.transform.parent = base.transform;
		TkAudioBus tkAudioBus = gameObject.AddComponent<TkAudioBus>();
		gameObject.name = "New Bus " + tkAudioBus.m_busId;
		return tkAudioBus;
	}

	// Token: 0x17000044 RID: 68
	// (get) Token: 0x06000655 RID: 1621 RVA: 0x00007528 File Offset: 0x00005728
	public TkAudioBus TkAudioBus_0
	{
		get
		{
			return (!base.transform.parent) ? null : base.transform.parent.GetComponent<TkAudioBus>();
		}
	}

	// Token: 0x06000656 RID: 1622 RVA: 0x00052DA4 File Offset: 0x00050FA4
	public static TkAudioBus smethod_0(int int_0)
	{
		TkAudioBus tkAudioBus_ = TkAudioSystem.TkAudioBus_0;
		return (!tkAudioBus_) ? null : tkAudioBus_.method_1(int_0);
	}

	// Token: 0x06000657 RID: 1623 RVA: 0x00052DCC File Offset: 0x00050FCC
	private TkAudioBus method_1(int int_0)
	{
		if (this.m_busId == int_0)
		{
			return this;
		}
		int childCount = base.transform.childCount;
		for (int i = 0; i < childCount; i++)
		{
			Transform child = base.transform.GetChild(i);
			TkAudioBus component = child.GetComponent<TkAudioBus>();
			if (component)
			{
				TkAudioBus tkAudioBus = component.method_1(int_0);
				if (tkAudioBus)
				{
					return tkAudioBus;
				}
			}
		}
		return null;
	}

	// Token: 0x06000658 RID: 1624 RVA: 0x00052E30 File Offset: 0x00051030
	private void Awake()
	{
		base.gameObject.hideFlags = HideFlags.DontSave;
		global::UnityEngine.Object.DontDestroyOnLoad(base.gameObject);
		if (this.m_busId == 0)
		{
			int num = 1000;
			TkAudioBus[] componentsInChildren = TkAudioSystem.TkAudioBus_0.GetComponentsInChildren<TkAudioBus>();
			for (int i = 0; i < componentsInChildren.Length; i++)
			{
				TkMath.smethod_15(ref num, componentsInChildren[i].m_busId);
			}
			this.m_busId = num + 1;
		}
	}

	// Token: 0x06000659 RID: 1625 RVA: 0x0000754F File Offset: 0x0000574F
	private void Start()
	{
		this.method_7();
	}

	// Token: 0x0600065A RID: 1626 RVA: 0x00052E94 File Offset: 0x00051094
	public void method_2(bool bool_0, bool bool_1)
	{
		if (this.m_playbackInstances != null)
		{
			for (int i = 0; i < this.m_playbackInstances.Count; i++)
			{
				TkAudioSource_PlaybackInstance tkAudioSource_PlaybackInstance = this.m_playbackInstances[i];
				if (tkAudioSource_PlaybackInstance != null)
				{
					tkAudioSource_PlaybackInstance.method_1(bool_1);
				}
			}
		}
		if (bool_0)
		{
			for (int j = 0; j < this.m_subBusList.Count; j++)
			{
				TkAudioBus tkAudioBus = this.m_subBusList[j];
				tkAudioBus.method_2(bool_0, bool_1);
			}
		}
	}

	// Token: 0x0600065B RID: 1627 RVA: 0x00007557 File Offset: 0x00005757
	public static int smethod_1(TkAudioBus tkAudioBus_0, TkAudioBus tkAudioBus_1)
	{
		return tkAudioBus_0._order - tkAudioBus_1._order;
	}

	// Token: 0x0600065C RID: 1628 RVA: 0x00052F0C File Offset: 0x0005110C
	public bool method_3(TkAudioSource_PlaybackInstance tkAudioSource_PlaybackInstance_0)
	{
		for (int i = this.m_playbackInstances.Count - 1; i >= 0; i--)
		{
			TkAudioSource_PlaybackInstance tkAudioSource_PlaybackInstance = this.m_playbackInstances[i];
			if (tkAudioSource_PlaybackInstance == null || tkAudioSource_PlaybackInstance.m_audioSource == null || tkAudioSource_PlaybackInstance.m_audioSource.clip == null)
			{
				this.m_playbackInstances.RemoveAt(i);
			}
		}
		if (this.m_limitAction != TkAudioBus.LimitAction.NoLimit && this.m_playbackInstances.Count + 1 > this.m_limitCount)
		{
			switch (this.m_limitAction)
			{
			case TkAudioBus.LimitAction.StopOldest:
			{
				for (int j = 0; j < this.m_playbackInstances.Count; j++)
				{
					TkAudioSource_PlaybackInstance tkAudioSource_PlaybackInstance2 = this.m_playbackInstances[j];
					if (tkAudioSource_PlaybackInstance2 && !tkAudioSource_PlaybackInstance2.Boolean_0)
					{
						tkAudioSource_PlaybackInstance2.method_1(true);
						break;
					}
				}
				break;
			}
			case TkAudioBus.LimitAction.StopLatest:
			{
				for (int k = this.m_playbackInstances.Count - 1; k >= 0; k++)
				{
					TkAudioSource_PlaybackInstance tkAudioSource_PlaybackInstance3 = this.m_playbackInstances[k];
					if (tkAudioSource_PlaybackInstance3 && !tkAudioSource_PlaybackInstance3.Boolean_0)
					{
						tkAudioSource_PlaybackInstance3.method_1(true);
						break;
					}
				}
				break;
			}
			case TkAudioBus.LimitAction.DiscardNew:
				return false;
			}
		}
		this.m_playbackInstances.Add(tkAudioSource_PlaybackInstance_0);
		return true;
	}

	// Token: 0x0600065D RID: 1629 RVA: 0x00007566 File Offset: 0x00005766
	public void method_4(TkAudioBus tkAudioBus_0, TkAudioBus tkAudioBus_1, float float_0)
	{
		this.method_5(tkAudioBus_0, tkAudioBus_1);
		this.method_8(float_0);
		this.method_6(float_0);
		this.method_9(float_0);
	}

	// Token: 0x0600065E RID: 1630 RVA: 0x00053050 File Offset: 0x00051250
	private void method_5(TkAudioBus tkAudioBus_0, TkAudioBus tkAudioBus_1)
	{
		this.m_computedVolume = this.m_volume;
		this.m_computedPitch = this.m_pitch;
		this.m_computedPan = this.m_pan;
		this.m_underSolo = this.m_solo;
		if (tkAudioBus_0)
		{
			this.m_computedVolume *= tkAudioBus_0.m_computedVolume;
			this.m_computedPitch *= tkAudioBus_0.m_computedPitch;
			this.m_computedPan += tkAudioBus_0.m_computedPan;
			if (tkAudioBus_0.m_underSolo)
			{
				this.m_underSolo = true;
			}
		}
		if (tkAudioBus_1 && tkAudioBus_1.m_overlayNextBus)
		{
			this.m_computedVolume *= tkAudioBus_1.m_overlayComputedVolume;
		}
		if (this.m_mute)
		{
			this.m_computedVolume = 0f;
		}
	}

	// Token: 0x0600065F RID: 1631 RVA: 0x00053114 File Offset: 0x00051314
	private void method_6(float float_0)
	{
		for (int i = this.m_playbackInstances.Count - 1; i >= 0; i--)
		{
			TkAudioSource_PlaybackInstance tkAudioSource_PlaybackInstance = this.m_playbackInstances[i];
			if (tkAudioSource_PlaybackInstance)
			{
				tkAudioSource_PlaybackInstance.method_9(float_0);
			}
			if (tkAudioSource_PlaybackInstance == null || tkAudioSource_PlaybackInstance.m_audioSource == null || tkAudioSource_PlaybackInstance.m_audioSource.clip == null)
			{
				this.m_playbackInstances.RemoveAt(i);
			}
		}
	}

	// Token: 0x06000660 RID: 1632 RVA: 0x0005318C File Offset: 0x0005138C
	public void method_7()
	{
		this.m_subBusList.Clear();
		for (int i = 0; i < base.transform.childCount; i++)
		{
			Transform child = base.transform.GetChild(i);
			TkAudioBus component = child.GetComponent<TkAudioBus>();
			if (component)
			{
				this.m_subBusList.Add(component);
			}
		}
		this.m_subBusList.Sort(new Comparison<TkAudioBus>(TkAudioBus.smethod_1));
	}

	// Token: 0x06000661 RID: 1633 RVA: 0x000531FC File Offset: 0x000513FC
	private void method_8(float float_0)
	{
		this.m_playbackCountInHierarchy = this.m_playbackInstances.Count;
		int num = 10;
		TkAudioBus tkAudioBus = null;
		for (int i = 0; i < this.m_subBusList.Count; i++)
		{
			TkAudioBus tkAudioBus2 = this.m_subBusList[i];
			tkAudioBus2._order = num;
			tkAudioBus2.method_4(this, tkAudioBus, float_0);
			this.m_playbackCountInHierarchy += tkAudioBus2.m_playbackCountInHierarchy;
			tkAudioBus = tkAudioBus2;
			num += 10;
		}
		if (TkAudioSystem.TkAudioSystem_0.m_soloCount > 0 && !this.m_underSolo)
		{
			this.m_computedVolume = 0f;
		}
	}

	// Token: 0x06000662 RID: 1634 RVA: 0x0005328C File Offset: 0x0005148C
	private void method_9(float float_0)
	{
		if (this.m_overlayNextBus)
		{
			float num = 1f;
			if (this.m_playbackCountInHierarchy > 0)
			{
				if (this.m_overlayFadeInDuration > 0f)
				{
					num = float_0 / this.m_overlayFadeInDuration;
				}
				this.m_overlayCurrentFade += num;
			}
			else
			{
				if (this.m_overlayFadeOutDuration > 0f)
				{
					num = float_0 / this.m_overlayFadeOutDuration;
				}
				this.m_overlayCurrentFade -= num;
			}
			this.m_overlayCurrentFade = Mathf.Clamp01(this.m_overlayCurrentFade);
			float num2 = this.m_overlayCurrentFade;
			if (this.m_overlayFadeCurve != null)
			{
				num2 = this.m_overlayFadeCurve.Evaluate(num2);
			}
			this.m_overlayComputedVolume = Mathf.Lerp(1f, this.m_overlayVolume, num2);
		}
	}

	// Token: 0x06000663 RID: 1635 RVA: 0x00053344 File Offset: 0x00051544
	public List<TkAudioSource_PlaybackInstance> method_10(bool bool_0 = true)
	{
		List<TkAudioSource_PlaybackInstance> list = new List<TkAudioSource_PlaybackInstance>();
		this.method_11(list, bool_0);
		return list;
	}

	// Token: 0x06000664 RID: 1636 RVA: 0x00053360 File Offset: 0x00051560
	public void method_11(List<TkAudioSource_PlaybackInstance> list_0, bool bool_0 = true)
	{
		for (int i = 0; i < this.m_playbackInstances.Count; i++)
		{
			list_0.Add(this.m_playbackInstances[i]);
		}
		if (bool_0)
		{
			for (int j = 0; j < this.m_subBusList.Count; j++)
			{
				this.m_subBusList[j].method_11(list_0, bool_0);
			}
		}
	}

	// Token: 0x040005BE RID: 1470
	[TkInspectorLabelField]
	public int m_busId;

	// Token: 0x040005BF RID: 1471
	[TkInspectorLabelField]
	public int _order;

	// Token: 0x040005C0 RID: 1472
	[NonSerialized]
	public bool m_solo;

	// Token: 0x040005C1 RID: 1473
	[NonSerialized]
	public bool m_mute;

	// Token: 0x040005C2 RID: 1474
	[NonSerialized]
	public bool m_underSolo;

	// Token: 0x040005C3 RID: 1475
	[TkInspectorSlider(0f, 1f)]
	public float m_volume = 1f;

	// Token: 0x040005C4 RID: 1476
	[NonSerialized]
	public float m_computedVolume = 1f;

	// Token: 0x040005C5 RID: 1477
	[TkInspectorSlider(0f, 1f)]
	public float m_pitch = 1f;

	// Token: 0x040005C6 RID: 1478
	[NonSerialized]
	public float m_computedPitch = 1f;

	// Token: 0x040005C7 RID: 1479
	[TkInspectorSlider(-1f, 1f)]
	public float m_pan;

	// Token: 0x040005C8 RID: 1480
	[NonSerialized]
	public float m_computedPan;

	// Token: 0x040005C9 RID: 1481
	public float m_stopFadeDuration = 0.5f;

	// Token: 0x040005CA RID: 1482
	public AnimationCurve m_stopFadeCurve = AnimationCurve.EaseInOut(0f, 0f, 1f, 1f);

	// Token: 0x040005CB RID: 1483
	public TkAudioBus.LimitAction m_limitAction;

	// Token: 0x040005CC RID: 1484
	public int m_limitCount = 10;

	// Token: 0x040005CD RID: 1485
	[NonSerialized]
	public int m_playbackCountInHierarchy;

	// Token: 0x040005CE RID: 1486
	public bool m_overlayNextBus;

	// Token: 0x040005CF RID: 1487
	[TkInspectorSlider(0f, 1f)]
	public float m_overlayVolume = 0.25f;

	// Token: 0x040005D0 RID: 1488
	public float m_overlayFadeInDuration;

	// Token: 0x040005D1 RID: 1489
	public float m_overlayFadeOutDuration;

	// Token: 0x040005D2 RID: 1490
	public AnimationCurve m_overlayFadeCurve = AnimationCurve.EaseInOut(0f, 0f, 1f, 1f);

	// Token: 0x040005D3 RID: 1491
	[NonSerialized]
	public float m_overlayCurrentFade;

	// Token: 0x040005D4 RID: 1492
	[NonSerialized]
	public float m_overlayComputedVolume = 1f;

	// Token: 0x040005D5 RID: 1493
	[NonSerialized]
	public List<TkAudioBus> m_subBusList = new List<TkAudioBus>();

	// Token: 0x040005D6 RID: 1494
	[NonSerialized]
	public List<TkAudioSource_PlaybackInstance> m_playbackInstances = new List<TkAudioSource_PlaybackInstance>();

	// Token: 0x0200011D RID: 285
	public enum LimitAction
	{
		// Token: 0x040005D8 RID: 1496
		NoLimit,
		// Token: 0x040005D9 RID: 1497
		StopOldest,
		// Token: 0x040005DA RID: 1498
		StopLatest,
		// Token: 0x040005DB RID: 1499
		DiscardNew
	}
}
