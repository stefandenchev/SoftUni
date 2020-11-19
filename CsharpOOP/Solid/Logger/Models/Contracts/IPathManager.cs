using System;
using System.Collections.Generic;
using System.Text;

namespace LoggerEx.Models.Contracts
{
    public interface IPathManager
    {
        string CurrentDirectoryPath { get; }

        string CurrentFilePath { get; }

        string GetCurrentPath();

        void EnsureDirectoryAndFileExists();
    }
}