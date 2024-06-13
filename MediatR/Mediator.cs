using Microsoft.Extensions.DependencyInjection;

namespace MediatR
{
    public class Mediator : IMediator
    {
        private readonly IServiceScopeFactory _serviceScopeFactory;

        public Mediator(IServiceScopeFactory serviceScopeFactory)
        {
            _serviceScopeFactory = serviceScopeFactory;
        }

        public async Task<TResponse> Send<TResponse>(IRequest<TResponse> request)
        {
            Type handlerType = typeof(IHandler<,>).MakeGenericType(request.GetType(), typeof(TResponse));
            dynamic handler = GetHandler(handlerType);
            return await handler.Handle((dynamic)request);
        }

        private dynamic GetHandler(Type handlerType)
        {
            using (var scope = _serviceScopeFactory.CreateScope())
            {
                return scope.ServiceProvider.GetService(handlerType);
            }
        }
    }
}
