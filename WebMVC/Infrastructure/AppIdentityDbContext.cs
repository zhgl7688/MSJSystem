using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using WebMVC.Models;

namespace WebMVC.Infrastructure
{

    public class AppIdentityDbContext : IdentityDbContext<Models.ApplicationUser>
    {
        public AppIdentityDbContext() : base("DefaultConnection") { }
        static AppIdentityDbContext()
        {
            Database.SetInitializer<AppIdentityDbContext>(new IdentityDbInit());
        }
        public static AppIdentityDbContext Create()
        {
            return new AppIdentityDbContext();
        }
        public DbSet<AgentInput> AgentInputs { get; set; }
        public DbSet<BrandsInput> BrandsInputs { get; set; }
        public DbSet<BrandStrengthInit> BrandStrengthInit { get; set; }
        public DbSet<ProductInnovationInit> ProductInnovationInit { get; set; }
        public DbSet<MarketPromotionInit> MarketPromotionInit { get; set; }
        public DbSet<ChannelServiceInit> ChannelServiceInit { get; set; }
        public DbSet<MarketPriceInit> MarketPriceInit { get; set; }
        public DbSet<CurrentShareInit> CurrentShareInit { get; set; }
        public DbSet<CodeInit> CodeInit { get; set; }
        public DbSet<PriceMange> PriceMange { get; set; }
        public DbSet<PurchaseTable> PurchaseTable { get; set; }
        public DbSet<StageAdd> StageAdd { get; set; }
        public DbSet<InvestSub> InvestSub { get; set; }
        public DbSet<PriceManageSub> PriceManageSub { get; set; }

        public DbSet<DataInit> DataInits { get; set; }
    }
    public class IdentityDbInit : DropCreateDatabaseIfModelChanges<AppIdentityDbContext>
    {
        protected override void Seed(AppIdentityDbContext context)
        {
            PerformInitialSetup(context);
            context.CodeInit.Add(new CodeInit
            {
                Code = "Stage",
                Value = 0,
                Text = "起始阶段",
                CreateDate = DateTime.Now
            });
            context.CodeInit.Add(new CodeInit
            {
                Code = "Stage",
                Value = 1,
                Text = "第1阶段",
                CreateDate = DateTime.Now
            });
            context.CodeInit.Add(new Models.CodeInit
            {
                Code = "Agent",
                Value = 1,
                Text = "代1",
                CreateDate = DateTime.Now
            });
            context.CodeInit.Add(new CodeInit {   Code = "Stage",   Value = 2,    Text = "第2阶段",  CreateDate = DateTime.Now    });
            context.CodeInit.Add(new CodeInit {   Code = "Stage",   Value = 3,    Text = "第3阶段",  CreateDate = DateTime.Now    });
            context.CodeInit.Add(new Models.CodeInit { Code = "Agent",  Value = 2, Text = "代2",  CreateDate = DateTime.Now   });
            context.CodeInit.Add(new Models.CodeInit { Code = "Agent",  Value = 3, Text = "代3",  CreateDate = DateTime.Now   });
            context.CodeInit.Add(new Models.CodeInit { Code = "Agent",  Value = 4, Text = "代4",  CreateDate = DateTime.Now   });
            context.CodeInit.Add(new Models.CodeInit { Code = "Agent",  Value = 5, Text = "代5",  CreateDate = DateTime.Now   });
            context.CodeInit.Add(new Models.CodeInit { Code = "Agent",  Value = 6, Text = "代6",  CreateDate = DateTime.Now   });
            context.CodeInit.Add(new Models.CodeInit { Code = "Brand", Value = 0, Text = "M品牌", CreateDate = DateTime.Now });
            context.CodeInit.Add(new Models.CodeInit { Code = "Brand", Value = 1, Text = "S品牌", CreateDate = DateTime.Now });
            context.CodeInit.Add(new Models.CodeInit { Code = "Brand", Value = 2, Text = "J品牌", CreateDate = DateTime.Now });

            context.CodeInit.Add(new Models.CodeInit { Code = "AgentName", Value = 1, Text = "代理商", ParentCode = "0", CreateDate = DateTime.Now });
            context.CodeInit.Add(new Models.CodeInit { Code = "BrandName", Value = 2, Text = "品牌商", ParentCode = "0", CreateDate = DateTime.Now });

            context.CodeInit.Add(new Models.CodeInit { Code = "APriceControl", Value = 1, ParentCode= "AgentName", Text = "代价格管控表", CreateDate = DateTime.Now });
            context.CodeInit.Add(new Models.CodeInit { Code = "Stocklist", Value = 2, ParentCode = "AgentName", Text = "进货表", CreateDate = DateTime.Now });
            context.CodeInit.Add(new Models.CodeInit { Code = "InvestmentSchedule", ParentCode = "BrandName", Value = 3, Text = "投资表", CreateDate = DateTime.Now });
            context.CodeInit.Add(new Models.CodeInit { Code = "PPriceControl", ParentCode = "BrandName", Value = 4, Text = "品价格管控表", CreateDate = DateTime.Now });


            //context.BrandStrengthInit.Add(new BrandStrengthInit());
            //context.ChannelServiceInit.Add(new ChannelServiceInit());
            context.CurrentShareInit.Add(new CurrentShareInit());
            context.CurrentShareInit.Add(new CurrentShareInit() { G="第1阶段",D=100, E=90,F=0.9m, AR = 0, H = 0, Z = 0 });
            context.CurrentShareInit.Add(new CurrentShareInit() { G = "第2阶段", D = 80, E = 105, F = 1.05m, AR=0, H=0,Z=0 });
            context.CurrentShareInit.Add(new CurrentShareInit() { G = "第3阶段", D = 50, E = 98, F = 0.98m, AR = 0, H = 0, Z = 0 });
            //context.MarketPriceInit.Add(new MarketPriceInit());
            //context.MarketPromotionInit.Add(new MarketPromotionInit());
            //context.ProductInnovationInit.Add(new ProductInnovationInit());
            context.DataInits.Add(new DataInit());
            //代价格管控表
            context.StageAdd.Add(new StageAdd { Stage = "第1阶段", retail = "零售价", StageType = Common.agentInputStageType.价格管控表.ToString() });
            context.StageAdd.Add(new StageAdd { Stage = "第1阶段", retail = "零售系统供价", StageType = Common.agentInputStageType.价格管控表.ToString(), });
            context.StageAdd.Add(new StageAdd { Stage = "第2阶段", retail = "常规单品（RC1）指导零售价", StageType = Common.agentInputStageType.价格管控表.ToString(), });
            context.StageAdd.Add(new StageAdd { Stage = "第2阶段", retail = "常规单品（RC1）零售系统供价", StageType = Common.agentInputStageType.价格管控表.ToString(), });
            context.StageAdd.Add(new StageAdd { Stage = "第2阶段", retail = "新增单品（RC2）零售价", StageType = Common.agentInputStageType.价格管控表.ToString(), });
            context.StageAdd.Add(new StageAdd { Stage = "第2阶段", retail = "新增单品（RC2）零售系统供价", StageType = Common.agentInputStageType.价格管控表.ToString(), });

            context.StageAdd.Add(new StageAdd { Stage = "第3阶段", retail = "常规单品（RC1）零售价", StageType = Common.agentInputStageType.价格管控表.ToString(), });
            context.StageAdd.Add(new StageAdd { Stage = "第3阶段", retail = "常规单品（RC1）零售系统供价", StageType = Common.agentInputStageType.价格管控表.ToString(), });
            context.StageAdd.Add(new StageAdd { Stage = "第3阶段", retail = "新增单品（RC2）零售价", StageType = Common.agentInputStageType.价格管控表.ToString(), });
            context.StageAdd.Add(new StageAdd { Stage = "第3阶段", retail = "新增单品（RC2）零售系统供价", StageType = Common.agentInputStageType.价格管控表.ToString(), });
            context.StageAdd.Add(new StageAdd { Stage = "第3阶段", retail = "新增单品（RC3）零售价", StageType = Common.agentInputStageType.价格管控表.ToString(), });
            context.StageAdd.Add(new StageAdd { Stage = "第3阶段", retail = "新增单品（RC3）零售系统供价", StageType = Common.agentInputStageType.价格管控表.ToString(), });

            //进货表
            context.StageAdd.Add(new StageAdd { Stage = "第1阶段", retail = "进货", StageType = Common.agentInputStageType.进货表.ToString(), });
            context.StageAdd.Add(new StageAdd { Stage = "第2阶段", retail = "常规单品（RC1）进货", StageType = Common.agentInputStageType.进货表.ToString(), });
            context.StageAdd.Add(new StageAdd { Stage = "第2阶段", retail = "新增单品（RC2）进货", StageType = Common.agentInputStageType.进货表.ToString(), });
            context.StageAdd.Add(new StageAdd { Stage = "第3阶段", retail = "常规单品（RC1）进货", StageType = Common.agentInputStageType.进货表.ToString(), });
            context.StageAdd.Add(new StageAdd { Stage = "第3阶段", retail = "新增单品（RC2）进货 ", StageType = Common.agentInputStageType.进货表.ToString(), });
            context.StageAdd.Add(new StageAdd { Stage = "第3阶段", retail = "新增单品（RC3）进货", StageType = Common.agentInputStageType.进货表.ToString(), });

            //投资表
            context.StageAdd.Add(new StageAdd { Stage = "第1阶段", retail = "外观常规", StageType = Common.agentInputStageType.投资表.ToString(), });
            context.StageAdd.Add(new StageAdd { Stage = "第1阶段", retail = "功能新增", StageType = Common.agentInputStageType.投资表.ToString(), });
            context.StageAdd.Add(new StageAdd { Stage = "第1阶段", retail = "材料新增", StageType = Common.agentInputStageType.投资表.ToString(), });
            context.StageAdd.Add(new StageAdd { Stage = "第2阶段", retail = "外观常规1", StageType = Common.agentInputStageType.投资表.ToString(), });
            context.StageAdd.Add(new StageAdd { Stage = "第2阶段", retail = "外观常规2", StageType = Common.agentInputStageType.投资表.ToString(), });
            context.StageAdd.Add(new StageAdd { Stage = "第2阶段", retail = "功能新增1", StageType = Common.agentInputStageType.投资表.ToString(), });
            context.StageAdd.Add(new StageAdd { Stage = "第2阶段", retail = "功能新增2", StageType = Common.agentInputStageType.投资表.ToString(), });
            context.StageAdd.Add(new StageAdd { Stage = "第2阶段", retail = "材料新增1", StageType = Common.agentInputStageType.投资表.ToString(), });
            context.StageAdd.Add(new StageAdd { Stage = "第2阶段", retail = "材料新增2", StageType = Common.agentInputStageType.投资表.ToString(), });
            context.StageAdd.Add(new StageAdd { Stage = "第3阶段", retail = "外观常规1", StageType = Common.agentInputStageType.投资表.ToString(), });
            context.StageAdd.Add(new StageAdd { Stage = "第3阶段", retail = "外观常规2", StageType = Common.agentInputStageType.投资表.ToString(), });
            context.StageAdd.Add(new StageAdd { Stage = "第3阶段", retail = "外观常规3", StageType = Common.agentInputStageType.投资表.ToString(), });
            context.StageAdd.Add(new StageAdd { Stage = "第3阶段", retail = "功能新增1", StageType = Common.agentInputStageType.投资表.ToString(), });
            context.StageAdd.Add(new StageAdd { Stage = "第3阶段", retail = "功能新增2", StageType = Common.agentInputStageType.投资表.ToString(), });
            context.StageAdd.Add(new StageAdd { Stage = "第3阶段", retail = "功能新增3", StageType = Common.agentInputStageType.投资表.ToString(), });
            context.StageAdd.Add(new StageAdd { Stage = "第3阶段", retail = "材料新增1", StageType = Common.agentInputStageType.投资表.ToString(), });
            context.StageAdd.Add(new StageAdd { Stage = "第3阶段", retail = "材料新增2", StageType = Common.agentInputStageType.投资表.ToString(), });
            context.StageAdd.Add(new StageAdd { Stage = "第3阶段", retail = "材料新增3", StageType = Common.agentInputStageType.投资表.ToString(), });



            //品价格管控表
            context.StageAdd.Add(new StageAdd { Stage = "第1阶段", retail = "常规单品指导零售价", StageType = Common.agentInputStageType.品价格管控表.ToString(), });
            context.StageAdd.Add(new StageAdd { Stage = "第1阶段", retail = "常规单品零售系统供价", StageType = Common.agentInputStageType.品价格管控表.ToString(), });

            context.StageAdd.Add(new StageAdd { Stage = "第2阶段", retail = "常规单品（RC1）指导零售价", StageType = Common.agentInputStageType.品价格管控表.ToString(), });
            context.StageAdd.Add(new StageAdd { Stage = "第2阶段", retail = "常规单品（RC1）零售系统供价", StageType = Common.agentInputStageType.品价格管控表.ToString(), });
            context.StageAdd.Add(new StageAdd { Stage = "第2阶段", retail = "新增单品（RC2）成本价", StageType = Common.agentInputStageType.品价格管控表.ToString(), });
            context.StageAdd.Add(new StageAdd { Stage = "第2阶段", retail = "新增单品（RC2）出厂价", StageType = Common.agentInputStageType.品价格管控表.ToString(), });
            context.StageAdd.Add(new StageAdd { Stage = "第2阶段", retail = "新增单品（RC2）零售价", StageType = Common.agentInputStageType.品价格管控表.ToString(), });
            context.StageAdd.Add(new StageAdd { Stage = "第2阶段", retail = "新增单品（RC2）零售系统供价", StageType = Common.agentInputStageType.品价格管控表.ToString(), });


            context.StageAdd.Add(new StageAdd { Stage = "第3阶段", retail = "常规单品（RC1）指导零售价", StageType = Common.agentInputStageType.品价格管控表.ToString(), });
            context.StageAdd.Add(new StageAdd { Stage = "第3阶段", retail = "常规单品（RC1）零售系统供价", StageType = Common.agentInputStageType.品价格管控表.ToString(), });
            context.StageAdd.Add(new StageAdd { Stage = "第3阶段", retail = "新增单品（RC2）指导零售价", StageType = Common.agentInputStageType.品价格管控表.ToString(), });
            context.StageAdd.Add(new StageAdd { Stage = "第3阶段", retail = "新增单品（RC2）零售系统供价", StageType = Common.agentInputStageType.品价格管控表.ToString(), });
            context.StageAdd.Add(new StageAdd { Stage = "第3阶段", retail = "新增单品（RC3）成本价", StageType = Common.agentInputStageType.品价格管控表.ToString(), });
            context.StageAdd.Add(new StageAdd { Stage = "第3阶段", retail = "新增单品（RC3）出厂价", StageType = Common.agentInputStageType.品价格管控表.ToString(), });
            context.StageAdd.Add(new StageAdd { Stage = "第3阶段", retail = "新增单品（RC3）零售价", StageType = Common.agentInputStageType.品价格管控表.ToString(), });
            context.StageAdd.Add(new StageAdd { Stage = "第3阶段", retail = "新增单品（RC3）零售系统供价", StageType = Common.agentInputStageType.品价格管控表.ToString(), });
             

            base.Seed(context);
        }

        public void PerformInitialSetup(AppIdentityDbContext context)
        {
            //初始化
            ApplicationUserManager userMgr = new ApplicationUserManager(new UserStore<Models.ApplicationUser>(context));
            AppRoleManager roleMgr = new AppRoleManager(new RoleStore<AppRole>(context));
            string roleName = "Administrators";
            string roleName1 = "品牌商";
            string userName = "Admin";
            string password = "Password2017";
            string email = "amin@MSJ.com";
            if (!roleMgr.RoleExists(roleName))
            {
                roleMgr.Create(new AppRole(roleName));
            }
            if (!roleMgr.RoleExists(roleName1))
            {
                roleMgr.Create(new AppRole(roleName1));
            }
            Models.ApplicationUser user = userMgr.FindByName(userName);
            if (user == null)
            {
                userMgr.Create(new Models.ApplicationUser { UserName = userName, Email = email }, password);
                user = userMgr.FindByName(userName);
            }
            if (!userMgr.IsInRole(user.Id, roleName))
            {
                userMgr.AddToRole(user.Id, roleName);
            }


        }
    }
    public class MsjDbContext : DbContext
    {
        public MsjDbContext() : base("ConnectionString") { }

        public DbSet<AgentInput> AgentInputs { get; set; }
        public DbSet<BrandsInput> BrandsInputs { get; set; }
    }
}