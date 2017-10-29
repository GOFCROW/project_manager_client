using System;
using Android.Content;
using Java.Lang;
using ProjectManager.Droid.code.entity;
using ProjectManager.Droid.code.logic.listeners;
using ProjectManager.Droid.code.services;

namespace ProjectManager.Droid.code.logic.tasks
{
    public class SaveDeveloperTask : AsyncTaskGOF
    {
        Developer developer;

        public SaveDeveloperTask(Context context, CompleteAsyncTask completeAsyncTask,
                                Developer developer) : base(context,completeAsyncTask)
        {
            this.developer = developer;
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
                response = services.PostSaveDeveloper(this.developer);
            }
            catch (Throwable throwable)
            {
                response = null;
            }
            return response;
        }


        protected override void OnPostExecute(object result)
        {
            if (result != null && result.Equals("error"))
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
