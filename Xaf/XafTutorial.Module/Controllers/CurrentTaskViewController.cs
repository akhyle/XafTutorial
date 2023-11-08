using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XafTutorial.Module.BusinessObjects;

namespace XafTutorial.Module.Controllers
{
    public class NonPersistentObjectActivatorController : ObjectViewController<ListView, CurrentTask>
    {
        protected override void OnActivated()
        {
            const string Criteria = "Priority == 'High' OR Status == 'InProgress'";
            base.OnActivated();

            var correctTasks = ObjectSpace.GetObjects<DemoTask>(CriteriaOperator.Parse(Criteria)).ToList();

            foreach (var item in correctTasks)
            {
                var currentTask = ObjectSpace.CreateObject<CurrentTask>();
                currentTask.Summary = item.Subject;
                currentTask.Priority = item.Priority;

                View.CollectionSource.Add(currentTask);
            }

            ObjectSpace.CommitChanges();
        }
    }
}
