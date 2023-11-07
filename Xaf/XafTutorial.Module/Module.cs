using DevExpress.ExpressApp;
using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Updating;
using DevExpress.ExpressApp.Xpo;

namespace XafTutorial.Module;

// For more typical usage scenarios, be sure to check out https://docs.devexpress.com/eXpressAppFramework/DevExpress.ExpressApp.ModuleBase.
public sealed class XafTutorialModule : ModuleBase {
    public XafTutorialModule() {
		RequiredModuleTypes.Add(typeof(DevExpress.ExpressApp.SystemModule.SystemModule));
		RequiredModuleTypes.Add(typeof(DevExpress.ExpressApp.Objects.BusinessClassLibraryCustomizationModule));
    }
    public override IEnumerable<ModuleUpdater> GetModuleUpdaters(IObjectSpace objectSpace, Version versionFromDB) {
        ModuleUpdater updater = new DatabaseUpdate.Updater(objectSpace, versionFromDB);
        return new ModuleUpdater[] { updater };
    }
    public override void Setup(XafApplication application) {
        base.Setup(application);
        application.ObjectSpaceCreated += HandleObjectSpaceCreate;
    }
    private void HandleObjectSpaceCreate(object sender, ObjectSpaceCreatedEventArgs e)
    {
        CompositeObjectSpace compositeObjectSpace = e.ObjectSpace as CompositeObjectSpace;
        if (compositeObjectSpace is null)
            return;

        if (compositeObjectSpace.Owner is not CompositeObjectSpace)
        {
            compositeObjectSpace.PopulateAdditionalObjectSpaces((XafApplication)sender);
        }
    }
    public override void CustomizeTypesInfo(ITypesInfo typesInfo) {
        base.CustomizeTypesInfo(typesInfo);
        CalculatedPersistentAliasHelper.CustomizeTypesInfo(typesInfo);
    }
}
