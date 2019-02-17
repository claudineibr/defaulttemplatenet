using Newtonsoft.Json;
using ProjetoPadrao.CrossCutting.Commons.Util;
using ProjetoPadrao.Domain.IRepository;
using System;
using System.Collections.Generic;
using System.Net;

namespace ProjetoPadrao.Repository.Repository
{
    public class MeuServicoRepository : BaseHttpResponseMessage, IMeuServicoRepository
    {


        public string[] GetServicos()
        {
            return new string[] { "value1", "value2" };
        }

        public IList<object> PostService()
        {
            var response = this.PostAsync("", "");

            if (response.StatusCode == HttpStatusCode.InternalServerError)
                throw new Exception("500");

            if (!response.IsSuccessStatusCode)
                throw new Exception("NOK");

            var json = response.Content.ReadAsStringAsync().Result;
            return JsonConvert.DeserializeObject<IList<object>>(json);
        }
    }
}
