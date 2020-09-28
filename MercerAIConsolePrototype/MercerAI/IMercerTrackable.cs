using System;
using System.Collections.Generic;
using System.Text;

namespace MercerAIConsolePrototype.MercerAI
{
    public interface IMercerTrackable
    {
        string Name { get; set; }

        List<Tag> Tags { get; set; }
    }
}
