# EstacionamentoAPI 
***Em Desenvolvimento***

<p>EstacionametoAPI é uma API desenvolvida utilizando o ASP.NET WebAPI, servindo para controle de diversos estacionamentos. Ela permitirá que o usuário possa cadastrar carros e estacionamentos, além de conseguir informar quais carros estão estacionados.</p>

## Diagrama de projeto

<p>Para melhor exemplicação e visualização da estrutura da API, foi desenvolvido um pequeno diagrama que mostra o comportamento desejado (Pode sofrer alterações no futuro)</p>

![Diagrama da estrutura da API](https://cdn.discordapp.com/attachments/396792372736032778/1194996002420166757/Estacionamneto.drawio_1.png?ex=65b261c0&is=659fecc0&hm=932f3d08dd7a9b5ff4abda801ee7806b9d3dae132959a78bea39c9027b77f975&)

## Execução
<p>
Para executar o projeto, basta você usar o <code>git clone https://github.com/hav0kinho/EstacionamentoAPI.git</code>

Com o código na sua máquina, basta você entrar no diretório da aplicação com um <code>cd EstacionamentoAPI</code> e então utilizar <code>dotnet build</code> para instalar os pacotes e preparar o código para execução. Após isso, basta usar o <code>dotnet run</code> para inicializar a API.
</p>

## Features
#### Resumo

O sistema conta com dois controllers para requisições ao servidor, sendo elas o <code>CarroController</code>, que lida com a parte de criação de carros no Banco de dados, e <code>EstacionamentoController</code>, que permite que o usuário crie novos estacionamentos e cadastre carros a eles.

#### Rotas

*O projeto ainda está em desenvolvimento inicial, então ainda não existem rotas para serem explicitadas aqui!*

#### Banco de dados

*O banco implementado está usando o EntityFramework, utilizando o InMemory como banco de dados para facilitar a execução do projeto, sem a necessidade de se preocupar com o SQLServer e connection strings*



