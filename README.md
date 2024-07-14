# EstacionamentoAPI

**_Parado_**

<p>EstacionametoAPI é uma API desenvolvida utilizando o ASP.NET WebAPI, servindo para controle de diversos estacionamentos. Ela permitirá que o usuários autenticados no sistema possam cadastrar carros e estacionamentos, além de conseguir informar quais carros estão estacionados.</p>

A autenticação é feita apartir de JWT, especificamente a biblioteca JWT Bearer do ASP.NET.

## Diagrama de projeto

<p>Para melhor exemplicação e visualização da estrutura da API, foi desenvolvido um pequeno diagrama que mostra o comportamento desejado (Pode sofrer alterações no futuro)</p>

![Diagrama da estrutura da API](./diagrama-estacionamento.png)

## Execução

<p>
Para executar o projeto, basta você usar o <code>git clone https://github.com/hav0kinho/EstacionamentoAPI.git</code>

Com o código na sua máquina, basta você entrar no diretório da aplicação com um <code>cd EstacionamentoAPI</code> e então utilizar <code>dotnet build</code> para instalar os pacotes e preparar o código para execução. Após isso, basta usar o <code>dotnet run --urls "http://localhost:8000"</code> para inicializar a API na porta 8000 do seu computador.

</p>

## Features

#### Resumo

<p>
    Você pode acessar a documentação Swagger da aplicação acessando <code>http://localhost:8000/swagger</code>, permitindo visualizar as rotas da aplicação.
</p>

O sistema conta com três controllers para requisições ao servidor, sendo elas o <code>CarroController</code>, que lida com a parte de criação de carros no Banco de dados, <code>EstacionamentoController</code>, que permite que o usuário crie novos estacionamentos e cadastre carros a eles e <code>AuthController</code>, que permite que o usuário se cadastre no sistema e realize o Login, recebendo um JWT com uma <strong>Role</strong> <code>Admin</code> ou <code>User</code>.

#### Rotas

- **Auth**<br/>
  <code>**_POST_**</code> <code>/api/auth/registrar</code> -> Cria usuários.<br/>
  <code>**_POST_**</code> <code>/api/auth/registrar/admin</code> -> **Rota para facilitar os testes** - Cria usuários administradores.<br/>
  <code>**_POST_**</code> <code>/api/auth/login</code> -> Recebe um usuário e devolve um JWT.<br/>

<br>

- **Carros**<br/>
  <code>**_GET_**</code> <code>/api/carros</code> <code>_User | Admin_</code> -> Resgata todos os carros.<br/>
  <code>**_GET_**</code> <code>/api/carros/{id}</code> <code>_User | Admin_</code> -> Resgata um carro a partir de um ID.<br/>
  <code>**_GET_**</code> <code>/api/carros/buscar-placa/{placa}</code> <code>_User | Admin_</code> -> Resgata um carro a partir de uma placa.<br/>
  <code>**_POST_**</code> <code>/api/carros</code> <code>_User | Admin_</code> -> Cadastra um carro.<br/>
  <code>**_DELETE_**</code> <code>/api/carros/{id}</code> <code>_Admin_</code> -> Deleta um carro a partir de um ID<br/>
  <code>**_DELETE_**</code> <code>/api/carros/buscar-placa/{id}</code> <code>_Admin_</code> -> Delete um carro a partir de uma placa.<br/>

<br>

- **Estacionamentos**<br/>
  <code>**_GET_**</code> <code>/api/estacionamentos</code> <code>_User | Admin_</code> -> Resgata todos os estacionamentos.<br/>
  <code>**_GET_**</code> <code>/api/estacionamentos/{id}</code> <code>_User | Admin_</code> -> Resgata um estacionamento a partir de um ID.<br/>
  <code>**_POST_**</code> <code>/api/estacionamentos</code> <code>_Admin_</code> -> Cadastra um estacionamento.<br/>
  <code>**_POST_**</code> <code>/api/estacionamentos/estacionar-carro/{id}/{placa}</code> <code>_User | Admin_</code> -> Estaciona um carro a partir da placa em um estacionamento com um determinado ID.<br/>
  <code>**_POST_**</code> <code>/api/estacionamentos/retirar-carro/{id}/{placa}</code> <code>_User | Admin_</code> -> Retira um carro a partir da placa de um estacionamento com um determinado ID.<br/>
  <code>**_DELETE_**</code> <code>/api/estacionamentos/{id}</code> <code>_Admin_</code> -> Deleta um estacionamento com um determinado ID.<br/>

##### Permissões

<code>**_User_**</code> -> Essa Role permite o usuário resgatar e cadastrar carros, além de deixar que ele estacione e retire o carro de um determinado estacionamento.<br/>

<code>**_Admin_**</code> -> Essa Role permite todas as operações que o usuário pode fazer, mas além disso, permite que ele também possa criar e deletar estacionamentos.<br/>

#### Banco de dados

_O banco implementado está usando o EntityFramework, utilizando o InMemory como banco de dados para facilitar a execução do projeto, sem a necessidade de se preocupar com o SQLServer e connection strings_
