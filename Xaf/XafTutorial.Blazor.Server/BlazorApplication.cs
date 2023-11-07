﻿using DevExpress.ExpressApp;
using DevExpress.ExpressApp.ApplicationBuilder;
using DevExpress.ExpressApp.Blazor;
using DevExpress.ExpressApp.SystemModule;
using DevExpress.ExpressApp.Xpo;
using XafTutorial.Blazor.Server.Services;

namespace XafTutorial.Blazor.Server;

public class XafTutorialBlazorApplication : BlazorApplication {
    public XafTutorialBlazorApplication() {
        ApplicationName = "XafTutorial";
        CheckCompatibilityType = DevExpress.ExpressApp.CheckCompatibilityType.DatabaseSchema;
        DatabaseVersionMismatch += XafTutorialBlazorApplication_DatabaseVersionMismatch;
    }
    protected override void CreateDefaultObjectSpaceProvider(CreateCustomObjectSpaceProviderEventArgs args)
    {
        base.CreateDefaultObjectSpaceProvider(args);
        args.ObjectSpaceProviders.Add(new NonPersistentObjectSpaceProvider(TypesInfo, null));
    }
    protected override void OnSetupStarted() {
        base.OnSetupStarted();
#if DEBUG
        if(System.Diagnostics.Debugger.IsAttached && CheckCompatibilityType == CheckCompatibilityType.DatabaseSchema) {
            DatabaseUpdateMode = DatabaseUpdateMode.UpdateDatabaseAlways;
        }
#endif
    }
    private void XafTutorialBlazorApplication_DatabaseVersionMismatch(object sender, DatabaseVersionMismatchEventArgs e) {
#if EASYTEST
        e.Updater.Update();
        e.Handled = true;
#else
        if(System.Diagnostics.Debugger.IsAttached) {
            e.Updater.Update();
            e.Handled = true;
        }
        else {
            string message = "The application cannot connect to the specified database, " +
                "because the database doesn't exist, its version is older " +
                "than that of the application or its schema does not match " +
                "the ORM data model structure. To avoid this error, use one " +
                "of the solutions from the https://www.devexpress.com/kb=T367835 KB Article.";

            if(e.CompatibilityError != null && e.CompatibilityError.Exception != null) {
                message += "\r\n\r\nInner exception: " + e.CompatibilityError.Exception.Message;
            }
            throw new InvalidOperationException(message);
        }
#endif
    }
}
