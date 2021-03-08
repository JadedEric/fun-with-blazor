using AutoMapper;
using BlazorApp.Domains;
using BlazorApp.Shared;
using BlazorApp.UnitOfWork.Implementation;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorApp.Services
{
    public class QuestionService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public QuestionService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<int> Delete(int id)
        {
            await _unitOfWork.Objectives.Delete(id);
            return await _unitOfWork.CompleteAsync();
        }

        public async Task<IReadOnlyList<QuestionViewModel>> Get()
        {
            var entries = await _unitOfWork.Questions.Get();
            return _mapper.Map<IReadOnlyList<QuestionViewModel>>(entries);
        }

        public async Task<QuestionViewModel> Get(int id)
        {
            var entry = await _unitOfWork.Questions.Get(id);
            return _mapper.Map<QuestionViewModel>(entry);
        }

        public async Task<int> Post(QuestionViewModel model)
        {
            var entry = _mapper.Map<Question>(model);
            await _unitOfWork.Questions.Post(entry);
            return await _unitOfWork.CompleteAsync();
        }

        public async Task<int> Put(QuestionViewModel model)
        {
            var entry = _mapper.Map<Question>(model);
            await _unitOfWork.Questions.Put(entry);
            return await _unitOfWork.CompleteAsync();
        }
    }
}
