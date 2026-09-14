using System;
using UnityEngine;

// Token: 0x020000D7 RID: 215
public class QEMFace
{
	// Token: 0x17000036 RID: 54
	// (get) Token: 0x06000512 RID: 1298 RVA: 0x00006972 File Offset: 0x00004B72
	public bool Boolean_0
	{
		get
		{
			return !this.method_10() && this.m_wedges[0].Boolean_0 && this.m_wedges[1].Boolean_0 && this.m_wedges[2].Boolean_0;
		}
	}

	// Token: 0x06000513 RID: 1299 RVA: 0x0004CC88 File Offset: 0x0004AE88
	public Vector3 method_0(bool bool_0)
	{
		Vector3 vector = Vector3.Cross(this.m_wedges[2].method_0() - this.m_wedges[0].method_0(), this.m_wedges[1].method_0() - this.m_wedges[0].method_0());
		if (bool_0)
		{
			vector.Normalize();
		}
		return vector;
	}

	// Token: 0x06000514 RID: 1300 RVA: 0x0004CCE4 File Offset: 0x0004AEE4
	public void method_1(QEMFace qemface_0)
	{
		qemface_0.m_dirty = this.m_dirty;
		qemface_0.m_index = this.m_index;
		qemface_0.m_qem = this.m_qem;
		for (int i = 0; i < 3; i++)
		{
			qemface_0.m_wedges[i] = this.m_wedges[i];
			qemface_0.m_edges[i] = this.m_edges[i];
		}
	}

	// Token: 0x06000515 RID: 1301 RVA: 0x0004CD44 File Offset: 0x0004AF44
	public bool method_2(QEMVertex qemvertex_0)
	{
		for (int i = 0; i < 3; i++)
		{
			if (this.m_wedges[i].m_vertex == qemvertex_0)
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x06000516 RID: 1302 RVA: 0x0004CD74 File Offset: 0x0004AF74
	public bool method_3(QEMWedge qemwedge_0)
	{
		for (int i = 0; i < 3; i++)
		{
			if (this.m_wedges[i] == qemwedge_0)
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x06000517 RID: 1303 RVA: 0x0004CDA0 File Offset: 0x0004AFA0
	public void method_4(QEMVertex qemvertex_0, QEMWedge qemwedge_0)
	{
		for (int i = 0; i < 3; i++)
		{
			if (this.m_wedges[i].m_vertex == qemvertex_0)
			{
				this.m_wedges[i] = qemwedge_0;
			}
		}
	}

	// Token: 0x06000518 RID: 1304 RVA: 0x0004CDD4 File Offset: 0x0004AFD4
	public void method_5(QEMWedge qemwedge_0, QEMWedge qemwedge_1)
	{
		for (int i = 0; i < 3; i++)
		{
			if (this.m_wedges[i] == qemwedge_0)
			{
				this.m_wedges[i] = qemwedge_1;
			}
		}
	}

	// Token: 0x06000519 RID: 1305 RVA: 0x0004CE04 File Offset: 0x0004B004
	public void method_6()
	{
		this.m_dirty = true;
		for (int i = 0; i < this.m_wedges.Length; i++)
		{
			this.m_wedges[i].m_vertex.method_4(false);
		}
		for (int j = 0; j < this.m_edges.Length; j++)
		{
			this.m_edges[j].method_6();
		}
	}

	// Token: 0x0600051A RID: 1306 RVA: 0x0004CE60 File Offset: 0x0004B060
	private void method_7(QEMWedge qemwedge_0, QEMWedge qemwedge_1, QEMWedge qemwedge_2, Vector3 vector3_0, int int_0, float float_0)
	{
		this.m_qem.method_6(qemwedge_0.method_0(), qemwedge_1.method_0(), qemwedge_2.method_0(), vector3_0, qemwedge_0.m_attributes[int_0] * float_0, qemwedge_1.m_attributes[int_0] * float_0, qemwedge_2.m_attributes[int_0] * float_0, int_0);
	}

	// Token: 0x0600051B RID: 1307 RVA: 0x0004CEB4 File Offset: 0x0004B0B4
	public void method_8()
	{
		QEMWedge qemwedge = this.m_wedges[0];
		QEMWedge qemwedge2 = this.m_wedges[1];
		QEMWedge qemwedge3 = this.m_wedges[2];
		if (qemwedge.Boolean_0 && qemwedge2.Boolean_0 && qemwedge3.Boolean_0)
		{
			Vector3 vector = this.method_0(true);
			this.m_qem.method_4(vector, -Vector3.Dot(qemwedge.method_0(), vector));
			int num = 0;
			QEMInput s_input = QEMCenter.s_input;
			if (s_input.m_uv != null)
			{
				this.method_7(qemwedge, qemwedge2, qemwedge3, vector, num++, s_input.m_uvWeight);
				this.method_7(qemwedge, qemwedge2, qemwedge3, vector, num++, s_input.m_uvWeight);
			}
			if (s_input.m_uv2 != null)
			{
				this.method_7(qemwedge, qemwedge2, qemwedge3, vector, num++, s_input.m_uv2Weight);
				this.method_7(qemwedge, qemwedge2, qemwedge3, vector, num++, s_input.m_uv2Weight);
			}
			if (s_input.m_normal != null)
			{
				this.method_7(qemwedge, qemwedge2, qemwedge3, vector, num++, s_input.m_normalWeight);
				this.method_7(qemwedge, qemwedge2, qemwedge3, vector, num++, s_input.m_normalWeight);
				this.method_7(qemwedge, qemwedge2, qemwedge3, vector, num++, s_input.m_normalWeight);
			}
		}
		else
		{
			this.m_qem.method_3();
		}
	}

	// Token: 0x0600051C RID: 1308 RVA: 0x000069AA File Offset: 0x00004BAA
	public QEMMatrix method_9()
	{
		if (this.m_dirty)
		{
			this.method_8();
			this.m_dirty = false;
		}
		return this.m_qem;
	}

	// Token: 0x0600051D RID: 1309 RVA: 0x0004CFF8 File Offset: 0x0004B1F8
	public bool method_10()
	{
		return this.m_wedges[0].m_vertex == this.m_wedges[1].m_vertex || this.m_wedges[0].m_vertex == this.m_wedges[2].m_vertex || this.m_wedges[1].m_vertex == this.m_wedges[2].m_vertex;
	}

	// Token: 0x0600051E RID: 1310 RVA: 0x0004D05C File Offset: 0x0004B25C
	public QEMEdge method_11(QEMWedge qemwedge_0, QEMWedge qemwedge_1)
	{
		QEMEdge qemedge = null;
		for (int i = 0; i < 3; i++)
		{
			if (this.m_edges[i] != null && this.m_edges[i].method_4(qemwedge_0, qemwedge_1))
			{
				qemedge = this.m_edges[i];
				return qemedge;
			}
		}
		return qemedge;
	}

	// Token: 0x0600051F RID: 1311 RVA: 0x0004D0A0 File Offset: 0x0004B2A0
	public QEMEdge method_12(QEMWedge qemwedge_0, QEMWedge qemwedge_1)
	{
		QEMEdge qemedge = null;
		for (int i = 0; i < 3; i++)
		{
			if (this.m_wedges[i] == qemwedge_0)
			{
				qemedge = qemwedge_0.method_1(qemwedge_1);
			}
			else if (this.m_wedges[i] == qemwedge_1)
			{
				qemedge = qemwedge_1.method_1(qemwedge_0);
			}
			if (qemedge != null)
			{
				break;
			}
		}
		return qemedge;
	}

	// Token: 0x040004AC RID: 1196
	private bool m_dirty = true;

	// Token: 0x040004AD RID: 1197
	public int m_index = -1;

	// Token: 0x040004AE RID: 1198
	private QEMMatrix m_qem = new QEMMatrix();

	// Token: 0x040004AF RID: 1199
	public QEMWedge[] m_wedges = new QEMWedge[3];

	// Token: 0x040004B0 RID: 1200
	public QEMEdge[] m_edges = new QEMEdge[3];
}
