using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Timezone
{
    interface IReader
    {
        List<Tuple<string, string>> Read();
    }
}
