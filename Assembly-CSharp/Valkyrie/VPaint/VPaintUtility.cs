using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

namespace Valkyrie.VPaint
{
	// Token: 0x02000B8F RID: 2959
	public static class VPaintUtility
	{
		// Token: 0x06004FEF RID: 20463 RVA: 0x00153844 File Offset: 0x00151A44
		public static void MergeColors(Color[] source, float[] sourceTransparency, Color[] target, float[] targetTransparency, VPaintBlendMode blendMode, float opacity, bool maskR, bool maskG, bool maskB, bool maskA)
		{
			if (source.Length != target.Length)
			{
				return;
			}
			for (int i = 0; i < source.Length; i++)
			{
				Color color = source[i];
				Color color2 = color;
				Color color3 = target[i];
				float num = Mathf.Clamp01(targetTransparency[i] * opacity);
				switch (blendMode)
				{
				case VPaintBlendMode.Opaque:
					color2 = color3;
					break;
				case VPaintBlendMode.Additive:
					color2 = color + color3;
					break;
				case VPaintBlendMode.Multiply:
					color2 = color * color3;
					break;
				case VPaintBlendMode.Overlay:
					color2 = color * color3 * 2f;
					break;
				}
				color2 = Color.Lerp(color, color2, num);
				if (maskR)
				{
					color.r = color2.r;
				}
				if (maskG)
				{
					color.g = color2.g;
				}
				if (maskB)
				{
					color.b = color2.b;
				}
				if (maskA)
				{
					color.a = color2.a;
				}
				source[i] = color;
				sourceTransparency[i] = Mathf.Clamp01(sourceTransparency[i] + num);
			}
		}

		// Token: 0x06004FF0 RID: 20464 RVA: 0x0015394C File Offset: 0x00151B4C
		public static void BlendRadial(VPaintLayer[] layers, VPaintObject[] blendObjects, VPaintObject[] blendTargets, float radius, float intensity = 1f, Bounds? bounds = null)
		{
			IEnumerator<VPaintProgress> enumerator = VPaintUtility.BlendRadialAsync(layers, blendObjects, blendTargets, radius, intensity, bounds);
			while (enumerator.MoveNext())
			{
			}
		}

		// Token: 0x06004FF1 RID: 20465 RVA: 0x00153970 File Offset: 0x00151B70
	public static IEnumerator<VPaintProgress> BlendRadialAsync(VPaintLayer[] layers, VPaintObject[] blendObjects, VPaintObject[] blendTargets, float radius, float intensity = 1f, Bounds? bounds = null)
	{
		List<VPaintObject> validTargets = new List<VPaintObject>();
		int num = 0;
		int j;
		while (true)
		{
			if (num < blendTargets.Length)
			{
				VPaintObject vc = blendTargets[num];
				if (!Application.isPlaying || vc.Boolean_0)
				{
					if (!bounds.HasValue || bounds.Value.Intersects(vc.editorCollider.bounds))
					{
						validTargets.Add(vc);
					}
					num++;
					continue;
				}
				throw new VPaintObjectNotDynamicException();
			}
			j = 0;
			break;
		}
		for (; j < layers.Length; j++)
		{
			VPaintLayer layer = layers[j];
			for (int i = 0; i < blendObjects.Length; i++)
			{
				VPaintObject vc2 = blendObjects[i];
				yield return new VPaintProgress
				{
					message = "Blending " + vc2.name + " on layer " + layer.name,
					progress = (float)i / (float)blendObjects.Length
				};
				Mesh k = vc2.method_6();
				Vector3[] vertices = k.vertices;
				VPaintVertexData paintData = layer.GetOrCreate(vc2);
				Color[] colors = paintData.colors;
				float[] trans = paintData.transparency;
				Transform t = vc2.transform;
				Vector4[] colTotal = new Vector4[colors.Length];
				float[] transTotal = new float[trans.Length];
				float[] facTotal = new float[trans.Length];
				float[] distTotal = new float[trans.Length];
				float[] countTotal = new float[trans.Length];
				for (int d = 0; d < distTotal.Length; d++)
				{
					distTotal[d] = radius;
				}
				for (int tg = 0; tg < validTargets.Count; tg++)
				{
					VPaintObject targ = validTargets[tg];
					VPaintVertexData targPaintData = layer.GetOrCreate(targ);
					if (targPaintData == null)
					{
						continue;
					}
					Mesh targMesh = targ.method_6();
					Vector3[] targVerts = targMesh.vertices;
					Color[] targCols = targPaintData.colors;
					float[] targTrans = targPaintData.transparency;
					Transform transform = targ.transform;
					for (int v2 = 0; v2 < vertices.Length; v2++)
					{
						Vector4 avg = Vector4.zero;
						float avgTrans = 0f;
						float shortestDist = radius;
						float fac2 = 0f;
						int total = 0;
						Vector3 vert = t.TransformPoint(vertices[v2]);
						for (int v3 = 0; v3 < targVerts.Length; v3++)
						{
							Vector3 targVert = transform.TransformPoint(targVerts[v3]);
							if (!bounds.HasValue || bounds.Value.Contains(targVert))
							{
								float dist = Vector3.Distance(vert, targVert);
								if (radius >= dist)
								{
									float factor = 1f - dist / radius;
									fac2 += factor;
									avg += (Vector4)(targCols[v3] * factor);
									avgTrans += targTrans[v3] * factor;
									total++;
									shortestDist = Mathf.Min(dist, shortestDist);
								}
							}
						}
						colTotal[v2] += avg;
						transTotal[v2] += avgTrans;
						facTotal[v2] += fac2;
						countTotal[v2] += total;
						distTotal[v2] = Mathf.Min(distTotal[v2], shortestDist);
					}
				}
				for (int v = 0; v < colors.Length; v++)
				{
					float fac = facTotal[v];
					Color col = ((fac != 0f) ? ((Color)colTotal[v] / fac) : default(Color));
					float tr = ((fac != 0f) ? (transTotal[v] / fac) : 0f);
					float count = countTotal[v];
					float lerp2 = ((count != 0f) ? (1f - distTotal[v] / radius) : 0f);
					lerp2 *= intensity;
					paintData.colors[v] = Color.Lerp(paintData.colors[v], col, lerp2);
					paintData.transparency[v] = Mathf.Lerp(paintData.transparency[v], tr, lerp2);
				}
			}
		}
	}
		// Token: 0x06004FF2 RID: 20466 RVA: 0x001539DC File Offset: 0x00151BDC
		public static void BlendDirectional(VPaintLayer[] layers, VPaintObject[] blendObjects, VPaintObject[] blendTargets, Vector3 direction, float distance, float intensity = 1f, float falloff = 1f, Vector3? offset = null, Bounds? bounds = null)
		{
			IEnumerator<VPaintProgress> enumerator = VPaintUtility.BlendDirectionalAsync(layers, blendObjects, blendTargets, direction, distance, intensity, falloff, offset, bounds);
			while (enumerator.MoveNext())
			{
			}
		}

		// Token: 0x06004FF3 RID: 20467 RVA: 0x00153A08 File Offset: 0x00151C08
	public static IEnumerator<VPaintProgress> BlendDirectionalAsync(VPaintLayer[] layers, VPaintObject[] blendObjects, VPaintObject[] blendTargets, Vector3 direction, float distance, float intensity = 1f, float falloff = 1f, Vector3? offset = null, Bounds? bounds = null)
	{
		if (!offset.HasValue)
		{
			offset = Vector3.zero;
		}
		List<VPaintObject> validTargets = new List<VPaintObject>();
		int num = 0;
		int j;
		while (true)
		{
			if (num < blendTargets.Length)
			{
				VPaintObject vc = blendTargets[num];
				if (!Application.isPlaying || vc.Boolean_0)
				{
					if (!bounds.HasValue || bounds.Value.Intersects(vc.editorCollider.bounds))
					{
						validTargets.Add(vc);
					}
					num++;
					continue;
				}
				throw new VPaintObjectNotDynamicException();
			}
			j = 0;
			break;
		}
		for (; j < layers.Length; j++)
		{
			VPaintLayer layer = layers[j];
			for (int i = 0; i < blendObjects.Length; i++)
			{
				VPaintObject vc2 = blendObjects[i];
				string message = "Blending " + vc2.name + " on layer " + layer.name;
				float progressBase = (float)i / (float)blendObjects.Length;
				float progressRange = ((float)(i + 1) / (float)blendObjects.Length - progressBase) / 1f;
				Mesh k = vc2.method_6();
				Vector3[] vertices = k.vertices;
				VPaintVertexData paintData = layer.GetOrCreate(vc2);
				Color[] colors = paintData.colors;
				float[] trans = paintData.transparency;
				Transform t = vc2.transform;
				float offsetMagnitude = offset.Value.magnitude;
				for (int v = 0; v < vertices.Length; v++)
				{
					yield return new VPaintProgress
					{
						message = message,
						progress = progressBase + progressRange * (float)v / (float)vertices.Length
					};
					Vector3 vert = t.TransformPoint(vertices[v]);
					if (bounds.HasValue && !bounds.Value.Contains(vert))
					{
						continue;
					}
					Vector4 avgCol = Vector4.zero;
					float avgTran = 0f;
					float fac = 0f;
					float count = 0f;
					foreach (VPaintObject target in validTargets)
					{
						MeshCollider mc = target.editorCollider;
						Ray r = new Ray(vert + offset.Value, direction);
						if (mc.Raycast(r, out var hit, distance) && (!bounds.HasValue || bounds.Value.Contains(hit.point)))
						{
							Mesh mi = target.method_6();
							if ((bool)mi)
							{
								int[] triangles = mi.triangles;
								VPaintVertexData pd = layer.GetOrCreate(target);
								int t2 = triangles[hit.triangleIndex * 3];
								int t3 = triangles[hit.triangleIndex * 3 + 1];
								int t4 = triangles[hit.triangleIndex * 3 + 2];
								Color c1 = pd.colors[t2];
								Color c2 = pd.colors[t3];
								Color c3 = pd.colors[t4];
								float tr1 = pd.transparency[t2];
								float tr2 = pd.transparency[t3];
								float tr3 = pd.transparency[t4];
								Vector3 bc = hit.barycentricCoordinate;
								Color sampleColor = c1 * bc.x + c2 * bc.y + c3 * bc.z;
								float sampleTran = tr1 * bc.x + tr2 * bc.y + tr3 * bc.z;
								float factor = Mathf.Pow(1f - (hit.distance - offsetMagnitude) / distance, falloff);
								fac += factor;
								avgTran += sampleTran * factor;
								avgCol += (Vector4)sampleColor * factor;
								count += 1f;
							}
						}
					}
					Color col = avgCol / fac;
					float tran = avgTran / fac;
					if (fac != 0f)
					{
						float lerp = intensity * (fac / count);
						colors[v] = Color.Lerp(colors[v], col, lerp);
						trans[v] = Mathf.Lerp(trans[v], tran, lerp);
					}
				}
			}
		}
	}
		// Token: 0x06004FF4 RID: 20468 RVA: 0x00153AA4 File Offset: 0x00151CA4
	public static IEnumerator LerpColors(VPaintObject obj, Color[] start, Color[] end, float time)
	{
		float t = 0f;
		int len = start.Length;
		Color[] lerp = new Color[len];
		for (; t < time; t += Time.deltaTime)
		{
			float f = t / time;
			for (int i = 0; i < len; i++)
			{
				lerp[i] = Color.Lerp(start[i], end[i], f);
			}
			obj.method_3(lerp);
			yield return null;
		}
		obj.method_3(end);
	}
	}
}