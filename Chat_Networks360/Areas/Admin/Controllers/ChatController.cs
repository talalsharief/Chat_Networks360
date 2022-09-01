using Chat_Networks360.Areas.HelpPage.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using Telnyx;

namespace Chat_Networks360.Areas.HelpPage.Controllers
{
    public class ChatController : ApiController
    {
        
        
        

        private static string telnyxNumber = "+18327404444";
        private static string destinationNumber = "+18328218486";
        private MesagingContext db = new MesagingContext();
        

        [Route("api/receive/sms")]
        [HttpPost]
        public IHttpActionResult ReceiveSms(object jsonObject)
        {
            string result = "";
                try
                {
                if (jsonObject != null)
                {

                    Receiving.Webhook webhook = JsonConvert.DeserializeObject<Receiving.Webhook>(jsonObject.ToString());
                    if (webhook.data.event_type != "message.finalized" && webhook.data.event_type != "message.sent")
                    {
                        Conversation con = new Conversation
                        {
                            Inbound_Number = webhook.data.payload.from.phone_number,
                            OutBound_Number = telnyxNumber,
                            Message = webhook.data.payload.text,
                            Received_At = webhook.data.payload.received_at

                        };
                        db.Conversation.Add(con);
                        db.SaveChanges();
                    }
                    
                }     
                   
                }
                catch (Exception ex)
                {
                    

                    return Ok(result);
                }
           
            return Ok("Success");
        }

        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [Route("api/send/sms/{Text}/{InboundNumber}")]
        [HttpPost]
        public async Task<IHttpActionResult> SendSms(string Text, string InboundNumber)
        {
             
                string TELNYX_API_KEY = Environment.GetEnvironmentVariable("KEY0182134E628E1E508085405C846FE23A_aFyzGajvxKJ73YTSeYEvT5");
                TelnyxConfiguration.SetApiKey("KEY0182134E628E1E508085405C846FE23A_aFyzGajvxKJ73YTSeYEvT5");

                
                    MessagingSenderIdService service = new MessagingSenderIdService();
                    string plus = "+";
                    string WholeNumber = plus + InboundNumber;
                    WholeNumber = WholeNumber.Replace(" ", String.Empty);
                    NewMessagingSenderId options = new NewMessagingSenderId
                    {
                        From = telnyxNumber,
                        To = WholeNumber,
                        Text = Text
                    };
                    try
                    {

                        MessagingSenderId messageResponse = await service.CreateAsync(options);
                        Conversation con = new Conversation
                        {
                            OutBound_Number = WholeNumber,
                            Inbound_Number = telnyxNumber,
                            Message = Text,
                            Created_At = DateTime.Now.ToString()

                        };
                        db.Conversation.Add(con);
                        db.SaveChanges();
                        Console.WriteLine(messageResponse.Id);

                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                
               
            
           
            return Ok("ok");
            
        }
    }
}
