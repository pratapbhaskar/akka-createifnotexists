using System;
using System.Threading.Tasks;
using Akka.Actor;
using IotNext.Akka.Contracts;

namespace Akka.Sample.Extensions
{
    public static class ActorExtensions
    {
        public static async Task<IActorRef> CreateActorIfNotExistsAsync(this ActorSystem actorSystem,
            ActorMetadata actorPath, Props creationProps)
        {
            IActorRef actor = null;
            try
            {
                actor = await actorSystem.ActorSelection(actorPath.Path)
                    .ResolveOne(TimeSpan.FromSeconds(1));
            }
            catch (ActorNotFoundException)
            {
                actor = actorSystem.ActorOf(creationProps, actorPath.Name);
            }
            return actor;
        } 
    }
}