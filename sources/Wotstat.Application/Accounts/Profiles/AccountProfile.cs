namespace Wotstat.Application.Accounts.Profiles
{
    using AutoMapper;
    using Domain.Model;
    using JetBrains.Annotations;
    using ViewModels;

    [UsedImplicitly]
    public class AccountProfile : Profile
    {
        protected override void Configure()
        {
            CreateMap<UserResponseModel, Account>()
                .ForMember(x => x.Name, x => x.MapFrom(z => z.Nickname))
                .ForMember(x => x.PlayerId, x => x.MapFrom(z => z.Id));

        }
    }
}