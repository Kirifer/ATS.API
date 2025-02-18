﻿using Ats.Shared.Enums;

namespace Ats.Shared
{
    public class ErrorDto
    {
        public ErrorCode Code { get; set; }

        public string Message { get; set; }

        public ErrorDto(ErrorCode code, string message)
        {
            Code = code;
            Message = message;
        }
    }
}
