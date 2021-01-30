using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Hikvision_iSecurePlatform.Lib.Commons;
using Newtonsoft.Json.Converters;
using Hikvision_iSecurePlatform.Lib.Models.Response;
using Hikvision_iSecurePlatform.Lib.Models.Request;
using System.Linq;

namespace Hikvision_iSecurePlatform.Lib
{
    public class ISecureClient
    {

        // private Newtonsoft.Json.JsonSerializerSettings settings = new Newtonsoft.Json.JsonSerializerSettings();
        // private string ip = null;
        // private int port = 443;
        // private String appKey = null;
        // private String appSecret = null;
        // private String baseUrl = null;
        // private bool isHttps = true;
        // // private QxHttpClient httpClient = null;
        private HikHttpHelper hikHttpHelper = null;




        public ISecureClient(String appKey, String appSecret, String ip, int port = 443, bool isHttps = true)
        {
            hikHttpHelper = new HikHttpHelper(appKey, appSecret, ip, port, isHttps);
        }

        #region  区域

        /// <summary>
        /// 获取根区域信息
        /// </summary>
        /// <returns>获取根区域信息接口</returns>
        public Area RegionsRoot()
        {
            string reqUrl = "/api/resource/v1/regions/root";
            var area = hikHttpHelper.HttpPostCast<BaseResponse<Area>>(reqUrl);
            return area.code=="0"?area.data:null;
        }

        #endregion

           #region  组织

        /// <summary>
        /// 获取根区域信息
        /// </summary>
        /// <returns>获取根区域信息接口</returns>
        public Organize OrgRootOrg()
        {
            string reqUrl = "/api/resource/v1/org/rootOrg";
            var org = hikHttpHelper.HttpPostCast<BaseResponse<Organize>>(reqUrl);
            return org.code=="0"?org.data:null;
        }

         /// <summary>
        /// 获取组织列表
        /// </summary>
        /// <returns>根据该接口全量同步组织信息,不作权限过滤，返回结果分页展示。</returns>
        public List<Organize> OrgorgList(PageQuery pageQuery)
        {
            string reqUrl = "/api/resource/v1/org/rootOrg";
            // var json = hikHttpHelper.HttpPostCast<String>(reqUrl,pageQuery);

            var orgList = hikHttpHelper.HttpPostCast<BaseListDataResponse<Organize>>(reqUrl,pageQuery);
            return orgList.code=="0"?orgList.data.list:null;
        }




        #endregion

    }

}