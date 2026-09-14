using System;
using ns0;
using UnityEngine;

// Token: 0x02000760 RID: 1888
public class WeaponPreviewView : BaseView
{
	// Token: 0x06003205 RID: 12805 RVA: 0x0001DF17 File Offset: 0x0001C117
	public override void vmethod_2()
	{
		base.vmethod_2();
	}

	// Token: 0x06003206 RID: 12806 RVA: 0x00020979 File Offset: 0x0001EB79
	public override void vmethod_3()
	{
		base.vmethod_3();
		this.vmethod_5();
	}

	// Token: 0x06003207 RID: 12807 RVA: 0x000E27B0 File Offset: 0x000E09B0
	public virtual void vmethod_5()
	{
		if (MonoSingleton<GraphicsMgr>.Instance != null)
		{
			MonoSingleton<GraphicsMgr>.Instance.method_22().method_12(false);
		}
		MonoSingleton<AppManager>.Instance.method_0().vmethod_5<CharInfoView>().vmethod_8(true);
		this.Boolean_1 = false;
		if (this._onHideWeaponPreview != null)
		{
			this._onHideWeaponPreview();
		}
	}

	// Token: 0x06003208 RID: 12808 RVA: 0x00020987 File Offset: 0x0001EB87
	protected override void vmethod_1(bool bool_0, bool bool_1 = false)
	{
		base.vmethod_1(bool_0, bool_1);
		MonoSingleton<AppManager>.Instance.method_0().Boolean_2 = !bool_0;
	}

	// Token: 0x06003209 RID: 12809 RVA: 0x000E280C File Offset: 0x000E0A0C
	public virtual void vmethod_6(WeaponDNA weaponDNA_0, bool bool_0 = true)
	{
		this.Boolean_1 = true;
		ServiceWrapperBase<QuestServiceWrapper>.Instance.method_15();
		MonoSingleton<AppManager>.Instance.method_0().vmethod_5<CharInfoView>().vmethod_8(false);
		if (MonoSingleton<GraphicsMgr>.Instance != null)
		{
			MonoSingleton<GraphicsMgr>.Instance.method_22().method_12(true);
		}
	}

	// Token: 0x0600320A RID: 12810 RVA: 0x000209A4 File Offset: 0x0001EBA4
	public void method_3(WeaponPreviewView.OnHideWeaponPreview onHideWeaponPreview_0)
	{
		this._onHideWeaponPreview = (WeaponPreviewView.OnHideWeaponPreview)Delegate.Combine(this._onHideWeaponPreview, onHideWeaponPreview_0);
	}

	// Token: 0x0600320B RID: 12811 RVA: 0x000209BD File Offset: 0x0001EBBD
	public void method_4(WeaponPreviewView.OnHideWeaponPreview onHideWeaponPreview_0)
	{
		this._onHideWeaponPreview = (WeaponPreviewView.OnHideWeaponPreview)Delegate.Remove(this._onHideWeaponPreview, onHideWeaponPreview_0);
	}

	// Token: 0x0600320C RID: 12812 RVA: 0x000E285C File Offset: 0x000E0A5C
	protected virtual void vmethod_7()
	{
		if (this.m_ShowingModel != null)
		{
			SkinnedMeshRenderer skinnedMeshRenderer = BuildingKitGenerator.smethod_1(this.m_ShowingModel);
			Vector3 center = skinnedMeshRenderer.bounds.center;
			if (MonoSingleton<InputManager>.Instance.method_4("Fire1"))
			{
				float num = this.mWpnRotSpeed;
				float num2 = -Input.GetAxis("Mouse X") * num;
				float num3 = -Input.GetAxis("Mouse Y") * num;
				float num4 = Math.Abs(num2);
				float num5 = Math.Abs(num3);
				if (num4 > 0.01f || num5 > 0.01f)
				{
					if (num4 > num5)
					{
						if (num2 < 0f)
						{
							num *= -1f;
						}
						this.m_ShowingModel.transform.RotateAround(center, Vector3.up, num * Time.deltaTime);
					}
					else
					{
						if (num3 < 0f)
						{
							num *= -1f;
						}
						this.m_ShowingModel.transform.RotateAround(center, this.m_ShowingModel.transform.forward, num * Time.deltaTime);
					}
				}
			}
			float num6 = MonoSingleton<InputManager>.Instance.method_5("SwitchWeapon");
			float num7 = 0.2f;
			Vector3 vector = this.m_ShowingModel.transform.localPosition;
			if (num6 < 0f)
			{
				vector += Vector3.forward * num7;
			}
			else if (num6 > 0f)
			{
				vector -= Vector3.forward * num7;
			}
			vector.z = Mathf.Min(5f, Mathf.Max(1f, vector.z));
			this.m_ShowingModel.transform.localPosition = vector;
		}
	}

	// Token: 0x04002290 RID: 8848
	protected WeaponPreviewView.OnHideWeaponPreview _onHideWeaponPreview;

	// Token: 0x04002291 RID: 8849
	protected GameObject m_ShowingModel;

	// Token: 0x04002292 RID: 8850
	protected float mWpnRotSpeed;

	// Token: 0x02000761 RID: 1889
	// (Invoke) Token: 0x0600320E RID: 12814
	public delegate void OnHideWeaponPreview();
}
