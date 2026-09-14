using System;
using System.Collections.Generic;
using System.IO;

// Token: 0x02000B65 RID: 2917
public class TkFileUtil
{
	// Token: 0x06004F26 RID: 20262 RVA: 0x00150438 File Offset: 0x0014E638
	public static void smethod_0(string string_0, string string_1, bool bool_0)
	{
		DirectoryInfo directoryInfo = new DirectoryInfo(string_0);
		DirectoryInfo[] directories = directoryInfo.GetDirectories();
		if (!directoryInfo.Exists)
		{
			throw new DirectoryNotFoundException("Source directory does not exist or could not be found: " + string_0);
		}
		if (!Directory.Exists(string_1))
		{
			Directory.CreateDirectory(string_1);
		}
		foreach (FileInfo fileInfo in directoryInfo.GetFiles())
		{
			string text = Path.Combine(string_1, fileInfo.Name);
			fileInfo.CopyTo(text, true);
		}
		if (bool_0)
		{
			foreach (DirectoryInfo directoryInfo2 in directories)
			{
				string text2 = Path.Combine(string_1, directoryInfo2.Name);
				TkFileUtil.smethod_0(directoryInfo2.FullName, text2, bool_0);
			}
		}
	}

	// Token: 0x06004F27 RID: 20263 RVA: 0x001504E8 File Offset: 0x0014E6E8
	public static string[] smethod_1(string string_0)
	{
		List<string> list = new List<string>();
		TkFileUtil.smethod_2(string_0, ref list);
		return list.ToArray();
	}

	// Token: 0x06004F28 RID: 20264 RVA: 0x0015050C File Offset: 0x0014E70C
	private static void smethod_2(string string_0, ref List<string> list_0)
	{
		if (Directory.Exists(string_0))
		{
			string[] files = Directory.GetFiles(string_0);
			for (int i = 0; i < files.Length; i++)
			{
				list_0.Add(files[i]);
			}
			string[] directories = Directory.GetDirectories(string_0);
			for (int j = 0; j < directories.Length; j++)
			{
				TkFileUtil.smethod_2(directories[j], ref list_0);
			}
		}
		if (File.Exists(string_0))
		{
			list_0.Add(string_0);
			return;
		}
	}

	// Token: 0x06004F29 RID: 20265 RVA: 0x00150570 File Offset: 0x0014E770
	public static long smethod_3(string string_0, string string_1)
	{
		FileInfo fileInfo = new FileInfo(string_0);
		FileInfo fileInfo2 = new FileInfo(string_1);
		return fileInfo2.LastWriteTimeUtc.Ticks - fileInfo.LastWriteTimeUtc.Ticks;
	}

	// Token: 0x06004F2A RID: 20266 RVA: 0x0003392A File Offset: 0x00031B2A
	public static bool smethod_4(string string_0)
	{
		if (!File.Exists(string_0))
		{
			return false;
		}
		File.SetAttributes(string_0, FileAttributes.Normal);
		File.Delete(string_0);
		return true;
	}

	// Token: 0x06004F2B RID: 20267 RVA: 0x001505A8 File Offset: 0x0014E7A8
	public static string smethod_5(string string_0, string string_1)
	{
		string_0 = string_0.Replace('\\', '/');
		if (string_0.StartsWith("/"))
		{
			string_0 = "Assets" + string_0;
		}
		else
		{
			string_0 = Path.GetDirectoryName(string_1) + "/" + string_0;
		}
		string_0 = Path.GetFullPath(string_0).Replace('\\', '/');
		string text = Directory.GetCurrentDirectory().Replace('\\', '/');
		string_0 = TkString.smethod_2(string_0, text + "/", true);
		return string_0;
	}
}
