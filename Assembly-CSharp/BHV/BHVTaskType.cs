using System;

namespace BHV
{
	// Token: 0x02000161 RID: 353
	public enum BHVTaskType
	{
		// Token: 0x04000735 RID: 1845
		INVALID,
		// Token: 0x04000736 RID: 1846
		Idle,
		// Token: 0x04000737 RID: 1847
		Die,
		// Token: 0x04000738 RID: 1848
		Dead,
		// Token: 0x04000739 RID: 1849
		MoveTo,
		// Token: 0x0400073A RID: 1850
		TurnTo,
		// Token: 0x0400073B RID: 1851
		MoveWithFacing,
		// Token: 0x0400073C RID: 1852
		TurnOnSpot,
		// Token: 0x0400073D RID: 1853
		SlideMoveTo,
		// Token: 0x0400073E RID: 1854
		PlayAnimation,
		// Token: 0x0400073F RID: 1855
		Fire,
		// Token: 0x04000740 RID: 1856
		Reload,
		// Token: 0x04000741 RID: 1857
		CoverIdle,
		// Token: 0x04000742 RID: 1858
		CoverFire,
		// Token: 0x04000743 RID: 1859
		CoverFireIdle,
		// Token: 0x04000744 RID: 1860
		CoverReload,
		// Token: 0x04000745 RID: 1861
		CoverPeakOut,
		// Token: 0x04000746 RID: 1862
		CoverPeakIn,
		// Token: 0x04000747 RID: 1863
		CoverLookAround,
		// Token: 0x04000748 RID: 1864
		DestructibleIdle,
		// Token: 0x04000749 RID: 1865
		DestructibleTakeDamage,
		// Token: 0x0400074A RID: 1866
		DestructibleDead,
		// Token: 0x0400074B RID: 1867
		MeleeAttack,
		// Token: 0x0400074C RID: 1868
		JumpAttack,
		// Token: 0x0400074D RID: 1869
		JumpAttackLand,
		// Token: 0x0400074E RID: 1870
		JumpOnTheSpotAttack,
		// Token: 0x0400074F RID: 1871
		ChargeAttack,
		// Token: 0x04000750 RID: 1872
		ChargeAttackHit,
		// Token: 0x04000751 RID: 1873
		Hurt,
		// Token: 0x04000752 RID: 1874
		LightHurt,
		// Token: 0x04000753 RID: 1875
		Spawn,
		// Token: 0x04000754 RID: 1876
		Respawn,
		// Token: 0x04000755 RID: 1877
		AdvanceSpawn,
		// Token: 0x04000756 RID: 1878
		Warcry,
		// Token: 0x04000757 RID: 1879
		Stunned,
		// Token: 0x04000758 RID: 1880
		Default,
		// Token: 0x04000759 RID: 1881
		PickUp,
		// Token: 0x0400075A RID: 1882
		CountDown,
		// Token: 0x0400075B RID: 1883
		BlowUp,
		// Token: 0x0400075C RID: 1884
		SecondChance,
		// Token: 0x0400075D RID: 1885
		PlayerDead,
		// Token: 0x0400075E RID: 1886
		Suicide,
		// Token: 0x0400075F RID: 1887
		Alert,
		// Token: 0x04000760 RID: 1888
		RadiusAttack,
		// Token: 0x04000761 RID: 1889
		BurrowAttack,
		// Token: 0x04000762 RID: 1890
		Roll,
		// Token: 0x04000763 RID: 1891
		SideStep,
		// Token: 0x04000764 RID: 1892
		Spit,
		// Token: 0x04000765 RID: 1893
		IceEarthquakeAttack,
		// Token: 0x04000766 RID: 1894
		IceMeteorAttack,
		// Token: 0x04000767 RID: 1895
		PlayerSpawn,
		// Token: 0x04000768 RID: 1896
		Disabled,
		// Token: 0x04000769 RID: 1897
		Spacing,
		// Token: 0x0400076A RID: 1898
		Critical,
		// Token: 0x0400076B RID: 1899
		SummonExtraNPC,
		// Token: 0x0400076C RID: 1900
		ShowWeapon,
		// Token: 0x0400076D RID: 1901
		Warning,
		// Token: 0x0400076E RID: 1902
		PlayerTransfer,
		// Token: 0x0400076F RID: 1903
		DazeEffect,
		// Token: 0x04000770 RID: 1904
		ThrowAttack,
		// Token: 0x04000771 RID: 1905
		EarthPikeAttack,
		// Token: 0x04000772 RID: 1906
		RailgunAttack,
		// Token: 0x04000773 RID: 1907
		MortarAttack,
		// Token: 0x04000774 RID: 1908
		JetAttack,
		// Token: 0x04000775 RID: 1909
		Teleport,
		// Token: 0x04000776 RID: 1910
		HoverPatrol,
		// Token: 0x04000777 RID: 1911
		FlyGather,
		// Token: 0x04000778 RID: 1912
		FlyMeleeAttack,
		// Token: 0x04000779 RID: 1913
		RocketAttack,
		// Token: 0x0400077A RID: 1914
		PlayerSkill,
		// Token: 0x0400077B RID: 1915
		DestoryMissile,
		// Token: 0x0400077C RID: 1916
		LaserSweep,
		// Token: 0x0400077D RID: 1917
		Recharge,
		// Token: 0x0400077E RID: 1918
		DeployAidStation,
		// Token: 0x0400077F RID: 1919
		FireFullBody,
		// Token: 0x04000780 RID: 1920
		AimingTarget,
		// Token: 0x04000781 RID: 1921
		HammerJumpAttack,
		// Token: 0x04000782 RID: 1922
		HammerAttack,
		// Token: 0x04000783 RID: 1923
		LavaStrike,
		// Token: 0x04000784 RID: 1924
		WebTrap,
		// Token: 0x04000785 RID: 1925
		TutorialLesson,
		// Token: 0x04000786 RID: 1926
		CircleMove,
		// Token: 0x04000787 RID: 1927
		EnergyBlast,
		// Token: 0x04000788 RID: 1928
		EnergyMissile,
		// Token: 0x04000789 RID: 1929
		DeathStruggle,
		// Token: 0x0400078A RID: 1930
		EyeLaser,
		// Token: 0x0400078B RID: 1931
		EyeLaserPlus,
		// Token: 0x0400078C RID: 1932
		PlayerTeleport,
		// Token: 0x0400078D RID: 1933
		TentacleSpawn,
		// Token: 0x0400078E RID: 1934
		TentacleSweep,
		// Token: 0x0400078F RID: 1935
		DrillAttack,
		// Token: 0x04000790 RID: 1936
		UndergroundIdle,
		// Token: 0x04000791 RID: 1937
		TutorialAction,
		// Token: 0x04000792 RID: 1938
		CrystalEnergyBlast,
		// Token: 0x04000793 RID: 1939
		CrystalDeathStruggle,
		// Token: 0x04000794 RID: 1940
		PoisonDash,
		// Token: 0x04000795 RID: 1941
		PoisonSpit,
		// Token: 0x04000796 RID: 1942
		PoisonCrush,
		// Token: 0x04000797 RID: 1943
		PlayerCripple,
		// Token: 0x04000798 RID: 1944
		PlayerDown,
		// Token: 0x04000799 RID: 1945
		PlayerRevive,
		// Token: 0x0400079A RID: 1946
		RollBack,
		// Token: 0x0400079B RID: 1947
		Invisible,
		// Token: 0x0400079C RID: 1948
		PlayerStun,
		// Token: 0x0400079D RID: 1949
		SwordSlash,
		// Token: 0x0400079E RID: 1950
		DefenseField,
		// Token: 0x0400079F RID: 1951
		DropBomb,
		// Token: 0x040007A0 RID: 1952
		AttachBomb,
		// Token: 0x040007A1 RID: 1953
		MAX
	}
}
