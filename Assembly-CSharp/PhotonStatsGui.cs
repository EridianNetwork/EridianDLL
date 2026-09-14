using System;
using System.Collections.Generic;
using Core;
using ExitGames.Client.Photon;
using ns0;
using UnityEngine;

// Token: 0x02000B35 RID: 2869
public class PhotonStatsGui : MonoBehaviour
{
	// Token: 0x06004E3E RID: 20030 RVA: 0x00032EAD File Offset: 0x000310AD
	public void Start()
	{
		this.statsRect.x = (float)Screen.width - this.statsRect.width;
	}

	// Token: 0x06004E3F RID: 20031 RVA: 0x00032ECC File Offset: 0x000310CC
	public void Update()
	{
		if (Input.GetKeyDown(KeyCode.Tab) && Input.GetKey(KeyCode.LeftShift))
		{
			this.statsWindowOn = !this.statsWindowOn;
			this.statsOn = true;
		}
	}

	// Token: 0x06004E40 RID: 20032 RVA: 0x0014B2A8 File Offset: 0x001494A8
	public void OnGUI()
	{
		if (PhotonNetwork.NetworkStatisticsEnabled != this.statsOn)
		{
			PhotonNetwork.NetworkStatisticsEnabled = this.statsOn;
		}
		if (!this.statsWindowOn)
		{
			return;
		}
		this.statsRect = GUILayout.Window(this.WindowId, this.statsRect, new GUI.WindowFunction(this.method_0), "Messages (shift+tab)", new GUILayoutOption[0]);
	}

	// Token: 0x06004E41 RID: 20033 RVA: 0x0014B304 File Offset: 0x00149504
	public void method_0(int int_0)
	{
		bool flag = false;
		TrafficStatsGameLevel trafficStatsGameLevel = PhotonNetwork.networkingPeer.TrafficStatsGameLevel;
		long num = PhotonNetwork.networkingPeer.TrafficStatsElapsedMs / 1000L;
		if (num == 0L)
		{
			num = 1L;
		}
		GUILayout.BeginHorizontal(new GUILayoutOption[0]);
		this.buttonsOn = GUILayout.Toggle(this.buttonsOn, "buttons", new GUILayoutOption[0]);
		this.healthStatsVisible = GUILayout.Toggle(this.healthStatsVisible, "health", new GUILayoutOption[0]);
		this.trafficStatsOn = GUILayout.Toggle(this.trafficStatsOn, "traffic", new GUILayoutOption[0]);
		this.trafficDetailStatsOn = GUILayout.Toggle(this.trafficDetailStatsOn, "trafficDetail", new GUILayoutOption[0]);
		this.prioritySystemOn = GUILayout.Toggle(this.prioritySystemOn, "prioritySystem", new GUILayoutOption[0]);
		GUILayout.EndHorizontal();
		string text = string.Format("Out|In|Sum:\t{0,4} | {1,4} | {2,4}", trafficStatsGameLevel.TotalOutgoingMessageCount, trafficStatsGameLevel.TotalIncomingMessageCount, trafficStatsGameLevel.TotalMessageCount);
		string text2 = string.Format("{0}sec average:", num);
		string text3 = string.Format("Out|In|Sum:\t{0,4} | {1,4} | {2,4}", (long)trafficStatsGameLevel.TotalOutgoingMessageCount / num, (long)trafficStatsGameLevel.TotalIncomingMessageCount / num, (long)trafficStatsGameLevel.TotalMessageCount / num);
		string text4 = string.Format("Out|In|Sum:\t{0,4} | {1,4} | {2,4}", (long)trafficStatsGameLevel.TotalOutgoingByteCount / num, (long)trafficStatsGameLevel.TotalIncomingByteCount / num, (long)trafficStatsGameLevel.TotalByteCount / num);
		GUILayout.Label(text, new GUILayoutOption[0]);
		GUILayout.Label(text2, new GUILayoutOption[0]);
		GUILayout.Label(text3, new GUILayoutOption[0]);
		GUILayout.Label(text4, new GUILayoutOption[0]);
		if (this.buttonsOn)
		{
			GUILayout.BeginHorizontal(new GUILayoutOption[0]);
			this.statsOn = GUILayout.Toggle(this.statsOn, "stats on", new GUILayoutOption[0]);
			if (GUILayout.Button("Reset", new GUILayoutOption[0]))
			{
				PhotonNetwork.NetworkStatisticsReset();
				PhotonNetwork.NetworkStatisticsEnabled = true;
			}
			flag = GUILayout.Button("To Log", new GUILayoutOption[0]);
			GUILayout.EndHorizontal();
		}
		string text5 = string.Empty;
		string text6 = string.Empty;
		if (this.trafficStatsOn)
		{
			text5 = "Incoming: " + PhotonNetwork.networkingPeer.TrafficStatsIncoming.ToString();
			text6 = "Outgoing: " + PhotonNetwork.networkingPeer.TrafficStatsOutgoing.ToString();
			GUILayout.Label(text5, new GUILayoutOption[0]);
			GUILayout.Label(text6, new GUILayoutOption[0]);
		}
		if (this.trafficDetailStatsOn)
		{
			if (!this.showSpeed)
			{
				num = 1L;
			}
			GUILayout.BeginHorizontal(new GUILayoutOption[0]);
			this.showRCV = GUILayout.Toggle(this.showRCV, "RCV", new GUILayoutOption[0]);
			int num2 = ((!this.showRCV) ? PhotonNetwork.networkingPeer.method_75() : PhotonNetwork.networkingPeer.method_76());
			string text7 = string.Concat(new object[]
			{
				"Ingame Total",
				(!this.showRCV) ? "Outgoing: " : "Incoming",
				(long)num2 / num,
				" instantiateSize:",
				(long)((!this.showRCV) ? PhotonNetwork.networkingPeer.grossInstantiateData : PhotonNetwork.networkingPeer.grossInstantiateDataRCV) / num,
				"|",
				(int)((float)((!this.showRCV) ? PhotonNetwork.networkingPeer.grossInstantiateData : PhotonNetwork.networkingPeer.grossInstantiateDataRCV) / (float)num2 * 100f)
			});
			this.trafficDetail = text7;
			GUILayout.Label(text7, new GUILayoutOption[0]);
			this.showSpeed = GUILayout.Toggle(this.showSpeed, "Speed", new GUILayoutOption[0]);
			GUILayout.EndHorizontal();
			List<PhotonView> list = ((!this.showRCV) ? PhotonNetwork.networkingPeer.method_73() : PhotonNetwork.networkingPeer.method_74());
			int num3 = 0;
			while (num3 < list.Count && num3 < 10)
			{
				this.trafficDetail += "\n";
				GUILayout.BeginHorizontal(new GUILayoutOption[0]);
				GUILayout.BeginVertical(new GUILayoutOption[0]);
				if (list[num3].observed == null)
				{
					text6 = list[num3].name + list[num3].Int32_1;
				}
				else
				{
					text6 = list[num3].name + list[num3].Int32_1 + list[num3].observed.GetType().Name;
				}
				GUILayout.Label(text6, new GUILayoutOption[0]);
				this.trafficDetail += text6;
				GUILayout.EndVertical();
				GUILayout.BeginVertical(new GUILayoutOption[0]);
				text6 = ((!this.showRCV) ? string.Concat(new object[]
				{
					" Out: ",
					(long)((!this.showRCV) ? list[num3].Int32_3 : list[num3].Int32_4) / num,
					"|",
					(int)((float)((!this.showRCV) ? list[num3].Int32_3 : list[num3].Int32_4) / (float)num2 * 100f)
				}) : "In:");
				GUILayout.Label(text6, new GUILayoutOption[0]);
				this.trafficDetail += text6;
				GUILayout.EndVertical();
				GUILayout.BeginVertical(new GUILayoutOption[0]);
				text6 = string.Concat(new object[]
				{
					" Srlz:",
					(long)((!this.showRCV) ? list[num3].grossSerializeSize : list[num3].grossSerializeSizeRCV) / num,
					"|",
					(int)((float)((!this.showRCV) ? list[num3].grossSerializeSize : list[num3].grossSerializeSizeRCV) / (float)num2 * 100f)
				});
				GUILayout.Label(text6, new GUILayoutOption[0]);
				this.trafficDetail += text6;
				GUILayout.EndVertical();
				GUILayout.BeginVertical(new GUILayoutOption[0]);
				text6 = string.Concat(new object[]
				{
					" RPC:",
					(long)((!this.showRCV) ? list[num3].grossRPCSize : list[num3].grossRPCSizeRCV) / num,
					"|",
					(int)((float)((!this.showRCV) ? list[num3].grossRPCSize : list[num3].grossRPCSizeRCV) / (float)num2 * 100f)
				});
				GUILayout.Label(text6, new GUILayoutOption[0]);
				this.trafficDetail += text6;
				GUILayout.EndVertical();
				GUILayout.EndHorizontal();
				foreach (KeyValuePair<string, int> keyValuePair in ((!this.showRCV) ? list[num3].sizePerMethod : list[num3].sizePerMethodRCV))
				{
					this.trafficDetail += "\n";
					GUILayout.BeginHorizontal(new GUILayoutOption[0]);
					text6 = string.Concat(new object[]
					{
						"    ",
						keyValuePair.Key,
						":",
						(long)keyValuePair.Value / num,
						"|",
						(int)((float)keyValuePair.Value / (float)num2 * 100f)
					});
					GUILayout.Label(text6, new GUILayoutOption[0]);
					this.trafficDetail += text6;
					GUILayout.EndHorizontal();
				}
				num3++;
			}
		}
		string text8 = string.Empty;
		if (this.healthStatsVisible)
		{
			text8 = string.Format("ping: {6}[+/-{7}]ms\nlongest delta between\nsend: {0,4}ms disp: {1,4}ms\nlongest time for:\nev({3}):{2,3}ms op({5}):{4,3}ms", new object[]
			{
				trafficStatsGameLevel.LongestDeltaBetweenSending,
				trafficStatsGameLevel.LongestDeltaBetweenDispatching,
				trafficStatsGameLevel.LongestEventCallback,
				trafficStatsGameLevel.LongestEventCallbackCode,
				trafficStatsGameLevel.LongestOpResponseCallback,
				trafficStatsGameLevel.LongestOpResponseCallbackOpCode,
				PhotonNetwork.networkingPeer.RoundTripTime,
				PhotonNetwork.networkingPeer.RoundTripTimeVariance
			});
			GUILayout.Label(text8, new GUILayoutOption[0]);
		}
		string text9 = string.Format("{0}\n{1}\n{2}\n{3}\n{4}\n{5}", new object[] { text, text2, text3, text5, text6, text8 });
		if (flag)
		{
			DebugUtils.Log(LogCategory.Network, text9);
			DebugUtils.Log(LogCategory.Network, this.trafficDetail);
		}
		if (this.prioritySystemOn)
		{
			GUILayout.BeginHorizontal(new GUILayoutOption[0]);
			GUILayout.Label("bandwidth cap:" + MonoSingleton<AppManager>.Instance.BandwidthCap, new GUILayoutOption[0]);
			MonoSingleton<AppManager>.Instance.BandwidthCap = (int)GUILayout.HorizontalSlider((float)MonoSingleton<AppManager>.Instance.BandwidthCap, 0f, 300f, new GUILayoutOption[0]);
			GUILayout.EndHorizontal();
			GUILayout.BeginHorizontal(new GUILayoutOption[0]);
			GUILayout.Label("Inspector:" + MonoSingleton<AppManager>.Instance.PriorityInspector, new GUILayoutOption[0]);
			MonoSingleton<AppManager>.Instance.PriorityInspector = (int)GUILayout.HorizontalSlider((float)MonoSingleton<AppManager>.Instance.PriorityInspector, 0f, (float)(PhotonNetwork.playerList.Length - 1), new GUILayoutOption[0]);
			GUILayout.EndHorizontal();
			if (MonoSingleton<AppManager>.Instance.PriorityInspector < PhotonNetwork.playerList.Length)
			{
				PhotonPlayer photonPlayer = PhotonNetwork.playerList[MonoSingleton<AppManager>.Instance.PriorityInspector];
				int num4 = 0;
				foreach (PhotonView photonView in NetworkingPriority.NetworkingPriority_0.method_1(photonPlayer))
				{
					if (photonView.method_0(photonPlayer) < 5000)
					{
						num4++;
						if (num4 == 11)
						{
							break;
						}
						GUILayout.BeginHorizontal(new GUILayoutOption[0]);
						GUILayout.Label(string.Concat(new object[]
						{
							photonView.name,
							"-",
							photonView.observed.GetType().ToString(),
							":",
							NetworkingPriority.NetworkingPriority_0.method_9(photonView, photonPlayer)
						}), new GUILayoutOption[0]);
						GUILayout.EndHorizontal();
					}
				}
			}
		}
		if (GUI.changed)
		{
			this.statsRect.height = 100f;
		}
		this.lastStats = text9 + " " + this.trafficDetail;
		GUI.DragWindow();
	}

	// Token: 0x04003A5B RID: 14939
	public bool statsWindowOn = true;

	// Token: 0x04003A5C RID: 14940
	public bool statsOn = true;

	// Token: 0x04003A5D RID: 14941
	public bool healthStatsVisible;

	// Token: 0x04003A5E RID: 14942
	public bool trafficStatsOn;

	// Token: 0x04003A5F RID: 14943
	public bool trafficDetailStatsOn;

	// Token: 0x04003A60 RID: 14944
	public bool showSpeed;

	// Token: 0x04003A61 RID: 14945
	public bool showRCV;

	// Token: 0x04003A62 RID: 14946
	public bool prioritySystemOn;

	// Token: 0x04003A63 RID: 14947
	private string trafficDetail;

	// Token: 0x04003A64 RID: 14948
	public bool buttonsOn;

	// Token: 0x04003A65 RID: 14949
	public Rect statsRect = new Rect(0f, 100f, 200f, 50f);

	// Token: 0x04003A66 RID: 14950
	public int WindowId = 100;

	// Token: 0x04003A67 RID: 14951
	public string lastStats;
}
