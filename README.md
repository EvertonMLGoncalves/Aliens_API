# Aliens API e Modulo de E-mails  
[![](https://img.shields.io/badge/.NET-5C2D91?style=for-the-badge&logo=.net&logoColor=white)]()
[![](https://img.shields.io/badge/Visual_Studio-5C2D91?style=for-the-badge&logo=visual%20studio&logoColor=white)]()
[![](https://img.shields.io/badge/Microsoft_SQL_Server-CC2927?style=for-the-badge&logo=microsoft-sql-server&logoColor=white)]() 
 
# Colaboradores 
- Everton M. L. Gonçalves 
- Bernardo C.
- Lucas C.Belletti
- Matheus Eduardo
## Sobre o nosso projeto: 
### O objeto do nosso projeto é construir uma API para controle de entrada e saída de aliens da terra conforme solicitado pelo nosso instrutor. Nós utilizamos o ASP .NET para construir a API, e o Entity framework para acessar o banco de dados. Como funcionalidade extra, adicionamos um módulo de envio de e-mails, que envia um e-mail para o e-mail fornecido pelo usuário na hora do cadastro sempre que um Alien é cadastrado ou atualizado.
### Existem três entidades básicas, sendo elas: 
* ## Alien 
* ## Poder 
* ## Planeta  
### A entidade Alien possui uma relação de n para n com a Entidade Poder e outra relação de n para 1 com a entidade Planeta.  
 
## Pré-requisitos: 
### Para utilizar nosso projeto, você deverá ter os seguintes programas instalados em seu computador: 
 1. ### Visual Studio (de preferência) ou Visual Studio Code;  
2.  ### SQL Server 
 
## Instalação - AliensAPI 
### Para instalar, siga os seguintes passos: 
1. ## Abra um repositório local (utilizando o git bash ou alguma ferramenta com interface gráfica): 
```bash 
git init
``` 
2. ## Execute o comando git clone para clonar o repositório do GitHub: 
```bash 
git clone https://github.com/EvertonMLGoncalves/Aliens_API
```
3. ## Após clonar o repositório, abra o projeto "AliensAPI" e localize o arquivo chamado appsettings.json. Após abrí-lo, mude o primeiro valor de "server" da string "DefaultConnect" colocando o seu banco de dados: 
```json
"ConnectionStrings": {
    "DefaultConnection": "server=SEU-SERVIDOR-SQL-SERVER;database=alienDb;trusted_connection=true;TrustServerCertificate=True"
  },
``` 
#### Dica: o nome do servidor pode ser obtido abrindo o SQL Server Management Studio (SSMS) no seu computador. Caso não possua, é recomendável a sua instalação 
4. ## Utilize (Ctrl + Q) e busque pelo "Console do gerenciador de pacotes". Após ter feito isso, execute dois comandos: 
```console
add-migration (qualquer_nome)
``` 
```console
update-database
``` 
#### Após ter feito isso, sua solução deve estar pronta para rodar. Fique atento aos próximos passos para a configuração do módulo de envio de e-mails.
  
## Instalação - Módulo de Envio de E-mails 
### Para instalar, siga os seguintes passos: 
1. ## Localize o arquivo appsettings.json e altere os seguintes dados:
```json 
"EmailHost": "seu_serviço_de_mensageria"
```
```json 
"EmailUsername": "seu_usuário@servico.com"
```
```json
"EmailPassword": "sua_senha"
``` 
#### Após ter feito isso, seu módulo de envio de e-mail deve estar pronto para o uso. Lembrando que seu endereço é: 
```
https://localhost:7043/api/Email
``` 
 
## Descrição - ALienAPI 
#### Nessa sessão será explicado cada componente da ALiensAPI. 
1. ## Program.cs:
- É onde toda a aplicação é executada; 
- Executa a conexão com o banco;
- Contém os escopos, que é o que permite a injeção de dependências. 
2. ## Appsetings.Json 
- É aqui que é estabelecido qual servidor SQL-Server será utilizado, junto com o nome da base de dados. 

3. ## Pasta Service 
- Contém as interfaces e as classes services de cada entidade; 
- Cada classe service contém uma injeção de dependências de DataContext, o que permite o acesso ao banco;
- As classes services que são responsáveis pelo acesso ao banco, sendo executadas nos controladores para realizar as funções relacionadas à cada rota.

4. ## Pasta Models 
- É aqui onde estão localizadas as nossas três classes; primordiais: Alien, Poder e Planeta.
 
5. ## Pasta Migrations 
- São as migrações, ou seja, a parte responsável pela criação das tabelas no banco de dados.
 
 6. ## Pasta EmailModule 
 - Contém a interface ISmtp e a classe Smtp, que é responsável pelo envio de e-mails através da requisição feita ao módulo de e-mails. 
  
7. ## Pasta DTOs 
- É onde todas as classes DTOs estão localizadas;
- As DTOs são utilizadas para o cadastro, retorno e atualizações de Aliens, Planetas e Poderes na classe service;
- Elas também são utilizadas nos controladores, para poderem ser utilizadas como parâmetros para os métodos das classes services.  
 
8. ## Pasta Data 
- Contém a classe DataContext, que herda de DbContext;
- É aqui que é arquitetado como as conexões com o banco da dados irão funcionar. 
 
9. ## Pasta Controllers 
- Contém os controladores que atenderão às requisições HTTP;
- Os controladores também são responsáveis pela validação de dados.
  
## Descrição - Modulo de E-mails 
#### Nessa sessão será explicado cada componente do módulo de e-mails. 
1.  ## Program.cs 
- Executa toda a API e contém os escopos de IEmailService e Email_Service.
 
2. ## Service 
- Contém a interface IEmailService e a classe Email_Service;
- É aqui que toda a lógica de envio de e-mails é feita e executada.
 
 3. ## Pasta DTOs 
 - Contém a classe DTO de email, que serve para pegar as informações necessárias para o envio de e-mails. 
  
4. ## Pasta Controllers 
- A classe controller de e-mails contém uma injeção de dependências de IEmailService;
- A classe controller também é responsável por atender às requisições HTTP POST de envio de e-mails.
  
## Agradecimentos 
### Agradecemos a Blusoft e a todos envolvidos no programa +Devs2Blu por nos proporcionar a oportunidade de estar desenvolvendo as tecnologias aqui apresentadas. 
 
## Licença: 
### Licença MIT.





 

