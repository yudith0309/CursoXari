using DevExpress.Xpo;
using NUnit.Framework.Internal;
using System.Diagnostics;

namespace IntroToXpo;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Test1()
    {
        // string conn = DevExpress.Xpo.DB.AccessConnectionProvider.GetConnectionString("Demo.mdb");

        string conn = "Integrated Security=SSPI;Pooling=false;Data Source=localhost\\SQLExpress;Initial Catalog=XpoDemoOctubre";

        IDataLayer dl = XpoDefault.GetDataLayer(conn, DevExpress.Xpo.DB.AutoCreateOption.DatabaseAndSchema);

        using (Session session = new Session(dl))
        {
            System.Reflection.Assembly[] assemblies = new System.Reflection.Assembly[]
            {
                typeof(Test).Assembly,
            };
            session.UpdateSchema(assemblies);
            session.CreateObjectTypeRecords(assemblies);
        }
        //Si ocurre un error durante la transacción, los cambios no se aplican, asegurando la consistencia de los datos.
        UnitOfWork unitOfWork = new UnitOfWork(dl);

        //Crenado cliente extrajero
        ClienteExtranjero clienteExtranjero = new ClienteExtranjero(unitOfWork);
        clienteExtranjero.Nombre = "Yudith Recio Milanes";
        clienteExtranjero.Direccion = "Panama";
        clienteExtranjero.Pasaporte = "54647";
        //clienteExtranjero.Save();

        var clienteExtranjeros = unitOfWork.Query<ClienteExtranjero>().ToList();
        foreach (ClienteExtranjero clienteExtranjero2 in clienteExtranjeros) { 

            Debug.WriteLine(clienteExtranjero2.Nombre);
        }

        //Creando una factura
        Factura factura = new Factura(unitOfWork);
        factura.Cliente = "Jose Javier";

        //Crear una factura con sus detalles 

        FacturaDetalle facturaDetalle = new FacturaDetalle(unitOfWork);
        facturaDetalle.Factura = factura;
        facturaDetalle.ProductName = "Computadora";

        factura.Delete();

        try
        {
            unitOfWork.PurgeDeletedObjects(); //elimina de la sesión los objetos que han sido marcados como eliminados y que ya no existen en la base de datos
            unitOfWork.CommitChanges();
            Console.WriteLine("Cambios guardados exitosamente.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al guardar los cambios: {ex.Message}");
        }

        Assert.Pass();
    }

}