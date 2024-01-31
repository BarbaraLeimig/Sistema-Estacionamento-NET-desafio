# DIO - Trilha .NET - Fundamentos

## 🐱‍👤 Desafio de Projeto 
Este desafio consistiu em usar os conhecimentos adquiridos no módulo de fundamentos, da trilha .NET da DIO. O desenvolvedor foi contratado para construir um sistema de estacionamento, usado para gerenciar os veículos estacionados e realizar suas operações, como por exemplo adicionar um veículo, remover um veículo (e exibir o valor cobrado durante o período) e listar os veículos.

## 🚗 Proposta Inicial do Projeto 
- [x]  **Construir uma classe chamada "Estacionamento", conforme o diagrama abaixo:**
<img width="250" src="https://github.com/BarbaraLeimig/Sistema-Estacionamento-NET-desafio/blob/main/diagrama_classe_estacionamento.png">

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
Para obter um programa funcional, foi cumprida a missão de continuar o código fornecido incompleto, baseando-se nos requisitos descritos acima. Com o objetivo de aplicar os conhecimentos adquiridos no `Bootcamp Decola Tech` 2024, o código foi reformulado visando desenvolver um sistema de estacionamento mais completo e robusto. Neste sistema, usuário pode interagir com a aplicação através do console, encontrando uma área para que este gerencie seus dados pessoais e de seus veículos, e outra para as interações relacionadas ao estacionamento. O código foi desenvolvido em inglês, exceto textos exibidos no console, com o intuito de praticar a escrita na linguagem referida.

<img width="600" src="https://github.com/BarbaraLeimig/Sistema-Estacionamento-NET-desafio/blob/main/diagrama_uml_estacionamento.png">

### 📄 Funcionalidades
- Menus interativos
- Cadastrar usuário
- Exibir informações do usuário
- Editar dados do usuário
- Excluir conta
- Cadastrar veículo
- Exibir veículos do usuário
- Editar informações do veículo
- Excluir veículo
- Estacionar veículo
- Exibir veículos estacionados
- Exibir vagas disponíveis para carros e motos
- Sair do estacionamento
- Realizar pagamento do estacionamento

### 📖 Especificações Técnicas

A solução é composta por 6 (seis) classes:
- **Program:** é responsável por iniciar o programa e gerenciar a interação inicial do usuário com o sistema de estacionamento.
- **Vehicle:** é uma classe abstrata que representa um veículo genérico, definindo propriedades comuns como Brand, Model, LicensePlate, e Color. Ela também possui uma propriedade virtual VehicleType que pode ser sobrescrita por classes derivadas. A classe fornece um construtor protegido para inicializar essas propriedades. Como uma classe abstrata, Vehicle serve como uma classe base para outras classes de veículos mais específicas para herdar e compartilhar código comum.
- **Car:** é uma subclasse da classe abstrata Vehicle. Ela herda todas as propriedades de Vehicle e especifica o tipo de veículo como “Carro”. A classe Car também possui um construtor que aceita uma marca, modelo, placa de licença e cor, e passa esses valores para o construtor da classe base Vehicle. Isso permite a criação de uma instância de Car com essas propriedades específicas.
- **Motorcycle:** é uma subclasse da classe abstrata Vehicle. Ela herda todas as propriedades de Vehicle e especifica o tipo de veículo como “Moto”. A classe Motorcycle também possui um construtor que aceita uma marca, modelo, placa de licença e cor, e passa esses valores para o construtor da classe base Vehicle. Isso permite a criação de uma instância de Motorcycle com essas propriedades específicas.
- **Users:** representa um usuário com propriedades como FullName (nome completo), Cpf (Cadastro de Pessoas Físicas) e uma lista de Vehicles (veículos). A classe possui métodos para definir e obter o nome completo e o CPF do usuário, com verificações para garantir que os valores não sejam nulos ou vazios. Além disso, a classe User tem um construtor que aceita o nome completo e o CPF como parâmetros e um método AddVehicle para adicionar um veículo à lista de veículos do usuário.
- **ParkinLot:** fornece uma representação de um estacionamento que pode acomodar vários usuários e seus veículos, com funcionalidades para gerenciar ambos. Aplica validações para CPF utilizando a biblioteca DocsBRValidator e para placas de veículo, utilizando Regular Expressions (regex).

## 👩🏻‍💻 Versões do Projeto
- **Versão 1.0:** versão original desenvolvida pelo professor Leonardo Buta para o Desafio Fundamentos da Trilha `C#` e `.NET` do BootCamp Decola Tech Avanade 2024.
- **Versão 1.1:** versão desenvolvida por mim para conclusão do desafio de projeto Fundamentos da Trilha `C#` e `.NET` do BootCamp Decola Tech Avanade 2024. Veja em mais detalhes o [fluxograma](https://modeler.cloud.camunda.io/share/f8ed33a4-34a9-4632-89cc-de8002915beb) da aplicação.
- **Versão 1.2:**  versão desenvolvida por mim, onde foram implementadas melhorias para aplicar mais dos conhecimentos que adquiri no BootCamp Decola Tech Avanade 2024.
- **Versão 1.3:** versão em estudo e desenvolvimento para modularização do código, com o intuito de facilitar a reutilização, manutenção e aprimorar a organização do mesmo.
- **Versão 2.0:** transformação do projeto em uma aplicação fullstack utilizando ASP .NET. Este processo envolve a prototipação de telas, criação de uma API RESTful, a integração com o front-end e a conexão com o banco de dados PostgreSQL.

## 💻 Tecnologias Utilizadas
![C#](https://img.shields.io/badge/c%23-%23239120.svg?style=for-the-badge&logo=csharp&logoColor=white)

![.Net](https://img.shields.io/badge/.NET-5C2D91?style=for-the-badge&logo=.net&logoColor=white)

![Git](https://img.shields.io/badge/git-%23F05033.svg?style=for-the-badge&logo=git&logoColor=white)

![Visual Studio Code](https://img.shields.io/badge/Visual%20Studio%20Code-0078d7.svg?style=for-the-badge&logo=visual-studio-code&logoColor=white)

## ⚙ Dependências e Versões 
- **[SDK .NET](https://dotnet.microsoft.com/pt-br/download)** - Versão: 8.0.100 ou 8.0.101 (para compilar e executar a aplicação)
- **[Visual Studio Code](https://code.visualstudio.com/download)** - Versão: 1.84.1 (editor de código)
- **[Git](https://git-scm.com/downloads)** - Versão: 2.43.0 (versionamento do código)

## 🕹 Como Executar a Aplicação
1. Instale em sua máquina as dependências acima, nas versões recomendadas.
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
4. Faça o download da bibliotca DocsBRValidator pelo terminal:
```
dotnet add package DocsBRValidator
```
5. Execute o seguinte comando para iniciar o programa:
```
dotnet run
```
6. Interaja com o programa seguindo as informações exibidas no console.
