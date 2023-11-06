using DevExpress.ExpressApp;
using DevExpress.Data.Filtering;
using DevExpress.Persistent.Base;
using DevExpress.ExpressApp.Updating;
using DevExpress.Xpo;
using DevExpress.ExpressApp.Xpo;
using DevExpress.Persistent.BaseImpl;
using XafTutorial.Module.BusinessObjects;

namespace XafTutorial.Module.DatabaseUpdate;

// For more typical usage scenarios, be sure to check out https://docs.devexpress.com/eXpressAppFramework/DevExpress.ExpressApp.Updating.ModuleUpdater
public class Updater : ModuleUpdater {
    public Updater(IObjectSpace objectSpace, Version currentDBVersion) :
        base(objectSpace, currentDBVersion) {
    }
    public override void UpdateDatabaseAfterUpdateSchema() {
        base.UpdateDatabaseAfterUpdateSchema();

        Contact contactMary = ObjectSpace.FirstOrDefault<Contact>(contact => contact.FirstName == "Mary" && contact.LastName == "Tellitson");

        if (contactMary == null)
        {
            contactMary = ObjectSpace.CreateObject<Contact>();
            contactMary.FirstName = "Mary";
            contactMary.LastName = "Tellitson";
            contactMary.Email = "tellitson@example.com";
            contactMary.Birthday = new DateTime(1980, 11, 27);
        }
        
        ObjectSpace.CommitChanges();
    }
    public override void UpdateDatabaseBeforeUpdateSchema() {
        base.UpdateDatabaseBeforeUpdateSchema();
        //if(CurrentDBVersion < new Version("1.1.0.0") && CurrentDBVersion > new Version("0.0.0.0")) {
        //    RenameColumn("DomainObject1Table", "OldColumnName", "NewColumnName");
        //}
    }
}
