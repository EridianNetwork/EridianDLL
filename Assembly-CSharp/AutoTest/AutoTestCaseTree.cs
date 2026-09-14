using System;

namespace AutoTest
{
	// Token: 0x02000637 RID: 1591
	internal class AutoTestCaseTree
	{
		// Token: 0x06002868 RID: 10344 RVA: 0x000BE0B8 File Offset: 0x000BC2B8
		public AutoTestCase FindCase(string caseName)
		{
			if (this.m_testCaseNodes != null)
			{
				for (int i = 0; i < this.m_testCaseNodes.Length; i++)
				{
					foreach (AutoTestCase autoTestCase in this.m_testCaseNodes[i].m_cases)
					{
						if (autoTestCase.Name == caseName)
						{
							return autoTestCase;
						}
					}
				}
			}
			return null;
		}

		// Token: 0x06002869 RID: 10345 RVA: 0x000BE13C File Offset: 0x000BC33C
		public void Construct(string[] names, AutoTestManager mgr)
		{
			if (this.m_curCaseNode != null)
			{
				return;
			}
			this.m_testCaseNodes = new AutoTestCaseNode[names.Length];
			for (int i = 0; i < names.Length; i++)
			{
				string text = names[i].Trim();
				this.m_testCaseNodes[i] = new AutoTestCaseNode();
				string[] array = text.Split(new char[] { '|' });
				for (int j = 0; j < array.Length; j++)
				{
					string text2 = array[j].Trim();
					this.m_testCaseNodes[i].AddTestCase(text2, mgr, i, j);
				}
			}
			int[] array2 = new int[names.Length];
			for (int k = 0; k < names.Length; k++)
			{
				array2[k] = this.GetDepth(names[k]);
			}
			for (int l = 1; l < names.Length; l++)
			{
				int num = array2[l - 1];
				int num2 = array2[l];
				AutoTestCaseNode autoTestCaseNode = this.m_testCaseNodes[l - 1];
				AutoTestCaseNode autoTestCaseNode2 = this.m_testCaseNodes[l];
				if (num2 == num)
				{
					autoTestCaseNode.m_nextSibling = autoTestCaseNode2;
					autoTestCaseNode2.m_parent = autoTestCaseNode.m_parent;
				}
				else if (num2 > num)
				{
					autoTestCaseNode.m_firstChild = autoTestCaseNode2;
					autoTestCaseNode2.m_parent = autoTestCaseNode;
				}
				else if (num2 < num)
				{
					int m;
					for (m = l - 2; m >= 0; m--)
					{
						if (num2 == array2[m])
						{
							break;
						}
					}
					AutoTestCaseNode autoTestCaseNode3 = this.m_testCaseNodes[m];
					autoTestCaseNode3.m_nextSibling = autoTestCaseNode2;
					autoTestCaseNode2.m_parent = autoTestCaseNode3.m_parent;
				}
			}
			if (this.m_testCaseNodes.Length > 0)
			{
				this.m_curCaseNode = this.m_testCaseNodes[0];
			}
		}

		// Token: 0x0600286A RID: 10346 RVA: 0x000BE2C4 File Offset: 0x000BC4C4
		public void Update()
		{
			if (this.m_curCaseNode != null)
			{
				if (this.m_curCaseNode.Closed)
				{
					if (this.m_curCaseNode.Pass && this.m_curCaseNode.m_firstChild != null && !this.m_curCaseNode.m_firstChild.Closed)
					{
						this.m_curCaseNode = this.m_curCaseNode.m_firstChild;
					}
					else if (this.m_curCaseNode.m_nextSibling != null && !this.m_curCaseNode.m_nextSibling.Closed)
					{
						this.m_curCaseNode = this.m_curCaseNode.m_nextSibling;
					}
					else
					{
						this.m_curCaseNode = this.m_curCaseNode.m_parent;
					}
				}
				else if (!this.m_curCaseNode.Started)
				{
					this.m_curCaseNode.StartTest();
				}
				else
				{
					this.m_curCaseNode.Update();
				}
			}
		}

		// Token: 0x0600286B RID: 10347 RVA: 0x000BE398 File Offset: 0x000BC598
		private int GetDepth(string name)
		{
			name = name.TrimEnd(new char[0]);
			int num = 0;
			int num2 = 0;
			for (;;)
			{
				num2 = name.IndexOf("  ", num2);
				if (num2 < 0)
				{
					break;
				}
				num++;
				num2 += 2;
			}
			return num;
		}

		// Token: 0x04001CA5 RID: 7333
		public AutoTestCaseNode m_curCaseNode;

		// Token: 0x04001CA6 RID: 7334
		public AutoTestCaseNode[] m_testCaseNodes;
	}
}
