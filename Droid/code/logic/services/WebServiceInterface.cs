using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ProjectManager.Droid.code.entity;
using Refit;

namespace ProjectManager.Droid.code.services
{
    public interface WebServiceInterface
    {
        [Get("/developers")]
        Task<String> GetListDevelopers();

        [Get("/projects")]
        Task<String> GetListProjects();

        [Headers("Content-Type: text/plain; charset=utf-8")]
        [Post("/developers/update")]
        Task<String> PostSaveDeveloper([Body(BodySerializationMethod.UrlEncoded)] String xmlDeveloper);

        [Headers("Content-Type: text/plain; charset=utf-8")]
        [Post("/projects/update")]
        Task<String> PostSaveProject([Body(BodySerializationMethod.UrlEncoded)] String xmlProject);

    }
}
