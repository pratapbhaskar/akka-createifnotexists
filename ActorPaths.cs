using System;

namespace Akka.Sample.Extensions
{
    public class ActorMetadata
    {
        public string Name { get; private set; }
        public string Path { get; private set; }

        public ActorMetadata Parent { get; private set; }
        public ActorMetadata(string name, ActorMetadata parent = null)
        {
            Name = name;
            var parentPath = parent != null ? parent.Path : "/user";
            Path = $"{parentPath}/{Name}";
        }
    }
}
