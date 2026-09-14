using System;
using UnityEngine;

namespace AutoTest
{
	// Token: 0x02000625 RID: 1573
	internal class AutoTestBandWidthInputReader : InputReader
	{
		// Token: 0x06002813 RID: 10259 RVA: 0x0001A874 File Offset: 0x00018A74
		public override bool GetKey(KeyCode key)
		{
			if (key != KeyCode.Space)
			{
				return key == KeyCode.W;
			}
			if (this.m_timeElapsed - this.m_lastJumpTime > 3f)
			{
				this.m_lastJumpTime = this.m_timeElapsed;
				return true;
			}
			return false;
		}

		// Token: 0x06002814 RID: 10260 RVA: 0x0000311D File Offset: 0x0000131D
		public override bool GetKey(string name)
		{
			return false;
		}

		// Token: 0x06002815 RID: 10261 RVA: 0x0000311D File Offset: 0x0000131D
		public override bool GetKeyDown(KeyCode key)
		{
			return false;
		}

		// Token: 0x06002816 RID: 10262 RVA: 0x0000311D File Offset: 0x0000131D
		public override bool GetKeyDown(string name)
		{
			return false;
		}

		// Token: 0x06002817 RID: 10263 RVA: 0x0000311D File Offset: 0x0000131D
		public override bool GetKeyUp(KeyCode key)
		{
			return false;
		}

		// Token: 0x06002818 RID: 10264 RVA: 0x0001A8A7 File Offset: 0x00018AA7
		public override float GetAxis(string axisName)
		{
			if (axisName == "Mouse X")
			{
				return 0.15f;
			}
			return 0f;
		}

		// Token: 0x06002819 RID: 10265 RVA: 0x0000311D File Offset: 0x0000131D
		public override bool GetButton(string buttonName)
		{
			return false;
		}

		// Token: 0x0600281A RID: 10266 RVA: 0x0000311D File Offset: 0x0000131D
		public override bool GetButtonDown(string buttonName)
		{
			return false;
		}

		// Token: 0x0600281B RID: 10267 RVA: 0x0000311D File Offset: 0x0000131D
		public override bool GetButtonUp(string buttonName)
		{
			return false;
		}

		// Token: 0x0600281C RID: 10268 RVA: 0x0000311D File Offset: 0x0000131D
		public override bool GetMouseButton(int button, bool bCareUI = false)
		{
			return false;
		}

		// Token: 0x0600281D RID: 10269 RVA: 0x0000311D File Offset: 0x0000131D
		public override bool GetMouseButtonDown(int button, bool bCareUI = false)
		{
			return false;
		}

		// Token: 0x0600281E RID: 10270 RVA: 0x0000311D File Offset: 0x0000131D
		public override bool GetMouseButtonUp(int button, bool bCareUI = false)
		{
			return false;
		}

		// Token: 0x04001C82 RID: 7298
		public float m_lastJumpTime;

		// Token: 0x04001C83 RID: 7299
		public float m_timeElapsed;
	}
}
