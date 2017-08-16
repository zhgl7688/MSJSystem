﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebMVC.Common;
using System.Collections.Generic;
using System.Linq;
using WebMVC.Models;

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
            var result =new List<test>{
                new test { Id=(int)Stage.起始阶段, name = Stage.起始阶段.ToString() },
                new test {Id=(int)Stage.第三阶段, name = Stage.第三阶段.ToString() },
                new test {Id=(int)Stage.第二阶段, name = Stage.第二阶段.ToString() },
                new test {Id=(int)Stage.第一阶段, name = Stage.第一阶段.ToString() },


            };
            List<test> resultMax = result.OrderByDescending(s=>s.Id).Take(1).ToList();
            Assert.AreEqual(Stage.第三阶段.ToString(), resultMax[0].name);
        }
        [TestMethod]
        public void DBadd()
        {
            MSJDBContext dbCotext = new MSJDBContext();
             
            var tables = new WebMVC.BLL.InvertmentTable1();
            var ss = tables.getBrandsInputs();
            foreach (var item in ss)
            {
                dbCotext.BrandsInputs.Add(item);
            }
            dbCotext.SaveChanges();
        }

        
    }
    class test
    {
        public int Id { get; set; }
        public string name { get; set; }

    }
}
