using System;
using System.Collections.Generic;

// Token: 0x020006EC RID: 1772
public class ChatStringMaker
{
	// Token: 0x06002EDF RID: 11999 RVA: 0x000D9148 File Offset: 0x000D7348
	private bool method_0(int int_0, out int int_1)
	{
		int num = 0;
		int num2 = 0;
		foreach (ChatStringMaker.InputInfo inputInfo in this.m_arrInputInfoList)
		{
			if (int_0 == num)
			{
				int_1 = num2;
				return false;
			}
			num += inputInfo.strValue.Length;
			if (int_0 < num)
			{
				int_1 = num2;
				return true;
			}
			num2++;
		}
		int_1 = this.m_arrInputInfoList.Count;
		return false;
	}

	// Token: 0x06002EE0 RID: 12000 RVA: 0x000D91D8 File Offset: 0x000D73D8
	public void method_1(int int_0, string string_0)
	{
		int num = 0;
		if (this.method_0(int_0, out num))
		{
			return;
		}
		for (int i = 0; i < string_0.Length; i++)
		{
			ChatStringMaker.InputInfo inputInfo;
			inputInfo.inputType = ChatStringMaker.ChatInputType.CT_Text;
			inputInfo.strValue = string_0[i].ToString();
			inputInfo.strTransValue = string_0[i].ToString();
			inputInfo.strViewValue = string_0[i].ToString();
			if (this._iMaxChars > 0 && this.method_9() + inputInfo.strValue.Length > this._iMaxChars)
			{
				return;
			}
			this.m_arrInputInfoList.Insert(num++, inputInfo);
		}
	}

	// Token: 0x06002EE1 RID: 12001 RVA: 0x000D928C File Offset: 0x000D748C
	public void method_2(int int_0, ChatStringMaker.InputInfo inputInfo_0)
	{
		int num;
		if (this.method_0(int_0, out num))
		{
			return;
		}
		if (this._iMaxChars > 0 && this.method_9() + inputInfo_0.strValue.Length > this._iMaxChars)
		{
			return;
		}
		this.m_arrInputInfoList.Insert(num, inputInfo_0);
	}

	// Token: 0x06002EE2 RID: 12002 RVA: 0x000D92D8 File Offset: 0x000D74D8
	public void method_3(int int_0, int int_1 = 1)
	{
		if (this.m_arrInputInfoList.Count == 0)
		{
			return;
		}
		int num = 1;
		int num2;
		this.method_0(int_0, out num2);
		if (int_1 > 1)
		{
			int num3;
			this.method_0(int_0 + int_1, out num3);
			num = num3 - num2;
		}
		if (num2 >= 0 && num >= 0)
		{
			this.m_arrInputInfoList.RemoveRange(num2, num);
		}
	}

	// Token: 0x06002EE3 RID: 12003 RVA: 0x0001EEB7 File Offset: 0x0001D0B7
	public void method_4()
	{
		this.m_arrInputInfoList.Clear();
	}

	// Token: 0x06002EE4 RID: 12004 RVA: 0x000D9328 File Offset: 0x000D7528
	public int method_5(int int_0, bool bool_0 = true)
	{
		int num = Math.Max(Math.Min(this.method_9(), int_0), 0);
		int num2;
		if (this.method_0(int_0, out num2))
		{
			num = 0;
			if (bool_0)
			{
				num2++;
			}
			for (int i = 0; i < num2; i++)
			{
				num += this.m_arrInputInfoList[i].strValue.Length;
			}
		}
		return num;
	}

	// Token: 0x06002EE5 RID: 12005 RVA: 0x000D9388 File Offset: 0x000D7588
	public string method_6(int int_0, int int_1)
	{
		if (int_1 < int_0)
		{
			return string.Empty;
		}
		string text = string.Empty;
		int i;
		this.method_0(int_0, out i);
		int num;
		this.method_0(int_1, out num);
		while (i <= num)
		{
			text += this.m_arrInputInfoList[i].strValue;
			i++;
		}
		return text;
	}

	// Token: 0x06002EE6 RID: 12006 RVA: 0x000D93E0 File Offset: 0x000D75E0
	public string method_7()
	{
		string text = string.Empty;
		foreach (ChatStringMaker.InputInfo inputInfo in this.m_arrInputInfoList)
		{
			text += inputInfo.strViewValue;
		}
		text = this._strPreText + text;
		return text;
	}

	// Token: 0x06002EE7 RID: 12007 RVA: 0x000D9450 File Offset: 0x000D7650
	public string method_8()
	{
		string text = string.Empty;
		foreach (ChatStringMaker.InputInfo inputInfo in this.m_arrInputInfoList)
		{
			text += inputInfo.strTransValue;
		}
		return text;
	}

	// Token: 0x06002EE8 RID: 12008 RVA: 0x000D94B0 File Offset: 0x000D76B0
	public int method_9()
	{
		int num = 0;
		foreach (ChatStringMaker.InputInfo inputInfo in this.m_arrInputInfoList)
		{
			num += inputInfo.strValue.Length;
		}
		return num;
	}

	// Token: 0x06002EE9 RID: 12009 RVA: 0x0001EEC4 File Offset: 0x0001D0C4
	public void method_10(int int_0)
	{
		this._iMaxChars = Math.Max(int_0, 0);
	}

	// Token: 0x06002EEA RID: 12010 RVA: 0x0001EED3 File Offset: 0x0001D0D3
	public void method_11(string string_0)
	{
		this._strPreText = string_0;
	}

	// Token: 0x06002EEB RID: 12011 RVA: 0x0001EEDC File Offset: 0x0001D0DC
	public string method_12()
	{
		return this._strPreText;
	}

	// Token: 0x040020CE RID: 8398
	protected List<ChatStringMaker.InputInfo> m_arrInputInfoList = new List<ChatStringMaker.InputInfo>();

	// Token: 0x040020CF RID: 8399
	private int _iMaxChars;

	// Token: 0x040020D0 RID: 8400
	private string m_strID;

	// Token: 0x040020D1 RID: 8401
	private string _strPreText;

	// Token: 0x020006ED RID: 1773
	public enum ChatInputType
	{
		// Token: 0x040020D3 RID: 8403
		CT_Text,
		// Token: 0x040020D4 RID: 8404
		CT_Weapon,
		// Token: 0x040020D5 RID: 8405
		CT_Mat
	}

	// Token: 0x020006EE RID: 1774
	public struct InputInfo
	{
		// Token: 0x040020D6 RID: 8406
		public ChatStringMaker.ChatInputType inputType;

		// Token: 0x040020D7 RID: 8407
		public string strValue;

		// Token: 0x040020D8 RID: 8408
		public string strViewValue;

		// Token: 0x040020D9 RID: 8409
		public string strTransValue;
	}
}
