# DIO - Trilha .NET - Fundamentos
www.dio.me

## 🐱‍👤 Desafio de projeto 
Para este desafio, você precisará usar seus conhecimentos adquiridos no módulo de fundamentos, da trilha .NET da DIO.

## 📄 Contexto
Você foi contratado para construir um sistema para um estacionamento, que será usado para gerenciar os veículos estacionados e realizar suas operações, como por exemplo adicionar um veículo, remover um veículo (e exibir o valor cobrado durante o período) e listar os veículos.

## 🚗 Proposta
Você precisará construir uma classe chamada "Estacionamento", conforme o diagrama abaixo:
![Diagrama de classe estacionamento](diagrama_classe_estacionamento.png)

A classe contém três variáveis, sendo:

**precoInicial**: Tipo decimal. É o preço cobrado para deixar seu veículo estacionado.

**precoPorHora**: Tipo decimal. É o preço por hora que o veículo permanecer estacionado.

**veiculos**: É uma lista de string, representando uma coleção de veículos estacionados. Contém apenas a placa do veículo.

A classe contém três métodos, sendo:

**AdicionarVeiculo**: Método responsável por receber uma placa digitada pelo usuário e guardar na variável **veiculos**.

**RemoverVeiculo**: Método responsável por verificar se um determinado veículo está estacionado, e caso positivo, irá pedir a quantidade de horas que ele permaneceu no estacionamento. Após isso, realiza o seguinte cálculo: **precoInicial** * **precoPorHora**, exibindo para o usuário.

**ListarVeiculos**: Lista todos os veículos presentes atualmente no estacionamento. Caso não haja nenhum, exibir a mensagem "Não há veículos estacionados".

Por último, deverá ser feito um menu interativo com as seguintes ações implementadas:
1. Cadastrar veículo
2. Remover veículo
3. Listar veículos
4. Encerrar


## 🎯 Solução
O código foi desenvolvido e complementado, criando-se um Sistema de Estacionamento em C#. O sistema permite que os usuários configurem taxas de estacionamento e realizem ações como adicionar, remover e listar os veículos no estacionamento. 

A solução é composta por duas partes principais: 

**1. Programa Principal (Program.cs)**
- Define a codificação do console como UTF-8 para a exibição correta de caracteres acentuados.
- Solicita aos usuários que forneçam o preço inicial e a taxa por hora para o estacionamento.
- Trata exceções para entradas inválidas.
- Utiliza um loop para o menu principal, permitindo que os usuários interajam com o sistema de estacionamento escolhendo opções como adicionar, remover ou listar veículos, bem como encerrar o programa.

**2. Classe Estacionamento (Estacionamento.cs)**
- Representa o estacionamento e contém propriedades para o preço inicial e taxa por hora.
- Fornece métodos para adicionar (AdicionarVeiculo), remover (RemoverVeiculo) e listar (ListarVeiculos) veículos no estacionamento.
- Utiliza Regex (Regular Expression) para validar formatos de placas de automóveis de acordo com o modelo padrão antigo e com o modelo padrão Mercosul.
- Trata exceções de entradas inválidas

### Tecnologias Utilizadas
![C#](https://img.shields.io/badge/c%23-%23239120.svg?style=for-the-badge&logo=csharp&logoColor=white)

![.Net](https://img.shields.io/badge/.NET-5C2D91?style=for-the-badge&logo=.net&logoColor=white)

![Git](https://img.shields.io/badge/git-%23F05033.svg?style=for-the-badge&logo=git&logoColor=white)

![Visual Studio Code](https://img.shields.io/badge/Visual%20Studio%20Code-0078d7.svg?style=for-the-badge&logo=visual-studio-code&logoColor=white)

### ✔ Requisitos
- SDK .NET Core para compilar e executar a aplicação

### 🎁 Como Executar
- Abra o terminal do seu VS Code ou prompt de comando
- Navegue até o diretório onde está salvo o projeto
- Execute os comandos
    - dotnet build
    - dotnet run
- Siga as orientações do programa ^^
