using System;
using Core;
using ns0;

// Token: 0x020005FF RID: 1535
public abstract class SessionLogic
{
	// Token: 0x06002738 RID: 10040
	public abstract void vmethod_0();

	// Token: 0x06002739 RID: 10041
	public abstract void vmethod_1();

	// Token: 0x0600273A RID: 10042
	public abstract void vmethod_2();

	// Token: 0x0600273B RID: 10043 RVA: 0x000BC6EC File Offset: 0x000BA8EC
	public virtual void vmethod_3()
	{
		if (this.m_timer.method_7())
		{
			DebugUtils.Log(LogCategory.Framework, string.Concat(new object[]
			{
				"SessionLogic: ",
				this.m_SessionSM.m_curState.StateName,
				" - map: ",
				MonoSingleton<Session>.Instance.method_5(),
				" - #players: ",
				MonoSingleton<Session>.Instance.method_37()
			}));
			this.m_timer.method_4();
		}
		if (!this.m_timer.method_6())
		{
			this.m_timer.Start(300f);
		}
		this.m_SessionSM.Update();
	}

	// Token: 0x0600273C RID: 10044
	public abstract bool vmethod_4();

	// Token: 0x0600273D RID: 10045
	public abstract void OnGoToSubInstance(string mapName);

	// Token: 0x0600273E RID: 10046
	public abstract void OnGoToInstance();

	// Token: 0x0600273F RID: 10047
	public abstract void OnMapChange();

	// Token: 0x04001C54 RID: 7252
	private Utils.Timer m_timer = new Utils.Timer();

	// Token: 0x04001C55 RID: 7253
	protected AnimationStateMachine m_SessionSM = new AnimationStateMachine();

	// Token: 0x04001C56 RID: 7254
	public bool m_isMapLoaded;
}
