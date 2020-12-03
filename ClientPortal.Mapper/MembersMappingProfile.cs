using AutoMapper;
using ClientPortal.Entities;
using ClientPortal.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClientPortal.Mapper
{
    public class MembersMappingProfile : Profile
    {
        public MembersMappingProfile()
        {
            CreateMap<Member, MemberViewModel>()
                .ForMember(memberViewModel => memberViewModel.MemberId, options => options.MapFrom(member => member.Id))
                .ForMember(memberViewModel => memberViewModel.Tasks, options => options.MapFrom(member => member.Tasks))
                .ForMember(memberViewModel => memberViewModel.Email, options => options.MapFrom(member => member.EmailAddress));

            CreateMap<MemberViewModel, Member>()
                .ForMember(member => member.Id, options => options.MapFrom(member => (member.MemberId == null || member.MemberId == new System.Guid()) ? System.Guid.NewGuid() : member.MemberId))
                .ForMember(member => member.EmailAddress, options => options.MapFrom(member => member.Email));
                //.ForMember(member => member.Tasks, options => options.Ignore());
        }
    }
}
