using System;
using System.Collections.Generic;
using ProjectManager.Droid.code.entity;
using ProjectManager.Droid.code.utils;
using Refit;

namespace ProjectManager.Droid.code.services
{
    public class Services
    {
        WebServiceInterface serviceApi = RestService.For<WebServiceInterface>("http://200.87.54.2:8899");
        Serializer serializer = new Serializer();
        public Services()
        {
            
        }

        public List<Developer> GetListDevelopers()
        {
            String xmlDevelopers = serviceApi.GetListDevelopers().Result;
            return serializer.Deserialize<List<Developer>>(xmlDevelopers);
        }
    }
}
