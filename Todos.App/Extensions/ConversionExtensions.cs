namespace Todos.App.Extensions;

public static class ConversionExtensions
{
    public static bool ToBool(this object? o) => o is not null && Convert.ToBoolean(o);
}
