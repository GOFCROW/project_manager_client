using System;
using System.Collections.Generic;
using Android.Content;
using Android.OS;
using Java.Lang;
using ProjectManager.Droid.code.entity;
using ProjectManager.Droid.code.logic.listeners;
using ProjectManager.Droid.code.services;

namespace ProjectManager.Droid.code.logic.tasks
{
    public class ListDevelopersTask : AsyncTaskGOF
    {
        public ListDevelopersTask(Context context, CompleteAsyncTask completeAsyncTask) : base(context,completeAsyncTask)
        {
           
        }


        protected override void OnPreExecute()
        {
            base.OnPreExecute();
        }

        protected override object RunInBackground(params object[] @params)
        {
            List<Developer> lstProjects = null;
            try
            {
                Services services = new Services();
                lstProjects = services.GetListDevelopers();
            }
            catch(Throwable throwable)
            {
                lstProjects = null;    
            }
            return lstProjects;
        }


        protected override void OnPostExecute(object result)
        {
            if(result != null)
            {
                base.completeAsyncTask.OnResponse(result); ;   
            }
            else
            {
                base.completeAsyncTask.OnError("Error, ");
            }
        }


    }
}
