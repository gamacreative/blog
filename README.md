# blog

Desenvolvimento de um blog sobre Mudanças, primeira casa e morar sozinho para o GAMA #03

A ideia inicial do desenvolvimento era ser feito um front end SPA com um background independente mas em vista do tempo que tinhamos mudamos a estratégia para um MVC.

Utilizamos o MVC do ASP.NET core e depois mudamos para o 4.6 utilizando algumas ferramentas do core por causa de servidor para deploy.

Usamos o banco de dados SQL server 2014 acessando o mesmo com Entity Framework Core.

Para testar o nosso projeto abra o arquivo Blog.MVC.xproj no Visual Studio 2015, altere a connectionString no arquivo "appsettings.json" para um banco de dados válido e clique em iniciar.