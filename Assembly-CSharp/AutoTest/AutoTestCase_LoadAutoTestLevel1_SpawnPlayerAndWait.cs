using System;
using Core;
using ns0;
using XsdSettings;

namespace AutoTest
{
	// Token: 0x0200062E RID: 1582
	internal class AutoTestCase_LoadAutoTestLevel1_SpawnPlayerAndWait : AutoTestCase_LoadAutoTestLevel1_WaitForPlayer
	{
		// Token: 0x06002833 RID: 10291 RVA: 0x0001A937 File Offset: 0x00018B37
		protected override void OpenAutoTestCase()
		{
			MonoSingleton<AutoTestManager>.Instance.StartCoroutine(AutoTestUtility.smethod_9(this.m_avatarType, -1));
		}

		// Token: 0x06002834 RID: 10292 RVA: 0x000BD5A4 File Offset: 0x000BB7A4
		public override void PostInit(string _fullName)
		{
			int num = _fullName.IndexOf('(');
			int num2 = _fullName.IndexOf(')');
			if (num != -1 && num2 != -1 && num2 > num)
			{
				string text = _fullName.Substring(num + 1, num2 - num - 1);
				string[] array = text.Split(new char[] { ',' });
				if (array.Length == 2)
				{
					try
					{
						this.m_avatarType = (AvatarType)((int)Enum.Parse(typeof(AvatarType), array[0], true));
						this.m_wait_num = int.Parse(array[1]);
					}
					catch (Exception ex)
					{
						DebugUtils.LogError(LogCategory.Autotest, "SpawnPlayerAndWait()  invalid parameters.  " + ex.Message);
					}
				}
			}
		}

		// Token: 0x06002835 RID: 10293 RVA: 0x0001A950 File Offset: 0x00018B50
		protected override void UpdateAutoTestCase()
		{
			base.Wait(this.m_wait_num);
		}

		// Token: 0x04001C85 RID: 7301
		public int m_wait_num = 1;

		// Token: 0x04001C86 RID: 7302
		public AvatarType m_avatarType;
	}
}
