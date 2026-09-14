using System;
using UnityEngine;

// Token: 0x02000B47 RID: 2887
public class DecalPolygon
{
	// Token: 0x06004E9B RID: 20123 RVA: 0x000332E5 File Offset: 0x000314E5
	public DecalPolygon()
	{
		this.verticeCount = 0;
		this.vertice = new Vector3[9];
		this.normal = new Vector3[9];
		this.tangent = new Vector4[9];
	}

	// Token: 0x06004E9C RID: 20124 RVA: 0x0014E110 File Offset: 0x0014C310
	public DecalPolygon method_0()
	{
		DecalPolygon decalPolygon = new DecalPolygon();
		decalPolygon.verticeCount = this.verticeCount;
		Array.Copy(this.normal, decalPolygon.normal, this.normal.Length);
		Array.Copy(this.vertice, decalPolygon.vertice, this.vertice.Length);
		Array.Copy(this.tangent, decalPolygon.tangent, this.tangent.Length);
		return decalPolygon;
	}

	// Token: 0x06004E9D RID: 20125 RVA: 0x0014E17C File Offset: 0x0014C37C
	public static DecalPolygon smethod_0(DecalPolygon decalPolygon_0, Vector4 vector4_0)
	{
		bool[] array = new bool[10];
		int num = 0;
		Vector3 vector = new Vector3(vector4_0.x, vector4_0.y, vector4_0.z);
		for (int i = 0; i < decalPolygon_0.verticeCount; i++)
		{
			array[i] = Vector3.Dot(decalPolygon_0.vertice[i], vector) + vector4_0.w < 0f;
			if (array[i])
			{
				num++;
			}
		}
		if (num == decalPolygon_0.verticeCount)
		{
			return null;
		}
		if (num == 0)
		{
			return decalPolygon_0;
		}
		DecalPolygon decalPolygon = new DecalPolygon();
		decalPolygon.verticeCount = 0;
		for (int j = 0; j < decalPolygon_0.verticeCount; j++)
		{
			int num2 = ((j != 0) ? (j - 1) : (decalPolygon_0.verticeCount - 1));
			if (array[j])
			{
				if (!array[num2])
				{
					Vector3 vector2 = decalPolygon_0.vertice[j];
					Vector3 vector3 = decalPolygon_0.vertice[num2];
					Vector3 vector4 = (vector3 - vector2).normalized;
					float num3 = -(Vector3.Dot(vector, vector2) + vector4_0.w) / Vector3.Dot(vector, vector4);
					decalPolygon.tangent[decalPolygon.verticeCount] = decalPolygon_0.tangent[j] + (decalPolygon_0.tangent[num2] - decalPolygon_0.tangent[j]).normalized * num3;
					decalPolygon.vertice[decalPolygon.verticeCount] = vector2 + (vector3 - vector2).normalized * num3;
					decalPolygon.normal[decalPolygon.verticeCount] = decalPolygon_0.normal[j] + (decalPolygon_0.normal[num2] - decalPolygon_0.normal[j]).normalized * num3;
					decalPolygon.verticeCount++;
				}
			}
			else
			{
				if (array[num2])
				{
					Vector3 vector2 = decalPolygon_0.vertice[num2];
					Vector3 vector3 = decalPolygon_0.vertice[j];
					Vector3 vector4 = (vector3 - vector2).normalized;
					float num3 = -(Vector3.Dot(vector, vector2) + vector4_0.w) / Vector3.Dot(vector, vector4);
					decalPolygon.tangent[decalPolygon.verticeCount] = decalPolygon_0.tangent[num2] + (decalPolygon_0.tangent[j] - decalPolygon_0.tangent[num2]).normalized * num3;
					decalPolygon.vertice[decalPolygon.verticeCount] = vector2 + (vector3 - vector2).normalized * num3;
					decalPolygon.normal[decalPolygon.verticeCount] = decalPolygon_0.normal[num2] + (decalPolygon_0.normal[j] - decalPolygon_0.normal[num2]).normalized * num3;
					decalPolygon.verticeCount++;
				}
				decalPolygon.tangent[decalPolygon.verticeCount] = decalPolygon_0.tangent[j];
				decalPolygon.vertice[decalPolygon.verticeCount] = decalPolygon_0.vertice[j];
				decalPolygon.normal[decalPolygon.verticeCount] = decalPolygon_0.normal[j];
				decalPolygon.verticeCount++;
			}
		}
		return decalPolygon;
	}

	// Token: 0x04003AD9 RID: 15065
	public int verticeCount;

	// Token: 0x04003ADA RID: 15066
	public Vector3[] normal;

	// Token: 0x04003ADB RID: 15067
	public Vector3[] vertice;

	// Token: 0x04003ADC RID: 15068
	public Vector4[] tangent;
}
