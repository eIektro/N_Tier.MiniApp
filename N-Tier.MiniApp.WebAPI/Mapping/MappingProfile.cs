using AutoMapper;
using N_Tier.MiniApp.Core.Models;
using N_Tier.MiniApp.WebAPI.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace N_Tier.MiniApp.WebAPI.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Kullanici, KullaniciDTO>();
            CreateMap<Sirket, SirketDTO>();
            CreateMap<Gorev, GorevDTO>();

            CreateMap<KullaniciDTO, Kullanici>();
            CreateMap<SirketDTO, Sirket>();
            CreateMap<GorevDTO, Gorev>();

            /* MVC Controller daki Create işlemi için oluşturduğum DTO' yu mapliyorum */
            // TO-DO: Kullanici oluşturma işlemi için ekledim diğer işlemler için de eklemeliyim.
            CreateMap<CreateKullaniciDTO, Kullanici>();
        }
    }
}
