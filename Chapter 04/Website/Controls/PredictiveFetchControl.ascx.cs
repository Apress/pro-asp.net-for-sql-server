using System;
using System.Diagnostics;
using System.Threading;
using System.Web.UI;

namespace Apress.Chapter04.UserControls
{
    public partial class AjaxPersonControl : UserControl
    {
        private delegate long PreFetchData(long id);

        private PreFetchData del1; // current request delegate
        private PreFetchData del2; // prefetch delegate
        private IAsyncResult result1;
        private IAsyncResult result2;

        protected void Page_Init(object sender, EventArgs e)
        {
            GetDataAsync(1, out del1, out result1);
            GetDataAsync(10, out del2, out result2);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            CurrentID = GetCurrentResult();
            lblCurrentID.Text = "CurrentID = " + CurrentID;
        }

        public long CurrentID
        {
            get
            {
                if (ViewState["CurrentID"] == null) 
                {
                    return -1; 
                }
                return (long) ViewState["CurrentID"];
            }
            set
            {
                ViewState["CurrentID"] = value;
            }
        }

        private long GetCurrentResult()
        {
            // wait for the first delegate
            WaitHandle[] handles = { result1.AsyncWaitHandle };
            WaitHandle.WaitAll(handles);
            Debug.WriteLine("Finished waiting for current result");
            return del1.EndInvoke(result1);
        }

        private void GetDataAsync(long id, out PreFetchData del, out IAsyncResult result)
        {
            del =
                delegate
                {
                    return DoPreFetchData(id);
                };
            AsyncCallback callback =
                delegate
                {
                    HandleCallback(id);
                };
            result = del.BeginInvoke(id, callback, null);
        }

        private void HandleCallback(long id)
        {
            Debug.WriteLine("HandleCallback: " + id + " at " + DateTime.Now);
        }

        private long DoPreFetchData(long id)
        {
            // get the data
            int wait = (int)id * 1000;
            Debug.WriteLine("Waiting " + wait + "ms for " + id);
            Thread.Sleep(wait);
            return id;
        }

    }
}
