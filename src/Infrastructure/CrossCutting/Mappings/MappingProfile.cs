using AutoMapper;
using Domain.Dtos.Category;
using Domain.Dtos.Entrance;
using Domain.Dtos.User;
using Domain.Dtos.Wallet;
using Domain.Dtos.WalletType;
using Domain.Entities;

namespace CrossCutting.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // User
            CreateMap<UserCreateDto, User>();
            // This option will prevent AutoMapper to replace fields that not will be updated to null
            CreateMap<UserUpdateDto, User>()
                .ReverseMap()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<User, UserResultDto>().ReverseMap();

            // Wallet
            CreateMap<WalletCreateDto, Wallet>();
            // This option will prevent AutoMapper to replace fields that not will be updated to null
            CreateMap<WalletUpdateDto, Wallet>()
                .ReverseMap()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<Wallet, WalletResultDto>().ReverseMap();

            // WalletType
            CreateMap<WalletTypeCreateDto, WalletType>();
            // This option will prevent AutoMapper to replace fields that not will be updated to null
            CreateMap<WalletTypeUpdateDto, WalletType>()
                .ReverseMap()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<WalletType, WalletTypeResultDto>().ReverseMap();

            // Category
            CreateMap<CategoryCreateDto, Category>();
            // This option will prevent AutoMapper to replace fields that not will be updated to null
            CreateMap<CategoryUpdateDto, Category>()
                .ReverseMap()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<Category, CategoryResultDto>().ReverseMap();

            // Entrance
            CreateMap<EntranceCreateDto, Entrance>();
            // This option will prevent AutoMapper to replace fields that not will be updated to null
            CreateMap<EntranceUpdateDto, Entrance>()
                .ReverseMap()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<Entrance, EntranceResultDto>().ReverseMap();
        }
    }
}
