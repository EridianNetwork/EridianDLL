using System;
using System.Collections;
using Core;
using ns0;
using UnityEngine;

// Token: 0x020005DD RID: 1501
public class SnapEffectMgr
{
	// Token: 0x06002602 RID: 9730 RVA: 0x000B778C File Offset: 0x000B598C
	public void method_0(GameObject gameObject_0)
	{
		this.mSnapRT = new RenderTexture(this.mSnapWidth, this.mSnapHeight, 24);
		this.mSnapRT.name = "SnapEffectMgr_mSnapRT";
		this.mSnapRT.Create();
		this.mSnapMesh = new Mesh();
		this.mSnapCamera = gameObject_0.AddComponent<Camera>();
		this.mSnapCamera.renderingPath = RenderingPath.UsePlayerSettings;
		this.mSnapCamera.cullingMask = 1 << this.mSnapLayer;
		this.mSnapCamera.targetTexture = this.mSnapRT;
		this.mSnapCamera.depth = 100f;
		this.mSnapCamera.clearFlags = CameraClearFlags.Color;
		this.mSnapCamera.backgroundColor = new Color(0f, 0f, 0f, 0f);
		this.mSnapCamera.nearClipPlane = 0.01f;
		this.mSnapCamera.useOcclusionCulling = false;
		gameObject_0.AddComponent<SnapImageEffect>();
		this.mSnapQueue = new Queue();
		this.mSnapStart = false;
		this.mSnapUv = new Rect(0f, 0f, 1f, 1f);
		this.mSnapCamera.gameObject.SetActive(false);
	}

	// Token: 0x06002603 RID: 9731 RVA: 0x00019C6C File Offset: 0x00017E6C
	public void Update()
	{
		this.method_4();
	}

	// Token: 0x06002604 RID: 9732 RVA: 0x00019C74 File Offset: 0x00017E74
	public void method_1(GameObject gameObject_0)
	{
		if (gameObject_0 != null)
		{
			ComponentHelper.smethod_0(gameObject_0, this.mSnapCamera.gameObject);
		}
	}

	// Token: 0x06002605 RID: 9733 RVA: 0x000B78C0 File Offset: 0x000B5AC0
	public void method_2(SkinnedMeshRenderer skinnedMeshRenderer_0, ref Matrix4x4 matrix4x4_0, Texture2D texture2D_0, TexPostEffectMgr.POST_EFFECT_TYPE post_EFFECT_TYPE_0 = TexPostEffectMgr.POST_EFFECT_TYPE.POST_EFFECT_UI)
	{
		if (skinnedMeshRenderer_0 == null)
		{
			DebugUtils.LogError(LogCategory.Graphics, "Null Snap Mesh!");
			return;
		}
		if (texture2D_0 == null)
		{
			DebugUtils.LogError(LogCategory.Graphics, "Null Snap Tex!");
			return;
		}
		Matrix4x4 localToWorldMatrix = this.mSnapCamera.gameObject.transform.localToWorldMatrix;
		SnapEffectMgr.SnapItem snapItem = new SnapEffectMgr.SnapItem(texture2D_0, localToWorldMatrix * matrix4x4_0, skinnedMeshRenderer_0, post_EFFECT_TYPE_0);
		this.mSnapQueue.Enqueue(snapItem);
	}

	// Token: 0x06002606 RID: 9734 RVA: 0x00019C90 File Offset: 0x00017E90
	public bool method_3()
	{
		return this.mSnapStart;
	}

	// Token: 0x06002607 RID: 9735 RVA: 0x000B7930 File Offset: 0x000B5B30
	public void method_4()
	{
		if (this.mSnapQueue.Count > 0 && !this.mSnapStart)
		{
			SnapEffectMgr.SnapItem snapItem = this.mSnapQueue.Peek() as SnapEffectMgr.SnapItem;
			if (snapItem == null)
			{
				return;
			}
			if (snapItem.mItemTex == null)
			{
				return;
			}
			this.mItemTexW = snapItem.mItemTex.width;
			this.mItemTexH = snapItem.mItemTex.height;
			this.mResultRt = RenderTexture.GetTemporary(this.mItemTexW, this.mItemTexH);
			this.mSnapCamera.gameObject.SetActive(true);
			MonoSingleton<GraphicsMgr>.Instance.method_25().method_2(LightsMgr.LightObjectType.LT_SnapLightsGroup, true);
			this.method_9(snapItem.mSnapMesh, snapItem.mToWorldMat);
			this.mSnapStart = true;
		}
	}

	// Token: 0x06002608 RID: 9736 RVA: 0x0000311B File Offset: 0x0000131B
	private void method_5(Texture2D texture2D_0, string string_0)
	{
	}

	// Token: 0x06002609 RID: 9737 RVA: 0x00019C98 File Offset: 0x00017E98
	public Rect method_6()
	{
		return this.mSnapUv;
	}

	// Token: 0x0600260A RID: 9738 RVA: 0x000B79F4 File Offset: 0x000B5BF4
	private void method_7(SkinnedMeshRenderer skinnedMeshRenderer_0, Matrix4x4 matrix4x4_0)
	{
		Bounds localBounds = skinnedMeshRenderer_0.localBounds;
		Vector3[] array = new Vector3[]
		{
			new Vector3(localBounds.min.x, localBounds.min.y, localBounds.min.z),
			new Vector3(localBounds.max.x, localBounds.min.y, localBounds.min.z),
			new Vector3(localBounds.max.x, localBounds.max.y, localBounds.min.z),
			new Vector3(localBounds.min.x, localBounds.max.y, localBounds.min.z),
			new Vector3(localBounds.min.x, localBounds.min.y, localBounds.max.z),
			new Vector3(localBounds.max.x, localBounds.min.y, localBounds.max.z),
			new Vector3(localBounds.max.x, localBounds.max.y, localBounds.max.z),
			new Vector3(localBounds.min.x, localBounds.max.y, localBounds.max.z)
		};
		Bounds bounds = default(Bounds);
		Matrix4x4 matrix4x = this.mSnapCamera.projectionMatrix * this.mSnapCamera.worldToCameraMatrix * matrix4x4_0;
		for (int i = 0; i < 8; i++)
		{
			Vector3 vector = matrix4x.MultiplyVector(array[i]);
			vector.x *= 0.5f;
			vector.x += 0.5f;
			vector.y *= 0.5f;
			vector.y += 0.5f;
			if (i == 0)
			{
				bounds = new Bounds(vector, Vector3.zero);
			}
			bounds.Encapsulate(vector);
		}
		Vector3 min = bounds.min;
		Vector3 max = bounds.max;
		this.mSnapUv = new Rect(min.x, min.y, max.x - min.x, max.y - min.y);
		if (this.mSnapUv.width + this.mSnapUv.x > 1f)
		{
			this.mSnapUv.width = 1f - this.mSnapUv.x;
		}
		if (this.mSnapUv.height + this.mSnapUv.y > 1f)
		{
			this.mSnapUv.height = 1f - this.mSnapUv.y;
		}
	}

	// Token: 0x0600260B RID: 9739 RVA: 0x000B7D94 File Offset: 0x000B5F94
	public IEnumerator method_8(RenderTexture renderTexture_0)
	{
		if (mSnapQueue.Count > 0 && mSnapStart)
		{
			yield return new WaitForEndOfFrame();
			SnapItem curItem = mSnapQueue.Dequeue() as SnapItem;
			RenderTexture currentActiveRT = RenderTexture.active;
			RenderTexture.active = renderTexture_0;
			curItem.mItemTex.ReadPixels(new Rect(0f, 0f, renderTexture_0.width, renderTexture_0.height), 0, 0);
			curItem.mItemTex.Apply();
			RenderTexture.active = currentActiveRT;
			ns0.MonoSingleton<GraphicsMgr>.Instance.method_23().method_4(curItem.mItemTex, curItem.mPostEffectType);
			RenderTexture.ReleaseTemporary(mResultRt);
			mSnapStart = false;
			ns0.MonoSingleton<GraphicsMgr>.Instance.method_25().method_2(LightsMgr.LightObjectType.LT_SnapLightsGroup, bool_0: false);
			mSnapCamera.gameObject.SetActive(value: false);
		}
		else
		{
			yield return null;
		}
	}
	// Token: 0x0600260C RID: 9740 RVA: 0x000B7DC0 File Offset: 0x000B5FC0
	private void method_9(SkinnedMeshRenderer skinnedMeshRenderer_0, Matrix4x4 matrix4x4_0)
	{
		if (skinnedMeshRenderer_0 != null)
		{
			skinnedMeshRenderer_0.BakeMesh(this.mSnapMesh);
			this.method_7(skinnedMeshRenderer_0, matrix4x4_0);
			Graphics.DrawMesh(this.mSnapMesh, matrix4x4_0, skinnedMeshRenderer_0.material, this.mSnapLayer, this.mSnapCamera);
		}
	}

	// Token: 0x04001BA3 RID: 7075
	private Camera mSnapCamera;

	// Token: 0x04001BA4 RID: 7076
	public int mSnapLayer = 22;

	// Token: 0x04001BA5 RID: 7077
	private RenderTexture mSnapRT;

	// Token: 0x04001BA6 RID: 7078
	private int mSnapWidth = 1280;

	// Token: 0x04001BA7 RID: 7079
	private int mSnapHeight = 720;

	// Token: 0x04001BA8 RID: 7080
	private Mesh mSnapMesh;

	// Token: 0x04001BA9 RID: 7081
	private GameObject mSnapPostEffect;

	// Token: 0x04001BAA RID: 7082
	private Matrix4x4 mToWorldMat;

	// Token: 0x04001BAB RID: 7083
	private Queue mSnapQueue;

	// Token: 0x04001BAC RID: 7084
	private bool mSnapStart;

	// Token: 0x04001BAD RID: 7085
	private Rect mSnapUv;

	// Token: 0x04001BAE RID: 7086
	public int mItemTexW;

	// Token: 0x04001BAF RID: 7087
	public int mItemTexH;

	// Token: 0x04001BB0 RID: 7088
	public RenderTexture mResultRt;

	// Token: 0x020005DE RID: 1502
	public class SnapItem
	{
		// Token: 0x0600260D RID: 9741 RVA: 0x00019CA0 File Offset: 0x00017EA0
		public SnapItem(Texture2D texture2D_0, Matrix4x4 matrix4x4_0, SkinnedMeshRenderer skinnedMeshRenderer_0, TexPostEffectMgr.POST_EFFECT_TYPE post_EFFECT_TYPE_0)
		{
			this.mItemTex = texture2D_0;
			this.mToWorldMat = matrix4x4_0;
			this.mSnapMesh = skinnedMeshRenderer_0;
			this.mPostEffectType = post_EFFECT_TYPE_0;
		}

		// Token: 0x04001BB1 RID: 7089
		public Texture2D mItemTex;

		// Token: 0x04001BB2 RID: 7090
		public Matrix4x4 mToWorldMat;

		// Token: 0x04001BB3 RID: 7091
		public SkinnedMeshRenderer mSnapMesh;

		// Token: 0x04001BB4 RID: 7092
		public TexPostEffectMgr.POST_EFFECT_TYPE mPostEffectType;
	}
}
