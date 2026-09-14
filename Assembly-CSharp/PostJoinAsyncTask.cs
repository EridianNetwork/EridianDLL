using System;
using ns0;

// Token: 0x020002C2 RID: 706
public class PostJoinAsyncTask : AsyncTaskBase
{
	// Token: 0x06000F3A RID: 3898 RVA: 0x0000D358 File Offset: 0x0000B558
	public void method_4()
	{
		this.float_1 = 30f;
	}

	// Token: 0x06000F3B RID: 3899 RVA: 0x00074BB8 File Offset: 0x00072DB8
	public override void Start()
	{
		base.Start();
		MonoSingleton<AppManager>.Instance.method_0().Boolean_0 = false;
		MonoSingleton<AppManager>.Instance.GetComponent<FrontEndStepManager>().method_3(FrontEndStepManager.StepState.none, null);
		MonoSingleton<AppManager>.Instance.method_0().vmethod_19(false);
		MonoSingleton<AppManager>.Instance.method_0().vmethod_12(false);
		MonoSingleton<AppManager>.Instance.method_0().vmethod_6<LoadingInGameView>().method_3(MonoSingleton<AppManager>.Instance.m_playlistId);
		MenuManager component = MonoSingleton<AppManager>.Instance.GetComponent<MenuManager>();
		if (component != null)
		{
			component.method_0(MenuManager.MenuPage.None);
		}
	}

	// Token: 0x06000F3C RID: 3900 RVA: 0x0000D365 File Offset: 0x0000B565
	public override void Update(float time)
	{
		base.Update(time);
		if (MonoSingleton<Session>.Instance != null)
		{
			base.SetStatus(AsyncTaskStatus.Success);
		}
	}
}
