using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace WeekDayMapper.Domain.Shared
{
    public readonly struct Result_<T>
    {
        private readonly bool _success;
        public readonly T Value;
        public readonly string Error;

        private Result_(T v, string e, bool success)
        {
            Value = v;
            Error = e;
            _success = success;
        }

        public bool IsSuccess => _success;
        public bool IsFailure => !_success;

        public static Result_<T> Success(T v)
        {
            return new(v, "", true);
        }

        public static Result_<T> Failure(string e)
        {
            return new(default(T), e, false);
        }

        public static implicit operator Result_<T>(T v) => new(v, "", true);
        public static implicit operator Result_<T>(string e) => new(default(T), e, false);

        public R Match<R>(
            Func<T, R> success,
            Func<string, R> failure) =>
            _success ? success(Value) : failure(Error);
    }
}
