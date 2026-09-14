using System;
using System.Runtime.InteropServices;

// Token: 0x02000C52 RID: 3154
public static class DiscordRpcHandler
{
	// Token: 0x060052E5 RID: 21221 RVA: 0x0015552C File Offset: 0x0015372C
	public static void Initialize()
	{
		if (DiscordRpcHandler.s_initialized)
		{
			return;
		}
		DiscordRpcHandler.DiscordEventHandlers discordEventHandlers = default(DiscordRpcHandler.DiscordEventHandlers);
		DiscordRpcHandler.Discord_Initialize("508875335186645022", ref discordEventHandlers, 1, null);
		DiscordRpcHandler.s_startTimestamp = DiscordRpcHandler.UnixNow();
		DiscordRpcHandler.s_initialized = true;
	}

	// Token: 0x060052E6 RID: 21222 RVA: 0x00034250 File Offset: 0x00032450
	public static void RunCallbacks()
	{
		if (!DiscordRpcHandler.s_initialized)
		{
			return;
		}
		DiscordRpcHandler.Discord_RunCallbacks();
	}

	// Token: 0x060052E7 RID: 21223 RVA: 0x00155568 File Offset: 0x00153768
	public static void UpdatePresence(string details, string state, string largeImageKey, string largeImageText)
	{
		if (!DiscordRpcHandler.s_initialized)
		{
			return;
		}
		if (details == DiscordRpcHandler.s_lastDetails && state == DiscordRpcHandler.s_lastState)
		{
			return;
		}
		DiscordRpcHandler.s_lastDetails = details;
		DiscordRpcHandler.s_lastState = state;
		DiscordRpcHandler.DiscordRichPresence discordRichPresence = default(DiscordRpcHandler.DiscordRichPresence);
		discordRichPresence.details = details;
		discordRichPresence.state = state;
		discordRichPresence.startTimestamp = DiscordRpcHandler.s_startTimestamp;
		discordRichPresence.largeImageKey = largeImageKey;
		discordRichPresence.largeImageText = largeImageText;
		discordRichPresence.instance = 1;
		DiscordRpcHandler.Discord_UpdatePresence(ref discordRichPresence);
	}

	// Token: 0x060052E8 RID: 21224 RVA: 0x0003425F File Offset: 0x0003245F
	public static void Shutdown()
	{
		if (!DiscordRpcHandler.s_initialized)
		{
			return;
		}
		DiscordRpcHandler.Discord_Shutdown();
		DiscordRpcHandler.s_initialized = false;
	}

	// Token: 0x060052E9 RID: 21225 RVA: 0x001555E8 File Offset: 0x001537E8
	private static long UnixNow()
	{
		return (long)(DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalSeconds;
	}

	// Token: 0x060052EA RID: 21226
	[DllImport("discord-rpc", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
	private static extern void Discord_Initialize(string applicationId, ref DiscordRpcHandler.DiscordEventHandlers handlers, int autoRegister, string optionalSteamId);

	// Token: 0x060052EB RID: 21227
	[DllImport("discord-rpc", CallingConvention = CallingConvention.Cdecl)]
	private static extern void Discord_RunCallbacks();

	// Token: 0x060052EC RID: 21228
	[DllImport("discord-rpc", CallingConvention = CallingConvention.Cdecl)]
	private static extern void Discord_UpdatePresence(ref DiscordRpcHandler.DiscordRichPresence presence);

	// Token: 0x060052ED RID: 21229
	[DllImport("discord-rpc", CallingConvention = CallingConvention.Cdecl)]
	private static extern void Discord_ClearPresence();

	// Token: 0x060052EE RID: 21230
	[DllImport("discord-rpc", CallingConvention = CallingConvention.Cdecl)]
	private static extern void Discord_Shutdown();

	// Token: 0x04003D0C RID: 15628
	private const string APPLICATION_ID = "508875335186645022";

	// Token: 0x04003D0D RID: 15629
	private static bool s_initialized;

	// Token: 0x04003D0E RID: 15630
	private static string s_lastDetails;

	// Token: 0x04003D0F RID: 15631
	private static string s_lastState;

	// Token: 0x04003D10 RID: 15632
	private static long s_startTimestamp;

	// Token: 0x02000C53 RID: 3155
	private struct DiscordRichPresence
	{
		// Token: 0x04003D11 RID: 15633
		public string state;

		// Token: 0x04003D12 RID: 15634
		public string details;

		// Token: 0x04003D13 RID: 15635
		public long startTimestamp;

		// Token: 0x04003D14 RID: 15636
		public long endTimestamp;

		// Token: 0x04003D15 RID: 15637
		public string largeImageKey;

		// Token: 0x04003D16 RID: 15638
		public string largeImageText;

		// Token: 0x04003D17 RID: 15639
		public string smallImageKey;

		// Token: 0x04003D18 RID: 15640
		public string smallImageText;

		// Token: 0x04003D19 RID: 15641
		public string partyId;

		// Token: 0x04003D1A RID: 15642
		public int partySize;

		// Token: 0x04003D1B RID: 15643
		public int partyMax;

		// Token: 0x04003D1C RID: 15644
		public string matchSecret;

		// Token: 0x04003D1D RID: 15645
		public string joinSecret;

		// Token: 0x04003D1E RID: 15646
		public string spectateSecret;

		// Token: 0x04003D1F RID: 15647
		public sbyte instance;
	}

	// Token: 0x02000C54 RID: 3156
	private struct DiscordEventHandlers
	{
		// Token: 0x04003D20 RID: 15648
		public IntPtr ready;

		// Token: 0x04003D21 RID: 15649
		public IntPtr disconnected;

		// Token: 0x04003D22 RID: 15650
		public IntPtr errored;

		// Token: 0x04003D23 RID: 15651
		public IntPtr joinGame;

		// Token: 0x04003D24 RID: 15652
		public IntPtr spectateGame;

		// Token: 0x04003D25 RID: 15653
		public IntPtr joinRequest;
	}
}
