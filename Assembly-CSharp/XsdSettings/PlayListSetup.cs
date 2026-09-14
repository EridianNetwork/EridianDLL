using System;
using System.Xml.Serialization;

namespace XsdSettings
{
	// Token: 0x020009F8 RID: 2552
	public class PlayListSetup
	{
		// Token: 0x17000658 RID: 1624
		// (get) Token: 0x0600463A RID: 17978 RVA: 0x0002E594 File Offset: 0x0002C794
		// (set) Token: 0x0600463B RID: 17979 RVA: 0x0002E59C File Offset: 0x0002C79C
		[XmlArrayItem("m_playlist", IsNullable = false)]
		public Playlist[] m_playlists { get; set; }

		// Token: 0x040031ED RID: 12781
		private Playlist[] m_playlistsField;
	}
}
