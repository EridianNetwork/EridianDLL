using System;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;

// Token: 0x02000095 RID: 149
public class MecanimAnimatorGraph
{
	// Token: 0x06000331 RID: 817 RVA: 0x00004E2A File Offset: 0x0000302A
	public MecanimAnimatorGraph(PlayerAnimationManagerFSM playerAnimationManagerFSM_0)
	{
		this.m_Owner = playerAnimationManagerFSM_0;
		this.method_11();
	}

	// Token: 0x1700001A RID: 26
	// (get) Token: 0x06000332 RID: 818 RVA: 0x00004E67 File Offset: 0x00003067
	// (set) Token: 0x06000333 RID: 819 RVA: 0x00004E6F File Offset: 0x0000306F
	private MecanimAnimationID MecanimAnimationID_0
	{
		get
		{
			return this.m_inner_currentAnimationID;
		}
		set
		{
			this.m_inner_currentAnimationID = value;
			this.m_startTime = -1f;
		}
	}

	// Token: 0x06000334 RID: 820 RVA: 0x000452C4 File Offset: 0x000434C4
	public void method_0(MecanimAnimationID mecanimAnimationID_0)
	{
		if (mecanimAnimationID_0 == this.MecanimAnimationID_0 && mecanimAnimationID_0 != MecanimAnimationID.ID_1st_CrouchIdle && mecanimAnimationID_0 != MecanimAnimationID.ID_1st_StandIdle)
		{
			return;
		}
		if (this.method_7(mecanimAnimationID_0) >= this.method_7(this.MecanimAnimationID_0))
		{
			this.method_10();
			this.m_Owner.m_firstPersonAnimator.SetBool(this.m_Nodes[(int)mecanimAnimationID_0].m_parameter, true);
			this.MecanimAnimationID_0 = mecanimAnimationID_0;
		}
		if (this.method_7(mecanimAnimationID_0) >= 4)
		{
			this.method_2(true);
		}
	}

	// Token: 0x06000335 RID: 821 RVA: 0x00004E83 File Offset: 0x00003083
	public void method_1(string string_0, int int_0, float float_0)
	{
		if (float_0 > 0f && this.method_8(string_0) >= this.method_7(this.MecanimAnimationID_0))
		{
			this.m_Owner.m_firstPersonAnimator.CrossFade(string_0, float_0, int_0);
		}
	}

	// Token: 0x06000336 RID: 822 RVA: 0x00045338 File Offset: 0x00043538
	private void method_2(bool bool_0)
	{
		if (bool_0)
		{
			this.m_Owner.m_firstPersonAnimator.SetBool("bFire", false);
			this.m_Owner.m_firstPersonAnimator.SetBool("bRecoilExit_1st", true);
			this.m_recoilExitTick = Time.frameCount;
		}
		else if (this.m_Owner.m_firstPersonAnimator.GetBool("bRecoilExit_1st") && Time.frameCount - this.m_recoilExitTick > 3)
		{
			this.m_Owner.m_firstPersonAnimator.SetBool("bRecoilExit_1st", false);
		}
	}

	// Token: 0x06000337 RID: 823 RVA: 0x00004EB5 File Offset: 0x000030B5
	public bool method_3(MecanimAnimationID mecanimAnimationID_0)
	{
		return mecanimAnimationID_0 == this.MecanimAnimationID_0;
	}

	// Token: 0x06000338 RID: 824 RVA: 0x00004EC0 File Offset: 0x000030C0
	public void method_4(MecanimAnimationID mecanimAnimationID_0)
	{
		if (mecanimAnimationID_0 != this.MecanimAnimationID_0)
		{
			return;
		}
		this.m_Owner.m_firstPersonAnimator.SetBool(this.m_Nodes[(int)mecanimAnimationID_0].m_parameter, false);
		this.MecanimAnimationID_0 = MecanimAnimationID.ID_1st_None;
	}

	// Token: 0x06000339 RID: 825 RVA: 0x000453C0 File Offset: 0x000435C0
	public void Update()
	{
		if (this.m_Owner.m_firstPersonAnimator == null)
		{
			return;
		}
		if (this.method_9(this.MecanimAnimationID_0) > 0f)
		{
			AnimatorStateInfo currentAnimatorStateInfo = this.m_Owner.m_firstPersonAnimator.GetCurrentAnimatorStateInfo(0);
			if (!currentAnimatorStateInfo.IsTag(this.method_6(this.MecanimAnimationID_0)))
			{
				return;
			}
			if (this.m_startTime < 0f)
			{
				this.m_startTime = currentAnimatorStateInfo.normalizedTime;
			}
			if (currentAnimatorStateInfo.normalizedTime < 1f && this.m_startTime > 1f)
			{
				this.m_startTime = this.method_12(this.m_startTime);
			}
			if (currentAnimatorStateInfo.normalizedTime >= Mathf.Floor(this.m_startTime) + this.method_9(this.MecanimAnimationID_0))
			{
				this.m_startTime = -1f;
				this.MecanimAnimationID_0 = MecanimAnimationID.ID_1st_None;
			}
		}
		this.method_2(false);
	}

	// Token: 0x0600033A RID: 826 RVA: 0x00004EF5 File Offset: 0x000030F5
	private void method_5(MecanimAnimationID mecanimAnimationID_0)
	{
		(this.m_Owner.m_upperBodyStateMachine.m_curState as PlayerAnimationState).OnMecanimAnimOver(mecanimAnimationID_0);
	}

	// Token: 0x0600033B RID: 827 RVA: 0x00004F12 File Offset: 0x00003112
	public string method_6(MecanimAnimationID mecanimAnimationID_0)
	{
		if (mecanimAnimationID_0 == MecanimAnimationID.ID_1st_None)
		{
			return string.Empty;
		}
		return this.m_Nodes[(int)mecanimAnimationID_0].m_tag;
	}

	// Token: 0x0600033C RID: 828 RVA: 0x00004F2F File Offset: 0x0000312F
	private int method_7(MecanimAnimationID mecanimAnimationID_0)
	{
		if (mecanimAnimationID_0 == MecanimAnimationID.ID_1st_None)
		{
			return -1;
		}
		return this.m_Nodes[(int)mecanimAnimationID_0].m_priority;
	}

	// Token: 0x0600033D RID: 829 RVA: 0x000454A0 File Offset: 0x000436A0
	private int method_8(string string_0)
	{
		if (!(string_0 == "Aim") && !(string_0 == "Idle_Aim"))
		{
			foreach (KeyValuePair<int, MecanimAnimatorGraph.MecanimAnimatorNode> keyValuePair in this.m_Nodes)
			{
				if (keyValuePair.Value.m_tag == string_0)
				{
					return keyValuePair.Value.m_priority;
				}
			}
			return -1;
		}
		return this.m_Nodes[11].m_priority;
	}

	// Token: 0x0600033E RID: 830 RVA: 0x00004F48 File Offset: 0x00003148
	private float method_9(MecanimAnimationID mecanimAnimationID_0)
	{
		if (mecanimAnimationID_0 == MecanimAnimationID.ID_1st_None)
		{
			return -1f;
		}
		return this.m_Nodes[(int)mecanimAnimationID_0].m_ExitTime;
	}

	// Token: 0x0600033F RID: 831 RVA: 0x00045540 File Offset: 0x00043740
	private void method_10()
	{
		Dictionary<int, MecanimAnimatorGraph.MecanimAnimatorNode>.Enumerator enumerator = this.m_Nodes.GetEnumerator();
		while (enumerator.MoveNext())
		{
			Animator firstPersonAnimator = this.m_Owner.m_firstPersonAnimator;
			KeyValuePair<int, MecanimAnimatorGraph.MecanimAnimatorNode> keyValuePair = enumerator.Current;
			firstPersonAnimator.SetBool(keyValuePair.Value.m_parameter, false);
		}
	}

	// Token: 0x06000340 RID: 832 RVA: 0x0004558C File Offset: 0x0004378C
	private void method_11()
	{
		this.m_Nodes.Clear();
		this.m_parameterNameList.Clear();
		TextAsset textAsset = Resources.Load("Entities/Player_Mecanim/Config_Animation_Priority", typeof(TextAsset)) as TextAsset;
		XmlDocument xmlDocument = new XmlDocument();
		xmlDocument.LoadXml(textAsset.text);
		XmlNode xmlNode = xmlDocument.GetElementsByTagName("Animations")[0];
		foreach (object obj in xmlNode.ChildNodes)
		{
			XmlNode xmlNode2 = (XmlNode)obj;
			string value = xmlNode2.Attributes["ID"].Value;
			MecanimAnimationID mecanimAnimationID = (MecanimAnimationID)((int)Enum.Parse(typeof(MecanimAnimationID), value));
			string value2 = xmlNode2.Attributes["Parameter"].Value;
			string value3 = xmlNode2.Attributes["Tag"].Value;
			int num = int.Parse(xmlNode2.Attributes["Priority"].Value);
			float num2 = float.Parse(xmlNode2.Attributes["ExitTime"].Value);
			this.m_Nodes.Add((int)mecanimAnimationID, new MecanimAnimatorGraph.MecanimAnimatorNode(value2, value3, num, num2));
			this.m_parameterNameList.Add(value2);
		}
	}

	// Token: 0x06000341 RID: 833 RVA: 0x00004F65 File Offset: 0x00003165
	private float method_12(float float_0)
	{
		return float_0 - Mathf.Floor(float_0);
	}

	// Token: 0x06000342 RID: 834 RVA: 0x00004F6F File Offset: 0x0000316F
	public List<string> method_13()
	{
		return this.m_parameterNameList;
	}

	// Token: 0x04000361 RID: 865
	public Dictionary<int, MecanimAnimatorGraph.MecanimAnimatorNode> m_Nodes = new Dictionary<int, MecanimAnimatorGraph.MecanimAnimatorNode>();

	// Token: 0x04000362 RID: 866
	private List<string> m_parameterNameList = new List<string>();

	// Token: 0x04000363 RID: 867
	private PlayerAnimationManagerFSM m_Owner;

	// Token: 0x04000364 RID: 868
	private MecanimAnimationID m_inner_currentAnimationID = MecanimAnimationID.ID_1st_SwitchUp;

	// Token: 0x04000365 RID: 869
	private float m_startTime = -1f;

	// Token: 0x04000366 RID: 870
	private int m_recoilExitTick;

	// Token: 0x02000096 RID: 150
	public class MecanimAnimatorNode
	{
		// Token: 0x06000343 RID: 835 RVA: 0x00004F77 File Offset: 0x00003177
		public MecanimAnimatorNode(string string_0, string string_1, int int_0, float float_0)
		{
			this.m_parameter = string_0;
			this.m_tag = string_1;
			this.m_priority = int_0;
			this.m_ExitTime = float_0;
		}

		// Token: 0x04000367 RID: 871
		public string m_parameter;

		// Token: 0x04000368 RID: 872
		public string m_tag;

		// Token: 0x04000369 RID: 873
		public int m_priority;

		// Token: 0x0400036A RID: 874
		public float m_ExitTime;
	}
}
