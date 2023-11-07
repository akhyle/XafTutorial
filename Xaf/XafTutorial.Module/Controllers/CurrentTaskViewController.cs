using DevExpress.ExpressApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XafTutorial.Module.BusinessObjects;

namespace XafTutorial.Module.Controllers
{
    public class NonPersistentObjectActivatorController : ObjectViewController<DetailView, CurrentTask>
    {
        protected override void OnActivated()
        {
            base.OnActivated();

            if ((ObjectSpace is NonPersistentObjectSpace) && (View.CurrentObject == null))
            {
                View.CurrentObject = ObjectSpace.CreateObject(View.ObjectTypeInfo.Type);
                View.ViewEditMode = DevExpress.ExpressApp.Editors.ViewEditMode.Edit;
            }
        }
    }
}
