using System;
using System.Collections;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using ns0;
using UnityEngine;

// Token: 0x020002B3 RID: 691
internal class TaskManager : MonoSingleton<TaskManager>
{
	// Token: 0x06000EE2 RID: 3810 RVA: 0x00074168 File Offset: 0x00072368
	public static TaskManager.TaskState smethod_0(IEnumerator ienumerator_0)
	{
		if (!MonoSingleton<TaskManager>.Boolean_0)
		{
			GameObject gameObject = new GameObject("TaskManager");
			global::UnityEngine.Object.DontDestroyOnLoad(gameObject);
			gameObject.AddComponent<TaskManager>();
		}
		return new TaskManager.TaskState(ienumerator_0);
	}

	// Token: 0x020002B4 RID: 692
	public class TaskState
	{
		public delegate void FinishedHandler(bool manual);

		private IEnumerator m_coroutine;

		private bool m_running;

		private bool m_paused;

		private bool m_stopped;

		private FinishedHandler Finished;

		public bool Boolean_0 => m_running;

		public bool Boolean_1 => m_paused;

		public event FinishedHandler Event_0
		{
			[MethodImpl(MethodImplOptions.Synchronized)]
			add
			{
				Finished = (FinishedHandler)Delegate.Combine(Finished, value);
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			remove
			{
				Finished = (FinishedHandler)Delegate.Remove(Finished, value);
			}
		}

		public TaskState(IEnumerator ienumerator_0)
		{
			m_coroutine = ienumerator_0;
		}

		public void method_0()
		{
			m_paused = true;
		}

		public void method_1()
		{
			m_paused = false;
		}

		public void Start()
		{
			m_running = true;
			ns0.MonoSingleton<TaskManager>.Instance.StartCoroutine(method_3());
		}

		public void method_2()
		{
			m_stopped = true;
			m_running = false;
		}

		private IEnumerator method_3()
		{
			yield return null;
			IEnumerator e = m_coroutine;
			while (m_running)
			{
				if (!m_paused)
				{
					if (e == null || !e.MoveNext())
					{
						m_running = false;
					}
					else
					{
						yield return e.Current;
					}
				}
				else
				{
					yield return null;
				}
			}
			Finished?.Invoke(m_stopped);
		}
	}
}
