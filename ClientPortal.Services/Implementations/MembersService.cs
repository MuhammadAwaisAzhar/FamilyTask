using AutoMapper;
using ClientPortal.Entities;
using ClientPortal.Models;
using ClientPortal.Repositories.Interfaces;
using ClientPortal.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClientPortal.Services.Implementations
{
    public class MembersService : ServiceBase<MemberViewModel, Member>, IMembersService
    {
        private readonly IMembersRepository _membersRepository;
        private readonly IMapper _mapper;

        public MembersService(IMembersRepository membersRepository, IMapper mapper) : base(membersRepository, mapper)
        {
            _membersRepository = membersRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<MemberViewModel>> GetMemberTaskDetailsAsync()
        {
            return _mapper.Map<IEnumerable<MemberViewModel>>(await _membersRepository.GetMemberTaskDetailsAsync());
        }
    }
}
