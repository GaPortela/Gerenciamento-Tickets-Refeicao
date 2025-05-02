# Gerenciador de Tickets Refeição

DESCRIÇÃO
O projeto consiste em um sistema de gerenciamento de tickets refeição, onde o usuário pode adicionar, editar e remover funcionarios e seus respectivos tickets refeição.O sistema também permite que o usuário visualize os tickets refeição de todos os funcionários cadastrados.

## Funcionalidades
- Adicionar funcionário
- Editar funcionário
- Visualizar Funcionários
- Filtrar funcionários por nome e CPF
- Adicionar tickets refeição para cada funcionário cadastrado ATIVO
- Editar registros para tickets refeição
- Visualizar registros tickets refeição
- Filtrar registros tickets refeição por funcionário

## Tecnologias Utilizadas
- C#
- Windows Forms
- MySQL
- Dapper (Micro ORM)

## Arquitetura Utilizada
A solução foi desenvolvida utilizando o padrão de arquitetura que utiliza-se de camadas separando as responsabilidades do sistema.
- Camada de Apresentação(UI): Responsável pela interface gráfica do usuário (Windows Forms).
- Camada de Negócio(BLL): Responsável pela lógica de negócio do sistema.
- Camada de Acesso a Dados(DAL): Responsável pela comunicação com o banco de dados.
- Camada de Entidade(Models): Responsável por representar as entidades do sistema.

## BLL (Business Logic Layer)
A camada de BLL é responsável por implementar a lógica de negócio do sistema. Ela utiliza a camada de DAL para realizar operações no banco de dados e retorna os resultados para a camada de UI. A BLL também valida os dados antes de enviá-los para a DAL.

## DAL (Data Access Layer)
A camada de DAL é responsável por realizar a comunicação com o banco de dados. Ela utiliza o Dapper como micro ORM para facilitar a execução de consultas SQL e mapeamento de objetos. A DAL é responsável por executar as operações CRUD (Create, Read, Update, Delete) no banco de dados.

## Models
A camada de Models é responsável por representar as entidades do sistema. Cada entidade possui suas propriedades e métodos relacionados. As entidades são utilizadas pela camada de BLL para realizar operações no banco de dados.

## UI
A camada de UI é responsável pela interface gráfica do usuário. Ela utiliza o Windows Forms para criar as telas do sistema. A UI se comunica com a camada de BLL para realizar operações no sistema e exibir os resultados para o usuário.

## Instalação e execução
1. Clone o repositório do GitHub para sua máquina local.
2. Abra o projeto no Visual Studio.
3. Certifique-se de ter o MySQL instalado e configurado em sua máquina.
4. Execute o arquivo `GerenciamentoTicketsRefDB.sql` para criar o banco de dados e as tabelas necessárias.  
5. Configure a string de conexão no arquivo `app.config` para apontar para o seu banco de dados MySQL.
 `<connectionStrings>
    <add name="MySqlConnection" connectionString="Server=localhost;Database=GerenciadorValeRefeicoes;Uid=root;Pwd=sua_senha;"/>
</connectionStrings>`
6. Compile e execute o projeto no Visual Studio.

## Pacotes NuGet
- Dapper: Micro ORM para facilitar a comunicação com o banco de dados MySQL.
- MySql.Data: Driver MySQL para .NET.

## Contribuição
Sinta-se à vontade para contribuir com o projeto. Você pode fazer isso de várias maneiras: