using System;
using System.Collections.Generic;
using Core;
using ns0;
using UnityEngine;

// Token: 0x020000F7 RID: 247
[RequireComponent(typeof(AudioEventTriggerCtl))]
[ExecuteInEditMode]
public class TensityControlSystem : MonoBehaviour
{
	// Token: 0x060005D5 RID: 1493 RVA: 0x0000709A File Offset: 0x0000529A
	private void Awake()
	{
		if (ComponentMonoSingleton<AudioSystem>.Boolean_0)
		{
			ComponentMonoSingleton<AudioSystem>.Instance.Tensity = this;
		}
		this.m_eventCtl = base.GetComponent<AudioEventTriggerCtl>();
		if (this.m_eventCtl == null)
		{
			DebugUtils.LogError(LogCategory.Audio, "AudioEventTriggerCtl missing, impossible!");
		}
		this.method_0();
	}

	// Token: 0x060005D6 RID: 1494 RVA: 0x00051814 File Offset: 0x0004FA14
	private void method_0()
	{
		List<TensityState> list = new List<TensityState>();
		for (int i = 0; i < this.m_controllers.Length; i++)
		{
			if (list.Contains(this.m_controllers[i].m_state))
			{
				DebugUtils.LogWarning(LogCategory.Audio, "*****Same state group in tensity controllers!");
			}
			else
			{
				list.Add(this.m_controllers[i].m_state);
			}
		}
	}

	// Token: 0x060005D7 RID: 1495 RVA: 0x000070D9 File Offset: 0x000052D9
	private void OnDestroy()
	{
		DebugUtils.Log(LogCategory.Audio, "Tensity.OnDestroy");
		if (ComponentMonoSingleton<AudioSystem>.Boolean_0)
		{
			ComponentMonoSingleton<AudioSystem>.Instance.Tensity = null;
		}
	}

	// Token: 0x060005D8 RID: 1496 RVA: 0x000070F8 File Offset: 0x000052F8
	private void Update()
	{
		if (!ComponentMonoSingleton<AudioSystem>.Boolean_0)
		{
			return;
		}
		if (Time.time < this.m_nextTime)
		{
			return;
		}
		if (this.m_needUpdate && !(this.m_eventCtl == null))
		{
			this.method_1();
			return;
		}
	}

	// Token: 0x060005D9 RID: 1497 RVA: 0x00051870 File Offset: 0x0004FA70
	private void method_1()
	{
		for (int i = 0; i < this.m_controllers.Length; i++)
		{
			if (this.m_controllers[i].m_state == this.m_currentState)
			{
				TensityControlElement tensityControlElement = this.m_controllers[i];
				for (int j = 0; j < tensityControlElement.m_eventPackages.Length; j++)
				{
					if (tensityControlElement.m_eventPackages[j].m_targetState == this.m_targetState)
					{
						TensityStateChangeEventPackage tensityStateChangeEventPackage = tensityControlElement.m_eventPackages[j];
						if (this.m_currentMusicEvent != string.Empty)
						{
							this.m_eventCtl.ReleaseEventByName(this.m_currentMusicEvent);
						}
						for (int k = 0; k < this.m_controllers.Length; k++)
						{
							if (this.m_controllers[k].m_state == this.m_targetState)
							{
								this.m_currentMusicEvent = this.m_controllers[k].m_event;
								if (this.m_controllers[k].m_event != string.Empty)
								{
									this.m_eventCtl.TriggerEventByName(this.m_controllers[k].m_event);
								}
							}
						}
						this.m_currentState = this.m_targetState;
						this.m_nextTime = Time.time + tensityStateChangeEventPackage.m_lastingTime;
						this.m_needUpdate = false;
						this.method_3(tensityStateChangeEventPackage.m_autoTurnToState, false);
						return;
					}
				}
			}
		}
	}

	// Token: 0x060005DA RID: 1498 RVA: 0x0000712D File Offset: 0x0000532D
	public void method_2()
	{
		this.m_needUpdate = true;
	}

	// Token: 0x060005DB RID: 1499 RVA: 0x00007136 File Offset: 0x00005336
	public void method_3(TensityState tensityState_0, bool bool_0 = true)
	{
		if (tensityState_0 == this.m_currentState)
		{
			return;
		}
		if (bool_0)
		{
			this.m_nextTime = 0f;
		}
		this.m_targetState = tensityState_0;
		this.method_2();
	}

	// Token: 0x04000564 RID: 1380
	public TensityState m_currentState;

	// Token: 0x04000565 RID: 1381
	public TensityState m_targetState;

	// Token: 0x04000566 RID: 1382
	public TensityControlElement[] m_controllers;

	// Token: 0x04000567 RID: 1383
	private AudioEventTriggerCtl m_eventCtl;

	// Token: 0x04000568 RID: 1384
	private bool m_needUpdate;

	// Token: 0x04000569 RID: 1385
	private float m_nextTime;

	// Token: 0x0400056A RID: 1386
	private string m_currentMusicEvent = string.Empty;
}
