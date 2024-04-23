namespace Market.DAL;

internal record DbResult(DbResultStatus Status)
{
    public static DbResult Ok() => new DbResult(DbResultStatus.Ok);
    public static DbResult NotFound() => new DbResult(DbResultStatus.NotFound);
    public static DbResult UnknownError() => new DbResult(DbResultStatus.UnknownError);
}

internal record DbResult<T>(T Result, DbResultStatus Status)
{
    public static DbResult<T> Ok(T result) => new DbResult<T>(result, DbResultStatus.Ok);
    public static DbResult<T> NotFound(T result) => new DbResult<T>(result, DbResultStatus.NotFound);
    public static DbResult<T> UnknownError(T result) => new DbResult<T>(result, DbResultStatus.UnknownError);
}

