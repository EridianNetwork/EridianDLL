using System;
using Core;
using ns0;
using UnityEngine;

// Token: 0x02000446 RID: 1094
public class DeathCamManager : ServiceWrapperBase<DeathCamManager>
{
	// Token: 0x06001AF0 RID: 6896 RVA: 0x0008903C File Offset: 0x0008723C
	public void method_0(bool bool_1)
	{
		this.m_enableMouseLook = bool_1;
		if (this.m_deathCam != null && bool_1)
		{
			this.m_rotationX = this.m_deathCam.transform.eulerAngles.y;
			this.m_rotationY = this.m_deathCam.transform.eulerAngles.x;
		}
	}

	// Token: 0x06001AF1 RID: 6897 RVA: 0x000890A0 File Offset: 0x000872A0
	public void method_1(bool bool_1)
	{
		if (this.m_deathCam != null)
		{
			SecondWindDownEffect secondWindDownEffect = this.m_deathCam.gameObject.GetComponent<SecondWindDownEffect>();
			if (secondWindDownEffect == null)
			{
				if (GraphicsDataMgr.PostProcess_SecondWindDownEffect == null)
				{
					GraphicsDataMgr.PostProcess_SecondWindDownEffect = (Resources.Load("Graphics/GraphicsData") as GameObject).GetComponent<SecondWindDownEffect>();
				}
				secondWindDownEffect = this.m_deathCam.gameObject.AddComponent<SecondWindDownEffect>();
				ComponentHelper.smethod_1(GraphicsDataMgr.PostProcess_SecondWindDownEffect, secondWindDownEffect);
			}
			secondWindDownEffect.enabled = bool_1;
		}
	}

	// Token: 0x06001AF2 RID: 6898 RVA: 0x00089120 File Offset: 0x00087320
	public void Update()
	{
		if (this.m_deathCam != null && this.m_enableMouseLook)
		{
			this.m_rotationX += Input.GetAxis("Mouse X") * this.m_sensitivityX;
			this.m_rotationY += Input.GetAxis("Mouse Y") * this.m_sensitivityY;
			this.m_deathCam.transform.rotation = Quaternion.Euler(-this.m_rotationY, this.m_rotationX, 0f);
		}
	}

	// Token: 0x06001AF3 RID: 6899 RVA: 0x000891A8 File Offset: 0x000873A8
	private bool method_2(Vector3 vector3_0, Entity entity_0, Entity entity_1)
	{
		bool flag = false;
		RaycastHit raycastHit;
		if (!Physics.Raycast(entity_0.vmethod_23(), vector3_0 - entity_0.vmethod_23(), out raycastHit, Vector3.Distance(vector3_0, entity_0.vmethod_23()), TargetingService.Int32_0))
		{
			flag = true;
		}
		if (flag && !Physics.Raycast(entity_1.vmethod_23(), vector3_0 - entity_1.vmethod_23(), out raycastHit, Vector3.Distance(vector3_0, entity_1.vmethod_23()), TargetingService.Int32_0))
		{
			flag = true;
		}
		return flag;
	}

	// Token: 0x06001AF4 RID: 6900 RVA: 0x00089218 File Offset: 0x00087418
	public void method_3(Entity entity_0, EntityPlayer entityPlayer_0)
	{
		if (this.m_deathCam != null)
		{
			return;
		}
		if (entityPlayer_0 == null)
		{
			return;
		}
		bool flag = false;
		if (entity_0)
		{
			entityPlayer_0.method_45().camera.enabled = false;
			entityPlayer_0.method_117(false);
			entityPlayer_0.method_59(true);
			Vector3 vector = entityPlayer_0.vmethod_23() + Vector3.up * 2f;
			Vector3 vector2 = entityPlayer_0.vmethod_23() - entity_0.vmethod_23();
			if (entity_0 != entityPlayer_0)
			{
				Vector3 vector3 = vector2;
				vector3.Normalize();
				Vector3 vector4 = entityPlayer_0.vmethod_23() + Vector3.Normalize(vector3) * 2f;
				Vector3 vector5 = entityPlayer_0.vmethod_23();
				if (!flag)
				{
					Vector3 vector6 = Vector3.Cross(vector3, Vector3.up);
					vector5 = vector4 + vector6 * 2f;
					flag = this.method_2(vector5, entity_0, entityPlayer_0);
				}
				if (!flag)
				{
					Vector3 vector7 = -Vector3.Cross(vector3, Vector3.up);
					vector5 = vector4 + vector7 * 2f;
					flag = this.method_2(vector5, entity_0, entityPlayer_0);
				}
				if (!flag)
				{
					vector5 = vector4 + Vector3.up * 2f;
					flag = this.method_2(vector5, entity_0, entityPlayer_0);
				}
				if (!flag)
				{
					vector5 = vector4 + Vector3.down * 2f;
					flag = this.method_2(vector5, entity_0, entityPlayer_0);
				}
				if (flag)
				{
					vector = vector5;
				}
			}
			GameObject gameObject = global::UnityEngine.Object.Instantiate(ResourcesLoader.smethod_0("Entities/Player_Mecanim/DeathCam"), vector, entityPlayer_0.method_2().rotation) as GameObject;
			this.m_deathCam = gameObject.camera;
			if (flag)
			{
				this.m_deathCam.transform.LookAt(entity_0.vmethod_23() + vector2 / 2f);
			}
			else
			{
				this.m_deathCam.transform.LookAt(entity_0.vmethod_23());
			}
		}
		else
		{
			DebugUtils.Log(LogCategory.Gamelogic, "BHVTaskPlayerDead.SpawnDeathCam - killer is null");
		}
	}

	// Token: 0x06001AF5 RID: 6901 RVA: 0x00089408 File Offset: 0x00087608
	public void method_4(EntityPlayer entityPlayer_0)
	{
		if (this.m_deathCam == null)
		{
			return;
		}
		if (entityPlayer_0 == null)
		{
			return;
		}
		entityPlayer_0.method_117(true);
		entityPlayer_0.method_59(false);
		entityPlayer_0.method_45().camera.enabled = true;
		if (this.m_deathCam == null)
		{
			return;
		}
		global::UnityEngine.Object.Destroy(this.m_deathCam.gameObject);
	}

	// Token: 0x040011CC RID: 4556
	private Camera m_deathCam;

	// Token: 0x040011CD RID: 4557
	private float m_sensitivityX = 15f;

	// Token: 0x040011CE RID: 4558
	private float m_sensitivityY = 15f;

	// Token: 0x040011CF RID: 4559
	private bool m_enableMouseLook;

	// Token: 0x040011D0 RID: 4560
	private float m_rotationX;

	// Token: 0x040011D1 RID: 4561
	private float m_rotationY;
}
