using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Shoppe.Model
{
    public class BaseModel : INotifyPropertyChanged
    {
        public BaseModel()
        {
            Oninit();
        }

        public virtual void Oninit()
        {
            try
            {
                Worker = new BackgroundWorker() { WorkerSupportsCancellation = true, WorkerReportsProgress = true };
                Worker.ProgressChanged += Worker_ProgressChanged;
                Worker.RunWorkerCompleted += Worker_RunWorkerCompleted;
            }
            catch (Exception e)
            {
                UpdateError(e);
            }
        }

        void Worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                var Error = e.Error;
            }
            AfterDoingWork();
        }

        void Worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            Progress = e.ProgressPercentage;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void Notify(string Property)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(Property));
            }
        }


        public virtual void BeforeDoingWork()
        {
            Progress = 0;
            Isbusy = true;
        }

        public virtual void AfterDoingWork()
        {
            Isbusy = false;
            //NotifyAll();
        }

        public virtual void StopWorkerAsync()
        {
            try
            {
                this.AfterDoingWork();
                Worker.CancelAsync();
            }
            catch (Exception e)
            {
                UpdateError(e);
            }
        }

        public virtual void UpdateError(Exception e)
        {
            string Desc = "";
            Desc = e.Message;
            if (e.InnerException != null)
            {
                Desc = e.InnerException.Message;
            }
            VMState = Desc;
        }

        public virtual void DoWorkAsync()
        {
            try
            {
                BeforeDoingWork();
                Worker.RunWorkerAsync();

            }
            catch (Exception e)
            {
                UpdateError(e);
            }
        }

        public void NotifyAll()
        {
            try
            {
                foreach (var Prp in GetType().GetProperties())
                {
                    Notify(Prp.Name);
                }
            }
            catch (Exception e)
            {

            }
        }

        public T GetNewObject<T>() where T : class,new()
        {
            try
            {
                T a = new T();
                var Type = typeof(T);
                foreach (var prp in Type.GetProperties())
                {
                    var Prp = this.GetType().GetProperty(prp.Name);
                    if (Prp != null)
                    {
                        var Value = Prp.GetValue(this, null);
                        prp.SetValue(a, Value);
                    }

                }
                return a;

            }
            catch (Exception e)
            {
                return default(T);
            }
        }

        bool _Isbusy = false;
        public bool Isbusy
        {
            get { return _Isbusy; }
            set
            {
                _Isbusy = value;
                Notify("Isbusy");
                Notify("IsFree");
            }
        }

        public bool IsFree { get { return !(Isbusy); } set { } }

        public int Progress { get; set; }

        public string VMState { get; set; }

        public BackgroundWorker Worker { get; set; }




    }
}
