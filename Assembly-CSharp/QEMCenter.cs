using System;
using System.Collections.Generic;
using Core;
using UnityEngine;

// Token: 0x020000DF RID: 223
internal class QEMCenter
{
	// Token: 0x06000560 RID: 1376 RVA: 0x00006C6E File Offset: 0x00004E6E
	public QEMCenter(QEMInput qeminput_0)
	{
		this.method_0(qeminput_0);
		this.method_4();
	}

	// Token: 0x06000561 RID: 1377 RVA: 0x0004E3D0 File Offset: 0x0004C5D0
	private void method_0(QEMInput qeminput_0)
	{
		QEMCenter.s_input = qeminput_0;
		int num = 3;
		if (qeminput_0.m_uv != null)
		{
			num += 2;
		}
		if (qeminput_0.m_uv2 != null)
		{
			num += 2;
		}
		if (qeminput_0.m_normal != null)
		{
			num += 3;
		}
		QEMMatrix.smethod_0(num);
		this.m_tempFace = new QEMFace();
		this.m_tempVertex = new QEMVertex();
	}

	// Token: 0x06000562 RID: 1378 RVA: 0x0004E428 File Offset: 0x0004C628
	public void method_1(QEMFace qemface_0, List<QEMEdge> list_0)
	{
		int[,] array = new int[,]
		{
			{ 0, 1 },
			{ 0, 2 },
			{ 1, 2 }
		};
		for (int i = 0; i < 3; i++)
		{
			QEMWedge qemwedge = qemface_0.m_wedges[array[i, 0]];
			QEMWedge qemwedge2 = qemface_0.m_wedges[array[i, 1]];
			if (qemface_0.m_edges[i] == null)
			{
				QEMEdge qemedge = qemface_0.method_12(qemwedge, qemwedge2);
				if (qemedge == null)
				{
					qemedge = new QEMEdge();
					qemedge.m_wedges[0] = qemwedge;
					qemedge.m_wedges[1] = qemwedge2;
					qemedge.m_ref = 1;
					list_0.Add(qemedge);
				}
				else
				{
					qemedge.m_ref++;
				}
				qemface_0.m_edges[i] = qemedge;
			}
		}
	}

	// Token: 0x06000563 RID: 1379 RVA: 0x0004E4D8 File Offset: 0x0004C6D8
	public void method_2(QEMFace qemface_0)
	{
		int[,] array = new int[,]
		{
			{ 0, 1 },
			{ 0, 2 },
			{ 1, 2 }
		};
		for (int i = 0; i < 3; i++)
		{
			QEMWedge qemwedge = qemface_0.m_wedges[array[i, 0]];
			QEMWedge qemwedge2 = qemface_0.m_wedges[array[i, 1]];
			if (!qemface_0.m_edges[i].method_4(qemwedge, qemwedge2))
			{
				QEMEdge qemedge = qemface_0.method_12(qemwedge, qemwedge2);
				if (qemedge == null)
				{
					qemedge = qemface_0.m_edges[i];
					qemedge.m_wedges[0] = qemwedge;
					qemedge.m_wedges[1] = qemwedge2;
				}
				else
				{
					this.m_edgeHeap.method_1(qemface_0.m_edges[i].m_index);
					qemface_0.m_edges[i] = qemedge;
					qemedge.m_ref++;
				}
			}
		}
	}

	// Token: 0x06000564 RID: 1380 RVA: 0x0004E59C File Offset: 0x0004C79C
	public void method_3(string string_0)
	{
		if (!string.IsNullOrEmpty(string_0))
		{
			DebugUtils.Log(LogCategory.Graphics, string_0);
		}
		for (int i = 0; i < this.m_allFaces.Length; i++)
		{
			QEMFace qemface = this.m_allFaces[i];
			if (qemface.m_index != i)
			{
				DebugUtils.Log(LogCategory.Graphics, "Face Error 0");
			}
			if (qemface.Boolean_0)
			{
				if (qemface.method_10())
				{
					DebugUtils.Log(LogCategory.Graphics, "Face Error 1");
				}
				QEMWedge qemwedge = qemface.m_wedges[0];
				QEMWedge qemwedge2 = qemface.m_wedges[1];
				QEMWedge qemwedge3 = qemface.m_wedges[2];
				QEMEdge qemedge = qemface.m_edges[0];
				QEMEdge qemedge2 = qemface.m_edges[1];
				QEMEdge qemedge3 = qemface.m_edges[2];
				for (int j = 0; j < 3; j++)
				{
					QEMWedge qemwedge4 = qemface.m_wedges[j];
					if (!qemwedge4.Boolean_0)
					{
						DebugUtils.Log(LogCategory.Graphics, "Face Error 2");
					}
				}
				if (!qemedge.method_4(qemwedge, qemwedge2))
				{
					DebugUtils.Log(LogCategory.Graphics, "Face Error 3");
				}
				if (!qemedge2.method_4(qemwedge, qemwedge3))
				{
					DebugUtils.Log(LogCategory.Graphics, "Face Error 4");
				}
				if (!qemedge3.method_4(qemwedge2, qemwedge3))
				{
					DebugUtils.Log(LogCategory.Graphics, "Face Error 5");
				}
				for (int k = 0; k < 3; k++)
				{
					QEMWedge qemwedge5 = qemface.m_wedges[k];
					foreach (QEMFace qemface2 in qemwedge5.m_faces)
					{
						if (!qemface2.Boolean_0)
						{
							DebugUtils.Log(LogCategory.Graphics, "Face Error 6");
						}
						if (!qemface2.method_3(qemwedge5))
						{
							DebugUtils.Log(LogCategory.Graphics, "Face Error 7");
						}
					}
				}
			}
		}
		for (int l = 0; l < this.m_edgeHeap.method_2(); l++)
		{
			QEMEdge qemedge4 = this.m_edgeHeap.method_4(l);
			for (int m = l + 1; m < this.m_edgeHeap.method_2(); m++)
			{
				QEMEdge qemedge5 = this.m_edgeHeap.method_4(m);
				if (qemedge5.method_3(qemedge4))
				{
					DebugUtils.Log(LogCategory.Graphics, "Edge Error 0");
				}
			}
			if (!qemedge4.Boolean_0)
			{
				DebugUtils.Log(LogCategory.Graphics, "Edge Error 1");
			}
			if (qemedge4.m_index >= this.m_edgeHeap.method_2())
			{
				DebugUtils.Log(LogCategory.Graphics, "Edge Error 2");
			}
			if (qemedge4.m_ref <= 0)
			{
				DebugUtils.Log(LogCategory.Graphics, "Edge Error 2");
			}
		}
		for (int n = 0; n < this.m_allVertices.Length; n++)
		{
			QEMVertex qemvertex = this.m_allVertices[n];
			if (qemvertex != null && qemvertex.Boolean_0)
			{
				foreach (QEMWedge qemwedge6 in qemvertex.m_wedges)
				{
					if (!qemwedge6.Boolean_0)
					{
						DebugUtils.Log(LogCategory.Graphics, "Vert Error 0");
					}
				}
			}
		}
	}

	// Token: 0x06000565 RID: 1381 RVA: 0x0004E87C File Offset: 0x0004CA7C
	public void method_4()
	{
		Vector3[] vertex = QEMCenter.s_input.m_vertex;
		int[] triangle = QEMCenter.s_input.m_triangle;
		Vector2[] uv = QEMCenter.s_input.m_uv;
		Vector2[] uv2 = QEMCenter.s_input.m_uv2;
		Vector3[] normal = QEMCenter.s_input.m_normal;
		this.m_allVertices = new QEMVertex[vertex.Length];
		this.m_allFaces = new QEMFace[triangle.Length / 3];
		this.m_activeFaceNumber = this.m_allFaces.Length;
		this.m_targetFaceNumber = (int)((float)this.m_activeFaceNumber * QEMCenter.s_input.m_percentage);
		for (int i = 0; i < this.m_allVertices.Length; i++)
		{
			QEMVertex qemvertex = (this.m_allVertices[i] = new QEMVertex());
			qemvertex.m_pos = vertex[i];
			QEMWedge qemwedge = new QEMWedge();
			if (QEMMatrix.s_n > 3)
			{
				qemwedge.m_attributes = new float[QEMMatrix.s_n - 3];
				int num = 0;
				if (uv != null)
				{
					qemwedge.m_attributes[num++] = uv[i].x;
					qemwedge.m_attributes[num++] = uv[i].y;
				}
				if (uv2 != null)
				{
					qemwedge.m_attributes[num++] = uv2[i].x;
					qemwedge.m_attributes[num++] = uv2[i].y;
				}
				if (normal != null)
				{
					qemwedge.m_attributes[num++] = normal[i].x;
					qemwedge.m_attributes[num++] = normal[i].y;
					qemwedge.m_attributes[num++] = normal[i].z;
				}
			}
			qemvertex.method_0(qemwedge);
		}
		for (int j = 0; j < this.m_allFaces.Length; j++)
		{
			int num2 = triangle[3 * j];
			int num3 = triangle[3 * j + 1];
			int num4 = triangle[3 * j + 2];
			if (num2 != num3 && num2 != num4 && num3 != num4)
			{
				QEMFace qemface = (this.m_allFaces[j] = new QEMFace());
				qemface.m_index = j;
				for (int k = 0; k < 3; k++)
				{
					int num5 = triangle[3 * j + k];
					qemface.m_wedges[k] = this.m_allVertices[num5].m_wedges.First.Value;
				}
			}
		}
		float num6 = QEMCenter.s_input.s_vertexCombineThreshold * QEMCenter.s_input.s_vertexCombineThreshold;
		for (int l = 0; l < this.m_allVertices.Length; l++)
		{
			QEMVertex qemvertex2 = this.m_allVertices[l];
			if (qemvertex2 != null)
			{
				for (int m = l + 1; m < this.m_allVertices.Length; m++)
				{
					QEMVertex qemvertex3 = this.m_allVertices[m];
					if (qemvertex3 != null && (qemvertex2.m_pos - qemvertex3.m_pos).sqrMagnitude < num6)
					{
						foreach (QEMWedge qemwedge2 in qemvertex3.m_wedges)
						{
							qemvertex2.method_0(qemwedge2);
						}
						qemvertex3.m_wedges.Clear();
						this.m_allVertices[m] = null;
					}
				}
			}
		}
		List<QEMEdge> list = new List<QEMEdge>(this.m_allFaces.Length * 3);
		for (int n = 0; n < this.m_allFaces.Length; n++)
		{
			QEMFace qemface2 = this.m_allFaces[n];
			if (qemface2 != null)
			{
				for (int num7 = 0; num7 < 3; num7++)
				{
					qemface2.m_wedges[num7].m_faces.AddFirst(qemface2);
				}
				this.method_1(qemface2, list);
			}
		}
		foreach (QEMEdge qemedge in list)
		{
			qemedge.method_8();
		}
		this.m_edgeHeap = new BinaryHeap(list.ToArray());
	}

	// Token: 0x06000566 RID: 1382 RVA: 0x0004ECA4 File Offset: 0x0004CEA4
	public void method_5(Mesh mesh_0)
	{
		List<Vector3> list = new List<Vector3>();
		List<Vector2> list2 = null;
		if (s_input.m_uv != null)
		{
			list2 = new List<Vector2>();
		}
		List<Vector2> list3 = null;
		if (s_input.m_uv2 != null)
		{
			list3 = new List<Vector2>();
		}
		List<Vector3> list4 = null;
		if (s_input.m_normal != null)
		{
			list4 = new List<Vector3>();
		}
		List<int> list5 = new List<int>(m_allFaces.Length * 3);
		int[,] array = new int[m_allFaces.Length, 3];
		for (int i = 0; i < m_allFaces.Length; i++)
		{
			int num = i;
			int num2 = i;
			array[i, 2] = -1;
			array[num2, 1] = -1;
			array[num, 0] = -1;
		}
		for (int j = 0; j < m_allFaces.Length; j++)
		{
			QEMFace qEMFace = m_allFaces[j];
			if (qEMFace == null || !qEMFace.Boolean_0)
			{
				continue;
			}
			for (int k = 0; k < 3; k++)
			{
				if (array[j, k] >= 0)
				{
					continue;
				}
				int count = list.Count;
				QEMWedge qEMWedge = qEMFace.m_wedges[k];
				list.Add(qEMWedge.method_0());
				int num3 = 0;
				if (list2 != null)
				{
					list2.Add(new Vector2(qEMWedge.m_attributes[num3], qEMWedge.m_attributes[num3 + 1]));
					num3 += 2;
				}
				if (list3 != null)
				{
					list3.Add(new Vector2(qEMWedge.m_attributes[num3], qEMWedge.m_attributes[num3 + 1]));
					num3 += 2;
				}
				if (list4 != null)
				{
					list4.Add(new Vector3(qEMWedge.m_attributes[num3], qEMWedge.m_attributes[num3 + 1], qEMWedge.m_attributes[num3 + 2]));
					num3 += 3;
				}
				array[j, k] = count;
				foreach (QEMFace face in qEMWedge.m_faces)
				{
					if (!face.Boolean_0)
					{
						continue;
					}
					for (int l = 0; l < 3; l++)
					{
						if (face.m_wedges[l] == qEMWedge)
						{
							array[face.m_index, l] = count;
						}
					}
				}
			}
		}
		for (int m = 0; m < m_allFaces.Length; m++)
		{
			bool flag = true;
			for (int n = 0; n < 3; n++)
			{
				if (array[m, n] < 0)
				{
					flag = false;
					break;
				}
			}
			if (flag)
			{
				for (int num4 = 0; num4 < 3; num4++)
				{
					list5.Add(array[m, num4]);
				}
			}
		}
		mesh_0.vertices = list.ToArray();
		mesh_0.triangles = list5.ToArray();
		if (list2 != null)
		{
			mesh_0.uv = list2.ToArray();
		}
		if (list3 != null)
		{
			mesh_0.uv2 = list3.ToArray();
		}
		if (list4 != null)
		{
			mesh_0.normals = list4.ToArray();
		}
	}
	// Token: 0x06000567 RID: 1383 RVA: 0x0004EF90 File Offset: 0x0004D190
	public void method_6(int int_0)
	{
		int i = 0;
		while (i < int_0)
		{
			QEMEdge qemedge;
			do
			{
				qemedge = this.m_edgeHeap.method_4(0);
				if (qemedge == null)
				{
					goto IL_0081;
				}
				if (qemedge.method_9() == 3.4028235E+38f)
				{
					goto Block_1;
				}
				if (this.method_11(qemedge))
				{
					goto IL_0048;
				}
				this.m_edgeHeap.method_7(0);
			}
			while (this.m_edgeHeap.method_2() > 0);
			IL_006D:
			i++;
			continue;
			IL_0048:
			this.method_8(qemedge);
			if (qemedge.m_index < this.m_edgeHeap.method_2())
			{
				DebugUtils.Log(LogCategory.Graphics, "edge not popped");
				goto IL_006D;
			}
			goto IL_006D;
			Block_1:
			IL_0081:
			DebugUtils.Log(LogCategory.Graphics, "No Edge To Collapse");
			return;
		}
		this.method_3(string.Empty);
	}

	// Token: 0x06000568 RID: 1384 RVA: 0x0004F02C File Offset: 0x0004D22C
	public void method_7()
	{
		while (this.m_activeFaceNumber > this.m_targetFaceNumber)
		{
			QEMEdge qemedge = this.m_edgeHeap.method_4(0);
			if (qemedge != null)
			{
				if (qemedge.method_9() != 3.4028235E+38f)
				{
					if (!this.method_11(qemedge))
					{
						this.m_edgeHeap.method_7(0);
						continue;
					}
					this.method_8(qemedge);
					if (qemedge.m_index < this.m_edgeHeap.method_2())
					{
						DebugUtils.Log(LogCategory.Graphics, "edge not popped");
						continue;
					}
					continue;
				}
			}
			DebugUtils.Log(LogCategory.Graphics, "No Edge To Collapse");
			return;
		}
		this.method_3(string.Empty);
	}

	// Token: 0x06000569 RID: 1385 RVA: 0x0004F0BC File Offset: 0x0004D2BC
	private void method_8(QEMEdge qemedge_0)
	{
		QEMWedge qemwedge = qemedge_0.m_wedges[0];
		foreach (QEMWedge qemwedge2 in qemwedge.m_vertex.m_wedges)
		{
			LinkedListNode<QEMFace> next;
			for (LinkedListNode<QEMFace> linkedListNode = qemwedge2.m_faces.First; linkedListNode != null; linkedListNode = next)
			{
				next = linkedListNode.Next;
				QEMFace value = linkedListNode.Value;
				if (!value.Boolean_0)
				{
					qemwedge2.m_faces.Remove(linkedListNode);
					for (int i = 0; i < 3; i++)
					{
						QEMWedge qemwedge3 = value.m_wedges[i];
						if (qemwedge3 != qemwedge2)
						{
							qemwedge3.m_faces.Remove(value);
						}
					}
					this.method_9(value);
					this.m_activeFaceNumber--;
				}
			}
		}
		foreach (QEMWedge qemwedge4 in qemwedge.m_vertex.m_wedges)
		{
			foreach (QEMFace qemface in qemwedge4.m_faces)
			{
				for (int j = 0; j < 3; j++)
				{
					QEMEdge qemedge = qemface.m_edges[j];
					if (qemedge.method_5() && qemedge.m_index < this.m_edgeHeap.method_2())
					{
						if (qemedge.Boolean_0)
						{
							this.m_edgeHeap.method_3(qemedge.m_index);
						}
						else
						{
							this.m_edgeHeap.method_1(qemedge.m_index);
							DebugUtils.Log(LogCategory.Graphics, "m_edgeHeap.Pop(edge.m_index);");
						}
					}
				}
			}
		}
	}

	// Token: 0x0600056A RID: 1386 RVA: 0x0004F298 File Offset: 0x0004D498
	public void method_9(QEMFace qemface_0)
	{
		for (int i = 0; i < 3; i++)
		{
			qemface_0.m_edges[i].m_ref--;
			if (qemface_0.m_edges[i].m_ref <= 0)
			{
				if (qemface_0.m_edges[i].m_ref < 0)
				{
					DebugUtils.Log(LogCategory.Graphics, "face.m_edges[i].m_ref < 0");
				}
				this.m_edgeHeap.method_1(qemface_0.m_edges[i].m_index);
			}
		}
	}

	// Token: 0x0600056B RID: 1387 RVA: 0x0004F30C File Offset: 0x0004D50C
	private bool method_10(QEMEdge qemedge_0)
	{
		QEMWedge qemwedge = qemedge_0.m_wedges[0];
		QEMWedge qemwedge2 = qemedge_0.m_wedges[1];
		QEMVertex vertex = qemwedge.m_vertex;
		QEMVertex vertex2 = qemwedge2.m_vertex;
		this.m_tempVertex.m_pos = qemedge_0.method_10().method_1();
		if (this.m_tempVertex.m_wedges.Count == 0)
		{
			QEMWedge qemwedge3 = new QEMWedge();
			this.m_tempVertex.method_0(qemwedge3);
		}
		QEMWedge value = this.m_tempVertex.m_wedges.First.Value;
		foreach (QEMWedge qemwedge4 in vertex.m_wedges)
		{
			LinkedListNode<QEMFace> next;
			for (LinkedListNode<QEMFace> linkedListNode = qemwedge4.m_faces.First; linkedListNode != null; linkedListNode = next)
			{
				next = linkedListNode.Next;
				QEMFace value2 = linkedListNode.Value;
				if (value2.Boolean_0)
				{
					value2.method_1(this.m_tempFace);
					this.m_tempFace.method_4(vertex, value);
					this.m_tempFace.method_4(vertex2, value);
					if (!this.m_tempFace.method_10())
					{
						Vector3 vector = value2.method_0(false);
						Vector3 vector2 = this.m_tempFace.method_0(false);
						if (Vector3.Dot(vector, vector2) < 0f)
						{
							return false;
						}
					}
				}
				else
				{
					DebugUtils.Log(LogCategory.Graphics, "v1 invalid face");
					qemwedge4.m_faces.Remove(linkedListNode);
					for (int i = 0; i < 3; i++)
					{
						if (value2.m_edges[i].Boolean_0)
						{
							this.m_edgeHeap.method_1(value2.m_edges[i].m_index);
						}
					}
				}
			}
		}
		foreach (QEMWedge qemwedge5 in vertex2.m_wedges)
		{
			LinkedListNode<QEMFace> next2;
			for (LinkedListNode<QEMFace> linkedListNode2 = qemwedge5.m_faces.First; linkedListNode2 != null; linkedListNode2 = next2)
			{
				next2 = linkedListNode2.Next;
				QEMFace value3 = linkedListNode2.Value;
				if (value3.Boolean_0)
				{
					value3.method_1(this.m_tempFace);
					this.m_tempFace.method_4(vertex, value);
					this.m_tempFace.method_4(vertex2, value);
					if (!this.m_tempFace.method_10())
					{
						Vector3 vector3 = value3.method_0(false);
						Vector3 vector4 = this.m_tempFace.method_0(false);
						if (Vector3.Dot(vector3, vector4) < 0f)
						{
							return false;
						}
					}
				}
				else
				{
					DebugUtils.Log(LogCategory.Graphics, "v2 invalid face");
					qemwedge5.m_faces.Remove(linkedListNode2);
					for (int j = 0; j < 3; j++)
					{
						if (value3.m_edges[j].Boolean_0)
						{
							this.m_edgeHeap.method_1(value3.m_edges[j].m_index);
						}
					}
				}
			}
		}
		return true;
	}

	// Token: 0x0600056C RID: 1388 RVA: 0x0004F61C File Offset: 0x0004D81C
	public bool method_11(QEMEdge qemedge_0)
	{
		qemedge_0.m_error = float.MaxValue;
		if (this.method_10(qemedge_0))
		{
			QEMWedge qemwedge = qemedge_0.m_wedges[0];
			QEMWedge qemwedge2 = qemedge_0.m_wedges[1];
			QEMVertex vertex = qemwedge.m_vertex;
			QEMVertex vertex2 = qemwedge2.m_vertex;
			QEMVectorN qemvectorN = qemedge_0.method_10();
			vertex.m_pos = qemvectorN.method_1();
			int num = 0;
			if (QEMCenter.s_input.m_uv != null)
			{
				qemwedge.m_attributes[num] = qemvectorN.method_3(num) / QEMCenter.s_input.m_uvWeight;
				num++;
				qemwedge.m_attributes[num] = qemvectorN.method_3(num) / QEMCenter.s_input.m_uvWeight;
				num++;
			}
			if (QEMCenter.s_input.m_uv2 != null)
			{
				qemwedge.m_attributes[num] = qemvectorN.method_3(num) / QEMCenter.s_input.m_uv2Weight;
				num++;
				qemwedge.m_attributes[num] = qemvectorN.method_3(num) / QEMCenter.s_input.m_uv2Weight;
				num++;
			}
			if (QEMCenter.s_input.m_normal != null)
			{
				qemwedge.m_attributes[num] = qemvectorN.method_3(num) / QEMCenter.s_input.m_normalWeight;
				num++;
				qemwedge.m_attributes[num] = qemvectorN.method_3(num) / QEMCenter.s_input.m_normalWeight;
				num++;
				qemwedge.m_attributes[num] = qemvectorN.method_3(num) / QEMCenter.s_input.m_normalWeight;
				num++;
			}
			foreach (QEMFace qemface in qemwedge2.m_faces)
			{
				qemface.method_5(qemwedge2, qemwedge);
				if (!qemface.method_10())
				{
					qemwedge.m_faces.AddFirst(qemface);
				}
			}
			qemwedge.m_boundaryQEM.method_0(qemwedge2.m_boundaryQEM);
			LinkedListNode<QEMWedge> next;
			for (LinkedListNode<QEMWedge> linkedListNode = vertex2.m_wedges.First; linkedListNode != null; linkedListNode = next)
			{
				QEMWedge value = linkedListNode.Value;
				next = linkedListNode.Next;
				if (value != qemwedge2)
				{
					vertex.method_0(value);
				}
			}
			foreach (QEMFace qemface2 in qemwedge2.m_faces)
			{
				this.method_2(qemface2);
			}
			vertex2.Boolean_0 = false;
			qemwedge2.Boolean_0 = false;
			vertex.method_4(true);
			return true;
		}
		return false;
	}

	// Token: 0x040004D2 RID: 1234
	public const bool CHECKERROR = true;

	// Token: 0x040004D3 RID: 1235
	public static QEMInput s_input;

	// Token: 0x040004D4 RID: 1236
	private BinaryHeap m_edgeHeap;

	// Token: 0x040004D5 RID: 1237
	private QEMFace[] m_allFaces;

	// Token: 0x040004D6 RID: 1238
	private QEMVertex[] m_allVertices;

	// Token: 0x040004D7 RID: 1239
	private QEMFace m_tempFace;

	// Token: 0x040004D8 RID: 1240
	private QEMVertex m_tempVertex;

	// Token: 0x040004D9 RID: 1241
	private int m_targetFaceNumber;

	// Token: 0x040004DA RID: 1242
	private int m_activeFaceNumber;
}
