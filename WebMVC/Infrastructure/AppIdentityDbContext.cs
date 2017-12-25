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
            context.CodeInit.Add(new CodeInit
            {
                Code = "Stage",
                Value = 2,
                Text = "第2阶段",
                CreateDate = DateTime.Now
            });
            context.CodeInit.Add(new Models.CodeInit
            {
                Code = "Agent",
                Value = 2,
                Text = "代2",
                CreateDate = DateTime.Now
            });
            context.BrandStrengthInit.Add(new BrandStrengthInit());
            context.ChannelServiceInit.Add(new ChannelServiceInit());
            context.CurrentShareInit.Add(new CurrentShareInit());
            context.MarketPriceInit.Add(new MarketPriceInit());
            context.MarketPromotionInit.Add(new MarketPromotionInit());
            context.ProductInnovationInit.Add(new ProductInnovationInit());
            context.StageAdd.Add(new StageAdd
            {
                Stage = "第1阶段",
                StageType = Common.agentInputStageType.代价格管控表.ToString(),
                retail = "零售价",
            });
            context.StageAdd.Add(new StageAdd
            {
                Stage = "第1阶段",
                StageType = Common.agentInputStageType.代价格管控表.ToString(),
                retail = "零售系统供价",
            });
            context.StageAdd.Add(new StageAdd
            {
                Stage = "第2阶段",
                StageType = Common.agentInputStageType.代价格管控表.ToString(),
                retail = "零售价1",
            });
            context.StageAdd.Add(new StageAdd
            {
                Stage = "第2阶段",
                StageType = Common.agentInputStageType.代价格管控表.ToString(),
                retail = "零售系统供价1",
            });
            context.StageAdd.Add(new StageAdd
            {
                Stage = "第2阶段",
                StageType = Common.agentInputStageType.代价格管控表.ToString(),
                retail = "零售价2",
            });
            context.StageAdd.Add(new StageAdd
            {
                Stage = "第2阶段",
                StageType = Common.agentInputStageType.代价格管控表.ToString(),
                retail = "零售系统供价2",
            });
            context.StageAdd.Add(new StageAdd
            {
                Stage = "第1阶段",
                StageType = Common.agentInputStageType.进货表.ToString(),
                retail = "进货",
            });
            context.StageAdd.Add(new StageAdd
            {
                Stage = "第2阶段",
                StageType = Common.agentInputStageType.进货表.ToString(),
                retail = "进货1",
            });
            context.StageAdd.Add(new StageAdd
            {
                Stage = "第2阶段",
                StageType = Common.agentInputStageType.进货表.ToString(),
                retail = "进货2",
            });
            context.StageAdd.Add(new StageAdd
            {
                Stage = "第1阶段",
                StageType = Common.agentInputStageType.投资表.ToString(),
                retail = "外观常规",
            });
            context.StageAdd.Add(new StageAdd
            {
                Stage = "第1阶段",
                StageType = Common.agentInputStageType.投资表.ToString(),
                retail = "功能新增",
            });
            context.StageAdd.Add(new StageAdd
            {
                Stage = "第1阶段",
                StageType = Common.agentInputStageType.投资表.ToString(),
                retail = "材料新增",
            });
            context.StageAdd.Add(new StageAdd
            {
                Stage = "第2阶段",
                StageType = Common.agentInputStageType.投资表.ToString(),
                retail = "外观常规1",
            });
            context.StageAdd.Add(new StageAdd
            {
                Stage = "第2阶段",
                StageType = Common.agentInputStageType.投资表.ToString(),
                retail = "外观常规2",
            });
            context.StageAdd.Add(new StageAdd
            {
                Stage = "第2阶段",
                StageType = Common.agentInputStageType.投资表.ToString(),
                retail = "功能新增1",
            });
            context.StageAdd.Add(new StageAdd
            {
                Stage = "第2阶段",
                StageType = Common.agentInputStageType.投资表.ToString(),
                retail = "功能新增2",
            });
            context.StageAdd.Add(new StageAdd
            {
                Stage = "第2阶段",
                StageType = Common.agentInputStageType.投资表.ToString(),
                retail = "材料新增1",
            });
            context.StageAdd.Add(new StageAdd
            {
                Stage = "第2阶段",
                StageType = Common.agentInputStageType.投资表.ToString(),
                retail = "材料新增2",
            });
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