using System;
namespace Domain.Application
{
    public interface IApplication
    {
        string CurrentApplicationSessionId { get; }

        string GetCurrentPlatform();
        string GetRepositoryStorage();
    }
}
