# Monolito Modular

## 🔎 Oque é ?
O monolito modular, também conhecido como modulito, é uma solução, proposta pela Google através do framework "Service Weaver", que nos permite juntar o melhor dos dois mundos: a velocidade de desenvolvimento de um monolito com a escalabilidade, segurança  e tolerância a falhas dos microserviços. Esta arquitetura tem a capacidade de manter as escolhas em aberto, ou seja, pode evoluir para um monolito clássico ou para uma arquitetura em microserviços conforme a necessidade do aplicativo. A figura abaixo ilustra as diferenças entre ambas as arquiteturas.

![Monolito](img/CompairMM.png)  
*Figura: Comparação entre monolito, monolito modular e microserviços. Fonte:*

Algumas características cruciais dos monolitos modulares são:
- Segregação de módulos : Cada módulo é independente, assim como nos microserviços, com cada um deles contendo seu próprio conjunto de testes.  
- Modularidade com baixo acoplamento e alta coesão: Comunicação entre módulos ocorre através de APIs. De preferência, adotando comunicação assincrona entre os módulos.
- Base de dados únificada 
- Estrutura de deploy similar ao monolíto: operam todas em uma máquina virtual ou todas em máquinas virtuais dedicadas, a escala dos módulos tornam a conteinerização deles impraticável.
- Processo de aplicação unificada: aplicação opera como um único processo, oferecendo uma solução uniforme além de velocidade e simplicidade no desenvolvimento.
- Manutenabilidade e escalabilidade: 

Quanto a estutura de código , o monolito modular deve conter vários modulos funcionais sendo  utilizado uma interface que liga-o com o mundo exterior. A literatura propoe uma estutura geral dividida em duas maneiras: 
- Externamente: o módulo oferece uma API que se comunica via REST HTTP ou GRPC com as chamadas sendo gerenciadas por um proxy ou gateway.
- Internamente: Os serviços acessam um módulo via uma interface abstrata permitindo a obtenção de informações sem acesso direto à implementação.

Quanto à testabilidade do monólito modular, como já mencionado, cada módulo pode ser testado individualmente. Além disso, ao contrário da arquitetura de microserviços, é possível realizar testes de integração de forma mais simples e eficiente, pois todos os módulos estão contidos na mesma aplicação. Ademais é essencial que os desenvolvedores revisem e refatorem regularmente o monólito modular, mantendo a base de código organizada, de fácil manutenção e adaptável a mudanças nos requisitos de negócio.

## 📎 Provas de conceito

Para submeter o monolito modular as provas de conceito, os modulos foram separados da mesma maneira dos microserviços além de também ser utilizado a arquitetura onion para realizar a comunicação interna dos módulos. Ao desenvolver o modulito, foi observado muita facilidade para testar a aplicação, além de, como sugerido pela literatura, uma facilidade para transicionar entre o monolito clássico e os microserviços. Todavia, ao se desenvolver, mostrou uma repetição grande dos processos, oque pode gerar fácilmente uma repetição de código caso não refatorado.


## 📖 Referências

## 📅 Versionamento

| Versão |    Data    |         Descrição          |  Autor(es)  |
| :----: | :--------: | :------------------------: | :---------: |
| `1.0`  | 04/12/2024 | Criação de documento | Kauã |
