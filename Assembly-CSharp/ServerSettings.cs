using System;
using UnityEngine;

// Token: 0x02000B38 RID: 2872
[Serializable]
public class ServerSettings : ScriptableObject
{
	// Token: 0x06004E63 RID: 20067 RVA: 0x0014C2B8 File Offset: 0x0014A4B8
	public static int smethod_0(string string_0)
	{
		int num = 0;
		for (int i = 0; i < ServerSettings.CloudServerRegionPrefixes.Length; i++)
		{
			if (string_0.StartsWith(ServerSettings.CloudServerRegionPrefixes[i]))
			{
				return i;
			}
		}
		return num;
	}

	// Token: 0x06004E64 RID: 20068 RVA: 0x00033003 File Offset: 0x00031203
	public static string smethod_1(int int_0)
	{
		return ServerSettings.DefaultCloudServerUrl.Replace("app-eu", ServerSettings.CloudServerRegionPrefixes[int_0]);
	}

	// Token: 0x06004E65 RID: 20069 RVA: 0x0003301B File Offset: 0x0003121B
	public void method_0(string string_0, int int_0)
	{
		this.HostType = ServerSettings.HostingOption.PhotonCloud;
		this.AppID = string_0;
		this.ServerAddress = ServerSettings.smethod_1(int_0);
		this.ServerPort = ServerSettings.DefaultMasterPort;
	}

	// Token: 0x06004E66 RID: 20070 RVA: 0x00033042 File Offset: 0x00031242
	public void method_1(string string_0, int int_0, string string_1)
	{
		this.HostType = ServerSettings.HostingOption.SelfHosted;
		this.AppID = ((string_1 == null) ? ServerSettings.DefaultAppID : string_1);
		this.ServerAddress = string_0;
		this.ServerPort = int_0;
	}

	// Token: 0x06004E67 RID: 20071 RVA: 0x0003306A File Offset: 0x0003126A
	public override string ToString()
	{
		return string.Concat(new object[] { "ServerSettings: ", this.HostType, " ", this.ServerAddress });
	}

	// Token: 0x04003A72 RID: 14962
	public static string DefaultCloudServerUrl = "app-eu.exitgamescloud.com";

	// Token: 0x04003A73 RID: 14963
	public static string[] CloudServerRegionNames = new string[] { "EU", "US", "Asia", "Japan" };

	// Token: 0x04003A74 RID: 14964
	public static string[] CloudServerRegionPrefixes = new string[] { "app-eu", "app-us", "app-asia", "app-jp" };

	// Token: 0x04003A75 RID: 14965
	public static string DefaultServerAddress = "127.0.0.1";

	// Token: 0x04003A76 RID: 14966
	public static int DefaultMasterPort = 5055;

	// Token: 0x04003A77 RID: 14967
	public static string DefaultAppID = "Master";

	// Token: 0x04003A78 RID: 14968
	public ServerSettings.HostingOption HostType;

	// Token: 0x04003A79 RID: 14969
	public string ServerAddress = ServerSettings.DefaultServerAddress;

	// Token: 0x04003A7A RID: 14970
	public int ServerPort = 5055;

	// Token: 0x04003A7B RID: 14971
	public string AppID = string.Empty;

	// Token: 0x04003A7C RID: 14972
	[HideInInspector]
	public bool DisableAutoOpenWizard;

	// Token: 0x02000B39 RID: 2873
	public enum HostingOption
	{
		// Token: 0x04003A7E RID: 14974
		NotSet,
		// Token: 0x04003A7F RID: 14975
		PhotonCloud,
		// Token: 0x04003A80 RID: 14976
		SelfHosted,
		// Token: 0x04003A81 RID: 14977
		OfflineMode
	}
}
