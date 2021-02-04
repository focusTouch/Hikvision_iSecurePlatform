using System;
using System.IO;
using System.Linq;
using System.Threading;
using Hikvision_iSecurePlatform.Lib.Commons;
using Hikvision_iSecurePlatform.Lib.Models.Request;
using Hikvision_iSecurePlatform.Lib.Models.Response;

namespace Hikvision_iSecurePlatform.Control
{
    class Program
    {


        //这里是调用方-
        static void Main(string[] args)
        {

            Hikvision_iSecurePlatform.Lib.ISecureClient secureClient = new Lib.ISecureClient("23766385", "pm6KG3CT1Q7rcwf4oZmg", "10.118.125.200", 443, true);

            //查询根区域
            // secureClient.RegionsRoot();  


            #region  组织相关

            //查询根组织
            // secureClient.OrgRootOrg();

            //获取组织列表
            //var orgList= secureClient.OrgorgList(new Lib.Models.Request.PageQuery(){pageNo=1, pageSize=1000});

            //查询组织列表
            //var orgList= secureClient.OrgAdvanceOrgList(new OrganizeQuery(){pageNo=1, pageSize=1000,orgName="华谊",orgIndexCodes="root000000"});

            //根据父组织编号获取下级组织列表
            //var orgList= secureClient.OrgParentOrgIndexCodeSubOrgList(new OrganizeQuery(){pageNo=1, pageSize=1000,parentOrgIndexCode="root000000"});

            //获取单个组织信息
            //var org= secureClient.OrgOrgIndexCodeOrgInfo(new OrganizeQuery(){orgIndexCode="root000000"});

            //修改组织(错)
            //var orgList= secureClient.OrgAdvanceOrgList(new OrganizeQuery(){pageNo=1, pageSize=1000,orgName="测试"});
            //var org= secureClient.OrgSingleUpdate(new OrganizeQuery(){orgIndexCode=orgList[0].orgIndexCode,orgName="测试产品部"});

            //批量删除组织(错)
            //var orgList= secureClient.OrgAdvanceOrgList(new OrganizeQuery(){pageNo=1, pageSize=1000,orgName="测试"});
            //var orgDeletes = secureClient.OrgBatchDelete(new OrganizeQuery(){indexCodes=orgList.Select(p=>p.orgIndexCode).ToList()});

            //批量添加组织
            //OrganizeAddRequest addOrgTest1 = new OrganizeAddRequest();
            //addOrgTest1.clientId = 888;
            //addOrgTest1.orgCode = "01101001";
            //addOrgTest1.orgIndexCode = "addOrgTest101101001";
            //addOrgTest1.orgName = "测试自动添加部门1";
            //addOrgTest1.parentIndexCode = "root000000";
            //var addOrgResp = secureClient.OrgBatchAdd(new OrganizeAddRequest[] { addOrgTest1 }.ToList());

            #endregion

            #region 人员相关..
            //查询人员列表v2
            //var personList= secureClient.PersonAdvancePersonList(new PeopleQuery(){gender=1,pageNo=1,pageSize=1000});

            //获取人员列表v2
            //var personList= secureClient.PersonPersonList(new PageQuery(){pageNo=1, pageSize=1000});

            //获取组织下人员列表v2
            var orgList = secureClient.OrgAdvanceOrgList(new OrganizeQuery() { pageNo = 1, pageSize = 1000, orgName = "华谊信息" });

            //FileStream fileStream = new FileStream(@"C:\Users\Administrator\Desktop\myq1.jpg", FileMode.Open);
            //byte[] faceBuffer = new byte[fileStream.Length];
            //fileStream.Read(faceBuffer, 0, faceBuffer.Length);
            //fileStream.Close();

            //PersonAddRequest personAdd1 = new PersonAddRequest();
            //personAdd1.personId = "10010100101";
            //personAdd1.birthday = "1990-08-30";
            //personAdd1.email = "123456@qq.com";
            //personAdd1.gender = "1";
            //personAdd1.orgIndexCode = orgList[0].orgIndexCode;
            //personAdd1.personName = "马跃乾";
            //personAdd1.jobNo = "10010100101";
            //personAdd1.certificateNo = "10010100101";
            //personAdd1.certificateType = "111";
            //personAdd1.faces = new System.Collections.Generic.List<FaceData>();
            //FaceData faceData = new FaceData();
            //faceData.faceData = Convert.ToBase64String(faceBuffer);
            //personAdd1.faces.Add(faceData);

            //////添加人员
            //var addPersonResp = secureClient.PersonSingleAdd(personAdd1);



            ////修改人员
            var personList = secureClient.PersonAdvancePersonList(new PersonQuery() { pageNo = 1, pageSize = 1000, personName = "马跃乾" });
            var editPerson1 = personList[0];
            editPerson1.certificateType = 111;
            editPerson1.personName = "老马识途C";
            var editResponse = secureClient.PersonSingleUpdate(editPerson1);

            //删除人员
            //personList = secureClient.PersonAdvancePersonList(new PersonQuery() { pageNo = 1, pageSize = 1000, personName = "老马识途" });
            //var deletePersonFlag = secureClient.PersonBatchDelete(personList.Select(p => p.personId).ToList());


            ////卡片退卡
            //var cardDeletion = new CardDeletionReq();
            //var personList = secureClient.PersonAdvancePersonList(new PersonQuery() { pageNo = 1, pageSize = 1000, personName = "明珠" });
            //cardDeletion.personId = personList[0].personId;
            //cardDeletion.cardNumber = "1A1B1C1D";
            //cardDeletion.personId = personList[0].personId;
            //var deleteCard = secureClient.CardDeletion(cardDeletion);

            //批量开卡
            var cardbindingReq = new CardBindingReq();
            cardbindingReq.startDate = "2021-02-01";
            cardbindingReq.endDate = "2022-02-01";
            cardbindingReq.cardList = new System.Collections.Generic.List<Card>();
            Card card = new Card();
            card.cardNo = "1A1B1C1D";
            card.cardType = "1";
            personList = secureClient.PersonAdvancePersonList(new PersonQuery() { pageNo = 1, pageSize = 1000, personName = "老马" });
            card.personId = personList[0].personId;
            card.orgIndexCode = personList[0].orgIndexCode;
            cardbindingReq.cardList.Add(card);
            var cardList = secureClient.CardBindings(cardbindingReq);



            //获取卡片列表
            // var cardResp = secureClient.CardCardList(new CardQuery() { pageNo = 1, pageSize = 1000 });

            #endregion


            #region  资源相关 

            var resources = secureClient.DeviceResourceResources(new ResourceTypeQery() { pageNo = 1, pageSize = 1000, resourceType = "door" });
            #endregion

            {
                //删除权限
                //var deleteConfgs = new AuthConfigAddRequest();
                //deleteConfgs.personDatas = new System.Collections.Generic.List<AuthConfigAddRequest.PersonData>();
                //deleteConfgs.personDatas.Add(new AuthConfigAddRequest.PersonData() { personDataType = "person", indexCodes = personList.Select(p => p.personId).ToList() });
                //deleteConfgs.resourceInfos = new System.Collections.Generic.List<AuthConfigAddRequest.RresourceInfo>();

                //resources.ForEach(v =>
                //{
                //    deleteConfgs.resourceInfos.Add(new AuthConfigAddRequest.RresourceInfo() { resourceIndexCode = v.indexCode, resourceType = v.resourceType });
                //});
                //var deleteConfigs = secureClient.AuthConfigDelete(deleteConfgs);
                //var shortCutReq1 = new AuthDownloadShortcutReq();
                //shortCutReq1.taskType = 1;//要搞1 和 4
                //shortCutReq1.resourceInfos = resources.Select(p => new AuthDownloadShortcutReq.ResourceInfo() { resourceIndexCode = p.indexCode, resourceType = p.channelType }).ToList();
                //var shortCutResp1 = secureClient.AuthDownloadConfigurationShortcut(shortCutReq1);

                //shortCutReq1.taskType = 4;//要搞1 和 4
                //shortCutResp1 = secureClient.AuthDownloadConfigurationShortcut(shortCutReq1);

            }

            #region 一卡通权限相关
            var authConfgs = new AuthConfigAddRequest();
            authConfgs.personDatas = new System.Collections.Generic.List<AuthConfigAddRequest.PersonData>();
            authConfgs.personDatas.Add(new AuthConfigAddRequest.PersonData() { personDataType = "person", indexCodes = personList.Select(p => p.personId).ToList() });
            authConfgs.resourceInfos = new System.Collections.Generic.List<AuthConfigAddRequest.RresourceInfo>();

            resources.ForEach(v =>
            {
                authConfgs.resourceInfos.Add(new AuthConfigAddRequest.RresourceInfo() { resourceIndexCode = v.indexCode, resourceType = v.resourceType });
            });


            var addConfigs = secureClient.AuthConfigAdd(authConfgs);
            var shortCutReq = new AuthDownloadShortcutReq();
            shortCutReq.taskType = 1;//要搞1 和 4
            shortCutReq.resourceInfos = resources.Select(p => new AuthDownloadShortcutReq.ResourceInfo() { resourceIndexCode = p.indexCode, resourceType = p.channelType }).ToList();
            var shortCutResp = secureClient.AuthDownloadConfigurationShortcut(shortCutReq);
            shortCutReq.taskType = 4;//要搞1 和 4
            shortCutResp = secureClient.AuthDownloadConfigurationShortcut(shortCutReq);


            #endregion



            Console.WriteLine("Hello World!");
        }
    }
}
