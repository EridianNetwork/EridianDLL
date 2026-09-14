using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using pumpkin.display;
using pumpkin.geom;
using pumpkin.swf;
using pumpkin.utils;
using UnityEngine;

namespace pumpkin.displayInternal
{
	// Token: 0x0200076E RID: 1902
	public class BadAssGraphicsDrawMeshGenerator : IGraphicsGenerator
	{
		// Token: 0x1700026C RID: 620
		// (get) Token: 0x0600324C RID: 12876 RVA: 0x00020CA5 File Offset: 0x0001EEA5
		// (set) Token: 0x0600324D RID: 12877 RVA: 0x00020CAD File Offset: 0x0001EEAD
		public MeshGeneratorOptions meshGeneratorOptions
		{
			get
			{
				return this.meshGeneratorOptions_0;
			}
			set
			{
				this.meshGeneratorOptions_0 = value;
			}
		}

		// Token: 0x0600324E RID: 12878 RVA: 0x000E41FC File Offset: 0x000E23FC
		public bool renderStage(Stage stage)
		{
			this.stage_0 = stage;
			this.list_1.Clear();
			this.list_0.Clear();
			this.arrayPool_0.method_4();
			this.material_0 = null;
			this.int_0 = -1;
			this.int_4 = 0;
			this.float_2 = 0f;
			this.int_5 = GraphicsDrawMeshGenerator.PHASE_SCAN;
			this.int_6 = 0;
			this.int_7 = 0;
			this.int_8 = 0;
			this.int_9 = 0;
			BadAssSwfGraphicsRenderState badAssSwfGraphicsRenderState = default(BadAssSwfGraphicsRenderState);
			badAssSwfGraphicsRenderState.int_0 = 0;
			float num = 1f;
			float num2 = 1f;
			badAssSwfGraphicsRenderState.color_0.a = num;
			float num3 = num2;
			num2 = 1f;
			badAssSwfGraphicsRenderState.color_0.b = num3;
			float num4 = num2;
			num2 = 1f;
			badAssSwfGraphicsRenderState.color_0.g = num4;
			badAssSwfGraphicsRenderState.color_0.r = num2;
			badAssSwfGraphicsRenderState.bool_0 = false;
			badAssSwfGraphicsRenderState.displayObject_0 = null;
			badAssSwfGraphicsRenderState.bool_1 = false;
			this.method_0(stage, badAssSwfGraphicsRenderState);
			this.list_0.Add(this.material_0);
			this.list_1.Add(this.arrayPool_0.method_0(this.int_9));
			Mesh mesh = this.method_5();
			mesh.Clear();
			if (this.vector3_0.Length < this.int_6)
			{
				this.vector3_0 = new Vector3[this.int_6];
			}
			if (this.vector2_0.Length < this.int_7)
			{
				this.vector2_0 = new Vector2[this.int_7];
			}
			if (this.color_0.Length < this.int_8)
			{
				this.color_0 = new Color[this.int_8];
			}
			this.material_0 = null;
			this.int_0 = -1;
			this.int_4 = 0;
			this.float_2 = 0f;
			this.int_5 = GraphicsDrawMeshGenerator.PHASE_BUILD;
			this.int_10 = 0;
			this.int_11 = 0;
			this.int_12 = 0;
			this.int_13 = 0;
			badAssSwfGraphicsRenderState.int_0 = 0;
			float num5 = 1f;
			num2 = 1f;
			badAssSwfGraphicsRenderState.color_0.a = num5;
			float num6 = num2;
			num2 = 1f;
			badAssSwfGraphicsRenderState.color_0.b = num6;
			float num7 = num2;
			num2 = 1f;
			badAssSwfGraphicsRenderState.color_0.g = num7;
			badAssSwfGraphicsRenderState.color_0.r = num2;
			badAssSwfGraphicsRenderState.bool_0 = false;
			badAssSwfGraphicsRenderState.displayObject_0 = null;
			badAssSwfGraphicsRenderState.bool_1 = false;
			this.method_0(stage, badAssSwfGraphicsRenderState);
			this.int_14 = Time.frameCount;
			mesh.vertices = this.vector3_0;
			mesh.uv = this.vector2_0;
			mesh.colors = this.color_0;
			mesh.subMeshCount = this.list_1.Count;
			for (int i = 0; i < this.list_1.Count; i++)
			{
				int[] array = this.list_1[i];
				mesh.SetTriangles(array, i);
			}
			if (this.meshGeneratorOptions_0.doubleBuffered)
			{
				this.bool_1 = !this.bool_1;
			}
			return true;
		}

		// Token: 0x0600324F RID: 12879 RVA: 0x000E44E0 File Offset: 0x000E26E0
		private void method_0(DisplayObjectContainer displayObjectContainer_0, BadAssSwfGraphicsRenderState badAssSwfGraphicsRenderState_0)
		{
			if (displayObjectContainer_0.visible && displayObjectContainer_0.alpha > 0f)
			{
				int num = badAssSwfGraphicsRenderState_0.int_0;
				if (displayObjectContainer_0.blendMode != 0)
				{
					badAssSwfGraphicsRenderState_0.int_0 = displayObjectContainer_0.blendMode;
				}
				Color color = badAssSwfGraphicsRenderState_0.color_0;
				bool flag = badAssSwfGraphicsRenderState_0.bool_0;
				badAssSwfGraphicsRenderState_0.color_0 = displayObjectContainer_0.colorTransform * badAssSwfGraphicsRenderState_0.color_0;
				if (displayObjectContainer_0.hasClipRect)
				{
					badAssSwfGraphicsRenderState_0.bool_0 = true;
					badAssSwfGraphicsRenderState_0.displayObject_0 = displayObjectContainer_0;
					badAssSwfGraphicsRenderState_0.bool_1 = false;
				}
				bool flag2;
				if (flag2 = displayObjectContainer_0 is pumpkin.display.Sprite)
				{
					pumpkin.display.Sprite sprite = displayObjectContainer_0 as pumpkin.display.Sprite;
					this.method_1(sprite.graphics, sprite, badAssSwfGraphicsRenderState_0);
				}
				for (int i = 0; i < displayObjectContainer_0.numChildren; i++)
				{
					DisplayObject childAt = displayObjectContainer_0.getChildAt(i);
					if (childAt is DisplayObjectContainer)
					{
						this.method_0(childAt as DisplayObjectContainer, badAssSwfGraphicsRenderState_0);
					}
				}
				if (flag2)
				{
					this.float_2 += this.float_1;
				}
				if (!flag)
				{
					badAssSwfGraphicsRenderState_0.displayObject_0 = null;
					badAssSwfGraphicsRenderState_0.bool_1 = false;
				}
				badAssSwfGraphicsRenderState_0.bool_0 = flag;
				badAssSwfGraphicsRenderState_0.color_0 = color;
				badAssSwfGraphicsRenderState_0.int_0 = num;
				return;
			}
		}

		// Token: 0x06003250 RID: 12880 RVA: 0x000E460C File Offset: 0x000E280C
		private void method_1(pumpkin.display.Graphics graphics_0, pumpkin.display.Sprite sprite_0, BadAssSwfGraphicsRenderState badAssSwfGraphicsRenderState_0)
		{
			if (sprite_0.visible && sprite_0.alpha > 0f)
			{
				for (int i = 0; i < graphics_0.drawOPs.Count; i++)
				{
					GraphicsDrawOP graphicsDrawOP = graphics_0.drawOPs[i];
					if (graphicsDrawOP.material != null)
					{
						int num = badAssSwfGraphicsRenderState_0.int_0;
						if (num != 0 && graphicsDrawOP.material.shader != TextureManager.baseBitmapAddShader)
						{
							Texture mainTexture = graphicsDrawOP.material.mainTexture;
							graphicsDrawOP.material = new Material(TextureManager.baseBitmapAddShader);
							graphicsDrawOP.material.mainTexture = mainTexture;
						}
						if (this.int_5 == GraphicsDrawMeshGenerator.PHASE_SCAN)
						{
							if (this.material_0 != graphicsDrawOP.material)
							{
								this.int_0++;
								if (this.material_0)
								{
									this.list_0.Add(this.material_0);
									this.list_1.Add(this.arrayPool_0.method_0(this.int_9));
									this.int_13 = 0;
									this.int_9 = 0;
								}
								this.material_0 = graphicsDrawOP.material;
							}
							if (graphicsDrawOP.simpleVectorShape != null)
							{
								int num2 = graphicsDrawOP.simpleVectorShape.vertices.Length;
								this.int_6 += num2;
								this.int_7 += num2;
								this.int_8 += num2;
								if (graphicsDrawOP.simpleVectorShape.cachedTriangulatedIndex == null)
								{
									BadAssTriangulator badAssTriangulator = new BadAssTriangulator(graphicsDrawOP.simpleVectorShape.vertices);
									graphicsDrawOP.simpleVectorShape.cachedTriangulatedIndex = badAssTriangulator.method_0();
								}
								this.int_9 += graphicsDrawOP.simpleVectorShape.cachedTriangulatedIndex.Length;
								this.int_4 += num2 / 4;
							}
							else
							{
								this.int_6 += 4;
								this.int_7 += 4;
								this.int_8 += 4;
								this.int_9 += 6;
								this.int_4++;
							}
							this.float_2 += this.float_0;
						}
						else if (this.int_5 == GraphicsDrawMeshGenerator.PHASE_BUILD)
						{
							if (this.material_0 != graphicsDrawOP.material)
							{
								this.int_0++;
								this.material_0 = graphicsDrawOP.material;
								this.int_13 = 0;
							}
							Matrix matrix = sprite_0._fastGetFullMatrixRef();
							float num3 = graphicsDrawOP.x;
							float num4 = graphicsDrawOP.y;
							float num5 = graphicsDrawOP.drawWidth;
							float num6 = graphicsDrawOP.drawHeight;
							Rect drawSrcRect = graphicsDrawOP.drawSrcRect;
							float num7 = this.float_2;
							bool flag;
							if (flag = badAssSwfGraphicsRenderState_0.bool_0)
							{
								Rect rect;
								if (!badAssSwfGraphicsRenderState_0.bool_1)
								{
									rect = (badAssSwfGraphicsRenderState_0.rect_0 = this.method_8(badAssSwfGraphicsRenderState_0.displayObject_0));
									badAssSwfGraphicsRenderState_0.bool_1 = true;
								}
								else
								{
									rect = badAssSwfGraphicsRenderState_0.rect_0;
								}
								if (rect.width != 0f && rect.height != 0f)
								{
									Rect rect2 = this.method_7(graphicsDrawOP, sprite_0, rect);
									BadAssUVPixelRect badAssUVPixelRect = new BadAssUVPixelRect(num3, num4, num5, num6, drawSrcRect.x, drawSrcRect.y, drawSrcRect.width, drawSrcRect.height);
									badAssUVPixelRect.method_0(rect2.width);
									badAssUVPixelRect.method_1(rect2.height);
									badAssUVPixelRect.method_2(rect2.x);
									badAssUVPixelRect.method_3(rect2.y);
									num3 = rect2.x;
									num4 = rect2.y;
									num5 = rect2.width;
									num6 = rect2.height;
									drawSrcRect.x = badAssUVPixelRect.float_4;
									drawSrcRect.y = badAssUVPixelRect.float_5;
									drawSrcRect.width = badAssUVPixelRect.float_6;
									drawSrcRect.height = badAssUVPixelRect.float_7;
								}
							}
							if (graphicsDrawOP.simpleVectorShape != null)
							{
								float num8 = 1f / (float)graphicsDrawOP.material.mainTexture.width;
								float num9 = 1f / (float)graphicsDrawOP.material.mainTexture.height;
								Color color = badAssSwfGraphicsRenderState_0.color_0 * graphicsDrawOP.color;
								if (color.a > 0f)
								{
									float xMin = drawSrcRect.xMin;
									float xMax = drawSrcRect.xMax;
									float yMin = drawSrcRect.yMin;
									float yMax = drawSrcRect.yMax;
									int num10 = graphicsDrawOP.simpleVectorShape.vertices.Length / 4;
									for (int j = 0; j < num10; j++)
									{
										int num11 = j << 2;
										if (flag)
										{
											float num12 = (float)((graphicsDrawOP.simpleVectorShape.vertices[num11].x <= graphicsDrawOP.simpleVectorShape.vertices[num11 + 2].x) ? (-1) : 1);
											float num13 = (float)((graphicsDrawOP.simpleVectorShape.vertices[num11].y <= graphicsDrawOP.simpleVectorShape.vertices[num11 + 2].y) ? (-1) : 1);
											for (int k = 0; k < 4; k++)
											{
												Vector2 vector = graphicsDrawOP.simpleVectorShape.vertices[num11 + k];
												float num14 = ((vector.x >= xMax) ? xMax : vector.x);
												num14 = ((num14 <= xMin) ? xMin : num14);
												float num15 = num14 - vector.x;
												vector.x = num14;
												num14 = ((vector.y >= yMax) ? yMax : vector.y);
												num14 = ((num14 <= yMin) ? yMin : num14);
												float num16 = num14 - vector.y;
												vector.y = num14;
												Vector2 vector2 = graphicsDrawOP.simpleVectorShape.uv[num11 + k];
												if (num12 + num13 == 0f)
												{
													vector2.y -= num15 * num12 * num9;
													vector2.x += num16 * num13 * num8;
												}
												else
												{
													vector2.x += num15 * num12 * num8;
													vector2.y -= num16 * num13 * num9;
												}
												Vector3 vector3 = this.method_6(matrix, vector.x, vector.y, this.float_2);
												this.vector3_0[this.int_10++] = vector3;
												this.vector2_0[this.int_11++] = vector2;
												this.color_0[this.int_12] = graphicsDrawOP.simpleVectorShape.colors[num11 + k];
												this.color_0[this.int_12++].a = graphicsDrawOP.simpleVectorShape.colors[num11].a * color.a;
											}
										}
										else
										{
											for (int l = 0; l < 4; l++)
											{
												Vector2 vector4 = graphicsDrawOP.simpleVectorShape.vertices[num11 + l];
												Vector3 vector5 = this.method_6(matrix, vector4.x, vector4.y, this.float_2);
												this.vector3_0[this.int_10++] = vector5;
												this.vector2_0[this.int_11++] = graphicsDrawOP.simpleVectorShape.uv[num11 + l];
												this.color_0[this.int_12] = graphicsDrawOP.simpleVectorShape.colors[num11 + l];
												Color[] array = this.color_0;
												int num17 = this.int_12++;
												array[num17].a = array[num17].a * color.a;
											}
										}
									}
									int[] array2 = this.list_1[this.int_0];
									for (int m = 0; m < graphicsDrawOP.simpleVectorShape.cachedTriangulatedIndex.Length; m++)
									{
										array2[this.int_13++] = graphicsDrawOP.simpleVectorShape.cachedTriangulatedIndex[m] + this.int_4 * 4;
									}
									this.int_4 += graphicsDrawOP.simpleVectorShape.vertices.Length / 4;
								}
							}
							else
							{
								this.vector2_2.x = drawSrcRect.x;
								this.vector2_2.y = 1f - drawSrcRect.y;
								this.vector2_3.x = drawSrcRect.width;
								this.vector2_3.y = drawSrcRect.height;
								if (graphicsDrawOP.matrix != null)
								{
									this.vector2_0[this.int_11++] = graphicsDrawOP.calcFromUV(num3 + num5, num4);
									this.vector2_0[this.int_11++] = graphicsDrawOP.calcFromUV(num3 + num5, num4 + num6);
									this.vector2_0[this.int_11++] = graphicsDrawOP.calcFromUV(num3, num4 + num6);
									this.vector2_0[this.int_11++] = graphicsDrawOP.calcFromUV(num3, num4);
								}
								else
								{
									this.vector2_1.x = this.vector2_2.x + this.vector2_3.x;
									this.vector2_1.y = this.vector2_2.y;
									this.vector2_0[this.int_11++] = this.vector2_1;
									this.vector2_1.x = this.vector2_2.x + this.vector2_3.x;
									this.vector2_1.y = this.vector2_2.y - this.vector2_3.y;
									this.vector2_0[this.int_11++] = this.vector2_1;
									this.vector2_1.x = this.vector2_2.x;
									this.vector2_1.y = this.vector2_2.y - this.vector2_3.y;
									this.vector2_0[this.int_11++] = this.vector2_1;
									this.vector2_1.x = this.vector2_2.x;
									this.vector2_1.y = this.vector2_2.y;
									this.vector2_0[this.int_11++] = this.vector2_1;
								}
								if (GraphicsDrawMeshGenerator.enableSubPixel_uv && !TextureManager.isOpenGL && this.material_0.HasProperty("_MainTex"))
								{
									Vector2 vector6 = new Vector2(1f / (float)this.material_0.mainTexture.width, 1f / (float)this.material_0.mainTexture.height);
									Vector2 vector7 = new Vector2(vector6.x * 0.5f, vector6.y * 0.5f);
									this.vector2_2.x = this.vector2_2.x + vector7.x;
									this.vector2_2.y = this.vector2_2.y + vector7.y;
									this.vector2_3.x = this.vector2_3.x - vector7.x;
									this.vector2_3.y = this.vector2_3.y - vector7.y;
									this.vector2_0[this.int_11 - 4] = new Vector2(this.vector2_2.x + this.vector2_3.x, this.vector2_2.y);
									this.vector2_0[this.int_11 - 3] = new Vector2(this.vector2_2.x + this.vector2_3.x, this.vector2_2.y - this.vector2_3.y);
									this.vector2_0[this.int_11 - 2] = new Vector2(this.vector2_2.x, this.vector2_2.y - this.vector2_3.y);
									this.vector2_0[this.int_11 - 1] = new Vector2(this.vector2_2.x, this.vector2_2.y);
								}
								Color color2 = badAssSwfGraphicsRenderState_0.color_0 * graphicsDrawOP.color;
								this.color_0[this.int_12++] = color2;
								this.color_0[this.int_12++] = color2;
								this.color_0[this.int_12++] = color2;
								this.color_0[this.int_12++] = color2;
								if (graphicsDrawOP.flipped)
								{
									this.vector3_0[this.int_10++] = this.method_6(matrix, num3, num4, num7);
									this.vector3_0[this.int_10++] = this.method_6(matrix, num3, num4 + num6, num7);
									this.vector3_0[this.int_10++] = this.method_6(matrix, num3 + num5, num4 + num6, num7);
									this.vector3_0[this.int_10++] = this.method_6(matrix, num3 + num5, num4, num7);
								}
								else
								{
									this.vector3_0[this.int_10++] = this.method_6(matrix, num3 + num5, num4, num7);
									this.vector3_0[this.int_10++] = this.method_6(matrix, num3 + num5, num4 + num6, num7);
									this.vector3_0[this.int_10++] = this.method_6(matrix, num3, num4 + num6, num7);
									this.vector3_0[this.int_10++] = this.method_6(matrix, num3, num4, num7);
								}
								if (GraphicsDrawMeshGenerator.enableSubPixel_vert)
								{
									Vector3 one = Vector3.one;
									Vector3 vector8 = (TextureManager.isOpenGL ? Vector3.zero : (one * 0.5f));
									if (graphicsDrawOP.pixelSnapping != 0)
									{
										this.vector3_0[this.int_10 - 4].x = Mathf.Floor(this.vector3_0[this.int_10 - 4].x);
										this.vector3_0[this.int_10 - 4].y = Mathf.Floor(this.vector3_0[this.int_10 - 4].y);
										this.vector3_0[this.int_10 - 3].x = Mathf.Floor(this.vector3_0[this.int_10 - 3].x);
										this.vector3_0[this.int_10 - 3].y = Mathf.Floor(this.vector3_0[this.int_10 - 3].y);
										this.vector3_0[this.int_10 - 2].x = Mathf.Floor(this.vector3_0[this.int_10 - 2].x);
										this.vector3_0[this.int_10 - 2].y = Mathf.Floor(this.vector3_0[this.int_10 - 2].y);
										this.vector3_0[this.int_10 - 1].x = Mathf.Floor(this.vector3_0[this.int_10 - 1].x);
										this.vector3_0[this.int_10 - 1].y = Mathf.Floor(this.vector3_0[this.int_10 - 1].y);
									}
									this.vector3_0[this.int_10 - 4] -= vector8;
									this.vector3_0[this.int_10 - 3] -= vector8;
									this.vector3_0[this.int_10 - 2] -= vector8;
									this.vector3_0[this.int_10 - 1] -= vector8;
								}
								if (sprite_0.rotateX != 0f || sprite_0.rotateY != 0f || sprite_0.rotateZ != 0f)
								{
									Quaternion quaternion = Quaternion.Euler(sprite_0.rotateX, sprite_0.rotateY, sprite_0.rotateZ);
									Matrix4x4 matrix4x = pumpkin.utils.Utils.MatrixFromQuaternion(quaternion);
									this.vector3_0[this.int_10 - 4] = matrix4x.MultiplyVector(this.vector3_0[this.int_10 - 4]);
									this.vector3_0[this.int_10 - 3] = matrix4x.MultiplyVector(this.vector3_0[this.int_10 - 3]);
									this.vector3_0[this.int_10 - 2] = matrix4x.MultiplyVector(this.vector3_0[this.int_10 - 2]);
									this.vector3_0[this.int_10 - 1] = matrix4x.MultiplyVector(this.vector3_0[this.int_10 - 1]);
								}
								if (this.int_0 >= this.list_1.Count)
								{
									return;
								}
								int[] array3 = this.list_1[this.int_0];
								array3[this.int_13++] = this.int_4 * 4;
								array3[this.int_13++] = this.int_4 * 4 + 1;
								array3[this.int_13++] = this.int_4 * 4 + 3;
								array3[this.int_13++] = this.int_4 * 4 + 3;
								array3[this.int_13++] = this.int_4 * 4 + 1;
								array3[this.int_13++] = this.int_4 * 4 + 2;
								this.int_4++;
							}
							this.float_2 += this.float_0;
						}
					}
				}
				return;
			}
		}

		// Token: 0x06003251 RID: 12881 RVA: 0x000E5A64 File Offset: 0x000E3C64
		private void method_2(DisplayObject displayObject_0, DisplayObject displayObject_1, Material material_1)
		{
			Matrix matrix = displayObject_0._fastGetFullMatrixRef().clone();
			Matrix matrix2 = displayObject_1._fastGetFullMatrixRef().clone();
			Vector2 vector = matrix.transformPoint(Vector2.zero);
			Vector2 vector2 = matrix2.transformPoint(Vector2.zero);
			Vector2 vector3 = new Vector2(matrix2.getScaleX(), matrix2.getScaleY());
			Vector2 vector4 = new Vector2(matrix.getScaleX(), matrix.getScaleY());
			float num = displayObject_0.rotation - displayObject_1.rotation;
			Matrix matrix3 = new Matrix(vector3.x * (1f / vector4.x), 0f, 0f, -vector3.y * (1f / vector4.y), 0f, 0f);
			float num2 = (float)((double)num * 3.141592653589793 / 180.0);
			matrix3.rotate(num2);
			material_1.SetVector("_Matrix2D", new Vector4(matrix3.a, matrix3.b, matrix3.c, matrix3.d));
			Matrix matrix4 = new Matrix(1f, 0f, 0f, 1f, vector.x - vector2.x, vector.y - vector2.y);
			num2 = (float)(-(double)displayObject_0.rotation * 3.141592653589793 / 180.0);
			matrix4.rotate(num2);
			Vector2 vector5 = matrix4.transformPoint(Vector2.zero);
			material_1.SetFloat("_tX", -(vector5.x / (float)material_1.mainTexture.width) * (1f / vector4.x));
			material_1.SetFloat("_tY", vector5.y / (float)material_1.mainTexture.height * (1f / vector4.y));
		}

		// Token: 0x06003252 RID: 12882 RVA: 0x000E5C38 File Offset: 0x000E3E38
		private GraphicsDrawOP method_3(DisplayObject displayObject_0)
		{
			if (displayObject_0 is pumpkin.display.Sprite)
			{
				pumpkin.display.Sprite sprite = displayObject_0 as pumpkin.display.Sprite;
				if (sprite.graphics.drawOPs.Count > 0)
				{
					return sprite.graphics.drawOPs[0];
				}
			}
			if (displayObject_0 is DisplayObjectContainer || displayObject_0 is MovieClip)
			{
				DisplayObjectContainer displayObjectContainer = displayObject_0 as DisplayObjectContainer;
				for (int i = 0; i < displayObjectContainer.numChildren; i++)
				{
					GraphicsDrawOP graphicsDrawOP = this.method_3(displayObjectContainer.getChildAt(i));
					if (graphicsDrawOP != null)
					{
						return graphicsDrawOP;
					}
				}
			}
			return null;
		}

		// Token: 0x06003253 RID: 12883 RVA: 0x000E5CB8 File Offset: 0x000E3EB8
		public void drawMeshNow(Matrix4x4 camMatrix, Vector3 drawOffset, Vector3 drawScale)
		{
			drawOffset.z += 1f;
			drawScale.z = drawScale.x;
			Matrix4x4 matrix4x = Matrix4x4.TRS(drawOffset, Quaternion.identity, drawScale);
			matrix4x = camMatrix * matrix4x;
			Mesh mesh = this.method_5();
			mesh.subMeshCount = this.list_1.Count;
			for (int i = 0; i < this.list_1.Count; i++)
			{
				Material material = this.list_0[i];
				if (!(material == null) && material.SetPass(0))
				{
					global::UnityEngine.Graphics.DrawMeshNow(mesh, matrix4x, i);
				}
			}
		}

		// Token: 0x06003254 RID: 12884 RVA: 0x000E5D50 File Offset: 0x000E3F50
		public void method_4(Matrix4x4 matrix4x4_0, Vector3 vector3_2, Vector3 vector3_3)
		{
			vector3_3.z = vector3_3.x * -10f;
			Matrix4x4 matrix4x = Matrix4x4.TRS(vector3_2, Quaternion.identity, vector3_3);
			matrix4x = matrix4x4_0 * matrix4x;
			while (this.arrayList_0.Count < this.list_1.Count)
			{
				this.arrayList_0.Add(new Mesh());
			}
			Mesh mesh = this.method_5();
			mesh.subMeshCount = this.list_1.Count;
			for (int i = 0; i < this.list_1.Count; i++)
			{
				Mesh mesh2 = (Mesh)this.arrayList_0[i];
				mesh2.Clear();
				mesh2.vertices = this.vector3_0;
				mesh2.uv = this.vector2_0;
				mesh2.colors = this.color_0;
				mesh2.triangles = this.list_1[i];
				Material material = this.list_0[i];
				global::UnityEngine.Graphics.DrawMesh(mesh2, matrix4x, material, 0, null, 0, null);
			}
		}

		// Token: 0x06003255 RID: 12885 RVA: 0x000E5E48 File Offset: 0x000E4048
		public Mesh method_5()
		{
			if (this.bool_1)
			{
				if (this.mesh_0 == null)
				{
					this.mesh_0 = new Mesh();
					this.mesh_0.name = "mesh_0";
				}
				return this.mesh_0;
			}
			if (this.mesh_1 == null)
			{
				this.mesh_1 = new Mesh();
				this.mesh_1.name = "mesh_1";
			}
			return this.mesh_1;
		}

		// Token: 0x06003256 RID: 12886 RVA: 0x000E5EBC File Offset: 0x000E40BC
		public SimpleStageRenderResult getSimpleStageRenderResult()
		{
			Mesh mesh = this.method_5();
			this.simpleStageRenderResult_0.materials = this.list_0.ToArray();
			this.simpleStageRenderResult_0.mesh = mesh;
			return this.simpleStageRenderResult_0;
		}

		// Token: 0x06003257 RID: 12887 RVA: 0x000E5EF8 File Offset: 0x000E40F8
		public Mesh applyToMeshRenderer(MeshRenderer meshRenderer)
		{
			Mesh mesh = this.method_5();
			mesh.vertices = this.vector3_0;
			mesh.uv = this.vector2_0;
			mesh.colors = this.color_0;
			if (meshRenderer)
			{
				meshRenderer.materials = this.list_0.ToArray();
			}
			mesh.subMeshCount = this.list_1.Count;
			for (int i = 0; i < this.list_1.Count; i++)
			{
				int[] array = this.list_1[i];
				mesh.SetTriangles(array, i);
			}
			return mesh;
		}

		// Token: 0x06003258 RID: 12888 RVA: 0x000E5F88 File Offset: 0x000E4188
		private Vector3 method_6(Matrix matrix_0, float float_3, float float_4, float float_5)
		{
			this.vector3_1.x = float_3 * matrix_0.a + float_4 * matrix_0.c + matrix_0.tx;
			this.vector3_1.y = float_3 * matrix_0.b + float_4 * matrix_0.d + matrix_0.ty;
			this.vector3_1.z = float_5;
			return this.vector3_1;
		}

		// Token: 0x06003259 RID: 12889 RVA: 0x000E5FF0 File Offset: 0x000E41F0
		private Rect method_7(GraphicsDrawOP graphicsDrawOP_0, pumpkin.display.Sprite sprite_0, Rect rect_2)
		{
			Matrix matrix = sprite_0._fastGetFullMatrixRef().clone();
			matrix.invert();
			float num = rect_2.x * matrix.a + rect_2.y * matrix.c + matrix.tx;
			float num2 = rect_2.x * matrix.b + rect_2.y * matrix.d + matrix.ty;
			float num3 = matrix.a * rect_2.width;
			float num4 = matrix.d * rect_2.height;
			float x = graphicsDrawOP_0.x;
			float y = graphicsDrawOP_0.y;
			float num5 = graphicsDrawOP_0.x + graphicsDrawOP_0.width;
			float num6 = graphicsDrawOP_0.y + graphicsDrawOP_0.height;
			float num7 = num;
			float num8 = num2;
			float num9 = num7 + num3;
			float num10 = num8 + num4;
			float num11 = ((x < num7) ? num7 : x);
			float num12 = ((num5 > num9) ? num9 : num5);
			if (num12 <= num11)
			{
				return this.rect_0;
			}
			float num13 = ((y < num8) ? num8 : y);
			float num14 = ((num6 > num10) ? num10 : num6);
			if (num14 <= num13)
			{
				return this.rect_0;
			}
			this.rect_1.x = num11;
			this.rect_1.y = num13;
			this.rect_1.width = num12 - num11;
			this.rect_1.height = num14 - num13;
			return this.rect_1;
		}

		// Token: 0x0600325A RID: 12890 RVA: 0x000E614C File Offset: 0x000E434C
		private Rect method_8(DisplayObject displayObject_0)
		{
			if (displayObject_0.rotation != 0f || displayObject_0.scaleX < 0f || displayObject_0.scaleY < 0f)
			{
				return this.rect_0;
			}
			if (displayObject_0.hasClipRect)
			{
				Rect rect = this.rect_0;
				Matrix matrix = displayObject_0._fastGetFullMatrixRef();
				rect.x = displayObject_0.clipRect.x * matrix.a + displayObject_0.clipRect.y * matrix.c + matrix.tx;
				rect.y = displayObject_0.clipRect.x * matrix.b + displayObject_0.clipRect.y * matrix.d + matrix.ty;
				rect.width = matrix.a * displayObject_0.clipRect.width;
				rect.height = matrix.d * displayObject_0.clipRect.height;
				if (displayObject_0.parent != null)
				{
					Rect rect2 = this.method_8(displayObject_0.parent);
					Rectangle rectangle = new Rectangle(rect2.x, rect2.y, rect2.width, rect2.height);
					Rectangle rectangle2 = new Rectangle(rect.x, rect.y, rect.width, rect.height);
					Rectangle rectangle3 = rectangle.intersection(rectangle2);
					if (rect2.width != 0f && rect2.height != 0f)
					{
						if (rectangle3.width != 0f && rectangle3.height != 0f)
						{
							rect = rectangle3.rect;
						}
						else
						{
							rect.x -= 100000f;
						}
					}
				}
				return rect;
			}
			if (displayObject_0.parent == null)
			{
				return this.rect_0;
			}
			return this.method_8(displayObject_0.parent);
		}

		// Token: 0x0600325B RID: 12891 RVA: 0x000E6334 File Offset: 0x000E4534
		private Rect method_9(DisplayObject displayObject_0)
		{
			Type type = displayObject_0.GetType();
			FieldInfo field = type.GetField("m_GlobalClipRect", BindingFlags.Instance | BindingFlags.NonPublic);
			return (Rect)field.GetValue(displayObject_0);
		}

		// Token: 0x0600325C RID: 12892 RVA: 0x000E6364 File Offset: 0x000E4564
		private void method_10(DisplayObject displayObject_0, ref Rect rect_2)
		{
			Type type = displayObject_0.GetType();
			FieldInfo field = type.GetField("m_GlobalClipRect", BindingFlags.Instance | BindingFlags.NonPublic);
			field.SetValue(displayObject_0, rect_2);
		}

		// Token: 0x0600325D RID: 12893 RVA: 0x00020CB6 File Offset: 0x0001EEB6
		private DisplayObject method_11(DisplayObject displayObject_0)
		{
			if (displayObject_0.mask != null)
			{
				return displayObject_0.mask;
			}
			if (displayObject_0.parent == null)
			{
				return displayObject_0.mask;
			}
			return this.method_11(displayObject_0.parent);
		}

		// Token: 0x040022C6 RID: 8902
		public Material material_0;

		// Token: 0x040022C7 RID: 8903
		private int int_0;

		// Token: 0x040022C8 RID: 8904
		public static int int_1;

		// Token: 0x040022C9 RID: 8905
		public static int int_2 = 1;

		// Token: 0x040022CA RID: 8906
		public static int int_3 = 2;

		// Token: 0x040022CB RID: 8907
		public float float_0 = 0.1f;

		// Token: 0x040022CC RID: 8908
		public float float_1;

		// Token: 0x040022CD RID: 8909
		public Vector3[] vector3_0 = new Vector3[0];

		// Token: 0x040022CE RID: 8910
		public Vector2[] vector2_0 = new Vector2[0];

		// Token: 0x040022CF RID: 8911
		public Color[] color_0 = new Color[0];

		// Token: 0x040022D0 RID: 8912
		public List<Material> list_0 = new List<Material>();

		// Token: 0x040022D1 RID: 8913
		public List<int[]> list_1 = new List<int[]>();

		// Token: 0x040022D2 RID: 8914
		private ArrayPool<int> arrayPool_0 = new ArrayPool<int>();

		// Token: 0x040022D3 RID: 8915
		public bool bool_0;

		// Token: 0x040022D4 RID: 8916
		protected float float_2;

		// Token: 0x040022D5 RID: 8917
		protected int int_4;

		// Token: 0x040022D6 RID: 8918
		protected int int_5;

		// Token: 0x040022D7 RID: 8919
		protected int int_6;

		// Token: 0x040022D8 RID: 8920
		protected int int_7;

		// Token: 0x040022D9 RID: 8921
		protected int int_8;

		// Token: 0x040022DA RID: 8922
		protected int int_9;

		// Token: 0x040022DB RID: 8923
		protected int int_10;

		// Token: 0x040022DC RID: 8924
		protected int int_11;

		// Token: 0x040022DD RID: 8925
		protected int int_12;

		// Token: 0x040022DE RID: 8926
		protected int int_13;

		// Token: 0x040022DF RID: 8927
		protected Stage stage_0;

		// Token: 0x040022E0 RID: 8928
		public int int_14 = -2;

		// Token: 0x040022E1 RID: 8929
		public Mesh mesh_0;

		// Token: 0x040022E2 RID: 8930
		public Mesh mesh_1;

		// Token: 0x040022E3 RID: 8931
		private bool bool_1 = true;

		// Token: 0x040022E4 RID: 8932
		public static bool bool_2;

		// Token: 0x040022E5 RID: 8933
		public static bool bool_3 = true;

		// Token: 0x040022E6 RID: 8934
		private Vector2 vector2_1;

		// Token: 0x040022E7 RID: 8935
		private Vector2 vector2_2;

		// Token: 0x040022E8 RID: 8936
		private Vector2 vector2_3;

		// Token: 0x040022E9 RID: 8937
		private ArrayList arrayList_0 = new ArrayList();

		// Token: 0x040022EA RID: 8938
		private MeshGeneratorOptions meshGeneratorOptions_0 = new MeshGeneratorOptions();

		// Token: 0x040022EB RID: 8939
		public SimpleStageRenderResult simpleStageRenderResult_0 = new SimpleStageRenderResult();

		// Token: 0x040022EC RID: 8940
		private Vector3 vector3_1;

		// Token: 0x040022ED RID: 8941
		private Rect rect_0 = default(Rect);

		// Token: 0x040022EE RID: 8942
		private Rect rect_1;
	}
}
