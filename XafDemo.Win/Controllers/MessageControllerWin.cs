using DevExpress.ExpressApp.Actions;
using XafDemo.Module.Controllers;

namespace XafDemo.Win.Controllers;

//xcv Para crear clases ViewController
public class MessageControllerWin : MessageController
{
    public MessageControllerWin() : base()
    {
        // Target required Views (use the TargetXXX properties) and create their Actions.
        //xas Para Actions        
    }
    protected override void ShowMessage_Execute(object sender, SimpleActionExecuteEventArgs e)
    {
        System.Windows.Forms.MessageBox.Show(this.GetMessage());
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

