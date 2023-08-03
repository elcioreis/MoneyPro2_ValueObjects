﻿using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace MoneyPro2.Api.Extensions;

public static class ModelStateExtension
{
    public static List<string> GetErrors(this ModelStateDictionary modelState, string error = "")
    {
        var result = new List<string>();

        if (!string.IsNullOrEmpty(error))
        {
            result.Add(error);
        }

        foreach (var item in modelState.Values)
        {
            result.AddRange(item.Errors.Select(error => error.ErrorMessage));
        }

        return result;
    }
}
