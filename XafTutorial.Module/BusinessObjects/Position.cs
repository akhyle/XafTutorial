using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XafTutorial.Module.BusinessObjects;

[DefaultClassOptions]
[System.ComponentModel.DefaultProperty(nameof(Title))]
public class Position : BaseObject
{
    public Position(Session session) : base(session) { }

    private string title;
    public string Title
    {
        get { return title; }
        set { SetPropertyValue(nameof(Title), ref title, value); }
    }

    [Association("Departments-Positions")]
    public XPCollection<Department> Departments
    {
        get { return GetCollection<Department>(nameof(Departments)); }
    }
}
