# HotChocolate public and private graphs issue

https://github.com/ChilliCream/hotchocolate/issues/1120

## About this codebase

It uses [ServiceStack](https://servicestack.net/).

It uses [HotChocolate 10.1.0](https://hotchocolate.io).

It attempts to serve 2 different graphs, based on the same shared graph.

- `http://localhost:5000/graphql`, which serves the **public** graph
- `http://localhost:5000/private_graphql`, which serves the **private** graph

See the Github issue linked at the top for more info.

## Check the result

`POST` to either of the endpoints with the following query to see the result :)

```text
query IntrospectionQuery {
   __type(name: "User") {
    name
    fields {
      name
    }
  }
}

```
