using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.Utils;
using DevExpress.Persistent.Base;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XafTutorial.Module.BusinessObjects;

namespace XafTutorial.Module.Controllers
{
    public class DemoTaskListViewController : ObjectViewController<ListView, DemoTask>
    {
        private ChoiceActionItem setAssignedToItem;
        public DemoTaskListViewController() : base()
        {
            SingleChoiceAction SetTaskAction = new SingleChoiceAction(this, "SetTaskAction", PredefinedCategory.Edit)
            {
                Caption = "Set Task",
                ItemType = SingleChoiceActionItemType.ItemIsOperation,
                SelectionDependencyType = SelectionDependencyType.RequireMultipleObjects
            };

            setAssignedToItem = new ChoiceActionItem(CaptionHelper.GetMemberCaption(typeof(DemoTask), "AssignedTo"), null);
            SetTaskAction.Items.Add(setAssignedToItem);
            

            SetTaskAction.Execute += SetTaskAction_Execute;
        }

        protected override void OnActivated()
        {
            base.OnActivated();
            PopulateItemWithOptions(ObjectSpace, setAssignedToItem);
        }

        private void PopulateItemWithOptions(IObjectSpace objectSpace, ChoiceActionItem parentItem)
        {
            var contacts = objectSpace.GetObjects<Contact>();
            foreach (var contact in contacts)
            {
                ChoiceActionItem item = new ChoiceActionItem(contact.DisplayName, contact);
                parentItem.Items.Add(item);
            }
        }

        private void SetTaskAction_Execute(object sender, SingleChoiceActionExecuteEventArgs e)
        {
            var objectsToProcess = new ArrayList(e.SelectedObjects);

            foreach (var obj in objectsToProcess)
            {
                DemoTask objInNewObjectSpace = (DemoTask)ObjectSpace.GetObject(obj);
                objInNewObjectSpace.AssignedTo = (Contact)e.SelectedChoiceActionItem.Data;
            }

            ObjectSpace.CommitChanges();
            View.ObjectSpace.Refresh();
        }
    }
}
