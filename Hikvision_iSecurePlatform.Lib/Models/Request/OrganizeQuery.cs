using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Hikvision_iSecurePlatform.Lib.Commons;
using Newtonsoft.Json.Converters;

namespace Hikvision_iSecurePlatform.Lib.Models.Request
{
    /// <summary>
    /// 组织机构查询类
    /// </summary>
    public class OrganizeQuery : PageQuery
    {
        /// <summary>
        /// 组织名称
        /// </summary>
        /// <value>组织名称，如默认部门</value>
        public String orgName{get;set;}

        /// <summary>
        /// 组织唯一标识码集合
        /// </summary>
        /// <value>组织唯一标识码集合 多个值使用英文逗号分隔，不超过1000个，从[获取组织列表]@[软件产品-综合安防管理平台-API列表-资源目录-人员信息接口-组织信息接口#获取组织列表]接口获取返回参数orgIndexCode</value>
        public String orgIndexCodes{get;set;}

        /// <summary>
        /// 父组织编号
        /// </summary>
        /// <value>父组织编号,从[获取组织列表]@[软件产品-综合安防管理平台-API列表-资源目录-人员信息接口-组织信息接口#获取组织列表]接口获取返回参数orgIndexCode</value>
        public String parentOrgIndexCode{get;set;}

        /// <summary>
        /// 组织编号
        /// </summary>
        /// <value>组织编号,从[获取组织列表]@[软件产品-综合安防管理平台-API列表-资源目录-人员信息接口-组织信息接口#获取组织列表]接口获取返回参数orgIndexCode</value>
        public String orgIndexCode{get;set;}

        /// <summary>
        /// 待删除的组织indexCode列表，单次提交上限为1000条
        /// </summary>
        /// <value>待删除的组织indexCode,从[获取组织列表]@[软件产品-综合安防管理平台-API列表-资源目录-人员信息接口-组织信息接口#获取组织列表]接口获取返回参数orgIndexCode</value>
        public List<String> indexCodes{get;set;}
    }

}