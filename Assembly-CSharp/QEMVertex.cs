using System;
using System.Collections.Generic;
using Core;
using UnityEngine;

// Token: 0x020000D5 RID: 213
public class QEMVertex
{
	// Token: 0x17000034 RID: 52
	// (get) Token: 0x06000504 RID: 1284 RVA: 0x00006857 File Offset: 0x00004A57
	// (set) Token: 0x06000505 RID: 1285 RVA: 0x0000686E File Offset: 0x00004A6E
	public bool Boolean_0
	{
		get
		{
			return this.m_pos.x != float.MaxValue;
		}
		set
		{
			if (value)
			{
				DebugUtils.Log(LogCategory.Graphics, "set valid to true ??");
			}
			else
			{
				this.m_pos.x = float.MaxValue;
			}
		}
	}

	// Token: 0x06000506 RID: 1286 RVA: 0x00006890 File Offset: 0x00004A90
	public void method_0(QEMWedge qemwedge_0)
	{
		this.m_wedges.AddFirst(qemwedge_0);
		qemwedge_0.m_vertex = this;
	}

	// Token: 0x06000507 RID: 1287 RVA: 0x0004CA88 File Offset: 0x0004AC88
	public bool method_1(QEMFace qemface_0)
	{
		foreach (QEMWedge qemwedge in this.m_wedges)
		{
			if (qemwedge.m_faces.Contains(qemface_0))
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x06000508 RID: 1288 RVA: 0x0004CAE8 File Offset: 0x0004ACE8
	public void method_2()
	{
		this.m_qem.method_3();
		foreach (QEMWedge qemwedge in this.m_wedges)
		{
			foreach (QEMFace qemface in qemwedge.m_faces)
			{
				if (qemface.Boolean_0)
				{
					this.m_qem.method_0(qemface.method_9());
				}
			}
		}
	}

	// Token: 0x06000509 RID: 1289 RVA: 0x000068A6 File Offset: 0x00004AA6
	public QEMMatrix method_3()
	{
		if (this.m_dirty)
		{
			this.method_2();
			this.m_dirty = false;
		}
		return this.m_qem;
	}

	// Token: 0x0600050A RID: 1290 RVA: 0x0004CB94 File Offset: 0x0004AD94
	public void method_4(bool bool_0)
	{
		this.m_dirty = true;
		if (bool_0)
		{
			foreach (QEMWedge qemwedge in this.m_wedges)
			{
				foreach (QEMFace qemface in qemwedge.m_faces)
				{
					qemface.method_6();
				}
			}
		}
	}

	// Token: 0x040004A4 RID: 1188
	public LinkedList<QEMWedge> m_wedges = new LinkedList<QEMWedge>();

	// Token: 0x040004A5 RID: 1189
	public Vector3 m_pos;

	// Token: 0x040004A6 RID: 1190
	private QEMMatrix m_qem = new QEMMatrix();

	// Token: 0x040004A7 RID: 1191
	public bool m_dirty = true;
}
