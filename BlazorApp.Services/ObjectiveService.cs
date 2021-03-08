using AutoMapper;
using BlazorApp.Domains;
using BlazorApp.Shared;
using BlazorApp.UnitOfWork.Implementation;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorApp.Services
{
    public class ObjectiveService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ObjectiveService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<int> Delete(int id)
        {
            await _unitOfWork.Objectives.Delete(id);
            return await _unitOfWork.CompleteAsync();
        }

        public async Task<IReadOnlyList<ObjectiveViewModel>> Get()
        {
            var entries = await _unitOfWork.Objectives.Get();
            return _mapper.Map<IReadOnlyList<ObjectiveViewModel>>(entries);
        }

        public async Task<ObjectiveViewModel> Get(int id)
        {
            var entry = await _unitOfWork.Objectives.Get(id);
            return _mapper.Map<ObjectiveViewModel>(entry);
        }

        public async Task<int> Post(ObjectiveViewModel model)
        {
            var entry = _mapper.Map<Objective>(model);
            await _unitOfWork.Objectives.Post(entry);
            return await _unitOfWork.CompleteAsync();
        }

        public async Task<int> Put(ObjectiveViewModel model)
        {
            var entry = _mapper.Map<Objective>(model);
            await _unitOfWork.Objectives.Put(entry);
            return await _unitOfWork.CompleteAsync();
        }
    }
}
