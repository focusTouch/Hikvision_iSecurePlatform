using System;
using Hikvision_iSecurePlatform.Lib.Commons;

namespace Hikvision_iSecurePlatform.Control
{
    class Program
    {
        static void Main(string[] args)
        {

            Hikvision_iSecurePlatform.Lib.ISecureClient secureClient=new Lib.ISecureClient("23766385","pm6KG3CT1Q7rcwf4oZmg","www.link456.com",2443,true);
            // secureClient.RegionsRoot();  //查询根区域

            // secureClient.OrgRootOrg();//查询根组织
            secureClient.OrgorgList(new Lib.Models.Request.PageQuery(){pageNo=1, pageSize=999999});//获取组织列表
            Console.WriteLine("Hello World!");
        }
    }
}
