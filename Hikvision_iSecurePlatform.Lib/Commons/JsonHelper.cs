using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

// Token: 0x02000002 RID: 2

public class JsonHelper
{
	// Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00000250
	public static string SerializeObject(object o)
	{
		return JsonConvert.SerializeObject(o);
	}

	// Token: 0x06000002 RID: 2 RVA: 0x0000206C File Offset: 0x0000026C
	public static T DeserializeJsonToObject<T>(string json) where T : class
	{
		JsonSerializer jsonSerializer = new JsonSerializer();
		StringReader reader = new StringReader(json);
		object obj = jsonSerializer.Deserialize(new JsonTextReader(reader), typeof(T));
		return obj as T;
	}

	// Token: 0x06000003 RID: 3 RVA: 0x000020B4 File Offset: 0x000002B4
	public static List<T> DeserializeJsonToList<T>(string json) where T : class
	{
		JsonSerializer jsonSerializer = new JsonSerializer();
		StringReader reader = new StringReader(json);
		object obj = jsonSerializer.Deserialize(new JsonTextReader(reader), typeof(List<T>));
		return obj as List<T>;
	}

	// Token: 0x06000004 RID: 4 RVA: 0x000020F4 File Offset: 0x000002F4
	public static T DeserializeAnonymousType<T>(string json, T anonymousTypeObject)
	{
		return JsonConvert.DeserializeAnonymousType<T>(json, anonymousTypeObject);
	}
}
