# ** Git Flow e Outros**

## **1. Uso do Git Flow**

### **1.1 Inicialização do Repositório**
```sh
git init
```

### **1.2 Configuração do Git Flow**
```sh
git flow init
```

### **1.3 Criando uma Nova Feature**
```sh
git flow feature start minha-feature
```

### **1.4 Finalizando uma Feature**
```sh
git flow feature finish minha-feature
```

### **1.5 Criando um Release**
```sh
git flow release start v1.0.0
```

### **1.6 Finalizando um Release**
```sh
git flow release finish v1.0.0
```

### **1.7 Correção de Bugs (Hotfix)**
```sh
git flow hotfix start correção-importante
```

### **1.8 Finalizando um Hotfix**
```sh
git flow hotfix finish correção-importante
```

## **2. Comandos Essenciais do C#**

### **2.1 Compilação e Execução**
```sh
# Compilar um arquivo C#
dotnet build

# Compilar e executar o programa
dotnet run

# Compilar e executar o programa visualizando as edições
dotnet watch run
```

### **2.2 Gerenciamento de Pacotes com NuGet**
```sh
# Instalar um pacote
nuget install <pacote>

# Restaurar pacotes
nuget restore
```


### **2.3`UrlHelper.Action`**

**Documentação**: [Microsoft Learn](https://learn.microsoft.com/pt-br/dotnet/api/system.web.mvc.urlhelper.action?view=aspnet-mvc-5.2)  

#### Descrição  
O método `Action` gera uma URL totalmente qualificada para um método de ação, utilizando o nome da ação e do controlador especificados.  

#### Assinatura  
```csharp
public virtual string Action (string actionName, string controllerName);
```  

#### Parâmetros  
- **`actionName` (String)** – Nome do método de ação.  
- **`controllerName` (String)** – Nome do controlador.  

#### Retorno  
- **(String)** – Retorna a URL totalmente qualificada para o método de ação.

