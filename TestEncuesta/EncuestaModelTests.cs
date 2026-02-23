using EncuestaRazorPage.Models;
using EncuestaRazorPage.Pages;
using EncuestaRazorPage.Servicios;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Moq;

namespace TestEncuesta;

[TestFixture]
public class EncuestaModelTests
{
    private Mock<IServicioEncuestas> _mockServicioEncuestas;
    private EncuestaModel _encuestaModel;

    [SetUp]
    public void Setup()
    {
        _mockServicioEncuestas = new Mock<IServicioEncuestas>();
        _encuestaModel = new EncuestaModel(_mockServicioEncuestas.Object);
    }

    [Test]
    public void OnGet_DeberiaEjecutarseSinErrores()
    {
        // Act
        _encuestaModel.OnGet();

        // Assert
        Assert.Pass();
    }

    [Test]
    public void OnPost_DeberiaAgregarEncuestaAlServicio()
    {
        // Arrange
        var encuesta = new Encuesta
        {
            Nombre = "Juan Pérez",
            Guardias = true,
            Comentarios = "Me gustaría hacer guardias"
        };
        _encuestaModel.Encuesta = encuesta;

        // Act
        var result = _encuestaModel.OnPost();

        // Assert
        _mockServicioEncuestas.Verify(x => x.Agregar(encuesta), Times.Once);
    }

    [Test]
    public void OnPost_DeberiaRedirigirAPaginaGracias()
    {
        // Arrange
        _encuestaModel.Encuesta = new Encuesta
        {
            Nombre = "María González",
            Guardias = false,
            Comentarios = "No puedo hacer guardias"
        };

        // Act
        var result = _encuestaModel.OnPost();

        // Assert
        Assert.That(result, Is.InstanceOf<RedirectToPageResult>());
        var redirectResult = result as RedirectToPageResult;
        Assert.That(redirectResult?.PageName, Is.EqualTo("Gracias"));
    }

    [Test]
    public void OnPost_ConDiferentesValores_DeberiaFuncionar()
    {
        // Arrange - caso con guardias Sí
        var encuestaSi = new Encuesta
        {
            Nombre = "Pedro López",
            Guardias = true,
            Comentarios = "Sin problemas"
        };
        _encuestaModel.Encuesta = encuestaSi;

        // Act
        var resultSi = _encuestaModel.OnPost();

        // Assert
        _mockServicioEncuestas.Verify(x => x.Agregar(encuestaSi), Times.Once);
        Assert.That(resultSi, Is.InstanceOf<RedirectToPageResult>());

        // Arrange - caso con guardias No
        _mockServicioEncuestas.Reset();
        var encuestaNo = new Encuesta
        {
            Nombre = "Ana Martínez",
            Guardias = false,
            Comentarios = "Prefiero no hacer guardias"
        };
        _encuestaModel.Encuesta = encuestaNo;

        // Act
        var resultNo = _encuestaModel.OnPost();

        // Assert
        _mockServicioEncuestas.Verify(x => x.Agregar(encuestaNo), Times.Once);
        Assert.That(resultNo, Is.InstanceOf<RedirectToPageResult>());
    }
}
