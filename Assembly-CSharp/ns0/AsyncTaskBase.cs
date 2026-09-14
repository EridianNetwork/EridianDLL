using System;
using Core;

namespace ns0
{
	// Token: 0x02000270 RID: 624
	public class AsyncTaskBase
	{
		// Token: 0x06000D3A RID: 3386 RVA: 0x0000C5DA File Offset: 0x0000A7DA
		public AsyncTaskBase()
		{
			this.TaskID = MonoSingleton<AsyncTaskManager>.Instance.GetNewTaskID();
		}

		// Token: 0x06000D3B RID: 3387 RVA: 0x0000C5F9 File Offset: 0x0000A7F9
		public int GetTaskID()
		{
			return this.TaskID;
		}

		// Token: 0x06000D3C RID: 3388 RVA: 0x0000C601 File Offset: 0x0000A801
		public virtual void Start()
		{
			this.SetStatus(AsyncTaskStatus.Proceeding);
		}

		// Token: 0x06000D3D RID: 3389 RVA: 0x0000C60A File Offset: 0x0000A80A
		public bool IsStatus()
		{
			return this.GetStatus() != AsyncTaskStatus.Proceeding;
		}

		// Token: 0x06000D3E RID: 3390 RVA: 0x0006F530 File Offset: 0x0006D730
		public virtual void Update(float time)
		{
			if (this.float_1 > 0f && time - this.StartTime > this.float_1)
			{
				DebugUtils.LogWarning(LogCategory.Framework, base.GetType().ToString() + "[AsyncTaskResult.Error_Timeout]");
				this.SetStatus(AsyncTaskStatus.Error_Timeout);
			}
		}

		// Token: 0x06000D3F RID: 3391 RVA: 0x0000311B File Offset: 0x0000131B
		public virtual void vmethod_0()
		{
		}

		// Token: 0x06000D40 RID: 3392 RVA: 0x0006F57C File Offset: 0x0006D77C
		protected void SetStatus(AsyncTaskStatus genum0_1)
		{
			if (genum0_1 != AsyncTaskStatus.Success && genum0_1 != AsyncTaskStatus.Proceeding)
			{
				DebugUtils.LogWarning(LogCategory.Framework, base.GetType().ToString() + "[" + genum0_1.ToString() + "]");
			}
			else
			{
				DebugUtils.Log(LogCategory.Framework, base.GetType().ToString() + "[" + genum0_1.ToString() + "]");
			}
			this.status = genum0_1;
		}

		// Token: 0x06000D41 RID: 3393 RVA: 0x0000C618 File Offset: 0x0000A818
		public AsyncTaskStatus GetStatus()
		{
			return this.status;
		}

		// Token: 0x04000C10 RID: 3088
		private int TaskID;

		// Token: 0x04000C11 RID: 3089
		private AsyncTaskStatus status = AsyncTaskStatus.Success;

		// Token: 0x04000C12 RID: 3090
		public float StartTime;

		// Token: 0x04000C13 RID: 3091
		public float float_1;
	}
}
