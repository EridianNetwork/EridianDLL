using System;

// Token: 0x02000B2C RID: 2860
public class PhotonMessageInfo
{
	// Token: 0x06004D98 RID: 19864 RVA: 0x000325DD File Offset: 0x000307DD
	public PhotonMessageInfo()
	{
		this.sender = PhotonNetwork.player;
		this.timeInt = (int)(PhotonNetwork.time * 1000.0);
		this.photonView = null;
	}

	// Token: 0x06004D99 RID: 19865 RVA: 0x0003260D File Offset: 0x0003080D
	public PhotonMessageInfo(PhotonPlayer photonPlayer_0, int int_0, PhotonView photonView_0)
	{
		this.sender = photonPlayer_0;
		this.timeInt = int_0;
		this.photonView = photonView_0;
	}

	// Token: 0x06004D9A RID: 19866 RVA: 0x0003262A File Offset: 0x0003082A
	public void method_0()
	{
		this.timeInt = PhotonNetwork.networkingPeer.ServerTimeInMilliSeconds;
	}

	// Token: 0x170007CC RID: 1996
	// (get) Token: 0x06004D9B RID: 19867 RVA: 0x0003263C File Offset: 0x0003083C
	public double Double_0
	{
		get
		{
			return this.timeInt / 1000.0;
		}
	}

	// Token: 0x06004D9C RID: 19868 RVA: 0x00032650 File Offset: 0x00030850
	public override string ToString()
	{
		return string.Format("[PhotonMessageInfo: player='{1}' timestamp={0}]", this.Double_0, this.sender);
	}

	// Token: 0x04003A29 RID: 14889
	private int timeInt;

	// Token: 0x04003A2A RID: 14890
	public PhotonPlayer sender;

	// Token: 0x04003A2B RID: 14891
	public PhotonView photonView;
}
