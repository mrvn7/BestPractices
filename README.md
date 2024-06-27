<header>
    <h1>Sobre o Projeto</h1>
</header>

<br/>

<section>
    <article>
        <h2>Objetivo</h2>
        <p>Este projeto tem como objetivo demonstrar as melhores práticas na criação de uma API RESTful utilizando .NET e uma arquitetura baseada em Domain-Driven Design (DDD). Através deste projeto, busco apresentar uma aplicação bem estruturada, modular e fácil de manter, seguindo princípios de desenvolvimento de software de alta qualidade.</p>
    </article>
</section>

<br/>

<section>
    <article>
        <h2>Tecnologias Utilizadas</h2>
        <ul>
            🔥<strong>ASP.NET Core</strong>: Framework utilizado para desenvolver a API RESTful.<br>
            🔥<strong>Entity Framework Core</strong>: ORM para manipulação de dados e mapeamento objeto-relacional.<br>
            🔥<strong>Domain-Driven Design (DDD)</strong>: Abordagem de design utilizada para estruturar a aplicação de forma modular e coesa.<br>
            🔥<strong>Swagger</strong>: Ferramenta utilizada para documentação automática da API.<br>
            🔥<strong>xUnit e Moq</strong>: Ferramentas utilizadas para testes unitários e mock de dependências.<br>
            🔥<strong>AutoMapper</strong>: Biblioteca usada para mapeamento entre objetos.<br>
            🔥 <strong>Unit Of Work</strong>: Gerencia as transações e garante a consistência dos dados durante operações que envolvem múltiplas atualizações, inserções ou exclusões no banco de dados.<br>
        </ul>
    </article>
</section>



<br/>

<section>
    <article>
        <h2>Estrutura do Projeto</h2>
        <p>O projeto está organizado em diferentes camadas, seguindo os princípios do DDD:</p>
        <ul>
            <li><strong>API</strong>: Contém os controladores da API e a configuração inicial da aplicação.</li>
            <li><strong>Application</strong>: Implementa a lógica de aplicação, incluindo serviços e objetos de transferência de dados (DTOs).</li>
            <li><strong>Domain</strong>: Define as entidades do domínio, interfaces dos repositórios e serviços de domínio, além dos objetos de valor.</li>
            <li><strong>Infrastructure</strong>: Implementa os repositórios, configura o contexto do banco de dados e define as configurações de mapeamento.</li>
            <li><strong>Tests</strong>: Contém os testes unitários para as camadas de domínio, aplicação e infraestrutura.</li>
        </ul>
    </article>
</section>

<br/>

<section>
    <article>
        <h2>Funcionalidades</h2>
        <ul>
            <li><strong>Validação de Dados</strong>: Validação de entrada utilizando FluentValidation.</li>
            <li><strong>Documentação da API</strong>: Documentação automatizada utilizando Swagger.</li>
            <li><strong>Testes Automatizados</strong>: Testes unitários para garantir a qualidade e a robustez do código.</li>
        </ul>
    </article>
</section>

</body>
</html>
