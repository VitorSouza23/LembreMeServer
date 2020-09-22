using System;
using System.Collections.Generic;
using System.Text;

namespace LembreMeServer.Domain.Commands
{
    public interface IValidable
    {
        bool IsValid();
    }
}
