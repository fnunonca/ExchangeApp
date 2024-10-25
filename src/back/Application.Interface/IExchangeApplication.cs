using Application.DTO;

namespace Application.Interface
{
    public interface IExchangeApplication
    {
        Task<ResponseBaseDto<ResponseExchangeDto>> Process(RequestExchangeDto request);
    }
}
