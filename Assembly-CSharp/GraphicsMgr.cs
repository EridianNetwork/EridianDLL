using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using BHV;
using Core;
using ns0;
using UnityEngine;

// Token: 0x020005A8 RID: 1448
public class GraphicsMgr : MonoSingleton<GraphicsMgr>
{
	// Token: 0x060024C1 RID: 9409 RVA: 0x000AFE64 File Offset: 0x000AE064
	public GraphicsMgr()
	{
		this.mLastResolution = default(Resolution);
		this.restoreResolution = default(Resolution);
		this.OnChangeResolution = new Action<int, int>(GraphicsMgr.smethod_0);
		if (MonoSingleton<AppManager>.Instance == null || !MonoSingleton<AppManager>.Instance.OnlineHostMinResMode)
		{
			this.mCharacterFxMgr = new CharacterFxMgr();
			this.mCameraEffectMgr = new CameraEffectMgr();
			this.mSnapEffectMgr = new SnapEffectMgr();
			this.mFpEffectMgr = new FpEffectMgr();
			this.mNpcTitleMgr = new NpcTitleMgr();
			this.mUIPreviewMgr = new UIPreviewMgr();
			this.mTexPostEffectMgr = new TexPostEffectMgr();
			this.mFpCameraEffectMgr = new FpCameraEffectMgr();
			this.mLightsMgr = new LightsMgr();
			this.mIsHideFpMesh = false;
			this.mResIndex = 0;
			this.mWantSupportResInfoArray = new Resolution[2];
			this.mWantSupportResInfoArray[0] = default(Resolution);
			this.mWantSupportResInfoArray[0].width = 1280;
			this.mWantSupportResInfoArray[0].height = 720;
			this.mWantSupportResInfoArray[1] = default(Resolution);
			this.mWantSupportResInfoArray[1].width = 1920;
			this.mWantSupportResInfoArray[1].height = 1080;
			this.mSupportResInfoArray = new List<Resolution>(Screen.resolutions);
			this.mSupportFrameRates = new List<int> { 30, 60, 90, 120, 144, 240, -1 };
			this.mLastResolution.width = -1;
			this.mLastResolution.height = -1;
		}
	}

	// Token: 0x1400000A RID: 10
	// (add) Token: 0x060024C2 RID: 9410 RVA: 0x0001903A File Offset: 0x0001723A
	// (remove) Token: 0x060024C3 RID: 9411 RVA: 0x00019053 File Offset: 0x00017253
	public event Action<int, int> Event_0
	{
		[MethodImpl(MethodImplOptions.Synchronized)]
		add
		{
			this.OnChangeResolution = (Action<int, int>)Delegate.Combine(this.OnChangeResolution, value);
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		remove
		{
			this.OnChangeResolution = (Action<int, int>)Delegate.Remove(this.OnChangeResolution, value);
		}
	}

	// Token: 0x170001CB RID: 459
	// (get) Token: 0x060024C4 RID: 9412 RVA: 0x0001906C File Offset: 0x0001726C
	public bool Boolean_1
	{
		get
		{
			return this.mFullScreen;
		}
	}

	// Token: 0x060024C5 RID: 9413 RVA: 0x000B0008 File Offset: 0x000AE208
	public bool method_0()
	{
		OperatingSystem osversion = Environment.OSVersion;
		return osversion.Platform == PlatformID.Win32NT && osversion.Version.Major == 5;
	}

	// Token: 0x060024C6 RID: 9414 RVA: 0x00019074 File Offset: 0x00017274
	public void OnDestroyPerMapResources()
	{
		if (this.mNpcTitleMgr != null)
		{
			this.mNpcTitleMgr.OnDestroyPerMapResources();
		}
	}

	// Token: 0x060024C7 RID: 9415 RVA: 0x00019089 File Offset: 0x00017289
	public int method_1(int int_0)
	{
		if (int_0 < 0)
		{
			return this.mSupportFrameRates[0];
		}
		return this.mSupportFrameRates[int_0 % this.mSupportFrameRates.Count];
	}

	// Token: 0x060024C8 RID: 9416 RVA: 0x000190B4 File Offset: 0x000172B4
	public Resolution method_2()
	{
		return this.mWantSupportResInfoArray[0];
	}

	// Token: 0x060024C9 RID: 9417 RVA: 0x000B0038 File Offset: 0x000AE238
	public void method_3()
	{
		GameObject gameObject = global::UnityEngine.Object.Instantiate(Resources.Load("NoneSceneLighting/LightingInfo") as GameObject) as GameObject;
		if (gameObject != null)
		{
			if (gameObject != null)
			{
				gameObject.transform.parent = this.mGraphicMgrObj.transform;
				this.mGraphicMgrObj.transform.Translate(gameObject.transform.position, this.mGraphicMgrObj.transform);
				gameObject.transform.localPosition = Vector3.zero;
			}
		}
		else
		{
			DebugUtils.LogError(LogCategory.Graphics, "Missing None Scene Lighting info!");
		}
	}

	// Token: 0x060024CA RID: 9418 RVA: 0x000B00CC File Offset: 0x000AE2CC
	public void method_4()
	{
		if (MonoSingleton<AppManager>.Instance == null || !MonoSingleton<AppManager>.Instance.OnlineHostMinResMode)
		{
			this.mGraphicMgrObj = new GameObject("GraphicMgr");
			this.mGraphicMgrObj.transform.parent = base.gameObject.transform;
			if (this.mCharacterFxMgr != null)
			{
				this.mCharacterFxMgr.method_0();
			}
			GameObject gameObject = new GameObject("SnapCamera");
			gameObject.transform.parent = this.mGraphicMgrObj.transform;
			this.mSnapEffectMgr.method_0(gameObject);
			GameObject gameObject2 = new GameObject("TexPostEffect");
			gameObject2.transform.parent = this.mGraphicMgrObj.transform;
			this.mTexPostEffectMgr.method_3(gameObject2);
			this.mFpEffectMgr.method_3(this.mGraphicMgrObj);
			this.mFpCameraEffectMgr.method_0(this.mGraphicMgrObj);
			this.mNpcTitleMgr.method_0();
			GameObject gameObject3 = new GameObject("previewCamera");
			gameObject3.transform.parent = this.mGraphicMgrObj.transform;
			this.mUIPreviewMgr.method_10(gameObject3);
			this.method_3();
			this.method_29();
			GraphicsDataMgr.smethod_0();
		}
	}

	// Token: 0x060024CB RID: 9419 RVA: 0x000190C7 File Offset: 0x000172C7
	public Matrix4x4 method_5()
	{
		return this.mWpnCamControl.method_0();
	}

	// Token: 0x060024CC RID: 9420 RVA: 0x000B01F8 File Offset: 0x000AE3F8
	public void method_6(bool bool_0, int int_0 = 0, int int_1 = 0)
	{
		if (Application.platform != RuntimePlatform.WindowsPlayer)
		{
			return;
		}
		if (bool_0 == this.mFullScreen && Screen.width == int_0 && Screen.height == int_1)
		{
			return;
		}
		if (bool_0)
		{
			int[] array = this.method_28();
			this.posXBeforeFullScreen = array[0];
			this.posYBeforeFullScreen = array[1];
			this.restoreResolution.width = ((int_0 != 0) ? int_0 : Screen.width);
			this.restoreResolution.height = ((int_1 != 0) ? int_1 : Screen.height);
			Screen.SetResolution(Screen.currentResolution.width, Screen.currentResolution.height, false);
			if (!MonoSingleton<AppManager>.Instance.m_useWrapperWindow)
			{
				this.method_30(0, 0, Screen.currentResolution.width, Screen.currentResolution.height, true);
			}
			else
			{
				MonoSingleton<AppManager>.Instance.method_22(1029, (IntPtr)this.restoreResolution.width, (IntPtr)((long)((ulong)uint.Parse(this.restoreResolution.height.ToString() + 1))));
			}
			DebugUtils.Log(LogCategory.Graphics, string.Concat(new object[]
			{
				"SwitchResolution: SwitchFullScreen - ",
				this.restoreResolution.width,
				", ",
				this.restoreResolution.height,
				", ",
				true
			}));
			this.mFullScreen = true;
		}
		else
		{
			if (int_0 == 0)
			{
				int_0 = this.restoreResolution.width;
			}
			if (int_1 == 0)
			{
				int_1 = this.restoreResolution.height;
			}
			Screen.SetResolution(int_0, int_1, false);
			if (!MonoSingleton<AppManager>.Instance.m_useWrapperWindow)
			{
				this.method_30(this.posXBeforeFullScreen, this.posYBeforeFullScreen, int_0 + this.widthMargin * 2, int_1 + this.titleHeight + this.widthMargin, false);
			}
			else
			{
				MonoSingleton<AppManager>.Instance.method_22(1029, (IntPtr)int_0, (IntPtr)((long)((ulong)uint.Parse(int_1.ToString() + 0))));
			}
			DebugUtils.Log(LogCategory.Graphics, string.Concat(new object[]
			{
				"SwitchResolution: SwitchFullScreen - ",
				this.restoreResolution.width,
				", ",
				this.restoreResolution.height,
				", ",
				false
			}));
			this.mFullScreen = false;
		}
	}

	// Token: 0x060024CD RID: 9421 RVA: 0x000B046C File Offset: 0x000AE66C
	public void method_7()
	{
		this.mResIndex++;
		if (this.mResIndex >= this.mSupportResInfoArray.Count)
		{
			this.mResIndex = 0;
		}
		Resolution resolution = this.mSupportResInfoArray[this.mResIndex];
		Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen, 0);
		if (MonoSingleton<AppManager>.Instance.m_useWrapperWindow)
		{
			int num = ((!this.mFullScreen) ? 0 : 1);
			MonoSingleton<AppManager>.Instance.method_22(1029, (IntPtr)resolution.width, (IntPtr)((long)((ulong)uint.Parse(resolution.height.ToString() + num))));
			DebugUtils.Log(LogCategory.Graphics, string.Concat(new object[] { "SwitchResolution: SwitchResolution - ", resolution.width, ", ", resolution.height, ", ", num }));
		}
		this.mFullScreen = false;
	}

	// Token: 0x060024CE RID: 9422 RVA: 0x000190D4 File Offset: 0x000172D4
	public List<Resolution> method_8()
	{
		return this.mSupportResInfoArray;
	}

	// Token: 0x060024CF RID: 9423 RVA: 0x000B0580 File Offset: 0x000AE780
	public Resolution method_9()
	{
		Resolution resolution = default(Resolution);
		resolution.width = 0;
		resolution.height = 0;
		foreach (Resolution resolution2 in this.mSupportResInfoArray)
		{
			if (resolution2.width + resolution2.height > resolution.width + resolution.height)
			{
				resolution.width = resolution2.width;
				resolution.height = resolution2.height;
				resolution.refreshRate = resolution2.refreshRate;
			}
		}
		return resolution;
	}

	// Token: 0x060024D0 RID: 9424 RVA: 0x000B0630 File Offset: 0x000AE830
	public bool method_10(int int_0, int int_1)
	{
		foreach (Resolution resolution in this.mSupportResInfoArray)
		{
			if (resolution.width == int_0 && resolution.height == int_1)
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x060024D1 RID: 9425 RVA: 0x000B0698 File Offset: 0x000AE898
	public bool method_11(int int_0, int int_1)
	{
		if (!this.method_10(int_0, int_1))
		{
			DebugUtils.LogWarning(LogCategory.Graphics, string.Concat(new object[] { "This system can't support this resolution: width = ", int_0, ", height = ", int_1 }));
			return false;
		}
		if (Screen.width == int_0 && Screen.height == int_1)
		{
			return false;
		}
		Screen.SetResolution(int_0, int_1, Screen.fullScreen);
		if (MonoSingleton<AppManager>.Instance.m_useWrapperWindow)
		{
			int num = ((!this.mFullScreen) ? 0 : 1);
			MonoSingleton<AppManager>.Instance.method_22(1029, (IntPtr)int_0, (IntPtr)((long)((ulong)uint.Parse(int_1.ToString() + num))));
			DebugUtils.Log(LogCategory.Graphics, string.Concat(new object[] { "SwitchResolution: SwitchToResolution - ", int_0, ", ", int_1, ", ", num }));
		}
		return true;
	}

	// Token: 0x060024D2 RID: 9426 RVA: 0x000B0798 File Offset: 0x000AE998
	public void method_12()
	{
		if (this.mEntityPlay != null)
		{
			this.mOriSceneFov = this.mEntityPlay.vmethod_14().vmethod_0<BHVFirstPersonSettings>().m_FOVDefault;
			WeaponCameraControl componentInChildren = this.mEntityPlay.GetComponentInChildren<WeaponCameraControl>();
			Camera camera = componentInChildren.camera;
			this.mOriWpnFov = camera.fieldOfView;
			this.mOriCameraLSPos = this.mFpsCamera.transform.localPosition;
		}
	}

	// Token: 0x060024D3 RID: 9427 RVA: 0x000B0804 File Offset: 0x000AEA04
	private void method_13()
	{
		this.mEntityPlay.vmethod_14().vmethod_0<BHVFirstPersonSettings>().m_FOVDefault = this.mOriSceneFov;
		WeaponCameraControl componentInChildren = this.mEntityPlay.GetComponentInChildren<WeaponCameraControl>();
		Camera camera = componentInChildren.camera;
		camera.fieldOfView = this.mOriWpnFov;
		this.mEntityPlay.m_equipedWeapon.method_56(this.mOriWpnFov);
		GameObject gameObject = this.mEntityPlay.method_60().gameObject;
		SkinnedMeshRenderer component = gameObject.GetComponent<SkinnedMeshRenderer>();
		for (int i = 0; i < component.materials.Length; i++)
		{
			component.materials[i].SetMatrix("_ProjMat", componentInChildren.method_0());
		}
		this.mFpsCamera.transform.localPosition = this.mOriCameraLSPos;
	}

	// Token: 0x060024D4 RID: 9428 RVA: 0x000B08C0 File Offset: 0x000AEAC0
	public void method_14()
	{
		float num = 500f;
		float num2 = 100f;
		float num3 = 30f;
		float num4 = 150f;
		float num5 = 30f;
		if (this.mEntityPlay != null)
		{
			float num6 = GUI.HorizontalSlider(new Rect(num, num2 + num3, num4, num5), this.mEntityPlay.vmethod_14().vmethod_0<BHVFirstPersonSettings>().m_FOVDefault, 3f, 175f);
			GUI.Label(new Rect(num, num2, num4, num5), "Scene Fov : " + num6.ToString());
			this.mEntityPlay.vmethod_14().vmethod_0<BHVFirstPersonSettings>().m_FOVDefault = num6;
			WeaponCameraControl componentInChildren = this.mEntityPlay.GetComponentInChildren<WeaponCameraControl>();
			Camera camera = componentInChildren.camera;
			float fieldOfView = camera.fieldOfView;
			float num7 = GUI.HorizontalSlider(new Rect(num, num2 + num3 * 3f, num4, num5), camera.fieldOfView, 3f, 175f);
			GUI.Label(new Rect(num, num2 + num3 * 2f, num4, num5), "Weapon Fov : " + num7.ToString());
			if (!Mathf.Approximately(fieldOfView, num7))
			{
				this.mEntityPlay.m_equipedWeapon.method_56(num7);
				GameObject gameObject = this.mEntityPlay.method_60().gameObject;
				SkinnedMeshRenderer component = gameObject.GetComponent<SkinnedMeshRenderer>();
				for (int i = 0; i < component.materials.Length; i++)
				{
					component.materials[i].SetMatrix("_ProjMat", componentInChildren.method_0());
				}
			}
		}
		if (this.mEntityPlay != null)
		{
			Transform transform = this.mFpsCamera.transform;
			float num8 = 0.2f;
			float num9 = 0.5f;
			float num10 = 50f;
			float num11 = 30f;
			GUI.Label(new Rect(num, num2 + num3 * 5f, num4 + 300f, num5), "FpsCam Local : " + transform.localPosition.ToString("n3"));
			GUI.Label(new Rect(num, num2 + num3 * 6f, num10, num5), "z : ");
			float num12 = GUI.HorizontalSlider(new Rect(num + num11, num2 + num3 * 6f, 300f, num5), transform.localPosition.x, -0.5f, num9);
			GUI.Label(new Rect(num, num2 + num3 * 7f, num10, num5), "x : ");
			float num13 = GUI.HorizontalSlider(new Rect(num + num11, num2 + num3 * 7f, 300f, num5), transform.localPosition.y, -0.2f, num8);
			GUI.Label(new Rect(num, num2 + num3 * 8f, num10, num5), "y : ");
			float num14 = GUI.HorizontalSlider(new Rect(num + num11, num2 + num3 * 8f, 300f, num5), transform.localPosition.z, -0.2f, num8);
			transform.localPosition = new Vector3(num12, num13, num14);
			if (GUI.Button(new Rect(num, num2 + num3 * 9f, num10, num5), "Reset"))
			{
				this.method_13();
			}
		}
	}

	// Token: 0x060024D5 RID: 9429 RVA: 0x000B0BEC File Offset: 0x000AEDEC
	public void method_15(GameObject gameObject_0, float float_0)
	{
		if (!MonoSingleton<AppManager>.Instance.OnlineHostMinResMode && gameObject_0 != null)
		{
			float num = 10f;
			int num2 = (int)(gameObject_0.transform.position - this.mFpsCameraPos).magnitude;
			SkinnedMeshRenderer component = gameObject_0.GetComponent<SkinnedMeshRenderer>();
			if (component != null)
			{
				foreach (Material material in component.materials)
				{
					if ((float)num2 > num)
					{
						material.SetFloat("_BRDF_PARA", 0f);
					}
					else
					{
						material.SetFloat("_BRDF_PARA", float_0);
					}
				}
			}
		}
	}

	// Token: 0x060024D6 RID: 9430 RVA: 0x000190DC File Offset: 0x000172DC
	public CharacterFxMgr method_16()
	{
		return this.mCharacterFxMgr;
	}

	// Token: 0x060024D7 RID: 9431 RVA: 0x000B0C8C File Offset: 0x000AEE8C
	public void Update()
	{
		if (this.mFpsCamera != null)
		{
			this.mFpsCameraPos = this.mFpsCamera.transform.position;
		}
		this.mSnapEffectMgr.Update();
		if (this.mLastResolution.width != Screen.width || this.mLastResolution.height != Screen.height)
		{
			if (this.mLastResolution.width != -1 && this.mLastResolution.height != -1)
			{
				this.OnChangeResolution(Screen.width, Screen.height);
			}
			this.mLastResolution.width = Screen.width;
			this.mLastResolution.height = Screen.height;
		}
	}

	// Token: 0x060024D8 RID: 9432 RVA: 0x000190E4 File Offset: 0x000172E4
	public Camera method_17()
	{
		return this.mFpsCamera;
	}

	// Token: 0x060024D9 RID: 9433 RVA: 0x000B0D40 File Offset: 0x000AEF40
	public void FixedUpdate()
	{
		if (this.mEntityPlay == null && MonoSingleton<Session>.Instance != null && MonoSingleton<Session>.Instance.GetLocalPlayer() != null)
		{
			this.mEntityPlay = (EntityPlayer)MonoSingleton<Session>.Instance.GetLocalPlayer().GetEntity();
		}
		if (this.mFpsCamera == null && this.mEntityPlay != null && this.mEntityPlay.method_45() != null)
		{
			this.mFpsCamera = this.mEntityPlay.method_45().camera;
		}
		if (this.mEntityPlay != null && this.mWpnCamControl == null)
		{
			this.mWpnCamControl = this.mEntityPlay.GetComponentInChildren<WeaponCameraControl>();
		}
		if (this.mCharacterFxMgr != null)
		{
			this.mCharacterFxMgr.Update();
		}
	}

	// Token: 0x060024DA RID: 9434 RVA: 0x000190EC File Offset: 0x000172EC
	public CameraEffectMgr method_18()
	{
		return this.mCameraEffectMgr;
	}

	// Token: 0x060024DB RID: 9435 RVA: 0x000190F4 File Offset: 0x000172F4
	public SnapEffectMgr method_19()
	{
		return this.mSnapEffectMgr;
	}

	// Token: 0x060024DC RID: 9436 RVA: 0x000190FC File Offset: 0x000172FC
	public FpEffectMgr method_20()
	{
		return this.mFpEffectMgr;
	}

	// Token: 0x060024DD RID: 9437 RVA: 0x00019104 File Offset: 0x00017304
	public NpcTitleMgr method_21()
	{
		return this.mNpcTitleMgr;
	}

	// Token: 0x060024DE RID: 9438 RVA: 0x0001910C File Offset: 0x0001730C
	public UIPreviewMgr method_22()
	{
		return this.mUIPreviewMgr;
	}

	// Token: 0x060024DF RID: 9439 RVA: 0x00019114 File Offset: 0x00017314
	public TexPostEffectMgr method_23()
	{
		return this.mTexPostEffectMgr;
	}

	// Token: 0x060024E0 RID: 9440 RVA: 0x0001911C File Offset: 0x0001731C
	public FpCameraEffectMgr method_24()
	{
		return this.mFpCameraEffectMgr;
	}

	// Token: 0x060024E1 RID: 9441 RVA: 0x00019124 File Offset: 0x00017324
	public LightsMgr method_25()
	{
		return this.mLightsMgr;
	}

	// Token: 0x060024E2 RID: 9442 RVA: 0x000B0E1C File Offset: 0x000AF01C
	public void method_26()
	{
		List<Entity> list;
		MonoSingleton<EntityManager>.Instance.method_6(Entity.EntityType.Player, out list);
		for (int i = 0; i < list.Count; i++)
		{
			EntityPlayer entityPlayer = list[i] as EntityPlayer;
			if (!entityPlayer.vmethod_26())
			{
				entityPlayer.method_117(true);
			}
		}
	}

	// Token: 0x060024E3 RID: 9443 RVA: 0x000B0E64 File Offset: 0x000AF064
	public void method_27()
	{
		List<Entity> list;
		MonoSingleton<EntityManager>.Instance.method_6(Entity.EntityType.Player, out list);
		for (int i = 0; i < list.Count; i++)
		{
			EntityPlayer entityPlayer = list[i] as EntityPlayer;
			if (!entityPlayer.vmethod_26())
			{
				entityPlayer.method_117(false);
			}
		}
	}

	// Token: 0x060024E4 RID: 9444
	[DllImport("user32.dll")]
	private static extern IntPtr GetForegroundWindow();

	// Token: 0x060024E5 RID: 9445
	[DllImport("user32.dll")]
	private static extern bool GetWindowRect(IntPtr intptr_0, out GraphicsMgr.WindowsRECT windowsRECT_0);

	// Token: 0x060024E6 RID: 9446
	[DllImport("user32.dll")]
	private static extern bool SetWindowPos(IntPtr intptr_0, int int_0, int int_1, int int_2, int int_3, int int_4, int int_5);

	// Token: 0x060024E7 RID: 9447
	[DllImport("user32.dll")]
	private static extern long SetWindowLong(IntPtr intptr_0, int int_0, long long_0);

	// Token: 0x060024E8 RID: 9448
	[DllImport("user32.dll")]
	private static extern int SetLayeredWindowAttributes(IntPtr intptr_0, int int_0, int int_1, int int_2);

	// Token: 0x060024E9 RID: 9449 RVA: 0x000B0EAC File Offset: 0x000AF0AC
	private int[] method_28()
	{
		int[] array = new int[4];
		GraphicsMgr.WindowsRECT windowsRECT = default(GraphicsMgr.WindowsRECT);
		GraphicsMgr.GetWindowRect(GraphicsMgr.GetForegroundWindow(), out windowsRECT);
		array[0] = windowsRECT.Left;
		array[1] = windowsRECT.Top;
		array[2] = windowsRECT.Right;
		array[3] = windowsRECT.Bottom;
		return array;
	}

	// Token: 0x060024EA RID: 9450 RVA: 0x000B0F00 File Offset: 0x000AF100
	private void method_29()
	{
		if (Application.platform == RuntimePlatform.WindowsPlayer)
		{
			int[] array = this.method_28();
			int num = array[2] - array[0];
			int num2 = array[3] - array[1];
			this.widthMargin = (num - Screen.width) / 2;
			this.titleHeight = num2 - Screen.height - this.widthMargin;
		}
	}

	// Token: 0x060024EB RID: 9451 RVA: 0x000B0F50 File Offset: 0x000AF150
	private bool method_30(int int_0, int int_1, int int_2, int int_3, bool bool_0)
	{
		IntPtr intPtr = MonoSingleton<AppManager>.Instance.method_19();
		base.StartCoroutine(this.method_31(intPtr, int_0, int_1, int_2, int_3, bool_0, 0.05f));
		return true;
	}

	// Token: 0x060024EC RID: 9452 RVA: 0x000B0F84 File Offset: 0x000AF184
	public IEnumerator method_31(IntPtr intptr_0, int int_0, int int_1, int int_2, int int_3, bool bool_0, float float_0)
	{
		yield return new WaitForSeconds(float_0);
		method_32(!bool_0);
		SetWindowPos(intptr_0, -2, int_0, int_1, int_2, int_3, 64);
		if (bool_0)
		{
			method_32(!bool_0);
			method_32(!bool_0);
			SetWindowPos(intptr_0, -2, int_0, int_1, int_2, int_3, 3);
		}
	}
	// Token: 0x060024ED RID: 9453 RVA: 0x000B100C File Offset: 0x000AF20C
	public void method_32(bool bool_0 = true)
	{
		IntPtr intPtr = MonoSingleton<AppManager>.Instance.method_19();
		if (!bool_0)
		{
			GraphicsMgr.SetWindowLong(intPtr, -20, 0L);
			GraphicsMgr.SetWindowLong(intPtr, -16, 369164288L);
			GraphicsMgr.SetLayeredWindowAttributes(intPtr, 0, 0, 1);
		}
		else
		{
			GraphicsMgr.SetWindowLong(intPtr, -16, 281673728L);
		}
	}

	// Token: 0x060024EE RID: 9454 RVA: 0x0000311B File Offset: 0x0000131B
	[CompilerGenerated]
	private static void smethod_0(int int_0, int int_1)
	{
	}

	// Token: 0x040019EF RID: 6639
	private const string APP_NAME = "Borderlands Online";

	// Token: 0x040019F0 RID: 6640
	private const int WS_BORDER = 8388608;

	// Token: 0x040019F1 RID: 6641
	private const int WS_CAPTION = 12582912;

	// Token: 0x040019F2 RID: 6642
	private const int WS_CLIPCHILDREN = 33554432;

	// Token: 0x040019F3 RID: 6643
	private const int WS_CLIPSIBLINGS = 67108864;

	// Token: 0x040019F4 RID: 6644
	private const int WS_MAXIMIZEBOX = 65536;

	// Token: 0x040019F5 RID: 6645
	private const int WS_VISIBLE = 268435456;

	// Token: 0x040019F6 RID: 6646
	private const int WS_SYSMENU = 524288;

	// Token: 0x040019F7 RID: 6647
	private const int WS_MINIMIZEBOX = 131072;

	// Token: 0x040019F8 RID: 6648
	private const int WS_EX_TOPMOST = 8;

	// Token: 0x040019F9 RID: 6649
	private const int GWL_STYLE = -16;

	// Token: 0x040019FA RID: 6650
	private const int GWL_EXSTYLE = -20;

	// Token: 0x040019FB RID: 6651
	private const int LWA_COLORKEY = 1;

	// Token: 0x040019FC RID: 6652
	private const int SWP_NOSIZE = 1;

	// Token: 0x040019FD RID: 6653
	private const int SWP_NOMOVE = 2;

	// Token: 0x040019FE RID: 6654
	private const int SWP_SHOWWINDOW = 64;

	// Token: 0x040019FF RID: 6655
	private const int STYLE_NORMAL = 281673728;

	// Token: 0x04001A00 RID: 6656
	private const int STYLE_FULLSCREEN = 369164288;

	// Token: 0x04001A01 RID: 6657
	private GameObject mGraphicMgrObj;

	// Token: 0x04001A02 RID: 6658
	private CharacterFxMgr mCharacterFxMgr;

	// Token: 0x04001A03 RID: 6659
	private CameraEffectMgr mCameraEffectMgr;

	// Token: 0x04001A04 RID: 6660
	private SnapEffectMgr mSnapEffectMgr;

	// Token: 0x04001A05 RID: 6661
	private FpEffectMgr mFpEffectMgr;

	// Token: 0x04001A06 RID: 6662
	private NpcTitleMgr mNpcTitleMgr;

	// Token: 0x04001A07 RID: 6663
	private UIPreviewMgr mUIPreviewMgr;

	// Token: 0x04001A08 RID: 6664
	private TexPostEffectMgr mTexPostEffectMgr;

	// Token: 0x04001A09 RID: 6665
	private FpCameraEffectMgr mFpCameraEffectMgr;

	// Token: 0x04001A0A RID: 6666
	private LightsMgr mLightsMgr;

	// Token: 0x04001A0B RID: 6667
	public bool mIsHideFpMesh;

	// Token: 0x04001A0C RID: 6668
	private EntityPlayer mEntityPlay;

	// Token: 0x04001A0D RID: 6669
	private Camera mFpsCamera;

	// Token: 0x04001A0E RID: 6670
	private Vector3 mFpsCameraPos;

	// Token: 0x04001A0F RID: 6671
	private int mResIndex;

	// Token: 0x04001A10 RID: 6672
	private Resolution[] mWantSupportResInfoArray;

	// Token: 0x04001A11 RID: 6673
	private List<Resolution> mSupportResInfoArray;

	// Token: 0x04001A12 RID: 6674
	private List<int> mSupportFrameRates;

	// Token: 0x04001A13 RID: 6675
	private float mOriSceneFov;

	// Token: 0x04001A14 RID: 6676
	private float mOriWpnFov;

	// Token: 0x04001A15 RID: 6677
	private Vector3 mOriCameraLSPos;

	// Token: 0x04001A16 RID: 6678
	private WeaponCameraControl mWpnCamControl;

	// Token: 0x04001A17 RID: 6679
	private Resolution mLastResolution;

	// Token: 0x04001A18 RID: 6680
	private bool mFullScreen;

	// Token: 0x04001A19 RID: 6681
	private int widthMargin;

	// Token: 0x04001A1A RID: 6682
	private int titleHeight;

	// Token: 0x04001A1B RID: 6683
	private int posXBeforeFullScreen;

	// Token: 0x04001A1C RID: 6684
	private int posYBeforeFullScreen;

	// Token: 0x04001A1D RID: 6685
	private Resolution restoreResolution;

	// Token: 0x04001A1E RID: 6686
	private Action<int, int> OnChangeResolution;

	// Token: 0x020005A9 RID: 1449
	private struct WindowsRECT
	{
		// Token: 0x04001A20 RID: 6688
		public int Left;

		// Token: 0x04001A21 RID: 6689
		public int Top;

		// Token: 0x04001A22 RID: 6690
		public int Right;

		// Token: 0x04001A23 RID: 6691
		public int Bottom;
	}
}
