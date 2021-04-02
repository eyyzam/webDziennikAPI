using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using WebDziennikAPI.Core.Extensions;
using WebDziennikAPI.Services.Accounts.Contracts.Requests;
using WebDziennikAPI.Services.Accounts.Contracts.Responses;
using WebDziennikAPI.Services.Common.Configuration;

namespace WebDziennikAPI.Services.Accounts
{
	public class AccountsService : IAccountsService
	{
		private readonly IHttpClientFactory _clientFactory;
		private readonly IConfigurationService _configurationService;
		private readonly UrlExtensions _urlExtension;

		public AccountsService(IHttpClientFactory clientFactory, IConfigurationService configurationSerivce)
		{
			_clientFactory = clientFactory;
			_configurationService = configurationSerivce;
			_urlExtension = new UrlExtensions();
		}

		public async Task<IAccountsService_SearchForPlayersByPhraseRes> SearchForPlayersByPhraseReq(IAccountsService_SearchForPlayersByPhraseReq request)
		{
			request.application_id = _configurationService.GetApplicationID();

			var httpClient = _clientFactory.CreateClient("default");
			var url = "https://api.worldoftanks.eu/wot/account/list/" + _urlExtension.BuildUrlQueryParams(request);
			var httpResponse = await httpClient.GetAsync(url);
			var httpResponseString = await httpResponse.Content.ReadAsStringAsync();

			return JsonConvert.DeserializeObject<AccountsService_SearchForPlayersByPhraseRes>(httpResponseString);
		}
	}
}
