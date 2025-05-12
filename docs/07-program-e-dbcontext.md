# Conceitos de Programação Orientada a Objetos

Nos arquivos `Program.cs` e `ApplicationDbContext.cs`, podemos identificar vários conceitos de **Programação Orientada a Objetos (POO)** sendo aplicados. Abaixo estão os principais conceitos de POO encontrados:

## 1. **Encapsulamento**

* **Definição**: O encapsulamento é o princípio da POO que envolve a ocultação dos detalhes internos de implementação de uma classe e a exposição apenas de uma interface pública, permitindo que o código externo interaja com o objeto de maneira controlada.
* **Exemplo no código**:

  * O `DbContext` (classe base para `ApplicationDbContext`) encapsula a lógica de acesso e manipulação do banco de dados. O código externo interage com o `DbContext` e suas propriedades (`DbSet<Category> Categories`, `DbSet<Product> Products`, etc.) sem precisar saber como os dados são armazenados ou acessados internamente.
  * **Exemplo**:

    ```csharp
    public DbSet<Category> Categories { get; set; }
    public DbSet<Product> Products { get; set; }
    ```

    Essas propriedades são a interface pública do `ApplicationDbContext`, mas os detalhes de como as entidades são persistidas são ocultados dentro da classe `DbContext`.

---

## 2. **Herança**

* **Definição**: A herança é um mecanismo que permite que uma classe derive de outra, herdando seus atributos e comportamentos (métodos), promovendo a reutilização de código.
* **Exemplo no código**:

  * A classe `ApplicationDbContext` herda de `DbContext`, permitindo que ela utilize toda a funcionalidade do Entity Framework Core para interação com o banco de dados, sem precisar reimplementar esse comportamento.
  * **Exemplo**:

    ```csharp
    public class ApplicationDbContext : DbContext
    ```

    A classe `ApplicationDbContext` herda todas as funcionalidades do `DbContext` e, além disso, define as suas próprias propriedades (como `DbSet<Category>`) e personaliza o comportamento da interação com o banco de dados.

---

## 3. **Polimorfismo**

* **Definição**: Polimorfismo é o princípio da POO que permite que objetos de diferentes classes sejam tratados de maneira uniforme, por meio de uma interface comum ou método sobrecarregado.
* **Exemplo no código**:

  * No código, temos o método `OnModelCreating(ModelBuilder modelBuilder)` da classe `DbContext`, que é sobrescrito na classe `ApplicationDbContext`. Esse é um exemplo clássico de polimorfismo, onde a classe derivada fornece uma implementação específica para um método da classe base.
  * **Exemplo**:

    ```csharp
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        // Customização específica
    }
    ```

    O método `OnModelCreating` é definido na classe base `DbContext` e é sobrescrito na classe derivada `ApplicationDbContext` para personalizar o comportamento do modelo de dados.

---

## 4. **Abstração**

* **Definição**: A abstração é o processo de simplificar sistemas complexos, ocultando detalhes desnecessários e expondo apenas o que é relevante. Em POO, a abstração é frequentemente implementada por meio de classes e interfaces.
* **Exemplo no código**:

  * O `DbContext` é uma abstração de todo o processo de interação com o banco de dados. O desenvolvedor não precisa saber como o banco de dados é acessado ou como as consultas são geradas, apenas interage com a abstração fornecida pelas propriedades do `DbContext` e pelas entidades (`Category`, `Product`, `Variation`).
  * **Exemplo**:

    ```csharp
    public DbSet<Category> Categories { get; set; }
    ```

    `DbSet` é uma abstração que permite realizar operações de banco de dados de maneira simplificada. A abstração ajuda a manter o código mais limpo e fácil de entender.

---

## 5. **Composição**

* **Definição**: Composição é o processo em que um objeto é composto por outros objetos. Em vez de herdar de uma classe, o objeto "tem" outro objeto como parte de sua estrutura.
* **Exemplo no código**:

  * A classe `Category` provavelmente possui uma propriedade de composição de outras instâncias de `Category` (por exemplo, categorias pai e subcategorias). Isso é configurado no método `OnModelCreating`.
  * **Exemplo**:

    ```csharp
    modelBuilder.Entity<Category>()
        .HasOne(c => c.ParentCategory)
        .WithMany(c => c.Subcategories)
        .HasForeignKey(c => c.ParentCategoryId)
        .OnDelete(DeleteBehavior.NoAction);
    ```

    Aqui, a `Category` tem uma relação de composição com `ParentCategory` e `Subcategories`, que são instâncias de `Category` associadas entre si.

---

## 6. **Dependência e Injeção de Dependência**

* **Definição**: A injeção de dependência é um padrão de design que permite que uma classe receba suas dependências de forma externa, ao invés de criá-las internamente. Isso promove um código mais modular, testável e desacoplado.
* **Exemplo no código**:

  * O uso de `AddDbContext<ApplicationDbContext>` no `Program.cs` é um exemplo de injeção de dependência. O `ApplicationDbContext` é injetado automaticamente quando necessário na aplicação.
  * **Exemplo**:

    ```csharp
    builder.Services.AddDbContext<ApplicationDbContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
    ```

    Isso garante que o `ApplicationDbContext` seja instanciado de forma controlada e possa ser utilizado em qualquer parte da aplicação onde for necessário, sem acoplamento direto entre as classes.

---

# Resumo dos Conceitos POO:

1. **Encapsulamento**: Controle da visibilidade dos dados e operações, expondo apenas o necessário.
2. **Herança**: Capacidade de uma classe herdar características de outra, promovendo reutilização de código.
3. **Polimorfismo**: Capacidade de métodos em diferentes classes responderem de maneira diferente à mesma chamada.
4. **Abstração**: Ocultação de detalhes de implementação, permitindo interação através de interfaces ou métodos simplificados.
5. **Composição**: Relação entre objetos, onde um objeto contém outro para formar uma estrutura mais complexa.
6. **Injeção de Dependência**: Técnica para fornecer objetos necessários a uma classe de fora, promovendo modularidade e testabilidade.

Esses conceitos ajudam a manter o código mais organizado, reutilizável, testável e com menos acoplamento entre os componentes do sistema.


## `Program.cs`

```csharp
using Microsoft.EntityFrameworkCore; 
// Importa a biblioteca necessária para utilizar o Entity Framework Core (EF Core) e sua funcionalidade de manipulação de banco de dados.

using TotemPWA.Data;
// Importa o namespace do projeto onde se encontra o contexto do banco de dados (ApplicationDbContext).

var builder = WebApplication.CreateBuilder(args);
// Cria um objeto builder para configurar os serviços e o pipeline da aplicação.

builder.Services.AddControllersWithViews();
// Adiciona os serviços necessários para controladores (controllers) com suporte a views, usados em aplicações MVC.

    // .AddJsonOptions(options =>
    //     {
    //         options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
    //         options.JsonSerializerOptions.MaxDepth = 4;
    //     });
// Comentado, mas caso ativado, configuraria o serializador JSON para gerenciar referências e profundidade de objetos.

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
// Adiciona o contexto do banco de dados ao contêiner de injeção de dependências, configurando o uso do SQL Server com a string de conexão do arquivo de configuração.

builder.Services.AddEndpointsApiExplorer();
// Adiciona suporte à exploração de endpoints, usado principalmente para gerar documentação da API.

builder.Services.AddSwaggerGen();  
// Adiciona o Swagger para a documentação da API.

var app = builder.Build();
// Cria a aplicação a partir do builder configurado.

using (var scope = app.Services.CreateScope()) 
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<ApplicationDbContext>();
    // Cria um escopo para injeção de dependências e recupera o contexto do banco de dados.

    // Apaga o banco de dados completamente
    // context.Database.EnsureDeleted(); 
    // Comentado, mas caso ativado, apagaria o banco de dados.

    // Aplica as migrações do zero
    context.Database.Migrate();       
    // Aplica as migrações pendentes no banco de dados.

    // Executa o Seed (inicialização de dados)
    // await DbInitializer.InitializeAsync(context);
    // Comentado, mas executaria a inicialização de dados do banco (ex: inserir dados iniciais ou padrões).
}

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // Define uma rota para tratamento de exceções em produção.

    app.UseHsts();
    // Ativa HTTP Strict Transport Security (HSTS) para aumentar a segurança.
}

app.UseSwagger();  
// Habilita o Swagger para expor a documentação da API.

app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "TotemPWA API v1"));  
// Configura a interface do Swagger para visualizar a documentação gerada.

app.UseHttpsRedirection();
// Força redirecionamento de HTTP para HTTPS para melhorar a segurança.

app.UseRouting();
// Ativa o roteamento de requisições (permite que o sistema determine qual controlador/rota será executada).

app.UseAuthorization();
// Ativa a autorização para garantir que os usuários tenham permissões adequadas.

app.MapStaticAssets();
// Mapeia arquivos estáticos, como CSS, JS, imagens, etc.

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();
// Define a rota padrão para os controladores, com suporte a assets estáticos.

app.Run();
// Inicia a aplicação.
```

# Teoria: Conceitos no `Program.cs`

1. **Injeção de Dependência (DI)**: O método `builder.Services.AddDbContext<ApplicationDbContext>()` é um exemplo de como a injeção de dependência funciona no ASP.NET Core. Ele permite que o contexto do banco de dados (`ApplicationDbContext`) seja injetado automaticamente nos controladores ou outros serviços quando necessário.

2. **Migrations**: `context.Database.Migrate()` aplica as migrações que são mudanças estruturais no banco de dados, garantindo que o banco de dados esteja atualizado com a estrutura definida no código.

3. **Swagger**: O Swagger é uma ferramenta de documentação interativa para APIs REST. O comando `builder.Services.AddSwaggerGen()` configura o Swagger, e `app.UseSwagger()` permite que a documentação seja acessada na aplicação.

4. **HSTS (HTTP Strict Transport Security)**: O `app.UseHsts()` garante que a aplicação só será acessada via HTTPS, aumentando a segurança contra ataques de downgrade (como o ataque Man-in-the-Middle).

5. **Roteamento**: `app.UseRouting()` permite o roteamento das requisições, ou seja, direciona as requisições para o controlador ou endpoint adequado.

---

## `ApplicationDbContext.cs`

```csharp
using Microsoft.EntityFrameworkCore;
using TotemPWA.Models;
// Importa as bibliotecas necessárias para o Entity Framework Core e as classes de modelo.

namespace TotemPWA.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        // Construtor que recebe opções de configuração e passa para a classe base DbContext.

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Variation> Variations { get; set; }
        // Propriedades do tipo DbSet representam tabelas no banco de dados.
        // O DbSet permite operações de CRUD sobre essas entidades.

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Chama a implementação base para garantir o comportamento padrão.

            // Define relacionamento autorreferenciado para Categoria
            modelBuilder.Entity<Category>()
                .HasOne(c => c.ParentCategory)
                .WithMany(c => c.Subcategories)
                .HasForeignKey(c => c.ParentCategoryId)
                .OnDelete(DeleteBehavior.NoAction);  // Permite que a categoria pai seja nula

            // Define relacionamento de 1 para muitos entre Produto e Categoria
            modelBuilder.Entity<Product>()
                .HasOne(p => p.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);

            // Define relacionamento de 1 para muitos entre Produto e Variação
            modelBuilder.Entity<Variation>()
                .HasOne(v => v.Product)
                .WithMany(p => p.Variations)
                .HasForeignKey(v => v.ProductId);

            // Define tipo de dados decimal para preço de Produto e Variação
            modelBuilder.Entity<Product>()
                .Property(p => p.Price)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Variation>()
                .Property(v => v.AdditionalPrice)
                .HasColumnType("decimal(18,2)");
        }
    }
}
```

# Teoria: Conceitos no `ApplicationDbContext.cs`

1. **DbContext**: O `DbContext` é a classe fundamental para interagir com o banco de dados usando o Entity Framework Core. Ele define as tabelas e mapeia as entidades para essas tabelas. `ApplicationDbContext` herda de `DbContext` e fornece o mapeamento de entidades como `Category`, `Product`, e `Variation`.

2. **DbSet**: As propriedades do tipo `DbSet` representam as coleções de entidades que serão mapeadas para tabelas no banco de dados. Por exemplo, `public DbSet<Category> Categories` mapeia a tabela de categorias.

3. **Relacionamentos entre Entidades**: O código configura relacionamentos entre as entidades, como:

   * `HasOne().WithMany()`: Define relacionamentos de 1 para muitos entre as entidades.
   * `HasForeignKey()`: Define a chave estrangeira para um relacionamento.
   * `OnDelete(DeleteBehavior.NoAction)`: Define o comportamento de exclusão, que pode ser `NoAction`, `Cascade`, etc., controlando o que acontece quando uma entidade relacionada é excluída.

4. **OnModelCreating**: Este método permite configurar o mapeamento de entidades, relacionamentos, tipos de dados e outras configurações específicas do banco de dados no EF Core.
