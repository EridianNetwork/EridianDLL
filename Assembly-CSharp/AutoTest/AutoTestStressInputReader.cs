using System;
using ns0;
using UnityEngine;

namespace AutoTest
{
	// Token: 0x02000635 RID: 1589
	internal class AutoTestStressInputReader : InputReader
	{
		// Token: 0x0600285A RID: 10330 RVA: 0x000BDFC0 File Offset: 0x000BC1C0
		public void Update(float timeElapsed)
		{
			this.m_timeElapsed = timeElapsed;
			int num = (int)timeElapsed;
			num %= 20;
			this.m_action = (AutoTestStressInputReader.StressTestAction)(num / 4);
		}

		// Token: 0x0600285B RID: 10331 RVA: 0x000BDFE8 File Offset: 0x000BC1E8
		public override bool GetKey(KeyCode key)
		{
			if (this.m_action == AutoTestStressInputReader.StressTestAction.A)
			{
				if (key == KeyCode.A)
				{
					return true;
				}
				if (key == KeyCode.Space && this.m_timeElapsed - this.m_lastJumpTime > 3f)
				{
					this.m_lastJumpTime = this.m_timeElapsed;
					return true;
				}
			}
			else if (this.m_action == AutoTestStressInputReader.StressTestAction.D)
			{
				if (key == KeyCode.D)
				{
					return true;
				}
				if (key == KeyCode.Space && this.m_timeElapsed - this.m_lastJumpTime > 3f)
				{
					this.m_lastJumpTime = this.m_timeElapsed;
					return true;
				}
			}
			else
			{
				if (MonoSingleton<Session>.Instance != null && MonoSingleton<Session>.Instance.method_16())
				{
					return false;
				}
				if (this.m_action == AutoTestStressInputReader.StressTestAction.F)
				{
					if (key == KeyCode.F)
					{
						return true;
					}
				}
				else if (this.m_action == AutoTestStressInputReader.StressTestAction.G)
				{
					if (key == KeyCode.G)
					{
						return true;
					}
				}
				else if (this.m_action == AutoTestStressInputReader.StressTestAction.Mouse0 && key == KeyCode.Mouse0)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x0600285C RID: 10332 RVA: 0x0000311D File Offset: 0x0000131D
		public override bool GetKey(string name)
		{
			return false;
		}

		// Token: 0x0600285D RID: 10333 RVA: 0x0000311D File Offset: 0x0000131D
		public override bool GetKeyDown(KeyCode key)
		{
			return false;
		}

		// Token: 0x0600285E RID: 10334 RVA: 0x0000311D File Offset: 0x0000131D
		public override bool GetKeyDown(string name)
		{
			return false;
		}

		// Token: 0x0600285F RID: 10335 RVA: 0x0000311D File Offset: 0x0000131D
		public override bool GetKeyUp(KeyCode key)
		{
			return false;
		}

		// Token: 0x06002860 RID: 10336 RVA: 0x0001396A File Offset: 0x00011B6A
		public override float GetAxis(string axisName)
		{
			return 0f;
		}

		// Token: 0x06002861 RID: 10337 RVA: 0x0000311D File Offset: 0x0000131D
		public override bool GetButton(string buttonName)
		{
			return false;
		}

		// Token: 0x06002862 RID: 10338 RVA: 0x0000311D File Offset: 0x0000131D
		public override bool GetButtonDown(string buttonName)
		{
			return false;
		}

		// Token: 0x06002863 RID: 10339 RVA: 0x0000311D File Offset: 0x0000131D
		public override bool GetButtonUp(string buttonName)
		{
			return false;
		}

		// Token: 0x06002864 RID: 10340 RVA: 0x0000311D File Offset: 0x0000131D
		public override bool GetMouseButton(int button, bool bCareUI = false)
		{
			return false;
		}

		// Token: 0x06002865 RID: 10341 RVA: 0x0000311D File Offset: 0x0000131D
		public override bool GetMouseButtonDown(int button, bool bCareUI = false)
		{
			return false;
		}

		// Token: 0x06002866 RID: 10342 RVA: 0x0000311D File Offset: 0x0000131D
		public override bool GetMouseButtonUp(int button, bool bCareUI = false)
		{
			return false;
		}

		// Token: 0x04001C99 RID: 7321
		private AutoTestStressInputReader.StressTestAction m_action = AutoTestStressInputReader.StressTestAction.None;

		// Token: 0x04001C9A RID: 7322
		public bool m_isTestProbe;

		// Token: 0x04001C9B RID: 7323
		private float m_timeElapsed;

		// Token: 0x04001C9C RID: 7324
		private float m_lastJumpTime;

		// Token: 0x02000636 RID: 1590
		private enum StressTestAction
		{
			// Token: 0x04001C9E RID: 7326
			None = -1,
			// Token: 0x04001C9F RID: 7327
			A,
			// Token: 0x04001CA0 RID: 7328
			D,
			// Token: 0x04001CA1 RID: 7329
			F,
			// Token: 0x04001CA2 RID: 7330
			G,
			// Token: 0x04001CA3 RID: 7331
			Mouse0,
			// Token: 0x04001CA4 RID: 7332
			Num
		}
	}
}
