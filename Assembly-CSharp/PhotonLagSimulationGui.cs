using System;
using ExitGames.Client.Photon;
using UnityEngine;

// Token: 0x02000B31 RID: 2865
public class PhotonLagSimulationGui : MonoBehaviour
{
	// Token: 0x170007D0 RID: 2000
	// (get) Token: 0x06004DC3 RID: 19907 RVA: 0x000327B8 File Offset: 0x000309B8
	// (set) Token: 0x06004DC4 RID: 19908 RVA: 0x000327C0 File Offset: 0x000309C0
	public PhotonPeer Peer { get; set; }

	// Token: 0x06004DC5 RID: 19909 RVA: 0x000327C9 File Offset: 0x000309C9
	public void Start()
	{
		this.Peer = PhotonNetwork.networkingPeer;
	}

	// Token: 0x06004DC6 RID: 19910 RVA: 0x000327D6 File Offset: 0x000309D6
	public void Update()
	{
		if (Input.GetKeyDown(KeyCode.Z) && Input.GetKey(KeyCode.LeftShift))
		{
			this.Visible = !this.Visible;
		}
	}

	// Token: 0x06004DC7 RID: 19911 RVA: 0x00149EFC File Offset: 0x001480FC
	public void OnGUI()
	{
		if (!this.Visible)
		{
			return;
		}
		if (this.Peer == null)
		{
			this.WindowRect = GUILayout.Window(this.WindowId, this.WindowRect, new GUI.WindowFunction(this.method_0), "Netw. Sim.", new GUILayoutOption[0]);
		}
		else
		{
			this.WindowRect = GUILayout.Window(this.WindowId, this.WindowRect, new GUI.WindowFunction(this.method_1), "Netw. Sim.", new GUILayoutOption[0]);
		}
	}

	// Token: 0x06004DC8 RID: 19912 RVA: 0x000327FC File Offset: 0x000309FC
	private void method_0(int int_0)
	{
		GUILayout.Label("No peer to communicate with. ", new GUILayoutOption[0]);
	}

	// Token: 0x06004DC9 RID: 19913 RVA: 0x00149F78 File Offset: 0x00148178
	private void method_1(int int_0)
	{
		GUILayout.Label(string.Format("Rtt:{0,4} +/-{1,3}", this.Peer.RoundTripTime, this.Peer.RoundTripTimeVariance), new GUILayoutOption[0]);
		bool isSimulationEnabled;
		bool flag;
		if ((flag = GUILayout.Toggle(isSimulationEnabled = this.Peer.IsSimulationEnabled, "Simulate", new GUILayoutOption[0])) != isSimulationEnabled)
		{
			this.Peer.IsSimulationEnabled = flag;
		}
		float num = (float)this.Peer.NetworkSimulationSettings.IncomingLag;
		GUILayout.Label("Lag " + num, new GUILayoutOption[0]);
		num = GUILayout.HorizontalSlider(num, 0f, 500f, new GUILayoutOption[0]);
		this.Peer.NetworkSimulationSettings.IncomingLag = (int)num;
		this.Peer.NetworkSimulationSettings.OutgoingLag = (int)num;
		float num2 = (float)this.Peer.NetworkSimulationSettings.IncomingJitter;
		GUILayout.Label("Jit " + num2, new GUILayoutOption[0]);
		num2 = GUILayout.HorizontalSlider(num2, 0f, 100f, new GUILayoutOption[0]);
		this.Peer.NetworkSimulationSettings.IncomingJitter = (int)num2;
		this.Peer.NetworkSimulationSettings.OutgoingJitter = (int)num2;
		float num3 = (float)this.Peer.NetworkSimulationSettings.IncomingLossPercentage;
		GUILayout.Label("Loss " + num3, new GUILayoutOption[0]);
		num3 = GUILayout.HorizontalSlider(num3, 0f, 10f, new GUILayoutOption[0]);
		this.Peer.NetworkSimulationSettings.IncomingLossPercentage = (int)num3;
		this.Peer.NetworkSimulationSettings.OutgoingLossPercentage = (int)num3;
		if (GUI.changed)
		{
			this.WindowRect.height = 100f;
		}
		GUI.DragWindow();
	}

	// Token: 0x04003A38 RID: 14904
	public Rect WindowRect = new Rect(0f, 100f, 120f, 100f);

	// Token: 0x04003A39 RID: 14905
	public int WindowId = 101;

	// Token: 0x04003A3A RID: 14906
	public bool Visible = true;
}
