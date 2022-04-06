using Domain.Base;
using Domain.Configuration;
using AutoMapper;

namespace Aplication.Base
{
    public abstract class BaseService
    {
        protected string NameService { get; }
        public BaseService()
        {
            NameService = this.GetType().ToString();
        }
    }

    public class CustomService<T> : BaseService, IService<T> where T : BaseEntidad
    {
        protected readonly IUnitOfWorkRepository _unitOfWork;
        protected readonly IMapper _mapper;

        protected CustomService(IUnitOfWorkRepository unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
    }
}
