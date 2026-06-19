using Microsoft.AspNetCore.Mvc;
using MarcasBlancasApp.Models;

namespace MarcasBlancasApp.Controllers;

public class MarcasController : Controller
{
    // Usaremos una lista en memoria para simular una base de datos.
    private static readonly List<MarcaBlanca> _marcas = new()
    {
        new MarcaBlanca { 
            Id = 1, 
            Nombre = "Marca Esencial", 
            Categoria = "Alimentación", 
            Descripcion = "Productos de despensa básicos con una excelente relación calidad-precio.",
            ImagenUrl = "https://via.placeholder.com/150/007bff/FFFFFF?text=Alimentos"
        },
        new MarcaBlanca { 
            Id = 2, 
            Nombre = "TecnoBasic", 
            Categoria = "Electrónica", 
            Descripcion = "Dispositivos y accesorios electrónicos funcionales y económicos.",
            ImagenUrl = "https://via.placeholder.com/150/28a745/FFFFFF?text=Tecno"
        },
        new MarcaBlanca { Id = 3, Nombre = "Hogar Limpio", Categoria = "Limpieza", Descripcion = "Línea completa de productos para el cuidado del hogar.", ImagenUrl = "https://via.placeholder.com/150/ffc107/000000?text=Limpieza" }
    };

    public IActionResult Index(string? searchString)
    {
        var marcas = from m in _marcas
                     select m;

        if (!String.IsNullOrEmpty(searchString))
        {
            marcas = marcas.Where(s => s.Categoria!.Contains(searchString, StringComparison.OrdinalIgnoreCase));
        }

        return View(marcas.ToList());
    }
}