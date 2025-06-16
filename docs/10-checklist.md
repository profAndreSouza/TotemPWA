# Checklist Totem ADS Burguer

## Datas Importantes
- Prévia 23/junho
- Apresentação 30/junho
  - Duração: 25 min
  - Apresentação em Slides
  - Documentação (Engenharia de Software)
  - Demonstração (localhost)

## **Backend**
### **Models e Migrations** (100%)  
- [x] `Category` (com auto-relacionamento)  
- [x] `Product`  
- [x] `Combo`  
- [x] `Promotion`  
- [x] `Ingredient`  
- [x] `Additional` (relação N:N entre `Product` e `Ingredient`)  
- [x] `Client`  
- [x] `Employee` (herança de `Client`)  
- [x] `Cupom`  
- [x] `Order`  
- [x] `Payment`  
- [x] `OrderItem`  
- [x] `Customize` (relação N:N entre `OrderItem` e `Ingredient`)  

### **Controllers Necessários**
#### **Área do Cliente (Totem)**
| Controller            | Métodos Principais                          | Descrição                               |
|-----------------------|---------------------------------------------|-----------------------------------------|
| [ ] `ClientController`    | `Register(clientData)`                      | Cadastro inicial do cliente (CPF/nome)  |
| [ ] `MenuController`      | `GetCategories()`, `GetProducts(categoryId)`| Listar categorias e produtos            |
| [ ] `CartController`      | `AddItem(productId)`, `UpdateItem(itemId)`, `RemoveItem(itemId)` | Gerenciar carrinho       |
| [ ] `CustomizationController` | `GetIngredients(productId)`, `ApplyCustomization(orderItemId, ingredientChanges)` | Personalizar itens |
| [ ] `OrderController`     | `ApplyCupom(code)`, `SetDeliveryType(type)`, `FinalizeOrder()` | Finalizar pedido   |
| [ ] `PaymentController`   | `ProcessPayment(orderId, method)`           | Pagamento simulado                      |

#### **Área Administrativa (CRUD)**
| Controller                | Métodos CRUD                                 | Descrição                               |
|---------------------------|----------------------------------------------|-----------------------------------------|
| [x] `CategoryController`  | `Create()`, `Edit()`, `Delete()`, `List()`   | Gerenciar categorias/subcategorias      |
| [x] `ProductController`   | `Create()`, `Edit()`, `Delete()`, `List()`   | Produtos e combos                       |
| [x] `PromotionController` | `Create()`, `Edit()`, `Delete()`, `List()`   | Promoções vinculadas a produtos         |
| [x] `IngredientController`| `Create()`, `Edit()`, `Delete()`, `List()`   | Ingredientes e associações              |
| [x] `CupomController`     | `Create()`, `Edit()`, `Delete()`, `List()`   | Cupons de desconto                      |
| [ ] `EmployeeController`  | `Register()`, `Edit()`, `Disable()`, `List()`| Funcionários (herdam de `Client`)       |
| [ ] `OrderAdminController`| `List()`, `UpdateStatus(orderId, status)`    | Visualizar/alterar pedidos              |


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
