﻿namespace NServiceBus
{
    using System.Collections.Generic;
    using Pipeline;

    class OutgoingReplyContext : OutgoingContext, IOutgoingReplyContext
    {
        public OutgoingReplyContext(OutgoingLogicalMessage message, ReplyOptions options, IBehaviorContext parentContext)
            : base(options.MessageId, new Dictionary<string, string>(options.OutgoingHeaders), parentContext)
        {
            Guard.AgainstNull(nameof(parentContext), parentContext);
            Guard.AgainstNull(nameof(message), message);
            Guard.AgainstNull(nameof(options), options);

            Message = message;

            Merge(options.Context);
        }

        public OutgoingLogicalMessage Message { get; }
    }
}