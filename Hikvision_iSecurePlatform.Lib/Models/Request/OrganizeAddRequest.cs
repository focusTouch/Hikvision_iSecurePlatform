using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Hikvision_iSecurePlatform.Lib.Commons;
using Newtonsoft.Json.Converters;

namespace Hikvision_iSecurePlatform.Lib.Models.Request
{
    public class OrganizeAddRequest
    {
        /// <summary>
        /// 调用方指定标识
        /// </summary>
        /// <value>接口执行成功后将服务端生成的标识与此标识绑定后返回，再通过返回值中的clientId判断哪些成功，哪些失败。所以建议每次接口调用，clientid保持唯一。 注：clientid只对本次调用有效</value>
       public long? clientId{get;set;}

       /// <summary>
       /// 组织唯一标志
       /// </summary>
       /// <value>组织唯一标志，为空时系统自动生成唯一标志</value>
       public String orgIndexCode{get;set;}

       /// <summary>
       /// 组织名称
       /// </summary>
       /// <value>组织名称，1~32个字符；不能包含 ' / \ : * ? " < > | 这些特殊字符</value>
       public String orgName{get;set;}

       /// <summary>
       /// 父组织唯一标识码
       /// </summary>
       /// <value>父组织唯一标识码</value>
       public String parentIndexCode{get;set;}

       /// <summary>
       /// 组织编码
       /// </summary>
       /// <value>组织编码，当添加小区节点时必填，编码使用01101开头的8位数字编码，当添加楼栋单元时必填，编码使用01101开头的20位数字编码， 其它场景下改值无效</value>
       public String orgCode{get;set;}  
    }

}