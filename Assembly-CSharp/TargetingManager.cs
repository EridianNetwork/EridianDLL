using System;
using System.Collections.Generic;
using ns0;
using UnityEngine;

// Token: 0x0200057F RID: 1407
public class TargetingManager : MonoSingleton<TargetingManager>
{
	// Token: 0x170001C8 RID: 456
	// (get) Token: 0x06002429 RID: 9257 RVA: 0x00018B30 File Offset: 0x00016D30
	public float Single_0
	{
		get
		{
			return this.m_distance_townNpc;
		}
	}

	// Token: 0x0600242A RID: 9258 RVA: 0x000AC6C4 File Offset: 0x000AA8C4
	private void Update()
	{
		if (this.m_localPlayerEntity == null)
		{
			PlayerInfoSync localPlayer = MonoSingleton<Session>.Instance.GetLocalPlayer();
			if (localPlayer != null)
			{
				this.m_localPlayerEntity = localPlayer.GetEntity() as EntityPlayer;
			}
		}
		if (this.m_camera == null)
		{
			this.m_camera = base.camera;
		}
		if (this.m_camera != null)
		{
			this.m_screenPosition.Set(this.m_camera.pixelWidth / 2f, this.m_camera.pixelHeight / 2f, 0f);
		}
		if (this.m_localPlayerEntity != null && this.m_camera != null)
		{
			this.m_lastAimingRay = this.m_camera.ScreenPointToRay(this.m_screenPosition);
			if (this.m_localPlayerEntity.vmethod_53())
			{
				this.m_availableInteraction = null;
				this.m_aimedEntity = null;
				return;
			}
			this.m_distanceToAimed = float.MaxValue;
			this.m_aimedEntity = TargetingService.smethod_2(this.m_lastAimingRay, this.m_localPlayerEntity, out this.m_aimedCollider, ref this.m_distanceToAimed, ColliderType.WeakPoint, true);
		}
		this.method_3();
		this.method_2();
	}

	// Token: 0x0600242B RID: 9259 RVA: 0x0000311B File Offset: 0x0000131B
	public void method_0()
	{
	}

	// Token: 0x0600242C RID: 9260 RVA: 0x0000311B File Offset: 0x0000131B
	public void method_1()
	{
	}

	// Token: 0x0600242D RID: 9261 RVA: 0x000AC7EC File Offset: 0x000AA9EC
	private void method_2()
	{
		if (this.m_autoAiming)
		{
			List<Entity> list = DamageManager.DamageManager_0.method_0();
			Entity entity = null;
			float num = float.PositiveInfinity;
			for (int i = 0; i < list.Count; i++)
			{
				EquipmentInventoryEntity equipmentInventoryEntity = list[i].vmethod_19();
				if (!list[i].vmethod_26() && equipmentInventoryEntity != null && equipmentInventoryEntity.vmethod_4() > 0)
				{
					float num2 = Vector3.Distance(list[i].method_1(), base.transform.position);
					if (num2 < num)
					{
						entity = list[i];
						num = num2;
					}
				}
			}
			if (entity != null && this.m_localPlayerEntity != null)
			{
				if (entity.vmethod_17() != null && entity.vmethod_17().method_7() != null)
				{
					this.m_localPlayerEntity.method_101(entity.vmethod_17().method_7().transform);
				}
				else
				{
					this.m_localPlayerEntity.method_101(entity.transform);
				}
			}
		}
		else if (this.m_localPlayerEntity != null)
		{
			this.m_localPlayerEntity.method_102();
		}
	}

	// Token: 0x0600242E RID: 9262 RVA: 0x000AC90C File Offset: 0x000AAB0C
	private void method_3()
	{
		InteractionManager.InteractionManager_0.method_3(this.m_localPlayerEntity, ref this.m_availableInteraction, ref this.m_seeableInteraction, ref this.m_distance_townNpc);
		if (this.m_availableInteraction != null)
		{
			InteractionManager.InteractionManager_0.method_4(this.m_availableInteraction, ref this.m_mutilpleInteractions);
		}
	}

	// Token: 0x0600242F RID: 9263 RVA: 0x00018B38 File Offset: 0x00016D38
	public bool method_4()
	{
		return this.m_availableInteraction != null;
	}

	// Token: 0x06002430 RID: 9264 RVA: 0x00018B46 File Offset: 0x00016D46
	public bool method_5()
	{
		return this.m_seeableInteraction != null;
	}

	// Token: 0x06002431 RID: 9265 RVA: 0x00018B54 File Offset: 0x00016D54
	private bool method_6(InteractionClient interactionClient_0)
	{
		return this.m_availableInteraction != null && this.m_availableInteraction == interactionClient_0;
	}

	// Token: 0x06002432 RID: 9266 RVA: 0x000AC95C File Offset: 0x000AAB5C
	private bool method_7(InteractionClient interactionClient_0)
	{
		if (this.m_localPlayerEntity == null)
		{
			return false;
		}
		Ray ray = new Ray(this.m_localPlayerEntity.vmethod_28(), this.m_localPlayerEntity.vmethod_27());
		float num = 50f;
		return interactionClient_0.imethod_2(ray, ref num);
	}

	// Token: 0x06002433 RID: 9267 RVA: 0x000AC9A8 File Offset: 0x000AABA8
	public E_HighlightType method_8(InteractionClient interactionClient_0, ref bool bool_0)
	{
		E_HighlightType e_HighlightType = E_HighlightType.None;
		if (this.method_6(interactionClient_0))
		{
			e_HighlightType = E_HighlightType.Golden;
			bool_0 = this.method_9();
		}
		else if (this.method_7(interactionClient_0))
		{
			e_HighlightType = E_HighlightType.Silver;
		}
		return e_HighlightType;
	}

	// Token: 0x06002434 RID: 9268 RVA: 0x000AC9D8 File Offset: 0x000AABD8
	private bool method_9()
	{
		foreach (InteractionClient interactionClient in InteractionManager.InteractionManager_0.method_2())
		{
			EntityPlayerTown entityPlayerTown = interactionClient as EntityPlayerTown;
			if (entityPlayerTown != null && entityPlayerTown != this.m_localPlayerEntity)
			{
				float num = Vector3.Distance(this.m_localPlayerEntity.transform.position, entityPlayerTown.transform.position);
				float interactionDistance = MonoSingleton<AppManager>.Instance.m_globalSettings.m_interactionDistance;
				if (num < interactionDistance * 1.5f)
				{
					Ray ray = new Ray(this.m_localPlayerEntity.vmethod_28(), this.m_localPlayerEntity.vmethod_27());
					float num2 = interactionDistance;
					if (interactionClient.imethod_2(ray, ref num2) && num2 <= this.Single_0)
					{
						return true;
					}
				}
			}
		}
		return false;
	}

	// Token: 0x040018CD RID: 6349
	public Ray m_lastAimingRay;

	// Token: 0x040018CE RID: 6350
	public Entity m_aimedEntity;

	// Token: 0x040018CF RID: 6351
	public InteractionClient m_currentInteraction;

	// Token: 0x040018D0 RID: 6352
	public InteractionClient m_availableInteraction;

	// Token: 0x040018D1 RID: 6353
	public InteractionClient m_seeableInteraction;

	// Token: 0x040018D2 RID: 6354
	public List<InteractionClient> m_mutilpleInteractions = new List<InteractionClient>();

	// Token: 0x040018D3 RID: 6355
	public Collider m_aimedCollider;

	// Token: 0x040018D4 RID: 6356
	public float m_distanceToAimed;

	// Token: 0x040018D5 RID: 6357
	public bool m_autoAiming;

	// Token: 0x040018D6 RID: 6358
	private Camera m_camera;

	// Token: 0x040018D7 RID: 6359
	private Vector3 m_screenPosition = Vector3.zero;

	// Token: 0x040018D8 RID: 6360
	private EntityPlayer m_localPlayerEntity;

	// Token: 0x040018D9 RID: 6361
	private float m_distance_townNpc;
}
