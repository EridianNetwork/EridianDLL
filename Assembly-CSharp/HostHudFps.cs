using System;
using UnityEngine;

// Token: 0x02000A98 RID: 2712
public class HostHudFps : HudFps
{
	// Token: 0x0600495B RID: 18779 RVA: 0x00130DFC File Offset: 0x0012EFFC
	public override void Start()
	{
		this.startRect = new Rect((float)(Screen.width - 75), 350f, 75f, 50f);
		this.startRect2 = new Rect((float)(Screen.width - 150), this.startRect.yMin, this.startRect.width, this.startRect.height);
		this.startRect5 = new Rect((float)(Screen.width - 150), this.startRect.yMin + 80f, 150f, 80f);
	}

	// Token: 0x0600495C RID: 18780 RVA: 0x0002FF13 File Offset: 0x0002E113
	public override void Update()
	{
		this.m_memCur = (uint)DebugUtils.s_debugInfoSync.m_hostmem;
		this.m_memPeak = 0U;
		this.m_fps = DebugUtils.s_debugInfoSync.m_hostfps;
	}
}
