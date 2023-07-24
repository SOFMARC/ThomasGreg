# ThomasGreg
Project API rest (Microserviços) With Front-and MVC

Este projeto é composto por uma aplicação web frontend construída utilizando o padrão Model-View-Controller (MVC) e uma API web backend estruturada em uma arquitetura de microserviços.
A solução é dividida em duas partes principais:

Frontend MVC: A interface do usuário é construída em uma arquitetura de camadas para promover a modularidade e a facilidade de manutenção. Esta arquitetura também foi escolhida para facilitar uma possível migração para a nuvem no futuro.
API Web Backend: O backend está estruturado como microserviços, onde cada serviço tem um propósito específico e opera de forma independente. A arquitetura de microserviços permite que cada serviço seja escalado independentemente conforme necessário.

Os microserviços consistem em:

Serviço de Autenticação: Este microserviço é responsável pela autenticação de usuários. Ele opera em seu próprio banco de dados dedicado para garantir um desempenho otimizado e manter a segurança dos dados do usuário.
Serviço de Cadastro de Clientes: Este microserviço gerencia todas as operações relacionadas aos clientes, incluindo criação, leitura, atualização e exclusão de registros de clientes (operações CRUD). Ele também opera em seu próprio banco de dados dedicado.
O projeto utiliza AutoMapper para simplificar o mapeamento de objetos, e implementa tratamento de erros e regras de negócios para garantir que a aplicação opere de forma robusta e confiável.

########## ATUALIZAÇÕES E CORREÇÕES ############
O projeto precisa ser feito mais testes para correção de bugs e prevenir algumas falhas.
Inclusão de log de erros.
Testes Unitários e de Integração:
Encapsulamento de serviços de dominio dividindo assim a logica de negocio.

## Instalação

Siga estes passos para instalar e configurar este projeto em seu ambiente local:

1. Clone este repositório: `git clone https://github.com/username/repo.git](https://github.com/SOFMARC/ThomasGreg/tree/master`
2. Navegue para o diretório BANCOS: RESTAURE OS BANCOS DE DADOS, INFORME AS INFORMAÇÕES DOS BANCOS NAS PROXIMAS ETAPAS
3. Navegue para o diretório RELEASES: abra o projeto AUTH API. Abra o arquivo appsettings.json
   {
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*",
  "ConnectionStrings": {
    "DefaultConnection": "Server=DESKTOP-GA80BOH\\SQLEXPRESS;Database=AuthDb;Trusted_Connection=True;TrustServerCertificate=true;"
  },
  "Jwt": {
    "Secret": "asdg356gfsDs@536ffRE",
    "Issuer": "https://localhost:7250",
    "Audience": "https://localhost:7250"
  }
}
Altere as informações conforme o seu ambiente, Issuer, Audience,DefaultConnection
Essa release deve ser hospedada em um servidor windows.

3.Navegue para o diretório RELEASES: abra o projeto CLIENTE SERVICE API. Abra o arquivo appsettings.json 
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*",
  "ConnectionStrings": {
    "DefaultConnection": "Server=DESKTOP-GA80BOH\\SQLEXPRESS;Database=ThomasGreg;Trusted_Connection=True;TrustServerCertificate=true;"
  }
}
Altere as informações conforme o seu ambiente DefaultConnection
Essa release deve ser hospedada em um servidor windows.

4. Navegue para o diretório RELEASES: abra o projeto FRONT. Abra o arquivo appsettings.json 
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft": "Warning",
      "Microsoft.Hosting.Lifetime": "Information"
    }
  },
  "AllowedHosts": "*",
  "AuthApiSettings": {
    "BaseApiUrl": "https://localhost:7228/api/Auth",
    "Username": "tsilva",
    "Password": "064248thi@GOa"
  },
  "ApiSettings": {
    "BaseApiUrl": "https://localhost:7250/api"
  }
}

Agora deve ser feito o apontamento dos outros dois projetos corretamente.
############AQUI PARA O PROJETO DE AUTENTICAÇÃO ##########################
 "AuthApiSettings": {
    "BaseApiUrl": "https://localhost:7228/api/Auth",
    "Username": "tsilva",
    "Password": "064248thi@GOa"
  },

  ############AQUI PARA O PROJETO DE FRONT-END ##########################
   "ApiSettings": {
    "BaseApiUrl": "https://localhost:7250/api"
  }


