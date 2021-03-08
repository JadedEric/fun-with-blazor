using AutoMapper;
using BlazorApp.Domains;
using BlazorApp.Shared;
using BlazorApp.UnitOfWork.Implementation;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp.Services
{
    public class RespondentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public RespondentService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<int> Delete(int id)
        {
            await _unitOfWork.Respondents.Delete(id);
            return await _unitOfWork.CompleteAsync();
        }

        public async Task<IReadOnlyList<RespondentViewModel>> Get()
        {
            var entries = await _unitOfWork.Respondents.Get();
            return _mapper.Map<IReadOnlyList<RespondentViewModel>>(entries);
        }

        public async Task<RespondentViewModel> Get(int id)
        {
            var entry = await _unitOfWork.Respondents.Get(id);
            return _mapper.Map<RespondentViewModel>(entry);
        }

        public async Task<int> Post(RespondentViewModel model)
        {
            var entry = _mapper.Map<Respondent>(model);
            await _unitOfWork.Respondents.Post(entry);
            return await _unitOfWork.CompleteAsync();
        }

        public async Task<int> Put(RespondentViewModel model)
        {
            var entry = _mapper.Map<Respondent>(model);
            await _unitOfWork.Respondents.Put(entry);
            return await _unitOfWork.CompleteAsync();
        }

        public async Task<bool> LoginAsync(RespondentViewModel model)
        {
            var entry = await _unitOfWork
                .Respondents
                .Entity
                .FirstOrDefaultAsync(entry => entry.Username == model.Username && entry.Password == model.Password);

            return entry != null;
        }
    }
}
