using System;
using Core;
using UnityEngine;

// Token: 0x0200012C RID: 300
[ExecuteInEditMode]
public abstract class AudioSubsystem : IAudioSubsystem
{
	// Token: 0x060006E5 RID: 1765
	protected abstract bool vmethod_0();

	// Token: 0x060006E6 RID: 1766
	protected abstract void vmethod_1();

	// Token: 0x060006E7 RID: 1767 RVA: 0x0000311B File Offset: 0x0000131B
	protected virtual void OnSceneLoaded(bool loaded)
	{
	}

	// Token: 0x060006E8 RID: 1768 RVA: 0x0000311B File Offset: 0x0000131B
	public virtual void Update()
	{
	}

	// Token: 0x060006E9 RID: 1769 RVA: 0x0000311B File Offset: 0x0000131B
	public virtual void LateUpdate()
	{
	}

	// Token: 0x060006EA RID: 1770 RVA: 0x0000311B File Offset: 0x0000131B
	public virtual void imethod_4()
	{
	}

	// Token: 0x060006EB RID: 1771 RVA: 0x000555B8 File Offset: 0x000537B8
	public bool imethod_0()
	{
		bool flag = false;
		if (!this.m_initialized)
		{
			flag = this.vmethod_0();
			this.m_initialized = flag;
		}
		else
		{
			DebugUtils.LogWarning(LogCategory.Audio, "Multiple initialization calls for subsystem: " + base.GetType());
		}
		return flag;
	}

	// Token: 0x060006EC RID: 1772 RVA: 0x00007954 File Offset: 0x00005B54
	public void imethod_1()
	{
		if (this.m_initialized)
		{
			this.vmethod_1();
		}
	}

	// Token: 0x060006ED RID: 1773 RVA: 0x00007964 File Offset: 0x00005B64
	public void imethod_2()
	{
		this.OnSceneLoaded(true);
		this.m_inScene = true;
	}

	// Token: 0x060006EE RID: 1774 RVA: 0x00007974 File Offset: 0x00005B74
	public void imethod_3()
	{
		this.OnSceneLoaded(false);
		this.m_inScene = false;
	}

	// Token: 0x04000646 RID: 1606
	protected bool m_initialized;

	// Token: 0x04000647 RID: 1607
	protected bool m_inScene;
}
