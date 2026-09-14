using System;
using System.Collections.Generic;
using UnityEngine;

namespace ns0
{
	// Token: 0x02000272 RID: 626
	public class AsyncTaskManager : MonoSingleton<AsyncTaskManager>
	{
		// Token: 0x06000D4C RID: 3404 RVA: 0x0000C66A File Offset: 0x0000A86A
		public int GetNewTaskID()
		{
			return AsyncTaskManager.TaskID++;
		}

		// Token: 0x06000D4D RID: 3405 RVA: 0x0000C679 File Offset: 0x0000A879
		public void method_1(AsyncTaskBase gclass0_0, TaskCompletedDelegate gdelegate3_0 = null)
		{
			gclass0_0.StartTime = Time.time;
			gclass0_0.Start();
			this.ActiveTasks.Add(new Pair<AsyncTaskBase, TaskCompletedDelegate>(gclass0_0, gdelegate3_0));
		}

		// Token: 0x06000D4E RID: 3406 RVA: 0x0000C69E File Offset: 0x0000A89E
		public int GetActiveTaskCount()
		{
			return this.ActiveTasks.Count;
		}

		// Token: 0x06000D4F RID: 3407 RVA: 0x0006F640 File Offset: 0x0006D840
		public bool HasTaskOfType<T>()
		{
			for (int i = 0; i < this.ActiveTasks.Count; i++)
			{
				if (this.ActiveTasks[i].GetType() == typeof(T))
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x06000D50 RID: 3408 RVA: 0x0006F688 File Offset: 0x0006D888
		private void Update()
		{
			this.list_1.Clear();
			float time = Time.time;
			for (int i = 0; i < this.ActiveTasks.Count; i++)
			{
				this.ActiveTasks[i].Left.Update(time);
				if (this.ActiveTasks[i].Left.IsStatus())
				{
					if (this.ActiveTasks[i].Left.GetStatus() != AsyncTaskStatus.Success)
					{
						int num = 1;
						if (this.dictionary_0.TryGetValue(this.ActiveTasks[i].Left.GetType(), out num))
						{
							this.dictionary_0[this.ActiveTasks[i].Left.GetType()] = num + 1;
						}
						else
						{
							this.dictionary_0.Add(this.ActiveTasks[i].Left.GetType(), num);
						}
					}
					else
					{
						this.dictionary_0.Remove(this.ActiveTasks[i].Left.GetType());
					}
					if (this.ActiveTasks[i].Right != null)
					{
						this.ActiveTasks[i].Right(this.ActiveTasks[i].Left, this.ActiveTasks[i].Left.GetStatus());
					}
					this.list_1.Add(this.ActiveTasks[i]);
				}
			}
			for (int j = 0; j < this.list_1.Count; j++)
			{
				this.list_1[j].Left.vmethod_0();
				this.ActiveTasks.Remove(this.list_1[j]);
			}
		}

		// Token: 0x06000D51 RID: 3409 RVA: 0x0006F84C File Offset: 0x0006DA4C
		public int method_4(Type type_0)
		{
			int num = 0;
			this.dictionary_0.TryGetValue(type_0, out num);
			return num;
		}

		// Token: 0x06000D52 RID: 3410 RVA: 0x0000C6AB File Offset: 0x0000A8AB
		public bool method_5(Type type_0)
		{
			return this.method_4(type_0) > AsyncTaskManager.int_0;
		}

		// Token: 0x06000D53 RID: 3411 RVA: 0x0000C6BB File Offset: 0x0000A8BB
		public void method_6(Type type_0)
		{
			this.dictionary_0.Remove(type_0);
		}

		// Token: 0x06000D54 RID: 3412 RVA: 0x0006F86C File Offset: 0x0006DA6C
		public string DumpToString()
		{
			string text = "AsyncTaskManager.DumpToString [" + this.ActiveTasks.Count + "] ";
			for (int i = 0; i < this.ActiveTasks.Count; i++)
			{
				string text2 = text;
				text = string.Concat(new object[]
				{
					text2,
					" [",
					this.ActiveTasks[i].GetType(),
					"] -"
				});
			}
			return text;
		}

		// Token: 0x04000C14 RID: 3092
		public static int int_0 = 3;

		// Token: 0x04000C15 RID: 3093
		private static int TaskID;

		// Token: 0x04000C16 RID: 3094
		private List<Pair<AsyncTaskBase, TaskCompletedDelegate>> ActiveTasks = new List<Pair<AsyncTaskBase, TaskCompletedDelegate>>();

		// Token: 0x04000C17 RID: 3095
		private Dictionary<Type, int> dictionary_0 = new Dictionary<Type, int>();

		// Token: 0x04000C18 RID: 3096
		private List<Pair<AsyncTaskBase, TaskCompletedDelegate>> list_1 = new List<Pair<AsyncTaskBase, TaskCompletedDelegate>>();
	}
}
