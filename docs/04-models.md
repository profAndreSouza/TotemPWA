# TotemPWA.Models

Este módulo define as entidades principais usadas no sistema do Totem Interativo (PWA). As classes modelam categorias, produtos e variações de produtos com base nos princípios da Programação Orientada a Objetos (OOP).

---

## O que são Classes em Orientação a Objetos?

**Classes** são estruturas fundamentais na **Programação Orientada a Objetos (OOP)**. Elas representam **modelos** ou **projetos** de entidades do mundo real, como pessoas, produtos ou categorias. Cada classe define as **propriedades** (atributos) e **comportamentos** (métodos) que os objetos daquela classe terão.

> Em termos simples: **uma classe é como uma planta (blueprint)**; um **objeto é a casa construída a partir dela**.

### Componentes de uma classe:

* **Propriedades**: dados que descrevem o objeto (ex: `Name`, `Price`).
* **Métodos**: ações que o objeto pode realizar (não incluídos neste exemplo).
* **Construtores**: inicializam novos objetos (neste caso, usamos inicialização direta com listas).

### Benefícios da OOP:

* **Reutilização** de código via herança
* **Organização** mais clara e modular
* **Encapsulamento**: oculta detalhes internos dos objetos
* **Facilidade de manutenção** e escalabilidade do sistema

---

## Pasta: `Models`

### Classe `Category`

```csharp
// Define a entidade Categoria, que pode ter subcategorias e produtos.
public class Category
{
    // Identificador único da categoria (chave primária).
    public int Id { get; set; }

    // Nome da categoria (obrigatório).
    public required string Name { get; set; }

    // Referência opcional à categoria pai.
    public int? ParentCategoryId { get; set; }

    // Objeto da categoria pai. Ignorado no JSON para evitar loops de serialização.
    [JsonIgnore]
    public Category? ParentCategory { get; set; }

    // Lista de subcategorias relacionadas a esta categoria.
    public ICollection<Category> Subcategories { get; set; } = new List<Category>();

    // Lista de produtos que pertencem a esta categoria.
    public ICollection<Product> Products { get; set; } = new List<Product>();
}
```

---

### Classe `Product`

```csharp
// Define a entidade Produto, que pertence a uma categoria e pode ter variações.
public class Product
{
    // Identificador único do produto.
    public int Id { get; set; }

    // Nome do produto (obrigatório).
    public required string Name { get; set; }

    // Preço base do produto (sem adicionais).
    public decimal Price { get; set; }

    // Chave estrangeira para a categoria associada.
    public int CategoryId { get; set; }

    // Objeto da categoria associada. Ignorado no JSON para evitar recursão.
    [JsonIgnore]
    public Category? Category { get; set; }

    // Lista de variações possíveis para o produto.
    public ICollection<Variation> Variations { get; set; } = new List<Variation>();
}
```

---

### Classe `Variation`

```csharp
// Define a entidade Variação, que representa um complemento ou versão do produto.
public class Variation
{
    // Identificador único da variação.
    public int Id { get; set; }

    // Descrição da variação (ex: "Grande", "Extra Bacon").
    public required string Description { get; set; }

    // Preço adicional cobrado por essa variação.
    public decimal AdditionalPrice { get; set; }

    // Chave estrangeira para o produto relacionado.
    public int ProductId { get; set; }

    // Objeto do produto associado. Ignorado na serialização JSON.
    [JsonIgnore]
    public Product Product { get; set; }
}
```

---

## Observações

* As anotações `[JsonIgnore]` são utilizadas para evitar ciclos de referência durante a serialização, especialmente útil em APIs REST.
* O uso de `required` (disponível a partir do C# 11) assegura que os campos obrigatórios sejam fornecidos na criação de objetos.
* As listas são inicializadas diretamente nas propriedades para evitar exceções de referência nula.
