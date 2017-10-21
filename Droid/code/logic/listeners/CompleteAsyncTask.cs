using System;
namespace ProjectManager.Droid.code.logic.listeners
{
    public interface CompleteAsyncTask
    {
        void OnResponse(Object result);
        void OnError(String message);
    }
}
