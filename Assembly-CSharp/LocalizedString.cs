using System;
using System.Text.RegularExpressions;
using Core;

// Token: 0x020005F6 RID: 1526
public class LocalizedString : ILocalizedContent
{
	// Token: 0x060026C3 RID: 9923 RVA: 0x0001A115 File Offset: 0x00018315
	private LocalizedString()
	{
	}

	// Token: 0x060026C4 RID: 9924 RVA: 0x0001A133 File Offset: 0x00018333
	public LocalizedString(string string_0)
	{
		this._codeValue = string_0;
		LocalizeSystem.smethod_0().vmethod_0(this);
	}

	// Token: 0x060026C5 RID: 9925 RVA: 0x0001A163 File Offset: 0x00018363
	public LocalizedString(string string_0, string[] string_1)
	{
		this._codeValue = string_0;
		LocalizeSystem.smethod_0().vmethod_0(this);
		this._arrParamString = string_1;
	}

	// Token: 0x170001EA RID: 490
	// (get) Token: 0x060026C7 RID: 9927 RVA: 0x0001A1AB File Offset: 0x000183AB
	public string String_0
	{
		get
		{
			return this._codeValue;
		}
	}

	// Token: 0x060026C8 RID: 9928 RVA: 0x000BB370 File Offset: 0x000B9570
	protected virtual string vmethod_0(Match match_0)
	{
		string text = match_0.Value.Substring(2, match_0.Value.Length - 3);
		int num = -1;
		if (int.TryParse(text, out num) && num >= 0 && num < this._arrParamString.Length)
		{
			return this._arrParamString[num];
		}
		DebugUtils.LogWarning(LogCategory.GUI, string.Concat(new string[] { "Localize parameter wrong! Key: ", this._codeValue, " Language string: ", this._lanValue, "  !!@ ", match_0.Value, " can not be substituted!" }));
		return match_0.Value;
	}

	// Token: 0x060026C9 RID: 9929 RVA: 0x0001A1AB File Offset: 0x000183AB
	public override string ToString()
	{
		return this._codeValue;
	}

	// Token: 0x060026CA RID: 9930 RVA: 0x0001A1B3 File Offset: 0x000183B3
	public void method_0(string string_0)
	{
		this._lanValue = string_0;
	}

	// Token: 0x060026CB RID: 9931 RVA: 0x000BB410 File Offset: 0x000B9610
	public static string smethod_0(LocalizedString localizedString_0)
	{
		if (localizedString_0._lanValue != string.Empty)
		{
			return LocalizedString.regex.Replace(localizedString_0._lanValue, new MatchEvaluator(localizedString_0.vmethod_0));
		}
		return "!-- " + localizedString_0._codeValue + "--!";
	}

	// Token: 0x04001C33 RID: 7219
	private string _lanValue = string.Empty;

	// Token: 0x04001C34 RID: 7220
	private string _codeValue = string.Empty;

	// Token: 0x04001C35 RID: 7221
	private string[] _arrParamString;

	// Token: 0x04001C36 RID: 7222
	private static Regex regex = new Regex("\\{P(\\d+)\\}");
}
