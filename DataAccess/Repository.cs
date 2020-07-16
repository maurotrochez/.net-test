using System;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using System.Text;
using DataAccess.Builders;
using System.Threading.Tasks;

namespace DataAccess
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private IConfiguration _config;

        public Repository(IConfiguration config)
        {
            _config = config;
        }
        public async Task<List<T>> GetAllAsync()
        {
            var response = await HttpRequestFactory.Get(_config["ApiUrl"]);
            return response.ContentAsType<List<T>>();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            var response = await HttpRequestFactory.Get($"{_config["ApiUrl"]}{id}");
            return response.ContentAsType<T>();
        }
    }
}
