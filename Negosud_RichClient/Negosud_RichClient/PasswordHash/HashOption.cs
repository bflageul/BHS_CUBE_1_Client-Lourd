using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Negosud_RichClient.PasswordHash
{
    public sealed class HashOption
    {
        public int Iterations { get; set; } = 10000;
    }
}
