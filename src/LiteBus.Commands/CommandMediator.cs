﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using LiteBus.Commands.Abstractions;
using LiteBus.Messaging.Abstractions;
using LiteBus.Messaging.Abstractions.Exceptions;
using LiteBus.Messaging.Abstractions.Extensions;
using LiteBus.Messaging.Abstractions.Strategies;

namespace LiteBus.Commands
{
    /// <inheritdoc cref="ICommandMediator" />
    public class CommandMediator : ICommandMediator
    {
        private readonly IMessageMediator _messageMediator;

        public CommandMediator(IMessageMediator messageMediator)
        {
            _messageMediator = messageMediator;
        }

        public async Task SendAsync<TCommand>(TCommand command, CancellationToken cancellationToken = default) where TCommand : ICommand
        {
            var strategy = new SingleAsyncHandlerMediationStrategy<TCommand>();

            ICancellableMessage<TCommand> message = new CancellableMessage<TCommand>(command, cancellationToken);
            
            await _messageMediator.Mediate<ICancellableMessage<TCommand>, Task>(message, null, strategy);
        }

        public async Task<TCommandResult> SendAsync<TCommandResult>(ICommand<TCommandResult> command,
                                                                    CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}