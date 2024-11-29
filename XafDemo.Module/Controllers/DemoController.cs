using DevExpress.ExpressApp;
namespace XafDemo.Module.Controllers;

public class MyWindowsController : WindowController
{
    public MyWindowsController()
    {
        this.TargetWindowType = WindowType.Main;
    }
}
// For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppViewControllertopic.aspx.
public partial class DemoController : ViewController
{

    // Use CodeRush to create Controllers and Actions with a few keystrokes.
    // https://docs.devexpress.com/CodeRushForRoslyn/403133/
    public DemoController()
    {
        //Especificar el tipo de objeto para el cual se aplicará dicho controlador
        //this.TargetObjectType = typeof(DemoParaController);

        //El controlador se activará solo cuando el usuario esté viendo una vista de detalle
        //this.TargetViewType = ViewType.DetailView;
        // Target required Views (via the TargetXXX properties) and create their Actions.

        this.TargetViewId = "Cliente_ListView;Cliente_DetailView";
    }
    protected override void OnActivated()
    {
        base.OnActivated();
        // Perform various tasks depending on the target View.
    }
    protected override void OnViewControlsCreated()
    {
        base.OnViewControlsCreated();
        // Access and customize the target View control.
    }
    protected override void OnDeactivated()
    {
        // Unsubscribe from previously subscribed events and release other references and resources.
        base.OnDeactivated();
    }
}
