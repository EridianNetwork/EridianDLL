using System;
using UnityEngine;

// Token: 0x02000086 RID: 134
public class PlayerCrippleMarker : MonoBehaviour
{
	// Token: 0x060002CF RID: 719 RVA: 0x00004A9A File Offset: 0x00002C9A
	private void Start()
	{
		this.m_equipmentPlayer = base.gameObject.GetComponent<EquipmentInventoryEntityPlayer>();
	}

	// Token: 0x060002D0 RID: 720 RVA: 0x00004AAD File Offset: 0x00002CAD
	private void Update()
	{
		if (this.m_showSign && this.m_timer > 0f)
		{
			this.m_timer -= Time.deltaTime;
		}
		if (!(this.m_equipmentPlayer != null))
		{
		}
	}

	// Token: 0x060002D1 RID: 721 RVA: 0x00042A38 File Offset: 0x00040C38
	private void OnGUI()
	{
		if (this.m_showSign && !string.IsNullOrEmpty(this.m_message))
		{
			string text = this.m_message;
			if (this.m_equipmentPlayer != null)
			{
				text = text + "\nBlood: " + this.m_equipmentPlayer.method_3();
				text = text + "\nRevive: " + this.m_equipmentPlayer.method_7();
			}
			DebugUtils.smethod_4(0.7f, 0.4f, 0.5f, 0.5f, text, Color.red, 24);
			Rect rect = new Rect((float)Screen.width * 0.7f, (float)Screen.height * 0.4f + 50f, 200f, 20f);
			GUI.HorizontalScrollbar(rect, 0f, (float)this.m_equipmentPlayer.method_3(), 0f, (float)this.m_equipmentPlayer.method_4());
			Rect rect2 = new Rect((float)Screen.width * 0.7f, (float)Screen.height * 0.4f + 75f, 200f, 20f);
			GUI.HorizontalScrollbar(rect2, 0f, (float)this.m_equipmentPlayer.method_7(), 0f, (float)this.m_equipmentPlayer.method_8());
		}
	}

	// Token: 0x040002B1 RID: 689
	public bool m_showSign;

	// Token: 0x040002B2 RID: 690
	public string m_message;

	// Token: 0x040002B3 RID: 691
	public float m_timer;

	// Token: 0x040002B4 RID: 692
	private EquipmentInventoryEntityPlayer m_equipmentPlayer;
}
