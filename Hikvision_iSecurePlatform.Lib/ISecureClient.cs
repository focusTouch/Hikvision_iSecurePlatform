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

    ///这里是实现方-库
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
            return area.code == "0" ? area.data : null;
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
            return org.code == "0" ? org.data : null;
        }

        /// <summary>
        /// 获取组织列表
        /// </summary>
        /// <returns>根据该接口全量同步组织信息,不作权限过滤，返回结果分页展示。</returns>
        public List<Organize> OrgorgList(PageQuery pageQuery)
        {
            string reqUrl = "/api/resource/v1/org/orgList";
            var orgList = hikHttpHelper.HttpPostCast<BaseListDataResponse<Organize>>(reqUrl, pageQuery);
            return orgList.code == "0" ? orgList.data.list : null;
        }



        /// <summary>
        /// 查询组织列表
        /// </summary>
        /// <returns>根据不同的组织属性分页查询组织信息。 查询组织列表接口可以根据组织唯一标识集、组织名称、组织状态这些查询条件来进行高级查询；若不指定查询条件，即全量获取所有的组织信息。返回结果分页展示。 注：若指定多个查询条件，表示将这些查询条件进行”与”的组合后进行精确查询。 根据”组织名称orgName”查询为模糊查询。</returns>
        public List<Organize> OrgAdvanceOrgList(OrganizeQuery pageQuery)
        {
            string reqUrl = "/api/resource/v1/org/advance/orgList";
            var orgList = hikHttpHelper.HttpPostCast<BaseListDataResponse<Organize>>(reqUrl, pageQuery);
            return orgList.code == "0" ? orgList.data.list : null;
        }

        /// <summary>
        /// 根据父组织编号获取下级组织列表
        /// </summary>
        /// <returns>根据父组织编号获取下级组织列表，主要用于逐层获取父组织的下级组织信息，返回结果分页展示。</returns>
        public List<Organize> OrgParentOrgIndexCodeSubOrgList(OrganizeQuery pageQuery)
        {
            string reqUrl = "/api/resource/v1/org/parentOrgIndexCode/subOrgList";
            var orgListResp = hikHttpHelper.HttpPostCast<BaseListDataResponse<Organize>>(reqUrl, pageQuery);
            return orgListResp.code == "0" ? orgListResp.data.list : null;
        }

        /// <summary>
        /// 获取单个组织信息
        /// </summary>
        /// <returns>根据组织唯一标识orgIndexCode获取指定的组织信息。</returns>
        public Organize OrgOrgIndexCodeOrgInfo(OrganizeQuery pageQuery)
        {
            string reqUrl = "/api/resource/v1/org/orgIndexCode/orgInfo";
            var orgResp = hikHttpHelper.HttpPostCast<BaseResponse<Organize>>(reqUrl, pageQuery);
            return orgResp.code == "0" ? orgResp.data : null;
        }

        /// <summary>
        ///修改组织
        /// </summary>
        /// <returns>根据组织编号修改组织信息。</returns>
        public bool OrgSingleUpdate(OrganizeQuery pageQuery)
        {
            string reqUrl = "/api/resource/v1/org/single/update";
            var orgResp = hikHttpHelper.HttpPostCast<BaseResponse<String>>(reqUrl, pageQuery);
            return orgResp.code == "0" ? true : false;
        }

        /// <summary>
        ///批量删除组织
        /// </summary>
        /// <returns>仅支持删除无子结点且组织下不存在人员的组织。</returns>
        public BaseListDataResponse<OrganizeDeleteResponse> OrgBatchDelete(OrganizeQuery pageQuery)
        {
            string reqUrl = "/api/resource/v1/org/batch/delete";
            var orgResp = hikHttpHelper.HttpPostCast<BaseListDataResponse<OrganizeDeleteResponse>>(reqUrl, pageQuery);
            return orgResp;
        }

        /// <summary>
        ///批量添加组织
        /// </summary>
        /// <returns>添加组织信息。 支持三方指定组织唯一标识， 也支持ISC独立生成组织唯一标识。</returns>
        public BaseBatchAddResponse<OrganizeAddResponse> OrgBatchAdd(List<OrganizeAddRequest> organizes)
        {
            string reqUrl = "/api/resource/v1/org/batch/add";
            var orgResp = hikHttpHelper.HttpPostCast<BaseBatchAddResponse<OrganizeAddResponse>>(reqUrl, organizes);
            return orgResp;
        }

        /// <summary>
        ///查询人员列表v2
        /// </summary>
        /// <returns>查询人员列表接口可以根据人员ID集、人员姓名、人员性别、所属组织、证件类型、证件号码、人员状态这些查询条件来进行高级查询；若不指定查询条件，即全量获取所有的人员信息。返回结果分页展示。 注：若指定多个查询条件，表示将这些查询条件进行”与”的组合后进行精确查询。 根据”人员名称personName”查询为模糊查询。本接口支持自定义属性的返回， 通过[获取资源属性]@[软件产品-综合安防管理平台-API列表-资源目录-人员信息接口-人员及照片接口#获取资源属性]接口获取平台已支持人员属性的说明。</returns>
        public List<Person> PersonAdvancePersonList(PersonQuery people)
        {
            string reqUrl = "/api/resource/v2/person/advance/personList";
            var orgResp = hikHttpHelper.HttpPostCast<BaseListDataResponse<Person>>(reqUrl, people);
            return orgResp.code == "0" ? orgResp.data.list : null;
        }

        /// <summary>
        ///获取人员列表v2
        /// </summary>
        /// <returns>获取人员列表接口可用来全量同步人员信息，返回结果分页展示。本接口支持自定义属性的返回， 通过[获取资源属性]@[软件产品-综合安防管理平台-API列表-资源目录-人员信息接口-人员及照片接口#获取资源属性]接口获取平台已支持人员属性的说明。 注：若指定多个查询条件，表示将这些查询条件进行”与”的组合后进行精确查询。 根据”人员名称personName”查询为模糊查询。本接口支持自定义属性的返回， 通过[获取资源属性]@[软件产品-综合安防管理平台-API列表-资源目录-人员信息接口-人员及照片接口#获取资源属性]接口获取平台已支持人员属性的说明。</returns>
        public List<Person> PersonPersonList(PageQuery people)
        {
            string reqUrl = "/api/resource/v2/person/personList";
            var orgResp = hikHttpHelper.HttpPostCast<BaseListDataResponse<Person>>(reqUrl, people);
            return orgResp.code == "0" ? orgResp.data.list : null;
        }

        /// <summary>
        /// 获取组织下人员列表v2
        /// </summary>
        /// <returns>根据组织编号获取组织下的人员信息列表，返回结果分页展示。本接口支持自定义属性的返回， 通过[获取资源属性]@[软件产品-综合安防管理平台-API列表-资源目录-人员信息接口-人员及照片接口#获取资源属性]接口获取平台已支持人员属性的说明。</returns>
        public List<Person> PersonOrgIndexCodePersonList(PersonQuery pensonQuery)
        {
            string reqUrl = "/api/resource/v2/person/orgIndexCode/personList";
            var orgListResp = hikHttpHelper.HttpPostCast<BaseListDataResponse<Person>>(reqUrl, pensonQuery);
            return orgListResp.code == "0" ? orgListResp.data.list : null;
        }

        /// <summary>
        /// 添加人员
        /// </summary>
        /// <returns>添加人员信息接口，注意，在安保基础数据配置的必选字段必须都包括在入参中。 人员添加的时候，可以指定人员personId，不允许与其他人员personId重复，包括已删除的人员。 本接口支持人员信息的扩展字段，按照属性定义key:value上传即可， 可通过[获取资源属性]@[软件产品-综合安防管理平台-API列表-资源目录-人员信息接口-人员及照片接口#获取资源属性]接口，获取平台已启用的人员属性信息。</returns>
        public bool PersonSingleAdd(PersonAddRequest personAddRequest)
        {
            string reqUrl = "/api/resource/v1/person/single/add";
            var personResponse = hikHttpHelper.HttpPostCast<BaseResponse<String>>(reqUrl, personAddRequest);
            return personResponse.code == "0"  ? true : false;
        }

        /// <summary>
        /// 修改人员
        /// </summary>
        /// <param name="personAddRequest"></param>
        /// <returns>根据人员编号修改人员信息。本接口支持人员信息的扩展字段，按照属性定义key:value上传即可， 可通过[获取资源属性]@[软件产品-综合安防管理平台-API列表-资源目录-人员信息接口-人员及照片接口#获取资源属性]接口，获取平台已启用的人员属性信息。</returns>
        public bool PersonSingleUpdate(Person person)
        {
            string reqUrl = "/api/resource/v1/person/single/update";
            var personResponse = hikHttpHelper.HttpPostCast<BaseResponse<String>>(reqUrl, person);
            return personResponse.code == "0"  ? true : false;
        }

        /// <summary>
        /// 批量删除人员
        /// </summary>
        /// <param name="person"></param>
        /// <returns>根据编号删除人员，人员删除是软删除，可以在安保基础数据查询已删除人员。支持批量删除人员。删除人员将会同时删除人员关联的指纹和人脸信息。</returns>
        public bool PersonBatchDelete(List<String> personIds)
        {
            string reqUrl = "/api/resource/v1/person/batch/delete";
            Dictionary<String,List<String>> reqData=new Dictionary<string, List<string>>();
            reqData.Add("personIds",personIds);
            var personResponse = hikHttpHelper.HttpPostCast<BaseListDataResponse<String>>(reqUrl, reqData);
            return personResponse.code == "0"  ? true : false;
        }

        /// <summary>
        /// 批量开卡
        /// </summary>
        /// <param name="person"></param>
        /// <returns>该接口主要是应用于对多个人同时开卡的场景，输入卡片开始有效日期、卡片截止有效日期以及对应的人员、卡片关联列表，实现对多个人员同时开卡的功能，开卡成功后，可以到相应子系统开启卡片的权限，例如到门禁子系统开启人员门禁权限。。</returns>
        public List<Card> CardBindings(CardBindingReq cardBindingReq)
        {
            string reqUrl = "/api/cis/v1/card/bindings";
            var cardResponse = hikHttpHelper.HttpPostCast<BaseListObjectResponse<Card>>(reqUrl, cardBindingReq);
            return cardResponse.code == "0" ? cardBindingReq.cardList : null;
        }

        /// <summary>
        /// 卡片退卡
        /// </summary>
        /// <param name="person"></param>
        /// <returns>该接口主要是应用于对人员下卡片进行退卡，输入卡号以及所属人员id，实现卡片退卡的功能。退卡成功后，相应子系统的卡片权限清除，例如所属卡片在门禁子系统的门禁权限全部清除。</returns>
        public bool CardDeletion(CardDeletionReq cardDeletion)
        {
            string reqUrl = "/api/cis/v1/card/deletion";
            var cardResponse = hikHttpHelper.HttpPostCast<BaseResponse<CardDeletionReq>>(reqUrl, cardDeletion);
            return cardResponse.code == "0" ? true : false;
        }

        /// <summary>
        /// 获取卡片列表
        /// </summary>
        /// <param name="person"></param>
        /// <returns>获取卡片列表接口可用来全量同步卡片信息，返回结果分页展示，不作权限过滤。</returns>
        public List<Card> CardCardList(CardQuery cardQuery)
        {
            string reqUrl = "/api/resource/v1/card/cardList";
            var cardResponse = hikHttpHelper.HttpPostCast<BaseListDataResponse<Card>>(reqUrl, cardQuery);
            return cardResponse.code == "0" ? cardResponse.data.list : null;
        }


        #endregion


        #region 资源

        /// <summary>
        /// 获取资源列表v2
        /// </summary>
        /// <param name="person"></param>
        /// <returns>根据资源类型分页获取资源列表，主要用于资源信息的全量同步。</returns>
        public List<Resource> DeviceResourceResources(ResourceTypeQery pageQuery)
        {
            string reqUrl = "/api/irds/v2/deviceResource/resources";
            var cardResponse = hikHttpHelper.HttpPostCast<BaseListDataResponse<Resource>>(reqUrl, pageQuery);
            return cardResponse.code == "0" ? cardResponse.data.list : null;
        }

        #endregion





        #region 一卡通权限相关



        /// <summary>
        /// 添加权限配置
        /// </summary>
        /// <param name="person"></param>
        /// <returns>权限配置支持按组织、人员和设备通道配置权限，适用综合大楼、学校、医院等场景。 说明：权限配置数据采用异步分批入库方式，接口调用成功后返回权限配置单编号，在配置的过程中分批插入数据，只有当配置单结束时才能查询到完整的权限配置信息。相同的配置数据重复配置时，第一次配置生效后，后面相同的配置将自动过滤丢弃。 合作方配置的tagId用于让多个应用共用出入控制权限服务时，用以区分各自的配置信息。 注意点：不同业务组件设备通道隔离，应该根据业务场景使用不同的设备通道配置权限；如对相同的设备通道都有业务应用，那么人员隔离，应该根据场景使用不同的人员，否则会造成权限条目归属相互竞争的情况，在权限条目综合查询时，数据归属以最后一次入库配置为准。</returns>
        public TaskResponse AuthConfigAdd(AuthConfigAddRequest authConfigAdd)
        {
            string reqUrl = "/api/acps/v1/auth_config/add";
            var taskResponse = hikHttpHelper.HttpPostCast<TaskResponse>(reqUrl, authConfigAdd);
            return taskResponse;
        }

        /// <summary>
        /// 删除权限配置
        /// </summary>
        /// <param name="person"></param>
        /// <returns>根据人员数据、设备通道删除已配置的权限，合作方配置的tagId用于让多个应用共用出入控制权限服务时，用以区分各自的配置信息，即只能删除同一个tagId的权限配置信息。</returns>
        public TaskResponse AuthConfigDelete(AuthConfigAddRequest authConfigAdd)
        {
            string reqUrl = "/api/acps/v1/auth_config/delete";
            var taskResponse = hikHttpHelper.HttpPostCast<TaskResponse>(reqUrl, authConfigAdd);
            return taskResponse;
        }




        /// <summary>
        /// 添加权限配置
        /// </summary>
        /// <param name="person"></param>
        /// <returns>权限配置支持按组织、人员和设备通道配置权限，适用综合大楼、学校、医院等场景。 说明：权限配置数据采用异步分批入库方式，接口调用成功后返回权限配置单编号，在配置的过程中分批插入数据，只有当配置单结束时才能查询到完整的权限配置信息。相同的配置数据重复配置时，第一次配置生效后，后面相同的配置将自动过滤丢弃。 合作方配置的tagId用于让多个应用共用出入控制权限服务时，用以区分各自的配置信息。 注意点：不同业务组件设备通道隔离，应该根据业务场景使用不同的设备通道配置权限；如对相同的设备通道都有业务应用，那么人员隔离，应该根据场景使用不同的人员，否则会造成权限条目归属相互竞争的情况，在权限条目综合查询时，数据归属以最后一次入库配置为准。</returns>
        public TaskProgressResponse AuthConfigTaskProgress(string taskId)
        {
            string reqUrl = "/api/acps/v1/auth_config/rate/search";
            Dictionary<String, string> req = new Dictionary<string, string>();
            req.Add("taskId", taskId);
            var taskResponse = hikHttpHelper.HttpPostCast<BaseResponse<TaskProgressResponse>>(reqUrl, req);
            return taskResponse.data;
        }

        public BaseResponse<String> AuthDownloadTaskStart(string taskId)
        {
            string reqUrl = "/api/acps/v1/authDownload/task/start";
            Dictionary<String, string> req = new Dictionary<string, string>();
            req.Add("taskId", taskId);
            var taskResponse = hikHttpHelper.HttpPostCast<BaseResponse<String>>(reqUrl, req);
            return taskResponse;
        }


        /// <summary>
        /// 根据出入权限配置快捷下载
        /// </summary>
        /// <param name="taskId">针对少量权限（100设备通道*1000人）的下载，减少调用方对接的复杂度，减少接口调用次数，该接口集合了创建任务-添加数据-开始下载3合1的功能。</param>
        /// <returns></returns>
        public TaskResponse AuthDownloadConfigurationShortcut(AuthDownloadShortcutReq req)
        {
            string reqUrl = "/api/acps/v1/authDownload/configuration/shortcut";
            var taskResponse = hikHttpHelper.HttpPostCast<TaskResponse>(reqUrl, req);
            return taskResponse;
        }



        public string AuthDownloadTaskProgress(String taskId)
        {
            string reqUrl = "/api/acps/v1/authDownload/task/progress";
            Dictionary<String, string> req = new Dictionary<string, string>();
            req.Add("taskId", taskId);
            var taskResponse = hikHttpHelper.HttpPostCast<String>(reqUrl, req);
            return taskResponse;
        }





        #endregion


    }

}