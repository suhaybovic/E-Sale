using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using E_Sale.Models;
using DbCenter.ModelClasses;

namespace E_Sale.AutoMapper
{
    public static class AutoMapperApplication
    {

        public static void AutoMapper()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Models.MVCAddress, DbCenter.ModelClasses.Address>();
                cfg.CreateMap<DbCenter.ModelClasses.Address, Models.MVCAddress>();

                cfg.CreateMap<Models.MVCPhoto, DbCenter.ModelClasses.Photo>();
                cfg.CreateMap<DbCenter.ModelClasses.Photo, Models.MVCPhoto>();

                cfg.CreateMap<DbCenter.ModelClasses.User, Models.MVCUser>();
                cfg.CreateMap<Models.MVCUser, DbCenter.ModelClasses.User>();


                cfg.CreateMap<DbCenter.ModelClasses.Company, Models.MVCCompany>().
                cfg.CreateMap<Models.MVCCompany, DbCenter.ModelClasses.Company>();


                cfg.CreateMap<DbCenter.ModelClasses.Product, Models.MVCProduct>();
                cfg.CreateMap<Models.MVCProduct, DbCenter.ModelClasses.Product>();


                cfg.CreateMap<DbCenter.ModelClasses.Comment, Models.MVCComment>();
                cfg.CreateMap<Models.MVCComment, DbCenter.ModelClasses.Comment>();


                cfg.CreateMap<DbCenter.ModelClasses.Like, Models.MVCLike>();
                cfg.CreateMap<Models.MVCLike, DbCenter.ModelClasses.Like>();


                cfg.CreateMap<DbCenter.ModelClasses.Post, Models.MVCPost>();
                cfg.CreateMap<Models.MVCPost, DbCenter.ModelClasses.Post>();


                cfg.CreateMap<DbCenter.ModelClasses.Product, Models.MVCProduct>();
                cfg.CreateMap<Models.MVCProduct, DbCenter.ModelClasses.Product>();


            });
           
        }
    }

}