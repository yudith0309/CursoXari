using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using XafDemo.Module.BusinessObjects;

namespace XafDemo.Module.Controllers
{
    public class MessageController : ViewController
    {
        SimpleAction CrearVistas;
        PopupWindowShowAction MostrarListadoClientes;
        SingleChoiceAction ActionSingleChoice;
        ParametrizedAction AccionParametrizada;
        ParametrizedAction action;
        SimpleAction ShowMessage;
        public MessageController() : base()
        {
            // Target required Views (use the TargetXXX properties) and create their Actions.
            //xas No parametrizadas
            ShowMessage = new SimpleAction(this, "My Show Message", "View");
            ShowMessage.Execute += ShowMessage_Execute;
            ShowMessage.Caption = "Mostrar mensaje";

            //Permite especificar el tipo de objeto de negocio al que se aplicará el controlador.
            ShowMessage.TargetObjectType = typeof(Cliente);

            //Permite especificar en qué tipo de vistas estará activo el controlador
            // ShowMessage.TargetViewType = ViewType.DetailView;

            //Permite especificar que el controlador estará activo únicamente en una vista con un Id específico
            //ShowMessage.TargetViewId = "";

            //Permite aplicar el controlador únicamente a los objetos de negocio que cumplan con una expresión de criterio
            ShowMessage.TargetObjectsCriteria = "Cliente.Activo = true";

            //xap Acciones parametrizadas, se ejecuta con entrada de parametros 
            AccionParametrizada = new ParametrizedAction(this, "Accion con Parametros", "View", typeof(int));
            AccionParametrizada.Execute += AccionParametrizada_Execute;
            AccionParametrizada.Caption = "PAction";

            //xac permite al usuario seleccionar una opción de un conjunto de valores predefinidos y ejecutar lógica en función de esa selección.

            ActionSingleChoice = new SingleChoiceAction(this, "My Single Choice action", "View");

            ActionSingleChoice.ItemType = SingleChoiceActionItemType.ItemIsMode;
            ActionSingleChoice.Caption = "Sca";
            ActionSingleChoice.Execute += ActionSingleChoice_Execute;
            // Create some items

            //Es un elemento que representa una opción dentro de una SingleChoiceAction o MultiChoiceAction.
            //Cada ChoiceActionItem contiene una etiqueta (caption) que se muestra al usuario y un valor asociado (data)
            ActionSingleChoice.Items.Add(new ChoiceActionItem("MyItem1", "My Item 1", 1));
            ChoiceActionItem item = new ChoiceActionItem("MyItem2", "My Item 2", 2);
            ChoiceActionItem item2 = new ChoiceActionItem("MyItem2.5", "My Item 2.5", 2.5);
            item.Items.Add(item2);
            ActionSingleChoice.Items.Add(item);

            //xapw
            //Acción que se utiliza para mostrar una ventana emergente (popup) dentro de la interfaz de usuario
            MostrarListadoClientes = new PopupWindowShowAction(this, "Poup Windows", "View");
            MostrarListadoClientes.Execute += MostrarListadoClientes_Execute;
            MostrarListadoClientes.CustomizePopupWindowParams += MostrarListadoClientes_CustomizePopupWindowParams;
            MostrarListadoClientes.Caption = "Mostrar vista de clientes";

            //Crar Simple Action 
            //xas
            CrearVistas = new SimpleAction(this, "MyAction", "View");
            CrearVistas.Execute += CrearVistas_Execute;
            

        }
        private void CrearVistas_Execute(object sender, SimpleActionExecuteEventArgs e)
        {
            var os = this.Application.CreateObjectSpace(typeof(Cliente));          
            var Javier = os.GetObjectsQuery<Cliente>().FirstOrDefault(c => c.Nombre == "Javier");
            var varDetailJavier = this.Application.CreateDetailView(os, "ClienteNombreDetailView", false, Javier);
            e.ShowViewParameters.CreatedView = varDetailJavier;
        }
        private void MostrarListadoClientes_Execute(object sender, PopupWindowShowActionExecuteEventArgs e)
        {
            var selectedPopupWindowObjects = e.PopupWindowViewSelectedObjects;
            var selectedSourceViewObjects = e.SelectedObjects;
            // Execute your business logic (https://docs.devexpress.com/eXpressAppFramework/112723/).
        }
        private void MostrarListadoClientes_CustomizePopupWindowParams(object sender, CustomizePopupWindowParamsEventArgs e)
        {
            var os = this.Application.CreateObjectSpace(typeof(Cliente));
            /* ListView MyView = this.Application.CreateListView(os, typeof(Cliente), false);
             e.View = MyView;*/


            var Javier = os.GetObjectsQuery<Cliente>().FirstOrDefault(c => c.Nombre == "Javier");

            var varDetailJavier = this.Application.CreateDetailView(os, "ClienteNombreDetailView", false, Javier);
            e.View = varDetailJavier;
            // Set the e.View parameter to a newly created view (https://docs.devexpress.com/eXpressAppFramework/112723/).
        }
        private void ActionSingleChoice_Execute(object sender, SingleChoiceActionExecuteEventArgs e)
        {
            var itemData = e.SelectedChoiceActionItem.Data;
            // Execute your business logic (https://docs.devexpress.com/eXpressAppFramework/112738/).
        }
        private void AccionParametrizada_Execute(object sender, ParametrizedActionExecuteEventArgs e)
        {
            var parameterValue = (string)e.ParameterCurrentValue;
            // Execute your business logic (https://docs.devexpress.com/eXpressAppFramework/112724/).
        }
        private void action_Execute(object sender, ParametrizedActionExecuteEventArgs e)
        {
            var parameterValue = (string)e.ParameterCurrentValue;
            // Execute your business logic (https://docs.devexpress.com/eXpressAppFramework/112724/).
        }

        protected virtual string GetMessage()
        {
            return "Hola mundo";
        }
        protected virtual void ShowMessage_Execute(object sender, SimpleActionExecuteEventArgs e)
        {
            throw new NotImplementedException("Esto no esta implementado");
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

}
