using Microsoft.AspNetCore.Mvc;
using Perez_T3.DB;
using Perez_T3.DB.Mapping;
using Perez_T3.Repositorios;
using Perez_T3.Models;
namespace Perez_T3.Controllers;

public class VeterinariaController : Controller
{
    private readonly IVeterinariaRepositorio _veteReposito;
    private DBEntities _dbEntities;

    public VeterinariaController(IVeterinariaRepositorio veteRepositorio, DBEntities dbEntities)
    {
        _veteReposito = veteRepositorio;
        _dbEntities = dbEntities;
    }
    
    [HttpGet]
    public IActionResult Index()
    {
        var item = _veteReposito.ObteniendoTodos().ToList();
        return View(item);
    }

    public IActionResult Create(int id)
    {
        ViewBag.Id = id;
        return View(new Veterinaria());
    }
    
    public IActionResult Guardar(Veterinaria veterinaria)
    {
        _veteReposito.SaveInfo(veterinaria);
        return RedirectToAction("Index");
    }

    public IActionResult Delete(int id)
    {
        _veteReposito.DeleteInfo(id);
        return RedirectToAction("Index");
    }
    
    
    public IActionResult Editar(int id)
    {
        var vetes = _veteReposito.InfoId(id);
        return View(vetes);
    }

    public IActionResult Actualizar(Veterinaria veterinaria)
    {
        _veteReposito.EditInfo(veterinaria);
      
        return RedirectToAction("Index");
    }
   
}