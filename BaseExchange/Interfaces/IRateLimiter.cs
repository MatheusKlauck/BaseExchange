using BaseExchange.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseExchange.Interfaces
{
    public interface IRateLimiter
    {
        CallResult<double> LimitRequest(string url, RateLimitingBehaviour limitBehaviour);
    }
}
