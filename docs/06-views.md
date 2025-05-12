# Razor Pages

**Razor Pages** é uma abordagem de desenvolvimento web no ASP.NET Core que combina a simplicidade das páginas da web com a flexibilidade do modelo de MVC (Model-View-Controller). Ao contrário do MVC, que separa o controle (Controller) e a visão (View) em arquivos diferentes, Razor Pages permite que você defina a lógica da página diretamente no arquivo da página, simplificando o processo de desenvolvimento e tornando o código mais organizado.

Em Razor Pages, cada página da web é representada por um arquivo `.cshtml`.

### Características principais:

* **Páginas e lógica combinadas**: As páginas web e sua lógica ficam no mesmo arquivo, simplificando o desenvolvimento.
* **Estrutura baseada em arquivos**: Cada Razor Page possui seu próprio arquivo `.cshtml` e um arquivo de modelo `PageModel`, onde você pode definir as ações e propriedades da página.
* **Fácil navegação e roteamento**: O roteamento é baseado na estrutura do diretório, facilitando a navegação entre as páginas.

### Exemplo:

O código abaixo é um exemplo de uma **Razor Page** que renderiza um menu de categorias e produtos para o Totem.

```cshtml
@{
    ViewData["Title"] = "Menu"; // Define o título da página
}

<!DOCTYPE html>
<html lang="pt-BR">
<head>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>@ViewData["Title"]</title> <!-- Renderiza o título definido no ViewData -->
    <link rel="stylesheet" href="~/css/site.css" asp-append-version="true" />
    <link rel="icon" type="image/png" href="~/img/favicon.png" />
</head>

<body>

    <div class="header">
        <img src="~/img/logotipo.jpeg" alt="Logo do Restaurante">
    </div>

    <div class="main-content">
        <div class="sidebar">
            @foreach (var category in ViewBag.Categories) // Itera sobre as categorias
            {
                string activeClass = category.active ? "active" : ""; // Define a classe "active" se a categoria estiver ativa
                <a href="/Menu/@category.id" class="category-btn @activeClass"> <!-- Gera o link da categoria com a classe condicional -->
                    <span class="icon">🍕</span>
                    <span class="label">@category.name</span> <!-- Nome da categoria -->
                </a>
            }
        </div>

        <div class="menu-section">
            <div class="subcategory-bar">
                @foreach (var subcategory in ViewBag.SubCategories) // Itera sobre as subcategorias
                {
                    string activeClass = subcategory.active ? "active" : ""; // Classe "active" se a subcategoria estiver ativa
                    <a href="/Menu/@ViewBag.Category/@subcategory.id" class="subcategory-btn @activeClass"> <!-- Link com categoria e subcategoria -->
                        <span class="label">@subcategory.name</span> <!-- Nome da subcategoria -->
                    </a>
                }
            </div>

            <div class="menu-container">
                @foreach (var product in ViewBag.Products) // Itera sobre os produtos
                {
                    <div class="menu-item">
                        <img src="https://fakeimg.pl/60x60/?retina=1&text=%F0%9F%8D%95" alt="@product.name"> <!-- Imagem com alt dinâmico -->
                        <div class="options">
                            <h3>@product.name</h3> <!-- Nome do produto -->
                            <p>Descrição</p> <!-- Descrição estática -->
                            <strong>
                                @product.price.ToString("C", System.Globalization.CultureInfo.GetCultureInfo("pt-BR")) 
                                // Preço formatado em Real brasileiro
                            </strong>
                        </div>
                    </div>
                }
            </div>
        </div>
    </div>

    <div class="footer">
        <p>Total do Pedido: <strong>R$ 0,00</strong></p>
    </div>

</body>
</html>
```

### Explicação:

1. **Diretiva `@{ ... }`**: Aqui, o título da página é definido dinamicamente no Razor com `ViewData["Title"] = "Menu";`. Esse valor será usado no título da página HTML.

2. **Uso de `ViewData` e `ViewBag`**:

   * `ViewData["Title"]`: Armazena o título da página, acessado no HTML com `@ViewData["Title"]`.
   * `ViewBag.Categories`, `ViewBag.SubCategories`, `ViewBag.Products`: São usados para passar listas de dados da lógica do servidor para a página. Esses dados poderiam ser definidos no controlador ou na página Model associada à Razor Page.

3. **Estrutura HTML**:

   * A página é estruturada com um cabeçalho (`header`), conteúdo principal (`main-content`), e um rodapé (`footer`).
   * **Sidebar**: Contém links para categorias de produtos. A classe `active` é aplicada dinamicamente se a categoria estiver ativa.
   * **Menu Section**: Exibe as subcategorias e produtos. Cada produto é listado com uma imagem, nome e preço formatado.

4. **Formatação de Preço**: O preço do produto é formatado em Real brasileiro com `ToString("C", System.Globalization.CultureInfo.GetCultureInfo("pt-BR"))`.
