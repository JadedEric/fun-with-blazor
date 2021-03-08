using AutoMapper;
using BlazorApp.Domains;
using BlazorApp.Shared;
using BlazorApp.UnitOfWork.Implementation;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorApp.Services
{
    public class ResultService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ResultService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<int> Delete(int id)
        {
            await _unitOfWork.Results.Delete(id);
            return await _unitOfWork.CompleteAsync();
        }

        public async Task<IReadOnlyList<ResultViewModel>> Get()
        {
            var entries = await _unitOfWork.Results.Get();
            return _mapper.Map<IReadOnlyList<ResultViewModel>>(entries);
        }

        public async Task<ResultViewModel> Get(int id)
        {
            var entry = await _unitOfWork.Results.Get(id);
            return _mapper.Map<ResultViewModel>(entry);
        }

        public async Task<int> Post(ResultViewModel model)
        {
            var entry = _mapper.Map<Result>(model);
            await _unitOfWork.Results.Post(entry);
            return await _unitOfWork.CompleteAsync();
        }

        public async Task<int> Put(ResultViewModel model)
        {
            var entry = _mapper.Map<Result>(model);
            await _unitOfWork.Results.Put(entry);
            return await _unitOfWork.CompleteAsync();
        }
    }
}
