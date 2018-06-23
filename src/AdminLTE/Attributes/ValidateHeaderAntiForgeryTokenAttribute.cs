using System;
using Microsoft.AspNetCore.Antiforgery;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;

namespace SGEJ.Attributes
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
    public sealed class ValidateHeaderAntiForgeryTokenAttribute : ActionFilterAttribute
    {
        private const string CookieName = "XSRF-TOKEN";
        private readonly IAntiforgery _antiforgery;

        public ValidateHeaderAntiForgeryTokenAttribute(IAntiforgery antiforgery)
        {
            this._antiforgery = antiforgery;
        }

        public override void OnResultExecuting(ResultExecutingContext context)
        {
            base.OnResultExecuting(context);

            if (context.Cancel) return;
            var tokens = _antiforgery.GetAndStoreTokens(context.HttpContext);

            context.HttpContext.Response.Cookies.Append(
                CookieName,
                tokens.RequestToken,
                new CookieOptions { HttpOnly = false });
        }
    }
}