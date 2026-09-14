using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading;

// Token: 0x02000394 RID: 916
public class HttpHelper
{
	// Token: 0x06001710 RID: 5904 RVA: 0x000110F5 File Offset: 0x0000F2F5
	private HttpHelper()
	{
		this.mLockable = new object();
		this.mRequestQueue = new Queue<HttpHelper.QueuedRequest>();
		this.mThread = new Thread(new ThreadStart(this.method_2));
		this.mThread.Start();
	}

	// Token: 0x1700012F RID: 303
	// (get) Token: 0x06001711 RID: 5905 RVA: 0x00011135 File Offset: 0x0000F335
	public static HttpHelper HttpHelper_0
	{
		get
		{
			if (HttpHelper.mInstance == null)
			{
				HttpHelper.mInstance = new HttpHelper();
			}
			return HttpHelper.mInstance;
		}
	}

	// Token: 0x06001712 RID: 5906 RVA: 0x0001114D File Offset: 0x0000F34D
	public void method_0(string string_0, string string_1, JSONObject jsonobject_0)
	{
		this.method_1(string_0, string_1, jsonobject_0.ToString());
	}

	// Token: 0x06001713 RID: 5907 RVA: 0x0007D3DC File Offset: 0x0007B5DC
	private void method_1(string string_0, string string_1, string string_2)
	{
		string text = "http://" + string_0 + string_1;
		object obj = this.mLockable;
		lock (obj)
		{
			this.mRequestQueue.Enqueue(new HttpHelper.QueuedRequest
			{
				Method = "POST",
				RemotePath = text,
				Payload = string_2
			});
		}
	}

	// Token: 0x06001714 RID: 5908 RVA: 0x0007D448 File Offset: 0x0007B648
	private void method_2()
	{
		while (true)
		{
			if (mRequestQueue.Count > 0)
			{
				try
				{
					QueuedRequest queuedRequest = null;
					lock (mLockable)
					{
						queuedRequest = mRequestQueue.Dequeue();
					}
					if (queuedRequest == null)
					{
						continue;
					}
					WebRequest webRequest = WebRequest.Create(new Uri(queuedRequest.RemotePath));
					webRequest.Timeout = 30000;
					webRequest.Method = queuedRequest.Method;
					if (!string.IsNullOrEmpty(queuedRequest.Payload))
					{
						webRequest.ContentLength = queuedRequest.Payload.Length;
						using Stream stream = webRequest.GetRequestStream();
						using StreamWriter streamWriter = new StreamWriter(stream);
						streamWriter.Write(queuedRequest.Payload);
					}
					using (webRequest.GetResponse())
					{
					}
				}
				catch (WebException)
				{
				}
			}
			else
			{
				Thread.Sleep(100);
			}
		}
	}
	// Token: 0x04000FB9 RID: 4025
	private static HttpHelper mInstance;

	// Token: 0x04000FBA RID: 4026
	private Thread mThread;

	// Token: 0x04000FBB RID: 4027
	private Queue<HttpHelper.QueuedRequest> mRequestQueue;

	// Token: 0x04000FBC RID: 4028
	private object mLockable;

	// Token: 0x02000395 RID: 917
	private class QueuedRequest
	{
		// Token: 0x17000130 RID: 304
		// (get) Token: 0x06001716 RID: 5910 RVA: 0x0001115D File Offset: 0x0000F35D
		// (set) Token: 0x06001717 RID: 5911 RVA: 0x00011165 File Offset: 0x0000F365
		public string Method { get; set; }

		// Token: 0x17000131 RID: 305
		// (get) Token: 0x06001718 RID: 5912 RVA: 0x0001116E File Offset: 0x0000F36E
		// (set) Token: 0x06001719 RID: 5913 RVA: 0x00011176 File Offset: 0x0000F376
		public string RemotePath { get; set; }

		// Token: 0x17000132 RID: 306
		// (get) Token: 0x0600171A RID: 5914 RVA: 0x0001117F File Offset: 0x0000F37F
		// (set) Token: 0x0600171B RID: 5915 RVA: 0x00011187 File Offset: 0x0000F387
		public string Payload { get; set; }
	}
}
