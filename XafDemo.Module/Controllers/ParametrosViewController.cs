using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;

namespace XafDemo.Module.BusinessObjects;


//xcv
public class ParametrosViewController : ViewController
{
    PopupWindowShowAction MostrarParametros;
    public ParametrosViewController() : base()
    {
        // Target required Views (use the TargetXXX properties) and create their Actions.

        MostrarParametros = new PopupWindowShowAction(this, "Mostrar Parametros", "View");
        MostrarParametros.Execute += MostrarParametros_Execute;
        MostrarParametros.CustomizePopupWindowParams += MostrarParametros_CustomizePopupWindowParams;
        

    }
    private void MostrarParametros_Execute(object sender, PopupWindowShowActionExecuteEventArgs e)
    {
        var selectedPopupWindowObjects = e.PopupWindowViewSelectedObjects[0];
        var selectedSourceViewObjects = e.SelectedObjects[0];
        // Execute your business logic (https://docs.devexpress.com/eXpressAppFramework/112723/).
    }
    private void MostrarParametros_CustomizePopupWindowParams(object sender, CustomizePopupWindowParamsEventArgs e)
    {
        var os = this.Application.CreateObjectSpace(typeof(NpParametros));
        var parametros = os.CreateObject<NpParametros>();
        var View = this.Application.CreateDetailView(os,parametros);
        e.View = View;
        // Set the e.View parameter to a newly created view (https://docs.devexpress.com/eXpressAppFramework/112723/).
    }
    protected override void OnActivated()
    {
        base.OnActivated();
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
