//using BlazorBase.Domain.Exceptions;
//using BlazorBase.Shared.Entities;
//using BlazorBase.Shared.Enums;
//using Microsoft.AspNetCore.Mvc;

//namespace BlazorBase.Server.Framework
//{
//    public class ControllerBase : Microsoft.AspNetCore.Mvc.ControllerBase
//    {
//        protected RequestResult Excute(Action action)
//        {
//            try
//            {
//                action?.Invoke();
//                return RequestResult.CreateSuccess();
//            }
//            catch (SaveErrorExcenption ex)
//            {
//                return RequestResult.CreateFailure(ErrorType.Save, ex.Message);
//            }
//            catch (Exception ex)
//            {
//                return RequestResult.CreateFailure(ErrorType.Other, ex.Message);
//            }
//        }
//    }
//}
