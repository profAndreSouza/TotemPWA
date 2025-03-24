# 1. Técnicas de Levantamento de Requisitos

## 1.1 – Entrevista

**Perguntas e Respostas:**
- **Pergunta 1:** Quais são os principais desafios no atendimento ao cliente?
  - *Resposta:* Temos um grande fluxo de clientes nos horários de pico, e isso gera filas no caixa.
- **Pergunta 2:** Como funciona atualmente o processo de pedidos?
  - *Resposta:* O atendente anota manualmente ou o cliente escolhe no balcão. Depois, o pedido é inserido no sistema.

**Requisitos levantados:**
- O sistema deve permitir que o cliente faça pedidos sem precisar de um atendente.
- Deve haver integração com um sistema de pagamento.

---

## 1.2 – Brainstorming

**Ideias levantadas:**
- Totem deve permitir pedidos personalizados (ex: sem cebola, extra bacon).
- O pagamento pode ser feito via Pix ou Cartão.
- Deve exibir tempo estimado de preparo.
- Deve permitir pedidos para retirada ou consumo no local.

**Requisitos levantados:**
- O sistema deve permitir que o cliente personalize ingredientes do pedido.
- O cliente deve escolher entre retirada e consumo no local.
- O tempo estimado de preparo deve ser exibido antes da finalização do pedido.

---

# 2. Classificação de Requisitos

### 2.1 – Requisitos Funcionais

| **ID**   | **Requisito Funcional** |
|---------|------------------------|
| RF-01   | O sistema deve permitir que clientes visualizem o cardápio no totem. |
| RF-02   | O sistema deve permitir que clientes adicionem itens ao carrinho. |
| RF-03   | O sistema deve permitir pagamento via Pix e cartão. |
| RF-04   | O sistema deve exibir tempo estimado de preparo. |
| RF-05   | O sistema deve enviar o pedido automaticamente para a cozinha. |
| RF-06   | O administrador deve poder cadastrar e editar produtos no cardápio. |

---

## 2.2 – Requisitos Não Funcionais

| **ID**   | **Requisito Não Funcional** |
|---------|----------------------------|
| RNF-01  | O sistema deve ter um tempo de resposta menor que 2 segundos para cada ação do usuário. |
| RNF-02  | O sistema deve estar disponível 24/7. |
| RNF-03  | O sistema deve criptografar dados de pagamento para garantir segurança. |
| RNF-04  | O sistema deve ser responsivo para se adaptar a diferentes telas. |
| RNF-05  | O sistema deve suportar até 100 pedidos simultâneos sem perda de desempenho. |


# 3. User Stories

Formato:
```
Como [tipo de usuário]
Quero [uma funcionalidade]
Para que [benefício esperado]
```

## **User Story 1 - Cliente faz pedido no totem**
```markdown
Como cliente,
Quero selecionar meu pedido pelo totem digital,
Para que eu não precise esperar na fila.
```

**Acceptance Criteria:**
- O totem exibe o cardápio completo com todos os produtos disponíveis.
- O cliente pode selecionar os itens do cardápio para adicionar ao pedido.
- O sistema deve permitir adicionar ou remover itens facilmente.
- O cliente pode ver a quantidade de itens no carrinho antes de finalizar.

---

## **User Story 2 - Pagamento digital**
```markdown
Como cliente,
Quero pagar com cartão ou Pix diretamente no totem,
Para que meu pedido seja processado rapidamente.
```

**Acceptance Criteria:**
- O totem oferece as opções de pagamento via Pix ou cartão de crédito/débito.
- O pagamento é processado com confirmação imediata.
- O cliente recebe uma confirmação de pagamento e do pedido.

---

## **User Story 3 - Personalização de pedidos**
```markdown
Como cliente,
Quero personalizar ingredientes do meu lanche,
Para que eu possa adaptar o pedido ao meu gosto.
```

**Acceptance Criteria:**
- O totem permite que o cliente personalize ingredientes (ex: retirar cebola, adicionar extra bacon).
- As personalizações aparecem claramente na tela antes de finalizar o pedido.
- O preço final é ajustado automaticamente com base nas alterações feitas pelo cliente.

---

# 4. Técnicas de Análise e Modelagem de Requisitos

## 4.1 – Casos de Uso

**Definição:**
Casos de uso descrevem como um sistema deve interagir com os usuários ou outros sistemas. Eles são fundamentais para capturar e documentar os requisitos funcionais de uma maneira que seja facilmente compreensível e acessível a todas as partes envolvidas no projeto.

**Exemplo de Caso de Uso:**

**Caso de Uso 1 - Realizar Pedido:**

**Ator Principal:** Cliente  
**Objetivo:** Realizar um pedido de maneira simples e rápida.  
**Descrição:** O cliente acessa o totem, escolhe os itens do cardápio, personaliza seu pedido (se necessário), e efetua o pagamento.

**Fluxo de Eventos Principal:**
1. O cliente visualiza o cardápio.
2. O cliente seleciona os itens desejados.
3. O cliente personaliza o pedido, se necessário.
4. O cliente visualiza o valor total e confirma.
5. O cliente escolhe o método de pagamento (Pix ou cartão).
6. O sistema processa o pagamento.
7. O sistema confirma o pedido e envia à cozinha.

**Fluxo de Exceção:**
- Se o pagamento falhar, o cliente é notificado e solicitado a tentar novamente.
- Se o pedido não for possível (por falta de estoque, por exemplo), o cliente é informado e pode escolher outro item.

---

## 4.2 – Diagramas de Atividade

**Definição:**
Diagramas de atividade são utilizados para modelar o fluxo de trabalho de um sistema, detalhando os passos de execução das atividades e como elas se inter-relacionam. Eles são ideais para ilustrar processos sequenciais e decisões lógicas dentro de um sistema.

**Exemplo de Diagrama de Atividade - Realização do Pedido:**

1. **Início**
2. O cliente visualiza o cardápio.
3. O cliente escolhe os itens.
4. O cliente personaliza o pedido (opcional).
5. O cliente confirma o pedido.
6. O cliente escolhe o pagamento.
7. **Decisão**: O pagamento é processado com sucesso?
   - **Sim**: Pedido confirmado.
   - **Não**: Exibe erro e solicita nova tentativa.
8. O pedido é enviado para a cozinha.
9. **Fim**

---

## 4.3 – Protótipos

**Definição:**
Protótipos são representações visuais ou funcionais de um sistema, utilizados para validar os requisitos com os usuários e testar a interação com o sistema antes de sua implementação final. Eles podem variar de simples esboços a modelos interativos mais complexos.

**Exemplo de Protótipo de Tela:**

1. Tela inicial com o logo e opções para acessar o cardápio, consultar o status do pedido ou fazer um novo pedido.
2. Tela de cardápio com categorias de itens (lanches, acompanhamentos, bebidas), onde o cliente pode selecionar os itens.
3. Tela de personalização do pedido, onde o cliente pode adicionar ou remover ingredientes.
4. Tela de pagamento, exibindo as opções de pagamento via cartão ou Pix.
5. Tela final de confirmação do pedido, com um número de identificação e o tempo estimado de preparo.

---

## 4.4 – Modelagem de Dados

**Definição:**
A modelagem de dados é o processo de criar um modelo conceitual de dados que define a estrutura das informações que serão armazenadas e processadas pelo sistema. Esse modelo ajuda a entender as relações entre os dados e garante que o sistema funcione de maneira eficiente.

**Exemplo de Diagrama Entidade-Relacionamento (ER):**

- **Entidade "Pedido":**  
  - Atributos: ID_Pedido, Data, Status, Valor_Total, ID_Cliente, Método_Pagamento
- **Entidade "Produto":**  
  - Atributos: ID_Produto, Nome, Descrição, Preço, Categoria
- **Entidade "Cliente":**  
  - Atributos: ID_Cliente, Nome, Email, Telefone
- **Entidade "Item_Pedido" (associativa entre Pedido e Produto):**  
  - Atributos: ID_Item, ID_Pedido, ID_Produto, Quantidade, Preço_Personalizado

---

# 5. Validação de Requisitos

## 5.1 – Revisão com Stakeholders

**Definição:**
A revisão de requisitos com stakeholders é uma técnica onde os requisitos levantados são apresentados e discutidos com as partes interessadas para garantir que todos os pontos importantes foram capturados e que as expectativas estão alinhadas.

**Exemplo de Revisão:**
- Durante a revisão dos requisitos, o cliente sugere incluir uma funcionalidade de rastreamento de pedidos em tempo real, para que o cliente saiba o status de seu pedido (em preparação, pronto para entrega, etc.).
- Esse requisito será adicionado como um requisito funcional (RF-07).

---

## 5.2 – Testes de Aceitação

**Definição:**
Testes de aceitação são realizados para garantir que os requisitos estão sendo atendidos conforme o esperado, antes de liberar o sistema para uso. Eles são baseados nas user stories e critérios de aceitação.

**Exemplo de Teste de Aceitação - Pagamento via Pix:**
- **Pré-condições:** O cliente deve ter um pedido no carrinho e selecionar a opção de pagamento via Pix.
- **Passos:** 
  1. Selecionar Pix como forma de pagamento.
  2. Realizar o pagamento via QR code.
  3. Confirmar que o pagamento foi processado com sucesso.
- **Resultado Esperado:** O sistema confirma o pagamento e envia o pedido para a cozinha.

---