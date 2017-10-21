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

    }
}
