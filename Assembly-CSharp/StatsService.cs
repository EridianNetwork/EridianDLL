using System;
using System.Collections;
using System.Collections.Generic;
using ns0;
using UnityEngine;

// Token: 0x020003E8 RID: 1000
internal class StatsService : OnAccessSingleton<IStatsService, StatsServiceOffline, StatsService>, IStatsService
{
	// Token: 0x06001917 RID: 6423 RVA: 0x000839C0 File Offset: 0x00081BC0
	public StatsService()
	{
		this.mEnabled = !string.IsNullOrEmpty(MonoSingleton<AppManager>.Instance.m_gameServerName) && !string.IsNullOrEmpty(MonoSingleton<AppManager>.Instance.m_statsDBAddress);
		if (this.mEnabled)
		{
			this.mGameServerName = MonoSingleton<AppManager>.Instance.m_gameServerName;
			this.mAddress = MonoSingleton<AppManager>.Instance.m_statsDBAddress;
		}
	}

	// Token: 0x06001918 RID: 6424 RVA: 0x00083A34 File Offset: 0x00081C34
	public void imethod_0(string string_0, int int_0, int int_1, int int_2, string string_1)
	{
		if (this.mEnabled)
		{
			JSONObject jsonobject = this.method_0();
			jsonobject.AddField("game_mode", string_0);
			jsonobject.AddField("playlist_id", int_0);
			jsonobject.AddField("account_id", int_1);
			jsonobject.AddField("character_id", int_2);
			jsonobject.AddField("character_name", string_1);
			HttpHelper.HttpHelper_0.method_0(this.mAddress, "/py/enter", jsonobject);
		}
	}

	// Token: 0x06001919 RID: 6425 RVA: 0x00083AA4 File Offset: 0x00081CA4
	public void imethod_1(string string_0, int int_0, int int_1, int int_2, string string_1)
	{
		if (this.mEnabled)
		{
			JSONObject jsonobject = this.method_0();
			jsonobject.AddField("game_mode", string_0);
			jsonobject.AddField("playlist_id", int_0);
			jsonobject.AddField("account_id", int_1);
			jsonobject.AddField("character_id", int_2);
			jsonobject.AddField("character_name", string_1);
			HttpHelper.HttpHelper_0.method_0(this.mAddress, "/py/leave", jsonobject);
		}
	}

	// Token: 0x0600191A RID: 6426 RVA: 0x00083B14 File Offset: 0x00081D14
	private JSONObject method_0()
	{
		JSONObject jsonobject = new JSONObject(JSONObject.Type.OBJECT);
		jsonobject.AddField("server_name", this.mGameServerName);
		jsonobject.AddField("ts", (float)DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds);
		jsonobject.AddField("account_id", OnlineService.s_accountId);
		jsonobject.AddField("character_id", OnlineService.s_characterId);
		jsonobject.AddField("character_name", OnlineService.s_userName);
		return jsonobject;
	}

	// Token: 0x0600191B RID: 6427 RVA: 0x00012C78 File Offset: 0x00010E78
	public void Update()
	{
		if (Time.time - this.mLastFlush > 60f)
		{
			this.mLastFlush = Time.time;
			this.method_3();
		}
	}

	// Token: 0x0600191C RID: 6428 RVA: 0x00012C9E File Offset: 0x00010E9E
	public void method_1(StatsEvent statsEvent_0)
	{
		this.mEvents.Add(statsEvent_0);
	}

	// Token: 0x0600191D RID: 6429 RVA: 0x00012CAC File Offset: 0x00010EAC
	public void method_2()
	{
		while (this.mEvents.Count > 0)
		{
			this.method_3();
		}
	}

	// Token: 0x0600191E RID: 6430 RVA: 0x00083B9C File Offset: 0x00081D9C
	private void method_3()
	{
		int num = Math.Min(64, this.mEvents.Count);
		if (num <= 0)
		{
			return;
		}
		Hashtable hashtable = new Hashtable();
		for (int i = 0; i < num; i++)
		{
			hashtable.Add(i, this.mEvents[i].imethod_0());
		}
		PhotonNetwork.networkingPeer.vmethod_10(209, hashtable, true, 1);
		this.mEvents.RemoveRange(0, num);
	}

	// Token: 0x04001115 RID: 4373
	private const float UPDATE_FREQUENCY = 60f;

	// Token: 0x04001116 RID: 4374
	private const int MAX_EVENTS_PER_UPDATE = 64;

	// Token: 0x04001117 RID: 4375
	private List<StatsEvent> mEvents = new List<StatsEvent>();

	// Token: 0x04001118 RID: 4376
	private string mGameServerName;

	// Token: 0x04001119 RID: 4377
	private string mAddress;

	// Token: 0x0400111A RID: 4378
	private float mLastFlush;

	// Token: 0x0400111B RID: 4379
	private bool mEnabled;
}
