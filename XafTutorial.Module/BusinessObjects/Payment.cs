using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XafTutorial.Module.BusinessObjects;

public class Payment : XPObject
{
    public Payment(Session session) : base(session) { }

    string fFirstName;
    public string FirstName
    {
        get { return fFirstName; }
        set { SetPropertyValue(nameof(FirstName), ref fFirstName, value); }
    }

    string fLastName;
    public string LastName
    {
        get { return fLastName; }
        set { SetPropertyValue(nameof(LastName), ref fLastName, value); }
    }
}
