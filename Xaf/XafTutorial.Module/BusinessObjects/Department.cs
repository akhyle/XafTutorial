﻿using DevExpress.Persistent.Base;
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
public class Department : BaseObject
{
    public Department(Session session) : base(session) { }

    private string title;
    public string Title
    {
        get { return title; }
        set { SetPropertyValue(nameof(Title), ref title, value); }
    }

    private string office;
    public string Office
    {
        get { return office; }
        set { SetPropertyValue(nameof(Office), ref office, value); }
    }

    [Association("Department-Contacts")]
    public XPCollection<Contact> Contacts
    {
        get
        {
            return GetCollection<Contact>(nameof(Contacts));
        }
    }

    [Association("Departments-Positions")]
    public XPCollection<Position> Positions
    {
        get { return GetCollection<Position>(nameof(Positions)); }
    }
}
