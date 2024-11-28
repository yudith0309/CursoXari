using DevExpress.ExpressApp;
using DevExpress.ExpressApp.SystemModule;

namespace XafDemo.Module.Controllers;

//xcv

public class ControllerTercerosController : ViewController
{
    public ControllerTercerosController() : base()
    {
        // Target required Views (use the TargetXXX properties) and create their Actions.

        this.TargetViewType = ViewType.DetailView;

    }
    protected override void OnActivated()
    {
        base.OnActivated();
        var ModificationsController = this.Frame.GetController<ModificationsController>();
        if (ModificationsController != null)
        {
            ModificationsController.SaveAction.Caption = "Guardar";
        }
        // Perform various tasks depending on the target View.
    }
    protected override void OnDeactivated()
    {
        // Unsubscribe from previously subscribed events and release other references and resources.
        base.OnDeactivated();
    }
    protected override void OnViewControlsCreated()
    {
        base.OnViewControlsCreated();
        // Access and customize the target View control.
    }
}
