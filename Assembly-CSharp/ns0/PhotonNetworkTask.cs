using System;

namespace ns0
{
	// Token: 0x02000271 RID: 625
	public class PhotonNetworkTask : AsyncTaskBase, INetworkManagerListener
	{
		// Token: 0x06000D43 RID: 3395 RVA: 0x0000311B File Offset: 0x0000131B
		public virtual void OnJoinedRoom()
		{
		}

		// Token: 0x06000D44 RID: 3396 RVA: 0x0000311B File Offset: 0x0000131B
		public virtual void OnPhotonJoinRoomFailed()
		{
		}

		// Token: 0x06000D45 RID: 3397 RVA: 0x0000311B File Offset: 0x0000131B
		public virtual void OnPhotonRandomJoinFailed()
		{
		}

		// Token: 0x06000D46 RID: 3398 RVA: 0x0000311B File Offset: 0x0000131B
		public virtual void OnLeftRoom()
		{
		}

		// Token: 0x06000D47 RID: 3399 RVA: 0x0000C628 File Offset: 0x0000A828
		public virtual void OnDisconnectedFromPhoton()
		{
			if (base.GetStatus() == AsyncTaskStatus.Proceeding)
			{
				base.SetStatus(AsyncTaskStatus.Error_Disconnected);
			}
		}

		// Token: 0x06000D48 RID: 3400 RVA: 0x0006F5F0 File Offset: 0x0006D7F0
		public override void Start()
		{
			base.Start();
			NetworkManager component = MonoSingleton<AppManager>.Instance.GetComponent<NetworkManager>();
			component.method_0(this);
		}

		// Token: 0x06000D49 RID: 3401 RVA: 0x0006F618 File Offset: 0x0006D818
		public override void vmethod_0()
		{
			NetworkManager component = MonoSingleton<AppManager>.Instance.GetComponent<NetworkManager>();
			component.method_1(this);
			base.vmethod_0();
		}
	}
}
