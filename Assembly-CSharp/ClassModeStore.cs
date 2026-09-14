using System;

// Token: 0x020008CA RID: 2250
public class ClassModeStore
{
	// Token: 0x1700034D RID: 845
	// (get) Token: 0x06003E40 RID: 15936 RVA: 0x0002A0D7 File Offset: 0x000282D7
	// (set) Token: 0x06003E41 RID: 15937 RVA: 0x0002A0EF File Offset: 0x000282EF
	public static ClassModeStore ClassModeStore_0
	{
		get
		{
			if (ClassModeStore.s_classModeStore == null)
			{
				ClassModeStore.s_classModeStore = new ClassModeStore();
			}
			return ClassModeStore.s_classModeStore;
		}
		protected set
		{
			ClassModeStore.s_classModeStore = value;
		}
	}

	// Token: 0x04002BC8 RID: 11208
	public ClassModeAttribute m_classModeAttr = new ClassModeAttribute();

	// Token: 0x04002BC9 RID: 11209
	private static ClassModeStore s_classModeStore;
}
