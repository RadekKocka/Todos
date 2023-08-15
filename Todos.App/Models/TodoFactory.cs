namespace Todos.App.Models;

public class TodoFactory
{
    List<Todo> todos = new();

    public List<Todo> GetTodos() => todos.GetRange(0, todos.Count);
    public bool Update(bool completed, Todo todo)
    {
        try
        {
            todo.Completed = completed;
        }
        catch
        {
            return false;
        }
        return true;
    }

    public void DeleteTodo(Todo todo)
    {
        todos.Remove(todo);
    }

    public void AddTodo(string description)
    {
        if (string.IsNullOrEmpty(description))
        {
            throw new ArgumentNullException(null, "Description cannot be empty!");
        }

        if (TodoExists(description))
        {
            throw new ArgumentException("Todo already exists!");
        }

        try
        {
            int newId = todos.Count().Equals(0) ? 1 : todos.Max(x => x.Id) + 1;
            Todo newTodo = new()
            {
                Id = newId,
                Description = description
            };
            todos.Add(newTodo);
        }
        catch
        {
            throw;
        }
    }
    private bool TodoExists(string description)
    {
        return todos.Any(x => x.Description == description);
    }
}
