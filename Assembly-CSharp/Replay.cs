using System;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;

// Token: 0x02000655 RID: 1621
[Serializable]
public class Replay
{
	// Token: 0x060028FC RID: 10492 RVA: 0x000C1634 File Offset: 0x000BF834
	public Replay(string string_0)
	{
		this.m_xmlfilename = string_0;
		this.m_replayxmldoc.Load(string_0);
		global::System.Random random = new global::System.Random();
		Color color = new Color(0.003921569f * (float)random.Next(0, 255), 0.003921569f * (float)random.Next(0, 255), 0.003921569f * (float)random.Next(0, 255));
		this.m_color = color;
	}

	// Token: 0x04001D46 RID: 7494
	public Vector3 m_last_pos;

	// Token: 0x04001D47 RID: 7495
	public List<ReplayPathnode> m_replayPathnodes = new List<ReplayPathnode>();

	// Token: 0x04001D48 RID: 7496
	public float m_replayspeed = 0.5f;

	// Token: 0x04001D49 RID: 7497
	public Vector3 m_v3target;

	// Token: 0x04001D4A RID: 7498
	public bool m_bismoving;

	// Token: 0x04001D4B RID: 7499
	public int m_itargetindex;

	// Token: 0x04001D4C RID: 7500
	public int m_imovedir = 1;

	// Token: 0x04001D4D RID: 7501
	public bool m_bpathloop;

	// Token: 0x04001D4E RID: 7502
	public string m_strplayername;

	// Token: 0x04001D4F RID: 7503
	public XmlDocument m_replayxmldoc = new XmlDocument();

	// Token: 0x04001D50 RID: 7504
	public Color m_color;

	// Token: 0x04001D51 RID: 7505
	public string m_xmlfilename;
}
