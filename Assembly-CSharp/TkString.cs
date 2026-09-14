using System;
using System.Collections.Generic;

// Token: 0x02000B68 RID: 2920
public static class TkString
{
	// Token: 0x06004F53 RID: 20307 RVA: 0x00033BCE File Offset: 0x00031DCE
	public static string smethod_0(List<string> list_0, string string_0)
	{
		return TkString.smethod_1(list_0.ToArray(), string_0);
	}

	// Token: 0x06004F54 RID: 20308 RVA: 0x001507E0 File Offset: 0x0014E9E0
	public static string smethod_1(string[] string_0, string string_1)
	{
		if (string_0 == null)
		{
			return string.Empty;
		}
		string text = string.Empty;
		for (int i = 0; i < string_0.Length; i++)
		{
			if (i > 0)
			{
				text += string_1;
			}
			text += string_0[i];
			i++;
		}
		return text;
	}

	// Token: 0x06004F55 RID: 20309 RVA: 0x00033BDC File Offset: 0x00031DDC
	public static string smethod_2(string string_0, string string_1, bool bool_0)
	{
		if (!string_0.StartsWith(string_1, bool_0, null))
		{
			return string.Empty;
		}
		return string_0.Substring(string_1.Length);
	}

	// Token: 0x06004F56 RID: 20310 RVA: 0x00033BFB File Offset: 0x00031DFB
	public static string smethod_3(string string_0, string string_1, bool bool_0)
	{
		if (!string_0.EndsWith(string_1, (!bool_0) ? StringComparison.Ordinal : StringComparison.OrdinalIgnoreCase))
		{
			return string.Empty;
		}
		return string_0.Substring(0, string_0.Length - string_1.Length);
	}

	// Token: 0x06004F57 RID: 20311 RVA: 0x00150828 File Offset: 0x0014EA28
	public static string smethod_4(string string_0, int int_0, params char[] char_0)
	{
		if (string_0 == null)
		{
			return null;
		}
		string[] array = string_0.Split(char_0);
		if (array != null && array.Length >= int_0)
		{
			return array[int_0];
		}
		return null;
	}

	// Token: 0x06004F58 RID: 20312 RVA: 0x00150850 File Offset: 0x0014EA50
	public static bool smethod_5<T>(out T gparam_0, string string_0, bool bool_0) where T : IConvertible, new()
	{
		bool flag;
		try
		{
			gparam_0 = (T)((object)Enum.Parse(typeof(T), string_0, bool_0));
			flag = true;
		}
		catch
		{
			gparam_0 = ((default(T) == null) ? new T() : default(T));
			flag = false;
		}
		return flag;
	}
}
