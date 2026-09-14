using System;
using UnityEngine;

// Token: 0x020000D4 RID: 212
public class QEMEdge
{
	// Token: 0x17000033 RID: 51
	// (get) Token: 0x060004F7 RID: 1271 RVA: 0x0000673A File Offset: 0x0000493A
	public bool Boolean_0
	{
		get
		{
			return !this.method_2() && this.m_wedges[0].Boolean_0 && this.m_wedges[1].Boolean_0;
		}
	}

	// Token: 0x060004F8 RID: 1272 RVA: 0x0004C65C File Offset: 0x0004A85C
	public QEMFace method_0()
	{
		QEMFace qemface = null;
		int num = 0;
		foreach (QEMFace qemface2 in this.m_wedges[0].m_faces)
		{
			if (qemface2.method_11(this.m_wedges[0], this.m_wedges[1]) != null)
			{
				num++;
				qemface = qemface2;
			}
		}
		if (num != 1)
		{
			qemface = null;
		}
		return qemface;
	}

	// Token: 0x060004F9 RID: 1273 RVA: 0x00006763 File Offset: 0x00004963
	public bool method_1(QEMWedge qemwedge_0)
	{
		return this.m_wedges[0] == qemwedge_0 || this.m_wedges[1] == qemwedge_0;
	}

	// Token: 0x060004FA RID: 1274 RVA: 0x0000677E File Offset: 0x0000497E
	public bool method_2()
	{
		return this.m_wedges[0].m_vertex == this.m_wedges[1].m_vertex;
	}

	// Token: 0x060004FB RID: 1275 RVA: 0x0000679C File Offset: 0x0000499C
	public bool method_3(QEMEdge qemedge_0)
	{
		return this.method_4(qemedge_0.m_wedges[0], qemedge_0.m_wedges[1]);
	}

	// Token: 0x060004FC RID: 1276 RVA: 0x000067B4 File Offset: 0x000049B4
	public bool method_4(QEMWedge qemwedge_0, QEMWedge qemwedge_1)
	{
		return (this.m_wedges[0] == qemwedge_0 && this.m_wedges[1] == qemwedge_1) || (this.m_wedges[1] == qemwedge_0 && this.m_wedges[0] == qemwedge_1);
	}

	// Token: 0x060004FD RID: 1277 RVA: 0x000067E7 File Offset: 0x000049E7
	public bool method_5()
	{
		return this.m_qemDirty;
	}

	// Token: 0x060004FE RID: 1278 RVA: 0x000067EF File Offset: 0x000049EF
	public void method_6()
	{
		this.m_qemDirty = true;
	}

	// Token: 0x060004FF RID: 1279 RVA: 0x0004C6D8 File Offset: 0x0004A8D8
	public void method_7()
	{
		if (this.Boolean_0)
		{
			this.m_wedges[0].method_2(ref QEMMatrix.s_tempQEMMatrix1);
			this.m_wedges[1].method_2(ref QEMMatrix.s_tempQEMMatrix2);
			QEMMatrix.smethod_1(QEMMatrix.s_tempQEMMatrix1, QEMMatrix.s_tempQEMMatrix2, ref QEMMatrix.s_tempQEMMatrix0);
			QEMMatrix s_tempQEMMatrix = QEMMatrix.s_tempQEMMatrix0;
			if (!s_tempQEMMatrix.method_8(ref this.m_collapsePosition))
			{
				this.m_collapsePosition.method_0((this.m_wedges[0].method_0() + this.m_wedges[1].method_0()) / 2f);
				for (int i = 0; i < QEMMatrix.s_n - 3; i++)
				{
					this.m_collapsePosition.method_2(i, (this.m_wedges[0].m_attributes[i] + this.m_wedges[1].m_attributes[i]) / 2f);
				}
			}
			bool flag = false;
			QEMInput s_input = QEMCenter.s_input;
			int num = 0;
			if (s_input.m_normal != null)
			{
				int num2 = num++;
				int num3 = num++;
				int num4 = num++;
				float num5 = this.m_collapsePosition.method_3(num2);
				float num6 = this.m_collapsePosition.method_3(num3);
				float num7 = this.m_collapsePosition.method_3(num4);
				this.m_collapsePosition.method_2(num2, num5);
				this.m_collapsePosition.method_2(num3, num6);
				this.m_collapsePosition.method_2(num4, num7);
			}
			this.m_error = s_tempQEMMatrix.method_2(this.m_collapsePosition);
			if (flag)
			{
				this.m_error = float.MaxValue;
			}
		}
		else
		{
			this.m_error = float.MaxValue;
		}
	}

	// Token: 0x06000500 RID: 1280 RVA: 0x0004C868 File Offset: 0x0004AA68
	public void method_8()
	{
		QEMMatrix s_tempQEMMatrix = QEMMatrix.s_tempQEMMatrix0;
		s_tempQEMMatrix.method_3();
		QEMFace qemface = this.method_0();
		if (qemface != null)
		{
			Vector3 vector = qemface.method_0(false);
			QEMWedge qemwedge = null;
			QEMWedge qemwedge2 = null;
			for (int i = 0; i < 3; i++)
			{
				if (this.m_wedges[0] == qemface.m_wedges[i])
				{
					qemwedge = this.m_wedges[0];
					qemwedge2 = this.m_wedges[1];
				}
				else if (this.m_wedges[1] == qemface.m_wedges[i])
				{
					qemwedge = this.m_wedges[1];
					qemwedge2 = this.m_wedges[0];
				}
			}
			Vector3 vector2 = Vector3.Cross(vector, qemwedge2.method_0() - qemwedge.method_0());
			vector2.Normalize();
			float num = -Vector3.Dot(this.m_wedges[0].method_0(), vector2);
			QEMInput s_input = QEMCenter.s_input;
			for (int j = 0; j < 2; j++)
			{
				QEMWedge qemwedge3 = this.m_wedges[j];
				s_tempQEMMatrix.method_4(vector2, num);
				int num2 = 0;
				if (s_input.m_uv != null)
				{
					s_tempQEMMatrix.method_7(s_input.m_uvWeight * qemwedge3.m_attributes[num2], num2);
					num2++;
					s_tempQEMMatrix.method_7(s_input.m_uvWeight * qemwedge3.m_attributes[num2], num2);
					num2++;
				}
				if (s_input.m_uv2 != null)
				{
					s_tempQEMMatrix.method_7(s_input.m_uv2Weight * qemwedge3.m_attributes[num2], num2);
					num2++;
					s_tempQEMMatrix.method_7(s_input.m_uv2Weight * qemwedge3.m_attributes[num2], num2);
					num2++;
				}
				if (s_input.m_normal != null)
				{
					s_tempQEMMatrix.method_7(s_input.m_normalWeight * qemwedge3.m_attributes[num2], num2);
					num2++;
					s_tempQEMMatrix.method_7(s_input.m_normalWeight * qemwedge3.m_attributes[num2], num2);
					num2++;
					s_tempQEMMatrix.method_7(s_input.m_normalWeight * qemwedge3.m_attributes[num2], num2);
					num2++;
				}
				s_tempQEMMatrix.method_1((float)QEMCenter.s_input.s_boundaryPlaneWeight);
				qemwedge3.m_boundaryQEM.method_0(s_tempQEMMatrix);
			}
		}
	}

	// Token: 0x06000501 RID: 1281 RVA: 0x000067F8 File Offset: 0x000049F8
	public float method_9()
	{
		if (this.m_qemDirty)
		{
			this.method_7();
			this.m_qemDirty = false;
		}
		return this.m_error;
	}

	// Token: 0x06000502 RID: 1282 RVA: 0x00006815 File Offset: 0x00004A15
	public QEMVectorN method_10()
	{
		if (this.m_qemDirty)
		{
			this.method_7();
			this.m_qemDirty = false;
		}
		return this.m_collapsePosition;
	}

	// Token: 0x0400049E RID: 1182
	public bool m_qemDirty = true;

	// Token: 0x0400049F RID: 1183
	public int m_index = -1;

	// Token: 0x040004A0 RID: 1184
	public QEMWedge[] m_wedges = new QEMWedge[2];

	// Token: 0x040004A1 RID: 1185
	public QEMVectorN m_collapsePosition = new QEMVectorN();

	// Token: 0x040004A2 RID: 1186
	public float m_error = float.MaxValue;

	// Token: 0x040004A3 RID: 1187
	public int m_ref;
}
