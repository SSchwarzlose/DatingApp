using System.Linq;
using AutoMapper;
using DatingApp.API.Dtos;
using DatingApp.API.Models;

namespace DatingApp.API.Helpers
{
    public class AutoMapperProfile: Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, UserForListDto>()
                .ForMember(dest => dest.PhotoUri, 
                    opt => opt.MapFrom(src => src.Photos.FirstOrDefault(p => p.IsMain).URI))
                .ForMember(dest => dest.Age, opt => 
                    opt.MapFrom(src => src.DateOfBirth.CalculateAge()));
            CreateMap<User, UserForDetailDto>()
                .ForMember(dest => dest.PhotoUri, 
                    opt => opt.MapFrom(src => src.Photos.FirstOrDefault(p => p.IsMain).URI))
                .ForMember(dest => dest.Age, opt => 
                    opt.MapFrom(src => src.DateOfBirth.CalculateAge()));
            CreateMap<Photo, PhotosForDetailDto>();
            CreateMap<UserForUpdateDto, User>();
            CreateMap<Photo, PhotoForReturnDto>();
            CreateMap<PhotoForCreationDto, Photo>();
            CreateMap<UserForRegisterDto, User>();
            CreateMap<MessageForCreationDto, Message>().ReverseMap();
            CreateMap<Message, MessageToReturnDto>()
                .ForMember(m => m.SenderPhotoUri, opt => opt.MapFrom(u => u.Sender.Photos.FirstOrDefault(p => p.IsMain).URI))
                .ForMember(m => m.RecipientPhotoUri, opt => opt.MapFrom(u => u.Recipient.Photos.FirstOrDefault(p => p.IsMain).URI));
        }
    }
}