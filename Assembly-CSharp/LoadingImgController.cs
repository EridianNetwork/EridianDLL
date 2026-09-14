using System;
using System.Collections;
using System.Diagnostics;
using System.Text;
using Core;
using ns0;
using UnityEngine;
using XsdSettings;

// Token: 0x020006D3 RID: 1747
public class LoadingImgController : MonoBehaviour
{
	// Token: 0x06002E29 RID: 11817 RVA: 0x000D708C File Offset: 0x000D528C
	private void OnDestroy()
	{
		if (MonoSingleton<AssetBundleManager>.Instance != null)
		{
			MonoSingleton<AssetBundleManager>.Instance.method_14(this._bundleName, false);
		}
		if (this.m_instanceNameMaterial != null)
		{
			Texture texture = this.m_instanceNameMaterial.GetTexture("_MainTex");
			if (texture != null)
			{
				Resources.UnloadAsset(texture);
			}
		}
		if (this.m_backgroungMaterial != null)
		{
			Texture texture2 = this.m_backgroungMaterial.GetTexture("_MainTex");
			if (texture2 != null)
			{
				Resources.UnloadAsset(texture2);
			}
		}
	}

	// Token: 0x06002E2A RID: 11818 RVA: 0x000D7114 File Offset: 0x000D5314
	private void Start()
	{
		this._progressBar = base.transform.FindChild("InstanceLoadingBar");
		this._progressBarTrack = base.transform.FindChild("InstanceLoadingBarBG");
		this._progressWidth = this._progressBarTrack.GetComponent<MeshRenderer>().bounds.extents.x * 2f;
		this._progressMargin = this._progressWidth * 0.5f - this._progressBar.GetComponent<MeshRenderer>().bounds.extents.x;
		this._progressOriginalScale = this._progressBar.localScale.x;
		this._progressBar.localScale = new Vector3(0f, this._progressBar.localScale.y, this._progressBar.localScale.z);
		this._textMS = base.gameObject.GetComponentInChildren<TextMesh>();
		this._textMS.text = "0 %";
		this._totalBrushCount = 10;
		this._brushArray = new GameObject[this._totalBrushCount];
		Shader shader = Shader.Find("Transparent/Cutout/Soft Edge Unlit");
		this._instanceNamePlane = GameObject.Find("LoadingPageScreenshotPoly_Title");
		this.m_instanceNameMaterial = new Material(shader);
		this._instanceNamePlane.renderer.material = this.m_instanceNameMaterial;
		this._instanceBGPlane = GameObject.Find("PlaneContainer/Plane_1");
		for (int i = 1; i <= this._totalBrushCount; i++)
		{
			string text = ((i >= 10) ? i.ToString() : ("0" + i));
			string text2 = "Brush" + text;
			GameObject gameObject = GameObject.Find(text2);
			if (gameObject == null)
			{
				DebugUtils.LogError(LogCategory.GUI, "Object not found : " + text2);
			}
			this._brushArray[i - 1] = gameObject;
		}
		bool flag = false;
		Playlist playlist = MatchmakingService.MatchmakingService_0.method_1(this._iInstanceID);
		if (playlist != null)
		{
			GamemodeType gamemodeType = MatchmakingService.smethod_0(playlist.m_gameMode);
			flag = MatchmakingService.smethod_1(gamemodeType);
		}
		StringBuilder stringBuilder = new StringBuilder(this.LoadingTipsKeyPrefix);
		if (!flag)
		{
			int num = global::UnityEngine.Random.Range(1, this._TotalTipsCount + 1);
			if (num < 10)
			{
				stringBuilder.Append("00").Append(num);
			}
			else if (num < 100)
			{
				stringBuilder.Append("0").Append(num);
			}
			else
			{
				stringBuilder.Append(num);
			}
		}
		else
		{
			stringBuilder.Append("047");
		}
		this._strLoadingTips = LocalizedString.smethod_0(new LocalizedString(stringBuilder.ToString()));
		base.transform.FindChild("Tips").GetComponent<TextMesh>().text = this._strLoadingTips;
		base.StartCoroutine(this.method_1());
	}

	// Token: 0x06002E2B RID: 11819 RVA: 0x000D73E0 File Offset: 0x000D55E0
	private void method_0()
	{
		if (this._iResouceIndex >= 0 && this._iResouceIndex < this._LoadingResouce.Length)
		{
			string strTitleImgName = this._LoadingResouce[this._iResouceIndex].strTitleImgName;
			if (strTitleImgName == null)
			{
				DebugUtils.LogError(LogCategory.GUI, "Instance Name not set : Instance " + this._iResouceIndex);
			}
			this.TitleImgPath += strTitleImgName;
			Texture texture = (Texture)Resources.Load(this.TitleImgPath);
			this.m_instanceNameMaterial.SetTexture("_MainTex", texture);
			this.m_instanceNameMaterial.SetFloat("_TextureAlpha", 1f);
		}
	}

	// Token: 0x06002E2C RID: 11820 RVA: 0x000D7484 File Offset: 0x000D5684
	public IEnumerator method_1()
	{
		string strBGImgFolderName = _LoadingResouce[_iResouceIndex].strBGImgFolderName;
		if (strBGImgFolderName == null)
		{
			DebugUtils.LogError(LogCategory.GUI, "Empty instance name : instance " + _iResouceIndex);
			yield break;
		}
		_bundleName = LoadingBundlePrefix + strBGImgFolderName.ToLower() + ".assetbundle";
		yield return StartCoroutine(ns0.MonoSingleton<AssetBundleManager>.Instance.method_4(_bundleName, null, null, bool_0: true));
		while (!ns0.MonoSingleton<AssetBundleManager>.Instance.method_10(_bundleName))
		{
			yield return null;
		}
		Texture planeTexture = ns0.MonoSingleton<AssetBundleManager>.Instance.method_7(_bundleName) as Texture;
		m_backgroungMaterial = _instanceBGPlane.renderer.material;
		m_backgroungMaterial.mainTexture = planeTexture;
		_instanceBGPlane.renderer.material = m_backgroungMaterial;
		method_0();
	}
	// Token: 0x06002E2D RID: 11821 RVA: 0x000D74A0 File Offset: 0x000D56A0
	public void method_2(int int_0)
	{
		for (int i = 0; i < this._LoadingResouce.Length; i++)
		{
			if (this._LoadingResouce[i].iPlayListID == int_0)
			{
				this._iResouceIndex = i;
				return;
			}
		}
		if (int_0 == 33)
		{
			for (int j = 0; j < this._LoadingResouce.Length; j++)
			{
				if (this._LoadingResouce[j].iPlayListID == 3333)
				{
					this._iResouceIndex = j;
					return;
				}
			}
		}
		this._iInstanceID = int_0;
	}

	// Token: 0x06002E2E RID: 11822 RVA: 0x000D7514 File Offset: 0x000D5714
	public void method_3(float float_0)
	{
		if (float_0 < 0f)
		{
			DebugUtils.LogError(LogCategory.GUI, "Progress percent over range");
			return;
		}
		float num = float_0 * 100f / 90f;
		int num2 = Mathf.FloorToInt((float)this._totalBrushCount * num);
		if (num2 > 10)
		{
			num2 = 10;
		}
		for (int i = 0; i < num2; i++)
		{
			this._brushArray[i].SetActive(false);
		}
	}

	// Token: 0x06002E2F RID: 11823 RVA: 0x000D7574 File Offset: 0x000D5774
	private void Update()
	{
		this.method_3(100f);
		float num = MonoSingleton<LevelLoadingManager>.Instance.method_1();
		int num2 = (int)(num * 100f);
		if (num2 != 0)
		{
			this._iCurPercent = num2;
			this.method_4(num);
		}
	}

	// Token: 0x06002E30 RID: 11824 RVA: 0x000D75B4 File Offset: 0x000D57B4
	private void method_4(float float_0)
	{
		if (this._progressBar != null)
		{
			this._progressBar.localScale = new Vector3(this._progressOriginalScale * float_0, this._progressBar.localScale.y, this._progressBar.localScale.z);
			float x = this._progressBar.GetComponent<MeshRenderer>().bounds.extents.x;
			this._progressBar.localPosition = new Vector3(this._progressMargin + this._progressBarTrack.localPosition.x - this._progressWidth * 0.5f + x, this._progressBar.localPosition.y, this._progressBar.localPosition.z);
		}
		if (this._textMS != null)
		{
			this._textMS.text = this._iCurPercent + " %";
		}
	}

	// Token: 0x04002050 RID: 8272
	public const string Path_LOADING_IN_ASSETS = "Assets/ArtResources/UI/Textures/";

	// Token: 0x04002051 RID: 8273
	public int _RowCount;

	// Token: 0x04002052 RID: 8274
	public int _ColumnCount;

	// Token: 0x04002053 RID: 8275
	public int _TotalTipsCount = 52;

	// Token: 0x04002054 RID: 8276
	protected int _iCurPercent;

	// Token: 0x04002055 RID: 8277
	public string LoadingTipsKeyPrefix = "Loading_Tips_";

	// Token: 0x04002056 RID: 8278
	public string LoadingBundlePrefix = "loading_";

	// Token: 0x04002057 RID: 8279
	public string TGA_Prefix = "GUI_Loading_";

	// Token: 0x04002058 RID: 8280
	public int LoadingTipsFontSize = 16;

	// Token: 0x04002059 RID: 8281
	public string BGImgPath;

	// Token: 0x0400205A RID: 8282
	public string TitleImgPath;

	// Token: 0x0400205B RID: 8283
	protected string _strLoadingTips;

	// Token: 0x0400205C RID: 8284
	protected Transform _progressBar;

	// Token: 0x0400205D RID: 8285
	protected Transform _progressBarTrack;

	// Token: 0x0400205E RID: 8286
	protected float _progressWidth;

	// Token: 0x0400205F RID: 8287
	protected float _progressMargin;

	// Token: 0x04002060 RID: 8288
	protected float _progressOriginalScale;

	// Token: 0x04002061 RID: 8289
	protected TextMesh _textMS;

	// Token: 0x04002062 RID: 8290
	protected Material m_instanceNameMaterial;

	// Token: 0x04002063 RID: 8291
	protected Material m_backgroungMaterial;

	// Token: 0x04002064 RID: 8292
	public LoadingImgController.LoadingResource[] _LoadingResouce;

	// Token: 0x04002065 RID: 8293
	private GameObject[] _brushArray;

	// Token: 0x04002066 RID: 8294
	private GameObject _instanceNamePlane;

	// Token: 0x04002067 RID: 8295
	private GameObject _instanceBGPlane;

	// Token: 0x04002068 RID: 8296
	protected int _totalBrushCount;

	// Token: 0x04002069 RID: 8297
	protected int _iResouceIndex;

	// Token: 0x0400206A RID: 8298
	protected int _iInstanceID;

	// Token: 0x0400206B RID: 8299
	protected string _bundleName;

	// Token: 0x020006D4 RID: 1748
	[Serializable]
	public class LoadingResource
	{
		// Token: 0x0400206C RID: 8300
		public string strTitleImgName = string.Empty;

		// Token: 0x0400206D RID: 8301
		public string strBGImgFolderName = string.Empty;

		// Token: 0x0400206E RID: 8302
		public int iPlayListID;
	}
}
