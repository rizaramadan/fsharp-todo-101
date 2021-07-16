namespace Shared

open System

//Route is used because we are overriding default behavior of Fable.Remoting path, we're adding api as a prefix
module Route =
    let builder typeName methodName =
        sprintf "/api/%s/%s" typeName methodName

type Todo = { Id: Guid; Description: string }

module MyTodo =
    let isValid description =
        String.IsNullOrWhiteSpace description |> not

    let create description =
        { Id = Guid.NewGuid()
          Description = description }

type ITodosApi =
    { getTodos: unit -> Async<Todo list>
      addTodo: Todo -> Async<Todo> }
