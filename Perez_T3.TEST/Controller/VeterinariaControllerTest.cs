using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using Perez_T3.Controllers;
using Perez_T3.Models;
using Perez_T3.Repositorios;

namespace Perez_T3.TEST.Controller;

public class VeterinariaControllerTest
{
    [Test]
    public void ObteniendoTodosTest()
    {
        var mockRepositorio = new Mock<IVeterinariaRepositorio>();
        mockRepositorio.Setup(o => o.ObteniendoTodos()).Returns(new List<Veterinaria>());

        var controlador = new VeterinariaController(mockRepositorio.Object, null);
        var vista = (ViewResult) controlador.Index();
        
        Assert.IsNotNull(vista);
        Assert.IsInstanceOf<ViewResult>(vista);
    }
    
    [Test]
    public void CreateTest()
    {
        var mockRepositorio = new Mock<IVeterinariaRepositorio>();
        mockRepositorio.Setup(o => o.ObteniendoTodos()).Returns(new List<Veterinaria>());

        var controlador = new VeterinariaController(mockRepositorio.Object, null);
        var vista = (ViewResult) controlador.Create(1);
        
        Assert.IsNotNull(vista);
        Assert.IsInstanceOf<ViewResult>(vista);
    }
    
    [Test]
    public void SaveTest()
    {
        var mockRepositorio = new Mock<IVeterinariaRepositorio>();
        mockRepositorio.Setup(o => o.ObteniendoTodos()).Returns(new List<Veterinaria>());

        var controlador = new VeterinariaController(mockRepositorio.Object, null);
        var vista = controlador.Guardar(new Veterinaria() {Id = 1, Nombre = "Nombre1", NombreDuenio = "Duenio1"});
        
        Assert.IsNotNull(vista);
    }
    
    [Test]
    public void DeleteTest()
    {
        var mockRepositorio = new Mock<IVeterinariaRepositorio>();
        mockRepositorio.Setup(o => o.ObteniendoTodos()).Returns(new List<Veterinaria>());

        var controlador = new VeterinariaController(mockRepositorio.Object, null);
        var vista = controlador.Delete(1);
        
        Assert.IsNotNull(vista);
     
    }
    
    [Test]
    public void EditGetTest()
    {
        var mockRepositorio = new Mock<IVeterinariaRepositorio>();
        mockRepositorio.Setup(o => o.InfoId(1)).Returns(new Veterinaria(){Id = 1, Nombre = "Nombre1", NombreDuenio = "Duenio1"});
        var controlador = new VeterinariaController(mockRepositorio.Object, null);
        var vista =  controlador.Editar(1);
        
        Assert.IsNotNull(vista);
       
    }
    
    [Test]
    public void EditPostTest()
    {
        var mockRepositorio = new Mock<IVeterinariaRepositorio>();

        var controlador = new VeterinariaController(mockRepositorio.Object, null);
        var vista =  controlador.Actualizar(new Veterinaria());
        
        Assert.IsNotNull(vista);
       
    }
   
}