using System;
using System.Collections.Generic;
using Android.Content;
using Java.Lang;
using ProjectManager.Droid.code.entity;
using ProjectManager.Droid.code.logic.listeners;
using ProjectManager.Droid.code.services;

namespace ProjectManager.Droid.code.logic.tasks
{
    public class ListProjectsTask : AsyncTaskGOF
    {
        public ListProjectsTask(Context context, CompleteAsyncTask completeAsyncTask) : base(context,completeAsyncTask)
        {

        }


        protected override void OnPreExecute()
        {
            base.OnPreExecute();
        }

        protected override object RunInBackground(params object[] @params)
        {
            List<Project> lstProjects = null;
            try
            {
                Services services = new Services();
                lstProjects = services.GetListProjects();
            }
            catch (Throwable throwable)
            {
                lstProjects = null;
            }
            return lstProjects;
        }


        protected override void OnPostExecute(object result)
        {
            if (result != null)
            {
                base.completeAsyncTask.OnResponse(result); ;
            }
            else
            {
                base.completeAsyncTask.OnError("Error, no se pudieron obtener los proyectos");
            }
        }

    }
}
