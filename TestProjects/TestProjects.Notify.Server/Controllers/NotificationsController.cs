using FirebaseAdmin;
using FirebaseAdmin.Messaging;
using Google.Apis.Auth.OAuth2;
using Microsoft.AspNetCore.Mvc;

namespace TestProjects.Notify.Server.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class NotificationsController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> SendPush()
        {
            FirebaseApp.Create(new AppOptions()
            {
                Credential = GoogleCredential.FromFile("path/to/your/firebase-config.json")
            });

            var messaging = FirebaseMessaging.DefaultInstance;

            var message = new Message()
            {
                Token = "android_token",
                Notification = new Notification
                {
                    Title = "Заголовок повідомлення",
                    Body = "Тіло повідомлення",
                    ImageUrl = "some_url"
                },
                Data = new Dictionary<string, string>
                {
                    { "UserId","1" },
                    { "SubscriptionId","3o4j9f0394fk340f934f0mfwevcwsfk" }
                }
            };

            var result = await messaging.SendAsync(message);

            return Ok();
        }
    }
}
