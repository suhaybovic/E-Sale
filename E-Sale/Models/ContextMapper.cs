using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DbCenter.ModelClasses;
using AutoMapper;
namespace E_Sale.Models
{
    public class ContextMapper
    {
        static DbCenter.ModelClasses.Photo MaptoDbcenterPhoto(Models.MVCPhoto photo)
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Models.MVCPhoto, DbCenter.ModelClasses.Photo>();
            });
            return Mapper.Map<DbCenter.ModelClasses.Photo>(photo);
        }

        public static DbCenter.ModelClasses.User MaptoDbcenterUser(Models.MVCUser user)
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Models.MVCUser, DbCenter.ModelClasses.User>()
                    .ForMember(dst => dst.Address, src => src.Ignore())
                    .ForMember(dst => dst.Photo, src => src.Ignore());
            });
            return Mapper.Map<DbCenter.ModelClasses.User>(user);
        }


        public static  DbCenter.ModelClasses.Company MaptoDbcenterCompany(Models.MVCCompany company)
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Models.MVCCompany, DbCenter.ModelClasses.Company>()
                    .ForMember(dst => dst.Address, src => src.Ignore())
                    .ForMember(dst => dst.Photo, src => src.Ignore());
            });
            return Mapper.Map<DbCenter.ModelClasses.Company>(company);
        }


        public static Models.MVCCompany MaptoMVCCompany(DbCenter.ModelClasses.Company company)
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<DbCenter.ModelClasses.Company,Models.MVCCompany>()
                    .ForMember(dst => dst.Address, src => src.Ignore())
                    .ForMember(dst => dst.Photo, src => src.Ignore());
            });
            return Mapper.Map<Models.MVCCompany>(company);
        }

        public static List<Models.MVCProduct> MaptoMVCProductList(List<DbCenter.ModelClasses.Product> list)
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<DbCenter.ModelClasses.Photo, Models.MVCPhoto>();
                cfg.CreateMap<DbCenter.ModelClasses.Address, Models.MVCAddress>();
                cfg.CreateMap<DbCenter.ModelClasses.Company, Models.MVCCompany>();
                cfg.CreateMap<DbCenter.ModelClasses.Product, Models.MVCProduct>();
            });

            return Mapper.Map<List<DbCenter.ModelClasses.Product>, List<Models.MVCProduct>>(list);

        }




        public static List<Models.MVCPost> MaptoMVCPostList(List<DbCenter.ModelClasses.Post> list)
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<DbCenter.ModelClasses.Photo, Models.MVCPhoto>();
                cfg.CreateMap<DbCenter.ModelClasses.Address, Models.MVCAddress>();
                cfg.CreateMap<DbCenter.ModelClasses.Comment, Models.MVCComment>();
                cfg.CreateMap<DbCenter.ModelClasses.Like, Models.MVCLike>();
                cfg.CreateMap<DbCenter.ModelClasses.User, Models.MVCUser>();
                cfg.CreateMap<DbCenter.ModelClasses.Company, Models.MVCCompany>();
                cfg.CreateMap<DbCenter.ModelClasses.Post, Models.MVCPost>();
            });
            return Mapper.Map<List<DbCenter.ModelClasses.Post>, List<Models.MVCPost>>(list);

        }

        
    }
}