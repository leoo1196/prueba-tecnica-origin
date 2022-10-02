using Core.Results;

namespace Core.Extensions;
public static class TaskExtensions
{
    /// <summary>
    /// Extensión para encadenar a una tarea la ejecución de un método sincronico que retorna un <see cref="Result{TModel}"/>.
    /// </summary>
    /// <typeparam name="TModel">Tipo del resultado de la tarea.</typeparam>
    /// <typeparam name="TTransform">Tipo del resultado del siguiente método.</typeparam>
    /// <param name="task">Tarea actual.</param>
    /// <param name="next">Siguiente método a ejecutar.</param>
    /// <returns>Una tarea con el resultado de <paramref name="next"/>.</returns>
    public static async Task<Result<TTransform>> Then<TModel, TTransform>(this Task<Result<TModel>> task, Func<TModel, Result<TTransform>> next)
    {
        var result = await task;
        return result.Then(next);
    }

    /// <summary>
    /// Extensión para encadenar a una tarea la ejecución de un método asincronico que retorna un <see cref="Result{TModel}"/>.
    /// </summary>
    /// <typeparam name="TModel">Tipo del resultado de la tarea.</typeparam>
    /// <typeparam name="TTransform">Tipo del resultado del siguiente método.</typeparam>
    /// <param name="task">Tarea actual.</param>
    /// <param name="next">Siguiente método a ejecutar.</param>
    /// <returns>Una tarea con el resultado de <paramref name="next"/>.</returns>
    public static async Task<Result<TTransform>> Then<TModel, TTransform>(this Task<Result<TModel>> task, Func<TModel, Task<Result<TTransform>>> next)
    {
        var result = await task;
        return await result.Then(next);
    }
}