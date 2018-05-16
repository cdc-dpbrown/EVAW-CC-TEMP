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
using System.Net.Http.Headers;
using CDC.ISB.EIDEV;
using CDC.ISB.EIDEV.Web.Services.CanvasDomainService;

namespace CDC.ISB.EIDEV.WebApi.Controllers
{
    public class LogInController : ApiController
    {
        // GET api/<controller>
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        // GET api/<controller>/5
        /// <summary>
        /// Method called to validate user against a datasourceid.
        /// </summary>
        /// <param name="bigObject"></param>
        /// <returns></returns>
        public bool Get(JObject bigObject)
        {
            UserDomainService UserDomainService = new UserDomainService();
            AdminDatasourcesDomainService AdminDatasourcesDomainService = new AdminDatasourcesDomainService();
            CanvasDomainService CanvasDomainService = new CanvasDomainService();
            ControllerCommon Common = new ControllerCommon();
            DatatableBag dtb = null;
            UserDTO possibleUser = new UserDTO();
            possibleUser.UserName = Request.GetQueryNameValuePairs().Single(x => x.Key == "userid").Value;

            UserDTO returnedUser = UserDomainService.GetUserForAuthentication(possibleUser);
            UserDTO LoadedUser = null;

            if (returnedUser.UserID != -1)
            {
                LoadedUser = UserDomainService.LoadUser(returnedUser.UserName);
            }

            dtb = CanvasDomainService.ReadCanvasListForLite(Request.GetQueryNameValuePairs().Single(x => x.Key == "datasourceid").Value, LoadedUser.UserID);

            List<CanvasDto> CanvasList = new List<CanvasDto>();
            Guid TempCanvasGuid;

            for (int i = 0; i < dtb.RecordList.Count; i++)
            {
                Guid.TryParse(Common.GetValueAtRow(dtb, "CanvasGUID", dtb.RecordList[i]), out TempCanvasGuid);

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
                        Datasource = Common.GetValueAtRow(dtb, "DatasourceName", dtb.RecordList[i]),
                        CanvasGUID = TempCanvasGuid
                    }
                );
            }

            if (CanvasList.Count > 0)
            {
                return true;
            }

            return false;
        }

        [AcceptVerbs("OPTIONS")]
        public HttpResponseMessage Options()
        {
            var resp = new HttpResponseMessage(HttpStatusCode.OK);
            resp.Headers.Add("Access-Control-Allow-Origin", "*");
            resp.Headers.Add("Access-Control-Allow-Methods", "GET,POST");
            resp.Headers.Add("Access-Control-Allow-Headers", "Content-Type");

            return resp;
        }

        // POST api/<controller>    
        //  [EnableCors(origins: "*", headers: "*", methods: "OPTIONS")]
        public HttpResponseMessage Post([FromBody] JObject value)
        {
            UserDomainService UserDomainService = new UserDomainService();
            CanvasDomainService CanvasDomainService = new CanvasDomainService();
            ControllerCommon Common = new Controllers.ControllerCommon();
            DatatableBag dtb = null;
            UserDTO possibleUser = new UserDTO();
            possibleUser.UserName = value["id"].ToString();

            var pwd = value["password"].ToString();

            var canvasid = new Guid(value["canvasid"].ToString());

            string KeyForUserPasswordSalt = System.Configuration.ConfigurationManager.AppSettings["KeyForUserPasswordSalt"];
            PasswordHasher ph = new PasswordHasher(KeyForUserPasswordSalt);
            string salt = ph.CreateSalt(possibleUser.UserName);
            possibleUser.PasswordHash = ph.HashPassword(salt, pwd);

            UserDTO returnedUser = UserDomainService.GetUserForAuthentication(possibleUser);
            UserDTO LoadedUser = null;

            if (returnedUser.UserName != null)
            {
                LoadedUser = UserDomainService.LoadUser(returnedUser.UserName);
                dtb = CanvasDomainService.LoadCanvasListForUser(LoadedUser.UserID);
            }
            else
            {
                return new HttpResponseMessage()
                {
                    Content = new StringContent("not-authenticated")
                };
            }

            List<CanvasDto> CanvasList = new List<CanvasDto>();

            for (int i = 0; i < dtb.RecordList.Count; i++)
            {
                CanvasList.Add(
                    new CanvasDto()
                    {
                        CanvasId = Convert.ToInt32(Common.GetValueAtRow(dtb, "CanvasID", dtb.RecordList[i])),
                        CanvasGUID = new Guid(Common.GetValueAtRow(dtb, "CanvasGUID", dtb.RecordList[i])),
                        CanvasName = Common.GetValueAtRow(dtb, "CanvasName", dtb.RecordList[i]),
                        UserId = Convert.ToInt32(Common.GetValueAtRow(dtb, "UserID", dtb.RecordList[i])),
                        CanvasDescription = Common.GetValueAtRow(dtb, "CanvasDescription", dtb.RecordList[i]),
                        CreatedDate = Convert.ToDateTime(Common.GetValueAtRow(dtb, "CreatedDate", dtb.RecordList[i])),
                        ModifiedDate = Convert.ToDateTime(Common.GetValueAtRow(dtb, "ModifiedDate", dtb.RecordList[i])),
                        DatasourceID = Convert.ToInt32(Common.GetValueAtRow(dtb, "DatasourceID", dtb.RecordList[i])),
                        Status = Common.GetValueAtRow(dtb, "Status", dtb.RecordList[i]),
                        Datasource = Common.GetValueAtRow(dtb, "DatasourceName", dtb.RecordList[i])
                    });
            }

            var isAuthorized = CanvasList.Any(canvas => canvas.CanvasGUID == canvasid && canvas.UserId == LoadedUser.UserID);

            if (!isAuthorized)
            {
                returnedUser = new UserDTO();
                return new HttpResponseMessage()
                {
                    Content = new StringContent("not-authorized")
                };
            }

            HttpResponseMessage ReturnedObj = new HttpResponseMessage()
            {
                Content = new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(returnedUser))
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