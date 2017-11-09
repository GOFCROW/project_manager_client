using System;
using System.Collections.Generic;
using ProjectManager.Droid.code.entity;
using ProjectManager.Droid.code.utils;
using Refit;

namespace ProjectManager.Droid.code.services
{
    public class Services
    {
        
        WebServiceInterface serviceApi = RestService.For<WebServiceInterface>(new System.Net.Http.HttpClient
        {
          BaseAddress = new Uri("http://200.87.54.2:8899"),
          Timeout = TimeSpan.FromSeconds(60)
        });


        public List<Developer> GetListDevelopers()
        {
            Serializer serializer = new Serializer("developers");
            try
            {
                String xmlDevelopers = serviceApi.GetListDevelopers().Result;
                return serializer.Deserialize<List<Developer>>(xmlDevelopers); 
            }
            catch
            {
                return null;   
            }
           
        }

        public List<Project> GetListProjects()
        {
            Serializer serializer = new Serializer("projects");
            try
            {
                String xmlProjects = serviceApi.GetListProjects().Result;
                return serializer.Deserialize<List<Project>>(xmlProjects);
            }
            catch
            {
                return null;
            }

        }

        public String PostSaveDeveloper(Developer developer)
        {
            Serializer serializer = new Serializer("developers");
            try
            {   
                String xmlDeveloper = serializer.Serialize(developer);
                String response = serviceApi.PostSaveDeveloper(xmlDeveloper).Result;
                return response;   
            }
            catch
            {
                return null;
            }

        }

        public String PostSaveProject(Project project)
        {
            Serializer serializer = new Serializer("projects");
            try
            {
                String xmlDeveloper = serializer.Serialize(project);
                String response = serviceApi.PostSaveProject(xmlDeveloper).Result;
                return response;  
            }
            catch
            {
                return null;
            }

        }
    }
}
