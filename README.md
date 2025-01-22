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

