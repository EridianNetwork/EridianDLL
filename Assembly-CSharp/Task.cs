using System;
using System.Collections;
using System.Runtime.CompilerServices;

// Token: 0x020002B1 RID: 689
public class Task
{
	// Token: 0x06000ED3 RID: 3795 RVA: 0x0000D09D File Offset: 0x0000B29D
	public Task(IEnumerator ienumerator_0, bool bool_0 = true)
	{
		this.m_task = TaskManager.smethod_0(ienumerator_0);
		this.m_task.Event_0 += this.method_3;
		if (bool_0)
		{
			this.Start();
		}
	}

	// Token: 0x14000007 RID: 7
	// (add) Token: 0x06000ED4 RID: 3796 RVA: 0x0000D0D1 File Offset: 0x0000B2D1
	// (remove) Token: 0x06000ED5 RID: 3797 RVA: 0x0000D0EA File Offset: 0x0000B2EA
	public event Task.FinishedHandler Event_0
	{
		[MethodImpl(MethodImplOptions.Synchronized)]
		add
		{
			this.Finished = (Task.FinishedHandler)Delegate.Combine(this.Finished, value);
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		remove
		{
			this.Finished = (Task.FinishedHandler)Delegate.Remove(this.Finished, value);
		}
	}

	// Token: 0x170000BE RID: 190
	// (get) Token: 0x06000ED6 RID: 3798 RVA: 0x0000D103 File Offset: 0x0000B303
	public bool Boolean_0
	{
		get
		{
			return this.m_task.Boolean_0;
		}
	}

	// Token: 0x170000BF RID: 191
	// (get) Token: 0x06000ED7 RID: 3799 RVA: 0x0000D110 File Offset: 0x0000B310
	public bool Boolean_1
	{
		get
		{
			return this.m_task.Boolean_1;
		}
	}

	// Token: 0x06000ED8 RID: 3800 RVA: 0x0000D11D File Offset: 0x0000B31D
	public void Start()
	{
		this.m_task.Start();
	}

	// Token: 0x06000ED9 RID: 3801 RVA: 0x0000D12A File Offset: 0x0000B32A
	public void method_0()
	{
		this.m_task.method_2();
	}

	// Token: 0x06000EDA RID: 3802 RVA: 0x0000D137 File Offset: 0x0000B337
	public void method_1()
	{
		this.m_task.method_0();
	}

	// Token: 0x06000EDB RID: 3803 RVA: 0x0000D144 File Offset: 0x0000B344
	public void method_2()
	{
		this.m_task.method_1();
	}

	// Token: 0x06000EDC RID: 3804 RVA: 0x00074148 File Offset: 0x00072348
	private void method_3(bool bool_0)
	{
		Task.FinishedHandler finished = this.Finished;
		if (finished != null)
		{
			finished(bool_0);
		}
	}

	// Token: 0x04000D41 RID: 3393
	private TaskManager.TaskState m_task;

	// Token: 0x04000D42 RID: 3394
	private Task.FinishedHandler Finished;

	// Token: 0x020002B2 RID: 690
	// (Invoke) Token: 0x06000EDE RID: 3806
	public delegate void FinishedHandler(bool manual);
}
