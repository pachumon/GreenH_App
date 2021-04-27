using GreenwayCoding.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GreenwayCoding.Services.Abstractions
{
    public interface IWebRetrieverService
    {
        Task<List<TriviaQuestion>> GetTriviaQueryResponse();
    }
}
