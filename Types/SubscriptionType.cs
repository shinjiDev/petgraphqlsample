using HotChocolate.Execution;
using HotChocolate.Subscriptions;
using HotChocolate.Types;

namespace HotChocolate.Validation.Types
{
    public class SubscriptionType
        : ObjectType
    {
        protected override void Configure(IObjectTypeDescriptor descriptor)
        {
            descriptor.Name("Subscription");

            descriptor.Field("newMessage")
                .Type<NonNullType<MessageType>>()
                .Resolve(context => context.GetEventMessage<MessageType>())
                .Subscribe(async context =>
                {
                    var receiver = context.Service<ITopicEventReceiver>();

                    ISourceStream stream =
                        await receiver.SubscribeAsync<string, MessageType>("messageAdded");

                    return stream;
                });

            descriptor.Field("disallowedSecondRootField")
                .Type<NonNullType<BooleanType>>()
                .Resolve(() => "foo");

            descriptor.Field("disallowedThirdRootField")
                .Type<NonNullType<BooleanType>>()
                .Resolve(() => "foo");
        }
    }
}
