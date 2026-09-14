using System;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;

// Token: 0x02000656 RID: 1622
[ExecuteInEditMode]
public class RePlayer : MonoBehaviour
{
	// Token: 0x060028FE RID: 10494 RVA: 0x000C16D0 File Offset: 0x000BF8D0
	public void Update()
	{
		if (this.m_playerreplay == null)
		{
			return;
		}
		if (this.m_playerreplay.m_replayPathnodes.Count <= this.targetindex)
		{
			return;
		}
		Vector3 pos = this.m_playerreplay.m_replayPathnodes[this.targetindex].pos;
		Quaternion rot = this.m_playerreplay.m_replayPathnodes[this.targetindex].rot;
		base.transform.rotation = Quaternion.Slerp(base.transform.rotation, rot, this.replayspeed * 2f);
		float num = Vector3.Distance(base.transform.position, pos);
		if (num < 0.1f)
		{
			this.targetindex++;
			this.targetindex %= this.m_playerreplay.m_replayPathnodes.Count;
		}
		else if (num > 5f)
		{
			base.transform.position = pos;
		}
		base.transform.position = Vector3.MoveTowards(base.transform.position, pos, this.replayspeed);
	}

	// Token: 0x04001D52 RID: 7506
	public string m_replayfiletag;

	// Token: 0x04001D53 RID: 7507
	public float replayspeed = 0.05f;

	// Token: 0x04001D54 RID: 7508
	public XmlDocument m_doc = new XmlDocument();

	// Token: 0x04001D55 RID: 7509
	public string m_loadedfile = string.Empty;

	// Token: 0x04001D56 RID: 7510
	public List<Replay> replaylist = new List<Replay>();

	// Token: 0x04001D57 RID: 7511
	public int targetindex;

	// Token: 0x04001D58 RID: 7512
	public Replay m_playerreplay;

	// Token: 0x04001D59 RID: 7513
	public bool bviewportcamfollowing;
}
