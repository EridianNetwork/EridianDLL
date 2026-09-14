using System;

// Token: 0x02000B7E RID: 2942
public class VPaintObjectNotDynamicException : Exception
{
	// Token: 0x1700080A RID: 2058
	// (get) Token: 0x06004F9D RID: 20381 RVA: 0x00033F58 File Offset: 0x00032158
	public override string Message
	{
		get
		{
			return "Method called requires VPaint Object to be dynamic. Set VPaintObject.isDynamic to true before calling this method.";
		}
	}
}
