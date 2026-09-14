using System;
using ns0;

// Token: 0x02000783 RID: 1923
public class TestViewFactory
{
	// Token: 0x06003303 RID: 13059 RVA: 0x00003197 File Offset: 0x00001397
	private TestViewFactory()
	{
	}

	// Token: 0x06003304 RID: 13060 RVA: 0x0002136A File Offset: 0x0001F56A
	public static TestViewFactory smethod_0()
	{
		if (TestViewFactory.factory == null)
		{
			TestViewFactory.factory = new TestViewFactory();
		}
		return TestViewFactory.factory;
	}

	// Token: 0x06003305 RID: 13061 RVA: 0x000EA650 File Offset: 0x000E8850
	public void method_0(UniUIManager uniUIManager_0, TestViewFactory.ViewType viewType_0)
	{
		if (this.m_curView != null)
		{
			this.m_curView.vmethod_0();
			this.m_curView = null;
		}
		switch (viewType_0)
		{
		case TestViewFactory.ViewType.TestTeammateportrait:
			this.m_curView = new TeammatePortraitView(uniUIManager_0);
			break;
		case TestViewFactory.ViewType.TestWrapUp:
			this.m_curView = new WrapUpView(uniUIManager_0);
			break;
		case TestViewFactory.ViewType.Testmatchmaking:
			this.m_curView = new MatchmakingView(uniUIManager_0);
			break;
		}
	}

	// Token: 0x06003306 RID: 13062 RVA: 0x000EA6B8 File Offset: 0x000E88B8
	public TestViewFactory.ViewType method_1(string string_0)
	{
		string_0 = string_0.Replace(".swf", string.Empty);
		string_0 = "Test" + string_0.Replace("_", string.Empty).Replace(" ", string.Empty);
		TestViewFactory.ViewType viewType = TestViewFactory.ViewType.All;
		string[] names = Enum.GetNames(typeof(TestViewFactory.ViewType));
		for (int i = 0; i < names.Length; i++)
		{
			if (names[i] == string_0)
			{
				return (TestViewFactory.ViewType)i;
			}
		}
		return viewType;
	}

	// Token: 0x04002365 RID: 9061
	private static TestViewFactory factory;

	// Token: 0x04002366 RID: 9062
	private TestBaseView m_curView;

	// Token: 0x02000784 RID: 1924
	public enum ViewType
	{
		// Token: 0x04002368 RID: 9064
		TestTeammateportrait,
		// Token: 0x04002369 RID: 9065
		TestWrapUp,
		// Token: 0x0400236A RID: 9066
		Testmatchmaking,
		// Token: 0x0400236B RID: 9067
		All
	}
}
