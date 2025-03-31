# Sprint 01

## 24/fev/2025 - Tarefa 01

### Desenvolvimento de Páginas Inicialmente Estáticas  

O Scrum Master **está responsável por** delegar a criação de duas páginas essenciais para o projeto:  

1. **Página Inicial (Landing - Iniciar Pedido)**  
   - Criar uma página inicial atraente e funcional, onde os usuários possam iniciar um pedido com facilidade.  
   - O design deve ser responsivo e intuitivo, garantindo uma boa experiência do usuário.  
   - Deve conter um botão de destaque para iniciar o pedido, além de uma breve apresentação do sistema.  

2. **Página de Produtos**  
   - Implementar uma estrutura com os seguintes componentes:  
     - **Header**: Contendo o nome do sistema e possíveis atalhos ou informações relevantes.  
     - **Navigation (lateral esquerda)**: Menu para facilitar a navegação entre categorias de produtos.  
     - **Grid de Produtos**: Exibição dos produtos disponíveis ao lado da Navigation, seguindo um layout organizado.  
     - **Footer**: Informações adicionais, como termos de uso, suporte e contatos.  

Para a implementação, **será necessário criar ou modificar** arquivos da **View** (páginas e layouts), do **Controller** e dos **estilos CSS**, garantindo que o desenvolvimento esteja alinhado com a arquitetura e a identidade visual do projeto.  

Cada desenvolvedor deverá seguir as tarefas designadas pelo Scrum Master, assegurando a coerência com os requisitos de design e usabilidade estabelecidos pelo time.


## 10/mar/2025 - Tarefa 02


### Requisitos Funcionais e Não Funcionais

Com base na entrevista e no brainstorm feitos anteriormente, organizar 

|   ID  |  Descrição  |
| ----- | ----------- |
| RF01  | Requisito Funcional 01  |
| RF02  | Requisito Funcional 02  |


|   ID  |  Descrição  |
| ----- | ----------- |
| RNF01  | Requisito Não Funcional 01  |
| RNF02  | Requisito Não Funcional 02  |

### User Histories

1. Cliente
- Realiza pedidos pelo totem.
- Personaliza ingredientes do lanche.
- Efetua pagamento via Pix ou cartão.
- Acompanha o tempo estimado de preparo.

2. Atendente
- Gerencia pedidos e pode editá-los, se necessário.
- Monitora pagamentos e confirma pedidos.
- Atualiza status dos pedidos (em preparo, pronto, retirado).

3. Administrador
- Cadastra e gerencia produtos do cardápio.
- Define promoções e preços.
- Acompanha relatórios de vendas e desempenho do sistema.

Gerar as User Histories baseadas nas funcionalidades, por exemplo:

1. Autenticação e Controle de Acesso
- Como administrador, quero acessar o painel de gerenciamento do totem, para que eu possa cadastrar e editar produtos.
- Como cliente, quero fazer meu pedido sem precisar de login, para que o processo seja mais rápido.

2. Exibição do Cardápio
- Como cliente, quero visualizar os hambúrgueres disponíveis com imagens e descrições, para que eu possa escolher facilmente.
- Como cliente, quero filtrar hambúrgueres por categoria (ex: tradicional, gourmet, vegetariano), para que eu encontre mais rápido o que desejo.

3. Montagem do Pedido
- Como cliente, quero adicionar itens ao carrinho com opções de personalização (ex: sem cebola, queijo extra), para que eu tenha um pedido personalizado.
- Como cliente, quero visualizar um resumo do meu pedido antes de confirmar, para que eu possa revisar antes de pagar.

4. Pagamento e Finalização do Pedido
- Como cliente, quero escolher entre pagamento com cartão ou QR Code Pix, para que eu possa pagar da maneira mais conveniente.
- Como cliente, quero receber um número de pedido após pagar, para que eu saiba quando meu pedido estiver pronto.

5. Gestão de Pedidos
- Como atendente, quero visualizar todos os pedidos em andamento, para que eu possa gerenciá-los e preparar os lanches.
- Como administrador, quero acessar um histórico de pedidos, para que eu possa analisar o desempenho de vendas.


## 24/mar/2025 - Tarefa 03

### Construir páginas (ou popup) estáticas

- Seleção do item
- Carrinho listando pedidos
- Personalização de ingredientes