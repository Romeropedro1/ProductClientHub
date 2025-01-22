

```markdown
# ProductClienthub API

Este projeto é uma API RESTful construída com **ASP.NET Core**, que gerencia um conjunto simples de produtos. A API permite realizar operações CRUD (Criar, Ler, Atualizar, Excluir) em uma lista de produtos, e utiliza exceções personalizadas para tratar erros específicos. O projeto serve como uma base para aprender a implementar controladores, manipulação de exceções e validações de modelo.

## Funcionalidades

- **Listar Produtos:** Retorna todos os produtos cadastrados.
- **Buscar Produto por ID:** Recupera um produto específico através de seu ID.
- **Criar Produto:** Adiciona um novo produto à lista de produtos.
- **Atualizar Produto:** Atualiza os dados de um produto existente.
- **Excluir Produto:** Remove um produto da lista.

## Tecnologias Utilizadas

- **ASP.NET Core** para a construção da API.
- **Exceções Personalizadas** para tratamento de erros específicos de produto.
- **Validação de Modelo** para garantir a integridade dos dados de entrada.

## Endpoints

### 1. `GET /api/products`

Retorna todos os produtos.

#### Exemplo de Resposta:
```json
[
  { "id": 1, "name": "Product 1", "price": 100 },
  { "id": 2, "name": "Product 2", "price": 200 },
  { "id": 3, "name": "Product 3", "price": 300 }
]
```

### 2. `GET /api/products/{id}`

Retorna um produto específico baseado no ID fornecido.

#### Exemplo de Resposta (Produto encontrado):
```json
{ "id": 1, "name": "Product 1", "price": 100 }
```

#### Exemplo de Resposta (Produto não encontrado):
Status HTTP: 404 (Not Found)

### 3. `POST /api/products`

Cria um novo produto.

#### Corpo da Requisição:
```json
{
  "name": "New Product",
  "price": 150
}
```

#### Exemplo de Resposta:
Status HTTP: 201 (Created)

```json
{ "id": 4, "name": "New Product", "price": 150 }
```

### 4. `PUT /api/products/{id}`

Atualiza um produto existente.

#### Corpo da Requisição:
```json
{
  "name": "Updated Product",
  "price": 250
}
```

#### Exemplo de Resposta:
Status HTTP: 204 (No Content)

### 5. `DELETE /api/products/{id}`

Exclui um produto existente.

#### Exemplo de Resposta:
Status HTTP: 204 (No Content)

---

## Exceções Personalizadas

O projeto implementa uma exceção personalizada chamada `ProductNotFoundException` que é lançada quando um produto não é encontrado nas operações de busca, atualização ou exclusão. A exceção retorna um código de status 404 e uma mensagem de erro indicando que o produto não foi encontrado.

Exemplo de exceção:
```json
{
  "error": "Produto com ID 1 não encontrado"
}
```

## Validação de Modelos

Antes de criar ou atualizar um produto, a API valida os dados recebidos. Caso o modelo enviado não seja válido (por exemplo, se algum campo obrigatório estiver ausente ou mal formatado), a resposta será um código de status 400 com os detalhes dos erros de validação.

Exemplo de erro de validação:
```json
{
  "errors": {
    "Name": ["The Name field is required."]
  }
}
```

## Como Rodar o Projeto

1. **Clone o repositório:**
   ```
   git clone https://github.com/seu-usuario/ProductClienthub.git
   ```

2. **Instale as dependências do projeto:**
   ```
   dotnet restore
   ```

3. **Execute o projeto:**
   ```
   dotnet run
   ```

4. A API estará disponível em `http://localhost:5000`.

## Contribuições

Sinta-se à vontade para contribuir com melhorias, correções de bugs ou novas funcionalidades. Para isso, basta fazer um fork do repositório, criar uma branch com a sua mudança e enviar um pull request.

## Licença

Este projeto está licenciado sob a licença MIT - veja o arquivo [LICENSE](LICENSE) para mais detalhes.

---

Este é um exemplo simples de uma API para gerenciar produtos, mas pode ser expandido com novas funcionalidades, como autenticação, banco de dados real e testes automatizados, conforme necessário.
```

