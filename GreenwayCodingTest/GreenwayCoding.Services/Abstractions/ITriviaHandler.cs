using GreenwayCoding.Models;

namespace GreenwayCoding.Services.Abstractions
{
    public interface ITriviaHandler
    {
        TriviaInfo RetrieveTriviaList();
        TriviaInfo ValidateTriviaResponse(TriviaInfo triviaInfo);

    }
}
