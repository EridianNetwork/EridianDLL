using System;
using Core;
using ns0;
using UnityEngine;

namespace AutoTest
{
	// Token: 0x02000605 RID: 1541
	internal abstract class AutoTestCase
	{
		// Token: 0x170001EE RID: 494
		// (get) Token: 0x06002756 RID: 10070 RVA: 0x0001A6E3 File Offset: 0x000188E3
		// (set) Token: 0x06002757 RID: 10071 RVA: 0x0001A6EB File Offset: 0x000188EB
		protected float m_timeElapsed { get; private set; }

		// Token: 0x170001EF RID: 495
		// (get) Token: 0x06002758 RID: 10072 RVA: 0x0001A6F4 File Offset: 0x000188F4
		// (set) Token: 0x06002759 RID: 10073 RVA: 0x0001A6FC File Offset: 0x000188FC
		protected float m_timeStart { get; private set; }

		// Token: 0x170001F0 RID: 496
		// (get) Token: 0x0600275A RID: 10074 RVA: 0x0001A705 File Offset: 0x00018905
		// (set) Token: 0x0600275B RID: 10075 RVA: 0x0001A70D File Offset: 0x0001890D
		protected float m_timeEnd { get; private set; }

		// Token: 0x170001F1 RID: 497
		// (get) Token: 0x0600275C RID: 10076 RVA: 0x000BCC60 File Offset: 0x000BAE60
		private int SessionPlayerNum
		{
			get
			{
				Session prop_ = MonoSingleton<Session>.Instance;
				if (prop_ != null)
				{
					return prop_.method_37();
				}
				return -1;
			}
		}

		// Token: 0x170001F2 RID: 498
		// (get) Token: 0x0600275D RID: 10077 RVA: 0x0001A716 File Offset: 0x00018916
		public bool Closed
		{
			get
			{
				return this.m_clientClosed >= this.SessionPlayerNum && this.m_hostClosed;
			}
		}

		// Token: 0x170001F3 RID: 499
		// (get) Token: 0x0600275E RID: 10078 RVA: 0x0001A72F File Offset: 0x0001892F
		public bool ClientClosed
		{
			get
			{
				return this.m_clientClosed >= this.SessionPlayerNum;
			}
		}

		// Token: 0x170001F4 RID: 500
		// (get) Token: 0x0600275F RID: 10079 RVA: 0x0001A742 File Offset: 0x00018942
		public bool Started
		{
			get
			{
				return this.m_autoTestCaseSM != null;
			}
		}

		// Token: 0x170001F5 RID: 501
		// (get) Token: 0x06002760 RID: 10080 RVA: 0x0001A750 File Offset: 0x00018950
		public string Status
		{
			get
			{
				return this.m_autoTestCaseSM.m_curState.StateName;
			}
		}

		// Token: 0x170001F6 RID: 502
		// (get) Token: 0x06002761 RID: 10081 RVA: 0x0001A762 File Offset: 0x00018962
		public bool Pass
		{
			get
			{
				return this.m_hostPass && this.m_clientPass;
			}
		}

		// Token: 0x170001F7 RID: 503
		// (get) Token: 0x06002762 RID: 10082 RVA: 0x0001A775 File Offset: 0x00018975
		// (set) Token: 0x06002763 RID: 10083 RVA: 0x0001A77D File Offset: 0x0001897D
		public string Name { get; set; }

		// Token: 0x06002764 RID: 10084 RVA: 0x000BCC84 File Offset: 0x000BAE84
		public void Close(bool pass, string msg = "")
		{
			this.m_localPass = pass;
			this.m_autoTestCaseSM.method_1("ReleaseResource");
			if (!string.IsNullOrEmpty(msg))
			{
				if (pass)
				{
					DebugUtils.Log(LogCategory.Autotest, "Close(" + this.Name + "): " + msg);
				}
				else
				{
					DebugUtils.LogError(LogCategory.Autotest, "Close(" + this.Name + "): " + msg);
				}
			}
		}

		// Token: 0x06002765 RID: 10085 RVA: 0x000BCCF0 File Offset: 0x000BAEF0
		public void StartTest()
		{
			if (this.Started)
			{
				return;
			}
			MecanimEventData mecanimEventData = new MecanimEventData();
			mecanimEventData = (Resources.Load("Animation_Events") as GameObject).GetComponent<MecanimEventData>();
			MecanimEventManager.smethod_0(mecanimEventData);
			this.m_autoTestCaseSM = new AnimationStateMachine();
			this.m_autoTestCaseSM.method_0("WaitingForResource");
			this.m_autoTestCaseSM["WaitingForResource"].onEnter += this.StateWaitingForResource_OnEnter;
			this.m_autoTestCaseSM["WaitingForResource"].onUpdate += this.StateWaitingForResource_OnUpdate;
			this.m_autoTestCaseSM.method_0("InProgress");
			this.m_autoTestCaseSM["InProgress"].onEnter += this.StateInProgress_OnEnter;
			this.m_autoTestCaseSM["InProgress"].onUpdate += this.StateInProgress_OnUpdate;
			this.m_autoTestCaseSM.method_0("Spawning");
			this.m_autoTestCaseSM["Spawning"].onEnter += this.StateSpawning_OnEnter;
			this.m_autoTestCaseSM["Spawning"].onUpdate += this.StateSpawning_OnUpdate;
			this.m_autoTestCaseSM.method_0("SyncResource");
			this.m_autoTestCaseSM["SyncResource"].onEnter += this.StateSyncResource_OnEnter;
			this.m_autoTestCaseSM["SyncResource"].onUpdate += this.StateSyncResource_OnUpdate;
			this.m_autoTestCaseSM.method_0("ReleaseResource");
			this.m_autoTestCaseSM["ReleaseResource"].onUpdate += this.StateReleaseResource_OnUpdate;
			this.m_autoTestCaseSM.method_0("Closed");
			this.m_autoTestCaseSM["Closed"].onEnter += this.StateClosed_OnEnter;
			this.m_autoTestCaseSM.method_0("Login");
			this.m_autoTestCaseSM["Login"].onEnter += this.StateLogin_OnEnter;
			this.m_autoTestCaseSM["Login"].onUpdate += this.StateLogin_OnUpdate;
			this.m_autoTestCaseSM.method_1("Login");
		}

		// Token: 0x06002766 RID: 10086 RVA: 0x0001A786 File Offset: 0x00018986
		public void Update()
		{
			if (this.m_autoTestCaseSM != null)
			{
				this.m_autoTestCaseSM.Update();
			}
		}

		// Token: 0x06002767 RID: 10087 RVA: 0x000BCF40 File Offset: 0x000BB140
		private void StateLogin_OnEnter()
		{
			this.m_autotestName = WebDebugManager.string_1 + Environment.GetEnvironmentVariable("COMPUTERNAME") + DateTime.Now.Ticks;
			uint num = Utility.smethod_1(this.m_autotestName);
			this.m_autotestName = "at_" + num;
			string text = this.m_autotestName;
			if (!string.IsNullOrEmpty(MonoSingleton<AppManager>.Instance.m_login))
			{
				text = MonoSingleton<AppManager>.Instance.m_login;
			}
			DebugUtils.Log(LogCategory.Autotest, "Start Login:" + this.m_autotestName + "!!");
			MonoSingleton<AutoTestManager>.Instance.GetComponent<MenuManager>();
			MonoSingleton<AutoTestManager>.Instance.GetComponent<MenuManager>();
			if (MonoSingleton<AppManager>.Instance.m_autoTestCase.Contains("stress") && MonoSingleton<AppManager>.Instance.m_enableSndaLogin)
			{
				this.m_authenticate = new NetworkManager.StressTestAuthenticateAsyncTask();
				(this.m_authenticate as NetworkManager.StressTestAuthenticateAsyncTask).method_4(MonoSingleton<AppManager>.Instance.m_login);
			}
			else
			{
				this.m_authenticate = new NetworkManager.AuthenticateAsyncTask();
				(this.m_authenticate as NetworkManager.AuthenticateAsyncTask).method_4(text);
			}
			MonoSingleton<AsyncTaskManager>.Instance.method_1(this.m_authenticate, null);
		}

		// Token: 0x06002768 RID: 10088 RVA: 0x000BD068 File Offset: 0x000BB268
		private void StateLogin_OnUpdate()
		{
			if (!this.m_authenticate.IsStatus())
			{
				return;
			}
			if (this.m_authenticate.GetStatus() == AsyncTaskStatus.Success)
			{
				string text;
				if (MonoSingleton<AppManager>.Instance.m_autoTestCase.Contains("stress") && MonoSingleton<AppManager>.Instance.m_enableSndaLogin)
				{
					text = (this.m_authenticate as NetworkManager.StressTestAuthenticateAsyncTask).m_login;
				}
				else
				{
					text = (this.m_authenticate as NetworkManager.AuthenticateAsyncTask).m_login;
				}
				DebugUtils.Log(LogCategory.Autotest, "Login:" + text + " successful!!");
				OnlineService.smethod_0(this.m_autotestName);
				this.m_autoTestCaseSM.method_1("WaitingForResource");
			}
			else
			{
				this.m_autoTestCaseSM.method_1("Closed");
			}
		}

		// Token: 0x06002769 RID: 10089 RVA: 0x000BD11C File Offset: 0x000BB31C
		private void StateInProgress_OnEnter()
		{
			this.m_timeStart = Time.realtimeSinceStartup;
			DebugUtils.Log(LogCategory.Autotest, string.Concat(new object[] { "[AutoTest]OpenTestCase:@@", this.Name, "@@", this.m_timeStart, "@@" }));
			this.OpenAutoTestCase();
		}

		// Token: 0x0600276A RID: 10090 RVA: 0x0001A79B File Offset: 0x0001899B
		private void StateInProgress_OnUpdate()
		{
			this.m_timeElapsed = Time.realtimeSinceStartup - this.m_timeStart;
			this.UpdateAutoTestCase();
		}

		// Token: 0x0600276B RID: 10091 RVA: 0x000BD17C File Offset: 0x000BB37C
		private void StateClosed_OnEnter()
		{
			this.m_timeEnd = Time.realtimeSinceStartup;
			DebugUtils.Log(LogCategory.Autotest, string.Concat(new object[] { "[AutoTest]CloseTestCase:@@", this.Name, "@@", this.m_localPass, "@@", this.m_timeEnd, "@@" }));
			if (MonoSingleton<AutoTestManager>.Instance != null && MonoSingleton<AutoTestManager>.Instance.m_autoTestSync != null)
			{
				MonoSingleton<AutoTestManager>.Instance.m_autoTestSync.RPC_CloseCase(this.Name, this.m_localPass);
			}
			this.CloseAutoTestCase();
		}

		// Token: 0x0600276C RID: 10092 RVA: 0x0000311B File Offset: 0x0000131B
		protected virtual void OpenAutoTestCase()
		{
		}

		// Token: 0x0600276D RID: 10093 RVA: 0x0000311B File Offset: 0x0000131B
		protected virtual void UpdateAutoTestCase()
		{
		}

		// Token: 0x0600276E RID: 10094 RVA: 0x0000311B File Offset: 0x0000131B
		protected virtual void CloseAutoTestCase()
		{
		}

		// Token: 0x0600276F RID: 10095 RVA: 0x0000311B File Offset: 0x0000131B
		protected virtual void RequestResource()
		{
		}

		// Token: 0x06002770 RID: 10096 RVA: 0x0000311B File Offset: 0x0000131B
		protected virtual void SpawnAndTeleport()
		{
		}

		// Token: 0x06002771 RID: 10097 RVA: 0x0000311B File Offset: 0x0000131B
		public virtual void PostInit(string _fullName)
		{
		}

		// Token: 0x06002772 RID: 10098 RVA: 0x000BD22C File Offset: 0x000BB42C
		public AutoTestContinentResource GetContinent()
		{
			AutoTestContinentResource autoTestContinentResource = null;
			if (this.m_requestList[0] != null && this.m_requestList[0].m_resource != null)
			{
				autoTestContinentResource = this.m_requestList[0].m_resource as AutoTestContinentResource;
			}
			return autoTestContinentResource;
		}

		// Token: 0x06002773 RID: 10099 RVA: 0x000BD268 File Offset: 0x000BB468
		public AutoTestPlayerResource GetPlayer(int i)
		{
			AutoTestPlayerResource autoTestPlayerResource = null;
			if (i >= 1 && i <= 4 && this.m_requestList[i] != null && this.m_requestList[i].m_resource != null)
			{
				autoTestPlayerResource = this.m_requestList[i].m_resource as AutoTestPlayerResource;
			}
			return autoTestPlayerResource;
		}

		// Token: 0x06002774 RID: 10100 RVA: 0x0001A7B5 File Offset: 0x000189B5
		private void StateWaitingForResource_OnEnter()
		{
			DebugUtils.Log(LogCategory.Autotest, "[AutoTest]RequestResource:@@" + this.Name);
			this.RequestResource();
		}

		// Token: 0x06002775 RID: 10101 RVA: 0x0001A7D4 File Offset: 0x000189D4
		private void StateWaitingForResource_OnUpdate()
		{
			this.m_autoTestCaseSM.method_1("Spawning");
		}

		// Token: 0x06002776 RID: 10102 RVA: 0x0000311B File Offset: 0x0000131B
		private void StateSpawning_OnEnter()
		{
		}

		// Token: 0x06002777 RID: 10103 RVA: 0x0001A7E6 File Offset: 0x000189E6
		private void StateSpawning_OnUpdate()
		{
			this.m_autoTestCaseSM.method_1("SyncResource");
		}

		// Token: 0x06002778 RID: 10104 RVA: 0x0000311B File Offset: 0x0000131B
		private void StateSyncResource_OnEnter()
		{
		}

		// Token: 0x06002779 RID: 10105 RVA: 0x0001A7F8 File Offset: 0x000189F8
		private void StateSyncResource_OnUpdate()
		{
			this.m_syncResourceTime += Time.deltaTime;
			if (this.m_IHaveGotResource && this.m_syncResourceTime > 1f)
			{
				this.m_autoTestCaseSM.method_1("InProgress");
			}
		}

		// Token: 0x0600277A RID: 10106 RVA: 0x0001A831 File Offset: 0x00018A31
		private void StateReleaseResource_OnUpdate()
		{
			this.m_autoTestCaseSM.method_1("Closed");
		}

		// Token: 0x04001C6C RID: 7276
		private bool m_localPass;

		// Token: 0x04001C6D RID: 7277
		public bool m_hostPass = true;

		// Token: 0x04001C6E RID: 7278
		public bool m_clientPass = true;

		// Token: 0x04001C6F RID: 7279
		public bool m_hostClosed;

		// Token: 0x04001C70 RID: 7280
		public int m_clientClosed;

		// Token: 0x04001C71 RID: 7281
		private AnimationStateMachine m_autoTestCaseSM;

		// Token: 0x04001C72 RID: 7282
		private PhotonNetworkTask m_authenticate;

		// Token: 0x04001C73 RID: 7283
		private string m_autotestName;

		// Token: 0x04001C74 RID: 7284
		public AutoTestResourceRequest[] m_requestList = new AutoTestResourceRequest[5];

		// Token: 0x04001C75 RID: 7285
		public bool m_IHaveGotResource;

		// Token: 0x04001C76 RID: 7286
		private float m_syncResourceTime;
	}
}
