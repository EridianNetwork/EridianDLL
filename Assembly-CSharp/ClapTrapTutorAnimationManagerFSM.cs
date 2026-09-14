using System;
using BHV;

// Token: 0x02000024 RID: 36
public class ClapTrapTutorAnimationManagerFSM : NPCAnimationManagerFSM
{
	// Token: 0x060000FD RID: 253 RVA: 0x0003A654 File Offset: 0x00038854
	public override void Update()
	{
		base.Update();
		if (base.Animator_0 != null)
		{
			if (base.BHVStressLevel_0 == BHVStressLevel.RELAX)
			{
				base.Animator_0.SetBool("IsCasual", true);
			}
			else if (base.BHVStressLevel_0 == BHVStressLevel.ALERT)
			{
				base.Animator_0.SetBool("IsCasual", false);
			}
		}
	}

	// Token: 0x0400011E RID: 286
	public string m_lessonMessage;

	// Token: 0x0400011F RID: 287
	public bool m_showMessage;
}
