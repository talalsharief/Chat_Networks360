using Chat_Networks360.Areas.HelpPage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Chat_Networks360.Areas.HelpPage.Controllers
{
    
    public class MessageAppController : ApiController
    {

        MesagingContext db = new MesagingContext();

        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [Route("api/GetAllSms")]
        [HttpGet]
        public IHttpActionResult ReceiveSmsApp()
        {
            string result = "";
            List<Conversation> conversation = new List<Conversation>();
            try
            {
               conversation = db.Conversation.ToList();
                var group = conversation.Where(x => x.Inbound_Number != null && x.Inbound_Number != "+18327404444").ToList();
                var InboundNumber = group.Select(x => x.Inbound_Number).Distinct().ToList();

                return Json(InboundNumber);
            }
            catch (Exception ex)
            {


                return Json(conversation);
            }

            
        }

        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [Route("api/Conversation")]
        [HttpGet]
        public IHttpActionResult ReceiveConversationApp(string InboundNumber)
        {
            string plus = "+";
            string WholeNumber = plus + InboundNumber;
            WholeNumber = WholeNumber.Replace(" ", String.Empty);
            List<Conversation> conversation = new List<Conversation>();
            try
            {
                conversation = db.Conversation.ToList();
                var group = conversation.Where(x => x.Inbound_Number == WholeNumber || x.OutBound_Number == WholeNumber).ToList();

                return Json(group);
            }
            catch (Exception ex)
            {


                return Json(conversation);
            }


        }
    }
}
