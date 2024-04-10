namespace NorthWind.Result.Entities;
public class Result<SuccessResultType, ErrorResultType> : Result<ErrorResultType>
{
    public SuccessResultType SuccessValue { get; private set; }
    public Result(SuccessResultType successValue) : base()
    {
        SuccessValue = successValue;        
    }

    public Result(ErrorResultType errorValue) : base(errorValue)
    {      
    }

    public void HandleError(Action<SuccessResultType> whenIsSuccess, Action<ErrorResultType> whenHasError)
    {
        if (HasError) whenHasError(ErrorValue);
        else whenIsSuccess(SuccessValue);
    }
}
