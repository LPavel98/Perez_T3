using Perez_T3.DB;
using Perez_T3.Models;

namespace Perez_T3.Repositorios;

public interface IVeterinariaRepositorio
{
    List<Veterinaria> ObteniendoTodos();
    void DeleteInfo(int id);
    void EditInfo(Veterinaria veterinaria);
    Veterinaria InfoId(int id);
    void SaveInfo(Veterinaria veterinaria);
}

public class VeteRepositorio : IVeterinariaRepositorio
{
    
    private DBEntities _dbEntities;

    public VeteRepositorio(DBEntities dbEntities)
    {
        _dbEntities = dbEntities;
    }

    public void SaveInfo(Veterinaria veterinaria)
    {
        _dbEntities.Veterinarias.Add(veterinaria);
        _dbEntities.SaveChanges();
    }
    
    public Veterinaria InfoId(int id)
    {
        var item = _dbEntities.Veterinarias.First(o => o.Id == id);
        return item;
    }
    
    public void EditInfo(Veterinaria veterinaria)
    {
        var item = _dbEntities.Veterinarias.First(o => o.Nombre == veterinaria.Nombre);
        item.Nombre = veterinaria.Nombre;
        item.NombreDuenio = veterinaria.NombreDuenio;
        _dbEntities.SaveChanges();
    }
    
    public void DeleteInfo(int id)
    {
        var item = _dbEntities.Veterinarias.First(o => o.Id == id);
        _dbEntities.Veterinarias.Remove(item);
        _dbEntities.SaveChanges();
    }
    
    public List<Veterinaria> ObteniendoTodos()
    {
        var item =_dbEntities.Veterinarias.ToList();
        return item;
    }

}