# Levantamento de Requisitos e Classificação

## 1. Técnicas de Levantamento de Requisitos

### 1.1 – Entrevista

**Perguntas e Respostas:**
- **Pergunta 1:** Quais são os principais desafios no atendimento ao cliente?
  - *Resposta:* Temos um grande fluxo de clientes nos horários de pico, e isso gera filas no caixa.
- **Pergunta 2:** Como funciona atualmente o processo de pedidos?
  - *Resposta:* O atendente anota manualmente ou o cliente escolhe no balcão. Depois, o pedido é inserido no sistema.

**Requisitos levantados:**
- O sistema deve permitir que o cliente faça pedidos sem precisar de um atendente.
- Deve haver integração com um sistema de pagamento.

---

### 1.2 – Brainstorming

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

### 1.3 – User Stories

Formato:
```
Como [tipo de usuário]
Quero [uma funcionalidade]
Para que [benefício esperado]
```

**User Story - Cliente faz pedido no totem**
```markdown
Como cliente,
Quero selecionar meu pedido pelo totem digital,
Para que eu não precise esperar na fila.
```

**User Story - Pagamento digital**
```markdown
Como cliente,
Quero pagar com cartão ou Pix diretamente no totem,
Para que meu pedido seja processado rapidamente.
```

**User Story - Personalização de pedidos**
```markdown
Como cliente,
Quero personalizar ingredientes do meu lanche,
Para que eu possa adaptar o pedido ao meu gosto.
```

---

## 2. Classificação de Requisitos

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

### 2.2 – Requisitos Não Funcionais

| **ID**   | **Requisito Não Funcional** |
|---------|----------------------------|
| RNF-01  | O sistema deve ter um tempo de resposta menor que 2 segundos para cada ação do usuário. |
| RNF-02  | O sistema deve estar disponível 24/7. |
| RNF-03  | O sistema deve criptografar dados de pagamento para garantir segurança. |
| RNF-04  | O sistema deve ser responsivo para se adaptar a diferentes telas. |
| RNF-05  | O sistema deve suportar até 100 pedidos simultâneos sem perda de desempenho. |
