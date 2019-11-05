using System;
namespace PrismFilms.DependencyServices
{
    public interface ITextToSpeech
    {
        void Speak(string text);
    }
}
