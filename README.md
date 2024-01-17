Projeto CRUD de cadastro de clientes e telefones

O projeto foi feito com o modelo de Clean Architeture.

A estrutura do projeto fico da seguinte forma
 - API
   - Api  
 - Core
   - Application
   - Domain
 - Infrastructure
   - Infrastructure
   - Persistence
  
- Test
  - UnitTests
 
Foi utilizado o padrão Mediator e Mapper para manter um fraco acomplamento entre as classes.
Para validação foi utilizado o FluentValidator, assim como a implementação de alguns logs com o Serilog.

Desenvolvido em .Net 6.0 com base de dados SQLLite
