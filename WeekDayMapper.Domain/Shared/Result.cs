using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeekDayMapper.Domain.Shared
{
    public abstract class Result<T>
    {
        public bool Success { get; private set; }
        public string Error { get; private set; }
        public T value { get; private set; }

        public Result(T data)
        {
            Success = true;
            value = data;
        }

        public Result(string error)
        {
            Error = error;
        }
    }
}
