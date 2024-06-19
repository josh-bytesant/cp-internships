using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Domain.Shared
{
    public static class ObjectSerializer
    {
        public static string SerializeThis(this object model)
        {
            return model is null ? string.Empty : JsonSerializer.Serialize(model);
        }
    }
}
