# Checklist Totem ADS Burguer

## Datas Importantes
- Prévia 26/junho
- Apresentação 30/junho
  - Duração: 25 min
  - Apresentação em Slides
  - Documentação (Engenharia de Software)
  - Demonstração (localhost)

## **Backend**
### **Models e Migrations** (100%)  
- [ ] `Category` (com auto-relacionamento)  
- [ ] `Product`  
- [ ] `Combo`  
- [ ] `Promotion`  
- [ ] `Ingredient`  
- [ ] `Additional` (relação N:N entre `Product` e `Ingredient`)  
- [ ] `Client`  
- [ ] `Employee` (herança de `Client`)  
- [ ] `Cupom`  
- [ ] `Order`  
- [ ] `Payment`  
- [ ] `OrderItem`  
- [ ] `Customize` (relação N:N entre `OrderItem` e `Ingredient`)  

### **Controllers Necessários**
#### **Área do Cliente (Totem)**
| Controller            | Métodos Principais                          | Descrição                               |
|-----------------------|---------------------------------------------|-----------------------------------------|
| `ClientController`    | `Register(clientData)`                      | Cadastro inicial do cliente (CPF/nome)  |
| `MenuController`      | `GetCategories()`, `GetProducts(categoryId)`| Listar categorias e produtos            |
| `CartController`      | `AddItem(productId)`, `UpdateItem(itemId)`, `RemoveItem(itemId)` | Gerenciar carrinho       |
| `CustomizationController` | `GetIngredients(productId)`, `ApplyCustomization(orderItemId, ingredientChanges)` | Personalizar itens |
| `OrderController`     | `ApplyCupom(code)`, `SetDeliveryType(type)`, `FinalizeOrder()` | Finalizar pedido   |
| `PaymentController`   | `ProcessPayment(orderId, method)`           | Pagamento simulado                      |

#### **Área Administrativa (CRUD)**
| Controller            | Métodos CRUD                                | Descrição                               |
|-----------------------|---------------------------------------------|-----------------------------------------|
| `CategoryController`  | `Create()`, `Edit()`, `Delete()`, `List()`  | Gerenciar categorias/subcategorias      |
| `ProductController`   | `Create()`, `Edit()`, `Delete()`, `List()`  | Produtos e combos                       |
| `PromotionController` | `Create()`, `Edit()`, `Delete()`, `List()`  | Promoções vinculadas a produtos         |
| `IngredientController`| `Create()`, `Edit()`, `Delete()`, `List()`  | Ingredientes e associações              |
| `CupomController`     | `Generate()`, `Disable()`, `List()`         | Cupons de desconto                      |
| `EmployeeController`  | `Register()`, `Edit()`, `Disable()`, `List()`| Funcionários (herdam de `Client`)       |
| `OrderAdminController`| `List()`, `UpdateStatus(orderId, status)`   | Visualizar/alterar pedidos              |


## **Frontend**
### **Telas do Totem (Cliente)**
- [ ] Identificação (`ClientController`)  
- [ ] Menu (`MenuController` + `CartController`)  
- [ ] Carrinho (`CartController` + `CustomizationController`)  
- [ ] Finalização (`OrderController` + `PaymentController`)  

### **Telas Administrativas**
- [ ] Dashboard (resumo de pedidos)  
- [ ] CRUDs (`CategoryController`, `ProductController`, etc.)  


## Fluxo de Desenvolvimento Recomendado
1. **Criar Models + DbContext** → Gerar Migrations  
2. **Implementar Controllers do Cliente** (foco no fluxo do totem)  
   - `ClientController` → `MenuController` → `CartController` → `OrderController`  
3. **Implementar Controllers Administrativos** (CRUDs básicos)  
   - Começar por `CategoryController` e `ProductController`  
4. **Frontend** (consumindo APIs/views dos controllers)  
