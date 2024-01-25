# DIO - Trilha .NET - Fundamentos

## 🐱‍👤 Desafio do Projeto 
Este desafio consistiu em usar os conhecimentos adquiridos no módulo de fundamentos, da trilha .NET da DIO. O desenvolvedor foi contratado para construir um sistema de estacionamento, usado para gerenciar os veículos estacionados e realizar suas operações, como por exemplo adicionar um veículo, remover um veículo (e exibir o valor cobrado durante o período) e listar os veículos.

## 🚗 Requisitos do Projeto
- [x]  **Construir uma classe chamada "Estacionamento", conforme o diagrama abaixo:**
![Diagrama de classe estacionamento](diagrama_classe_estacionamento.png)

**A classe deve conter três variáveis, sendo:**

- [x]  **precoInicial**: Tipo decimal. É o preço cobrado para deixar seu veículo estacionado.
- [x]  **precoPorHora**: Tipo decimal. É o preço por hora que o veículo permanecer estacionado.
- [x]  **veiculos**: É uma lista de string, representando uma coleção de veículos estacionados. Contém apenas a placa do veículo.

**A classe deve conter três métodos, sendo:**

- [x]  **AdicionarVeiculo**: Método responsável por receber uma placa digitada pelo usuário e guardar na variável **veiculos**.
- [x]  **RemoverVeiculo**: Método responsável por verificar se um determinado veículo está estacionado, e caso positivo, irá pedir a quantidade de horas que ele permaneceu no estacionamento. Após isso, realiza o seguinte cálculo: **precoInicial** * **precoPorHora**, exibindo para o usuário.
- [x]  **ListarVeiculos**: Lista todos os veículos presentes atualmente no estacionamento. Caso não haja nenhum, exibir a mensagem "Não há veículos estacionados".

- [x]  **Menu interativo com as seguintes ações implementadas:**
1. Cadastrar veículo
2. Remover veículo
3. Listar veículos
4. Encerrar

## 🎯 Solução
Para obter um programa funcional, foi cumprida a missão de continuar o código fornecido pela metade, respeitando e implementando os requisitos descritos acima. Neste sistema, é permitido interagir com o usuário através do console para realizar registro dos valores cobrados no estacionamento, cadastro, remoção e listagem de veículos, bem como encerrar o programa.
Veja o [fluxograma](https://modeler.cloud.camunda.io/share/f8ed33a4-34a9-4632-89cc-de8002915beb) da aplicação.
![fluxograma](fluxogramaEestacionamento.png)

### 📄 Funcionalidades
- Cadastrar os valores do Estacionamento
- Cadastrar veículo
- Remover veículo
- Listar veículos
- Encerrar programa

### 📖 Especificações Técnicas

A solução é composta por duas partes principais: 

**1. Programa Principal (Program.cs)**
- Composto pela classe Program, que representa o programa principal da aplicação.
- Define a codificação do console como UTF-8 para a exibição correta de caracteres acentuados.
- Exibe para o usuário uma mensagem de boas-vindas com o nome do estacionamento.
- Cria uma instância da classe Estacionamento, inicializando os atributos precoInicial e precoPorHora com zero.
- Entra em um loop `while` para solicitar ao usuário que digite o preço inicial e o preço por hora do estacionamento, validando os valores e tratando possíveis exceções.
- Entra em outro loop `while` para exibir um menu do tipo `switch` com quatro opções: cadastrar veículo, remover veículo, listar veículos e encerrar o programa.
- Dependendo da escolha do usuário, chama um dos métodos da classe Estacionamento: AdicionarVeiculo, RemoverVeiculo ou ListarVeiculos.
- Ao optar por encerrar o programa, o usuário deve confirmar sua escolha em um loop `while` que verifica a resposta.
    - O loop termina se a resposta for “s”.
    - O menu é exibido novamente se a resposta for “n”.
    - Uma mensagem de erro é mostrada se a resposta for inválida e a confirmação é repetida.
- Exibe uma mensagem informando que o programa se encerrou.

**2. Classe Estacionamento (Estacionamento.cs)**
- É uma classe que modela um estacionamento, com propriedades para o preço inicial e a taxa por hora, uma lista para guardar os veículos e métodos para executar as opções do menu da aplicação.
- **_precoInicial:** um campo privado do tipo decimal que armazena o preço inicial do estacionamento.
- **_precoPorHora:** um campo privado do tipo decimal que armazena o preço por hora do estacionamento.
- **veiculos:** uma lista privada de strings que armazena as placas dos veículos estacionados.
- **PrecoInicial:** uma propriedade pública do tipo decimal que permite acessar e modificar o valor do campo _precoInicial, lançando uma exceção do tipo ArgumentException se o valor for negativo.
- **PrecoPorHora:** uma propriedade pública do tipo decimal que permite acessar e modificar o valor do campo _precoPorHora, lançando uma exceção do tipo ArgumentException se o valor for negativo.
- **Estacionamento(decimal precoInicial, decimal precoPorHora):** um construtor público que recebe dois parâmetros do tipo decimal e inicializa as propriedades PrecoInicial e PrecoPorHora com os valores recebidos.
- **AdicionarVeiculo():** um método público que não retorna nada e não recebe parâmetros. Ele limpa o console, entra em um loop `while` para solicitar ao usuário que digite a placa do veículo a ser estacionado, utiliza RegEx (Regular Expression) para validar se os formatos de placas de automóveis obedecem ao modelo padrão antigo ou ao modelo padrão Mercosul, adiciona a placa à lista de veículos e exibe uma mensagem de sucesso. Se a placa for inválida, exibe uma mensagem de erro e repete o loop.
- **RemoverVeiculo():** um método público que não retorna nada e não recebe parâmetros. Ele limpa o console, entra em um loop `while` para solicitar ao usuário que digite a placa do veículo a ser removido, verifica se a placa existe na lista de veículos, entra em outro loop `while` para solicitar ao usuário que digite a quantidade de horas que o veículo permaneceu estacionado, valida o valor, calcula o preço total a ser pago, remove a placa da lista de veículos e exibe uma mensagem com o valor total. Se a placa não existir ou o valor for inválido, exibe uma mensagem de erro e repete o loop.
- **ListarVeiculos():** é um método público que não retorna nada e não recebe parâmetros. Ele verifica se a lista de veículos está vazia ou não, usando o método Any(). Se a lista não estiver vazia, limpa o console e exibe uma mensagem informando os veículos estacionados. Usa uma variável inteira i para contar os veículos e um loop `foreach` para percorrer a lista de veículos. Dentro do loop, exibe a placa de cada veículo, usando a interpolação de strings para formatar a saída. Incrementa a variável i a cada iteração do loop. Se a lista estiver vazia, limpa o console e exibe uma mensagem informando que não há veículos estacionados.

## 💻 Tecnologias Utilizadas
![C#](https://img.shields.io/badge/c%23-%23239120.svg?style=for-the-badge&logo=csharp&logoColor=white)

![.Net](https://img.shields.io/badge/.NET-5C2D91?style=for-the-badge&logo=.net&logoColor=white)

![Git](https://img.shields.io/badge/git-%23F05033.svg?style=for-the-badge&logo=git&logoColor=white)

![Visual Studio Code](https://img.shields.io/badge/Visual%20Studio%20Code-0078d7.svg?style=for-the-badge&logo=visual-studio-code&logoColor=white)

## ⚙ Dependências e Versões 
- **SDK .NET** - Versão: 8.0.100 ou 8.0.101 (para compilar e executar a aplicação)
- **Visual Studio Code** - Versão: 1.84.1 (editor de código)
- **Git** - Versão: 2.43.0 (versionamento do código)

## 🕹 Como Executar a Aplicação
1. Instale o [.NET](https://dotnet.microsoft.com/pt-br/download) na versão recomendada em sua máquina
2. Clone o repositório para a sua máquina local. Você pode utiizar um dos seguintes comandos:
```
git clone https://github.com/BarbaraLeimig/Sistema-Estacionamento-NET-desafio.git
```
ou
```
git clone git@github.com:BarbaraLeimig/Sistema-Estacionamento-NET-desafio.git
```
3. No Visual Studio Code navegue até a pasta do projeto em sua máquina via menu ou pela linha de comando. Ex:
```
cd Desktop/Projetos/Estacionamento
```
4. Execute o seguinte comando para iniciar o programa:
```
dotnet run
```
5. Interaja com o programa seguindo as informações exibidas no console.
