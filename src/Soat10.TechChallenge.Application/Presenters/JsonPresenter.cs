using Soat10.TechChallenge.Application.Interfaces;
using System.Text.Json;

namespace Soat10.TechChallenge.Application.Presenters
{
    public class JsonPresenter<T> : IJsonPresenter
    {
        private readonly T _input;
        public JsonPresenter(T input)
        {
            _input = input;
        }
        public string GetPresenter()
        {
            return JsonSerializer.Serialize(_input);
        }
    }
}
