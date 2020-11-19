using LoggerEx.Enumerations;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoggerEx.Models.Contracts
{
    public interface IAppender
    {
        ILayout Layout { get; }

        Level Level { get; }

        void Append(IError error);
    }
}