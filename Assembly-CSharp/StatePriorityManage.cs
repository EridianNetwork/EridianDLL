using System;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;

// Token: 0x0200009B RID: 155
public class StatePriorityManage
{
	// Token: 0x060003A5 RID: 933 RVA: 0x000053E9 File Offset: 0x000035E9
	public StatePriorityManage(PlayerAnimationManagerFSM playerAnimationManagerFSM_0)
	{
		this.m_Owner = playerAnimationManagerFSM_0;
		this.method_1();
	}

	// Token: 0x060003A6 RID: 934 RVA: 0x00047DE0 File Offset: 0x00045FE0
	public bool method_0(string string_0)
	{
		if (this.m_Owner.m_upperBodyStateMachine == null || this.m_Owner.m_upperBodyStateMachine.m_curState == null)
		{
			return false;
		}
		string stateName = this.m_Owner.m_upperBodyStateMachine.m_curState.StateName;
		if (this.m_infos.ContainsKey(stateName) && this.m_infos.ContainsKey(string_0))
		{
			int priority = this.m_infos[string_0].m_priority;
			int priority2 = this.m_infos[stateName].m_priority;
			return priority > priority2 || (priority == priority2 && this.m_infos[stateName].m_bCanOverrideSamePriority && this.m_infos[string_0].m_bCanOverrideSamePriority);
		}
		return true;
	}

	// Token: 0x060003A7 RID: 935 RVA: 0x00047EA0 File Offset: 0x000460A0
	private void method_1()
	{
		this.m_infos.Clear();
		TextAsset textAsset = Resources.Load("Entities/Player_Mecanim/Config_Animation_Priority", typeof(TextAsset)) as TextAsset;
		XmlDocument xmlDocument = new XmlDocument();
		xmlDocument.LoadXml(textAsset.text);
		XmlNode xmlNode = xmlDocument.GetElementsByTagName("States")[0];
		foreach (object obj in xmlNode.ChildNodes)
		{
			XmlNode xmlNode2 = (XmlNode)obj;
			string value = xmlNode2.Attributes["Name"].Value;
			int num = int.Parse(xmlNode2.Attributes["Priority"].Value);
			bool flag = bool.Parse(xmlNode2.Attributes["Override"].Value);
			this.m_infos.Add(value, new StatePriorityManage.PriorityInfo(num, flag));
		}
	}

	// Token: 0x040003A8 RID: 936
	private PlayerAnimationManagerFSM m_Owner;

	// Token: 0x040003A9 RID: 937
	private Dictionary<string, StatePriorityManage.PriorityInfo> m_infos = new Dictionary<string, StatePriorityManage.PriorityInfo>();

	// Token: 0x0200009C RID: 156
	public class PriorityInfo
	{
		// Token: 0x060003A8 RID: 936 RVA: 0x00005409 File Offset: 0x00003609
		public PriorityInfo(int int_0, bool bool_0)
		{
			this.m_priority = int_0;
			this.m_bCanOverrideSamePriority = bool_0;
		}

		// Token: 0x040003AA RID: 938
		public int m_priority;

		// Token: 0x040003AB RID: 939
		public bool m_bCanOverrideSamePriority;
	}
}
