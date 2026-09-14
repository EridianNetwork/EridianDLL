using System;
using System.Collections.Generic;
using ns0;

// Token: 0x020003C4 RID: 964
public class OnlineService : MonoSingleton<OnlineService>
{
	// Token: 0x06001866 RID: 6246 RVA: 0x00081794 File Offset: 0x0007F994
	protected override void Awake()
	{
		base.Awake();
		this.m_servers = new Dictionary<OnlineService.ServerFrameWorkEnv, string>
		{
			{
				OnlineService.ServerFrameWorkEnv.Proto,
				"127.0.0.1"
			},
			{
				OnlineService.ServerFrameWorkEnv.Dev,
				"127.0.0.1"
			},
			{
				OnlineService.ServerFrameWorkEnv.Test,
				"127.0.0.1"
			},
			{
				OnlineService.ServerFrameWorkEnv.Prod,
				"127.0.0.1"
			},
			{
				OnlineService.ServerFrameWorkEnv.Latest,
				"127.0.0.1"
			},
			{
				OnlineService.ServerFrameWorkEnv.Shard,
				"127.0.0.1"
			},
			{
				OnlineService.ServerFrameWorkEnv.Shenda,
				"127.0.0.1"
			},
			{
				OnlineService.ServerFrameWorkEnv.Custom,
				MonoSingleton<AppManager>.Instance.m_serverIP
			}
		};
	}

	// Token: 0x06001867 RID: 6247 RVA: 0x00012322 File Offset: 0x00010522
	public static void smethod_0(string string_0)
	{
		OnlineService.s_userName = string_0;
	}

	// Token: 0x06001868 RID: 6248 RVA: 0x0001232A File Offset: 0x0001052A
	public string method_0()
	{
		return this.m_servers[MonoSingleton<AppManager>.Instance.m_serverEnvironment];
	}

	// Token: 0x06001869 RID: 6249 RVA: 0x00012341 File Offset: 0x00010541
	public string method_1()
	{
		return this.m_servers[OnlineService.ServerFrameWorkEnv.Proto];
	}

	// Token: 0x0600186A RID: 6250 RVA: 0x0001234F File Offset: 0x0001054F
	public string method_2()
	{
		return string.Concat(new object[]
		{
			"http://",
			this.method_1(),
			":",
			this.m_serverPort
		});
	}

	// Token: 0x0400107A RID: 4218
	private Dictionary<OnlineService.ServerFrameWorkEnv, string> m_servers;

	// Token: 0x0400107B RID: 4219
	public static string s_userName;

	// Token: 0x0400107C RID: 4220
	public static int s_accountId;

	// Token: 0x0400107D RID: 4221
	public static int s_characterId;

	// Token: 0x0400107E RID: 4222
	public static string s_serverVersionId;

	// Token: 0x0400107F RID: 4223
	public bool m_usePhotonOLCall = true;

	// Token: 0x04001080 RID: 4224
	public readonly int m_serverPort = 2001;

	// Token: 0x020003C5 RID: 965
	public enum ServerFrameWorkEnv
	{
		// Token: 0x04001082 RID: 4226
		Proto,
		// Token: 0x04001083 RID: 4227
		Dev,
		// Token: 0x04001084 RID: 4228
		Test,
		// Token: 0x04001085 RID: 4229
		Prod,
		// Token: 0x04001086 RID: 4230
		Latest,
		// Token: 0x04001087 RID: 4231
		Shard,
		// Token: 0x04001088 RID: 4232
		Shenda,
		// Token: 0x04001089 RID: 4233
		Custom
	}

	// Token: 0x020003C6 RID: 966
	public enum OnlineCallResultHashkey : byte
	{
		// Token: 0x0400108B RID: 4235
		Dummy,
		// Token: 0x0400108C RID: 4236
		Result
	}
}
