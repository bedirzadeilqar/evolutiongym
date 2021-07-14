using evolution_gym.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace evolution_gym.Controllers
{
    public class LoginController : Controller
    {
        public static string CreateMD5(string input)
        {
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("X2"));
                }
                return sb.ToString();
            }
        }
       [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        public ActionResult SignIn(string IstifadeciMail, string IstifadeciParol)
        {
            var c = CreateMD5("ilqar" + IstifadeciParol + "ilqar");
            DataTable dt = Sql.Exec($"select * from Admin where IstifadeciMail=N'{IstifadeciMail}' and IstifadeciParol=N'{c}'");
            if (dt.Rows.Count == 0 || IstifadeciMail == null || IstifadeciParol == null)
            {
                TempData["Message"] = "Istifadəçi mailiniz və ya parolunuz yanlışdır.Zəhmət olmasa yenidən cəhd edin!";
                return RedirectToAction("Login");
            }
            else
            {
                TempData["Message"] = "Əməliyyat uğurla həyata keçirildi!";
                HttpCookie cookie = new HttpCookie("Admin");
                cookie.Expires = DateTime.Now.AddDays(1d);
                cookie.Values.Add("IstifadeciId", dt.Rows[0][0].ToString());
                cookie.Values.Add("IstifadeciName", dt.Rows[0][5].ToString());
                Response.Cookies.Add(cookie);
                return RedirectToAction("Index","Admin");
            }
        }


        



    }
}