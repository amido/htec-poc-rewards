using System.Net;

namespace Htec.Poc.Common.Exceptions;

public static class ExceptionCodeToHttpStatusCodeConverter
{
    internal static HttpStatusCode GetHttpStatusCode(int exceptionCode)
    {
        switch ((ExceptionCode)exceptionCode)
        {
            case Exceptions.ExceptionCode.UnauthorizedOperation:
                return HttpStatusCode.Unauthorized;
            case Exceptions.ExceptionCode.ForbiddenOperation:
                return HttpStatusCode.Forbidden;
            case Exceptions.ExceptionCode.BadRequest:
                return HttpStatusCode.BadRequest;
            case Exceptions.ExceptionCode.NotFound:
                return HttpStatusCode.NotFound;
            case Exceptions.ExceptionCode.Conflict:
                return HttpStatusCode.Conflict;
            case Exceptions.ExceptionCode.FeatureDisabled:
                return HttpStatusCode.NotFound;
            case Exceptions.ExceptionCode.CircuitBreakerEnabled:
                return HttpStatusCode.ServiceUnavailable;

            //Business related
            case Exceptions.ExceptionCode.RewardAlreadyExists:
            case Exceptions.ExceptionCode.CategoryAlreadyExists:
            case Exceptions.ExceptionCode.RewardItemAlreadyExists:
                return HttpStatusCode.Conflict;

            case Exceptions.ExceptionCode.RewardDoesNotExist:
            case Exceptions.ExceptionCode.CategoryDoesNotExist:
            case Exceptions.ExceptionCode.RewardItemDoesNotExist:
                return HttpStatusCode.NotFound;

            case Exceptions.ExceptionCode.RewardItemPriceMustNotBeZero:
            default:
                return HttpStatusCode.BadRequest;
        }
    }
}
