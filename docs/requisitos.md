## **Requisitos Funcionais**  

| Id   | Nome                                     | Descrição |
|------|------------------------------------------|-----------|
| **RF01** | Tela de Início                       | Exibe a tela principal do totem com opções de "iniciar pedido". |
| **RF02** | Escolha do Tipo de Pedido           | Permite selecionar entre "Viagem" ou "Consumo no Local". |
| **RF03** | Login e Identificação               | Cliente pode se identificar via CPF ou login anônimo. |
| **RF04** | Aplicação de Cupons                 | Permite inserir cupons de desconto antes do pagamento. |
| **RF05** | Seleção de Itens                    | Exibição dos produtos disponíveis com imagem, preço e descrição. |
| **RF06** | Personalização de Ingredientes      | Cliente pode adicionar ou remover ingredientes dos produtos. |
| **RF07** | Adicionar Item ao Carrinho          | Adiciona produtos ao carrinho para posterior finalização do pedido. |
| **RF08** | Revisão do Pedido                   | Exibe um resumo do pedido antes da finalização. |
| **RF09** | Remoção de Itens do Carrinho        | Permite excluir itens individualmente do carrinho. |
| **RF10** | Cancelamento do Carrinho            | Cancela o pedido inteiro antes da finalização. |
| **RF11** | Efetivação do Pedido                | Confirma o pedido e o encaminha para a cozinha. |
| **RF12** | Emissão de Nota Fiscal              | Gera nota fiscal com ou sem CPF, conforme escolha do cliente. |
| **RF13** | Pagamento Integrado                 | Aceita pagamentos via Dinheiro, Pix, Carteira Digital e Cartão. |
| **RF14** | Identificação do Pedido             | Exibe nome ou código do pedido para retirada. |
| **RF15** | Modo Daltônico                      | Ajusta cores e contrastes para melhor acessibilidade. |
| **RF16** | Navegação por Categorias            | Permite alternar entre lanches, combos, sobremesas, etc. |
| **RF17** | Filtros no Menu                     | Disponibiliza filtros no topo da interface para refinar a busca. |
| **RF18** | Progresso do Pedido                 | Exibe as etapas do processamento do pedido em tempo real. |
| **RF19** | Notificação de Pedido Pronto        | Cliente recebe alerta via telão quando o pedido está pronto. |
| **RF20** | Cadastro de Categorias e Subcategorias | Permite gerenciar categorias e subcategorias dos produtos. |
| **RF21** | Limite de Ingredientes              | Define a quantidade máxima de personalizações por item. |
| **RF22** | Gerenciamento do Cardápio (Admin)   | Admin pode adicionar, editar e remover itens do cardápio. |
| **RF23** | Relatório de Vendas e Preferências  | Geração de relatórios sobre vendas e comportamento dos clientes. |
| **RF24** | Integração com Programa de Fidelidade | Permite acúmulo e resgate de pontos via login. |

---

## **Requisitos Não Funcionais**  

| Id    | Nome                                   | Descrição |
|-------|----------------------------------------|-----------|
| **RNF01** | Tempo de Resposta                  | Exibição de menus em até 4 segundos. |
| **RNF02** | Interface Intuitiva                | UI deve ser de fácil compreensão e uso. |
| **RNF03** | Segurança de Pagamento             | Proteção contra fraudes e segurança nos dados bancários. |
| **RNF04** | Conformidade com LGPD              | Sistema deve garantir privacidade e proteção de dados do usuário. |
| **RNF05** | Deploy Contínuo                    | Atualizações sem interrupção do serviço. |
| **RNF06** | Prevenção de Travamentos           | Implementação de mecanismos para evitar congelamento da tela. |
| **RNF07** | Responsividade                     | O sistema deve ser um **PWA** e funcionar em diferentes dispositivos. |
| **RNF08** | Escalabilidade                     | Suporte para expansão sem perda de desempenho. |
| **RNF09** | Disponibilidade 24/7               | Sistema deve estar sempre acessível. |
| **RNF10** | Proteção contra Ataques            | Medidas contra injeções SQL, XSS, e outras ameaças. |
| **RNF11** | Backup e Sincronização             | O sistema deve realizar backups frequentes e sincronizar com o servidor. |
| **RNF12** | Interações Sonoras e Visuais       | Sons e animações para feedback ao usuário, podendo ser desativados. |
| **RNF13** | Proteção de Dados                  | Armazenamento seguro e criptografado das informações. |
| **RNF14** | Usabilidade (UI/UX)                | Design focado em experiência do usuário eficiente e acessível. |
| **RNF15** | Capacidade de Processamento        | Deve suportar alto volume de transações sem lentidão. |
| **RNF16** | Modo Offline                       | Deve permitir operação mínima sem internet, com sincronização posterior. |
| **RNF17** | Cache para Carregamento Rápido     | Armazenamento local para otimizar velocidade. |
| **RNF18** | Análise de Uso e Relatórios        | Coleta de métricas para melhorar interface e performance. |
| **RNF19** | Tempo de Inatividade               | O sistema deverá retornar automaticamente para a tela inicial após 1 minuto de inatividade, garantindo que pedidos abandonados não fiquem na tela e liberando o totem para novos clientes. |