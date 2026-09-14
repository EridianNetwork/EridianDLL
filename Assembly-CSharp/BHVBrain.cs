using System;
using System.Diagnostics;
using ns0;
using UnityEngine;

// Token: 0x02000157 RID: 343
public class BHVBrain : MonoBehaviour, IDamageListener, IPrefabManagerXmlGenericSetup
{
	// Token: 0x17000061 RID: 97
	// (get) Token: 0x060007ED RID: 2029 RVA: 0x000082A3 File Offset: 0x000064A3
	// (set) Token: 0x060007EE RID: 2030 RVA: 0x000082AB File Offset: 0x000064AB
	[HideInInspector]
	public Entity m_entity { get; private set; }

	// Token: 0x060007EF RID: 2031 RVA: 0x000039EC File Offset: 0x00001BEC
	public bool imethod_0(string string_0)
	{
		return true;
	}

	// Token: 0x060007F0 RID: 2032 RVA: 0x0005A344 File Offset: 0x00058544
	private void Start()
	{
		this.m_entity = base.GetComponent<Entity>();
		if (DamageManager.DamageManager_0)
		{
			if (this.m_isDamageable)
			{
				DamageManager.DamageManager_0.method_3(this);
			}
			else
			{
				DamageManager.DamageManager_0.method_2(this.m_entity);
			}
		}
		this.m_isNpc = base.GetComponent<EntityNpc>() != null;
		this.m_isPlayer = base.GetComponent<EntityPlayer>() != null;
	}

	// Token: 0x060007F1 RID: 2033 RVA: 0x00003878 File Offset: 0x00001A78
	private void OnDestroy()
	{
		if (DamageManager.DamageManager_0)
		{
			DamageManager.DamageManager_0.method_4(this);
		}
	}

	// Token: 0x060007F2 RID: 2034 RVA: 0x0000311B File Offset: 0x0000131B
	private void Update()
	{
	}

	// Token: 0x060007F3 RID: 2035 RVA: 0x0000311B File Offset: 0x0000131B
	public void OnDamaged(DamageContext context)
	{
	}

	// Token: 0x060007F4 RID: 2036 RVA: 0x0000311B File Offset: 0x0000131B
	public void OnEntityKill(KillContext context)
	{
	}

	// Token: 0x060007F5 RID: 2037 RVA: 0x0005A3C0 File Offset: 0x000585C0
	[Conditional("DEBUG")]
	private void OnGUI()
	{
		if (MonoSingleton<Session>.Instance == null)
		{
			return;
		}
		bool flag = false;
		bool flag2 = false;
		bool flag3 = false;
		bool flag4 = false;
		if (MonoSingleton<DebugCamera>.Instance != null && MonoSingleton<DebugCamera>.Instance.method_0())
		{
			flag4 = true;
			flag = MonoSingleton<DebugCamera>.Instance.m_showNPCLog;
			flag2 = false;
			flag3 = MonoSingleton<DebugCamera>.Instance.m_showPlayerLog;
		}
		if (!flag && !this.m_isShowDebugFSM && !this.m_isShowDebugBHVTaskManager && !this.m_isShowDebugAnimationManager && !flag2 && !flag3 && !AIServiceUtility.AIServiceUtility_0.m_bShowNpcHP)
		{
			return;
		}
		string text = string.Empty;
		if (this.m_isPlayer)
		{
			PlayerAnimationManagerFSM component = base.GetComponent<PlayerAnimationManagerFSM>();
			if (component != null)
			{
				flag2 = flag2 && component.m_isPlayerLocal;
				flag3 = flag3 && !component.m_isPlayerLocal;
				if (flag2 || flag3)
				{
					BHVTaskManager component2 = base.GetComponent<BHVTaskManager>();
					if (component2 != null)
					{
						text += component2.ToString();
					}
					text += component.ToString();
				}
			}
			if (flag2)
			{
				if (text.Length != 0)
				{
					Color contentColor = GUI.contentColor;
					GUI.contentColor = this.m_debugTextColot;
					GUI.Label(new Rect(180f, (float)(Screen.height - 500), 800f, 600f), "<LocalPlayer>\n" + text);
					GUI.contentColor = contentColor;
				}
				return;
			}
		}
		if (this.m_isNpc || flag3)
		{
			Camera camera;
			if (flag4)
			{
				if (MonoSingleton<DebugCamera>.Instance == null || MonoSingleton<DebugCamera>.Instance.m_camera == null)
				{
					return;
				}
				camera = MonoSingleton<DebugCamera>.Instance.m_camera;
			}
			else
			{
				if (MonoSingleton<Session>.Instance == null || MonoSingleton<Session>.Instance.GetLocalPlayer() == null)
				{
					return;
				}
				EntityPlayer entityPlayer = MonoSingleton<Session>.Instance.GetLocalPlayer().GetEntity() as EntityPlayer;
				if (entityPlayer == null || entityPlayer.method_45() == null)
				{
					return;
				}
				camera = entityPlayer.method_45().camera;
			}
			if (camera != null)
			{
				Vector3 vector = camera.WorldToScreenPoint(base.transform.position + Vector3.up * 1f + camera.transform.right * 0.5f);
				if (vector.z > 0f)
				{
					if (AIServiceUtility.AIServiceUtility_0.m_bShowNpcHP)
					{
						text = text + Convert.ToString(this.m_entity.vmethod_40()) + "\n";
					}
					if ((flag && this.m_isNpc) || this.m_isShowDebugBHVTaskManager)
					{
						BHVTaskManager component3 = base.GetComponent<BHVTaskManager>();
						if (component3)
						{
							text += component3.ToString();
						}
					}
					if (((flag && this.m_isNpc) || this.m_isShowDebugAnimationManager) && this.m_isNpc)
					{
						AnimationManagerFSM component4 = base.GetComponent<AnimationManagerFSM>();
						if (component4)
						{
							text += component4.ToString();
						}
					}
					if (text.Length == 0)
					{
						return;
					}
					Color contentColor2 = GUI.contentColor;
					GUI.contentColor = this.m_debugTextColot;
					GUI.Label(new Rect(vector.x, (float)Screen.height - vector.y, 800f, 600f), text);
					GUI.contentColor = contentColor2;
				}
			}
		}
	}

	// Token: 0x060007F6 RID: 2038 RVA: 0x0000311B File Offset: 0x0000131B
	private void OnSpawnCompleted()
	{
	}

	// Token: 0x040006E7 RID: 1767
	public bool m_isDamageable = true;

	// Token: 0x040006E8 RID: 1768
	public bool m_isShowDebugFSM;

	// Token: 0x040006E9 RID: 1769
	public bool m_isShowDebugBHVTaskManager;

	// Token: 0x040006EA RID: 1770
	public bool m_isShowDebugAnimationManager;

	// Token: 0x040006EB RID: 1771
	public Color m_debugTextColot = Color.red;

	// Token: 0x040006EC RID: 1772
	protected bool m_isNpc;

	// Token: 0x040006ED RID: 1773
	protected bool m_isPlayer;
}
