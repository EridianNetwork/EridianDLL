using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Core;

// Token: 0x0200065B RID: 1627
public static class Utility
{
	// Token: 0x0600290C RID: 10508 RVA: 0x000C1D4C File Offset: 0x000BFF4C
	public static List<string> smethod_0(string string_0, string string_1)
	{
		List<string> list = new List<string>();
		string[] directories = Directory.GetDirectories(string_0);
		for (int i = 0; i < directories.Length; i++)
		{
			list.AddRange(Utility.smethod_0(directories[i], string_1));
		}
		list.AddRange(Directory.GetFiles(string_0, string_1));
		return list;
	}

	// Token: 0x0600290D RID: 10509 RVA: 0x000C1D94 File Offset: 0x000BFF94
	public static uint smethod_1(string string_0)
	{
		uint num = 0U;
		for (int i = string_0.Length - 1; i >= 0; i--)
		{
			num = (num << 5) - num + (uint)string_0[i];
		}
		return num;
	}

	// Token: 0x0600290E RID: 10510 RVA: 0x000C1DC8 File Offset: 0x000BFFC8
	public static uint smethod_2(char[] char_0)
	{
		uint num = 0U;
		for (int i = char_0.Length - 1; i >= 0; i--)
		{
			num = (num << 5) - num + (uint)char_0[i];
		}
		return num;
	}

	// Token: 0x0600290F RID: 10511 RVA: 0x000C1DF4 File Offset: 0x000BFFF4
	private static void smethod_3()
	{
		if (Utility.CRC32Table != null)
		{
			return;
		}
		Utility.CRC32Table = new uint[256];
		for (uint num = 0U; num < 256U; num += 1U)
		{
			uint num2 = num;
			for (int i = 0; i < 8; i++)
			{
				if (num2 % 2U == 0U)
				{
					num2 >>= 1;
				}
				else
				{
					num2 = (num2 >> 1) ^ 3988292384U;
				}
			}
			Utility.CRC32Table[(int)((UIntPtr)num)] = num2;
		}
	}

	// Token: 0x06002910 RID: 10512 RVA: 0x000C1E54 File Offset: 0x000C0054
	public static uint smethod_4(string string_0)
	{
		Utility.smethod_3();
		uint num = uint.MaxValue;
		if (File.Exists(string_0))
		{
			FileStream fileStream = new FileStream(string_0, FileMode.Open, FileAccess.Read);
			num = Utility.smethod_10(fileStream);
			fileStream.Close();
			fileStream.Dispose();
		}
		else
		{
			DebugUtils.LogError(LogCategory.Tool, "File Not Exists: " + string_0);
		}
		return num;
	}

	// Token: 0x06002911 RID: 10513 RVA: 0x0001AF72 File Offset: 0x00019172
	public static string smethod_5(string string_0, string string_1)
	{
		Utility.stringBuilder.Remove(0, Utility.stringBuilder.Length);
		Utility.stringBuilder.Append(string_0);
		Utility.stringBuilder.Append(string_1);
		return Utility.stringBuilder.ToString();
	}

	// Token: 0x06002912 RID: 10514 RVA: 0x000C1EA4 File Offset: 0x000C00A4
	public static string smethod_6(string string_0, string string_1, string string_2)
	{
		Utility.stringBuilder.Remove(0, Utility.stringBuilder.Length);
		Utility.stringBuilder.Append(string_0);
		Utility.stringBuilder.Append(string_1);
		Utility.stringBuilder.Append(string_2);
		return Utility.stringBuilder.ToString();
	}

	// Token: 0x06002913 RID: 10515 RVA: 0x000C1EF8 File Offset: 0x000C00F8
	public static string smethod_7(string string_0, string string_1, string string_2, string string_3)
	{
		Utility.stringBuilder.Remove(0, Utility.stringBuilder.Length);
		Utility.stringBuilder.Append(string_0);
		Utility.stringBuilder.Append(string_1);
		Utility.stringBuilder.Append(string_2);
		Utility.stringBuilder.Append(string_3);
		return Utility.stringBuilder.ToString();
	}

	// Token: 0x06002914 RID: 10516 RVA: 0x0001AFAC File Offset: 0x000191AC
	public static string smethod_8(int int_0)
	{
		return Convert.ToString(int_0);
	}

	// Token: 0x06002915 RID: 10517 RVA: 0x0001AFB4 File Offset: 0x000191B4
	public static string smethod_9(float float_0)
	{
		return Convert.ToString(float_0);
	}

	// Token: 0x06002916 RID: 10518 RVA: 0x000C1F58 File Offset: 0x000C0158
	public static uint smethod_10(Stream stream_0)
	{
		Utility.smethod_3();
		long length = stream_0.Length;
		uint num = uint.MaxValue;
		for (long num2 = 0L; num2 < length; num2 += 1L)
		{
			byte b = (byte)stream_0.ReadByte();
			num = ((num >> 8) & 16777215U) ^ Utility.CRC32Table[(int)((UIntPtr)((num ^ (uint)b) & 255U))];
		}
		return num ^ uint.MaxValue;
	}

	// Token: 0x06002917 RID: 10519 RVA: 0x000C1FB8 File Offset: 0x000C01B8
	public static uint smethod_11(byte[] byte_0)
	{
		Utility.smethod_3();
		long num = (long)byte_0.Length;
		uint num2 = uint.MaxValue;
		for (long num3 = 0L; num3 < num; num3 += 1L)
		{
			byte b = byte_0[(int)(checked((IntPtr)num3))];
			num2 = ((num2 >> 8) & 16777215U) ^ Utility.CRC32Table[(int)((UIntPtr)((num2 ^ (uint)b) & 255U))];
		}
		return num2 ^ uint.MaxValue;
	}

	// Token: 0x06002918 RID: 10520 RVA: 0x000C2014 File Offset: 0x000C0214
	public static string smethod_12(int int_0, int int_1, bool bool_0 = false)
	{
		string text = string.Empty;
		int num = (((int_1 & 8) == 0) ? int_0 : (int_0 % 60));
		int num2 = (((int_1 & 4) == 0) ? (int_0 / 60) : (int_0 / 60 % 60));
		int num3 = (((int_1 & 2) == 0) ? (int_0 / 60 / 60) : (int_0 / 60 / 60 % 24));
		int num4 = int_0 / 60 / 60 / 24;
		if ((int_1 & 2) != 0 && (num4 > 0 || bool_0))
		{
			text = text + num4 + LocalizedString.smethod_0(new LocalizedString("Day"));
		}
		if ((int_1 & 4) != 0 && (num3 > 0 || bool_0))
		{
			text = text + num3 + LocalizedString.smethod_0(new LocalizedString("Hour"));
		}
		if ((int_1 & 8) != 0 && (num2 > 0 || bool_0))
		{
			text = text + num2 + LocalizedString.smethod_0(new LocalizedString("Minute"));
		}
		if ((int_1 & 16) != 0 && (num > 0 || bool_0))
		{
			text = text + num + LocalizedString.smethod_0(new LocalizedString("Second"));
		}
		return text;
	}

	// Token: 0x06002919 RID: 10521 RVA: 0x000C2110 File Offset: 0x000C0310
	public static string smethod_13(DateTime dateTime_0)
	{
		string text = LocalizedString.smethod_0(new LocalizedString("Offline"));
		TimeSpan timeSpan = DateTime.Now.Subtract(dateTime_0);
		if (timeSpan.Days != 0)
		{
			text = text + timeSpan.Days + LocalizedString.smethod_0(new LocalizedString("Day"));
		}
		else if (timeSpan.Hours != 0)
		{
			text = text + timeSpan.Hours + LocalizedString.smethod_0(new LocalizedString("Hour"));
		}
		else if (timeSpan.Minutes != 0)
		{
			text = text + timeSpan.Minutes + LocalizedString.smethod_0(new LocalizedString("Minute"));
		}
		else
		{
			text = text + "1" + LocalizedString.smethod_0(new LocalizedString("Minute"));
		}
		return text;
	}

	// Token: 0x0600291A RID: 10522 RVA: 0x0001AFBC File Offset: 0x000191BC
	public static float smethod_14(float float_0, float float_1, float float_2, float float_3, float float_4, float float_5, float float_6)
	{
		return float_0 + (float_1 - float_0) * (float_6 - float_3) / (float_4 - float_3) + ((float_2 - float_0) / (float_5 - float_3) - (float_1 - float_0) / (float_4 - float_3)) / (float_5 - float_4) * (float_6 - float_3) * (float_6 - float_4);
	}

	// Token: 0x0600291B RID: 10523 RVA: 0x000C21E0 File Offset: 0x000C03E0
	public static float smethod_15(float float_0, float float_1, float float_2, float float_3, float float_4, float float_5, float float_6)
	{
		float num = Math.Max(Math.Max(float_0, float_1), float_2);
		if (num - float_0 > 180f)
		{
			float_0 += 360f;
		}
		if (num - float_1 > 180f)
		{
			float_1 += 360f;
		}
		if (num - float_2 > 180f)
		{
			float_2 += 360f;
		}
		float num2 = Utility.smethod_14(float_0, float_1, float_2, float_3, float_4, float_5, float_6);
		return num2 % 360f;
	}

	// Token: 0x04001D5D RID: 7517
	private static uint[] CRC32Table = null;

	// Token: 0x04001D5E RID: 7518
	private static StringBuilder stringBuilder = new StringBuilder(32, 128);

	// Token: 0x0200065C RID: 1628
	public enum TimeComponent : byte
	{
		// Token: 0x04001D60 RID: 7520
		Day = 2,
		// Token: 0x04001D61 RID: 7521
		Hour = 4,
		// Token: 0x04001D62 RID: 7522
		Minute = 8,
		// Token: 0x04001D63 RID: 7523
		Second = 16
	}
}
