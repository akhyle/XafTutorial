using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.DC;
using DevExpress.Persistent.Base;

namespace XafTutorial.Module.BusinessObjects
{
    [DomainComponent, DefaultClassOptions]
    public class CurrentTask : NonPersistentBaseObject, IObjectSpaceLink
    {
        [VisibleInDetailView(false)]
        public string JesusChrixt => "Jesus";

        private IList<DemoTask> _tasks;
        public IList<DemoTask> Tasks { get => _tasks is null ? GetTasks() : _tasks; internal set => _tasks = value; }

        private IList<DemoTask> GetTasks()
        {
            const string Criteria = "Priority == 'High' OR Status == 'InProgress'";
            var tasks = ObjectSpace.GetObjects<DemoTask>(CriteriaOperator.Parse(Criteria));

            return tasks;
        }
    }
}
