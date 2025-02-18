﻿using Ats.Shared.Enums;

namespace Ats.Shared.Exceptions
{
    public class DatabaseAccessException : Exception
    {
        public List<string>? ErrorMessages { get; }
        public DbErrorCode Code { get; }

        public DatabaseAccessException(DbErrorCode code, params string[] messages)
        {
            ErrorMessages = messages?.ToList();
            Code = code;
        }
    }
}
