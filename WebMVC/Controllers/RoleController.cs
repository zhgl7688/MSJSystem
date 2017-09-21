﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using WebMVC.Infrastructure;
using WebMVC.Models;

namespace WebMVC.Controllers
{
    [Authorize(Roles = "Administrators")]
    public class RoleController : Controller
    {
        // GET: Role
              public ActionResult Index()
            {
                return View(RoleManager.Roles.ToList());
            }
            public ActionResult Create()
            {
                return View();
            }
            /// <summary>
            /// 编辑操作，获取所有隶属于此Role的成员和非隶属于此Role的成员
            /// </summary>
            /// <param name="id"></param>
            /// <returns></returns>
            public async Task<ActionResult> Edit(string id)
            {
                AppRole role = await RoleManager.FindByIdAsync(id);
                string[] memberIDs = role.Users.Select(x => x.UserId).ToArray();
            IEnumerable<Models.ApplicationUser> members = UserManager.Users.Where(x => memberIDs.Any(y => y == x.Id));
            IEnumerable<Models.ApplicationUser> nonMembers = UserManager.Users.Except(members);
                return View(new RoleEditModel()
                {
                    Role = role,
                    Members = members,
                    NonMembers = nonMembers
                });
            }
            [HttpPost]
            public async Task<ActionResult> Edit(RoleModificationModel model)
            {
                IdentityResult result;
                if (ModelState.IsValid)
                {
                    foreach (string userId in model.IDsToAdd ?? new string[] { })
                    {
                        result = await UserManager.AddToRoleAsync(userId, model.RoleName);
                        if (!result.Succeeded)
                        {
                            return View("Error", result.Errors);
                        }
                    }
                    foreach (var userId in model.IDsToDelete ?? new string[] { })
                    {
                        //演示用，正式部署时去掉
                        var currentUser = await UserManager.FindByIdAsync(userId);
                        if (currentUser.UserName == "Admin" && model.RoleName == "Administrator")
                        {
                            return View("Error", new string[] { "请勿修改Admin的角色！" });
                        }

                        result = await UserManager.RemoveFromRoleAsync(userId, model.RoleName);
                        if (!result.Succeeded)
                        {
                            return View("Error", result.Errors);
                        }
                    }
                    return RedirectToAction("Index");
                }
                return View("Error", new string[] { "无法找到此角色" });
            }

            [HttpPost]
            public async Task<ActionResult> Create(string name)
            {
                if (ModelState.IsValid)
                {
                    IdentityResult result = await RoleManager.CreateAsync(new AppRole(name));
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        AddErrorsFromResult(result);
                    }
                }
                return View(name);
            }

            [HttpPost]
            public async Task<ActionResult> Delete(string id)
            {
                AppRole role = await RoleManager.FindByIdAsync(id);
                if (role != null)
                {
                    if (role.Name == "Administrator")
                    {
                        return View("Error", new string[] { "请勿删除该管理员角色！" });
                    }

                    IdentityResult result = await RoleManager.DeleteAsync(role);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        return View("Error", result.Errors);
                    }
                }
                else
                {
                    return View("Error", new string[] { "无法找到该Role" });
                }
            }

            private void AddErrorsFromResult(IdentityResult result)
            {
                foreach (string error in result.Errors)
                {
                    ModelState.AddModelError("", error);
                }
            }
            /// <summary>
            /// 从OWIN环境字典中获取AppUserManager对象
            /// </summary>
            private ApplicationUserManager UserManager
            {
                get
                {
                    return HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
                }
            }
            /// <summary>
            /// 从OWIN环境字典中获取AppRoleManager对象
            /// </summary>
            private AppRoleManager RoleManager
            {
                get
                {
                    return HttpContext.GetOwinContext().GetUserManager<AppRoleManager>();
                }
            }
        }
    }