using System;
using UnityEngine;

// Token: 0x02000520 RID: 1312
public class LevelObjectSync : MonoBehaviour
{
	// Token: 0x060021DC RID: 8668 RVA: 0x0000311B File Offset: 0x0000131B
	protected virtual void Awake()
	{
	}

	// Token: 0x060021DD RID: 8669 RVA: 0x000174FB File Offset: 0x000156FB
	private void OnLevelWasLoaded()
	{
		if (LevelObjectSyncManager.LevelObjectSyncManager_0)
		{
			this.m_levelObjectID = LevelObjectSyncManager.LevelObjectSyncManager_0.method_0(this);
			LevelObjectSyncManager.LevelObjectSyncManager_0.method_1(this.m_levelObjectID, ref this.m_initialState);
		}
	}

	// Token: 0x060021DE RID: 8670 RVA: 0x00017531 File Offset: 0x00015731
	protected virtual void Start()
	{
		this.m_animation = base.GetComponent<Animation>();
		this.method_1(this.m_initialState, true);
	}

	// Token: 0x060021DF RID: 8671 RVA: 0x0001754C File Offset: 0x0001574C
	public int method_0()
	{
		return this.m_levelObjectID;
	}

	// Token: 0x060021E0 RID: 8672 RVA: 0x000A1BE4 File Offset: 0x0009FDE4
	private void method_1(LevelObjectSync.LevelObjectSyncState levelObjectSyncState_0, bool bool_0)
	{
		if (bool_0 || levelObjectSyncState_0 != this.m_state)
		{
			this.m_state = levelObjectSyncState_0;
			LevelObjectSync.LevelObjectSyncState state = this.m_state;
			if (state != LevelObjectSync.LevelObjectSyncState.Deactivated)
			{
				if (state == LevelObjectSync.LevelObjectSyncState.Activated)
				{
					this.OnActivate();
				}
			}
			else
			{
				this.OnDeactivate();
			}
		}
	}

	// Token: 0x060021E1 RID: 8673 RVA: 0x00017554 File Offset: 0x00015754
	public virtual void vmethod_0(LevelObjectSync.LevelObjectSyncState levelObjectSyncState_0)
	{
		this.method_1(levelObjectSyncState_0, false);
	}

	// Token: 0x060021E2 RID: 8674 RVA: 0x000A1C24 File Offset: 0x0009FE24
	public virtual void OnActivate()
	{
		for (int i = 0; i < this.m_enableOnActivate.Length; i++)
		{
			if (this.m_enableOnActivate[i] != null)
			{
				this.m_enableOnActivate[i].SetActive(true);
			}
		}
		for (int j = 0; j < this.m_disableOnActivate.Length; j++)
		{
			if (this.m_disableOnActivate[j] != null)
			{
				this.m_disableOnActivate[j].SetActive(false);
			}
		}
		for (int k = 0; k < this.m_playOnActivate.Length; k++)
		{
			if (this.m_playOnActivate[k] != null)
			{
				this.m_animation.Play(this.m_playOnActivate[k].name);
			}
		}
	}

	// Token: 0x060021E3 RID: 8675 RVA: 0x000A1CD0 File Offset: 0x0009FED0
	public virtual void OnDeactivate()
	{
		for (int i = 0; i < this.m_enableOnDeactivate.Length; i++)
		{
			if (this.m_enableOnDeactivate[i])
			{
				this.m_enableOnDeactivate[i].SetActive(true);
			}
		}
		for (int j = 0; j < this.m_disableOnDeactivate.Length; j++)
		{
			if (this.m_disableOnDeactivate[j])
			{
				this.m_disableOnDeactivate[j].SetActive(false);
			}
		}
		for (int k = 0; k < this.m_playOnDeactivate.Length; k++)
		{
			if (this.m_playOnDeactivate[k] != null)
			{
				this.m_animation.Play(this.m_playOnDeactivate[k].name);
			}
		}
	}

	// Token: 0x060021E4 RID: 8676 RVA: 0x0001755E File Offset: 0x0001575E
	public LevelObjectSync.LevelObjectSyncState method_2()
	{
		return this.m_state;
	}

	// Token: 0x04001685 RID: 5765
	private LevelObjectSync.LevelObjectSyncState m_state;

	// Token: 0x04001686 RID: 5766
	public LevelObjectSync.LevelObjectSyncState m_initialState;

	// Token: 0x04001687 RID: 5767
	public GameObject[] m_enableOnActivate = new GameObject[0];

	// Token: 0x04001688 RID: 5768
	public GameObject[] m_disableOnActivate = new GameObject[0];

	// Token: 0x04001689 RID: 5769
	public AnimationClip[] m_playOnActivate = new AnimationClip[0];

	// Token: 0x0400168A RID: 5770
	public GameObject[] m_enableOnDeactivate = new GameObject[0];

	// Token: 0x0400168B RID: 5771
	public GameObject[] m_disableOnDeactivate = new GameObject[0];

	// Token: 0x0400168C RID: 5772
	public Animation[] m_playOnDeactivate = new Animation[0];

	// Token: 0x0400168D RID: 5773
	private int m_levelObjectID;

	// Token: 0x0400168E RID: 5774
	protected Animation m_animation;

	// Token: 0x02000521 RID: 1313
	public enum LevelObjectSyncState
	{
		// Token: 0x04001690 RID: 5776
		Deactivated,
		// Token: 0x04001691 RID: 5777
		Activated
	}
}
