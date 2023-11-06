using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.Base;
using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XafTutorial.Module.BusinessObjects;

[DefaultClassOptions]
[ModelDefault("Caption", "Task")]
public class DemoTask : DevExpress.Persistent.BaseImpl.Task
{
    public DemoTask(Session session) : base(session) { }

    [Association("Contact-DemoTask")]
    public XPCollection<Contact> Contacts
    {
        get
        {
            return GetCollection<Contact>(nameof(Contacts));
        }
    }

    private Priority priority;
    public Priority Priority
    {
        get { return priority; }
        set
        {
            SetPropertyValue(nameof(Priority), ref priority, value);
        }
    }

    public override void AfterConstruction()
    {
        base.AfterConstruction();
        Priority = Priority.Normal;
    }
}

public enum Priority
{
    Low,
    Normal,
    High
}
