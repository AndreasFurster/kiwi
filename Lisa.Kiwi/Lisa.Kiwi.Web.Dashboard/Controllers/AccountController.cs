﻿using System.Threading.Tasks;
using System.Web.Mvc;
using Lisa.Kiwi.WebApi.Access;
using Resources;

namespace Lisa.Kiwi.Web.Dashboard.Controllers
{
	public class AccountController : Controller
	{
		// GET: Account
		[HttpGet]
		public ActionResult Login()
		{
			var sessionTimeOut = Session.Timeout = 60;

			if (Session["user"] == null || sessionTimeOut == 0)
			{
				return View();
			}
			return RedirectToAction("Index", "Report");
		}

		[HttpPost]
        [ValidateInput(false)]
		public async Task<ActionResult> Login(string username, string password)
		{

			if (!ModelState.IsValid)
			{
				return View();
			}

			var authenticationClient = new AuthenticationProxy(ConfigHelper.GetAuthUri(), ConfigHelper.GetUserControllerUri());
			var authResponse = await authenticationClient.Login(username, password);

			if (authResponse.Status != LoginStatus.Success)
			{
				ModelState.AddModelError("password", DisplayNames.AccountLoginInvalid);
				return View();
			}

			Session["token"] = authResponse.Token;
			Session["token_type"] = authResponse.TokenType;
			Session["token_aliveTime"] = authResponse.TokenExpiresIn;
			Session["user"] = username;

			Session["is_admin"] = await authenticationClient.GetIsAdmin(authResponse.TokenType, authResponse.Token);

			return RedirectToAction("Index", "Report");
		}

		public ActionResult Logout()
		{
			if (Session.Count > 0)
			{
				Session.RemoveAll();
			}

			return RedirectToAction("Login");
		}
	}
}