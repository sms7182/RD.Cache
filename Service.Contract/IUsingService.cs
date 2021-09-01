using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contract
{
    public interface IUsingService
    {
        object GetContent(string key);
    }
}
