using System;
using AutoMapper;
using WebDziennikAPI.Contracts.Requests;
using WebDziennikAPI.Core.Models.Common.Enums;

namespace WebDziennikAPI.Controllers.Mappings
{
	public class AccountsProfile : Profile
	{
		public AccountsProfile()
		{
			CreateMap<ISearchForPlayersByPhraseReq, IAccounts_SearchForPlayersByPhraseReq>()
				.ForMember(dest => dest.Language, opt => opt.MapFrom((src, dest) =>
					!Enum.TryParse(typeof(Language), src.Language, out var parsedLanguage)
						? Language.EN
						: parsedLanguage))
				.ForMember(dest => dest.Search, opt => opt.MapFrom((src, dest) =>
					!Enum.TryParse(typeof(SearchType), src.Search, out var parsedSearchType)
						? SearchType.StartsWith
						: parsedSearchType));
		}
	}
}
