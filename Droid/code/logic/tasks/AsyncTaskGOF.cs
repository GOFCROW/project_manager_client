using System;
using Android.Content;
using Android.OS;
using Java.Lang;
using ProjectManager.Droid.code.logic.listeners;

namespace ProjectManager.Droid.code.logic.tasks
{
    public abstract class AsyncTaskGOF : AsyncTask<System.Object, System.Object,System.Object>
    {
        protected Context context;
        protected CompleteAsyncTask completeAsyncTask;

        public AsyncTaskGOF(Context context, CompleteAsyncTask completeAsyncTask)
        {
            this.context = context;
            this.completeAsyncTask = completeAsyncTask;
        }

    }
}
