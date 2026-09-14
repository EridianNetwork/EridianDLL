using System;
using System.IO;
using System.Net.Sockets;
using System.Text;
using Core;
using UnityEngine;

namespace ns0
{
	// Token: 0x020002A6 RID: 678
	public class WebDebugManager : MonoSingleton<WebDebugManager>
	{
		// Token: 0x06000E9B RID: 3739 RVA: 0x00073AF8 File Offset: 0x00071CF8
		protected override void Awake()
		{
			base.Awake();
			Application.RegisterLogCallback(new Application.LogCallback(this.method_2));
			this.stringWriter_0 = new StringWriter();
			IAsyncResult asyncResult = this.tcpClient_0.BeginConnect("127.0.0.1", 666, null, null);
			if (!asyncResult.AsyncWaitHandle.WaitOne(TimeSpan.FromSeconds(0.1)))
			{
				DebugUtils.Log(LogCategory.Profile, "Failed to connect to log server");
			}
			else
			{
				this.networkStream_0 = this.tcpClient_0.GetStream();
			}
			try
			{
			}
			catch (Exception)
			{
			}
			this.method_3();
		}

		// Token: 0x06000E9C RID: 3740 RVA: 0x0000CD34 File Offset: 0x0000AF34
		private void OnDestroy()
		{
			this.method_0();
			Application.RegisterLogCallback(null);
		}

		// Token: 0x06000E9D RID: 3741 RVA: 0x00073B94 File Offset: 0x00071D94
		private void method_0()
		{
			if (this.networkStream_0 != null)
			{
				UTF8Encoding utf8Encoding = new UTF8Encoding();
				byte[] bytes = utf8Encoding.GetBytes(this.stringWriter_0.ToString());
				this.networkStream_0.Write(bytes, 0, bytes.Length);
			}
			if (this.streamWriter_0 != null)
			{
				this.streamWriter_0.Write(this.stringWriter_0.ToString());
				this.streamWriter_0.Flush();
			}
			this.stringWriter_0.GetStringBuilder().Remove(0, this.stringWriter_0.ToString().Length);
		}

		// Token: 0x06000E9E RID: 3742 RVA: 0x0000311B File Offset: 0x0000131B
		public void method_1(LogCategory logCategory_0, LogType logType_0, string string_2)
		{
		}

		// Token: 0x06000E9F RID: 3743 RVA: 0x00073C1C File Offset: 0x00071E1C
		private void method_2(string string_2, string string_3, LogType logType_0)
		{
			if (logType_0 == LogType.Assert || logType_0 == LogType.Exception)
			{
			}
			if (logType_0 == LogType.Assert || logType_0 == LogType.Error || logType_0 == LogType.Exception)
			{
			}
			string_2 = string_2.Replace("Exception: ", string.Empty);
			string text = "trace" + this.int_0++;
			if (!string_2.Contains("::"))
			{
				string_2 = string.Concat(new object[]
				{
					"<p class=\"",
					LogCategory.Default,
					"\"><span class=\"",
					logType_0,
					"\"/><span class=\"time\">TIME##</span><a onclick=\"hide('TRACE##')\">STACK</a>",
					string_2,
					"</p>"
				});
			}
			else
			{
				string_2 = string_2.Replace("::", "\"><span class=\"" + logType_0 + "\"/><span class=\"time\">TIME##</span><a onclick=\"hide('TRACE##')\">STACK</a>");
				string_2 = "<p class=\"" + string_2 + "</p>";
			}
			string text2 = Time.realtimeSinceStartup.ToString();
			string_2 = string_2.Replace("TIME##", text2);
			string_2 = string_2.Replace("TRACE##", text);
			this.stringWriter_0.WriteLine(string_2);
			string_2 = string.Concat(new string[] { "<pre id=\"", text, "\">", string_3, "</pre>" });
			this.stringWriter_0.WriteLine(string_2);
			this.method_0();
		}

		// Token: 0x06000EA0 RID: 3744 RVA: 0x00073D78 File Offset: 0x00071F78
		private void method_3()
		{
			this.stringWriter_0.WriteLine("<script language=\"javascript\" src=\"http://localhost:8080/debug/log.js\"></script>");
			this.stringWriter_0.WriteLine("<link rel=\"stylesheet\" type=\"text/css\" href=\"http://localhost:8080/debug/log.css\" />");
			this.stringWriter_0.WriteLine("<div class=\"Category\">\n");
			for (int i = 0; i < Enum.GetValues(typeof(LogCategory)).Length; i++)
			{
				this.stringWriter_0.WriteLine(string.Concat(new object[]
				{
					"<input type=\"button\" value=\"",
					Enum.GetValues(typeof(LogCategory)).GetValue(i),
					"\" class=\"",
					Enum.GetValues(typeof(LogCategory)).GetValue(i),
					" Button\" onclick=\"hide_class('",
					Enum.GetValues(typeof(LogCategory)).GetValue(i),
					"')\"/>"
				}));
			}
			this.stringWriter_0.WriteLine("<br />");
			this.stringWriter_0.WriteLine("</div>");
			this.stringWriter_0.WriteLine("<div class=\"Priority\">\n");
			for (int j = 0; j < Enum.GetValues(typeof(LogType)).Length; j++)
			{
				this.stringWriter_0.WriteLine(string.Concat(new object[]
				{
					"<input type=\"button\" value=\"",
					Enum.GetValues(typeof(LogType)).GetValue(j),
					"\" class=\"Button\" onclick=\"hide_priority('",
					Enum.GetValues(typeof(LogType)).GetValue(j),
					"')\"/>"
				}));
			}
			this.stringWriter_0.WriteLine("<br />");
			this.stringWriter_0.WriteLine("</div>");
			this.stringWriter_0.WriteLine("<h1 class=\"date\">{0} - {1} - {2}</h1>", DateTime.Now.ToString(), Application.platform, Application.unityVersion);
			this.stringWriter_0.WriteLine("<p>Click on buttons to toggle visibility. Click on STACK buttons to toggle visibility of stack traces.</p>");
			this.method_0();
		}

		// Token: 0x04000D1B RID: 3355
		private const string webUrl = "http://localhost:8080/debug/";

		// Token: 0x04000D1C RID: 3356
		private TcpClient tcpClient_0 = new TcpClient();

		// Token: 0x04000D1D RID: 3357
		private NetworkStream networkStream_0;

		// Token: 0x04000D1E RID: 3358
		private StringWriter stringWriter_0;

		// Token: 0x04000D1F RID: 3359
		private StreamWriter streamWriter_0;

		// Token: 0x04000D20 RID: 3360
		private int int_0;

		// Token: 0x04000D21 RID: 3361
		public static string string_1 = "bol_output.html";
	}
}
