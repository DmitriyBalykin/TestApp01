using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp01.Model
{
    public interface IMapper
    {
        object Map(object source, Type sourceType, Type destinationType);
    }
}
