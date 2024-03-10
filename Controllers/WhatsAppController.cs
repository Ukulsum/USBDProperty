using Microsoft.AspNetCore.Mvc;
using WhatsAppApi;

namespace USBDProperty.Controllers
{
    public class WhatsAppController : Controller
    {
        public IActionResult Index()
        {
            string m = "disconnect";
            try
            {
                WhatsApp ap = new WhatsApp("+8801778849326", "SHA778849326#", "powersoftit", false, false);
                ap.OnConnectSuccess += () =>
                {
                    m = "connected";
                    ap.OnLoginSuccess += (p, d) =>
                    {
                        ap.SendMessage("+8801913168904", "Hi");
                        m = "message sent successfully";
                    };
                    ap.OnLoginFailed += (data) =>
                    {
                        m = "Failed";
                    };
                    ap.Login();
                };
            }
            catch (Exception ex)
            {

            }
            ViewBag.msg = m;
            return View();
        }
    }
}
