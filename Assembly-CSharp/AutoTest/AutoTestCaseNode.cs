using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace AutoTest
{
	// Token: 0x02000638 RID: 1592
	internal class AutoTestCaseNode
	{
		// Token: 0x170001FA RID: 506
		// (get) Token: 0x0600286D RID: 10349 RVA: 0x000BE3D8 File Offset: 0x000BC5D8
		public bool Closed
		{
			get
			{
				foreach (AutoTestCase autoTestCase in this.m_cases)
				{
					if (!autoTestCase.Closed)
					{
						return false;
					}
				}
				return true;
			}
		}

		// Token: 0x170001FB RID: 507
		// (get) Token: 0x0600286E RID: 10350 RVA: 0x000BE434 File Offset: 0x000BC634
		public bool Pass
		{
			get
			{
				foreach (AutoTestCase autoTestCase in this.m_cases)
				{
					if (!autoTestCase.Pass)
					{
						return false;
					}
				}
				return true;
			}
		}

		// Token: 0x170001FC RID: 508
		// (get) Token: 0x0600286F RID: 10351 RVA: 0x000BE490 File Offset: 0x000BC690
		public bool Started
		{
			get
			{
				foreach (AutoTestCase autoTestCase in this.m_cases)
				{
					if (!autoTestCase.Started)
					{
						return false;
					}
				}
				return true;
			}
		}

		// Token: 0x06002870 RID: 10352 RVA: 0x000BE4EC File Offset: 0x000BC6EC
		public void StartTest()
		{
			foreach (AutoTestCase autoTestCase in this.m_cases)
			{
				autoTestCase.StartTest();
			}
		}

		// Token: 0x06002871 RID: 10353 RVA: 0x000BE540 File Offset: 0x000BC740
		public void Update()
		{
			foreach (AutoTestCase autoTestCase in this.m_cases)
			{
				autoTestCase.Update();
			}
		}

		// Token: 0x06002872 RID: 10354 RVA: 0x000BE594 File Offset: 0x000BC794
		public void PrintInfoOnScreen()
		{
			Color contentColor = GUI.contentColor;
			GUI.contentColor = Color.yellow;
			GUILayout.BeginArea(new Rect(610f, 10f, 600f, 800f));
			GUILayout.BeginVertical(new GUILayoutOption[0]);
			if (this.m_infoStart > 0)
			{
				if (GUILayout.Button("[up]", new GUILayoutOption[0]))
				{
					this.m_infoStart--;
				}
			}
			else
			{
				GUILayout.Label(string.Empty, new GUILayoutOption[0]);
			}
			int num = this.m_infoStart;
			while (num < this.m_cases.Count && num < this.m_infoStart + 20)
			{
				AutoTestCase autoTestCase = this.m_cases[num];
				if (autoTestCase.Started)
				{
					string text = autoTestCase.Name + "[" + autoTestCase.Status + "]";
					if (autoTestCase.Status == "Closed")
					{
						text += autoTestCase.Pass;
					}
					GUILayout.Label(text, new GUILayoutOption[0]);
				}
				num++;
			}
			if (this.m_infoStart + 20 < this.m_cases.Count && GUILayout.Button("[down]", new GUILayoutOption[0]))
			{
				this.m_infoStart++;
			}
			GUILayout.EndVertical();
			GUILayout.EndArea();
			GUI.contentColor = contentColor;
		}

		// Token: 0x06002873 RID: 10355 RVA: 0x000BE6E4 File Offset: 0x000BC8E4
		public void AddTestCase(string caseName, AutoTestManager autoTestComponent, int row, int col)
		{
			string text = this.TrimParams(caseName);
			Assembly executingAssembly = Assembly.GetExecutingAssembly();
			Type type = executingAssembly.GetType("AutoTest.AutoTestCase_" + text);
			AutoTestCase autoTestCase = (AutoTestCase)Activator.CreateInstance(type);
			autoTestCase.Name = string.Format("[{0}|{1}]{2}", row, col, caseName);
			autoTestCase.PostInit(caseName);
			this.m_cases.Add(autoTestCase);
		}

		// Token: 0x06002874 RID: 10356 RVA: 0x000BE750 File Offset: 0x000BC950
		private string TrimParams(string _fullName)
		{
			int num = _fullName.IndexOf('(');
			if (num != -1)
			{
				return _fullName.Substring(0, num);
			}
			return _fullName;
		}

		// Token: 0x04001CA7 RID: 7335
		public AutoTestCaseNode m_parent;

		// Token: 0x04001CA8 RID: 7336
		public AutoTestCaseNode m_nextSibling;

		// Token: 0x04001CA9 RID: 7337
		public AutoTestCaseNode m_firstChild;

		// Token: 0x04001CAA RID: 7338
		public List<AutoTestCase> m_cases = new List<AutoTestCase>();

		// Token: 0x04001CAB RID: 7339
		private int m_infoStart;
	}
}
