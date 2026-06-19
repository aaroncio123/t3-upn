using Fact;
using Microsoft.AspNetCore.Mvc;
using MarcasBlancasApp.Controllers;
using MarcasBlancasApp.Models;
using System.Collections.Generic;

namespace MarcasBlancasApp.Tests;

public class MarcasControllerTests
{
    [Fact]
    public void Index_ReturnsAViewResult_WithAListOfMarcas()
    {
        
        var controller = new MarcasController();

        
        var result = controller.Index(null);

        var viewResult = Assert.IsType<ViewResult>(result);
        var model = Assert.IsAssignableFrom<IEnumerable<MarcaBlanca>>(viewResult.ViewData.Model);
        Assert.NotEmpty(model);
    }
}