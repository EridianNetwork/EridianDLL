using System;
using ns0;
using UnityEngine;

// Token: 0x02000B54 RID: 2900
[AddComponentMenu("Effects/TKC/Effect Trigger")]
public class EffectTrigger : MonoBehaviour
{
	// Token: 0x06004EB2 RID: 20146 RVA: 0x00033458 File Offset: 0x00031658
	private void Start()
	{
		if ((this.m_triggerType & EffectTriggerType.Start) != (EffectTriggerType)0)
		{
			this.method_0();
		}
	}

	// Token: 0x06004EB3 RID: 20147 RVA: 0x0003346A File Offset: 0x0003166A
	private void Update()
	{
		if ((this.m_triggerType & EffectTriggerType.Update) != (EffectTriggerType)0)
		{
			this.method_0();
			return;
		}
		if ((this.m_triggerType & EffectTriggerType.KeyDown) != (EffectTriggerType)0 && Input.GetKeyDown(this.m_keyCode))
		{
			this.method_0();
			return;
		}
	}

	// Token: 0x06004EB4 RID: 20148 RVA: 0x0003349F File Offset: 0x0003169F
	private void OnCollisionEnter()
	{
		if ((this.m_triggerType & EffectTriggerType.CollisionEnter) != (EffectTriggerType)0)
		{
			this.method_0();
		}
	}

	// Token: 0x06004EB5 RID: 20149 RVA: 0x000334B5 File Offset: 0x000316B5
	private void OnCollisionExit()
	{
		if ((this.m_triggerType & EffectTriggerType.CollisionExit) != (EffectTriggerType)0)
		{
			this.method_0();
		}
	}

	// Token: 0x06004EB6 RID: 20150 RVA: 0x000334CB File Offset: 0x000316CB
	private void OnDestroy()
	{
		if ((this.m_triggerType & EffectTriggerType.Destroy) != (EffectTriggerType)0)
		{
			this.method_0();
		}
	}

	// Token: 0x06004EB7 RID: 20151 RVA: 0x000334DD File Offset: 0x000316DD
	private void OnDisable()
	{
		if ((this.m_triggerType & EffectTriggerType.Disable) != (EffectTriggerType)0)
		{
			this.method_0();
		}
	}

	// Token: 0x06004EB8 RID: 20152 RVA: 0x000334F0 File Offset: 0x000316F0
	private void OnEnable()
	{
		if ((this.m_triggerType & EffectTriggerType.Enable) != (EffectTriggerType)0)
		{
			this.method_0();
		}
	}

	// Token: 0x06004EB9 RID: 20153 RVA: 0x00033502 File Offset: 0x00031702
	private void OnMouseDown()
	{
		if ((this.m_triggerType & EffectTriggerType.MouseDown) != (EffectTriggerType)0)
		{
			this.method_0();
		}
	}

	// Token: 0x06004EBA RID: 20154 RVA: 0x00033518 File Offset: 0x00031718
	private void OnMouseUp()
	{
		if ((this.m_triggerType & EffectTriggerType.MouseUp) != (EffectTriggerType)0)
		{
			this.method_0();
		}
	}

	// Token: 0x06004EBB RID: 20155 RVA: 0x0003352E File Offset: 0x0003172E
	private void OnTriggerEnter()
	{
		if ((this.m_triggerType & EffectTriggerType.TriggerEnter) != (EffectTriggerType)0)
		{
			this.method_0();
		}
	}

	// Token: 0x06004EBC RID: 20156 RVA: 0x00033541 File Offset: 0x00031741
	private void OnTriggerExit()
	{
		if ((this.m_triggerType & EffectTriggerType.TriggerExit) != (EffectTriggerType)0)
		{
			this.method_0();
		}
	}

	// Token: 0x06004EBD RID: 20157 RVA: 0x0014E948 File Offset: 0x0014CB48
	public void method_0()
	{
		if (NetworkManager.smethod_3() && !MonoSingleton<AppManager>.Instance.m_offlineMode)
		{
			return;
		}
		if (this.m_effectItemList != null && this.m_effectItemList.Length > 0 && this.method_1())
		{
			for (int i = 0; i < this.m_effectItemList.Length; i++)
			{
				this.m_effectItemList[i].method_0(this);
			}
		}
	}

	// Token: 0x06004EBE RID: 20158 RVA: 0x00033554 File Offset: 0x00031754
	public void TriggerEffectByName(string name)
	{
		if (name == this.m_name)
		{
			this.method_0();
		}
	}

	// Token: 0x06004EBF RID: 20159 RVA: 0x0014E9A8 File Offset: 0x0014CBA8
	private bool method_1()
	{
		bool flag = true;
		if (this.m_gameObject == null)
		{
			this.m_gameObject = base.gameObject;
		}
		if (this.m_location == EffectLocationType.GameObject)
		{
			flag = true;
		}
		else if (this.m_location == EffectLocationType.Raycast)
		{
			Vector3 vector = new Vector3(0f, -1f, 0f);
			Vector3 vector2 = new Vector3(0f, 0f, 0f);
			Transform transform = this.m_gameObject.transform;
			vector2 = transform.position;
			if (this.m_raycastDirection == EffectRayCastDirectionType.Forward)
			{
				vector = transform.forward;
			}
			else if (this.m_raycastDirection == EffectRayCastDirectionType.Backward)
			{
				vector = -transform.forward;
			}
			else if (this.m_raycastDirection == EffectRayCastDirectionType.Up)
			{
				vector = transform.up;
			}
			else if (this.m_raycastDirection == EffectRayCastDirectionType.Down)
			{
				vector = -transform.up;
			}
			else if (this.m_raycastDirection == EffectRayCastDirectionType.Left)
			{
				vector = -transform.right;
			}
			else if (this.m_raycastDirection == EffectRayCastDirectionType.Right)
			{
				vector = transform.right;
			}
			else if (this.m_raycastDirection == EffectRayCastDirectionType.Specified)
			{
				vector = this.m_specifiedRaycastDirection;
				vector2 = this.m_specifiedRaycastOrigin;
			}
			if (this.m_raycastDistance <= 0f)
			{
				flag = Physics.Raycast(vector2, vector, out this.m_raycastHit);
			}
			else
			{
				flag = Physics.Raycast(vector2, vector, out this.m_raycastHit, this.m_raycastDistance);
			}
		}
		return flag;
	}

	// Token: 0x04003B17 RID: 15127
	public string m_name = "EffectTrigger";

	// Token: 0x04003B18 RID: 15128
	public EffectTriggerType m_triggerType;

	// Token: 0x04003B19 RID: 15129
	public KeyCode m_keyCode;

	// Token: 0x04003B1A RID: 15130
	public EffectLocationType m_location;

	// Token: 0x04003B1B RID: 15131
	public EffectTriggerItem[] m_effectItemList;

	// Token: 0x04003B1C RID: 15132
	public GameObject m_gameObject;

	// Token: 0x04003B1D RID: 15133
	public RaycastHit m_raycastHit;

	// Token: 0x04003B1E RID: 15134
	public float m_raycastDistance;

	// Token: 0x04003B1F RID: 15135
	public EffectRayCastDirectionType m_raycastDirection;

	// Token: 0x04003B20 RID: 15136
	public Vector3 m_specifiedRaycastDirection = new Vector3(0f, -1f, 0f);

	// Token: 0x04003B21 RID: 15137
	[HideInInspector]
	public Vector3 m_specifiedRaycastOrigin = new Vector3(0f, 0f, 0f);
}
