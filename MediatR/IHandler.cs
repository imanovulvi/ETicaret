using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediatR
{
    public interface IHandler<TRequest,TResponse> where TRequest:IRequest<TResponse>
    {
        TResponse Handle(TRequest reuquest);
    }
}
