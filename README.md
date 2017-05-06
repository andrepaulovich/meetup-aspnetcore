# README #

Este é um template de aplicação ASP.NET CORE, para funcionar como authservice.

## URLS ##

**Teste simples de repositorio com Automapper**
* Obter dados do banco de dados: http://localhost:5000/api/user

**Teste de obtenção de configuração da cloud**
* Obter dados de configuração cloud: http://localhost:5000/api/config

**Teste de exibição do Swagger**
* Exibe o dashboard de actions do serviço: http://localhost:5000/swagger

## AUTHORIZATION ##

**Teste de Geração de Token**
URL para autenticação do usuário, gere dois tokens um para um usuário com todas as roles:

```
#!python
POST /token
Content-Type: application/x-www-form-urlencoded
username=andre&password=parmegiana
```

e outro para um usuário que não possua todos os acessos.

```
#!python
POST /token
Content-Type: application/x-www-form-urlencoded
Body: username=tanato&password=bolacha
```

**Teste de Autenticação**
esta URL só deve ser carregada com token valido, caso contrário enviará código 401

```
#!python
GET /api/user
Header: Authorization: Bearer {token gerado para o andre}
```

A tela deve carregar as informações corretamente, pois além de logado, o usuário andrepg possui a role necessária para executar esta URL.

```
#!python
GET /api/user/4
Header: Authorization: Bearer {token gerado para o tanato}
```

Deve carregar normalmente, pois esta URL precisa apenas de que o usuário esteja logado.

**Teste de Geração de Refresh Token**
URL para "esquentar" um token que esteja "expirando" e manter a "sessão do usuário" ativa.

```
#!python
POST /token
Content-Type: application/x-www-form-urlencoded
Header: Authorization: Bearer {token gerado para o andre}
Body: refresh_token=31b0c265-258a-44eb-a350-2297a8808d7f
```

Deve-se enviar o jwtId que está embutido no token de barreira. Para que o refresh token seja gerado, é necesário enviar além do jwtId o cabeçalho com um token ainda válido. O Sistema irá gerar um novo token que deve ser armazenado pelo cliente no lugar do anterior.