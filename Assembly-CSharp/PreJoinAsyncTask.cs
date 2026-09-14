using System;
using ns0;
using UnityEngine;

// Token: 0x020002C1 RID: 705
public class PreJoinAsyncTask : AsyncTaskBase
{
	// Token: 0x06000F34 RID: 3892 RVA: 0x0000D2E8 File Offset: 0x0000B4E8
	public void method_4()
	{
		this.float_1 = 60f;
	}

	// Token: 0x06000F35 RID: 3893 RVA: 0x00074ACC File Offset: 0x00072CCC
	public override void Start()
	{
		base.Start();
		MatchmakingService.LeaveRoomAsyncTask leaveRoomAsyncTask = new MatchmakingService.LeaveRoomAsyncTask();
		leaveRoomAsyncTask.method_4();
		MonoSingleton<AsyncTaskManager>.Instance.method_1(leaveRoomAsyncTask, new TaskCompletedDelegate(this.OnLeaveRoom));
	}

	// Token: 0x06000F36 RID: 3894 RVA: 0x0000D322 File Offset: 0x0000B522
	private void OnLeaveRoom(AsyncTaskBase task, AsyncTaskStatus result)
	{
		if (!(task is MatchmakingService.LeaveRoomAsyncTask))
		{
			return;
		}
		if (base.IsStatus())
		{
			return;
		}
		this.m_resourcesLoading = Application.LoadLevelAsync("ResourcesLoading");
	}

	// Token: 0x06000F37 RID: 3895 RVA: 0x00074B04 File Offset: 0x00072D04
	public override void Update(float time)
	{
		base.Update(time);
		if (this.m_resourcesLoading != null && this.m_resourcesLoading.isDone)
		{
			MonoSingleton<AppManager>.Instance.method_1(true);
			this.m_resourcesLoading = null;
			MonoSingleton<AppManager>.Instance.method_12(false);
			MonoSingleton<AppManager>.Instance.method_0().vmethod_15();
			MenuManager component = MonoSingleton<AppManager>.Instance.GetComponent<MenuManager>();
			if (component != null)
			{
				component.method_0(MenuManager.MenuPage.None);
				MonoSingleton<GameFlowManager>.Instance.method_1();
			}
			if (NetworkManager.smethod_4())
			{
				base.SetStatus(AsyncTaskStatus.Error_Disconnected);
			}
			else
			{
				RetrieveCurrentCharacterDataAsyncTask retrieveCurrentCharacterDataAsyncTask = new RetrieveCurrentCharacterDataAsyncTask();
				retrieveCurrentCharacterDataAsyncTask.method_4();
				MonoSingleton<AsyncTaskManager>.Instance.method_1(retrieveCurrentCharacterDataAsyncTask, new TaskCompletedDelegate(this.OnRetrieveCurrentCharacterData));
			}
		}
	}

	// Token: 0x06000F38 RID: 3896 RVA: 0x0000D346 File Offset: 0x0000B546
	private void OnRetrieveCurrentCharacterData(AsyncTaskBase task, AsyncTaskStatus result)
	{
		if (base.IsStatus())
		{
			return;
		}
		base.SetStatus(result);
	}

	// Token: 0x04000D7E RID: 3454
	private AsyncOperation m_resourcesLoading;

	// Token: 0x04000D7F RID: 3455
	public PlayerProperties m_playerProperties;
}
