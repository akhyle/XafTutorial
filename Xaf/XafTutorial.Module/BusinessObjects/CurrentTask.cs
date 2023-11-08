using DevExpress.Data.Filtering;
using DevExpress.Data.TreeList;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.DC;
using DevExpress.Persistent.Base;

namespace XafTutorial.Module.BusinessObjects
{
    [DomainComponent, DefaultClassOptions]
    public class CurrentTask : NonPersistentBaseObject, IObjectSpaceLink
    {
        public string Summary {  get; set; }
        
        public Priority Priority { get; set; }
    }
}
