using System;
using ns0;
using UnityEngine;

// Token: 0x0200050B RID: 1291
public class CutScenePlayer : MonoBehaviour
{
	// Token: 0x0600218E RID: 8590 RVA: 0x000170EE File Offset: 0x000152EE
	private void Awake()
	{
		this.m_playlistIndex = 0;
	}

	// Token: 0x0600218F RID: 8591 RVA: 0x000170F7 File Offset: 0x000152F7
	private void Start()
	{
		if (this.m_playlist.Length == 0)
		{
			return;
		}
		this.method_0(this.m_playlistIndex);
	}

	// Token: 0x06002190 RID: 8592 RVA: 0x000A1500 File Offset: 0x0009F700
	private void Update()
	{
		if (this.m_isSkipable && Input.GetKeyDown(KeyCode.Escape))
		{
			this.method_2(this.m_playlistIndex);
			this.m_playlistIndex = this.m_playlist.Length;
			MonoSingleton<GameFlowManager>.Instance.OnIntroCutsceneFinished();
		}
		if (this.m_playlist.Length == 0)
		{
			return;
		}
		if (this.m_playlistIndex >= this.m_playlist.Length)
		{
			return;
		}
		if (!this.method_1(this.m_playlistIndex))
		{
			this.method_2(this.m_playlistIndex);
			this.m_playlistIndex++;
			if (this.m_playlistIndex >= this.m_playlist.Length)
			{
				MonoSingleton<GameFlowManager>.Instance.OnIntroCutsceneFinished();
				return;
			}
			this.method_0(this.m_playlistIndex);
		}
	}

	// Token: 0x06002191 RID: 8593 RVA: 0x00017110 File Offset: 0x00015310
	private void method_0(int int_0)
	{
		this.m_playlist[int_0].gameObject.SetActive(true);
		this.m_playlistIndex = int_0;
	}

	// Token: 0x06002192 RID: 8594 RVA: 0x000A15B0 File Offset: 0x0009F7B0
	private bool method_1(int int_0)
	{
		if (this.m_playlist[int_0].gameObject.activeSelf)
		{
			Animation[] componentsInChildren = this.m_playlist[int_0].gameObject.GetComponentsInChildren<Animation>(true);
			for (int i = 0; i < componentsInChildren.Length; i++)
			{
				if (componentsInChildren[i].isPlaying)
				{
					return true;
				}
			}
		}
		return false;
	}

	// Token: 0x06002193 RID: 8595 RVA: 0x0001712C File Offset: 0x0001532C
	private void method_2(int int_0)
	{
		this.m_playlist[int_0].gameObject.SetActive(false);
	}

	// Token: 0x04001644 RID: 5700
	public bool m_isSkipable = true;

	// Token: 0x04001645 RID: 5701
	public CutScene[] m_playlist = new CutScene[0];

	// Token: 0x04001646 RID: 5702
	private int m_playlistIndex;
}
