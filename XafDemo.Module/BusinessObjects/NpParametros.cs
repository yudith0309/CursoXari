using DevExpress.ExpressApp;
using DevExpress.ExpressApp.DC;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace XafDemo.Module.BusinessObjects;

[DomainComponent]

public class NpParametros : IXafEntityObject/*, IObjectSpaceLink*/, INotifyPropertyChanged
{
    //private IObjectSpace objectSpace;
    private void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
    public NpParametros()
    {
        Oid = Guid.NewGuid();
    }

    [DevExpress.ExpressApp.Data.Key]
    [Browsable(false)]  // Hide the entity identifier from UI.
    public Guid Oid { get; set; }


    DateTime fechaHasta;
    DateTime fechaDesde;

    public DateTime FechaDesde
    {
        get => fechaDesde;
        set
        {
            if (fechaDesde == value)
                return;
            fechaDesde = value;
            OnPropertyChanged();
        }
    }
    public DateTime FechaHasta
    {
        get => fechaHasta;
        set
        {
            if (fechaHasta == value)
                return;
            fechaHasta = value;
            OnPropertyChanged();
        }
    }



    #region IXafEntityObject members (see https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppIXafEntityObjecttopic.aspx)
    void IXafEntityObject.OnCreated()
    {
        // Place the entity initialization code here.
        // You can initialize reference properties using Object Space methods; e.g.:
        // this.Address = objectSpace.CreateObject<Address>();
    }
    void IXafEntityObject.OnLoaded()
    {
        // Place the code that is executed each time the entity is loaded here.
    }
    void IXafEntityObject.OnSaving()
    {
        // Place the code that is executed each time the entity is saved here.
    }
    #endregion

    #region IObjectSpaceLink members (see https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppIObjectSpaceLinktopic.aspx)
    // If you implement this interface, handle the NonPersistentObjectSpace.ObjectGetting event and find or create a copy of the source object in the current Object Space.
    // Use the Object Space to access other entities (see https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113707.aspx).
    //IObjectSpace IObjectSpaceLink.ObjectSpace {
    //    get { return objectSpace; }
    //    set { objectSpace = value; }
    //}
    #endregion

    #region INotifyPropertyChanged members (see http://msdn.microsoft.com/en-us/library/system.componentmodel.inotifypropertychanged(v=vs.110).aspx)
    public event PropertyChangedEventHandler PropertyChanged;
    #endregion
}