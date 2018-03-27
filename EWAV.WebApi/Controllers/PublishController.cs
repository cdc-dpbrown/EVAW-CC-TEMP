using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using CDC.ISB.EIDEV.DTO;
using CDC.ISB.EIDEV.Security;
using CDC.ISB.EIDEV.Web.Services;
using Newtonsoft.Json.Linq;
using CDC.ISB.EIDEV.Web.Services.CanvasDomainService;
using System.Net.Http.Headers;
using EWAV;



namespace CDC.ISB.EIDEV.WebApi.Controllers
{
    public class PublishController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }




        // POST api/<controller>
        public HttpResponseMessage Post([FromBody] JObject value)
        {
            UserDomainService UserDomainService = new CDC.ISB.EIDEV.Web.Services.UserDomainService();
            CanvasDomainService CanvasDomainService = new CDC.ISB.EIDEV.Web.Services.CanvasDomainService.CanvasDomainService();
            ControllerCommon Common = new Controllers.ControllerCommon();
            DatatableBag dtb = null;
            UserDTO possibleUser = new UserDTO();
            possibleUser.UserName = value["id"].ToString();

            var pwd = value["password"].ToString();
            string KeyForUserPasswordSalt = System.Configuration.ConfigurationManager.AppSettings["KeyForUserPasswordSalt"];
            CDC.ISB.EIDEV.PasswordHasher ph = new CDC.ISB.EIDEV.PasswordHasher(KeyForUserPasswordSalt);
            string salt = ph.CreateSalt(possibleUser.UserName);
            possibleUser.PasswordHash = ph.HashPassword(salt, pwd);

            UserDTO returnedUser = UserDomainService.GetUserForAuthentication(possibleUser);

            if (returnedUser.UserID != -1)
            {
                UserDTO LoadedUser = UserDomainService.LoadUser(returnedUser.UserName);
                dtb = CanvasDomainService.LoadCanvasListForUser(LoadedUser.UserID);
            }

            List<CanvasDto> CanvasList = new List<CanvasDto>();

            for (int i = 0; i < dtb.RecordList.Count; i++)
            {
                CanvasList.Add(
                    new CanvasDto()
                    {
                        CanvasId = Convert.ToInt32(Common.GetValueAtRow(dtb, "CanvasID", dtb.RecordList[i])),
                        CanvasName = Common.GetValueAtRow(dtb, "CanvasName", dtb.RecordList[i]),
                        UserId = Convert.ToInt32(Common.GetValueAtRow(dtb, "UserID", dtb.RecordList[i])),
                        CanvasDescription = Common.GetValueAtRow(dtb, "CanvasDescription", dtb.RecordList[i]),
                        CreatedDate = Convert.ToDateTime(Common.GetValueAtRow(dtb, "CreatedDate", dtb.RecordList[i])),
                        ModifiedDate = Convert.ToDateTime(Common.GetValueAtRow(dtb, "ModifiedDate", dtb.RecordList[i])),
                        DatasourceID = Convert.ToInt32(Common.GetValueAtRow(dtb, "DatasourceID", dtb.RecordList[i])),
                        Status = Common.GetValueAtRow(dtb, "Status", dtb.RecordList[i]),
                        Datasource = Common.GetValueAtRow(dtb, "DatasourceName", dtb.RecordList[i])
                        //XmlData = new System.Xml.Linq.XElement()
                    });
            }

            HttpResponseMessage ReturnedObj = new HttpResponseMessage()
            {
                Content = new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(CanvasList))
            };


            ReturnedObj.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");


            return ReturnedObj;
        }


        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}