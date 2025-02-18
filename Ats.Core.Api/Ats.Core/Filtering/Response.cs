﻿using System.Net;

using Ats.Shared;
using Ats.Shared.Enums;
using Ats.Shared.Exceptions;

namespace Ats.Core.Filtering
{
    public class Response<TData>
    {
        public TData? Data { get; set; }
        public int? TotalCount { get; set; }
        public List<ErrorDto>? Errors { get; set; }

        public HttpStatusCode Code { get; set; }

        public bool Succeeded => Errors == null || !Errors.Any();

        public static Response<TData> Success(TData result, int? totalCount = null)
        {
            int? recordCount = typeof(TData).IsArray ?
                (result as List<TData>)!.Count : null;

            return new Response<TData>()
            {
                Code = HttpStatusCode.OK,
                Data = result,
                TotalCount = totalCount ?? recordCount,
                Errors = null
            };
        }

        public static Response<TData> Error(HttpStatusCode code, ErrorCode errorCode, string message)
        {
            return new Response<TData>()
            {
                Code = code,
                Data = default,
                Errors = [new ErrorDto(errorCode, message)]
            };
        }

        public static Response<TData> Error(params ErrorDto[] errors)
        {
            return new Response<TData>()
            {
                Code = HttpStatusCode.BadRequest,
                Data = default,
                Errors = errors?.ToList()
            };
        }

        public static Response<TData> Error(HttpStatusCode code, params ErrorDto[] errors)
        {
            return new Response<TData>()
            {
                Code = code,
                Data = default,
                Errors = errors?.ToList()
            };
        }

        public static Response<TData> Exception(Exception ex)
        {
            if (ex.GetType() == typeof(RequestException))
            {
                var requestEx = ex as RequestException;
                var errors = requestEx!.Messages?
                    .Select(errorMessage => new ErrorDto(requestEx.Code, errorMessage))
                    .ToArray();

                return new Response<TData>()
                {
                    Code = HttpStatusCode.BadRequest,
                    Data = default,
                    Errors = errors?.ToList()
                };
            }
            else if (ex.GetType() == typeof(DatabaseAccessException))
            {
                var requestEx = ex as DatabaseAccessException;
                var errors = requestEx!.ErrorMessages?
                    .Select(errorMessage => new ErrorDto(ErrorCode.DatabaseError, errorMessage))
                    .ToArray();

                return new Response<TData>()
                {
                    Code = HttpStatusCode.BadRequest,
                    Data = default,
                    Errors = errors?.ToList()
                };
            }
            else if (ex.GetType() == typeof(UnprocessableException))
            {
                var requestEx = ex as UnprocessableException;
                var errors = requestEx!.Messages?
                    .Select(errorMessage => new ErrorDto(requestEx.Code, errorMessage))
                    .ToArray();

                return new Response<TData>()
                {
                    Code = HttpStatusCode.UnprocessableEntity,
                    Data = default,
                    Errors = errors?.ToList()
                };
            }
            return Error(new ErrorDto(ErrorCode.GenericError, ex.Message));
        }
    }
}
