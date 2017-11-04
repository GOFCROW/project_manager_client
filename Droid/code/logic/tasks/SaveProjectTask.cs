using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using ProjectManager.Droid.code.entity;
using ProjectManager.Droid.code.logic.listeners;
using ProjectManager.Droid.code.services;
using Java.Lang;

namespace ProjectManager.Droid.code.logic.tasks
{
    class SaveProjectTask : AsyncTaskGOF
    {
        Project project;

        public SaveProjectTask(Context context, CompleteAsyncTask completeAsyncTask,
            Project project) : base(context, completeAsyncTask)
        {
            this.project = project;
        }


        protected override void OnPreExecute()
        {
            base.OnPreExecute();
        }

        protected override object RunInBackground(params object[] @params)
        {
            System.String response = "";
            try
            {
                Services services = new Services();
                response = services.PostSaveProject(this.project);
            }
            catch (Throwable throwable)
            {
                response = null;
            }
            return response;
        }

        protected override void OnPostExecute(object result)
        {
            if (result != null && ((string)result).Contains("ok"))
            {
                base.completeAsyncTask.OnResponse(result); ;
            }
            else
            {
                base.completeAsyncTask.OnError("Error, no se pudieron guardar los datos");
            }
        }
    }
}