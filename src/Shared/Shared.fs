namespace Shared

open System

//Route is used because we are overriding default behavior of Fable.Remoting path, we're adding api as a prefix
module Route =
    let builder typeName methodName =
        sprintf "/api/%s/%s" typeName methodName

//type Todo is data structure for both server and client
type Todo = { Id: Guid; Description: string }

//MyTodo helper to create and validate todo
module MyTodo =
    let isValid description =
        String.IsNullOrWhiteSpace description |> not

    let create description =
        { Id = Guid.NewGuid()
          Description = description }

//ITodosApi is the interface for the RPC, Server will implement it and client will calling it
type ITodosApi =
    { getTodos: unit -> Async<Todo list>
      addTodo: Todo -> Async<Todo> }
