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
public class Category
```

Define a entidade **Categoria**, usada para organizar produtos de forma hierárquica.

> Exemplifica **composição** em OOP, pois contém subcategorias e produtos.

```csharp
public int Id { get; set; }
```

Identificador único da categoria (chave primária).

```csharp
public required string Name { get; set; }
```

Nome da categoria. A anotação `required` indica que o valor é obrigatório (C# 11+).

```csharp
public int? ParentCategoryId { get; set; }
```

Referência opcional à categoria pai (categoria hierarquicamente superior).

```csharp
[JsonIgnore]
public Category? ParentCategory { get; set; }
```

Objeto que representa a categoria pai. A anotação `[JsonIgnore]` evita que essa propriedade seja serializada em JSON (ex: para prevenir loops).

```csharp
public ICollection<Category> Subcategories { get; set; } = new List<Category>();
```

Lista de subcategorias associadas a esta categoria. Inicializada como lista vazia.

```csharp
public ICollection<Product> Products { get; set; } = new List<Product>();
```

Lista de produtos associados diretamente a esta categoria. Também inicializada como lista vazia.

---

### Classe `Product`

```csharp
public class Product
```

Define a entidade **Produto**, representando um item comercializável no sistema.

```csharp
public int Id { get; set; }
```

Identificador único do produto.

```csharp
public required string Name { get; set; }
```

Nome do produto. Também obrigatório.

```csharp
public decimal Price { get; set; }
```

Preço base do produto (sem variações).

```csharp
public int CategoryId { get; set; }
```

Chave estrangeira que relaciona o produto à sua categoria.

```csharp
[JsonIgnore]
public Category? Category { get; set; }
```

Objeto da categoria associada ao produto. Ignorado na serialização JSON.

```csharp
public ICollection<Variation> Variations { get; set; } = new List<Variation>();
```

Lista de variações disponíveis para este produto (ex: tamanhos, adicionais). Inicializada vazia.

---

### Classe `Variation`

```csharp
public class Variation
```

Define a entidade **Variação**, usada para representar diferentes versões de um produto.

```csharp
public int Id { get; set; }
```

Identificador único da variação.

```csharp
public required string Description { get; set; }
```

Descrição da variação (ex: "Tamanho Grande", "Extra Bacon").

```csharp
public decimal AdditionalPrice { get; set; }
```

Preço adicional cobrado por esta variação.

```csharp
public int ProductId { get; set; }
```

Chave estrangeira que associa a variação ao seu produto principal.

```csharp
[JsonIgnore]
public Product Product { get; set; }
```

Objeto do produto relacionado a esta variação. Também ignorado na serialização JSON.

---

## Observações

* As anotações `[JsonIgnore]` são utilizadas para evitar ciclos de referência durante a serialização, especialmente útil ao retornar os dados por uma API.
* O uso de `required` impõe regras de validação para propriedades obrigatórias na criação de objetos.
* As listas (`ICollection<T>`) são inicializadas no momento da declaração para evitar erros de referência nula.
