using System.Collections.Generic;
using System.Linq;
using Moq;
using NUnit.Framework;
using Perez_T3.DB;
using Perez_T3.Models;
using Perez_T3.Repositorios;
using Perez_T3.TEST.Helpers;

namespace Perez_T3.TEST.Repositorios;

public class NotaRepositorioTest
{
    private IQueryable<Veterinaria> data;
    private Mock<DBEntities> mockDB;

    [SetUp]
    public void SetUp()
    {
        data = new List<Veterinaria>
        {
            new Veterinaria() {Id = 1, Nombre = "Prueba1", NombreDuenio = "prueba dueño 1"},
            new Veterinaria() {Id = 2, Nombre = "Prueba2", NombreDuenio = "prueba dueño 2"},
            new Veterinaria() {Id = 3, Nombre = "Prueba3", NombreDuenio = "prueba dueño 3"}

        }.AsQueryable();

        var mockDbsetNota = new MockDbSetcs.MockDbSet<Veterinaria>(data);
        mockDB = new Mock<DBEntities>();
        mockDB.Setup(o => o.Veterinarias).Returns(mockDbsetNota.Object);
    }

    [Test]

    public void ObteniendoTodosRepositorioTest()
    {
        var repo = new VeteRepositorio(mockDB.Object);
        var repoObt = repo.ObteniendoTodos();
        Assert.IsNotNull(repoObt);
    }
    
    [Test]
    public void ObteniendoTodosIdRepositorioTest()
    {
        var repo = new VeteRepositorio(mockDB.Object);
        var repoObt = repo.InfoId(1);
        Assert.AreEqual(1, repoObt.Id);
    }
    
    [Test]
    public void addRepositorioTest()
    {
        var mockDbsetNota = new MockDbSetcs.MockDbSet<Veterinaria>(data);
        mockDB = new Mock<DBEntities>();
        mockDB.Setup(o => o.Veterinarias).Returns(mockDbsetNota.Object);
        var repo = new VeteRepositorio(mockDB.Object);
        repo.SaveInfo(new Veterinaria() {Id = 1, Nombre = "Prueba1", NombreDuenio = "Comentario prueba 1"});
        mockDbsetNota.Verify(o => o.Add(It.IsAny<Veterinaria>()), Times.Once);
    }
    
    [Test]
    public void EditRepositorioTest()
    {
        var repo = new VeteRepositorio(mockDB.Object);
        var editr = repo.InfoId(1);
        Assert.AreEqual(1, editr.Id);
    }
    
    [Test]
    public void DeleteRepositorioTest()
    {
        var mockDbsetNota = new MockDbSetcs.MockDbSet<Veterinaria>(data);
        mockDB = new Mock<DBEntities>();
        mockDB.Setup(o => o.Veterinarias).Returns(mockDbsetNota.Object);
        var repo = new VeteRepositorio(mockDB.Object);
        repo.DeleteInfo(1);
        var del = data.First(o => o.Id == 1);
        mockDbsetNota.Verify(o => o.Remove(del));
    }
}