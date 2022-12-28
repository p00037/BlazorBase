using BlazorBase.Domain.Exceptions;
using BlazorBase.Shared.Entities;
using BlazorBase.Shared.Enums;

namespace BlazorBase.Server.Controllers
{
    public class ApiResult
    {
        public static async Task<RequestResult> ExecuteAsync(Func<Task> action)
        {
            try
            {
                await action();
                return RequestResult.CreateSuccess();
            }
            catch (SaveErrorExcenption ex)
            {
                return RequestResult.CreateFailure(ErrorType.Save, ex.Message);
            }
            catch (Exception ex)
            {
                return RequestResult.CreateFailure(ErrorType.Other, ex.Message);
            }
        }
    }
}
