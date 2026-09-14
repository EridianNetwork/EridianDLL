using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Core;
using ns0;
using UnityEngine;

// Token: 0x02000B5A RID: 2906
public class TkAnimEventAction : MonoBehaviour
{
	// Token: 0x17000801 RID: 2049
	// (get) Token: 0x06004ED6 RID: 20182 RVA: 0x00033669 File Offset: 0x00031869
	public int Int32_0
	{
		get
		{
			return (!this.prefab) ? base.GetInstanceID() : this.prefab.GetInstanceID();
		}
	}

	// Token: 0x06004ED7 RID: 20183 RVA: 0x0014F378 File Offset: 0x0014D578
	public static TkAnimEventAction smethod_0(string string_0, GameObject gameObject_0, string string_1 = null, bool bool_0 = false)
	{
		if (string_0 == null)
		{
			return null;
		}
		GameObject gameObject = Tk.smethod_15(string_0);
		if (!gameObject)
		{
			return null;
		}
		TkAnimEventAction component = gameObject.GetComponent<TkAnimEventAction>();
		if (!component)
		{
			DebugUtils.LogWarning(LogCategory.AnimEvent, "TkAnimEventAction is missing in " + string_0);
			return null;
		}
		return component.method_0(gameObject_0, string_1, bool_0);
	}

	// Token: 0x06004ED8 RID: 20184 RVA: 0x000039EC File Offset: 0x00001BEC
	public virtual bool OnPreTrigger(GameObject host, double currentTime)
	{
		return true;
	}

	// Token: 0x06004ED9 RID: 20185 RVA: 0x0000311B File Offset: 0x0000131B
	public virtual void OnPostTrigger(GameObject host, GameObject eventAction)
	{
	}

	// Token: 0x06004EDA RID: 20186 RVA: 0x0000311B File Offset: 0x0000131B
	public virtual void vmethod_0(double double_0)
	{
	}

	// Token: 0x06004EDB RID: 20187 RVA: 0x0014F3C8 File Offset: 0x0014D5C8
	public TkAnimEventAction method_0(GameObject gameObject_0, string string_0 = null, bool bool_0 = false)
	{
		double dspTime = AudioSettings.dspTime;
		this.vmethod_0(dspTime);
		if (!TkAnimEventAction.globalLimitRuntime.method_1(this, this.globalLimit, gameObject_0, dspTime))
		{
			return null;
		}
		if (!this.OnPreTrigger(gameObject_0, dspTime))
		{
			return null;
		}
		TkAnimEventActionLimitHelper tkAnimEventActionLimitHelper = null;
		if (gameObject_0 && (this.perObjectLimit.action != TkAnimEventAction.Limit.Action.NoLimit || this.perObjectLimit.minInterval > 0f))
		{
			tkAnimEventActionLimitHelper = Tk.smethod_48<TkAnimEventActionLimitHelper>(gameObject_0);
			if (!tkAnimEventActionLimitHelper.runtime.method_1(this, this.perObjectLimit, gameObject_0, dspTime))
			{
				return null;
			}
		}
		GameObject gameObject = ComponentMonoSingleton<AudioSystem>.Instance.AudioResourceManager_0.m_poolManager.method_3(base.name, gameObject_0);
		if (gameObject == null)
		{
			DebugUtils.LogWarning(LogCategory.AnimEvent, "TkAnimEventAction.Trigger[" + Utils.smethod_16(base.gameObject) + "]: Instantiate failed");
			return null;
		}
		gameObject.name = base.name;
		if (gameObject_0)
		{
			gameObject.transform.parent = gameObject_0.transform;
		}
		TkAnimEventAction component = gameObject.GetComponent<TkAnimEventAction>();
		if (!component)
		{
			ComponentMonoSingleton<AudioSystem>.Instance.AudioResourceManager_0.m_poolManager.method_4(gameObject);
			return null;
		}
		component.prefab = this;
		component.previewInEditor = bool_0;
		component.autoDestroy = true;
		component.host = gameObject_0;
		component.locatorName = ((string_0 != null) ? string_0 : string.Empty);
		TkAnimEventAction.globalLimitRuntime.method_2(component, component.globalLimit, dspTime);
		if (tkAnimEventActionLimitHelper)
		{
			tkAnimEventActionLimitHelper.runtime.method_2(component, component.perObjectLimit, dspTime);
		}
		if (gameObject_0)
		{
			TkRTPC_OutputComponent component2 = gameObject.GetComponent<TkRTPC_OutputComponent>();
			if (component2)
			{
				component2.m_host = gameObject_0;
			}
		}
		component.method_1(this);
		this.OnPostTrigger(gameObject_0, gameObject);
		return component;
	}

	// Token: 0x06004EDC RID: 20188 RVA: 0x0014F56C File Offset: 0x0014D76C
	public void method_1(TkAnimEventAction tkAnimEventAction_0)
	{
		this.positioning.method_0(base.gameObject, this.host, this.locatorName);
		this.OnCreate(tkAnimEventAction_0);
		if (!this.OnAnimEvent())
		{
			string text = ((!(this.prefab == null)) ? this.prefab.name : string.Empty);
			DebugUtils.LogWarning(LogCategory.AnimEvent, "Warning: create AnimEvent Action " + text);
			ComponentMonoSingleton<AudioSystem>.Instance.AudioResourceManager_0.m_poolManager.method_4(base.gameObject);
		}
	}

	// Token: 0x06004EDD RID: 20189 RVA: 0x0000311B File Offset: 0x0000131B
	public virtual void OnCreate(TkAnimEventAction template)
	{
	}

	// Token: 0x06004EDE RID: 20190 RVA: 0x0000311D File Offset: 0x0000131D
	public virtual bool OnAnimEvent()
	{
		return false;
	}

	// Token: 0x04003B2C RID: 15148
	public TkAnimEventAction.Positioning positioning = new TkAnimEventAction.Positioning();

	// Token: 0x04003B2D RID: 15149
	public TkAnimEventAction.Limit globalLimit = new TkAnimEventAction.Limit();

	// Token: 0x04003B2E RID: 15150
	public TkAnimEventAction.Limit perObjectLimit = new TkAnimEventAction.Limit();

	// Token: 0x04003B2F RID: 15151
	private static TkAnimEventAction.LimitRuntime globalLimitRuntime = new TkAnimEventAction.LimitRuntime();

	// Token: 0x04003B30 RID: 15152
	[NonSerialized]
	public bool autoDestroy;

	// Token: 0x04003B31 RID: 15153
	[NonSerialized]
	public bool previewInEditor;

	// Token: 0x04003B32 RID: 15154
	[NonSerialized]
	public TkAnimEventAction prefab;

	// Token: 0x04003B33 RID: 15155
	[NonSerialized]
	public GameObject host;

	// Token: 0x04003B34 RID: 15156
	[NonSerialized]
	public string locatorName;

	// Token: 0x02000B5B RID: 2907
	public class LimitRuntime
	{
		// Token: 0x06004EE0 RID: 20192 RVA: 0x0014F5F4 File Offset: 0x0014D7F4
		public TkAnimEventAction.LimitRuntime.Entry method_0(int int_0)
		{
			TkAnimEventAction.LimitRuntime.Entry entry = null;
			if (!this.objDict.TryGetValue(int_0, out entry))
			{
				entry = new TkAnimEventAction.LimitRuntime.Entry();
				this.objDict.Add(int_0, entry);
			}
			return entry;
		}

		// Token: 0x06004EE1 RID: 20193 RVA: 0x0014F628 File Offset: 0x0014D828
		public bool method_1(TkAnimEventAction tkAnimEventAction_0, TkAnimEventAction.Limit limit_0, GameObject gameObject_0, double double_0)
		{
			if (limit_0.action == TkAnimEventAction.Limit.Action.NoLimit && limit_0.minInterval <= 0f)
			{
				return true;
			}
			TkAnimEventAction.LimitRuntime.Entry entry = this.method_0(tkAnimEventAction_0.Int32_0);
			if (limit_0.minInterval > 0f)
			{
				double num = double_0 - entry.lastTriggerTime;
				if (num < (double)limit_0.minInterval)
				{
					return false;
				}
			}
			entry.instList.RemoveAll(new Predicate<TkAnimEventAction>(TkAnimEventAction.LimitRuntime.smethod_0));
			entry.instList.RemoveAll(new Predicate<TkAnimEventAction>(TkAnimEventAction.LimitRuntime.smethod_1));
			if (entry.instList.Count > 0 && entry.instList.Count + 1 > limit_0.count)
			{
				switch (limit_0.action)
				{
				case TkAnimEventAction.Limit.Action.DiscardNew:
					return false;
				case TkAnimEventAction.Limit.Action.StopOldest:
					ComponentMonoSingleton<AudioSystem>.Instance.AudioResourceManager_0.m_poolManager.method_4(entry.instList[0].gameObject);
					return true;
				case TkAnimEventAction.Limit.Action.StopLatest:
					ComponentMonoSingleton<AudioSystem>.Instance.AudioResourceManager_0.m_poolManager.method_4(entry.instList[entry.instList.Count - 1].gameObject);
					return true;
				case TkAnimEventAction.Limit.Action.StopFarthest:
				{
					AudioListener audioListener_ = TkAudioSystem.AudioListener_0;
					if (!audioListener_ || !gameObject_0)
					{
						ComponentMonoSingleton<AudioSystem>.Instance.AudioResourceManager_0.m_poolManager.method_4(entry.instList[0].gameObject);
						return true;
					}
					Vector3 position = audioListener_.transform.position;
					TkAnimEventAction tkAnimEventAction = null;
					float num2 = (gameObject_0.transform.position - position).sqrMagnitude;
					for (int i = 0; i < entry.instList.Count; i++)
					{
						TkAnimEventAction tkAnimEventAction2 = entry.instList[i];
						float sqrMagnitude = (tkAnimEventAction2.transform.position - position).sqrMagnitude;
						if (sqrMagnitude >= num2)
						{
							tkAnimEventAction = tkAnimEventAction2;
							num2 = sqrMagnitude;
						}
					}
					if (!tkAnimEventAction)
					{
						return false;
					}
					ComponentMonoSingleton<AudioSystem>.Instance.AudioResourceManager_0.m_poolManager.method_4(tkAnimEventAction.gameObject);
					break;
				}
				case TkAnimEventAction.Limit.Action.StopClosest:
				{
					AudioListener audioListener_2 = TkAudioSystem.AudioListener_0;
					if (!audioListener_2 || !gameObject_0)
					{
						ComponentMonoSingleton<AudioSystem>.Instance.AudioResourceManager_0.m_poolManager.method_4(entry.instList[0].gameObject);
						return true;
					}
					Vector3 position2 = audioListener_2.transform.position;
					TkAnimEventAction tkAnimEventAction3 = null;
					float num3 = (gameObject_0.transform.position - position2).sqrMagnitude;
					for (int j = 0; j < entry.instList.Count; j++)
					{
						TkAnimEventAction tkAnimEventAction4 = entry.instList[j];
						float sqrMagnitude2 = (tkAnimEventAction4.transform.position - position2).sqrMagnitude;
						if (sqrMagnitude2 <= num3)
						{
							tkAnimEventAction3 = tkAnimEventAction4;
							num3 = sqrMagnitude2;
						}
					}
					if (!tkAnimEventAction3)
					{
						return false;
					}
					ComponentMonoSingleton<AudioSystem>.Instance.AudioResourceManager_0.m_poolManager.method_4(tkAnimEventAction3.gameObject);
					break;
				}
				}
			}
			return true;
		}

		// Token: 0x06004EE2 RID: 20194 RVA: 0x0014F95C File Offset: 0x0014DB5C
		public void method_2(TkAnimEventAction tkAnimEventAction_0, TkAnimEventAction.Limit limit_0, double double_0)
		{
			if (limit_0.action == TkAnimEventAction.Limit.Action.NoLimit && limit_0.minInterval <= 0f)
			{
				return;
			}
			TkAnimEventAction.LimitRuntime.Entry entry = this.method_0(tkAnimEventAction_0.Int32_0);
			entry.instList.Add(tkAnimEventAction_0);
			entry.lastTriggerTime = double_0;
		}

		// Token: 0x06004EE3 RID: 20195 RVA: 0x00006CC7 File Offset: 0x00004EC7
		[CompilerGenerated]
		private static bool smethod_0(TkAnimEventAction tkAnimEventAction_0)
		{
			return tkAnimEventAction_0 == null;
		}

		// Token: 0x06004EE4 RID: 20196 RVA: 0x0003369E File Offset: 0x0003189E
		[CompilerGenerated]
		private static bool smethod_1(TkAnimEventAction tkAnimEventAction_0)
		{
			return string.IsNullOrEmpty(tkAnimEventAction_0.gameObject.name);
		}

		// Token: 0x04003B35 RID: 15157
		private Dictionary<int, TkAnimEventAction.LimitRuntime.Entry> objDict = new Dictionary<int, TkAnimEventAction.LimitRuntime.Entry>();

		// Token: 0x02000B5C RID: 2908
		public class Entry
		{
			// Token: 0x04003B38 RID: 15160
			public List<TkAnimEventAction> instList = new List<TkAnimEventAction>();

			// Token: 0x04003B39 RID: 15161
			public double lastTriggerTime;
		}
	}

	// Token: 0x02000B5D RID: 2909
	[Serializable]
	public class Limit
	{
		// Token: 0x04003B3A RID: 15162
		public TkAnimEventAction.Limit.Action action;

		// Token: 0x04003B3B RID: 15163
		public int count = 1;

		// Token: 0x04003B3C RID: 15164
		public float minInterval;

		// Token: 0x02000B5E RID: 2910
		public enum Action
		{
			// Token: 0x04003B3E RID: 15166
			NoLimit,
			// Token: 0x04003B3F RID: 15167
			DiscardNew,
			// Token: 0x04003B40 RID: 15168
			StopOldest,
			// Token: 0x04003B41 RID: 15169
			StopLatest,
			// Token: 0x04003B42 RID: 15170
			StopFarthest,
			// Token: 0x04003B43 RID: 15171
			StopClosest
		}
	}

	// Token: 0x02000B5F RID: 2911
	[Serializable]
	public class Positioning
	{
		// Token: 0x06004EE8 RID: 20200 RVA: 0x0014F9A0 File Offset: 0x0014DBA0
		public void method_0(GameObject gameObject_0, GameObject gameObject_1, string string_0)
		{
			Transform transform = gameObject_0.transform;
			Transform transform2 = null;
			if (gameObject_1 && !string.IsNullOrEmpty(string_0))
			{
				GameObject gameObject = Tk.smethod_33(gameObject_1, string_0, true, true);
				if (!gameObject)
				{
					DebugUtils.LogWarning(LogCategory.AnimEvent, "AnimEvent Cannot find locator " + string_0 + " in GameObject " + Tk.smethod_27(gameObject_1));
				}
				else
				{
					transform2 = gameObject.transform;
				}
			}
			switch (this.parent)
			{
			case TkAnimEventAction.Positioning.Space.LocatorSpace:
				if (transform2)
				{
					transform.parent = transform2;
				}
				else if (gameObject_1)
				{
					transform.parent = gameObject_1.transform;
				}
				break;
			case TkAnimEventAction.Positioning.Space.ObjectSpace:
				if (gameObject_1)
				{
					transform.parent = gameObject_1.transform;
				}
				break;
			case TkAnimEventAction.Positioning.Space.WorldSpace:
				transform.parent = null;
				break;
			}
			switch (this.startPosition)
			{
			case TkAnimEventAction.Positioning.Space.LocatorSpace:
				if (transform2)
				{
					transform.position = transform2.position;
				}
				else if (gameObject_1)
				{
					transform.position = gameObject_1.transform.position;
				}
				break;
			case TkAnimEventAction.Positioning.Space.ObjectSpace:
				if (gameObject_1)
				{
					transform.position = gameObject_1.transform.position;
				}
				break;
			}
			switch (this.startRotation)
			{
			case TkAnimEventAction.Positioning.Space.LocatorSpace:
				if (transform2)
				{
					transform.rotation = transform2.rotation;
				}
				else if (gameObject_1)
				{
					transform.rotation = gameObject_1.transform.rotation;
				}
				break;
			case TkAnimEventAction.Positioning.Space.ObjectSpace:
				if (gameObject_1)
				{
					transform.rotation = gameObject_1.transform.rotation;
				}
				break;
			}
		}

		// Token: 0x04003B44 RID: 15172
		[HideInInspector]
		public string locatorName = string.Empty;

		// Token: 0x04003B45 RID: 15173
		public TkAnimEventAction.Positioning.Space parent;

		// Token: 0x04003B46 RID: 15174
		public TkAnimEventAction.Positioning.Space startPosition;

		// Token: 0x04003B47 RID: 15175
		public TkAnimEventAction.Positioning.Space startRotation;

		// Token: 0x02000B60 RID: 2912
		public enum Space
		{
			// Token: 0x04003B49 RID: 15177
			LocatorSpace,
			// Token: 0x04003B4A RID: 15178
			ObjectSpace,
			// Token: 0x04003B4B RID: 15179
			WorldSpace
		}
	}
}
