using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.Persistent.Validation;
using DevExpress.XtraRichEdit.Import.OpenDocument;

namespace XafDemo.Module.Controllers;

public interface IPost
{
    void Postear();
    bool Posteado { get; }
}
public class MyValidationController : ViewController
{
    SimpleAction Postear;
    public MyValidationController() : base()
    {
        // Target required Views (use the TargetXXX properties) and create their Actions.

        TargetObjectType = typeof(IPost);
        Postear = new SimpleAction(this, "Postear Action", "View");
        Postear.Execute += Postear_Execute;
    }
    private void Postear_Execute(object sender, SimpleActionExecuteEventArgs e)
    {
        IPost CurrentIPost = this.View.CurrentObject as IPost;
        var ValidationService = DevExpress.Persistent.Validation.Validator.GetService(this.Application.ServiceProvider);

        //ValidationService.Validate(this.View.ObjectSpace, CurrentIPost, new ContextIdentifiers("Postear"));

        var Rulset = ValidationService.ValidateTarget(this.View.ObjectSpace, CurrentIPost, new ContextIdentifiers("Postear"));

        if (Rulset.ValidationOutcome == ValidationOutcome.Valid)
        {
            CurrentIPost.Postear();
            this.View.ObjectSpace.CommitChanges();
        }
        else
        {
            throw new UserFriendlyException("No se puede postear el documento");
        }
        // Execute your business logic (https://docs.devexpress.com/eXpressAppFramework/112737/).
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
