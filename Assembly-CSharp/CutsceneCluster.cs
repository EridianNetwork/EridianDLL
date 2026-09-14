using System;
using System.Collections.Generic;
using Core;
using ns0;

// Token: 0x0200050C RID: 1292
public class CutsceneCluster : Scene
{
	// Token: 0x06002195 RID: 8597 RVA: 0x00017154 File Offset: 0x00015354
	private void OnLevelWasLoaded(int level)
	{
		CutsceneCluster.s_cutsceneIdGenerator = 0;
	}

	// Token: 0x06002196 RID: 8598 RVA: 0x0001715C File Offset: 0x0001535C
	protected override void Awake()
	{
		this.m_cutsceneId = ++CutsceneCluster.s_cutsceneIdGenerator;
		base.Awake();
	}

	// Token: 0x06002197 RID: 8599 RVA: 0x000A1604 File Offset: 0x0009F804
	protected override void vmethod_0()
	{
		DebugUtils.Log(LogCategory.Gamelogic, "CutScene.Begin");
		IHostSession hostSession = MonoSingleton<Session>.Instance.method_24();
		if (hostSession != null)
		{
			List<PlayerInfoSync> list;
			base.method_7(out list);
			for (int i = 0; i < list.Count; i++)
			{
				hostSession.imethod_9(this.m_cutsceneId, list[i]);
			}
		}
		this.m_cutsceneTimer.Start(this.m_duration);
	}

	// Token: 0x06002198 RID: 8600 RVA: 0x00017177 File Offset: 0x00015377
	protected override bool vmethod_3()
	{
		return !this.m_cutsceneTimer.method_6() || this.m_cutsceneTimer.method_7();
	}

	// Token: 0x06002199 RID: 8601 RVA: 0x000A1668 File Offset: 0x0009F868
	protected override void vmethod_1()
	{
		IHostSession hostSession = MonoSingleton<Session>.Instance.method_24();
		if (hostSession != null)
		{
			List<PlayerInfoSync> list;
			base.method_7(out list);
			for (int i = 0; i < list.Count; i++)
			{
				hostSession.imethod_10(this.m_cutsceneId, list[i]);
			}
		}
		base.vmethod_1();
	}

	// Token: 0x04001647 RID: 5703
	public CutScene m_cutscene;

	// Token: 0x04001648 RID: 5704
	public float m_duration;

	// Token: 0x04001649 RID: 5705
	private Utils.Timer m_cutsceneTimer = new Utils.Timer();

	// Token: 0x0400164A RID: 5706
	private static int s_cutsceneIdGenerator;

	// Token: 0x0400164B RID: 5707
	public int m_cutsceneId;
}
