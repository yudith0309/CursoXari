using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;

namespace XafDemo.Win.Controllers;

//xcv Para crear clases ViewController
public class MyViewController : ViewController
{
    SimpleAction MostrarMensaje;
    public MyViewController() : base()
    {
        // Target required Views (use the TargetXXX properties) and create their Actions.
        //xas Para Actions 

        MostrarMensaje = new SimpleAction(this, "MostrarBoton", "View");
        MostrarMensaje.Execute += MostrarMensaje_Execute;

    }
    private void MostrarMensaje_Execute(object sender, SimpleActionExecuteEventArgs e)
    {
        System.Windows.Forms.MessageBox.Show("Hola Mundo");
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

