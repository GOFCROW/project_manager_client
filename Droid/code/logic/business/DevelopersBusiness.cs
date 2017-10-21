using System;
using System.Collections.Generic;
using Android.Content;
using ProjectManager.Droid.code.entity;
using ProjectManager.Droid.code.logic.listeners;
using ProjectManager.Droid.code.logic.tasks;

namespace ProjectManager.Droid.code.logic.business
{
    public class DevelopersBusiness : CompleteAsyncTask
    {
        private Context context;
        private NotifyController notifyController;

        public DevelopersBusiness(Context context, NotifyController notifyController)
        {
            this.context = context;
            this.notifyController = notifyController;
        }

        public void GetListDevelopers()
        {
            new ListDevelopersTask(this.context, this).Execute();
        }


        public void OnResponse(object result)
        {
            notifyController.Notify(result, "ListarDeveloper");
        }

        public void OnError(string message)
        {
            throw new NotImplementedException();
        }

    }
}
