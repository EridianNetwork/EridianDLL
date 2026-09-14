using System;
using System.Collections;

// Token: 0x020003CD RID: 973
public class Query
{
	// Token: 0x06001896 RID: 6294 RVA: 0x000125F8 File Offset: 0x000107F8
	public Query()
	{
		this.Parameters = new Hashtable();
		this.Operations = new Hashtable();
	}

	// Token: 0x06001897 RID: 6295 RVA: 0x00012616 File Offset: 0x00010816
	public void method_0(string string_0, object object_0, QueryComparisonType queryComparisonType_0 = QueryComparisonType.Equal)
	{
		this.Parameters[string_0] = object_0;
		this.Operations[string_0] = (byte)queryComparisonType_0;
	}

	// Token: 0x040010B2 RID: 4274
	public Hashtable Parameters;

	// Token: 0x040010B3 RID: 4275
	public Hashtable Operations;
}
