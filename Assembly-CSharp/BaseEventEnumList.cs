using System;
using System.Collections.Generic;

// Token: 0x02000ACE RID: 2766
public class BaseEventEnumList
{
	// Token: 0x06004B40 RID: 19264 RVA: 0x00031192 File Offset: 0x0002F392
	public BaseEventEnumList()
	{
		this.method_0();
	}

	// Token: 0x06004B41 RID: 19265 RVA: 0x000311AB File Offset: 0x0002F3AB
	public void method_0()
	{
		this.DicData.Add(0, "111");
		this.DicData.Add(1, "222");
		this.DicData.Add(2, "333");
	}

	// Token: 0x040036A5 RID: 13989
	public Dictionary<int, string> DicData = new Dictionary<int, string>();
}
