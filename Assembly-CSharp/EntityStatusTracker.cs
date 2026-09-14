using System;
using ns0;

// Token: 0x02000082 RID: 130
public class EntityStatusTracker
{
	// Token: 0x060002B7 RID: 695 RVA: 0x000423E8 File Offset: 0x000405E8
	public void method_0(string string_0)
	{
		if (string.IsNullOrEmpty(string_0))
		{
			return;
		}
		if (this.m_previousRecord == string_0)
		{
			return;
		}
		this.m_previousRecord = string_0;
		char[] array = this.m_previousRecord.ToCharArray();
		for (int i = 0; i < array.Length; i++)
		{
			this.m_statusBuffer.Add(array[i]);
		}
	}

	// Token: 0x060002B8 RID: 696 RVA: 0x0004243C File Offset: 0x0004063C
	public string method_1()
	{
		if (this.m_statusBuffer != null && this.m_statusBuffer.Count != 0)
		{
			char[] array = new char[this.m_statusBuffer.Count];
			this.m_statusBuffer.CopyTo(array, 0);
			return new string(array);
		}
		return string.Empty;
	}

	// Token: 0x060002B9 RID: 697 RVA: 0x0000311B File Offset: 0x0000131B
	public void method_2(string string_0 = "EntityStatusTracker\n")
	{
	}

	// Token: 0x04000291 RID: 657
	private CircularBuffer<char> m_statusBuffer = new CircularBuffer<char>(200);

	// Token: 0x04000292 RID: 658
	private string m_previousRecord;
}
