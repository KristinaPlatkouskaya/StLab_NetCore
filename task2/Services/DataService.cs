using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using task2.Models;

namespace task2.Services
{
    public class DataService : IDataService
    {
        private readonly IMapper _mapper;
        private readonly string url;
        public DataService(IMapper mapper, IConfiguration configuration)
        {
            this._mapper = mapper;
            url = configuration["StarShipsUrl"];
        }

        public StarShipsModel GetData()
        {
            ApiDataModel starShips = new ApiDataModel();
            using (var client = new WebClient())
            {
                var content = client.DownloadString(url);
                starShips = JsonConvert.DeserializeObject<ApiDataModel>(content);
                for (int i = 0; i < starShips.Results.Count; i++)
                {
                    starShips.Results[i].Index = i + 1;
                }
            }
            return _mapper.Map<ApiDataModel, StarShipsModel>(starShips); ;
        }
        public async Task<StarShipsModel> GetDataAsync()
        {
            ApiDataModel starShips = new ApiDataModel();
            using (var client = new WebClient())
            {
                PagingInfo pagingInfo = new PagingInfo()
                {
                    ItemsPerPage = 10,
                    CurrentPage = 1
                };
                do
                {
                    var content = await client.DownloadStringTaskAsync($"{url}/?page={pagingInfo.CurrentPage}");
                    ApiDataModel data = JsonConvert.DeserializeObject<ApiDataModel>(content);
                    pagingInfo.TotalItems = data.Count;
                    pagingInfo.CurrentPage++;
                    starShips.Results.AddRange(data.Results);
                }
                while (pagingInfo.CurrentPage <= pagingInfo.TotalPages);

                starShips.Count = pagingInfo.TotalItems;
                for (int i = 0; i < starShips.Results.Count; i++)
                {
                    starShips.Results[i].Index = i + 1;
                }
            }
            return _mapper.Map<ApiDataModel, StarShipsModel>(starShips);
        }
    }
}
