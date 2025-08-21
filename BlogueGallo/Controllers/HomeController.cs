using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using BlogueGallo.Models;

namespace BlogueGallo.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private List<Categoria> Categorias;
    private List<Postagem> postagens;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
        Categoria tecnologia = new();
        tecnologia.Id = 1;
        tecnologia.Nome = "Tecnologia";

        Categoria ia = new(){
            Id = 2,
            Nome = "Casa"
        };
        
        Categoria design = new(3,"Design");
       postagens = [

            new() {
                Id = 2,
                Nome = "Atibaia/SP",
                CategoriaId = 2,
                Categoria = ia,
                DataPostagem = DateTime.Parse("08/08/2025"),
                Descricao = "Casa Alto Padrão - Terreno 4.000m² - Área de Lazer",
                Texto = " Casa de Alto Padrão, terreno c/ 4.000m², Rua José Paschoal Capello, nº 86, Vila Santista, situado na Chácara Beiral das Pedras, Bairro do Marmeleiro, perímetro urbano do município e comarca de Atibaia. Imóvel matriculado sob o nº 22.778 do 1° Cartório de Registro de Imóveis de Atibaia/SP. (Proc. 0160772-60.2002.8.26.0100)<br> <br>AVALIAÇÃO: R$ 5.611.754,11 | <br> <br>LANCE MÍNIMO: R$ 4.208.815,58 <br> <br> (O IMÓVEL PODE SER PARCELADO COM 25% DE ENTRADA E O RESTANTE EM ATÉ 30 MESES)",
                Thumbnail = "/img/casa2.jpg",
                Foto = "/img/casa2.jpg"
            },
            new() {
                Id = 3,
                Nome = "São Carlos/SP",
                CategoriaId = 2,
                Categoria = ia,
                DataPostagem = DateTime.Parse("08/08/2025"),
                Descricao = "Sobrado e piscina - 291,25m² -Terreno - 500m² -São Carlos/SP",
                Texto = "Sobrado e piscina c/ 291,25m², terreno c/ 500m², à Rua Doutor Astor Dias de Andrade n° 1.790, Vila Faria, São Carlos/SP. Imóveis matriculado sob os nº 52.334 e 35.304 do Cartório de Registro de Imóveis da Comarca de São Carlos/SP. (Proc. 1009362-33.2018.8.26.0566) <br> <br> AVALIAÇÃO: R$ 800.445,07 |<br> <br> LANCE MÍNIMO: R$ 480.267,04 <br> <br>(O IMÓVEL PODE SER PARCELADO COM 25% DE ENTRADA E O RESTANTE EM ATÉ 30 MESES)",
                Thumbnail = "/img/casa3.jpg",
                Foto = "/img/casa3.jpg"
            },
            new() {
                Id = 4,
                Nome = "Atibaia/SP",
                CategoriaId = 2,
                Categoria = ia,
                DataPostagem = DateTime.Parse("08/08/2025"),
                Descricao = "Casa - 237,15m² - Terreno - 480m²",
                Texto = "Parte ideal correspondente à 50% do prédio residencial com área de 237,15m², terreno com 480m², lote 12, da quadra 31, situado na Rua Araraquara, nº 137, Jardim Paulista, Atibaia/SP. Imóvel matriculado sob o nº 44.061, no Cartório de Registro de Imóveis de Atibaia/SP. (Proc. 0004351-66.2023.8.26.0048) <br> <br> AVALIAÇÃO: R$ 531.460,34 | <br> <br> LANCE MÍNIMO: R$ 372.022,23 <br> <br> (O IMÓVEL PODE SER PARCELADO COM 25% DE ENTRADA E O RESTANTE EM ATÉ 30 MESES)",
                Thumbnail = "/img/casa4.jpg",
                Foto = "/img/casa4.jpg"
            },
            new() {
                Id = 5,
                Nome = "Ourinhos/SP",
                CategoriaId = 2,
                Categoria = ia,
                DataPostagem = DateTime.Parse("08/08/2025"),
                Descricao = "Terreno - 306,30m² - Casa - 59,85m² - Ourinhos/SP",
                Texto = "Fração ideal 306,30 m² do terreno (total de 456,89 m²), sobre o qual se encontra construído um  imóvel residencial c/ área edificada de 59,85 m²,  lote nº 1 da quadra nº 68 Rua José Luiz  Lemos Medalha, Loteamento “PARQUE MINAS  GERAIS”, Ourinhos/SP, CRI 10.361. (Proc. 1005221-62.2015.8.26.0408) <br> <br> AVALIAÇÃO: R$ 242.479,41 | <br> <br> LANCE MÍNIMO: R$ 121.239,70 <br> <br> Valor de avaliação atualizado para R$ 242.479,41 em 23/07/2025, com base nos índices da Tabela Prática do Tribunal de Justiça do Estado de São Paulo.",
                Thumbnail = "/img/casa1.jpg",
                Foto = "/img/casa1.jpg"
            },
        
        ];
    }

    public IActionResult Index()
    {
        

      
        return View(postagens);
    }

    public IActionResult Postagem(int id)
    {   
        var postagem = postagens
            .Where(p => p.Id == id)
            .SingleOrDefault();
        if (postagem == null)
            return NotFound();
        return View(postagem);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
