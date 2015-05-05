using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Message_Board.Services
{
    public interface IEncryptor
    {
        string Encrypt(string input);
    }
}
