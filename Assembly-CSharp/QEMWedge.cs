using System;
using System.Collections.Generic;
using Core;
using UnityEngine;

// Token: 0x020000D6 RID: 214
public class QEMWedge
{
	// Token: 0x0600050B RID: 1291 RVA: 0x000068C3 File Offset: 0x00004AC3
	public QEMWedge()
	{
		this.m_boundaryQEM.method_3();
	}

	// Token: 0x17000035 RID: 53
	// (get) Token: 0x0600050C RID: 1292 RVA: 0x000068EC File Offset: 0x00004AEC
	// (set) Token: 0x0600050D RID: 1293 RVA: 0x000068FA File Offset: 0x00004AFA
	public bool Boolean_0
	{
		get
		{
			return this.m_vertex != null;
		}
		set
		{
			if (value)
			{
				DebugUtils.Log(LogCategory.Graphics, "set valid to true ??");
			}
			else
			{
				this.m_vertex = null;
			}
		}
	}

	// Token: 0x0600050E RID: 1294 RVA: 0x00006913 File Offset: 0x00004B13
	public Vector3 method_0()
	{
		return this.m_vertex.m_pos;
	}

	// Token: 0x0600050F RID: 1295 RVA: 0x0004CC2C File Offset: 0x0004AE2C
	public QEMEdge method_1(QEMWedge qemwedge_0)
	{
		QEMEdge qemedge = null;
		foreach (QEMFace qemface in this.m_faces)
		{
			qemedge = qemface.method_11(this, qemwedge_0);
			if (qemedge != null)
			{
				break;
			}
		}
		return qemedge;
	}

	// Token: 0x06000510 RID: 1296 RVA: 0x00006920 File Offset: 0x00004B20
	public void method_2(ref QEMMatrix qemmatrix_0)
	{
		QEMMatrix.smethod_1(this.m_vertex.method_3(), this.m_boundaryQEM, ref qemmatrix_0);
	}

	// Token: 0x040004A8 RID: 1192
	public LinkedList<QEMFace> m_faces = new LinkedList<QEMFace>();

	// Token: 0x040004A9 RID: 1193
	public QEMVertex m_vertex;

	// Token: 0x040004AA RID: 1194
	public QEMMatrix m_boundaryQEM = new QEMMatrix();

	// Token: 0x040004AB RID: 1195
	public float[] m_attributes;
}
