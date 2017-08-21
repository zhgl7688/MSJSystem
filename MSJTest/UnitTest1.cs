using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebMVC.Common;
using System.Collections.Generic;
using System.Linq;
using WebMVC.Models;
using WebMVC.Infrastructure;

namespace MSJTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            // Assert.AreEqual("第一阶段", Stage.第一阶段.ToString());
            //  Assert.AreEqual("第一阶段",Enum.GetName(typeof(Stage), Stage.第一阶段));
            //var result =new List<test>{
            //    new test { Id=(int)Stage.起始阶段, name = Stage.起始阶段.ToString() },
            //    new test {Id=(int)Stage.第三阶段, name = Stage.第三阶段.ToString() },
            //    new test {Id=(int)Stage.第二阶段, name = Stage.第二阶段.ToString() },
            //    new test {Id=(int)Stage.第一阶段, name = Stage.第一阶段.ToString() },


            //};
            //List<test> resultMax = result.OrderByDescending(s=>s.Id).Take(1).ToList();
            //Assert.AreEqual(Stage.第三阶段.ToString(), resultMax[0].name);
            //var ss = 0.3334m;
            //var tt = string.Format("{0:P0}", ss);
            //Assert.AreEqual("33%", tt);
            //var sss = 33.33m;
            //var ttt = string.Format("{0:F0}", sss);
            //Assert.AreEqual("33%", ttt);

            var ss = 100.4m;
            var kk = 4;
            var tt = 4m;
            Assert.AreEqual(ss / kk, ss / tt);
        }
        [TestMethod]
        public void DBadd()
        {
            MsjDbContext dbCotext = new MsjDbContext();
             
            var tables = new WebMVC.BLL.ExampleData();
            var ss = tables.brands;
            foreach (var item in ss)
            {
                dbCotext.BrandsInputs.Add(item);
            }
            var sss = tables.agentInputs;
            foreach (var item in sss)
            {
              //  if (item.Stage==Stage.第三阶段.ToString())
                dbCotext.AgentInputs.Add(item);
            }
            dbCotext.SaveChanges();
        }
        [TestMethod]
        public void DBUseradd()
        {

           
            AppIdentityDbContext dbCotext = new AppIdentityDbContext();

            User user = new User()
            {
                UserName = "lili",
                Password = "111111"
            };
          //  dbCotext.Users.Add(user);

          //  dbCotext.SaveChanges();
            Assert.AreEqual(2, user.UserId);
        }

    }
    class test
    {
        public int Id { get; set; }
        public string name { get; set; }

    }
}
