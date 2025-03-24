# Documentação do Projeto

## 1 – Entrevista

### 1.1 Funcionalidades Principais
- **Interface Touchscreen Intuitiva com Categorias Organizadas**:
  - Promoções
  - Combos
  - Produtos Unitários
  - Bebidas
  - Sobremesas
- **Exibição de Produtos**:
  - Imagem, preço e descrição (detalhes aparecem ao clicar no item).
- **Customização de Pedidos**:
  - Permite que o cliente adicione ou remova ingredientes (ex: tirar alface, adicionar extra bacon).
- **Pagamento Integrado**:
  - Aceita pagamentos via cartão de crédito/débito, NFC (Apple Pay, Google Pay) ou Pix.
- **Impressão de Nota Fiscal**:
  - Nota fiscal gerada diretamente no totem.
- **Integração com Estoque**:
  - Controle em tempo real para evitar vendas de produtos esgotados.

---

### 1.2 Acessibilidade
- **Modo para Daltônicos**:
  - Ajustes de contraste e indicação de cores alternativas para garantir uma experiência inclusiva.

### 1.3 Cores
<img src="stakeholder/paleta.png" alt="Paleta de Cores" />

**Fonte**: [Color Hunt](https://colorhunt.co/palette/990000ff5b00d4d925ffee63)

### 1.4 Demais Observações
O cardápio será inspirado nos totens do BK e McDonald's, com alguns detalhes criativos:

- **Acompanhamentos**
- **Lanches**: Exemplo: "C# Burguer", "PHP Burguer"
- **Sobremesas**: Milk Shakes, casquinha, petit gâteau
- **Bebidas**: Refrigerantes, sucos
- **Molhos**: Mais opções do que ketchup! E combos criativos!
- **Cupons**: Uma aba de cupons de desconto estará disponível.

**Nome do Sistema**: ADS Burguer  
**Tamanho da Tela**: 800x1280  
**Extensão**: Simulador Móvel (ferramenta de teste responsiva)

---

## 2. Requisitos

### **Requisitos Funcionais do Sistema Atual**  

| Id   | Nome                                     | Descrição |
|------|------------------------------------------|-----------|
| **RF01** | Tela de Início                          | Exibe a tela principal do totem com opções de "iniciar pedido". |
| **RF02** | Escolha do Tipo de Pedido               | Permite selecionar entre "Viagem" ou "Consumo no Local". |
| **RF03** | Login e Identificação                   | Cliente pode se identificar via CPF ou login anônimo. |
| **RF04** | Aplicação de Cupons                     | Permite inserir cupons de desconto antes do pagamento. |
| **RF05** | Seleção de Itens                        | Exibição dos produtos disponíveis com imagem, preço e descrição. |
| **RF06** | Personalização de Ingredientes          | Cliente pode adicionar ou remover ingredientes dos produtos. |
| **RF07** | Adicionar Item ao Carrinho              | Adiciona produtos ao carrinho para posterior finalização do pedido. |
| **RF08** | Revisão do Pedido                       | Exibe um resumo do pedido antes da finalização. |
| **RF09** | Remoção de Itens do Carrinho            | Permite excluir itens individualmente do carrinho. |
| **RF10** | Cancelamento do Carrinho                | Cancela o pedido inteiro antes da finalização. |
| **RF11** | Efetivação do Pedido                    | Confirma o pedido e o encaminha para a cozinha. |
| **RF12** | Emissão de Nota Fiscal                  | Gera nota fiscal com ou sem CPF, conforme escolha do cliente. |
| **RF13** | Pagamento Integrado                     | Aceita pagamentos via Dinheiro, Pix, Carteira Digital e Cartão. |
| **RF14** | Identificação do Pedido                 | Exibe nome ou código do pedido para retirada. |
| **RF15 (Cancelado)** | Modo Daltônico                          | Ajusta cores e contrastes para melhor acessibilidade. |
| **RF16** | Navegação por Categorias                | Permite alternar entre lanches, combos, sobremesas, etc. |
| **RF17** | Filtros no Menu                         | Disponibiliza filtros no topo da interface para refinar a busca. |
| **RF18** | Progresso do Pedido                     | Exibe as etapas do processamento do pedido em tempo real. |
| **RF19** | Notificação de Pedido Pronto            | Cliente recebe alerta via telão quando o pedido está pronto. |
| **RF20** | Cadastro de Categorias e Subcategorias  | Permite gerenciar categorias e subcategorias dos produtos. |
| **RF21** | Limite de Ingredientes                  | Define a quantidade máxima de personalizações por item. |
| **RF22** | Gerenciamento do Cardápio (Admin)       | Admin pode adicionar, editar e remover itens do cardápio. |
| **RF23** | Relatório de Vendas e Preferências      | Geração de relatórios sobre vendas e comportamento dos clientes. |
| **RF24** | Integração com Programa de Fidelidade   | Permite acúmulo e resgate de pontos via login. |

---

### **Requisitos Não Funcionais**  

| Id    | Nome                                   | Descrição |
|-------|----------------------------------------|-----------|
| **RNF01** | Tempo de Resposta                     | Exibição de menus em até 4 segundos. |
| **RNF02 (Cancelado)** | Interface Intuitiva                   | UI deve ser de fácil compreensão e uso. |
| **RNF03** | Segurança de Pagamento                | Proteção contra fraudes e segurança nos dados bancários. |
| **RNF04** | Conformidade com LGPD                 | Sistema deve garantir privacidade e proteção de dados do usuário. |
| **RNF05** | Deploy Contínuo                       | Atualizações sem interrupção do serviço. |
| **RNF06** | Prevenção de Travamentos              | Implementação de mecanismos para evitar congelamento da tela. |
| **RNF07 (Cancelado)** | Responsividade                        | O sistema deve ser um **PWA** e funcionar em diferentes dispositivos. |
| **RNF08** | Escalabilidade                        | Suporte para expansão sem perda de desempenho. |
| **RNF09** | Disponibilidade 24/7                  | Sistema deve estar sempre acessível. |
| **RNF10** | Proteção contra Ataques               | Medidas contra injeções SQL, XSS, e outras ameaças. |
| **RNF11** | Backup e Sincronização                | O sistema deve realizar backups frequentes e sincronizar com o servidor. |
| **RNF12 (Cancelado)** | Interações Sonoras e Visuais          | Sons e animações para feedback ao usuário, podendo ser desativados. |
| **RNF13** | Proteção de Dados                     | Armazenamento seguro e criptografado das informações. |
| **RNF14** | Usabilidade (UI/UX)                   | Design focado em experiência do usuário eficiente e acessível. |
| **RNF15** | Capacidade de Processamento           | Deve suportar alto volume de transações sem lentidão. |
| **RNF16** | Modo Offline                          | Deve permitir operação mínima sem internet, com sincronização posterior. |
| **RNF17** | Cache para Carregamento Rápido        | Armazenamento local para otimizar velocidade. |
| **RNF18** | Análise de Uso e Relatórios           | Coleta de métricas para melhorar interface e performance. |
| **RNF19** | Tempo de Inatividade                  | O sistema deverá retornar automaticamente para a tela inicial após 1 minuto de inatividade, garantindo que pedidos abandonados não fiquem na tela e liberando o totem para novos clientes. |

---

## 3. User Stories


### Visualizar itens do cardápio por categoria
**Como** cliente  
**Eu quero** visualizar os itens do cardápio de acordo com a categoria  
**Para** que eu possa achar o meu lanche de interesse mais rápido  

#### Critérios de Aceitação
- Os itens devem estar cadastrados (RF22)
- Os itens devem ser exibidos para o usuário (RF05)
- O filtro de categorias deve funcionar (RF17)

---

### Tela inicial sem pedidos ativos
**Como** cliente  
**Eu quero** uma tela inicial  
**Para** que ao iniciar o pedido indique que não há pedidos sendo feitos  

#### Critérios de Aceitação
- Botão "Iniciar pedido" deve ser visível e acessível (RF01)
- Apresentar o logo da empresa
- Ícones e textos acessíveis para todas as pessoas (RNF14)

---

### Menu organizado e intuitivo
**Como** cliente  
**Eu quero** um menu organizado e satisfatório  
**Para** escolher o tipo de pedido  

#### Critérios de Aceitação
- Exibe claramente as opções "Viagem" e "Consumo no local" (RF02)
- Ícones e textos autoexplicativos (RNF14)
- Botões funcionais (RNF14)

---

### Identificação por CPF ou continuar sem login
**Como** cliente  
**Eu quero** me identificar pelo CPF ou continuar sem login  
**Para** que eu possa registrar minha conta e acumular pontos se desejar  

#### Critérios de Aceitação
- O sistema deve oferecer um campo para inserir o CPF (RF03)
- Deve haver a opção de prosseguir sem login (RF03)
- A identificação deve ser rápida e sem travamentos (RNF01)

---

### Cancelar pedido
**Como** cliente  
**Eu quero** cancelar meu pedido  
**Para** que eu possa desistir sem precisar remover item por item  

#### Critérios de Aceitação
- Deve haver um botão para cancelar todo o pedido (RF10)
- O sistema deve pedir uma confirmação antes de cancelar (RNF14)
- O carrinho deve ser esvaziado

---

### Adicionar e remover itens ao carrinho
**Como** cliente  
**Eu quero** conseguir adicionar e remover itens ao carrinho  
**Para** realizar meu pedido  

#### Critérios de Aceitação
- A tela de seleção do item deverá ter um botão "Adicionar ao carrinho" (RF07)
- A tela do carrinho deverá ter um botão para remover ou alterar a quantidade de cada item (RF09)
- O sistema deverá recalcular o valor ao adicionar/remover itens

---

### Inserir cupom de desconto
**Como** cliente  
**Eu quero** inserir um cupom de desconto no meu pedido  
**Para** aproveitar promoções e economizar na compra  

#### Critérios de Aceitação (RF04)
- Usuário pode inserir um cupom de desconto
- O sistema deve validar se o cupom é válido
- Apenas um cupom pode ser aplicado por pedido
- O usuário pode remover o cupom e o valor do pedido será recalculado

---

### Diversas formas de pagamento
**Como** cliente  
**Eu quero** ter diversas formas de pagamento  
**Para** ter maior versatilidade ao fazer uma compra  

#### Critérios de Aceitação (RF13)
- O sistema deve permitir a escolha da forma de pagamento antes da finalização da compra
- Deve oferecer pelo menos as seguintes opções: débito, crédito, pix e dinheiro

---

### Conferir os itens do pedido
**Como** cliente  
**Eu quero** uma tela  
**Para** conferir os itens do meu pedido  

#### Critérios de Aceitação
- Exibe resumo claro dos itens (quantidade, preço) (RF08)
- Botão para confirmar e voltar
- Layout fácil de entender (RNF14)

---

### Implementação de novos recursos e correções
**Como** administrador  
**Eu quero** que sejam implementados novos recursos e correções  
**Para** que o sistema esteja sempre atualizado  

#### Critérios de Aceitação
- O deploy deverá ser sem interrupção do serviço (RNF05 - RNF09)
- As atualizações deverão ser testadas antes da implantação
- As atualizações deverão estar protegidas contra ataques (SQL Injection, etc) (RNF10)

---

### Backups regulares e sincronização automática
**Como** administrador  
**Eu quero** que o sistema faça backups regulares e sincronize os dados automaticamente  
**Para** que não ocorra o risco de perder alguma informação importante caso ocorra alguma falha  

#### Critérios de Aceitação
- O sistema deverá realizar backup automático e regular (RNF11)
- Haverá sincronização automática dos dados entre dispositivos (RNF16)
- Em caso de falhas, os dados deverão ser recuperados do último backup (RNF11)

---

### Retorno automático para tela inicial
**Como** administrador  
**Eu quero** que o sistema retorne automaticamente para a tela inicial após um período de inatividade  
**Para** liberar a interface para novos usuários e descartar pedidos abandonados  

#### Critérios de Aceitação (RNF19)
- O sistema deve detectar inatividade e retornar à tela inicial após 1 min
- Deve haver uma contagem regressiva antes do redirecionamento

---

### Registro de logs de uso
**Como** administrador  
**Eu quero** que o sistema registre os logs de uso  
**Para** melhorar a eficiência, otimizar a experiência e visualizar possíveis melhorias  

#### Critérios de Aceitação (RNF18)
- O sistema deve armazenar os logs de interação do usuário
- O sistema deve gerar relatórios automáticos e legíveis
- Deve permitir a personalização do período do relatório
- Deve permitir a exportação dos dados (CSV, PDF, TXT)

---

### Gerenciamento do Cardápio
**Como** administrador  
**Eu quero** adicionar, editar e remover itens do cardápio  
**Para** manter o menu sempre atualizado  

#### Critérios de Aceitação
- Deve ser possível cadastrar novos itens (RF22)
- Deve ser possível editar os detalhes de um item existente (RF22)
- Deve ser possível remover itens do cardápio (RF22)

---

### Cadastro de Categorias e Subcategorias
**Como** administrador  
**Eu quero** cadastrar e gerenciar categorias e subcategorias  
**Para** organizar melhor os produtos no menu  

#### Critérios de Aceitação
- Deve ser possível criar novas categorias e subcategorias (RF20)
- Deve ser possível editar os nomes e descrições das categorias (RF20)
- Deve ser possível excluir categorias e realocar os produtos (RF20)

---

### Limite de Personalização de Ingredientes
**Como** administrador  
**Eu quero** definir um limite para personalização de ingredientes  
**Para** evitar alterações excessivas nos produtos  

#### Critérios de Aceitação
- Deve ser possível definir um limite de adições e remoções por item (RF21)
- O sistema deve exibir um alerta ao tentar ultrapassar o limite (RF21)

---

### Progresso do Pedido
**Como** cliente  
**Eu quero** acompanhar o progresso do meu pedido em tempo real  
**Para** saber quando ele estará pronto  

#### Critérios de Aceitação
- O sistema deve exibir status como "Em preparo" e "Pronto para retirada" (RF18)
- O cliente deve conseguir visualizar sua posição na fila (RF18)
- A atualização do status deve ser automática
