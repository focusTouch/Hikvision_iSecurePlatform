using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Hikvision_iSecurePlatform.Lib.Commons
{

    	public class HikRequest
	{
		// Token: 0x06000031 RID: 49 RVA: 0x00004B7E File Offset: 0x00002D7E
		public HikRequest()
		{
            
		}

		// Token: 0x06000032 RID: 50 RVA: 0x00004C26 File Offset: 0x00002E26
		public HikRequest(Method method, string host, string path, string appKey, string appSecret, int timeout)
		{
			this.method = method;
			this.host = host;
			this.path = path;
			this.appKey = appKey;
			this.appSecret = appSecret;
			this.timeout = timeout;
		}

		// Token: 0x17000007 RID: 7
		// (get) Token: 0x06000033 RID: 51 RVA: 0x00004C60 File Offset: 0x00002E60
		// (set) Token: 0x06000034 RID: 52 RVA: 0x00004C78 File Offset: 0x00002E78
		public Method Method
		{
			get
			{
				return this.method;
			}
			set
			{
				this.method = value;
			}
		}

		// Token: 0x17000008 RID: 8
		// (get) Token: 0x06000035 RID: 53 RVA: 0x00004C84 File Offset: 0x00002E84
		// (set) Token: 0x06000036 RID: 54 RVA: 0x00004C9C File Offset: 0x00002E9C
		public string Host
		{
			get
			{
				return this.host;
			}
			set
			{
				this.host = value;
			}
		}

		// Token: 0x17000009 RID: 9
		// (get) Token: 0x06000037 RID: 55 RVA: 0x00004CA8 File Offset: 0x00002EA8
		// (set) Token: 0x06000038 RID: 56 RVA: 0x00004CC0 File Offset: 0x00002EC0
		public string Path
		{
			get
			{
				return this.path;
			}
			set
			{
				this.path = value;
			}
		}

		// Token: 0x1700000A RID: 10
		// (get) Token: 0x06000039 RID: 57 RVA: 0x00004CCC File Offset: 0x00002ECC
		// (set) Token: 0x0600003A RID: 58 RVA: 0x00004CE4 File Offset: 0x00002EE4
		public string AppKey
		{
			get
			{
				return this.appKey;
			}
			set
			{
				this.appKey = value;
			}
		}

		// Token: 0x1700000B RID: 11
		// (get) Token: 0x0600003B RID: 59 RVA: 0x00004CF0 File Offset: 0x00002EF0
		// (set) Token: 0x0600003C RID: 60 RVA: 0x00004D08 File Offset: 0x00002F08
		public string AppSecret
		{
			get
			{
				return this.appSecret;
			}
			set
			{
				this.appSecret = value;
			}
		}

		// Token: 0x1700000C RID: 12
		// (get) Token: 0x0600003D RID: 61 RVA: 0x00004D14 File Offset: 0x00002F14
		// (set) Token: 0x0600003E RID: 62 RVA: 0x00004D2C File Offset: 0x00002F2C
		public int Timeout
		{
			get
			{
				return this.timeout;
			}
			set
			{
				this.timeout = value;
			}
		}

		// Token: 0x1700000D RID: 13
		// (get) Token: 0x0600003F RID: 63 RVA: 0x00004D38 File Offset: 0x00002F38
		// (set) Token: 0x06000040 RID: 64 RVA: 0x00004D50 File Offset: 0x00002F50
		public Dictionary<string, string> Headers
		{
			get
			{
				return this.headers;
			}
			set
			{
				this.headers = value;
			}
		}

		// Token: 0x1700000E RID: 14
		// (get) Token: 0x06000041 RID: 65 RVA: 0x00004D5C File Offset: 0x00002F5C
		// (set) Token: 0x06000042 RID: 66 RVA: 0x00004D74 File Offset: 0x00002F74
		public Dictionary<string, string> Querys
		{
			get
			{
				return this.querys;
			}
			set
			{
				this.querys = value;
			}
		}

		// Token: 0x1700000F RID: 15
		// (get) Token: 0x06000043 RID: 67 RVA: 0x00004D80 File Offset: 0x00002F80
		// (set) Token: 0x06000044 RID: 68 RVA: 0x00004D98 File Offset: 0x00002F98
		public Dictionary<string, string> Bodys
		{
			get
			{
				return this.bodys;
			}
			set
			{
				this.bodys = value;
			}
		}

		// Token: 0x17000010 RID: 16
		// (get) Token: 0x06000045 RID: 69 RVA: 0x00004DA4 File Offset: 0x00002FA4
		// (set) Token: 0x06000046 RID: 70 RVA: 0x00004DBC File Offset: 0x00002FBC
		public string StringBody
		{
			get
			{
				return this.stringBody;
			}
			set
			{
				this.stringBody = value;
			}
		}

		// Token: 0x17000011 RID: 17
		// (get) Token: 0x06000047 RID: 71 RVA: 0x00004DC8 File Offset: 0x00002FC8
		// (set) Token: 0x06000048 RID: 72 RVA: 0x00004DE0 File Offset: 0x00002FE0
		public byte[] BytesBody
		{
			get
			{
				return this.bytesBody;
			}
			set
			{
				this.bytesBody = value;
			}
		}

		// Token: 0x17000012 RID: 18
		// (get) Token: 0x06000049 RID: 73 RVA: 0x00004DEC File Offset: 0x00002FEC
		// (set) Token: 0x0600004A RID: 74 RVA: 0x00004E04 File Offset: 0x00003004
		public List<string> SignHeaderPrefixList
		{
			get
			{
				return this.signHeaderPrefixList;
			}
			set
			{
				this.signHeaderPrefixList = value;
			}
		}

		// Token: 0x04000029 RID: 41
		private Method method;

		// Token: 0x0400002A RID: 42
		private string host;

		// Token: 0x0400002B RID: 43
		private string path;

		// Token: 0x0400002C RID: 44
		private string appKey;

		// Token: 0x0400002D RID: 45
		private string appSecret;

		// Token: 0x0400002E RID: 46
		private int timeout;

		// Token: 0x0400002F RID: 47
		private Dictionary<string, string> headers;

		// Token: 0x04000030 RID: 48
		private Dictionary<string, string> querys;

		// Token: 0x04000031 RID: 49
		private Dictionary<string, string> bodys;

		// Token: 0x04000032 RID: 50
		private string stringBody;

		// Token: 0x04000033 RID: 51
		private byte[] bytesBody;

		// Token: 0x04000034 RID: 52
		private List<string> signHeaderPrefixList;
	}

    	public enum Method
	{
		// Token: 0x04000021 RID: 33
		GET,
		// Token: 0x04000022 RID: 34
		POST_FORM,
		// Token: 0x04000023 RID: 35
		POST_STRING,
		// Token: 0x04000024 RID: 36
		POST_BYTES,
		// Token: 0x04000025 RID: 37
		PUT_FORM,
		// Token: 0x04000026 RID: 38
		PUT_STRING,
		// Token: 0x04000027 RID: 39
		PUT_BYTES,
		// Token: 0x04000028 RID: 40
		DELETE
	}

}
